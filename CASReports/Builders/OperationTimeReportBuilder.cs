using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;

namespace CASReports.Builders
{
	/// <summary>
	/// ??????????? ?????? Release To Service 
	/// </summary>
	public class OperationTimeReportBuilder : AbstractReportBuilder
	{
		#region Fields

		private Aircraft _currentAircraft;
		/// <summary>
		/// ????????? ?????????? ? ?????
		/// </summary>
		private List<MaintenanceCheckRecordGroup> _records;

		private IEnumerable<BaseComponent> _aircraftBaseDetails;

		private MaintenanceCheckRecord _lastCheckRecord;

		private IEnumerable<WorkPackage> _workPackages;

		private DateTime _from;

		private DateTime _to;

		#endregion

		#region Properties

		#region public Aircraft Aircrafte
		/// <summary>
		/// ?????????? ??
		/// </summary>
		public Aircraft Aircraft
		{
			set { _currentAircraft = value; }
		}

		#endregion

		#endregion

		#region Constructor

		/// <summary>
		/// ????????? ??????????? ?????? Operation Time
		/// </summary>
		/// <param name="aircraft">??</param>
		/// <param name="items"></param>
		/// <param name="aircraftBaseDetails"></param>
		/// <param name="lastCCheckRecord"></param>
		/// <param name="workPackages"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		public OperationTimeReportBuilder(Aircraft aircraft, 
										  List<MaintenanceCheckRecordGroup> items, 
										  IEnumerable<BaseComponent> aircraftBaseDetails,
										  MaintenanceCheckRecord lastCCheckRecord,
										  IEnumerable<WorkPackage> workPackages,
										  DateTime from,
										  DateTime to)
		{
			_currentAircraft = aircraft;
			_records = items;
			_aircraftBaseDetails = aircraftBaseDetails;
			_lastCheckRecord = lastCCheckRecord;
			_workPackages = workPackages;
			_from = from;
			_to = to;
		}

		#endregion

		#region Methods

		#region public override object GenerateReport()

		/// <summary>
		/// ?????????????? ????? ?? ??????, ??????????? ? ??????? ??????
		/// </summary>
		/// <returns>??????????? ?????</returns>
		public override object GenerateReport()
		{
			OperationTimeReport report = new OperationTimeReport();
			report.SetDataSource(GenerateDataSet());
			return report;
		}

		#endregion

		#region private OperationTimeDataSet GenerateDataSet()

		private OperationTimeDataSet GenerateDataSet()
		{
			OperationTimeDataSet dataSet = new OperationTimeDataSet();
			AddReleaseToServiceInformationToDataSet(dataSet);
			AddBaseDetailsToDataSet(dataSet);
			AddItemsToDataSet(dataSet);
			return dataSet;
		}

		#endregion

		#region private void AddItemsToDataSet(OperationTimeDataSet dataset)

		/// <summary>
		/// ?????????? ???????? ? ??????? ??????
		/// </summary>
		/// <param name="dataset">???????, ? ??????? ??????????? ??????</param>
		private void AddItemsToDataSet(OperationTimeDataSet dataset)
		{
			foreach (MaintenanceCheckRecordGroup checkRecord in _records)
			{
				AddItemDataset(checkRecord, dataset);
			}
		}

		#endregion

		#region private void AddItemDataset(MaintenanceCheckRecordGroup checkRecord, OperationTimeDataSet destinationDataSet
		/// <summary>
		/// ??????????? ??????? ? ??????? ??????
		/// </summary>
		/// <param name="grouping">?????????? ?????????</param>
		/// <param name="destinationDataSet">???????, ? ??????? ??????????? ???????</param>
		private void AddItemDataset(MaintenanceCheckRecordGroup grouping, OperationTimeDataSet destinationDataSet)
		{
			if(grouping == null)
				return;

			string checkName = "";
			string performanceSourceHours = "";
			string performanceSourceCycles = "";
			string station = "";
			string checkStartEndString = "";
			if (grouping.Records.Count > 0)
			{
				grouping.Sort();

				MaintenanceCheckRecord mcr = grouping.LastOrDefault();
				MaintenanceCheck mc = grouping.GetMaxIntervalCheck();

				if (mcr != null)
				{
					checkName = _currentAircraft != null && _currentAircraft.MaintenanceProgramCheckNaming
										? (!string.IsNullOrEmpty(grouping.First().ComplianceCheckName)
											   ? mcr.ComplianceCheckName
											   : mc.Name)
										: mc.Name;
					performanceSourceHours = mcr.OnLifelength.ToHoursMinutesFormat("");
					performanceSourceCycles = mcr.OnLifelength.Cycles != null ? mcr.OnLifelength.Cycles.ToString() : "";
					if(mcr.DirectivePackage == null)
						mcr.DirectivePackage = _workPackages != null
											  ? _workPackages.FirstOrDefault(wp => wp.ItemId == mcr.DirectivePackageId)
											  : null;
					if(mcr.DirectivePackage != null)
					{
						if (mcr.DirectivePackage.Status == WorkPackageStatus.Published)
						{
							checkStartEndString = mcr.DirectivePackage.PublishingDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
							checkStartEndString += " - Present day";
						}
						if(mcr.DirectivePackage.Status == WorkPackageStatus.Closed)
						{
							checkStartEndString = mcr.DirectivePackage.PublishingDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
							checkStartEndString += " - " + mcr.DirectivePackage.ClosingDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
							
						}
						station = mcr.DirectivePackage.Station;
					}
					else
					{
						checkStartEndString = mcr.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
						station = "--";
					}
				}
			}

			var sinceLastCCheckHours = "--";
			var sinceLastCCheckCycles = "--";
			//TODO:???????????? ??????
			//if(_lastC?heckRecord != null && 
			//   _aircraftBaseDetails != null && 
			//   _aircraftBaseDetails.FirstOrDefault(bd => bd.BaseComponentType == BaseComponentType.Frame) != null)
			//{
			//    BaseComponent frame = _aircraftBaseDetails.First(bd => bd.BaseComponentType == BaseComponentType.Frame);
			//    Lifelength current = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(frame, grouping.LastOrDefault() != null ? grouping.Last().RecordDate : DateTime.Today);
			//    Lifelength sinceLast =  current - _lastC?heckRecord.OnLifelength;
			//    sinceLastCCheckHours = sinceLast.TotalMinutes != null ? sinceLast.ToHoursMinutesFormat("") : "";
			//    sinceLastCCheckCycles = sinceLast.Cycles != null ? sinceLast.Cycles.ToString() : "";
			//}

			destinationDataSet.MaintenanceTable.AddMaintenanceTableRow(checkName,
																	   checkStartEndString, 
																	   station,
																	   performanceSourceHours,
																	   performanceSourceCycles,
																	   sinceLastCCheckHours,
																	   sinceLastCCheckCycles);
		}

		#endregion

		#region private void AddReleaseToServiceInformationToDataSet(OperationTimeDataSet destinationDataSet)

		private void AddReleaseToServiceInformationToDataSet(OperationTimeDataSet destinationDataSet)
		{
			var period = SmartCore.Auxiliary.Convert.DatePeriodToString(_from, _to);
			var totalFlight = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentAircraft);
			var op = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _currentAircraft.OperatorId);
			var airportName = op.Name + Environment.NewLine + "The Seychelles National Airport";
			var manufacturer = GlobalObjects.ComponentCore.GetBaseComponentById(_currentAircraft.AircraftFrameId).Manufacturer;
			var registrationMark = _currentAircraft.RegistrationNumber;
			var model = _currentAircraft.Model.ToString();
			var serialNumber = _currentAircraft.SerialNumber;
			var totalCycles = totalFlight.Cycles.ToString();
			var totalFlightHours = totalFlight.Hours.ToString();
			var operatorLogotype = op.LogotypeReportVeryLarge;
			var operatorName = op.Name;
			var operatorAddress = op.Address;

			destinationDataSet.MainDataTable.AddMainDataTableRow(airportName,
																 manufacturer,
																 registrationMark, model, serialNumber,
																 totalCycles, totalFlightHours,
																 operatorLogotype,
																 operatorName, operatorAddress,
																 period,
																 "",
																 "",
																 "");
		}

		#endregion

		#region private void AddBaseDetailsToDataSet(OperationTimeDataSet dataset)

		/// <summary>
		/// ?????????? ???????? ? ??????? ??????
		/// </summary>
		/// <param name="dataset">???????, ? ??????? ??????????? ??????</param>
		private void AddBaseDetailsToDataSet(OperationTimeDataSet dataset)
		{
			if (_aircraftBaseDetails == null)
				return;

			var frame = _aircraftBaseDetails.FirstOrDefault(bd => bd.BaseComponentType == BaseComponentType.Frame);
			if(frame != null)
			{
				var subs = frame.Position.Split('-');
				var framePosition = new StringBuilder();
				for (int i = 0; i < subs.Length; i++)
				{
					if (i == subs.Length - 1)
						framePosition.AppendLine(subs[i]);
					else framePosition.AppendLine(subs[i] + '-');
				}

				var from = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(frame, _from);
				//Lifelength period = GlobalObjects.CasEnvironment.Calculator.GetLifelength(frame, _from, _to);
				var total = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(frame, _to);
				var period = new Lifelength(total);
				period.Substract(from);
				//res.Substract(GetLifelength(baseDetail, fromDate));
				var onCCheck = _lastCheckRecord!= null
					? GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(frame, _lastCheckRecord.RecordDate)
					: Lifelength.Null;
				var sinceLast = onCCheck != null ? total - onCCheck : Lifelength.Null;
				dataset.BaseDetailsTable.AddBaseDetailsTableRow
					(framePosition.ToString(),
					 frame.SerialNumber,
					 total.TotalMinutes != null ? total.ToHoursMinutesFormat("") : "",
					 total.Cycles != null ? total.Cycles.ToString() : "",
					 sinceLast.TotalMinutes != null ? sinceLast.ToHoursMinutesFormat("") : "",
					 sinceLast.Cycles != null ? sinceLast.Cycles.ToString() : "",
					 period.TotalMinutes != null ? period.ToHoursMinutesFormat("") : "",
					 period.Cycles != null ? period.Cycles.ToString() : "",
					 frame.Model.ToString());
			}

			var engines = _aircraftBaseDetails.Where(bd => bd.BaseComponentType == BaseComponentType.Engine);
			if (engines.Count() > 0)
			{
				var engineNum = 1;
				foreach (BaseComponent engine in engines)
				{
					var from = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(engine, _from);
					//Lifelength period = GlobalObjects.CasEnvironment.Calculator.GetLifelength(frame, _from, _to);
					var total = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(engine, _to);
					var period = new Lifelength(total);
					period.Substract(from);
					var onCCheck = _lastCheckRecord != null
						? GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(engine, _lastCheckRecord.RecordDate)
						: Lifelength.Null;
					var sinceLast = onCCheck != null ? total - onCCheck : Lifelength.Null;
					dataset.BaseDetailsTable.AddBaseDetailsTableRow
						("Engine " + engineNum,
						 engine.SerialNumber,
						 total.TotalMinutes != null ? total.ToHoursMinutesFormat("") : "",
						 total.Cycles != null ? total.Cycles.ToString() : "",
						 sinceLast.TotalMinutes != null ? sinceLast.ToHoursMinutesFormat("") : "",
						 sinceLast.Cycles != null ? sinceLast.Cycles.ToString() : "",
						 period.TotalMinutes != null ? period.ToHoursMinutesFormat("") : "",
						 period.Cycles != null ? period.Cycles.ToString() : "",
						 engine.Model.ToString());

					engineNum++;
				}    
			}

			var apu = _aircraftBaseDetails.FirstOrDefault(bd => bd.BaseComponentType == BaseComponentType.Apu);
			if (apu!= null)
			{
#if KAC
				var subs = apu.SerialNumber.Split('-');
				var apuNumber = new StringBuilder();
				for (int i = 0; i < subs.Length; i++)
				{
					if(i == subs.Length - 1)
						apuNumber.AppendLine(subs[i]);
					else apuNumber.AppendLine(subs[i] + '-');
				}
				var from = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(apu, _from);
				//Lifelength period = GlobalObjects.CasEnvironment.Calculator.GetLifelength(frame, _from, _to);
				var total = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(apu, _to);
				//Lifelength period = new Lifelength(total);
				//period.Substract(from);

				var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(apu.ParentAircraftId);
				var period = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthForPeriod(parentAircraft, _from, _to);
				var calculated = _currentAircraft.RegistrationNumber == "EX-37401" 
					? period
					: new Lifelength(period.Days, period.Cycles, Convert.ToInt32(period.Cycles * 60 * 1.3));
				//Lifelength total = GlobalObjects.CasEnvironment.Calculator.GetLifelength(apu, _to);
				var onCCheck = _lastCheckRecord != null
					? GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(apu, _lastCheckRecord.RecordDate)
					: Lifelength.Null;
				var sinceLast = onCCheck != null ? total - onCCheck : Lifelength.Null;
				dataset.BaseDetailsTable.AddBaseDetailsTableRow
					("APU",
					 apuNumber.ToString(),
					 total.TotalMinutes != null ? total.Hours.ToString() : "",
					 "--",
					 sinceLast.TotalMinutes != null ? sinceLast.Hours.ToString() : "",
					 "--",
					 calculated.TotalMinutes != null ? calculated.Hours.ToString() : "",
					 "--",
					 apu.Model.ToString());
#else
				Lifelength period = GlobalObjects.CasEnvironment.Calculator.GetLifelength(apu, _from, _to);
				Lifelength total = GlobalObjects.CasEnvironment.Calculator.GetLifelength(apu, _to);
				Lifelength onCCheck = _lastC?heckRecord != null
					? GlobalObjects.CasEnvironment.Calculator.GetLifelength(apu, _lastC?heckRecord.RecordDate)
					: Lifelength.Null;
				Lifelength sinceLast = onCCheck != null ? total - onCCheck : Lifelength.Null;
				dataset.BaseDetailsTable.AddBaseDetailsTableRow
					("APU",
					 apu.SerialNumber,
					 total.TotalMinutes != null ? total.ToHoursMinutesFormat("") : "",
					 "--",
					 sinceLast.TotalMinutes != null ? sinceLast.ToHoursMinutesFormat("") : "",
					 "--",
					 period.TotalMinutes != null ? period.ToHoursMinutesFormat("") : "",
					 "--",
					 apu.Model.ToString());
#endif
			}
		}
		#endregion

		#endregion
	}
}
