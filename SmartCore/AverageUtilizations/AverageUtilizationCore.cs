using SmartCore.Aircrafts;
using SmartCore.Calculations;
using SmartCore.Component;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Stores;

namespace SmartCore.AverageUtilizations
{
	public class AverageUtilizationCore : IAverageUtilizationCore
	{
		private readonly IAircraftsCore _aircraftsCore;
		private readonly IStoreCore _storeCore;
		private readonly IComponentCore _componentCore;

		public AverageUtilizationCore(IAircraftsCore aircraftsCore, IStoreCore storeCore, IComponentCore componentCore)
		{
			_aircraftsCore = aircraftsCore;
			_storeCore = storeCore;
			_componentCore = componentCore;
		}

		public AverageUtilization GetAverageUtillization(Aircraft aircraft)
		{
			var aircraftFrame = _componentCore.GetBaseComponentById(aircraft.AircraftFrameId);
			return aircraftFrame.AverageUtilization;
		}


		#region public AverageUtilization GetAverageUtillization(IDirective source, ForecastData forecastData = null)

		/// <summary>
		/// Определяет значение средней утилизации для выполнения задачи
		/// </summary>
		/// <param name="source">Задача, для которой нужно определить утилизацию</param>
		/// <param name="forecastData">прогнозируемый ресурс выполнения задачи</param>
		/// <returns>Значение средней утилизации или null</returns>
		public AverageUtilization GetAverageUtillization(IDirective source, ForecastData forecastData = null)
		{
			if (source == null) return null;
			if (forecastData == null)
			{
				if (source is BaseComponent) return ((BaseComponent)source).AverageUtilization;

				var a = _aircraftsCore.GetParentAircraft(source);
				if (a != null)
				{
					var aircraftFrame = _componentCore.GetBaseComponentById(a.AircraftFrameId);
					return aircraftFrame.AverageUtilization;
				}

				var s = _storeCore.GetParentStore(source);
				return s != null ? new AverageUtilization(0, 0) : null;
			}
			return forecastData.AverageUtilization;
		}

		#endregion
	}
}