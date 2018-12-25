
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Dialogs.Employees
{
	public partial class EmployeeDocDlg
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Button buttonSave;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Label label5;

		private global::Gamma.Widgets.yEnumComboBox comboCategory;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Label label1;

		private global::Gamma.GtkWidgets.yEntry yentry3;

		private global::Gtk.Label label2;

		private global::Gamma.GtkWidgets.yEntry yentry4;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Label label3;

		private global::Gamma.Widgets.yDatePicker ydatepicker2;

		private global::Gtk.HBox hbox6;

		private global::Gtk.Label label4;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTextView ytextview2;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Dialogs.Employees.EmployeeDocDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Dialogs.Employees.EmployeeDocDlg";
			// Container child Vodovoz.Dialogs.Employees.EmployeeDocDlg.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-cancel", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w1;
			this.hbox1.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonCancel]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
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
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox2.Add(this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label();
			this.label5.WidthRequest = 83;
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Вид документа:");
			this.hbox2.Add(this.label5);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.label5]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.comboCategory = new global::Gamma.Widgets.yEnumComboBox();
			this.comboCategory.WidthRequest = 300;
			this.comboCategory.Name = "comboCategory";
			this.comboCategory.ShowSpecialStateAll = false;
			this.comboCategory.ShowSpecialStateNot = false;
			this.comboCategory.UseShortTitle = false;
			this.comboCategory.DefaultFirst = true;
			this.hbox2.Add(this.comboCategory);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.comboCategory]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			this.vbox2.Add(this.hbox2);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox2]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.WidthRequest = 83;
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("серия:");
			this.hbox3.Add(this.label1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label1]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.yentry3 = new global::Gamma.GtkWidgets.yEntry();
			this.yentry3.CanFocus = true;
			this.yentry3.Name = "yentry3";
			this.yentry3.IsEditable = true;
			this.yentry3.InvisibleChar = '•';
			this.hbox3.Add(this.yentry3);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.yentry3]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("номер:");
			this.hbox3.Add(this.label2);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label2]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.yentry4 = new global::Gamma.GtkWidgets.yEntry();
			this.yentry4.CanFocus = true;
			this.yentry4.Name = "yentry4";
			this.yentry4.IsEditable = true;
			this.yentry4.InvisibleChar = '•';
			this.hbox3.Add(this.yentry4);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.yentry4]));
			w12.Position = 3;
			w12.Expand = false;
			w12.Fill = false;
			this.vbox2.Add(this.hbox3);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox3]));
			w13.Position = 2;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label();
			this.label3.WidthRequest = 83;
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Дата выдачи:");
			this.hbox4.Add(this.label3);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.label3]));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.ydatepicker2 = new global::Gamma.Widgets.yDatePicker();
			this.ydatepicker2.Events = ((global::Gdk.EventMask)(256));
			this.ydatepicker2.Name = "ydatepicker2";
			this.ydatepicker2.WithTime = false;
			this.ydatepicker2.Date = new global::System.DateTime(0);
			this.ydatepicker2.IsEditable = false;
			this.ydatepicker2.AutoSeparation = false;
			this.hbox4.Add(this.ydatepicker2);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.ydatepicker2]));
			w15.Position = 1;
			this.vbox2.Add(this.hbox4);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox4]));
			w16.Position = 3;
			w16.Expand = false;
			w16.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label();
			this.label4.WidthRequest = 83;
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Кем выдан:");
			this.hbox6.Add(this.label4);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.label4]));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytextview2 = new global::Gamma.GtkWidgets.yTextView();
			this.ytextview2.HeightRequest = 80;
			this.ytextview2.CanFocus = true;
			this.ytextview2.Name = "ytextview2";
			this.GtkScrolledWindow.Add(this.ytextview2);
			this.hbox6.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.GtkScrolledWindow]));
			w19.Position = 1;
			this.vbox2.Add(this.hbox6);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox6]));
			w20.Position = 4;
			w20.Expand = false;
			w20.Fill = false;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
