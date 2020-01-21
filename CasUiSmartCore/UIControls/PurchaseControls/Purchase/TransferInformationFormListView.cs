using System;
using System.Collections.Generic;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Purchase
{
	public partial class TransferInformationFormListView : BaseGridViewControl<TransferInformation>
	{
		#region Constructor

		public TransferInformationFormListView()
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
			AddColumn("Product", (int)(radGridView1.Width * 0.2f));
			AddColumn("Number", (int)(radGridView1.Width * 0.2f));
			AddColumn("Part Number", (int)(radGridView1.Width * 0.23f));
			AddColumn("Serial Number", (int) (radGridView1.Width * 0.23f));
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Product item)

		protected override List<CustomCell> GetListViewSubItems(TransferInformation item)
		{
			return new List<CustomCell>()
			{
				CreateRow(item.Product.ToString(),item.Product),
				CreateRow(item.Number.ToString(),item.Number),
				CreateRow(item.PartNumber, item.PartNumber),
				CreateRow(item.SerialNumber, item.SerialNumber)
			};
		}

		#endregion

		#region protected override void GroupingItems()

		protected override void GroupingItems()
		{
			Grouping("Product");
		}

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			
		}
		#endregion
	}
}
