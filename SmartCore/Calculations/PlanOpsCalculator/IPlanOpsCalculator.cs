using System;
using System.Collections.Generic;
using SmartCore.Entities.General.Schedule;

namespace SmartCore.Calculations.PlanOpsCalculator
{
	public interface IPlanOpsCalculator
	{
		List<FlightPlanOpsRecords> CalculateTripForPeriod(FlightPlanOps currentPlanOps);
		List<FlightPlanOpsRecords> LoadAircraftStatusOps();
		List<FlightPlanOpsRecords> LoadOpsRecordsByPlanOpsId(int planOpsId);
		void CreateCopyFromExistPlan(FlightPlanOps currentPlanOps);
	}
}