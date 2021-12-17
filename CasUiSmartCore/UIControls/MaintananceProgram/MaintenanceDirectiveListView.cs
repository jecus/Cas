﻿using System.Collections.Generic;
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
			OldColumnIndex = 1;
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
			AddColumn("APU Hour", (int)(radGridView1.Width * 0.16f));
			AddColumn("1st. Perf.", (int)(radGridView1.Width * 0.24f));
			AddColumn("Rpt. Intv.", (int)(radGridView1.Width * 0.24f));
			AddColumn("Next(E)", (int)(radGridView1.Width * 0.15f));
			AddColumn("Next Estimated Data", (int)(radGridView1.Width * 0.2f));
			AddColumn("Remain(E)", (int)(radGridView1.Width * 0.2f));
			AddColumn("Next(L)", (int)(radGridView1.Width * 0.15f));
			AddColumn("Next Limit Data", (int)(radGridView1.Width * 0.2f));
			AddColumn("Remain(L)", (int)(radGridView1.Width * 0.24f));
			AddColumn("Last", (int)(radGridView1.Width * 0.15f));
			AddColumn("Last Data", (int)(radGridView1.Width * 0.2f));
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
			AddColumn("RVSM", (int)(radGridView1.Width * 0.10f));
			AddColumn("ETOPS", (int)(radGridView1.Width * 0.10f));
			AddColumn("Skill", (int)(radGridView1.Width * 0.10f));
			AddColumn("Category", (int)(radGridView1.Width * 0.10f));
			AddColumn("Elapsed M.H.", (int)(radGridView1.Width * 0.16f));
			AddColumn("M.H.", (int)(radGridView1.Width * 0.16f));
			AddColumn("Cost", (int)(radGridView1.Width * 0.16f));
			AddColumn("Applicability", (int)(radGridView1.Width * 0.10f));
			AddColumn("Source Task Reference", (int)(radGridView1.Width * 0.10f));
			AddColumn("Reference", (int)(radGridView1.Width * 0.10f));
			AddColumn("Applicability", (int)(radGridView1.Width * 0.10f));
			AddColumn("AD", (int)(radGridView1.Width * 0.10f));
			AddColumn("Component", (int)(radGridView1.Width * 0.10f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("SB Control", (int)(radGridView1.Width * 0.14f));
			AddColumn("Hidden remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("Extension", (int)(radGridView1.Width * 0.16f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, MaintenanceDirective item)

		protected override void SetItemColor(GridViewRowInfo listViewItem, MaintenanceDirective item)
		{
			var itemBackColor = UsefulMethods.GetColor(item);
			var itemForeColor = Color.Black;

			foreach (GridViewCellInfo cell in listViewItem.Cells)
			{
				cell.Style.DrawFill = true;
				cell.Style.CustomizeFill = true;
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
			var defaultDateTime = DateTimeExtend.GetCASMinDateTime();
			var lastComplianceDate = defaultDateTime;
			var nextComplianceDate = defaultDateTime;
			var lastComplianceLifeLength = Lifelength.Zero;
			//Lifelength nextComplianceLifelength = Lifelength.Null;

			string lastPerformanceString, firstPerformanceString = "N/A";

			var tcnColor = radGridView1.ForeColor;
			var kitColor = radGridView1.BackColor;
			var ata = item.ATAChapter;
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

			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var kitRequieredString = item.KitsApplicable ? item.Kits.Count + " EA" : "N/A";
			var ndtString = item.NDTType.ShortName;
			var skillString = item.Skill.ShortName;
			var categoryString = item.Category.ShortName;
			var remarksString = item.Remarks;
			var hiddenRemarksString = item.HiddenRemarks;

			if (lastComplianceDate <= defaultDateTime)
				lastPerformanceString = "N/A";
			else lastPerformanceString = lastComplianceLifeLength.ToString();

			var lastDate = (lastComplianceDate <= defaultDateTime)
				? ""
				: SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate);

			var repeat = item.Threshold.RepeatInterval.ToString();
			if (item.APUCalc)
			{
				firstPerformanceString = firstPerformanceString.Replace("FH", "AH");
				repeat = repeat.Replace("FH", "AH");
			}

			//////////////////////////////////////////////////////////////////////////////////////
			var description = item.Description != "" ? item.Description : "N/A";
			var app = item.IsApplicability ? $"APL {item.Applicability}" : $"N/A {item.Applicability}";
			var taskNumber = item.MPDTaskNumber != "" ? item.MPDTaskNumber : "N/A";
			var taskCheck = item.TaskNumberCheck != "" ? item.TaskNumberCheck : "N/A";
			var maintManual = item.MaintenanceManual != "" ? item.MaintenanceManual : "N/A";
			var mrb = item.MRB != "" ? item.MRB : "N/A";
			var check = item.MaintenanceCheck != null ? item.MaintenanceCheck.Name : "N/A";
			var status = item.Status;
			var condition = !string.IsNullOrEmpty(firstPerformanceString) ? (item.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst
				? "/WF"
				: "/WL") : "";
			var conditionRepeat = !item.Threshold.RepeatInterval.IsNullOrZero() ? (item.Threshold.RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst
				? "/WF"
				: "/WL") : "";

			var ad = item.ItemRelations.FirstOrDefault(i =>
				i.FirtsItemTypeId == SmartCoreType.Directive.ItemId ||
				i.SecondItemTypeId == SmartCoreType.Directive.ItemId)?.AdditionalInformation?.Ad;
			var component = item.ItemRelations.FirstOrDefault(i =>
				i.FirtsItemTypeId == SmartCoreType.ComponentDirective.ItemId ||
				i.SecondItemTypeId == SmartCoreType.ComponentDirective.ItemId)?.AdditionalInformation?.Component;

			if (!item.HasTaskCardFile)
				tcnColor = Color.MediumVioletRed;

			if(item.KitsApplicable && item.Kits.Count == 0)
				kitColor = Color.FromArgb(Highlight.Red.Color);

			subItems.Add(CreateRow(item.ScheduleItem, item.ScheduleItem));
			subItems.Add(CreateRow(taskCheck, taskCheck));
			subItems.Add(CreateRow(item.TaskCardNumber, item.TaskCardNumber, tcnColor));
			subItems.Add(CreateRow(description, description));
			subItems.Add(CreateRow(item.Program.ToString(), item.Program));
			subItems.Add(CreateRow(item.ProgramIndicator.ShortName, item.ProgramIndicator));
			subItems.Add(CreateRow(item.WorkType.ToString(), item.WorkType));
			subItems.Add(CreateRow(check, check));
			subItems.Add(CreateRow(item.APUCalc ? "Yes" : "No", item.APUCalc));
			subItems.Add(CreateRow($"{firstPerformanceString} {condition}", firstPerformanceString));
			subItems.Add(CreateRow($"{repeat} {conditionRepeat}", item.Threshold.RepeatInterval));
			subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.NextPerformance?.PerformanceDate), item.NextPerformance?.PerformanceDate));
			subItems.Add(CreateRow(item.NextPerformance?.PerformanceSource.ToString(), item.NextPerformance?.PerformanceSource));
			subItems.Add(CreateRow(item.NextPerformance?.Remains.ToString(), item.NextPerformance?.Remains));
			subItems.Add(CreateRow(item.NextPerformance?.NextLimit.Days != null ? SmartCore.Auxiliary.Convert.GetDateFormat(item.NextPerformance?.NextPerformanceDateNew) : "", item.NextPerformance?.NextPerformanceDateNew));
			subItems.Add(CreateRow(item.NextPerformance?.NextLimit.ToString(), item.NextPerformance?.NextLimit.ToString()));
			subItems.Add(CreateRow(item.NextPerformance?.RemainLimit.ToString(), item.NextPerformance?.RemainLimit.ToString()));
			subItems.Add(CreateRow(lastDate, lastComplianceDate));
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
			subItems.Add(CreateRow(item.IsRVSM ? "Yes" : "No", item.IsRVSM));
			subItems.Add(CreateRow(item.IsETOPS ? "Yes" : "No", item.IsETOPS));
			subItems.Add(CreateRow(skillString, skillString));
			subItems.Add(CreateRow(categoryString, categoryString));
			subItems.Add(CreateRow(item.Elapsed <= 0 ? "" : item.Elapsed.ToString(), item.Elapsed));
			subItems.Add(CreateRow(item.ManHours <= 0 ? "" : item.ManHours.ToString(), item.ManHours));
			subItems.Add(CreateRow(item.Cost <= 0 ? "" : item.Cost.ToString(), item.Cost));
			subItems.Add(CreateRow(app, app));
			subItems.Add(CreateRow(item.SourceTaskReference, item.SourceTaskReference));
			subItems.Add(CreateRow(item.Reference, item.Reference));
			subItems.Add(CreateRow(ad, ad));
			subItems.Add(CreateRow(component, component));
			subItems.Add(CreateRow(remarksString, remarksString));
			subItems.Add(CreateRow(item.IsSBControl ? "Yes" : "No", item.IsSBControl));
			subItems.Add(CreateRow(hiddenRemarksString, hiddenRemarksString));
			subItems.Add(CreateRow(item.Extension.ToString("F0"), item.Extension));
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
