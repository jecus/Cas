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

			comboBoxCostType.Items.Clear();
			comboBoxCostType.Items.AddRange(QuotationCostType.Items.ToArray());
			comboBoxCostType.SelectedItem = QuotationCostType.New;

			comboBoxCostType.Enabled = numericUpDownCostNew.Enabled = numericUpDownExNew.Enabled =
				numericUpDownReadinessNew.Enabled = comboBoxCostNew.Enabled = supplierListView1.SelectedItem != null;
		}

		private void SupplierListView1_SelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)
		{
			comboBoxCostType.Enabled = numericUpDownCostNew.Enabled = numericUpDownExNew.Enabled =
				numericUpDownReadinessNew.Enabled = comboBoxCostNew.Enabled = supplierListView1.SelectedItem != null;
			if (supplierListView1.SelectedItem == null) return;
			comboBoxCostType.SelectedItem = null;
			comboBoxCostType.SelectedItem = QuotationCostType.New;
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if (supplierListView1.SelectedItem == null) return;

			var type = comboBoxCostType.SelectedItem as QuotationCostType;

			if (type == QuotationCostType.New)
			{
				supplierListView1.SelectedItem.CostNew = numericUpDownCostNew.Value;
				supplierListView1.SelectedItem.CostNewEx = numericUpDownExNew.Value;
				supplierListView1.SelectedItem.CostNewReadiness = numericUpDownReadinessNew.Value;
				supplierListView1.SelectedItem.СurrencyNew = (Сurrency)comboBoxCostNew.SelectedItem;
			}
			else if (type == QuotationCostType.OH)
			{
				supplierListView1.SelectedItem.CostOverhaul = numericUpDownCostNew.Value;
				supplierListView1.SelectedItem.CostOverhaulEx = numericUpDownExNew.Value;
				supplierListView1.SelectedItem.CostOverhaulReadiness = numericUpDownReadinessNew.Value;
				supplierListView1.SelectedItem.СurrencyOH = (Сurrency)comboBoxCostNew.SelectedItem;
			}
			else if (type == QuotationCostType.Repair)
			{
				supplierListView1.SelectedItem.CostRepair = numericUpDownCostNew.Value;
				supplierListView1.SelectedItem.CostRepairEx = numericUpDownExNew.Value;
				supplierListView1.SelectedItem.CostRepairReadiness = numericUpDownReadinessNew.Value;
				supplierListView1.SelectedItem.СurrencyRepair = (Сurrency)comboBoxCostNew.SelectedItem;
			}
			else if (type == QuotationCostType.Serv)
			{
				supplierListView1.SelectedItem.CostServiceable = numericUpDownCostNew.Value;
				supplierListView1.SelectedItem.CostServiceableEx = numericUpDownExNew.Value;
				supplierListView1.SelectedItem.CostServiceableReadiness = numericUpDownReadinessNew.Value;
				supplierListView1.SelectedItem.СurrencyServ = (Сurrency)comboBoxCostNew.SelectedItem;
			}

			else if (type == QuotationCostType.Test)
			{
				supplierListView1.SelectedItem.CostTest = numericUpDownCostNew.Value;
				supplierListView1.SelectedItem.CostTestEx = numericUpDownExNew.Value;
				supplierListView1.SelectedItem.CostTestReadiness = numericUpDownReadinessNew.Value;
				supplierListView1.SelectedItem.СurrencyTest = (Сurrency)comboBoxCostNew.SelectedItem;
			}

			else if (type == QuotationCostType.Inspect)
			{
				supplierListView1.SelectedItem.CostInspect = numericUpDownCostNew.Value;
				supplierListView1.SelectedItem.CostInspectEx = numericUpDownExNew.Value;
				supplierListView1.SelectedItem.CostInspectReadiness = numericUpDownReadinessNew.Value;
				supplierListView1.SelectedItem.СurrencyInspect = (Сurrency)comboBoxCostNew.SelectedItem;
			}

			else if (type == QuotationCostType.Modification)
			{
				supplierListView1.SelectedItem.CostModification = numericUpDownCostNew.Value;
				supplierListView1.SelectedItem.CostModificationEx = numericUpDownExNew.Value;
				supplierListView1.SelectedItem.CostModificationReadiness = numericUpDownReadinessNew.Value;
				supplierListView1.SelectedItem.СurrencyModification = (Сurrency)comboBoxCostNew.SelectedItem;
			}

			supplierListView1.SetItemsArray(_prices.ToArray());
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

		private void comboBoxCostType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (supplierListView1.SelectedItem == null) return;
			var type = comboBoxCostType.SelectedItem as QuotationCostType;

			if (type == QuotationCostType.New)
			{
				numericUpDownCostNew.Value = supplierListView1.SelectedItem.CostNew;
				numericUpDownExNew.Value = supplierListView1.SelectedItem.CostNewEx;
				numericUpDownReadinessNew.Value = supplierListView1.SelectedItem.CostNewReadiness;
				comboBoxCostNew.SelectedItem= supplierListView1.SelectedItem.СurrencyNew;
			}
			else if (type == QuotationCostType.OH)
			{
				numericUpDownCostNew.Value = supplierListView1.SelectedItem.CostOverhaul;
				numericUpDownExNew.Value = supplierListView1.SelectedItem.CostOverhaulEx;
				numericUpDownReadinessNew.Value = supplierListView1.SelectedItem.CostOverhaulReadiness;
				comboBoxCostNew.SelectedItem = supplierListView1.SelectedItem.СurrencyOH;
			}
			else if (type == QuotationCostType.Repair)
			{
				numericUpDownCostNew.Value = supplierListView1.SelectedItem.CostRepair;
				numericUpDownExNew.Value = supplierListView1.SelectedItem.CostRepairEx;
				numericUpDownReadinessNew.Value = supplierListView1.SelectedItem.CostRepairReadiness;
				comboBoxCostNew.SelectedItem = supplierListView1.SelectedItem.СurrencyRepair;
			}
			else if (type == QuotationCostType.Serv)
			{
				numericUpDownCostNew.Value = supplierListView1.SelectedItem.CostServiceable;
				numericUpDownExNew.Value = supplierListView1.SelectedItem.CostServiceableEx;
				numericUpDownReadinessNew.Value = supplierListView1.SelectedItem.CostServiceableReadiness;
				comboBoxCostNew.SelectedItem = supplierListView1.SelectedItem.СurrencyServ;
			}

			else if (type == QuotationCostType.Test)
			{
				numericUpDownCostNew.Value = supplierListView1.SelectedItem.CostTest;
				numericUpDownExNew.Value = supplierListView1.SelectedItem.CostTestEx;
				numericUpDownReadinessNew.Value = supplierListView1.SelectedItem.CostTestReadiness;
				comboBoxCostNew.SelectedItem = supplierListView1.SelectedItem.СurrencyTest;
			}

			else if (type == QuotationCostType.Inspect)
			{
				numericUpDownCostNew.Value = supplierListView1.SelectedItem.CostInspect;
				numericUpDownExNew.Value = supplierListView1.SelectedItem.CostInspectEx;
				numericUpDownReadinessNew.Value = supplierListView1.SelectedItem.CostInspectReadiness;
				comboBoxCostNew.SelectedItem = supplierListView1.SelectedItem.СurrencyInspect;
			}

			else if (type == QuotationCostType.Modification)
			{
				numericUpDownCostNew.Value = supplierListView1.SelectedItem.CostModification;
				numericUpDownExNew.Value = supplierListView1.SelectedItem.CostModificationEx;
				numericUpDownReadinessNew.Value = supplierListView1.SelectedItem.CostModificationReadiness;
				comboBoxCostNew.SelectedItem = supplierListView1.SelectedItem.СurrencyModification;
			}
		}
	}
}
