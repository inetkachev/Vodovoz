
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

		private global::Gamma.Widgets.yEnumComboBox comboboxDriver;

		private global::Gamma.Widgets.yEntryReferenceVM yentryDriver;

		private global::Gamma.Widgets.ySpecComboBox ySpecCmbNonReturnReason;

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
			this.table1 = new global::Gtk.Table(((uint)(4)), ((uint)(1)), false);
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
			this.comboboxDriver = new global::Gamma.Widgets.yEnumComboBox();
			this.comboboxDriver.Name = "comboboxDriver";
			this.comboboxDriver.ShowSpecialStateAll = false;
			this.comboboxDriver.ShowSpecialStateNot = false;
			this.comboboxDriver.UseShortTitle = false;
			this.comboboxDriver.DefaultFirst = true;
			this.table1.Add(this.comboboxDriver);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.comboboxDriver]));
			w5.TopAttach = ((uint)(3));
			w5.BottomAttach = ((uint)(4));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryDriver = new global::Gamma.Widgets.yEntryReferenceVM();
			this.yentryDriver.Sensitive = false;
			this.yentryDriver.Events = ((global::Gdk.EventMask)(256));
			this.yentryDriver.Name = "yentryDriver";
			this.table1.Add(this.yentryDriver);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.yentryDriver]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ySpecCmbNonReturnReason = new global::Gamma.Widgets.ySpecComboBox();
			this.ySpecCmbNonReturnReason.Name = "ySpecCmbNonReturnReason";
			this.ySpecCmbNonReturnReason.AddIfNotExist = false;
			this.ySpecCmbNonReturnReason.DefaultFirst = true;
			this.ySpecCmbNonReturnReason.ShowSpecialStateAll = true;
			this.ySpecCmbNonReturnReason.ShowSpecialStateNot = false;
			this.table1.Add(this.ySpecCmbNonReturnReason);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.ySpecCmbNonReturnReason]));
			w7.TopAttach = ((uint)(2));
			w7.BottomAttach = ((uint)(3));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add(this.table1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.table1]));
			w8.Position = 1;
			// Container child vbox1.Gtk.Box+BoxChild
			this.buttonCreateRepot = new global::Gtk.Button();
			this.buttonCreateRepot.CanFocus = true;
			this.buttonCreateRepot.Name = "buttonCreateRepot";
			this.buttonCreateRepot.UseUnderline = true;
			this.buttonCreateRepot.Label = global::Mono.Unix.Catalog.GetString("Сформировать отчет");
			this.vbox1.Add(this.buttonCreateRepot);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.buttonCreateRepot]));
			w9.PackType = ((global::Gtk.PackType)(1));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.checkOneDriver.Toggled += new global::System.EventHandler(this.OnCheckOneDriverToggled);
			this.buttonCreateRepot.Clicked += new global::System.EventHandler(this.OnButtonCreateRepotClicked);
		}
	}
}
