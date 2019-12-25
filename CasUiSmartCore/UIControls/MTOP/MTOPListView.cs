using System;
using System.Collections.Generic;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.General.MTOP;

namespace CAS.UI.UIControls.MTOP
{
	public partial class MTOPListView : BaseGridViewControl<MTOPCheck>
	{
		private Dictionary<int, Lifelength> _groupLifelengths;

		#region Constructor

		public MTOPListView()
		{
			InitializeComponent();
			DisableContectMenu();
		}

		public MTOPListView(Dictionary<int, Lifelength> groupLifelengths) : this()
		{
			_groupLifelengths = groupLifelengths;
			SetHeaders();
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			if (_groupLifelengths == null)
				return;
			AddColumn("Group", (int)(radGridView1.Width * 0.2f));
			
			foreach (var lifelength in _groupLifelengths)
				AddColumn(lifelength.Key.ToString(), (int)(radGridView1.Width * 0.5f));
			
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
			
			radGridView1.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(MTOPCheck item)

		protected override List<CustomCell> GetListViewSubItems(MTOPCheck item)
		{
			var subItems = new List<CustomCell>();

			var tempHours = item.PhaseThresh.Hours;
			var name = $"{item.Name}";
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			
			subItems.Add(CreateRow(name, name));

			foreach (var lifelength in _groupLifelengths)
			{
				if (tempHours == lifelength.Value.Hours)
				{
					if (item.PhaseRepeat != null && !item.PhaseRepeat.IsNullOrZero())
						tempHours += item.PhaseRepeat.Hours;
					else tempHours += item.PhaseThresh.Hours;
					
					subItems.Add(CreateRow("x", ""));
				}
				else if (tempHours / _groupLifelengths[1].Hours == lifelength.Key)
				{
					if (item.PhaseRepeat != null && !item.PhaseRepeat.IsNullOrZero())
						tempHours += item.PhaseRepeat.Hours;
					else tempHours += item.PhaseThresh.Hours;

					subItems.Add(CreateRow("x", ""));
				}
				else subItems.Add(CreateRow("", ""));
			}
			subItems.Add(CreateRow(author, author));
			
			return subItems;
		}

		#endregion

		#region protected override void SetGroupsToItems(int columnIndex)

		//protected override void SetGroupsToItems(int columnIndex)
		//{
		//	itemsListView.Groups.Clear();

		//	foreach (ListViewItem item in ListViewItemList)
		//	{
		//		string temp;

		//		if (item.Tag is MTOPCheck)
		//		{
		//			var mtop = item.Tag as MTOPCheck;

		//			temp = $"{mtop.CheckType.FullName}";
		//			itemsListView.Groups.Add(temp, temp);
		//			item.Group = itemsListView.Groups[temp];
		//		}
		//	}
		//}

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)

		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
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
