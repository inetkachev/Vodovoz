
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.ViewWidgets.DialogueScriptWidgets
{
	public partial class DialogueOrderRepeatWidget
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView treeItems;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button buttonAccept;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ViewWidgets.DialogueScriptWidgets.DialogueOrderRepeatWidget
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.ViewWidgets.DialogueScriptWidgets.DialogueOrderRepeatWidget";
			// Container child Vodovoz.ViewWidgets.DialogueScriptWidgets.DialogueOrderRepeatWidget.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.VscrollbarPolicy = ((global::Gtk.PolicyType)(2));
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeItems = new global::Gamma.GtkWidgets.yTreeView();
			this.treeItems.CanFocus = true;
			this.treeItems.Name = "treeItems";
			this.GtkScrolledWindow.Add(this.treeItems);
			this.vbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
			w2.Position = 0;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonAccept = new global::Gtk.Button();
			this.buttonAccept.CanFocus = true;
			this.buttonAccept.Name = "buttonAccept";
			this.buttonAccept.UseUnderline = true;
			this.buttonAccept.Label = global::Mono.Unix.Catalog.GetString("Сформировать заказ");
			this.hbox1.Add(this.buttonAccept);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonAccept]));
			w3.Position = 3;
			w3.Expand = false;
			w3.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonAccept.Clicked += new global::System.EventHandler(this.OnButtonAcceptClicked);
		}
	}
}
