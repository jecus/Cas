using System;
using System.Collections.Generic;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета Release To Service 
    /// </summary>
    public class WorkPackageReleaseToServiceBuilderAquiline : AbstractReportBuilder
    {

        #region Fields

        private readonly WorkPackage _currentWorkPackage;
	    private readonly bool _isScatReport;

	    /// <summary>
        /// Директивы включаемые в отчет
        /// </summary>
        private List<KeyValuePair<string, int>> Items { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Создается построитель отчета Release To Service 
        /// </summary>
        /// <param name="workPackage">Рабочий пакет</param>
        /// <param name="items"></param>
        public WorkPackageReleaseToServiceBuilderAquiline(WorkPackage workPackage, List<KeyValuePair<string, int>> items, bool isScatReport = false)
        {
            _currentWorkPackage = workPackage;
	        _isScatReport = isScatReport;
	        Items = items;
        }

        #endregion

        #region Properties
        
        #endregion

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {

	        if (_isScatReport)
	        {
		        var report = new WorkPackageReleaseToServiceReportScat();
		        report.SetDataSource(GenerateDataSet());
		        return report;
			}
	        else
	        {
				var report = new WorkPackageReleaseToServiceReportAquiline();
		        report.SetDataSource(GenerateDataSet());
		        return report;
			}
        }

        #endregion

        #region private MaintenanceJobCardDataSet GenerateDataSet()

        private WorkPackageReleaseToServiceDataSet GenerateDataSet()
        {
            var dataSet = new WorkPackageReleaseToServiceDataSet();
            AddReleaseToServiceInformationToDataSet(dataSet);
            AddItemsToDataSet(dataSet);
            return dataSet;
        }

        #endregion

        #region private void AddItemsToDataSet(WorkPackageReleaseToServiceDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        private void AddItemsToDataSet(WorkPackageReleaseToServiceDataSet dataset)
        {
            foreach (KeyValuePair<string, int> keyValuePair in Items)
            {
                AddItemDataset(keyValuePair, dataset);
            }
        }

        #endregion

        #region private void AddItemDataset(object reportedDirective, WorkPackageReleaseToServiceDataSet destinationDataSet)
        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="keyValuePair">Добавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddItemDataset(KeyValuePair<string, int> keyValuePair, WorkPackageReleaseToServiceDataSet destinationDataSet)
        {
            destinationDataSet.WPItemsTable.AddWPItemsTableRow(keyValuePair.Key, keyValuePair.Value);
        }

        #endregion

        #region private void AddReleaseToServiceInformationToDataSet(WorkPackageReleaseToServiceDataSet destinationDataSet)

        private void AddReleaseToServiceInformationToDataSet(WorkPackageReleaseToServiceDataSet destinationDataSet)
        {
			var termsProvider = new GlobalTermsProvider();
			var aircraft = _currentWorkPackage.Aircraft;
			var totalFlight = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(aircraft);
	        var op = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == aircraft.OperatorId);
			var airportName = op.Name + Environment.NewLine + "The Seychelles National Airport";
			var maintenanceReleaseCertificate = _currentWorkPackage.ReleaseCertificateNo;
			var nationality = "The Seychelles";
			var manufacturer = GlobalObjects.ComponentCore.GetBaseComponentById(aircraft.AircraftFrameId).Manufacturer;
			var registrationMark = aircraft.RegistrationNumber;
			var model = aircraft.Model.ToString();
			var serialNumber = aircraft.SerialNumber;
			var totalCycles = totalFlight.Cycles.ToString();
			var totalFlightHours = totalFlight.Hours.ToString();
			var operatorLogotype = op.LogotypeReportLarge;
			var operatorName = op.Name;
			var operatorAddress = op.Address;
			var pagesCount = Items != null ? Items.Sum(x => x.Value) : 0;
            
            var engines = new List<BaseComponent>(GlobalObjects.ComponentCore.GetAircraftEngines(aircraft.ItemId));

	        var leftEngine = engines.FirstOrDefault(i => i.Position.Equals("LH"));
	        var rightEngine = engines.FirstOrDefault(i => i.Position.Equals("RH"));

	        var engine1Serial = "";
	        var engine2Serial = "";
	        if (_isScatReport)
	        {
		        if (leftEngine != null)
			        engine1Serial = $"{leftEngine.SerialNumber}";

		        if (rightEngine != null)
			        engine2Serial = $"{rightEngine.SerialNumber}";
			}
	        else
	        {
				if (leftEngine != null)
			        engine1Serial = $"{leftEngine.Model} \n s/n {leftEngine.SerialNumber}";

		        if (rightEngine != null)
			        engine2Serial = $"{rightEngine.Model} \n s/n {rightEngine.SerialNumber}";
			}
	       

			var apu = GlobalObjects.ComponentCore.GetAircraftApu(aircraft.ItemId);
			var apuSerial = apu != null ? apu.SerialNumber : "";

			var workPerformedCheckType = _currentWorkPackage.CheckType;
			var workPerformedStartDate = "";
            if (_currentWorkPackage.Status == WorkPackageStatus.Published || _currentWorkPackage.Status == WorkPackageStatus.Closed)
                workPerformedStartDate = _currentWorkPackage.PublishingDate.ToString(termsProvider["DateFormat"].ToString());
			else workPerformedStartDate = _currentWorkPackage.OpeningDate.ToString(termsProvider["DateFormat"].ToString());
			var workPerformedEndDate = "";
            if (_currentWorkPackage.Status == WorkPackageStatus.Closed)
                workPerformedEndDate = _currentWorkPackage.ClosingDate.ToString(termsProvider["DateFormat"].ToString());
			var workPerformedStation = _currentWorkPackage.Station;
			var workPerformedWorkOrderNo = _currentWorkPackage.Number;
			var wpTitle = _currentWorkPackage.Title;
			var workPerformedMaintenanceReportNo = _currentWorkPackage.MaintenanceRepairOrzanization;
			var remarks = _currentWorkPackage.Remarks;
			var additionalRemarks = "";
			var catchword = "";
			var crsNumber = "";
			
			var task = _currentWorkPackage.WorkPakageRecords.FirstOrDefault(i => i.Task is MaintenanceDirective)?.Task;
			if (task != null)
			{
				var mpd = task as MaintenanceDirective;
				additionalRemarks = mpd.ScheduleRef;
				catchword = $"R{mpd.ScheduleRevisionNum}";
				crsNumber = $"{mpd.ScheduleRevisionDate:dd.MM.yyyy}";
			}

			var revision = _currentWorkPackage.Revision;
            destinationDataSet.ReleaseToServiceTable.AddReleaseToServiceTableRow(airportName,
                                                                                 maintenanceReleaseCertificate,
                                                                                 nationality, manufacturer,
                                                                                 registrationMark, model, serialNumber,
                                                                                 totalCycles, totalFlightHours,
                                                                                 operatorLogotype,
                                                                                 operatorName, operatorAddress,
                                                                                 workPerformedCheckType,
                                                                                 workPerformedStartDate,
                                                                                 workPerformedEndDate,
                                                                                 workPerformedStation,
                                                                                 workPerformedWorkOrderNo,
                                                                                 wpTitle,
                                                                                 workPerformedMaintenanceReportNo,
                                                                                 remarks, additionalRemarks, catchword,crsNumber, engine1Serial, engine2Serial,

																				 apuSerial, _currentWorkPackage.Station, pagesCount);
        }

        #endregion

        #endregion
    }
}
