using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using EFCore.DTO.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class PurchaseRecordListView : BaseListViewControl<PurchaseRequestRecord>
	{
		#region Constructor

		public PurchaseRecordListView()
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

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Supplier" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Q-ty" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Cost" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Condition" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Measure" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Product item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(PurchaseRequestRecord item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

			var subItem = new ListViewItem.ListViewSubItem { Text = item.Supplier.ToString(), Tag = item.Supplier };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Quantity.ToString(), Tag = item.Quantity };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Cost.ToString(), Tag = item.Cost };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.CostCondition.ToString(), Tag = item.Measure };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Measure.ToString(), Tag = item.Measure };
			subItems.Add(subItem);

			return subItems.ToArray();
		}

		#endregion


		protected override void SetGroupsToItems(int columnIndex)
		{
			itemsListView.Groups.Clear();
			foreach (ListViewItem item in itemsListView.Items)
			{
				string temp;
				if (item.Tag is PurchaseRequestRecord)
				{
					var p = (PurchaseRequestRecord)item.Tag;

					temp = $"{p.Product?.PartNumber}";
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
