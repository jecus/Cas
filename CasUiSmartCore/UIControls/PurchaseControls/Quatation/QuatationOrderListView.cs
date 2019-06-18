using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class QuatationOrderListView : BaseGridViewControl<RequestForQuotationRecord>
	{
		public QuatationOrderListView()
		{
			InitializeComponent();
		}


		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			AddColumn("P/N", (int)(radGridView1.Width * 0.2f));
			AddColumn("Description", (int)(radGridView1.Width * 0.2f));
			AddColumn("Suppliers", (int)(radGridView1.Width * 0.2f));
			AddColumn("Measure", (int)(radGridView1.Width * 0.2f));
			AddColumn("Quantity", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}

		#endregion

		protected override List<CustomCell> GetListViewSubItems(RequestForQuotationRecord item)
		{
			var subItems = new List<CustomCell>();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			subItems.Add(CreateRow(item.Product?.PartNumber, item.Product?.PartNumber));
			subItems.Add(CreateRow(item.Product?.Description, item.Product?.Description));
			subItems.Add(CreateRow(item.Suppliers?.ToString(), item.Suppliers?.ToString()));
			subItems.Add(CreateRow(item.Measure.ToString(), item.Measure.ToString()));
			subItems.Add(CreateRow(item.Quantity.ToString(), item.Quantity.ToString()));
			subItems.Add(CreateRow(author, author));

			return subItems;
		}
	}
}
