
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class ReadyForShipmentView
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox1;

		private global::Vodovoz.ReadyForShipmentFilter readyforshipmentfilter1;

		private global::QSWidgetLib.SearchEntity searchentity2;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::QSOrmProject.RepresentationTreeView tableReadyForShipment;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button buttonOpen;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ReadyForShipmentView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.ReadyForShipmentView";
			// Container child Vodovoz.ReadyForShipmentView.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.readyforshipmentfilter1 = new global::Vodovoz.ReadyForShipmentFilter();
			this.readyforshipmentfilter1.Events = ((global::Gdk.EventMask)(256));
			this.readyforshipmentfilter1.Name = "readyforshipmentfilter1";
			this.hbox1.Add(this.readyforshipmentfilter1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.readyforshipmentfilter1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.searchentity2 = new global::QSWidgetLib.SearchEntity();
			this.searchentity2.Events = ((global::Gdk.EventMask)(256));
			this.searchentity2.Name = "searchentity2";
			this.vbox1.Add(this.searchentity2);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.searchentity2]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.tableReadyForShipment = new global::QSOrmProject.RepresentationTreeView();
			this.tableReadyForShipment.CanFocus = true;
			this.tableReadyForShipment.Name = "tableReadyForShipment";
			this.GtkScrolledWindow.Add(this.tableReadyForShipment);
			this.vbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
			w5.Position = 2;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonOpen = new global::Gtk.Button();
			this.buttonOpen.Sensitive = false;
			this.buttonOpen.CanFocus = true;
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.UseUnderline = true;
			this.buttonOpen.Label = global::Mono.Unix.Catalog.GetString("Погрузить машину");
			global::Gtk.Image w6 = new global::Gtk.Image();
			w6.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-ok", global::Gtk.IconSize.Menu);
			this.buttonOpen.Image = w6;
			this.hbox2.Add(this.buttonOpen);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonOpen]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			this.vbox1.Add(this.hbox2);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
			w8.Position = 3;
			w8.Expand = false;
			w8.Fill = false;
			this.Add(this.vbox1);
			if((this.Child != null)) {
				this.Child.ShowAll();
			}
			this.Hide();
			this.searchentity2.TextChanged += new global::System.EventHandler(this.OnSearchentity2TextChanged);
			this.tableReadyForShipment.RowActivated += new global::Gtk.RowActivatedHandler(this.OnTableReadyForShipmentRowActivated);
			this.buttonOpen.Clicked += new global::System.EventHandler(this.OnButtonOpenClicked);
		}
	}
}
