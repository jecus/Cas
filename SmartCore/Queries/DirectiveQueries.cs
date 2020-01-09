/*
* Class code generate programm
* Date: 12.07.2010
* Database: CasDemo
* Table: Directive
*/

using System;
using System.Collections.Generic;
    // DataRow, DataTable, DataSet
    // SqlParameter
using System.Linq;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Filters;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.WorkPackage;


namespace SmartCore.Queries
{
    /// <summary>
    /// Содержит запросы для получения директив
    /// </summary>
	public static class DirectiveQueries
	{

		#region public static List<DbQuery> GetSelectQuery(Aircraft aircraft, DirectiveType directiveType, IEnumerable<IQueryFilter> filters = null, bool loadChild = false, bool getDeleted = false)

		/// <summary>
		/// Возвращает строку запроса на получение всех облуживания воздушного судна
		/// </summary>
		/// <param name="aircraftId">ВС, диретивы которого необходимо получить</param>
		/// <param name="directiveType">Тип загружаемых задач</param>
		/// <param name="filters">Фильтры для Maintenance Directives</param>
		/// <param name="loadChild">Загружать дочерние элементы</param>
		/// <param name="getDeleted">Загружать недействительные записи</param>
		/// <returns></returns>
		public static List<DbQuery> GetAircraftDirectivesSelectQuery(int aircraftId, 
																	 DirectiveType directiveType, 
																	 ICommonFilter[] filters = null, 
																	 bool loadChild = false, 
																	 bool getDeleted = false)
        {
            var componentIn = ComponentQueries.GetSelectQueryPrimaryColumnOnly(aircraftId);
            var allFilters = new List<ICommonFilter> { new CommonFilter<string>(Directive.ParentBaseComponentProperty, FilterType.In, new[] { componentIn }) };
            if (filters != null && filters.Length > 0)
                allFilters.AddRange(filters);
            allFilters.Add(GetWhereStatement(directiveType));
            var qrs = BaseQueries.GetSelectQueryWithWhereAll<Directive>(allFilters.ToArray(), loadChild, getDeleted);
            return qrs;

        }
		#endregion

		#region public static List<DbQuery> GetSelectIdsQueryForWp(int workPackageId, DirectiveType directiveType, ICommonFilter[] filters = null, bool loadChild = false, bool getDeleted = false)
		/// <summary>
		/// Возвращает строку запроса на получение всех облуживания рабочего пакета
		/// </summary>
		/// <param name="workPackageId"></param>
		/// <param name="directiveType"></param>
		/// <param name="filters"></param>
		/// <param name="loadChild"></param>
		/// <returns></returns>
		public static List<DbQuery> GetSelectQueryForWp(int workPackageId, DirectiveType directiveType,
														ICommonFilter[] filters = null,
														bool loadChild = false)
	    {
		    var directiveIn = BaseQueries.GetSelectQueryColumnOnly<WorkPackageRecord>(WorkPackageRecord.DirectiveIdProperty,
			    new ICommonFilter[]
			    {
				    new CommonFilter<int>(WorkPackageRecord.WorkPakageIdProperty, workPackageId),
					new CommonFilter<int>(WorkPackageRecord.WorkPackageItemTypeProperty, SmartCoreType.Directive.ItemId)
				});

		    List<ICommonFilter> allFilters =
			    new List<ICommonFilter>
			    {
				    new CommonFilter<string>(BaseEntityObject.ItemIdProperty, FilterType.In, new[] {directiveIn})
			    };
		    if (filters != null && filters.Length > 0)
			    allFilters.AddRange(filters);
		    allFilters.Add(GetWhereStatement(directiveType));

		    return BaseQueries.GetSelectQueryWithWhereAll<Directive>(allFilters.ToArray(), loadChild, true);
	    }

	    #endregion


		#region public static List<DbQuery> GetSelectQuery(AircraftFlight aircraftFlight, DirectiveType directiveType, IEnumerable<IQueryFilter> filters = null, bool loadChild = false, bool getDeleted = false)

		/// <summary>
		/// Возвращает строку запроса на получение всех облуживания воздушного судна
		/// </summary>
		/// <param name="aircraftFlight">полет ВС, диретивы которого необходимо получить</param>
		/// <param name="directiveType">Тип загружаемых задач</param>
		/// <param name="filters">Фильтры для Maintenance Directives</param>
		/// <param name="loadChild">Загружать дочерние элементы</param>
		/// <param name="getDeleted">Загружать недействительные записи</param>
		/// <returns></returns>
		public static List<DbQuery> GetSelectQuery(AircraftFlight aircraftFlight, 
                                                   DirectiveType directiveType, 
                                                   ICommonFilter[] filters = null, 
                                                   bool loadChild = false, 
                                                   bool getDeleted = false)
        {
            List<ICommonFilter> allFilters =
                new List<ICommonFilter> { new CommonFilter<int>(Directive.AircraftFlightIdProperty, aircraftFlight.ItemId) };
            if (filters != null && filters.Length > 0)
                allFilters.AddRange(filters);
            allFilters.Add(GetWhereStatement(directiveType));
            List<DbQuery> qrs = BaseQueries.GetSelectQueryWithWhereAll<Directive>(allFilters.ToArray(), loadChild, getDeleted);
            return qrs;

        }
		#endregion

		public static List<DbQuery> GetSelectQuery(DirectiveType directiveType, string text,
			string paragraph,
			bool loadChild = false,
			bool getDeleted = false)
		{
			List<ICommonFilter> allFilters = new List<ICommonFilter> ();
			allFilters.Add(GetWhereStatementForAll(directiveType, text, paragraph));
			List<DbQuery> qrs = BaseQueries.GetSelectQueryWithWhereAll<Directive>(allFilters.ToArray(), loadChild, getDeleted);
			return qrs;

		}

		#region public static List<DbQuery> GetSelectQuery(BaseComponent parentBaseComponent, DirectiveType directiveType, IEnumerable<IQueryFilter> filters = null, bool loadChild = false, bool getDeleted = false)

		/// <summary>
		/// Возвращает строку запроса на получение всех директив базового агрегата
		/// </summary>
		/// <param name="parentBaseComponent">Базовый агрегат, диретивы которого необходимо получить</param>
		/// <param name="directiveType">Тип загружаемых задач</param>
		/// <param name="filters">Фильтры для Maintenance Directives</param>
		/// <param name="loadChild">Загружать дочерние элементы</param>
		/// <param name="getDeleted">Загружать недействительные записи</param>
		/// <returns></returns>
		public static List<DbQuery> GetSelectQuery(BaseComponent parentBaseComponent,
                                                   DirectiveType directiveType,
                                                   ICommonFilter[] filters = null,
                                                   bool loadChild = false,
                                                   bool getDeleted = false)
        {
            List<ICommonFilter> allFilters =
                new List<ICommonFilter> { new CommonFilter<int>(Directive.ParentBaseComponentProperty, parentBaseComponent.ItemId) };
            if (filters != null && filters.Length > 0)
                allFilters.AddRange(filters);
            allFilters.Add(GetWhereStatement(directiveType));
            List<DbQuery> qrs = BaseQueries.GetSelectQueryWithWhereAll<Directive>(allFilters.ToArray(), loadChild, getDeleted);
            return qrs;

        }
		#endregion

		#region public static List<DbQuery> GetAircraftDirectivesSelectQuery(int itemId, DirectiveType directiveType, IEnumerable<IQueryFilter> filters = null, bool loadChild = false, bool getDeleted = false)

		/// <summary>
		/// Возвращает строку запроса на получение диретивы по заданному Id
		/// </summary>
		/// <param name="itemId">Id необходимой диретивы</param>
		/// <param name="directiveType">Тип загружаемых задач</param>
		/// <param name="filters">Фильтры для Maintenance Directives</param>
		/// <param name="loadChild">Загружать дочерние элементы</param>
		/// <param name="getDeleted">Загружать недействительные записи</param>
		/// <returns></returns>
		public static List<DbQuery> GetSelectQueryById(int itemId,
													   DirectiveType directiveType,
													   ICommonFilter[] filters = null,
													   bool loadChild = false,
													   bool getDeleted = false)
        {
            List<ICommonFilter> allFilters =
                new List<ICommonFilter> { new CommonFilter<int>(BaseEntityObject.ItemIdProperty, itemId) };
            if (filters != null && filters.Any())
                allFilters.AddRange(filters);
            allFilters.Add(GetWhereStatement(directiveType));
            List<DbQuery> qrs = BaseQueries.GetSelectQueryWithWhereAll<Directive>(allFilters.ToArray(), loadChild, getDeleted);
            return qrs;

        }
		#endregion


		#region public static List<DbQuery> GetDamageItemSelectQuery(Aircraft aircraft, IEnumerable<IQueryFilter> filters = null, bool loadChild = false, bool getDeleted = false)

		/// <summary>
		/// Возвращает строку запроса на получение всех повреждений воздушного судна
		/// </summary>
		/// <param name="aircraftId">Id ВС, диретивы которого необходимо получить</param>
		/// <param name="filters">Фильтры для Maintenance Directives</param>
		/// <param name="loadChild">Загружать дочерние элементы</param>
		/// <param name="getDeleted">Загружать недействительные записи</param>
		/// <returns></returns>
		public static List<DbQuery> GetAircraftDamageItemSelectQuery(int aircraftId,
                                                             ICommonFilter[] filters = null,
                                                             bool loadChild = false,
                                                             bool getDeleted = false)
        {
            var componentIn = ComponentQueries.GetSelectQueryPrimaryColumnOnly(aircraftId);
            var allFilters = new List<ICommonFilter> { new CommonFilter<string>(Directive.ParentBaseComponentProperty, FilterType.In, new[] { componentIn }) };
            if (filters != null && filters.Any())
                allFilters.AddRange(filters);
            var qrs = BaseQueries.GetSelectQueryWithWhereAll<DamageItem>(allFilters.ToArray(), loadChild, getDeleted);
            return qrs;

        }
		#endregion

		#region public static List<DbQuery> GetDamageItemSelectQuery(BaseComponent parentBaseComponent, IEnumerable<IQueryFilter> filters = null, bool loadChild = false, bool getDeleted = false)

		/// <summary>
		/// Возвращает строку запроса на получение всех повреждений базового агрегата
		/// </summary>
		/// <param name="parentBaseComponent">Базовый агрегат, диретивы которого необходимо получить</param>
		/// <param name="filters">Фильтры для Maintenance Directives</param>
		/// <param name="loadChild">Загружать дочерние элементы</param>
		/// <param name="getDeleted">Загружать недействительные записи</param>
		/// <returns></returns>
		public static List<DbQuery> GetDamageItemSelectQuery(BaseComponent parentBaseComponent,
                                                             ICommonFilter[] filters = null,
                                                             bool loadChild = false,
                                                             bool getDeleted = false)
        {
            List<ICommonFilter> allFilters =
                new List<ICommonFilter> { new CommonFilter<int>(Directive.ParentBaseComponentProperty, parentBaseComponent.ItemId) };
            if (filters != null && filters.Any())
                allFilters.AddRange(filters);

            List<DbQuery> qrs = BaseQueries.GetSelectQueryWithWhereAll<DamageItem>(allFilters.ToArray(), loadChild, getDeleted);
            return qrs;

        }
        #endregion


        #region public static ICommonFilter GetWhereStatement(DirectiveType directiveType)
        /// <summary>
        /// Возвращает условие того деталь принадлежит базовому агрегату
        /// </summary>
        /// <param name="directiveType"></param>
        /// <returns></returns>
        public static ICommonFilter GetWhereStatement(DirectiveType directiveType)
        {
            if (directiveType == null)
                throw new ArgumentNullException("directiveType", "must be not null");
            if (DirectiveType.GetDirectiveTypeById(directiveType.ItemId) == DirectiveType.Unknown)
                throw new ArgumentException("unknown directive type", "directiveType");

            ICommonFilter state;

            if (directiveType == DirectiveType.All)
            {
                DirectiveType[] s =
                { DirectiveType.AirworthenessDirectives,
                    DirectiveType.DamagesRequiring,
                    DirectiveType.EngineeringOrders,
                    DirectiveType.OutOfPhase,
                    DirectiveType.SB };

                state = new CommonFilter<DirectiveType>(Directive.DirectiveTypeProperty, FilterType.In, s);
            }
            else if (directiveType == DirectiveType.EngineeringOrders)
            {
                state = 
                    new CommonFilter<string>($@" (directives.EngineeringOrders <> '' 
                                      or directives.EngineeringOrderFileID > 0 
                                      or directives.DirectiveType = {directiveType.ItemId})");
            }
            else if (directiveType == DirectiveType.ModificationStatus)
            {
                state = new CommonFilter<DirectiveWorkType>(Directive.WorkTypeProperty, DirectiveWorkType.Modification);
            }
            else if (directiveType == DirectiveType.SB)
            {
				//state =
				//    new CommonFilter<string>(string.Format(@"((directives.ServiceBulletinNo <> '' 
				//                                           or directives.ServiceBulletinFileID > 0 )
				//                                           and directives.DirectiveType = {0})", directiveType.ItemId));
				//TODO: Было так но потом захотели sb в ad перемещать
				state = new CommonFilter<string>($@"(directives.ServiceBulletinNo <> '' 
				                                           or directives.ServiceBulletinFileID > 0 
				                                           or directives.DirectiveType = {directiveType.ItemId})");
			}
			else
            {
				//state = new CommonFilter<DirectiveType>(Directive.DirectiveTypeProperty, directiveType);
				state =
					new CommonFilter<string>($@"(directives.Title != 'N/A'
                                                           and directives.DirectiveType = {directiveType.ItemId})");
			}
            return state;
        }

		#endregion

		public static ICommonFilter GetWhereStatementForAll(DirectiveType directiveType, string text, string paragraph)
		{
			if (directiveType == null)
				throw new ArgumentNullException("directiveType", "must be not null");
			if (DirectiveType.GetDirectiveTypeById(directiveType.ItemId) == DirectiveType.Unknown)
				throw new ArgumentException("unknown directive type", "directiveType");

			ICommonFilter state;

				state =
					new CommonFilter<string>(string.Format($@"(directives.Title != 'N/A' and directives.Title like '%{text}%' and directives.Paragraph like '%{paragraph}%'
                                                           and directives.DirectiveType = {directiveType.ItemId})"));
				return state;
		}

	} 
}
  
  
  
  
  
  
