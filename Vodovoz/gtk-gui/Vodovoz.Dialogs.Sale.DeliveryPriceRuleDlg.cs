
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Dialogs.Sale
{
	public partial class DeliveryPriceRuleDlg
	{
		private global::Gtk.VBox vbox5;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Table table2;

		private global::Gtk.Label lbl19LQty;

		private global::Gtk.Label lbl600mlQty;

		private global::Gtk.Label lbl6LQty;

		private global::Gamma.GtkWidgets.ySpinButton spin19LQty;

		private global::Gamma.GtkWidgets.yLabel ylabel600mlBottles;

		private global::Gamma.GtkWidgets.yLabel ylabel6LWater;

		private global::Gtk.VBox vboxDistricts;

		private global::Gtk.Label lblDistricts;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView treeDistricts;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Dialogs.Sale.DeliveryPriceRuleDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Dialogs.Sale.DeliveryPriceRuleDlg";
			// Container child Vodovoz.Dialogs.Sale.DeliveryPriceRuleDlg.Gtk.Container+ContainerChild
			this.vbox5 = new global::Gtk.VBox();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox3.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox3.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox5.Add(this.hbox3);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox3]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.table2 = new global::Gtk.Table(((uint)(7)), ((uint)(2)), false);
			this.table2.Name = "table2";
			this.table2.RowSpacing = ((uint)(6));
			this.table2.ColumnSpacing = ((uint)(6));
			// Container child table2.Gtk.Table+TableChild
			this.lbl19LQty = new global::Gtk.Label();
			this.lbl19LQty.Name = "lbl19LQty";
			this.lbl19LQty.Xalign = 1F;
			this.lbl19LQty.LabelProp = global::Mono.Unix.Catalog.GetString("Кол-во 19л бутылей:");
			this.table2.Add(this.lbl19LQty);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table2[this.lbl19LQty]));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.lbl600mlQty = new global::Gtk.Label();
			this.lbl600mlQty.Name = "lbl600mlQty";
			this.lbl600mlQty.Xalign = 1F;
			this.lbl600mlQty.LabelProp = global::Mono.Unix.Catalog.GetString("Кол-во 0.6л бутылей:");
			this.table2.Add(this.lbl600mlQty);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table2[this.lbl600mlQty]));
			w7.TopAttach = ((uint)(2));
			w7.BottomAttach = ((uint)(3));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.lbl6LQty = new global::Gtk.Label();
			this.lbl6LQty.Name = "lbl6LQty";
			this.lbl6LQty.Xalign = 1F;
			this.lbl6LQty.LabelProp = global::Mono.Unix.Catalog.GetString("Кол-во 6л бутылей:");
			this.table2.Add(this.lbl6LQty);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table2[this.lbl6LQty]));
			w8.TopAttach = ((uint)(1));
			w8.BottomAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.spin19LQty = new global::Gamma.GtkWidgets.ySpinButton(0D, 500D, 2D);
			this.spin19LQty.CanFocus = true;
			this.spin19LQty.Name = "spin19LQty";
			this.spin19LQty.Adjustment.PageIncrement = 10D;
			this.spin19LQty.ClimbRate = 2D;
			this.spin19LQty.Numeric = true;
			this.spin19LQty.Value = 2D;
			this.spin19LQty.ValueAsDecimal = 0m;
			this.spin19LQty.ValueAsInt = 0;
			this.table2.Add(this.spin19LQty);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table2[this.spin19LQty]));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.ylabel600mlBottles = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel600mlBottles.Name = "ylabel600mlBottles";
			this.ylabel600mlBottles.Xalign = 0F;
			this.table2.Add(this.ylabel600mlBottles);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table2[this.ylabel600mlBottles]));
			w10.TopAttach = ((uint)(2));
			w10.BottomAttach = ((uint)(3));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.ylabel6LWater = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel6LWater.Name = "ylabel6LWater";
			this.ylabel6LWater.Xalign = 0F;
			this.table2.Add(this.ylabel6LWater);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table2[this.ylabel6LWater]));
			w11.TopAttach = ((uint)(1));
			w11.BottomAttach = ((uint)(2));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			this.hbox2.Add(this.table2);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.table2]));
			w12.Position = 0;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vboxDistricts = new global::Gtk.VBox();
			this.vboxDistricts.Name = "vboxDistricts";
			this.vboxDistricts.Spacing = 6;
			// Container child vboxDistricts.Gtk.Box+BoxChild
			this.lblDistricts = new global::Gtk.Label();
			this.lblDistricts.Name = "lblDistricts";
			this.lblDistricts.Xalign = 0F;
			this.lblDistricts.LabelProp = global::Mono.Unix.Catalog.GetString("Правило используется в районах:");
			this.vboxDistricts.Add(this.lblDistricts);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vboxDistricts[this.lblDistricts]));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vboxDistricts.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.HscrollbarPolicy = ((global::Gtk.PolicyType)(2));
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeDistricts = new global::Gamma.GtkWidgets.yTreeView();
			this.treeDistricts.CanFocus = true;
			this.treeDistricts.Name = "treeDistricts";
			this.GtkScrolledWindow.Add(this.treeDistricts);
			this.vboxDistricts.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vboxDistricts[this.GtkScrolledWindow]));
			w15.Position = 1;
			this.hbox2.Add(this.vboxDistricts);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vboxDistricts]));
			w16.Position = 1;
			this.vbox5.Add(this.hbox2);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox2]));
			w17.Position = 1;
			w17.Expand = false;
			w17.Fill = false;
			this.Add(this.vbox5);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
