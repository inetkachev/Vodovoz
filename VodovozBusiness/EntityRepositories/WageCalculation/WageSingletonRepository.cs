﻿using System;
using System.Collections.Generic;
using QS.DomainModel.UoW;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.WageCalculation;
using Vodovoz.Domain.Logistic;
using NHibernate.Criterion;

namespace Vodovoz.EntityRepositories.WageCalculation
{
	public class WageSingletonRepository : IWageCalculationRepository
	{
		static WageSingletonRepository instance;
		public static WageSingletonRepository GetInstance()
		{
			if(instance == null)
				instance = new WageSingletonRepository();
			return instance;
		}

		protected WageSingletonRepository() { }

		public IEnumerable<WageDistrict> AllWageDistricts(IUnitOfWork uow, bool hideArchive = true)
		{
			var baseQuery = uow.Session.QueryOver<WageDistrict>();
			return hideArchive ? baseQuery.Where(d => !d.IsArchive).List() : baseQuery.List();
		}

		public IEnumerable<WageDistrictLevelRates> AllLevelRates(IUnitOfWork uow, bool hideArchive = true)
		{
			var baseQuery = uow.Session.QueryOver<WageDistrictLevelRates>();
			return hideArchive ? baseQuery.Where(d => !d.IsArchive).OrderBy(r => r.Name).Asc.List() : baseQuery.OrderBy(r => r.Name).Asc.List();
		}

		public IList<WageParameter> GetWageParameters(IUnitOfWork uow, WageParameterTargets wageParameterTarget)
		{
			return uow.Session.QueryOver<WageParameter>()
				.Where(x => x.WageParameterTarget == wageParameterTarget)
				.List();
		}

		public WageParameter GetActualParameterForOurCars(IUnitOfWork uow, DateTime dateTime)
		{
			return uow.Session.QueryOver<WageParameter>()
				.Where(x => x.WageParameterTarget == WageParameterTargets.ForOurCars)
				.Where(x => x.StartDate <= dateTime)
				.OrderBy(x => x.StartDate).Desc
				.Take(1)
				.SingleOrDefault();
		}

		public IEnumerable<SalesPlan> AllSalesPlans(IUnitOfWork uow, bool hideArchive = true)
		{
			var baseQuery = uow.Session.QueryOver<SalesPlan>();
			return hideArchive ? baseQuery.Where(d => !d.IsArchive).List() : baseQuery.List();
		}

		public WageDistrictLevelRates DefaultLevelForNewEmployees(IUnitOfWork uow)
		{
			return uow.Session.QueryOver<WageDistrictLevelRates>()
							  .Where(x => x.IsDefaultLevel)
							  .Take(1)
							  .SingleOrDefault();
		}

		public IEnumerable<DateTime> GetDaysWorkedWithRouteLists(IUnitOfWork uow, Employee employee)
		{
			if(uow == null) {
				throw new ArgumentNullException(nameof(uow));
			}

			if(employee == null) {
				throw new ArgumentNullException(nameof(employee));
			}

			return uow.Session.QueryOver<RouteList>()
				.Where(x => x.Driver.Id == employee.Id)
				.Select(Projections.Distinct(Projections.Property<RouteList>(x => x.Date)))
				.List<DateTime>();
		}
	}
}