
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class RouteListMileageCheckDlg
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox7;
		
		private global::Gtk.Button buttonSave;
		
		private global::Gtk.Button buttonCancel;
		
		private global::Gtk.Table table1;
		
		private global::Gtk.Button buttonConfirm;
		
		private global::Gamma.Widgets.yDatePicker datePickerDate;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.Label label10;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Label label4;
		
		private global::Gtk.Label label5;
		
		private global::Gtk.Label label6;
		
		private global::Gtk.Label label7;
		
		private global::Gtk.Label label9;
		
		private global::Gamma.Widgets.yEntryReference referenceCar;
		
		private global::Gamma.Widgets.yEntryReference referenceDriver;
		
		private global::Gamma.Widgets.yEntryReference referenceForwarder;
		
		private global::Gamma.Widgets.yEntryReference referenceLogistican;
		
		private global::Gamma.Widgets.ySpecComboBox speccomboShift;
		
		private global::Gamma.GtkWidgets.ySpinButton yspinActualDistance;
		
		private global::Gamma.GtkWidgets.ySpinButton yspinConfirmedDistance;
		
		private global::Gamma.GtkWidgets.ySpinButton yspinPlannedDistance;
		
		private global::Gtk.HBox hbox6;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gamma.GtkWidgets.yTreeView ytreeviewAddresses;
		
		private global::Gtk.HBox hbox8;
		
		private global::Gtk.Button buttonCloseRouteList;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Vodovoz.RouteListMileageCheckDlg
			global::Stetic.BinContainer.Attach (this);
			this.Name = "Vodovoz.RouteListMileageCheckDlg";
			// Container child Vodovoz.RouteListMileageCheckDlg.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			this.vbox1.BorderWidth = ((uint)(6));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox ();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button ();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString ("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image ();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox7.Add (this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString ("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox7.Add (this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox1.Add (this.hbox7);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox7]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table (((uint)(5)), ((uint)(4)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.buttonConfirm = new global::Gtk.Button ();
			this.buttonConfirm.CanFocus = true;
			this.buttonConfirm.Name = "buttonConfirm";
			this.buttonConfirm.UseUnderline = true;
			this.buttonConfirm.Label = global::Mono.Unix.Catalog.GetString ("Подтвердить");
			this.table1.Add (this.buttonConfirm);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1 [this.buttonConfirm]));
			w6.TopAttach = ((uint)(4));
			w6.BottomAttach = ((uint)(5));
			w6.LeftAttach = ((uint)(2));
			w6.RightAttach = ((uint)(3));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.datePickerDate = new global::Gamma.Widgets.yDatePicker ();
			this.datePickerDate.Events = ((global::Gdk.EventMask)(256));
			this.datePickerDate.Name = "datePickerDate";
			this.datePickerDate.Date = new global::System.DateTime (0);
			this.datePickerDate.IsEditable = false;
			this.datePickerDate.AutoSeparation = false;
			this.table1.Add (this.datePickerDate);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1 [this.datePickerDate]));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Смена:");
			this.table1.Add (this.label1);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1 [this.label1]));
			w8.TopAttach = ((uint)(1));
			w8.BottomAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label10 = new global::Gtk.Label ();
			this.label10.Name = "label10";
			this.label10.Xalign = 1F;
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString ("Логист:");
			this.table1.Add (this.label10);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1 [this.label10]));
			w9.LeftAttach = ((uint)(2));
			w9.RightAttach = ((uint)(3));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Дата:");
			this.table1.Add (this.label2);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1 [this.label2]));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Водитель:");
			this.table1.Add (this.label3);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1 [this.label3]));
			w11.TopAttach = ((uint)(2));
			w11.BottomAttach = ((uint)(3));
			w11.LeftAttach = ((uint)(2));
			w11.RightAttach = ((uint)(3));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Машина:");
			this.table1.Add (this.label4);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1 [this.label4]));
			w12.TopAttach = ((uint)(1));
			w12.BottomAttach = ((uint)(2));
			w12.LeftAttach = ((uint)(2));
			w12.RightAttach = ((uint)(3));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Фактическое расстояние:");
			this.table1.Add (this.label5);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1 [this.label5]));
			w13.TopAttach = ((uint)(3));
			w13.BottomAttach = ((uint)(4));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Планируемое расстояние:");
			this.table1.Add (this.label6);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1 [this.label6]));
			w14.TopAttach = ((uint)(2));
			w14.BottomAttach = ((uint)(3));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Подтвержденное расстояние:");
			this.table1.Add (this.label7);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table1 [this.label7]));
			w15.TopAttach = ((uint)(4));
			w15.BottomAttach = ((uint)(5));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label9 = new global::Gtk.Label ();
			this.label9.Name = "label9";
			this.label9.Xalign = 1F;
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString ("Экспедитор:");
			this.table1.Add (this.label9);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table1 [this.label9]));
			w16.TopAttach = ((uint)(3));
			w16.BottomAttach = ((uint)(4));
			w16.LeftAttach = ((uint)(2));
			w16.RightAttach = ((uint)(3));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.referenceCar = new global::Gamma.Widgets.yEntryReference ();
			this.referenceCar.Events = ((global::Gdk.EventMask)(256));
			this.referenceCar.Name = "referenceCar";
			this.table1.Add (this.referenceCar);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table1 [this.referenceCar]));
			w17.TopAttach = ((uint)(1));
			w17.BottomAttach = ((uint)(2));
			w17.LeftAttach = ((uint)(3));
			w17.RightAttach = ((uint)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.referenceDriver = new global::Gamma.Widgets.yEntryReference ();
			this.referenceDriver.Events = ((global::Gdk.EventMask)(256));
			this.referenceDriver.Name = "referenceDriver";
			this.table1.Add (this.referenceDriver);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.table1 [this.referenceDriver]));
			w18.TopAttach = ((uint)(2));
			w18.BottomAttach = ((uint)(3));
			w18.LeftAttach = ((uint)(3));
			w18.RightAttach = ((uint)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.referenceForwarder = new global::Gamma.Widgets.yEntryReference ();
			this.referenceForwarder.Events = ((global::Gdk.EventMask)(256));
			this.referenceForwarder.Name = "referenceForwarder";
			this.table1.Add (this.referenceForwarder);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.table1 [this.referenceForwarder]));
			w19.TopAttach = ((uint)(3));
			w19.BottomAttach = ((uint)(4));
			w19.LeftAttach = ((uint)(3));
			w19.RightAttach = ((uint)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.referenceLogistican = new global::Gamma.Widgets.yEntryReference ();
			this.referenceLogistican.Events = ((global::Gdk.EventMask)(256));
			this.referenceLogistican.Name = "referenceLogistican";
			this.table1.Add (this.referenceLogistican);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.table1 [this.referenceLogistican]));
			w20.LeftAttach = ((uint)(3));
			w20.RightAttach = ((uint)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.speccomboShift = new global::Gamma.Widgets.ySpecComboBox ();
			this.speccomboShift.Name = "speccomboShift";
			this.speccomboShift.AddIfNotExist = false;
			this.speccomboShift.ShowSpecialStateAll = false;
			this.speccomboShift.ShowSpecialStateNot = false;
			this.table1.Add (this.speccomboShift);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.table1 [this.speccomboShift]));
			w21.TopAttach = ((uint)(1));
			w21.BottomAttach = ((uint)(2));
			w21.LeftAttach = ((uint)(1));
			w21.RightAttach = ((uint)(2));
			w21.XOptions = ((global::Gtk.AttachOptions)(4));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yspinActualDistance = new global::Gamma.GtkWidgets.ySpinButton (0, 100, 1);
			this.yspinActualDistance.CanFocus = true;
			this.yspinActualDistance.Name = "yspinActualDistance";
			this.yspinActualDistance.Adjustment.PageIncrement = 10;
			this.yspinActualDistance.ClimbRate = 1;
			this.yspinActualDistance.Numeric = true;
			this.yspinActualDistance.ValueAsDecimal = 0m;
			this.yspinActualDistance.ValueAsInt = 0;
			this.table1.Add (this.yspinActualDistance);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.table1 [this.yspinActualDistance]));
			w22.TopAttach = ((uint)(3));
			w22.BottomAttach = ((uint)(4));
			w22.LeftAttach = ((uint)(1));
			w22.RightAttach = ((uint)(2));
			w22.XOptions = ((global::Gtk.AttachOptions)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yspinConfirmedDistance = new global::Gamma.GtkWidgets.ySpinButton (0, 100, 1);
			this.yspinConfirmedDistance.CanFocus = true;
			this.yspinConfirmedDistance.Name = "yspinConfirmedDistance";
			this.yspinConfirmedDistance.Adjustment.PageIncrement = 10;
			this.yspinConfirmedDistance.ClimbRate = 1;
			this.yspinConfirmedDistance.Numeric = true;
			this.yspinConfirmedDistance.ValueAsDecimal = 0m;
			this.yspinConfirmedDistance.ValueAsInt = 0;
			this.table1.Add (this.yspinConfirmedDistance);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.table1 [this.yspinConfirmedDistance]));
			w23.TopAttach = ((uint)(4));
			w23.BottomAttach = ((uint)(5));
			w23.LeftAttach = ((uint)(1));
			w23.RightAttach = ((uint)(2));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yspinPlannedDistance = new global::Gamma.GtkWidgets.ySpinButton (0, 100, 1);
			this.yspinPlannedDistance.CanFocus = true;
			this.yspinPlannedDistance.Name = "yspinPlannedDistance";
			this.yspinPlannedDistance.Adjustment.PageIncrement = 10;
			this.yspinPlannedDistance.ClimbRate = 1;
			this.yspinPlannedDistance.Numeric = true;
			this.yspinPlannedDistance.ValueAsDecimal = 0m;
			this.yspinPlannedDistance.ValueAsInt = 0;
			this.table1.Add (this.yspinPlannedDistance);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.table1 [this.yspinPlannedDistance]));
			w24.TopAttach = ((uint)(2));
			w24.BottomAttach = ((uint)(3));
			w24.LeftAttach = ((uint)(1));
			w24.RightAttach = ((uint)(2));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add (this.table1);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.table1]));
			w25.Position = 1;
			w25.Expand = false;
			w25.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox ();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreeviewAddresses = new global::Gamma.GtkWidgets.yTreeView ();
			this.ytreeviewAddresses.CanFocus = true;
			this.ytreeviewAddresses.Name = "ytreeviewAddresses";
			this.GtkScrolledWindow.Add (this.ytreeviewAddresses);
			this.hbox6.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.GtkScrolledWindow]));
			w27.Position = 0;
			this.vbox1.Add (this.hbox6);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox6]));
			w28.Position = 2;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox ();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.buttonCloseRouteList = new global::Gtk.Button ();
			this.buttonCloseRouteList.CanFocus = true;
			this.buttonCloseRouteList.Name = "buttonCloseRouteList";
			this.buttonCloseRouteList.UseUnderline = true;
			this.buttonCloseRouteList.Label = global::Mono.Unix.Catalog.GetString ("Закрыть маршрутный лист");
			global::Gtk.Image w29 = new global::Gtk.Image ();
			w29.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-apply", global::Gtk.IconSize.Menu);
			this.buttonCloseRouteList.Image = w29;
			this.hbox8.Add (this.buttonCloseRouteList);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.buttonCloseRouteList]));
			w30.PackType = ((global::Gtk.PackType)(1));
			w30.Position = 2;
			w30.Expand = false;
			w30.Fill = false;
			this.vbox1.Add (this.hbox8);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox8]));
			w31.PackType = ((global::Gtk.PackType)(1));
			w31.Position = 3;
			w31.Expand = false;
			w31.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.buttonSave.Clicked += new global::System.EventHandler (this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnButtonCancelClicked);
			this.buttonConfirm.Clicked += new global::System.EventHandler (this.OnButtonConfirmClicked);
			this.buttonCloseRouteList.Clicked += new global::System.EventHandler (this.OnButtonCloseRouteListClicked);
		}
	}
}
