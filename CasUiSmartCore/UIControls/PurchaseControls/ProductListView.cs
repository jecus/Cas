using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.StoresControls;
using SmartCore.Entities.General;
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

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				var dp = ScreenAndFormManager.GetEditScreenOrForm(SelectedItem);
				if (dp.DisplayerType == DisplayerType.Screen)
					e.SetParameters(dp);
				else
				{
					if (dp.Form.ShowDialog() == DialogResult.OK)
					{
						if (dp.Form is ProductForm)
						{
							var changedJob = ((ProductForm)dp.Form).CurrentProdcuct;
							itemsListView.SelectedItems[0].Tag = changedJob;

							var subs = GetListViewSubItems(SelectedItem);
							for (int i = 0; i < subs.Length; i++)
								itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
						}
					}

					e.Cancel = true;
				}
			}

			#endregion
		}
	}
}
