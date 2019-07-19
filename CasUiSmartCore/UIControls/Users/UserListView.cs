using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using SmartCore.Entities;

namespace CAS.UI.UIControls.Users
{
    ///<summary>
    /// список для отображения документов
    ///</summary>
    public partial class UserListView : BaseGridViewControl<User>
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
		protected override void GroupingItems()
		{
			Grouping("User Type");
		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetItemsString(Document item)

		protected override List<CustomCell> GetListViewSubItems(User item)
		{
			var userName = $"{item.Surname} {item.Name}";
			var subItems = new List<CustomCell>()
			{
				CreateRow(userName,userName),
				CreateRow(item.Login,item.Login),
				CreateRow(item.Password,item.Password),
				CreateRow(item.UserType.ToString(),item.UserType),
				CreateRow(item.UiType.ToString(),item.UiType),
			};

			return subItems;
		}

		#endregion

		#region protected override void SetHeaders()
		///// <summary>
		///// Устанавливает заголовки
		///// </summary>
		protected override void SetHeaders()
		{
			AddColumn("UserName", (int)(radGridView1.Width * 0.20f));
			AddColumn("Login", (int)(radGridView1.Width * 0.20f));
			AddColumn("Password", (int)(radGridView1.Width * 0.20f));
			AddColumn("User Type", (int)(radGridView1.Width * 0.20f));
			AddColumn("Ui Type", (int)(radGridView1.Width * 0.20f));
		}
		#endregion

		#region protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
            if (SelectedItem != null)
            {
				var form = new UserForm(SelectedItem);
				if (form.ShowDialog() == DialogResult.OK)
				{
					var subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Count; i++)
						radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
				}
            }
        }
        #endregion

		#endregion
	}
}
