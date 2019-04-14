using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.PurchaseControls.Purchase;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    ///</summary>
    public partial class PurchaseOrderListView : BaseListViewControl<PurchaseOrder>
    {
        #region public PurchaseOrderListView()
        ///<summary>
        ///</summary>
        public PurchaseOrderListView()
        {
            IgnoreAutoResize = true;
            InitializeComponent();
        }
		#endregion

		#region Methods

		#region protected override SetGroupsToItems(int columnIndex)
		protected override void SetGroupsToItems(int columnIndex)
        {
            itemsListView.Groups.Clear();
            itemsListView.Groups.Add("GroupOpened", "Opened");
            itemsListView.Groups.Add("GroupPublished", "Published");
            itemsListView.Groups.Add("GroupClosed", "Closed");
            itemsListView.Groups.Add("GroupUnknown", "Unknown");

            foreach (ListViewItem item in ListViewItemList)
            {
                if (((PurchaseOrder)item.Tag).Status == WorkPackageStatus.Closed)
                {
                    item.Group = itemsListView.Groups[2];
                }
                else if (((PurchaseOrder)item.Tag).Status == WorkPackageStatus.Published)
                {
                    item.Group = itemsListView.Groups[1];
                }
                else if (((PurchaseOrder)item.Tag).Status == WorkPackageStatus.Opened)
                {
                    item.Group = itemsListView.Groups[0];
                }
                else
                {
                    item.Group = itemsListView.Groups[3];
                }
            }   
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetItemsString(PurchaseOrder item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(PurchaseOrder item)
        {
            var subItems = new List<ListViewItem.ListViewSubItem>();
            var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Number, Tag = item.Number });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Title, Tag = item.Title });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Description, Tag = item.Description });
            subItems.Add(new ListViewItem.ListViewSubItem
            {
                Text = item.OpeningDate == (new DateTime(1852, 01, 01))
                    ? ""
                    : SmartCore.Auxiliary.Convert.GetDateFormat(item.OpeningDate),
                Tag = item.OpeningDate
            });
            subItems.Add(new ListViewItem.ListViewSubItem
            {
                Text = item.Status != WorkPackageStatus.Opened
                    ? item.PublishingDate == (new DateTime(1852, 01, 01))
                        ? ""
                        : SmartCore.Auxiliary.Convert.GetDateFormat(item.PublishingDate)
                    : "",
                Tag = item.PublishingDate
            });
            subItems.Add(new ListViewItem.ListViewSubItem
            {
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

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		//protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		//{
		//    //if (SelectedItem != null)
		//    //{
		//    //    e.TypeOfReflection = ReflectionTypes.DisplayInCurrent;
		//    //    e.DisplayerText = SelectedItem.Title;
		//    //    e.RequestedEntity = new PurchaseOrderScreen(SelectedItem);
		//    //}
		//}

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)

		/// <summary>
		/// Реагирует на двойной щелчок в списке элементов
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (SelectedItem == null) return;

			var form = new PurchaseOrderForm(SelectedItem);
			form.ShowDialog();
		}
		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
        {
            ColumnHeaderList.Clear();

            var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Order No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Title" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Description" };
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
