using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Initial
{
	public partial class InitialOrderFormListView :  BaseGridViewControl<InitialOrderRecord>
	{
		public InitialOrderFormListView()
		{
			InitializeComponent();
			DisableContectMenu();
		}

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			AddColumn("P/N", (int)(radGridView1.Width * 0.2f));
			AddColumn("Specification", (int)(radGridView1.Width * 0.2f));
			AddColumn("Name", (int)(radGridView1.Width * 0.2f));
			AddColumn("Class", (int)(radGridView1.Width * 0.2f));
			AddColumn("Measure", (int)(radGridView1.Width * 0.2f));
			AddColumn("Quantity", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}

		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(InitialOrderRecord item)

		protected override List<CustomCell> GetListViewSubItems(InitialOrderRecord item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			return new List<CustomCell>()
			{
				CreateRow(item.Product?.PartNumber, item.Product?.PartNumber),
				CreateRow( item.Product?.Standart?.ToString(),  item.Product?.Standart?.ToString()),
				CreateRow( item.Product?.Name,  item.Product?.Name),
				CreateRow( item.Product?.GoodsClass?.ShortName ?? "Another accessory",  item.Product?.GoodsClass),
				CreateRow( item.Measure.ToString(),  item.Measure.ToString()),
				CreateRow( item.Quantity.ToString(),  item.Quantity.ToString()),
				CreateRow( author,  author),
			};
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

		#region Overrides of BaseGridViewControl<InitialOrderRecord>

		protected override void GroupingItems()
		{
			Grouping("Class");
		}

		#endregion

	}
}
