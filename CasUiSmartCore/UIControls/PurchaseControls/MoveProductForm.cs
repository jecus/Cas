using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CASTerms;
using EntityCore.DTO.General;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Store;
using SmartCore.Filters;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
	/// <summary>
	/// Форма для установки агрегата со склада на ВС
	/// </summary>
	public partial class MoveProductForm : MetroForm
	{
		

		#region Fields

		private Store[] _stores;
		private readonly PurchaseOrder _order;
		private List<PurchaseRequestRecord> _allRecords;

		#endregion

		#region Constructors

		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public MoveProductForm()
		{
			InitializeComponent();
		}

		public MoveProductForm(PurchaseOrder order) : this()
		{
			_order = order;
			
			Task.Run(() => DoWork())
				.ContinueWith(task => Completed(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion

		#region Methods

		#region private void Completed()

		private void Completed()
		{
			UpdateInformation();
			int counter = 1;
			foreach (var record in _allRecords.GroupBy(i => i.Product))
			{
				var row = new DataGridViewRow { Tag = record.Key };

				DataGridViewCell numbercell = new DataGridViewTextBoxCell { Value = counter.ToString() };
				DataGridViewCell descCell = new DataGridViewTextBoxCell { Value = record.Key.ToString() };

				double qty = 0;
				foreach (var requestRecord in record)
				{
					qty += requestRecord.Quantity;
				}

				DataGridViewCell qTycell = new DataGridViewTextBoxCell { Value = qty };

				row.Cells.AddRange(numbercell, descCell, qTycell);

				descCell.ReadOnly = true;
				descCell.ReadOnly = true;
				qTycell.ReadOnly = true;

				dataGridViewComponents.Rows.Add(row);
				counter++;
			}
		}

		#endregion

		#region private void DoWork()

		private void DoWork()
		{

			var records = GlobalObjects.CasEnvironment.Loader.GetObjectList<PurchaseRequestRecord>(new ICommonFilter[] { new CommonFilter<int>(PurchaseRequestRecord.ParentPackageIdProperty, _order.ItemId) });
			var ids = records.Select(s => s.SupplierId).Distinct().ToArray();
			var productIds = records.Select(s => s.PackageItemId).Distinct().ToArray();
			var suppliers = GlobalObjects.CasEnvironment.Loader.GetObjectList<Supplier>(new ICommonFilter[] { new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In, ids), });
			var products = GlobalObjects.CasEnvironment.Loader.GetObjectList<Product>(new ICommonFilter[] { new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In, productIds), });

			foreach (var record in records)
			{
				record.Product = products.FirstOrDefault(i => i.ItemId == record.PackageItemId);
				record.Supplier = suppliers.FirstOrDefault(i => i.ItemId == record.SupplierId);
			}

			_allRecords = new List<PurchaseRequestRecord>();
			_allRecords.AddRange(records);
		}

		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			var personnel = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<SpecialistDTO, Specialist>();
			comboBoxReleased.Items.Clear();
			comboBoxReleased.Items.AddRange(personnel.ToArray());

			comboBoxRecived.Items.Clear();
			comboBoxRecived.Items.AddRange(personnel.ToArray());

			dataGridViewComponents.Rows.Clear();
			
			_stores = GlobalObjects.CasEnvironment.Stores.ToArray();
			comboBoxStore.Items.Clear();
			comboBoxStore.Items.AddRange(_stores);
		}

		#endregion

		#region private void ButtonOkClick(object sender, EventArgs e)

		private void ButtonOkClick(object sender, EventArgs e)
		{
			if (comboBoxStore.SelectedItem == null)
			{
				MessageBox.Show("Please, select store", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				return;
			}

			if (comboBoxRecived.SelectedItem == null)
			{
				MessageBox.Show("Please, select received", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				return;
			}

			if (comboBoxReleased.SelectedItem == null)
			{
				MessageBox.Show("Please, select released", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				return;
			}

			foreach (var record in _allRecords.GroupBy(i => i.Product))
			{
				var component = new Component
				{
					GoodsClass = record.Key.GoodsClass,
					Measure = record.Key.Measure,
					Standart = record.Key.Standart,
					PartNumber = record.Key.PartNumber,
					ALTPartNumber = record.Key.AltPartNumber,
					Description = record.Key.Description,
					IsDangerous = record.Key.IsDangerous,
					Manufacturer = record.Key.Manufacturer,
					ATAChapter = record.Key.ATAChapter,
					Code = record.Key.Code,
					Product = record.Key,
					Quantity = record.Select(i => i.Quantity).Sum(),
					QuantityIn = record.Select(i => i.Quantity).Sum()
				};

				//GlobalObjects.ComponentCore.AddComponent(component, (Store)comboBoxStore.SelectedItem, dateTimePickerDate.Value, "", ComponentStorePosition.UNK, destinationResponsible: true);

			}
		}

		#endregion

		#region private void ButtonCancelClick(object sender, EventArgs e)

		private void ButtonCancelClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#endregion

	}
}
