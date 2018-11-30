using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.AverageUtilizations
{
	public interface IAverageUtilizationCore
	{
		AverageUtilization GetAverageUtillization(Aircraft aircraft);
		AverageUtilization GetAverageUtillization(IDirective source, ForecastData forecastData = null);
	}
}