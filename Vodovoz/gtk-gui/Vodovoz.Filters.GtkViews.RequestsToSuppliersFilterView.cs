
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Filters.GtkViews
{
	public partial class RequestsToSuppliersFilterView
	{
		private global::Gtk.HBox hbox1;

		private global::Gtk.Label lblCreateDate;

		private global::Gamma.Widgets.yDatePeriodPicker dPerCreatedDate;

		private global::Gtk.Label lblNomenclature;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry entVMEntNomenclature;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Filters.GtkViews.RequestsToSuppliersFilterView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Filters.GtkViews.RequestsToSuppliersFilterView";
			// Container child Vodovoz.Filters.GtkViews.RequestsToSuppliersFilterView.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.lblCreateDate = new global::Gtk.Label();
			this.lblCreateDate.Name = "lblCreateDate";
			this.lblCreateDate.Xalign = 1F;
			this.lblCreateDate.LabelProp = global::Mono.Unix.Catalog.GetString("Дата создания:");
			this.hbox1.Add(this.lblCreateDate);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.lblCreateDate]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.dPerCreatedDate = new global::Gamma.Widgets.yDatePeriodPicker();
			this.dPerCreatedDate.Events = ((global::Gdk.EventMask)(256));
			this.dPerCreatedDate.Name = "dPerCreatedDate";
			this.dPerCreatedDate.StartDate = new global::System.DateTime(0);
			this.dPerCreatedDate.EndDate = new global::System.DateTime(0);
			this.hbox1.Add(this.dPerCreatedDate);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.dPerCreatedDate]));
			w2.Position = 1;
			// Container child hbox1.Gtk.Box+BoxChild
			this.lblNomenclature = new global::Gtk.Label();
			this.lblNomenclature.Name = "lblNomenclature";
			this.lblNomenclature.Xalign = 1F;
			this.lblNomenclature.LabelProp = global::Mono.Unix.Catalog.GetString("Номенклатура:");
			this.hbox1.Add(this.lblNomenclature);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.lblNomenclature]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.entVMEntNomenclature = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.entVMEntNomenclature.Events = ((global::Gdk.EventMask)(256));
			this.entVMEntNomenclature.Name = "entVMEntNomenclature";
			this.entVMEntNomenclature.CanEditReference = false;
			this.hbox1.Add(this.entVMEntNomenclature);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.entVMEntNomenclature]));
			w4.Position = 3;
			this.Add(this.hbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}