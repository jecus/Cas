using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.NewGrid;
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
    public partial class AllOrderListView : BaseGridViewControl<ILogistic>
    {
        #region public InitialOrderListView()
        ///<summary>
        ///</summary>
        public AllOrderListView()
        {
            OldColumnIndex = 0;
            SortMultiplier = 1;
            InitializeComponent();
        }
		#endregion

		#region Methods

		#region protected override SetGroupsToItems(int columnIndex)
		//protected override void SetGroupsToItems(int columnIndex)
  //      {
  //          itemsListView.Groups.Clear();
  //          itemsListView.Groups.Add("GroupInitial", "Initial");
  //          itemsListView.Groups.Add("GroupQuotation", "Quotation");
  //          itemsListView.Groups.Add("GroupPurchase", "Purchase");
  //          itemsListView.Groups.Add("GroupUnknown", "Unknown");

  //          foreach (var item in ListViewItemList)
  //          {
  //              if (((ILogistic)item.Tag) is InitialOrder)
  //                  item.Group = itemsListView.Groups[0];
  //              else if (((ILogistic)item.Tag) is RequestForQuotation)
  //                  item.Group = itemsListView.Groups[1];
  //              else if (((ILogistic)item.Tag) is PurchaseOrder)
  //                  item.Group = itemsListView.Groups[2];
  //              else item.Group = itemsListView.Groups[3];
  //          }   
  //      }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetItemsString(InitialOrder item)

        protected override List<CustomCell> GetListViewSubItems(ILogistic item)
        {
            var subItems = new List<CustomCell>();
            var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			subItems.Add(CreateRow(item.Status.ToString(), item.Status ));
			subItems.Add(CreateRow(item.Number, item.Number ));
            subItems.Add(CreateRow(item.Title, item.Title ));
			subItems.Add(CreateRow( "", "" ));
            subItems.Add(CreateRow(item.OpeningDate == (new DateTime(1852, 01, 01))
                    ? ""
                    : SmartCore.Auxiliary.Convert.GetDateFormat(item.OpeningDate), item.OpeningDate));
            subItems.Add(CreateRow(item.Status != WorkPackageStatus.Opened
                    ? item.PublishingDate == (new DateTime(1852, 01, 01))
                        ? ""
                        : SmartCore.Auxiliary.Convert.GetDateFormat(item.PublishingDate)
                    : "", item.PublishingDate));
            subItems.Add(CreateRow(item.Status == WorkPackageStatus.Closed
                    ? item.ClosingDate == (new DateTime(1852, 01, 01))
                        ? ""
                        : SmartCore.Auxiliary.Convert.GetDateFormat(item.ClosingDate)
                    : "", item.ClosingDate));
            subItems.Add(CreateRow(item.Author, item.Author ));
            subItems.Add(CreateRow(item.PublishedByUser, item.PublishedByUser ));
            subItems.Add(CreateRow(item.CloseByUser, item.CloseByUser ));
            subItems.Add(CreateRow(item.Remarks, item.Remarks ));
            subItems.Add(CreateRow(author, author ));

			return subItems;
        }

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem == null) return;

			if (SelectedItem is InitialOrder)
			{
				var editForm = new InitialOrderFormNew(SelectedItem as InitialOrder);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					var subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Count; i++)
						radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
				}
			}
			else if (SelectedItem is RequestForQuotation)
			{
				var editForm = new QuatationOrderFormNew(SelectedItem as RequestForQuotation);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					var subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Count; i++)
						radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
				}
			}
			else
			{
				var editForm = new PurchaseOrderForm(SelectedItem as PurchaseOrder);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					var subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Count; i++)
						radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
				}
			}

			
		}
		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
        {
			AddColumn("Status", (int)(radGridView1.Width * 0.24f));
			AddColumn("Order No", (int)(radGridView1.Width * 0.24f));
			AddColumn("Title", (int)(radGridView1.Width * 0.30f));
			AddColumn("Create Date", (int)(radGridView1.Width * 0.24f));
			AddColumn("Opening date", (int)(radGridView1.Width * 0.24f));
			AddColumn("Publishing date", (int)(radGridView1.Width * 0.26f));
			AddColumn("Closing date", (int)(radGridView1.Width * 0.24f));
			AddColumn("Author", (int)(radGridView1.Width * 0.24f));
			AddColumn("Published By", (int)(radGridView1.Width * 0.24f));
			AddColumn("Closed By", (int)(radGridView1.Width * 0.24f));
			AddColumn("Remark", (int)(radGridView1.Width * 0.24f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
        }

        #endregion

        #endregion
    }
}
