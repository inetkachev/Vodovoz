
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Dialogs.DocumentDialogs
{
	public partial class ShiftChangeWarehouseDocumentItemsView
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.Label label1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewItems;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button buttonFillItems;

		private global::Gtk.Button buttonAdd;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Dialogs.DocumentDialogs.ShiftChangeWarehouseDocumentItemsView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Dialogs.DocumentDialogs.ShiftChangeWarehouseDocumentItemsView";
			// Container child Vodovoz.Dialogs.DocumentDialogs.ShiftChangeWarehouseDocumentItemsView.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 0F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Список номенклатур:");
			this.vbox1.Add(this.label1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.label1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreeviewItems = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewItems.CanFocus = true;
			this.ytreeviewItems.Name = "ytreeviewItems";
			this.GtkScrolledWindow.Add(this.ytreeviewItems);
			this.vbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
			w3.Position = 1;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonFillItems = new global::Gtk.Button();
			this.buttonFillItems.CanFocus = true;
			this.buttonFillItems.Name = "buttonFillItems";
			this.buttonFillItems.UseUnderline = true;
			this.buttonFillItems.Label = global::Mono.Unix.Catalog.GetString("Заполнить по складу");
			global::Gtk.Image w4 = new global::Gtk.Image();
			w4.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("Vodovoz.icons.buttons.insert-object.png");
			this.buttonFillItems.Image = w4;
			this.hbox1.Add(this.buttonFillItems);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonFillItems]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonAdd = new global::Gtk.Button();
			this.buttonAdd.CanFocus = true;
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.UseUnderline = true;
			this.buttonAdd.Label = global::Mono.Unix.Catalog.GetString("Добавить отсутствующее");
			global::Gtk.Image w6 = new global::Gtk.Image();
			w6.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-add", global::Gtk.IconSize.Menu);
			this.buttonAdd.Image = w6;
			this.hbox1.Add(this.buttonAdd);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonAdd]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w8.Position = 2;
			w8.Expand = false;
			w8.Fill = false;
			this.Add(this.vbox1);
			if((this.Child != null)) {
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonFillItems.Clicked += new global::System.EventHandler(this.OnButtonFillItemsClicked);
			this.buttonAdd.Clicked += new global::System.EventHandler(this.OnButtonAddClicked);
		}
	}
}