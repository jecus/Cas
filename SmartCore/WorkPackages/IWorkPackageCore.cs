using System;
using System.Collections.Generic;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;

namespace SmartCore.WorkPackages
{
	public interface IWorkPackageCore
	{
		List<WorkPackage> GetWorkPackages(Aircraft aircraft = null,
											WorkPackageStatus status = WorkPackageStatus.All,
											bool loadWorkPackageItems = false,
											IList<IDirective> includedTasks = null);

		List<WorkPackage> GetWorkPackagesLite(Aircraft aircraft,
											  WorkPackageStatus status = WorkPackageStatus.All,
											  IList<IDirective> includedTasks = null);

		void LoadWorkPackageItems(WorkPackage workPackage);

		void GetWorkPackageItemsWithCalculateNew(WorkPackage workPackage);
		void GetWorkPackageItemsWithCalculate(WorkPackage workPackage);

		void Publish(WorkPackage wp, DateTime date, string remarks);

		IEnumerable<MaintenanceCheckBindTaskRecord> GetMaintenanceBingTasksRecords(int workPackageId,
																				   bool loadTasks = true,
																				   bool lastPerformanceOnly = true);

		WorkPackage AddWorkPakage(IEnumerable<NextPerformance> workPackageItems, Aircraft parentAircraft, out string message);

		WorkPackage AddWorkPakage(CommonCollection<NonRoutineJob> nonRoutine, Aircraft parentAircraft, out string message);

		bool AddToWorkPakage(List<NextPerformance> workPackageItems, int workPackageId, Aircraft parentAircraft, out string message);

		bool AddToWorkPakage(CommonCollection<NonRoutineJob> nonRoutine, int workPackageId, Aircraft parentAircraft, out string message);

		void DeleteFromWorkPackage(int workPackageId, IEnumerable<IBaseEntityObject> recordsToDelete);
	}
}