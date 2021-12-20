﻿using System;
using System.Collections.Generic;
using CAS.UI.UIControls.NewGrid;
using SmartCore.Activity;

namespace CAS.UI.UICAAControls.Activity
{
	///<summary>
	/// список для отображения документов
	///</summary>
	public partial class CAAActivityListView : BaseGridViewControl<ActivityDTO>
	{
		#region public UserListView()
		public CAAActivityListView()
		{
			SortDirection = SortDirection.Desc;
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

		#region protected override List<CustomCell> GetItemsString(Document item)

		protected override List<CustomCell> GetListViewSubItems(ActivityDTO item)
		{
			var subItems = new List<CustomCell>()
			{
				CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.Date), item.Date.Date),
				CreateRow(item.Date.ToString("HH:mm:ss"), item.Date),
				CreateRow(item.User.ToString(), item.User),
				CreateRow(item.Operation.ToString(), item.Operation),
				CreateRow(item.Type.FullName, item.Type),
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
			AddDateColumn("Date", (int)(radGridView1.Width * 0.20f));
			AddColumn("Time", (int)(radGridView1.Width * 0.20f));
			AddColumn("User", (int)(radGridView1.Width * 0.20f));
			AddColumn("Activity Type", (int)(radGridView1.Width * 0.20f));
			AddColumn("Object Type", (int)(radGridView1.Width * 0.20f));
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
