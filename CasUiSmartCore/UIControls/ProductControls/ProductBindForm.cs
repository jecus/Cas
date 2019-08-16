using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAS.UI.UIControls.PurchaseControls;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Queries;

namespace CAS.UI.UIControls.ProductControls
{
	public partial class ProductBindForm : MetroForm
	{
		private readonly AbstractAccessory _currentKit;

		#region Fields

		private readonly Component _current;
		private List<Product> _result = new List<Product>();

		#endregion

		#region Constructor

		public ProductBindForm()
		{
			InitializeComponent();
		}

		public ProductBindForm(Component current) :this()
		{
			_current = current;
		}

		public ProductBindForm(AbstractAccessory currentKit) : this()
		{
			_currentKit = currentKit;
		}

		#endregion

		#region private void Button1_Click(object sender, System.EventArgs e)

		private void Button1_Click(object sender, EventArgs e)
		{
			metroProgressSpinner1.Visible = true;
			Task.Run(() => DoWork())
				.ContinueWith(task => Complete(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion

		#region private void DoWork()

		private void DoWork()
		{
			_result.Clear();
			var res = BaseQueries.GetSelectQueryWithWhere<Product>(loadChild:true) + $" AND ( AccessoryDescriptions.Model like '%{textBoxPartNumber.Text}%' OR " +
			          $"AccessoryDescriptions.PartNumber like '%{textBoxPartNumber.Text}%' OR " +
			          $"AccessoryDescriptions.Description like '%{textBoxPartNumber.Text}%' OR " +
			          $"AccessoryDescriptions.AltPartNumber like '%{textBoxPartNumber.Text}%' OR " +
			          $"AccessoryDescriptions.Reference like '%{textBoxPartNumber.Text}%')";

			var ds = GlobalObjects.CasEnvironment.Execute(res);
			_result.AddRange(BaseQueries.GetObjectList<Product>(ds.Tables[0], true));

			//_result.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, Product>(new Filter[]
			//{
			//	new Filter("PartNumber",FilterType.Contains, textBoxPartNumber.Text),
			//	new Filter("ModelingObjectTypeId", -1)
			//}));
		}

		#endregion

		#region private void Complete()

		private void Complete()
		{
			allProductListView1.SetItemsArray(_result.ToArray());
			allProductListView1.Focus();
			metroProgressSpinner1.Visible = false;
		}

		#endregion

		#region private void ButtonCancel_Click(object sender, EventArgs e)

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion

		#region private void ButtonOk_Click(object sender, EventArgs e)

		private void ButtonOk_Click(object sender, EventArgs e)
		{
			if (allProductListView1.SelectedItem != null)
			{
				if (_current != null)
					_current.Product = allProductListView1.SelectedItem;
				else _currentKit.Product = allProductListView1.SelectedItem;
			}
			else
			{
				MessageBox.Show("Please select one product!", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		#endregion

		#region private void Button2_Click(object sender, EventArgs e)

		private void Button2_Click(object sender, EventArgs e)
		{
			var form = new ProductForm(new Product());
			if (form.ShowDialog() == DialogResult.OK)
			{
				if (textBoxPartNumber.Text != "")
				{
					metroProgressSpinner1.Visible = true;
					Task.Run(() => DoWork())
						.ContinueWith(task => Complete(), TaskScheduler.FromCurrentSynchronizationContext());
				}
			}

		}

		#endregion
	}
}
