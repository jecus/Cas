using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class QuotationSupplierForm : MetroForm
	{
		#region Fields

		private readonly List<Supplier> _suppliers;
		private readonly List<RequestForQuotationRecord> _selectedItems;
		private List<SupplierPrice> _prices = new List<SupplierPrice>();
		private RequestForQuotationRecord _selectedItem;

		#endregion

		#region Constructor

		public QuotationSupplierForm()
		{
			InitializeComponent();
		}

		public QuotationSupplierForm(List<Supplier> suppliers, List<RequestForQuotationRecord> selectedItems) : this()
		{
			_suppliers = suppliers;
			_selectedItems = selectedItems;
			supplierListView.SetItemsArray(suppliers.ToArray());

			UpdateControls();
		}

		public QuotationSupplierForm(List<Supplier> suppliers, RequestForQuotationRecord selectedItem) : this()
		{
			_suppliers = suppliers;
			_selectedItem = selectedItem;

			foreach (var price in selectedItem.SupplierPrice)
				price.Supplier = _suppliers.FirstOrDefault(i => i.ItemId == price.SupplierId);

			_prices.AddRange(selectedItem.SupplierPrice);
			if(_prices.Count > 0)
				supplierListView1.SetItemsArray(_prices.ToArray());
			supplierListView.SetItemsArray(suppliers.ToArray());

			UpdateControls();
		}

		#endregion

		public void UpdateControls()
		{
			comboBoxCostNew.Items.Clear();
			comboBoxCostNew.Items.AddRange(Сurrency.Items.ToArray());

			comboBoxCostOH.Items.Clear();
			comboBoxCostOH.Items.AddRange(Сurrency.Items.ToArray());

			comboBoxCostRepair.Items.Clear();
			comboBoxCostRepair.Items.AddRange(Сurrency.Items.ToArray());

			comboBoxCostServ.Items.Clear();
			comboBoxCostServ.Items.AddRange(Сurrency.Items.ToArray());
		}

		private void ButtonAdd_Click(object sender, System.EventArgs e)
		{
			foreach (var supplier in supplierListView.SelectedItems.ToArray())
				_prices.Add(new SupplierPrice{Supplier = supplier, SupplierId = supplier.ItemId, Parent = _selectedItem});

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

			numericUpDownCostNew.Value = supplierListView1.SelectedItem.CostNew;
			numericUpDownCostOH.Value = supplierListView1.SelectedItem.CostOverhaul;
			numericUpDownCostRepair.Value = supplierListView1.SelectedItem.CostRepair;
			numericUpDownCostServ.Value = supplierListView1.SelectedItem.CostServiceable;

			comboBoxCostNew.SelectedItem = supplierListView1.SelectedItem.СurrencyNew;
			comboBoxCostOH.SelectedItem = supplierListView1.SelectedItem.СurrencyOH;
			comboBoxCostRepair.SelectedItem = supplierListView1.SelectedItem.СurrencyRepair;
			comboBoxCostServ.SelectedItem = supplierListView1.SelectedItem.СurrencyServ;

		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if (supplierListView1.SelectedItem == null) return;

			supplierListView1.SelectedItem.CostNew = numericUpDownCostNew.Value;
			supplierListView1.SelectedItem.CostOverhaul = numericUpDownCostOH.Value;
			supplierListView1.SelectedItem.CostRepair = numericUpDownCostRepair.Value;
			supplierListView1.SelectedItem.CostServiceable = numericUpDownCostServ.Value;

			supplierListView1.SelectedItem.СurrencyNew = (Сurrency) comboBoxCostNew.SelectedItem;
			supplierListView1.SelectedItem.СurrencyOH = (Сurrency)comboBoxCostOH.SelectedItem;
			supplierListView1.SelectedItem.СurrencyRepair = (Сurrency)comboBoxCostRepair.SelectedItem;
			supplierListView1.SelectedItem.СurrencyServ = (Сurrency)comboBoxCostServ.SelectedItem;

			supplierListView1.SetItemsArray(_prices.ToArray());

			Reset();
		}

		private void Reset()
		{
			numericUpDownCostNew.Value = 0;
			numericUpDownCostOH.Value = 0;
			numericUpDownCostRepair.Value = 0;
			numericUpDownCostServ.Value = 0;
			comboBoxCostNew.SelectedItem = Сurrency.UNK;
			comboBoxCostOH.SelectedItem = Сurrency.UNK;
			comboBoxCostRepair.SelectedItem = Сurrency.UNK;
			comboBoxCostServ.SelectedItem = Сurrency.UNK;
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

			if (_selectedItem != null)
			{
				_selectedItem.SupplierPrice.Clear();
				_selectedItem.SupplierPrice.AddRange(_prices);
			}
			else
			{
				foreach (var record in _selectedItems)
				{
					record.SupplierPrice.Clear();
					record.SupplierPrice.AddRange(_prices);
				}
			}

			
		}

		private void textBoxSearchPartNumber_TextChanged(object sender, System.EventArgs e)
		{
			supplierListView.SetItemsArray(_suppliers.Where(i => i.Name.ToLower().Contains(textBoxSearchName.Text.ToLower())).ToArray());
		}
	}
}
