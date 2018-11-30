using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.WorkPackage;

namespace CASReports.Builders
{
	public class MaintenanceReportBuilder : AbstractReportBuilder
	{
		#region Fields

		private string _reportTitle = "Maintenance Report";
		private byte[] _operatorLogotype;
		private Aircraft _reportedAircraft;
		private Operator _reportedOperator;
		private WorkPackage _reportedWorkPackage;

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
				_reportedOperator = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId);
				_operatorLogotype = _reportedOperator.LogotypeReportVeryLarge;
			}
		}

		#endregion

		#region public WorkPackage ReportedWorkPackage

		public WorkPackage ReportedWorkPackage
		{
			get { return _reportedWorkPackage; }
			set { _reportedWorkPackage = value; }
		}

		#endregion

		#endregion

		#region public override object GenerateReport()

		public override object GenerateReport()
		{
			var report = new MaintenanceReport();
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
			var dataset = new MaintenanceReportDataSet();
			AddBaseComponentDataToDataSet(dataset);
			AddAdditionalDataToDataSet(dataset);
			AddWorkPackageDataToDataSet(dataset);
			AddAircraftDataToDataSet(dataset);
			return dataset;
		}

		#endregion

		#region private void AddBaseComponentDataToDataSet(MaintenanceReportDataSet dataset)

		private void AddBaseComponentDataToDataSet(MaintenanceReportDataSet dataset)
		{
			var baseComponents =
				GlobalObjects.CasEnvironment.BaseComponents.Where(
					c => c.ParentAircraftId == _reportedAircraft.ItemId && c.BaseComponentType != BaseComponentType.Frame);

			foreach (var baseComponent in baseComponents)
			{
				var name = baseComponent.BaseComponentType.ToString();
				var manufacturer = baseComponent.Manufacturer;
				var serialNumber = baseComponent.SerialNumber;
				var partNumber = baseComponent.BaseComponentType == BaseComponentType.Engine ? baseComponent.Model.ToString() : baseComponent.PartNumber;


				var currentDetailSource = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(baseComponent, _reportedWorkPackage.ClosingDate);
				var tsn = currentDetailSource.Hours != null ? currentDetailSource.Hours.ToString() : "";
				var tso = "";

				//поиск директив деталей
				var directives = GlobalObjects.ComponentCore.GetComponentDirectives(baseComponent, true);
				//поиск директивы ремонта
				var overhauls = directives.Where(d => d.DirectiveType == ComponentRecordType.Overhaul).ToList();
				var lastOverhaulDate = DateTime.MinValue;
				if (overhauls.Count != 0)
				{
					ComponentDirective lastOverhaul = null;
					foreach (var d in overhauls)
					{
						GlobalObjects.PerformanceCalculator.GetNextPerformance(d);
						if (d.LastPerformance == null || d.LastPerformance.RecordDate <= lastOverhaulDate) continue;

						lastOverhaulDate = d.LastPerformance.RecordDate;
						lastOverhaul = d;
					}

					if (lastOverhaul != null)
					{
						currentDetailSource.Substract(lastOverhaul.LastPerformance.OnLifelength);
						tso = currentDetailSource.Hours.ToString();
					}
				}

				dataset.BaseDetailDataTable.AddBaseDetailDataTableRow(name, manufacturer, serialNumber, partNumber, tsn , tso);
			}	
		}

		#endregion

		#region private void AddAircraftDataToDataSet(MaintenanceReportDataSet dataset)

		private void AddAircraftDataToDataSet(MaintenanceReportDataSet dataset)
		{
			var regNumber = _reportedAircraft.RegistrationNumber;
			var serialNumber = _reportedAircraft.SerialNumber;
			var model = _reportedAircraft.Model.ToString();

			var reportAircraftLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(_reportedAircraft, _reportedWorkPackage.ClosingDate);
			var sinceNewHours = reportAircraftLifeLenght.Hours != null ? (int)reportAircraftLifeLenght.Hours : 0;
			var sinceNewCycles = reportAircraftLifeLenght.Cycles != null ? (int)reportAircraftLifeLenght.Cycles : 0;

			dataset.AircraftDataTable.AddAircraftDataTableRow(regNumber, serialNumber, model, sinceNewHours, sinceNewCycles);
		}

		#endregion

		#region private void AddWorkPackageDataToDataSet(MaintenanceReportDataSet dataset)

		private void AddWorkPackageDataToDataSet(MaintenanceReportDataSet dataset)
		{
			var publishDate = _reportedWorkPackage.PublishingDate.ToString("dd MMMM yyyy");
			var closeDate = _reportedWorkPackage.ClosingDate.ToString("dd MMMM yyyy");
			var wpNumber = _reportedWorkPackage.Number;
			var title = _reportedWorkPackage.Title;

			dataset.WorkPackageDataTable.AddWorkPackageDataTableRow(publishDate, closeDate, wpNumber, title);

			foreach (var wpr in _reportedWorkPackage.WorkPakageRecords)
			{
				string descriptionOfTaskTitle;

				if (wpr.Task is Component)
				{
					var component = wpr.Task as Component;
					descriptionOfTaskTitle = $"P/N:{component.PartNumber} Pos:{component.Position} S/N:{component.SerialNumber} {component.WorkType}";
					dataset.TaskDataTable.AddTaskDataTableRow(descriptionOfTaskTitle);
				}
				else if (wpr.Task is ComponentDirective)
				{
					var dd = wpr.Task as ComponentDirective;
					descriptionOfTaskTitle = dd.ParentComponent != null ? $"P/N:{dd.ParentComponent.PartNumber} Pos:{dd.ParentComponent.Position} S/N:{dd.ParentComponent.SerialNumber} {dd.ParentComponent.WorkType}" : "";
					dataset.TaskDataTable.AddTaskDataTableRow(descriptionOfTaskTitle);
				}
				else if(wpr.Task is NonRoutineJob)
				{
					var nrj = wpr.Task as NonRoutineJob;
					dataset.TaskDataTable.AddTaskDataTableRow($"{nrj.Title} {nrj.Description}");
				}
				else if (wpr.Task is Directive)
				{
					var directive = wpr.Task as Directive;

					if(directive.DirectiveType == DirectiveType.OutOfPhase)
						dataset.TaskDataTable.AddTaskDataTableRow($"{directive.Title} {directive.Description}");

					if(directive.DirectiveType == DirectiveType.EngineeringOrders)
						dataset.ADSBDataTable.AddADSBDataTableRow($"{directive.DirectiveType.ShortName} {directive.EngineeringOrders} {directive.Description}");

					if (directive.DirectiveType == DirectiveType.SB || directive.DirectiveType == DirectiveType.AirworthenessDirectives)
						dataset.ADSBDataTable.AddADSBDataTableRow($"{directive.DirectiveType.ShortName} {directive.Title}");
				}
			}

			if(dataset.ADSBDataTable.Rows.Count == 0)
				dataset.ADSBDataTable.AddADSBDataTableRow("N/A");
			if (dataset.TaskDataTable.Rows.Count == 0)
				dataset.TaskDataTable.AddTaskDataTableRow("N/A");

		}

		#endregion

		#region private void AddAdditionalDataToDataSet(MaintenanceReportDataSet dataset)

		private void AddAdditionalDataToDataSet(MaintenanceReportDataSet dataset)
		{
			var phone = $"тел./факс  {_reportedOperator.Phone}";
			dataset.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, phone, _reportedOperator.Address, _reportedOperator.Name);
		}

		#endregion
	}
}