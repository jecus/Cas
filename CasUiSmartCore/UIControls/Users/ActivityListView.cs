using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASTerms;
using SmartCore.Entities;

namespace CAS.UI.UIControls.Users
{
    ///<summary>
    /// список для отображения документов
    ///</summary>
    public partial class ActivityListView : BaseListViewControl<User>
    {
		#region public UserListView()
		public ActivityListView()
		{
			SortMultiplier = 1;
			InitializeComponent();
        }
		#endregion

		#region Methods

		#region protected override SetGroupsToItems()
		protected override void SetGroupsToItems(int columnIndex)
		{
			
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
			var resultList = new List<ListViewItem>();
			SetGroupsToItems(columnIndex);

			//добавление остальных подзадач
			foreach (ListViewItem item in ListViewItemList)
			{
				resultList.Add(item);
			}
			resultList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));
		
			itemsListView.Items.AddRange(resultList.ToArray());
			OldColumnIndex = columnIndex;

		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetItemsString(Document item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(User item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();
			
			subItems.Add(new ListViewItem.ListViewSubItem {Text = "", Tag = "" });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = "", Tag = "" });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = "", Tag = "" });
			
			return subItems.ToArray();
		}

		#endregion

		#region protected override void SetHeaders()
		///// <summary>
		///// Устанавливает заголовки
		///// </summary>
		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Date" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "User" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Activity Type" };
			ColumnHeaderList.Add(columnHeader);

			
			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}
		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }
        #endregion

		#endregion
	}
}
