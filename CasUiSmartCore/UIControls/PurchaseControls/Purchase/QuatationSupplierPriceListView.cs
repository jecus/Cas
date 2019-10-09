using System.Collections.Generic;
using System.Drawing;
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
			AddColumn("New", (int)(radGridView1.Width * 0.15f));
			AddColumn("Overhaul", (int)(radGridView1.Width * 0.15f));
			AddColumn("Serviceable", (int)(radGridView1.Width * 0.15f));
			AddColumn("Repair", (int)(radGridView1.Width * 0.15f));
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

			Color? colorNew = null;
			Color? colorOH = null;
			Color? colorServ = null;
			Color? colorRep = null;

			if(item.IsHighestCostNew)
				colorNew = Color.Red;
			if(item.IsLowestCostNew)
				colorNew = Color.Green;

			if (item.IsHighestCostOH)
				colorOH = Color.Red;
			if (item.IsHighestCostOH)
				colorOH = Color.Green;

			if (item.IsHighestCostServ)
				colorServ = Color.Red;
			if (item.IsHighestCostServ)
				colorServ = Color.Green;

			if (item.IsHighestCostRepair)
				colorRep = Color.Red;
			if (item.IsHighestCostRepair)
				colorRep = Color.Green;


			return new List<CustomCell>()
			{
				CreateRow(item.Supplier.ToString(),item.Supplier),
				CreateRow(item.CostNew.ToString(),item.CostNew, colorNew),
				CreateRow(item.CostOverhaul.ToString(),item.CostOverhaul, colorOH),
				CreateRow(item.CostServiceable.ToString(),item.CostServiceable, colorServ),
				CreateRow(item.CostRepair.ToString(),item.CostRepair, colorRep),
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
