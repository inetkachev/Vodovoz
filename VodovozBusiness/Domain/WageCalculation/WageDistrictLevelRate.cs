﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Bindings.Collections.Generic;
using Gamma.Utilities;
using QS.DomainModel.Entity;
using QS.DomainModel.Entity.EntityPermissions;
using QS.HistoryLog;
using QS.Utilities.Text;

namespace Vodovoz.Domain.WageCalculation
{
	[
		Appellative(
			Gender = GrammaticalGender.Feminine,
			NominativePlural = "строки ставок по зарплатным районам и уровням",
			Nominative = "строка ставки по зарплатным районам и уровням"
		)
	]
	[HistoryTrace]
	[EntityPermission]
	public class WageDistrictLevelRate : PropertyChangedBase, IDomainObject, IValidatableObject
	{
		#region Свойства

		public virtual int Id { get; set; }

		WageDistrict wageDistrict;
		[Display(Name = "Зарплатный район")]
		public virtual WageDistrict WageDistrict {
			get => wageDistrict;
			set => SetField(ref wageDistrict, value);
		}

		WageDistrictLevelRates wageDistrictLevelRates;
		[Display(Name = "Набор ставок по уровню")]
		public virtual WageDistrictLevelRates WageDistrictLevelRates {
			get => wageDistrictLevelRates;
			set => SetField(ref wageDistrictLevelRates, value);
		}

		IList<WageRate> wageRates = new List<WageRate>();
		[Display(Name = "Ставки")]
		public virtual IList<WageRate> WageRates {
			get => wageRates;
			set => SetField(ref wageRates, value);
		}

		GenericObservableList<WageRate> observableWageRates;
		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.
		public virtual GenericObservableList<WageRate> ObservableWageRates {
			get {
				if(observableWageRates == null)
					observableWageRates = new GenericObservableList<WageRate>(WageRates);
				return observableWageRates;
			}
		}

		#endregion Свойства

		#region Вычисляемые

		public virtual string Title => $"{GetType().GetSubjectName().StringToTitleCase()} №{Id}";

		public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if(WageRates.Count < Enum.GetValues(typeof(WageRateTypes)).Length)
				yield return new ValidationResult(
					string.Format("Не заполнены ставки для зарплатной группы \"{0}\"", WageDistrict.Name),
					new[] { this.GetPropertyName(o => o.WageRates) }
				);
		}

		#endregion Вычисляемые
	}
}
