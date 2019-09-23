using System.Collections.Generic;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls.PlanOPS
{
	public partial class FlightPlanOpsListView : BaseGridViewControl<FlightPlanOps>
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
			AddColumn("From - To", (int)(radGridView1.Width * 0.8f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.16f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}

		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(FlightPlanOps item)

		protected override List<CustomCell> GetListViewSubItems(FlightPlanOps item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var period = $"{item.From:dd-MMMM-yyyy} - {item.To:dd-MMMM-yyyy}";

			return new List<CustomCell>
			{
				CreateRow(period, Tag = period),
				CreateRow(item.Remarks, Tag = item.Remarks),
				CreateRow(author, Tag = author)
			};
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

		//protected override void SortItems(int columnIndex)
		//{
		//	if (OldColumnIndex != columnIndex)
		//		SortMultiplier = -1;
		//	if (SortMultiplier == 1)
		//		SortMultiplier = -1;
		//	else
		//		SortMultiplier = 1;
		//	itemsListView.Items.Clear();
		//	SetGroupsToItems(columnIndex);

		//	if (columnIndex == 0)
		//	{
		//		itemsListView.Items.AddRange(ListViewItemList.OrderByDescending(i => ((FlightPlanOps)i.Tag).From).ToArray());
		//	}
		//	else
		//	{
		//		ListViewItemList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));
		//		itemsListView.Items.AddRange(ListViewItemList.ToArray());
		//	}

		//	OldColumnIndex = columnIndex;
		//	SetItemsColor();
		//}

		#endregion
	}
}
