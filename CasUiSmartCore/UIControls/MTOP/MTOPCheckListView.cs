using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.General.MTOP;

namespace CAS.UI.UIControls.MTOP
{
	public partial class MTOPCheckListView : BaseListViewControl<MTOPCheck>
	{
		#region Constructor

		public MTOPCheckListView()
		{
			InitializeComponent();
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Thresh" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Repeat" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Notify" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.18f), Text = "Estimated Thresh" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Estimated Thresh Limit" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.18f), Text = "Estimated Repeat" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Estimated Repeat Limit" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Author" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MTOPCheck item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MTOPCheck item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			var subItem = new ListViewItem.ListViewSubItem { Text = item.Name, Tag = item.Name };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Thresh.ToRepeatIntervalsFormat(), Tag = item.Thresh };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Repeat.ToRepeatIntervalsFormat(), Tag = item.Repeat };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Notify.ToRepeatIntervalsFormat(), Tag = item.Repeat };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.PhaseThreshLimit.ToRepeatIntervalsFormat(), Tag = item.PhaseThreshLimit };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.PhaseThresh.ToRepeatIntervalsFormat(), Tag = item.PhaseThresh};
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.PhaseRepeatLimit == null ? "": item.PhaseRepeatLimit.ToRepeatIntervalsFormat(), Tag = item.PhaseRepeatLimit };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.PhaseRepeat == null ? "" : item.PhaseRepeat.ToRepeatIntervalsFormat(), Tag = item.PhaseRepeat };
			subItems.Add(subItem);

			subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
		}

		#endregion

		#region protected override void SetGroupsToItems(int columnIndex)

		protected override void SetGroupsToItems(int columnIndex)
		{
			itemsListView.Groups.Clear();
			
			foreach (ListViewItem item in ListViewItemList)
			{
				string temp;

				if (item.Tag is MTOPCheck)
				{
					var mtop = item.Tag as MTOPCheck;

					if(mtop.IsZeroPhase)
						temp = $"Zero Phase: {mtop.CheckType.FullName}";
					else  temp = $"{mtop.CheckType.FullName}";
					itemsListView.Groups.Add(temp, temp);
					item.Group = itemsListView.Groups[temp];
				}
			}
		}

		#endregion

		protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		{
			
		}

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			
		}
	}
}
