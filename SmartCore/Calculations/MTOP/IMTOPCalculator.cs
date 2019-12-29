using System;
using System.Collections.Generic;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;

namespace SmartCore.Calculations.MTOP
{
	public interface IMTOPCalculator
	{
		void CalculateMtopChecks(List<MTOPCheck> checks, AverageUtilization averageUtilization);

		void CalculateNextPerformance(List<MTOPCheck> checks, DateTime frameStartDate,
			Dictionary<int, Lifelength> groupLifelengths, Aircraft currentAircraft,
			AverageUtilization averageUtilization,MTOPCheckRecord lastCompliance, bool ingoneCompliance = false);

		Dictionary<int, Lifelength> CalculateGroupNew(List<MTOPCheck> checks);

		void CalculateDirective(IMtopCalc directive, AverageUtilization averageUtilization);

		void CalculatePhase(IEnumerable<IMtopCalc> directives, List<MTOPCheck> checks,
			AverageUtilization averageUtilization, bool isZeroPhase = false);

		void CalculatePhaseWithPerformance(IEnumerable<IMtopCalc> directives, List<MTOPCheck> checks,
			AverageUtilization averageUtilization, DateTime from, DateTime to, bool isZeroPhase = false);
	}
}