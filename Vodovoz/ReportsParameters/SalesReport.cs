﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Bindings.Collections.Generic;
using System.Linq;
using Gamma.ColumnConfig;
using Gamma.GtkWidgets;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Dialect.Function;
using NHibernate.Transform;
using QS.DomainModel.Entity;
using QS.DomainModel.UoW;
using QS.Report;
using QSReport;
using Vodovoz.Domain;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Orders;
using Gamma.Utilities;
using Vodovoz.Domain.Sale;
using QS.Dialog.GtkUI;
using NHibernate.Util;
using Gamma.Binding;

namespace Vodovoz.Reports
{
	public partial class SalesReport : SingleUoWWidgetBase, IParametersWidget
	{
		class SalesReportNode : PropertyChangedBase
		{
			public int Id { get; set; }

			public string Name { get; set; }

			private bool selected;

			public bool Selected {
				get => selected;
				set => SetField(ref selected, value, () => Selected);
			}
		}

		/// <summary>
		/// Конструкция фильтра где фильтры могут быть связаны друг с другом,
		/// позволяет снимать выделение документов и фильтровать наборы данных других фильтров
		/// 
		/// Принцип работы: Выбираемые в одном фильтре Id передается связанным фильтрам по FilteringRelation
		/// в связанных фильтрах наборы данных фильтруются по переданным им Id, условия фильтрации определяются
		/// в функции переданной при создании фильтра.
		/// </summary>
		class Criterion
		{
			//Набор данных
			private List<SalesReportNode> list = new List<SalesReportNode>();
			//Observable служит для подсчета количества выделенных элементов при их выделении
			public GenericObservableList<SalesReportNode> ObservableList;

			/// <summary>
			/// Функция по получению набора данных, принимающая массив id для фильтрации
			/// </summary>
			private Func<int[], List<SalesReportNode>> sourceFunction;

			public List<Criterion> UnselectRelation = new List<Criterion>();
			public List<Criterion> FilteringRelation = new List<Criterion>();
			/// <summary>
			/// Хранит массив id  
			/// </summary>
			/// <value>The filtered identifier.</value>
			public int[] FilteredId { get; set; }

			public event Action<string> Changed;

			public void SubcribeWithClearOld(Action<string> action)
			{
				Changed = delegate { };
				Changed += action;
			}

			public bool HaveSelected {
				get { return list.Any(x => x.Selected); }
			}

			public void Unselect()
			{
				if(HaveSelected) {
					ObservableList.ElementChanged -= ObservableList_ElementChanged_Unselect;
					list.Where(x => x.Selected).ToList().ForEach((obj) => { obj.Selected = false; });
					ObservableList.ElementChanged += ObservableList_ElementChanged_Unselect;
				}
			}

			public void RefreshItems()
			{
				list = sourceFunction.Invoke(FilteredId);
				ObservableList = new GenericObservableList<SalesReportNode>(list);

				ObservableList.ElementChanged -= ObservableList_ElementChanged_Unselect;
				ObservableList.ElementChanged += ObservableList_ElementChanged_Unselect;

				ObservableList.ElementChanged -= ObservableList_ElementChanged_Filtering;
				ObservableList.ElementChanged += ObservableList_ElementChanged_Filtering;
			}

			void ObservableList_ElementChanged_Unselect(object aList, int[] aIdx)
			{
				if(UnselectRelation.Any()) {
					UnselectRelation.ForEach(x => x.Unselect());
				}
				Changed?.Invoke(SumSelected());
			}

			void ObservableList_ElementChanged_Filtering(object aList, int[] aIdx)
			{
				FilteringRelation.ForEach(x => x.Unselect());
				FilteringRelation.ForEach(x => x.FilteredId = ObservableList.Where(o => o.Selected).Select(o => o.Id).ToArray());
				FilteringRelation.ForEach(x => x.RefreshItems());
				Changed?.Invoke(SumSelected());
			}

			public Criterion(Func<int[], List<SalesReportNode>> sourceFunc)
			{
				sourceFunction = sourceFunc;
				RefreshItems();
			}

			string SumSelected() => ObservableList.Count(x => x.Selected).ToString();
		}

		enum FilterTypes
		{
			NomenclatureInclude,
			NomenclatureExclude,
			NomenclatureTypeInclude,
			NomenclatureTypeExclude,
			ClientInclude,
			ClientExclude,
			OrganizationInclude,
			OrganizationExclude,
			DiscountReasonInclude,
			DiscountReasonExclude,
			SubdivisionInclude,
			SubdivisionExclude,
			OrderAuthorInclude,
			OrderAuthorExclude,
			GeoGrpInclude,
			GeoGrpExclude,
			PaymentTypeInclude,
			PaymentTypeExclude,
			PromoSetInclude,
			PromoSetExclude
		}

		Dictionary<FilterTypes, Criterion> criterions = new Dictionary<FilterTypes, Criterion>();
		GenericObservableList<SelectableProductGroupNode> observableProductGroups { get; set; }

		public SalesReport()
		{
			this.Build();
			UoW = UnitOfWorkFactory.CreateWithoutRoot();
			ConfigureFilters();
			ConfigureDlg();
		}

		private void ConfigureDlg()
		{
			dateperiodpicker.StartDate = dateperiodpicker.EndDate = DateTime.Today;

			ytreeviewSelectedList.ColumnsConfig = ColumnsConfigFactory
				.Create<SalesReportNode>()
				.AddColumn("Выбрать").AddToggleRenderer(n => n.Selected).Editing()
				.AddColumn("Название").AddTextRenderer(n => n.Name)
					.WrapMode(Pango.WrapMode.WordChar)
					.WrapWidth(400)
				.Finish();

			scrolledwindow3.WidthRequest = 350;

			ConfigureProductGroups();
		}

		private void ConfigureProductGroups()
		{
			var groups = UoW.Session.QueryOver<ProductGroup>().List().ToList();
			var parentGroups = UoW.Session.QueryOver<ProductGroup>().Where(g => g.MappedParent == null).List().ToList();

			List<SelectableProductGroupNode> items = new List<SelectableProductGroupNode>();

			foreach(var parentGroup in parentGroups) {
				var node = new SelectableProductGroupNode();
				node.Name = parentGroup.Name;
				node.Id = parentGroup.Id;
				node.Children = GenerateGoodsGroupNodes(groups, parentGroup);
				node.Children.ForEach(x => x.Parent = node);
				items.Add(node);
			}

			observableProductGroups = new GenericObservableList<SelectableProductGroupNode>(items);
			observableProductGroups.ListContentChanged += (sender, e) => { ytreeviewProductGroup.QueueDraw(); };

			foreach(SelectableProductGroupNode item in SelectableProductGroupNode.GetAllNodes(observableProductGroups)) {
				if(item.Children != null && item.Children.Any()) {
					item.Children.ListContentChanged += (sender, e) => { ytreeviewProductGroup.QueueDraw(); };
				}
			}

			ytreeviewProductGroup.ColumnsConfig = FluentColumnsConfig<SelectableProductGroupNode>
				.Create()
				.AddColumn("Выбрать").AddToggleRenderer(node => node.Selected).Editing()
				.AddColumn("Название").AddTextRenderer(node => node.Name)
					.WrapMode(Pango.WrapMode.WordChar)
					.WrapWidth(200)
				.Finish();

			ytreeviewProductGroup.WidthRequest = 300;
			ytreeviewProductGroup.YTreeModel = new RecursiveTreeModel<SelectableProductGroupNode>(
				observableProductGroups, x => x.Parent, x => x.Children);
		}

		public GenericObservableList<SelectableProductGroupNode> GenerateGoodsGroupNodes(List<ProductGroup> groups, ProductGroup parent)
		{
			var result = new GenericObservableList<SelectableProductGroupNode>();

			foreach(var item in groups.Where(x => x.Parent == parent)) {
				var subNode = new SelectableProductGroupNode();
				subNode.Name = item.Name;
				subNode.Id = item.Id;
				subNode.Children = GenerateGoodsGroupNodes(groups, item);
				subNode.Children.ForEach(x => x.Parent = subNode);
				result.Add(subNode);
			}
			return result;
		}

		private void ConfigureFilters()
		{
			//Номенклатура
			Criterion nomenclatureIncludeCrit = CreateNomenclatureCriterion();
			Criterion nomenclatureExcludeCrit = CreateNomenclatureCriterion();
			//Типы номенклатуры
			Criterion nomenclatureTypeIncludeCrit = CreateNomenclatureTypeCriterion();
			Criterion nomenclatureTypeExcludeCrit = CreateNomenclatureTypeCriterion();
			// Клиенты
			Criterion clientIncludeCrit = CreateCounterpartyCriterion();
			Criterion clientExcludeCrit = CreateCounterpartyCriterion();
			// Поставщики (организации)
			Criterion organizationIncludeCrit = CreateOrganizationCriterion();
			Criterion organizationExcludeCrit = CreateOrganizationCriterion();
			// Основания скидок
			Criterion discountReasonIncludeCrit = CreateDiscountReasonCriterion();
			Criterion discountReasonExcludeCrit = CreateDiscountReasonCriterion();
			// Отделы пользователей
			Criterion subdivisionIncludeCrit = CreateSubdivisionCriterion();
			Criterion subdivisionExcludeCrit = CreateSubdivisionCriterion();
			// Авторы заказов
			Criterion orderAuthorIncludeCrit = CreateOrderAuthorCriterion();
			Criterion orderAuthorExcludeCrit = CreateOrderAuthorCriterion();
			//Части города
			Criterion geoGrpIncludeCrit = CreategeoGrpCriterion();
			Criterion geoGrpExcludeCrit = CreategeoGrpCriterion();
			//Тип оплаты
			Criterion paymentTypeIncludeCrit = CreatePaymentTypeCriterion();
			Criterion paymentTypeExcludeCrit = CreatePaymentTypeCriterion();
			//Промо-набор
			Criterion promoSetIncludeCrit = CreatePromoSetCriterion();
			Criterion promoSetExcludeCrit = CreatePromoSetCriterion();

			//Задание связей по фильтрации и снятию выделения между критериями
			//Номенклатура
			nomenclatureIncludeCrit.UnselectRelation.Add(nomenclatureExcludeCrit);
			nomenclatureExcludeCrit.UnselectRelation.Add(nomenclatureIncludeCrit);
			//Типы номенклатур
			nomenclatureTypeIncludeCrit.FilteringRelation.Add(nomenclatureIncludeCrit);
			nomenclatureTypeIncludeCrit.FilteringRelation.Add(nomenclatureExcludeCrit);
			nomenclatureTypeIncludeCrit.UnselectRelation.Add(nomenclatureIncludeCrit);
			nomenclatureTypeIncludeCrit.UnselectRelation.Add(nomenclatureExcludeCrit);
			nomenclatureTypeIncludeCrit.UnselectRelation.Add(nomenclatureTypeExcludeCrit);
			nomenclatureTypeExcludeCrit.FilteringRelation.Add(nomenclatureIncludeCrit);
			nomenclatureTypeExcludeCrit.FilteringRelation.Add(nomenclatureExcludeCrit);
			nomenclatureTypeExcludeCrit.UnselectRelation.Add(nomenclatureIncludeCrit);
			nomenclatureTypeExcludeCrit.UnselectRelation.Add(nomenclatureExcludeCrit);
			nomenclatureTypeExcludeCrit.UnselectRelation.Add(nomenclatureTypeIncludeCrit);
			//Клиенты
			clientIncludeCrit.UnselectRelation.Add(clientExcludeCrit);
			clientExcludeCrit.UnselectRelation.Add(clientIncludeCrit);
			//Организации
			organizationIncludeCrit.UnselectRelation.Add(organizationExcludeCrit);
			organizationExcludeCrit.UnselectRelation.Add(organizationIncludeCrit);
			//Основания для скидок
			discountReasonIncludeCrit.UnselectRelation.Add(discountReasonExcludeCrit);
			discountReasonExcludeCrit.UnselectRelation.Add(discountReasonIncludeCrit);
			//Отделы пользователей
			subdivisionIncludeCrit.FilteringRelation.Add(orderAuthorIncludeCrit);
			subdivisionIncludeCrit.FilteringRelation.Add(orderAuthorExcludeCrit);
			subdivisionIncludeCrit.UnselectRelation.Add(orderAuthorIncludeCrit);
			subdivisionIncludeCrit.UnselectRelation.Add(orderAuthorExcludeCrit);
			subdivisionIncludeCrit.UnselectRelation.Add(subdivisionExcludeCrit);
			subdivisionExcludeCrit.FilteringRelation.Add(orderAuthorIncludeCrit);
			subdivisionExcludeCrit.FilteringRelation.Add(orderAuthorExcludeCrit);
			subdivisionExcludeCrit.UnselectRelation.Add(orderAuthorIncludeCrit);
			subdivisionExcludeCrit.UnselectRelation.Add(orderAuthorExcludeCrit);
			subdivisionExcludeCrit.UnselectRelation.Add(subdivisionIncludeCrit);
			//Авторы заказов
			orderAuthorIncludeCrit.UnselectRelation.Add(orderAuthorExcludeCrit);
			orderAuthorExcludeCrit.UnselectRelation.Add(orderAuthorIncludeCrit);
			//Части города
			geoGrpIncludeCrit.UnselectRelation.Add(geoGrpExcludeCrit);
			geoGrpExcludeCrit.UnselectRelation.Add(geoGrpIncludeCrit);
			//Типы оплаты
			paymentTypeIncludeCrit.UnselectRelation.Add(paymentTypeExcludeCrit);
			paymentTypeExcludeCrit.UnselectRelation.Add(paymentTypeIncludeCrit);
			//Промо-наборы
			promoSetIncludeCrit.UnselectRelation.Add(promoSetExcludeCrit);
			promoSetExcludeCrit.UnselectRelation.Add(promoSetIncludeCrit);

			//Сохранение фильтров для использования
			criterions.Add(FilterTypes.NomenclatureInclude, nomenclatureIncludeCrit);
			criterions.Add(FilterTypes.NomenclatureExclude, nomenclatureExcludeCrit);
			criterions.Add(FilterTypes.NomenclatureTypeInclude, nomenclatureTypeIncludeCrit);
			criterions.Add(FilterTypes.NomenclatureTypeExclude, nomenclatureTypeExcludeCrit);
			criterions.Add(FilterTypes.ClientInclude, clientIncludeCrit);
			criterions.Add(FilterTypes.ClientExclude, clientExcludeCrit);
			criterions.Add(FilterTypes.OrganizationInclude, organizationIncludeCrit);
			criterions.Add(FilterTypes.OrganizationExclude, organizationExcludeCrit);
			criterions.Add(FilterTypes.DiscountReasonInclude, discountReasonIncludeCrit);
			criterions.Add(FilterTypes.DiscountReasonExclude, discountReasonExcludeCrit);
			criterions.Add(FilterTypes.SubdivisionInclude, subdivisionIncludeCrit);
			criterions.Add(FilterTypes.SubdivisionExclude, subdivisionExcludeCrit);
			criterions.Add(FilterTypes.OrderAuthorInclude, orderAuthorIncludeCrit);
			criterions.Add(FilterTypes.OrderAuthorExclude, orderAuthorExcludeCrit);
			criterions.Add(FilterTypes.GeoGrpInclude, geoGrpIncludeCrit);
			criterions.Add(FilterTypes.GeoGrpExclude, geoGrpExcludeCrit);
			criterions.Add(FilterTypes.PaymentTypeInclude, paymentTypeIncludeCrit);
			criterions.Add(FilterTypes.PaymentTypeExclude, paymentTypeExcludeCrit);
			criterions.Add(FilterTypes.PromoSetInclude, promoSetIncludeCrit);
			criterions.Add(FilterTypes.PromoSetExclude, promoSetExcludeCrit);
		}

		#region Создание фильтров

		private Criterion CreateOrderAuthorCriterion()
		{
			return new Criterion((arg) => {
				SalesReportNode alias = null;
				Employee employeeAlias = null;
				var query = UoW.Session.QueryOver<Employee>(() => employeeAlias);
				if(arg != null && arg.Any()) {
					query.WhereRestrictionOn(x => x.Subdivision.Id).IsIn(arg);
				}
				var queryResult = query.SelectList(list => list
												   .Select(x => x.Id).WithAlias(() => alias.Id)
												   .Select(
													   Projections.SqlFunction(
														   new SQLFunctionTemplate(NHibernateUtil.String, "CONCAT(?2,' ',SUBSTR(?1,1,1))"),
														   NHibernateUtil.String,
														   Projections.Property(() => employeeAlias.Name),
														   Projections.Property(() => employeeAlias.LastName)
														  )
													  ).WithAlias(() => alias.Name)
												  ).OrderBy(o => o.LastName).Asc
				.TransformUsing(Transformers.AliasToBean<SalesReportNode>())
				.List<SalesReportNode>();
				return queryResult.ToList();
			});
		}

		private Criterion CreateSubdivisionCriterion()
		{
			return new Criterion((arg) => {
				List<SalesReportNode> result = new List<SalesReportNode>();
				SalesReportNode alias = null;
				return UoW.Session.QueryOver<Subdivision>()
						  .SelectList(list => list
									  .Select(x => x.Id).WithAlias(() => alias.Id)
									  .Select(x => x.Name).WithAlias(() => alias.Name)
									 )
						  .TransformUsing(Transformers.AliasToBean<SalesReportNode>())
						  .List<SalesReportNode>().ToList();
			});
		}

		private Criterion CreateDiscountReasonCriterion()
		{
			return new Criterion((arg) => {
				SalesReportNode alias = null;
				var query = UoW.Session.QueryOver<DiscountReason>();
				var queryResult = query.SelectList(list => list
						 .Select(x => x.Id).WithAlias(() => alias.Id)
						 .Select(x => x.Name).WithAlias(() => alias.Name)
						)
				.TransformUsing(Transformers.AliasToBean<SalesReportNode>())
				.List<SalesReportNode>()
				.OrderBy(x => x.Name);
				return queryResult.ToList();
			});
		}

		private Criterion CreateOrganizationCriterion()
		{
			return new Criterion((arg) => {
				SalesReportNode alias = null;
				var query = UoW.Session.QueryOver<Organization>();
				var queryResult = query.SelectList(list => list
						 .Select(x => x.Id).WithAlias(() => alias.Id)
						 .Select(x => x.Name).WithAlias(() => alias.Name)
						)
				.TransformUsing(Transformers.AliasToBean<SalesReportNode>())
				.List<SalesReportNode>();
				return queryResult.ToList();
			});
		}

		private Criterion CreateCounterpartyCriterion()
		{
			return new Criterion((arg) => {
				SalesReportNode alias = null;
				var query = UoW.Session.QueryOver<Counterparty>();
				var queryResult = query.SelectList(list => list
						 .Select(x => x.Id).WithAlias(() => alias.Id)
						 .Select(x => x.Name).WithAlias(() => alias.Name)
						)
				.TransformUsing(Transformers.AliasToBean<SalesReportNode>())
				.List<SalesReportNode>();
				return queryResult.ToList();
			});
		}

		private Criterion CreateNomenclatureTypeCriterion()
		{
			return new Criterion((arg) => {
				List<SalesReportNode> result = new List<SalesReportNode>();
				var categories = Enum.GetValues(typeof(NomenclatureCategory)).Cast<NomenclatureCategory>();
				foreach(var item in categories) {
					result.Add(new SalesReportNode() {
						Id = (int)item,
						Name = item.GetAttribute<DisplayAttribute>().Name
					});
				}
				return result;
			});
		}

		private Criterion CreateNomenclatureCriterion()
		{
			return new Criterion((arg) => {
				SalesReportNode alias = null;
				var query = UoW.Session.QueryOver<Nomenclature>()
							   .Where(n => n.IsArchive == false);
				if(arg != null && arg.Any()) {
					NomenclatureCategory[] categories = new NomenclatureCategory[arg.Count()];
					for(int i = 0; i < arg.Count(); i++) {
						categories[i] = (NomenclatureCategory)arg[i];
					}
					query.WhereRestrictionOn(x => x.Category).IsIn(categories);
				}
				var queryResult = query.SelectList(list => list
						 .Select(x => x.Id).WithAlias(() => alias.Id)
						 .Select(x => x.Name).WithAlias(() => alias.Name)
						)
				.TransformUsing(Transformers.AliasToBean<SalesReportNode>())
				.List<SalesReportNode>();
				return queryResult.ToList();
			});
		}

		Criterion CreategeoGrpCriterion()
		{
			return new Criterion(
				(arg) => {
					SalesReportNode alias = null;
					var query = UoW.Session.QueryOver<GeographicGroup>();
					var queryResult = query.SelectList(
						list => list.Select(x => x.Id).WithAlias(() => alias.Id)
									.Select(x => x.Name).WithAlias(() => alias.Name)
						)
						.TransformUsing(Transformers.AliasToBean<SalesReportNode>())
						.List<SalesReportNode>();
					return queryResult.ToList();
				}
			);
		}

		Criterion CreatePaymentTypeCriterion()
		{
			return new Criterion(
				(arg) => {
					List<SalesReportNode> result = new List<SalesReportNode>();
					var categories = Enum.GetValues(typeof(PaymentType)).Cast<PaymentType>();
					foreach(var item in categories) {
						result.Add(new SalesReportNode {
							Id = (int)item,
							Name = item.GetAttribute<DisplayAttribute>().Name
						});
					}
					return result;
				}
			);
		}

		Criterion CreatePromoSetCriterion()
		{
			return new Criterion(
				(arg) => {
					SalesReportNode alias = null;
					var query = UoW.Session.QueryOver<PromotionalSet>();
					var queryResult = query.SelectList(
						list => list.Select(x => x.Id).WithAlias(() => alias.Id)
									.Select((x) => x.Name).WithAlias(() => alias.Name)
						)
						.TransformUsing(Transformers.AliasToBean<SalesReportNode>())
						.List<SalesReportNode>();
					return queryResult.ToList();
				}
			);
		}

		#endregion

		#region IParametersWidget implementation

		public event EventHandler<LoadReportEventArgs> LoadReport;

		public string Title => "Отчет по продажам";

		#endregion

		private string[] GetCategories(int[] enumIds)
		{
			if(!enumIds.Any()) {
				return new string[] { "0" };
			}
			string[] result = new string[enumIds.Count()];
			for(int i = 0; i < enumIds.Count(); i++) {
				result[i] = ((NomenclatureCategory)enumIds[i]).ToString();
			}
			return result;
		}

		private string[] GetPayTypes(int[] enumIds)
		{
			if(!enumIds.Any()) {
				return new string[] { "0" };
			}
			string[] result = new string[enumIds.Count()];
			for(int i = 0; i < enumIds.Count(); i++) {
				result[i] = ((PaymentType)enumIds[i]).ToString();
			}
			return result;
		}

		private int[] GetResultIds(IEnumerable<int> ids)
		{
			return ids.Any() ? ids.ToArray() : new int[] { 0 };
		}

		private ReportInfo GetReportInfo()
		{
			string[] includeCategories = GetCategories(criterions[FilterTypes.NomenclatureTypeInclude].ObservableList.Where(x => x.Selected).Select(d => d.Id).ToArray());
			string[] excludeCategories = GetCategories(criterions[FilterTypes.NomenclatureTypeExclude].ObservableList.Where(x => x.Selected).Select(d => d.Id).ToArray());

			string[] includePayTypes = GetPayTypes(criterions[FilterTypes.PaymentTypeInclude].ObservableList.Where(x => x.Selected).Select(d => d.Id).ToArray());
			string[] excludePayTypes = GetPayTypes(criterions[FilterTypes.PaymentTypeExclude].ObservableList.Where(x => x.Selected).Select(d => d.Id).ToArray());

			int[] productGroupIds = SelectableProductGroupNode.GetAllNodes(observableProductGroups)
																 .Where(g => g.Children == null || !g.Children.Any())
																 .Where(g => g.Selected)
																 .Select(g => g.Id).ToArray();

			return new ReportInfo {
				Identifier = ycheckbuttonDetail.Active ? "Sales.SalesReportDetail" : "Sales.SalesReport",
				Parameters = new Dictionary<string, object>
				{
					{ "start_date", dateperiodpicker.StartDateOrNull },
					{ "end_date", dateperiodpicker.EndDateOrNull },
					//тип номенклатур
					{ "nomtype_include", includeCategories },
					{ "nomtype_exclude", excludeCategories },
					//номенклатуры
					{ "nomen_include", GetResultIds(criterions[FilterTypes.NomenclatureInclude].ObservableList.Where(x => x.Selected).Select(d => d.Id))},
					{ "nomen_exclude", GetResultIds(criterions[FilterTypes.NomenclatureExclude].ObservableList.Where(x => x.Selected).Select(d => d.Id))},
					//клиенты
					{ "client_include", GetResultIds(criterions[FilterTypes.ClientInclude].ObservableList.Where(x => x.Selected).Select(d => d.Id)) },
					{ "client_exclude", GetResultIds(criterions[FilterTypes.ClientExclude].ObservableList.Where(x => x.Selected).Select(d => d.Id)) },
					//поставщики (наши организации)
					{ "org_include", GetResultIds(criterions[FilterTypes.OrganizationInclude].ObservableList.Where(x => x.Selected).Select(d => d.Id)) },
					{ "org_exclude", GetResultIds(criterions[FilterTypes.OrganizationExclude].ObservableList.Where(x => x.Selected).Select(d => d.Id)) },
					//основания для скидок
					{ "discountreason_include", GetResultIds(criterions[FilterTypes.DiscountReasonInclude].ObservableList.Where(x => x.Selected).Select(d => d.Id)) },
					{ "discountreason_exclude", GetResultIds(criterions[FilterTypes.DiscountReasonExclude].ObservableList.Where(x => x.Selected).Select(d => d.Id)) },
					//авторы заказа
					{ "subdivision_include", GetResultIds(criterions[FilterTypes.SubdivisionInclude].ObservableList.Where(x => x.Selected).Select(d => d.Id)) },
					{ "subdivision_exclude", GetResultIds(criterions[FilterTypes.SubdivisionExclude].ObservableList.Where(x => x.Selected).Select(d => d.Id)) },
					//авторы заказа
					{ "orderauthor_include", GetResultIds(criterions[FilterTypes.OrderAuthorInclude].ObservableList.Where(x => x.Selected).Select(d => d.Id)) },
					{ "orderauthor_exclude", GetResultIds(criterions[FilterTypes.OrderAuthorExclude].ObservableList.Where(x => x.Selected).Select(d => d.Id)) },
					//Части города
					{ "geographic_groups_include", GetResultIds(criterions[FilterTypes.GeoGrpInclude].ObservableList.Where(x => x.Selected).Select(d => d.Id)) },
					{ "geographic_groups_exclude", GetResultIds(criterions[FilterTypes.GeoGrpExclude].ObservableList.Where(x => x.Selected).Select(d => d.Id)) },
					//Типы Оплаты
					{ "payment_type_include", includePayTypes },
					{ "payment_type_exclude", excludePayTypes },
					//Промо-наборы
					{ "promo_sets_include", GetResultIds(criterions[FilterTypes.PromoSetInclude].ObservableList.Where(x => x.Selected).Select(d => d.Id)) },
					{ "promo_sets_exclude", GetResultIds(criterions[FilterTypes.PromoSetExclude].ObservableList.Where(x => x.Selected).Select(d => d.Id)) },

					{"creation_date", DateTime.Now},
					{"product_group_ids", GetResultIds(productGroupIds) }
				}
			};
		}

		protected void OnButtonCreateReportClicked(object sender, EventArgs e)
		{
			OnUpdate(true);
		}

		void OnUpdate(bool hide = false)
		{
			LoadReport?.Invoke(this, new LoadReportEventArgs(GetReportInfo(), hide));
		}

		GenericObservableList<SalesReportNode> treeNodes;

		protected void OnButtonNomTypeSelectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.NomenclatureTypeInclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.NomenclatureTypeInclude].SubcribeWithClearOld((string obj) => {
				ylabelNomType.Text = String.Format("Вкл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Включаемые категории номенклатуры";
		}

		protected void OnButtonNomenSelectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.NomenclatureInclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.NomenclatureInclude].SubcribeWithClearOld((string obj) => {
				ylabelNomen.Text = String.Format("Вкл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Включаемые номенклатуры";
		}

		protected void OnButtonNomTypeUnselectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.NomenclatureTypeExclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.NomenclatureTypeExclude].SubcribeWithClearOld((string obj) => {
				ylabelNomType.Text = String.Format("Искл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Исключаемые категории номенклатуры";
		}

		protected void OnButtonNomenUnselectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.NomenclatureExclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.NomenclatureExclude].SubcribeWithClearOld((string obj) => {
				ylabelNomen.Text = String.Format("Искл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Исключаемые номенклатуры";
		}

		protected void OnButtonClientSelectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.ClientInclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.ClientInclude].SubcribeWithClearOld((string obj) => {
				ylabelClient.Text = String.Format("Вкл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Включаемые номенклатуры";
		}

		protected void OnButtonClientUnselectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.ClientExclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.ClientExclude].SubcribeWithClearOld((string obj) => {
				ylabelClient.Text = String.Format("Искл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Исключаемые контрагенты";
		}

		protected void OnButtonOrgSelectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.OrganizationInclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.OrganizationInclude].SubcribeWithClearOld((string obj) => {
				ylabelOrg.Text = String.Format("Вкл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Включаемые номенклатуры";
		}

		protected void OnButtonOrgUnselectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.OrganizationExclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.OrganizationExclude].SubcribeWithClearOld((string obj) => {
				ylabelOrg.Text = String.Format("Искл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Исключаемые поставщики";
		}

		protected void OnButtonDiscountReasonSelectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.DiscountReasonInclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.DiscountReasonInclude].SubcribeWithClearOld((string obj) => {
				ylabelDiscountReason.Text = String.Format("Вкл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Включаемые основания скидок";
		}

		protected void OnButtonDiscountReasonUnselectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.DiscountReasonExclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.DiscountReasonExclude].SubcribeWithClearOld((string obj) => {
				ylabelDiscountReason.Text = String.Format("Искл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Исключаемые основания скидок";
		}

		protected void OnBtnOrderAuthorSelectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.OrderAuthorInclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.OrderAuthorInclude].SubcribeWithClearOld((string obj) => {
				yLblOrderAuthor.Text = String.Format("Вкл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Включаемые авторы заказа";
		}

		protected void OnBtnOrderAuthorDeselectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.OrderAuthorExclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.OrderAuthorExclude].SubcribeWithClearOld((string obj) => {
				yLblOrderAuthor.Text = String.Format("Искл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Исключаемые авторы заказа";
		}

		protected void OnBtnSubdivisionSelectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.SubdivisionInclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.SubdivisionInclude].SubcribeWithClearOld((string obj) => {
				yLblSubdivision.Text = String.Format("Вкл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Включаемые отделы";
		}

		protected void OnBtnSubdivisionDeselectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.SubdivisionExclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.SubdivisionExclude].SubcribeWithClearOld((string obj) => {
				yLblSubdivision.Text = String.Format("Искл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Исключаемые отделы";
		}

		protected void OnBtnGeoGroupsSelectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.GeoGrpInclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.GeoGrpInclude].SubcribeWithClearOld((string obj) => {
				ylblGeoGroups.Text = String.Format("Вкл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Включаемые части города";
		}

		protected void OnBtnGeoGroupsDeselectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.GeoGrpExclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.GeoGrpExclude].SubcribeWithClearOld((string obj) => {
				ylblGeoGroups.Text = String.Format("Искл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Исключаемые части города";
		}

		protected void OnBtnPaymentTypeSelectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.PaymentTypeInclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.PaymentTypeInclude].SubcribeWithClearOld((string obj) => {
				ylblPaymentType.Text = String.Format("Вкл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Включаемые типы оплаты";
		}

		protected void OnBtnPaymentTypeDeselectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.PaymentTypeExclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.PaymentTypeInclude].SubcribeWithClearOld((string obj) => {
				ylblPaymentType.Text = String.Format("Искл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Исключаемые типы оплаты";
		}

		protected void OnBtnPromoSetsSelectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.PromoSetInclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.PromoSetInclude].SubcribeWithClearOld((string obj) => {
				ylblPromoSet.Text = String.Format("Вкл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Включаемые промо-наборы";
		}

		protected void OnBtnPromoSetsDeselectClicked(object sender, EventArgs e)
		{
			treeNodes = criterions[FilterTypes.PromoSetExclude].ObservableList;
			ytreeviewSelectedList.ItemsDataSource = treeNodes;
			criterions[FilterTypes.PromoSetExclude].SubcribeWithClearOld((string obj) => {
				ylblPromoSet.Text = String.Format("Искл.: {0} елем.", obj);
			});
			labelTableTitle.Text = "Исключаемые промо-наборы";
		}


		protected void OnButtonSelectAllClicked(object sender, EventArgs e)
		{
			object source = ytreeviewSelectedList.ItemsDataSource;
			if(source is GenericObservableList<SalesReportNode>) {
				foreach(SalesReportNode item in (source as GenericObservableList<SalesReportNode>)) {
					item.Selected = true;
				}
			}
		}

		protected void OnButtonUnselectAllClicked(object sender, EventArgs e)
		{
			object source = ytreeviewSelectedList.ItemsDataSource;
			if(source is GenericObservableList<SalesReportNode>) {
				foreach(SalesReportNode item in (source as GenericObservableList<SalesReportNode>)) {
					item.Selected = false;
				}
			}
		}

		protected void OnSearchEntityInSelectedListTextChanged(object sender, EventArgs e)
		{
			if(treeNodes != null) {
				if(searchEntityInSelectedList.Text.Length > 0)
					ytreeviewSelectedList.ItemsDataSource = new GenericObservableList<SalesReportNode>(
						treeNodes
						.Where(
							n => n.Name
							.ToLower()
							.Contains(
								searchEntityInSelectedList
								.Text
								.ToLower()
							)
						)
						.ToList()
					);
				else
					ytreeviewSelectedList.ItemsDataSource = treeNodes;
			} else {
				searchEntityInSelectedList.Text = String.Empty;
			}
		}

		#region SalesReportNode

		public class SelectableProductGroupNode : PropertyChangedBase
		{
			private bool selected;
			public bool Selected {
				get { return selected; }
				set {
					if(SetField(ref selected, value, () => Selected)) {
						if(Children != null && Children.Any())
							Children.ForEach(x => x.Selected = value);
						if(!value && Parent != null)
							UnselectParentOnly(Parent);
					}
				}
			}

			public int Id { get; set; }
			public string Name { get; set; }
			public SelectableProductGroupNode Parent { get; set; }
			public GenericObservableList<SelectableProductGroupNode> Children { get; set; }

			public void UnselectParentOnly(SelectableProductGroupNode parentNode)
			{
				parentNode.selected = false;
				OnPropertyChanged(() => parentNode.Selected);
				if(parentNode.Parent != null)
					parentNode.UnselectParentOnly(parentNode.Parent);
			}

			//Не возвращает parent ноды
			public static IEnumerable<SelectableProductGroupNode> GetAllNodes(GenericObservableList<SelectableProductGroupNode> list)
			{
				List<SelectableProductGroupNode> result = new List<SelectableProductGroupNode>();

				foreach(SelectableProductGroupNode item in list) {

					result.Add(item);
					if(item.Children != null && item.Children.Any())
						result.AddRange(GetAllNodes(item.Children));
				}
				return result;
			}
		}

		#endregion

	}
}