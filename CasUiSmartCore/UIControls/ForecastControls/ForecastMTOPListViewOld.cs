using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;


namespace CAS.UI.UIControls.ForecastControls
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class ForecastMTOPListViewOld : BaseListViewControl<NextPerformance>
	{
		#region public ForecastListView()
		///<summary>
		///</summary>
		public ForecastMTOPListViewOld()
		{
			InitializeComponent();
		}
		#endregion

		#region Methods

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();

			ColumnHeader columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "ATA" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Title" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Description" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Times" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Work Type" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Check" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Next" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Fst.Perf" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Rpt. Intv." };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Overdue/Remain" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Kit" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "MH" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Cost" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Total MH" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Total Cost", };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "X1" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Forecast Data" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "X2" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Signer" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
			itemsListView.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.None);
			itemsListView.Columns[3].Width = 10;
		}
		#endregion

		protected override void SetGroupsToItems(List<ListViewItem> listViewItems, int colunmIndex)
		{
			itemsListView.Groups.Clear();
			foreach (var item in listViewItems.OrderBy(lvi => Convert.ToDateTime(((NextPerformance)lvi.Tag).PerformanceDate).Date))
			{
				if (item.Tag is NextPerformance)
				{
					var np = item.Tag as NextPerformance;
					var temp = "";

					if (np.Parent is MaintenanceDirective)
						temp = $"Check: {np.Group}-{np.ParentCheck.Name} ";
					else temp = $"{ListViewGroupHelper.GetGroupString(item.Tag)} | Date: {np.PerformanceDate?.ToString(new GlobalTermsProvider()["DateFormat"].ToString())}";
					itemsListView.Groups.Add(temp, temp);
					item.Group = itemsListView.Groups[temp];
				}
			}
		}

		#region protected override SetGroupsToItems(int columnIndex)
		protected override void SetGroupsToItems(int columnIndex)
		{
			itemsListView.Groups.Clear();
			foreach (var item in ListViewItemList)
			{
				if (item.Tag is NextPerformance)
				{
					var np = item.Tag as NextPerformance;
					//var temp = $"Date:{np.PerformanceDate?.ToString(new GlobalTermsProvider()["DateFormat"].ToString())} | Check: {np.Group}-{np.ParentCheck.Name} ";
					var temp = $"Date:{np.PerformanceDate?.ToString(new GlobalTermsProvider()["DateFormat"].ToString())}";
					itemsListView.Groups.Add(temp, temp);
					item.Group = itemsListView.Groups[temp];
				}
			}
		}
		#endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, NextPerformance item)
		protected override void SetItemColor(ListViewItem listViewItem, NextPerformance item)
		{
			Color itemForeColor = Color.Black;

			if (item is MaintenanceNextPerformance)
			{
				MaintenanceNextPerformance mnp = item as MaintenanceNextPerformance;
				listViewItem.ForeColor = mnp == ((MaintenanceCheck)item.Parent).GetPergormanceGroupWhereCheckIsSenior()[0]
					? Color.Black
					: Color.Gray;

				if (mnp.CalcForHight)
				{
					listViewItem.ForeColor = itemForeColor;
					listViewItem.BackColor = Color.FromArgb(Highlight.PurpleLight.Color);
				}
			}
			else
			{
				IDirective imd = item.Parent;
				listViewItem.ForeColor = imd.NextPerformances.IndexOf(item) == 0
					? Color.Black
					: Color.Gray;
				if (imd.Condition == ConditionState.Notify)
					listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);
				if (imd.Condition == ConditionState.Overdue)
					listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);
				if (imd.Percents != null && imd.Percents > 0)
					listViewItem.BackColor = Color.FromArgb(Highlight.Green.Color);

				listViewItem.ForeColor = itemForeColor;
			}

			if (item.BlockedByPackage != null)
			{
				listViewItem.ForeColor = itemForeColor;
				listViewItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
				listViewItem.ToolTipText = "This performance is involved on Work Package:" + item.BlockedByPackage.Title;
			}


			Color itemBacBlackolor = ItemListView.BackColor;
			if (item.Parent is MaintenanceDirective)
			{
				var mpd = item.Parent as MaintenanceDirective;
				if (mpd.RecalculateTenPercent)
				{
					itemBacBlackolor = Color.DodgerBlue;
					listViewItem.BackColor = itemBacBlackolor;
				}
			}


			Color listViewForeColor = ItemListView.ForeColor;
			Color listViewBackColor = ItemListView.BackColor;

			listViewItem.UseItemStyleForSubItems = true;
			foreach (ListViewItem.ListViewSubItem subItem in listViewItem.SubItems)
			{
				if (subItem.ForeColor.ToArgb() == listViewForeColor.ToArgb())
					subItem.ForeColor = itemForeColor;
				if (subItem.BackColor.ToArgb() == listViewBackColor.ToArgb())
					subItem.BackColor = itemBacBlackolor;
			}

		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetItemsString(NextPerformance item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(NextPerformance item)
		{
			List<ListViewItem.ListViewSubItem> subItems = new List<ListViewItem.ListViewSubItem>();
			Color tcnColor = itemsListView.ForeColor;
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
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
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


			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ATAChapter?.ToString(), Tag = item.ATAChapter });
			subItems.Add(new ListViewItem.ListViewSubItem { ForeColor = tcnColor, Text = title, Tag = title });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Description, Tag = item.Description });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = timesString, Tag = times });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.WorkType, Tag = item.WorkType });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.MaintenanceCheck != null ? item.MaintenanceCheck.ToString() : "", Tag = item.MaintenanceCheck });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.PerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)item.PerformanceDate), Tag = item.PerformanceDate });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.PerformanceSource?.ToString(), Tag = item.PerformanceSource });
			if (item.Parent is MaintenanceDirective)
			{
				var d = item.Parent as MaintenanceDirective;
				subItems.Add(new ListViewItem.ListViewSubItem { Text = d.PhaseRepeat?.ToString(), Tag = d.PhaseRepeat });
			}
			else subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Parent.Threshold.RepeatInterval.ToString(), Tag = item.Parent.Threshold.RepeatInterval });

			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Remains.ToString(), Tag = item.Remains });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.KitsToString, Tag = item.Kits?.Count });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = manHours.ToString(), Tag = manHours });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = cost.ToString(), Tag = cost });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.BeforeForecastResourceRemain != null ? item.BeforeForecastResourceRemain?.ToString() : "", Tag = item.BeforeForecastResourceRemain });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Parent?.ForecastLifelength?.ToString(), Tag = item.Parent?.ForecastLifelength });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Parent.AfterForecastResourceRemain != null ? item.Parent.AfterForecastResourceRemain?.ToString() : "", Tag = item.Parent.AfterForecastResourceRemain });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
		}

		#endregion

		#region protected override void SortItems(int columnIndex)

		protected override void SortItems(int columnIndex)
		{
			if (OldColumnIndex != columnIndex)
				SortMultiplier = -1;
			if (SortMultiplier == 1)
				SortMultiplier = -1;
			else
				SortMultiplier = 1;
			itemsListView.Items.Clear();
			OldColumnIndex = columnIndex;

			List<ListViewItem> resultList = new List<ListViewItem>();

			if (columnIndex != 6)
			{
				//SetGroupsToItems(columnIndex);

				//ListViewItemList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));
				//добавление остальных подзадач
				foreach (ListViewItem item in ListViewItemList)
				{
					resultList.Add(item);
					NextPerformance np = (NextPerformance)item.Tag;
					//if (np.Parent is MaintenanceCheck && ((MaintenanceCheck)np.Parent).Grouping)
					//{
					//	MaintenanceCheck mc = (MaintenanceCheck)np.Parent;
					//	List<MaintenanceNextPerformance> performances = mc.GetPergormanceGroupWhereCheckIsSenior();
					//	if (performances == null || performances.Count == 1) continue;
					//	for (int i = 1; i < performances.Count; i++)
					//	{
					//		ListViewItem temp = new ListViewItem(GetListViewSubItems(performances[i]), null)
					//		{
					//			Tag = performances[i],
					//			Group = item.Group
					//		};
					//		resultList.Add(temp);
					//	}
					//}
					if (np.Parent is MaintenanceDirective)
					{
						var directive = (MaintenanceDirective)np.Parent;
						if (directive.MtopNextPerformances == null || directive.MtopNextPerformances.Count <= 1) continue;
						for (int i = 1; i < directive.MtopNextPerformances.Count; i++)
						{
							ListViewItem temp = new ListViewItem(GetListViewSubItems(directive.MtopNextPerformances[i]), null)
							{
								Tag = directive.MtopNextPerformances[i],
								Group = item.Group
							};
							resultList.Add(temp);
						}
					}
					else
					{
						//первая подзадача описывает саму родитескую задачу, повторно ее добавлять ненадо
						if (np.Parent.NextPerformances == null || np.Parent.NextPerformances.Count <= 1) continue;
						for (int i = 1; i < np.Parent.NextPerformances.Count; i++)
						{
							ListViewItem temp = new ListViewItem(GetListViewSubItems(np.Parent.NextPerformances[i]), null)
							{
								Tag = np.Parent.NextPerformances[i],
								Group = item.Group
							};
							resultList.Add(temp);
						}
					}
				}
			}
			else
			{
				foreach (ListViewItem item in ListViewItemList)
				{
					resultList.Add(item);
					NextPerformance np = (NextPerformance)item.Tag;
					if (np.Parent is MaintenanceCheck && ((MaintenanceCheck)np.Parent).Grouping)
					{
						MaintenanceCheck mc = (MaintenanceCheck)np.Parent;
						List<MaintenanceNextPerformance> performances = mc.GetPergormanceGroupWhereCheckIsSenior();
						if (performances == null || performances.Count == 1) continue;
						for (int i = 1; i < performances.Count; i++)
						{
							ListViewItem temp = new ListViewItem(GetListViewSubItems(performances[i]), null)
							{
								Tag = performances[i],
								Group = item.Group
							};
							resultList.Add(temp);
						}
					}
					else
					{
						//первая подзадача описывает саму родитескую задачу, повторно ее добавлять ненадо
						if (np.Parent.NextPerformances == null || np.Parent.NextPerformances.Count <= 1) continue;
						for (int i = 1; i < np.Parent.NextPerformances.Count; i++)
						{
							ListViewItem temp = new ListViewItem(GetListViewSubItems(np.Parent.NextPerformances[i]), null)
							{
								Tag = np.Parent.NextPerformances[i],
							};
							resultList.Add(temp);
						}
					}
				}

				resultList.Sort(new DirectiveListViewComparer(columnIndex, SortMultiplier));
				itemsListView.Groups.Clear();
				//foreach (ListViewItem item in resultList)
				//{
				//    DateTime date = new DateTime(1950, 1, 1);
				//    if (item.Tag is NextPerformance)
				//    {
				//        NextPerformance np = (NextPerformance)item.Tag;
				//        if (np.PerformanceDate != null)
				//            date = np.PerformanceDate.Value.Date;
				//    }

				//    string temp = date.Date > new DateTime(1950, 1, 1).Date ? SmartCore.Auxiliary.Convert.GetDateFormat(date.Date) : "";
				//    itemsListView.Groups.Add(temp, temp);
				//    item.Group = itemsListView.Groups[temp];
				//}

				//Группировка элементов по датам выполнения
				IEnumerable<IGrouping<DateTime, ListViewItem>> groupedItems =
					resultList.Where(lvi => lvi.Tag != null &&
												  lvi.Tag is NextPerformance)
									.GroupBy(lvi => Convert.ToDateTime(((NextPerformance)lvi.Tag).PerformanceDate).Date);
				foreach (var groupedItem in groupedItems)
				{
					//Собрание всех выполнений на данную дату в одну коллекцию
					var performances = groupedItem.Select(lvi => lvi.Tag as NextPerformance).ToList();

					var temp = ListViewGroupHelper.GetGroupStringByPerformanceDate(performances, groupedItem.Key.Date);

					itemsListView.Groups.Add(temp, temp);
					foreach (var item in groupedItem)
						item.Group = itemsListView.Groups[temp];
				}
				//SetGroupsToItems();
			}

			SetGroupsToItems(resultList, columnIndex);
			itemsListView.Items.AddRange(resultList.OrderBy(lvi => Convert.ToDateTime(((NextPerformance)lvi.Tag).PerformanceDate).Date).ToArray());

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

		#endregion
	}
}
