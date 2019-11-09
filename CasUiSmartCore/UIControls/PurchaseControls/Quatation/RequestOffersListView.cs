using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.PurchaseControls.Initial;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{

	public class SupplierPriceCustom : BaseEntityObject
	{
		public SupplierPrice Price { get; set; }
		public RequestForQuotationRecord Record { get; set; }
	}

	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class RequestOffersListView : BaseGridViewControl<SupplierPriceCustom>
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

		protected override List<CustomCell> GetListViewSubItems(SupplierPriceCustom item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var destiantion = "";
			if (item.Record?.ParentInitialRecord?.DestinationObjectType == SmartCoreType.Aircraft)
				destiantion = GlobalObjects.AircraftsCore.GetAircraftById(item.Record?.ParentInitialRecord?.DestinationObjectId ?? -1)?.ToString();
			else destiantion = GlobalObjects.StoreCore.GetStoreById(item?.Record.ParentInitialRecord?.DestinationObjectId ?? -1)?.ToString();
			var temp = $"{item.Record?.Product?.PartNumber}";
			if (item.Record?.ParentInitialRecord != null)
				temp += $"| Name: {item.Record.Product?.Name} | Destination: {destiantion} | Priority: {item.Record?.ParentInitialRecord?.Priority} | №:{((RequestForQuotation)item.Record.ParentPackage).Number} | {SmartCore.Auxiliary.Convert.GetDateFormat(item.Record.ParentPackage.OpeningDate)}";


			return new List<CustomCell>
			{
				CreateRow(item.Price.SupplierName, item.Price.SupplierName),
				CreateRow(item.Record.Quantity.ToString(), item.Record.Quantity),
				CreateRow(item.Record.Measure.ToString(), item.Record.Measure),
				CreateRow(item.Price.GetNewPriceString(), item.Price),
				CreateRow(item.Price.GetServPriceString(), item.Price),
				CreateRow(item.Price.GetOHPriceString(), item.Price),
				CreateRow(item.Price.GetRepairPriceString(), item.Price),
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
