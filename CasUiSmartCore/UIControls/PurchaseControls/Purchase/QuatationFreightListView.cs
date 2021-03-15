using System.Collections.Generic;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Purchase
{
	public partial class QuatationFreightListView : BaseGridViewControl<PurchaseShipper>
	{
		public QuatationFreightListView()
		{
			InitializeComponent();
			DisableContectMenu();
		}


		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			AddColumn("PO №", (int)(radGridView1.Width * 0.2f));
			AddColumn("Shippers", (int)(radGridView1.Width * 0.3f));
			AddColumn("Cost", (int)(radGridView1.Width * 0.2f));
			AddColumn("Remark", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}

		#endregion

		protected override List<CustomCell> GetListViewSubItems(PurchaseShipper item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var subItems = new List<CustomCell>
			{
				CreateRow(item.PONumber, item.PONumber),
				CreateRow(item.Shipper.ToString(), item.Shipper.ToString()),
				CreateRow($"{item.Cost:F} {item.Currency}", item.Cost),
				CreateRow(item.Remark, item.Remark),
				CreateRow(author, author)
			};
			return subItems;
		}
	}
}
