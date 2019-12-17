﻿using System;
using System.ComponentModel.DataAnnotations;
using QS.DomainModel.Entity;
using Vodovoz.Domain.Goods;

namespace Vodovoz.Domain.Orders
{
	public abstract class PromotionalSetActionBase : PropertyChangedBase, IDomainObject
	{
		public virtual int Id { get; set; }

		PromotionalSet promotionalSet;
		[Display(Name = "Промо-набор")]
		public virtual PromotionalSet PromotionalSet {
			get { return promotionalSet; }
			set { SetField(ref promotionalSet, value, () => PromotionalSet); }
		}

		public abstract string Title { get; }
	}
}
