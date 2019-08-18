﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QS.DomainModel.Entity;
using QS.DomainModel.Entity.EntityPermissions;
using QS.DomainModel.UoW;
using QS.Contacts;
using Vodovoz.Domain.Employees;
using Vodovoz.Repositories.HumanResources;

namespace Vodovoz.Domain.Client
{
	[Appellative(Gender = GrammaticalGender.Masculine,
		NominativePlural = "Задачи по обзвону",
		Nominative = "Задача по обзвону"
	)]
	[EntityPermission]
	public class CallTask : PropertyChangedBase, ITask , IValidatableObject
	{
		public virtual string Title {
			get { return String.Format(" задача по обзвону : {0}", DeliveryPoint?.ShortAddress); }
		}

		public virtual int Id { get; set; }

		public virtual IList<Phone> Phones { get { return DeliveryPoint.Phones; } }

		string comment;
		[Display(Name = "Комментарий")]
		public virtual string Comment {
			get { return comment; }
			set { SetField(ref comment, value, () => Comment); }
		}

		DeliveryPoint deliveryPoint;
		[Display(Name = "Aдрес клиента")]
		public virtual DeliveryPoint DeliveryPoint {
			get { return deliveryPoint; }
			set {   
					SetField(ref deliveryPoint, value, () => DeliveryPoint);
					Counterparty = deliveryPoint?.Counterparty;
				}
		}

		Counterparty counterparty;
		[Display(Name = "Клиент")]
		public virtual Counterparty Counterparty{
			get { return counterparty; }
			set { SetField(ref counterparty, value, () => Counterparty); }
		}

		CallTaskStatus taskState;
		[Display(Name = "Статус")]
		public virtual CallTaskStatus TaskState {
			get { return taskState; }
			set { SetField(ref taskState, value, () => TaskState); }
		}

		ImportanceDegreeType importanceDegree;
		[Display(Name = "Срочность задачи")]
		public virtual ImportanceDegreeType ImportanceDegree {
			get { return importanceDegree; }
			set { SetField(ref importanceDegree, value, () => ImportanceDegree); }
		}

		DateTime creationDate;
		[Display(Name = "Дата создания задачи")]
		public virtual DateTime CreationDate {
			get { return creationDate; }
			set { SetField(ref creationDate, value, () => CreationDate); }
		}

		DateTime? completeDate;
		[Display(Name = "Дата выполнения задачи")]
		public virtual DateTime? CompleteDate {
			get { return completeDate; }
			set { SetField(ref completeDate, value, () => CompleteDate); }
		}

		[Display(Name = "Период активности задачи (начало)")]
		public virtual DateTime StartActivePeriod { get { return EndActivePeriod.AddDays(-1); } set { } }

		DateTime endActivePeriod;
		[Display(Name = "Срок выполнения задачи")]
		public virtual DateTime EndActivePeriod {
			get { return endActivePeriod; }
			set { SetField(ref endActivePeriod, value, () => EndActivePeriod); }
		}

		Employee assignedEmployee;
		[Display(Name = "Закреплено за")]
		public virtual Employee AssignedEmployee {
			get { return assignedEmployee; }
			set { SetField(ref assignedEmployee, value, () => AssignedEmployee); }
		}

		Employee taskCreator;
		[Display(Name = "Создатель задачи")]
		public virtual Employee TaskCreator {
			get { return taskCreator; }
			set { SetField(ref taskCreator, value, () => TaskCreator); }
		}

		bool isTaskComplete;
		[Display(Name = "Статус выполнения задачи")]
		public virtual bool IsTaskComplete {
			get { return isTaskComplete; }
			set { 
				SetField(ref isTaskComplete, value, () => IsTaskComplete);
				completeDate =  isTaskComplete ? DateTime.Now as DateTime?  : null ;
			}
		}

		int tareReturn;
		[Display(Name = "Количество тары на сдачу")]
		public virtual int TareReturn {
			get { return tareReturn; }
			set { SetField(ref tareReturn, value, () => TareReturn); }
		}

		public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if(DeliveryPoint == null)
				yield return new ValidationResult("Должна быть выбрана точка доставки", new[] { "Address" });
		}

		public virtual CallTask CreateNewTask(IUnitOfWork uow)
		{
			CallTask task = new CallTask 
			{
				DeliveryPoint = DeliveryPoint,
				TaskCreator = EmployeeRepository.GetEmployeeForCurrentUser(uow),
				Counterparty = Counterparty,
				CreationDate = DateTime.Now,
				EndActivePeriod = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59),
				AssignedEmployee = AssignedEmployee
			};
			return task;
		}

		public virtual void CopyTask(CallTask callTask , IUnitOfWork uow)
		{
			DeliveryPoint = callTask.DeliveryPoint;
			Counterparty = callTask.Counterparty;
			TaskCreator = EmployeeRepository.GetEmployeeForCurrentUser(uow); 
			CreationDate = DateTime.Now;
			EndActivePeriod = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
			AssignedEmployee = callTask.AssignedEmployee;
		}

		public virtual void AddComment(IUnitOfWork UoW , string comment , out string lastComment)
		{
			var employee = EmployeeRepository.GetEmployeeForCurrentUser(UoW);
			comment = comment.Insert(0, employee.ShortName + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + ": ");
			lastComment = comment;
			Comment += comment;
			Comment += Environment.NewLine; 
		}

		public virtual void AddComment(IUnitOfWork UoW, string comment)
		{
			AddComment(UoW, comment, out string lastComment);
		}

	}

	public enum CallTaskStatus
	{
		[Display(Name = "Звонок")]
		Call,
		[Display(Name = "Задание")]
		Task,
		[Display(Name = "Сложный клиент")]
		DifficultClient
	}

	public enum ImportanceDegreeType
	{
		[Display(Name = "Нет")]
		Nope,
		[Display(Name = "Важно")]
		Important
	}

	public class CallTaskStatusStringType : NHibernate.Type.EnumStringType
	{
		public CallTaskStatusStringType() : base(typeof(CallTaskStatus))
		{
		}
	}

	public class ImportanceDegreeStringType : NHibernate.Type.EnumStringType
	{
		public ImportanceDegreeStringType() : base(typeof(ImportanceDegreeType))
		{
		}
	}

	public interface ITask : IDomainObject
	{
		Counterparty Counterparty { get; set; }

		DeliveryPoint DeliveryPoint { get; set; }

		DateTime CreationDate { get; set; }

		DateTime? CompleteDate { get; set; }

		DateTime StartActivePeriod { get; set; }

		DateTime EndActivePeriod{ get; set; }

		bool IsTaskComplete { get; set; }

		Employee AssignedEmployee { get; set; }

		Employee TaskCreator { get; set; }

		string Comment { get; set; }

		IList<Phone> Phones { get; }
	}
}
