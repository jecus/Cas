using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.PurchaseControls.Initial;
using CAS.UI.UIControls.PurchaseControls.Purchase;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.AllOrders
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class AllOrderListView : BaseListViewControl<ILogistic>
    {
        #region public InitialOrderListView()
        ///<summary>
        ///</summary>
        public AllOrderListView()
        {
            IgnoreAutoResize = true;
            OldColumnIndex = 0;
            SortMultiplier = 1;
            InitializeComponent();
        }
		#endregion

		#region Methods

		#region protected override SetGroupsToItems(int columnIndex)
		protected override void SetGroupsToItems(int columnIndex)
        {
            itemsListView.Groups.Clear();
            itemsListView.Groups.Add("GroupInitial", "Initial");
            itemsListView.Groups.Add("GroupQuotation", "Quotation");
            itemsListView.Groups.Add("GroupPurchase", "Purchase");
            itemsListView.Groups.Add("GroupUnknown", "Unknown");

            foreach (var item in ListViewItemList)
            {
                if (((ILogistic)item.Tag) is InitialOrder)
                    item.Group = itemsListView.Groups[0];
                else if (((ILogistic)item.Tag) is RequestForQuotation)
                    item.Group = itemsListView.Groups[1];
                else if (((ILogistic)item.Tag) is PurchaseOrder)
                    item.Group = itemsListView.Groups[2];
                else item.Group = itemsListView.Groups[3];
            }   
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetItemsString(InitialOrder item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(ILogistic item)
        {
            var subItems = new List<ListViewItem.ListViewSubItem>();
            var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Status.ToString(), Tag = item.Status });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Number, Tag = item.Number });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Title, Tag = item.Title });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem {
                Text = item.OpeningDate == (new DateTime(1852, 01, 01))
                    ? ""
                    : SmartCore.Auxiliary.Convert.GetDateFormat(item.OpeningDate),
                Tag = item.OpeningDate
            });
            subItems.Add(new ListViewItem.ListViewSubItem {
                Text = item.Status != WorkPackageStatus.Opened
                    ? item.PublishingDate == (new DateTime(1852, 01, 01))
                        ? ""
                        : SmartCore.Auxiliary.Convert.GetDateFormat(item.PublishingDate)
                    : "",
                Tag = item.PublishingDate});
            subItems.Add(new ListViewItem.ListViewSubItem {
                Text = item.Status == WorkPackageStatus.Closed
                    ? item.ClosingDate == (new DateTime(1852, 01, 01))
                        ? ""
                        : SmartCore.Auxiliary.Convert.GetDateFormat(item.ClosingDate)
                    : "",
                Tag = item.ClosingDate
            });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Author, Tag = item.Author });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.PublishedByUser, Tag = item.PublishedByUser });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CloseByUser, Tag = item.CloseByUser });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Remarks, Tag = item.Remarks });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
           
        }

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (SelectedItem == null) return;

			if (SelectedItem is InitialOrder)
			{
				var editForm = new InitialOrderFormNew(SelectedItem as InitialOrder);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					var subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Length; i++)
						itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
				}
			}
			else if (SelectedItem is RequestForQuotation)
			{
				var editForm = new QuatationOrderFormNew(SelectedItem as RequestForQuotation);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					var subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Length; i++)
						itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
				}
			}
			else
			{
				var editForm = new PurchaseOrderForm(SelectedItem as PurchaseOrder);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					var subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Length; i++)
						itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
				}
			}

			
		}
		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
        {
            ColumnHeaderList.Clear();

            var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Status" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Order No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Title" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Create Date" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Opening date" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.13f), Text = "Publishing date" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Closing date" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Author" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Published By" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Closed By" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Remark" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Signer" };
            ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }

        #endregion

        #endregion
    }
}
