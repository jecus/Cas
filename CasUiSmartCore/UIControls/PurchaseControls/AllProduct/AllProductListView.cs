using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.PurchaseControls
{
	public partial class AllProductListView : BaseListViewControl<Product>
	{
		#region public ProductListView()

		public AllProductListView()
        {
            IgnoreAutoResize = true;
			InitializeComponent();
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				var dp = ScreenAndFormManager.GetEditScreenOrForm(SelectedItem);
				if (dp.DisplayerType == DisplayerType.Screen)
					e.SetParameters(dp);
				else
				{
					if (dp.Form.ShowDialog() == DialogResult.OK)
					{
						if (dp.Form is ProductForm)
						{
							var changedJob = ((ProductForm)dp.Form).CurrentProdcuct;
							itemsListView.SelectedItems[0].Tag = changedJob;

							var subs = GetListViewSubItems(SelectedItem);
							for (int i = 0; i < subs.Length; i++)
								itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
						}
					}

					e.Cancel = true;
				}
			}

			#endregion
		}

        protected override void SetHeaders()
        {
            ColumnHeaderList.Clear();

            var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Part Number" };
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

            itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Product item)
        {
            var subItems = new List<ListViewItem.ListViewSubItem>();

            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.PartNumber, Tag = item.PartNumber });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Standart?.ToString(), Tag = item.Standart });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Description, Tag = item.Description });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Reference, Tag = item.Reference });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Code, Tag = item.Code });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Suppliers?.ToString(), Tag = item.Suppliers });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ATAChapter?.ToString(), Tag = item.ATAChapter });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.GoodsClass?.ToString(), Tag = item.GoodsClass });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.IsDangerous.ToString(), Tag = item.IsDangerous });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Remarks, Tag = item.Remarks });
            
            return subItems.ToArray();
        }
    }
}
