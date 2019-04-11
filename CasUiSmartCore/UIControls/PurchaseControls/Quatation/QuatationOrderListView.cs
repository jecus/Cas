using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class QuatationOrderListView : BaseListViewControl<RequestForQuotationRecord>
	{
		public QuatationOrderListView()
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

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Description" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Suppliers" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Measure" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Quantity" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Author" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(RequestForQuotationRecord item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
			var subItem = new ListViewItem.ListViewSubItem { Text = item.Product?.PartNumber, Tag = item.Product?.PartNumber };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Product?.Description, Tag = item.Product?.Description };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Suppliers?.ToString(), Tag = item.Suppliers?.ToString() };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Measure.ToString(), Tag = item.Measure.ToString() };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Quantity.ToString(), Tag = item.Quantity.ToString() };
			subItems.Add(subItem);

			subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
		}

		protected override void SetGroupsToItems(int columnIndex)
		{
			itemsListView.Groups.Clear();
			foreach (ListViewItem item in itemsListView.Items)
			{
				String temp;
				if (item.Tag is RequestForQuotationRecord)
				{
					var q= (RequestForQuotationRecord)item.Tag;
					var p =  q.Product;

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
