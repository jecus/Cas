using System;
using System.Collections.Generic;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Filters;

namespace SmartCore.Maintenance
{
	public interface IMaintenanceCore
	{
		ICommonCollection<MaintenanceCheck> GetMaintenanceCheck(params object[] parametres);

		List<MaintenanceCheck> GetMaintenanceCheck(Aircraft aircraft, bool? schedule = null);

		IList<MaintenanceCheck> GetMaintenanceCheckList(IList<int> maintenanceCheckIds, bool getDeleted = false);

		ICommonCollection<MaintenanceDirective> GetMaintenanceDirectives(params object[] parametres);

		List<MaintenanceDirective> GetMaintenanceDirectives(BaseEntityObject parent, IEnumerable<ICommonFilter> filters = null);

		MaintenanceDirective GetMaintenanceDirective(Int32 itemId, int? parentAircraftId = null);

		IList<MaintenanceDirective> GetMaintenanceDirectiveList(IList<int> maintenanceDirectiveIds, int? parentAircraftId = null);

		void AddMaintenanceCheck(MaintenanceCheck check, Aircraft aircraft);

		void RegisterMaintenanceProgramChangeRecord(Aircraft aircraft, MaintenanceProgramChangeRecord maintenanceProgramChangeRecord);

		void Delete(MaintenanceCheckRecord record);
	}
}