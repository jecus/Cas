using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAS.UI.UIControls.PurchaseControls;
using CASTerms;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;
using EFCore.Filter;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Queries;

namespace CAS.UI.UIControls.ProductControls
{
	public partial class ModelBindForm : MetroForm
	{

		#region Fields

		private readonly Component _current;
		private List<ComponentModel> _result = new List<ComponentModel>();

		#endregion

		#region Constructor

		public ModelBindForm()
		{
			InitializeComponent();
		}

		public ModelBindForm(Component current) :this()
		{
			_current = current;
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
			var res = BaseQueries.GetSelectQueryWithWhere<ComponentModel>() + $" AND ( Model like '%{textBoxPartNumber.Text}%' OR " +
			          $"PartNumber like '%{textBoxPartNumber.Text}%' OR " +
			          $"Description like '%{textBoxPartNumber.Text}%' OR " +
			          $"AltPartNumber like '%{textBoxPartNumber.Text}%' OR " +
			          $"Reference like '%{textBoxPartNumber.Text}%')";

			var ds = GlobalObjects.CasEnvironment.Execute(res);
			_result.AddRange(BaseQueries.GetObjectList<ComponentModel>(ds.Tables[0]));

			
			//_result.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, ComponentModel>(new Filter[]
			//{
			//	new Filter("PartNumber",FilterType.Contains, textBoxPartNumber.Text),
			//	new Filter("ModelingObjectTypeId", 5)
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
				_current.Model = allProductListView1.SelectedItem;
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
			var form = new ModelForm(new ComponentModel());
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
