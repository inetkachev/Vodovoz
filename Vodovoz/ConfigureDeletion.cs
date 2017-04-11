﻿using System.Collections.Generic;
using QSBanks;
using QSBusinessCommon.Domain;
using QSContacts;
using QSOrmProject.Deletion;
using Vodovoz.Domain;
using Vodovoz.Domain.Accounting;
using Vodovoz.Domain.Cash;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Documents;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Logistic;
using Vodovoz.Domain.Operations;
using Vodovoz.Domain.Orders;
using Vodovoz.Domain.Orders.Documents;
using Vodovoz.Domain.Service;
using Vodovoz.Domain.Store;
using Vodovoz.Domain.Goods;

namespace Vodovoz
{
	partial class MainClass
	{
		public static void ConfigureDeletion ()
		{
			logger.Info ("Настройка параметров удаления...");

			QSContactsMain.ConfigureDeletion ();
			QSBanksMain.ConfigureDeletion ();

			#region Goods

			DeleteConfig.AddHibernateDeleteInfo<Nomenclature>()
				.AddDeleteDependenceFromBag (item => item.NomenclaturePrice)
				.AddDeleteDependence<Equipment> (item => item.Nomenclature)
				.AddDeleteDependence<OrderItem>(x => x.Nomenclature)
				.AddDeleteDependence<OrderEquipment>(x => x.NewEquipmentNomenclature)
				.AddDeleteDependence<ServiceClaim>(x => x.Nomenclature)
				.AddDeleteDependence<ServiceClaimItem>(x => x.Nomenclature)
				.AddDeleteDependence<WarehouseMovementOperation> (item => item.Nomenclature)
				.AddDeleteDependence<CounterpartyMovementOperation> (item => item.Nomenclature)
				.AddDeleteDependence<IncomingInvoiceItem> (item => item.Nomenclature)
				.AddDeleteDependence<IncomingWater>(x => x.Product)
				.AddDeleteDependence<IncomingWaterMaterial>(x => x.Nomenclature)
				.AddDeleteDependence<MovementDocumentItem>(x => x.Nomenclature)
				.AddDeleteDependence<WriteoffDocumentItem>(x => x.Nomenclature)
				.AddDeleteDependence<InventoryDocumentItem>(x => x.Nomenclature)
				.AddDeleteDependence<SelfDeliveryDocumentItem>(x => x.Nomenclature)
				.AddDeleteDependence<SelfDeliveryDocumentReturned>(x => x.Nomenclature)
				.AddDeleteDependence<RegradingOfGoodsDocumentItem>(x => x.NomenclatureOld)
				.AddDeleteDependence<RegradingOfGoodsDocumentItem>(x => x.NomenclatureNew)
				.AddDeleteDependence<RegradingOfGoodsTemplateItem>(x => x.NomenclatureOld)
				.AddDeleteDependence<RegradingOfGoodsTemplateItem>(x => x.NomenclatureNew)
				.AddDeleteDependence<ProductSpecificationMaterial>(x => x.Material)
				.AddDeleteDependence<ProductSpecification>(x => x.Product)
				.AddDeleteDependence<WaterSalesAgreementFixedPrice>(x => x.Nomenclature)
				.AddDeleteDependence<FineNomenclature>(x => x.Nomenclature)
				.AddDeleteDependence<CarLoadDocumentItem>(x => x.Nomenclature)
				.AddClearDependence<PaidRentPackage>(x => x.RentServiceDaily)
				.AddClearDependence<PaidRentPackage>(x => x.RentServiceMonthly)
				.AddClearDependence<PaidRentPackage>(x => x.DepositService)
				.AddClearDependence<FreeRentPackage>(x => x.DepositService);

			DeleteConfig.AddDeleteInfo (new DeleteInfo {
				ObjectClass = typeof(EquipmentColors),
				SqlSelect = "SELECT id, name FROM @tablename ",
				DisplayString = "{1}",
				ClearItems = new List<ClearDependenceInfo> {
					ClearDependenceInfo.Create<Nomenclature> (item => item.Color)
				}
			}.FillFromMetaInfo ()
			);

			DeleteConfig.AddDeleteInfo (new DeleteInfo {
				ObjectClass = typeof(EquipmentType),
				SqlSelect = "SELECT id, name FROM @tablename ",
				DisplayString = "{1}",
				DeleteItems = new List<DeleteDependenceInfo> {
					DeleteDependenceInfo.Create<FreeRentPackage> (item => item.EquipmentType),
					DeleteDependenceInfo.Create<Nomenclature> (item => item.Type),
					DeleteDependenceInfo.Create<PaidRentPackage> (item => item.EquipmentType)
				}
			}.FillFromMetaInfo ()
			);

			DeleteConfig.AddHibernateDeleteInfo<Equipment>()
				.AddDeleteDependence<FreeRentEquipment> (item => item.Equipment)
				.AddDeleteDependence<IncomingInvoiceItem> (item => item.Equipment)
				.AddDeleteDependence<OrderEquipment> (item => item.Equipment)
				.AddDeleteDependence<OrderItem> (item => item.Equipment)
				.AddDeleteDependence<ServiceClaim>(x => x.Equipment)
				.AddDeleteDependence<PaidRentEquipment> (item => item.Equipment)
				.AddDeleteDependence<WarehouseMovementOperation> (item => item.Equipment)
				.AddDeleteDependence<CounterpartyMovementOperation> (item => item.Equipment)
				.AddDeleteDependence<MovementDocumentItem>(x => x.Equipment)
				.AddDeleteDependence<WriteoffDocumentItem>(x => x.Equipment)
				.AddDeleteDependence<SelfDeliveryDocumentItem>(x => x.Equipment)
				.AddDeleteDependence<SelfDeliveryDocumentReturned>(x => x.Equipment)
				.AddDeleteDependence<CarLoadDocumentItem>(x => x.Equipment)
				.AddClearDependence<ServiceClaim>(x => x.ReplacementEquipment);

			DeleteConfig.AddDeleteInfo (new DeleteInfo {
				ObjectClass = typeof(Manufacturer),
				SqlSelect = "SELECT id, name FROM @tablename ",
				DisplayString = "{1}",
				ClearItems = new List<ClearDependenceInfo> {
					ClearDependenceInfo.Create<Nomenclature> (item => item.Manufacturer)
				}
			}.FillFromMetaInfo ()
			);

			DeleteConfig.AddDeleteInfo (new DeleteInfo {
				ObjectClass = typeof(MeasurementUnits),
				SqlSelect = "SELECT id, name FROM @tablename ",
				DisplayString = "{1}",
				ClearItems = new List<ClearDependenceInfo> {
					ClearDependenceInfo.Create<Nomenclature> (item => item.Unit)
				}
			}.FillFromMetaInfo ()
			);

			DeleteConfig.AddDeleteInfo (new DeleteInfo {
				ObjectClass = typeof(NomenclaturePrice),
				SqlSelect = "SELECT id, price, min_count FROM @tablename ",
				DisplayString = "{1:C} (от {2})"
			}.FillFromMetaInfo ()
			);

			DeleteConfig.AddHibernateDeleteInfo<CullingCategory>()
				.AddClearDependence<WriteoffDocumentItem>(x => x.CullingCategory);
			
			#endregion

			//Наша организация
			#region Organization

			DeleteConfig.AddHibernateDeleteInfo<Organization>()
				.AddDeleteDependenceFromBag (item => item.Phones)
				.AddDeleteDependenceFromBag(item => item.Accounts)
				.AddDeleteDependence<CounterpartyContract> (item => item.Organization)
				.AddDeleteDependence<AccountIncome> (item => item.Organization)
				.AddDeleteDependence<AccountExpense> (item => item.Organization)
				.AddDeleteDependence<DocTemplate>(x => x.Organization);

			DeleteConfig.AddClearDependence<Account> (ClearDependenceInfo.Create<Organization> (item => item.DefaultAccount));

			DeleteConfig.AddHibernateDeleteInfo<FreeRentPackage>()
				.AddClearDependence<FreeRentEquipment>(x => x.FreeRentPackage);

			DeleteConfig.AddHibernateDeleteInfo<PaidRentPackage>()
				.AddClearDependence<PaidRentEquipment>(x => x.PaidRentPackage);

			#endregion

			#region Сотрудники

			DeleteConfig.AddHibernateDeleteInfo<Employee>()
				.AddDeleteDependenceFromBag (item => item.Phones)
				.AddDeleteDependenceFromBag(item => item.Accounts)
				.AddDeleteDependence<Income> (item => item.Casher)
				.AddDeleteDependence<Expense> (item => item.Casher)
				.AddDeleteDependence<AdvanceReport> (item => item.Casher)
				.AddDeleteDependence<AdvanceReport> (item => item.Accountable)
				.AddDeleteDependence<RouteList>(x => x.Driver)
				.AddDeleteDependence<RouteList>(x => x.Forwarder)
				.AddDeleteDependence<RouteList>(x => x.Logistican)
				.AddDeleteDependence<FineItem>(x => x.Employee)
				.AddDeleteDependence<EmployeeWorkChart>(item => item.Employee)
				.AddDeleteDependence<FuelDocument>(x => x.Driver)
				.AddDeleteDependence<FuelOperation>(x => x.Driver)
				.AddDeleteDependence<WagesMovementOperations>(x => x.Employee)
				.AddDeleteDependence<Track>(x => x.Driver)
				.AddClearDependence<Car> (item => item.Driver)
				.AddClearDependence<Counterparty> (item => item.Accountant)
				.AddClearDependence<Counterparty> (item => item.SalesManager)
				.AddClearDependence<Counterparty> (item => item.BottlesManager)
				.AddClearDependence<Order>(x => x.Author)
				.AddClearDependence<ServiceClaim>(x => x.Engineer)
				.AddClearDependence<ServiceClaimHistory>(x => x.Employee)
				.AddClearDependence<MovementDocument> (item => item.ResponsiblePerson)
				.AddClearDependence<WriteoffDocument> (item => item.ResponsibleEmployee)
				.AddClearDependence<Organization> (item => item.Leader)
				.AddClearDependence<Organization> (item => item.Buhgalter)
				.AddClearDependence<Income> (item => item.Employee)
				.AddClearDependence<Expense> (item => item.Employee)
				.AddClearDependence<AccountExpense> (item => item.Employee)
				.AddClearDependence<CarLoadDocument> (item => item.Author)
				.AddClearDependence<CarLoadDocument> (item => item.LastEditor)
				.AddClearDependence<CarUnloadDocument>(x => x.Author)
				.AddClearDependence<CarUnloadDocument>(x => x.LastEditor)
				.AddClearDependence<IncomingInvoice>(x => x.Author)
				.AddClearDependence<IncomingInvoice>(x => x.LastEditor)
				.AddClearDependence<IncomingWater>(x => x.Author)
				.AddClearDependence<IncomingWater>(x => x.LastEditor)
				.AddClearDependence<MovementDocument>(x => x.Author)
				.AddClearDependence<MovementDocument>(x => x.LastEditor)
				.AddClearDependence<WriteoffDocument>(x => x.Author)
				.AddClearDependence<WriteoffDocument>(x => x.LastEditor)
				.AddClearDependence<InventoryDocument>(x => x.Author)
				.AddClearDependence<InventoryDocument>(x => x.LastEditor)
				.AddClearDependence<RegradingOfGoodsDocument>(x => x.Author)
				.AddClearDependence<RegradingOfGoodsDocument>(x => x.LastEditor)
				.AddClearDependence<SelfDeliveryDocument>(x => x.Author)
				.AddClearDependence<SelfDeliveryDocument>(x => x.LastEditor)
				.AddClearDependence<RouteList>(x => x.Cashier)
				.AddClearDependence<Residue>(x => x.Author)
				.AddClearDependence<Residue>(x => x.LastEditAuthor)
				.AddClearDependence<Subdivision>(x => x.Chief);

			DeleteConfig.AddClearDependence<Account> (ClearDependenceInfo.Create<Employee> (item => item.DefaultAccount));

			DeleteConfig.AddDeleteInfo (new DeleteInfo {
				ObjectClass = typeof(Nationality),
				SqlSelect = "SELECT id, name FROM @tablename ",
				DisplayString = "{1}",
				ClearItems = new List<ClearDependenceInfo> {
					ClearDependenceInfo.Create<Employee> (item => item.Nationality)
				}
			}.FillFromMetaInfo ()
			);

			DeleteConfig.AddHibernateDeleteInfo<User>()
				.AddDeleteDependence<UserSettings>(x => x.User)
				.AddClearDependence<Employee> (item => item.User);

			DeleteConfig.AddHibernateDeleteInfo<UserSettings>();

			DeleteConfig.AddHibernateDeleteInfo<Fine>()
				.AddDeleteDependence<FineItem>(x => x.Fine)
				.AddDeleteDependence<FineNomenclature>(x => x.Fine)
				.AddClearDependence<InventoryDocumentItem>(x => x.Fine)
				.AddClearDependence<WriteoffDocumentItem>(x => x.Fine)
				.AddClearDependence<RegradingOfGoodsDocumentItem>(x => x.Fine)
				.AddClearDependence<RouteList>(x => x.BottleFine);

			DeleteConfig.AddHibernateDeleteInfo<FineItem>()
				.AddDeleteCascadeDependence(item => item.WageOperation);

			DeleteConfig.AddHibernateDeleteInfo<Subdivision>()
				.AddClearDependence<Employee>(item => item.Subdivision);
			
			DeleteConfig.AddHibernateDeleteInfo<EmployeeWorkChart>();

			#endregion

			//Контрагент и все что сним связано
			#region NearCounterparty

			DeleteConfig.AddHibernateDeleteInfo<Counterparty>()
				.AddDeleteDependenceFromBag(item => item.Phones)
				.AddDeleteDependenceFromBag(item => item.Emails)
				.AddDeleteDependenceFromBag(item => item.Accounts)
				.AddDeleteDependence<DeliveryPoint>(item => item.Counterparty)
				.AddDeleteDependence<Proxy>(item => item.Counterparty)
				.AddDeleteDependence<Contact> (item => item.Counterparty)
				.AddDeleteDependence<CounterpartyContract> (item => item.Counterparty)
				.AddDeleteDependence<BottlesMovementOperation> (item => item.Counterparty)
				.AddDeleteDependence<DepositOperation> (item => item.Counterparty)
				.AddDeleteDependence<CounterpartyMovementOperation> (item => item.WriteoffCounterparty)
				.AddDeleteDependence<CounterpartyMovementOperation> (item => item.IncomingCounterparty)
				.AddDeleteDependence<IncomingInvoice> (item => item.Contractor)
				.AddDeleteDependence<MoneyMovementOperation> (item => item.Counterparty)
				.AddDeleteDependence<MovementDocument> (item => item.FromClient)
				.AddDeleteDependence<MovementDocument> (item => item.ToClient)
				.AddDeleteDependence<Order> (item => item.Client)
				.AddDeleteDependence<ServiceClaim>(x => x.Counterparty)
				.AddDeleteDependence<WriteoffDocument> (item => item.Client)
				.AddDeleteDependence<AccountIncome> (item => item.Counterparty)
				.AddDeleteDependence<AccountExpense> (item => item.Counterparty)
				.AddDeleteDependence<MovementDocument> (item => item.FromClient)
				.AddDeleteDependence<MovementDocument> (item => item.ToClient)
				.AddDeleteDependence<Income>(x => x.Customer)
				.AddDeleteDependence<Residue>(x => x.Customer)
				.AddClearDependence<Counterparty> (item => item.MainCounterparty)
				.AddClearDependence<Counterparty>(x => x.PreviousCounterparty)
				.AddClearDependence<Equipment>(x => x.AssignedToClient);

			DeleteConfig.AddClearDependence<Account> (ClearDependenceInfo.Create<Counterparty> (item => item.DefaultAccount));

			DeleteConfig.AddHibernateDeleteInfo<Contact>()
				.AddDeleteDependenceFromBag(item => item.Emails)
				.AddDeleteDependenceFromBag(item => item.Phones)
				.AddClearDependence<Counterparty> (item => item.MainContact)
				.AddClearDependence<Counterparty> (item => item.FinancialContact)
				.AddRemoveFromDependence<DeliveryPoint>(x => x.Contacts);

			DeleteConfig.AddClearDependence<Post> (ClearDependenceInfo.Create<Contact> (item => item.Post));

			DeleteConfig.AddDeleteInfo (new DeleteInfo {
				ObjectClass = typeof(Significance),
				SqlSelect = "SELECT id, name FROM @tablename ",
				DisplayString = "{1}",
				ClearItems = new List<ClearDependenceInfo> {
					ClearDependenceInfo.Create<Counterparty> (item => item.Significance)
				}
			}.FillFromMetaInfo ()
			);

			DeleteConfig.AddDeleteInfo (new DeleteInfo {
				ObjectClass = typeof(CounterpartyStatus),
				SqlSelect = "SELECT id, name FROM @tablename ",
				DisplayString = "{1}",
				ClearItems = new List<ClearDependenceInfo> {
					ClearDependenceInfo.Create<Counterparty> (item => item.Status)
				}
			}.FillFromMetaInfo ()
			);

			DeleteConfig.AddHibernateDeleteInfo<Proxy>()
				.AddDeleteDependenceFromBag(item => item.Persons);

			DeleteConfig.AddHibernateDeleteInfo<CounterpartyContract>()
				.AddDeleteDependence<AdditionalAgreement> (item => item.Contract)
				.AddDeleteDependence<OrderContract>(x => x.Contract)
				.AddClearDependence<Order>(x => x.Contract);

			DeleteConfig.AddHibernateDeleteInfo<AdditionalAgreement>().HasSubclasses()
				.AddDeleteDependence<OrderAgreement>(x => x.AdditionalAgreement)
				.AddDeleteDependence<WaterSalesAgreementFixedPrice>(x => x.AdditionalAgreement)
				.AddClearDependence<OrderItem> (item => item.AdditionalAgreement);

			DeleteConfig.AddHibernateDeleteInfo<WaterSalesAgreement>();

			DeleteConfig.AddHibernateDeleteInfo<RepairAgreement>();

			DeleteConfig.AddHibernateDeleteInfo<NonfreeRentAgreement>()
				.AddDeleteDependenceFromBag(x => x.Equipment);

			DeleteConfig.AddHibernateDeleteInfo<FreeRentAgreement>()
				.AddDeleteDependenceFromBag(x => x.Equipment);

			DeleteConfig.AddHibernateDeleteInfo<DailyRentAgreement>()
				.AddDeleteDependenceFromBag(x => x.Equipment);

			DeleteConfig.AddHibernateDeleteInfo<FreeRentEquipment>()
				.AddClearDependence<OrderDepositItem>(x => x.FreeRentItem);

			DeleteConfig.AddHibernateDeleteInfo<PaidRentEquipment>()
				.AddClearDependence<OrderDepositItem>(x => x.PaidRentItem);
				
			DeleteConfig.AddHibernateDeleteInfo<DeliveryPoint>()
				.AddDeleteDependence<AdditionalAgreement> (item => item.DeliveryPoint)
				.AddDeleteDependence<BottlesMovementOperation> (item => item.DeliveryPoint)
				.AddDeleteDependence<DepositOperation> (item => item.DeliveryPoint)
				.AddDeleteDependence<CounterpartyMovementOperation> (item => item.WriteoffDeliveryPoint)
				.AddDeleteDependence<CounterpartyMovementOperation> (item => item.IncomingDeliveryPoint)
				.AddDeleteDependence<Order>(x => x.DeliveryPoint)
				.AddDeleteDependence<MovementDocument>(x => x.FromDeliveryPoint)
				.AddDeleteDependence<MovementDocument>(x => x.ToDeliveryPoint)
				.AddDeleteDependence<WriteoffDocument>(x => x.DeliveryPoint)
				.AddDeleteDependence<Residue>(x => x.DeliveryPoint)
				.AddRemoveFromDependence<Proxy> (item => item.DeliveryPoints)
				.AddRemoveFromDependence<Contact>(x => x.DeliveryPoints)
				.AddClearDependence<ServiceClaim>(x => x.DeliveryPoint);

			DeleteConfig.AddHibernateDeleteInfo<WaterSalesAgreementFixedPrice>();

			#endregion
				
			#region Logistics

			DeleteConfig.AddHibernateDeleteInfo<Car>()
				.AddDeleteDependence<RouteList>(x => x.Car)
				.AddDeleteDependence<FuelDocument>(x => x.Car)
				.AddDeleteDependence<FuelOperation>(x => x.Car);

			DeleteConfig.AddHibernateDeleteInfo<FuelType>()
				.AddDeleteDependence<FuelDocument>(x => x.Fuel)
				.AddDeleteDependence<FuelOperation>(x => x.Fuel)
				.AddClearDependence<Car>(x => x.FuelType);

			DeleteConfig.AddDeleteInfo (new DeleteInfo {
				ObjectClass = typeof(DeliverySchedule),
				SqlSelect = "SELECT id, name FROM @tablename ",
				DisplayString = "{1}",
				DeleteItems = new List<DeleteDependenceInfo> {
					DeleteDependenceInfo.Create<Order> (item => item.DeliverySchedule)	
				},
				ClearItems = new List<ClearDependenceInfo> {
					ClearDependenceInfo.Create<DeliveryPoint> (item => item.DeliverySchedule)
				}
			}.FillFromMetaInfo ()
			);

			DeleteConfig.AddHibernateDeleteInfo<DeliveryShift>()
				.AddClearDependence<RouteList>(x => x.Shift);

			DeleteConfig.AddHibernateDeleteInfo<LogisticsArea>()
				.AddClearDependence<DeliveryPoint> (item => item.LogisticsArea);

			DeleteConfig.AddHibernateDeleteInfo<RouteList>()
				.AddDeleteDependence<RouteListItem>(x => x.RouteList)
				.AddDeleteDependence<CarLoadDocument>(x => x.RouteList)
				.AddDeleteDependence<CarUnloadDocument>(x => x.RouteList)
				.AddDeleteDependence<Track>(x => x.RouteList)
				.AddClearDependence<Fine>(x => x.RouteList)
				.AddDeleteCascadeDependence(x => x.FuelOutlayedOperation);

			DeleteConfig.AddHibernateDeleteInfo<RouteList>()
				.AddClearDependence<Expense>(x => x.RouteListClosing)
				.AddClearDependence<Income>(x => x.RouteListClosing);

			DeleteConfig.AddHibernateDeleteInfo<RouteColumn>()
				.AddClearDependence<Nomenclature>(x => x.RouteListColumn);

			DeleteConfig.AddHibernateDeleteInfo<RouteListItem>()
				.AddRemoveFromDependence<RouteList>(x => x.Addresses, x => x.RemoveAddress);

			DeleteConfig.AddHibernateDeleteInfo<Track>();

			#endregion

			//Вокруг заказа
			#region Order

			DeleteConfig.AddHibernateDeleteInfo<Order>()
				.AddDeleteDependence<OrderItem> (item => item.Order)
				.AddDeleteDependence<OrderEquipment>(x => x.Order)
				.AddDeleteDependence<OrderDocument> (item => item.Order)
				.AddDeleteDependence<OrderDepositItem> (item => item.Order)
				.AddDeleteDependence<RouteListItem>(x => x.Order)
				.AddDeleteDependence<BottlesMovementOperation>(item => item.Order)
				.AddDeleteDependence<DepositOperation>(x => x.Order)
				.AddDeleteDependence<MoneyMovementOperation>(x => x.Order)
				.AddDeleteDependence<SelfDeliveryDocument>(x => x.Order)
				.AddDeleteDependence<OrderDocument>(x => x.AttachedToOrder)
				.AddDeleteCascadeDependence(x => x.BottlesMovementOperation)
				.AddDeleteCascadeDependence(x => x.MoneyMovementOperation)
				.AddClearDependence<Order>(x => x.PreviousOrder)
				.AddClearDependence<ServiceClaim>(x => x.InitialOrder)
				.AddClearDependence<ServiceClaim>(x => x.FinalOrder);

			DeleteConfig.AddHibernateDeleteInfo<OrderItem>()
				.AddDeleteDependence<OrderEquipment> (item => item.OrderItem)
				.AddDeleteDependence<SelfDeliveryDocumentItem>(x => x.OrderItem)
				.AddDeleteCascadeDependence(x => x.CounterpartyMovementOperation);

			DeleteConfig.AddDeleteInfo (new DeleteInfo {
				ObjectClass = typeof(OrderEquipment),
				SqlSelect = "SELECT id, order_id FROM @tablename ",
				DisplayString = "Оборудование заказа №{1}"
			}.FillFromMetaInfo ()
			);

			DeleteConfig.AddHibernateDeleteInfo<OrderDocument>().HasSubclasses();

			DeleteConfig.AddHibernateDeleteInfo<OrderDepositItem>()
				.AddDeleteCascadeDependence(x => x.DepositOperation);
				
			DeleteConfig.AddHibernateDeleteInfo<CommentTemplate>();

			DeleteConfig.AddHibernateDeleteInfo<ServiceClaim>()
				.AddDeleteDependence<ServiceClaimItem>(x => x.ServiceClaim)
				.AddDeleteDependence<ServiceClaimHistory>(x => x.ServiceClaim)
				.AddDeleteDependence<DoneWorkDocument>(x => x.ServiceClaim)
				.AddDeleteDependence<EquipmentTransferDocument>(x => x.ServiceClaim);

			DeleteConfig.AddHibernateDeleteInfo<ServiceClaimItem>();

			DeleteConfig.AddHibernateDeleteInfo<ServiceClaimHistory>();

			#endregion

			#region Документы заказа

			DeleteConfig.AddHibernateDeleteInfo<BillDocument>();

			DeleteConfig.AddHibernateDeleteInfo<CoolerWarrantyDocument>();

			DeleteConfig.AddHibernateDeleteInfo<DoneWorkDocument>();

			DeleteConfig.AddHibernateDeleteInfo<EquipmentTransferDocument>();

			DeleteConfig.AddHibernateDeleteInfo<InvoiceBarterDocument>();

			DeleteConfig.AddHibernateDeleteInfo<InvoiceDocument>();

			DeleteConfig.AddHibernateDeleteInfo<OrderAgreement>();

			DeleteConfig.AddHibernateDeleteInfo<OrderContract>();

			DeleteConfig.AddHibernateDeleteInfo<PumpWarrantyDocument>();

			DeleteConfig.AddHibernateDeleteInfo<UPDDocument>();

			DeleteConfig.AddHibernateDeleteInfo<DriverTicketDocument>();

			DeleteConfig.AddHibernateDeleteInfo<DocTemplate>()
				.AddClearDependence<AdditionalAgreement>(x => x.AgreementTemplate)
				.AddClearDependence<CounterpartyContract>(x => x.ContractTemplate);

			DeleteConfig.AddHibernateDeleteInfo<ShetFacturaDocument>();

			DeleteConfig.AddHibernateDeleteInfo<Torg12Document>();

			#endregion

			//Документы
			#region Склад

			DeleteConfig.AddHibernateDeleteInfo<Warehouse>()
				.AddDeleteDependence<IncomingInvoice> (item => item.Warehouse)
				.AddDeleteDependence<CarLoadDocument>(x => x.Warehouse)
				.AddDeleteDependence<CarUnloadDocument>(x => x.Warehouse)
				.AddDeleteDependence<IncomingWater>(x => x.IncomingWarehouse)
				.AddDeleteDependence<IncomingWater>(x => x.WriteOffWarehouse)
				.AddDeleteDependence<MovementDocument>(x => x.FromWarehouse)
				.AddDeleteDependence<MovementDocument>(x => x.ToWarehouse)
				.AddDeleteDependence<WarehouseMovementOperation>(x => x.IncomingWarehouse)
				.AddDeleteDependence<WarehouseMovementOperation>(x => x.WriteoffWarehouse)
				.AddDeleteDependence<WriteoffDocument>(x => x.WriteoffWarehouse)
				.AddDeleteDependence<InventoryDocument>(x => x.Warehouse)
				.AddDeleteDependence<RegradingOfGoodsDocument>(x => x.Warehouse)
				.AddDeleteDependence<SelfDeliveryDocument>(x => x.Warehouse)
				.AddClearDependence<Nomenclature>(x => x.Warehouse)
				.AddClearDependence<UserSettings>(x => x.DefaultWarehouse);

			DeleteConfig.AddHibernateDeleteInfo<IncomingInvoice>()
				.AddDeleteDependence<IncomingInvoiceItem>(x => x.Document);

			DeleteConfig.AddHibernateDeleteInfo<IncomingInvoiceItem>()
				.AddDeleteCascadeDependence(x => x.IncomeGoodsOperation);

			DeleteConfig.AddHibernateDeleteInfo<IncomingWater>()
				.AddDeleteDependence<IncomingWaterMaterial>(x => x.Document)
				.AddDeleteCascadeDependence(x => x.ProduceOperation);

			DeleteConfig.AddHibernateDeleteInfo<IncomingWaterMaterial>()
				.AddDeleteCascadeDependence(x => x.ConsumptionMaterialOperation);

			DeleteConfig.AddHibernateDeleteInfo<MovementDocument>()
				.AddDeleteDependence<MovementDocumentItem>(x => x.Document);

			DeleteConfig.AddHibernateDeleteInfo<MovementDocumentItem>()
				.AddDeleteCascadeDependence(x => x.WarehouseMovementOperation)
				.AddDeleteCascadeDependence(x => x.CounterpartyMovementOperation)
				.AddDeleteCascadeDependence(x => x.DeliveryMovementOperation);

			DeleteConfig.AddHibernateDeleteInfo<WriteoffDocument>()
				.AddDeleteDependence<WriteoffDocumentItem>(x => x.Document);

			DeleteConfig.AddHibernateDeleteInfo<WriteoffDocumentItem>()
				.AddDeleteCascadeDependence(x => x.CounterpartyWriteoffOperation)
				.AddDeleteCascadeDependence(x => x.WarehouseWriteoffOperation);

			DeleteConfig.AddHibernateDeleteInfo<ProductSpecification>()
				.AddDeleteDependenceFromBag(x => x.Materials);

			DeleteConfig.AddHibernateDeleteInfo<ProductSpecificationMaterial>();

			DeleteConfig.AddHibernateDeleteInfo<CarLoadDocument>()
				.AddDeleteDependence<CarLoadDocumentItem>(x => x.Document);

			DeleteConfig.AddHibernateDeleteInfo<CarLoadDocumentItem>()
				.AddDeleteCascadeDependence(x => x.MovementOperation);

			DeleteConfig.AddHibernateDeleteInfo<CarUnloadDocument>()
				.AddDeleteDependence<CarUnloadDocumentItem>(x => x.Document);

			DeleteConfig.AddHibernateDeleteInfo<CarUnloadDocumentItem>()
				.AddDeleteCascadeDependence(x => x.MovementOperation);

			DeleteConfig.AddHibernateDeleteInfo<InventoryDocument>()
				.AddDeleteDependence<InventoryDocumentItem>(x => x.Document);

			DeleteConfig.AddHibernateDeleteInfo<InventoryDocumentItem>()
				.AddDeleteCascadeDependence(x => x.WarehouseChangeOperation);

			DeleteConfig.AddHibernateDeleteInfo<SelfDeliveryDocument>()
				.AddDeleteDependence<SelfDeliveryDocumentItem>(x => x.Document)
				.AddDeleteDependence<SelfDeliveryDocumentReturned>(x => x.Document);

			DeleteConfig.AddHibernateDeleteInfo<SelfDeliveryDocumentItem>()
				.AddDeleteCascadeDependence(x => x.WarehouseMovementOperation);

			DeleteConfig.AddHibernateDeleteInfo<SelfDeliveryDocumentReturned>()
				.AddDeleteCascadeDependence(x => x.WarehouseMovementOperation);		

			DeleteConfig.AddHibernateDeleteInfo<RegradingOfGoodsDocument>()
				.AddDeleteDependence<RegradingOfGoodsDocumentItem>(x => x.Document);

			DeleteConfig.AddHibernateDeleteInfo<RegradingOfGoodsDocumentItem>()
				.AddDeleteCascadeDependence(x => x.WarehouseIncomeOperation)
				.AddDeleteCascadeDependence(x => x.WarehouseWriteOffOperation);

			DeleteConfig.AddHibernateDeleteInfo<RegradingOfGoodsTemplate>()
				.AddDeleteDependence<RegradingOfGoodsTemplateItem>(x => x.Template);

			DeleteConfig.AddHibernateDeleteInfo<RegradingOfGoodsTemplateItem>();

			DeleteConfig.AddHibernateDeleteInfo<MovementWagon>()
				.AddClearDependence<MovementDocument>(x => x.MovementWagon);

			DeleteConfig.AddHibernateDeleteInfo<Residue>()
				.AddDeleteCascadeDependence(x => x.DepositBottlesOperation)
				.AddDeleteCascadeDependence(x => x.DepositEquipmentOperation)
				.AddDeleteCascadeDependence(x => x.BottlesMovementOperation)
				.AddDeleteCascadeDependence(x => x.MoneyMovementOperation);

			#endregion

			//Операции в журналах
			#region Operations

			DeleteConfig.AddHibernateDeleteInfo<BottlesMovementOperation>()
				.RequiredCascadeDeletion()
				.AddClearDependence<Order>(x => x.BottlesMovementOperation)
				.AddDeleteDependence<Residue>(x => x.BottlesMovementOperation);

			DeleteConfig.AddHibernateDeleteInfo<WarehouseMovementOperation>()
				.RequiredCascadeDeletion()
				.AddDeleteDependence<CarLoadDocumentItem>(x => x.MovementOperation)
				.AddDeleteDependence<CarUnloadDocumentItem>(x => x.MovementOperation)
				.AddDeleteDependence<IncomingInvoiceItem>(x => x.IncomeGoodsOperation)
				.AddDeleteDependence<IncomingWater>(x => x.ProduceOperation)
				.AddDeleteDependence<IncomingWaterMaterial>(x => x.ConsumptionMaterialOperation)
				.AddDeleteDependence<MovementDocumentItem>(x => x.WarehouseMovementOperation)
				.AddDeleteDependence<MovementDocumentItem>(x => x.DeliveryMovementOperation)
				.AddDeleteDependence<WriteoffDocumentItem>(x => x.WarehouseWriteoffOperation)
				.AddDeleteDependence<InventoryDocumentItem>(x => x.WarehouseChangeOperation)
				.AddDeleteDependence<RegradingOfGoodsDocumentItem>(x => x.WarehouseIncomeOperation)
				.AddDeleteDependence<RegradingOfGoodsDocumentItem>(x => x.WarehouseWriteOffOperation)
				.AddDeleteDependence<SelfDeliveryDocumentItem>(x => x.WarehouseMovementOperation)
				.AddDeleteDependence<SelfDeliveryDocumentReturned>(x => x.WarehouseMovementOperation);

			DeleteConfig.AddHibernateDeleteInfo<CounterpartyMovementOperation>()
				.RequiredCascadeDeletion()
				.AddDeleteDependence<MovementDocumentItem>(x => x.CounterpartyMovementOperation)
				.AddDeleteDependence<WriteoffDocumentItem>(x => x.CounterpartyWriteoffOperation)
				.AddDeleteDependence<OrderItem>(x => x.CounterpartyMovementOperation);

			DeleteConfig.AddHibernateDeleteInfo<MoneyMovementOperation>()
				.RequiredCascadeDeletion()
				.AddClearDependence<Order>(x => x.MoneyMovementOperation)
				.AddDeleteDependence<AccountExpense>(x => x.MoneyOperation)
				.AddDeleteDependence<AccountIncome>(x => x.MoneyOperation)
				.AddDeleteDependence<Residue>(x => x.MoneyMovementOperation);

			DeleteConfig.AddHibernateDeleteInfo<DepositOperation>()
				.RequiredCascadeDeletion()
				.AddDeleteDependence<OrderDepositItem>(x => x.DepositOperation)
				.AddDeleteDependence<Residue>(x => x.DepositBottlesOperation)
				.AddDeleteDependence<Residue>(x => x.DepositEquipmentOperation);

			DeleteConfig.AddHibernateDeleteInfo<WagesMovementOperations>()
				.AddDeleteDependence<FineItem>(item => item.WageOperation)
				.AddDeleteDependence<RouteList>(item => item.WageOperation)
				.AddDeleteDependence<Expense>(item => item.WagesOperation);

			DeleteConfig.AddHibernateDeleteInfo<FuelOperation>()
				.RequiredCascadeDeletion()
				.AddDeleteDependence<RouteList>(x => x.FuelOutlayedOperation)
				.AddDeleteDependence<FuelDocument>(x => x.Operation);

			#endregion

			#region Cash

			DeleteConfig.AddHibernateDeleteInfo<Income>()
				.AddDeleteDependence<AdvanceClosing>(x => x.Income)
				.AddDeleteDependence<AdvanceReport>(x => x.ChangeReturn);

			DeleteConfig.AddHibernateDeleteInfo<Expense>()
				.AddDeleteDependence<AdvanceClosing>(x => x.AdvanceExpense)
				.AddDeleteDependence<FuelDocument>(x => x.FuelCashExpense);

			DeleteConfig.AddDeleteInfo (new DeleteInfo {
				ObjectClass = typeof(AdvanceReport),
				SqlSelect = "SELECT id, date FROM @tablename ",
				DisplayString = "Авансовый отчет №{0} от {1:d}",
				DeleteItems = new List<DeleteDependenceInfo> {
					DeleteDependenceInfo.Create<AdvanceClosing> (item => item.AdvanceReport) //FIXME Запустить перерасчет калки закрытия. 
				}
			}.FillFromMetaInfo ()
			);

			DeleteConfig.AddDeleteInfo(new DeleteInfo {
				ObjectClass = typeof(AdvanceClosing),
				SqlSelect = "SELECT id FROM @tablename ",
				DisplayString = "Строка закрытия аванса №{0} на сумму #FIXME",
			}.FillFromMetaInfo ());

			DeleteConfig.AddDeleteInfo (new DeleteInfo {
				ObjectClass = typeof(IncomeCategory),
				SqlSelect = "SELECT id, name FROM @tablename ",
				DisplayString = "Статья дохода {1}",
				DeleteItems = new List<DeleteDependenceInfo> {
					DeleteDependenceInfo.Create<AccountIncome> (item => item.Category),
					DeleteDependenceInfo.Create<Income> (item => item.IncomeCategory)
				}
			}.FillFromMetaInfo ()
			);
				
			DeleteConfig.AddHibernateDeleteInfo<ExpenseCategory>()
				.AddDeleteDependence<Expense> (item => item.ExpenseCategory)
				.AddDeleteDependence<AdvanceReport> (item => item.ExpenseCategory)
				.AddDeleteDependence<Income> (item => item.ExpenseCategory)
				.AddDeleteDependence<AccountExpense> (item => item.Category)
				.AddDeleteDependence<ExpenseCategory>(x => x.Parent)
				.AddClearDependence<Counterparty> (item => item.DefaultExpenseCategory);

			DeleteConfig.AddHibernateDeleteInfo<FuelDocument>()
				.AddDeleteCascadeDependence(x => x.Operation)
				.AddClearDependence<RouteList>(x => x.FuelGivedDocument);

			DeleteConfig.AddHibernateDeleteInfo<FineNomenclature>();

			#endregion

			#region Операции по счету

			DeleteConfig.AddHibernateDeleteInfo<AccountIncome>()
				.AddDeleteCascadeDependence(x => x.MoneyOperation);

			DeleteConfig.AddHibernateDeleteInfo<AccountExpense>()
				.AddDeleteCascadeDependence(x => x.MoneyOperation);
				
			DeleteConfig.ExistingConfig<Account> ().DeleteItems
				.AddRange (new List<DeleteDependenceInfo> {
				DeleteDependenceInfo.Create<AccountIncome> (item => item.CounterpartyAccount),
				DeleteDependenceInfo.Create<AccountIncome> (item => item.OrganizationAccount),
				DeleteDependenceInfo.Create<AccountExpense> (item => item.CounterpartyAccount),
				DeleteDependenceInfo.Create<AccountExpense> (item => item.OrganizationAccount),
				DeleteDependenceInfo.Create<AccountExpense> (item => item.EmployeeAccount),
			});

			#endregion

			//Для тетирования
			#if DEBUG
			DeleteConfig.IgnoreMissingClass.Add (typeof(TrackPoint));
			//DeleteConfig.IgnoreMissingClass.Add (typeof(DailyRentAgreement));
			//DeleteConfig.IgnoreMissingClass.Add (typeof(FreeRentAgreement));
			//DeleteConfig.IgnoreMissingClass.Add (typeof(WaterSalesAgreement));
			//DeleteConfig.IgnoreMissingClass.Add (typeof(RepairAgreement));

			DeleteConfig.DeletionCheck ();
			#endif

			logger.Info ("Ок");
		}
	}
}
