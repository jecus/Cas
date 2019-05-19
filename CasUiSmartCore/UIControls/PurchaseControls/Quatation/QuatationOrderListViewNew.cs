using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class QuatationOrderListViewNew : BaseListViewControl<BaseCoreObject>
	{
		public QuatationOrderListViewNew()
		{
			InitializeComponent();
		}


		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();
			itemsListView.Columns.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "P/N" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Suppliers" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.17f), Text = "Description" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.17f), Text = "Measure" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.17f), Text = "Quantity" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.7f), Text = "Signer" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseCoreObject item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();
			if (item is RequestForQuotationRecord)
			{
				var record = item as RequestForQuotationRecord;
				var author = GlobalObjects.CasEnvironment.GetCorrector(record.CorrectorId);

				var subItem = new ListViewItem.ListViewSubItem { Text = record.Product?.PartNumber, Tag = record.Product?.PartNumber };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = record.Suppliers?.ToString(), Tag = record.Suppliers?.ToString() };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = record.Product?.Description, Tag = record.Product?.Description };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = record.Measure.ToString(), Tag = record.Measure.ToString() };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = record.Quantity.ToString(), Tag = record.Quantity.ToString() };
				subItems.Add(subItem);

				subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });
			}
			else
			{
				var record = item as SupplierPrice;
				subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = record.Supplier.ToString(), Tag = record.Supplier });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = $"New:{record.CostNew} {record.СurrencyNew}", Tag = record.CostNew });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = $"OH:{record.CostOverhaul} {record.СurrencyOH}", Tag = record.CostOverhaul });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = $"Serv:{record.CostServiceable} {record.СurrencyServ}", Tag = record.CostServiceable });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = $"Rep:{record.CostRepair} {record.СurrencyRepair}", Tag = record.CostRepair });
			}
				

			return subItems.ToArray();
		}

		#region protected override void SetItemColor(ListViewItem listViewItem, BaseSmartCoreObject item)
		protected override void SetItemColor(ListViewItem listViewItem, BaseCoreObject item)
		{
			if (item is SupplierPrice)
			{
				listViewItem.ForeColor = Color.Gray;
				listViewItem.BackColor = Color.FromArgb(Highlight.White.Color);
			}
			if (item is RequestForQuotationRecord)
			{
				listViewItem.ForeColor = Color.Black;
				listViewItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
			}
		}
		#endregion

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
				else if (item.Tag is SupplierPrice)
				{
					var q = (SupplierPrice)item.Tag;
					var p = q.Parent.Product;

					temp = p.GoodsClass.ShortName;
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
