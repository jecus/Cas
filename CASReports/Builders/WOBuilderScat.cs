using System;
using System.Collections.Generic;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета Release To Service 
    /// </summary>
    public class WOBuilderScat : AbstractReportBuilder
	{

        #region Fields

        private WorkPackage _currentWorkPackage;

		private readonly bool _isScatReport;

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

		public ICommonCollection<BaseEntityObject> Items { get; set; }

		#endregion

        #endregion

        #region Constructor
        /// <summary>
        /// Создается построитель отчета Release To Service 
        /// </summary>
        /// <param name="workPackage">Рабочий пакет</param>
        /// <param name="items"></param>
        public WOBuilderScat(WorkPackage workPackage)
        {
            _currentWorkPackage = workPackage;
        }

		#endregion

		#region Methods

		#region public object GenerateReport()

		/// <summary>
		/// Сгенерируовать отчет по данным, добавленным в текущий объект
		/// </summary>
		/// <returns>Построенный отчет</returns>
		public override object GenerateReport()
		{
			var report = new WOScat();
			report.SetDataSource(GenerateDataSet());
			return report;
		}

		#endregion

		#region private WorkPackageTitlePageDataSet GenerateDataSet()

		private WorkPackageTitlePageDataSet GenerateDataSet()
		{
			var dataSet = new WorkPackageTitlePageDataSet();
			AddReleaseToServiceInformationToDataSet(dataSet);
			AddItemsToDataSet(dataSet);
			return dataSet;
		}

		#endregion

		private void AddItemsToDataSet(WorkPackageTitlePageDataSet destinationDataSet)
		{
			int count = 1;

			foreach (var item in _currentWorkPackage.MaintenanceDirectives)
			{
				destinationDataSet.WPItemsTable.AddWPItemsTableRow(item.TaskCardNumber,
					0, item.Description.Replace("\r\n", " "), count.ToString(), item.TaskNumberCheck);
				count++;
			}

			foreach (Directive item in _currentWorkPackage.AdStatus)
			{
				var directiveString = item.Title + (string.IsNullOrEmpty(item.Paragraph) ? "" : (" § " + item.Paragraph));
				var taskCardString = item.EngineeringOrders != "" ? item.EngineeringOrders : "*";

				destinationDataSet.WPItemsTable.AddWPItemsTableRow(directiveString,
					0, item.Description, count.ToString(), taskCardString);
				count++;
			}

			foreach (Directive item in _currentWorkPackage.AdStatus)
			{
				var directiveString = "EO" + (string.IsNullOrEmpty(item.Paragraph) ? "" : (" § " + item.Paragraph));
				var taskCardString = item.EngineeringOrders != "" ? item.EngineeringOrders : "*";

				destinationDataSet.WPItemsTable.AddWPItemsTableRow(directiveString,
					0, item.Description, count.ToString(), taskCardString);
				count++;
			}

			foreach (var item in _currentWorkPackage.ComponentDirectives)
			{
				var d = item.ParentComponent;
				destinationDataSet.WPItemsTable.AddWPItemsTableRow(item.MaintenanceDirective?.TaskNumberCheck,
					0, item.DirectiveType + " for " + d.Description + " P/N:" + d.PartNumber + " S/N:" + d.SerialNumber, count.ToString(), item.MaintenanceDirective?.TaskCardNumber);
				count++;
			}
		}


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
			var wpTitle = _currentWorkPackage.Title;
			var wpCreatedBy = _currentWorkPackage.Author;
			var wpPublishedBy = _currentWorkPackage.PublishedBy;
			var accomplich = Items.Count.ToString();
			var createDate = _currentWorkPackage.CreateDate;


			destinationDataSet.MainDataTable.AddMainDataTableRow(GlobalObjects.ComponentCore.GetBaseComponentById(aircraft.AircraftFrameId).SerialNumber,
																 manufacturer,
																 registrationMark, model, serialNumber,
																 totalCycles, totalFlightHours,
																 operatorLogotype,
																 operatorName, operatorAddress,
																 workPerformedStartDate,
																 workPerformedEndDate,
																 workPerformedStation,
																 workPerformedWorkOrderNo,
																 wpTitle, wpCreatedBy, wpPublishedBy, accomplich, createDate);
		}

		#endregion

		private string GetAccomplich(IEnumerable<WorkPackageRecord> workPakageRecords)
		{
			var groups = new List<string>();

			foreach (var workPackageRecord in workPakageRecords)
			{
				IBaseEntityObject parent = workPackageRecord.Task;

				if (parent is Directive)
				{
					var directive = (Directive) parent;
					if (directive is DeferredItem)
						groups.Add("Deffred");
					else if (directive is DamageItem)
						groups.Add("Damage");
					else if (directive.DirectiveType == DirectiveType.OutOfPhase)
						groups.Add("Out of phase");
					else
					{
						if (directive.DirectiveType.ItemId == DirectiveType.AirworthenessDirectives.ItemId)
							groups.Add("AD");
						else if (directive.DirectiveType.ItemId == DirectiveType.EngineeringOrders.ItemId)
							groups.Add("EO");
						else if (directive.DirectiveType.ItemId == DirectiveType.SB.ItemId)
							groups.Add("SB");
					}
				}
				else if (parent is BaseComponent)
					groups.Add("Base Component");
				else if (parent is Component)
					groups.Add("Component");
				else if (parent is ComponentDirective)
					groups.Add("Component directive");
				else if (parent is MaintenanceCheck)
					groups.Add("MC");
				else if (parent is MaintenanceDirective)
					groups.Add("MPD");
				else if (parent is NonRoutineJob)
					groups.Add("NRJ");
			}
			return string.Join("+" , groups.Distinct().ToArray());
		}

		#endregion
	}
}
