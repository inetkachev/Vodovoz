﻿using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Dialect.Function;
using NHibernate.Transform;
using QS.DomainModel.UoW;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Orders;
using Vodovoz.Domain.Sale;

namespace Vodovoz.Repositories.Sale
{
	public static class ScheduleRestrictionRepository
	{
		public static QueryOver<ScheduleRestrictedDistrict> AreaWithGeometryQuery()
		{
			return QueryOver.Of<ScheduleRestrictedDistrict>().Where(x => x.DistrictBorder != null);
		}

		public static IList<ScheduleRestrictedDistrict> AreasWithGeometry(IUnitOfWork uow)
		{
			return AreaWithGeometryQuery()
							.GetExecutableQueryOver(uow.Session)
							.List();
		}

		public static IList<OrderCountResult> OrdersCountByDistrict(IUnitOfWork uow, DateTime date, int minBottlesInOrder)
		{
			OrderCountResult resultAlias = null;
			Domain.Orders.Order orderAlias = null;
			OrderItem orderItemsAlias = null;
			DeliveryPoint deliveryPointAlias = null;

			var districtSubquery = QueryOver.Of<ScheduleRestrictedDistrict>()
											.Where(
												Restrictions.Eq(
													Projections.SqlFunction(
														new SQLFunctionTemplate(
															NHibernateUtil.Boolean,
															"ST_WITHIN(PointFromText(CONCAT('POINT(', ?1 ,' ', ?2,')')), ?3)"
														),
														NHibernateUtil.Boolean,
														Projections.Property(() => deliveryPointAlias.Latitude),
														Projections.Property(() => deliveryPointAlias.Longitude),
														Projections.Property<ScheduleRestrictedDistrict>(x => x.DistrictBorder)
													),
													true
												)
											)
											.Select(x => x.Id)
											.Take(1);

			return uow.Session.QueryOver(() => orderAlias)
						  .Where(x => x.DeliveryDate == date)
						  .Where(x => x.OrderStatus == OrderStatus.Accepted || x.OrderStatus == OrderStatus.InTravelList)
						  .JoinQueryOver(x => x.OrderItems, () => orderItemsAlias)
						  .JoinQueryOver(x => x.Nomenclature)
						  .Where(x => x.Category == Domain.Goods.NomenclatureCategory.water && !x.IsDisposableTare)
												.JoinAlias(() => orderAlias.DeliveryPoint, () => deliveryPointAlias)
							.SelectList(list => list.SelectGroup(x => x.Id).WithAlias(() => resultAlias.OrderId)
										.SelectSum(() => orderItemsAlias.Count).WithAlias(() => resultAlias.WaterCount)
										.SelectSubQuery(districtSubquery).WithAlias(() => resultAlias.DistrictId)
									   )
							.Where(Restrictions.Gt(
								Projections.Sum(
								Projections.Property(() => orderItemsAlias.Count)), 12))
							.TransformUsing(Transformers.AliasToBean<OrderCountResult>())
							.List<OrderCountResult>();
		}

		public class OrderCountResult
		{
			public int OrderId;
			public int WaterCount;
			public int DistrictId;
		}
	}
}