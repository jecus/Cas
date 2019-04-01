using System;
using System.Linq;
using Auxiliary;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета по бортовому журналу ВС
    /// </summary>
    public class ATLBBuilder : AbstractReportBuilder
    {
        #region Fields

        private readonly ATLB _currentATLB;
        private readonly GlobalTermsProvider _termsProvider = new GlobalTermsProvider();
        private int _currentPageNumber;
        private readonly string _ATASpec = "ATA SPEC 5 6 7 8 9 10 11 12 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 38 49 51 52 52 54 55 56 57 71 72 73 74 75 76 77 78 79 80";
        //private List<MaintenanceCheckJobCard> MaintenanceSubChecks;

        #endregion

        #region Constructor

        #region public ATLBBuilder(ATLB atlb)

        /// <summary>
        /// Создается построитель отчета по бортовому журналу ВС
        /// </summary>
        public ATLBBuilder(ATLB atlb)
        {
            //загрузка данных Maintenance для отчета
            //MaintenanceSubChecks =
            //    GlobalObjects.CasEnvironment.Loader.
            //        GetMaintenanceFullSubCheckByAircraftId(atlb.ParentAircraft.AircraftID);
            _currentATLB = atlb;
            _currentPageNumber = _currentATLB.StartPageNo;
        }

        #endregion

        #region public ATLBBuilder(AircraftFlight aircraftFlight)

        /// <summary>
        /// Создается построитель отчета по полету ВС
        /// </summary>
        public ATLBBuilder(AircraftFlight aircraftFlight)
        {
            _currentATLB = aircraftFlight.ParentATLB;
            _currentPageNumber = _currentATLB.StartPageNo;
        }

        #endregion
        
        #endregion

        #region Properties

        #region public ATLB ATLB

        /// <summary>
        /// Возвращает бортовой журнал
        /// </summary>
        public ATLB ATLB
        {
            get { return _currentATLB; }
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
            ATLBReport report = new ATLBReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region private ATLBDataSet GenerateDataSet()

        private ATLBDataSet GenerateDataSet()
        {
            ATLBDataSet dataSet = new ATLBDataSet();
            AddATLBInformation(dataSet);
            
            return dataSet;
        }

        #endregion

        #region private void AddATLBInformation(ATLBDataSet dataSet)

        private void AddATLBInformation(ATLBDataSet dataSet)
        {
            for (int i = 0; i < _currentATLB.AircraftFlightsCollection.Count; i++)
            {
                AddAircraftFlightInformation(dataSet, _currentATLB.AircraftFlightsCollection[i]);
            }
        }

        #endregion

        #region private void AddAircraftFlightInformation(ATLBDataSet dataSet, AircraftFlight aircraftFlight)

        private void AddAircraftFlightInformation(ATLBDataSet dataSet, AircraftFlight aircraftFlight)
        {
            var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentATLB.ParentAircraftId);
            var currentOperator = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == aircraft.OperatorId);
            var operatorLogotype = currentOperator.LogoTypeWhite;
            var operatorAddress = currentOperator.Address;
            var revision = _termsProvider["Revision"].ToString();
            var caaRequirements = _termsProvider["CAARequirements"].ToString();
            var pageNumber = (_currentPageNumber++).ToString().PadLeft(5, '0');//todo проверить
            var reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            var reportFooterLink = new GlobalTermsProvider()["ReportFooterLink"].ToString();
            var specialistCaptain = 
                aircraftFlight.GetSpecialistBySpecializationId(1);
            var specialistCopilot =
                aircraftFlight.GetSpecialistBySpecializationId(2);
            var specialistGroundEngineerAP =
                aircraftFlight.GetSpecialistBySpecializationId(3);
            var specialistGroundEngineerAVI =
                aircraftFlight.GetSpecialistBySpecializationId(4);
            var specialistLoadMaster =
                aircraftFlight.GetSpecialistBySpecializationId(5);
            var specialistQualityControl =
                aircraftFlight.GetSpecialistBySpecializationId(6);
            var captain = specialistCaptain == null ? "" : specialistCaptain.FirstName;
            var captainId = specialistCaptain == null ? "" : specialistCaptain.IdNo;
            var copilot = specialistCopilot == null ? "" : specialistCopilot.FirstName;
            var copilotId = specialistCopilot == null ? "" : specialistCopilot.IdNo;
            var groundEngineerAP = specialistGroundEngineerAP == null ? "" : specialistGroundEngineerAP.FirstName;
            var groundEngineerApid = specialistGroundEngineerAP == null ? "" : specialistGroundEngineerAP.IdNo;
            var groundEngineerAVI = specialistGroundEngineerAVI == null ? "" : specialistGroundEngineerAVI.FirstName;
            var groundEngineerAviid = specialistGroundEngineerAVI == null ? "" : specialistGroundEngineerAVI.IdNo;
            var loadMaster = specialistLoadMaster == null ? "" : specialistLoadMaster.FirstName;
            var loadMasterId = specialistLoadMaster == null ? "" : specialistLoadMaster.IdNo;
            var qualityControl = specialistQualityControl == null ? "" : specialistQualityControl.FirstName;
            var qualityControlId = specialistQualityControl == null ? "" : specialistQualityControl.IdNo;
            var aircraftFlightNo = aircraftFlight.FlightNumber.ToString();
            var aircraftFlightDate = aircraftFlight.FlightDate.ToString(_termsProvider["DateFormat"].ToString());
			var stationFrom = aircraftFlight.StationFromId.ShortName;
			var stationTo = aircraftFlight.StationToId.ShortName;
			var airborneTimeOut = aircraftFlight.TimespanOutTime.ToString();// UsefulMethods.TimeToString(aircraftFlight.OutTime);
			var airborneTimeIn = aircraftFlight.TimespanInTime.ToString();//UsefulMethods.TimeToString(aircraftFlight.InTime));
			var airborneTimeBlock = aircraftFlight.BlockTime.ToString();
			var airborneTimeTakeOff = aircraftFlight.TimespanTakeOffTime.ToString();//UsefulMethods.TimeToString(aircraftFlight.TakeOffTime));
			var airborneTimeLDG = aircraftFlight.TimespanLDGTime.ToString();//UsefulMethods.TimeToString(aircraftFlight.LDGTime));
			var airborneTimeFlight = aircraftFlight.FlightTime.ToString();//UsefulMethods.TimeToString(aircraftFlight.FlightTime);
			var accumulatedTime = ""; //todo
			var totalFlightTime = ""; //aircraft.//todo
			var accumulatedLanding = ""; //todo
			var totalFlightLanding = ""; //todo
			var aircraftModel = aircraft.Model.ToString();
			var aircraftRegistrationNumber = aircraft.RegistrationNumber;
			var aCheckLastExecutionD = "";
			var aCheckLastExecutionH = "";
			var aCheckNextDueD = "";
			var aCheckNextDueH = "";
			//  MaintenanceLimitation aCheckLimitation;// = GetCheck(Cas3MaintenanceTypeItem.Instance.ACheck);//GetCheck(MaintenanceCheckTypesCollection.Instance.ACheck);
			//if (aCheckLimitation != null)
			//{
			//    Main
			//    MaintenancePerformance aCheckLastPerformance = aCheckLimitation.LastPerformance as MaintenancePerformance;
			//    if (aCheckLastPerformance != null)
			//    {
			//        aCheckLastExecutionD = aCheckLastPerformance.RecordDate.ToString(termsProvider["DateFormat"].ToString());
			//        aCheckLastExecutionH = Math.Round(aCheckLastPerformance.Lifelength.Hours.TotalHours).ToString();
			//    }
			//    aCheckNextDueD = aircraft.ManufactureDate.AddTicks(aCheckLimitation.Next.Calendar.Ticks).ToString(termsProvider["DateFormat"].ToString());
			//    aCheckNextDueH = Math.Round(aCheckLimitation.Next.Hours.TotalHours).ToString();
			//}
			var aCheckLimitation = GetCheck(1/*ACheck*/);
            if (aCheckLimitation != null)
            {
                MaintenanceCheckRecord aCheckLastPerformance = GetLastPerformanceForCheckType(1);
                if (aCheckLastPerformance != null)
                {
                    aCheckLastExecutionD = aCheckLastPerformance.RecordDate.ToString(_termsProvider["DateFormat"].ToString());
                //    aCheckLastExecutionH = Math.Round(aCheckLastPerformance.Lifelength.Hours.TotalHours).ToString();
                }
                //aCheckNextDueD = aircraft.ManufactureDate.AddTicks(aCheckLimitation.Next.Calendar.Ticks).ToString(termsProvider["DateFormat"].ToString());
                //aCheckNextDueH = Math.Round(aCheckLimitation.Next.Hours.TotalHours).ToString();
            }
			var bCheckLastExecutionD = "";
			var bCheckLastExecutionH = "";
			var bCheckNextDueD = "";
			var bCheckNextDueH = "";
			var bCheckLimitation = GetCheck(2/*BCheck*/);
            if (bCheckLimitation != null)
            {
                MaintenanceCheckRecord bCheckLastPerformance = GetLastPerformanceForCheckType(2);
                if (bCheckLastPerformance != null)
                {
                    bCheckLastExecutionD = bCheckLastPerformance.RecordDate.ToString(_termsProvider["DateFormat"].ToString());
                //    bCheckLastExecutionH = Math.Round(bCheckLastPerformance.Lifelength.Hours.TotalHours).ToString();
                }
                //bCheckNextDueD = aircraft.ManufactureDate.AddTicks(bCheckLimitation.Next.Calendar.Ticks).ToString(termsProvider["DateFormat"].ToString());
                //bCheckNextDueH = Math.Round(bCheckLimitation.Next.Hours.TotalHours).ToString();
            }
			var cCheckLastExecutionD = "";
			var cCheckLastExecutionH = "";
			var cCheckNextDueD = "";
			var cCheckNextDueH = "";
			var cCheckLimitation = GetCheck(3/*CCheck*/);
            if (cCheckLimitation != null)
            {
                MaintenanceCheckRecord cCheckLastPerformance = GetLastPerformanceForCheckType(3);
                if (cCheckLastPerformance != null)
                {
                    cCheckLastExecutionD = cCheckLastPerformance.RecordDate.ToString(_termsProvider["DateFormat"].ToString());
                //    cCheckLastExecutionH = Math.Round(cCheckLastPerformance.Lifelength.Hours.TotalHours).ToString();
                }
                //cCheckNextDueD = aircraft.ManufactureDate.AddTicks(cCheckLimitation.Next.Calendar.Ticks).ToString(termsProvider["DateFormat"].ToString());
                //cCheckNextDueH = Math.Round(cCheckLimitation.Next.Hours.TotalHours).ToString();
            }
			var discrepancy1 = "";
			var discrepancy2 = "";
			var discrepancy3 = "";
			var discrepancy4 = "";
			var filledBy1 = "";
			var filledBy2 = "";
			var filledBy3 = "";
			var filledBy4 = "";
			var addNo1 = "";
			var addNo2 = "";
			var addNo3 = "";
			var addNo4 = "";
			var openClosePage1 = "";
			var openClosePage2 = "";
			var openClosePage3 = "";
			var openClosePage4 = "";
			var caDescription1 = "";
			var caDescription2 = "";
			var caDescription3 = "";
			var caDescription4 = "";
			var pnOn1 = "";
			var pnOn2 = "";
			var pnOn3 = "";
			var pnOn4 = "";
			var snOn1 = "";
			var snOn2 = "";
			var snOn3 = "";
			var snOn4 = "";
			var pnOff1 = "";
			var pnOff2 = "";
			var pnOff3 = "";
			var pnOff4 = "";
			var snOff1 = "";
			var snOff2 = "";
			var snOff3 = "";
			var snOff4 = "";
			var sta1 = "";
			var sta2 = "";
			var sta3 = "";
			var sta4 = "";
			var autorizationNo1 = "";
			var autorizationNo2 = "";
			var autorizationNo3 = "";
			var autorizationNo4 = "";
			var date1 = "";
			var date2 = "";
			var date3 = "";
			var date4 = "";
            if (aircraftFlight.Discrepancies.Count > 0)
                FillDiscrepancyInformation(aircraftFlight.Discrepancies[0], out discrepancy1, out filledBy1, out addNo1, out openClosePage1, out caDescription1, out pnOn1, out snOn1, out pnOff1, out snOff1, out sta1, out autorizationNo1, out date1);
            if (aircraftFlight.Discrepancies.Count > 1)
                FillDiscrepancyInformation(aircraftFlight.Discrepancies[1], out discrepancy2, out filledBy2, out addNo2, out openClosePage2, out caDescription2, out pnOn2, out snOn2, out pnOff2, out snOff2, out sta2, out autorizationNo2, out date2);
            if (aircraftFlight.Discrepancies.Count > 2)
                FillDiscrepancyInformation(aircraftFlight.Discrepancies[2], out discrepancy3, out filledBy3, out addNo3, out openClosePage3, out caDescription3, out pnOn3, out snOn3, out pnOff3, out snOff3, out sta3, out autorizationNo3, out date3);
            if (aircraftFlight.Discrepancies.Count > 3)
                FillDiscrepancyInformation(aircraftFlight.Discrepancies[3], out discrepancy4, out filledBy4, out addNo4, out openClosePage4, out caDescription4, out pnOn4, out snOn4, out pnOff4, out snOff4, out sta4, out autorizationNo4, out date4);
			var tank1Name = "";
			var tank1RemainKg = "";
			var tank1OnBoardKg = "";
			var tank1CorrectionKg = "";
			var tank2Name = "";
			var tank2RemainKg = "";
			var tank2OnBoardKg = "";
			var tank2CorrectionKg = "";
			var tank3Name = "";
			var tank3RemainKg = "";
			var tank3OnBoardKg = "";
			var tank3CorrectionKg = "";
			var totalName =  aircraftFlight.FuelTankCollection.TotalFuel.Tank;
			var totalRemainKg = aircraftFlight.FuelTankCollection.TotalFuel.Remaining.ToString();//aircraftFlight.FuelTankCollection.TotalFuel.Remaining.ToString();
			var totalOnBoardKg = aircraftFlight.FuelTankCollection.TotalFuel.OnBoard.ToString();//aircraftFlight.FuelTankCollection.TotalFuel.OnBoard.ToString();
			var totalCorrectionKg = aircraftFlight.FuelTankCollection.TotalFuel.Correction.ToString();//aircraftFlight.FuelTankCollection.TotalFuel.Correction.ToString();
			var calculateUpliftKg = "";
			var actualUpliftLit = "";
			var discrepancy = "";
			var density = "";
            if (aircraftFlight.FuelTankCollection.Count > 0)
            {
                tank1Name = aircraftFlight.FuelTankCollection[0].Tank;
                tank1RemainKg = aircraftFlight.FuelTankCollection[0].Remaining.ToString();
                tank1OnBoardKg = aircraftFlight.FuelTankCollection[0].OnBoard.ToString();
                tank1CorrectionKg = aircraftFlight.FuelTankCollection[0].Correction.ToString();
                calculateUpliftKg = aircraftFlight.FuelTankCollection[0].CalculateUplift.ToString();
                actualUpliftLit = aircraftFlight.FuelTankCollection[0].ActualUpliftLit.ToString();
                discrepancy = aircraftFlight.FuelTankCollection[0].Discrepancy.ToString();
                density = aircraftFlight.FuelTankCollection[0].Density.ToString();
            }
            if (aircraftFlight.FuelTankCollection.Count > 1)
            {
                tank2Name = aircraftFlight.FuelTankCollection[1].Tank;
                tank2RemainKg = aircraftFlight.FuelTankCollection[1].Remaining.ToString();
                tank2OnBoardKg = aircraftFlight.FuelTankCollection[1].OnBoard.ToString();
                tank2CorrectionKg = aircraftFlight.FuelTankCollection[1].Correction.ToString();
            }
            if (aircraftFlight.FuelTankCollection.Count > 2)
            {
                tank3Name = aircraftFlight.FuelTankCollection[2].Tank;
                tank3RemainKg = aircraftFlight.FuelTankCollection[2].Remaining.ToString();
                tank3OnBoardKg = aircraftFlight.FuelTankCollection[2].OnBoard.ToString();
                tank3CorrectionKg = aircraftFlight.FuelTankCollection[2].Correction.ToString();
            }
			var added = aircraftFlight.FluidsCondition.HydraulicFluidAdded.ToString();
			var onBoard = aircraftFlight.FluidsCondition.HydraulicFluidOnBoard.ToString();
			var groundDeIce = aircraftFlight.FluidsCondition.GroundDeIce ? "X" : "";
			var start = aircraftFlight.FluidsCondition.AntiIcingStartTime.ToString();
			var end = aircraftFlight.FluidsCondition.AntiIcingEndTime.ToString();//UsefulMethods.TimeToString(aircraftFlight.FluidsCondition.AntiIcingEndTime);
			var fluidType = aircraftFlight.FluidsCondition.AntiIcingFluidType;
			var aeaCode = aircraftFlight.FluidsCondition.AEACode;
			var landingGear1 = "";
			var landingGear1TirePressure1 = "";
			var landingGear1TirePressure2 = "";
			var landingGear2 = "";
			var landingGear2TirePressure1 = "";
			var landingGear2TirePressure2 = "";
			var landingGear3 = "";
			var landingGear3TirePressure1 = "";
			var landingGear3TirePressure2 = "";
            if (aircraftFlight.LandingGearConditions.Count > 0)
            {
            //    landingGear1 = "";//UsefulMethods.GetLandingGearPositionName(aircraftFlight.LandingGearConditions[0].LandingGear);
                landingGear1 = aircraftFlight.LandingGearConditions[0].LandingGear.ToString();
                landingGear1TirePressure1 = aircraftFlight.LandingGearConditions[0].TirePressure1.ToString();
                landingGear1TirePressure2 = aircraftFlight.LandingGearConditions[0].TirePressure2.ToString();
            }
            if (aircraftFlight.LandingGearConditions.Count > 1)
            {
            //    landingGear2 = ""; //UsefulMethods.GetLandingGearPositionName(aircraftFlight.LandingGearConditions[1].LandingGear);
                landingGear2 = aircraftFlight.LandingGearConditions[1].LandingGear.ToString();
                landingGear2TirePressure1 = aircraftFlight.LandingGearConditions[1].TirePressure1.ToString();
                landingGear2TirePressure2 = aircraftFlight.LandingGearConditions[1].TirePressure2.ToString();
            }
            if (aircraftFlight.LandingGearConditions.Count > 2)
            {
           //     landingGear3 = ""; //UsefulMethods.GetLandingGearPositionName(aircraftFlight.LandingGearConditions[2].LandingGear);
                landingGear3 = aircraftFlight.LandingGearConditions[2].LandingGear.ToString();
                landingGear3TirePressure1 = aircraftFlight.LandingGearConditions[2].TirePressure1.ToString();
                landingGear3TirePressure2 = aircraftFlight.LandingGearConditions[2].TirePressure2.ToString();
            }
			var oilCSD1Name = "";
			var oilCsd1Add = "";
			var oilCsd1OnBoard = "";
			var oilCSD2Name = "";
			var oilCsd2Add = "";
			var oilCsd2OnBoard = "";
			var oilEng1Name = "";
			var oilEng1Add = "";
			var oilEng1OnBoard = "";
			var oilEng2Name = "";
			var oilEng2Add = "";
			var oilEng2OnBoard = "";
			var oilAPUName = "";
			var oilAPUAdd = "";
			var oilAPUOnBoard = "";
            if (aircraftFlight.OilConditionCollection.Count > 0)
            {
                //oilCSD1Name = aircraftFlight.OilConditionCollection[0].DetailId;
                oilCsd1Add = aircraftFlight.OilConditionCollection[0].OilAdded.ToString();
                oilCsd1OnBoard = aircraftFlight.OilConditionCollection[0].OnBoard.ToString();
            }
            if (aircraftFlight.OilConditionCollection.Count > 1)
            {
                //oilCSD2Name = aircraftFlight.OilConditionCollection[1].DetailId;
                oilCsd2Add = aircraftFlight.OilConditionCollection[1].OilAdded.ToString();
                oilCsd2OnBoard = aircraftFlight.OilConditionCollection[1].OnBoard.ToString();
            }
            if (aircraftFlight.OilConditionCollection.Count > 2)
            {
                //oilEng1Name = aircraftFlight.OilConditionCollection[2].DetailId;
                oilEng1Add = aircraftFlight.OilConditionCollection[2].OilAdded.ToString();
                oilEng1OnBoard = aircraftFlight.OilConditionCollection[2].OnBoard.ToString();
            }
            if (aircraftFlight.OilConditionCollection.Count > 3)
            {
                //oilEng2Name = aircraftFlight.OilConditionCollection[3].DetailId;
                oilEng2Add = aircraftFlight.OilConditionCollection[3].OilAdded.ToString();
                oilEng2OnBoard = aircraftFlight.OilConditionCollection[3].OnBoard.ToString();
            }
            if (aircraftFlight.OilConditionCollection.Count > 4)
            {
               //oilAPUName = aircraftFlight.OilConditionCollection[4].DetailId;
                oilAPUAdd = aircraftFlight.OilConditionCollection[4].OilAdded.ToString();
                oilAPUOnBoard = aircraftFlight.OilConditionCollection[4].OnBoard.ToString();
            }
			var pressAlt = aircraftFlight.EnginesGeneralConditions.PressALT;
			var gmt = UsefulMethods.TimeToString(aircraftFlight.EnginesGeneralConditions.TimeGMT);
			var grossWeight = aircraftFlight.EnginesGeneralConditions.GrossWeight.ToString();
			var ias = aircraftFlight.EnginesGeneralConditions.IAS.ToString();
			var mach = aircraftFlight.EnginesGeneralConditions.Mach.ToString();
			var tat = aircraftFlight.EnginesGeneralConditions.TAT.ToString();
			var oat = aircraftFlight.EnginesGeneralConditions.OAT.ToString();
			var releaseToServiceCheckPerformed = "";
			var releaseToServiceDate = "";
			var releaseToServiceAuth = "";
            if (aircraftFlight.CertificateOfReleaseToService != null)
            {
                releaseToServiceCheckPerformed = aircraftFlight.CertificateOfReleaseToService.CheckPerformed;
                releaseToServiceDate = aircraftFlight.CertificateOfReleaseToService.RecordDate.ToString(_termsProvider["DateFormat"].ToString());
                if(aircraftFlight.CertificateOfReleaseToService.AuthorizationB1 != null)
                    releaseToServiceAuth = aircraftFlight.CertificateOfReleaseToService.AuthorizationB1.ToString();
                if (aircraftFlight.CertificateOfReleaseToService.AuthorizationB2 != null)
                    releaseToServiceAuth = aircraftFlight.CertificateOfReleaseToService.AuthorizationB2.ToString();
            }
			var engine1 = "";
			var engine2 = "";
			var epr1 = "";
			var epr2 = "";
			var n11 = "";
			var n12 = "";
			var egt1 = "";
			var egt2 = "";
			var n21 = "";
			var n22 = "";
			var oilTemperature1 = "";
			var oilTemperature2 = "";
			var oilPressure1 = "";
			var oilPressure2 = "";
			var fuelFlow1 = "";
			var fuelFlow2 = "";
			var fuelBnKg1 = "";
			var fuelBnKg2 = "";
            if (aircraftFlight.EngineConditionCollection.Count > 0)
            {
                engine1 = "Engine " + aircraftFlight.EngineConditionCollection[0].Engine.PositionNumber;
                epr1 = aircraftFlight.EngineConditionCollection[0].ERP.ToString();
                n11 = aircraftFlight.EngineConditionCollection[0].N1.ToString();
                egt1 = aircraftFlight.EngineConditionCollection[0].EGT.ToString();
                n21 = aircraftFlight.EngineConditionCollection[0].N2.ToString();
                oilTemperature1 = aircraftFlight.EngineConditionCollection[0].OilTemperature.ToString();
                oilPressure1 = aircraftFlight.EngineConditionCollection[0].OilPressure.ToString();
                fuelFlow1 = aircraftFlight.EngineConditionCollection[0].FuelFlow.ToString();
                fuelBnKg1 = aircraftFlight.EngineConditionCollection[0].FuelBurn.ToString();
            }
            if (aircraftFlight.EngineConditionCollection.Count > 1)
            {
                engine2 = "Engine " + aircraftFlight.EngineConditionCollection[1].Engine.PositionNumber;
                epr2 = aircraftFlight.EngineConditionCollection[1].ERP.ToString();
                n12 = aircraftFlight.EngineConditionCollection[1].N1.ToString();
                egt2 = aircraftFlight.EngineConditionCollection[1].EGT.ToString();
                n22 = aircraftFlight.EngineConditionCollection[1].N2.ToString();
                oilTemperature2 = aircraftFlight.EngineConditionCollection[1].OilTemperature.ToString();
                oilPressure2 = aircraftFlight.EngineConditionCollection[1].OilPressure.ToString();
                fuelFlow2 = aircraftFlight.EngineConditionCollection[1].FuelFlow.ToString();
                fuelBnKg2 = aircraftFlight.EngineConditionCollection[1].FuelBurn.ToString();
            }
            dataSet.AircraftFlightTable.AddAircraftFlightTableRow(operatorLogotype, operatorAddress, revision,
                                                                  caaRequirements, pageNumber, reportFooterPrepared,
                                                                  reportFooterLink, captain, captainId, copilot,
                                                                  copilotId,
                                                                  groundEngineerAP, groundEngineerApid,
                                                                  groundEngineerAVI, groundEngineerAviid, loadMaster,
                                                                  loadMasterId, qualityControl, qualityControlId,
                                                                  aircraftFlightNo, aircraftFlightDate, stationFrom,
                                                                  stationTo, airborneTimeOut, airborneTimeIn,
                                                                  airborneTimeBlock, airborneTimeTakeOff,
                                                                  airborneTimeLDG, airborneTimeFlight,
                                                                  accumulatedTime, totalFlightTime,
                                                                  accumulatedLanding, totalFlightLanding,
                                                                  aircraftModel, aircraftRegistrationNumber,
                                                                  aCheckLastExecutionD, aCheckLastExecutionH,
                                                                  aCheckNextDueD, aCheckNextDueH,
                                                                  bCheckLastExecutionD, bCheckLastExecutionH,
                                                                  bCheckNextDueD, bCheckNextDueH,
                                                                  cCheckLastExecutionD, cCheckLastExecutionH,
                                                                  cCheckNextDueD, cCheckNextDueH, discrepancy1,
                                                                  discrepancy2, discrepancy3, discrepancy4, filledBy1,
                                                                  filledBy2, filledBy3, filledBy4, addNo1, addNo2,
                                                                  addNo3, addNo4, openClosePage1, openClosePage2,
                                                                  openClosePage3, openClosePage4, caDescription1,
                                                                  caDescription2, caDescription3, caDescription4, pnOn1,
                                                                  pnOn2, pnOn3,
                                                                  pnOn4, snOn1, snOn2, snOn3, snOn4, pnOff1,
                                                                  pnOff2, pnOff3, pnOff4, snOff1, snOff2, snOff3,
                                                                  snOff4, sta1, sta2, sta3, sta4, autorizationNo1,
                                                                  autorizationNo2, autorizationNo3, autorizationNo4,
                                                                  date1, date2, date3, date4, tank1Name, tank1RemainKg,
                                                                  tank1OnBoardKg, tank1CorrectionKg, tank2Name,
                                                                  tank2RemainKg, tank2OnBoardKg, tank2CorrectionKg,
                                                                  tank3Name, tank3RemainKg, tank3OnBoardKg,
                                                                  tank3CorrectionKg, totalName, totalRemainKg,
                                                                  totalOnBoardKg, totalCorrectionKg, calculateUpliftKg,
                                                                  actualUpliftLit, discrepancy, density, added, onBoard,
                                                                  groundDeIce, start, end, fluidType, aeaCode,
                                                                  landingGear1, landingGear1TirePressure1,
                                                                  landingGear1TirePressure2, landingGear2,
                                                                  landingGear2TirePressure1, landingGear2TirePressure2,
                                                                  landingGear3, landingGear3TirePressure1,
                                                                  landingGear3TirePressure2,
                                                                  oilCSD1Name, oilCsd1Add, oilCsd1OnBoard, oilCSD2Name,
                                                                  oilCsd2Add, oilCsd2OnBoard, oilEng1Name, oilEng1Add,
                                                                  oilEng1OnBoard, oilEng2Name, oilEng2Add,
                                                                  oilEng2OnBoard, oilAPUName, oilAPUAdd, oilAPUOnBoard,
                                                                  pressAlt,
                                                                  gmt, grossWeight, ias, mach, tat, oat,
                                                                  releaseToServiceCheckPerformed, releaseToServiceDate,
                                                                  releaseToServiceAuth, engine1,
                                                                  engine2, epr1, epr2, n11, n12, egt1, egt2, n21,
                                                                  n22, oilTemperature1, oilTemperature2, oilPressure1,
                                                                  oilPressure2, fuelFlow1, fuelFlow2, fuelBnKg1,
                                                                  fuelBnKg2, _ATASpec);
            if (aircraftFlight.Discrepancies.Count > 4)
                AddAdditionalAircraftFlightTableRow(dataSet, aircraftFlight, 4);
        }

        #endregion

        #region private void AddAdditionalAircraftFlightTableRow(ATLBDataSet dataSet, AircraftFlight aircraftFlight, int discrepancyIndex)

        private void AddAdditionalAircraftFlightTableRow(ATLBDataSet dataSet, AircraftFlight aircraftFlight, int discrepancyIndex)
        {
			var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentATLB.ParentAircraftId);
			var currentOperator = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == aircraft.OperatorId);
			var operatorLogotype = currentOperator.LogoTypeWhite;
			var operatorAddress = currentOperator.Address;
			var revision = _termsProvider["Revision"].ToString();
			var _CAARequirements = _termsProvider["CAARequirements"].ToString();
			var pageNumber = (_currentPageNumber++).ToString().PadLeft(5, '0');
			var reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
			var reportFooterLink = new GlobalTermsProvider()["ReportFooterLink"].ToString();
			var aircraftFlightNo = aircraftFlight.FlightNumber.ToString();
			var aircraftFlightDate = aircraftFlight.FlightDate.ToString(_termsProvider["DateFormat"].ToString());
			var aircraftModel = aircraft.Model.ToString();
			var aircraftRegistrationNumber = aircraft.RegistrationNumber;
			var discrepancy1 = "";
			var discrepancy2 = "";
			var discrepancy3 = "";
			var discrepancy4 = "";
			var filledBy1 = "";
			var filledBy2 = "";
			var filledBy3 = "";
			var filledBy4 = "";
			var addNo1 = "";
			var addNo2 = "";
			var addNo3 = "";
			var addNo4 = "";
			var openClosePage1 = "";
			var openClosePage2 = "";
			var openClosePage3 = "";
			var openClosePage4 = "";
			var caDescription1 = "";
			var caDescription2 = "";
			var caDescription3 = "";
			var caDescription4 = "";
			var pn_ON1 = "";
			var pn_ON2 = "";
			var pn_ON3 = "";
			var pn_ON4 = "";
			var sn_ON1 = "";
			var sn_ON2 = "";
			var sn_ON3 = "";
			var sn_ON4 = "";
			var pn_OFF1 = "";
			var pn_OFF2 = "";
			var pn_OFF3 = "";
			var pn_OFF4 = "";
			var sn_OFF1 = "";
			var sn_OFF2 = "";
			var sn_OFF3 = "";
			var sn_OFF4 = "";
			var sta1 = "";
			var sta2 = "";
			var sta3 = "";
			var sta4 = "";
			var autorizationNo1 = "";
			var autorizationNo2 = "";
			var autorizationNo3 = "";
			var autorizationNo4 = "";
			var date1 = "";
			var date2 = "";
			var date3 = "";
			var date4 = "";
            if (aircraftFlight.Discrepancies.Count > discrepancyIndex)
                FillDiscrepancyInformation(aircraftFlight.Discrepancies[discrepancyIndex++], out discrepancy1, out filledBy1, out addNo1, out openClosePage1, out caDescription1, out pn_ON1, out sn_ON1, out pn_OFF1, out sn_OFF1, out sta1, out autorizationNo1, out date1);
            if (aircraftFlight.Discrepancies.Count > discrepancyIndex)
                FillDiscrepancyInformation(aircraftFlight.Discrepancies[discrepancyIndex++], out discrepancy2, out filledBy2, out addNo2, out openClosePage2, out caDescription2, out pn_ON2, out sn_ON2, out pn_OFF2, out sn_OFF2, out sta2, out autorizationNo2, out date2);
            if (aircraftFlight.Discrepancies.Count > discrepancyIndex)
                FillDiscrepancyInformation(aircraftFlight.Discrepancies[discrepancyIndex++], out discrepancy3, out filledBy3, out addNo3, out openClosePage3, out caDescription3, out pn_ON3, out sn_ON3, out pn_OFF3, out sn_OFF3, out sta3, out autorizationNo3, out date3);
            if (aircraftFlight.Discrepancies.Count > discrepancyIndex)
                FillDiscrepancyInformation(aircraftFlight.Discrepancies[discrepancyIndex++], out discrepancy4, out filledBy4, out addNo4, out openClosePage4, out caDescription4, out pn_ON4, out sn_ON4, out pn_OFF4, out sn_OFF4, out sta4, out autorizationNo4, out date4); 
            dataSet.AircraftFlightTable.AddAircraftFlightTableRow(operatorLogotype, operatorAddress, revision,
                                                                  _CAARequirements, pageNumber, reportFooterPrepared,
                                                                  reportFooterLink, "", "", "", "", "", "", "", "", "",
                                                                  "", "", "", aircraftFlightNo, aircraftFlightDate, "",
                                                                  "", "", "", "", "", "", "", "", "", "", "",
                                                                  aircraftModel, aircraftRegistrationNumber, "", "", "",
                                                                  "", "", "", "", "", "", "", "", "", discrepancy1,
                                                                  discrepancy2, discrepancy3, discrepancy4, filledBy1,
                                                                  filledBy2, filledBy3, filledBy4, addNo1, addNo2,
                                                                  addNo3, addNo4, openClosePage1, openClosePage2,
                                                                  openClosePage3, openClosePage4, caDescription1,
                                                                  caDescription2, caDescription3, caDescription4, pn_ON1,
                                                                  pn_ON2, pn_ON3, pn_ON4, sn_ON1, sn_ON2, sn_ON3, sn_ON4,
                                                                  pn_OFF1, pn_OFF2, pn_OFF3, pn_OFF4, sn_OFF1, sn_OFF2,
                                                                  sn_OFF3, sn_OFF4, sta1, sta2, sta3, sta4,
                                                                  autorizationNo1, autorizationNo2, autorizationNo3,
                                                                  autorizationNo4, date1, date2, date3, date4, "", "",
                                                                  "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                                                  "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                                                  "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                                                  "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                                                  "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                                                  "", "", "", "", "", "", "", _ATASpec);
            if (aircraftFlight.Discrepancies.Count > discrepancyIndex)
                AddAdditionalAircraftFlightTableRow(dataSet, aircraftFlight, discrepancyIndex);
        }

        #endregion

        #region private void FillDiscrepancyInformation(Discrepancy discrepancy, out string description, out string filledBy, out string addNo, out string openClosePage, out string caDescription, out string pn_ON, out string sn_ON, out string pn_OFF, out string sn_OFF, out string sta, out string autorizationNo, out string date)

        private void FillDiscrepancyInformation(Discrepancy discrepancy, out string description, out string filledBy, out string addNo, out string openClosePage, out string caDescription, out string pn_ON, out string sn_ON, out string pn_OFF, out string sn_OFF, out string sta, out string autorizationNo, out string date)
        {
            sta = "";
            autorizationNo = "";
            date = "";
            description = discrepancy.Description;
            filledBy = discrepancy.FilledBy == false ? "Crew" : "Maintenance Staff";
            addNo = discrepancy.CorrectiveAction.AddNo;
            openClosePage = discrepancy.CorrectiveAction.Status.ToString();
            caDescription = discrepancy.CorrectiveAction.Description;
            pn_ON = discrepancy.CorrectiveAction.PartNumberOn;
            sn_ON = discrepancy.CorrectiveAction.SerialNumberOn;
            pn_OFF = discrepancy.CorrectiveAction.PartNumberOff;
            sn_OFF = discrepancy.CorrectiveAction.SerialNumberOff;
            if (discrepancy.CertificateOfReleaseToService != null)
            {
                sta = discrepancy.CertificateOfReleaseToService.Station;
                date = discrepancy.CertificateOfReleaseToService.RecordDate.ToString(_termsProvider["DateFormat"].ToString());
                if (discrepancy.CertificateOfReleaseToService.AuthorizationB1 != null)
                    autorizationNo = discrepancy.CertificateOfReleaseToService.AuthorizationB1.ToString();
            
            }
            filledBy = null;
        }

        #endregion
        
        #region private MaintenanceLimitation GetCheck(MaintenanceCheckType checkType)

        private MaintenanceCheck GetCheck(Int32 checkType)
        {
            //Cas3MaintenanceSubCheckItem A Check
            //Cas3MaintenanceLiminationItem
            //Aircraft aircraft = currentATLB.ParentAircraft;
            //for (int i = 0; i < MaintenanceSubChecks.Count; i++)
            //{
            //    if (MaintenanceSubChecks[i].ParentCheck.CheckType.ItemId == checkType)
            //        return MaintenanceSubChecks[i].ParentCheck;
            //}
            return null;
        }

        #endregion

        #region private Cas3MaintenanceSubCheckPerformanceItem GetLastPerformanceForCheckType(MaintenanceCheckType checkType)

        private MaintenanceCheckRecord GetLastPerformanceForCheckType(Int32 checkType)
        {
            //List<MaintenanceCheckJobCard> subCheckItems = 
            //    MaintenanceSubChecks.Where(t => t.ParentCheck.CheckType.ItemId == checkType).ToList();
            ////собрание последних Performance для каждого SubCheck-а
            //DateTime lastDate = new DateTime(1950, 1, 1);
            //MaintenanceCheckRecord lastPerformance = null;

            //foreach (MaintenanceCheckJobCard t in subCheckItems)
            //{
            //    MaintenanceCheckRecord newItem =
            //        GlobalObjects.CasEnvironment.Loader.
            //            GetPerformances<MaintenanceCheckRecord>(t.SmartCoreObjectType, t.ItemId, true);

            //    if (newItem == null || (newItem.RecordDate <= lastDate)) continue;
            //    lastDate = newItem.RecordDate;
            //    lastPerformance = newItem;
            //}

            //return lastPerformance;
            return null;
        }

        #endregion

        #endregion
    }
}
