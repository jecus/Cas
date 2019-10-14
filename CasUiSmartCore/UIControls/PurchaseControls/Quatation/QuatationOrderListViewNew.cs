using System.Collections.Generic;
using System.Drawing;
using Auxiliary;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Purchase;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class QuatationOrderListViewNew : BaseGridViewControl<IBaseEntityObject>
	{
		public QuatationOrderListViewNew()
		{
			InitializeComponent();
		}


		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			AddColumn("P/N", (int)(radGridView1.Width * 0.2f));
			AddColumn("Suppliers", (int)(radGridView1.Width * 0.2f));
			AddColumn("Name", (int)(radGridView1.Width * 0.2f));
			AddColumn("Measure", (int)(radGridView1.Width * 0.2f));
			AddColumn("Quantity", (int)(radGridView1.Width * 0.2f));
			AddColumn("Specification", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}

		#endregion

		protected override List<CustomCell> GetListViewSubItems(IBaseEntityObject item)
		{
			var subItems = new List<CustomCell>();
			if (item is RequestForQuotationRecord)
			{
				var record = item as RequestForQuotationRecord;
				var author = GlobalObjects.CasEnvironment.GetCorrector(record);

				subItems.Add(CreateRow(record.Product?.PartNumber, record.Product?.PartNumber));
				subItems.Add(CreateRow(record.Suppliers?.ToString(), record.Suppliers?.ToString()));
				subItems.Add(CreateRow(record.Product?.Name, record.Product?.Name));
				subItems.Add(CreateRow(record.Measure.ToString(), record.Measure.ToString()));
				subItems.Add(CreateRow(record.Quantity.ToString(), record.Quantity.ToString()));
				subItems.Add(CreateRow(record.Product?.Standart?.ToString(), record.Product?.Standart?.ToString()));
				subItems.Add(CreateRow(author, author));
			}
			else
			{
				var record = item as SupplierPrice;
				subItems.Add(CreateRow("",""));
				subItems.Add(CreateRow(record.Supplier.ToString(), record.Supplier));
				subItems.Add(CreateRow($"New:{record.CostNew} {record.СurrencyNew}".ToString(), record.CostNew));
				subItems.Add(CreateRow($"OH:{record.CostOverhaul} {record.СurrencyOH}".ToString(), record.CostOverhaul));
				subItems.Add(CreateRow($"Serv:{record.CostServiceable} {record.СurrencyServ}".ToString(), record.CostServiceable));
				subItems.Add(CreateRow("", ""));
				subItems.Add(CreateRow($"Rep:{record.CostRepair} {record.СurrencyRepair}", record.CostRepair));
			}

			return subItems;
		}

		#region protected override void SetItemColor(ListViewItem listViewItem, BaseSmartCoreObject item)
		protected override void SetItemColor(GridViewRowInfo listViewItem, IBaseEntityObject item)
		{
			if (item is SupplierPrice)
			{
				foreach (GridViewCellInfo cell in listViewItem.Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.ForeColor = Color.Gray;
					cell.Style.BackColor = UsefulMethods.GetColor(item);
				}
			}
			if (item is RequestForQuotationRecord)
			{
				foreach (GridViewCellInfo cell in listViewItem.Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.ForeColor = Color.Black;
					cell.Style.BackColor = UsefulMethods.GetColor(item);
				}
			}
		}
		#endregion

		#region Overrides of BaseGridViewControl<BaseCoreObject>

		protected override void Sorting(string colName = null)
		{
			
		}

		#endregion
	}
}
