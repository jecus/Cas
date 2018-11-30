using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CASReports.Builders
{
	public class ComponentAMReportBuilder : AbstractReportBuilder
	{
		#region Fields

		private byte[] _operatorLogotype;
		private Aircraft _reportedAircraft;
		private string _reportTitle;
		private List<Component> _reportedDirectives = new List<Component>();

		#endregion


		#region Properties

		#region public string ReportTitle { get; set; }

		public string ReportTitle
		{
			get { return _reportTitle; }
			set { _reportTitle = value; }
		}

		#endregion

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
				_operatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogotypeReportLarge;
			}
		}

		#endregion

		#region public List<MaintenanceDirective> ReportedDirectives

		/// <summary>
		/// Директивы включаемые в отчет
		/// </summary>
		public List<Component> ReportedDirectives
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


		#endregion


		#region public override object GenerateReport()

		public override object GenerateReport()
		{
			var report = new ComponentMpReport();
			report.SetDataSource(GenerateDataSet());
			return report;
		}

		#endregion

		#region protected virtual DataSet GenerateDataSet()

		protected virtual DataSet GenerateDataSet()
		{
			var dataset = new MaintenanceDirectivesMPDataSet();
			AddAdditionalDataToDataSet(dataset);
			AddDirectivesToDataSet(dataset);
			return dataset;
		}

		#endregion

		#region public void AddDirectives(IEnumerable<BaseEntityObject> directives)

		public void AddDirectives(IEnumerable<Component> directives)
		{
			_reportedDirectives.Clear();
			_reportedDirectives.AddRange(directives);
			if (_reportedDirectives.Count == 0)
				return;

		}

		#endregion

		private void AddDirectivesToDataSet(MaintenanceDirectivesMPDataSet destinationDateSet)
		{

			var resultComponent = new List<Component>();

			foreach (var component in _reportedDirectives)
			{
				if(resultComponent.FirstOrDefault(i => i.PartNumber.Equals(component.PartNumber) && i.Description.Equals(component.Description)) == null)
					resultComponent.Add(component);
			}


			foreach (var component in resultComponent)
			{
				if (component == null)
					continue;

				var rev = "";
				var revDate = "";
				var mpdItem = "";
				var taskCardNumber = "";
				var docNo = "";
				var threshold = "";
				var repeat = "";
				var description = "";
				var applicability = "";
				var zone = "";
				var access = "";
				var manHours = "";
				var WorkType = "";
				var cat = "";


				foreach (var componentDirective in component.ComponentDirectives)
				{
					if (componentDirective.MaintenanceDirective != null)
					{
						rev += "\n" + componentDirective.MaintenanceDirective.ScheduleRevisionNum;
						revDate += "\n" + componentDirective.MaintenanceDirective.ScheduleRevisionDate;
						mpdItem += "\n" + componentDirective.MaintenanceDirective.TaskNumberCheck;
						taskCardNumber += "\n" + componentDirective.MaintenanceDirective.TaskNumberCheck;
						docNo += "\n" + componentDirective.MaintenanceDirective.MPDTaskNumber;
						threshold = "\n" + componentDirective.MaintenanceDirective.Threshold.FirstPerformanceToStrings();
						repeat = "\n" + componentDirective.MaintenanceDirective.RepeatInterval.ToRepeatIntervalsFormat();
						description = "\n" + componentDirective.MaintenanceDirective.Description;
						applicability = "\n" + componentDirective.MaintenanceDirective.Applicability;
						manHours = "\n" + componentDirective.CMM;
						WorkType = "\n" + componentDirective.MaintenanceDirective.WorkType.ShortName;
						cat = "\n" + componentDirective.MaintenanceDirective.Category.ShortName;
					
						var sb = new StringBuilder();
						foreach (var z in componentDirective.MaintenanceDirective.Zone.Split(' '))
							sb.AppendLine(z);

						zone = sb.ToString();

						sb = new StringBuilder();
						foreach (var z in componentDirective.MaintenanceDirective.Access.Split(' '))
							sb.AppendLine(z);

						access = sb.ToString();
					}
				}


				var ata = $"ATA : {component.ATAChapter}";
				var program = component.PartNumber;
				destinationDateSet.ItemsTable.AddItemsTableRow(rev, revDate, mpdItem, taskCardNumber, cat, WorkType, threshold, repeat, zone, access, manHours, description, "", applicability, ata, program);
			}
		}

		private void AddAdditionalDataToDataSet(MaintenanceDirectivesMPDataSet destinationDateSet)
		{
			string firsttitle = "MPD Item";
			string discriptiontitle = "Description";
			string secondtitle = "Task Card №";

			string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
			string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
			string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
			destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, "", "", firsttitle, secondtitle, discriptiontitle, reportFooter, reportFooterPrepared, reportFooterLink);
		}
	}
}
