
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class CounterpartyContractDlg
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Table datatable5;

		private global::Vodovoz.AdditionalAgreementsView additionalagreementsview1;

		private global::Gamma.GtkWidgets.yCheckButton checkOnCancellation;

		private global::Gamma.Widgets.yDatePicker dateIssue;

		private global::Gamma.GtkWidgets.yEntry entryNumber;

		private global::Gtk.HBox hbox17;

		private global::Gtk.VSeparator vseparator2;

		private global::Gamma.GtkWidgets.yCheckButton checkArchive;

		private global::Gtk.VSeparator vseparator3;

		private global::Gtk.Label label32;

		private global::Gtk.Label label33;

		private global::Gtk.Label label35;

		private global::Gtk.Label label38;

		private global::Gamma.Widgets.yEntryReference referenceOrganization;

		private global::Gamma.GtkWidgets.ySpinButton spinDelay;

		private global::QSDocTemplates.TemplateWidget templatewidget1;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.CounterpartyContractDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.CounterpartyContractDlg";
			// Container child Vodovoz.CounterpartyContractDlg.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox4.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox4.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox1.Add(this.hbox4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox4]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.datatable5 = new global::Gtk.Table(((uint)(6)), ((uint)(3)), false);
			this.datatable5.Name = "datatable5";
			this.datatable5.RowSpacing = ((uint)(6));
			this.datatable5.ColumnSpacing = ((uint)(6));
			this.datatable5.BorderWidth = ((uint)(6));
			// Container child datatable5.Gtk.Table+TableChild
			this.additionalagreementsview1 = new global::Vodovoz.AdditionalAgreementsView();
			this.additionalagreementsview1.HeightRequest = 150;
			this.additionalagreementsview1.Events = ((global::Gdk.EventMask)(256));
			this.additionalagreementsview1.Name = "additionalagreementsview1";
			this.additionalagreementsview1.IsEditable = true;
			this.datatable5.Add(this.additionalagreementsview1);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.datatable5[this.additionalagreementsview1]));
			w6.TopAttach = ((uint)(5));
			w6.BottomAttach = ((uint)(6));
			w6.RightAttach = ((uint)(3));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable5.Gtk.Table+TableChild
			this.checkOnCancellation = new global::Gamma.GtkWidgets.yCheckButton();
			this.checkOnCancellation.CanFocus = true;
			this.checkOnCancellation.Name = "checkOnCancellation";
			this.checkOnCancellation.Label = global::Mono.Unix.Catalog.GetString("На расторжении");
			this.checkOnCancellation.DrawIndicator = true;
			this.checkOnCancellation.UseUnderline = true;
			this.datatable5.Add(this.checkOnCancellation);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.datatable5[this.checkOnCancellation]));
			w7.TopAttach = ((uint)(4));
			w7.BottomAttach = ((uint)(5));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable5.Gtk.Table+TableChild
			this.dateIssue = new global::Gamma.Widgets.yDatePicker();
			this.dateIssue.Events = ((global::Gdk.EventMask)(256));
			this.dateIssue.Name = "dateIssue";
			this.dateIssue.WithTime = false;
			this.dateIssue.Date = new global::System.DateTime(0);
			this.dateIssue.IsEditable = true;
			this.dateIssue.AutoSeparation = false;
			this.datatable5.Add(this.dateIssue);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.datatable5[this.dateIssue]));
			w8.TopAttach = ((uint)(1));
			w8.BottomAttach = ((uint)(2));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable5.Gtk.Table+TableChild
			this.entryNumber = new global::Gamma.GtkWidgets.yEntry();
			this.entryNumber.CanFocus = true;
			this.entryNumber.Name = "entryNumber";
			this.entryNumber.IsEditable = false;
			this.entryNumber.InvisibleChar = '●';
			this.datatable5.Add(this.entryNumber);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.datatable5[this.entryNumber]));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable5.Gtk.Table+TableChild
			this.hbox17 = new global::Gtk.HBox();
			this.hbox17.Name = "hbox17";
			this.hbox17.Spacing = 6;
			// Container child hbox17.Gtk.Box+BoxChild
			this.vseparator2 = new global::Gtk.VSeparator();
			this.vseparator2.Name = "vseparator2";
			this.hbox17.Add(this.vseparator2);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox17[this.vseparator2]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox17.Gtk.Box+BoxChild
			this.checkArchive = new global::Gamma.GtkWidgets.yCheckButton();
			this.checkArchive.CanFocus = true;
			this.checkArchive.Name = "checkArchive";
			this.checkArchive.Label = global::Mono.Unix.Catalog.GetString("Архивный");
			this.checkArchive.DrawIndicator = true;
			this.checkArchive.UseUnderline = true;
			this.hbox17.Add(this.checkArchive);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox17[this.checkArchive]));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			// Container child hbox17.Gtk.Box+BoxChild
			this.vseparator3 = new global::Gtk.VSeparator();
			this.vseparator3.Name = "vseparator3";
			this.hbox17.Add(this.vseparator3);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox17[this.vseparator3]));
			w12.Position = 2;
			w12.Expand = false;
			w12.Fill = false;
			this.datatable5.Add(this.hbox17);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.datatable5[this.hbox17]));
			w13.TopAttach = ((uint)(4));
			w13.BottomAttach = ((uint)(5));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable5.Gtk.Table+TableChild
			this.label32 = new global::Gtk.Label();
			this.label32.Name = "label32";
			this.label32.Xalign = 1F;
			this.label32.LabelProp = global::Mono.Unix.Catalog.GetString("Номер:");
			this.datatable5.Add(this.label32);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.datatable5[this.label32]));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable5.Gtk.Table+TableChild
			this.label33 = new global::Gtk.Label();
			this.label33.Name = "label33";
			this.label33.Xalign = 1F;
			this.label33.LabelProp = global::Mono.Unix.Catalog.GetString("Дата заключения:");
			this.datatable5.Add(this.label33);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.datatable5[this.label33]));
			w15.TopAttach = ((uint)(1));
			w15.BottomAttach = ((uint)(2));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable5.Gtk.Table+TableChild
			this.label35 = new global::Gtk.Label();
			this.label35.Name = "label35";
			this.label35.Xalign = 1F;
			this.label35.LabelProp = global::Mono.Unix.Catalog.GetString("Организация:");
			this.datatable5.Add(this.label35);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.datatable5[this.label35]));
			w16.TopAttach = ((uint)(2));
			w16.BottomAttach = ((uint)(3));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable5.Gtk.Table+TableChild
			this.label38 = new global::Gtk.Label();
			this.label38.Name = "label38";
			this.label38.Xalign = 1F;
			this.label38.LabelProp = global::Mono.Unix.Catalog.GetString("Максимальный срок отсрочки:");
			this.datatable5.Add(this.label38);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.datatable5[this.label38]));
			w17.TopAttach = ((uint)(3));
			w17.BottomAttach = ((uint)(4));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable5.Gtk.Table+TableChild
			this.referenceOrganization = new global::Gamma.Widgets.yEntryReference();
			this.referenceOrganization.Events = ((global::Gdk.EventMask)(256));
			this.referenceOrganization.Name = "referenceOrganization";
			this.referenceOrganization.DisplayFields = new string[] {
					"Name"};
			this.datatable5.Add(this.referenceOrganization);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.datatable5[this.referenceOrganization]));
			w18.TopAttach = ((uint)(2));
			w18.BottomAttach = ((uint)(3));
			w18.LeftAttach = ((uint)(1));
			w18.RightAttach = ((uint)(2));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable5.Gtk.Table+TableChild
			this.spinDelay = new global::Gamma.GtkWidgets.ySpinButton(0, 100, 1);
			this.spinDelay.CanFocus = true;
			this.spinDelay.Name = "spinDelay";
			this.spinDelay.Adjustment.PageIncrement = 10;
			this.spinDelay.ClimbRate = 1;
			this.spinDelay.Numeric = true;
			this.spinDelay.Value = 3;
			this.spinDelay.ValueAsDecimal = 0m;
			this.spinDelay.ValueAsInt = 0;
			this.datatable5.Add(this.spinDelay);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.datatable5[this.spinDelay]));
			w19.TopAttach = ((uint)(3));
			w19.BottomAttach = ((uint)(4));
			w19.LeftAttach = ((uint)(1));
			w19.RightAttach = ((uint)(2));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable5.Gtk.Table+TableChild
			this.templatewidget1 = new global::QSDocTemplates.TemplateWidget();
			this.templatewidget1.Events = ((global::Gdk.EventMask)(256));
			this.templatewidget1.Name = "templatewidget1";
			this.datatable5.Add(this.templatewidget1);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.datatable5[this.templatewidget1]));
			w20.BottomAttach = ((uint)(5));
			w20.LeftAttach = ((uint)(2));
			w20.RightAttach = ((uint)(3));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add(this.datatable5);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.datatable5]));
			w21.Position = 1;
			this.Add(this.vbox1);
			if((this.Child != null)) {
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonSave.Clicked += new global::System.EventHandler(this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler(this.OnButtonCancelClicked);
		}
	}
}
