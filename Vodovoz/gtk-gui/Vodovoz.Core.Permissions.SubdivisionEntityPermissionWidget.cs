
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Core.Permissions
{
	public partial class SubdivisionEntityPermissionWidget
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox2;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewEntitiesList;

		private global::Gtk.VBox vbox1;

		private global::Gtk.Button buttonAdd;

		private global::QS.Project.Dialogs.GtkUI.PermissionListView permissionlistview;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Core.Permissions.SubdivisionEntityPermissionWidget
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Core.Permissions.SubdivisionEntityPermissionWidget";
			// Container child Vodovoz.Core.Permissions.SubdivisionEntityPermissionWidget.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.ytreeviewEntitiesList = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewEntitiesList.CanFocus = true;
			this.ytreeviewEntitiesList.Name = "ytreeviewEntitiesList";
			this.GtkScrolledWindow1.Add(this.ytreeviewEntitiesList);
			this.hbox2.Add(this.GtkScrolledWindow1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.GtkScrolledWindow1]));
			w2.Position = 0;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.buttonAdd = new global::Gtk.Button();
			this.buttonAdd.CanFocus = true;
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.UseUnderline = true;
			this.buttonAdd.Label = global::Mono.Unix.Catalog.GetString(">");
			this.vbox1.Add(this.buttonAdd);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.buttonAdd]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			this.hbox2.Add(this.vbox1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vbox1]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.permissionlistview = new global::QS.Project.Dialogs.GtkUI.PermissionListView();
			this.permissionlistview.Events = ((global::Gdk.EventMask)(256));
			this.permissionlistview.Name = "permissionlistview";
			this.hbox2.Add(this.permissionlistview);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.permissionlistview]));
			w5.Position = 2;
			this.vbox2.Add(this.hbox2);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox2]));
			w6.Position = 0;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.ytreeviewEntitiesList.RowActivated += new global::Gtk.RowActivatedHandler(this.OnYtreeviewEntitiesListRowActivated);
			this.buttonAdd.Clicked += new global::System.EventHandler(this.OnButtonAddClicked);
		}
	}
}
