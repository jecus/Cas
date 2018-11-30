using System;
using System.Collections.Generic;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;
using TempUIExtentions;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчетов по ВС
    /// </summary>
    public class AircraftGeneralDataReportBuilder : AbstractReportBuilder
    {

        #region Fields

        private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
        private Aircraft _reportedAircraft;
        private string _dateAsOf = "";

        //readonly AllDirectiveFilter defaultFilter = new AllDirectiveFilter();
        private string _reportTitle = "AIRCRAFT GENERAL DATA";
        private byte[] _operatorLogotype;

        private Lifelength _lifelengthAircraftSinceNew;

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

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            AircraftGeneralDataReport report = new AircraftGeneralDataReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region public virtual AircraftGeneralDataDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        public virtual AircraftGeneralDataDataSet GenerateDataSet()
        {
            AircraftGeneralDataDataSet dataset = new AircraftGeneralDataDataSet();
            AddAircraftToDataset(dataset);
            AddBaseDetailToDataset(dataset);
            AddChecksToDataset(dataset);
            AddAdditionalDataToDataSet(dataset);
            AddOperatorDataToDataSet(dataset);
            return dataset;
        }

        #endregion

        #region private void AddAircraftToDataset(AircraftGeneralDataDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(AircraftGeneralDataDataSet destinationDataSet)
        {
            if (_reportedAircraft == null)
                return;

            var reportAircraftLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);
            var aircraftDocs = GlobalObjects.DocumentCore.GetAircraftDocuments(_reportedAircraft);
            var operatorDocs = GlobalObjects.DocumentCore.GetDocuments(GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId), DocumentType.Certificate, true);
            //DocumentSubType aocType =
            //    GlobalObjects.CasEnvironment.DocSubTypes.ToArray().Where(d => d.FullName == "AOC").FirstOrDefault();
            DocumentSubType aocType = (DocumentSubType)
            GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().ToArray().FirstOrDefault(d => d.FullName == "AOC");
            if (aocType != null)
                operatorDocs.Remove(operatorDocs.FirstOrDefault(d => d.DocumentSubType == aocType));
            string manufactureDate = _reportedAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            int sinceNewHours = reportAircraftLifeLenght.Hours != null ? (int)reportAircraftLifeLenght.Hours : 0;
            int sinceNewCycles = reportAircraftLifeLenght.Cycles != null ? (int)reportAircraftLifeLenght.Cycles : 0;
            destinationDataSet.AircraftDataTable.AddAircraftDataTableRow(_reportedAircraft.SerialNumber,
                                                                         manufactureDate,
                                                                         sinceNewHours,
                                                                         sinceNewCycles,
                                                                         _reportedAircraft.RegistrationNumber,
                                                                         _reportedAircraft.Model.ToString(),
                                                                         _reportedAircraft.LineNumber,
                                                                         _reportedAircraft.VariableNumber,
                                                                         _reportedAircraft.MaxTakeOffCrossWeight.ToString(),
                                                                         _reportedAircraft.MaxTaxiWeight.ToString(),
                                                                         _reportedAircraft.MaxZeroFuelWeight.ToString(),
                                                                         _reportedAircraft.MaxLandingWeight.ToString(),
                                                                         _reportedAircraft.BasicEmptyWeight.ToString(),
                                                                         _reportedAircraft.OperationalEmptyWeight.ToString(),
                                                                         _reportedAircraft.FuelCapacity,
                                                                         _reportedAircraft.MaxCruiseAltitude,
                                                                         _reportedAircraft.CruiseFuelFlow,
                                                                         _reportedAircraft.CargoCapacityContainer,
                                                                         _reportedAircraft.AircraftAddress24Bit,
                                                                         _reportedAircraft.ELTIdHexCode);
            destinationDataSet.InteriorConfiguration.AddInteriorConfigurationRow(_reportedAircraft.CockpitSeating,
                                                                         _reportedAircraft.Galleys,
                                                                         _reportedAircraft.Lavatory,
                                                                         _reportedAircraft.SeatingEconomy.ToString(),
                                                                         _reportedAircraft.Oven,
                                                                         _reportedAircraft.Boiler,
                                                                         _reportedAircraft.AirStairsDoors);



            var aircraftEquipment = _reportedAircraft.AircraftEquipments.Where(a => a.AircraftEquipmetType == AircraftEquipmetType.Equipmet);
            foreach (var equipment in aircraftEquipment)
            {
	            destinationDataSet.AircraftSpecialEquipmentTable.AddAircraftSpecialEquipmentTableRow(
		            equipment.AircraftOtherParameter.ToString(), equipment.Description);

            }
			var aircraftApproval = _reportedAircraft.AircraftEquipments.Where(a => a.AircraftEquipmetType == AircraftEquipmetType.TapeOfOperationApproval);
			foreach (var approval in aircraftApproval)
            {
                destinationDataSet.AircraftCertificatesTable.AddAircraftCertificatesTableRow(
				   approval.AircraftOtherParameter.ToString(), approval.Description);
            }
        }

        #endregion

        #region private void AddBaseDetailToDataset(AircraftGeneralDataDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddBaseDetailToDataset(AircraftGeneralDataDataSet destinationDataSet)
        {
            if (_reportedAircraft == null) return;
            var baseDetails = 
                new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(_reportedAircraft.ItemId));

            foreach (var baseDetail in baseDetails)
            {
                if(baseDetail.BaseComponentType == BaseComponentType.Frame)continue;

				var currentDetailSource =
                    GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseDetail);

				var status = baseDetail.Serviceable ? "Serviceable" : "Unserviceable";
				var sinceNewHours = currentDetailSource.Hours != null ?currentDetailSource.Hours.ToString() : "";
				var sinceNewCycles = currentDetailSource.Cycles != null ? currentDetailSource.Cycles.ToString() : "";
				var sinceNewDays = currentDetailSource.Days != null ? currentDetailSource.Days.ToString() : "";

				var lifeLimit = baseDetail.LifeLimit;
				var lifeLimitHours = lifeLimit.Hours != null ? lifeLimit.Hours.ToString() : "";
				var lifeLimitCycles = lifeLimit.Cycles != null ? lifeLimit.Cycles.ToString() : "";
                string lifeLimitDays = lifeLimit.Days != null ? lifeLimit.Days.ToString() : "";
				var remain = Lifelength.Null;
                if (!lifeLimit.IsNullOrZero())
                {
                    remain = new Lifelength(lifeLimit);
                    remain.Substract(currentDetailSource);
                    remain.Resemble(lifeLimit);
                }
				var remainHours = remain.Hours != null ? remain.Hours.ToString() : "";
				var remainCycles = remain.Cycles != null ? remain.Cycles.ToString() : "";
                var remainDays = remain.Days != null ? remain.Days.ToString() : "";    

                Lifelength betweenOverhaul = Lifelength.Null, lastCompliance = Lifelength.Null;
                DateTime lastOverhaulDate = DateTime.MinValue;

                string lastOverhaulDateString = "", lastOverhaulHours = "", lastOverhaulCycles = "";
                string remainOverhaulDays = "", remainOverhaulHours = "", remainOverhaulCycles = "";
                string type = "";
	            string registrationNumber = baseDetail.GetParentAircraftRegNumber();

				if (baseDetail.BaseComponentType == BaseComponentType.LandingGear)type = "Part C: Landing Gears";
                if (baseDetail.BaseComponentType == BaseComponentType.Propeller) type = "Part B1: Propeller";
                if (baseDetail.BaseComponentType == BaseComponentType.Engine) type = "Part B2: Engines";
                if (baseDetail.BaseComponentType == BaseComponentType.Apu) type = "Part D: Auxiliary Power Unit ";

                #region поиск последнего ремонта и расчет времени, прошедшего с него
                //поиск директив деталей
                List<ComponentDirective> directives = 
                    GlobalObjects.ComponentCore.GetComponentDirectives(baseDetail,true);
                //поиск директивы ремонта
                List<ComponentDirective> overhauls =
                    directives.Where(d => d.DirectiveType == ComponentRecordType.Overhaul).ToList();
				//поиск последнего ремонта
				if (overhauls.Count!= 0)
                {
					var remains = Lifelength.Null;
					ComponentDirective lastOverhaul = null;
                    foreach (ComponentDirective d in overhauls)
                    {
						GlobalObjects.PerformanceCalculator.GetNextPerformance(d);
	                    remains = d.Remains;
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
	                    if (!remains.IsNullOrZero())
	                    {
							remainOverhaulHours = remains.Hours != null ? remains.Hours.ToString() : "";
							remainOverhaulCycles = remains.Cycles != null ? remains.Cycles.ToString() : "";
							remainOverhaulDays = remains.Days != null ? remains.Days.ToString() : "";
						}
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
																		 registrationNumber,
																		 baseDetail.TransferRecords.GetLast().Position,
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
                                                                         lastCompliance.Cycles != null ? lastCompliance.Hours.ToString() : "");   
            }
        }

        #endregion

        #region private void AddChecksToDataset(AircraftGeneralDataDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddChecksToDataset(AircraftGeneralDataDataSet destinationDataSet)
        {
            if (_reportedAircraft == null)
                return;
            var mc = GlobalObjects.MaintenanceCore.GetMaintenanceCheck(_reportedAircraft, _reportedAircraft.Schedule);
            var aircraftChecks = new MaintenanceCheckCollection(mc);
            GlobalObjects.MaintenanceCheckCalculator.GetNextPerformanceGroup(aircraftChecks, _reportedAircraft.Schedule);
            foreach (object o in GlobalObjects.CasEnvironment.GetDictionary<MaintenanceCheckType>())
            {
                var checkType = o as MaintenanceCheckType;
                if(checkType != null)
                {
                    var lastComplianceGroups =
                        aircraftChecks.GetLastComplianceCheckGroup(_reportedAircraft.Schedule, _reportedAircraft.ItemId,
                                                                   true, LifelengthSubResource.Hours,
                                                                   checkType);

                    if (lastComplianceGroups == null || lastComplianceGroups.Checks.Count == 0)
                    {
                        continue;
                    }
                    var maxCheck = lastComplianceGroups.GetMaxIntervalCheck();
                    var minCheck = lastComplianceGroups.GetMinIntervalCheck();
                    var repeatInterval = minCheck.Interval;
                    //расчет остатка от выполнения с даты производтсва
                    var lastComplianceDate = maxCheck.LastPerformance.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
	                var lastCompliance = maxCheck.LastPerformance.OnLifelength;
					var remains = minCheck.Remains;
                    var condition = minCheck.Condition ?? ConditionState.NotEstimated;
                    destinationDataSet.MaintenanceTable.AddMaintenanceTableRow(maxCheck.Name,
                                                               repeatInterval.Days != null ? repeatInterval.Days.ToString() : "",
                                                               repeatInterval.Hours != null ? repeatInterval.Hours.ToString() : "",
                                                               repeatInterval.Cycles != null ? repeatInterval.Cycles.ToString() : "",
                                                               lastComplianceDate,
                                                               lastCompliance.Hours != null ? lastCompliance.Hours.ToString() : "",
                                                               lastCompliance.Cycles != null ? lastCompliance.Cycles.ToString() : "",
                                                               remains.Days != null ? remains.Days.ToString() : "",
                                                               remains.Hours != null ? remains.Hours.ToString() : "",
                                                               remains.Cycles != null ? remains.Cycles.ToString() : "",
                                                               condition.ToString());
                }
            }
        }

        #endregion

        #region private void AddAdditionalDataToDataSet(AircraftGeneralDataDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(AircraftGeneralDataDataSet destinationDateSet)
        {
            List<Document> aircraftDocs =
                GlobalObjects.DocumentCore.GetAircraftDocuments(_reportedAircraft);
            //DocumentSubType awType =
            //    GlobalObjects.CasEnvironment.DocSubTypes.ToArray().Where(d => d.FullName == "AW").FirstOrDefault();
            DocumentSubType awType = (DocumentSubType)
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

        #region private void AddOperatorDataToDataSet(AircraftGeneralDataDataSet destinationDateSet)

        /// <summary>
        /// Добавление информации об операторе 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddOperatorDataToDataSet(AircraftGeneralDataDataSet destinationDateSet)
        {
            if(_reportedAircraft == null) return;
			var op = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId);

			var operatorDocs = GlobalObjects.DocumentCore.GetDocuments(op, DocumentType.Certificate, true);
            //DocumentSubType aocType =
            //    GlobalObjects.CasEnvironment.DocSubTypes.ToArray().Where(d => d.FullName == "AOC").FirstOrDefault();
            var aocType = (DocumentSubType) GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().ToArray().FirstOrDefault(d => d.FullName == "AOC");
            var awDoc = aocType != null ? operatorDocs.FirstOrDefault(d => d.DocumentSubType == aocType) : null;
            string aocUpTo = awDoc != null && awDoc.IssueValidTo
                                ? awDoc.IssueDateValidTo.ToString(new GlobalTermsProvider()["DateFormat"].ToString())
                                : "";
            
            destinationDateSet.OperatorTable.AddOperatorTableRow(_reportedAircraft.Owner, 
                                                                 op.Name, op.ICAOCode, op.Address, op.Phone,
                                                                 op.Fax, op.Email, aocUpTo);

        }

        #endregion

        #endregion
    }
}
