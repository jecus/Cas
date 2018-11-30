using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;

namespace SmartCore.Maintenance
{
	public interface IMaintenanceCheckCalculator
	{
		void GetNextPerformanceGroup(MaintenanceCheckCollection sourceCollection, bool schedule, ForecastData forecast = null);

		MaintenanceCheckGroupByType GetNextCheckComplianceGroup(MaintenanceCheckCollection collection, bool schedule, Aircraft aircraft);
	}
}