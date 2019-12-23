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
			DisableContectMenu();
			OldColumnIndex = 2;
			SortMultiplier = 1;
		}

		#endregion


		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			AddColumn("Suppliers", (int)(radGridView1.Width * 0.2f));
			AddColumn("New", (int)(radGridView1.Width * 0.15f));
			AddColumn("Serv", (int)(radGridView1.Width * 0.15f));
			AddColumn("Test", (int)(radGridView1.Width * 0.15f));
			AddColumn("Inspect", (int)(radGridView1.Width * 0.15f));
			AddColumn("OH", (int)(radGridView1.Width * 0.15f));
			AddColumn("Repair", (int)(radGridView1.Width * 0.15f));
			AddColumn("Modification", (int)(radGridView1.Width * 0.15f));
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

			var temp = $"P/N: {item?.Parent?.Product?.PartNumber}";
			if (item?.Parent?.ParentInitialRecord != null)
				temp += $"| {item.Parent?.Product?.Standart}  | Name: {item?.Parent?.Product?.Name} | {destiantion} | {item?.Parent?.ParentInitialRecord?.Priority} | Requsted By: {((InitialOrder)item?.Parent?.ParentInitialRecord?.ParentPackage)?.Author}";

			Color? colorNew = null;
			Color? colorOH = null;
			Color? colorServ = null;
			Color? colorRep = null;
			Color? colorTest = null;
			Color? colorInsp = null;
			Color? colorMod = null;

			if(item.IsHighestCostNew)
				colorNew = Color.Red;
			if(item.IsLowestCostNew)
				colorNew = Color.Green;

			if (item.IsHighestCostOH)
				colorOH = Color.Red;
			if (item.IsLowestCostOH)
				colorOH = Color.Green;

			if (item.IsHighestCostServ)
				colorServ = Color.Red;
			if (item.IsLowestCostServ)
				colorServ = Color.Green;

			if (item.IsHighestCostRepair)
				colorRep = Color.Red;
			if (item.IsLowestCostRepair)
				colorRep = Color.Green;

			if (item.IsHighestCostTest)
				colorTest = Color.Red;
			if (item.IsHighestCostTest)
				colorTest = Color.Green;

			if (item.IsHighestCostInspect)
				colorInsp = Color.Red;
			if (item.IsHighestCostInspect)
				colorInsp = Color.Green;

			if (item.IsHighestCostMod)
				colorMod = Color.Red;
			if (item.IsHighestCostMod)
				colorMod = Color.Green;


			return new List<CustomCell>()
			{
				CreateRow(item.Supplier.ToString(),item.Supplier),
				CreateRow(item.CostNewString, item.CostNewString, colorNew),
				CreateRow(item.CostServString, item.CostServString, colorServ),
				CreateRow(item.CostTestString, item.CostTestString, colorTest),
				CreateRow(item.CostInspectString, item.CostInspectString, colorInsp),
				CreateRow(item.CostOHString, item.CostOHString, colorOH),
				CreateRow(item.CostRepairString, item.CostRepairString, colorRep),
				CreateRow(item.CostModificationString, item.CostModificationString, colorMod),
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
