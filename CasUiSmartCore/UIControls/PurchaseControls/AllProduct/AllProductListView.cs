
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.PurchaseControls
{
	public partial class AllProductListView : BaseGridViewControl<Product>
	{
		#region public ProductListView()

		public AllProductListView()
		{
			SortMultiplier = 1;
			//IgnoreAutoResize = true;
			InitializeComponent();
		}

		#endregion

		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem == null) return;

			if (SelectedItem.ProductType == ProductType.ComponentModel)
			{
				var editForm = new ModelForm(SelectedItem as ComponentModel);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					var subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Count; i++)
						radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
				}
			}
			else
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


		protected override void SetHeaders()
		{
			AddColumn("Type", (int)(radGridView1.Width * 0.20f));
			AddColumn("Name", (int)(radGridView1.Width * 0.20f));
			AddColumn("Part Number", (int)(radGridView1.Width * 0.20f));
			AddColumn("Alt Part Number", (int)(radGridView1.Width * 0.20f));
			AddColumn("Specification", (int)(radGridView1.Width * 0.20f));
			AddColumn("Description", (int)(radGridView1.Width * 0.24f));
			AddColumn("Reference", (int)(radGridView1.Width * 0.20f));
			AddColumn("Engine Ref", (int)(radGridView1.Width * 0.20f));
			AddColumn("Suppliers", (int)(radGridView1.Width * 0.24f));
			AddColumn("Code", (int)(radGridView1.Width * 0.20f));
			AddColumn("ATA", (int)(radGridView1.Width * 0.24f));
			AddColumn("Class", (int)(radGridView1.Width * 0.20f));
			AddColumn("IsForbidden", (int)(radGridView1.Width * 0.20f));
			AddColumn("IsDangerous", (int)(radGridView1.Width * 0.20f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}

		protected override List<CustomCell> GetListViewSubItems(Product item)
		{
			var subItems = new List<CustomCell>();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);

			subItems.Add(CreateRow(item.ProductType.ToString(), item.ProductType));
			subItems.Add(CreateRow(item.Name, item.Name));
			subItems.Add(CreateRow(item.PartNumber, item.PartNumber));
			subItems.Add(CreateRow(item.AltPartNumber, item.AltPartNumber));
			subItems.Add(CreateRow(item.Standart?.ToString(), item.Standart));
			subItems.Add(CreateRow(item.Description, item.Description));
			subItems.Add(CreateRow(item.Reference, item.Reference));
			subItems.Add(CreateRow(item.EngineRef, item.EngineRef));
			subItems.Add(CreateRow(item.Suppliers?.ToString(), item.Suppliers));
			subItems.Add(CreateRow(item.Code, item.Code));
			subItems.Add(CreateRow(item.ATAChapter?.ToString(), item.ATAChapter));
			subItems.Add(CreateRow(item.GoodsClass?.ToString(), item.GoodsClass));
			subItems.Add(CreateRow(item.IsForbiddenString, item.IsForbidden));
			subItems.Add(CreateRow(item.IsDangerous.ToString(), item.IsDangerous));
			subItems.Add(CreateRow(item.Remarks, item.Remarks));
			subItems.Add(CreateRow(author, author));

			return subItems;
		}

		#region Overrides of BaseGridViewControl<InitialOrderRecord>

		protected override void GroupingItems()
		{
			Grouping("Type");
		}

		#endregion

	}
}
