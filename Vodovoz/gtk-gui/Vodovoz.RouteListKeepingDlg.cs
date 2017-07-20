
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class RouteListKeepingDlg
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox7;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Table table1;

		private global::Gamma.Widgets.yDatePicker datePickerDate;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button buttonMadeCall;

		private global::Gtk.Button buttonNewFine;

		private global::Gtk.Label label1;

		private global::Gtk.Label label10;

		private global::Gtk.Label label2;

		private global::Gtk.Label label3;

		private global::Gtk.Label label4;

		private global::Gtk.Label label5;

		private global::Gtk.Label label9;

		private global::Gtk.Label labelPhonesInfo;

		private global::Gamma.Widgets.yEntryReference referenceCar;

		private global::Gamma.Widgets.yEntryReference referenceDriver;

		private global::Gamma.Widgets.yEntryReference referenceForwarder;

		private global::Gamma.Widgets.yEntryReference referenceLogistican;

		private global::Gamma.Widgets.ySpecComboBox speccomboShift;

		private global::Gamma.GtkWidgets.yLabel ylabelLastTimeCall;

		private global::Gamma.GtkWidgets.ySpinButton yspinActualDistance;

		private global::Gtk.HBox hbox6;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewAddresses;

		private global::Gtk.HBox hbox8;

		private global::Gtk.Button buttonChangeDeliveryTime;

		private global::Gtk.Button buttonSetStatusComplete;

		private global::Gtk.Button buttonRetriveEnRoute;

		private global::Gtk.Button buttonRefresh;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.RouteListKeepingDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.RouteListKeepingDlg";
			// Container child Vodovoz.RouteListKeepingDlg.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			this.vbox1.BorderWidth = ((uint)(6));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox7.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox7.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			this.hbox7.Add(this.hbox3);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.hbox3]));
			w5.PackType = ((global::Gtk.PackType)(1));
			w5.Position = 2;
			this.vbox1.Add(this.hbox7);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox7]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(4)), ((uint)(5)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.datePickerDate = new global::Gamma.Widgets.yDatePicker();
			this.datePickerDate.Events = ((global::Gdk.EventMask)(256));
			this.datePickerDate.Name = "datePickerDate";
			this.datePickerDate.WithTime = false;
			this.datePickerDate.Date = new global::System.DateTime(0);
			this.datePickerDate.IsEditable = false;
			this.datePickerDate.AutoSeparation = false;
			this.table1.Add(this.datePickerDate);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.datePickerDate]));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonMadeCall = new global::Gtk.Button();
			this.buttonMadeCall.CanFocus = true;
			this.buttonMadeCall.Name = "buttonMadeCall";
			this.buttonMadeCall.UseUnderline = true;
			this.buttonMadeCall.Label = global::Mono.Unix.Catalog.GetString("Сделан звонок");
			this.hbox2.Add(this.buttonMadeCall);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonMadeCall]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonNewFine = new global::Gtk.Button();
			this.buttonNewFine.CanFocus = true;
			this.buttonNewFine.Name = "buttonNewFine";
			this.buttonNewFine.UseUnderline = true;
			this.buttonNewFine.Label = global::Mono.Unix.Catalog.GetString("Новый штраф");
			this.hbox2.Add(this.buttonNewFine);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonNewFine]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			this.table1.Add(this.hbox2);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox2]));
			w10.TopAttach = ((uint)(3));
			w10.BottomAttach = ((uint)(4));
			w10.LeftAttach = ((uint)(4));
			w10.RightAttach = ((uint)(5));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Смена:");
			this.table1.Add(this.label1);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.label1]));
			w11.TopAttach = ((uint)(1));
			w11.BottomAttach = ((uint)(2));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label10 = new global::Gtk.Label();
			this.label10.Name = "label10";
			this.label10.Xalign = 1F;
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString("Логист:");
			this.table1.Add(this.label10);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1[this.label10]));
			w12.LeftAttach = ((uint)(2));
			w12.RightAttach = ((uint)(3));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Дата:");
			this.table1.Add(this.label2);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Водитель:");
			this.table1.Add(this.label3);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1[this.label3]));
			w14.TopAttach = ((uint)(2));
			w14.BottomAttach = ((uint)(3));
			w14.LeftAttach = ((uint)(2));
			w14.RightAttach = ((uint)(3));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Машина:");
			this.table1.Add(this.label4);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table1[this.label4]));
			w15.TopAttach = ((uint)(1));
			w15.BottomAttach = ((uint)(2));
			w15.LeftAttach = ((uint)(2));
			w15.RightAttach = ((uint)(3));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Фактическое расстояние:");
			this.table1.Add(this.label5);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table1[this.label5]));
			w16.TopAttach = ((uint)(3));
			w16.BottomAttach = ((uint)(4));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label9 = new global::Gtk.Label();
			this.label9.Name = "label9";
			this.label9.Xalign = 1F;
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString("Экспедитор:");
			this.table1.Add(this.label9);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table1[this.label9]));
			w17.TopAttach = ((uint)(3));
			w17.BottomAttach = ((uint)(4));
			w17.LeftAttach = ((uint)(2));
			w17.RightAttach = ((uint)(3));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelPhonesInfo = new global::Gtk.Label();
			this.labelPhonesInfo.Name = "labelPhonesInfo";
			this.labelPhonesInfo.Xalign = 0F;
			this.labelPhonesInfo.Yalign = 0F;
			this.labelPhonesInfo.UseMarkup = true;
			this.labelPhonesInfo.Selectable = true;
			this.table1.Add(this.labelPhonesInfo);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.table1[this.labelPhonesInfo]));
			w18.BottomAttach = ((uint)(2));
			w18.LeftAttach = ((uint)(4));
			w18.RightAttach = ((uint)(5));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.referenceCar = new global::Gamma.Widgets.yEntryReference();
			this.referenceCar.Events = ((global::Gdk.EventMask)(256));
			this.referenceCar.Name = "referenceCar";
			this.table1.Add(this.referenceCar);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.table1[this.referenceCar]));
			w19.TopAttach = ((uint)(1));
			w19.BottomAttach = ((uint)(2));
			w19.LeftAttach = ((uint)(3));
			w19.RightAttach = ((uint)(4));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.referenceDriver = new global::Gamma.Widgets.yEntryReference();
			this.referenceDriver.Events = ((global::Gdk.EventMask)(256));
			this.referenceDriver.Name = "referenceDriver";
			this.table1.Add(this.referenceDriver);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.table1[this.referenceDriver]));
			w20.TopAttach = ((uint)(2));
			w20.BottomAttach = ((uint)(3));
			w20.LeftAttach = ((uint)(3));
			w20.RightAttach = ((uint)(4));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.referenceForwarder = new global::Gamma.Widgets.yEntryReference();
			this.referenceForwarder.Events = ((global::Gdk.EventMask)(256));
			this.referenceForwarder.Name = "referenceForwarder";
			this.table1.Add(this.referenceForwarder);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.table1[this.referenceForwarder]));
			w21.TopAttach = ((uint)(3));
			w21.BottomAttach = ((uint)(4));
			w21.LeftAttach = ((uint)(3));
			w21.RightAttach = ((uint)(4));
			w21.XOptions = ((global::Gtk.AttachOptions)(4));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.referenceLogistican = new global::Gamma.Widgets.yEntryReference();
			this.referenceLogistican.Events = ((global::Gdk.EventMask)(256));
			this.referenceLogistican.Name = "referenceLogistican";
			this.table1.Add(this.referenceLogistican);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.table1[this.referenceLogistican]));
			w22.LeftAttach = ((uint)(3));
			w22.RightAttach = ((uint)(4));
			w22.XOptions = ((global::Gtk.AttachOptions)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.speccomboShift = new global::Gamma.Widgets.ySpecComboBox();
			this.speccomboShift.Name = "speccomboShift";
			this.speccomboShift.AddIfNotExist = false;
			this.speccomboShift.DefaultFirst = false;
			this.speccomboShift.ShowSpecialStateAll = false;
			this.speccomboShift.ShowSpecialStateNot = false;
			this.table1.Add(this.speccomboShift);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.table1[this.speccomboShift]));
			w23.TopAttach = ((uint)(1));
			w23.BottomAttach = ((uint)(2));
			w23.LeftAttach = ((uint)(1));
			w23.RightAttach = ((uint)(2));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabelLastTimeCall = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelLastTimeCall.Name = "ylabelLastTimeCall";
			this.ylabelLastTimeCall.Xalign = 0F;
			this.ylabelLastTimeCall.LabelProp = global::Mono.Unix.Catalog.GetString("ylabel1");
			this.table1.Add(this.ylabelLastTimeCall);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabelLastTimeCall]));
			w24.TopAttach = ((uint)(2));
			w24.BottomAttach = ((uint)(3));
			w24.LeftAttach = ((uint)(4));
			w24.RightAttach = ((uint)(5));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yspinActualDistance = new global::Gamma.GtkWidgets.ySpinButton(0, 10000, 1);
			this.yspinActualDistance.CanFocus = true;
			this.yspinActualDistance.Name = "yspinActualDistance";
			this.yspinActualDistance.Adjustment.PageIncrement = 10;
			this.yspinActualDistance.ClimbRate = 1;
			this.yspinActualDistance.Numeric = true;
			this.yspinActualDistance.ValueAsDecimal = 0m;
			this.yspinActualDistance.ValueAsInt = 0;
			this.table1.Add(this.yspinActualDistance);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.table1[this.yspinActualDistance]));
			w25.TopAttach = ((uint)(3));
			w25.BottomAttach = ((uint)(4));
			w25.LeftAttach = ((uint)(1));
			w25.RightAttach = ((uint)(2));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add(this.table1);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.table1]));
			w26.Position = 1;
			w26.Expand = false;
			w26.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreeviewAddresses = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewAddresses.CanFocus = true;
			this.ytreeviewAddresses.Name = "ytreeviewAddresses";
			this.GtkScrolledWindow.Add(this.ytreeviewAddresses);
			this.hbox6.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.GtkScrolledWindow]));
			w28.Position = 0;
			this.vbox1.Add(this.hbox6);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox6]));
			w29.Position = 2;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.buttonChangeDeliveryTime = new global::Gtk.Button();
			this.buttonChangeDeliveryTime.CanFocus = true;
			this.buttonChangeDeliveryTime.Name = "buttonChangeDeliveryTime";
			this.buttonChangeDeliveryTime.UseUnderline = true;
			this.buttonChangeDeliveryTime.Label = global::Mono.Unix.Catalog.GetString("Изменить время доставки");
			global::Gtk.Image w30 = new global::Gtk.Image();
			w30.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("document-open-recent.png");
			this.buttonChangeDeliveryTime.Image = w30;
			this.hbox8.Add(this.buttonChangeDeliveryTime);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.buttonChangeDeliveryTime]));
			w31.Position = 0;
			w31.Expand = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.buttonSetStatusComplete = new global::Gtk.Button();
			this.buttonSetStatusComplete.CanFocus = true;
			this.buttonSetStatusComplete.Name = "buttonSetStatusComplete";
			this.buttonSetStatusComplete.UseUnderline = true;
			this.buttonSetStatusComplete.Label = global::Mono.Unix.Catalog.GetString("Установить в статус \"Выпонено\"");
			this.hbox8.Add(this.buttonSetStatusComplete);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.buttonSetStatusComplete]));
			w32.Position = 1;
			w32.Expand = false;
			w32.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.buttonRetriveEnRoute = new global::Gtk.Button();
			this.buttonRetriveEnRoute.CanFocus = true;
			this.buttonRetriveEnRoute.Name = "buttonRetriveEnRoute";
			this.buttonRetriveEnRoute.UseUnderline = true;
			this.buttonRetriveEnRoute.Label = global::Mono.Unix.Catalog.GetString("Вернуть статус \"В пути\"");
			this.hbox8.Add(this.buttonRetriveEnRoute);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.buttonRetriveEnRoute]));
			w33.Position = 2;
			w33.Expand = false;
			w33.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.buttonRefresh = new global::Gtk.Button();
			this.buttonRefresh.CanFocus = true;
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.UseUnderline = true;
			this.buttonRefresh.Label = global::Mono.Unix.Catalog.GetString("Обновить");
			global::Gtk.Image w34 = new global::Gtk.Image();
			w34.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-refresh", global::Gtk.IconSize.Menu);
			this.buttonRefresh.Image = w34;
			this.hbox8.Add(this.buttonRefresh);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.buttonRefresh]));
			w35.PackType = ((global::Gtk.PackType)(1));
			w35.Position = 3;
			w35.Expand = false;
			w35.Fill = false;
			this.vbox1.Add(this.hbox8);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox8]));
			w36.Position = 3;
			w36.Expand = false;
			w36.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonMadeCall.Clicked += new global::System.EventHandler(this.OnButtonMadeCallClicked);
			this.buttonNewFine.Clicked += new global::System.EventHandler(this.OnButtonNewFineClicked);
			this.buttonChangeDeliveryTime.Clicked += new global::System.EventHandler(this.OnButtonChangeDeliveryTimeClicked);
			this.buttonSetStatusComplete.Clicked += new global::System.EventHandler(this.OnButtonSetStatusCompleteClicked);
			this.buttonRetriveEnRoute.Clicked += new global::System.EventHandler(this.OnButtonRetriveEnRouteClicked);
			this.buttonRefresh.Clicked += new global::System.EventHandler(this.OnButtonRefreshClicked);
		}
	}
}
