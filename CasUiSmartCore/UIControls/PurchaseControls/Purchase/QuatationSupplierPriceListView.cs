using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Entities.General.Accessory;
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

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Offering" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Routine" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "K for MH" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "NDT" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "K for MH" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "AD" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "K for MH" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "NRC" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "K for MH" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Currency" };
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

			subItem = new ListViewItem.ListViewSubItem { Text = item.Offering.ToString(), Tag = item.Offering };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Routine.ToString(), Tag = item.Routine };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.RoutineKMH.ToString(), Tag = item.RoutineKMH };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.NDT.ToString(), Tag = item.NDT };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.NDTKMH.ToString(), Tag = item.NDTKMH };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.AD.ToString(), Tag = item.AD };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.ADKMH.ToString(), Tag = item.ADKMH };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.NRC.ToString(), Tag = item.NRC };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.NRCKMH.ToString(), Tag = item.NRCKMH };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.СurrencyOffering.ToString(), Tag = item.СurrencyOffering };
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
