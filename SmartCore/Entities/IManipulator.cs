using SmartCore.AircraftFlights;
using SmartCore.Aircrafts;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Store;
using SmartCore.Maintenance;
using SmartCore.Packages;
using SmartCore.Purchase;
using SmartCore.WorkPackages;

namespace SmartCore.Entities
{
	public interface IManipulator
	{
		IPurchaseCore PurchaseService { get; set; }
		IMaintenanceCore MaintenanceCore { get; set; }
		IWorkPackageCore WorkPackageCore { get; set; }
		IAircraftFlightCore AircraftFlightCore { get; set; }
		IAircraftsCore AircraftsCore { get; set; }


		void Save(JobCardTask jobCardTask);
	
		void Save(BaseEntityObject saveObject);

		void SaveAll(BaseEntityObject saveObject, bool saveChild = false, bool saveForced = false);

		void Save(AbstractPerformanceRecord performance, bool saveAttachedFile = true);

		void Delete(BaseEntityObject deletedObject, bool isDeletedOnly = true);

	}
}