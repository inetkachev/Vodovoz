
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class WarehouseDlg
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label labelName;

		private global::Gamma.GtkWidgets.yEntry yentryName;

		private global::Gamma.GtkWidgets.yCheckButton ycheckbuttonCanReceiveBottles;

		private global::Gamma.GtkWidgets.yCheckButton ycheckbuttonCanReceiveEquipment;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.WarehouseDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.WarehouseDlg";
			// Container child Vodovoz.WarehouseDlg.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox4.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox4.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox2.Add(this.hbox4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox4]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.labelName = new global::Gtk.Label();
			this.labelName.Name = "labelName";
			this.labelName.Xalign = 1F;
			this.labelName.LabelProp = global::Mono.Unix.Catalog.GetString("Название:");
			this.hbox1.Add(this.labelName);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.labelName]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.yentryName = new global::Gamma.GtkWidgets.yEntry();
			this.yentryName.CanFocus = true;
			this.yentryName.Name = "yentryName";
			this.yentryName.IsEditable = true;
			this.yentryName.InvisibleChar = '•';
			this.hbox1.Add(this.yentryName);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.yentryName]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			this.vbox2.Add(this.hbox1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.ycheckbuttonCanReceiveBottles = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckbuttonCanReceiveBottles.CanFocus = true;
			this.ycheckbuttonCanReceiveBottles.Name = "ycheckbuttonCanReceiveBottles";
			this.ycheckbuttonCanReceiveBottles.Label = global::Mono.Unix.Catalog.GetString("Прием тары");
			this.ycheckbuttonCanReceiveBottles.DrawIndicator = true;
			this.ycheckbuttonCanReceiveBottles.UseUnderline = true;
			this.vbox2.Add(this.ycheckbuttonCanReceiveBottles);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.ycheckbuttonCanReceiveBottles]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.ycheckbuttonCanReceiveEquipment = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckbuttonCanReceiveEquipment.CanFocus = true;
			this.ycheckbuttonCanReceiveEquipment.Name = "ycheckbuttonCanReceiveEquipment";
			this.ycheckbuttonCanReceiveEquipment.Label = global::Mono.Unix.Catalog.GetString("Прием оборудования");
			this.ycheckbuttonCanReceiveEquipment.DrawIndicator = true;
			this.ycheckbuttonCanReceiveEquipment.UseUnderline = true;
			this.vbox2.Add(this.ycheckbuttonCanReceiveEquipment);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.ycheckbuttonCanReceiveEquipment]));
			w10.Position = 3;
			w10.Expand = false;
			w10.Fill = false;
			this.Add(this.vbox2);
			if((this.Child != null)) {
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonSave.Clicked += new global::System.EventHandler(this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler(this.OnButtonCancelClicked);
		}
	}
}
