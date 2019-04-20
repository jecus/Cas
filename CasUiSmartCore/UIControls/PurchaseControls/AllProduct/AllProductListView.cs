using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.PurchaseControls
{
	public partial class AllProductListView : BaseListViewControl<Product>
	{
		#region public ProductListView()

		public AllProductListView()
        {
            SortMultiplier = 1;
            IgnoreAutoResize = true;
			InitializeComponent();
		}

		#endregion

		protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (SelectedItem == null) return;

			if (SelectedItem.ProductType == ProductType.ComponentModel)
			{
				var editForm = new ModelForm(SelectedItem as ComponentModel);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					var subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Length; i++)
						itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
				}
			}
			else
			{
				var editForm = new ProductForm(SelectedItem);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					var subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Length; i++)
						itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
				}
			}
		}


		protected override void SetHeaders()
        {
            ColumnHeaderList.Clear();


            var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Name" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Part Number" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Alt Part Number" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Standart" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Description" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Reference" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Product Code" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Suppliers" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "ATA" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Class" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "IsDangerous" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Remarks" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Signer" };
            ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Product item)
        {
            var subItems = new List<ListViewItem.ListViewSubItem>();
            var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Name, Tag = item.Name });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.PartNumber, Tag = item.PartNumber });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.AltPartNumber, Tag = item.AltPartNumber });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Standart?.ToString(), Tag = item.Standart });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Description, Tag = item.Description });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Reference, Tag = item.Reference });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Code, Tag = item.Code });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Suppliers?.ToString(), Tag = item.Suppliers });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ATAChapter?.ToString(), Tag = item.ATAChapter });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.GoodsClass?.ToString(), Tag = item.GoodsClass });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.IsDangerous.ToString(), Tag = item.IsDangerous });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Remarks, Tag = item.Remarks });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
        }

        protected override void SetGroupsToItems(int columnIndex)
        {
            itemsListView.Groups.Clear();
            foreach (var item in ListViewItemList)
            {
                var product = item.Tag as Product;
                var temp = product.ProductType.ToString();

                itemsListView.Groups.Add(temp, temp);
                item.Group = itemsListView.Groups[temp];
            }
        }
        
    }
}
