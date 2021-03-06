﻿using System;
using QS.DomainModel.UoW;
using Vodovoz.Domain.Sale;
using System.Collections.Generic;
using NetTopologySuite.Geometries;
using System.Linq;

namespace Vodovoz.EntityRepositories.Delivery
{
	public class DeliveryRepository : IDeliveryRepository
	{
		#region Получение районов по координатам

		public ScheduleRestrictedDistrict GetDistrict(IUnitOfWork uow, decimal latitude, decimal longitude)
		{
			var districts = GetDistricts(uow, latitude, longitude);
			return districts.FirstOrDefault();
		}

		public IEnumerable<ScheduleRestrictedDistrict> GetDistricts(IUnitOfWork uow, decimal latitude, decimal longitude)
		{
			Point point = new Point((double)latitude, (double)longitude);

			IList<ScheduleRestrictedDistrict> districtsWithBorders = uow.Session.QueryOver<ScheduleRestrictedDistrict>().Where(x => x.DistrictBorder != null).List();

			var districts = districtsWithBorders.Where(x => x.DistrictBorder.Contains(point));

			if(districts.Any()) {
				return districts;
			}

			foreach(var nearPoint in Get4PointsInRadiusOfXMetersFromBasePoint(point)) {
				districts = districtsWithBorders.Where(x => x.DistrictBorder.Contains(nearPoint));
				if(districts.Any()) {
					return districts;
				}
			}
			return new List<ScheduleRestrictedDistrict>();
		}

		/// <summary>
		/// Получение 4 точек, отстоящих от базовой точки на <paramref name="distanceInMeters"/> вправо, влево, вверх и вниз.
		/// </summary>
		/// <param name="basePoint">Базовая точка</param>
		/// <param name="distanceInMeters">Дистанция отступа от базовой точки <paramref name="basePoint"/></param>
		private Point[] Get4PointsInRadiusOfXMetersFromBasePoint(Point basePoint, double distanceInMeters = 100)
		{
			Point[] array = new Point[4];
			array[0] = new Point(GetNewLatitude(basePoint.X, distanceInMeters), basePoint.Y);
			array[1] = new Point(basePoint.X, GetNewLongitude(basePoint.Y, distanceInMeters));
			array[2] = new Point(GetNewLatitude(basePoint.X, -distanceInMeters), basePoint.Y);
			array[3] = new Point(basePoint.X, GetNewLongitude(basePoint.Y, -distanceInMeters));
			return array;
		}

		private double GetNewLatitude(double lat, double metersToAdd)
		{
			double earth = 6378.137; //radius of the earth in kilometer
			double pi = Math.PI;
			double m = 1 / (2 * pi / 360 * earth) / 1000;  //1 meter in degree

			double newLatitude = lat + (metersToAdd * m);

			return newLatitude;
		}

		private double GetNewLongitude(double lon, double metersToAdd)
		{
			double earth = 6378.137;  //radius of the earth in kilometer
			double pi = Math.PI;
			double m = 1 / (2 * pi / 360 * earth) / 1000;  //1 meter in degree

			double newLongitude = lon + metersToAdd * m / Math.Cos(lon * (pi / 180));
			return newLongitude;
		}

		#endregion Получение районов по координатам
	}
}
