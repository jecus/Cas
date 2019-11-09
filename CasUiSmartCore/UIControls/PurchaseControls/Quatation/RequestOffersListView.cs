using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.PurchaseControls.Initial;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class RequestOffersListView : BaseGridViewControl<RequestForQuotationRecord>
	{
		#region public RequestOffersListView()
		///<summary>
		///</summary>
		public RequestOffersListView()
		{
			InitializeComponent();
			SortMultiplier = 0;
		}
		#endregion

		#region Methods

		#region protected override void SetGroupsToItems(int columnIndex)


		protected override void GroupingItems()
		{
			Grouping("Product");
		}


		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetItemsString(RequestForQuotation item)

		protected override List<CustomCell> GetListViewSubItems(RequestForQuotationRecord item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var destiantion = "";
			if (item?.ParentInitialRecord?.DestinationObjectType == SmartCoreType.Aircraft)
				destiantion = GlobalObjects.AircraftsCore.GetAircraftById(item?.ParentInitialRecord?.DestinationObjectId ?? -1)?.ToString();
			else destiantion = GlobalObjects.StoreCore.GetStoreById(item?.ParentInitialRecord?.DestinationObjectId ?? -1)?.ToString();
			var temp = $"{item?.Product?.PartNumber}";
			if (item?.ParentInitialRecord != null)
				temp += $"| Name: {item.Product?.Name} | Destination: {destiantion} | Priority: {item?.ParentInitialRecord?.Priority} | Requseted By: {((InitialOrder)item?.ParentInitialRecord?.ParentPackage)?.Author} | №:{item.ParentPackage.Title} | {item.ParentPackage.OpeningDate}";
			var res = new List<CustomCell>();
			foreach (var price in item.SupplierPrice)
			{
				res.AddRange(new List<CustomCell>
				{
					CreateRow(price.SupplierName, price.SupplierName),
					CreateRow(item.Quantity.ToString(), item.Quantity),
					CreateRow(item.Measure.ToString(), item.Measure),
					CreateRow(price.GetNewPriceString(), price),
					CreateRow(price.GetServPriceString(), price),
					CreateRow(price.GetOHPriceString(), price),
					CreateRow(price.GetRepairPriceString(), price),
					CreateRow(temp, temp),
					CreateRow(author, author),
				});
			}

			return res;
		}

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			//if (SelectedItem != null)
			//{

			//	var editForm = new QuatationOrderFormNew(SelectedItem);
			//	if (editForm.ShowDialog() == DialogResult.OK)
			//	{
			//		var subs = GetListViewSubItems(SelectedItem);
			//		for (int i = 0; i < subs.Count; i++)
			//			radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
			//	}
			//}
		}
		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			AddColumn("Supplier", (int)(radGridView1.Width * 0.2f));
			AddColumn("Q-ty", (int)(radGridView1.Width * 0.2f));
			AddColumn("Measure", (int)(radGridView1.Width * 0.2f));
			AddColumn("New", (int)(radGridView1.Width * 0.2f));
			AddColumn("Serv", (int)(radGridView1.Width * 0.2f));
			AddColumn("OH", (int)(radGridView1.Width * 0.2f));
			AddColumn("Repair", (int)(radGridView1.Width * 0.2f));
			AddColumn("Product", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));

		}

		#endregion
		#endregion
	}
}
