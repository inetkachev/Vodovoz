﻿using System;
using QS.DomainModel.UoW;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Orders;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.Services;

namespace Vodovoz.Tools.CallTasks
{
	public class CallTaskFactory : ICallTaskFactory
	{
		private static CallTaskFactory instance;

		public static CallTaskFactory GetInstance()
		{
			if(instance == null)
				instance = new CallTaskFactory();
			return instance;
		}

		protected CallTaskFactory() { }

		public CallTask CreateCopyTask(IUnitOfWork uow, IEmployeeRepository employeeRepository , CallTask originTask)
		{
			var task = new CallTask {
				DeliveryPoint = originTask.DeliveryPoint,
				Counterparty = originTask.Counterparty,
				AssignedEmployee = originTask.AssignedEmployee
			};
			FillNewTask(uow, task, employeeRepository);
			return task;
		}

		public void CopyTask(IUnitOfWork uow, IEmployeeRepository employeeRepository, CallTask copyFrom, CallTask copyTo)
		{
			copyTo.DeliveryPoint = copyFrom.DeliveryPoint;
			copyTo.Counterparty = copyFrom.Counterparty;
			copyTo.AssignedEmployee = copyFrom.AssignedEmployee;
			copyTo.TaskCreator = employeeRepository.GetEmployeeForCurrentUser(uow);
			copyTo.CreationDate = DateTime.Now;
			copyTo.EndActivePeriod = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
		}

		public CallTask CreateTask(IUnitOfWork uow, IEmployeeRepository employeeRepository, IPersonProvider personProvider, CallTask newTask = null, object source = null, string creationComment = null)
		{
			CallTask callTask = newTask ?? new CallTask();
			FillNewTask(uow, callTask, employeeRepository);

			switch(source) {
				case Order order:
					callTask.DeliveryPoint = uow.GetById<DeliveryPoint>(order.DeliveryPoint.Id);
					callTask.TaskState = CallTaskStatus.Reconciliation;
					callTask.AssignedEmployee = personProvider.GetDefaultEmployeeForCallTask(uow);
					callTask.SourceDocumentId = (source as Order)?.Id;
					break;
			}

			if(creationComment != null)
				callTask.AddComment(uow, creationComment, employeeRepository);
			return callTask;
		}

		public CallTask FillNewTask(IUnitOfWork uow,CallTask callTask ,IEmployeeRepository employeeRepository)
		{
			callTask.CreationDate = DateTime.Now;
			callTask.TaskCreator = employeeRepository.GetEmployeeForCurrentUser(uow);
			callTask.EndActivePeriod = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
			return callTask;
		}
	}
}