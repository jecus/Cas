using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class QuotationSupplierForm : MetroForm
	{
		#region Fields

		private readonly List<RequestForQuotationRecord> _selectedItems;
		private List<SupplierPrice> _prices = new List<SupplierPrice>();

		#endregion

		#region Constructor

		public QuotationSupplierForm()
		{
			InitializeComponent();
		}

		public QuotationSupplierForm(List<Supplier> suppliers, List<RequestForQuotationRecord> selectedItems) : this()
		{
			_selectedItems = selectedItems;
			supplierListView.SetItemsArray(suppliers.ToArray());
		}

		#endregion

		private void ButtonAdd_Click(object sender, System.EventArgs e)
		{
			foreach (var supplier in supplierListView.SelectedItems.ToArray())
				_prices.Add(new SupplierPrice(){Supplier = supplier});

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
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if (supplierListView1.SelectedItem == null) return;

			supplierListView1.SelectedItem.CostNew = numericUpDownCostNew.Value;
			supplierListView1.SelectedItem.CostOverhaul = numericUpDownCostOH.Value;
			supplierListView1.SelectedItem.CostRepair = numericUpDownCostRepair.Value;
			supplierListView1.SelectedItem.CostServiceable = numericUpDownCostServ.Value;

			supplierListView1.SetItemsArray(_prices.ToArray());

			Reset();
		}

		private void Reset()
		{
			numericUpDownCostNew.Value = 0;
			numericUpDownCostOH.Value = 0;
			numericUpDownCostRepair.Value = 0;
			numericUpDownCostServ.Value = 0;
		}

		private void ButtonCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void ButtonOk_Click(object sender, System.EventArgs e)
		{
			if (supplierListView1.ListViewItemList.Count <= 0)
			{
				MessageBox.Show("Please select a suppliers for  order", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				return;
			}

			foreach (var record in _selectedItems)
				record.SupplierPrice.AddRange(_prices);
		}
	}
}
