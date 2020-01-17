using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Calculations.MTOP;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Purchase;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;


namespace CAS.UI.UIControls.LDND
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class LDNDListView : BaseGridViewControl<NextPerformance>
	{
		#region public ForecastListView()
		///<summary>
		///</summary>
		public LDNDListView()
		{
			InitializeComponent();
			DisableContectMenu();
			EnableCustomSorting = false;
			this.radGridView1.MasterTemplate.GroupComparer = new GroupComparer();
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
			AddColumn("Item №", (int)(radGridView1.Width * 0.14f));
			AddColumn("Task Card №", (int)(radGridView1.Width * 0.14f));
			AddColumn("Description", (int)(radGridView1.Width * 0.2f));
			AddColumn("Work Type", (int)(radGridView1.Width * 0.2f));
			AddColumn("Thresh", (int)(radGridView1.Width * 0.24f));
			AddColumn("Rpt. Intv.", (int)(radGridView1.Width * 0.20f));
			AddColumn("Next(E)", (int)(radGridView1.Width * 0.15f));
			AddColumn("Next Estimated Data", (int)(radGridView1.Width * 0.2f));
			AddColumn("Remain(E)", (int)(radGridView1.Width * 0.2f));
			AddColumn("Next(L)", (int)(radGridView1.Width * 0.15f));
			AddColumn("Next Limit Data", (int)(radGridView1.Width * 0.2f));
			AddColumn("Remain(L)", (int)(radGridView1.Width * 0.24f));
			AddColumn("Last", (int)(radGridView1.Width * 0.15f));
			AddColumn("Last Data", (int)(radGridView1.Width * 0.2f));
			AddColumn("Kit", (int)(radGridView1.Width * 0.08f));
			AddColumn("MH", (int)(radGridView1.Width * 0.08f));
			
			AddColumn("Type", (int)(radGridView1.Width * 0.07f));
			AddColumn("ATA", (int)(radGridView1.Width * 0.10f));
			AddColumn("Times", (int)(radGridView1.Width * 0.2f));
			AddColumn("Check", (int)(radGridView1.Width * 0.2f));
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
		protected override void SetItemColor(GridViewRowInfo listViewItem, NextPerformance item)
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
			var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
			var lastComplianceLifeLength = Lifelength.Zero;
			string lastPerformanceString, firstPerformanceString = "N/A";

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
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var title = item.Title;
			var card = "";
			var description = item.Description;
			if (item.Parent is Directive directive)
			{
				if (directive.DirectiveType == DirectiveType.SB)
					title = directive.ServiceBulletinNo;
				else if (directive.DirectiveType == DirectiveType.EngineeringOrders)
					title = directive.EngineeringOrders;
				card = directive.EngineeringOrders;
			}
			else if (item.Parent is MaintenanceDirective d)
			{
				if (d.TaskCardNumberFile == null)
					tcnColor = Color.MediumVioletRed;
				card = d.TaskCardNumber;
			}
			else if (item.Parent is ComponentDirective c)
			{
				description = item.Title;
				title = c.MaintenanceDirective?.TaskNumberCheck ?? "";
				card = c.MaintenanceDirective?.TaskCardNumber ?? "";
			}
			//Последнее выполнение
			if (item.Parent.LastPerformance != null &&
			    item.Parent.LastPerformance.RecordDate > lastComplianceDate)
			{
				lastComplianceDate = item.Parent.LastPerformance.RecordDate;
				lastComplianceLifeLength = item.Parent.LastPerformance.OnLifelength;
			}

			//Следующее выполнение
			if (item.Parent.Threshold.FirstPerformanceSinceNew != null && !item.Parent.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
			{
				firstPerformanceString = "s/n: " + item.Parent.Threshold.FirstPerformanceSinceNew;
			}
			if (item.Parent.Threshold.FirstPerformanceSinceEffectiveDate != null &&
			    !item.Parent.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
			{
				if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
				else firstPerformanceString = "";
				firstPerformanceString += "s/e.d: " + item.Parent.Threshold.FirstPerformanceSinceEffectiveDate;
			}
			var repeatInterval = item.Parent.Threshold.RepeatInterval;

			if (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
				lastPerformanceString = "N/A";
			else lastPerformanceString = lastComplianceLifeLength.ToString();

			var lastDate = (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
				? ""
				: SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate);

			var condition = !string.IsNullOrEmpty(firstPerformanceString) ? (item.Parent.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst
				? "/WF"
				: "/WL") : "";
			var conditionRepeat = !item.Parent.Threshold.RepeatInterval.IsNullOrZero() ? (item.Parent.Threshold.RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst
				? "/WF"
				: "/WL") : "";
			

			var temp = "";
			if (item.Parent is IMtopCalc)
				temp = $"Check: {item.Group}-{item.ParentCheck?.Name} ({item.ParentCheck?.NextPerformances.FirstOrDefault(i => i.Group == item.Group)?.PerformanceSource})";
			else temp = $"{ListViewGroupHelper.GetGroupString(item)} | Date: {item.PerformanceDate?.ToString(new GlobalTermsProvider()["DateFormat"].ToString())}";
			
			subItems.Add(CreateRow(temp, item.ParentCheck?.NextPerformances.FirstOrDefault(i => i.Group == item.Group)?.PerformanceSource));
			subItems.Add(CreateRow(title, title, tcnColor));
			subItems.Add(CreateRow(card, card, tcnColor));
			subItems.Add(CreateRow(description, description));
			subItems.Add(CreateRow(item.WorkType, item.WorkType));
			subItems.Add(CreateRow($"{firstPerformanceString} {condition}", firstPerformanceString));
			subItems.Add(CreateRow($"{repeatInterval} {conditionRepeat}", repeatInterval));
			subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.PerformanceDate), item.PerformanceDate));
			subItems.Add(CreateRow(item.PerformanceSource.ToString(), item.PerformanceSource));
			subItems.Add(CreateRow(item.Remains.ToString(), item.Remains));
			subItems.Add(CreateRow(item.NextLimit.Days != null ? SmartCore.Auxiliary.Convert.GetDateFormat(item.NextPerformanceDateNew) : "", item.NextPerformanceDateNew));
			subItems.Add(CreateRow(item.NextLimit.ToString(), item.NextLimit.ToString()));
			subItems.Add(CreateRow(item.RemainLimit.ToString(), item.RemainLimit.ToString()));
			subItems.Add(CreateRow(lastDate, lastComplianceDate));
			subItems.Add(CreateRow(lastPerformanceString, lastComplianceDate));
			subItems.Add(CreateRow(item.KitsToString, item.Kits?.Count));
			subItems.Add(CreateRow(manHours.ToString(), manHours));
			
			subItems.Add(CreateRow(item.Parent.SmartCoreObjectType.ToString(), item.Parent.SmartCoreObjectType));
			subItems.Add(CreateRow(item.ATAChapter?.ToString(), item.ATAChapter));
			subItems.Add(CreateRow(timesString, times));
			subItems.Add(CreateRow(item.MaintenanceCheck != null ? item.MaintenanceCheck.ToString() : "", item.MaintenanceCheck));
			subItems.Add(CreateRow(author, author));

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


	public class GroupComparer : IComparer<Group<GridViewRowInfo>>
	{
		public int Compare(Group<GridViewRowInfo> x, Group<GridViewRowInfo> y)
		{
			int parsedX;
			int parsedY;
			var first = ((object[]) x.Key).First().ToString().Trim();
			var second = ((object[]) y.Key).First().ToString().Trim();

			if (first.Contains('/') && second.Contains('/'))
			{
				first = first.Remove(0, first.LastIndexOf('/')+1);
				second = second.Remove(0, second.LastIndexOf('/')+1);
				if (first.Contains("d") && second.Contains("d"))
				{
					first = first.Remove(first.Length-2);
					second = second.Remove(second.Length-2);
				}
			}
			

			if (int.TryParse(first, out parsedX) &&
			    int.TryParse(second, out parsedY))
			{
				int result = parsedX.CompareTo(parsedY);
				DataGroup xGroup = x as DataGroup;
				if (xGroup != null && ((DataGroup)x).GroupDescriptor.GroupNames.First().Direction == ListSortDirection.Descending)
				{
					result *= -1;
				}
				return result;
			}
			return ((object[])x.Key)[0].ToString().CompareTo(((object[])y.Key)[0].ToString());
		}
	}

}
