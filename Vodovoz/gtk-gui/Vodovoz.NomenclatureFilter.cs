
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class NomenclatureFilter
	{
		private global::Gtk.Table table1;

		private global::Gamma.GtkWidgets.yCheckButton checkShowArchive;

		private global::Gamma.Widgets.yEnumComboBox enumcomboType;

		private global::Gtk.Label label1;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.NomenclatureFilter
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.NomenclatureFilter";
			// Container child Vodovoz.NomenclatureFilter.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(1)), ((uint)(3)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.checkShowArchive = new global::Gamma.GtkWidgets.yCheckButton();
			this.checkShowArchive.CanFocus = true;
			this.checkShowArchive.Name = "checkShowArchive";
			this.checkShowArchive.Label = global::Mono.Unix.Catalog.GetString("Показывать архивные");
			this.checkShowArchive.DrawIndicator = true;
			this.checkShowArchive.UseUnderline = true;
			this.table1.Add(this.checkShowArchive);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.checkShowArchive]));
			w1.LeftAttach = ((uint)(2));
			w1.RightAttach = ((uint)(3));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.enumcomboType = new global::Gamma.Widgets.yEnumComboBox();
			this.enumcomboType.Name = "enumcomboType";
			this.enumcomboType.ShowSpecialStateAll = true;
			this.enumcomboType.ShowSpecialStateNot = false;
			this.enumcomboType.UseShortTitle = false;
			this.enumcomboType.DefaultFirst = false;
			this.table1.Add(this.enumcomboType);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.enumcomboType]));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Тип:");
			this.table1.Add(this.label1);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.label1]));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.enumcomboType.Changed += new global::System.EventHandler(this.OnEnumcomboTypeChanged);
			this.checkShowArchive.Toggled += new global::System.EventHandler(this.OnCheckShowArchiveToggled);
		}
	}
}
