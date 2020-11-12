﻿using System;
using System.Linq;
using Gamma.Utilities;
using Gtk;
using NLog;
using QS.Dialog.Gtk;
using QS.DomainModel.UoW;
using QSOrmProject;
using QSOrmProject.UpdateNotification;
using Vodovoz.Additions.Store;
using Vodovoz.Core;
using Vodovoz.Infrastructure.Permissions;
using Vodovoz.Dialogs.DocumentDialogs;
using Vodovoz.Domain.Documents;
using Vodovoz.ViewModel;
using Vodovoz.ViewModels.Warehouses;
using QS.Project.Domain;
using Vodovoz.Services.Permissions;
using QS.Project.Services;
using Vodovoz.PermissionExtensions;
using QS.DomainModel.Entity.EntityPermissions.EntityExtendedPermission;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.TempAdapters;
using Vodovoz.EntityRepositories.Store;
using Vodovoz.EntityRepositories;

namespace Vodovoz
{
	public partial class WarehouseDocumentsView : QS.Dialog.Gtk.TdiTabBase
	{
		static Logger logger = LogManager.GetCurrentClassLogger ();

		IUnitOfWork uow;

		public WarehouseDocumentsView ()
		{
			this.Build ();
			this.TabName = "Журнал документов";
			tableDocuments.RepresentationModel = new DocumentsVM ();
			hboxFilter.Add (tableDocuments.RepresentationModel.RepresentationFilter as Widget);
			(tableDocuments.RepresentationModel.RepresentationFilter as Widget).Show ();
			uow = tableDocuments.RepresentationModel.UoW;
			tableDocuments.Selection.Changed += OnSelectionChanged;
			buttonEdit.Sensitive = buttonDelete.Sensitive = false;
			buttonAdd.ItemsEnum = typeof(DocumentType);
			buttonAdd.SetVisibility(DocumentType.DeliveryDocument, false);

			var allPermissions = CurrentPermissions.Warehouse.AnyEntities();
			foreach(DocumentType doctype in Enum.GetValues(typeof(DocumentType))) {
				if(allPermissions.Any(x => x.GetAttributes<DocumentTypeAttribute>().Any(at => at.Type.Equals(doctype))))
					continue;
				buttonAdd.SetSensitive(doctype, false);
			}
		}

		void OnRefObjectUpdated (object sender, OrmObjectUpdatedEventArgs e)
		{
			tableDocuments.RepresentationModel.UpdateNodes ();
		}

		void OnSelectionChanged (object sender, EventArgs e)
		{
			buttonEdit.Sensitive = false;
			buttonDelete.Sensitive = false;

			bool isSelected = tableDocuments.Selection.CountSelectedRows() > 0;

			if(isSelected) {
				var node = tableDocuments.GetSelectedObject<DocumentVMNode>();
				if(node.DocTypeEnum == DocumentType.ShiftChangeDocument) {
					var doc = uow.GetById<ShiftChangeWarehouseDocument>(node.Id);
					isSelected = isSelected && StoreDocumentHelper.CanEditDocument(WarehousePermissions.ShiftChangeEdit, doc.Warehouse);
				}

				var item = tableDocuments.GetSelectedObject<DocumentVMNode>();
				var permissionResult = ServicesConfig.CommonServices.PermissionService.ValidateUserPermission(Document.GetDocClass(item.DocTypeEnum), ServicesConfig.UserService.CurrentUserId);

				buttonDelete.Sensitive = permissionResult.CanDelete;
				buttonEdit.Sensitive = permissionResult.CanUpdate;
			}
		}

		protected void OnButtonAddEnumItemClicked (object sender, QS.Widgets.EnumItemClickedEventArgs e)
		{
			DocumentType type = (DocumentType)e.ItemEnum;
			switch(type) {
				case DocumentType.MovementDocument:
					TabParent.OpenTab(
						DialogHelper.GenerateDialogHashName(Document.GetDocClass(type), 0),
						() => {
							return new MovementDocumentViewModel(
								EntityUoWBuilder.ForCreate(),
								UnitOfWorkFactory.GetDefaultFactory,
								new WarehousePermissionService(),
								VodovozGtkServicesConfig.EmployeeService,
								new EntityExtendedPermissionValidator(PermissionExtensionSingletonStore.GetInstance(), EmployeeSingletonRepository.GetInstance()),
								new NomenclatureSelectorFactory(),
								new OrderSelectorFactory(),
								new WarehouseRepository(),
								UserSingletonRepository.GetInstance(),
								new RdlPreviewOpener(),
								ServicesConfig.CommonServices
							);
						},
						this
					);
					break;
				case DocumentType.IncomingInvoice:
					TabParent.OpenTab(
						DialogHelper.GenerateDialogHashName(Document.GetDocClass(type), 0),
						() => {
							return new IncomingInvoiceViewModel(
								EntityUoWBuilder.ForCreate(),
								UnitOfWorkFactory.GetDefaultFactory,
								new WarehousePermissionService(),
								VodovozGtkServicesConfig.EmployeeService,
								new EntityExtendedPermissionValidator(PermissionExtensionSingletonStore.GetInstance(), EmployeeSingletonRepository.GetInstance()),
								new NomenclatureSelectorFactory(),
								new OrderSelectorFactory(),
								new WarehouseRepository(),
								new RdlPreviewOpener(),
								ServicesConfig.CommonServices
							);
						},
						this
					);
					break;
				case DocumentType.IncomingWater:
				case DocumentType.WriteoffDocument:
				case DocumentType.SelfDeliveryDocument:
				case DocumentType.CarLoadDocument:
				case DocumentType.CarUnloadDocument:
				case DocumentType.InventoryDocument:
				case DocumentType.ShiftChangeDocument:
				case DocumentType.RegradingOfGoodsDocument:
				default:
					TabParent.OpenTab(
						DialogHelper.GenerateDialogHashName(Document.GetDocClass(type), 0),
						() => OrmMain.CreateObjectDialog(Document.GetDocClass(type)),
						this
					);
					break;
			}

		}

		protected void OnTableDocumentsRowActivated (object o, RowActivatedArgs args)
		{
			buttonEdit.Click ();
		}

		protected void OnButtonEditClicked (object sender, EventArgs e)
		{
			if (tableDocuments.GetSelectedObjects ().GetLength (0) > 0) {
				int id = (tableDocuments.GetSelectedObjects () [0] as ViewModel.DocumentVMNode).Id;
				DocumentType DocType = (tableDocuments.GetSelectedObjects () [0] as ViewModel.DocumentVMNode).DocTypeEnum;

				switch (DocType) {
					case DocumentType.IncomingInvoice:
						TabParent.OpenTab(
							DialogHelper.GenerateDialogHashName<IncomingInvoice>(id),
							() => {
								return new IncomingInvoiceViewModel(
									EntityUoWBuilder.ForOpen(id),
									UnitOfWorkFactory.GetDefaultFactory,
									new WarehousePermissionService(),
									VodovozGtkServicesConfig.EmployeeService,
									new EntityExtendedPermissionValidator(PermissionExtensionSingletonStore.GetInstance(), EmployeeSingletonRepository.GetInstance()),
									new NomenclatureSelectorFactory(),
									new OrderSelectorFactory(),
									new WarehouseRepository(),
									new RdlPreviewOpener(),
									ServicesConfig.CommonServices
								);
							},
							this
						);
						
						break;
					case DocumentType.IncomingWater:
						TabParent.OpenTab(
							DialogHelper.GenerateDialogHashName<IncomingWater>(id),
							() => new IncomingWaterDlg (id),
							this);
						break;
					case DocumentType.MovementDocument:
						TabParent.OpenTab(
							DialogHelper.GenerateDialogHashName<MovementDocument>(id),
							() => {
								return new MovementDocumentViewModel(
									EntityUoWBuilder.ForOpen(id),
									UnitOfWorkFactory.GetDefaultFactory,
									new WarehousePermissionService(),
									VodovozGtkServicesConfig.EmployeeService,
									new EntityExtendedPermissionValidator(PermissionExtensionSingletonStore.GetInstance(), EmployeeSingletonRepository.GetInstance()),
									new NomenclatureSelectorFactory(),
									new OrderSelectorFactory(),
									new WarehouseRepository(),
									UserSingletonRepository.GetInstance(),
									new RdlPreviewOpener(),
									ServicesConfig.CommonServices
								);
							},
							this
						);
						break;
					case DocumentType.WriteoffDocument:
						TabParent.OpenTab(
							DialogHelper.GenerateDialogHashName<WriteoffDocument>(id),
							() => new WriteoffDocumentDlg (id),
							this);
						break;
					case DocumentType.InventoryDocument:
						TabParent.OpenTab(
							DialogHelper.GenerateDialogHashName<InventoryDocument>(id),
							() => new InventoryDocumentDlg (id),
							this);
						break;
					case DocumentType.ShiftChangeDocument:
						TabParent.OpenTab(
							DialogHelper.GenerateDialogHashName<ShiftChangeWarehouseDocument>(id),
							() => new ShiftChangeWarehouseDocumentDlg(id),
							this);
						break;
					case DocumentType.RegradingOfGoodsDocument:
						TabParent.OpenTab(
							DialogHelper.GenerateDialogHashName<RegradingOfGoodsDocument>(id),
							() => new RegradingOfGoodsDocumentDlg (id),
							this);
						break;
					case DocumentType.SelfDeliveryDocument:
						TabParent.OpenTab(
							DialogHelper.GenerateDialogHashName<SelfDeliveryDocument>(id),
							() => new SelfDeliveryDocumentDlg (id),
							this);
						break;
					case DocumentType.CarLoadDocument:
						TabParent.OpenTab(
							DialogHelper.GenerateDialogHashName<CarLoadDocument>(id),
							() => new CarLoadDocumentDlg (id),
							this);
						break;
					case DocumentType.CarUnloadDocument:
						TabParent.OpenTab(
							DialogHelper.GenerateDialogHashName<CarUnloadDocument>(id),
							() => new CarUnloadDocumentDlg (id),
							this);
						break;
				default:
					throw new NotSupportedException ("Тип документа не поддерживается.");
				}
			}
		}

		protected void OnButtonDeleteClicked (object sender, EventArgs e)
		{
			var item = tableDocuments.GetSelectedObject<DocumentVMNode>();
			var permissionResult = ServicesConfig.CommonServices.PermissionService.ValidateUserPermission(Document.GetDocClass(item.DocTypeEnum), ServicesConfig.UserService.CurrentUserId);

			if(!permissionResult.CanDelete) {
				return;
			}

			if(OrmMain.DeleteObject (Document.GetDocClass(item.DocTypeEnum), item.Id))
				tableDocuments.RepresentationModel.UpdateNodes ();
		}

		protected void OnButtonFilterToggled (object sender, EventArgs e)
		{
			hboxFilter.Visible = buttonFilter.Active;
		}

		protected void OnSearchentity1TextChanged(object sender, EventArgs e)
		{
			tableDocuments.SearchHighlightText = searchentity1.Text;
			tableDocuments.RepresentationModel.SearchString = searchentity1.Text;
		}

		protected void OnButtonRefreshClicked(object sender, EventArgs e)
		{
			tableDocuments.RepresentationModel.UpdateNodes ();
		}

		public override void Destroy()
		{
			uow?.Dispose();
			base.Destroy();
		}
	}
}