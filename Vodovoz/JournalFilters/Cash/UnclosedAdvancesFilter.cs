﻿using System;
using QS.DomainModel.UoW;
using QSOrmProject.RepresentationModel;
using Vodovoz.Domain.Cash;
using Vodovoz.Domain.Employees;

namespace Vodovoz
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class UnclosedAdvancesFilter : RepresentationFilterBase<UnclosedAdvancesFilter>
	{
		protected override void ConfigureWithUow()
		{
			repEntryAccountable.RepresentationModel = new ViewModel.EmployeesVM();
			yentryExpense.ItemsQuery = Repository.Cash.CategoryRepository.ExpenseCategoriesQuery();
			yAdvancePeriod.StartDateOrNull = new DateTime(DateTime.Today.Year-1, 1, 1);
			yAdvancePeriod.EndDateOrNull = DateTime.Today;
		}

		public UnclosedAdvancesFilter(IUnitOfWork uow) : this()
		{
			UoW = uow;
		}

		public UnclosedAdvancesFilter()
		{
			this.Build();
		}

		public ExpenseCategory RestrictExpenseCategory {
			get { return yentryExpense.Subject as ExpenseCategory; }
			set {
				yentryExpense.Subject = value;
				yentryExpense.Sensitive = false;
			}
		}

		public Employee RestrictAccountable {
			get { return repEntryAccountable.Subject as Employee; }
			set {
				repEntryAccountable.Subject = value;
				repEntryAccountable.Sensitive = false;
			}
		}

		public DateTime? RestrictStartDate {
			get { return yAdvancePeriod.StartDateOrNull; }
			set {
				yAdvancePeriod.StartDateOrNull = value;
				yAdvancePeriod.Sensitive = false;
			}
		}

		public DateTime? RestrictEndDate {
			get { return yAdvancePeriod.EndDateOrNull; }
			set {
				yAdvancePeriod.EndDateOrNull = value;
				yAdvancePeriod.Sensitive = false;
			}
		}

		protected void OnYentryAccountableChanged(object sender, EventArgs e)
		{
			OnRefiltered();
		}

		protected void OnYentryExpenseChanged(object sender, EventArgs e)
		{
			OnRefiltered();
		}

		protected void OnYAdvancePeriodPeriodChanged(object sender, EventArgs e)
		{
			OnRefiltered();
		}
	}
}

