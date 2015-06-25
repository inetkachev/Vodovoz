
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class IncomingWaterDlg
	{
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.HBox hbox3;
		
		private global::Gtk.Button buttonSave;
		
		private global::Gtk.Button buttonCancel;
		
		private global::Gtk.DataBindings.DataTable tableWater;
		
		private global::Vodovoz.IncomingWaterMaterialView incomingwatermaterialview1;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Label label5;
		
		private global::Gtk.Label label6;
		
		private global::Gtk.DataBindings.DataLabel labelTimeStamp;
		
		private global::Gtk.DataBindings.DataEntryReference referenceDstWarehouse;
		
		private global::Gtk.DataBindings.DataEntryReference referenceProduct;
		
		private global::Gtk.DataBindings.DataEntryReference referenceSrcWarehouse;
		
		private global::Gtk.DataBindings.DataSpinButton spinAmount;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Vodovoz.IncomingWaterDlg
			global::Stetic.BinContainer.Attach (this);
			this.Name = "Vodovoz.IncomingWaterDlg";
			// Container child Vodovoz.IncomingWaterDlg.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button ();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString ("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image ();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox3.Add (this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString ("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox3.Add (this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox2.Add (this.hbox3);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox3]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.tableWater = new global::Gtk.DataBindings.DataTable (((uint)(6)), ((uint)(2)), false);
			this.tableWater.Name = "tableWater";
			this.tableWater.RowSpacing = ((uint)(6));
			this.tableWater.ColumnSpacing = ((uint)(6));
			this.tableWater.InheritedDataSource = false;
			this.tableWater.InheritedBoundaryDataSource = false;
			this.tableWater.InheritedDataSource = false;
			this.tableWater.InheritedBoundaryDataSource = false;
			// Container child tableWater.Gtk.Table+TableChild
			this.incomingwatermaterialview1 = new global::Vodovoz.IncomingWaterMaterialView ();
			this.incomingwatermaterialview1.Events = ((global::Gdk.EventMask)(256));
			this.incomingwatermaterialview1.Name = "incomingwatermaterialview1";
			this.tableWater.Add (this.incomingwatermaterialview1);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.tableWater [this.incomingwatermaterialview1]));
			w6.TopAttach = ((uint)(5));
			w6.BottomAttach = ((uint)(6));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWater.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Дата документа:");
			this.tableWater.Add (this.label1);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.tableWater [this.label1]));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWater.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Количество единиц:");
			this.tableWater.Add (this.label2);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.tableWater [this.label2]));
			w8.TopAttach = ((uint)(2));
			w8.BottomAttach = ((uint)(3));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWater.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Склад поступления:");
			this.tableWater.Add (this.label3);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.tableWater [this.label3]));
			w9.TopAttach = ((uint)(3));
			w9.BottomAttach = ((uint)(4));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWater.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Склад списания:");
			this.tableWater.Add (this.label5);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.tableWater [this.label5]));
			w10.TopAttach = ((uint)(4));
			w10.BottomAttach = ((uint)(5));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWater.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Продукт производства:");
			this.tableWater.Add (this.label6);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.tableWater [this.label6]));
			w11.TopAttach = ((uint)(1));
			w11.BottomAttach = ((uint)(2));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWater.Gtk.Table+TableChild
			this.labelTimeStamp = new global::Gtk.DataBindings.DataLabel ();
			this.labelTimeStamp.Name = "labelTimeStamp";
			this.labelTimeStamp.Xalign = 0F;
			this.labelTimeStamp.InheritedDataSource = true;
			this.labelTimeStamp.Mappings = "DateString";
			this.labelTimeStamp.InheritedBoundaryDataSource = false;
			this.labelTimeStamp.Important = false;
			this.labelTimeStamp.InheritedDataSource = true;
			this.labelTimeStamp.Mappings = "DateString";
			this.labelTimeStamp.InheritedBoundaryDataSource = false;
			this.tableWater.Add (this.labelTimeStamp);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.tableWater [this.labelTimeStamp]));
			w12.LeftAttach = ((uint)(1));
			w12.RightAttach = ((uint)(2));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWater.Gtk.Table+TableChild
			this.referenceDstWarehouse = new global::Gtk.DataBindings.DataEntryReference ();
			this.referenceDstWarehouse.Events = ((global::Gdk.EventMask)(256));
			this.referenceDstWarehouse.Name = "referenceDstWarehouse";
			this.referenceDstWarehouse.DisplayFields = new string[] {
				"Name"
			};
			this.referenceDstWarehouse.DisplayFormatString = "{0}";
			this.referenceDstWarehouse.InheritedDataSource = true;
			this.referenceDstWarehouse.Mappings = "IncomingWarehouse";
			this.referenceDstWarehouse.InheritedBoundaryDataSource = false;
			this.referenceDstWarehouse.CursorPointsEveryType = false;
			this.tableWater.Add (this.referenceDstWarehouse);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.tableWater [this.referenceDstWarehouse]));
			w13.TopAttach = ((uint)(3));
			w13.BottomAttach = ((uint)(4));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWater.Gtk.Table+TableChild
			this.referenceProduct = new global::Gtk.DataBindings.DataEntryReference ();
			this.referenceProduct.Events = ((global::Gdk.EventMask)(256));
			this.referenceProduct.Name = "referenceProduct";
			this.referenceProduct.DisplayFields = new string[] {
				"Name"
			};
			this.referenceProduct.DisplayFormatString = "{0}";
			this.referenceProduct.InheritedDataSource = true;
			this.referenceProduct.Mappings = "Product";
			this.referenceProduct.InheritedBoundaryDataSource = false;
			this.referenceProduct.CursorPointsEveryType = false;
			this.tableWater.Add (this.referenceProduct);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.tableWater [this.referenceProduct]));
			w14.TopAttach = ((uint)(1));
			w14.BottomAttach = ((uint)(2));
			w14.LeftAttach = ((uint)(1));
			w14.RightAttach = ((uint)(2));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWater.Gtk.Table+TableChild
			this.referenceSrcWarehouse = new global::Gtk.DataBindings.DataEntryReference ();
			this.referenceSrcWarehouse.Events = ((global::Gdk.EventMask)(256));
			this.referenceSrcWarehouse.Name = "referenceSrcWarehouse";
			this.referenceSrcWarehouse.DisplayFields = new string[] {
				"Name"
			};
			this.referenceSrcWarehouse.DisplayFormatString = "{0}";
			this.referenceSrcWarehouse.InheritedDataSource = true;
			this.referenceSrcWarehouse.Mappings = "WriteOffWarehouse";
			this.referenceSrcWarehouse.InheritedBoundaryDataSource = false;
			this.referenceSrcWarehouse.CursorPointsEveryType = false;
			this.tableWater.Add (this.referenceSrcWarehouse);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.tableWater [this.referenceSrcWarehouse]));
			w15.TopAttach = ((uint)(4));
			w15.BottomAttach = ((uint)(5));
			w15.LeftAttach = ((uint)(1));
			w15.RightAttach = ((uint)(2));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWater.Gtk.Table+TableChild
			this.spinAmount = new global::Gtk.DataBindings.DataSpinButton (1, 100, 1);
			this.spinAmount.CanFocus = true;
			this.spinAmount.Name = "spinAmount";
			this.spinAmount.Adjustment.PageIncrement = 10;
			this.spinAmount.ClimbRate = 1;
			this.spinAmount.Numeric = true;
			this.spinAmount.Value = 1;
			this.spinAmount.InheritedDataSource = true;
			this.spinAmount.Mappings = "Amount";
			this.spinAmount.InheritedBoundaryDataSource = false;
			this.spinAmount.InheritedDataSource = true;
			this.spinAmount.Mappings = "Amount";
			this.spinAmount.InheritedBoundaryDataSource = false;
			this.tableWater.Add (this.spinAmount);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.tableWater [this.spinAmount]));
			w16.TopAttach = ((uint)(2));
			w16.BottomAttach = ((uint)(3));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add (this.tableWater);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.tableWater]));
			w17.Position = 1;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.buttonSave.Clicked += new global::System.EventHandler (this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnButtonCancelClicked);
		}
	}
}
