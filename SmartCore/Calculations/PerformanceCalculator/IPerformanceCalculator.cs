using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Calculations.PerformanceCalculator
{
	public interface IPerformanceCalculator
	{
		void GetNextPerformance(Document directive);
		bool GetPerformance(IDirective directive, int performanceNum, bool reset = true);
		bool GetPerformance(Entities.General.Accessory.Component component, int performanceNum);
		void GetPerformance(MaintenanceCheckGroupByType groupChecks, int performanceNum);
		void GetNextPerformance(IDirective directive, ForecastData forecast = null);

		/*
	    * Директивы 
	    */
		ConditionState GetConditionState(Entities.General.Accessory.Component component, bool parentOnly = false);
		ConditionState GetConditionState(ComponentDirective componentDirective);
		ConditionState GetConditionState(Directive directive);
		ConditionState GetConditionState(IDirective directive);
	}
}