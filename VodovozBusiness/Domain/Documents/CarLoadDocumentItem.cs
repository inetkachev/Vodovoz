﻿using System;
using System.ComponentModel.DataAnnotations;
using QS.DomainModel.Entity;
using QS.HistoryLog;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Operations;
using Vodovoz.Domain.Store;

namespace Vodovoz.Domain.Documents
{
	[Appellative (Gender = GrammaticalGender.Feminine,
		NominativePlural = "строки талона погрузки",
		Nominative = "строка талона погрузки")]
	[HistoryTrace]
	public class CarLoadDocumentItem: PropertyChangedBase, IDomainObject
	{
		#region Свойства
		public virtual int Id { get; set; }

		CarLoadDocument document;

		public virtual CarLoadDocument Document {
			get { return document; }
			set { SetField (ref document, value, () => Document); }
		}

		WarehouseMovementOperation movementOperation;

		public virtual WarehouseMovementOperation MovementOperation { 
			get { return movementOperation; }
			set { SetField (ref movementOperation, value, () => MovementOperation); }
		}

		EmployeeNomenclatureMovementOperation employeeNomenclatureMovementOperation;
		public virtual EmployeeNomenclatureMovementOperation EmployeeNomenclatureMovementOperation { 
			get => employeeNomenclatureMovementOperation;
			set => SetField (ref employeeNomenclatureMovementOperation, value);
		}
		
		Nomenclature nomenclature;

		[Display (Name = "Номенклатура")]
		public virtual Nomenclature Nomenclature {
			get { return nomenclature; }
			set {
				SetField (ref nomenclature, value, () => Nomenclature);

				if (MovementOperation != null && MovementOperation.Nomenclature != nomenclature)
					MovementOperation.Nomenclature = nomenclature;
			}
		}

		Equipment equipment;

		[Display (Name = "Оборудование")]
		public virtual Equipment Equipment {
			get { return equipment; }
			set {
				SetField (ref equipment, value, () => Equipment);
				if (MovementOperation != null && MovementOperation.Equipment != equipment)
					MovementOperation.Equipment = equipment;
			}
		}

		decimal amount;

		[Display (Name = "Количество")]
		public virtual decimal Amount {
			get => amount;
			set => SetField (ref amount, value, () => Amount);
		}

		#endregion

		#region Не сохраняемые

		decimal amountInStock;

		[Display (Name = "Количество на складе")]
		public virtual decimal AmountInStock {
			get { return amountInStock; }
			set {
				SetField (ref amountInStock, value, () => AmountInStock);
			}
		}

		decimal amountInRouteList;

		[Display (Name = "Количество в машрутном листе")]
		public virtual decimal AmountInRouteList {
			get { return amountInRouteList; }
			set {
				SetField (ref amountInRouteList, value, () => AmountInRouteList);
			}
		}

		decimal amountLoaded;

		[Display (Name = "Уже отгружено")]
		public virtual decimal AmountLoaded {
			get { return amountLoaded; }
			set {
				SetField (ref amountLoaded, value, () => AmountLoaded);
			}
		}
			
		public virtual string Title =>
			MovementOperation == null ? Nomenclature.Name : String.Format("[{2}] {0} - {1}",
				MovementOperation.Nomenclature.Name,
				MovementOperation.Nomenclature.Unit?.MakeAmountShortStr(MovementOperation.Amount) ?? MovementOperation.Amount.ToString(),
				document.Title);

		#endregion

		#region Функции

		public virtual void CreateOperation(Warehouse warehouse, DateTime time)
		{
			MovementOperation = new WarehouseMovementOperation
				{
					WriteoffWarehouse = warehouse,
					Amount = Amount,
					OperationTime = time,
					Nomenclature = Nomenclature,
					Equipment = Equipment
				};
		}

		public virtual void UpdateOperation(Warehouse warehouse)
		{
			MovementOperation.WriteoffWarehouse = warehouse;
			MovementOperation.IncomingWarehouse = null;
			MovementOperation.Amount = Amount;
			MovementOperation.Equipment = Equipment;
		}
		
		public virtual void CreateEmployeeNomenclatureIncomeOperation(DateTime time)
		{
			EmployeeNomenclatureMovementOperation = new EmployeeNomenclatureMovementOperation
			{
				Amount = (int)Amount,
				OperationTime = time,
				Employee = Document.RouteList.Driver,
				Nomenclature = Nomenclature
			};
		}

		#endregion
	}
}

