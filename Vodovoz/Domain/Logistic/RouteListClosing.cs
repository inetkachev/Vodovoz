﻿using System;
using QSOrmProject;
using Vodovoz.Domain;
using Vodovoz.Domain.Logistic;
using Vodovoz.Domain.Operations;
using System.Collections.Generic;
using System.Linq;
using Vodovoz.Domain.Orders;
using Vodovoz.Repository;

namespace Vodovoz.Domain.Logistic
{
	[OrmSubject (Gender = QSProjectsLib.GrammaticalGender.Neuter,
		NominativePlural = "закрытия маршрутного листа",
		Nominative = "закрытие маршрутного листа")]
	public class RouteListClosing:PropertyChangedBase, IDomainObject
	{		
		public virtual int Id{ get; set;}

		DateTime closingDate;
		public virtual DateTime ClosingDate{
			get{
				return closingDate;
			}
			set{
				SetField(ref closingDate, value, () => ClosingDate);
			}
		}

		Employee cashier;
		public virtual Employee Cashier{
			get{
				return cashier;
			}
			set{
				SetField(ref cashier, value, () => Cashier);
			}
		}

		RouteList routeList;
		public virtual RouteList RouteList{
			get{
				return routeList;
			}
			set{
				SetField(ref routeList, value, () => RouteList);
			}
		}


		public virtual List<BottlesMovementOperation> CreateBottlesMovementOperation(){
			var result = new List<BottlesMovementOperation>();
			foreach (RouteListItem address in RouteList.Addresses)
			{
				int amountDelivered= address.Order.OrderItems
					.Where(item => item.Nomenclature.Category == NomenclatureCategory.water)
					.Sum(item => item.ActualCount);
				if (amountDelivered != 0 || address.BottlesReturned != 0)
				{
					var bottlesMovementOperation = new BottlesMovementOperation
					{
						OperationTime = DateTime.Now,
						Order = address.Order,
						Delivered = amountDelivered,
						Returned = address.BottlesReturned,
						Counterparty = address.Order.Client,
						DeliveryPoint = address.Order.DeliveryPoint
					};
					address.Order.BottlesMovementOperation = bottlesMovementOperation;
					result.Add(bottlesMovementOperation);
				}
			}
			return result;
		}

		public virtual List<CounterpartyMovementOperation> CreateCounterpartyMovementOperations(){
			var result = new List<CounterpartyMovementOperation>();
			foreach (var orderItem in RouteList.Addresses.SelectMany(item=>item.Order.OrderItems)
				.Where(item=>Nomenclature.GetCategoriesForShipment().Contains(item.Nomenclature.Category))
				.Where(item=>!item.Nomenclature.Serial)
			)
			{
				var amount = (orderItem.ActualCount);
				if (amount > 0)
				{
					var counterpartyMovementOperation = new CounterpartyMovementOperation
						{
							OperationTime = DateTime.Now,
							Amount = amount,
							Nomenclature = orderItem.Nomenclature,
							Equipment = orderItem.Equipment,
							IncomingCounterparty = orderItem.Order.Client,
							IncomingDeliveryPoint = orderItem.Order.DeliveryPoint
						};
					result.Add(counterpartyMovementOperation);
				}
			}
			foreach (var orderEquipment in RouteList.Addresses.SelectMany(item=>item.Order.OrderEquipments)
				.Where(item=>Nomenclature.GetCategoriesForShipment().Contains(item.Equipment.Nomenclature.Category)))
			{
				var amount = orderEquipment.Confirmed ? 1 : 0;
				if (amount > 0)
				{
					if (orderEquipment.Direction == Direction.Deliver)
					{
						var counterpartyMovementOperation = new CounterpartyMovementOperation
						{
							OperationTime = DateTime.Now,
							Amount = amount,
							Nomenclature = orderEquipment.Equipment.Nomenclature,
							Equipment = orderEquipment.Equipment,
							ForRent = orderEquipment.Reason == Reason.Rent,
							IncomingCounterparty = orderEquipment.Order.Client,
							IncomingDeliveryPoint = orderEquipment.Order.DeliveryPoint
						};
						result.Add(counterpartyMovementOperation);
					}
					else
					{
						var counterpartyMovementOperation = new CounterpartyMovementOperation
							{
								OperationTime = DateTime.Now,
								Amount = amount,
								Nomenclature = orderEquipment.Equipment.Nomenclature,
								Equipment = orderEquipment.Equipment,
								WriteoffCounterparty = orderEquipment.Order.Client,
								WriteoffDeliveryPoint = orderEquipment.Order.DeliveryPoint
							};
						result.Add(counterpartyMovementOperation);
					}
				}
			}
			return result;
		}

		private void AddOrUpdateDeposit(Order order,DepositOperation depositOperation){

			order.OrderDepositItems.FirstOrDefault(deposit => deposit.DepositType == DepositType.Bottles);
		}

		public virtual List<DepositOperation> CreateDepositOperations(IUnitOfWork UoW){
			var result = new List<DepositOperation>();
			var bottleDepositNomenclature = NomenclatureRepository.GetBottleDeposit(UoW);
			var bottleDepositPrice = bottleDepositNomenclature.GetPrice(1);
			foreach (RouteListItem item in RouteList.Addresses.Where(address=>address.Order.PaymentType==PaymentType.cash))
			{
				var deliveredEquipmentForRent = item.Order.OrderEquipments.Where(eq => eq.Confirmed)
						.Where(eq => eq.Direction == Vodovoz.Domain.Orders.Direction.Deliver)
						.Where(eq => eq.Reason == Reason.Rent);

				var paidRentDepositsFromClient = item.Order.OrderDepositItems
						.Where(deposit => deposit.PaymentDirection == PaymentDirection.FromClient)
						.Where(deposit => deposit.PaidRentItem != null
					                       && deliveredEquipmentForRent.Any(eq => eq.Id == deposit.PaidRentItem.Equipment.Id));

				var freeRentDepositsFromClient = item.Order.OrderDepositItems
						.Where(deposit => deposit.PaymentDirection == PaymentDirection.FromClient)
						.Where(deposit => deposit.FreeRentItem != null
					                       && deliveredEquipmentForRent.Any(eq => eq.Id == deposit.FreeRentItem.Equipment.Id));

				foreach (var deposit in paidRentDepositsFromClient.Union(freeRentDepositsFromClient))
				{
					var operation = new DepositOperation
					{
						Order = item.Order,
						OperationTime = DateTime.Now,
						DepositType = DepositType.Equipment,
						Counterparty = item.Order.Client,
						DeliveryPoint = item.Order.DeliveryPoint,
						ReceivedDeposit = deposit.Total			
					};
					deposit.DepositOperation = operation;
					result.Add(operation);
				}

				var pickedUpEquipmentForRent = item.Order.OrderEquipments.Where(eq => eq.Confirmed)
					.Where(eq => eq.Direction == Vodovoz.Domain.Orders.Direction.PickUp)
					.Where(eq => eq.Reason == Reason.Rent);

				var paidRentDepositsToClient = item.Order.OrderDepositItems
					.Where(deposit => deposit.PaymentDirection == PaymentDirection.ToClient)
					.Where(deposit => deposit.PaidRentItem != null
						&& pickedUpEquipmentForRent.Any(eq => eq.Id == deposit.PaidRentItem.Equipment.Id));

				var freeRentDepositsToClient = item.Order.OrderDepositItems
					.Where(deposit => deposit.PaymentDirection == PaymentDirection.ToClient)
					.Where(deposit => deposit.FreeRentItem != null
						&& pickedUpEquipmentForRent.Any(eq => eq.Id == deposit.FreeRentItem.Equipment.Id));
				
				foreach (var deposit in paidRentDepositsToClient.Union(freeRentDepositsToClient))
				{
					var operation = new DepositOperation
						{
							Order = item.Order,
							OperationTime = DateTime.Now,
							DepositType = DepositType.Equipment,
							Counterparty = item.Order.Client,
							DeliveryPoint = item.Order.DeliveryPoint,
							RefundDeposit = deposit.Total			
						};
					deposit.DepositOperation = operation;
					result.Add(operation);
				}					

				var bottleDepositsOperation = new DepositOperation()
				{
					Order = item.Order,
					OperationTime = DateTime.Now,
					DepositType = DepositType.Bottles,
					Counterparty = item.Order.Client,
					DeliveryPoint = item.Order.DeliveryPoint,
					ReceivedDeposit = item.DepositsCollected>0 ? item.DepositsCollected : 0,
					RefundDeposit = item.DepositsCollected<0 ? -item.DepositsCollected : 0
				};					
				
				var depositsCount = (int)(Math.Abs(item.DepositsCollected) / bottleDepositPrice);
				var depositOrderItem = item.Order.ObservableOrderItems.FirstOrDefault (i => i.Nomenclature.Id == bottleDepositNomenclature.Id);
				var depositItem = item.Order.ObservableOrderDepositItems.FirstOrDefault (i => i.DepositType == DepositType.Bottles);

				if (item.DepositsCollected>0) {
					if (depositItem != null) {
						depositItem.Deposit = bottleDepositPrice;
						depositItem.Count = depositsCount;
						depositItem.PaymentDirection = PaymentDirection.FromClient;
						depositItem.DepositOperation = bottleDepositsOperation;
					}
					if (depositOrderItem != null)
					{
						depositOrderItem.Count = depositsCount;
						depositOrderItem.ActualCount = depositsCount;
					}
					else {
						item.Order.ObservableOrderItems.Add (new OrderItem {
							Order = item.Order,
							AdditionalAgreement = null,
							Count = depositsCount,
							ActualCount = depositsCount,
							Equipment = null,
							Nomenclature = bottleDepositNomenclature,
							Price = bottleDepositPrice
						});
						item.Order.ObservableOrderDepositItems.Add (new OrderDepositItem {
							Order = item.Order,
							Count = depositsCount,
							Deposit = bottleDepositPrice,
							DepositOperation = bottleDepositsOperation,
							DepositType = DepositType.Bottles,
							FreeRentItem = null,
							PaidRentItem = null,
							PaymentDirection = PaymentDirection.FromClient
						});
					}
				}
				if (item.DepositsCollected==0) {
					if (depositItem != null)
						item.Order.ObservableOrderDepositItems.Remove (depositItem);
					if (depositOrderItem != null)
						item.Order.ObservableOrderItems.Remove (depositOrderItem);					
				}
				if (item.DepositsCollected<0) {
					if (depositOrderItem != null)
						item.Order.ObservableOrderItems.Remove (depositOrderItem);
					if (depositItem != null) {
						depositItem.Deposit = bottleDepositPrice;
						depositItem.Count = depositsCount;
						depositItem.PaymentDirection = PaymentDirection.ToClient;
						depositItem.DepositOperation = bottleDepositsOperation;
					} else
						item.Order.ObservableOrderDepositItems.Add (new OrderDepositItem {
							Order = item.Order,
							DepositOperation = bottleDepositsOperation,
							DepositType = DepositType.Bottles,
							Deposit = bottleDepositPrice,
							PaidRentItem = null,
							FreeRentItem = null,
							PaymentDirection = PaymentDirection.ToClient,
							Count = depositsCount
						});					
				}

				result.Add(bottleDepositsOperation);
			}
			return result;
		}

		public virtual void Confirm()
		{			
			RouteList.Status = RouteListStatus.MileageCheck;
			foreach (var order in RouteList.Addresses.Select(item=>item.Order))
			{
				order.OrderStatus = OrderStatus.Closed;
			}
			ClosingDate = DateTime.Now;
		}

		public virtual void RequestAdditionalUnloading()
		{
			RouteList.Status = RouteListStatus.EnRoute;
		}
	}
}

