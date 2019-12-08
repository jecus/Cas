using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Purchase;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.PurchaseControls.Purchase
{
	public partial class QuatationFreightListView : BaseGridViewControl<IBaseEntityObject>
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
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}

		#endregion

		protected override List<CustomCell> GetListViewSubItems(IBaseEntityObject item)
		{
			var subItems = new List<CustomCell>();
			if (item is PurchaseRequestRecord record)
			{
				var author = GlobalObjects.CasEnvironment.GetCorrector(record);

				subItems.Add(CreateRow(record.ItemId.ToString(), record.Product?.PartNumber));
				subItems.Add(CreateRow(record.ItemId.ToString(), record.ItemId.ToString()));
				subItems.Add(CreateRow(record.Product?.Name, record.Product?.Name));
				subItems.Add(CreateRow(author, author));
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
