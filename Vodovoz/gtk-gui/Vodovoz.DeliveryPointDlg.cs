
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class DeliveryPointDlg
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Button buttonSave;
		
		private global::Gtk.Button buttonCancel;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.DataBindings.DataTable datatable1;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		
		private global::Gtk.DataBindings.DataTextView textComment;
		
		private global::Gtk.HBox hbox11;
		
		private global::Gtk.DataBindings.DataEntryReference referenceLogisticsArea;
		
		private global::Gtk.Label label20;
		
		private global::Gamma.GtkWidgets.yLabel ylabelDistrictOfCity;
		
		private global::Gtk.HBox hbox5;
		
		private global::Gtk.Label label19;
		
		private global::QSOrmProject.DataValidatedEntry entryPhone;
		
		private global::Gtk.HBox hbox6;
		
		private global::Gtk.DataBindings.DataLabel labelCompiledAddress;
		
		private global::Gamma.GtkWidgets.yLabel ylabelFoundOnOsm;
		
		private global::Gtk.DataBindings.DataCheckButton checkIsActive;
		
		private global::Gtk.HBox hbox7;
		
		private global::QSOsm.CityEntry entryCity;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.DataBindings.DataEntry entryRegion;
		
		private global::Gtk.HBox hbox8;
		
		private global::QSOsm.StreetEntry entryStreet;
		
		private global::Gtk.Label label7;
		
		private global::QSOsm.HouseEntry entryBuilding;
		
		private global::Gtk.HBox hbox9;
		
		private global::Gamma.Widgets.yEnumComboBox comboRoomType;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.DataBindings.DataEntry entryRoom;
		
		private global::Gtk.Label label9;
		
		private global::Gtk.DataBindings.DataSpinButton spinFloor;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.Label label10;
		
		private global::Gtk.Label label11;
		
		private global::Gtk.Label label14;
		
		private global::Gtk.Label label15;
		
		private global::Gtk.Label label18;
		
		private global::Gtk.Label label4;
		
		private global::Gtk.Label label5;
		
		private global::Gtk.Label label6;
		
		private global::Gtk.DataBindings.DataEntryReferenceVM referenceContact;
		
		private global::Gtk.DataBindings.DataEntryReference referenceDeliverySchedule;
		
		private global::Gtk.DataBindings.DataSpinButton spinMinutesToUnload;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Vodovoz.DeliveryPointDlg
			global::Stetic.BinContainer.Attach (this);
			this.Name = "Vodovoz.DeliveryPointDlg";
			// Container child Vodovoz.DeliveryPointDlg.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			this.vbox1.BorderWidth = ((uint)(6));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button ();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString ("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image ();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox1.Add (this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString ("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox1.Add (this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			this.GtkScrolledWindow.BorderWidth = ((uint)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			global::Gtk.Viewport w6 = new global::Gtk.Viewport ();
			w6.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.datatable1 = new global::Gtk.DataBindings.DataTable (((uint)(10)), ((uint)(2)), false);
			this.datatable1.Name = "datatable1";
			this.datatable1.RowSpacing = ((uint)(6));
			this.datatable1.ColumnSpacing = ((uint)(6));
			this.datatable1.BorderWidth = ((uint)(6));
			this.datatable1.InheritedDataSource = false;
			this.datatable1.InheritedBoundaryDataSource = false;
			this.datatable1.InheritedDataSource = false;
			this.datatable1.InheritedBoundaryDataSource = false;
			// Container child datatable1.Gtk.Table+TableChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.textComment = new global::Gtk.DataBindings.DataTextView ();
			this.textComment.CanFocus = true;
			this.textComment.Name = "textComment";
			this.textComment.InheritedDataSource = true;
			this.textComment.Mappings = "Comment";
			this.textComment.InheritedBoundaryDataSource = false;
			this.textComment.InheritedDataSource = true;
			this.textComment.Mappings = "Comment";
			this.textComment.InheritedBoundaryDataSource = false;
			this.GtkScrolledWindow1.Add (this.textComment);
			this.datatable1.Add (this.GtkScrolledWindow1);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.GtkScrolledWindow1]));
			w8.TopAttach = ((uint)(6));
			w8.BottomAttach = ((uint)(7));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.hbox11 = new global::Gtk.HBox ();
			this.hbox11.Name = "hbox11";
			this.hbox11.Spacing = 6;
			// Container child hbox11.Gtk.Box+BoxChild
			this.referenceLogisticsArea = new global::Gtk.DataBindings.DataEntryReference ();
			this.referenceLogisticsArea.TooltipMarkup = "При проставлении логистического района у данной точки доставки он проставится у всех точек доставки с совпадающим до номера дома включительно адресом.";
			this.referenceLogisticsArea.Events = ((global::Gdk.EventMask)(256));
			this.referenceLogisticsArea.Name = "referenceLogisticsArea";
			this.referenceLogisticsArea.DisplayFields = new string[] {
				"Name"
			};
			this.referenceLogisticsArea.DisplayFormatString = "{0}";
			this.referenceLogisticsArea.InheritedDataSource = true;
			this.referenceLogisticsArea.Mappings = "LogisticsArea";
			this.referenceLogisticsArea.ColumnMappings = "";
			this.referenceLogisticsArea.InheritedBoundaryDataSource = false;
			this.referenceLogisticsArea.CursorPointsEveryType = false;
			this.hbox11.Add (this.referenceLogisticsArea);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox11 [this.referenceLogisticsArea]));
			w9.Position = 0;
			// Container child hbox11.Gtk.Box+BoxChild
			this.label20 = new global::Gtk.Label ();
			this.label20.Name = "label20";
			this.label20.LabelProp = global::Mono.Unix.Catalog.GetString ("Район города:");
			this.hbox11.Add (this.label20);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox11 [this.label20]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox11.Gtk.Box+BoxChild
			this.ylabelDistrictOfCity = new global::Gamma.GtkWidgets.yLabel ();
			this.ylabelDistrictOfCity.Name = "ylabelDistrictOfCity";
			this.ylabelDistrictOfCity.LabelProp = global::Mono.Unix.Catalog.GetString ("отсутствует");
			this.hbox11.Add (this.ylabelDistrictOfCity);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox11 [this.ylabelDistrictOfCity]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			this.datatable1.Add (this.hbox11);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.hbox11]));
			w12.TopAttach = ((uint)(4));
			w12.BottomAttach = ((uint)(5));
			w12.LeftAttach = ((uint)(1));
			w12.RightAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label19 = new global::Gtk.Label ();
			this.label19.Name = "label19";
			this.label19.LabelProp = global::Mono.Unix.Catalog.GetString ("+7");
			this.hbox5.Add (this.label19);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.label19]));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.entryPhone = new global::QSOrmProject.DataValidatedEntry ();
			this.entryPhone.WidthRequest = 0;
			this.entryPhone.CanFocus = true;
			this.entryPhone.Name = "entryPhone";
			this.entryPhone.IsEditable = true;
			this.entryPhone.InvisibleChar = '●';
			this.entryPhone.InheritedDataSource = true;
			this.entryPhone.Mappings = "Phone";
			this.entryPhone.InheritedBoundaryDataSource = false;
			this.hbox5.Add (this.entryPhone);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.entryPhone]));
			w14.Position = 1;
			this.datatable1.Add (this.hbox5);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.hbox5]));
			w15.TopAttach = ((uint)(8));
			w15.BottomAttach = ((uint)(9));
			w15.LeftAttach = ((uint)(1));
			w15.RightAttach = ((uint)(2));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.hbox6 = new global::Gtk.HBox ();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.labelCompiledAddress = new global::Gtk.DataBindings.DataLabel ();
			this.labelCompiledAddress.Name = "labelCompiledAddress";
			this.labelCompiledAddress.Xalign = 0F;
			this.labelCompiledAddress.Wrap = true;
			this.labelCompiledAddress.Selectable = true;
			this.labelCompiledAddress.InheritedDataSource = true;
			this.labelCompiledAddress.Mappings = "CompiledAddress";
			this.labelCompiledAddress.InheritedBoundaryDataSource = false;
			this.labelCompiledAddress.Important = false;
			this.labelCompiledAddress.InheritedDataSource = true;
			this.labelCompiledAddress.Mappings = "CompiledAddress";
			this.labelCompiledAddress.InheritedBoundaryDataSource = false;
			this.hbox6.Add (this.labelCompiledAddress);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.labelCompiledAddress]));
			w16.Position = 0;
			// Container child hbox6.Gtk.Box+BoxChild
			this.ylabelFoundOnOsm = new global::Gamma.GtkWidgets.yLabel ();
			this.ylabelFoundOnOsm.Name = "ylabelFoundOnOsm";
			this.ylabelFoundOnOsm.LabelProp = global::Mono.Unix.Catalog.GetString ("FoundOnOsm");
			this.ylabelFoundOnOsm.UseMarkup = true;
			this.ylabelFoundOnOsm.Selectable = true;
			this.hbox6.Add (this.ylabelFoundOnOsm);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.ylabelFoundOnOsm]));
			w17.Position = 1;
			w17.Expand = false;
			w17.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.checkIsActive = new global::Gtk.DataBindings.DataCheckButton ();
			this.checkIsActive.CanFocus = true;
			this.checkIsActive.Name = "checkIsActive";
			this.checkIsActive.Label = global::Mono.Unix.Catalog.GetString ("Активный");
			this.checkIsActive.DrawIndicator = true;
			this.checkIsActive.UseUnderline = true;
			this.checkIsActive.InheritedDataSource = true;
			this.checkIsActive.Mappings = "IsActive";
			this.checkIsActive.InheritedBoundaryDataSource = false;
			this.checkIsActive.Editable = true;
			this.checkIsActive.AutomaticTitle = false;
			this.checkIsActive.InheritedBoundaryDataSource = false;
			this.checkIsActive.InheritedDataSource = true;
			this.checkIsActive.Mappings = "IsActive";
			this.hbox6.Add (this.checkIsActive);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.checkIsActive]));
			w18.Position = 2;
			w18.Expand = false;
			w18.Fill = false;
			this.datatable1.Add (this.hbox6);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.hbox6]));
			w19.LeftAttach = ((uint)(1));
			w19.RightAttach = ((uint)(2));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.hbox7 = new global::Gtk.HBox ();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.entryCity = new global::QSOsm.CityEntry ();
			this.entryCity.CanFocus = true;
			this.entryCity.Name = "entryCity";
			this.entryCity.IsEditable = true;
			this.entryCity.InvisibleChar = '●';
			this.hbox7.Add (this.entryCity);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.entryCity]));
			w20.Position = 0;
			// Container child hbox7.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Регион:");
			this.hbox7.Add (this.label3);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.label3]));
			w21.Position = 1;
			w21.Expand = false;
			w21.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.entryRegion = new global::Gtk.DataBindings.DataEntry ();
			this.entryRegion.Sensitive = false;
			this.entryRegion.CanFocus = true;
			this.entryRegion.Name = "entryRegion";
			this.entryRegion.IsEditable = true;
			this.entryRegion.InvisibleChar = '●';
			this.entryRegion.InheritedDataSource = true;
			this.entryRegion.Mappings = "Region";
			this.entryRegion.InheritedBoundaryDataSource = false;
			this.entryRegion.InheritedDataSource = true;
			this.entryRegion.Mappings = "Region";
			this.entryRegion.InheritedBoundaryDataSource = false;
			this.hbox7.Add (this.entryRegion);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.entryRegion]));
			w22.Position = 2;
			this.datatable1.Add (this.hbox7);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.hbox7]));
			w23.TopAttach = ((uint)(1));
			w23.BottomAttach = ((uint)(2));
			w23.LeftAttach = ((uint)(1));
			w23.RightAttach = ((uint)(2));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.hbox8 = new global::Gtk.HBox ();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.entryStreet = new global::QSOsm.StreetEntry ();
			this.entryStreet.CanFocus = true;
			this.entryStreet.Name = "entryStreet";
			this.entryStreet.IsEditable = true;
			this.entryStreet.InvisibleChar = '●';
			this.entryStreet.CityId = 0;
			this.hbox8.Add (this.entryStreet);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.entryStreet]));
			w24.Position = 0;
			// Container child hbox8.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Дом:");
			this.hbox8.Add (this.label7);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.label7]));
			w25.Position = 1;
			w25.Expand = false;
			w25.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.entryBuilding = new global::QSOsm.HouseEntry ();
			this.entryBuilding.CanFocus = true;
			this.entryBuilding.Name = "entryBuilding";
			this.entryBuilding.IsEditable = true;
			this.entryBuilding.WidthChars = 20;
			this.entryBuilding.MaxLength = 20;
			this.entryBuilding.InvisibleChar = '●';
			this.hbox8.Add (this.entryBuilding);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.entryBuilding]));
			w26.Position = 2;
			w26.Expand = false;
			w26.Fill = false;
			this.datatable1.Add (this.hbox8);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.hbox8]));
			w27.TopAttach = ((uint)(2));
			w27.BottomAttach = ((uint)(3));
			w27.LeftAttach = ((uint)(1));
			w27.RightAttach = ((uint)(2));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.hbox9 = new global::Gtk.HBox ();
			this.hbox9.Name = "hbox9";
			this.hbox9.Spacing = 6;
			// Container child hbox9.Gtk.Box+BoxChild
			this.comboRoomType = new global::Gamma.Widgets.yEnumComboBox ();
			this.comboRoomType.Name = "comboRoomType";
			this.comboRoomType.ShowSpecialStateAll = false;
			this.comboRoomType.ShowSpecialStateNot = false;
			this.comboRoomType.UseShortTitle = false;
			this.comboRoomType.DefaultFirst = false;
			this.hbox9.Add (this.comboRoomType);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.comboRoomType]));
			w28.Position = 0;
			w28.Expand = false;
			w28.Fill = false;
			// Container child hbox9.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("№:");
			this.hbox9.Add (this.label2);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.label2]));
			w29.Position = 1;
			w29.Expand = false;
			w29.Fill = false;
			// Container child hbox9.Gtk.Box+BoxChild
			this.entryRoom = new global::Gtk.DataBindings.DataEntry ();
			this.entryRoom.CanFocus = true;
			this.entryRoom.Name = "entryRoom";
			this.entryRoom.IsEditable = true;
			this.entryRoom.InvisibleChar = '●';
			this.entryRoom.InheritedDataSource = true;
			this.entryRoom.Mappings = "Room";
			this.entryRoom.InheritedBoundaryDataSource = false;
			this.entryRoom.InheritedDataSource = true;
			this.entryRoom.Mappings = "Room";
			this.entryRoom.InheritedBoundaryDataSource = false;
			this.hbox9.Add (this.entryRoom);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.entryRoom]));
			w30.Position = 2;
			// Container child hbox9.Gtk.Box+BoxChild
			this.label9 = new global::Gtk.Label ();
			this.label9.Name = "label9";
			this.label9.Xalign = 1F;
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString ("Этаж:");
			this.hbox9.Add (this.label9);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.label9]));
			w31.Position = 3;
			w31.Expand = false;
			w31.Fill = false;
			// Container child hbox9.Gtk.Box+BoxChild
			this.spinFloor = new global::Gtk.DataBindings.DataSpinButton (-5, 100, 1);
			this.spinFloor.CanFocus = true;
			this.spinFloor.Name = "spinFloor";
			this.spinFloor.Adjustment.PageIncrement = 10;
			this.spinFloor.ClimbRate = 1;
			this.spinFloor.Numeric = true;
			this.spinFloor.InheritedDataSource = true;
			this.spinFloor.Mappings = "Floor";
			this.spinFloor.InheritedBoundaryDataSource = false;
			this.spinFloor.InheritedDataSource = true;
			this.spinFloor.Mappings = "Floor";
			this.spinFloor.InheritedBoundaryDataSource = false;
			this.hbox9.Add (this.spinFloor);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.spinFloor]));
			w32.Position = 4;
			w32.Expand = false;
			w32.Fill = false;
			this.datatable1.Add (this.hbox9);
			global::Gtk.Table.TableChild w33 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.hbox9]));
			w33.TopAttach = ((uint)(3));
			w33.BottomAttach = ((uint)(4));
			w33.LeftAttach = ((uint)(1));
			w33.RightAttach = ((uint)(2));
			w33.XOptions = ((global::Gtk.AttachOptions)(4));
			w33.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Название:");
			this.datatable1.Add (this.label1);
			global::Gtk.Table.TableChild w34 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.label1]));
			w34.XOptions = ((global::Gtk.AttachOptions)(4));
			w34.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label10 = new global::Gtk.Label ();
			this.label10.Name = "label10";
			this.label10.Xalign = 1F;
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString ("Приблизительное время\nразгрузки (минуты):");
			this.label10.Justify = ((global::Gtk.Justification)(1));
			this.datatable1.Add (this.label10);
			global::Gtk.Table.TableChild w35 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.label10]));
			w35.TopAttach = ((uint)(5));
			w35.BottomAttach = ((uint)(6));
			w35.XOptions = ((global::Gtk.AttachOptions)(4));
			w35.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label11 = new global::Gtk.Label ();
			this.label11.Name = "label11";
			this.label11.Xalign = 1F;
			this.label11.Yalign = 0F;
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString ("Комментарий:");
			this.datatable1.Add (this.label11);
			global::Gtk.Table.TableChild w36 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.label11]));
			w36.TopAttach = ((uint)(6));
			w36.BottomAttach = ((uint)(7));
			w36.XOptions = ((global::Gtk.AttachOptions)(4));
			w36.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label14 = new global::Gtk.Label ();
			this.label14.Name = "label14";
			this.label14.Xalign = 1F;
			this.label14.LabelProp = global::Mono.Unix.Catalog.GetString ("Ответственное лицо:");
			this.datatable1.Add (this.label14);
			global::Gtk.Table.TableChild w37 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.label14]));
			w37.TopAttach = ((uint)(7));
			w37.BottomAttach = ((uint)(8));
			w37.XOptions = ((global::Gtk.AttachOptions)(4));
			w37.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label15 = new global::Gtk.Label ();
			this.label15.Name = "label15";
			this.label15.Xalign = 1F;
			this.label15.LabelProp = global::Mono.Unix.Catalog.GetString ("Телефон точки \nдоставки:");
			this.label15.Justify = ((global::Gtk.Justification)(1));
			this.datatable1.Add (this.label15);
			global::Gtk.Table.TableChild w38 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.label15]));
			w38.TopAttach = ((uint)(8));
			w38.BottomAttach = ((uint)(9));
			w38.XOptions = ((global::Gtk.AttachOptions)(4));
			w38.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label18 = new global::Gtk.Label ();
			this.label18.Name = "label18";
			this.label18.Xalign = 1F;
			this.label18.LabelProp = global::Mono.Unix.Catalog.GetString ("Время доставки \nпо-умолчанию:");
			this.label18.Justify = ((global::Gtk.Justification)(1));
			this.datatable1.Add (this.label18);
			global::Gtk.Table.TableChild w39 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.label18]));
			w39.TopAttach = ((uint)(9));
			w39.BottomAttach = ((uint)(10));
			w39.XOptions = ((global::Gtk.AttachOptions)(4));
			w39.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Город:");
			this.datatable1.Add (this.label4);
			global::Gtk.Table.TableChild w40 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.label4]));
			w40.TopAttach = ((uint)(1));
			w40.BottomAttach = ((uint)(2));
			w40.XOptions = ((global::Gtk.AttachOptions)(4));
			w40.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Логистический район:");
			this.label5.Justify = ((global::Gtk.Justification)(1));
			this.datatable1.Add (this.label5);
			global::Gtk.Table.TableChild w41 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.label5]));
			w41.TopAttach = ((uint)(4));
			w41.BottomAttach = ((uint)(5));
			w41.XOptions = ((global::Gtk.AttachOptions)(4));
			w41.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Улица:");
			this.datatable1.Add (this.label6);
			global::Gtk.Table.TableChild w42 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.label6]));
			w42.TopAttach = ((uint)(2));
			w42.BottomAttach = ((uint)(3));
			w42.XOptions = ((global::Gtk.AttachOptions)(4));
			w42.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.referenceContact = new global::Gtk.DataBindings.DataEntryReferenceVM ();
			this.referenceContact.Events = ((global::Gdk.EventMask)(256));
			this.referenceContact.Name = "referenceContact";
			this.referenceContact.InheritedDataSource = true;
			this.referenceContact.Mappings = "Contact";
			this.referenceContact.ColumnMappings = "";
			this.referenceContact.InheritedBoundaryDataSource = false;
			this.referenceContact.CursorPointsEveryType = false;
			this.datatable1.Add (this.referenceContact);
			global::Gtk.Table.TableChild w43 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.referenceContact]));
			w43.TopAttach = ((uint)(7));
			w43.BottomAttach = ((uint)(8));
			w43.LeftAttach = ((uint)(1));
			w43.RightAttach = ((uint)(2));
			w43.XOptions = ((global::Gtk.AttachOptions)(4));
			w43.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.referenceDeliverySchedule = new global::Gtk.DataBindings.DataEntryReference ();
			this.referenceDeliverySchedule.Events = ((global::Gdk.EventMask)(256));
			this.referenceDeliverySchedule.Name = "referenceDeliverySchedule";
			this.referenceDeliverySchedule.DisplayFields = new string[] {
				"Name"
			};
			this.referenceDeliverySchedule.DisplayFormatString = "{0}";
			this.referenceDeliverySchedule.InheritedDataSource = true;
			this.referenceDeliverySchedule.Mappings = "DeliverySchedule";
			this.referenceDeliverySchedule.ColumnMappings = "";
			this.referenceDeliverySchedule.InheritedBoundaryDataSource = false;
			this.referenceDeliverySchedule.CursorPointsEveryType = false;
			this.datatable1.Add (this.referenceDeliverySchedule);
			global::Gtk.Table.TableChild w44 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.referenceDeliverySchedule]));
			w44.TopAttach = ((uint)(9));
			w44.BottomAttach = ((uint)(10));
			w44.LeftAttach = ((uint)(1));
			w44.RightAttach = ((uint)(2));
			w44.XOptions = ((global::Gtk.AttachOptions)(4));
			w44.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.spinMinutesToUnload = new global::Gtk.DataBindings.DataSpinButton (0, 100, 1);
			this.spinMinutesToUnload.CanFocus = true;
			this.spinMinutesToUnload.Name = "spinMinutesToUnload";
			this.spinMinutesToUnload.Adjustment.PageIncrement = 10;
			this.spinMinutesToUnload.ClimbRate = 1;
			this.spinMinutesToUnload.Numeric = true;
			this.spinMinutesToUnload.InheritedDataSource = true;
			this.spinMinutesToUnload.Mappings = "MinutesToUnload";
			this.spinMinutesToUnload.InheritedBoundaryDataSource = false;
			this.spinMinutesToUnload.InheritedDataSource = true;
			this.spinMinutesToUnload.Mappings = "MinutesToUnload";
			this.spinMinutesToUnload.InheritedBoundaryDataSource = false;
			this.datatable1.Add (this.spinMinutesToUnload);
			global::Gtk.Table.TableChild w45 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.spinMinutesToUnload]));
			w45.TopAttach = ((uint)(5));
			w45.BottomAttach = ((uint)(6));
			w45.LeftAttach = ((uint)(1));
			w45.RightAttach = ((uint)(2));
			w45.YOptions = ((global::Gtk.AttachOptions)(4));
			w6.Add (this.datatable1);
			this.GtkScrolledWindow.Add (w6);
			this.vbox1.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w48 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
			w48.Position = 1;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.buttonSave.Clicked += new global::System.EventHandler (this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnButtonCancelClicked);
		}
	}
}
