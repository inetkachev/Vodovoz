﻿
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Filters.GtkViews
{
	public partial class OrderFilterView
	{
		private global::Gtk.Table table1;

		private global::QS.Widgets.GtkUI.DateRangePicker dateperiodOrders;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry entryCounterparty;

		private global::Gamma.Widgets.yEnumComboBox enumcomboPaymentType;

		private global::Gamma.Widgets.yEnumComboBox enumcomboStatus;

		private global::Gtk.HBox hbox4;

		private global::Gamma.GtkWidgets.yCheckButton ycheckOnlySelfdelivery;

		private global::Gamma.GtkWidgets.yCheckButton ycheckWithoutSelfdelivery;

		private global::Gtk.HBox hbox5;

		private global::Gamma.GtkWidgets.yCheckButton ycheckOnlyServices;

		private global::Gamma.GtkWidgets.yCheckButton ycheckHideServices;

		private global::Gtk.Label label1;

		private global::Gtk.Label label2;

		private global::Gtk.Label label3;

		private global::Gtk.Label label4;

		private global::Gtk.Label label5;

		private global::QS.Widgets.GtkUI.RepresentationEntry representationentryDeliveryPoint;

		private global::Gamma.GtkWidgets.yCheckButton ycheckLessThreeHours;

		private global::Gamma.GtkWidgets.yCheckButton ycheckOnlyWithoutCoordinates;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Filters.GtkViews.OrderFilterView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Filters.GtkViews.OrderFilterView";
			// Container child Vodovoz.Filters.GtkViews.OrderFilterView.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(3)), ((uint)(7)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.dateperiodOrders = new global::QS.Widgets.GtkUI.DateRangePicker();
			this.dateperiodOrders.Events = ((global::Gdk.EventMask)(256));
			this.dateperiodOrders.Name = "dateperiodOrders";
			this.dateperiodOrders.StartDate = new global::System.DateTime(0);
			this.dateperiodOrders.EndDate = new global::System.DateTime(0);
			this.table1.Add(this.dateperiodOrders);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.dateperiodOrders]));
			w1.LeftAttach = ((uint)(5));
			w1.RightAttach = ((uint)(6));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entryCounterparty = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.entryCounterparty.Events = ((global::Gdk.EventMask)(256));
			this.entryCounterparty.Name = "entryCounterparty";
			this.entryCounterparty.CanEditReference = false;
			this.table1.Add(this.entryCounterparty);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.entryCounterparty]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.enumcomboPaymentType = new global::Gamma.Widgets.yEnumComboBox();
			this.enumcomboPaymentType.Name = "enumcomboPaymentType";
			this.enumcomboPaymentType.ShowSpecialStateAll = true;
			this.enumcomboPaymentType.ShowSpecialStateNot = false;
			this.enumcomboPaymentType.UseShortTitle = false;
			this.enumcomboPaymentType.DefaultFirst = false;
			this.table1.Add(this.enumcomboPaymentType);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.enumcomboPaymentType]));
			w3.LeftAttach = ((uint)(3));
			w3.RightAttach = ((uint)(4));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.enumcomboStatus = new global::Gamma.Widgets.yEnumComboBox();
			this.enumcomboStatus.Name = "enumcomboStatus";
			this.enumcomboStatus.ShowSpecialStateAll = true;
			this.enumcomboStatus.ShowSpecialStateNot = false;
			this.enumcomboStatus.UseShortTitle = false;
			this.enumcomboStatus.DefaultFirst = false;
			this.table1.Add(this.enumcomboStatus);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.enumcomboStatus]));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.ycheckOnlySelfdelivery = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckOnlySelfdelivery.CanFocus = true;
			this.ycheckOnlySelfdelivery.Name = "ycheckOnlySelfdelivery";
			this.ycheckOnlySelfdelivery.Label = global::Mono.Unix.Catalog.GetString("Только самовывоз");
			this.ycheckOnlySelfdelivery.DrawIndicator = true;
			this.ycheckOnlySelfdelivery.UseUnderline = true;
			this.hbox4.Add(this.ycheckOnlySelfdelivery);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.ycheckOnlySelfdelivery]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.ycheckWithoutSelfdelivery = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckWithoutSelfdelivery.CanFocus = true;
			this.ycheckWithoutSelfdelivery.Name = "ycheckWithoutSelfdelivery";
			this.ycheckWithoutSelfdelivery.Label = global::Mono.Unix.Catalog.GetString("Скрыть самовывозы");
			this.ycheckWithoutSelfdelivery.DrawIndicator = true;
			this.ycheckWithoutSelfdelivery.UseUnderline = true;
			this.hbox4.Add(this.ycheckWithoutSelfdelivery);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.ycheckWithoutSelfdelivery]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			this.table1.Add(this.hbox4);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox4]));
			w7.TopAttach = ((uint)(2));
			w7.BottomAttach = ((uint)(3));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(3));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.ycheckOnlyServices = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckOnlyServices.CanFocus = true;
			this.ycheckOnlyServices.Name = "ycheckOnlyServices";
			this.ycheckOnlyServices.Label = global::Mono.Unix.Catalog.GetString("Только выезд мастера");
			this.ycheckOnlyServices.DrawIndicator = true;
			this.ycheckOnlyServices.UseUnderline = true;
			this.hbox5.Add(this.ycheckOnlyServices);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.ycheckOnlyServices]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.ycheckHideServices = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckHideServices.CanFocus = true;
			this.ycheckHideServices.Name = "ycheckHideServices";
			this.ycheckHideServices.Label = global::Mono.Unix.Catalog.GetString("Скрыть выезд мастера");
			this.ycheckHideServices.DrawIndicator = true;
			this.ycheckHideServices.UseUnderline = true;
			this.hbox5.Add(this.ycheckHideServices);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.ycheckHideServices]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			this.table1.Add(this.hbox5);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox5]));
			w10.TopAttach = ((uint)(2));
			w10.BottomAttach = ((uint)(3));
			w10.LeftAttach = ((uint)(3));
			w10.RightAttach = ((uint)(6));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Статус:");
			this.table1.Add(this.label1);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.label1]));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Контрагент:");
			this.table1.Add(this.label2);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w12.TopAttach = ((uint)(1));
			w12.BottomAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Точка доставки:");
			this.table1.Add(this.label3);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.label3]));
			w13.TopAttach = ((uint)(1));
			w13.BottomAttach = ((uint)(2));
			w13.LeftAttach = ((uint)(2));
			w13.RightAttach = ((uint)(3));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Период:");
			this.table1.Add(this.label4);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1[this.label4]));
			w14.LeftAttach = ((uint)(4));
			w14.RightAttach = ((uint)(5));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Тип оплаты:");
			this.table1.Add(this.label5);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table1[this.label5]));
			w15.LeftAttach = ((uint)(2));
			w15.RightAttach = ((uint)(3));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.representationentryDeliveryPoint = new global::QS.Widgets.GtkUI.RepresentationEntry();
			this.representationentryDeliveryPoint.Events = ((global::Gdk.EventMask)(256));
			this.representationentryDeliveryPoint.Name = "representationentryDeliveryPoint";
			this.table1.Add(this.representationentryDeliveryPoint);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table1[this.representationentryDeliveryPoint]));
			w16.TopAttach = ((uint)(1));
			w16.BottomAttach = ((uint)(2));
			w16.LeftAttach = ((uint)(3));
			w16.RightAttach = ((uint)(6));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ycheckLessThreeHours = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckLessThreeHours.CanFocus = true;
			this.ycheckLessThreeHours.Name = "ycheckLessThreeHours";
			this.ycheckLessThreeHours.Label = global::Mono.Unix.Catalog.GetString("Менее 3-х часов");
			this.ycheckLessThreeHours.DrawIndicator = true;
			this.ycheckLessThreeHours.UseUnderline = true;
			this.table1.Add(this.ycheckLessThreeHours);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table1[this.ycheckLessThreeHours]));
			w17.TopAttach = ((uint)(1));
			w17.BottomAttach = ((uint)(2));
			w17.LeftAttach = ((uint)(6));
			w17.RightAttach = ((uint)(7));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ycheckOnlyWithoutCoordinates = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckOnlyWithoutCoordinates.CanFocus = true;
			this.ycheckOnlyWithoutCoordinates.Name = "ycheckOnlyWithoutCoordinates";
			this.ycheckOnlyWithoutCoordinates.Label = global::Mono.Unix.Catalog.GetString("Только без координат");
			this.ycheckOnlyWithoutCoordinates.DrawIndicator = true;
			this.ycheckOnlyWithoutCoordinates.UseUnderline = true;
			this.table1.Add(this.ycheckOnlyWithoutCoordinates);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.table1[this.ycheckOnlyWithoutCoordinates]));
			w18.LeftAttach = ((uint)(6));
			w18.RightAttach = ((uint)(7));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
