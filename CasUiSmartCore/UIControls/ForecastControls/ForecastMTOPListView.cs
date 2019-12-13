using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Calculations.MTOP.Interfaces;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;


namespace CAS.UI.UIControls.ForecastControls
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class ForecastMTOPListView : BaseGridViewControl<NextPerformance>
	{
		#region public ForecastListView()
		///<summary>
		///</summary>
		public ForecastMTOPListView()
		{
			InitializeComponent();
			DisableContectMenu();
		}
		#endregion

		#region Methods

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Check", (int)(radGridView1.Width * 0.10f));
			AddColumn("ATA", (int)(radGridView1.Width * 0.10f));
			AddColumn("Type", (int)(radGridView1.Width * 0.10f));
			AddColumn("Title", (int)(radGridView1.Width * 0.2f));
			AddColumn("Description", (int)(radGridView1.Width * 0.2f));
			AddColumn("Times", (int)(radGridView1.Width * 0.2f));
			AddColumn("Work Type", (int)(radGridView1.Width * 0.2f));
			AddColumn("Check", (int)(radGridView1.Width * 0.2f));
			AddDateColumn("Next", (int)(radGridView1.Width * 0.2f));
			AddColumn("Fst.Perf", (int)(radGridView1.Width * 0.2f));
			AddColumn("Thresh", (int)(radGridView1.Width * 0.2f));
			AddColumn("ThreshRepeat", (int)(radGridView1.Width * 0.2f));
			AddColumn("Overdue/Remain", (int)(radGridView1.Width * 0.2f));
			AddColumn("Last", (int)(radGridView1.Width * 0.2f));
			AddColumn("Kit", (int)(radGridView1.Width * 0.2f));
			AddColumn("MH", (int)(radGridView1.Width * 0.2f));
			AddColumn("Cost", (int)(radGridView1.Width * 0.2f));
			AddColumn("Total MH", (int)(radGridView1.Width * 0.2f));
			AddColumn("Total Cost", (int)(radGridView1.Width * 0.2f));
			AddColumn("X1", (int)(radGridView1.Width * 0.2f));
			AddColumn("Forecast Data", (int)(radGridView1.Width * 0.2f));
			AddColumn("X2", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)

		protected override void GroupingItems()
		{
			Grouping("Check");
		}

		#endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, NextPerformance item)
		protected override void  SetItemColor(GridViewRowInfo listViewItem, NextPerformance item)
		{
			Color itemForeColor = Color.Black;

			if (item is MaintenanceNextPerformance)
			{
				MaintenanceNextPerformance mnp = item as MaintenanceNextPerformance;
				foreach (GridViewCellInfo cell in listViewItem.Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.ForeColor = mnp == ((MaintenanceCheck)item.Parent).GetPergormanceGroupWhereCheckIsSenior()[0]
						? Color.Black
						: Color.Gray;
				}

				if (mnp.CalcForHight)
				{
					foreach (GridViewCellInfo cell in listViewItem.Cells)
					{
						cell.Style.CustomizeFill = true;
						cell.Style.BackColor = Color.FromArgb(Highlight.PurpleLight.Color);
						cell.Style.ForeColor = itemForeColor;
					}
				}
			}
			else
			{
				IDirective imd = item.Parent;
				foreach (GridViewCellInfo cell in listViewItem.Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.White;
					if (imd.Condition == ConditionState.Notify)
						cell.Style.BackColor = Color.FromArgb(Highlight.Yellow.Color);
					if (imd.Condition == ConditionState.Overdue)
						cell.Style.BackColor = Color.FromArgb(Highlight.Red.Color);
					if (imd.Percents != null && imd.Percents > 0)
						cell.Style.BackColor = Color.FromArgb(Highlight.Green.Color);

					cell.Style.ForeColor = imd.NextPerformances.IndexOf(item) == 0
						? Color.Black
						: Color.Gray; ;
				}
			}

			if (item.BlockedByPackage != null)
			{
				foreach (GridViewCellInfo cell in listViewItem.Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.FromArgb(Highlight.Grey.Color);
					cell.Style.ForeColor = itemForeColor;
				}
			}


			Color itemBacBlackolor = listViewItem.Cells[0].Style.BackColor;
			if (item.Parent is MaintenanceDirective)
			{
				var mpd = item.Parent as MaintenanceDirective;
				if (mpd.RecalculateTenPercent)
				{
					itemBacBlackolor = Color.DodgerBlue;
					foreach (GridViewCellInfo cell in listViewItem.Cells)
					{
						cell.Style.CustomizeFill = true;
						cell.Style.BackColor = itemBacBlackolor;
					}
				}
			}
		}
		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(NextPerformance item)

		protected override List<CustomCell> GetListViewSubItems(NextPerformance item)
		{
			var subItems = new List<CustomCell>();
			Color tcnColor = radGridView1.ForeColor;
			int index;
			if (item is MaintenanceNextPerformance)
			{
				MaintenanceCheck mc = item.Parent as MaintenanceCheck;
				if (mc != null && mc.GetPergormanceGroupWhereCheckIsSenior().FirstOrDefault() != null)
				{
					index = mc.GetPergormanceGroupWhereCheckIsSenior().First() == item
						? 0
						: item.Parent.NextPerformances.IndexOf(item);
				}
				else
				{
					index = item.Parent.NextPerformances.IndexOf(item);
				}
			}
			else
			{
				index = item.Parent.NextPerformances.IndexOf(item);
			}
			string timesString = index == 0 ? item.Parent.TimesToString : "#" + (index + 1);
			int times = index == 0 ? item.Parent.Times : index + 1;
			double manHours = item.Parent is IEngineeringDirective ? ((IEngineeringDirective)item.Parent).ManHours : 0;
			double cost = item.Parent is IEngineeringDirective ? ((IEngineeringDirective)item.Parent).Cost : 0;
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var title = item.Title;
			if (item.Parent is Directive)
			{
				var directive = item.Parent as Directive;

				if (directive.DirectiveType == DirectiveType.SB)
					title = directive.ServiceBulletinNo;
				else if (directive.DirectiveType == DirectiveType.EngineeringOrders)
					title = directive.EngineeringOrders;
			}

			if (item.Parent is MaintenanceDirective)
			{
				var d = item.Parent as MaintenanceDirective;
				if (d.TaskCardNumberFile == null)
					tcnColor = Color.MediumVioletRed;

			}

			var temp = "";
			if (item.Parent is IMtopCalc)
				temp = $"Check: {item.Group}-{item.ParentCheck.Name} ({item.ParentCheck.NextPerformances.FirstOrDefault(i => i.Group == item.Group)?.PerformanceSource})";
			else temp = $"{ListViewGroupHelper.GetGroupString(item)} | Date: {item.PerformanceDate?.ToString(new GlobalTermsProvider()["DateFormat"].ToString())}";

				subItems.Add(CreateRow(temp, temp ));
			subItems.Add(CreateRow(item.ATAChapter?.ToString(), item.ATAChapter ));
			subItems.Add(CreateRow(item.Parent.SmartCoreObjectType.ToString(), item.Parent.SmartCoreObjectType));
			subItems.Add(CreateRow(title, title, tcnColor));
			subItems.Add(CreateRow(item.Description, item.Description ));
			subItems.Add(CreateRow(timesString, times ));
			subItems.Add(CreateRow(item.WorkType, item.WorkType ));
			subItems.Add(CreateRow(item.MaintenanceCheck != null ? item.MaintenanceCheck.ToString() : "", item.MaintenanceCheck ));
			subItems.Add(CreateRow(item.PerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)item.PerformanceDate), item.PerformanceDate ));

			//item.PerformanceSource?.Resemble(item.Parent.Threshold.FirstPerformanceSinceNew);
			
			subItems.Add(CreateRow(item.PerformanceSource?.ToString(), item.PerformanceSource ));
			if (item.Parent is IMtopCalc)
			{
				var d = item.Parent as IMtopCalc;
				d.PhaseRepeat?.Resemble(item.Parent.Threshold.RepeatInterval);
				subItems.Add(CreateRow(d.PhaseThresh?.ToString(), d.PhaseThresh));
				subItems.Add(CreateRow(d.PhaseRepeat?.ToString(), d.PhaseRepeat ));
				
			}
			else subItems.Add(CreateRow(item.Parent.Threshold.RepeatInterval.ToString(), item.Parent.Threshold.RepeatInterval ));
			subItems.Add(CreateRow(item.Remains.ToString(), item.Remains ));
			subItems.Add(CreateRow(item.Parent.LastPerformance?.OnLifelength.ToString(), item.Parent.LastPerformance));

			subItems.Add(CreateRow(item.KitsToString, item.Kits?.Count ));
			subItems.Add(CreateRow(manHours.ToString(), manHours ));
			subItems.Add(CreateRow(cost.ToString(), cost ));
			subItems.Add(CreateRow("", "" ));
			subItems.Add(CreateRow("", "" ));
			subItems.Add(CreateRow(item.BeforeForecastResourceRemain != null ? item.BeforeForecastResourceRemain?.ToString() : "", item.BeforeForecastResourceRemain ));
			subItems.Add(CreateRow(item.Parent?.ForecastLifelength?.ToString(), item.Parent?.ForecastLifelength ));
			subItems.Add(CreateRow(item.Parent.AfterForecastResourceRemain != null ? item.Parent.AfterForecastResourceRemain?.ToString() : "", item.Parent.AfterForecastResourceRemain ));
			subItems.Add(CreateRow(author, author ));

			return subItems;
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem == null) return;

			var dp = ScreenAndFormManager.GetEditScreenOrForm(SelectedItem);
			if (dp.DisplayerType == DisplayerType.Screen)
				e.SetParameters(dp);
			else
				dp.Form.ShowDialog();
		}
		#endregion

		protected override void CustomSort(int ColumnIndex)
		{
			if (OldColumnIndex != ColumnIndex)
				SortMultiplier = -1;
			if (SortMultiplier == 1)
				SortMultiplier = -1;
			else
				SortMultiplier = 1;

			OldColumnIndex = ColumnIndex;
			var resultList = new List<NextPerformance>();
			var list = radGridView1.Rows.Select(i => i).ToList();
			list.Sort(new GridViewDataRowInfoComparer(ColumnIndex, SortMultiplier));

			resultList.AddRange(list.Select(i => i.Tag as NextPerformance));

			SetItemsArray(resultList.ToArray());


		}

		#endregion
	}
}
