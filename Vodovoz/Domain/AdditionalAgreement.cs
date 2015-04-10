﻿using System;
using QSOrmProject;
using System.Data.Bindings;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Vodovoz
{
	[OrmSubject ("Дополнительные соглашения")]
	public class AdditionalAgreement : IDomainObject, IValidatableObject
	{
		public virtual int Id { get; set; }

		[Required (ErrorMessage = "Номер доп. соглашения должен быть заполнен.")]
		public virtual string AgreementNumber { get; set; }

		public virtual AgreementType Type {
			get {	 
				if (this is DailyRentAgreement)		//Не менять Daily и Nonfree местами!
					return AgreementType.DailyRent;
				if (this is NonfreeRentAgreement)	//Иначе из-за наследования тип будет определен некорректно.
					return AgreementType.NonfreeRent;
				if (this is FreeRentAgreement)
					return AgreementType.FreeRent;
				if (this is WaterSalesAgreement)
					return AgreementType.WaterSales;
				return AgreementType.Repair;
			}

		}

		public virtual CounterpartyContract Contract { get; set; }

		public virtual DateTime IssueDate { get; set; }

		public virtual DateTime StartDate { get; set; }

		public virtual DeliveryPoint DeliveryPoint { get; set; }

		public virtual string AgreementDeliveryPoint { get { return DeliveryPoint != null ? DeliveryPoint.Point : "Не указана"; } }

		public virtual string AgreementTypeTitle { get { return Type.GetEnumTitle (); } }

		public virtual bool IsNew { get; set; }

		public AdditionalAgreement ()
		{
			AgreementNumber = String.Empty;
			IssueDate = StartDate = DateTime.Now;
		}

		public virtual IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
		{
			int count = 0;
			foreach (AdditionalAgreement agreement in Contract.AdditionalAgreements)
				if (agreement.AgreementNumber == this.AgreementNumber)
					count++;
			if (count > 1)
				yield return new ValidationResult ("Доп. соглашение с таким номером уже существует.", new[] { "AgreementNumber" });
		}
	}

	public class NonfreeRentAgreement : AdditionalAgreement, IPaidRentEquipmentOwner
	{
		public virtual IList<PaidRentEquipment> Equipment { get; set; }

		public override IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
		{
			foreach (ValidationResult result in base.Validate (validationContext))
				yield return result;
			if (DeliveryPoint == null)
				yield return new ValidationResult ("Необходимо указать точку доставки.", new[] { "DeliveryPoint" });
		}
	}

	public class DailyRentAgreement : NonfreeRentAgreement
	{
		public virtual int RentDays { get; set; }

		public override IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
		{
			foreach (ValidationResult result in base.Validate (validationContext))
				yield return result;
			if (RentDays < 1)
				yield return new ValidationResult ("Срок аренды не может быть меньше одного дня.", new[] { "RentDays" });
		}
	}

	public class FreeRentAgreement : AdditionalAgreement, IFreeRentEquipmentOwner
	{
		public virtual IList<FreeRentEquipment> Equipment { get; set; }

		public override IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
		{
			foreach (ValidationResult result in base.Validate (validationContext))
				yield return result;
			if (DeliveryPoint == null)
				yield return new ValidationResult ("Необходимо указать точку доставки.", new[] { "DeliveryPoint" });
		}
	}

	public class WaterSalesAgreement : AdditionalAgreement
	{
		public virtual bool IsFixedPrice { get; set; }

		public virtual decimal FixedPrice { get; set; }

		public override IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
		{
			foreach (ValidationResult result in base.Validate (validationContext))
				yield return result;
			var agreements = new List<AdditionalAgreement> ();
			foreach (AdditionalAgreement agreement in Contract.AdditionalAgreements)
				if (agreement is WaterSalesAgreement)
					agreements.Add (agreement);
			if (agreements.FindAll (m => m.DeliveryPoint == this.DeliveryPoint).Count > 1) {
				if (DeliveryPoint != null)
					yield return new ValidationResult ("Доп. соглашение для данной точки доставки уже существует.", new[] { "DeliveryPoint" });
				else
					yield return new ValidationResult ("Общее доп. соглашение по продаже воды уже существует. " +
					"Пожалуйста, укажите точку доставки или перейдите к существующему соглашению.", new[] { "DeliveryPoint" });
			}
		}
	}

	public class RepairAgreement : AdditionalAgreement
	{
	}

	public enum AgreementType
	{
		[ItemTitleAttribute ("Платная аренда")]
		NonfreeRent,
		[ItemTitleAttribute ("Платная посуточная аренда")]
		DailyRent,
		[ItemTitleAttribute ("Бесплатная аренда")]
		FreeRent,
		[ItemTitleAttribute ("Продажа воды")]
		WaterSales,
		[ItemTitleAttribute ("Ремонт")]
		Repair
	}

	public class AgreementTypeStringType : NHibernate.Type.EnumStringType
	{
		public AgreementTypeStringType () : base (typeof(AgreementType))
		{
		}
	}
}

