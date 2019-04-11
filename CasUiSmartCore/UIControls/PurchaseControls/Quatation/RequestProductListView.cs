using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class RequestProductListView : BaseListViewControl<Product>
	{
		#region Constructor

		public RequestProductListView()
		{
			InitializeComponent();
			OldColumnIndex = 2;
			SortMultiplier = 1;
		}

		#endregion


		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();
			itemsListView.Columns.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "P/N" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Standart" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.25f), Text = "Description" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "ATA" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Author" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Product item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Product item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			var subItem = new ListViewItem.ListViewSubItem { Text = item.PartNumber, Tag = item.PartNumber };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Standart?.ToString(), Tag = item.Standart };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Description, Tag = item.Description };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.ATAChapter?.ToString(), Tag = item.ATAChapter?.ToString() };
			subItems.Add(subItem);

			subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
		}

		#endregion

		protected override void SetGroupsToItems(int columnIndex)
		{
			itemsListView.Groups.Clear();
			foreach (ListViewItem item in itemsListView.Items)
			{
				String temp;
				if (item.Tag is Product)
				{
					var p = (Product)item.Tag;

					temp = p.GoodsClass.ShortName;
					itemsListView.Groups.Add(temp, temp);
					item.Group = itemsListView.Groups[temp];
				}
				else
				{
					temp = "Another accessory";
					itemsListView.Groups.Add(temp, temp);
					item.Group = itemsListView.Groups[temp];
				}
			}
		}

		protected override void SortItems(int columnIndex)
		{
			SetGroupsToItems(columnIndex);
		}
	}
}
