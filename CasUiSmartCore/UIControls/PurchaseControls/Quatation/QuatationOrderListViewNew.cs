using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
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
			DisableContectMenu();
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
			AddColumn("Class", (int)(radGridView1.Width * 0.2f));
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
				subItems.Add(CreateRow(record.Product?.GoodsClass?.ToString() ?? "Another accessory", record.Product?.GoodsClass?.ToString()));
				subItems.Add(CreateRow(author, author));
			}
			else
			{
				var record = item as SupplierPrice;
				var order = ((RequestForQuotation) record.Parent.ParentPackage);
				var qualification = order.AdditionalInformation.QualificationNumbers.ContainsKey(record.SupplierId) ? order.AdditionalInformation.QualificationNumbers[record.SupplierId] : null;
				subItems.Add(CreateRow(string.IsNullOrEmpty(qualification) ? "" : $"             QO №:{qualification}",""));
				subItems.Add(CreateRow(record.Supplier.ToString(), record.Supplier));
				subItems.Add(CreateRow($"New:{record.CostNewString}".ToString(), record.CostNewString));
				subItems.Add(CreateRow($"OH:{record.CostOHString}".ToString(), record.CostOHString));
				subItems.Add(CreateRow($"Serv:{record.CostServString}".ToString(), record.CostServString));
				subItems.Add(CreateRow($"Rep:{record.CostRepairString}", record.CostRepairString));
				subItems.Add(CreateRow("", ""));
				subItems.Add(CreateRow("", ""));
			}

			return subItems;
		}

		#region protected override void CustomSort(int ColumnIndex)

		protected override void CustomSort(int ColumnIndex)
		{
			if (OldColumnIndex != ColumnIndex)
				SortMultiplier = -1;
			if (SortMultiplier == 1)
				SortMultiplier = -1;
			else
				SortMultiplier = 1;

			var resultList = new List<IBaseEntityObject>();
			var list = radGridView1.Rows.Where(i => i.Tag is RequestForQuotationRecord).Select(i => i).ToList();
			list.Sort(new GridViewDataRowInfoComparer(ColumnIndex, SortMultiplier));
			//добавление остальных подзадач
			foreach (GridViewRowInfo item in list)
			{
				if (item.Tag is RequestForQuotationRecord rec)
				{
					resultList.Add(rec);
					resultList.AddRange(rec.SupplierPrice);
				}

			}

			SetItemsArray(resultList.ToArray());

		}

		#endregion

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
	}
}
