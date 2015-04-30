﻿using System;
using System.Data.Bindings;
using QSOrmProject;
using QSTDI;
using NHibernate;
using NLog;
using System.Collections.Generic;
using QSValidation;

namespace Vodovoz
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class NomenclatureDlg : Gtk.Bin, QSTDI.ITdiDialog, IOrmDialog
	{
		private static Logger logger = LogManager.GetCurrentClassLogger ();
		private ISession session;
		private Adaptor adaptor = new Adaptor ();
		private Nomenclature subject;

		public ITdiTabParent TabParent { set; get; }

		public event EventHandler<TdiTabNameChangedEventArgs> TabNameChanged;
		public event EventHandler<TdiTabCloseEventArgs> CloseTab;

		public bool HasChanges { 
			get { return Session.IsDirty (); }
		}

		private string _tabName = "Новая номенклатура";

		public string TabName {
			get { return _tabName; }
			set {
				if (_tabName == value)
					return;
				_tabName = value;
				if (TabNameChanged != null)
					TabNameChanged (this, new TdiTabNameChangedEventArgs (value));
			}

		}

		public ISession Session {
			get {
				if (session == null)
					Session = OrmMain.OpenSession ();
				return session;
			}
			set { session = value; }
		}

		public object Subject {
			get { return subject; }
			set {
				if (value is Nomenclature)
					subject = value as Nomenclature;
			}
		}

		public NomenclatureDlg ()
		{
			this.Build ();
			subject = new Nomenclature ();
			Session.Persist (subject);
			ConfigureDlg ();
		}

		public NomenclatureDlg (int id)
		{
			this.Build ();
			subject = Session.Load<Nomenclature> (id);
			TabName = subject.Name;
			ConfigureDlg ();
		}

		public NomenclatureDlg (Nomenclature sub)
		{
			this.Build ();
			subject = Session.Load<Nomenclature> (sub.Id);
			TabName = subject.Name;
			ConfigureDlg ();
		}

		private void ConfigureDlg ()
		{
			notebook1.ShowTabs = false;
			spinWeight.Sensitive = false;
			entryName.IsEditable = true;
			adaptor.Target = subject;
			datatable1.DataSource = adaptor;
			datatable2.DataSource = adaptor;
			enumType.DataSource = adaptor;
			enumVAT.DataSource = adaptor;
			referenceUnit.SubjectType = typeof(MeasurementUnits);
			referenceColor.SubjectType = typeof(EquipmentColors);
			referenceManufacturer.SubjectType = typeof(Manufacturer);
			referenceType.SubjectType = typeof(EquipmentType);
			ConfigureInputs ((NomenclatureCategory)enumType.Active);
			pricesView.Session = Session;
			if (subject.NomenclaturePrice == null)
				subject.NomenclaturePrice = new List<NomenclaturePrice> ();
			pricesView.Prices = subject.NomenclaturePrice;
			radioInfo.Active = true;
		}

		public bool Save ()
		{
			var valid = new QSValidator<Nomenclature> (subject);
			if (valid.RunDlgIfNotValid ((Gtk.Window)this.Toplevel))
				return false;
			logger.Info ("Сохраняем номенклатуру...");
			pricesView.SaveChanges ();
			Session.Flush ();
			OrmMain.NotifyObjectUpdated (subject);
			return true;
		}

		public override void Destroy ()
		{
			Session.Close ();
			adaptor.Disconnect ();
			base.Destroy ();
		}

		protected void OnButtonSaveClicked (object sender, EventArgs e)
		{
			if (!this.HasChanges || Save ())
				OnCloseTab (false);
		}

		protected void OnButtonCancelClicked (object sender, EventArgs e)
		{
			OnCloseTab (false);
		}

		protected void OnCloseTab (bool askSave)
		{
			if (CloseTab != null)
				CloseTab (this, new TdiTabCloseEventArgs (askSave));
		}

		protected void OnEnumTypeChanged (object sender, EventArgs e)
		{
			ConfigureInputs ((NomenclatureCategory)enumType.Active);
		}

		protected void ConfigureInputs (NomenclatureCategory selected)
		{
			spinWeight.Sensitive = !(selected == NomenclatureCategory.service || selected == NomenclatureCategory.rent || selected == NomenclatureCategory.deposit);
			labelManufacturer.Sensitive = referenceManufacturer.Sensitive = (selected == NomenclatureCategory.equipment);
			labelColor.Sensitive = referenceColor.Sensitive = (selected == NomenclatureCategory.equipment);
			labelClass.Sensitive = referenceType.Sensitive = (selected == NomenclatureCategory.equipment);
			labelModel.Sensitive = entryModel.Sensitive = (selected == NomenclatureCategory.equipment);
			labelSerial.Sensitive = checkSerial.Sensitive = (selected == NomenclatureCategory.equipment);
			labelReserve.Sensitive = checkNotReserve.Sensitive = !(selected == NomenclatureCategory.service || selected == NomenclatureCategory.rent || selected == NomenclatureCategory.deposit);
			radioPrice.Sensitive = !(selected == NomenclatureCategory.deposit || selected == NomenclatureCategory.rent || selected == NomenclatureCategory.service);
		}

		protected void OnRadioPriceToggled (object sender, EventArgs e)
		{
			if (radioPrice.Active)
				notebook1.CurrentPage = 1;
		}

		protected void OnRadioInfoToggled (object sender, EventArgs e)
		{
			if (radioInfo.Active)
				notebook1.CurrentPage = 0;
		}
	}
}

