using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CASReports.Builders
{
	public class MaintenanceDirectivesAMReportBuilder : AbstractReportBuilder
	{
		#region Fields

		private byte[] _operatorLogotype;
		private Aircraft _reportedAircraft;
		private string _reportTitle;
		private List<MaintenanceDirective> _reportedDirectives = new List<MaintenanceDirective>();
		public bool IsAWL = false;

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
		public List<MaintenanceDirective> ReportedDirectives
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
			if (IsAWL)
			{
				var report = new MaintenanceDirectiveMpAWLReport();
				report.SetDataSource(GenerateDataSet());
				return report;
			}
			else
			{
				var report = new MaintenanceDirectiveMpReport();
				report.SetDataSource(GenerateDataSet());
				return report;
			}
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

		public void AddDirectives(IEnumerable<MaintenanceDirective> directives)
		{
			_reportedDirectives.Clear();
			_reportedDirectives.AddRange(directives);
			if (_reportedDirectives.Count == 0)
				return;

		}

		#endregion

		private void AddDirectivesToDataSet(MaintenanceDirectivesMPDataSet destinationDateSet)
		{
			foreach (var directive in _reportedDirectives)
			{
				if (directive == null)
					continue;

				var rev = directive.ScheduleRevisionNum;
				var revDate = directive.ScheduleRevisionDate.ToString("dd MMMM yyyy");
				var mpdItem = directive.TaskNumberCheck;
				var taskCardNumber = directive.TaskCardNumber;
				var docNo = directive.MPDTaskNumber;
				var threshold = directive.Threshold.FirstPerformanceToStrings();
				var repeat = directive.RepeatInterval.ToRepeatIntervalsFormat();

				var sb = new StringBuilder();
				foreach (var z in directive.Zone.Split(' '))
					sb.AppendLine(z);

				var zone = sb.ToString();

				sb = new StringBuilder();
				foreach (var z in directive.Access.Split(' '))
					sb.AppendLine(z);

				var access = sb.ToString();

				var manHours = directive.ManHours.ToString();
				var description = directive.Description;
				var applicability = directive.Applicability;

				var ata = $"ATA : {directive.ATAChapter}";
				var program = directive.Program.ToString();

				var pgm = directive.ProgramIndicator != MaintenanceDirectiveProgramIndicator.Unknown ? directive.ProgramIndicator.ShortName : "N/A";

				destinationDateSet.ItemsTable.AddItemsTableRow(rev, revDate, mpdItem, taskCardNumber, docNo, pgm, threshold, repeat, zone, access, manHours, description, "", applicability, ata, program);
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
