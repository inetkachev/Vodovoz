﻿using System;
using System.Collections.Generic;
using Gtk;
using NHibernate.Transform;
using QSOrmProject;
using QSOrmProject.RepresentationModel;
using Vodovoz.Domain;
using Gtk.DataBindings;

namespace Vodovoz.ViewModel
{
	public class DeliveryPointsVM : RepresentationModelBase<DeliveryPoint, DeliveryPointVMNode>
	{
		public IUnitOfWorkGeneric<Counterparty> CounterpartyUoW {
			get {
				return UoW as IUnitOfWorkGeneric<Counterparty>;
			}
		}

		int counterpartyId;
		public int CounterpartyId {
			get {if (CounterpartyUoW != null)
					return CounterpartyUoW.Root.Id;
			else
				return counterpartyId;
			}
			private set {
				counterpartyId = value;
			}
		}

		#region IRepresentationModel implementation

		public override void UpdateNodes ()
		{
			DeliveryPoint deliveryPointAlias = null;
			Counterparty counterpartyAlias = null;
			DeliveryPointVMNode resultAlias = null;

			var deliveryPointslist = UoW.Session.QueryOver<DeliveryPoint> (() => deliveryPointAlias)
				.JoinAlias (c => c.Counterparty, () => counterpartyAlias)
				.Where (() => counterpartyAlias.Id == CounterpartyId)
				.SelectList (list => list
					.Select (() => deliveryPointAlias.Id).WithAlias (() => resultAlias.Id)
					.Select (() => deliveryPointAlias.Building).WithAlias (() => resultAlias.Building)
					.Select (() => deliveryPointAlias.City).WithAlias (() => resultAlias.City)
					.Select (() => deliveryPointAlias.IsActive).WithAlias (() => resultAlias.IsActive)
					.Select (() => deliveryPointAlias.Name).WithAlias (() => resultAlias.Name)
					.Select (() => deliveryPointAlias.Street).WithAlias (() => resultAlias.Street)
					.Select (() => deliveryPointAlias.Room).WithAlias (() => resultAlias.Room)
			                         )
				.TransformUsing (Transformers.AliasToBean<DeliveryPointVMNode> ())
				.List<DeliveryPointVMNode> ();

			SetItemsSource (deliveryPointslist);
		}

		IMappingConfig treeViewConfig = FluentMappingConfig<DeliveryPointVMNode>.Create ()
			.AddColumn ("Название").SetDataProperty (node => node.Point)
			.RowCells ().AddSetter<CellRendererText> ((c, n) => c.Foreground = n.RowColor)
			.Finish ();

		public override IMappingConfig TreeViewConfig {
			get { return treeViewConfig; }
		}

		#endregion

		#region implemented abstract members of RepresentationModelBase

		protected override bool NeedUpdateFunc (DeliveryPoint updatedSubject)
		{
			return CounterpartyUoW.Root.Id == updatedSubject.Counterparty.Id;
		}

		protected override bool NeedUpdateFunc (object updatedSubject)
		{
			throw new NotImplementedException ();
		}

		#endregion

		public DeliveryPointsVM (IUnitOfWorkGeneric<Counterparty> uow)
		{
			this.UoW = uow;
		}

		public DeliveryPointsVM (IUnitOfWork uow, int counterpartyId)
		{
			this.UoW = uow;
			CounterpartyId = counterpartyId;
		}
	}

	public class DeliveryPointVMNode
	{

		public int Id { get; set; }

		public string Name { get; set; }

		public string City { get; set; }

		public string Street { get; set; }

		public string Building { get; set; }

		public string Room { get; set; }

		public bool IsActive { get; set; }

		public string RowColor { get { return IsActive ? "black" : "grey"; } }

		public string Point { 
			get { return String.Format ("{0}г. {1}, ул. {2}, д.{3}, квартира/офис {4}", 
				(Name == String.Empty ? "" : "\"" + Name + "\": "), City, Street, Building, Room); } 
		}
	}
}

