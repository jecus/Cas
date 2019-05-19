using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Filters;
using SmartCore.Management;

namespace SmartCore.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public static class DeferredItemQueries
    {

		/*
         * DefferedItems содержится в таблице dbo.Directives и его DirectiveTypeID=5
         */

		#region public static List<DbQuery> GetSelectQuery(Aircraft aircraft, IEnumerable<IQueryFilter> filters = null, bool loadChild = false, bool getDeleted = false)

		/// <summary>
		/// Возвращает строку запроса на получение всех облуживания воздушного судна
		/// </summary>
		/// <param name="aircraftId">ВС, диретивы которого необходимо получить</param>
		/// <param name="filters">Фильтры для Maintenance Directives</param>
		/// <param name="loadChild">Загружать дочерние элементы</param>
		/// <param name="getDeleted">Загружать недействительные записи</param>
		/// <returns></returns>
		public static List<DbQuery> GetSelectQuery(int aircraftId,
                                                   IEnumerable<ICommonFilter> filters = null,
                                                   bool loadChild = false,
                                                   bool getDeleted = false)
        {
            var componentIn = ComponentQueries.GetSelectQueryPrimaryColumnOnly(aircraftId);
            var allFilters = new List<ICommonFilter> { new CommonFilter<string>(Directive.ParentBaseComponentProperty, FilterType.In, new[] { componentIn }) };
            if (filters != null && filters.Any())
                allFilters.AddRange(filters);
            var qrs = BaseQueries.GetSelectQueryWithWhereAll<DeferredItem>(allFilters.ToArray(), loadChild, getDeleted);
            return qrs;

        }
        #endregion

        #region public static List<DbQuery> GetSelectQuery(AircraftFlight aircraftFlight, IEnumerable<IQueryFilter> filters = null, bool loadChild = false, bool getDeleted = false)

        /// <summary>
        /// Возвращает строку запроса на получение всех облуживания воздушного судна
        /// </summary>
        /// <param name="aircraftFlight">полет ВС, диретивы которого необходимо получить</param>
        /// <param name="filters">Фильтры для Maintenance Directives</param>
        /// <param name="loadChild">Загружать дочерние элементы</param>
        /// <param name="getDeleted">Загружать недействительные записи</param>
        /// <returns></returns>
        public static List<DbQuery> GetSelectQuery(AircraftFlight aircraftFlight,
                                                   IEnumerable<ICommonFilter> filters = null,
                                                   bool loadChild = false,
                                                   bool getDeleted = false)
        {
            List<ICommonFilter> allFilters =
                new List<ICommonFilter> { new CommonFilter<int>(Directive.AircraftFlightIdProperty, aircraftFlight.ItemId) };
            if (filters != null && filters.Count() > 0)
                allFilters.AddRange(filters);
            List<DbQuery> qrs = BaseQueries.GetSelectQueryWithWhereAll<DeferredItem>(allFilters.ToArray(), loadChild, getDeleted);
            return qrs;

        }
        #endregion

        #region public static List<DbQuery> GetSelectQuery(BaseDetail parentBaseDetail, IEnumerable<IQueryFilter> filters = null, bool loadChild = false, bool getDeleted = false)

        /// <summary>
        /// Возвращает строку запроса на получение всех директив базового агрегата
        /// </summary>
        /// <param name="parentBaseComponentазовый агрегат, диретивы которого необходимо получить</param>
        /// <param name="filters">Фильтры для Maintenance Directives</param>
        /// <param name="loadChild">Загружать дочерние элементы</param>
        /// <param name="getDeleted">Загружать недействительные записи</param>
        /// <returns></returns>
        public static List<DbQuery> GetSelectQuery(BaseComponent parentBaseComponent,
                                                   IEnumerable<ICommonFilter> filters = null,
                                                   bool loadChild = false,
                                                   bool getDeleted = false)
        {
            List<ICommonFilter> allFilters =
                new List<ICommonFilter> { new CommonFilter<int>(Directive.ParentBaseComponentProperty, parentBaseComponent.ItemId) };
            if (filters != null && filters.Count() > 0)
                allFilters.AddRange(filters);

            List<DbQuery> qrs = BaseQueries.GetSelectQueryWithWhereAll<DeferredItem>(allFilters.ToArray(), loadChild, getDeleted);
            return qrs;

        }
		#endregion

		#region public static List<DbQuery> GetLastSelectQuery(Aircraft aircraft, IEnumerable<IQueryFilter> filters = null, bool loadChild = false, bool getDeleted = false)

		/// <summary>
		/// Возвращает строку запроса на получение всех облуживания воздушного судна
		/// </summary>
		/// <param name="aircraftId">ВС, диретивы которого необходимо получить</param>
		/// <param name="aircraftFlight"></param>
		/// <param name="filters">Фильтры для Maintenance Directives</param>
		/// <param name="loadChild">Загружать дочерние элементы</param>
		/// <param name="getDeleted">Загружать недействительные записи</param>
		/// <returns></returns>
		public static List<DbQuery> GetLastSelectQuery(int aircraftId,
                                                       AircraftFlight aircraftFlight,
                                                       IEnumerable<ICommonFilter> filters = null,
                                                       bool loadChild = false,
                                                       bool getDeleted = false)
        {
            if (aircraftFlight == null || aircraftFlight.ItemId < 0)
                return GetSelectQuery(aircraftId, filters, loadChild, getDeleted);

            string s = string.Format(@"-- не имеющие статус Closed
                                       directives.IsClosed <> 1
                                       or
                                       -- не имеющие записей о выполнении
                                       directives.ItemId not in (Select DR.ParentId
                                                                 from dbo.DirectivesRecords DR
                                                                 where DR.IsDeleted = 0
                                                                 and DR.ParentTypeId = {0})
                                       or
                                       -- дата последнего выполения которых >= дате текущего полета при наличии статуса Closed
                                           (    directives.IsClosed = 1
                                            and directives.ItemId in (Select top 1 DR.ParentId
                                                                        from dbo.DirectivesRecords DR
                                                                        where DR.IsDeleted = 0
                                                                        and DR.ParentId = directives.ItemId
                                                                        and DR.ParentTypeId = {0} 
                                                                        and DR.RecordDate >= convert(datetime, '{1}', 104)
                                                                        Order by DR.RecordDate desc))",
                          SmartCoreType.Directive.ItemId, DbTypes.DbObject(aircraftFlight.FlightDate.Date));

            List<ICommonFilter> allFilters = new List<ICommonFilter> 
                { 
                    new CommonFilter<int> (Directive.AircraftFlightIdProperty, FilterType.NotEqual, new[] {0}) , 
                    new CommonFilter<int> (Directive.AircraftFlightIdProperty, FilterType.NotEqual, new[] {aircraftFlight.ItemId}),
                    new CommonFilter<string> (s) 
                };
            if (filters != null && filters.Count() > 0)
                allFilters.AddRange(filters);
            List<DbQuery> qrs = GetSelectQuery(aircraftId, allFilters, loadChild, getDeleted);

            return qrs;

        }
        #endregion

    }
}
