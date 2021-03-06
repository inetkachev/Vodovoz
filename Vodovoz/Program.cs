﻿using System;
using Gtk;
using NLog;
using QSProjectsLib;
using Vodovoz.Parameters;
using Vodovoz.Additions;
using Vodovoz.DriverTerminal;
using QS.Project.Repositories;
using EmailService;
using QS.Project.Dialogs.GtkUI;
using QS.Utilities.Text;
using QSSupportLib;
using QS.Widgets.GtkUI;
using QS.DomainModel.UoW;
using Vodovoz.Domain.Employees;
using InstantSmsService;
using QS.Project.Services;

namespace Vodovoz
{
	partial class MainClass
	{
		private static Logger logger = LogManager.GetCurrentClassLogger ();
		public static MainWindow MainWin;
		public static IProgressBarDisplayable progressBarWin;

		[STAThread]
		public static void Main (string[] args)
		{
			Application.Init ();
			QSMain.SubscribeToUnhadledExceptions();
			QSMain.GuiThread = System.Threading.Thread.CurrentThread;
			MainSupport.SendErrorRequestEmail = false;

			//FIXME Удалить после того как будет удалена зависимость от библиотеки QSProjectLib
			QSMain.ProjectPermission = new System.Collections.Generic.Dictionary<string, UserPermission>();

			CreateProjectParam ();
			ConfigureViewModelWidgetResolver();
			ConfigureJournalColumnsConfigs();

			QSMain.SetupFromArgs(args);
			QS.Project.Search.GtkUI.SearchView.QueryDelay = 1500;

			// Создаем окно входа
			Login LoginDialog = new Login ();
			LoginDialog.Logo = Gdk.Pixbuf.LoadFromResource ("Vodovoz.icons.logo.png");
			LoginDialog.SetDefaultNames ("Vodovoz");
			LoginDialog.DefaultLogin = "user";
			LoginDialog.DefaultServer = "sql.vod.qsolution.ru";
			LoginDialog.UpdateFromGConf ();

			ResponseType LoginResult;
			LoginResult = (ResponseType)LoginDialog.Run ();
			if (LoginResult == ResponseType.DeleteEvent || LoginResult == ResponseType.Cancel)
				return;

			LoginDialog.Destroy ();

			QSProjectsLib.PerformanceHelper.StartMeasurement ("Замер запуска приложения");

			MainSupport.HandleStaleObjectStateException = EntityChangedExceptionHelper.ShowExceptionMessage;

			//Настройка базы
			CreateBaseConfig ();
			QSProjectsLib.PerformanceHelper.AddTimePoint (logger, "Закончена настройка базы");
			VodovozGtkServicesConfig.CreateVodovozDefaultServices();

			MainSupport.LoadBaseParameters();
			ParametersProvider.Instance.RefreshParameters();

			//Настройка карты
			GMap.NET.MapProviders.GMapProvider.UserAgent = String.Format("{0}/{1} used GMap.Net/{2} ({3})",
				QSSupportLib.MainSupport.ProjectVerion.Product,
				VersionHelper.VersionToShortString(QSSupportLib.MainSupport.ProjectVerion.Version),
				VersionHelper.VersionToShortString(System.Reflection.Assembly.GetAssembly(typeof(GMap.NET.MapProviders.GMapProvider)).GetName().Version),
				Environment.OSVersion.VersionString
			);
			GMap.NET.MapProviders.GMapProvider.Language = GMap.NET.LanguageType.Russian;
			QSProjectsLib.PerformanceHelper.AddTimePoint (logger, "Закончена настройка карты.");

			DatePicker.DefaultWidthRequest = 400;
			DateRangePicker.DefaultWidthRequest = 800;

			QSOsm.OsmWorker.ServiceHost = "osm.vod.qsolution.ru";
			QSOsm.OsmWorker.ServicePort = 7073;

			QSOsm.Osrm.OsrmMain.ServerUrl = "http://osrm.vod.qsolution.ru:5000";
			
			PerformanceHelper.StartPointsGroup ("Главное окно");

			MainSupport.TestVersion(null); //Проверяем версию базы
			QSMain.CheckServer(null); // Проверяем настройки сервера

			PerformanceHelper.AddTimePoint("Закончена загрузка параметров базы и проверка версии.");

			if(QSMain.User.Login == "root") {
				string Message = "Вы зашли в программу под администратором базы данных. У вас есть только возможность создавать других пользователей.";
				MessageDialog md = new MessageDialog(null, DialogFlags.Modal,
									   MessageType.Info,
									   ButtonsType.Ok,
									   Message);
				md.Run();
				md.Destroy();
				UsersDialog usersDlg = new UsersDialog();
				usersDlg.Show();
				usersDlg.Run();
				usersDlg.Destroy();
				return;
				// Пока неактуально + ломает работу для пользователей с админскими правами
				//} else if(ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("driver_terminal")) {
				//DriverTerminalWindow driverTerminal = new DriverTerminalWindow();
				//progressBarWin = driverTerminal;
				//driverTerminal.Title = "Печать документов МЛ";
				//QSMain.ErrorDlgParrent = driverTerminal;
				//driverTerminal.Show();
			} else {
				if(ChangePassword(LoginDialog.BaseName))
					StartMainWindow(LoginDialog.BaseName);
				else
					return;
			}

			PerformanceHelper.EndPointsGroup ();

			PerformanceHelper.AddTimePoint (logger, "Закончен старт SAAS. Конец загрузки.");

			QSSaaS.Session.StartSessionRefresh ();

			QSProjectsLib.PerformanceHelper.AddTimePoint (logger, "Закончен старт SAAS. Конец загрузки.");
			QSProjectsLib.PerformanceHelper.Main.PrintAllPoints (logger);

			Application.Run();
			QSSaaS.Session.StopSessionRefresh ();
			ClearTempDir();
		}

		private static bool ChangePassword(string loginDialogName)
		{
			using(var UoW = UnitOfWorkFactory.GetDefaultFactory.CreateForRoot<User>(QSMain.User.Id)) {
				if(!UoW.Root.NeedPasswordChange)
					return true;

				ChangePassword changePasswordWindow = new ChangePassword();
				changePasswordWindow.Title = "Требуется сменить пароль";
				QSMain.ErrorDlgParrent = changePasswordWindow;

				int response = changePasswordWindow.Run();
				if(response == (int)ResponseType.Ok) {
					UoW.Root.NeedPasswordChange = false;
					UoW.Save();
					changePasswordWindow.Destroy();
					return true;
				} else {
					QSSaaS.Session.StopSessionRefresh();
					ClearTempDir();
					return false;
				}
			}
		}

		private static void StartMainWindow(string loginDialogName)
		{
			//Настрока удаления
			Configure.ConfigureDeletion();
			PerformanceHelper.AddTimePoint(logger, "Закончена настройка удаления");

			if(ParametersProvider.Instance.ContainsParameter("email_send_enabled_database") && ParametersProvider.Instance.ContainsParameter("email_service_address")) {
				if(ParametersProvider.Instance.GetParameterValue("email_send_enabled_database") == loginDialogName) {
					EmailServiceSetting.Init(ParametersProvider.Instance.GetParameterValue("email_service_address"));
				}
			}
			if(ParametersProvider.Instance.ContainsParameter("instant_sms_enabled_database") && ParametersProvider.Instance.ContainsParameter("sms_service_address")) {
				if(ParametersProvider.Instance.GetParameterValue("instant_sms_enabled_database") == loginDialogName) {
					InstantSmsServiceSetting.Init(ParametersProvider.Instance.GetParameterValue("sms_service_address"));
				}
			}
			CreateTempDir();

			//Запускаем программу
			MainWin = new MainWindow();
			progressBarWin = MainWin;
			MainWin.Title += string.Format(" (БД: {0})", loginDialogName);
			QSMain.ErrorDlgParrent = MainWin;
			MainWin.Show();
		}
	}
}
