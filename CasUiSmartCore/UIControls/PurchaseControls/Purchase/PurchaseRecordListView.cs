using System.Collections.Generic;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
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
			AddColumn("Condition", (int)(radGridView1.Width * 0.2f));
			AddColumn("Measure", (int)(radGridView1.Width * 0.2f));
			AddColumn("P/N", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Product item)

		protected override List<CustomCell> GetListViewSubItems(PurchaseRequestRecord item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);

			return new List<CustomCell>()
			{
				CreateRow(item.Supplier.ToString(),item.Supplier),
				CreateRow(item.Quantity.ToString(),item.Quantity),
				CreateRow(item.Cost.ToString(),item.Cost),
				CreateRow(item.CostCondition.ToString(),item.CostCondition),
				CreateRow(item.Measure.ToString(),item.Measure),
				CreateRow(item.Product?.PartNumber,item.Product?.PartNumber),
				CreateRow(author,author),
			};
		}

		#endregion

		#region Overrides of BaseGridViewControl<InitialOrderRecord>

		protected override void GroupingItems()
		{
			Grouping("P/N");
		}

		#endregion

	}
}
