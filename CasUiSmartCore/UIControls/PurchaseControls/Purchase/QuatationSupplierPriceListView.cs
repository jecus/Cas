using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class QuatationSupplierPriceListView : BaseListViewControl<SupplierPrice>
	{
		#region Constructor

		public QuatationSupplierPriceListView()
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

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Suppliers" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "CostNew" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "CostOverhaul" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "CostServiceable" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "CostRepair" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Product item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(SupplierPrice item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

			var subItem = new ListViewItem.ListViewSubItem { Text = item.Supplier.ToString(), Tag = item.Supplier };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.CostNew.ToString(), Tag = item.CostNew };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.CostOverhaul.ToString(), Tag = item.CostOverhaul };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.CostServiceable.ToString(), Tag = item.CostServiceable };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.CostRepair.ToString(), Tag = item.CostRepair };
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
				if (item.Tag is SupplierPrice)
				{
					var p = (SupplierPrice)item.Tag;

					temp = $"{p.Parent?.Product?.PartNumber} | Q-ty:{p.Parent?.Quantity}";
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
