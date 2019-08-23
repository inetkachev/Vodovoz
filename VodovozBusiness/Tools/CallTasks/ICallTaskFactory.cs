﻿using QS.DomainModel.UoW;
using Vodovoz.Domain.Client;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.Services;

namespace Vodovoz.Tools.CallTasks
{
	public interface ICallTaskFactory
	{
		void CopyTask(IUnitOfWork uow, IEmployeeRepository employeeRepository, CallTask copyFrom, CallTask copyTo);
		CallTask CreateCopyTask(IUnitOfWork uow, IEmployeeRepository employeeRepository, CallTask originTask);
		CallTask CreateTask(IUnitOfWork uow, IEmployeeRepository employeeRepository, IPersonProvider personProvider, CallTask newTask = null, object source = null, string creationComment = null);
	}
}