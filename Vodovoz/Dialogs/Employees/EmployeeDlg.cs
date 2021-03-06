﻿using System;
using System.Collections.Generic;
using System.Linq;
using Gamma.ColumnConfig;
using Gamma.Utilities;
using NLog;
using QS.Banks.Domain;
using Vodovoz.Domain.Contacts;
using QS.Dialog.GtkUI;
using QS.DomainModel.Entity.PresetPermissions;
using QS.DomainModel.UoW;
using QS.Project.DB;
using QS.Project.Repositories;
using QS.Validation.GtkUI;
using QSOrmProject;
using QSProjectsLib;
using Vodovoz.Dialogs.Employees;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Logistic;
using Vodovoz.Domain.Sale;
using Vodovoz.EntityRepositories;
using Vodovoz.EntityRepositories.WageCalculation;
using Vodovoz.Filters.ViewModels;
using Vodovoz.Repositories.Sale;
using Vodovoz.ViewModel;
using Vodovoz.ViewModels.WageCalculation;
using Vodovoz.Core.DataService;
using QS.Project.Services;
using Vodovoz.Infrastructure;
using Vodovoz.EntityRepositories.Employees;
using QS.Project.Dialogs.GtkUI.ServiceDlg;
using QS.Project.Services.GtkUI;
using QS.EntityRepositories;
using Vodovoz.Domain.Sms;
using System.Threading.Tasks;
using InstantSmsService;
using Vodovoz.Services;
using Vodovoz.Domain.Service.BaseParametersServices;
using Vodovoz.Domain.Permissions;
using Vodovoz.EntityRepositories.Permissions;

namespace Vodovoz
{
	public partial class EmployeeDlg : QS.Dialog.Gtk.EntityDialogBase<Employee>
	{
		IWageCalculationRepository wageParametersRepository;
		ISubdivisionService subdivisionService;
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public override bool HasChanges {
			get {
				phonesView.RemoveEmpty();
				return UoWGeneric.HasChanges || attachmentFiles.HasChanges || !String.IsNullOrEmpty(yentryUserLogin.Text);
			}
			set => base.HasChanges = value;
		}
		private MySQLUserRepository mySQLUserRepository;
		private EmployeeCategory[] hiddenCategory;
		private readonly EmployeeDocumentType[] hiddenForRussianDocument = { EmployeeDocumentType.RefugeeId, EmployeeDocumentType.RefugeeCertificate, EmployeeDocumentType.Residence };
		private readonly EmployeeDocumentType[] hiddenForForeignCitizen = { EmployeeDocumentType.MilitaryID, EmployeeDocumentType.NavyPassport, EmployeeDocumentType.OfficerCertificate };

		public EmployeeDlg()
		{
			this.Build();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<Employee>();
			mySQLUserRepository = new MySQLUserRepository(new MySQLProvider(new GtkRunOperationService(), new GtkQuestionDialogsInteractive()), new GtkInteractiveService());
			TabName = "Новый сотрудник";
			ConfigureDlg();
		}

		public EmployeeDlg(int id)
		{
			this.Build();
			logger.Info("Загрузка информации о сотруднике...");
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<Employee>(id);
			mySQLUserRepository = new MySQLUserRepository(new MySQLProvider(new GtkRunOperationService(), new GtkQuestionDialogsInteractive()), new GtkInteractiveService());
			ConfigureDlg();
		}

		public EmployeeDlg(Employee sub) : this(sub.Id)
		{
		}

		public EmployeeDlg(IUnitOfWorkGeneric<Employee> uow)
		{
			this.Build();
			UoWGeneric = uow;
			if(!ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_change_trainee_to_driver")) {
				hiddenCategory = new EmployeeCategory[] { EmployeeCategory.driver, EmployeeCategory.forwarder };
			}
			mySQLUserRepository = new MySQLUserRepository(new MySQLProvider(new GtkRunOperationService(), new GtkQuestionDialogsInteractive()), new GtkInteractiveService());
			ConfigureDlg();
		}

		private void ConfigureDlg()
		{
			OnRussianCitizenToggled(null, EventArgs.Empty);
			dataentryDrivingNumber.MaxLength = 20;
			dataentryDrivingNumber.Binding.AddBinding(Entity, e => e.DrivingNumber, w => w.Text).InitializeFromSource();
			UoWGeneric.Root.PropertyChanged += OnPropertyChanged;
			notebookMain.Page = 0;
			notebookMain.ShowTabs = false;

			wageParametersRepository = WageSingletonRepository.GetInstance();
			subdivisionService = SubdivisionParametersProvider.Instance;

			checkIsFired.Binding.AddBinding(Entity, e => e.IsFired, w => w.Active).InitializeFromSource();
			checkVisitingMaster.Binding.AddBinding(Entity, e => e.VisitingMaster, w => w.Active).InitializeFromSource();
			chkDriverForOneDay.Binding.AddBinding(Entity, e => e.IsDriverForOneDay, w => w.Active).InitializeFromSource();
			cmbDriverOf.ItemsEnum = typeof(CarTypeOfUse);
			cmbDriverOf.Binding.AddBinding(Entity, e => e.DriverOf, w => w.SelectedItemOrNull).InitializeFromSource();

			dataentryLastName.Binding.AddBinding(Entity, e => e.LastName, w => w.Text).InitializeFromSource();
			dataentryName.Binding.AddBinding(Entity, e => e.Name, w => w.Text).InitializeFromSource();
			dataentryPatronymic.Binding.AddBinding(Entity, e => e.Patronymic, w => w.Text).InitializeFromSource();

			entryAddressCurrent.Binding.AddBinding(Entity, e => e.AddressCurrent, w => w.Text).InitializeFromSource();
			entryAddressRegistration.Binding.AddBinding(Entity, e => e.AddressRegistration, w => w.Text).InitializeFromSource();
			entryInn.Binding.AddBinding(Entity, e => e.INN, w => w.Text).InitializeFromSource();

			dataentryAndroidLogin.Binding.AddBinding(Entity, e => e.AndroidLogin, w => w.Text).InitializeFromSource();
			dataentryAndroidPassword.Binding.AddBinding(Entity, e => e.AndroidPassword, w => w.Text).InitializeFromSource();
			yentryDeliveryDaySchedule.SubjectType = typeof(DeliveryDaySchedule);
			yentryDeliveryDaySchedule.Binding.AddBinding(Entity, e => e.DefaultDaySheldule, w => w.Subject).InitializeFromSource();

			var filterDefaultForwarder = new EmployeeFilterViewModel();
			filterDefaultForwarder.SetAndRefilterAtOnce(
				x => x.RestrictCategory = EmployeeCategory.forwarder,
				x => x.ShowFired = false
			);
			repEntDefaultForwarder.RepresentationModel = new EmployeesVM(filterDefaultForwarder);
			repEntDefaultForwarder.Binding.AddBinding(Entity, e => e.DefaultForwarder, w => w.Subject).InitializeFromSource();

			referenceNationality.SubjectType = typeof(Nationality);
			referenceNationality.Binding.AddBinding(Entity, e => e.Nationality, w => w.Subject).InitializeFromSource();
			referenceCitizenship.SubjectType = typeof(Citizenship);
			referenceCitizenship.Binding.AddBinding(Entity, e => e.Citizenship, w => w.Subject).InitializeFromSource();
			yentrySubdivision.SubjectType = typeof(Subdivision);
			yentrySubdivision.Binding.AddBinding(Entity, e => e.Subdivision, w => w.Subject).InitializeFromSource();
			referenceUser.SubjectType = typeof(User);
			referenceUser.CanEditReference = false;
			referenceUser.Binding.AddBinding(Entity, e => e.User, w => w.Subject).InitializeFromSource();
			referenceUser.Sensitive = ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_manage_users");

			comboCategory.ItemsEnum = typeof(EmployeeCategory);
			if(hiddenCategory != null && hiddenCategory.Any()) {
				comboCategory.AddEnumToHideList(hiddenCategory.Cast<object>().ToArray());
			}
			comboCategory.Binding.AddBinding(Entity, e => e.Category, w => w.SelectedItem).InitializeFromSource();
			comboCategory.ChangedByUser += (sender, e) => {
				if(Entity.Category != EmployeeCategory.driver)
					cmbDriverOf.SelectedItemOrNull = null;
			};

			yenumcombobox13.ItemsEnum = typeof(RegistrationType);
			yenumcombobox13.Binding.AddBinding(Entity, e => e.Registration, w => w.SelectedItemOrNull).InitializeFromSource();

			ydatepicker1.Binding.AddBinding(Entity, e => e.BirthdayDate, w => w.DateOrNull).InitializeFromSource();

			photoviewEmployee.Binding.AddBinding(Entity, e => e.Photo, w => w.ImageFile).InitializeFromSource();
			photoviewEmployee.GetSaveFileName = () => Entity.FullName;

			attachmentFiles.AttachToTable = OrmConfig.GetDBTableName(typeof(Employee));
			if(Entity.Id != 0) {
				attachmentFiles.ItemId = UoWGeneric.Root.Id;
				attachmentFiles.UpdateFileList();
			}
			phonesView.UoW = UoWGeneric;
			if(UoWGeneric.Root.Phones == null)
				UoWGeneric.Root.Phones = new List<Phone>();
			phonesView.Phones = UoWGeneric.Root.Phones;
			accountsView.ParentReference = new ParentReferenceGeneric<Employee, Account>(UoWGeneric, o => o.Accounts);
			accountsView.SetTitle("Банковские счета сотрудника");
			ydateFirstWorkDay.Binding.AddBinding(Entity, e => e.FirstWorkDay, w => w.DateOrNull).InitializeFromSource();
			yspinTripsPriority.Binding.AddBinding(Entity, e => e.TripPriority, w => w.ValueAsShort).InitializeFromSource();
			yspinDriverSpeed.Binding.AddBinding(Entity, e => e.DriverSpeed, w => w.Value, new MultiplierToPercentConverter()).InitializeFromSource();
			checkbuttonRussianCitizen.Binding.AddBinding(Entity, e => e.IsRussianCitizen, w => w.Active).InitializeFromSource();

			ylblUserLogin.TooltipText = "При сохранении сотрудника создаёт нового пользователя с введённым логином и отправляет сотруднику SMS с сгенерированным паролем";
			yentryUserLogin.Binding.AddBinding(Entity, e => e.LoginForNewUser, w => w.Text);
			yentryUserLogin.Sensitive = CanCreateNewUser;

			Entity.CheckAndFixDriverPriorities();
			ytreeviewDistricts.ColumnsConfig = FluentColumnsConfig<DriverDistrictPriority>.Create()
				.AddColumn("Район").AddTextRenderer(x => x.District.DistrictName)
				.AddColumn("Приоритет").AddNumericRenderer(x => x.Priority + 1)
				.Finish();
			ytreeviewDistricts.Reorderable = true;
			ytreeviewDistricts.SetItemsSource(Entity.ObservableDistricts);

			ytreeviewEmployeeDocument.ColumnsConfig = FluentColumnsConfig<EmployeeDocument>.Create()
				.AddColumn("Документ").AddTextRenderer(x => x.Document.GetEnumTitle())
				.AddColumn("Доп. название").AddTextRenderer(x => x.Name)
				.Finish();
			ytreeviewEmployeeDocument.SetItemsSource(Entity.ObservableDocuments);

			ytreeviewEmployeeContract.ColumnsConfig = FluentColumnsConfig<EmployeeContract>.Create()
				.AddColumn("Договор").AddTextRenderer(x => x.EmployeeContractTemplate.TemplateType.GetEnumTitle())
				.AddColumn("Название").AddTextRenderer(x => x.Name)
				.AddColumn("Дата начала").AddTextRenderer(x => x.FirstDay.ToString("dd/MM/yyyy"))
				.AddColumn("Дата конца").AddTextRenderer(x => x.LastDay.ToString("dd/MM/yyyy"))
				.Finish();
			ytreeviewEmployeeContract.SetItemsSource(Entity.ObservableContracts);

			wageParametersView.ViewModel = new EmployeeWageParametersViewModel
			(
				Entity, 
				this, 
				UoW, 
				new HierarchicalPresetPermissionValidator(EmployeeSingletonRepository.GetInstance(), new PermissionRepository()),
				UserSingletonRepository.GetInstance(),
				ServicesConfig.CommonServices,
				NavigationManagerProvider.NavigationManager
			);

			logger.Info("Ok");
		}

		bool CanCreateNewUser => Entity.User == null && ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_manage_users");

		void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			logger.Debug("Property {0} changed", e.PropertyName);
		}

		public override bool Save()
		{
			//Проверяем, чтобы в БД не попала пустая строка
			if(string.IsNullOrWhiteSpace(Entity.AndroidLogin))
				Entity.AndroidLogin = null;

			var valid = new QSValidator<Employee>(UoWGeneric.Root, Entity.GetValidationContextItems(subdivisionService));
			if(valid.RunDlgIfNotValid((Gtk.Window)this.Toplevel))
				return false;

			if(Entity.User != null) {
				var associatedEmployees = EmployeeSingletonRepository.GetInstance().GetEmployeesForUser(UoW, Entity.User.Id);
				if(associatedEmployees.Any(e => e.Id != Entity.Id)) {
					string mes = String.Format("Пользователь {0} уже связан с сотрудником {1}, при привязке этого сотрудника к пользователю, старая связь будет удалена. Продолжить?",
									 Entity.User.Name,
									 String.Join(", ", associatedEmployees.Select(e => e.ShortName))
								 );
					if(MessageDialogHelper.RunQuestionDialog(mes)) {
						foreach(var ae in associatedEmployees.Where(e => e.Id != Entity.Id)) {
							ae.User = null;
							UoWGeneric.Save(ae);
						}
					} else
						return false;
				}
			}
			Entity.CreateDefaultWageParameter(WageSingletonRepository.GetInstance(), new BaseParametersProvider(), ServicesConfig.InteractiveService);

			phonesView.RemoveEmpty();
			UoWGeneric.Save(Entity);

			#region Попытка сохранить логин для нового юзера

			if(!String.IsNullOrEmpty(Entity.LoginForNewUser) && InstantSmsServiceSetting.SendingAllowed) {
				var user = new User {
					Login = Entity.LoginForNewUser,
					Name = Entity.FullName,
					NeedPasswordChange = true
				};
				bool cont = MessageDialogHelper.RunQuestionDialog($"При сохранении работника будет создан \nпользователь с логином {user.Login} \nи на " +
					$"указанный номер +7{Entity.GetPhoneForSmsNotification()}\nбудет выслана SMS с временным паролем\n\t\t\tПродолжить?");
				if(!cont)
					return false;

				var password = new Tools.PasswordGenerator().GeneratePassword(5);
				//Сразу пишет в базу
				var result = mySQLUserRepository.CreateLogin(user.Login, password);
				if(result) {
					try {
						mySQLUserRepository.UpdatePrivileges(user.Login, false);
					} catch {
						mySQLUserRepository.DropUser(user.Login);
						throw;
					}
					UoWGeneric.Save(user);

					logger.Info("Идёт отправка sms (до 10 секунд)...");
					bool sendResult = false;
					try {
						sendResult = SendPasswordByPhone(password);
					} catch(TimeoutException) {
						RemoveUserData(user);
						logger.Info("Ошибка при отправке sms");
						MessageDialogHelper.RunErrorDialog("Сервис отправки Sms временно недоступен\n");
						return false;
					} catch {
						RemoveUserData(user);
						logger.Info("Ошибка при отправке sms");
						throw;
					}
					if(!sendResult) {
						//Если не получилось отправить смс с паролем - удаляем пользователя
						RemoveUserData(user);
						logger.Info("Ошибка при отправке sms");
						return false;
					}
					logger.Info("Sms успешно отправлено");
					Entity.User = user;
				} else {
					MessageDialogHelper.RunErrorDialog("Не получилось создать нового пользователя");
					return false;
				}
			}

			#endregion

			logger.Info("Сохраняем сотрудника...");
			try {
				UoWGeneric.Save();
				if(UoWGeneric.IsNew) {
					attachmentFiles.ItemId = UoWGeneric.Root.Id;
				}
				attachmentFiles.SaveChanges();
			} catch(Exception ex) {
				logger.Error(ex, "Не удалось записать сотрудника.");
				QSMain.ErrorMessage((Gtk.Window)this.Toplevel, ex);
				return false;
			}
			logger.Info("Ok");
			return true;
		}

		private void RemoveUserData(User user)
		{
			UoWGeneric.Delete(user);
			UoWGeneric.Session.Flush();
			mySQLUserRepository.DropUser(user.Login);
		}

		private bool SendPasswordByPhone(string password)
		{
			SmsNotifier smsNotifier = new SmsNotifier(new BaseParametersProvider());
			SmsMessageResult result;
			result = smsNotifier.SendPasswordToEmployee(Entity, password);
			if(result.MessageStatus == SmsMessageStatus.Ok) {
				MessageDialogHelper.RunInfoDialog("Sms с паролем отправлена успешно");
				return true;
			} else {
				MessageDialogHelper.RunErrorDialog(result.ErrorDescription, "Ошибка при отправке Sms");
				return false;
			}
		}

		protected void OnRussianCitizenToggled(object sender, EventArgs e)
		{
			if(Entity.IsRussianCitizen == false) {
				labelCitizenship.Visible = true;
				referenceCitizenship.Visible = true;
			} else {
				labelCitizenship.Visible = false;
				referenceCitizenship.Visible = false;
				Entity.Citizenship = null;
			}
		}

		#region RadioTabToggled
		protected void OnRadioTabInfoToggled(object sender, EventArgs e)
		{
			if(radioTabInfo.Active)
				notebookMain.CurrentPage = 0;
		}

		protected void OnRadioTabFilesToggled(object sender, EventArgs e)
		{
			if(radioTabFiles.Active)
				notebookMain.CurrentPage = 3;
		}

		protected void OnRadioTabAccountingToggled(object sender, EventArgs e)
		{
			if(radioTabAccounting.Active)
				notebookMain.CurrentPage = 2;
		}

		protected void OnRadioTabLogisticToggled(object sender, EventArgs e)
		{
			if(radioTabLogistic.Active)
				notebookMain.CurrentPage = 1;
		}

		protected void OnRadioTabEmployeeDocumentToggled(object sender, EventArgs e)
		{
			if(radioTabEmployeeDocument.Active)
				notebookMain.CurrentPage = 5;
		}

		protected void OnRadioTabContractsToggled(object sender, EventArgs e)
		{
			if(radioTabContracts.Active)
				notebookMain.CurrentPage = 4;
		}
		#endregion

		#region Document
		protected void OnButtonAddDocumentClicked(object sender, EventArgs e)
		{
			EmployeeDocDlg dlg = new EmployeeDocDlg(UoW, Entity.IsRussianCitizen ? hiddenForRussianDocument : hiddenForForeignCitizen);
			dlg.Save += (object sender1, EventArgs e1) => Entity.ObservableDocuments.Add(dlg.Entity);
			TabParent.AddSlaveTab(this, dlg);
		}

		protected void OnButtonRemoveDocumentClicked(object sender, EventArgs e)
		{
			var toRemoveDocument = ytreeviewEmployeeDocument.GetSelectedObjects<EmployeeDocument>().ToList();
			toRemoveDocument.ForEach(x => Entity.ObservableDocuments.Remove(x));
		}

		protected void OnButtonEditDocumentClicked(object sender, EventArgs e)
		{
			if(ytreeviewEmployeeDocument.GetSelectedObject<EmployeeDocument>() != null) {
				EmployeeDocDlg dlg = new EmployeeDocDlg(((EmployeeDocument)ytreeviewEmployeeDocument.GetSelectedObjects()[0]).Id, UoW);
				TabParent.AddSlaveTab(this, dlg);
			}
		}

		protected void OnEmployeeDocumentRowActivated(object o, Gtk.RowActivatedArgs args)
		{
			buttonDocumentEdit.Click();
		}

		#endregion

		#region Contract
		protected void OnAddContractButtonCliked(object sender, EventArgs e)
		{
			List<EmployeeDocument> doc = Entity.GetMainDocuments();
			if(!doc.Any()) {
				MessageDialogHelper.RunInfoDialog("Отсутствует главный документ");
				return;
			} 
			if(Entity.Registration != RegistrationType.Contract) {
				MessageDialogHelper.RunInfoDialog("Должен быть указан тип регистрации: 'ГПК' ");//FIXME: Временно до задачи I-1556
				return;
			}
			EmployeeContractDlg dlg = new EmployeeContractDlg(doc[0], Entity, UoW);
			dlg.Save += (object sender1, EventArgs e1) => Entity.ObservableContracts.Add(dlg.Entity);
			TabParent.AddSlaveTab(this, dlg);
		}

		protected void OnButtonRemoveContractClicked(object sender, EventArgs e)
		{
			var toRemoveContract = ytreeviewEmployeeContract.GetSelectedObjects<EmployeeContract>().ToList();
			toRemoveContract.ForEach(x => Entity.ObservableContracts.Remove(x));
		}

		protected void OnButtonEditContractClicked(object sender, EventArgs e)
		{
			if(ytreeviewEmployeeContract.GetSelectedObject<EmployeeContract>() != null) {
				EmployeeContractDlg dlg = new EmployeeContractDlg(((EmployeeContract)ytreeviewEmployeeContract.GetSelectedObjects()[0]).Id, UoW);
				TabParent.AddSlaveTab(this, dlg);
			}

		}

		protected void OnEmployeeContractRowActivated(object o, Gtk.RowActivatedArgs args)
		{
			buttonContractEdit.Click();
		}

		#endregion

		#region Driver & forwarder
		protected void OnButtonAddDistrictClicked(object sender, EventArgs e)
		{
			var SelectDistrict = new OrmReference(
				UoW,
				ScheduleRestrictionRepository.AreaWithGeometryQuery()
			) {
				Mode = OrmReferenceMode.MultiSelect
			};
			SelectDistrict.ObjectSelected += SelectDistrict_ObjectSelected;
			TabParent.AddSlaveTab(this, SelectDistrict);
		}

		protected void OnButtonRemoveDistrictClicked(object sender, EventArgs e)
		{
			var toRemoveDistricts = ytreeviewDistricts.GetSelectedObjects<DriverDistrictPriority>().ToList();
			toRemoveDistricts.ForEach(x => Entity.ObservableDistricts.Remove(x));
		}

		void SelectDistrict_ObjectSelected(object sender, OrmReferenceObjectSectedEventArgs e)
		{
			var addDistricts = e.GetEntities<ScheduleRestrictedDistrict>();
			addDistricts.Where(x => Entity.Districts.All(d => d.District.Id != x.Id))
						.Select(x => new DriverDistrictPriority {
							Driver = Entity,
							District = x
						})
						.ToList()
						.ForEach(x => Entity.ObservableDistricts.Add(x))
						;
		}

		protected void OnComboCategoryEnumItemSelected(object sender, Gamma.Widgets.ItemSelectedEventArgs e)
		{
			radioTabLogistic.Visible
				= lblDriverOf.Visible
				= hboxDriversParameters.Visible
				= ((EmployeeCategory)e.SelectedItem == EmployeeCategory.driver);

			wageParametersView.Sensitive = ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_edit_wage");
		}

		protected void OnRadioWageParametersClicked(object sender, EventArgs e)
		{
			if(radioWageParameters.Active)
				notebookMain.CurrentPage = 6;
		}

		#endregion
	}
}