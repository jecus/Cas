using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CASTerms;
using EntityCore.DTO.General;
using MetroFramework.Forms;
using SmartCore.Entities.General.Setting;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class QuotationSupplierForAllForm : MetroForm
	{
		#region Fields

		private List<Supplier> _suppliers;
		private List<SupplierPrice> _prices = new List<SupplierPrice>();
		private Settings _settings;

		#endregion

		#region Constructor

		public QuotationSupplierForAllForm()
		{
			InitializeComponent();
			Task.Run(() => DoWork())
				.ContinueWith(task => Completed(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion

		private void Completed()
		{
			UpdateControls();

			supplierListView.SetItemsArray(_suppliers.ToArray());
		}

		private void DoWork()
		{
			var suppliers = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SupplierDTO, Supplier>();
			_suppliers = new List<Supplier>(suppliers);

			_settings = GlobalObjects.CasEnvironment.NewLoader.GetObject<SettingDTO, Settings>();
			if(_settings == null)
				_settings=new Settings();
		}

		private void UpdateControls()
		{
			comboBox1.Items.Clear();
			comboBox1.Items.AddRange(_settings.GlobalSetting.QuotationSupplierSetting.Parameters.Select(i => i.Key).ToArray());
			comboBox1.SelectedItem = null;
			comboBox1.Text = "";
		}

		private void ButtonAdd_Click(object sender, System.EventArgs e)
		{
			bool showMsg = false;
			foreach (var supplier in supplierListView.SelectedItems.ToArray())
			{
				if (_prices.FirstOrDefault(i => i.SupplierId == supplier.ItemId) == null)

					_prices.Add(new SupplierPrice
						{Supplier = supplier, SupplierId = supplier.ItemId});

				else
					showMsg = true;

			}

			if(showMsg)
				MessageBox.Show($"Supplier alredy added!", (string)new GlobalTermsProvider()["SystemName"],
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation);

			supplierListView1.SetItemsArray(_prices.Select(i => i.Supplier).ToArray());
		}

		private void ButtonDelete_Click(object sender, System.EventArgs e)
		{
			if (supplierListView1.SelectedItems.Count == 0) return;

			foreach (var item in supplierListView1.SelectedItems.ToArray())
				_prices.RemoveAll(i => i.SupplierId == item.ItemId);

			supplierListView1.SetItemsArray(_prices.Select(i => i.Supplier).ToArray());
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if (supplierListView1.ItemsCount == 0)
			{
				MessageBox.Show("Please select a suppliers!", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				return;
			}

			var res = _settings.GlobalSetting.QuotationSupplierSetting.Parameters[textBox1.Text];
			res.Clear();
			res.AddRange(_prices.Select(i => i.SupplierId).ToList());
			
			UpdateControls();
			textBox1.Text = "";
			supplierListView1.radGridView1.Rows.Clear();
		}


		private void ButtonCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void ButtonOk_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			GlobalObjects.CasEnvironment.NewKeeper.Save(_settings);
			
		}

		private void textBoxSearchPartNumber_TextChanged(object sender, System.EventArgs e)
		{
			supplierListView.SetItemsArray(_suppliers.Where(i => i.Name.ToLower().Contains(textBoxSearchName.Text.ToLower())).ToArray());
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(comboBox1.SelectedItem == null)
				return;

			textBox1.Text = comboBox1.SelectedItem.ToString();
			supplierListView1.radGridView1.Rows.Clear();

			var ids = _settings.GlobalSetting.QuotationSupplierSetting.Parameters[comboBox1.SelectedItem.ToString()];
			var price = _suppliers
				.Where(i => ids.Contains(i.ItemId))
				.Select(supplier => new SupplierPrice {SupplierId = supplier.ItemId, Supplier = supplier})
				.ToArray();
			_prices.Clear();
			_prices.AddRange(price);
			supplierListView1.SetItemsArray(_prices.Select(i => i.Supplier).ToArray());
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if (comboBox1.SelectedItem == null)
				return;

			_settings.GlobalSetting.QuotationSupplierSetting.Parameters.Remove(comboBox1.SelectedItem.ToString());
			UpdateControls();
			supplierListView1.radGridView1.Rows.Clear();

		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox1.Text))
			{
				MessageBox.Show("Please input setting name!", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				return;
			}

			if (_settings.GlobalSetting.QuotationSupplierSetting.Parameters.ContainsKey(textBox1.Text))
			{
				MessageBox.Show($"Setting with Name:{textBox1.Text} alredy exist!", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				return;
			}

			_settings.GlobalSetting.QuotationSupplierSetting.Parameters.Add(textBox1.Text, new List<int>());
			UpdateControls();
			comboBox1.SelectedItem = textBox1.Text;
			
		}
	}
}
