
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.WageCalculation
{
	public partial class PercentWageParameterView
	{
		private global::Gtk.VBox vboxWidget;

		private global::Gtk.HBox hboxFixedType;

		private global::Gamma.GtkWidgets.yLabel ylabelPercentType;

		private global::Gamma.Widgets.yEnumComboBox comboPercentType;

		private global::Gtk.Table tableContent;

		private global::Gamma.GtkWidgets.ySpinButton entryRouteListPercentWage;

		private global::Gamma.GtkWidgets.yLabel ylabelWageForRouteList;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.WageCalculation.PercentWageParameterView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.WageCalculation.PercentWageParameterView";
			// Container child Vodovoz.Views.WageCalculation.PercentWageParameterView.Gtk.Container+ContainerChild
			this.vboxWidget = new global::Gtk.VBox();
			this.vboxWidget.Name = "vboxWidget";
			this.vboxWidget.Spacing = 6;
			// Container child vboxWidget.Gtk.Box+BoxChild
			this.hboxFixedType = new global::Gtk.HBox();
			this.hboxFixedType.Name = "hboxFixedType";
			this.hboxFixedType.Spacing = 6;
			// Container child hboxFixedType.Gtk.Box+BoxChild
			this.ylabelPercentType = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelPercentType.Name = "ylabelPercentType";
			this.ylabelPercentType.LabelProp = global::Mono.Unix.Catalog.GetString("Тип фиксы:");
			this.hboxFixedType.Add(this.ylabelPercentType);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hboxFixedType[this.ylabelPercentType]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hboxFixedType.Gtk.Box+BoxChild
			this.comboPercentType = new global::Gamma.Widgets.yEnumComboBox();
			this.comboPercentType.Name = "comboPercentType";
			this.comboPercentType.ShowSpecialStateAll = false;
			this.comboPercentType.ShowSpecialStateNot = false;
			this.comboPercentType.UseShortTitle = false;
			this.comboPercentType.DefaultFirst = false;
			this.hboxFixedType.Add(this.comboPercentType);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hboxFixedType[this.comboPercentType]));
			w2.Position = 1;
			w2.Expand = false;
			this.vboxWidget.Add(this.hboxFixedType);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vboxWidget[this.hboxFixedType]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vboxWidget.Gtk.Box+BoxChild
			this.tableContent = new global::Gtk.Table(((uint)(3)), ((uint)(2)), false);
			this.tableContent.Name = "tableContent";
			this.tableContent.RowSpacing = ((uint)(6));
			this.tableContent.ColumnSpacing = ((uint)(6));
			// Container child tableContent.Gtk.Table+TableChild
			this.entryRouteListPercentWage = new global::Gamma.GtkWidgets.ySpinButton(0D, 100D, 1D);
			this.entryRouteListPercentWage.CanFocus = true;
			this.entryRouteListPercentWage.Name = "entryRouteListPercentWage";
			this.entryRouteListPercentWage.Adjustment.PageIncrement = 10D;
			this.entryRouteListPercentWage.ClimbRate = 1D;
			this.entryRouteListPercentWage.Numeric = true;
			this.entryRouteListPercentWage.ValueAsDecimal = 0m;
			this.entryRouteListPercentWage.ValueAsInt = 0;
			this.tableContent.Add(this.entryRouteListPercentWage);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.tableContent[this.entryRouteListPercentWage]));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableContent.Gtk.Table+TableChild
			this.ylabelWageForRouteList = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelWageForRouteList.Name = "ylabelWageForRouteList";
			this.ylabelWageForRouteList.LabelProp = global::Mono.Unix.Catalog.GetString("За МЛ:");
			this.tableContent.Add(this.ylabelWageForRouteList);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.tableContent[this.ylabelWageForRouteList]));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vboxWidget.Add(this.tableContent);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vboxWidget[this.tableContent]));
			w6.Position = 1;
			this.Add(this.vboxWidget);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
