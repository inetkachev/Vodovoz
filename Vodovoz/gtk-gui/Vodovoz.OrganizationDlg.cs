
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class OrganizationDlg
	{
		private global::Gtk.UIManager UIManager;

		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.VSeparator vseparator1;

		private global::Gtk.RadioButton radioTabInfo;

		private global::Gtk.RadioButton radioTabAccounts;

		private global::Gtk.Notebook notebookMain;

		private global::Gtk.ScrolledWindow scrolledwindow1;

		private global::Gtk.Table datatableMain;

		private global::Gamma.Widgets.yValidatedEntry dataentryEmail;

		private global::Gamma.GtkWidgets.yEntry dataentryFullName;

		private global::Gamma.Widgets.yValidatedEntry dataentryINN;

		private global::Gamma.Widgets.yValidatedEntry dataentryKPP;

		private global::Gamma.GtkWidgets.yEntry dataentryName;

		private global::Gamma.Widgets.yValidatedEntry dataentryOGRN;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gamma.GtkWidgets.yTextView datatextviewJurAddress;

		private global::Gtk.ScrolledWindow GtkScrolledWindow2;

		private global::Gamma.GtkWidgets.yTextView datatextviewAddress;

		private global::Gtk.Label label10;

		private global::Gtk.Label label11;

		private global::Gtk.Label label13;

		private global::Gtk.Label label14;

		private global::Gtk.Label label3;

		private global::Gtk.Label label4;

		private global::Gtk.Label label5;

		private global::Gtk.Label label6;

		private global::Gtk.Label label7;

		private global::Gtk.Label label8;

		private global::Gtk.Label label9;

		private global::QSContacts.PhonesView phonesview1;

		private global::Gamma.Widgets.yEntryReferenceVM referenceBuhgalter;

		private global::Gamma.Widgets.yEntryReferenceVM referenceLeader;

		private global::Gtk.Label label1;

		private global::QSBanks.AccountsView accountsview1;

		private global::Gtk.Label label12;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.OrganizationDlg
			Stetic.BinContainer w1 = global::Stetic.BinContainer.Attach(this);
			this.UIManager = new global::Gtk.UIManager();
			global::Gtk.ActionGroup w2 = new global::Gtk.ActionGroup("Default");
			this.UIManager.InsertActionGroup(w2, 0);
			this.Name = "Vodovoz.OrganizationDlg";
			// Container child Vodovoz.OrganizationDlg.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w3;
			this.hbox1.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonSave]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w5 = new global::Gtk.Image();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w5;
			this.hbox1.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonCancel]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator();
			this.vseparator1.Name = "vseparator1";
			this.hbox1.Add(this.vseparator1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vseparator1]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.radioTabInfo = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Основное"));
			this.radioTabInfo.CanFocus = true;
			this.radioTabInfo.Name = "radioTabInfo";
			this.radioTabInfo.Active = true;
			this.radioTabInfo.DrawIndicator = false;
			this.radioTabInfo.UseUnderline = true;
			this.radioTabInfo.Group = new global::GLib.SList(global::System.IntPtr.Zero);
			this.hbox1.Add(this.radioTabInfo);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.radioTabInfo]));
			w8.Position = 3;
			// Container child hbox1.Gtk.Box+BoxChild
			this.radioTabAccounts = new global::Gtk.RadioButton(global::Mono.Unix.Catalog.GetString("Счета"));
			this.radioTabAccounts.CanFocus = true;
			this.radioTabAccounts.Name = "radioTabAccounts";
			this.radioTabAccounts.DrawIndicator = false;
			this.radioTabAccounts.UseUnderline = true;
			this.radioTabAccounts.Group = this.radioTabInfo.Group;
			this.hbox1.Add(this.radioTabAccounts);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.radioTabAccounts]));
			w9.Position = 4;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.notebookMain = new global::Gtk.Notebook();
			this.notebookMain.CanFocus = true;
			this.notebookMain.Name = "notebookMain";
			this.notebookMain.CurrentPage = 0;
			// Container child notebookMain.Gtk.Notebook+NotebookChild
			this.scrolledwindow1 = new global::Gtk.ScrolledWindow();
			this.scrolledwindow1.CanFocus = true;
			this.scrolledwindow1.Name = "scrolledwindow1";
			this.scrolledwindow1.HscrollbarPolicy = ((global::Gtk.PolicyType)(2));
			this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindow1.Gtk.Container+ContainerChild
			global::Gtk.Viewport w11 = new global::Gtk.Viewport();
			w11.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.datatableMain = new global::Gtk.Table(((uint)(11)), ((uint)(2)), false);
			this.datatableMain.Name = "datatableMain";
			this.datatableMain.RowSpacing = ((uint)(6));
			this.datatableMain.ColumnSpacing = ((uint)(6));
			this.datatableMain.BorderWidth = ((uint)(2));
			// Container child datatableMain.Gtk.Table+TableChild
			this.dataentryEmail = new global::Gamma.Widgets.yValidatedEntry();
			this.dataentryEmail.CanFocus = true;
			this.dataentryEmail.Name = "dataentryEmail";
			this.dataentryEmail.IsEditable = true;
			this.dataentryEmail.MaxLength = 45;
			this.dataentryEmail.InvisibleChar = '●';
			this.datatableMain.Add(this.dataentryEmail);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.dataentryEmail]));
			w12.TopAttach = ((uint)(3));
			w12.BottomAttach = ((uint)(4));
			w12.LeftAttach = ((uint)(1));
			w12.RightAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.dataentryFullName = new global::Gamma.GtkWidgets.yEntry();
			this.dataentryFullName.CanFocus = true;
			this.dataentryFullName.Name = "dataentryFullName";
			this.dataentryFullName.IsEditable = true;
			this.dataentryFullName.MaxLength = 200;
			this.dataentryFullName.InvisibleChar = '●';
			this.datatableMain.Add(this.dataentryFullName);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.dataentryFullName]));
			w13.TopAttach = ((uint)(1));
			w13.BottomAttach = ((uint)(2));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.dataentryINN = new global::Gamma.Widgets.yValidatedEntry();
			this.dataentryINN.CanFocus = true;
			this.dataentryINN.Name = "dataentryINN";
			this.dataentryINN.IsEditable = true;
			this.dataentryINN.MaxLength = 12;
			this.dataentryINN.InvisibleChar = '●';
			this.datatableMain.Add(this.dataentryINN);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.dataentryINN]));
			w14.TopAttach = ((uint)(6));
			w14.BottomAttach = ((uint)(7));
			w14.LeftAttach = ((uint)(1));
			w14.RightAttach = ((uint)(2));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.dataentryKPP = new global::Gamma.Widgets.yValidatedEntry();
			this.dataentryKPP.CanFocus = true;
			this.dataentryKPP.Name = "dataentryKPP";
			this.dataentryKPP.IsEditable = true;
			this.dataentryKPP.MaxLength = 9;
			this.dataentryKPP.InvisibleChar = '●';
			this.datatableMain.Add(this.dataentryKPP);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.dataentryKPP]));
			w15.TopAttach = ((uint)(7));
			w15.BottomAttach = ((uint)(8));
			w15.LeftAttach = ((uint)(1));
			w15.RightAttach = ((uint)(2));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.dataentryName = new global::Gamma.GtkWidgets.yEntry();
			this.dataentryName.CanFocus = true;
			this.dataentryName.Name = "dataentryName";
			this.dataentryName.IsEditable = true;
			this.dataentryName.MaxLength = 100;
			this.dataentryName.InvisibleChar = '●';
			this.datatableMain.Add(this.dataentryName);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.dataentryName]));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.dataentryOGRN = new global::Gamma.Widgets.yValidatedEntry();
			this.dataentryOGRN.CanFocus = true;
			this.dataentryOGRN.Name = "dataentryOGRN";
			this.dataentryOGRN.IsEditable = true;
			this.dataentryOGRN.MaxLength = 13;
			this.dataentryOGRN.InvisibleChar = '●';
			this.datatableMain.Add(this.dataentryOGRN);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.dataentryOGRN]));
			w17.TopAttach = ((uint)(8));
			w17.BottomAttach = ((uint)(9));
			w17.LeftAttach = ((uint)(1));
			w17.RightAttach = ((uint)(2));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.datatextviewJurAddress = new global::Gamma.GtkWidgets.yTextView();
			this.datatextviewJurAddress.CanFocus = true;
			this.datatextviewJurAddress.Name = "datatextviewJurAddress";
			this.datatextviewJurAddress.WrapMode = ((global::Gtk.WrapMode)(2));
			this.GtkScrolledWindow1.Add(this.datatextviewJurAddress);
			this.datatableMain.Add(this.GtkScrolledWindow1);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.GtkScrolledWindow1]));
			w19.TopAttach = ((uint)(10));
			w19.BottomAttach = ((uint)(11));
			w19.LeftAttach = ((uint)(1));
			w19.RightAttach = ((uint)(2));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.GtkScrolledWindow2 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
			this.GtkScrolledWindow2.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
			this.datatextviewAddress = new global::Gamma.GtkWidgets.yTextView();
			this.datatextviewAddress.CanFocus = true;
			this.datatextviewAddress.Name = "datatextviewAddress";
			this.datatextviewAddress.WrapMode = ((global::Gtk.WrapMode)(2));
			this.GtkScrolledWindow2.Add(this.datatextviewAddress);
			this.datatableMain.Add(this.GtkScrolledWindow2);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.GtkScrolledWindow2]));
			w21.TopAttach = ((uint)(9));
			w21.BottomAttach = ((uint)(10));
			w21.LeftAttach = ((uint)(1));
			w21.RightAttach = ((uint)(2));
			w21.XOptions = ((global::Gtk.AttachOptions)(4));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label10 = new global::Gtk.Label();
			this.label10.Name = "label10";
			this.label10.Xalign = 1F;
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString("ОГРН:");
			this.datatableMain.Add(this.label10);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label10]));
			w22.TopAttach = ((uint)(8));
			w22.BottomAttach = ((uint)(9));
			w22.XOptions = ((global::Gtk.AttachOptions)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label11 = new global::Gtk.Label();
			this.label11.Name = "label11";
			this.label11.Xalign = 1F;
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString("E-mail:");
			this.datatableMain.Add(this.label11);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label11]));
			w23.TopAttach = ((uint)(3));
			w23.BottomAttach = ((uint)(4));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label13 = new global::Gtk.Label();
			this.label13.Name = "label13";
			this.label13.Xalign = 1F;
			this.label13.LabelProp = global::Mono.Unix.Catalog.GetString("Руководитель:");
			this.datatableMain.Add(this.label13);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label13]));
			w24.TopAttach = ((uint)(4));
			w24.BottomAttach = ((uint)(5));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label14 = new global::Gtk.Label();
			this.label14.Name = "label14";
			this.label14.Xalign = 1F;
			this.label14.LabelProp = global::Mono.Unix.Catalog.GetString("Главный бухгалтер:");
			this.datatableMain.Add(this.label14);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label14]));
			w25.TopAttach = ((uint)(5));
			w25.BottomAttach = ((uint)(6));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Полное название:");
			this.datatableMain.Add(this.label3);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label3]));
			w26.TopAttach = ((uint)(1));
			w26.BottomAttach = ((uint)(2));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Название<span foreground=\"red\">*</span>:");
			this.label4.UseMarkup = true;
			this.datatableMain.Add(this.label4);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label4]));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.Yalign = 0F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Адрес:");
			this.datatableMain.Add(this.label5);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label5]));
			w28.TopAttach = ((uint)(9));
			w28.BottomAttach = ((uint)(10));
			w28.XOptions = ((global::Gtk.AttachOptions)(4));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.Yalign = 0F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Юр. адрес:");
			this.datatableMain.Add(this.label6);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label6]));
			w29.TopAttach = ((uint)(10));
			w29.BottomAttach = ((uint)(11));
			w29.XOptions = ((global::Gtk.AttachOptions)(4));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("ИНН:");
			this.datatableMain.Add(this.label7);
			global::Gtk.Table.TableChild w30 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label7]));
			w30.TopAttach = ((uint)(6));
			w30.BottomAttach = ((uint)(7));
			w30.XOptions = ((global::Gtk.AttachOptions)(4));
			w30.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label8 = new global::Gtk.Label();
			this.label8.Name = "label8";
			this.label8.Xalign = 1F;
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString("КПП:");
			this.datatableMain.Add(this.label8);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label8]));
			w31.TopAttach = ((uint)(7));
			w31.BottomAttach = ((uint)(8));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label9 = new global::Gtk.Label();
			this.label9.Name = "label9";
			this.label9.Xalign = 1F;
			this.label9.Yalign = 0F;
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString("Телефоны:");
			this.datatableMain.Add(this.label9);
			global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.label9]));
			w32.TopAttach = ((uint)(2));
			w32.BottomAttach = ((uint)(3));
			w32.XOptions = ((global::Gtk.AttachOptions)(4));
			w32.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.phonesview1 = new global::QSContacts.PhonesView();
			this.phonesview1.Events = ((global::Gdk.EventMask)(256));
			this.phonesview1.Name = "phonesview1";
			this.datatableMain.Add(this.phonesview1);
			global::Gtk.Table.TableChild w33 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.phonesview1]));
			w33.TopAttach = ((uint)(2));
			w33.BottomAttach = ((uint)(3));
			w33.LeftAttach = ((uint)(1));
			w33.RightAttach = ((uint)(2));
			w33.XOptions = ((global::Gtk.AttachOptions)(4));
			w33.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.referenceBuhgalter = new global::Gamma.Widgets.yEntryReferenceVM();
			this.referenceBuhgalter.Events = ((global::Gdk.EventMask)(256));
			this.referenceBuhgalter.Name = "referenceBuhgalter";
			this.datatableMain.Add(this.referenceBuhgalter);
			global::Gtk.Table.TableChild w34 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.referenceBuhgalter]));
			w34.TopAttach = ((uint)(5));
			w34.BottomAttach = ((uint)(6));
			w34.LeftAttach = ((uint)(1));
			w34.RightAttach = ((uint)(2));
			w34.XOptions = ((global::Gtk.AttachOptions)(4));
			w34.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.referenceLeader = new global::Gamma.Widgets.yEntryReferenceVM();
			this.referenceLeader.Events = ((global::Gdk.EventMask)(256));
			this.referenceLeader.Name = "referenceLeader";
			this.datatableMain.Add(this.referenceLeader);
			global::Gtk.Table.TableChild w35 = ((global::Gtk.Table.TableChild)(this.datatableMain[this.referenceLeader]));
			w35.TopAttach = ((uint)(4));
			w35.BottomAttach = ((uint)(5));
			w35.LeftAttach = ((uint)(1));
			w35.RightAttach = ((uint)(2));
			w35.XOptions = ((global::Gtk.AttachOptions)(4));
			w35.YOptions = ((global::Gtk.AttachOptions)(4));
			w11.Add(this.datatableMain);
			this.scrolledwindow1.Add(w11);
			this.notebookMain.Add(this.scrolledwindow1);
			// Notebook tab
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Информация");
			this.notebookMain.SetTabLabel(this.scrolledwindow1, this.label1);
			this.label1.ShowAll();
			// Container child notebookMain.Gtk.Notebook+NotebookChild
			this.accountsview1 = new global::QSBanks.AccountsView();
			this.accountsview1.Events = ((global::Gdk.EventMask)(256));
			this.accountsview1.Name = "accountsview1";
			this.notebookMain.Add(this.accountsview1);
			global::Gtk.Notebook.NotebookChild w39 = ((global::Gtk.Notebook.NotebookChild)(this.notebookMain[this.accountsview1]));
			w39.Position = 1;
			// Notebook tab
			this.label12 = new global::Gtk.Label();
			this.label12.Name = "label12";
			this.label12.LabelProp = global::Mono.Unix.Catalog.GetString("Счет");
			this.notebookMain.SetTabLabel(this.accountsview1, this.label12);
			this.label12.ShowAll();
			this.vbox1.Add(this.notebookMain);
			global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.notebookMain]));
			w40.Position = 1;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			w1.SetUiManager(UIManager);
			this.Hide();
			this.buttonSave.Clicked += new global::System.EventHandler(this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler(this.OnButtonCancelClicked);
			this.radioTabInfo.Toggled += new global::System.EventHandler(this.OnRadioTabInfoToggled);
			this.radioTabAccounts.Toggled += new global::System.EventHandler(this.OnRadioTabAccountsToggled);
		}
	}
}
