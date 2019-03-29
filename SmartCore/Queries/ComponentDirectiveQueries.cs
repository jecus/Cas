/*
* Class code generate programm
* Date: 12.07.2010
* Database: CasDemo
* Table: DetailDirective
*/

using System.Collections.Generic;
    // DataRow, DataTable, DataSet
    // SqlParameter
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;


namespace SmartCore.Queries
{

	public static class ComponentDirectiveQueries
    {
		#region public static List<DbQuery> GetAircraftDirectivesSelectQuery(Aircraft aircraft, ICommonFilter[] filters = null, bool loadChild = false, bool getDeleted = false)

		/// <summary>
		/// Возвращает строку запроса на получение всех облуживания воздушного судна
		/// </summary>
		/// <param name="aircraftId">Id ВС, диретивы которого необходимо получить</param>
		/// <param name="filters">Фильтры для Maintenance Directives</param>
		/// <param name="loadChild">Загружать дочерние элементы</param>
		/// <param name="getDeleted">Загружать недействительные записи</param>
		/// <returns></returns>
		public static List<DbQuery> GetAircraftDirectivesSelectQuery(int aircraftId, ICommonFilter[] filters = null, bool loadChild = false, bool getDeleted = false)
        {
            //string detailIn = 
            //    BaseQueries.GetSelectQueryColumnOnly<Detail>(BaseEntityObject.ItemIdProperty, new[] {DetailQueries.GetWhereStatement(aircraft)});
            var componentIn = string.Format(@"(select ItemId 
                                               from dbo.Components 
                                               where dbo.Components.IsDeleted = 0 and {0})",
                                              ComponentQueries.GetWhereStatement(aircraftId).Values[0]);
            var allFilters = new List<ICommonFilter> { new CommonFilter<string>(ComponentDirective.ComponentIdProperty, FilterType.In, new[] { componentIn }) };
            if (filters != null && filters.Length > 0)
                allFilters.AddRange(filters);
            return BaseQueries.GetSelectQueryWithWhereAll<ComponentDirective>(allFilters.ToArray(), loadChild, getDeleted);

        }
		#endregion

		#region public static List<DbQuery> GetSelectQueryForWp(int workPackageId, ICommonFilter[] filters = null, bool loadChild = false, bool getDeleted = false)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="workPackageId"></param>
		/// <param name="filters"></param>
		/// <param name="loadChild"></param>
		/// <param name="getDeleted"></param>
		/// <returns></returns>
		public static List<DbQuery> GetSelectQueryForWp(int workPackageId, ICommonFilter[] filters = null, bool loadChild = false, bool getDeleted = false)
		{
			var directiveIn = BaseQueries.GetSelectQueryColumnOnly<WorkPackageRecord>(WorkPackageRecord.DirectiveIdProperty,
				new ICommonFilter[]
				{
					new CommonFilter<int>(WorkPackageRecord.WorkPakageIdProperty, workPackageId),
					new CommonFilter<int>(WorkPackageRecord.WorkPackageItemTypeProperty, SmartCoreType.ComponentDirective.ItemId)
				});

			List<ICommonFilter> allFilters =
				new List<ICommonFilter>
				{
					new CommonFilter<string>(BaseEntityObject.ItemIdProperty, FilterType.In, new[] {directiveIn})
				};
			if (filters != null && filters.Length > 0)
				allFilters.AddRange(filters);
			return BaseQueries.GetSelectQueryWithWhereAll<ComponentDirective>(allFilters.ToArray(), loadChild, getDeleted);
		}

		#endregion

		#region public static List<DbQuery> GetAircraftBaseComponentDirectivesSelectQuery(int aircraftId, ICommonFilter[] filters = null, bool loadChild = false, bool getDeleted = false)

		/// <summary>
		/// Возвращает строку запроса на получение всех облуживания воздушного судна
		/// </summary>
		/// <param name="aircraftId">Id ВС, диретивы которого необходимо получить</param>
		/// <param name="filters">Фильтры для Maintenance Directives</param>
		/// <param name="loadChild">Загружать дочерние элементы</param>
		/// <param name="getDeleted">Загружать недействительные записи</param>
		/// <returns></returns>
		public static List<DbQuery> GetAircraftBaseComponentDirectivesSelectQuery(int aircraftId, ICommonFilter[] filters = null, bool loadChild = false, bool getDeleted = false)
		{
			var detailIn = $@"(select ItemId 
                               from dbo.Components 
                               where dbo.Components.IsDeleted = 0 and {BaseComponentQueries.GetWhereStatement(aircraftId).Values[0]})";
			List<ICommonFilter> allFilters =
				new List<ICommonFilter> { new CommonFilter<string>(ComponentDirective.ComponentIdProperty, FilterType.In, new[] { detailIn }) };
			if (filters != null && filters.Length > 0)
				allFilters.AddRange(filters);
			return BaseQueries.GetSelectQueryWithWhereAll<ComponentDirective>(allFilters.ToArray(), loadChild, getDeleted);

		}
		#endregion

	}
}