﻿using System;
using QSOrmProject;
using QSReport;

namespace Vodovoz.Reports
{
	public partial class SalesReport : Gtk.Bin, IOrmDialog, IParametersWidget
	{
		public SalesReport()
		{
			this.Build();
			UoW = UnitOfWorkFactory.CreateWithoutRoot ();
			yentryNomenclature.ItemsQuery = Repository.NomenclatureRepository.NomenclatureForSaleQuery();
		}

		#region IOrmDialog implementation

		public IUnitOfWork UoW { get; private set; }

		public object EntityObject {
			get {
				return null;
			}
		}

		#endregion

		#region IParametersWidget implementation

		public event EventHandler<LoadReportEventArgs> LoadReport;

		public string Title	{ 
			get {
				return "Отчет по продажам";
			}
		}

		#endregion
	}
}

