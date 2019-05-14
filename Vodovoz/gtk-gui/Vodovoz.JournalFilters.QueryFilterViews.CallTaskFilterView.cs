
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.JournalFilters.QueryFilterViews
{
	public partial class CallTaskFilterView
	{
		private global::Gtk.VBox vboxFilter;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Label label3;

		private global::Gamma.Widgets.yEntryReferenceVM entryreferencevmEmployee;

		private global::Gamma.GtkWidgets.yCheckButton checkbuttonHideCompleted;

		private global::Gtk.HBox hbox3;

		private global::Gamma.Widgets.yEnumComboBox comboboxDateType;

		private global::Gamma.Widgets.yDatePeriodPicker dateperiodpickerDateFilter;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button buttonExpired;

		private global::Gtk.Button buttonToday;

		private global::Gtk.Button buttonTomorrow;

		private global::Gtk.Button buttonThisWeek;

		private global::Gtk.Button buttonNextWeek;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.JournalFilters.QueryFilterViews.CallTaskFilterView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.JournalFilters.QueryFilterViews.CallTaskFilterView";
			// Container child Vodovoz.JournalFilters.QueryFilterViews.CallTaskFilterView.Gtk.Container+ContainerChild
			this.vboxFilter = new global::Gtk.VBox();
			this.vboxFilter.Name = "vboxFilter";
			this.vboxFilter.Spacing = 6;
			// Container child vboxFilter.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("ФИ оператора :");
			this.hbox4.Add(this.label3);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.label3]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.entryreferencevmEmployee = new global::Gamma.Widgets.yEntryReferenceVM();
			this.entryreferencevmEmployee.Events = ((global::Gdk.EventMask)(256));
			this.entryreferencevmEmployee.Name = "entryreferencevmEmployee";
			this.hbox4.Add(this.entryreferencevmEmployee);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.entryreferencevmEmployee]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.checkbuttonHideCompleted = new global::Gamma.GtkWidgets.yCheckButton();
			this.checkbuttonHideCompleted.CanFocus = true;
			this.checkbuttonHideCompleted.Name = "checkbuttonHideCompleted";
			this.checkbuttonHideCompleted.Label = global::Mono.Unix.Catalog.GetString("Скрыть выполненые");
			this.checkbuttonHideCompleted.Active = true;
			this.checkbuttonHideCompleted.DrawIndicator = true;
			this.checkbuttonHideCompleted.UseUnderline = true;
			this.hbox4.Add(this.checkbuttonHideCompleted);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.checkbuttonHideCompleted]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			this.vboxFilter.Add(this.hbox4);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vboxFilter[this.hbox4]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vboxFilter.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.comboboxDateType = new global::Gamma.Widgets.yEnumComboBox();
			this.comboboxDateType.Name = "comboboxDateType";
			this.comboboxDateType.ShowSpecialStateAll = false;
			this.comboboxDateType.ShowSpecialStateNot = false;
			this.comboboxDateType.UseShortTitle = false;
			this.comboboxDateType.DefaultFirst = false;
			this.hbox3.Add(this.comboboxDateType);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.comboboxDateType]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.dateperiodpickerDateFilter = new global::Gamma.Widgets.yDatePeriodPicker();
			this.dateperiodpickerDateFilter.Events = ((global::Gdk.EventMask)(256));
			this.dateperiodpickerDateFilter.Name = "dateperiodpickerDateFilter";
			this.dateperiodpickerDateFilter.StartDate = new global::System.DateTime(0);
			this.dateperiodpickerDateFilter.EndDate = new global::System.DateTime(0);
			this.hbox3.Add(this.dateperiodpickerDateFilter);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.dateperiodpickerDateFilter]));
			w6.Position = 1;
			this.vboxFilter.Add(this.hbox3);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vboxFilter[this.hbox3]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vboxFilter.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonExpired = new global::Gtk.Button();
			this.buttonExpired.CanFocus = true;
			this.buttonExpired.Name = "buttonExpired";
			this.buttonExpired.UseUnderline = true;
			this.buttonExpired.Label = global::Mono.Unix.Catalog.GetString("Просрочено");
			this.hbox2.Add(this.buttonExpired);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonExpired]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonToday = new global::Gtk.Button();
			this.buttonToday.CanFocus = true;
			this.buttonToday.Name = "buttonToday";
			this.buttonToday.UseUnderline = true;
			this.buttonToday.Label = global::Mono.Unix.Catalog.GetString("Сегодня");
			this.hbox2.Add(this.buttonToday);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonToday]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonTomorrow = new global::Gtk.Button();
			this.buttonTomorrow.CanFocus = true;
			this.buttonTomorrow.Name = "buttonTomorrow";
			this.buttonTomorrow.UseUnderline = true;
			this.buttonTomorrow.Label = global::Mono.Unix.Catalog.GetString("Завтра");
			this.hbox2.Add(this.buttonTomorrow);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonTomorrow]));
			w10.Position = 2;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonThisWeek = new global::Gtk.Button();
			this.buttonThisWeek.CanFocus = true;
			this.buttonThisWeek.Name = "buttonThisWeek";
			this.buttonThisWeek.UseUnderline = true;
			this.buttonThisWeek.Label = global::Mono.Unix.Catalog.GetString("На этой неделе");
			this.hbox2.Add(this.buttonThisWeek);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonThisWeek]));
			w11.Position = 3;
			w11.Expand = false;
			w11.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonNextWeek = new global::Gtk.Button();
			this.buttonNextWeek.CanFocus = true;
			this.buttonNextWeek.Name = "buttonNextWeek";
			this.buttonNextWeek.UseUnderline = true;
			this.buttonNextWeek.Label = global::Mono.Unix.Catalog.GetString("На следующей неделе");
			this.hbox2.Add(this.buttonNextWeek);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonNextWeek]));
			w12.Position = 4;
			w12.Expand = false;
			w12.Fill = false;
			this.vboxFilter.Add(this.hbox2);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vboxFilter[this.hbox2]));
			w13.Position = 2;
			w13.Expand = false;
			w13.Fill = false;
			this.Add(this.vboxFilter);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.vboxFilter.Hide();
			this.Hide();
			this.entryreferencevmEmployee.ChangedByUser += new global::System.EventHandler(this.OnEntryreferencevmEmployeeChangedByUser);
			this.checkbuttonHideCompleted.Toggled += new global::System.EventHandler(this.OnCheckbuttonHideCompletedToggled);
			this.comboboxDateType.ChangedByUser += new global::System.EventHandler(this.OnComboboxDateTypeChangedByUser);
			this.dateperiodpickerDateFilter.PeriodChangedByUser += new global::System.EventHandler(this.OnDateperiodpickerDateFilterPeriodChangedByUser);
			this.buttonExpired.Clicked += new global::System.EventHandler(this.OnButtonExpiredClicked);
			this.buttonToday.Clicked += new global::System.EventHandler(this.OnButtonTodayClicked);
			this.buttonTomorrow.Clicked += new global::System.EventHandler(this.OnButtonTomorrowClicked);
			this.buttonThisWeek.Clicked += new global::System.EventHandler(this.OnButtonThisWeekClicked);
			this.buttonNextWeek.Clicked += new global::System.EventHandler(this.OnButtonNextWeekClicked);
		}
	}
}