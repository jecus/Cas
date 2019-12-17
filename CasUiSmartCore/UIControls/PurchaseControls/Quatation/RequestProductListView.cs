using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
			DisableContectMenu();
			OldColumnIndex = 2;
			SortMultiplier = 1;
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			AddColumn("P/N", (int)(radGridView1.Width * 0.2f));
			AddColumn("Specification", (int)(radGridView1.Width * 0.2f));
			AddColumn("Name", (int)(radGridView1.Width * 0.3f));
			AddColumn("Class", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Product item)

		protected override List<CustomCell> GetListViewSubItems(Product item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			return new List<CustomCell>()
			{
				CreateRow(item.PartNumber, item.PartNumber),
				CreateRow(item.Standart?.ToString(), item.Standart),
				CreateRow(item.Name, item.Name),
				CreateRow( item?.GoodsClass?.ShortName ?? "Another accessory",  item?.GoodsClass),
				CreateRow(author, author),
			};
		}

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem != null)
			{
				var editForm = new ProductForm(SelectedItem);
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
