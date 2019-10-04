﻿using System.Collections.Generic;
using NHibernate.Criterion;
using QS.DomainModel.UoW;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Logistic;

namespace Vodovoz.EntityRepositories.Logistic
{
	public class CarRepository : ICarRepository
	{
		public Car GetCarByDriver(IUnitOfWork uow, Employee driver)
		{
			return uow.Session.QueryOver<Car>()
					  .Where(x => x.Driver == driver)
					  .Take(1)
					  .SingleOrDefault();
		}

		public IList<Car> GetCarsByDrivers(IUnitOfWork uow, int[] driversIds)
		{
			return uow.Session.QueryOver<Car>()
					  .Where(x => x.Driver.Id.IsIn(driversIds))
					  .List();
		}

		public QueryOver<Car> ActiveCompanyCarsQuery()
		{
			return QueryOver.Of<Car>()
							.Where(x => x.IsCompanyHavings && !x.IsArchive);
		}

		public QueryOver<Car> ActiveCarsQuery()
		{
			return QueryOver.Of<Car>()
							.Where(x => !x.IsArchive);
		}
	}
}