using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using Telerik.WinControls.UI;


namespace CAS.UI.UIControls.ForecastControls
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class ForecastListView : BaseGridViewControl<NextPerformance>
	{
		#region Fields

		#endregion

		#region Properties
		#endregion

		#region public ForecastListView()
		///<summary>
		///</summary>
		public ForecastListView()
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
			AddColumn("ATA", (int)(radGridView1.Width * 0.10f));
			AddColumn("Title", (int)(radGridView1.Width * 0.2f));
			AddColumn("Description", (int)(radGridView1.Width * 0.2f));
			AddColumn("Times", (int)(radGridView1.Width * 0.2f));
			AddColumn("Work Type", (int)(radGridView1.Width * 0.2f));
			AddColumn("Check", (int)(radGridView1.Width * 0.2f));
			AddDateColumn("Next", (int)(radGridView1.Width * 0.2f));
			AddColumn("Fst.Perf", (int)(radGridView1.Width * 0.2f));
			AddColumn("Rpt. Intv.", (int)(radGridView1.Width * 0.2f));
			AddColumn("Overdue/Remain", (int)(radGridView1.Width * 0.2f));
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
		//protected override void SetGroupsToItems(int columnIndex)
		//      {
		//          itemsListView.Groups.Clear();
		//          foreach (var item in ListViewItemList)
		//          {
		//              var temp = ListViewGroupHelper.GetGroupString(item.Tag);

		//		itemsListView.Groups.Add(temp, temp);
		//		item.Group = itemsListView.Groups[temp];
		//	}
		//      }
		#endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, NextPerformance item)
		protected override void SetItemColor(GridViewRowInfo listViewItem, NextPerformance item)
		{
			if (item is MaintenanceNextPerformance)
			{
				MaintenanceNextPerformance mnp = item as MaintenanceNextPerformance;
				foreach (GridViewCellInfo cell in listViewItem.Cells)
				{
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
					}
				}
			}
			else
			{
				IDirective imd = item.Parent;

				foreach (GridViewCellInfo cell in listViewItem.Cells)
				{
					cell.Style.ForeColor = imd.NextPerformances.IndexOf(item) == 0
						? Color.Black
						: Color.Gray;
					if (imd.Condition == ConditionState.Notify)
						cell.Style.BackColor = Color.FromArgb(Highlight.Yellow.Color);
					if (imd.Percents != null && imd.Percents > 0)
						cell.Style.BackColor = Color.FromArgb(Highlight.Green.Color);
				}

				
			}

			if (item.BlockedByPackage != null)
			{

				foreach (GridViewCellInfo cell in listViewItem.Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.FromArgb(Highlight.Grey.Color);
				}
			}
		}
		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(NextPerformance item)

		protected override List<CustomCell> GetListViewSubItems(NextPerformance item)
		{
			var subItems = new List<CustomCell>();
			//ListViewItem.ListViewSubItem subItem;
			//if(item.ItemId == 41043)
			//{
				
			//}
			int index;
			if (item is MaintenanceNextPerformance)
			{
				MaintenanceCheck mc = item.Parent as MaintenanceCheck;
				if(mc != null && mc.GetPergormanceGroupWhereCheckIsSenior().FirstOrDefault() != null)
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
			double manHours = item.Parent is IEngineeringDirective ? ((IEngineeringDirective) item.Parent).ManHours : 0;
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

			subItems.Add(CreateRow(item.ATAChapter.ToString(), item.ATAChapter));
			subItems.Add(CreateRow(title, title));
			subItems.Add(CreateRow(item.Description, item.Description));
			subItems.Add(CreateRow(timesString, times));
			subItems.Add(CreateRow(item.WorkType, item.WorkType));
			subItems.Add(CreateRow(item.MaintenanceCheck != null ? item.MaintenanceCheck.ToString() : "", item.MaintenanceCheck));
			subItems.Add(CreateRow(item.PerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime) item.PerformanceDate), item.PerformanceDate));
			subItems.Add(CreateRow(item.PerformanceSource.ToString(), item.PerformanceSource));
			subItems.Add(CreateRow(item.Parent.Threshold.RepeatInterval.ToString(), item.Parent.Threshold.RepeatInterval));
			subItems.Add(CreateRow(item.Remains.ToString(), item.Remains));
			subItems.Add(CreateRow(item.KitsToString, item.Kits.Count));
			subItems.Add(CreateRow(manHours.ToString(), manHours));
			subItems.Add(CreateRow(cost.ToString(), cost));
			subItems.Add(CreateRow("", ""));
			subItems.Add(CreateRow("", ""));
			subItems.Add(CreateRow(item.BeforeForecastResourceRemain != null ? item.BeforeForecastResourceRemain.ToString() : "", item.BeforeForecastResourceRemain));
			subItems.Add(CreateRow(item.Parent.ForecastLifelength.ToString(), item.Parent.ForecastLifelength));
			subItems.Add(CreateRow(item.Parent.AfterForecastResourceRemain != null ? item.Parent.AfterForecastResourceRemain.ToString() : "", item.Parent.AfterForecastResourceRemain));
			subItems.Add(CreateRow(author, author));

			return subItems;
		}

		#endregion

		#region protected override void SortItems(int columnIndex)

	 //   protected override void SortItems(int columnIndex)
	 //   {
	 //       if (OldColumnIndex != columnIndex)
	 //           SortMultiplier = -1;
	 //       if (SortMultiplier == 1)
	 //           SortMultiplier = -1;
	 //       else
	 //           SortMultiplier = 1;
	 //       itemsListView.Items.Clear();
	 //       OldColumnIndex = columnIndex;

	 //       List<ListViewItem> resultList = new List<ListViewItem>();

	 //       if (columnIndex != 6)
	 //       {
	 //           SetGroupsToItems(columnIndex);

	 //           ListViewItemList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));
	 //           //добавление остальных подзадач
	 //           foreach (ListViewItem item in ListViewItemList)
	 //           {
	 //               resultList.Add(item);
	 //               NextPerformance np = (NextPerformance) item.Tag;
	 //               if (np.Parent is MaintenanceCheck && ((MaintenanceCheck)np.Parent).Grouping)
	 //               {
	 //                   MaintenanceCheck mc = (MaintenanceCheck)np.Parent;
	 //                   List<MaintenanceNextPerformance> performances = mc.GetPergormanceGroupWhereCheckIsSenior();
	 //                   if (performances == null || performances.Count == 1) continue;
	 //                   for (int i = 1; i < performances.Count; i++)
	 //                   {
	 //                       ListViewItem temp = new ListViewItem(GetListViewSubItems(performances[i]), null)
	 //                       {
	 //                           Tag = performances[i],
	 //                           Group = item.Group
	 //                       };
	 //                       resultList.Add(temp);
	 //                   }
	 //               }
	 //               else
	 //               {
	 //                   //первая подзадача описывает саму родитескую задачу, повторно ее добавлять ненадо
	 //                   if (np.Parent.NextPerformances == null || np.Parent.NextPerformances.Count <= 1) continue;
	 //                   for (int i = 1; i < np.Parent.NextPerformances.Count; i++)
	 //                   {
	 //                       ListViewItem temp = new ListViewItem(GetListViewSubItems(np.Parent.NextPerformances[i]), null)
	 //                       {
	 //                           Tag = np.Parent.NextPerformances[i],
	 //                           Group = item.Group
	 //                       };
	 //                       resultList.Add(temp);
	 //                   }
	 //               }
	 //           }
	 //       }
	 //       else
	 //       {
	 //           foreach (ListViewItem item in ListViewItemList)
	 //           {
	 //               resultList.Add(item);
	 //               NextPerformance np = (NextPerformance) item.Tag;
	 //               if (np.Parent is MaintenanceCheck && ((MaintenanceCheck)np.Parent).Grouping)
	 //               {
	 //                   MaintenanceCheck mc = (MaintenanceCheck)np.Parent;
	 //                   List<MaintenanceNextPerformance> performances = mc.GetPergormanceGroupWhereCheckIsSenior();
	 //                   if (performances == null || performances.Count == 1) continue;
	 //                   for (int i = 1; i < performances.Count; i++)
	 //                   {
	 //                       ListViewItem temp = new ListViewItem(GetListViewSubItems(performances[i]), null)
	 //                       {
	 //                           Tag = performances[i],
	 //                           Group = item.Group
	 //                       };
	 //                       resultList.Add(temp);
	 //                   }
	 //               }
	 //               else
	 //               {
	 //                   //первая подзадача описывает саму родитескую задачу, повторно ее добавлять ненадо
	 //                   if (np.Parent.NextPerformances == null || np.Parent.NextPerformances.Count <= 1) continue;
	 //                   for (int i = 1; i < np.Parent.NextPerformances.Count; i++)
	 //                   {
	 //                       ListViewItem temp = new ListViewItem(GetListViewSubItems(np.Parent.NextPerformances[i]), null)
	 //                       {
	 //                           Tag = np.Parent.NextPerformances[i],
	 //                       };
	 //                       resultList.Add(temp);
	 //                   }
	 //               }
	 //           }
				
	 //           resultList.Sort(new DirectiveListViewComparer(columnIndex, SortMultiplier));
	 //           itemsListView.Groups.Clear();
	 //           //foreach (ListViewItem item in resultList)
	 //           //{
	 //           //    DateTime date = new DateTime(1950, 1, 1);
	 //           //    if (item.Tag is NextPerformance)
	 //           //    {
	 //           //        NextPerformance np = (NextPerformance)item.Tag;
	 //           //        if (np.PerformanceDate != null)
	 //           //            date = np.PerformanceDate.Value.Date;
	 //           //    }

	 //           //    string temp = date.Date > new DateTime(1950, 1, 1).Date ? SmartCore.Auxiliary.Convert.GetDateFormat(date.Date) : "";
	 //           //    itemsListView.Groups.Add(temp, temp);
	 //           //    item.Group = itemsListView.Groups[temp];
	 //           //}

	 //           //Группировка элементов по датам выполнения
	 //           IEnumerable<IGrouping<DateTime, ListViewItem>> groupedItems =
	 //               resultList.Where(lvi => lvi.Tag != null &&
	 //                                             lvi.Tag is NextPerformance)
	 //                               .GroupBy(lvi => Convert.ToDateTime(((NextPerformance)lvi.Tag).PerformanceDate).Date);
	 //           foreach (var groupedItem in groupedItems)
	 //           {
	 //               //Собрание всех выполнений на данную дату в одну коллекцию
	 //               var performances = groupedItem.Select(lvi => lvi.Tag as NextPerformance).ToList();

					//var temp = ListViewGroupHelper.GetGroupStringByPerformanceDate(performances, groupedItem.Key.Date);
					
					//itemsListView.Groups.Add(temp, temp);
	 //               foreach (var item in groupedItem)
	 //                   item.Group = itemsListView.Groups[temp];
	 //           }
	 //           //SetGroupsToItems();
	 //       }
	 //       itemsListView.Items.AddRange(resultList.ToArray());
	 //   }

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
