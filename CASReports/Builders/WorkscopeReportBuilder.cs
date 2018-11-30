using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Auxiliary;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;

namespace CASReports.Builders
{
    public class WorkscopeReportBuilder : AbstractReportBuilder
    {

        #region Fields

        private string _reportTitle = "WORK SCOPE";
        private string _filterSelection;
        private byte[] _operatorLogotype;
        private Aircraft _reportedAircraft;
        private BaseComponent _reportedBaseComponent;
        private WorkPackage _workPackage;
        private List<BaseEntityObject> _reportedDirectives = new List<BaseEntityObject>();

        private Forecast _forecast;
        private string _dateAsOf = "";

        #endregion

        #region Properties

        #region public Aircraft ReportedAircraft

        /// <summary>
        /// ВС включаемыое в отчет
        /// </summary>
        public Aircraft ReportedAircraft
        {
            set
            {
                _reportedAircraft = value;
                if (value == null) return;
                _reportedBaseComponent = GlobalObjects.ComponentCore.GetBaseComponentById(value.AircraftFrameId);
                _operatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogotypeReportLarge;
            }
        }

        #endregion

        #region public BaseDetail ReportedBaseDetail

        /// <summary>
        /// Базовый агрегат, включаемый в отчет
        /// </summary>
        public BaseComponent ReportedBaseComponent
        {
            set
            {
                if (value == null) return;
                _reportedBaseComponent = value;
                _operatorLogotype = GlobalObjects.CasEnvironment.Operators[0].LogotypeReportLarge;
                _reportedDirectives.Clear();
            }
        }

        #endregion

        #region public List<BaseEntityObject> ReportedDirectives

        /// <summary>
        /// Директивы включаемые в отчет
        /// </summary>
        public List<BaseEntityObject> ReportedDirectives
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

        #region public Forecast Forecast

        public Forecast Forecast
        {
            set { _forecast = value; }
        }
        #endregion

        #region public CommonFilterCollection ReportTitle

        /// <summary>
        /// Текст фильтра отчета
        /// </summary>
        public CommonFilterCollection FilterSelection
        {
            set { GetFilterSelection(value); }
        }

        #endregion

        #region public Aircraft ReportedAircraft

        /// <summary>
        /// Рабочий пакет по которому строится workscope
        /// </summary>
        public WorkPackage WorkPackage
        {
            set
            {
                _workPackage = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region protected virtual void GetFilterSelection(CommonFilterCollection filterCollection)
        protected virtual void GetFilterSelection(CommonFilterCollection filterCollection)
        {
            if (_reportedAircraft != null)
            {
                _filterSelection = "All";
                if (filterCollection == null || filterCollection.IsEmpty) 
                    return;
                _filterSelection = filterCollection.ToStrings();
            }
            else
            {
                if (_reportedBaseComponent != null)
                {
                    _filterSelection = "All";
                    if (filterCollection == null) return;
                    if (_reportedBaseComponent.BaseComponentType == BaseComponentType.LandingGear)
                        _filterSelection = _reportedBaseComponent.TransferRecords.GetLast().Position;
                    if (_reportedBaseComponent.BaseComponentType == BaseComponentType.Engine)
                        _filterSelection = BaseComponentType.Engine + " " + _reportedBaseComponent.TransferRecords.GetLast().Position;
                    if (_reportedBaseComponent.BaseComponentType == BaseComponentType.Apu)
                        _filterSelection = BaseComponentType.Apu.ToString();
                }
                else
                {
                    _filterSelection = "All";
                }
            }

        }
        #endregion

        #region public void AddDirectives(IEnumerable<BaseEntityObject> directives)

        public void AddDirectives(IEnumerable<BaseEntityObject> directives)
        {
            _reportedDirectives.Clear();
            _reportedDirectives.AddRange(directives);
            if (_reportedDirectives.Count == 0)
                return;

        }

        #endregion

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерировать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            WorkscopeReport report = new WorkscopeReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region protected virtual DataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        protected virtual DataSet GenerateDataSet()
        {
            WorkscopeDataSet dataset = new WorkscopeDataSet();
            AddAircraftToDataset(dataset);
            AddDirectivesToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
            AddForecastToDataSet(dataset);
            return dataset;
        }

        #endregion

        #region protected virtual void AddDirectivesToDataSet(WorkscopeDataSet dataset)
        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        protected virtual void AddDirectivesToDataSet(WorkscopeDataSet dataset)
        {
            foreach (BaseEntityObject t in _reportedDirectives)
            {
                AddDirectiveToDataset(t, dataset);
            }
        }
        #endregion

        #region private void AddAircraftToDataset(WorkscopeDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(WorkscopeDataSet destinationDataSet)
        {
            if (_reportedAircraft == null)
                return;

            Lifelength reportAircraftLifeLenght =
                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);

            var manufactureDate = _reportedAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var serialNumber = _reportedAircraft.SerialNumber;
            var model = _reportedAircraft.Model.ShortName;
            var sinceNewHours = reportAircraftLifeLenght.Hours != null ? (int)reportAircraftLifeLenght.Hours : 0;
            var sinceNewCycles = reportAircraftLifeLenght.Cycles != null ? (int)reportAircraftLifeLenght.Cycles : 0;
            var registrationNumber = _reportedAircraft.RegistrationNumber;
            int averageUtilizationHours;
            int averageUtilizationCycles;
            string averageUtilizationType;
            if (_forecast == null)
            {
				var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(_reportedAircraft.AircraftFrameId);
				var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(aircraftFrame);

				averageUtilizationHours = (int)averageUtilization.Hours;
                averageUtilizationCycles = (int)averageUtilization.Cycles;
                averageUtilizationType = averageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";
            }
            else
            {
                averageUtilizationHours = (int)_forecast.ForecastDatas[0].AverageUtilization.Hours;
                averageUtilizationCycles = (int)_forecast.ForecastDatas[0].AverageUtilization.Cycles;
                averageUtilizationType =
                   _forecast.ForecastDatas[0].AverageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";

            }

            var lineNumber = _reportedAircraft.LineNumber;
            var variableNumber = _reportedAircraft.VariableNumber;
            destinationDataSet.AircraftDataTable.AddAircraftDataTableRow(serialNumber,
                                                                         manufactureDate,
                                                                         sinceNewHours,
                                                                         sinceNewCycles,
                                                                         registrationNumber, model, lineNumber, variableNumber,
                                                                         averageUtilizationHours, averageUtilizationCycles, averageUtilizationType);
        }

        #endregion

        #region public void AddDirectiveToDataset(BaseEntityObject directive, DefferedListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="item">Добавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddDirectiveToDataset(BaseEntityObject item, WorkscopeDataSet destinationDataSet)
        {
            if(item == null)
                return;

            string status;
            string applicabilityString;
            string hiddenRemarks;
            string description;
            string itemString;
            string lastPerformanceString;
            string nextPerformanceString;
            string conditionString;
            string zone;
            string ataShort;
            string ataFull;
            string taskCardNumber;
            string programmString;
            string maintenanceCheckString;
            string remarks;
            string directiveType;
            double cost;
            double mh;
            string effectivityDate;
            string kits;
            string remainString;
            string firstPerformanceString;
            string repeatPerformanceToString;

            IBaseEntityObject parent;
            if (item is NextPerformance) 
                parent = ((NextPerformance)item).Parent;
            else if (item is AbstractPerformanceRecord)
                parent = ((AbstractPerformanceRecord)item).Parent;
            else parent = item;

            if(parent == null)
                return;

            if (parent is Directive)
            {
                Directive directive = (Directive)parent;
                status = directive.Status.ToString();
                lastPerformanceString = directive.LastPerformance != null ? directive.LastPerformance.ToStrings() : "";
                nextPerformanceString = directive.NextPerformance != null ? directive.NextPerformance.ToStrings() : "";
                conditionString = directive.Condition.ToString();
                zone = "";
                programmString = "";
                maintenanceCheckString = "N/A";
                remarks = "";
                directiveType = directive.WorkType.ToString();
                cost = directive.Cost;
                mh = directive.ManHours;
                effectivityDate = UsefulMethods.NormalizeDate(directive.Threshold.EffectiveDate);
                kits = directive.Kits != null && directive.Kits.Count > 0 ? directive.Kits.Count + " kits" : "";
                firstPerformanceString = directive.Threshold.FirstPerformanceToStrings();
                repeatPerformanceToString = directive.Threshold.RepeatPerformanceToStrings();
                remainString = directive.Remains.ToString();

                StringBuilder stringBuilder = new StringBuilder();
                applicabilityString = directive.Applicability;
                hiddenRemarks = directive.HiddenRemarks;
                description = directive.Description;

                stringBuilder.AppendLine(directive.DirectiveType.ShortName);
                stringBuilder.AppendLine(directive.Title);
                if (!string.IsNullOrEmpty(directive.Paragraph))
                    stringBuilder.AppendLine("\n§ " + directive.Paragraph);
                AtaChapter ata = directive.ATAChapter;
                ataShort = ata.ShortName;
                ataFull = ata.ToString();
                taskCardNumber = directive.EngineeringOrders;
                stringBuilder.AppendLine(directive.EngineeringOrders);

                itemString = stringBuilder.ToString();
            }
            else if (parent is BaseComponent)
            {
                var bd = (BaseComponent)parent;
                var ata = bd.ATAChapter ?? (AtaChapter)GlobalObjects.CasEnvironment.GetDictionary<AtaChapter>().GetItemById(-1);

                ataShort = ata.ShortName;
                ataFull = ata.ToString();

                applicabilityString = "";
                hiddenRemarks = bd.HiddenRemarks;
                description = "";
                status = "";
                lastPerformanceString = "";
                nextPerformanceString = bd.NextPerformance != null ? bd.NextPerformance.ToStrings() : "";
                conditionString = bd.Condition.ToString();
                zone = "";
                programmString = "";
                maintenanceCheckString = "N/A";
                remarks = bd.Remarks;
                directiveType = MaintenanceDirectiveTaskType.Discard.ToString();
                cost = bd.Cost;
                mh = bd.ManHours;
                effectivityDate = UsefulMethods.NormalizeDate(bd.Threshold.EffectiveDate);
                taskCardNumber = "";
                kits = bd.Kits != null && bd.Kits.Count > 0 ? bd.Kits.Count + " kits" : "";
                firstPerformanceString = bd.Threshold.FirstPerformanceToStrings();
                repeatPerformanceToString = bd.Threshold.RepeatPerformanceToStrings();
                remainString = bd.Remains.ToString();

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Compnt.");
                stringBuilder.AppendLine(bd.PartNumber);
                stringBuilder.AppendLine(bd.Description);

                itemString = stringBuilder.ToString();
            }
            else if (parent is Component)
            {
                var d = (Component)parent;
                var ata = d.ATAChapter ?? (AtaChapter)GlobalObjects.CasEnvironment.GetDictionary<AtaChapter>().GetItemById(-1);

                ataShort = ata.ShortName;
                ataFull = ata.ToString();

                applicabilityString = "";
                hiddenRemarks = d.HiddenRemarks;
                description = d.Description;
                status = "";
                lastPerformanceString = "";
                nextPerformanceString = d.NextPerformance != null ? d.NextPerformance.ToStrings() : "";
                conditionString = d.Condition.ToString();
                zone = "";
                programmString = "";
                maintenanceCheckString = "N/A";
                remarks = d.Remarks;
                directiveType = MaintenanceDirectiveTaskType.Discard.ToString();
                cost = d.Cost;
                mh = d.ManHours;
                effectivityDate = UsefulMethods.NormalizeDate(d.Threshold.EffectiveDate);
                taskCardNumber = "";
                kits = d.Kits != null && d.Kits.Count > 0 ? d.Kits.Count + " kits" : "";
                firstPerformanceString = d.Threshold.FirstPerformanceToStrings();
                repeatPerformanceToString = d.Threshold.RepeatPerformanceToStrings();
                remainString = d.Remains.ToString();

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Compnt.");
                stringBuilder.AppendLine("P/N:" + d.PartNumber);
                stringBuilder.AppendLine("S/N:" + d.SerialNumber);

                itemString = stringBuilder.ToString();
            }
            else if (parent is ComponentDirective)
            {
                var dd = (ComponentDirective)parent;
                var ata = dd.ParentComponent.ATAChapter ?? (AtaChapter)GlobalObjects.CasEnvironment.GetDictionary<AtaChapter>().GetItemById(-1);

                ataShort = ata.ShortName;
                ataFull = ata.ToString();

                applicabilityString = "";
                hiddenRemarks = dd.HiddenRemarks;
                description = "";
                status = dd.Status.ToString();
                lastPerformanceString = dd.LastPerformance != null ? dd.LastPerformance.ToStrings() : "";
                nextPerformanceString = dd.NextPerformance != null ? dd.NextPerformance.ToStrings() : "";
                conditionString = dd.Condition.ToString();
                zone = "";
                programmString = "";
                maintenanceCheckString = "N/A";
                remarks = dd.Remarks;
                directiveType = dd.DirectiveType.ToString();
                cost = dd.Cost;
                mh = dd.ManHours;
                effectivityDate = UsefulMethods.NormalizeDate(dd.Threshold.EffectiveDate);
                taskCardNumber = "";
                kits = dd.Kits != null && dd.Kits.Count > 0 ? dd.Kits.Count + " kits" : "";
                firstPerformanceString = dd.Threshold.FirstPerformanceToStrings();
                repeatPerformanceToString = dd.Threshold.RepeatPerformanceToStrings();
                remainString = dd.Remains.ToString();

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Compnt.");
                if(dd.ParentComponent != null)
                {
                    Component d = dd.ParentComponent;
                    stringBuilder.AppendLine("P/N:" + d.PartNumber);
                    stringBuilder.AppendLine("S/N:" + d.SerialNumber);

                    description = d.Description;
                }
                itemString = stringBuilder.ToString();
            }
            else if (parent is MaintenanceCheck)
            {
                return;
                //MaintenanceCheck mc = (MaintenanceCheck)parent;

                //AtaChapter ata = (AtaChapter)GlobalObjects.CasEnvironment.Dictionaries[typeof(AtaChapter)].GetItemById(-1);
                //ataShort = ata.ShortName;
                //ataFull = ata.ToString();

                //applicabilityString = "";
                //hiddenRemarks = "";
                //description = "";
                //status = "";
                //lastPerformanceString = mc.LastPerformance != null ? mc.LastPerformance.ToStrings() : "";
                //nextPerformanceString = mc.NextPerformance != null ? mc.NextPerformance.ToStrings() : "";
                //conditionString = mc.Condition.ToString();
                //zone = "";
                //programmString = "";
                //maintenanceCheckString = "";
                //remarks = "";
                //directiveType = "";
                //cost = mc.Cost;
                //mh = mc.ManHours;
                //effectivityDate = UsefulMethods.NormalizeDate(mc.Threshold.EffectiveDate);
                //taskCardNumber = "";
                //kits = mc.Kits != null && mc.Kits.Count > 0 ? mc.Kits.Count + " kits" : "";
                //firstPerformanceString = mc.Threshold.FirstPerformanceToStrings();
                //repeatPerformanceToString = mc.Threshold.RepeatPerformanceToStrings();
                //remainString = mc.Remains.ToString();

                //StringBuilder stringBuilder = new StringBuilder();
                //stringBuilder.AppendLine("Check");
                //stringBuilder.AppendLine(mc.ToString());

                //itemString = stringBuilder.ToString();
            }
            else if (parent is MaintenanceDirective)
            {
                MaintenanceDirective md = (MaintenanceDirective)parent;

                AtaChapter ata = md.ATAChapter;
                ataShort = ata.ShortName;
                ataFull = ata.ToString();

                applicabilityString = md.Applicability;
                hiddenRemarks = md.HiddenRemarks;
                description = md.Description;
                status = md.Status.ToString();
                lastPerformanceString = md.LastPerformance != null ? md.LastPerformance.ToStrings() : "";
                nextPerformanceString = md.NextPerformance != null ? md.NextPerformance.ToStrings() : "";
                conditionString = md.Condition?.ToString();
                zone = md.Zone;
                programmString = md.Program.ToString();
                
                if(md.MaintenanceCheck != null)
                    maintenanceCheckString = md.MaintenanceCheck.ToString();
                else if(_workPackage != null)
                {
                    MaintenanceCheckBindTaskRecord record =
                        _workPackage.MaintenanceCheckBindTaskRecords.FirstOrDefault(br => br.TaskType == SmartCoreType.MaintenanceDirective
                                                                                       && br.TaskId == md.ItemId);
                    if(record != null)
                        maintenanceCheckString = record.ParentCheck != null ? record.ParentCheck.ToString() : "N/A";
                    else maintenanceCheckString = "N/A";
                }
                else maintenanceCheckString = "N/A";

                remarks = md.Remarks;
                directiveType = md.WorkType.ToString();
                cost = md.Cost;
                mh = md.ManHours;
                effectivityDate = UsefulMethods.NormalizeDate(md.Threshold.EffectiveDate);
                taskCardNumber = md.TaskCardNumber;
                kits = md.Kits != null && md.Kits.Count > 0 ? md.Kits.Count + " kits" : "";
                firstPerformanceString = md.Threshold.FirstPerformanceToStrings();
                repeatPerformanceToString = md.Threshold.RepeatPerformanceToStrings();
                remainString = md.Remains.ToString();

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("MPD");
                stringBuilder.AppendLine(md.TaskNumberCheck);
                stringBuilder.AppendLine(md.TaskCardNumber);

                itemString = stringBuilder.ToString();
            }
            else if (parent is NonRoutineJob)
            {
                NonRoutineJob job = (NonRoutineJob)parent;

                AtaChapter ata = job.ATAChapter;
                ataShort = ata.ShortName;
                ataFull = ata.ToString();

                applicabilityString = "";
                hiddenRemarks = "";
                description = job.Description;
                status = "";
                lastPerformanceString = "";
                nextPerformanceString = "";
                conditionString = job.Condition.ToString();
                zone = "";
                programmString = "";
                maintenanceCheckString = "N/A";
                remarks = "";
                directiveType = "";
                cost = job.Cost;
                mh = job.ManHours;
                effectivityDate = "";
                taskCardNumber = "";
                kits = job.Kits != null && job.Kits.Count > 0 ? job.Kits.Count + " kits" : "";
                firstPerformanceString = "";
                repeatPerformanceToString = "";
                remainString = job.Remains.ToString();

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("NRC");
                stringBuilder.AppendLine(job.Title);

                itemString = stringBuilder.ToString();
            }
            else return;

            destinationDataSet.ItemsTable.AddItemsTableRow(applicabilityString,
                                                           remarks,
                                                           hiddenRemarks,
                                                           description,
                                                           itemString,
                                                           "",
                                                           directiveType,
                                                           status,
                                                           effectivityDate,
                                                           firstPerformanceString,
                                                           lastPerformanceString,
                                                           nextPerformanceString,
                                                           remainString,
                                                           conditionString,
                                                           mh,
                                                           cost,
                                                           kits,
                                                           zone,
                                                           ataShort,
                                                           ataFull,
                                                           taskCardNumber,
                                                           programmString,
                                                           repeatPerformanceToString,
                                                           "",
                                                           maintenanceCheckString);
        }

        #endregion

        #region private void AddAdditionalDataToDataSet(WorkscopeDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(WorkscopeDataSet destinationDateSet)
        {
            string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, _filterSelection, _dateAsOf, reportFooter, reportFooterPrepared, reportFooterLink);
        }

        #endregion

        #region protected virtual void AddForecastToDataSet(WorkscopeDataSet destinationDataSet)

        protected virtual void AddForecastToDataSet(WorkscopeDataSet destinationDataSet)
        {
            ForecastData fd = _forecast != null ? _forecast.GetForecastDataFrame() : null;
            double avgUtilizationCycles = fd != null ? fd.AverageUtilization.Cycles : 0;
            double avgUtilizationHours = fd != null ? fd.AverageUtilization.Hours : 0;
            string avgUtilizationType = fd != null
                                            ? fd.AverageUtilization.SelectedInterval.ToString()
                                            : "";
            int forecastCycles = fd != null
                ? fd.ForecastLifelength.Cycles != null
                    ? (int)fd.ForecastLifelength.Cycles
                    : 0
                : 0;
            int forecastHours = fd != null
                ? fd.ForecastLifelength.Hours != null
                    ? (int)fd.ForecastLifelength.Hours
                    : 0
                : 0;
            int forecastDays = fd != null
                ? fd.ForecastLifelength.Days != null
                    ? (int)fd.ForecastLifelength.Days
                    : 0
                : 0;
            string forecastDate = _forecast != null
                ? _forecast.ForecastDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString())
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