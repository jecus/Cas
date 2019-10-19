using System.Collections.Generic;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Initial
{
	public partial class InitialOrderListView :  BaseGridViewControl<InitialOrderRecord>
	{
		public InitialOrderListView()
		{
			InitializeComponent();
		}

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			AddColumn("P/N", (int)(radGridView1.Width * 0.2f));
			AddColumn("Standart", (int)(radGridView1.Width * 0.2f));
			AddColumn("Description", (int)(radGridView1.Width * 0.2f));
			AddColumn("Class", (int)(radGridView1.Width * 0.2f));
			AddColumn("Measure", (int)(radGridView1.Width * 0.2f));
			AddColumn("Quantity", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}

		#endregion

		protected override List<CustomCell> GetListViewSubItems(InitialOrderRecord item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			return new List<CustomCell>()
			{
				CreateRow(item.Product?.PartNumber, item.Product?.PartNumber),
				CreateRow( item.Product?.Standart?.ToString(),  item.Product?.Standart?.ToString()),
				CreateRow( item.Product?.Name,  item.Product?.Name),
				CreateRow( item.Product?.GoodsClass?.ShortName ?? "Another accessory",  item.Product?.GoodsClass),
				CreateRow( item.Measure.ToString(),  item.Measure.ToString()),
				CreateRow( item.Quantity.ToString(),  item.Quantity.ToString()),
				CreateRow( author,  author),
			};
		}


		#region Overrides of BaseGridViewControl<InitialOrderRecord>

		protected override void GroupingItems()
		{
			Grouping("Class");
		}

		#endregion


	}
}
