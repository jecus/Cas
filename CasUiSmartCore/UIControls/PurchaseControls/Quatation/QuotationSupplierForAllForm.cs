using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class QuotationSupplierForAllForm : MetroForm
	{
		#region Fields

		private readonly List<Supplier> _suppliers;
		private readonly List<RequestForQuotationRecord> _selectedItems;
		private List<SupplierPrice> _prices = new List<SupplierPrice>();
		private RequestForQuotationRecord _selectedItem;

		#endregion

		#region Constructor

		public QuotationSupplierForAllForm()
		{
			InitializeComponent();
		}

		public QuotationSupplierForAllForm(List<Supplier> suppliers, List<RequestForQuotationRecord> selectedItems) : this()
		{
			UpdateControls();

			_suppliers = suppliers;
			_selectedItems = selectedItems;
			supplierListView.SetItemsArray(suppliers.ToArray());
		}

		public QuotationSupplierForAllForm(List<Supplier> suppliers, RequestForQuotationRecord selectedItem) : this()
		{
			UpdateControls();

			_suppliers = suppliers;
			_selectedItem = selectedItem;

			foreach (var price in selectedItem.SupplierPrice)
				price.Supplier = _suppliers.FirstOrDefault(i => i.ItemId == price.SupplierId);

			_prices.AddRange(selectedItem.SupplierPrice);
			if(_prices.Count > 0)
				supplierListView1.SetItemsArray(_prices.ToArray());
			supplierListView.SetItemsArray(suppliers.ToArray());
		}

		#endregion

		public void UpdateControls()
		{
			comboBox1.Items.Clear();
			comboBox1.Items.AddRange(Сurrency.Items.ToArray());
			
		}

		private void ButtonAdd_Click(object sender, System.EventArgs e)
		{
			bool showMsg = false;
			foreach (var supplier in supplierListView.SelectedItems.ToArray())
			{
				if (_prices.FirstOrDefault(i => i.SupplierId == supplier.ItemId) == null)

					_prices.Add(new SupplierPrice
						{Supplier = supplier, SupplierId = supplier.ItemId, Parent = _selectedItem});

				else
					showMsg = true;

			}

			if(showMsg)
				MessageBox.Show($"Supplier alredy added!", (string)new GlobalTermsProvider()["SystemName"],
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation);

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
			
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Reset();
		}

		private void Reset()
		{
			
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
