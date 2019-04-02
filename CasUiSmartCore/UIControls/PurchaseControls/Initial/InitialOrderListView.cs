using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Initial
{
	public partial class InitialOrderListView :  BaseListViewControl<InitialOrderRecord>
	{
		public InitialOrderListView()
		{
			InitializeComponent();
		}

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();
			itemsListView.Columns.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "P/N" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Standart" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Description" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Measure" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Quantity" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(InitialOrderRecord item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

			var subItem = new ListViewItem.ListViewSubItem { Text = item.Product?.PartNumber, Tag = item.Product?.PartNumber };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Product?.Standart?.ToString(), Tag = item.Product?.Standart?.ToString() };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Product?.Description, Tag = item.Product?.Description };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Measure.ToString(), Tag = item.Measure.ToString() };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Quantity.ToString(), Tag = item.Quantity.ToString() };
			subItems.Add(subItem);

			return subItems.ToArray();
		}

		protected override void SetGroupsToItems(int columnIndex)
		{
			itemsListView.Groups.Clear();
			foreach (ListViewItem item in itemsListView.Items)
			{
				String temp;
				if (item.Tag is InitialOrderRecord)
				{
					var q = (InitialOrderRecord)item.Tag;
					var p = q.Product;

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

		protected override void SetItemColor(ListViewItem listViewItem, InitialOrderRecord item)
		{
			
		}
	}
}
