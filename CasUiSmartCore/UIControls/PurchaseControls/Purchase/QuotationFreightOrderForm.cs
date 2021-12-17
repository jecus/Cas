using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAS.Entity.Models.DTO.General;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Setting;
using SmartCore.Filters;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Purchase
{
	public partial class QuotationFreightOrderForm : MetroForm
	{
		#region Fields

		private List<PurchaseShipper> _addedRecord = new List<PurchaseShipper>();

		private PurchaseOrder _order;
		private List<Supplier> _supplierShipper = new List<Supplier>();
		private Settings _setting;

		#endregion

		#region Constructor

		public QuotationFreightOrderForm()
		{
			InitializeComponent();
		}

		public QuotationFreightOrderForm(PurchaseOrder order):this()
		{
			_order = order;
			
			Task.Run(() => DoWork())
				.ContinueWith(task => Completed(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion

		#region private void Completed()

		private void Completed()
		{
			UpdateControls();
			supplierListView.SetItemsArray(_supplierShipper.ToArray());
			purchaseRecordListView1.SetItemsArray(_addedRecord.ToArray());
		}

		#endregion

		#region private void DoWork()

		private void DoWork()
		{
			_addedRecord.Clear();
			_supplierShipper.Clear();
			_supplierShipper.AddRange(GlobalObjects.CasEnvironment.Loader.GetObjectList<Supplier>(new ICommonFilter[] { new CommonFilter<int>(Supplier.SupplierClassProperty, SupplierClass.Shipper.ItemId) }));
			_order.ShipCompany = _supplierShipper.FirstOrDefault(i => i.ItemId == _order.ShipCompanyId) ?? Supplier.Unknown;

			_setting = GlobalObjects.CasEnvironment.NewLoader.GetObject<SettingDTO, Settings>();

			if (_setting == null)
				_setting = new Settings();

			foreach (var record in _order.AdditionalInformation.PurchaseShippers)
			{
				record.Shipper = _supplierShipper.FirstOrDefault(i => i.ItemId == record.ShipperId) ?? Supplier.Unknown;
				record.Currency = Сurrency.GetItemById(record.CurrencyId);
				record.PONumber = _order.Number;
			}

			_addedRecord.AddRange(_order.AdditionalInformation.PurchaseShippers);
		}

		#endregion

		#region private void UpdateControls()

		private void UpdateControls()
		{
			comboBox1.Items.Clear();
			comboBox1.Items.AddRange(_setting.GlobalSetting.QuotationSupplierSetting.Parameters.Select(i => i.Key).ToArray());

			comboBoxStatus.Items.Clear();
			comboBoxStatus.DataSource = Enum.GetValues(typeof(WorkPackageStatus));
			comboBoxStatus.SelectedItem = _order.Status;

			if (_order.ItemId > 0)
			{
				textBoxTitle.Text = _order.Title;
				metroTextBoxNumber.Text = _order.Number;
				dateTimePickerOpeningDate.Value = _order.OpeningDate;
				textBoxAuthor.Text = _order.Author;
				textBoxRemarks.Text = _order.Remarks;
			}

			comboBoxCurrency.Items.Clear();
			comboBoxCurrency.Items.AddRange(Сurrency.Items.ToArray());
		}

		#endregion

		#region private void ButtonCancel_Click(object sender, EventArgs e)

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#region private void PurchaseRecordListView1_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void PurchaseRecordListView1_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			button1.Enabled = purchaseRecordListView1.SelectedItem != null;
			if (purchaseRecordListView1.SelectedItem == null) return;

			comboBoxCurrency.SelectedItem = purchaseRecordListView1.SelectedItem.Currency;
			numericUpDownCost.Value = (decimal) purchaseRecordListView1.SelectedItem.Cost;
			metroTextBox1.Text = purchaseRecordListView1.SelectedItem.Remark;
		}
		#endregion

		#region private void ButtonOk_Click(object sender, EventArgs e)

		private void ButtonOk_Click(object sender, EventArgs e)
		{
			if (purchaseRecordListView1.ItemsCount <= 0)
			{
				MessageBox.Show("Please select a price for purchase order", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}
			else
			{
				_order.AdditionalInformation.PurchaseShippers.Clear();
				_order.AdditionalInformation.PurchaseShippers.AddRange(_addedRecord);
				GlobalObjects.NewKeeper.Save(_order);
				DialogResult = DialogResult.OK;
			}
		}

		#endregion

		#region private void ButtonAdd_Click(object sender, EventArgs e)

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			foreach (var supplier in supplierListView.SelectedItems.ToArray())
			{
				var record = new PurchaseShipper
				{
					PONumber = _order.Number,
					Currency = Сurrency.USD,
					CurrencyId = Сurrency.USD.ItemId,
					CorrectorId = GlobalObjects.CasEnvironment.IdentityUser.ItemId,
					Shipper = supplier,
					ShipperId = supplier.ItemId,
				};
				_addedRecord.Add(record);
			}

			purchaseRecordListView1.SetItemsArray(_addedRecord.ToArray());
		}

		#endregion

		#region private void ButtonDelete_Click(object sender, EventArgs e)

		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			if (purchaseRecordListView1.SelectedItems.Count == 0) return;

			foreach (var item in purchaseRecordListView1.SelectedItems.ToArray())
			{
				_order.AdditionalInformation.PurchaseShippers.Remove(item);
				_addedRecord.Remove(item);
			}

			purchaseRecordListView1.SetItemsArray(_addedRecord.ToArray());
		}


		#endregion

		#region private void button1_Click(object sender, EventArgs e)

		private void button1_Click(object sender, EventArgs e)
		{
			purchaseRecordListView1.SelectedItem.Currency = (Сurrency) comboBoxCurrency.SelectedItem;
			purchaseRecordListView1.SelectedItem.Cost = (double) numericUpDownCost.Value;
			purchaseRecordListView1.SelectedItem.Remark = metroTextBox1.Text;

			purchaseRecordListView1.SetItemsArray(_addedRecord.ToArray());
		}

		#endregion

		private void buttonAddSupplierForAll_Click(object sender, EventArgs e)
		{
			if (comboBox1.SelectedItem == null)
				return;

			var ids = _setting.GlobalSetting.QuotationSupplierSetting.Parameters[comboBox1.SelectedItem.ToString()];
			var shippers = _supplierShipper.Where(i => ids.Contains(i.ItemId));

			foreach (var shipper in shippers)
			{
				if(_addedRecord.Any(i => i.ShipperId == shipper.ItemId))
					continue;

				var record = new PurchaseShipper
				{
					PONumber = _order.Number,
					Currency = Сurrency.USD,
					CurrencyId = Сurrency.USD.ItemId,
					CorrectorId = GlobalObjects.CasEnvironment.IdentityUser.ItemId,
					Shipper = shipper,
					ShipperId = shipper.ItemId,
				};
				_addedRecord.Add(record);
			}

			purchaseRecordListView1.SetItemsArray(_addedRecord.ToArray());
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if(purchaseRecordListView1.SelectedItem == null)
				return;
			var dialog = MessageBox.Show($"Do you really want apply shipper({purchaseRecordListView1.SelectedItem.Shipper}) for purchase order({_order.Title})?", (string)new GlobalTermsProvider()["SystemName"],
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);
			
		
			if(dialog == DialogResult.No)
				return;

			_order.AdditionalInformation.FreightPrice = purchaseRecordListView1.SelectedItem.Cost;
			_order.AdditionalInformation.СurrencyFreight = purchaseRecordListView1.SelectedItem.Currency;
			_order.AdditionalInformation.СurrencyFreightId = purchaseRecordListView1.SelectedItem.CurrencyId;
			_order.ShipCompanyId = purchaseRecordListView1.SelectedItem.ShipperId;
			_order.ShipCompany = purchaseRecordListView1.SelectedItem.Shipper;
			GlobalObjects.NewKeeper.Save(_order);
		}
	}
}
