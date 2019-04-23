﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Bindings.Collections.Generic;
using System.Data.Bindings.Utilities;
using QS.DomainModel.Entity;
using QS.DomainModel.Entity.EntityPermissions;
using Vodovoz.Domain.Goods;

namespace Vodovoz.Domain.Store
{
	[Appellative(Gender = GrammaticalGender.Masculine,
		NominativePlural = "склады",
		Nominative = "склад")]
	[EntityPermission]
	public class Warehouse : PropertyChangedBase, IDomainObject, IValidatableObject
	{
		public Warehouse() { }
		string name;

		#region Свойства

		public virtual int Id { get; set; }

		[Required(ErrorMessage = "Название склада должно быть заполнено.")]
		[Display(Name = "Название")]
		public virtual string Name {
			get => name;
			set => SetField(ref name, value, () => Name);
		}

		bool canReceiveBottles;
		public virtual bool CanReceiveBottles {
			get => canReceiveBottles;
			set => SetField(ref canReceiveBottles, value, () => CanReceiveBottles);
		}

		bool canReceiveEquipment;
		public virtual bool CanReceiveEquipment {
			get => canReceiveEquipment;
			set => SetField(ref canReceiveEquipment, value, () => CanReceiveEquipment);
		}

		private bool publishOnlineStore;
		[Display(Name = "Публиковать в интернет магазине")]
		public virtual bool PublishOnlineStore {
			get => publishOnlineStore;
			set => SetField(ref publishOnlineStore, value, () => PublishOnlineStore);
		}

		private WarehouseUsing typeOfUse;
		[Display(Name = "Тип использования")]
		public virtual WarehouseUsing TypeOfUse {
			get => typeOfUse;
			set => SetField(ref typeOfUse, value, () => TypeOfUse);
		}

		private bool isArchive;
		[Display(Name = "Архивный")]
		public virtual bool IsArchive {
			get => isArchive;
			set => SetField(ref isArchive, value, () => IsArchive);
		}

		Subdivision owningSubdivision;
		[Display(Name = "Подразделение-владелец")]
		public virtual Subdivision OwningSubdivision {
			get => owningSubdivision;
			set => SetField(ref owningSubdivision, value, () => OwningSubdivision);
		}

		IList<Nomenclature> nomenclatures = new List<Nomenclature>();

		[Display(Name = "Отгружаемые номенклатуры")]
		public virtual IList<Nomenclature> Nomenclatures {
			get => nomenclatures;
			set => SetField(ref nomenclatures, value, () => Nomenclatures);
		}

		GenericObservableList<Nomenclature> observableNomenclatures;
		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.
		public virtual GenericObservableList<Nomenclature> ObservableNomenclatures {
			get {
				if(observableNomenclatures == null)
					observableNomenclatures = new GenericObservableList<Nomenclature>(Nomenclatures);
				return observableNomenclatures;
			}
		}

		#endregion

		#region IValidatableObject implementation
		public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if(OwningSubdivision == null)
				yield return new ValidationResult(
					"К складу должно быть привязано \"Подразделение-владелец\"",
					new[] { this.GetPropertyName(o => o.OwningSubdivision) }
				);
		}
		#endregion
	}

	public enum WarehouseUsing
	{
		[Display(Name = "Отгрузка")]
		Shipment,
		[Display(Name = "Производство")]
		Production,
	}

	public class WarehouseUsingStringType : NHibernate.Type.EnumStringType
	{
		public WarehouseUsingStringType() : base(typeof(WarehouseUsing)) { }
	}
}