﻿using QS.Dialog.Gtk;
using QS.DomainModel.UoW;
using Vodovoz.Domain;

namespace Vodovoz
{
	public partial class EquipmentTypeDlg : QS.Dialog.Gtk.EntityDialogBase<EquipmentType>{
		protected static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();

		public EquipmentTypeDlg ()
		{			
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<EquipmentType> ();
			ConfigureDialog ();
		}

		public EquipmentTypeDlg (int id)
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<EquipmentType> (id);
			ConfigureDialog ();
		}

		public EquipmentTypeDlg (EquipmentType sub): this(sub.Id) {}


		protected void ConfigureDialog(){
			yentryName.Binding
				.AddBinding (UoWGeneric.Root, equipmentType => equipmentType.Name, widget => widget.Text)
				.InitializeFromSource ();
			
			enumWarrantyType.ItemsEnum = typeof(WarrantyCardType);					
				
			enumWarrantyType.Binding
				.AddBinding (UoWGeneric.Root, equipmentType => equipmentType.WarrantyCardType, widget => widget.SelectedItem)
				.InitializeFromSource ();
		}

		#region implemented abstract members of OrmGtkDialogBase

		public override bool Save ()
		{
			var valid = new QS.Validation.GtkUI.QSValidator<EquipmentType> (UoWGeneric.Root);
			if (valid.RunDlgIfNotValid ((Gtk.Window)this.Toplevel))
				return false;

			logger.Info ("Сохраняем тип оборудования...");
			UoWGeneric.Save ();
			return true;
		}

		#endregion
	}
}


