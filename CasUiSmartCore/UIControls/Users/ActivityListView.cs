using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.NewGrid;
using SmartCore.Activity;

namespace CAS.UI.UIControls.Users
{
    ///<summary>
    /// список для отображения документов
    ///</summary>
    public partial class ActivityListView : BaseGridViewControl<ActivityDTO>
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
		protected override void GroupingItems()
		{
			Grouping("Date");
		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetItemsString(Document item)

		protected override List<CustomCell> GetListViewSubItems(ActivityDTO item)
		{
			var subItems = new List<CustomCell>()
			{
				CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.Date), item.Date),
				CreateRow(item.Date.ToString("HH:mm:ss"), item.Date),
				CreateRow(item.User.ToString(), item.User),
				CreateRow(item.Operation.ToString(), item.Operation),
				CreateRow(item.Type.FullName, item.Type),
				CreateRow(item.Aircraft.ToString(), item.Aircraft),
				CreateRow(item.Title, item.Title),
				CreateRow(item.Information, item.Information),
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
			AddColumn("Date", (int)(radGridView1.Width * 0.20f));
			AddColumn("Time", (int)(radGridView1.Width * 0.20f));
			AddColumn("User", (int)(radGridView1.Width * 0.20f));
			AddColumn("Activity Type", (int)(radGridView1.Width * 0.20f));
			AddColumn("Object Type", (int)(radGridView1.Width * 0.20f));
			AddColumn("Aircraft", (int)(radGridView1.Width * 0.20f));
			AddColumn("Title", (int)(radGridView1.Width * 0.20f));
			AddColumn("Additional Information", (int)(radGridView1.Width * 0.20f));
		}
		#endregion


		#region protected override void RadGridView1_DoubleClick(object sender, EventArgs e)

		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{

		}

		#endregion


		#endregion
	}
}
