using System;
using System.Collections.Generic;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{

	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class PurchaseStatusListView : BaseGridViewControl<PurchaseRequestRecord>
	{
		#region public PurchaseStatusListView()
		///<summary>
		///</summary>
		public PurchaseStatusListView()
		{
			InitializeComponent();
			DisableContectMenu();
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

		protected override List<CustomCell> GetListViewSubItems(PurchaseRequestRecord item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var destiantion = "";
			if (item.ParentInitialRecord?.DestinationObjectType == SmartCoreType.Aircraft)
				destiantion = GlobalObjects.AircraftsCore.GetAircraftById(item.ParentInitialRecord?.DestinationObjectId ?? -1)?.ToString();
			else destiantion = GlobalObjects.StoreCore.GetStoreById(item?.ParentInitialRecord?.DestinationObjectId ?? -1)?.ToString();
			var temp = $"{item.Product?.PartNumber}";
			if (item.ParentInitialRecord != null)
				temp += $"| {item.Product?.Standart} | {item.Product?.Name} | {destiantion} | {item.ParentInitialRecord?.Priority} | №:{((PurchaseOrder)item.ParentPackage).Number} | {SmartCore.Auxiliary.Convert.GetDateFormat(item.ParentPackage.OpeningDate)}";
			double total = item.Quantity * item.Cost;
			var order = item.ParentPackage as PurchaseOrder;

			return new List<CustomCell>
			{
				CreateRow(item.Supplier.Name, item.Supplier.Name),
				CreateRow(item.Quantity.ToString(), item.Quantity),
				CreateRow($"{item.Cost} {item.Currency}",item.Cost),
				CreateRow($"{total:0.##} {item.Currency}", total),
				CreateRow(item.CostCondition.ToString(),item.CostCondition),
				CreateRow(item.Measure.ToString(),item.Measure),
				CreateRow($"{SmartCore.Auxiliary.Convert.GetDateFormat(order.AdditionalInformation.ArrivalDate)} {order.AdditionalInformation.ArrivalTime:HH:mm}", order),
				CreateRow($"{SmartCore.Auxiliary.Convert.GetDateFormat(order.AdditionalInformation.ReceiptDate)} {order.AdditionalInformation.ReceiptTime:HH:mm}", order),
				CreateRow(order.AdditionalInformation.StatusOfDelivery.ToString(), order.AdditionalInformation.StatusOfDelivery),
				CreateRow(temp, temp),
				CreateRow(author, author),
			}; 
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
			AddColumn("Cost", (int)(radGridView1.Width * 0.2f));
			AddColumn("Total Cost", (int)(radGridView1.Width * 0.2f));
			AddColumn("Condition", (int)(radGridView1.Width * 0.2f));
			AddColumn("Measure", (int)(radGridView1.Width * 0.2f));
			AddColumn("Arrival", (int)(radGridView1.Width * 0.2f));
			AddColumn("Receipt", (int)(radGridView1.Width * 0.2f));
			AddColumn("Status of delivery", (int)(radGridView1.Width * 0.2f));
			AddColumn("Product", (int)(radGridView1.Width * 0.3f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));

		}

		#endregion
		#endregion
	}
}
