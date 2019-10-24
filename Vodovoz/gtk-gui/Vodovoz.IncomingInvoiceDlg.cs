
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class IncomingInvoiceDlg
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Table tableInvoice;

		private global::Gamma.GtkWidgets.yEntry entryInvoiceNumber;

		private global::Gamma.GtkWidgets.yEntry entryWaybillNumber;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gamma.GtkWidgets.yTextView ytextviewComment;

		private global::Gtk.Label label1;

		private global::Gtk.Label label2;

		private global::Gtk.Label label4;

		private global::Gtk.Label label5;

		private global::Gtk.Label label6;

		private global::Gtk.Label labelCounterparty;

		private global::Gamma.GtkWidgets.yLabel labelTimeStamp;

		private global::QS.Widgets.GtkUI.RepresentationEntry referenceContractor;

		private global::Gamma.Widgets.yEntryReference referenceWarehouse;

		private global::Vodovoz.IncomingInvoiceItemsView incominginvoiceitemsview1;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.IncomingInvoiceDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.IncomingInvoiceDlg";
			// Container child Vodovoz.IncomingInvoiceDlg.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox2.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox2.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox1.Add(this.hbox2);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.tableInvoice = new global::Gtk.Table(((uint)(5)), ((uint)(3)), false);
			this.tableInvoice.Name = "tableInvoice";
			this.tableInvoice.RowSpacing = ((uint)(6));
			this.tableInvoice.ColumnSpacing = ((uint)(6));
			// Container child tableInvoice.Gtk.Table+TableChild
			this.entryInvoiceNumber = new global::Gamma.GtkWidgets.yEntry();
			this.entryInvoiceNumber.CanFocus = true;
			this.entryInvoiceNumber.Name = "entryInvoiceNumber";
			this.entryInvoiceNumber.IsEditable = true;
			this.entryInvoiceNumber.MaxLength = 45;
			this.entryInvoiceNumber.InvisibleChar = '●';
			this.tableInvoice.Add(this.entryInvoiceNumber);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.tableInvoice[this.entryInvoiceNumber]));
			w6.TopAttach = ((uint)(2));
			w6.BottomAttach = ((uint)(3));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInvoice.Gtk.Table+TableChild
			this.entryWaybillNumber = new global::Gamma.GtkWidgets.yEntry();
			this.entryWaybillNumber.CanFocus = true;
			this.entryWaybillNumber.Name = "entryWaybillNumber";
			this.entryWaybillNumber.IsEditable = true;
			this.entryWaybillNumber.MaxLength = 45;
			this.entryWaybillNumber.InvisibleChar = '●';
			this.tableInvoice.Add(this.entryWaybillNumber);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.tableInvoice[this.entryWaybillNumber]));
			w7.TopAttach = ((uint)(1));
			w7.BottomAttach = ((uint)(2));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInvoice.Gtk.Table+TableChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.ytextviewComment = new global::Gamma.GtkWidgets.yTextView();
			this.ytextviewComment.CanFocus = true;
			this.ytextviewComment.Name = "ytextviewComment";
			this.GtkScrolledWindow1.Add(this.ytextviewComment);
			this.tableInvoice.Add(this.GtkScrolledWindow1);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.tableInvoice[this.GtkScrolledWindow1]));
			w9.TopAttach = ((uint)(2));
			w9.BottomAttach = ((uint)(5));
			w9.LeftAttach = ((uint)(2));
			w9.RightAttach = ((uint)(3));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInvoice.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Дата:");
			this.tableInvoice.Add(this.label1);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.tableInvoice[this.label1]));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInvoice.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Склад:");
			this.tableInvoice.Add(this.label2);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.tableInvoice[this.label2]));
			w11.TopAttach = ((uint)(4));
			w11.BottomAttach = ((uint)(5));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInvoice.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Номер накладной:");
			this.tableInvoice.Add(this.label4);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.tableInvoice[this.label4]));
			w12.TopAttach = ((uint)(1));
			w12.BottomAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInvoice.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Номер счета-фактуры:");
			this.tableInvoice.Add(this.label5);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.tableInvoice[this.label5]));
			w13.TopAttach = ((uint)(2));
			w13.BottomAttach = ((uint)(3));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInvoice.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.Xalign = 0F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Комментарий</b>");
			this.label6.UseMarkup = true;
			this.tableInvoice.Add(this.label6);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.tableInvoice[this.label6]));
			w14.TopAttach = ((uint)(1));
			w14.BottomAttach = ((uint)(2));
			w14.LeftAttach = ((uint)(2));
			w14.RightAttach = ((uint)(3));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInvoice.Gtk.Table+TableChild
			this.labelCounterparty = new global::Gtk.Label();
			this.labelCounterparty.Name = "labelCounterparty";
			this.labelCounterparty.Xalign = 1F;
			this.labelCounterparty.LabelProp = global::Mono.Unix.Catalog.GetString("Контрагент:");
			this.tableInvoice.Add(this.labelCounterparty);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.tableInvoice[this.labelCounterparty]));
			w15.TopAttach = ((uint)(3));
			w15.BottomAttach = ((uint)(4));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInvoice.Gtk.Table+TableChild
			this.labelTimeStamp = new global::Gamma.GtkWidgets.yLabel();
			this.labelTimeStamp.Name = "labelTimeStamp";
			this.labelTimeStamp.Xalign = 0F;
			this.tableInvoice.Add(this.labelTimeStamp);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.tableInvoice[this.labelTimeStamp]));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInvoice.Gtk.Table+TableChild
			this.referenceContractor = new global::QS.Widgets.GtkUI.RepresentationEntry();
			this.referenceContractor.Events = ((global::Gdk.EventMask)(256));
			this.referenceContractor.Name = "referenceContractor";
			this.tableInvoice.Add(this.referenceContractor);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.tableInvoice[this.referenceContractor]));
			w17.TopAttach = ((uint)(3));
			w17.BottomAttach = ((uint)(4));
			w17.LeftAttach = ((uint)(1));
			w17.RightAttach = ((uint)(2));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInvoice.Gtk.Table+TableChild
			this.referenceWarehouse = new global::Gamma.Widgets.yEntryReference();
			this.referenceWarehouse.Events = ((global::Gdk.EventMask)(256));
			this.referenceWarehouse.Name = "referenceWarehouse";
			this.tableInvoice.Add(this.referenceWarehouse);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.tableInvoice[this.referenceWarehouse]));
			w18.TopAttach = ((uint)(4));
			w18.BottomAttach = ((uint)(5));
			w18.LeftAttach = ((uint)(1));
			w18.RightAttach = ((uint)(2));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add(this.tableInvoice);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.tableInvoice]));
			w19.Position = 1;
			w19.Expand = false;
			w19.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.incominginvoiceitemsview1 = new global::Vodovoz.IncomingInvoiceItemsView();
			this.incominginvoiceitemsview1.Events = ((global::Gdk.EventMask)(256));
			this.incominginvoiceitemsview1.Name = "incominginvoiceitemsview1";
			this.vbox1.Add(this.incominginvoiceitemsview1);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.incominginvoiceitemsview1]));
			w20.Position = 2;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
