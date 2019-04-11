using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.General.MTOP;

namespace CAS.UI.UIControls.MTOP
{
	public partial class MTOPListView : BaseListViewControl<MTOPCheck>
	{
		private Dictionary<int, Lifelength> _groupLifelengths;

		#region Constructor

		public MTOPListView()
		{
			InitializeComponent();
		}

		public MTOPListView(Dictionary<int, Lifelength> groupLifelengths) : this()
		{
			_groupLifelengths = groupLifelengths;
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();
			itemsListView.Columns.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Group" };
			ColumnHeaderList.Add(columnHeader);

			foreach (var lifelength in _groupLifelengths)
			{
				columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.025f), Text = lifelength.Key.ToString() };
				ColumnHeaderList.Add(columnHeader);
			}

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Author" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MTOPCheck item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MTOPCheck item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

			var tempHours = item.PhaseThresh.Hours;
			var name = $"{item.Name}";
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
			var subItem = new ListViewItem.ListViewSubItem { Text = name, Tag = name };
			subItems.Add(subItem);

			foreach (var lifelength in _groupLifelengths)
			{
				if (tempHours == lifelength.Value.Hours)
				{
					if (item.PhaseRepeat != null && !item.PhaseRepeat.IsNullOrZero())
						tempHours += item.PhaseRepeat.Hours;
					else tempHours += item.PhaseThresh.Hours;

					subItem = new ListViewItem.ListViewSubItem { Text = "x", Tag = "" };
				}
				else if (tempHours / _groupLifelengths[1].Hours == lifelength.Key)
				{
					if (item.PhaseRepeat != null && !item.PhaseRepeat.IsNullOrZero())
						tempHours += item.PhaseRepeat.Hours;
					else tempHours += item.PhaseThresh.Hours;

					subItem = new ListViewItem.ListViewSubItem { Text = "x", Tag = "" };

				}
				else subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };

				subItems.Add(subItem);
			}

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

					temp = $"{mtop.CheckType.FullName}";
					itemsListView.Groups.Add(temp, temp);
					item.Group = itemsListView.Groups[temp];
				}
			}
		}

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)

		protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		{

		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{

		}

		#endregion
	}
}
