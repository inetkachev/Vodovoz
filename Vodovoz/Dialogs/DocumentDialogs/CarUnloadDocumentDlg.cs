﻿using System;
using System.Collections.Generic;
using System.Linq;
using QS.Dialog.GtkUI;
using QS.DomainModel.Entity.EntityPermissions.EntityExtendedPermission;
using QS.DomainModel.UoW;
using QS.EntityRepositories;
using QSOrmProject;
using Vodovoz.Additions.Store;
using Vodovoz.Infrastructure.Permissions;
using Vodovoz.Domain;
using Vodovoz.Domain.Documents;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Logistic;
using Vodovoz.Domain.Permissions;
using Vodovoz.Domain.Store;
using Vodovoz.EntityRepositories;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.EntityRepositories.Goods;
using Vodovoz.EntityRepositories.Logistic;
using Vodovoz.PermissionExtensions;
using Vodovoz.Repository.Store;
using Vodovoz.ViewWidgets.Store;
using QS.Project.Services;

namespace Vodovoz
{
	public partial class CarUnloadDocumentDlg : QS.Dialog.Gtk.EntityDialogBase<CarUnloadDocument>
	{
		static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		private IEmployeeRepository EmployeeRepository { get { return EmployeeSingletonRepository.GetInstance(); } }
		private IUserPermissionRepository UserPermissionRepository { get { return UserPermissionSingletonRepository.GetInstance(); } }
		private ICarUnloadRepository CarUnloadRepository { get { return CarUnloadSingletonRepository.GetInstance(); } }
		IList<Equipment> alreadyUnloadedEquipment;

		public override bool HasChanges => true;

		#region Конструкторы
		public CarUnloadDocumentDlg()
		{
			this.Build();
			ConfigureNewDoc();
			ConfigureDlg();
		}


		public CarUnloadDocumentDlg(int routeListId, int? warehouseId)
		{
			this.Build();
			ConfigureNewDoc();

			if(warehouseId.HasValue)
				Entity.Warehouse = UoW.GetById<Warehouse>(warehouseId.Value);
			Entity.RouteList = UoW.GetById<RouteList>(routeListId);
			ConfigureDlg();
		}

		public CarUnloadDocumentDlg(int routeListId, int warehouseId, DateTime date) : this(routeListId, warehouseId)
		{
			Entity.TimeStamp = date;
		}

		public CarUnloadDocumentDlg(int id)
		{
			this.Build();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<CarUnloadDocument>(id);
			ConfigureDlg();
		}

		public CarUnloadDocumentDlg(CarUnloadDocument sub) : this(sub.Id) { }
		#endregion

		#region Методы

		void ConfigureNewDoc()
		{
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<CarUnloadDocument>();
			Entity.Author = EmployeeRepository.GetEmployeeForCurrentUser(UoW);
			if(Entity.Author == null) {
				MessageDialogHelper.RunErrorDialog("Ваш пользователь не привязан к действующему сотруднику, вы не можете создавать складские документы, так как некого указывать в качестве кладовщика.");
				FailInitialize = true;
				return;
			}
			Entity.Warehouse = StoreDocumentHelper.GetDefaultWarehouse(UoW, WarehousePermissions.CarUnloadEdit);
		}

		void ConfigureDlg()
		{
			if(StoreDocumentHelper.CheckAllPermissions(UoW.IsNew, WarehousePermissions.CarUnloadEdit, Entity.Warehouse)) {
				FailInitialize = true;
				return;
			}

			var currentUserId = QS.Project.Services.ServicesConfig.CommonServices.UserService.CurrentUserId;
			var hasPermitionToEditDocWithClosedRL = QS.Project.Services.ServicesConfig.CommonServices.PermissionService.ValidateUserPresetPermission("can_change_car_load_and_unload_docs", currentUserId);
			var editing = StoreDocumentHelper.CanEditDocument(WarehousePermissions.CarUnloadEdit, Entity.Warehouse);
			editing &= Entity.RouteList?.Status != RouteListStatus.Closed || hasPermitionToEditDocWithClosedRL;
			Entity.InitializeDefaultValues(UoW, new NomenclatureRepository());
			yentryrefRouteList.IsEditable = ySpecCmbWarehouses.Sensitive = ytextviewCommnet.Editable = editing;
			returnsreceptionview1.Sensitive =
				hbxTareToReturn.Sensitive =
					nonserialequipmentreceptionview1.Sensitive =
						defectiveitemsreceptionview1.Sensitive = editing;

			defectiveitemsreceptionview1.UoW =
				returnsreceptionview1.UoW = UoW;

			ylabelDate.Binding.AddFuncBinding(Entity, e => e.TimeStamp.ToString("g"), w => w.LabelProp).InitializeFromSource();
			ySpecCmbWarehouses.ItemsList = StoreDocumentHelper.GetRestrictedWarehousesList(UoW, WarehousePermissions.CarUnloadEdit);
			ySpecCmbWarehouses.Binding.AddBinding(Entity, e => e.Warehouse, w => w.SelectedItem).InitializeFromSource();
			ytextviewCommnet.Binding.AddBinding(Entity, e => e.Comment, w => w.Buffer.Text).InitializeFromSource();
			var filter = new RouteListsFilter(UoW);
			filter.SetAndRefilterAtOnce(x => x.RestrictStatus = RouteListStatus.EnRoute);
			yentryrefRouteList.RepresentationModel = new ViewModel.RouteListsVM(filter);
			yentryrefRouteList.Binding.AddBinding(Entity, e => e.RouteList, w => w.Subject).InitializeFromSource();
			yentryrefRouteList.CanEditReference = ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_delete");

			Entity.PropertyChanged += (sender, e) => { if(e.PropertyName == nameof(Entity.Warehouse)) OnWarehouseChanged();};

			lblTareReturnedBefore.Binding.AddFuncBinding(Entity, e => e.ReturnedTareBeforeText, w => w.Text).InitializeFromSource();
			spnTareToReturn.Binding.AddBinding(Entity, e => e.TareToReturn, w => w.ValueAsInt).InitializeFromSource();

			defectiveitemsreceptionview1.Warehouse = returnsreceptionview1.Warehouse = Entity.Warehouse;

			UpdateWidgetsVisible();
			buttonSave.Sensitive = editing;
			if(!editing)
				HasChanges = false;
			if(!UoW.IsNew)
				LoadReception();

			var permmissionValidator = new EntityExtendedPermissionValidator(PermissionExtensionSingletonStore.GetInstance(), EmployeeRepository);
			Entity.CanEdit = permmissionValidator.Validate(typeof(CarUnloadDocument), UserSingletonRepository.GetInstance().GetCurrentUser(UoW).Id, nameof(RetroactivelyClosePermission));
			if(!Entity.CanEdit && Entity.TimeStamp.Date != DateTime.Now.Date) {
				ytextviewCommnet.Binding.AddFuncBinding(Entity, e => e.CanEdit, w => w.Sensitive).InitializeFromSource();
				yentryrefRouteList.Binding.AddFuncBinding(Entity, e => e.CanEdit, w => w.Sensitive).InitializeFromSource();
				ySpecCmbWarehouses.Binding.AddFuncBinding(Entity, e => e.CanEdit, w => w.Sensitive).InitializeFromSource();
				ytextviewRouteListInfo.Binding.AddFuncBinding(Entity, e => e.CanEdit, w => w.Sensitive).InitializeFromSource();
				spnTareToReturn.Binding.AddFuncBinding(Entity, e => e.CanEdit, w => w.Sensitive).InitializeFromSource();
				defectiveitemsreceptionview1.Sensitive = false;
				nonserialequipmentreceptionview1.Sensitive = false;
				returnsreceptionview1.Sensitive = false;

				buttonSave.Sensitive = false;
			} else {
				Entity.CanEdit = true;
			}
		}

		public override bool Save()
		{
			if(!Entity.CanEdit)
				return false;

			if(!UpdateReceivedItemsOnEntity())
				return false;

			var valid = new QS.Validation.GtkUI.QSValidator<CarUnloadDocument>(UoWGeneric.Root);
			if(valid.RunDlgIfNotValid((Gtk.Window)this.Toplevel))
				return false;

			if(!CarUnloadRepository.IsUniqueDocumentAtDay(UoW, Entity.RouteList, Entity.Warehouse, Entity.Id)) {
				MessageDialogHelper.RunErrorDialog("Документ по данному МЛ и складу уже сформирован");
				return false;
			}

			Entity.LastEditor = EmployeeRepository.GetEmployeeForCurrentUser(UoW);
			Entity.LastEditedTime = DateTime.Now;
			if(Entity.LastEditor == null) {
				MessageDialogHelper.RunErrorDialog("Ваш пользователь не привязан к действующему сотруднику, вы не можете изменять складские документы, так как некого указывать в качестве кладовщика.");
				return false;
			}

			logger.Info("Сохраняем разгрузочный талон...");
			UoWGeneric.Save();
			logger.Info("Ok.");
			return true;
		}

		void UpdateRouteListInfo()
		{
			if(Entity.RouteList == null) {
				ytextviewRouteListInfo.Buffer.Text = string.Empty;
				return;
			}

			ytextviewRouteListInfo.Buffer.Text =
				string.Format("Маршрутный лист №{0} от {1:d}\nВодитель: {2}\nМашина: {3}({4})\nЭкспедитор: {5}",
					Entity.RouteList.Id,
					Entity.RouteList.Date,
					Entity.RouteList.Driver.FullName,
					Entity.RouteList.Car.Model,
					Entity.RouteList.Car.RegistrationNumber,
					Entity.RouteList.Forwarder != null ? Entity.RouteList.Forwarder.FullName : "(Отсутствует)"
				);
		}

		void UpdateAlreadyUnloaded()
		{
			alreadyUnloadedEquipment = Repository.EquipmentRepository.GetEquipmentUnloadedTo(UoW, Entity.RouteList);
			returnsreceptionview1.AlreadyUnloadedEquipment = alreadyUnloadedEquipment;
		}

		void FillOtherReturnsTable()
		{
			if(Entity.RouteList == null || Entity.Warehouse == null)
				return;
			Dictionary<int, decimal> returns = CarUnloadRepository.NomenclatureUnloaded(UoW, Entity.RouteList, Entity.Warehouse, Entity);

			treeOtherReturns.ColumnsConfig = Gamma.GtkWidgets.ColumnsConfigFactory.Create<Nomenclature>()
				.AddColumn("Название").AddTextRenderer(x => x.Name)
				.AddColumn("Количество").AddTextRenderer(x => ((int)returns[x.Id]).ToString())
				.Finish();

			Nomenclature nomenclatureAlias = null;

			var query = UoW.Session.QueryOver<Nomenclature>(() => nomenclatureAlias)
						   .WhereRestrictionOn(() => nomenclatureAlias.Id)
						   .IsIn(returns.Keys)
						   .List<Nomenclature>();

			treeOtherReturns.ItemsDataSource = query;
		}

		void SetupForNewRouteList()
		{
			UpdateRouteListInfo();
			if(Entity.RouteList != null) {
				UpdateAlreadyUnloaded();
			}
			nonserialequipmentreceptionview1.RouteList =
				defectiveitemsreceptionview1.RouteList =
					returnsreceptionview1.RouteList = Entity.RouteList;
		}

		private void UpdateWidgetsVisible()
		{
			lblTareReturnedBefore.Visible = Entity.RouteList != null;
			hbxTareToReturn.Visible = Entity.RouteList != null && Entity.Warehouse != null && Entity.Warehouse.CanReceiveBottles;
			nonserialequipmentreceptionview1.Visible = Entity.Warehouse != null && Entity.Warehouse.CanReceiveEquipment;
		}

		void LoadReception()
		{
			foreach(var item in Entity.Items) {
				if(Entity.IsDefaultBottle(item))
					continue;

				if(defectiveitemsreceptionview1.Items.Any(x => x.NomenclatureId == item.MovementOperation.Nomenclature.Id))
					continue;

				var returned = item.MovementOperation.Equipment != null
					? returnsreceptionview1.Items.FirstOrDefault(x => x.EquipmentId == item.MovementOperation.Equipment.Id)
					: returnsreceptionview1.Items.FirstOrDefault(x => x.NomenclatureId == item.MovementOperation.Nomenclature.Id);
				if(returned != null) {
					returned.Amount = (int)item.MovementOperation.Amount;
					returned.Redhead = item.Redhead;
					continue;
				}

				switch(item.ReciveType) {
					case ReciveTypes.Equipment:
						var equipmentByNomenclature = nonserialequipmentreceptionview1.Items.FirstOrDefault(x => x.NomenclatureId == item.MovementOperation.Nomenclature.Id);
						if(equipmentByNomenclature != null) {
							equipmentByNomenclature.Amount = (int)item.MovementOperation.Amount;
							continue;
						}
						nonserialequipmentreceptionview1.Items.Add(
							new ReceptionNonSerialEquipmentItemNode {
								NomenclatureCategory = NomenclatureCategory.equipment,
								NomenclatureId = item.MovementOperation.Nomenclature.Id,
								Amount = (int)item.MovementOperation.Amount,
								Name = item.MovementOperation.Nomenclature.Name
							}
						);
						continue;
					case ReciveTypes.Bottle:
					case ReciveTypes.Returnes:
						break;
					case ReciveTypes.Defective:
						var defective = defectiveitemsreceptionview1.Items.FirstOrDefault(x => x.NomenclatureId == item.MovementOperation.Nomenclature.Id);
						if(defective != null) {
							defective.Amount = (int)item.MovementOperation.Amount;
							continue;
						}
						defectiveitemsreceptionview1.Items.Add(
							new DefectiveItemNode {
								NomenclatureCategory = item.MovementOperation.Nomenclature.Category,
								NomenclatureId = item.MovementOperation.Nomenclature.Id,
								Amount = (int)item.MovementOperation.Amount,
								Name = item.MovementOperation.Nomenclature.Name,
								Source = item.Source,
								TypeOfDefect = item.TypeOfDefect
							}
						);
						continue;
				}

				logger.Warn("Номенклатура {0} не найдена в заказа мл, добавляем отдельно...", item.MovementOperation.Nomenclature);
				var newItem = new ReceptionItemNode(item);
				if(item.MovementOperation.Equipment != null) {
					newItem.EquipmentId = item.MovementOperation.Equipment.Id;
				}
				returnsreceptionview1.AddItem(newItem);
			}
		}

		bool UpdateReceivedItemsOnEntity()
		{
			//Собираем список всего на возврат из разных виджетов.
			var tempItemList = new List<InternalItem>();
			if(Entity.TareToReturn > 0)
				tempItemList.Add(
					new InternalItem {
						ReciveType = ReciveTypes.Bottle,
						NomenclatureId = Entity.DefBottleId,
						Amount = Entity.TareToReturn
					}
				);

			var defectiveItemsList = new List<InternalItem>();
			foreach(var node in defectiveitemsreceptionview1.Items) {
				if(node.Amount == 0)
					continue;

				var item = new InternalItem {
					ReciveType = ReciveTypes.Defective,
					NomenclatureId = node.NomenclatureId,
					Amount = node.Amount,
					MovementOperationId = node.MovementOperation != null ? node.MovementOperation.Id : 0,
					TypeOfDefect = node.TypeOfDefect,
					Source = node.Source
				};

				if(!defectiveItemsList.Any(i => i.EqualsToAnotherInternalItem(item)))
					defectiveItemsList.Add(item);
			}

			foreach(var node in returnsreceptionview1.Items) {
				if(node.Amount == 0)
					continue;

				var item = new InternalItem {
					ReciveType = ReciveTypes.Returnes,
					NomenclatureId = node.NomenclatureId,
					Amount = node.Amount,
					Redhead = node.Redhead
				};
				tempItemList.Add(item);
			}

			foreach(var node in nonserialequipmentreceptionview1.Items) {
				if(node.Amount == 0)
					continue;

				var item = new InternalItem {
					ReciveType = ReciveTypes.Equipment,
					NomenclatureId = node.NomenclatureId,
					Amount = node.Amount
				};
				tempItemList.Add(item);
			}

			//Обновляем Entity
			foreach(var tempItem in defectiveItemsList) {
				//валидация брака
				if(tempItem.TypeOfDefect == null) {
					MessageDialogHelper.RunWarningDialog("Для брака необходимо указать его вид");
					return false;
				}

				//проверка на дубли. если несколько одинаковых, то устанавливаем кол-во в 0 для последующего удаления из коллекции
				if(tempItem.Amount > 0 && defectiveItemsList.Count(i => i.EqualsToAnotherInternalItem(tempItem)) > 1)
					tempItem.Amount = 0;
			}

			foreach(var tempItem in defectiveItemsList) {
				var item = Entity.Items.FirstOrDefault(x => x.MovementOperation.Id > 0 && x.MovementOperation.Id == tempItem.MovementOperationId);
				if(item == null) {
					Entity.AddItem(
						tempItem.ReciveType,
						UoW.GetById<Nomenclature>(tempItem.NomenclatureId),
						null,
						tempItem.Amount,
						null,
						null,
						tempItem.Source,
						tempItem.TypeOfDefect
					);
				} else {
					if(item.MovementOperation.Amount != tempItem.Amount)
						item.MovementOperation.Amount = tempItem.Amount;
					if(item.TypeOfDefect != tempItem.TypeOfDefect)
						item.TypeOfDefect = tempItem.TypeOfDefect;
					if(item.Source != tempItem.Source)
						item.Source = tempItem.Source;
				}
			}

			var nomenclatures = UoW.GetById<Nomenclature>(tempItemList.Select(x => x.NomenclatureId).ToArray());
			foreach(var tempItem in tempItemList) {
				var item = Entity.Items.FirstOrDefault(x => x.MovementOperation.Nomenclature.Id == tempItem.NomenclatureId);
				if(item == null) {
					var nomenclature = nomenclatures.First(x => x.Id == tempItem.NomenclatureId);
					Entity.AddItem(
						tempItem.ReciveType,
						nomenclature,
						null,
						tempItem.Amount,
						null,
						tempItem.Redhead
					);
				} else {
					if(item.MovementOperation.Amount != tempItem.Amount)
						item.MovementOperation.Amount = tempItem.Amount;
					if(item.Redhead != tempItem.Redhead)
						item.Redhead = tempItem.Redhead;
				}
			}

			foreach(var item in Entity.Items.ToList()) {
				bool exist = true;
				if(item.ReciveType != ReciveTypes.Defective)
					exist = tempItemList.Any(x => x.NomenclatureId == item.MovementOperation.Nomenclature?.Id);
				else
					exist = defectiveItemsList.Any(x => x.MovementOperationId == item.MovementOperation.Id && x.Amount > 0);

				if(!exist) {
					UoW.Delete(item.MovementOperation);
					Entity.ObservableItems.Remove(item);
				}
			}

			return true;
		}
		#endregion

		#region События
		protected void OnButtonPrintClicked(object sender, EventArgs e)
		{
			if(UoWGeneric.HasChanges && CommonDialogs.SaveBeforePrint(typeof(CarUnloadDocument), "талона"))
				Save();

			var reportInfo = new QS.Report.ReportInfo {
				Title = Entity.Title,
				Identifier = "Store.CarUnloadDoc",
				Parameters = new Dictionary<string, object>
					{
						{ "id",  Entity.Id }
					}
			};

			TabParent.OpenTab(
				QSReport.ReportViewDlg.GenerateHashName(reportInfo),
				() => new QSReport.ReportViewDlg(reportInfo),
				this);
		}

		protected void OnWarehouseChanged()
		{
			UpdateWidgetsVisible();
			returnsreceptionview1.Warehouse = Entity.Warehouse;
			FillOtherReturnsTable();
		}

		protected void OnYentryrefRouteListChanged(object sender, EventArgs e)
		{
			SetupForNewRouteList();
			FillOtherReturnsTable();
			Entity.ReturnedEmptyBottlesBefore(UoW, new RouteListRepository());
		}
		#endregion

		class InternalItem
		{
			public ReciveTypes ReciveType;
			public int NomenclatureId;

			public decimal Amount;
			public string Redhead;

			public DefectSource Source;
			public CullingCategory TypeOfDefect;

			public int MovementOperationId;

			public bool EqualsToAnotherInternalItem(InternalItem item)
			{
				if(item.TypeOfDefect == null || TypeOfDefect == null)
					return false;
				bool eq = item.ReciveType == ReciveType;
				eq &= item.Source == Source;
				eq &= item.NomenclatureId == NomenclatureId;
				eq &= item.TypeOfDefect.Id == TypeOfDefect.Id;
				return eq;
			}
		}
	}
}

