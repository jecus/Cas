using System.Collections.Generic;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Store;
using SmartCore.Filters;

namespace SmartCore.Analyst
{
	public interface IAnalystCore
	{
		Forecast GetForecastByAverageUtilization(Store store, ForecastData forecastData);

		void GetForecast<T>(IEnumerable<T> initialArray, ICommonCollection resultArray, Forecast forecast)
			where T : BaseEntityObject, IDirective;

		void GetBaseComponentsAndComponentDirectives(Forecast forecast);

		IEnumerable<AccessoryRequired> GetBaseComponentsAndComponentDirectivesKits(Forecast forecast);

		void GetComponentsAndComponentDirectives(Forecast forecast);

		IEnumerable<AccessoryRequired> GetComponentsAndComponentDirectivesKits(Forecast forecast);

		void GetDirectives(Forecast forecast, DirectiveType directiveType);

		IEnumerable<AccessoryRequired> GetDirectivesKits(Forecast forecast, DirectiveType directiveType);

		void GetEngineeringOrders(Forecast forecast);

		IEnumerable<AccessoryRequired> GetEngineeringOrdersKits(Forecast forecast);

		void GetServiceBulletins(Forecast forecast);

		IEnumerable<AccessoryRequired> GetServiceBulletinsKits(Forecast forecast);

		void GetMaintenanceCheck(Forecast forecast);

		IEnumerable<AccessoryRequired> GetMaintenanceChecksKits(Forecast forecast);

		void GetMaintenanceDirectives(Forecast forecast, IEnumerable<ICommonFilter> filters = null);

		IEnumerable<AccessoryRequired> GetMaintenanceDirectivesKits(Forecast forecast);

	}
}