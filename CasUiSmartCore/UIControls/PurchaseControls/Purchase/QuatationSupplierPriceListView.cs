using System.Collections.Generic;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class QuatationSupplierPriceListView : BaseGridViewControl<SupplierPrice>
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
			AddColumn("Suppliers", (int)(radGridView1.Width * 0.2f));
			AddColumn("CostNew", (int)(radGridView1.Width * 0.2f));
			AddColumn("CostOverhaul", (int)(radGridView1.Width * 0.2f));
			AddColumn("CostServiceable", (int)(radGridView1.Width * 0.2f));
			AddColumn("CostRepair", (int)(radGridView1.Width * 0.2f));
			AddColumn("Product", (int)(radGridView1.Width * 0.2f));
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Product item)

		protected override List<CustomCell> GetListViewSubItems(SupplierPrice item)
		{
			var destiantion = "";
			if(item.Parent?.ParentInitialRecord?.DestinationObjectType == SmartCoreType.Aircraft)
				destiantion = GlobalObjects.AircraftsCore.GetAircraftById(item.Parent?.ParentInitialRecord?.DestinationObjectId ?? -1)?.ToString();
			else destiantion = GlobalObjects.StoreCore.GetStoreById(item.Parent?.ParentInitialRecord?.DestinationObjectId ?? -1)?.ToString();

			var temp = $"{item.Parent?.Product?.PartNumber} | Q-ty:{item.Parent?.Quantity} | Reason: {item.Parent?.ParentInitialRecord?.InitialReason} | Destination: {destiantion} | Priority: {item.Parent?.ParentInitialRecord?.Priority}";
			return new List<CustomCell>()
			{
				CreateRow(item.Supplier.ToString(),item.Supplier),
				CreateRow(item.CostNew.ToString(),item.CostNew),
				CreateRow(item.CostOverhaul.ToString(),item.CostOverhaul),
				CreateRow(item.CostServiceable.ToString(),item.CostServiceable),
				CreateRow(item.CostRepair.ToString(),item.CostRepair),
				CreateRow(temp,temp),
			};
		}

		#endregion

		#region Overrides of BaseGridViewControl<InitialOrderRecord>

		protected override void GroupingItems()
		{
			Grouping("Product");
		}

		#endregion

	}
}
