﻿using System;
using System.Collections.Generic;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using QSOrmProject;
using QS.Validation.GtkUI;
using Vodovoz.Domain.Cash;
using Vodovoz.Domain.Employees;
using Vodovoz.Filters.ViewModels;
using Vodovoz.Repositories.HumanResources;
using QS.Services;
using Vodovoz.EntityRepositories;

namespace Vodovoz
{
	public partial class CashExpenseDlg : QS.Dialog.Gtk.EntityDialogBase<Expense>
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();
		private decimal currentEmployeeWage = default(decimal);
		private bool canEdit = true;

		public CashExpenseDlg (IPermissionService permissionService)
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<Expense>();
			Entity.Casher = EmployeeRepository.GetEmployeeForCurrentUser (UoW);
			if(Entity.Casher == null)
			{
				MessageDialogHelper.RunErrorDialog ("Ваш пользователь не привязан к действующему сотруднику, вы не можете создавать кассовые документы, так как некого указывать в качестве кассира.");
				FailInitialize = true;
				return;
			}

			var userPermission = permissionService.ValidateUserPermission(typeof(Expense), UserSingletonRepository.GetInstance().GetCurrentUser(UoW).Id);
			if(!userPermission.CanCreate) {
				MessageDialogHelper.RunErrorDialog("Отсутствуют права на создание приходного ордера");
				FailInitialize = true;
				return;
			}

			if(!accessfilteredsubdivisionselectorwidget.Configure(UoW, false,  typeof(Expense))) {

				MessageDialogHelper.RunErrorDialog(accessfilteredsubdivisionselectorwidget.ValidationErrorMessage);
				FailInitialize = true;
				return;
			}

			Entity.Date = DateTime.Now;
			ConfigureDlg ();
		}

		public CashExpenseDlg (int id, IPermissionService permissionService)
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<Expense>(id);

			if(!accessfilteredsubdivisionselectorwidget.Configure(UoW, false, typeof(Expense))) {

				MessageDialogHelper.RunErrorDialog(accessfilteredsubdivisionselectorwidget.ValidationErrorMessage);
				FailInitialize = true;
				return;
			}

			var userPermission = permissionService.ValidateUserPermission(typeof(Expense), UserSingletonRepository.GetInstance().GetCurrentUser(UoW).Id);
			if(!userPermission.CanRead) {
				MessageDialogHelper.RunErrorDialog("Отсутствуют права на просмотр приходного ордера");
				FailInitialize = true;
				return;
			}
			canEdit = userPermission.CanUpdate;

			ConfigureDlg ();
		}

		public CashExpenseDlg (Expense sub, IPermissionService permissionService) : this (sub.Id, permissionService) {}

		void ConfigureDlg()
		{
			accessfilteredsubdivisionselectorwidget.OnSelected += Accessfilteredsubdivisionselectorwidget_OnSelected;
			if(Entity.RelatedToSubdivision != null) {
				accessfilteredsubdivisionselectorwidget.SelectIfPossible(Entity.RelatedToSubdivision);
			}

			enumcomboOperation.ItemsEnum = typeof(ExpenseType);
			enumcomboOperation.Binding.AddBinding (Entity, s => s.TypeOperation, w => w.SelectedItem).InitializeFromSource ();

			var filterCasher = new EmployeeFilterViewModel();
			filterCasher.ShowFired = false;
			yentryCasher.RepresentationModel = new ViewModel.EmployeesVM(filterCasher);
			yentryCasher.Binding.AddBinding(Entity, s => s.Casher, w => w.Subject).InitializeFromSource();

			var filterEmployee = new EmployeeFilterViewModel();
			filterEmployee.ShowFired = false;
			yentryEmployee.RepresentationModel = new ViewModel.EmployeesVM(filterEmployee);
			yentryEmployee.Binding.AddBinding(Entity, s => s.Employee, w => w.Subject).InitializeFromSource();
			yentryEmployee.ChangedByUser += (sender, e) => UpdateEmployeeBalaceInfo();

			ydateDocument.Binding.AddBinding (Entity, s => s.Date, w => w.Date).InitializeFromSource ();

			OrmMain.GetObjectDescription<ExpenseCategory> ().ObjectUpdated += OnExpenseCategoryUpdated;
			OnExpenseCategoryUpdated (null, null);
			comboExpense.Binding.AddBinding (Entity, s => s.ExpenseCategory, w => w.SelectedItem).InitializeFromSource ();

			yspinMoney.Binding.AddBinding (Entity, s => s.Money, w => w.ValueAsDecimal).InitializeFromSource ();

			ytextviewDescription.Binding.AddBinding (Entity, s => s.Description, w => w.Buffer.Text).InitializeFromSource ();

			ExpenseType type = (ExpenseType)enumcomboOperation.SelectedItem;
			ylabelEmployeeWageBalance.Visible = type == ExpenseType.EmployeeAdvance
											 || type == ExpenseType.Salary
											 || type == ExpenseType.Advance;
			UpdateEmployeeBalaceInfo();
			UpdateSubdivision();

			if(!canEdit) {
				table1.Sensitive = false;
				accessfilteredsubdivisionselectorwidget.Sensitive = false;
				buttonSave.Sensitive = false;
				ytextviewDescription.Editable = false;
			}
		}

		void OnExpenseCategoryUpdated (object sender, QSOrmProject.UpdateNotification.OrmObjectUpdatedEventArgs e)
		{
			comboExpense.ItemsList = Repository.Cash.CategoryRepository.ExpenseCategories (UoW);
		}

		void Accessfilteredsubdivisionselectorwidget_OnSelected(object sender, EventArgs e)
		{
			UpdateSubdivision();
		}

		private void UpdateSubdivision()
		{
			if(accessfilteredsubdivisionselectorwidget.SelectedSubdivision != null && accessfilteredsubdivisionselectorwidget.NeedChooseSubdivision) {
				Entity.RelatedToSubdivision = accessfilteredsubdivisionselectorwidget.SelectedSubdivision;
			}
		}

		public override bool Save ()
		{
			var valid = new QSValidator<Expense> (UoWGeneric.Root);
			if (valid.RunDlgIfNotValid ((Gtk.Window)this.Toplevel))
				return false;

			Entity.UpdateWagesOperations(UoW);

			logger.Info ("Сохраняем расходный ордер...");
			UoWGeneric.Save();
			logger.Info ("Ok");
			return true;

		}

		protected void OnEnumcomboOperationEnumItemSelected (object sender, Gamma.Widgets.ItemSelectedEventArgs e)
		{
			UpdateEmployeeBalaceInfo();

			switch((ExpenseType)e.SelectedItem)
			{
				case ExpenseType.Advance: 
					labelEmployee.LabelProp = "Подотчетное лицо:";
					ylabelEmployeeWageBalance.Visible = true;
					break;
				case ExpenseType.Expense :
					labelEmployee.LabelProp = "Сотрудник:";
					ylabelEmployeeWageBalance.Visible = false;
					break;
				case ExpenseType.EmployeeAdvance:
					labelEmployee.LabelProp = "Сотрудник:";
					ylabelEmployeeWageBalance.Visible = true;
					break;
				case ExpenseType.Salary:
					labelEmployee.LabelProp = "Сотрудник:";
					ylabelEmployeeWageBalance.Visible = true;
					break;
			}
		}

		private void UpdateEmployeeBalaceInfo()
		{
			currentEmployeeWage = 0;
			string labelTemplate = "Текущий баланс сотрудника: {0}";
			Employee employee = yentryEmployee.Subject as Employee;

			if (employee != null)
			{
				currentEmployeeWage =
					Repository.Operations.WagesMovementRepository.GetCurrentEmployeeWageBalance(UoW, employee.Id);
			}

			ylabelEmployeeWageBalance.LabelProp = string.Format(labelTemplate, currentEmployeeWage);
		}

		protected void OnButtonPrintClicked (object sender, EventArgs e)
		{
			if (UoWGeneric.HasChanges && CommonDialogs.SaveBeforePrint (typeof(Expense), "квитанции"))
				Save ();

			var reportInfo = new QS.Report.ReportInfo {
				Title = String.Format ("Квитанция №{0} от {1:d}", Entity.Id, Entity.Date),
				Identifier = "Cash.Expense",
				Parameters = new Dictionary<string, object> {
					{ "id",  Entity.Id }
				}
			};
				
			var report = new QSReport.ReportViewDlg (reportInfo);
			TabParent.AddTab (report, this, false);
		}
	}
}

