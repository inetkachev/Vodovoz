
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Filters.GtkViews
{
	public partial class OrderForMovDocFilterView
	{
		private global::Gtk.HBox hbox1;

		private global::Gtk.Table table1;

		private global::QS.Widgets.GtkUI.DateRangePicker daterangepickerOrderCreateDate;

		private global::Gtk.Label labelStatus;

		private global::Gtk.VSeparator vseparator2;

		private global::Gamma.GtkWidgets.yCheckButton ycheckIsOnlineStore;

		private global::Gamma.GtkWidgets.yLabel ylabel1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.Widgets.EnumCheckList enumchecklistStatuses;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Filters.GtkViews.OrderForMovDocFilterView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Filters.GtkViews.OrderForMovDocFilterView";
			// Container child Vodovoz.Filters.GtkViews.OrderForMovDocFilterView.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(3)), ((uint)(3)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.daterangepickerOrderCreateDate = new global::QS.Widgets.GtkUI.DateRangePicker();
			this.daterangepickerOrderCreateDate.Events = ((global::Gdk.EventMask)(256));
			this.daterangepickerOrderCreateDate.Name = "daterangepickerOrderCreateDate";
			this.daterangepickerOrderCreateDate.StartDate = new global::System.DateTime(0);
			this.daterangepickerOrderCreateDate.EndDate = new global::System.DateTime(0);
			this.table1.Add(this.daterangepickerOrderCreateDate);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.daterangepickerOrderCreateDate]));
			w1.TopAttach = ((uint)(2));
			w1.BottomAttach = ((uint)(3));
			w1.RightAttach = ((uint)(3));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelStatus = new global::Gtk.Label();
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.LabelProp = global::Mono.Unix.Catalog.GetString("Статусы заказа:");
			this.table1.Add(this.labelStatus);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.labelStatus]));
			w2.LeftAttach = ((uint)(2));
			w2.RightAttach = ((uint)(3));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.vseparator2 = new global::Gtk.VSeparator();
			this.vseparator2.Name = "vseparator2";
			this.table1.Add(this.vseparator2);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.vseparator2]));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ycheckIsOnlineStore = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckIsOnlineStore.CanFocus = true;
			this.ycheckIsOnlineStore.Name = "ycheckIsOnlineStore";
			this.ycheckIsOnlineStore.Label = global::Mono.Unix.Catalog.GetString("Заказ ИМ");
			this.ycheckIsOnlineStore.DrawIndicator = true;
			this.ycheckIsOnlineStore.UseUnderline = true;
			this.table1.Add(this.ycheckIsOnlineStore);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.ycheckIsOnlineStore]));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabel1 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel1.Name = "ylabel1";
			this.ylabel1.Xalign = 0F;
			this.ylabel1.LabelProp = global::Mono.Unix.Catalog.GetString("Дата создания заказа:");
			this.table1.Add(this.ylabel1);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabel1]));
			w5.TopAttach = ((uint)(1));
			w5.BottomAttach = ((uint)(2));
			w5.RightAttach = ((uint)(3));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			this.hbox1.Add(this.table1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.table1]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.WidthRequest = 200;
			this.GtkScrolledWindow.HeightRequest = 80;
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			global::Gtk.Viewport w7 = new global::Gtk.Viewport();
			w7.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.enumchecklistStatuses = new global::Gamma.Widgets.EnumCheckList();
			this.enumchecklistStatuses.Sensitive = false;
			this.enumchecklistStatuses.Name = "enumchecklistStatuses";
			w7.Add(this.enumchecklistStatuses);
			this.GtkScrolledWindow.Add(w7);
			this.hbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.GtkScrolledWindow]));
			w10.Position = 1;
			w10.Expand = false;
			this.Add(this.hbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}