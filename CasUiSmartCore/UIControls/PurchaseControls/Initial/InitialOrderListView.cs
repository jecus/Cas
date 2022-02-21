﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Initial
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class InitialOrderListView : BaseGridViewControl<InitialOrder>
	{
		#region public InitialOrderListView()
		///<summary>
		///</summary>
		public InitialOrderListView()
		{
			InitializeComponent();
			SortDirection = SortDirection.Asc;
			DisableContectMenu();
		}
		#endregion

		#region Methods

		#region protected override void SetGroupsToItems(int columnIndex)


		protected override void GroupingItems()
		{
			Grouping("Status");
		}


		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetItemsString(InitialOrder item)

		protected override List<CustomCell> GetListViewSubItems(InitialOrder item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var status = "1.Opened";
			if (item.Status == WorkPackageStatus.Published)
				status = "2.Published";
			else if (item.Status == WorkPackageStatus.Closed)
				status = "3.Closed";

			return new List<CustomCell>
			{
				CreateRow(status, item.Status),
				CreateRow(item.Number, item.Number),
				CreateRow(item.Title, item.Title),
				CreateRow(item.OpeningDate == new DateTime(1852, 01, 01)
					? ""
					: SmartCore.Auxiliary.Convert.GetDateFormat(item.OpeningDate), item.OpeningDate),
				CreateRow(item.Status != WorkPackageStatus.Opened
					? item.PublishingDate == new DateTime(1852, 01, 01)
					? ""
					: SmartCore.Auxiliary.Convert.GetDateFormat(item.PublishingDate)
					: "", item.PublishingDate),
				CreateRow(item.Status == WorkPackageStatus.Closed
					? item.ClosingDate == new DateTime(1852, 01, 01)
					? ""
					: SmartCore.Auxiliary.Convert.GetDateFormat(item.ClosingDate)
					: "", item.ClosingDate),
				CreateRow(item.Author, item.Author),
				CreateRow(item.PublishedByUser, item.PublishedByUser),
				CreateRow(item.CloseByUser, item.CloseByUser),
				CreateRow(item.Remarks, item.Remarks),
				CreateRow(author, author)
			};
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		//protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		//{
		//    if (SelectedItem != null)
		//    {
		//        e.TypeOfReflection = ReflectionTypes.DisplayInCurrent;
		//        e.DisplayerText = SelectedItem.Title;
		//        e.RequestedEntity = new InitionalOrderScreen(SelectedItem);
		//    }
		//}

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem != null)
			{

				var editForm = new InitialOrderFormNew(SelectedItem);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					var subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Count; i++)
						radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
				}
			}
		}
		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			AddColumn("Status", (int)(radGridView1.Width * 0.2f));
			AddColumn("Order No", (int)(radGridView1.Width * 0.2f));
			AddColumn("Title", (int)(radGridView1.Width * 0.3f));
			AddColumn("Opening date", (int)(radGridView1.Width * 0.2f));
			AddColumn("Publishing date", (int)(radGridView1.Width * 0.2f));
			AddColumn("Closing date", (int)(radGridView1.Width * 0.2f));
			AddColumn("Author", (int)(radGridView1.Width * 0.2f));
			AddColumn("Published By", (int)(radGridView1.Width * 0.2f));
			AddColumn("Closed By", (int)(radGridView1.Width * 0.2f));
			AddColumn("Remark", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}

		#endregion

		#endregion
	}
}
