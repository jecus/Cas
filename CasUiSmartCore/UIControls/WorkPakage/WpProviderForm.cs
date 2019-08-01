using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CASTerms;
using EntityCore.DTO.General;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.WorkPakage
{
	public partial class WpProviderForm : MetroForm
	{
		#region Fields

		private readonly List<Supplier> _suppliers = new List<Supplier>();
		private List<ProviderPrice> _prices = new List<ProviderPrice>();
		private WorkPackage _selectedItem;

		#endregion

		#region Constructor

		public WpProviderForm()
		{
			InitializeComponent();
		}

		public WpProviderForm(WorkPackage selectedItem) : this()
		{
			_selectedItem = selectedItem;

			foreach (var price in selectedItem.ProviderPrice)
				price.Supplier = _suppliers.FirstOrDefault(i => i.ItemId == price.SupplierId);

			_prices.AddRange(selectedItem.ProviderPrice);
			if (_prices.Count > 0)
				supplierListView1.SetItemsArray(_prices.ToArray());
			

			Task.Run(() => DoWork())
				.ContinueWith(task => Completed(), TaskScheduler.FromCurrentSynchronizationContext());

			
		}

		#endregion

		private void Completed()
		{
			supplierListView.SetItemsArray(_suppliers.ToArray());
			supplierListView1.SetItemsArray(_prices.ToArray());
			UpdateControls();
		}

		private void DoWork()
		{
			_suppliers.Clear();
			_suppliers.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<SupplierDTO, Supplier>(loadChild: true));

			foreach (var providerPrice in _prices)
			{
				providerPrice.Supplier = _suppliers.FirstOrDefault(i => i.ItemId == providerPrice.SupplierId);
				providerPrice.Parent = _selectedItem;
			}
		}

		public void UpdateControls()
		{
			comboBoxOffering.Items.Clear();
			comboBoxOffering.Items.AddRange(Сurrency.Items.ToArray());
		}

		private void ButtonAdd_Click(object sender, System.EventArgs e)
		{
			foreach (var supplier in supplierListView.SelectedItems.ToArray())
				_prices.Add(new ProviderPrice { Supplier = supplier, SupplierId = supplier.ItemId, Parent = _selectedItem });

			supplierListView1.SetItemsArray(_prices.ToArray());
		}

		private void ButtonDelete_Click(object sender, System.EventArgs e)
		{
			if (supplierListView1.SelectedItems.Count == 0) return;

			foreach (var item in supplierListView1.SelectedItems.ToArray())
				_prices.Remove(item);

			supplierListView1.SetItemsArray(_prices.ToArray());
		}

		private void SupplierListView1_SelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)
		{
			if (supplierListView1.SelectedItem == null) return;

			comboBoxOffering.SelectedItem = supplierListView1.SelectedItem.CurrencyOffering;
			numericUpDownAD.Value = supplierListView1.SelectedItem.AD;
			numericUpDownADKMH.Value = supplierListView1.SelectedItem.ADKMH;
			numericUpDownNDT.Value = supplierListView1.SelectedItem.NDT;
			numericUpDownNDTKMH.Value = supplierListView1.SelectedItem.NDTKMH;
			numericUpDownNRC.Value = supplierListView1.SelectedItem.NRC;
			numericUpDownNRCKMH.Value = supplierListView1.SelectedItem.NRCKMH;
			numericUpDownOffering.Value = supplierListView1.SelectedItem.Offering;
			numericUpDownRoutine.Value = supplierListView1.SelectedItem.Routine;
			numericUpDownRoutineKMH.Value = supplierListView1.SelectedItem.RoutineKMH;

		}

		private void Reset()
		{
			comboBoxOffering.SelectedItem = Сurrency.UNK;
			numericUpDownAD.Value = 0;
			numericUpDownADKMH.Value = 0;
			numericUpDownNDT.Value = 0;
			numericUpDownNDTKMH.Value = 0;
			numericUpDownNRC.Value = 0;
			numericUpDownNRCKMH.Value = 0;
			numericUpDownOffering.Value = 0;
			numericUpDownRoutine.Value = 0;
			numericUpDownRoutineKMH.Value = 0;
		}

		private void ButtonCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void ButtonOk_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			if (supplierListView1.ItemsCount <= 0)
			{
				MessageBox.Show("Please select a suppliers for  order", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				return;
			}


			_selectedItem.ProviderPrice.Clear();
			_selectedItem.ProviderPrice.AddRange(_prices);
		}

		private void textBoxSearchPartNumber_TextChanged(object sender, System.EventArgs e)
		{
			supplierListView.SetItemsArray(_suppliers.Where(i => i.Name.ToLower().Contains(textBoxSearchName.Text.ToLower())).ToArray());
		}

		private void Button1_Click_1(object sender, System.EventArgs e)
		{
			if (supplierListView1.SelectedItem == null) return;

			supplierListView1.SelectedItem.CurrencyOffering = (Сurrency)comboBoxOffering.SelectedItem;
			supplierListView1.SelectedItem.AD = numericUpDownAD.Value;
			supplierListView1.SelectedItem.ADKMH = numericUpDownADKMH.Value;
			supplierListView1.SelectedItem.NDT = numericUpDownNDT.Value;
			supplierListView1.SelectedItem.NDTKMH = numericUpDownNDTKMH.Value;
			supplierListView1.SelectedItem.NRC = numericUpDownNRC.Value;
			supplierListView1.SelectedItem.NRCKMH = numericUpDownNRCKMH.Value;
			supplierListView1.SelectedItem.Offering = numericUpDownOffering.Value;
			supplierListView1.SelectedItem.Routine = numericUpDownRoutine.Value;
			supplierListView1.SelectedItem.RoutineKMH = numericUpDownRoutineKMH.Value;

			supplierListView1.SetItemsArray(_prices.ToArray());

			Reset();
		}
	}
}

