using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Purchase
{
	public partial class PurchaseRecordListView : BaseGridViewControl<PurchaseRequestRecord>
	{
		private readonly bool _orderBySupplies;

		#region Constructor

		public PurchaseRecordListView(bool orderBySupplies = false)
		{
			_orderBySupplies = orderBySupplies;
			InitializeComponent();
			DisableContectMenu();
			OldColumnIndex = 2;
			SortDirection = SortDirection.Desc;
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			AddColumn("Supplier", (int)(radGridView1.Width * 0.2f));
			AddColumn("Q-ty", (int)(radGridView1.Width * 0.1f));
			AddColumn("Unit Cost", (int)(radGridView1.Width * 0.16f));
			AddColumn("Item Cost", (int)(radGridView1.Width * 0.16f));
			AddColumn("Total Cost", (int)(radGridView1.Width * 0.16f));
			AddColumn("Condition", (int)(radGridView1.Width * 0.14f));
			AddColumn("Type", (int)(radGridView1.Width * 0.16f));
			AddColumn("Product", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.1f));
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Product item)

		protected override List<CustomCell> GetListViewSubItems(PurchaseRequestRecord item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var destiantion = "";
			if (item?.ParentInitialRecord?.DestinationObjectType == SmartCoreType.Aircraft)
				destiantion = GlobalObjects.AircraftsCore.GetAircraftById(item?.ParentInitialRecord?.DestinationObjectId ?? -1)?.ToString();
			else destiantion = GlobalObjects.StoreCore.GetStoreById(item?.ParentInitialRecord?.DestinationObjectId ?? -1)?.ToString();
			var temp = $"P/N: {item?.Product?.PartNumber}";
			if (item?.ParentInitialRecord != null)
				temp += $"| {item.Product?.Standart} | Name: {item?.Product?.Name} | {destiantion} | {item?.ParentInitialRecord?.Priority} | Requested By: {((InitialOrder)item?.ParentInitialRecord?.ParentPackage)?.Author}";

			return new List<CustomCell>()
			{
				CreateRow(item.Supplier.ToString(),item.Supplier),
				CreateRow($"{item.Quantity.ToString()} {item.Measure}",item.Quantity),
				CreateRow($"{item.Cost} {item.Currency}",item.Cost),
				CreateRow($"{item.ItemCost:0.##} {item.Currency}", item.ItemCost),
				CreateRow($"{item.TotalCost:0.##} {item.Currency}", item.TotalCost),
				CreateRow(item.CostCondition.ToString(),item.CostCondition),
				CreateRow(item.Exchange.ToString(),item.Exchange),
				CreateRow(temp,temp),
				CreateRow(author,author),
			};
		}

		#endregion

		#region Overrides of BaseGridViewControl<InitialOrderRecord>

		protected override void GroupingItems()
		{
			Grouping("Product");
		}

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem != null)
			{
				var editForm = new ProductForm(SelectedItem.Product);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					var subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Count; i++)
						radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
				}
			}
		}
		#endregion
	}
}
