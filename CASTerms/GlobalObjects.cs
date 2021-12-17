using Newtonsoft.Json.Linq;
using SmartCore;
using SmartCore.AircraftFlights;
using SmartCore.Aircrafts;
using SmartCore.Analyst;
using SmartCore.AuditMongo;
using SmartCore.AuditMongo.Repository;
using SmartCore.Audits;
using SmartCore.AverageUtilizations;
using SmartCore.Calculations.MTOP;
using SmartCore.Calculations.PerformanceCalculator;
using SmartCore.Calculations.PlanOpsCalculator;
using SmartCore.Calculations.StockCalculator;
using SmartCore.Component;
using SmartCore.DataAccesses.ItemsRelation;
using SmartCore.Directives;
using SmartCore.Discrepancies;
using SmartCore.Documents;
using SmartCore.Kits;
using SmartCore.Maintenance;
using SmartCore.NonRoutineJobs;
using SmartCore.Packages;
using SmartCore.Personnel;
using SmartCore.Purchase;
using SmartCore.RegisterPerformances;
using SmartCore.Relation;
using SmartCore.Sms;
using SmartCore.Stores;
using SmartCore.TrackCore;
using SmartCore.TransferRec;
using SmartCore.WorkPackages;

namespace CASTerms
{
    /// <summary>
    /// Глобальные объекты
    /// </summary>
    public static class GlobalObjects
    {
        /// <summary>
        /// Используемое ядро Cas
        /// </summary>
        public static JObject Config { get; set; }

		public static AuditContext  AuditContext { get; set; }
		public static IAuditRepository  AuditRepository { get; set; }
        public static ICasEnvironment CasEnvironment { get; set; }
        public static ICaaEnvironment CaaEnvironment { get; set; }
        public static IPackageCore PackageCore { get; set; }
        public static IPurchaseCore PurchaseCore { get; set; }
		public static IComponentCore ComponentCore { get; set; }
		public static IAnalystCore AnalystCore { get; set; }
		public static IStockCalculator StockCalculator { get; set; }
		public static IDocumentCore DocumentCore { get; set; }
		public static IAuditCore AuditCore { get; set; }
		public static IMaintenanceCore MaintenanceCore { get; set; }
		public static IWorkPackageCore WorkPackageCore { get; set; }
		public static INonRoutineJobCore NonRoutineJobCore { get; set; }
		public static IDirectiveCore DirectiveCore { get; set; }
		public static IAircraftFlightCore AircraftFlightsCore { get; set; }
		public static IDiscrepanciesCore DiscrepanciesCore { get; set; }
		public static IKitsCore KitsCore { get; set; }
		public static ISMSCore SmsCore { get; set; }
		public static IPersonnelCore PersonnelCore { get; set; }
		public static ITransferRecordCore TransferRecordCore { get; set; }
		public static IAircraftsCore AircraftsCore { get; set; }
		public static IItemsRelationsDataAccess ItemsRelationsDataAccess { get; set; }
		public static IStoreCore StoreCore { get; set; }
		public static IBindedItemsCore BindedItemsCore { get; set; }
		public static IAverageUtilizationCore AverageUtilizationCore { get; set; }
		public static IMaintenanceCheckCalculator MaintenanceCheckCalculator { get; set; }
		public static IPerformanceCalculator PerformanceCalculator { get; set; }
		public static IMTOPCalculator MTOPCalculator { get; set; }
		public static IPlanOpsCalculator PlanOpsCalculator { get; set; }
		public static IPerformanceCore PerformanceCore { get; set; }
		public static IFlightTrackCore FlightTrackCore { get; set; }
	}
}
