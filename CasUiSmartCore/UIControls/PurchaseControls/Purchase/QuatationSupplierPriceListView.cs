using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.NewGrid;
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
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Product item)

		protected override List<CustomCell> GetListViewSubItems(SupplierPrice item)
		{
			return new List<CustomCell>()
			{
				CreateRow(item.Supplier.ToString(),item.Supplier),
				CreateRow(item.CostNew.ToString(),item.CostNew),
				CreateRow(item.CostOverhaul.ToString(),item.CostOverhaul),
				CreateRow(item.CostServiceable.ToString(),item.CostServiceable),
				CreateRow(item.CostRepair.ToString(),item.CostRepair),
			};
		}

		#endregion
	}
}
