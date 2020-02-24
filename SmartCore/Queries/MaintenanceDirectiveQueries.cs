using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;


namespace SmartCore.Queries
{

    /// <summary>
    /// Содержит запросы для получения директив
    /// </summary>
	public static class MaintenanceDirectiveQueries
    {
		#region public static List<DbQuery> GetAircraftDirectivesSelectQuery(int aircraftId, IEnumerable<ICommonFilter> filters = null, bool loadChild = false, bool getDeleted = false)

		/// <summary>
		/// Возвращает строку запроса на получение всех облуживания воздушного судна
		/// </summary>
		/// <param name="aircraftId">Id ВС, диретивы которого необходимо получить</param>
		/// <param name="filters">Фильтры для Maintenance Directives</param>
		/// <param name="loadChild">Загружать дочерние элементы</param>
		/// <param name="getDeleted">Загружать недействительные записи</param>
		/// <returns></returns>
		public static List<DbQuery> GetAircraftDirectivesSelectQuery(int aircraftId, IEnumerable<ICommonFilter> filters = null, bool loadChild = false, bool getDeleted = false)
        {
            string componentIn = $@"(select ItemId 
                                               from dbo.Components 
                                               where dbo.Components.IsDeleted = 0 and dbo.Components.IsBaseComponent = 1 and
	                                                (Select top 1 DestinationObjectId from dbo.TransferRecords Where 
					                                 ParentType = {SmartCoreType.BaseComponent.ItemId}
                                                     and DestinationObjectType = {SmartCoreType.Aircraft.ItemId} 
				                                     and ParentId = dbo.Components.ItemId 
					                                 and IsDeleted = 0) = {aircraftId} )";
            List<ICommonFilter> allFilters = 
                new List<ICommonFilter>{ new CommonFilter<string>(MaintenanceDirective.ParentBaseComponentProperty, FilterType.In, new[] {componentIn})};
            if(filters != null && filters.Count() > 0)
                allFilters.AddRange(filters);
            return BaseQueries.GetSelectQueryWithWhereAll<MaintenanceDirective>(allFilters.ToArray(), loadChild, getDeleted);

        }
		#endregion

		#region public static List<DbQuery> GetSelectQueryForWp(int workPackageId, IEnumerable<ICommonFilter> filters = null, bool loadChild = false, bool getDeleted = false)
		/// <summary>
		/// Возвращает строку запроса на получение всех облуживаний рабочего пакета
		/// </summary>
		/// <param name="workPackageId"></param>
		/// <param name="filters"></param>
		/// <param name="loadChild"></param>
		/// <param name="getDeleted"></param>
		/// <returns></returns>
		public static List<DbQuery> GetSelectQueryForWp(int workPackageId, IEnumerable<ICommonFilter> filters = null, bool loadChild = false, bool getDeleted = false)
	    {
		    var directiveIn = BaseQueries.GetSelectQueryColumnOnly<WorkPackageRecord>(WorkPackageRecord.DirectiveIdProperty,
			    new ICommonFilter[]
			    {
				    new CommonFilter<int>(WorkPackageRecord.WorkPakageIdProperty, workPackageId),
				    new CommonFilter<int>(WorkPackageRecord.WorkPackageItemTypeProperty, SmartCoreType.MaintenanceDirective.ItemId)
			    });

		    List<ICommonFilter> allFilters = new List<ICommonFilter>
		    {
			    new CommonFilter<string>(BaseEntityObject.ItemIdProperty, FilterType.In, new[] {directiveIn})
		    };
		    if (filters != null && filters.Count() > 0)
			    allFilters.AddRange(filters);
		    return BaseQueries.GetSelectQueryWithWhereAll<MaintenanceDirective>(allFilters.ToArray(), loadChild, getDeleted);
	    }

		#endregion

		#region public static List<DbQuery> GetSelectQuery(BaseComponent baseComponent, IEnumerable<IQueryFilter> filters = null, bool loadChild = false, bool getDeleted = false)

		/// <summary>
		/// Возвращает строку запроса на получение всех облуживания воздушного судна
		/// </summary>
		/// <param name="baseComponent">Базоввй агрегат, диретивы которого необходимо получить</param>
		/// <param name="filters">Фильтры для Maintenance Directives</param>
		/// <param name="loadChild">Загружать дочерние элементы</param>
		/// <param name="getDeleted">Загружать недействительные записи</param>
		/// <returns></returns>
		public static List<DbQuery> GetSelectQuery(BaseComponent baseComponent, IEnumerable<ICommonFilter> filters = null, bool loadChild = false, bool getDeleted = false)
        {
            List<ICommonFilter> allFilters = 
                new List<ICommonFilter> { new CommonFilter<int>(MaintenanceDirective.ParentBaseComponentProperty, baseComponent.ItemId) };
            if (filters != null && filters.Count() > 0)
                allFilters.AddRange(filters);

            return BaseQueries.GetSelectQueryWithWhereAll<MaintenanceDirective>(allFilters.ToArray(), loadChild, getDeleted);

        }
		#endregion

		public static List<DbQuery> GetSelectQuery(string text,
			bool loadChild = false,
			bool getDeleted = false)
		{
			List<ICommonFilter> allFilters = new List<ICommonFilter>();
			allFilters.Add(GetWhereStatementForAll(text));
			List<DbQuery> qrs = BaseQueries.GetSelectQueryWithWhereAll<MaintenanceDirective>(allFilters.ToArray(), loadChild, getDeleted);
			return qrs;

		}

		public static ICommonFilter GetWhereStatementForAll(string text)
		{
			ICommonFilter state = new CommonFilter<string>($"(MaintenanceDirectives.TaskNumberCheck like '%{text}%' or MaintenanceDirectives.TaskCardNumber like '%{text}%')");
			return state;
		}

	}
}
  
  
  
  
  
  
