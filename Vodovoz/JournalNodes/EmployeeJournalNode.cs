﻿using QS.Project.Journal;
using Vodovoz.Domain.Employees;
using QS.Utilities.Text;

namespace Vodovoz.JournalNodes
{
	public class EmployeeJournalNode : JournalEntityNodeBase<Employee>
	{
		public override string Title => $"{EmpLastName} {EmpFirstName} {EmpMiddleName}";
		public string EmpLastName { get; set; }
		public string EmpFirstName { get; set; }
		public string EmpMiddleName { get; set; }
		public EmployeeCategory EmpCatEnum { get; set; }
		public bool IsFired { get; set; }
		public string FullName => string.Format("{0} {1} {2}", EmpLastName, EmpFirstName, EmpMiddleName);
		public string RowColor => IsFired ? "grey" : "black";
	}
}