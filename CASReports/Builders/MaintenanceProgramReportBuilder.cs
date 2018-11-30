using System;
using System.Collections.Generic;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета по Maintenance Status
    /// </summary>
    public class MaintenanceProgramReportBuilder : AbstractReportBuilder
    {

        #region Fields

        private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
        private Aircraft _reportedAircraft;
        private BaseComponent _reportedBaseComponent;
        private MaintenanceCheckCollection _reportedDirectives = new MaintenanceCheckCollection();
        private ForecastData _forecastData;
        private string _dateAsOf = "";

        //readonly AllDirectiveFilter defaultFilter = new AllDirectiveFilter();
        private string _reportTitle = "MAINTENANCE PROGRAM";
        private bool _filterSelection;
        private byte[] _operatorLogotype;

        private Lifelength _lifelengthAircraftSinceNew;
        private Lifelength _lifelengthAircraftSinceOverhaul;
        private Lifelength _current;
        private DateTime _manufactureDate;

        #endregion

        #region Properties

        #region public Aircraft ReportedAircraft

        /// <summary>
        /// ВС включаемыое в отчет
        /// </summary>
        public Aircraft ReportedAircraft
        {
            get
            {
                return _reportedAircraft;
            }
            set
            {
                _reportedAircraft = value;
                if (value == null) return;
                _reportedBaseComponent = GlobalObjects.ComponentCore.GetBaseComponentById(value.AircraftFrameId);
                _manufactureDate = value.ManufactureDate;
                _current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);
                OperatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogoTypeWhite;
            }
        }

        #endregion

        #region public BaseDetail ReportedBaseDetail

        /// <summary>
        /// Базовый агрегат, включаемый в отчет
        /// </summary>
        public BaseComponent ReportedBaseComponent
        {
            get
            {
                return _reportedBaseComponent;
            }
            set
            {
                if (value == null) return;
                _reportedBaseComponent = value;
                _manufactureDate = _reportedBaseComponent.ManufactureDate;
                _current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);
                OperatorLogotype = GlobalObjects.CasEnvironment.Operators[0].LogoTypeWhite;
                _reportedDirectives.Clear();
            }
        }
        #endregion

        #region public MaintenanceCheckCollectionReportedDirectives

        /// <summary>
        /// Директивы включаемые в отчет
        /// </summary>
        public MaintenanceCheckCollection ReportedDirectives
        {
            get
            {
                return _reportedDirectives;
            }
            set
            {
                _reportedDirectives = value;
            }
        }

        #endregion

        #region public string DateAsOf

        /// <summary>
        /// Текст поля DateAsOf
        /// </summary>
        public string DateAsOf
        {
            get { return _dateAsOf; }
            set { _dateAsOf = value; }
        }

        #endregion

        #region public string ReportTitle

        /// <summary>
        /// Текст заголовка отчета
        /// </summary>
        public string ReportTitle
        {
            get { return _reportTitle; }
            set { _reportTitle = value; }
        }

        #endregion

        #region public ForecastData ForecastData

        public ForecastData ForecastData
        {
            set { _forecastData = value; }
        }
        #endregion

        #region public public bool FilterSelection

        /// <summary>
        /// Текст фильтра отчета
        /// </summary>
        public bool FilterSelection
        {
            get { return _filterSelection; }
            set { _filterSelection = value; }
        }

        #endregion

        #region public LifelengthFormatter LifelengthFormatter

        /// <summary>
        /// Формировщик вывода информации о наработке
        /// </summary>
        public LifelengthFormatter LifelengthFormatter
        {
            get { return _lifelengthFormatter; }
        }

        #endregion

        #region public Image OperatorLogotype

        /// <summary>
        /// Возвращает или устанавливает логтип эксплуатанта
        /// </summary>
        public byte[] OperatorLogotype
        {
            get
            {
                return _operatorLogotype;
            }
            set
            {
                _operatorLogotype = value;
            }
        }

        #endregion

        #region public Lifelength LifelengthAircraftSinceNew

        /// <summary>
        /// Наработка ВС SinceNew
        /// </summary>
        public Lifelength LifelengthAircraftSinceNew
        {
            get { return _lifelengthAircraftSinceNew; }
            set { _lifelengthAircraftSinceNew = value; }
        }

        #endregion

        #region public Lifelength LifelengthAircraftSinceOverhaul

        /// <summary>
        /// Наработка ВС SinceOverhaul
        /// </summary>
        public Lifelength LifelengthAircraftSinceOverhaul
        {
            get { return _lifelengthAircraftSinceOverhaul; }
            set { _lifelengthAircraftSinceOverhaul = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region public void AddDirectives(MaintenanceCheck[] directives)

        public void AddDirectives(MaintenanceCheck[] directives)
        {
            _reportedDirectives.Clear();
            _reportedDirectives.AddRange(directives);
            if (_reportedDirectives.Count == 0)
                return;

        }

        #endregion

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            MaintenanceProgramReport report = new MaintenanceProgramReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region public virtual MaintenanceProgramDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        public virtual MaintenanceProgramDataSet GenerateDataSet()
        {
            MaintenanceProgramDataSet dataset = new MaintenanceProgramDataSet();
            AddAircraftToDataset(dataset);
            AddDirectivesToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
            AddForecastToDataSet(dataset);
            return dataset;
        }

        #endregion

        #region protected virtual void AddDirectivesToDataSet(MaintenanceProgramDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        protected virtual void AddDirectivesToDataSet(MaintenanceProgramDataSet dataset)
        {
            List<MaintenanceCheck>checks = new List<MaintenanceCheck>(_reportedDirectives.ToArray());
            List<MaintenanceCheckGroupByType>groups = new List<MaintenanceCheckGroupByType>();
            int groupId = 0;
            
            var v = from liminationItem in checks
                    where liminationItem.Schedule == _filterSelection
                    group liminationItem by liminationItem.CheckType.FullName
                        into fileGroup
                        orderby fileGroup.Key
                        select fileGroup;
            foreach (IGrouping<string, MaintenanceCheck> grouping in v)
            {   
                MaintenanceCheckGroupByType g = new MaintenanceCheckGroupByType(_filterSelection);
                groups.Add(g);
                foreach (MaintenanceCheck liminationItem in grouping)
                {
                    g.Checks.Add(liminationItem);
                    liminationItem.Tag = groupId;
                    groupId++;
                }
            }

            groups.OrderBy(g => g.MinInterval());
            

            int min, max, countGroups;
            for (int i = 0; i < groups.Count; i++ )
            {
                if (_filterSelection)
                {
                    min = groups[i].MinInterval();
                    max = i != groups.Count - 1 ? groups[i + 1].MinInterval() : groups[i].MaxInterval();
                    //Вычисление количества групп выполнения для данного типа чеков (A,B or C)
                    countGroups = max / min;
                    //Вычисление интервала выполнения для каждой группы выполнения
                    //если интервал, на котором должен выполнится чек равени интервалу группы
                    //то чек посещается в даннуб группу выполнения
                    for(int j = 0; j < countGroups; j++)
                    {
                        int interval = min*(j + 1);
                        foreach (MaintenanceCheck liminationItem in groups[i].Checks)
                        {
                            if(interval%liminationItem.Interval.Hours== 0)
                                dataset.ItemsTable.AddItemsTableRow(interval, (int)liminationItem.Tag, liminationItem.Name, "X");      
                        }
                        if (i <= 0) continue;
                        //Если просматривается не базовая группа (groups[0])
                        //то в набор данных должны быть включены все предыдущие группы чеков
                        for (int k = 0; k < i; k++)
                        {
                            interval = min*(j + 1);
                            int localInterval = k != groups.Count - 1 ? groups[k + 1].MinInterval() : groups[k].MaxInterval();
                            foreach (MaintenanceCheck liminationItem in groups[k].Checks)
                            {
                                if (localInterval % liminationItem.Interval.Hours == 0)
                                    dataset.ItemsTable.AddItemsTableRow(interval, (int)liminationItem.Tag, liminationItem.Name, "X");
                                else dataset.ItemsTable.AddItemsTableRow(interval, (int)liminationItem.Tag, liminationItem.Name, "[X]");
                            }
                        }
                    }
                }
                else
                {
                    min = groups[i].MinInterval();
                    max = i != groups.Count - 1 ? groups[i + 1].MinInterval() : groups[i].MaxInterval();
                    //Вычисление количества групп выполнения для данного типа чеков (A,B or C)
                    countGroups = max / min;
                    //Вычисление интервала выполнения для каждой группы выполнения
                    //если интервал, на котором должен выполнится чек равен интервалу группы
                    //то чек посещается в данную группу выполнения
                    for (int j = 0; j < countGroups; j++)
                    {
                        int interval = min * (j + 1);

                        foreach (MaintenanceCheck liminationItem in groups[i].Checks)
                        {
                            if (interval % liminationItem.Interval.Days == 0)
                                dataset.ItemsTable.AddItemsTableRow(interval, (int)liminationItem.Tag, liminationItem.Name, "X");
                        }
                        if (i <= 0) continue;
                        //Если просматривается не базовая группа (groups[0])
                        //то в набор данных должны быть включены все предыдущие группы чеков
                        for (int k = 0; k < i; k++)
                        {
                            interval = min * (j + 1);
                            int localInterval = k != groups.Count - 1 ? groups[k + 1].MinInterval() : groups[k].MaxInterval();
                            foreach (MaintenanceCheck liminationItem in groups[k].Checks)
                            {
                                if (localInterval % liminationItem.Interval.Days == 0)
                                    dataset.ItemsTable.AddItemsTableRow(interval, (int)liminationItem.Tag, liminationItem.Name, "X");
                                else dataset.ItemsTable.AddItemsTableRow(interval, (int)liminationItem.Tag, liminationItem.Name, "[X]");
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region private void AddAircraftToDataset(MaintenanceProgramDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(MaintenanceProgramDataSet destinationDataSet)
        {
            if (_reportedAircraft == null)
                return;

            var reportAircraftLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);

            var manufactureDate = _reportedAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var serialNumber = ReportedAircraft.SerialNumber;
            var model = _reportedAircraft.Model.ToString();
            var sinceNewHours = reportAircraftLifeLenght.Hours != null ? (int)reportAircraftLifeLenght.Hours : 0;
            var sinceNewCycles = reportAircraftLifeLenght.Cycles != null ? (int)reportAircraftLifeLenght.Cycles : 0;
            var registrationNumber = ReportedAircraft.RegistrationNumber;
            int averageUtilizationHours;
            int averageUtilizationCycles;
            string averageUtilizationType;
            if (_forecastData == null)
            {
				var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(_reportedAircraft.AircraftFrameId);
				var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(aircraftFrame);

				averageUtilizationHours = (int)averageUtilization.Hours;
                averageUtilizationCycles = (int)averageUtilization.Cycles;
                averageUtilizationType = averageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";
            }
            else
            {
                averageUtilizationHours = (int)_forecastData.AverageUtilization.Hours;
                averageUtilizationCycles = (int)_forecastData.AverageUtilization.Cycles;
                averageUtilizationType =
                    _forecastData.AverageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";

            }

            var lineNumber = (ReportedAircraft).LineNumber;
            var variableNumber = (ReportedAircraft).VariableNumber;
            destinationDataSet.AircraftDataTable.AddAircraftDataTableRow(serialNumber,
                                                                         manufactureDate,
                                                                         sinceNewHours,
                                                                         sinceNewCycles,
                                                                         registrationNumber, model, lineNumber, variableNumber,
                                                                         averageUtilizationHours, averageUtilizationCycles, averageUtilizationType);
        }

        #endregion

        #region private void AddAdditionalDataToDataSet(MaintenanceProgramDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(MaintenanceProgramDataSet destinationDateSet)
        {
            string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, OperatorLogotype, _filterSelection?"Schedule":"Unschedule", DateAsOf, reportFooter, reportFooterPrepared, reportFooterLink);

        }

        #endregion

        #region protected virtual void AddForecastToDataSet(MaintenanceProgramDataSet destinationDataSet)

        protected virtual void AddForecastToDataSet(MaintenanceProgramDataSet destinationDataSet)
        {
            var avgUtilizationCycles = _forecastData != null ? _forecastData.AverageUtilization.Cycles : 0;
            var avgUtilizationHours = _forecastData != null ? _forecastData.AverageUtilization.Hours : 0;
            var avgUtilizationType = _forecastData != null
                                            ? _forecastData.AverageUtilization.SelectedInterval.ToString()
                                            : "";
            var forecastCycles = _forecastData != null
                ? _forecastData.ForecastLifelength.Cycles != null ? (int)_forecastData.ForecastLifelength.Cycles : 0
                : 0;
            var forecastHours = _forecastData != null
                ? _forecastData.ForecastLifelength.Hours != null ? (int)_forecastData.ForecastLifelength.Hours : 0
                : 0;
            var forecastDays = _forecastData != null
                ? _forecastData.ForecastLifelength.Days != null ? (int)_forecastData.ForecastLifelength.Days : 0
                : 0;
            var forecastDate = _forecastData != null
                ? _forecastData.ForecastDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString())
                : "";
            destinationDataSet.ForecastTable.AddForecastTableRow(avgUtilizationCycles,
                                                                 avgUtilizationHours,
                                                                 avgUtilizationType,
                                                                 forecastCycles,
                                                                 forecastHours,
                                                                 forecastDays,
                                                                 forecastDate);
        }

        #endregion

        #endregion

    }
}