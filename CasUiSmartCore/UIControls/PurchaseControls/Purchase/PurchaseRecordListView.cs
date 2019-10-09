using System.Collections.Generic;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Purchase
{
	public partial class PurchaseRecordListView : BaseGridViewControl<PurchaseRequestRecord>
	{
		private readonly bool _orderBySupplies;

		#region Constructor

		public PurchaseRecordListView(bool orderBySupplies = false)
		{
			_orderBySupplies = orderBySupplies;
			InitializeComponent();
			OldColumnIndex = 2;
			SortMultiplier = 1;
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
			AddColumn("Product", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Product item)

		protected override List<CustomCell> GetListViewSubItems(PurchaseRequestRecord item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var destiantion = "";
			if (item?.ParentInitialRecord?.DestinationObjectType == SmartCoreType.Aircraft)
				destiantion = GlobalObjects.AircraftsCore.GetAircraftById(item?.ParentInitialRecord?.DestinationObjectId ?? -1)?.ToString();
			else destiantion = GlobalObjects.StoreCore.GetStoreById(item?.ParentInitialRecord?.DestinationObjectId ?? -1)?.ToString();
			var temp = $"{item?.Product?.PartNumber}";
			if (item?.ParentInitialRecord != null)
			 temp += $" | Q-ty:{item?.ParentInitialRecord?.Quantity} | Reason: {item?.ParentInitialRecord?.InitialReason} | Destination: {destiantion} | Priority: {item?.ParentInitialRecord?.Priority}";

			double total = item.Quantity * item.Cost;

			return new List<CustomCell>()
			{
				CreateRow(item.Supplier.ToString(),item.Supplier),
				CreateRow(item.Quantity.ToString(),item.Quantity),
				CreateRow($"{item.Cost} {item.Currency}",item.Cost),
				CreateRow($"{total:0.##} {item.Currency}", total),
				CreateRow(item.CostCondition.ToString(),item.CostCondition),
				CreateRow(item.Measure.ToString(),item.Measure),
				CreateRow(temp,temp),
				CreateRow(author,author),
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
