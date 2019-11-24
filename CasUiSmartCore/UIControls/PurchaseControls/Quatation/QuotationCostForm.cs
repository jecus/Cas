using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class QuotationCostForm : MetroForm
	{
		#region Fields

		private readonly List<Supplier> _suppliers;
		private readonly List<RequestForQuotationRecord> _selectedItems;
		private List<SupplierPrice> _prices = new List<SupplierPrice>();
		private RequestForQuotationRecord _selectedItem;

		#endregion

		#region Constructor

		public QuotationCostForm()
		{
			InitializeComponent();
		}

		public QuotationCostForm(List<Supplier> suppliers, List<RequestForQuotationRecord> selectedItems) : this()
		{
			UpdateControls();

			_suppliers = suppliers;
			_selectedItems = selectedItems;


			foreach (var item in selectedItems)
			foreach (var price in item.SupplierPrice)
			{
				price.Supplier = _suppliers.FirstOrDefault(i => i.ItemId == price.SupplierId);
				_prices.Add(price);
			}


			supplierListView1.SetItemsArray(_prices.ToArray());
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

		private void SupplierListView1_SelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)
		{
			if (supplierListView1.SelectedItem == null) return;

			numericUpDownCostNew.Value = supplierListView1.SelectedItem.CostNew;
			numericUpDownCostOH.Value = supplierListView1.SelectedItem.CostOverhaul;
			numericUpDownCostRepair.Value = supplierListView1.SelectedItem.CostRepair;
			numericUpDownCostServ.Value = supplierListView1.SelectedItem.CostServiceable;

			numericUpDownExNew.Value = supplierListView1.SelectedItem.CostNewEx;
			numericUpDownExOH.Value = supplierListView1.SelectedItem.CostOverhaulEx;
			numericUpDownExRepair.Value = supplierListView1.SelectedItem.CostRepairEx;
			numericUpDownExServ.Value = supplierListView1.SelectedItem.CostServiceableEx;

			numericUpDownReadinessNew.Value = supplierListView1.SelectedItem.CostNewReadiness;
			numericUpDownReadinessOH.Value = supplierListView1.SelectedItem.CostOverhaulReadiness;
			numericUpDownReadinessRepair.Value = supplierListView1.SelectedItem.CostRepairReadiness;
			numericUpDownReadinessServ.Value = supplierListView1.SelectedItem.CostServiceableReadiness;

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

			supplierListView1.SelectedItem.CostNewEx = numericUpDownExNew.Value;
			supplierListView1.SelectedItem.CostOverhaulEx = numericUpDownExOH.Value;
			supplierListView1.SelectedItem.CostRepairEx = numericUpDownExRepair.Value;
			supplierListView1.SelectedItem.CostServiceableEx = numericUpDownExServ.Value;

			supplierListView1.SelectedItem.CostNewReadiness = numericUpDownReadinessNew.Value;
			supplierListView1.SelectedItem.CostOverhaulReadiness = numericUpDownReadinessOH.Value;
			supplierListView1.SelectedItem.CostRepairReadiness = numericUpDownReadinessRepair.Value;
			supplierListView1.SelectedItem.CostServiceableReadiness = numericUpDownReadinessServ.Value;

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

			numericUpDownExNew.Value = 0;
			numericUpDownExOH.Value = 0;
			numericUpDownExRepair.Value = 0;
			numericUpDownExServ.Value = 0;

			numericUpDownReadinessNew.Value = 0;
			numericUpDownReadinessOH.Value = 0;
			numericUpDownReadinessRepair.Value = 0;
			numericUpDownReadinessServ.Value = 0;

			comboBoxCostNew.SelectedItem = Сurrency.USD;
			comboBoxCostOH.SelectedItem = Сurrency.USD;
			comboBoxCostRepair.SelectedItem = Сurrency.USD;
			comboBoxCostServ.SelectedItem = Сurrency.USD;
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

			//if (_selectedItem != null)
			//{
			//	_selectedItem.SupplierPrice.Clear();
			//	_selectedItem.SupplierPrice.AddRange(_prices);
			//}
			//else
			//{
			//	foreach (var record in _selectedItems)
			//	{
			//		record.SupplierPrice.Clear();
			//		record.SupplierPrice.AddRange(_prices);
			//	}
			//}

			
		}
	}
}
