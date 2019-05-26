using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CASTerms;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;
using EFCore.Filter;
using MetroFramework.Forms;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.ProductControls
{
	public partial class ProductBindForm : MetroForm
	{

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
			_result.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, Product>(new Filter[]
			{
				new Filter("PartNumber",FilterType.Contains, textBoxPartNumber.Text)
			}));
		}

		#endregion

		#region private void Complete()

		private void Complete()
		{
			allProductListView1.SetItemsArray(_result.ToArray());
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
				_current.Product = allProductListView1.SelectedItem;
		}

		#endregion
	}
}
