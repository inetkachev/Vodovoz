﻿using System;
using System.Collections.Generic;
using QS.Dialog.Gtk;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using QSOrmProject;
using QS.Validation.GtkUI;
using Vodovoz.Domain.Cash;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Orders;
using Vodovoz.Filters.ViewModels;
using Vodovoz.Repositories.HumanResources;
using Vodovoz.ViewModel;
using QS.Services;
using Vodovoz.EntityRepositories;

namespace Vodovoz.Dialogs.Cash
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class CashIncomeSelfDeliveryDlg : EntityDialogBase<Income>
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
		private bool canEdit = true;

		public CashIncomeSelfDeliveryDlg(IPermissionService permissionService)
		{
			this.Build();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<Income>();
			Entity.Casher = EmployeeRepository.GetEmployeeForCurrentUser(UoW);
			if(Entity.Casher == null) {
				MessageDialogHelper.RunErrorDialog("Ваш пользователь не привязан к действующему сотруднику, вы не можете создавать кассовые документы, так как некого указывать в качестве кассира.");
				FailInitialize = true;
				return;
			}

			var userPermission = permissionService.ValidateUserPermission(typeof(Income), UserSingletonRepository.GetInstance().GetCurrentUser(UoW).Id);
			if(!userPermission.CanCreate) {
				MessageDialogHelper.RunErrorDialog("Отсутствуют права на создание приходного ордера");
				FailInitialize = true;
				return;
			}

			if(!accessfilteredsubdivisionselectorwidget.Configure(UoW, false, typeof(Income))) {

				MessageDialogHelper.RunErrorDialog(accessfilteredsubdivisionselectorwidget.ValidationErrorMessage);
				FailInitialize = true;
				return;
			}
			accessfilteredsubdivisionselectorwidget.OnSelected += Accessfilteredsubdivisionselectorwidget_OnSelected;

			Entity.Date = DateTime.Now;
			ConfigureDlg();
		}

		public CashIncomeSelfDeliveryDlg(Order forOrder, IPermissionService permissionService) : this(permissionService)
		{
			Entity.Order = UoW.GetById<Order>(forOrder.Id);
		}

		public CashIncomeSelfDeliveryDlg(int id, IPermissionService permissionService)
		{
			this.Build();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<Income>(id);

			if(!accessfilteredsubdivisionselectorwidget.Configure(UoW, false, typeof(Income))) {

				MessageDialogHelper.RunErrorDialog(accessfilteredsubdivisionselectorwidget.ValidationErrorMessage);
				FailInitialize = true;
				return;
			}
			accessfilteredsubdivisionselectorwidget.OnSelected += Accessfilteredsubdivisionselectorwidget_OnSelected;

			var userPermission = permissionService.ValidateUserPermission(typeof(Income), UserSingletonRepository.GetInstance().GetCurrentUser(UoW).Id);
			if(!userPermission.CanRead) {
				MessageDialogHelper.RunErrorDialog("Отсутствуют права на просмотр приходного ордера");
				FailInitialize = true;
				return;
			}
			canEdit = userPermission.CanUpdate;

			ConfigureDlg();
		}

		public CashIncomeSelfDeliveryDlg(Income sub, IPermissionService permissionService) : this(sub.Id, permissionService) { }

		void ConfigureDlg()
		{
			TabName = "Приходный кассовый ордер самовывоза";

			Entity.TypeDocument = IncomeInvoiceDocumentType.IncomeInvoiceSelfDelivery;

			permissioncommentview.UoW = UoW;
			permissioncommentview.Title = "Комментарий по проверке закрытия МЛ: ";
			permissioncommentview.Comment = Entity.CashierReviewComment;
			permissioncommentview.PermissionName = "can_edit_cashier_review_comment";
			permissioncommentview.Comment = Entity.CashierReviewComment;
			permissioncommentview.CommentChanged += (comment) => Entity.CashierReviewComment = comment;

			enumcomboOperation.ItemsEnum = typeof(IncomeType);
			enumcomboOperation.Binding.AddBinding(Entity, s => s.TypeOperation, w => w.SelectedItem).InitializeFromSource();
			enumcomboOperation.Sensitive = false;
			Entity.TypeOperation = IncomeType.Payment;

			var filterCasher = new EmployeeFilterViewModel();
			filterCasher.ShowFired = false;
			yentryCasher.RepresentationModel = new EmployeesVM(filterCasher);
			yentryCasher.Binding.AddBinding(Entity, s => s.Casher, w => w.Subject).InitializeFromSource();
			yentryCasher.Sensitive = false;

			var filterOrders = new OrdersFilter(UoW);
			filterOrders.SetAndRefilterAtOnce(
				x => x.RestrictStatus = OrderStatus.WaitForPayment,
				x => x.AllowPaymentTypes = new PaymentType[] { PaymentType.cash, PaymentType.BeveragesWorld },
				x => x.RestrictSelfDelivery = true,
				x => x.RestrictWithoutSelfDelivery = false,
				x => x.RestrictHideService = true,
				x => x.RestrictOnlyService = false
			);
			yentryOrder.RepresentationModel = new OrdersVM(filterOrders);
			yentryOrder.Binding.AddBinding(Entity, x => x.Order, x => x.Subject).InitializeFromSource();

			ydateDocument.Binding.AddBinding(Entity, s => s.Date, w => w.Date).InitializeFromSource();

			OrmMain.GetObjectDescription<IncomeCategory>().ObjectUpdated += OnIncomeCategoryUpdated;
			OnIncomeCategoryUpdated(null, null);
			comboCategory.Binding.AddBinding(Entity, s => s.IncomeCategory, w => w.SelectedItem).InitializeFromSource();

			yspinMoney.Binding.AddBinding(Entity, s => s.Money, w => w.ValueAsDecimal).InitializeFromSource();

			ytextviewDescription.Binding.AddBinding(Entity, s => s.Description, w => w.Buffer.Text).InitializeFromSource();

			if(!canEdit) {
				table1.Sensitive = false;
				ytextviewDescription.Editable = false;
				buttonSave.Sensitive = false;
				accessfilteredsubdivisionselectorwidget.Sensitive = false;
			}

			UpdateSubdivision();
		}

		void OnIncomeCategoryUpdated(object sender, QSOrmProject.UpdateNotification.OrmObjectUpdatedEventArgs e)
		{
			comboCategory.ItemsList = Repository.Cash.CategoryRepository.SelfDeliveryIncomeCategories(UoW);
		}

		void Accessfilteredsubdivisionselectorwidget_OnSelected(object sender, EventArgs e)
		{
			UpdateSubdivision();
		}

		private void UpdateSubdivision()
		{
			Entity.RelatedToSubdivision = accessfilteredsubdivisionselectorwidget.SelectedSubdivision;
		}

		public override bool Save()
		{
			var validationContext = new Dictionary<object, object>();
			validationContext.Add("IsSelfDelivery", true);
			var valid = new QSValidator<Income>(UoWGeneric.Root, validationContext);
			if(valid.RunDlgIfNotValid((Gtk.Window)this.Toplevel))
				return false;

			Entity.AcceptSelfDeliveryPaid();

			logger.Info("Сохраняем Приходный ордер самовывоза...");
			UoWGeneric.Save();
			//FIXME Необходимо проверить правильность этого кода, так как если заказ именялся то уведомление на его придет и без кода.
			//А если в каком то месте нужно получать уведомления об изменениях текущего объекта, то логично чтобы этот объект на него и подписался.
			//OrmMain.NotifyObjectUpdated(new object[] { Entity.Order });
			logger.Info("Ok");
			return true;
		}

		protected void OnButtonPrintClicked(object sender, EventArgs e)
		{
			if(UoWGeneric.HasChanges && CommonDialogs.SaveBeforePrint(typeof(Income), "квитанции"))
				Save();

			var reportInfo = new QS.Report.ReportInfo {
				Title = String.Format("Квитанция №{0} от {1:d}", Entity.Id, Entity.Date),
				Identifier = "Cash.ReturnTicket",
				Parameters = new Dictionary<string, object> {
					{ "id",  Entity.Id }
				}
			};

			var report = new QSReport.ReportViewDlg(reportInfo);
			TabParent.AddTab(report, this, false);
		}

		protected void OnYentryOrderChanged(object sender, EventArgs e)
		{
			Entity.FillFromOrder(UoW);
		}
	}
}
