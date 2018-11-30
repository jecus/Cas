using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Calculations;
using SmartCore.Calculations.PerformanceCalculator;
using SmartCore.Component;
using SmartCore.Directives;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Store;
using SmartCore.Filters;
using SmartCore.Maintenance;

namespace SmartCore.Analyst
{
    /// <summary>
    /// Объект содержит методы для прогнозирования
    /// </summary>
    public class AnalystCore : IAnalystCore
    {
	    private readonly IComponentCore _componentCore;
	    private readonly IMaintenanceCore _maintenanceCore;
	    private readonly IDirectiveCore _directiveCore;
	    private readonly IMaintenanceCheckCalculator _maintenanceCheckCalculator;
	    private readonly IPerformanceCalculator _performanceCalculator;

	    public AnalystCore(IComponentCore componentCore,
						   IMaintenanceCore maintenanceCore,
						   IDirectiveCore directiveCore, IMaintenanceCheckCalculator maintenanceCheckCalculator,
						   IPerformanceCalculator performanceCalculator)
        {
			_componentCore = componentCore;
		    _maintenanceCore = maintenanceCore;
		    _directiveCore = directiveCore;
		    _maintenanceCheckCalculator = maintenanceCheckCalculator;
		    _performanceCalculator = performanceCalculator;
        }

		/*
         * Прогнозирование для воздушного судна и всего флота в целом
         */

		#region public Forecast GetForecastByAverageUtilization(Store store, ForecastData forecastData)
		/// <summary>
		/// Строит прогноз по выполнению работ воздушного судна 
		/// </summary>
		/// <param name="store"></param>
		/// <param name="forecastData"></param>
		/// <returns></returns>
		public Forecast GetForecastByAverageUtilization(Store store, ForecastData forecastData)
        {
            // Создаем объект отчета
            var forecast = new Forecast(store, forecastData.ForecastDate);

            // Пробегаем по всем отчетам

            // базовые агрегаты и работы по ним
            BaseComponentCollection baseComponents;
            ICommonCollection<ComponentDirective> baseComponentDirectives;

            GetBaseComponentsAndComponentDirectives(store, forecastData, out baseComponents, out baseComponentDirectives);
            forecast.BaseComponents = baseComponents;
            forecast.ComponentDirectives.AddRange(baseComponentDirectives.ToArray());

            // агрегаты воздушного судна и работы по ним
            ComponentCollection components;
            ICommonCollection<ComponentDirective> componentDirectives;
            GetComponentsAndComponentDirectives(store, forecastData, out components, out componentDirectives);
            forecast.Components = components;
            forecast.ComponentDirectives.AddRange(componentDirectives.ToArray());
            // Возвращаем результат
            return forecast;
        }
        #endregion

        /*
         * Прогнозирование отдельных отчетов
         */
        #region public void GetForecast<T>(IEnumerable<T> initialArray, ICommonCollection<T> resultArray, Forecast forecast) where T : IDirective
        public void GetForecast<T>(IEnumerable<T> initialArray, ICommonCollection resultArray, Forecast forecast) where T : BaseEntityObject, IDirective
        {
            if (forecast == null) 
                return;

            ForecastData frameForecastData = forecast.GetForecastDataFrame() ?? forecast.ForecastDataForNonLifelenght;
            if (frameForecastData == null) return;
            if (resultArray == null)
                resultArray = new CommonCollection<T>();

            foreach (T directive in initialArray)
            {
                directive.NextPerformances.Clear();

				_performanceCalculator.GetNextPerformance(directive, frameForecastData);
                if ((directive.NextPerformanceDate != null &&
                     directive.NextPerformanceDate.Value.Date <= frameForecastData.ForecastDate.Date) ||
                    (directive.Condition == ConditionState.Overdue || directive.Condition == ConditionState.Notify && frameForecastData.IncludeNotifyes) ||
                    (forecast.ForecastDatas[0].IncludePercents && directive.Percents != null && directive.Percents <= frameForecastData.Percents))
                {

					directive.NextPerformances.RemoveAll(np => np.PerformanceDate == null
														    || np.PerformanceDate.Value.Date > frameForecastData.ForecastDate.Date
													        || np.PerformanceDate.Value.Date < frameForecastData.LowerLimit.Date);
					if (directive.NextPerformances.Count == 0)
                        continue;
                    AdditionalFiltration(frameForecastData, directive);
                    if (directive.NextPerformances.Count == 0)
                        continue;
                    resultArray.Add(directive);
                }
            }
        }
		#endregion

		#region public void GetBaseComponentsAndComponentDirectives(Forecast forecast)
		/// <summary>
		/// Прогнозирует проведение работ на базовых агрегатах, а также замену или снятие с экплуатации самих базовых агрегатов
		/// </summary>
		/// <param name="forecast"></param>
		public void GetBaseComponentsAndComponentDirectives(Forecast forecast)
        {
            forecast.BaseComponents.Clear();
            forecast.BaseComponentDirectives.Clear();
            // пробегаем по всем базовым агрегатам воздушного судна и выбираем просроченные (требующие замены)
            foreach (ForecastData forecastData in forecast.ForecastDatas)
            {
                BaseComponent baseComponent = forecastData.BaseComponent;
                baseComponent.ForecastLifelength = forecastData.ForecastLifelength;
                
                if (baseComponent.LifeLimit != null && !baseComponent.LifeLimit.IsNullOrZero())
                {
					_performanceCalculator.GetNextPerformance(baseComponent, forecastData);

                    if (baseComponent.NextPerformanceDate != null &&
                        baseComponent.NextPerformanceDate.Value.Date <= forecastData.ForecastDate.Date ||
                        baseComponent.Condition == ConditionState.Notify &&
                        forecastData.IncludeNotifyes ||
                        forecastData.IncludePercents &&
                        baseComponent.Percents <= forecastData.Percents)
                    {
						baseComponent.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													             || np.PerformanceDate > forecastData.ForecastDate
													             || np.PerformanceDate < forecastData.LowerLimit);
						if (baseComponent.NextPerformances.Count == 0)
                            continue;
                        AdditionalFiltration(forecastData, baseComponent);
                        if (baseComponent.NextPerformances.Count == 0)
                            continue;
                        forecast.BaseComponents.Add(baseComponent);
                    }
                }

                // пробегаем по всем работам базового агрегата и выбираем все просроченные
                foreach (var directive in baseComponent.ComponentDirectives)
                {
					_performanceCalculator.GetNextPerformance(directive, forecastData);
                    if (directive.NextPerformanceDate != null && 
                        directive.NextPerformanceDate.Value.Date <= forecastData.ForecastDate.Date)
                    {
						directive.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													            || np.PerformanceDate > forecastData.ForecastDate
													            || np.PerformanceDate < forecastData.LowerLimit);
						if (directive.NextPerformances.Count == 0)
                            continue;
                        AdditionalFiltration(forecastData, directive);
                        if (directive.NextPerformances.Count == 0)
                            continue;
                        forecast.BaseComponentDirectives.Add(directive);
                    }
                }
            }
        }

		#endregion

		#region public IEnumerable<AccessoryRequired> GetBaseComponentsAndComponentDirectivesKits(Forecast forecast)

		/// <summary>
		/// Прогнозирует проведение работ на базовых агрегатах, а также замену или снятие с экплуатации самих базовых агрегатов
		/// </summary>
		/// <param name="forecast"></param>
		public IEnumerable<AccessoryRequired> GetBaseComponentsAndComponentDirectivesKits(Forecast forecast)
        {
            List<AccessoryRequired> result = new List<AccessoryRequired>();
            // пробегаем по всем базовым агрегатам воздушного судна и выбираем просроченные (требующие замены)
            foreach (ForecastData fd in forecast.ForecastDatas)
            {
                BaseComponent baseComponent = fd.BaseComponent;
                if (baseComponent.Kits.Count <= 0) continue;

                if (baseComponent.LifeLimit != null && !baseComponent.LifeLimit.IsNullOrZero())
                {
					_performanceCalculator.GetNextPerformance(baseComponent, fd);

                    if (baseComponent.NextPerformanceDate != null &&
                        baseComponent.NextPerformanceDate.Value.Date <= fd.ForecastDate.Date ||
                        baseComponent.Condition == ConditionState.Notify &&
                        fd.IncludeNotifyes ||
                        fd.IncludePercents &&
                        baseComponent.Percents <= fd.Percents)
                    {
						baseComponent.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													             || np.PerformanceDate > fd.ForecastDate
													             || np.PerformanceDate < fd.LowerLimit);
                        if (baseComponent.NextPerformances.Count == 0)
                            continue;
                        AdditionalFiltration(fd, baseComponent);
                        if (baseComponent.NextPerformances.Count == 0)
                            continue;
                        result.AddRange(baseComponent.Kits);
                    }
                }

                // пробегаем по всем работам базового агрегата и выбираем все просроченные
                foreach (ComponentDirective directive in baseComponent.ComponentDirectives)
                {
                    if (directive.Kits.Count <= 0) continue;

					_performanceCalculator.GetNextPerformance(directive, fd);
                    if (directive.NextPerformanceDate != null &&
                        directive.NextPerformanceDate.Value.Date <= fd.ForecastDate.Date)
                    {
						directive.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													            || np.PerformanceDate > fd.ForecastDate
													            || np.PerformanceDate < fd.LowerLimit);
						if (directive.NextPerformances.Count == 0)
                            continue;
                        AdditionalFiltration(fd, directive);
                        if (directive.NextPerformances.Count == 0)
                            continue;
                        result.AddRange(directive.Kits);
                    }
                }
            }

            return result;
        }

		#endregion

		#region private void GetBaseComponentsAndComponentDirectives(Store store, ForecastData forecastData, out BaseComponentCollection baseDetails, out DetailDirectiveCollection detailDirectives)

		/// <summary>
		/// Прогнозирует проведение работ на базовых агрегатах, а также замену или снятие с экплуатации самих базовых агрегатов
		/// </summary>
		/// <param name="store"></param>
		/// <param name="forecastData"></param>
		/// <param name="baseComponents"></param>
		/// <param name="componentlDirectives"></param>
		private void GetBaseComponentsAndComponentDirectives(Store store, ForecastData forecastData, 
                                                       out BaseComponentCollection baseComponents, 
                                                       out ICommonCollection<ComponentDirective> componentlDirectives)
        {
            baseComponents = new BaseComponentCollection();
            componentlDirectives = new CommonCollection<ComponentDirective>();

            var storeBaseComponents = new BaseComponentCollection(_componentCore.GetStoreBaseComponents(store.ItemId));
            // пробегаем по всем базовым агрегатам воздушного судна и выбираем просроченные (требующие замены)
            foreach (var baseComponent in storeBaseComponents)
                if (baseComponent.IsDeleted == false)
                {
                    if (baseComponent.LifeLimit != null && !baseComponent.LifeLimit.IsNullOrZero())
                    {
						_performanceCalculator.GetNextPerformance(baseComponent, forecastData);

                        if (baseComponent.NextPerformanceDate != null &&
                            baseComponent.NextPerformanceDate.Value.Date <= forecastData.ForecastDate.Date ||
                            baseComponent.Condition == ConditionState.Notify &&
                            forecastData.IncludeNotifyes ||
                            forecastData.IncludePercents &&
                            baseComponent.Percents <= forecastData.Percents)
                            baseComponents.Add(baseComponent);
                    }

                    // пробегаем по всем работам базового агрегата и выбираем все просроченные
                    foreach (var directive in baseComponent.ComponentDirectives)
                    {
						_performanceCalculator.GetNextPerformance(directive, forecastData);
                        if (directive.NextPerformanceDate != null && 
                            directive.NextPerformanceDate.Value.Date <= forecastData.ForecastDate.Date)
                            componentlDirectives.Add(directive);
                    }
                }
        }

		#endregion

		#region public void GetComponentsAndComponentDirectives(Forecast forecast)
		/// <summary>
		/// Прогнознирует замену агрегатов воздушного судна и выполнение других работ на агрегатах
		/// </summary>
		/// <param name="forecast"></param>
		public void GetComponentsAndComponentDirectives(Forecast forecast)
        {
            if(forecast == null)return;
            forecast.Components.Clear();
            forecast.ComponentDirectives.Clear();
            if (forecast.Store != null)
            {
                var tempData = forecast.ForecastDataForNonLifelenght;
                var components = new ComponentCollection();
                var componentDirectives = new CommonCollection<ComponentDirective>();
                // пробегаем по всем компонентам базового агрегата и выбираем те, которые необходимо заменить
                var tempComponents = _componentCore.GetStoreComponents(forecast.Store);
                var storeBaseComponents = new List<BaseComponent>(_componentCore.GetStoreBaseComponents(forecast.Store.ItemId));
                tempComponents.AddRange(_componentCore.GetComponents(storeBaseComponents).ToArray());
                ICommonCollection<ComponentDirective> tempDeleting = new CommonCollection<ComponentDirective>();
                foreach (var t in tempComponents)
                {
                    if (t.LifeLimit != null && !t.LifeLimit.IsNullOrZero())
                    {
						_performanceCalculator.GetNextPerformance(t, tempData);

                        if (t.Condition == ConditionState.Overdue ||
                            t.NextPerformanceDate != null && 
                            t.NextPerformanceDate.Value.Date <= tempData.ForecastDate.Date)
                        {
							t.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													        || np.PerformanceDate.Value.Date > tempData.ForecastDate.Date
													        || np.PerformanceDate.Value.Date < tempData.LowerLimit.Date);
                            if (t.NextPerformances.Count == 0)
                                continue;
                            AdditionalFiltration(tempData, t);
                            if (t.NextPerformances.Count == 0)
                                continue;
                            components.Add(t);
                        }
                    }

                    // пробегаем по всем работам агрегата и выбираем просроченные
                    tempDeleting.Clear();
                    foreach (var componentDirective in t.ComponentDirectives)
                    {
						_performanceCalculator.GetNextPerformance(componentDirective, tempData);

                        if (componentDirective.Condition == ConditionState.Overdue ||
                            componentDirective.NextPerformanceDate != null &&
                            componentDirective.NextPerformanceDate.Value.Date <= tempData.ForecastDate.Date)
                        {
							componentDirective.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													                      || np.PerformanceDate.Value.Date > tempData.ForecastDate.Date
													                      || np.PerformanceDate.Value.Date < tempData.LowerLimit.Date);
							if (componentDirective.NextPerformances.Count == 0)
                                continue;
                            AdditionalFiltration(tempData, componentDirective);
                            if (componentDirective.NextPerformances.Count == 0)
                                continue;
                            componentDirectives.Add(componentDirective);
                            //details.CompareAndAdd(t);
                        }
                        else tempDeleting.Add(componentDirective);
                    }

                    foreach (ComponentDirective directive in tempDeleting)
                    {
                        t.ComponentDirectives.Remove(t.ComponentDirectives.GetItemById(directive.ItemId));
                    }
                }

                forecast.Components.AddRange(components.ToArray());
                forecast.ComponentDirectives.AddRange(componentDirectives.ToArray());
            }

            if (forecast.ForecastDatas == null) return;
            foreach (var forecastData in forecast.ForecastDatas)
            {
                var baseComponent = forecastData.BaseComponent;
                ComponentCollection tempComponents;
                ICommonCollection<ComponentDirective> tempComponentDirectives;

                GetComponentsAndComponentDirectives(baseComponent, forecastData, out tempComponents, out tempComponentDirectives);

                forecast.Components.AddRange(tempComponents.ToArray());
                forecast.ComponentDirectives.AddRange(tempComponentDirectives.ToArray());
            }
        }

		#endregion

		#region public IEnumerable<AccessoryRequired> GetComponentsAndComponentDirectivesKits(Forecast forecast)

		/// <summary>
		/// Прогнознирует замену агрегатов воздушного судна и выполнение других работ на агрегатах
		/// </summary>
		/// <param name="forecast"></param>
		public IEnumerable<AccessoryRequired> GetComponentsAndComponentDirectivesKits(Forecast forecast)
        {
            var result = new List<AccessoryRequired>();
            foreach (ForecastData data in forecast.ForecastDatas)
            {
                result.AddRange(GetComponentsAndComponentDirectivesKits(data));
            }

            return result;
        }

		#endregion

		#region private void GetComponentsAndComponentDirectives(Store store, ForecastData forecastData, out ComponentCollection details, out DetailDirectiveCollection componentDirectives)

		/// <summary>
		/// Прогнознирует замену агрегатов воздушного судна и выполнение других работ на агрегатах
		/// </summary>
		/// <param name="store"></param>
		/// <param name="forecastData"></param>
		/// <param name="components"></param>
		/// <param name="componentDirectives"></param>
		private void GetComponentsAndComponentDirectives(Store store, ForecastData forecastData, 
                                                      out ComponentCollection components, 
                                                      out ICommonCollection<ComponentDirective> componentDirectives)
        {
            components = new ComponentCollection();
            componentDirectives = new CommonCollection<ComponentDirective>();
            var storeComponentCollection = new ComponentCollection(_componentCore.GetStoreComponents(store).ToArray());
            foreach (var component in storeComponentCollection)
            {
                if ((component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ComponentsAndParts) || 
                     component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ControlTestEquipment) ||
                     component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.GroundEquipment) ||
                     component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.OfficeEquipment) && component.LifeLimit != null && !component.LifeLimit.IsNullOrZero())
                    || (component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Tools) || component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.MaintenanceMaterials) && component.ExpirationDate != null))
                {
					_performanceCalculator.GetNextPerformance(component, forecastData);

                    if (component.NextPerformanceDate != null &&
                        component.NextPerformanceDate.Value.Date <= forecastData.ForecastDate.Date ||
                        component.Condition == ConditionState.Notify && forecastData.IncludeNotifyes ||
                        forecastData.IncludePercents && component.Percents <= forecastData.Percents)
                        components.Add(component);
                }

                // пробегаем по всем работам агрегата и выбираем просроченные
                foreach (var componentDirective in component.ComponentDirectives)
                {
					_performanceCalculator.GetNextPerformance(componentDirective, forecastData);
                    if (componentDirective.NextPerformanceDate != null &&
                        componentDirective.NextPerformanceDate.Value.Date <= forecastData.ForecastDate.Date)
                        componentDirectives.Add(componentDirective);
                }
            }
        }

		#endregion

		#region private void GetComponentsAndComponentDirectives(BaseDetail baseDetail, ForecastData forecastData, out ComponentCollection details, out ICommonCollection<ComponentDirective> componentDirectives)

		/// <summary>
		/// Прогнозирует замену агрегатов и выполнение других работ на агрегатах
		/// </summary>
		/// <param name="baseComponent"></param>
		/// <param name="forecastData"></param>
		/// <param name="components"></param>
		/// <param name="componentDirectives"></param>
		private void GetComponentsAndComponentDirectives(BaseComponent baseComponent, 
                                                     ForecastData forecastData, 
                                                     out ComponentCollection components, 
                                                     out ICommonCollection<ComponentDirective> componentDirectives)
        {
            components = new ComponentCollection();
            componentDirectives = new CommonCollection<ComponentDirective>();

            // пробегаем по всем компонентам базового агрегата и выбираем те, которые необходимо заменить
            var tempComponents = _componentCore.GetComponents(baseComponent);
            ICommonCollection<ComponentDirective> tempDeleting = new CommonCollection<ComponentDirective>();
            foreach (var t in tempComponents)
            {
                if (t.LifeLimit != null && !t.LifeLimit.IsNullOrZero())
                {
					_performanceCalculator.GetNextPerformance(t, forecastData);

                    if (t.NextPerformanceDate != null &&
                        t.NextPerformanceDate.Value.Date <= forecastData.ForecastDate.Date ||
                        t.Condition == ConditionState.Notify && forecastData.IncludeNotifyes ||
                        forecastData.IncludePercents && t.Percents <= forecastData.Percents)
                    {
						t.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													    || np.PerformanceDate.Value.Date > forecastData.ForecastDate.Date
													    || np.PerformanceDate.Value.Date < forecastData.LowerLimit.Date);
						if (t.NextPerformances.Count == 0)
                            continue;
                        AdditionalFiltration(forecastData, t);
                        if (t.NextPerformances.Count == 0)
                            continue;
                        components.Add(t);
                    }
                }

                // пробегаем по всем работам агрегата и выбираем просроченные
                tempDeleting.Clear();
                foreach (ComponentDirective componentDirective in t.ComponentDirectives)
                {
					_performanceCalculator.GetNextPerformance(componentDirective, forecastData);

                    if (componentDirective.NextPerformanceDate != null &&
                        componentDirective.NextPerformanceDate.Value.Date <= forecastData.ForecastDate.Date)
                    {
						componentDirective.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													                  || np.PerformanceDate.Value.Date > forecastData.ForecastDate.Date
													                  || np.PerformanceDate.Value.Date < forecastData.LowerLimit.Date);
						if (componentDirective.NextPerformances.Count == 0)
                            continue;
                        AdditionalFiltration(forecastData, componentDirective);
                        if (componentDirective.NextPerformances.Count == 0)
                            continue;
                        componentDirectives.Add(componentDirective);
                        //details.CompareAndAdd(t);
                    }
                    else tempDeleting.Add(componentDirective);
                }

                foreach (ComponentDirective directive in tempDeleting)
                {
                    t.ComponentDirectives.Remove(t.ComponentDirectives.GetItemById(directive.ItemId));
                }
            }
        }

		#endregion

		#region private IEnumerable<Kit> GetComponentsAndComponentDirectives(ForecastData forecastData)

		/// <summary>
		/// Прогнозирует замену агрегатов и выполнение других работ на агрегатах
		/// </summary>
		/// <param name="forecastData"></param>
		private IEnumerable<AccessoryRequired> GetComponentsAndComponentDirectivesKits(ForecastData forecastData)
        {
            List <AccessoryRequired> result = new List<AccessoryRequired>();
            // пробегаем по всем компонентам базового агрегата и выбираем те, которые необходимо заменить
            ComponentCollection tempComponents = _componentCore.GetComponents(forecastData.BaseComponent);
            ComponentCollection preResultComponents = _componentCore.GetComponents(forecastData.BaseComponent);

            for (int i = 0; i < tempComponents.Count; i++)
            {
                if (tempComponents[i].Kits.Count <= 0)continue;
                //if (detail.LifeLimit != null && !detail.LifeLimit.IsNullLifelength() && detail.LifeLimit.IsLessOrEqualByAnyParameter(forecastData.ForecastLifelength))
                if (tempComponents[i].LifeLimit != null && !tempComponents[i].LifeLimit.IsNullOrZero())
                {
					_performanceCalculator.GetNextPerformance(tempComponents[i], forecastData);

                    if (tempComponents[i].Condition == ConditionState.Overdue ||
                        tempComponents[i].NextPerformanceDate != null &&
                        tempComponents[i].NextPerformanceDate.Value.Date <= forecastData.ForecastDate.Date)
                    {
						tempComponents[i].NextPerformances.RemoveAll(np => np.PerformanceDate == null
													                 || np.PerformanceDate.Value.Date > forecastData.ForecastDate.Date
													                 || np.PerformanceDate.Value.Date < forecastData.LowerLimit.Date);
                        if (tempComponents[i].NextPerformances.Count == 0)
                            continue;
                        AdditionalFiltration(forecastData, tempComponents[i]);
                        if (tempComponents[i].NextPerformances.Count == 0)
                            continue;
                        result.AddRange(tempComponents[i].Kits);
                    }
                }

                // пробегаем по всем работам агрегата и выбираем просроченные
                foreach (ComponentDirective componentDirective in tempComponents[i].ComponentDirectives)
                {
                    if (componentDirective.Kits.Count <= 0) continue;
					_performanceCalculator.GetNextPerformance(componentDirective, forecastData);

                    if (componentDirective.Condition == ConditionState.Overdue ||
                        componentDirective.NextPerformanceDate != null &&
                        componentDirective.NextPerformanceDate.Value.Date <= forecastData.ForecastDate.Date)
                    {
						componentDirective.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													                  || np.PerformanceDate.Value.Date > forecastData.ForecastDate.Date
													                  || np.PerformanceDate.Value.Date < forecastData.LowerLimit.Date);
						if (componentDirective.NextPerformances.Count == 0)
                            continue;
                        AdditionalFiltration(forecastData, componentDirective);
                        if (componentDirective.NextPerformances.Count == 0)
                            continue;
                        result.AddRange(componentDirective.Kits);
                        //details.CompareAndAdd(t);
                    }
                }
            }

            return result;
        }

        #endregion

        #region public void GetDirectives(Forecast forecast, PrimaryDirectiveType directiveType)
        /// <summary>
        /// Прогнозирует выполнение директив воздушного судна
        /// </summary>
        /// <param name="forecast"></param>
        /// <param name="directiveType"></param>
        /// <returns></returns>
        public void GetDirectives(Forecast forecast, DirectiveType directiveType)
        {
            if (forecast == null || forecast.ForecastDatas == null) return;
            if (directiveType == null) directiveType = DirectiveType.AirworthenessDirectives;
            
            forecast.DirectiveCollections[directiveType].Clear();
            
            foreach (ForecastData forecastData in forecast.ForecastDatas)
            {
                forecast.DirectiveCollections[directiveType].AddRange(GetDirectives(forecastData, directiveType).ToArray());
            }
        }

        #endregion

        #region private DirectiveCollection GetDirectives(ForecastData forecastData, PrimaryDirectiveType directiveType)

        /// <summary>
        /// Прогнозирует выполнение директив базового агрегата
        /// </summary>
        /// <param name="forecastData"></param>
        /// <param name="directiveType"></param>
        /// <returns></returns>
        private DirectiveCollection GetDirectives(ForecastData forecastData, DirectiveType directiveType)
        {
            //коллекция просроченных директив
            DirectiveCollection overdue = new DirectiveCollection();

            if (forecastData == null || forecastData.BaseComponent == null) return overdue;
            // пробегаем по всем директивам воздушного судна и отбираем просроченные
            DirectiveCollection adStatus = _directiveCore.GetDirectives(forecastData.BaseComponent, directiveType);
            foreach (Directive directive in adStatus)
            {
				_performanceCalculator.GetNextPerformance(directive, forecastData);
                if ((directive.NextPerformanceDate != null &&
                     directive.NextPerformanceDate.Value.Date >= forecastData.LowerLimit.Date) &&
                     directive.NextPerformanceDate.Value.Date <= forecastData.ForecastDate.Date ||
                    (directive.Condition == ConditionState.Notify && forecastData.IncludeNotifyes) ||
                    (forecastData.IncludePercents && directive.Percents != null && directive.Percents <= forecastData.Percents))
                {
					directive.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													        || np.PerformanceDate.Value.Date > forecastData.ForecastDate.Date
													        || np.PerformanceDate.Value.Date < forecastData.LowerLimit.Date);
                    if (directive.NextPerformances.Count == 0)
                        continue;
                    AdditionalFiltration(forecastData, directive);
                    if (directive.NextPerformances.Count == 0)
                        continue;
                    overdue.Add(directive);
                }
            }

            adStatus.Clear();
            // возвращаем просроченные директивы
            return overdue;
        }

        #endregion

        #region public IEnumerable<AccessoryRequired> GetDirectivesKits(Forecast forecast, PrimaryDirectiveType directiveType)
        /// <summary>
        /// Прогнозирует выполнение директив воздушного судна
        /// </summary>
        /// <param name="forecast"></param>
        /// <param name="directiveType"></param>
        /// <returns></returns>
        public IEnumerable<AccessoryRequired> GetDirectivesKits(Forecast forecast, DirectiveType directiveType)
        {
            List<AccessoryRequired> result = new List<AccessoryRequired>();
            foreach (ForecastData data in forecast.ForecastDatas)
            {
                result.AddRange(GetDirectivesKits(data, directiveType));
            }

            return result;
        }

        #endregion

        #region private IEnumerable<KitRequired> GetDirectivesKits(ForecastData forecastData, PrimaryDirectiveType directiveType)
        /// <summary>
        /// Прогнозирует выполнение директив базового агрегата
        /// </summary>
        /// <param name="forecastData"></param>
        /// <param name="directiveType"></param>
        /// <returns></returns>
        private IEnumerable<AccessoryRequired> GetDirectivesKits(ForecastData forecastData, DirectiveType directiveType)
        {
            List<AccessoryRequired> result = new List<AccessoryRequired>();
            // пробегаем по всем директивам воздушного судна и отбираем просроченные
            DirectiveCollection adStatus = _directiveCore.GetDirectives(forecastData.BaseComponent, directiveType);
            foreach (Directive directive in adStatus)
            {
                if (directive.Kits.Count <= 0)
                    continue;

				_performanceCalculator.GetNextPerformance(directive, forecastData);
                if ((directive.NextPerformanceDate != null &&
                     directive.NextPerformanceDate.Value.Date <= forecastData.ForecastDate.Date) ||
                    (directive.Condition == ConditionState.Notify && forecastData.IncludeNotifyes) ||
                    (forecastData.IncludePercents && directive.Percents != null && directive.Percents <= forecastData.Percents))
                {
					directive.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													        || np.PerformanceDate.Value.Date > forecastData.ForecastDate.Date
													        || np.PerformanceDate.Value.Date < forecastData.LowerLimit.Date);
					if (directive.NextPerformances.Count == 0)
                        continue;
                    AdditionalFiltration(forecastData, directive);
                    if (directive.NextPerformances.Count == 0)
                        continue;
                    result.AddRange(directive.Kits);
                }
            }
            adStatus.Clear();
            // возвращаем просроченные директивы
            return result;
        }

        #endregion

        #region public void GetEngineeringOrders(Forecast forecast)
        /// <summary>
        /// Прогнозирует выполнение директив базового агрегата
        /// </summary>
        /// <param name="forecast"></param>
        /// <returns></returns>
        public void GetEngineeringOrders(Forecast forecast)
        {
            forecast.EngineeringOrders.Clear();
            //DirectiveCollection directiveCollection = new DirectiveCollection();
            // пробегаем по всем cpcp воздушного судна и отбираем просроченные
            foreach (ForecastData forecastData in forecast.ForecastDatas)
            {
                forecast.EngineeringOrders.AddRange(GetEngineeringOrders(forecastData).ToArray());
            }
        }

        #endregion

        #region private DirectiveCollection GetEngineeringOrders(ForecastData forecastData)
        /// <summary>
        /// Прогнозирует выполнение директив базового агрегата
        /// </summary>
        /// <param name="forecastData"></param>
        /// <returns></returns>
        private DirectiveCollection GetEngineeringOrders(ForecastData forecastData)
        {
            //коллекция просроченных директив
            DirectiveCollection overdue = new DirectiveCollection();
            // пробегаем по всем cpcp воздушного судна и отбираем просроченные
            DirectiveCollection eos = _directiveCore.GetDirectives(forecastData.BaseComponent, DirectiveType.EngineeringOrders);

            foreach (Directive directive in eos)
            {
				_performanceCalculator.GetNextPerformance(directive, forecastData);
                if ((directive.NextPerformanceDate != null &&
                     directive.NextPerformanceDate.Value.Date <= forecastData.ForecastDate.Date) ||
                    (directive.Condition == ConditionState.Notify && forecastData.IncludeNotifyes) ||
                    (forecastData.IncludePercents && directive.Percents != null && directive.Percents <= forecastData.Percents))
                {
					directive.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													        || np.PerformanceDate.Value.Date > forecastData.ForecastDate.Date
													        || np.PerformanceDate.Value.Date < forecastData.LowerLimit.Date);
					if (directive.NextPerformances.Count == 0)
                        continue;
                    AdditionalFiltration(forecastData, directive);
                    if (directive.NextPerformances.Count == 0)
                        continue;
                    overdue.Add(directive);
                }
            }
            
            eos.Clear();
            //Удаление НЕпросроченных директив
            return overdue;
        }

        #endregion

        #region public IEnumerable<AccessoryRequired> GetEngineeringOrdersKits(Forecast forecast)
        /// <summary>
        /// Прогнозирует выполнение директив базового агрегата
        /// </summary>
        /// <param name="forecast"></param>
        /// <returns></returns>
        public IEnumerable<AccessoryRequired> GetEngineeringOrdersKits(Forecast forecast)
        {
            List<AccessoryRequired> result = new List<AccessoryRequired>();
            // пробегаем по всем cpcp воздушного судна и отбираем просроченные
            DirectiveCollection eos = _directiveCore.GetDirectives(forecast.Aircraft, DirectiveType.EngineeringOrders);
            if (eos.Count == 0)
                return result;
            ForecastData frameForecastData = forecast.GetForecastDataFrame();
            foreach (Directive directive in eos)
            {
                if (directive.Kits.Count <= 0) continue;
				_performanceCalculator.GetNextPerformance(directive, frameForecastData);
                if ((directive.NextPerformanceDate != null &&
                     directive.NextPerformanceDate.Value.Date <= frameForecastData.ForecastDate.Date) ||
                    (directive.Condition == ConditionState.Notify && frameForecastData.IncludeNotifyes) ||
                    (frameForecastData.IncludePercents && directive.Percents != null && directive.Percents <= frameForecastData.Percents))
                {
					directive.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													        || np.PerformanceDate.Value.Date > frameForecastData.ForecastDate.Date
													        || np.PerformanceDate.Value.Date < frameForecastData.LowerLimit.Date);
					if (directive.NextPerformances.Count == 0)
                        continue;
                    AdditionalFiltration(frameForecastData, directive);
                    if (directive.NextPerformances.Count == 0)
                        continue;
                    result.AddRange(directive.Kits);
                }
            }
            eos.Clear();

            return result;
        }

        #endregion

        #region public void GetServiceBulletins(Forecast forecast)
        /// <summary>
        /// Прогнозирует выполнение директив базового агрегата
        /// </summary>
        /// <param name="forecast"></param>
        /// <returns></returns>
        public void GetServiceBulletins(Forecast forecast)
        {
            forecast.ServiceBulletins.Clear();
            // пробегаем по всем ServiceBulletins воздушного судна и отбираем просроченные
            foreach (ForecastData forecastData in forecast.ForecastDatas)
            {
                forecast.ServiceBulletins.AddRange(GetServiceBulletins(forecastData).ToArray());
            }
        }

        #endregion

        #region private DirectiveCollection GetServiceBulletins(ForecastData forecastData)
        /// <summary>
        /// Прогнозирует выполнение директив базового агрегата
        /// </summary>
        /// <param name="forecastData"></param>
        /// <returns></returns>
        private DirectiveCollection GetServiceBulletins(ForecastData forecastData)
        {
            //коллекция просроченных директив
            DirectiveCollection overdue = new DirectiveCollection();
            DirectiveCollection eos = _directiveCore.GetDirectives(forecastData.BaseComponent, DirectiveType.SB);
            foreach (Directive directive in eos)
            {
				_performanceCalculator.GetNextPerformance(directive, forecastData);
                if ((directive.NextPerformanceDate != null &&
                     directive.NextPerformanceDate.Value.Date <= forecastData.ForecastDate.Date) ||
                    (directive.Condition == ConditionState.Notify && forecastData.IncludeNotifyes) ||
                    (forecastData.IncludePercents && directive.Percents != null && directive.Percents <= forecastData.Percents))
                {
					directive.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													        || np.PerformanceDate.Value.Date > forecastData.ForecastDate.Date
													        || np.PerformanceDate.Value.Date < forecastData.LowerLimit.Date);
					if (directive.NextPerformances.Count == 0)
                        continue;
                    AdditionalFiltration(forecastData, directive);
                    if (directive.NextPerformances.Count == 0)
                        continue;
                    overdue.Add(directive);
                }
            }
            eos.Clear();
           
            return overdue;
        }

        #endregion

        #region public IEnumerable<AccessoryRequired> GetServiceBulletinsKits(ForecastData forecast)
        /// <summary>
        /// Прогнозирует выполнение директив базового агрегата
        /// </summary>
        /// <param name="forecast"></param>
        /// <returns></returns>
        public IEnumerable<AccessoryRequired> GetServiceBulletinsKits(Forecast forecast)
        {
            List<AccessoryRequired>result = new List<AccessoryRequired>();

            DirectiveCollection sbs = _directiveCore.GetDirectives(forecast.Aircraft, DirectiveType.SB);
            if (sbs.Count == 0)
                return result;
            
            ForecastData frameForecastData = forecast.GetForecastDataFrame();
            foreach (Directive eo in sbs)
            {
                if (eo.Kits.Count <= 0) continue;
				_performanceCalculator.GetNextPerformance(eo, frameForecastData);
                if ((eo.NextPerformanceDate != null &&
                     eo.NextPerformanceDate.Value.Date <= frameForecastData.ForecastDate.Date) ||
                    (eo.Condition == ConditionState.Notify && frameForecastData.IncludeNotifyes) ||
                    (frameForecastData.IncludePercents && eo.Percents != null && eo.Percents <= frameForecastData.Percents))
                {
					eo.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													 || np.PerformanceDate.Value.Date > frameForecastData.ForecastDate.Date
													 || np.PerformanceDate.Value.Date < frameForecastData.LowerLimit.Date);
					if (eo.NextPerformances.Count == 0)
                        continue;
                    AdditionalFiltration(frameForecastData, eo);
                    if (eo.NextPerformances.Count == 0)
                        continue;
                    result.AddRange(eo.Kits);
                }
            }

            sbs.Clear();

            return result;
        }

        #endregion

        #region  public void GetMaintenanceCheck(Forecast forecast)
        public void GetMaintenanceCheck(Forecast forecast)
        {
            if (forecast.Aircraft == null) return;

            ForecastData frameForecastData = forecast.GetForecastDataFrame();
            if(frameForecastData == null)return;
            forecast.MaintenanceChecks.Clear();
            MaintenanceCheckCollection sourceCollection = new MaintenanceCheckCollection();
            sourceCollection.AddRange(_maintenanceCore.GetMaintenanceCheck(forecast.Aircraft, forecast.Aircraft.Schedule));

			_maintenanceCheckCalculator.GetNextPerformanceGroup(sourceCollection, forecast.Aircraft.Schedule, frameForecastData);

            foreach (MaintenanceCheck mc in sourceCollection)
            {
                if (mc.Grouping)
                {
                    if (mc.GetPergormanceGroupWhereCheckIsSenior().Count <= 0)
                        continue;
					mc.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													 || np.PerformanceDate.Value.Date > frameForecastData.ForecastDate.Date
													 || np.PerformanceDate.Value.Date < frameForecastData.LowerLimit.Date);
					if (mc.GetPergormanceGroupWhereCheckIsSenior().Count == 0)
                        continue;
                    
                    AdditionalFiltration(frameForecastData, mc);

                    if (mc.GetPergormanceGroupWhereCheckIsSenior().Count == 0)
                        continue;
                    forecast.MaintenanceChecks.Add(mc);
                }
                else
                {
					mc.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													 || np.PerformanceDate.Value.Date > frameForecastData.ForecastDate.Date
													 || np.PerformanceDate.Value.Date < frameForecastData.LowerLimit.Date);
					if (mc.NextPerformances.Count == 0)
                        continue;
                    
                    AdditionalFiltration(frameForecastData, mc);

                    if (mc.NextPerformances.Count == 0)
                        continue;
                    forecast.MaintenanceChecks.Add(mc);
                }
            }
            sourceCollection.Clear();
        }
        #endregion

        #region  public IEnumerable<KitRequired> GetMaintenanceChecksKits(Forecast forecast)
        public IEnumerable<AccessoryRequired> GetMaintenanceChecksKits(Forecast forecast)
        {
            List<AccessoryRequired> result = new List<AccessoryRequired>();
            if (forecast.Aircraft == null) return null;
            ForecastData main = forecast.GetForecastDataFrame();
            if (main == null) return null;
                        
            MaintenanceCheckCollection maintenanceChecks =
                new MaintenanceCheckCollection(_maintenanceCore.GetMaintenanceCheck(forecast.Aircraft, forecast.Aircraft.Schedule).ToArray());
			_maintenanceCheckCalculator.GetNextPerformanceGroup(maintenanceChecks, forecast.Aircraft.Schedule);
            foreach (MaintenanceCheck mc in maintenanceChecks)
            {
                if (mc.Kits.Count == 0)
                    continue;
                if (mc.Grouping)
                {
                    if (mc.GetPergormanceGroupWhereCheckIsSenior().Count <= 0)
                        continue;
                    List<NextPerformance> npForDelete =
                        mc.NextPerformances.Where(np => np.PerformanceDate == null ||
                                                        np.PerformanceDate.Value.Date > main.ForecastDate.Date ||
                                                        np.PerformanceDate.Value.Date < main.LowerLimit.Date).ToList();
                    foreach (NextPerformance performance in npForDelete)
                    {
                        mc.NextPerformances.Remove(performance);
                    }
                    if (mc.GetPergormanceGroupWhereCheckIsSenior().Count == 0)
                        continue;

                    AdditionalFiltration(main, mc);

                    if (mc.GetPergormanceGroupWhereCheckIsSenior().Count == 0)
                        continue;
                    result.AddRange(mc.Kits);
                }
                else
                {
                    List<NextPerformance> npForDelete =
                        mc.NextPerformances.Where(np => np.PerformanceDate == null ||
                                                        np.PerformanceDate.Value.Date > main.ForecastDate.Date ||
                                                        np.PerformanceDate.Value.Date < main.LowerLimit.Date).ToList();
                    foreach (NextPerformance performance in npForDelete)
                    {
                        mc.NextPerformances.Remove(performance);
                    }
                    if (mc.NextPerformances.Count == 0)
                        continue;

                    AdditionalFiltration(main, mc);

                    if (mc.NextPerformances.Count == 0)
                        continue;
                    result.AddRange(mc.Kits);
                }
            }
            //возвращаем просроченные директивы
            return result;
        }
        #endregion

        #region  public void GetMaintenanceDirectives(Forecast forecast, IEnumerable<ICommonFilter> filters = null)
        public void GetMaintenanceDirectives(Forecast forecast, IEnumerable<ICommonFilter> filters = null)
        {
            if (forecast == null || forecast.Aircraft == null) return;

            forecast.MaintenanceDirectives.Clear();
            ForecastData frameForecastData = forecast.GetForecastDataFrame();
            if (frameForecastData == null) return;

            IEnumerable<MaintenanceDirective> mpdStatus = _maintenanceCore.GetMaintenanceDirectives(forecast.Aircraft, filters);
            foreach (var mpd in mpdStatus)
            {
                if(mpd.ItemRelations.Count > 0)
                    continue;

				//if(mpd.TaskNumberCheck == "26-070-01")
				//{
				//    mpd.ToString();
				//}

				_performanceCalculator.GetNextPerformance(mpd, frameForecastData);
                if ((mpd.NextPerformanceDate != null && 
                     mpd.NextPerformanceDate.Value.Date <= frameForecastData.ForecastDate.Date) ||
                    (mpd.Condition == ConditionState.Overdue || mpd.Condition == ConditionState.Notify && frameForecastData.IncludeNotifyes) ||
                    (forecast.ForecastDatas[0].IncludePercents && mpd.Percents != null && mpd.Percents <= frameForecastData.Percents))
                {
	                mpd.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													  || np.PerformanceDate.Value.Date > frameForecastData.ForecastDate.Date 
													  || np.PerformanceDate.Value.Date < frameForecastData.LowerLimit.Date);
					if (mpd.NextPerformances.Count == 0)
                        continue;
                    AdditionalFiltration(frameForecastData, mpd);
                    if (mpd.NextPerformances.Count == 0)
                        continue;
                    forecast.MaintenanceDirectives.Add(mpd);
                }
            }
        }
        #endregion

        #region public IEnumerable<KitRequired> GetMaintenanceDirectivesKits(Forecast forecast)
        public IEnumerable<AccessoryRequired> GetMaintenanceDirectivesKits(Forecast forecast)
        {
            List<AccessoryRequired> result = new List<AccessoryRequired>();
            if (forecast == null || forecast.Aircraft == null) return result;
            ForecastData frameForecastData = forecast.GetForecastDataFrame();
            if (frameForecastData == null) return result;

            IEnumerable<MaintenanceDirective> mpdStatus = _maintenanceCore.GetMaintenanceDirectives(forecast.Aircraft);

            foreach (MaintenanceDirective mpd in mpdStatus)
            {
                if (mpd.Kits.Count <= 0) continue;
                if (mpd.ItemRelations.Count > 0)
                    continue;

				//if (mpd.TaskNumberCheck == "27-108-01")
				//{
				//    mpd.ToString();
				//}

				_performanceCalculator.GetNextPerformance(mpd, frameForecastData);
                if ((mpd.NextPerformanceDate != null &&
                     mpd.NextPerformanceDate.Value.Date <= frameForecastData.ForecastDate.Date) ||
                    (mpd.Condition == ConditionState.Overdue || mpd.Condition == ConditionState.Notify && frameForecastData.IncludeNotifyes) ||
                    (forecast.ForecastDatas[0].IncludePercents && mpd.Percents != null && mpd.Percents <= frameForecastData.Percents))
                {
					mpd.NextPerformances.RemoveAll(np => np.PerformanceDate == null
													  || np.PerformanceDate.Value.Date > frameForecastData.ForecastDate.Date
													  || np.PerformanceDate.Value.Date < frameForecastData.LowerLimit.Date);
					if (mpd.NextPerformances.Count == 0)
                        continue;
                    AdditionalFiltration(frameForecastData, mpd);
                    if (mpd.NextPerformances.Count == 0)
                        continue;
                    result.AddRange(mpd.Kits);
                }
            }

            return result;
        }
        #endregion

        /*
         *  Вспомогательные методы фильтации выполнений задач прогноза
         */
        #region private void AdditionalFiltration(ForecastData forecastData, IDirective dir)
        private void AdditionalFiltration(ForecastData forecastData, IDirective dir)
        {
            if (forecastData.SelectedForecastType != ForecastType.ForecastByCheck ||
                forecastData.NextPerformance == null) return;
            
            NextPerformance nearest = null;
            double currentOffset = 0;
            if (dir is MaintenanceCheck && ((MaintenanceCheck)dir).Grouping)
            {
                MaintenanceCheck mc = (MaintenanceCheck)dir;

                //Проход по всем след. выполнениям чека и записям в рабочих пакетах
                //для поиска перекрывающихся выполнений
                List<MaintenanceNextPerformance> performances = mc.GetPergormanceGroupWhereCheckIsSenior();
                foreach (MaintenanceNextPerformance mnp in performances)
                {
                    //Производится поиск ближайшего выполнения данной задачи к выбранному чеку
                    if (nearest == null)
                    {
                        nearest = mnp;
                        //Расчитывается текущий отступ между тек. ближайшим выполнением 
                        //и датой выполнения выбранного чека
                        currentOffset =
                            Math.Abs((System.Convert.ToDateTime(nearest.PerformanceDate).Date -
                                      System.Convert.ToDateTime(forecastData.NextPerformance.PerformanceDate).Date).TotalDays);
                    }
                    else
                    {
                        //Расчитывается отступ между кандидатом на ближайшее выполнение
                        //и датой выполнения выбранного чека
                        double newOffset =
                            Math.Abs((System.Convert.ToDateTime(mnp.PerformanceDate).Date -
                                      System.Convert.ToDateTime(forecastData.NextPerformance.PerformanceDate).Date).TotalDays);
                        //Если у кандидата отступ меньше чем у тек. ближайшего выполнения
                        //то кандидат становится ближайшим выполнением
                        if (newOffset < currentOffset)
                        {
                            nearest = mnp;
                            //Расчитывается текущий отступ между тек. ближайшим выполнением 
                            //и датой выполнения выбранного чека
                            currentOffset = newOffset;
                        }
                    }
                }
            }
            else
            {
                if (dir.NextPerformances.Count <= 0)
                    return;
                //Проход по всем след. выполнениям чека и записям в рабочих пакетах
                //для поиска перекрывающихся выполнений
                List<NextPerformance> performances = dir.NextPerformances;
                foreach (NextPerformance np in performances)
                {
                    //Производится поиск ближайшего выполнения данной задачи к выбранному чеку
                    if (nearest == null)
                    {
                        nearest = np;
                        //Расчитывается текущий отступ между тек. ближайшим выполнением 
                        //и датой выполнения выбранного чека
                        currentOffset =
                            Math.Abs((System.Convert.ToDateTime(nearest.PerformanceDate).Date -
                                      System.Convert.ToDateTime(forecastData.NextPerformance.PerformanceDate).Date).TotalDays);
                    }
                    else
                    {
                        //Расчитывается отступ между кандидатом на ближайшее выполнение
                        //и датой выполнения выбранного чека
                        double newOffset =
                            Math.Abs((System.Convert.ToDateTime(np.PerformanceDate).Date -
                                      System.Convert.ToDateTime(forecastData.NextPerformance.PerformanceDate).Date).TotalDays);
                        //Если у кандидата отступ меньше чем у тек. ближайшего выполнения
                        //то кандидат становится ближайшим выполнением
                        if (newOffset < currentOffset)
                        {
                            nearest = np;
                            //Расчитывается текущий отступ между тек. ближайшим выполнением 
                            //и датой выполнения выбранного чека
                            currentOffset = newOffset;
                        }
                    }
                }
            }

            if (nearest == null)
            {
                dir.NextPerformances.Clear();
                return;
            }

            List<NextPerformance> npForDelete = dir.NextPerformances.Where(np => np != nearest).ToList();
            foreach (NextPerformance performance in npForDelete)
            {
                dir.NextPerformances.Remove(performance);
            }
        }
        #endregion


        /*
         * Реализация Forecast для базового агрегата
         */
    }
}
