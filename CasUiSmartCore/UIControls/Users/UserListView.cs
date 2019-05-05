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
    public partial class UserListView : BaseListViewControl<User>
    {
		#region public UserListView()
		public UserListView()
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
				var temp = ((User)item.Tag).UserType.ToString();

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

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(User item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
			var userName = $"{item.Surname} {item.Name}";

			subItems.Add(new ListViewItem.ListViewSubItem {Text = userName, Tag = userName });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.Login, Tag = item.Login });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.Password, Tag = item.Password });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.UiType.ToString(), Tag = item.UiType });
			//subItems.Add(new ListViewItem.ListViewSubItem {Text = item.UserType.ToString(), Tag = item.UserType });
			
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

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "UserName" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Login" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Password" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Ui Type" };
			ColumnHeaderList.Add(columnHeader);

			//columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "UserType" };
			//ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}
		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null)
            {
				var form = new UserForm(SelectedItem);
				if (form.ShowDialog() == DialogResult.OK)
				{
					ListViewItem.ListViewSubItem[] subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Length; i++)
						itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
				}
				itemsListView.SelectedItems[0].Group = itemsListView.Groups[SelectedItem.UserType.ToString()];
			}
        }
        #endregion

		#endregion
	}
}
