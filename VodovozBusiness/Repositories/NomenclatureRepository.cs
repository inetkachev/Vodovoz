﻿using QSOrmProject;
using NHibernate.Criterion;
using QSSupportLib;
using System;
using Vodovoz.Domain.Goods;

namespace Vodovoz.Repository
{
	public static class NomenclatureRepository
	{

		public static QueryOver<Nomenclature> NomenclatureForProductMaterialsQuery ()
		{
			return QueryOver.Of<Nomenclature> ()
				.Where (n => n.Category.IsIn (Nomenclature.GetCategoriesForProductMaterial ()))
				            .Where(n => !n.IsArchive);
		}

		public static QueryOver<Nomenclature> NomenclatureEquipmentsQuery()
		{
			return QueryOver.Of<Nomenclature>()
				.Where(n => n.Category == NomenclatureCategory.equipment)
							.Where(n => !n.IsArchive);
		}

		public static QueryOver<Nomenclature> NomenclatureForSaleQuery ()
		{
			return QueryOver.Of<Nomenclature> ()
				.Where (n => n.Category.IsIn (Nomenclature.GetCategoriesForSale ()))
				            .Where(n => !n.IsArchive);
		}

		public static QueryOver<Nomenclature> NomenclatureByCategory(NomenclatureCategory category)
		{
			return QueryOver.Of<Nomenclature>()
				.Where(n => n.Category == category)
							.Where(n => !n.IsArchive);
		}

		/// <summary>
		/// Запрос номенклатур которые можно использовать на складе
		/// </summary>
		public static QueryOver<Nomenclature> NomenclatureOfGoodsOnlyQuery ()
		{
			return QueryOver.Of<Nomenclature> ()
				.Where (n => n.Category.IsIn (Nomenclature.GetCategoriesForGoods ()))
				            .Where(n => !n.IsArchive);
		}

		public static QueryOver<Nomenclature> NomenclatureWaterOnlyQuery ()
		{
			return QueryOver.Of<Nomenclature> ()
				.Where (n => n.Category == NomenclatureCategory.water)
				            .Where(n => !n.IsArchive);
		}

		public static Nomenclature GetBottleDeposit (IUnitOfWork uow)
		{
			var bottleDepositParameter = "bottleDeposit_id";
			if (!MainSupport.BaseParameters.All.ContainsKey (bottleDepositParameter))
				throw new InvalidProgramException("В параметрах базы не настроена номенклатура залога за бутыли.");
			return uow.GetById<Nomenclature> (int.Parse(MainSupport.BaseParameters.All [bottleDepositParameter]));
		}

		public static Nomenclature GetDefaultBottle (IUnitOfWork uow)
		{
			var defaultBottleParameter = "default_bottle_nomenclature";
			if (!MainSupport.BaseParameters.All.ContainsKey (defaultBottleParameter))
				throw new InvalidProgramException("В параметрах базы не настроена номенклатура бутыли по умолчанию.");
			return uow.GetById<Nomenclature> (int.Parse(MainSupport.BaseParameters.All [defaultBottleParameter]));
		}

		public static QueryOver<Nomenclature> NomenclatureOfItemsForService ()
		{
			return QueryOver.Of<Nomenclature> ()
				.Where (n => n.Category == NomenclatureCategory.equipment)
				            .Where(n => !n.IsArchive);
		}

		public static QueryOver<Nomenclature> NomenclatureOfPartsForService ()
		{
			return QueryOver.Of<Nomenclature> ()
				.Where (n => n.Category == NomenclatureCategory.spare_parts)
				            .Where(n => !n.IsArchive);
		}

		public static QueryOver<Nomenclature> NomenclatureOfServices ()
		{
			return QueryOver.Of<Nomenclature> ()
				.Where (n => n.Category == NomenclatureCategory.service)
				            .Where(n => !n.IsArchive);
		}
	}
}

