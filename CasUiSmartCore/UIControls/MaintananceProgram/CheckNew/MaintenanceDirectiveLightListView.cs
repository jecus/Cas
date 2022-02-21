using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.General.MaintenanceWorkscope;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.MaintananceProgram.CheckNew
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class MaintenanceDirectiveLightListView : BaseGridViewControl<MaintenanceDirective>
	{
		#region Fields

		#endregion

		#region Constructors

		#region public MaintenanceDirectiveLightListView()
		///<summary>
		///</summary>
		public MaintenanceDirectiveLightListView()
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
			AddColumn("AMP", (int)(radGridView1.Width * 0.15f));
			AddColumn("MPD Item", (int)(radGridView1.Width * 0.15f));
			AddColumn("Task Card №", (int)(radGridView1.Width * 0.15f));
			AddColumn("Extension", (int)(radGridView1.Width * 0.11f));
			AddColumn("Description", (int)(radGridView1.Width * 0.24f));
			AddColumn("Check", (int)(radGridView1.Width * 0.09f));
			AddColumn("Program", (int)(radGridView1.Width * 0.15f));
			AddColumn("Work Type", (int)(radGridView1.Width * 0.15f));
			AddColumn("APU Hour", (int)(radGridView1.Width * 0.12f));
			AddColumn("1st. Perf.", (int)(radGridView1.Width * 0.15f));
			AddColumn("Rpt. Intv.", (int)(radGridView1.Width * 0.15f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.14f));
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

			string  firstPerformanceString = "N/A";

			var tcnColor = radGridView1.ForeColor;
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

			var repeat = item.Threshold.RepeatInterval.ToString();
			if (item.APUCalc)
			{
				firstPerformanceString = firstPerformanceString.Replace("FH", "AH");
				repeat = repeat.Replace("FH", "AH");
			}

			//////////////////////////////////////////////////////////////////////////////////////
			var description = item.Description != "" ? item.Description : "N/A";
			var taskCheck = item.TaskNumberCheck != "" ? item.TaskNumberCheck : "N/A";
			var check = item.MaintenanceCheck != null ? item.MaintenanceCheck.Name : "N/A";
			var condition = !string.IsNullOrEmpty(firstPerformanceString) ? (item.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst
				? "/WF"
				: "/WL") : "";
			var conditionRepeat = !item.Threshold.RepeatInterval.IsNullOrZero() ? (item.Threshold.RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst
				? "/WF"
				: "/WL") : "";

			if (!item.HasTaskCardFile)
				tcnColor = Color.MediumVioletRed;


			subItems.Add(CreateRow(item.ScheduleItem, item.ScheduleItem));
			subItems.Add(CreateRow(taskCheck, taskCheck));
			subItems.Add(CreateRow(item.TaskCardNumber, item.TaskCardNumber, tcnColor));
			subItems.Add(CreateRow(item.Extension.ToString("F0"), item.Extension));
			subItems.Add(CreateRow(description, description));
			subItems.Add(CreateRow(check, check));
			subItems.Add(CreateRow(item.Program.ToString(), item.Program));
			subItems.Add(CreateRow(item.WorkType.ToString(), item.WorkType));
			subItems.Add(CreateRow(item.APUCalc ? "Yes" : "No", item.APUCalc));
			subItems.Add(CreateRow($"{firstPerformanceString} {condition}", firstPerformanceString));
			subItems.Add(CreateRow($"{repeat} {conditionRepeat}", item.Threshold.RepeatInterval));
			subItems.Add(CreateRow(author, author));

			return subItems;
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			
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
