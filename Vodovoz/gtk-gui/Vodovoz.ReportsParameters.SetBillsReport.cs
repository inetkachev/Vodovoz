
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.ReportsParameters
{
	public partial class SetBillsReport
	{
		private global::Gtk.VBox vbox2;

		private global::Gamma.GtkWidgets.yLabel ylabelDescription;

		private global::QS.Widgets.GtkUI.DateRangePicker daterangepickerOrderCreation;

		private global::Gamma.GtkWidgets.yButton ybuttonCreateReport;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ReportsParameters.SetBillsReport
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.ReportsParameters.SetBillsReport";
			// Container child Vodovoz.ReportsParameters.SetBillsReport.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.ylabelDescription = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelDescription.Name = "ylabelDescription";
			this.ylabelDescription.LabelProp = global::Mono.Unix.Catalog.GetString("Дата создания заказа:");
			this.vbox2.Add(this.ylabelDescription);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.ylabelDescription]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.daterangepickerOrderCreation = new global::QS.Widgets.GtkUI.DateRangePicker();
			this.daterangepickerOrderCreation.Events = ((global::Gdk.EventMask)(256));
			this.daterangepickerOrderCreation.Name = "daterangepickerOrderCreation";
			this.daterangepickerOrderCreation.StartDate = new global::System.DateTime(0);
			this.daterangepickerOrderCreation.EndDate = new global::System.DateTime(0);
			this.vbox2.Add(this.daterangepickerOrderCreation);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.daterangepickerOrderCreation]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.ybuttonCreateReport = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonCreateReport.CanFocus = true;
			this.ybuttonCreateReport.Name = "ybuttonCreateReport";
			this.ybuttonCreateReport.UseUnderline = true;
			this.ybuttonCreateReport.Label = global::Mono.Unix.Catalog.GetString("Сформировать отчет");
			this.vbox2.Add(this.ybuttonCreateReport);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.ybuttonCreateReport]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
