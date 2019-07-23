using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MaintenanceWorkscope;
using Telerik.WinControls.UI;
using Convert = System.Convert;

namespace CAS.UI.UIControls.MaintananceProgram
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class MaintenanceDirectiveListView : BaseGridViewControl<MaintenanceDirective>
	{
		#region Fields

		#endregion

		#region Constructors

		#region public MaintenanceDirectiveListView()
		///<summary>
		///</summary>
		public MaintenanceDirectiveListView()
		{
			InitializeComponent();
		}
		#endregion

		#endregion

		#region Methods

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("AMP", (int)(radGridView1.Width * 0.16f));
			AddColumn("MPD Item", (int)(radGridView1.Width * 0.16f));
			AddColumn("Task Card №", (int)(radGridView1.Width * 0.16f));
			AddColumn("Description", (int)(radGridView1.Width * 0.24f));
			AddColumn("Program", (int)(radGridView1.Width * 0.16f));
			AddColumn("Program Indicator", (int)(radGridView1.Width * 0.16f));
			AddColumn("Work Type", (int)(radGridView1.Width * 0.16f));
			AddColumn("Check", (int)(radGridView1.Width * 0.16f));
			AddColumn("APU Calc.", (int)(radGridView1.Width * 0.16f));
			AddColumn("1st. Perf.", (int)(radGridView1.Width * 0.24f));
			AddColumn("Rpt. Intv.", (int)(radGridView1.Width * 0.24f));
			AddColumn("Next", (int)(radGridView1.Width * 0.24f));
			AddColumn("Remain/Overdue", (int)(radGridView1.Width * 0.24f));
			AddColumn("Last", (int)(radGridView1.Width * 0.10f));
			AddColumn("Zone", (int)(radGridView1.Width * 0.16f));
			AddColumn("Work Area", (int)(radGridView1.Width * 0.16f));
			AddColumn("Access", (int)(radGridView1.Width * 0.16f));
			AddColumn("Status", (int)(radGridView1.Width * 0.24f));
			AddColumn("Doc. No", (int)(radGridView1.Width * 0.24f));
			AddColumn("Maint. Manual", (int)(radGridView1.Width * 0.16f));
			AddColumn("MRB", (int)(radGridView1.Width * 0.16f));
			AddColumn("Old Task Card Number", (int)(radGridView1.Width * 0.16f));
			AddColumn("Critical System", (int)(radGridView1.Width * 0.16f));
			AddColumn("ATA Chapter", (int)(radGridView1.Width * 0.16f));
			AddColumn("Kit", (int)(radGridView1.Width * 0.10f));
			AddColumn("NDT", (int)(radGridView1.Width * 0.10f));
			AddColumn("Skill", (int)(radGridView1.Width * 0.10f));
			AddColumn("Category", (int)(radGridView1.Width * 0.10f));
			AddColumn("Elapsed M.H.", (int)(radGridView1.Width * 0.16f));
			AddColumn("M.H.", (int)(radGridView1.Width * 0.16f));
			AddColumn("Cost", (int)(radGridView1.Width * 0.16f));
			AddColumn("Applicability", (int)(radGridView1.Width * 0.10f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("Hidden remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}
		#endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, MaintenanceDirective item)

		protected override void SetItemColor(GridViewRowInfo listViewItem, MaintenanceDirective item)
		{
			Color itemBackColor = UsefulMethods.GetColor(item);
			Color itemForeColor = Color.Black;

			foreach (GridViewCellInfo cell in listViewItem.Cells)
			{
				cell.Style.DrawFill = true;
				cell.Style.CustomizeFill = true;
				cell.Style.BackColor = UsefulMethods.GetColor(item);

				var listViewForeColor = cell.Style.ForeColor;

				if (listViewForeColor != Color.MediumVioletRed)
					cell.Style.ForeColor = itemForeColor;
				cell.Style.BackColor = itemBackColor;
			}
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MaintenanceDirective item)

		protected override List<CustomCell> GetListViewSubItems(MaintenanceDirective item)
		{
			var subItems = new List<CustomCell>();

			//////////////////////////////////////////////////////////////////////////////////////
			//         Определение последнего выполнения директивы и KitRequiered               //
			//////////////////////////////////////////////////////////////////////////////////////
			DateTime defaultDateTime = DateTimeExtend.GetCASMinDateTime();
			DateTime lastComplianceDate = defaultDateTime;
			DateTime nextComplianceDate = defaultDateTime;
			Lifelength lastComplianceLifeLength = Lifelength.Zero;
			//Lifelength nextComplianceLifelength = Lifelength.Null;

			string lastPerformanceString, firstPerformanceString = "N/A";

			Color tcnColor = radGridView1.ForeColor;
			Color kitColor = radGridView1.BackColor;
			AtaChapter ata = item.ATAChapter;
			if(item.LastPerformance != null)
			{
				lastComplianceDate = item.LastPerformance.RecordDate;
				lastComplianceLifeLength = item.LastPerformance.OnLifelength;    
			}
			if (item.Threshold.FirstPerformanceSinceNew != null && !item.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
			{
				firstPerformanceString = "s/n: " + item.Threshold.FirstPerformanceSinceNew;
			}
			if (item.Threshold.FirstPerformanceSinceEffectiveDate != null &&
				!item.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
			{
				if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
				else firstPerformanceString = "";
				firstPerformanceString += "s/e.d: " + item.Threshold.FirstPerformanceSinceEffectiveDate;
			}

		   if (item.NextPerformanceDate != null && item.NextPerformanceDate > defaultDateTime)
			  nextComplianceDate = Convert.ToDateTime(item.NextPerformanceDate);

			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
			string kitRequieredString = item.KitsApplicable ? item.Kits.Count + " EA" : "N/A";
			string ndtString = item.NDTType.ShortName;
			string skillString = item.Skill.ShortName;
			string categoryString = item.Category.ShortName;
			string remarksString = item.Remarks;
			string hiddenRemarksString = item.HiddenRemarks;

			if (lastComplianceDate <= defaultDateTime)
				lastPerformanceString = "N/A";
			else
				lastPerformanceString = SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate) + " " +
										lastComplianceLifeLength;
			string nextComplianceString = ((nextComplianceDate <= defaultDateTime)
											   ? ""
											   : SmartCore.Auxiliary.Convert.GetDateFormat(nextComplianceDate) + " ") +
										  item.NextPerformanceSource;
			string nextRemainString = item.Remains != null && !item.Remains.IsNullOrZero()
										  ? item.Remains.ToString()
										  : "N/A";

			//////////////////////////////////////////////////////////////////////////////////////
			string description = item.Description != "" ? item.Description : "N/A";
			string app = item.IsApplicability ? $"APL {item.Applicability}" : $"N/A {item.Applicability}";
			string taskNumber = item.MPDTaskNumber != "" ? item.MPDTaskNumber : "N/A";
			string taskCheck = item.TaskNumberCheck != "" ? item.TaskNumberCheck : "N/A";
			string maintManual = item.MaintenanceManual != "" ? item.MaintenanceManual : "N/A";
			string mrb = item.MRB != "" ? item.MRB : "N/A";
			string check = item.MaintenanceCheck != null ? item.MaintenanceCheck.Name : "N/A";
			DirectiveStatus status = item.Status;

			if (item.TaskCardNumberFile == null)
				tcnColor = Color.MediumVioletRed;

			if(item.KitsApplicable && item.Kits.Count == 0)
				kitColor = Color.FromArgb(Highlight.Red.Color);

			subItems.Add(CreateRow(item.ScheduleItem, item.ScheduleItem));
			subItems.Add(CreateRow(taskCheck, taskCheck));
			subItems.Add(CreateRow(item.TaskCardNumber, item.TaskCardNumber, tcnColor));
			subItems.Add(CreateRow(description, description));
			subItems.Add(CreateRow(item.Program.ToString(), item.Program));
			subItems.Add(CreateRow(item.ProgramIndicator.ToString(), item.ProgramIndicator));
			subItems.Add(CreateRow(item.WorkType.ToString(), item.WorkType));
			subItems.Add(CreateRow(check, check));
			subItems.Add(CreateRow(item.APUCalc ? "Yes" : "No", item.APUCalc));
			subItems.Add(CreateRow(firstPerformanceString, firstPerformanceString));
			subItems.Add(CreateRow(item.Threshold.RepeatInterval.ToString(), item.Threshold.RepeatInterval));
			subItems.Add(CreateRow(nextComplianceString, nextComplianceDate));
			subItems.Add(CreateRow(nextRemainString, nextRemainString));
			subItems.Add(CreateRow(lastPerformanceString, lastComplianceDate));
			subItems.Add(CreateRow(item.Zone, item.Zone));
			subItems.Add(CreateRow(item.Workarea, item.Workarea));
			subItems.Add(CreateRow(item.Access, item.Access));
			subItems.Add(CreateRow(status.ToString(), status));
			subItems.Add(CreateRow(taskNumber, taskNumber));
			subItems.Add(CreateRow(maintManual, maintManual));
			subItems.Add(CreateRow(mrb, mrb));
			subItems.Add(CreateRow(item.TaskCardNumber, item.TaskCardNumber));
			subItems.Add(CreateRow(item.CriticalSystem.ToString(), item.CriticalSystem));
			subItems.Add(CreateRow(ata.ToString(), ata));
			subItems.Add(CreateRow(kitRequieredString, kitRequieredString, kitColor));
			subItems.Add(CreateRow(ndtString, ndtString));
			subItems.Add(CreateRow(skillString, skillString));
			subItems.Add(CreateRow(categoryString, categoryString));
			subItems.Add(CreateRow(item.Elapsed <= 0 ? "" : item.Elapsed.ToString(), item.Elapsed));
			subItems.Add(CreateRow(item.ManHours <= 0 ? "" : item.ManHours.ToString(), item.ManHours));
			subItems.Add(CreateRow(item.Cost <= 0 ? "" : item.Cost.ToString(), item.Cost));
			subItems.Add(CreateRow(app, app));
			subItems.Add(CreateRow(remarksString, remarksString));
			subItems.Add(CreateRow(hiddenRemarksString, hiddenRemarksString));
			subItems.Add(CreateRow(author, author));

			return subItems;
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				var dp = ScreenAndFormManager.GetMaintenanceDirectiveScreen(SelectedItem);
				e.SetParameters(dp);
			}
		}
		#endregion

		protected override void SetTotalText()
		{
			var dir = GetItemsArray().Select(i => i);

			var dict = new List<string>();
			foreach (var directive in dir)
			{
				var value = directive.TaskNumberCheck;
				if (value.LastIndexOf("(") > 0)
					value = value.Substring(0, value.LastIndexOf("("));

				if (!dict.Contains(value))
					dict.Add(value);
			}


			this.labelTotal.Text = $"Total: {dict.Count}/{radGridView1.Rows.Count}";
		}

		#endregion
	}
}
