using System.Collections.Generic;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class RequestProductListView : BaseGridViewControl<Product>
	{
		#region Constructor

		public RequestProductListView()
		{
			InitializeComponent();
			OldColumnIndex = 2;
			SortMultiplier = 1;
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			AddColumn("P/N", (int)(radGridView1.Width * 0.2f));
			AddColumn("Standart", (int)(radGridView1.Width * 0.2f));
			AddColumn("Description", (int)(radGridView1.Width * 0.2f));
			AddColumn("Class", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Product item)

		protected override List<CustomCell> GetListViewSubItems(Product item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			return new List<CustomCell>()
			{
				CreateRow(item.PartNumber, item.PartNumber),
				CreateRow(item.Standart?.ToString(), item.Standart),
				CreateRow(item.Name, item.Name),
				CreateRow( item?.GoodsClass?.ShortName ?? "Another accessory",  item?.GoodsClass),
				CreateRow(author, author),
			};
		}

		#endregion

		#region Overrides of BaseGridViewControl<InitialOrderRecord>

		protected override void GroupingItems()
		{
			Grouping("GoodClass");
		}

		#endregion
	}
}
