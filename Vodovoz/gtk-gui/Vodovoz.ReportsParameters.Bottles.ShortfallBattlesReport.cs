
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.ReportsParameters.Bottles
{
	public partial class ShortfallBattlesReport
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Label label2;

		private global::Gamma.Widgets.yDatePicker ydatepicker;

		private global::Gtk.Table table1;

		private global::Gtk.CheckButton checkOneDriver;

		private global::Gtk.CheckButton checkReason;

		private global::Gamma.Widgets.yEnumComboBox comboboxDriver;

		private global::Gtk.VBox vbox3;

		private global::Gtk.RadioButton radiobuttonNewAddress;

		private global::Gtk.RadioButton radiobuttonOrderIncrease;

		private global::Gtk.VBox vbox4;

		private global::Gtk.RadioButton radiobuttonFirstOrder;

		private global::Gtk.RadioButton radiobuttonUnknown;

		private global::Gtk.Label label1;

		private global::Gamma.Widgets.yEntryReference yentryDriver;

		private global::Gtk.Button buttonCreateRepot;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ReportsParameters.Bottles.ShortfallBattlesReport
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.ReportsParameters.Bottles.ShortfallBattlesReport";
			// Container child Vodovoz.ReportsParameters.Bottles.ShortfallBattlesReport.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Дата:");
			this.hbox3.Add(this.label2);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label2]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.ydatepicker = new global::Gamma.Widgets.yDatePicker();
			this.ydatepicker.Events = ((global::Gdk.EventMask)(256));
			this.ydatepicker.Name = "ydatepicker";
			this.ydatepicker.WithTime = false;
			this.ydatepicker.Date = new global::System.DateTime(0);
			this.ydatepicker.IsEditable = true;
			this.ydatepicker.AutoSeparation = false;
			this.hbox3.Add(this.ydatepicker);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.ydatepicker]));
			w2.Position = 1;
			this.vbox1.Add(this.hbox3);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox3]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(5)), ((uint)(1)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.checkOneDriver = new global::Gtk.CheckButton();
			this.checkOneDriver.CanFocus = true;
			this.checkOneDriver.Name = "checkOneDriver";
			this.checkOneDriver.Label = global::Mono.Unix.Catalog.GetString("По водителю");
			this.checkOneDriver.DrawIndicator = true;
			this.checkOneDriver.UseUnderline = true;
			this.table1.Add(this.checkOneDriver);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.checkOneDriver]));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.checkReason = new global::Gtk.CheckButton();
			this.checkReason.CanFocus = true;
			this.checkReason.Name = "checkReason";
			this.checkReason.Label = global::Mono.Unix.Catalog.GetString("Причина несдачи:");
			this.checkReason.DrawIndicator = true;
			this.checkReason.UseUnderline = true;
			this.table1.Add(this.checkReason);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.checkReason]));
			w5.TopAttach = ((uint)(2));
			w5.BottomAttach = ((uint)(3));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.comboboxDriver = new global::Gamma.Widgets.yEnumComboBox();
			this.comboboxDriver.Name = "comboboxDriver";
			this.comboboxDriver.ShowSpecialStateAll = false;
			this.comboboxDriver.ShowSpecialStateNot = false;
			this.comboboxDriver.UseShortTitle = false;
			this.comboboxDriver.DefaultFirst = true;
			this.table1.Add(this.comboboxDriver);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.comboboxDriver]));
			w6.TopAttach = ((uint)(4));
			w6.BottomAttach = ((uint)(5));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.vbox3 = new global::Gtk.VBox();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.radiobuttonNewAddress = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("новый адрес"));
			this.radiobuttonNewAddress.Sensitive = false;
			this.radiobuttonNewAddress.CanFocus = true;
			this.radiobuttonNewAddress.Name = "radiobuttonNewAddress";
			this.radiobuttonNewAddress.DrawIndicator = true;
			this.radiobuttonNewAddress.UseUnderline = true;
			this.radiobuttonNewAddress.Group = new global::GLib.SList(global::System.IntPtr.Zero);
			this.vbox3.Add(this.radiobuttonNewAddress);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.radiobuttonNewAddress]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.radiobuttonOrderIncrease = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("увеличение заказа"));
			this.radiobuttonOrderIncrease.Sensitive = false;
			this.radiobuttonOrderIncrease.CanFocus = true;
			this.radiobuttonOrderIncrease.Name = "radiobuttonOrderIncrease";
			this.radiobuttonOrderIncrease.DrawIndicator = true;
			this.radiobuttonOrderIncrease.UseUnderline = true;
			this.radiobuttonOrderIncrease.Group = this.radiobuttonNewAddress.Group;
			this.vbox3.Add(this.radiobuttonOrderIncrease);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.radiobuttonOrderIncrease]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.radiobuttonFirstOrder = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("первый заказ"));
			this.radiobuttonFirstOrder.Sensitive = false;
			this.radiobuttonFirstOrder.CanFocus = true;
			this.radiobuttonFirstOrder.Name = "radiobuttonFirstOrder";
			this.radiobuttonFirstOrder.DrawIndicator = true;
			this.radiobuttonFirstOrder.UseUnderline = true;
			this.radiobuttonFirstOrder.Group = this.radiobuttonNewAddress.Group;
			this.vbox4.Add(this.radiobuttonFirstOrder);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.radiobuttonFirstOrder]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.radiobuttonUnknown = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("неизвестно"));
			this.radiobuttonUnknown.Sensitive = false;
			this.radiobuttonUnknown.CanFocus = true;
			this.radiobuttonUnknown.Name = "radiobuttonUnknown";
			this.radiobuttonUnknown.DrawIndicator = true;
			this.radiobuttonUnknown.UseUnderline = true;
			this.radiobuttonUnknown.Group = this.radiobuttonNewAddress.Group;
			this.vbox4.Add(this.radiobuttonUnknown);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.radiobuttonUnknown]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Водитель без отзвона");
			this.vbox4.Add(this.label1);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.label1]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			this.vbox3.Add(this.vbox4);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.vbox4]));
			w12.Position = 2;
			w12.Expand = false;
			w12.Fill = false;
			this.table1.Add(this.vbox3);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.vbox3]));
			w13.TopAttach = ((uint)(3));
			w13.BottomAttach = ((uint)(4));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryDriver = new global::Gamma.Widgets.yEntryReference();
			this.yentryDriver.Sensitive = false;
			this.yentryDriver.Events = ((global::Gdk.EventMask)(256));
			this.yentryDriver.Name = "yentryDriver";
			this.table1.Add(this.yentryDriver);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1[this.yentryDriver]));
			w14.TopAttach = ((uint)(1));
			w14.BottomAttach = ((uint)(2));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add(this.table1);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.table1]));
			w15.Position = 1;
			w15.Expand = false;
			w15.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.buttonCreateRepot = new global::Gtk.Button();
			this.buttonCreateRepot.CanFocus = true;
			this.buttonCreateRepot.Name = "buttonCreateRepot";
			this.buttonCreateRepot.UseUnderline = true;
			this.buttonCreateRepot.Label = global::Mono.Unix.Catalog.GetString("Сформировать отчет");
			this.vbox1.Add(this.buttonCreateRepot);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.buttonCreateRepot]));
			w16.PackType = ((global::Gtk.PackType)(1));
			w16.Position = 2;
			w16.Expand = false;
			w16.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.checkReason.Toggled += new global::System.EventHandler(this.OnCheckReasonToggled);
			this.checkOneDriver.Toggled += new global::System.EventHandler(this.OnCheckOneDriverToggled);
			this.buttonCreateRepot.Clicked += new global::System.EventHandler(this.OnButtonCreateRepotClicked);
		}
	}
}