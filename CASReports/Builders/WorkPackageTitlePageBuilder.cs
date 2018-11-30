using System;
using System.Collections.Generic;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.WorkPackage;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета Release To Service 
    /// </summary>
    public class WorkPackageTitlePageBuilder
    {

        #region Fields

        private WorkPackage _currentWorkPackage;

        /// <summary>
        /// Директивы включаемые в отчет
        /// </summary>
        private readonly List<KeyValuePair<string, int>> _items;

        private IEnumerable<BaseComponent> _aircraftBaseDetails;

        #endregion

        #region Properties

        #region public WorkPackage WorkPackage
        /// <summary>
        /// Возвращает рабочий пакет
        /// </summary>
        public WorkPackage WorkPackage
        {
            set { _currentWorkPackage = value; }
        }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Создается построитель отчета Release To Service 
        /// </summary>
        /// <param name="workPackage">Рабочий пакет</param>
        /// <param name="items"></param>
        /// <param name="aircraftBaseDetails"></param>
        public WorkPackageTitlePageBuilder(WorkPackage workPackage, 
                                           List<KeyValuePair<string, int>> items, 
                                           IEnumerable<BaseComponent> aircraftBaseDetails)
        {
            _currentWorkPackage = workPackage;
            _items = items;
            _aircraftBaseDetails = aircraftBaseDetails;
        }

        #endregion

        #region Methods

        #region public object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public object GenerateReport()
        {
            WPTitlePageReport report = new WPTitlePageReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region private WorkPackageTitlePageDataSet GenerateDataSet()

        private WorkPackageTitlePageDataSet GenerateDataSet()
        {
            WorkPackageTitlePageDataSet dataSet = new WorkPackageTitlePageDataSet();
            AddReleaseToServiceInformationToDataSet(dataSet);
            AddBaseDetailsToDataSet(dataSet);
            AddItemsToDataSet(dataSet);
            return dataSet;
        }

        #endregion

        #region private void AddItemsToDataSet(WorkPackageTitlePageDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        private void AddItemsToDataSet(WorkPackageTitlePageDataSet dataset)
        {
            _items.Add(new KeyValuePair<string, int>("Total:", _items.Sum(x => x.Value)));
            foreach (KeyValuePair<string, int> keyValuePair in _items)
            {
                AddItemDataset(keyValuePair, dataset);
            }
        }

        #endregion

        #region private void AddItemDataset(object reportedDirective, WorkPackageTitlePageDataSet destinationDataSet)
        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="keyValuePair">Добавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddItemDataset(KeyValuePair<string, int> keyValuePair, WorkPackageTitlePageDataSet destinationDataSet)
        {
            destinationDataSet.WPItemsTable.AddWPItemsTableRow(keyValuePair.Key, keyValuePair.Value);
        }

        #endregion

        #region private void AddReleaseToServiceInformationToDataSet(WorkPackageTitlePageDataSet destinationDataSet)

        private void AddReleaseToServiceInformationToDataSet(WorkPackageTitlePageDataSet destinationDataSet)
        {
            var termsProvider = new GlobalTermsProvider();
            var aircraft = _currentWorkPackage.Aircraft;
            var totalFlight = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(aircraft);
	        var op = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == aircraft.OperatorId);
			var airportName = op.Name + Environment.NewLine + "The Seychelles National Airport";
            var manufacturer = GlobalObjects.ComponentCore.GetBaseComponentById(aircraft.AircraftFrameId).Manufacturer;
            var registrationMark = aircraft.RegistrationNumber;
            var model = aircraft.Model.ToString();
            var serialNumber = aircraft.SerialNumber;
            var totalCycles = totalFlight.Cycles.ToString();
            var totalFlightHours = totalFlight.Hours.ToString();
            var operatorLogotype = op.LogotypeReportVeryLarge;
            var operatorName = op.Name;
            var operatorAddress = op.Address;
            var workPerformedStartDate = "";
            if (_currentWorkPackage.Status == WorkPackageStatus.Published || _currentWorkPackage.Status == WorkPackageStatus.Closed)
                workPerformedStartDate = _currentWorkPackage.PublishingDate.ToString(termsProvider["DateFormat"].ToString());
            var workPerformedEndDate = "";
            if (_currentWorkPackage.Status == WorkPackageStatus.Closed)
                workPerformedEndDate = _currentWorkPackage.ClosingDate.ToString(termsProvider["DateFormat"].ToString());
            var workPerformedStation = _currentWorkPackage.Station;
            var workPerformedWorkOrderNo = _currentWorkPackage.Number;
            var wpTitle= _currentWorkPackage.Title;
			var wpCreatedBy = _currentWorkPackage.Author;
			var wpPublishedBy = _currentWorkPackage.PublishedBy;
	        var createDate = _currentWorkPackage.CreateDate;

			destinationDataSet.MainDataTable.AddMainDataTableRow(airportName,
                                                                 manufacturer,
                                                                 registrationMark, model, serialNumber,
                                                                 totalCycles, totalFlightHours,
                                                                 operatorLogotype,
                                                                 operatorName, operatorAddress,
                                                                 workPerformedStartDate,
                                                                 workPerformedEndDate,
                                                                 workPerformedStation,
                                                                 workPerformedWorkOrderNo,
                                                                 wpTitle, wpCreatedBy, wpPublishedBy, "", createDate);
        }

        #endregion

        #region private void AddBaseDetailsToDataSet(WorkPackageTitlePageDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        private void AddBaseDetailsToDataSet(WorkPackageTitlePageDataSet dataset)
        {
            if (_aircraftBaseDetails == null)
                return;

            BaseComponent frame = _aircraftBaseDetails.FirstOrDefault(bd => bd.BaseComponentType == BaseComponentType.Frame);
            if(frame != null)
                dataset.BaseDetailsTable.AddBaseDetailsTableRow
                    ("Aircraft", 
                     frame.SerialNumber,
                     "FH ___________ Cycles________",
                     "FH ___________ Cycles________");

            IEnumerable<BaseComponent> engines = _aircraftBaseDetails.Where(bd => bd.BaseComponentType == BaseComponentType.Engine);
            if (engines.Count() > 0)
            {
                int engineNum = 1;
                foreach (BaseComponent engine in engines)
                {
                    dataset.BaseDetailsTable.AddBaseDetailsTableRow
                        ("Engine # " + engineNum,
                         engine.SerialNumber,
                         "FH",
                         "FH");
                    
                    engineNum++;
                }    
            }

            BaseComponent apu = _aircraftBaseDetails.FirstOrDefault(bd => bd.BaseComponentType == BaseComponentType.Apu);
            if (apu != null)
                dataset.BaseDetailsTable.AddBaseDetailsTableRow
                    ("APU",
                     apu.SerialNumber,
                     "APU Hrs",
                     "APU Hrs");
        }
        #endregion

        #endregion
    }
}
