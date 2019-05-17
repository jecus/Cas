using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using SmartCore.Activity;

namespace CAS.UI.UIControls.Users
{
    ///<summary>
    /// список для отображения документов
    ///</summary>
    public partial class ActivityListView : BaseListViewControl<ActivityDTO>
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
			itemsListView.Groups.Clear();
			foreach (var item in ListViewItemList)
			{
				var activityDto = item.Tag as ActivityDTO;
				var temp = SmartCore.Auxiliary.Convert.GetDateFormat(activityDto.Date);

				itemsListView.Groups.Add(temp, temp);
				item.Group = itemsListView.Groups[temp];
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

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(ActivityDTO item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();
			
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.Date.ToString("HH:mm:ss"), Tag = item.Date });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.User.ToString(), Tag = item.User });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.Operation.ToString(), Tag = item.Operation });
			//subItems.Add(new ListViewItem.ListViewSubItem {Text = item.ObjectId.ToString(), Tag = item.ObjectId });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.Type.FullName, Tag = item.Type });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.Information, Tag = item.Information });
			
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

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Time" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "User" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Activity Type" };
			ColumnHeaderList.Add(columnHeader);

			//columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Object Id" };
			//ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Object Type" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.40f), Text = "Additional Information" };
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
