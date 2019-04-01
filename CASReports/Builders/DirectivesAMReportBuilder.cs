using System.Collections.Generic;
using System.Data;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Directives;

namespace CASReports.Builders
{
	public class DirectivesAMReportBuilder : AbstractReportBuilder
	{
		#region Fields

		private byte[] _operatorLogotype;
		private Aircraft _reportedAircraft;
		private string _reportTitle;
		private List<Directive> _reportedDirectives = new List<Directive>();

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
		public List<Directive> ReportedDirectives
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
			var report = new DirectiveMpReport();
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

		public void AddDirectives(IEnumerable<Directive> directives)
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

				var rev = "";
				var revDate = directive.Threshold.EffectiveDate.ToString("dd MMMM yyyy");
				var mpdItem = directive.EngineeringOrders;
				var taskCardNumber = "";
				var threshold = directive.Threshold.FirstPerformanceToStrings();
				var repeat = directive.RepeatInterval.ToRepeatIntervalsFormat();

				var manHours = directive.ManHours.ToString();
				var description = directive.Description;
				var applicability = directive.Applicability;

				var adno = directive.Title;
				var sbno = directive.ServiceBulletinNo != "" ? directive.ServiceBulletinNo : "";

				var refe = $"AD: {adno}";
				if(!string.IsNullOrEmpty(sbno))
					refe += $" | SB: {sbno}";

				var ata = $"ATA : {directive.ATAChapter}";
				var program = directive.Program.ToString();

				destinationDateSet.ItemsTable.AddItemsTableRow(rev, revDate, mpdItem, taskCardNumber, "FAA", directive.WorkType.ShortName, threshold, repeat, "", "", manHours, description, refe, applicability, ata, program);
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
