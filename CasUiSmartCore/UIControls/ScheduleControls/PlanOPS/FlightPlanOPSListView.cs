using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASTerms;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls.PlanOPS
{
	public partial class FlightPlanOpsListView : BaseListViewControl<FlightPlanOps>
	{
		#region public FlightPlanOpsListView()

		public FlightPlanOpsListView()
		{
			InitializeComponent();

			SortMultiplier = 0;
			OldColumnIndex = 0;
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.4f), Text = "From - To" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.8f), Text = "Remarks" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Author" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(IFlightNumberParams item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(FlightPlanOps item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
			var period = $"{item.From:dd-MMMM-yyyy} - {item.To:dd-MMMM-yyyy}";

			var subItem = new ListViewItem.ListViewSubItem { Text = period, Tag = period };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Remarks, Tag = item.Remarks };
			subItems.Add(subItem);
			subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });
			return subItems.ToArray();
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				var period = $"{SelectedItem.From:dd-MMMM-yyyy} - {SelectedItem.To:dd-MMMM-yyyy}";
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.DisplayerText = $"{period} OPS";
				e.RequestedEntity = new FlightPlanOpsRecordListScreen(GlobalObjects.CasEnvironment.Operators[0] ,SelectedItem);
			}
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
			SetGroupsToItems(columnIndex);

			if (columnIndex == 0)
			{
				itemsListView.Items.AddRange(ListViewItemList.OrderByDescending(i => ((FlightPlanOps)i.Tag).From).ToArray());
			}
			else
			{
				ListViewItemList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));
				itemsListView.Items.AddRange(ListViewItemList.ToArray());
			}

			OldColumnIndex = columnIndex;
			SetItemsColor();
		}

		#endregion
	}
}
