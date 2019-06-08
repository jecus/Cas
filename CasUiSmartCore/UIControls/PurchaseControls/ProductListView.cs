using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.PurchaseControls
{
	public partial class ProductListView : BaseListViewControl<Product>
	{
		#region public ProductListView()

		public ProductListView()
		{
			InitializeComponent();
		}

		#endregion

		#region Overrides of BaseListViewControl<Product>

		protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (SelectedItem != null)
			{
				var dp = ScreenAndFormManager.GetEditForm(SelectedItem);
				if (dp.ShowDialog() == DialogResult.OK)
				{
					if (dp is ProductForm)
					{
						var changedJob = ((ProductForm) dp).CurrentProdcuct;
						itemsListView.SelectedItems[0].Tag = changedJob;

						var subs = GetListViewSubItems(SelectedItem);
						for (int i = 0; i < subs.Length; i++)
							itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
					}
				}

			}
		}


		#endregion

		}
	}

