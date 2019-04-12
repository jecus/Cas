using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.KitControls;
using CASTerms;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.ForecastControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class ForecastKitsListView : BaseListViewControl<AccessoryRequired>
    {
        #region public ForecastKitsListView()
        ///<summary>
        ///</summary>
        public ForecastKitsListView()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        #region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)

        protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem == null) return;

            KitForm form = new KitForm(SelectedItem);

            if (form.ShowDialog() == DialogResult.OK)
            {
                ListViewItem.ListViewSubItem[] subs = GetListViewSubItems(SelectedItem);
                for (int i = 0; i < subs.Length; i++)
                    itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
            }
        }
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)
		protected override void SetGroupsToItems(int columnIndex)
        {
            itemsListView.Groups.Clear();

            IEnumerable<IGrouping<Product, ListViewItem>> groupByDescription =
                ListViewItemList.Where(l => l.Tag != null && l.Tag is AccessoryRequired)
                                .GroupBy(acr => ((AccessoryRequired)acr.Tag).Product);

            foreach (IGrouping<Product, ListViewItem> grouping in groupByDescription)
            {
                //Необходимые комплектующие
                IEnumerable<AccessoryRequired> requireds = grouping.Select(lvi => lvi.Tag as AccessoryRequired);
                //Описание необходимых комплектующих
                Product ad = grouping.Key;
                //кол-во необходимого комплектующего на период прогноза
                double qtyOnPeriod = requireds.Sum(r => r.TaskQuantity);
                string temp = ad + " Total per period: " + qtyOnPeriod;
                itemsListView.Groups.Add(temp, temp);

                foreach (ListViewItem item in grouping)
                {
                    item.Group = itemsListView.Groups[temp];
                }
            } 
        }
		#endregion

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			itemsListView.Columns.Clear();
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Standart" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Part Number" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Product" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Manufacturer" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Suppliers" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Check" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Task" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Cost new" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Cost OH" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Cost Serv." };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Q-ty." };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Task Q-ty." };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Class" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Remarks" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Signer" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(AccessoryRequired item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(AccessoryRequired item)
	    {
		    var subItems = new List<ListViewItem.ListViewSubItem>();

		    var check = item.MaintenanceCheck != null ? item.MaintenanceCheck.ToString() : "";
		    var standart = item.Standart != null ? item.Standart.ToString() : "";
		    var product = item.Product != null ? item.Product.ToString() : "";
		    var supplier = item.Suppliers != null ? item.Suppliers.ToString() : "";
		    var quantity = Math.Round(item.Quantity, 2).ToString();
		    var taskQuantity = Math.Round(item.TaskQuantity, 2).ToString();
		    var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			subItems.Add(new ListViewItem.ListViewSubItem { Text = standart, Tag = standart });
		    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.PartNumber, Tag = item.PartNumber });
		    subItems.Add(new ListViewItem.ListViewSubItem { Text = product, Tag = product });
		    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Manufacturer, Tag = item.Manufacturer });
		    subItems.Add(new ListViewItem.ListViewSubItem { Text = supplier, Tag = supplier });
		    subItems.Add(new ListViewItem.ListViewSubItem { Text = check, Tag = check });
		    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ParentString, Tag = item.ParentString });
		    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CostNew.ToString(), Tag = item.CostNew });
		    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CostOverhaul.ToString(), Tag = item.CostOverhaul });
		    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CostServiceable.ToString(), Tag = item.CostServiceable });
		    subItems.Add(new ListViewItem.ListViewSubItem { Text = quantity, Tag = item.Quantity });
		    subItems.Add(new ListViewItem.ListViewSubItem { Text = taskQuantity, Tag = item.TaskQuantity });
		    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.GoodsClass.ToString(), Tag = item.GoodsClass });
		    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Remarks, Tag = item.Remarks });
		    subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
	    }

	    #endregion

	    #endregion
	}
}
