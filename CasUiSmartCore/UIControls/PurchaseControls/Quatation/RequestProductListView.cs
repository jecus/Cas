using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
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
			AddColumn("GoodClass", (int)(radGridView1.Width * 0.2f));
			AddColumn("ATA", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Product item)

		protected override List<CustomCell> GetListViewSubItems(Product item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
			return new List<CustomCell>()
			{
				CreateRow(item.PartNumber, item.PartNumber),
				CreateRow(item.Standart?.ToString(), item.Standart),
				CreateRow(item.Description, item.Description),
				CreateRow( item?.GoodsClass?.ShortName ?? "Another accessory",  item?.GoodsClass),
				CreateRow(item.ATAChapter?.ToString(), item.ATAChapter?.ToString()),
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
