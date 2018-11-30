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
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using TempUIExtentions;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчетов по ВС
    /// </summary>
    public class AircraftTechnicalConditionReportBuilder : AbstractReportBuilder
    {

        #region Fields

        private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
        private Aircraft _reportedAircraft;
        private string _dateAsOf = "";

        private readonly MaintenanceCheck _minCCheck;

        private readonly MaintenanceCheckRecord _lastCСheckRecord;
        private readonly MaintenanceCheckRecord _lastACheckRecord;

        //readonly AllDirectiveFilter defaultFilter = new AllDirectiveFilter();
        private string _reportTitle = "AIRCRAFT GENERAL DATA";
        private byte[] _operatorLogotype;

        private Lifelength _lifelengthAircraftSinceNew;

        private readonly IEnumerable<WorkPackage> _workPackages;

        private readonly IEnumerable<BaseComponent> _aircraftBaseDetails;

        private readonly int _countDCheckPerformances;

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
                OperatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogoTypeWhite;
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

        #endregion

        #region Constructor

        /// <summary>
        /// Создается построитель отчета Operation Time
        /// </summary>
        /// <param name="aircraft">ВС</param>
        /// <param name="minCCheck"></param>
        /// <param name="aircraftBaseDetails"></param>
        /// <param name="lastACheckRecord"></param>
        /// <param name="lastCCheckRecord"></param>
        /// <param name="workPackages"></param>
        /// <param name="countDCheckPerformances"></param>
        public AircraftTechnicalConditionReportBuilder(Aircraft aircraft, 
                                                       MaintenanceCheck minCCheck, 
                                                       IEnumerable<BaseComponent> aircraftBaseDetails,
                                                       MaintenanceCheckRecord lastACheckRecord,
                                                       MaintenanceCheckRecord lastCCheckRecord,
                                                       IEnumerable<WorkPackage> workPackages,
                                                       int countDCheckPerformances)
        {
            _reportedAircraft = aircraft;
            _minCCheck = minCCheck;
            _aircraftBaseDetails = aircraftBaseDetails;
            _lastACheckRecord = lastACheckRecord;
            _lastCСheckRecord = lastCCheckRecord;
            _workPackages = workPackages;
            _countDCheckPerformances = countDCheckPerformances;
        }

        #endregion

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            AircraftTechnicalConditionReport report = new AircraftTechnicalConditionReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region public virtual AircraftTechicalConditionDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        protected virtual AircraftTechicalConditionDataSet GenerateDataSet()
        {
            AircraftTechicalConditionDataSet dataset = new AircraftTechicalConditionDataSet();
            AddAircraftToDataset(dataset);
            AddBaseDetailToDataset(dataset);
            AddChecksToDataset(dataset);
            AddAdditionalDataToDataSet(dataset);
            return dataset;
        }

        #endregion

        #region private void AddAircraftToDataset(AircraftTechicalConditionDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(AircraftTechicalConditionDataSet destinationDataSet)
        {
            if (_reportedAircraft == null)
                return;

            var reportAircraftLifeLenght =
                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);

            var lifeLimit = GlobalObjects.ComponentCore.GetBaseComponentById(_reportedAircraft.AircraftFrameId).LifeLimit;
            var lifeLimitHours = lifeLimit.Hours != null ? lifeLimit.Hours.ToString() : "--";
            var lifeLimitCycles = lifeLimit.Cycles != null ? lifeLimit.Cycles.ToString() : "--";
            var lifeLimitDays = lifeLimit.Days != null ? lifeLimit.Days.ToString() : "--";
            var remain = Lifelength.Null;
            if (!lifeLimit.IsNullOrZero())
            {
                remain = lifeLimit - reportAircraftLifeLenght;
                remain.Resemble(lifeLimit);
            }
            var remainHours = remain.Hours != null ? remain.Hours.ToString() : "--";
            var remainCycles = remain.Cycles != null ? remain.Cycles.ToString() : "--";
            var remainDays = remain.Days != null ? remain.Days.ToString() : "--";
 
            var ohIntervalHours = "";
            var ohIntervalCycles = "";
            var ohIntervalCalendar = "";
            if(_minCCheck != null)
            {
                ohIntervalHours = _minCCheck.Interval.TotalMinutes != null ? _minCCheck.Interval.Hours.ToString() : "--";
                ohIntervalCycles = _minCCheck.Interval.Cycles != null ? _minCCheck.Interval.Cycles.ToString() : "--";
                ohIntervalCalendar = _minCCheck.Interval.CalendarValue != null ? _minCCheck.Interval.CalendarSpan.Years.ToString() : "--";            
            }

            var sinceLastCCheckHours = "--";
            var sinceLastCCheckCycles = "--";
            var sinceLastCCheckCalendar = "--";
            var lastOHCheckDate = "";
            var lastOHStation = "";
            var lastOHType = "";
            var ohRemainHours = "";
            var ohRemainCycles = "";
            var ohRemainCalendar = "";
            if(_lastCСheckRecord != null)
            {
                if (_lastCСheckRecord.DirectivePackage == null)
                    _lastCСheckRecord.DirectivePackage = _workPackages != null
                                          ? _workPackages.FirstOrDefault(wp => wp.ItemId == _lastCСheckRecord.DirectivePackageId)
                                          : null;
                lastOHStation = _lastCСheckRecord.DirectivePackage != null
                    ? _lastCСheckRecord.DirectivePackage.Station + "."
                    : "";

                lastOHCheckDate = _lastCСheckRecord.RecordDate.ToString("d.M.yyyy");
                lastOHType = _lastCСheckRecord.ParentCheck.CheckType.ToString();
                Lifelength sinceLast =  reportAircraftLifeLenght - _lastCСheckRecord.OnLifelength;
                if(_minCCheck != null)
                {
                    sinceLast.Resemble(_minCCheck.Interval);
                    Lifelength ohRemains = _minCCheck.Interval - sinceLast;
                    ohRemainHours = ohRemains.TotalMinutes != null ? ohRemains.Hours.ToString() : "--";
                    ohRemainCycles = ohRemains.Cycles != null ? ohRemains.Cycles.ToString() : "--";
                    ohRemainCalendar = ohRemains.CalendarValue != null ? ohRemains.CalendarSpan.Years.ToString() : "--";
                }
                sinceLastCCheckHours = sinceLast.TotalMinutes != null ? sinceLast.Hours.ToString() : "--";
                sinceLastCCheckCycles = sinceLast.Cycles != null ? sinceLast.Cycles.ToString() : "--";
                sinceLastCCheckCalendar = sinceLast.CalendarValue != null ? sinceLast.CalendarSpan.Years.ToString() : "--";
            }

            var manufactureDate = _reportedAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var sinceNewHours = reportAircraftLifeLenght.Hours != null ? (int)reportAircraftLifeLenght.Hours : 0;
            var sinceNewCycles = reportAircraftLifeLenght.Cycles != null ? (int)reportAircraftLifeLenght.Cycles : 0;
            var sinceNewCalendar = reportAircraftLifeLenght.Days != null ? reportAircraftLifeLenght.CalendarSpan.Years.ToString() : "--";

            var powerPlantsModelsString = "";
            var powerPlantsModels =
                _aircraftBaseDetails.Where(bd => (bd.BaseComponentType == BaseComponentType.Engine ||
                                                  bd.BaseComponentType == BaseComponentType.Apu) &&
                                                  bd.Model != null)
                                    .Select(bd => bd.Model)
                                    .Distinct(new ComponentModelStringComparer())
                                    .ToList();
            for (int i = 0; i < powerPlantsModels.Count(); i++)
            {
                var model = powerPlantsModels[i].ToString();
                if(string.IsNullOrEmpty(model))
                    continue;
                if (powerPlantsModelsString != "" && i > 0)
                    powerPlantsModelsString += "/";
                powerPlantsModelsString += model;
            }
            destinationDataSet.AircraftDataTable.AddAircraftDataTableRow(_reportedAircraft.SerialNumber,
                                                                         manufactureDate,
                                                                         sinceNewHours,
                                                                         sinceNewCycles,
                                                                         _reportedAircraft.RegistrationNumber,
                                                                         _reportedAircraft.Model.ToString(),
                                                                         _reportedAircraft.LineNumber,
                                                                         _reportedAircraft.VariableNumber,
                                                                         lifeLimitHours,
                                                                         lifeLimitCycles, 
                                                                         lifeLimitDays,
                                                                         remainHours,
                                                                         remainCycles,
                                                                         remainDays,
                                                                         lastOHCheckDate,
                                                                         lastOHStation,
                                                                         lastOHType,
                                                                         ohIntervalHours,
                                                                         ohIntervalCycles,
                                                                         ohIntervalCalendar,
                                                                         ohRemainHours,
                                                                         ohRemainCycles,
                                                                         ohRemainCalendar,
                                                                         sinceNewCalendar,
                                                                         sinceLastCCheckHours,
                                                                         sinceLastCCheckCycles,
                                                                         sinceLastCCheckCalendar,
                                                                         _countDCheckPerformances > 0 ? _countDCheckPerformances.ToString() : "",
                                                                         powerPlantsModelsString);
        }

        #endregion

        #region private void AddBaseDetailToDataset(AircraftTechicalConditionDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddBaseDetailToDataset(AircraftTechicalConditionDataSet destinationDataSet)
        {
            if (_reportedAircraft == null) return;
            
            int engineNum = 1;
            
            foreach (BaseComponent baseDetail in _aircraftBaseDetails.Where(bd => bd.BaseComponentType == BaseComponentType.Engine ||
                                                                               bd.BaseComponentType == BaseComponentType.Apu))
            {
                if(baseDetail.BaseComponentType == BaseComponentType.Frame)continue;

                string position = "";
                if (baseDetail.BaseComponentType == BaseComponentType.Engine)
                {
                    position = engineNum.ToString();
                    engineNum ++;
                }
                else if (baseDetail.BaseComponentType == BaseComponentType.Apu)
                {
                    position = "ВСУ";
                }
                Lifelength currentDetailSource =
                    GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseDetail);

                string status = baseDetail.Serviceable ? "Serviceable" : "Unserviceable";
                string sinceNewHours = currentDetailSource.Hours != null ?currentDetailSource.Hours.ToString() : "";
                string sinceNewCycles = currentDetailSource.Cycles != null ? currentDetailSource.Cycles.ToString() : "";
                string sinceNewDays = currentDetailSource.Days != null ? currentDetailSource.Days.ToString() : "";

                Lifelength lifeLimit = baseDetail.LifeLimit;
                string lifeLimitHours = lifeLimit.Hours != null ? lifeLimit.Hours.ToString() : "";
                string lifeLimitCycles = lifeLimit.Cycles != null ? lifeLimit.Cycles.ToString() : "";
                string lifeLimitDays = lifeLimit.Days != null ? lifeLimit.Days.ToString() : "";
                Lifelength remain = Lifelength.Null;
                if (!lifeLimit.IsNullOrZero())
                {
                    remain = new Lifelength(lifeLimit);
                    remain.Substract(currentDetailSource);
                    remain.Resemble(lifeLimit);
                }  
                string remainHours = remain.Hours != null ? remain.Hours.ToString() : "";
                string remainCycles = remain.Cycles != null ? remain.Cycles.ToString() : "";
                string remainDays = remain.Days != null ? remain.Days.ToString() : "";    

                Lifelength betweenOverhaul = Lifelength.Null, lastCompliance = Lifelength.Null;
                DateTime lastOverhaulDate = DateTime.MinValue;

                string lastOverhaulDateString = "", lastOverhaulHours = "", lastOverhaulCycles = "";
                string remainOverhaulDays = "", remainOverhaulHours = "", remainOverhaulCycles = "";
                string type = "";

				if (baseDetail.BaseComponentType == BaseComponentType.LandingGear)type = "Part C: Landing Gears";
                if (baseDetail.BaseComponentType == BaseComponentType.Engine) type = "Part B: Engines";
                if (baseDetail.BaseComponentType == BaseComponentType.Apu) type = "Part D: Auxiliary Power Unit ";

                #region поиск последнего ремонта и расчет времени, прошедшего с него
                //поиск директив деталей
                List<ComponentDirective> directives = GlobalObjects.ComponentCore.GetComponentDirectives(baseDetail, true);
                //поиск директивы ремонта
                List<ComponentDirective> overhauls =
                    directives.Where(d => d.DirectiveType == ComponentRecordType.Overhaul).ToList();
                //поиск последнего ремонта
                if(overhauls.Count!= 0)
                {
                    ComponentDirective lastOverhaul = null;
                    foreach (ComponentDirective d in overhauls)
                    {
                        if (d.LastPerformance == null || d.LastPerformance.RecordDate <= lastOverhaulDate) continue;

                        lastOverhaulDate = d.LastPerformance.RecordDate;
                        lastOverhaul = d;
                    }

                    if(lastOverhaul != null)
                    {
                        betweenOverhaul = lastOverhaul.Threshold.RepeatInterval;
                        lastOverhaulDateString = lastOverhaulDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
                        lastOverhaulHours = lastOverhaul.LastPerformance.OnLifelength.Hours != null
                                                ? lastOverhaul.LastPerformance.OnLifelength.Hours.ToString()
                                                : "";
                        lastOverhaulCycles = lastOverhaul.LastPerformance.OnLifelength.Cycles != null
                                                ? lastOverhaul.LastPerformance.OnLifelength.Cycles.ToString()
                                                : "";
                        if (lastOverhaul.NextPerformance != null)
                        {
                            NextPerformance np = lastOverhaul.NextPerformance;
                            remainOverhaulHours = np.Remains.Hours != null ? np.Remains.Hours.ToString() : "";
                            remainOverhaulCycles = np.Remains.Cycles != null ? np.Remains.Cycles.ToString() : "";
                            remainOverhaulDays = np.Remains.Days != null ? np.Remains.Days.ToString() : "";
                        }

                        GlobalObjects.PerformanceCalculator.GetNextPerformance(lastOverhaul);
                        if (lastOverhaul.NextPerformanceDate != null)
                        {
                            remainOverhaulHours = lastOverhaul.Remains.Hours != null ? lastOverhaul.Remains.Hours.ToString() : "";
                            remainOverhaulCycles = lastOverhaul.Remains.Cycles != null ? lastOverhaul.Remains.Cycles.ToString() : "";
                            remainOverhaulDays = lastOverhaul.Remains.Days != null ? lastOverhaul.Remains.Days.ToString() : "";
                        }

                    }
                    else
                    {
                        betweenOverhaul = overhauls[0].Threshold.RepeatInterval;
                    }
                }
                
                ComponentDirective lastPerformance = directives.Where(d => d.LastPerformance != null).
                    OrderBy(d => d.LastPerformance.RecordDate).LastOrDefault();
                if(lastPerformance != null)
                {
                    lastCompliance.Add(currentDetailSource);
                    lastCompliance.Substract(lastPerformance.LastPerformance.OnLifelength);
                }
                #endregion

                destinationDataSet.BaseDetailTable.AddBaseDetailTableRow(baseDetail.PartNumber,
                                                                         baseDetail.SerialNumber,
                                                                         baseDetail.Model != null ? baseDetail.Model.ToString() : "",
                                                                         type,
																		 baseDetail.GetParentAircraftRegNumber(),
																		 position,
                                                                         status,
                                                                         lifeLimitHours,
                                                                         lifeLimitCycles,
                                                                         lifeLimitDays,
                                                                         sinceNewHours,
                                                                         sinceNewCycles,
                                                                         sinceNewDays,
                                                                         remainCycles,
                                                                         remainHours,
                                                                         remainDays,
                                                                         lastOverhaulDateString,
                                                                         lastOverhaulHours,
                                                                         lastOverhaulCycles,
                                                                         betweenOverhaul.Days != null ? betweenOverhaul.Days.ToString() : "",
                                                                         betweenOverhaul.Hours != null ? betweenOverhaul.Hours.ToString() : "",
                                                                         betweenOverhaul.Cycles != null ? betweenOverhaul.Hours.ToString() : "",
                                                                         remainOverhaulDays,
                                                                         remainOverhaulHours,
                                                                         remainOverhaulCycles,
                                                                         lastCompliance.Days != null ? lastCompliance.Days.ToString() : "",
                                                                         lastCompliance.Hours != null ? lastCompliance.Hours.ToString() : "",
                                                                         lastCompliance.Cycles != null ? lastCompliance.Hours.ToString() : "",
                                                                         baseDetail.ManufactureDate.ToString("dd.MM.yyyy"));   
            }
        }

        #endregion

        #region private void AddChecksToDataset(AircraftTechicalConditionDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddChecksToDataset(AircraftTechicalConditionDataSet destinationDataSet)
        {
            if (_reportedAircraft == null || _lastACheckRecord == null)
                return;

            if (_lastACheckRecord.DirectivePackage == null)
                _lastACheckRecord.DirectivePackage = _workPackages != null
                                      ? _workPackages.FirstOrDefault(wp => wp.ItemId == _lastACheckRecord.DirectivePackageId)
                                      : null;

            string checkName;
            string station = "--";
            if (_lastACheckRecord.DirectivePackage != null)
            {
                station = _lastACheckRecord.DirectivePackage.Station;
                checkName = _lastACheckRecord.DirectivePackage.Title;
            }
            else
            {
                checkName = _reportedAircraft.MaintenanceProgramCheckNaming
                                        ? (!string.IsNullOrEmpty(_lastACheckRecord.ComplianceCheckName)
                                               ? _lastACheckRecord.ComplianceCheckName
                                               : _lastACheckRecord.ParentCheck.Name)
                                        : _lastACheckRecord.ParentCheck.Name;
            }

            destinationDataSet.MaintenanceTable.AddMaintenanceTableRow(checkName,
                                                                       _lastACheckRecord.RecordDate.ToString("d.M.yyyy"),
                                                                       station);
        }

        #endregion

        #region private void AddAdditionalDataToDataSet(AircraftTechicalConditionDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(AircraftTechicalConditionDataSet destinationDateSet)
        {
            List<Document> aircraftDocs =
                GlobalObjects.DocumentCore.GetAircraftDocuments(_reportedAircraft);
            //DocumentSubType awType =
            //    GlobalObjects.CasEnvironment.DocSubTypes.ToArray().Where(d => d.FullName == "AW").FirstOrDefault();
            var awType = (DocumentSubType)
                GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().ToArray().FirstOrDefault(d => d.FullName == "AW");
            Document awDoc = awType != null ? aircraftDocs.FirstOrDefault(d => d.DocumentSubType == awType):null;
            string awUpTo = awDoc != null && awDoc.IssueValidTo
                                ? awDoc.IssueDateValidTo.ToString(new GlobalTermsProvider()["DateFormat"].ToString())
                                : "";
            string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, OperatorLogotype, awUpTo, DateAsOf, reportFooter, reportFooterPrepared, reportFooterLink);

        }

        #endregion

        #endregion
    }
}
