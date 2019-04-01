using System.Collections.Generic;
using System.Data;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CASReports.Builders
{
	public class ComponentAMLLPReportBuilder : AbstractReportBuilder
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
			var report = new ComponentMpLLPReport();
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
			foreach (var component in _reportedDirectives)
			{
				if (component == null)
					continue;

				var cat = component.ParentBaseComponent.ChangeLLPCategoryRecords.GetLast().ToCategory;

				var rev = component.Position;
				var revDate = "";
				var mpdItem = component.Description;
				var taskCardNumber = component.PartNumber;
				var docNo = "";
				var threshold = component.LLPData.FirstOrDefault(i => i.ParentCategory.ItemId == cat.ItemId)?.LLPLifeLimit.ToStrings();
				var repeat = "";
				var description = component.Description;
				var applicability = "";
				var zone = "";
				var access = "";
				var manHours = "";

				var ata = $"ATA : {component.ATAChapter}";
				var program = component.PartNumber;
				destinationDateSet.ItemsTable.AddItemsTableRow(rev, revDate, mpdItem, taskCardNumber, docNo, "", threshold, repeat, zone, access, manHours, description, "", applicability, ata, program);
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
