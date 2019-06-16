using System;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.NewGrid;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.PurchaseControls
{
	public partial class ProductListView : BaseGridViewControl<Product>
	{
		#region public ProductListView()

		public ProductListView()
		{
			InitializeComponent();
		}

		#endregion

		#region Overrides of BaseListViewControl<Product>

		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem != null)
			{
				var dp = ScreenAndFormManager.GetEditForm(SelectedItem);
				if (dp.ShowDialog() == DialogResult.OK)
				{
					if (dp is ProductForm)
					{
						var changedJob = ((ProductForm) dp).CurrentProdcuct;
						radGridView1.SelectedRows[0].Tag = changedJob;

						var subs = GetListViewSubItems(SelectedItem);
						for (int i = 0; i < subs.Count; i++)
							radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
					}
				}

			}
		}


		#endregion

		}
	}

