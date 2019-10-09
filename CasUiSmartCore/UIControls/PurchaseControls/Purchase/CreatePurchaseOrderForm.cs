using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using EntityCore.DTO.General;
using EntityCore.Filter;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Filters;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Purchase
{
	public partial class CreatePurchaseOrderForm : MetroForm
	{
		#region Fields

		private List<PurchaseRequestRecord> _addedRecord = new List<PurchaseRequestRecord>();

		private readonly RequestForQuotation _quotation;
		private List<SupplierPrice> _prices = new List<SupplierPrice>();
		private PurchaseOrder _order;
		private List<DocumentControl> DocumentControls = new List<DocumentControl>();

		#endregion

		#region Constructor

		public CreatePurchaseOrderForm()
		{
			InitializeComponent();
		}

		public CreatePurchaseOrderForm(RequestForQuotation quotation) : this()
		{
			_quotation = quotation;

			_order = new PurchaseOrder()
			{
				Parent = _quotation,
				ParentType = _quotation.SmartCoreObjectType,
				Title = _quotation.Title,
				OpeningDate = DateTime.Now,
				Author = _quotation.Author,
				Remarks = _quotation.Remarks,
				Number = _quotation.Number,
			};

			Task.Run(() => DoWork())
				.ContinueWith(task => Completed(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion

		#region private void Completed()

		private void Completed()
		{
			quatationSupplierPriceListView1.SetItemsArray(_prices.ToArray());
			UpdateControls();
			UpdateInitialControls();
		}

		#endregion

		#region private void DoWork()

		private void DoWork()
		{
			_prices.Clear();

			var records =
				GlobalObjects.CasEnvironment.NewLoader
					.GetObjectList<RequestForQuotationRecordDTO, RequestForQuotationRecord>(
						new Filter("ParentPackageId", _quotation.ItemId));
			var ids = records.SelectMany(i => i.SupplierPrice).Select(s => s.SupplierId).Distinct().ToArray();
			var productIds = records.Select(s => s.PackageItemId).Distinct().ToArray();
			var suppliers = GlobalObjects.CasEnvironment.Loader.GetObjectList<Supplier>(new ICommonFilter[]
				{new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In, ids),});
			var products = GlobalObjects.CasEnvironment.Loader.GetObjectList<Product>(new ICommonFilter[]
				{new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In, productIds),});


			var parentInitialId = (int) GlobalObjects.CasEnvironment.Execute(
					$@"select i.ItemId from RequestsForQuotation q
			left join InitialOrders i on i.ItemID = q.ParentID where q.ItemId = {_quotation.ItemId}").Tables[0]
				.Rows[0][0];
			var initialRecords =
				GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderRecordDTO, InitialOrderRecord>(
					new Filter("ParentPackageId", parentInitialId));

			foreach (var record in records)
			{
				record.ParentInitialRecord = initialRecords.FirstOrDefault(i => i.ProductId == record.PackageItemId);
				record.Product = products.FirstOrDefault(i => i.ItemId == record.PackageItemId);
				foreach (var price in record.SupplierPrice)
				{
					price.Supplier = suppliers.FirstOrDefault(i => i.ItemId == price.SupplierId);
					price.Parent = record;
				}

				if (record.SupplierPrice.Any(i => i.CostNew != record?.SupplierPrice?.FirstOrDefault()?.CostNew))
				{
					var lowest = record.SupplierPrice.OrderBy(i => i.CostNew).FirstOrDefault();
					if (lowest != null)
						lowest.IsLowestCostNew = true;
					var highest = record.SupplierPrice.OrderBy(i => i.CostNew).LastOrDefault();
					if (highest != null)
						highest.IsHighestCostNew = true;
				}

				if (record.SupplierPrice.Any(i => i.CostOverhaul != record?.SupplierPrice?.FirstOrDefault()?.CostOverhaul))
				{
					var lowest = record.SupplierPrice.OrderBy(i => i.CostOverhaul).FirstOrDefault();
					if (lowest != null)
						lowest.IsLowestCostOH = true;
					var highest = record.SupplierPrice.OrderBy(i => i.CostOverhaul).LastOrDefault();
					if (highest != null)
						highest.IsHighestCostOH = true;
				}

				if (record.SupplierPrice.Any(i => i.CostRepair != record?.SupplierPrice?.FirstOrDefault()?.CostRepair))
				{
					var lowest = record.SupplierPrice.OrderBy(i => i.CostRepair).FirstOrDefault();
					if (lowest != null)
						lowest.IsLowestCostRepair = true;
					var highest = record.SupplierPrice.OrderBy(i => i.CostRepair).LastOrDefault();
					if (highest != null)
						highest.IsLowestCostRepair = true;

				}

				if (record.SupplierPrice.Any(i => i.CostServiceable != record?.SupplierPrice?.FirstOrDefault()?.CostServiceable))
				{
					var lowest = record.SupplierPrice.OrderBy(i => i.CostServiceable).FirstOrDefault();
					if (lowest != null)
						lowest.IsLowestCostServ = true;
					var highest = record.SupplierPrice.OrderBy(i => i.CostServiceable).LastOrDefault();
					if (highest != null)
						highest.IsLowestCostServ = true;
				}
			}

		

		_prices.AddRange(records.SelectMany(i => i.SupplierPrice));
	}

	#endregion

		#region private void UpdateInitialControls()

		private void UpdateInitialControls()
		{
			comboBoxStatus.Items.Clear();
			comboBoxStatus.DataSource = Enum.GetValues(typeof(WorkPackageStatus));
			comboBoxStatus.SelectedItem = _order.Status;

			textBoxTitle.Text = _order.Title;
			metroTextBoxNumber.Text = _order.Number;
			dateTimePickerOpeningDate.Value = _order.OpeningDate;
			dateTimePickerClosingDate.Value = _order.ClosingDate;
			dateTimePickerPublishDate.Value = _order.PublishingDate;
			textBoxClosingBy.Text = _order.CloseByUser;
			textBoxPublishedBy.Text = _order.PublishedByUser;
			textBoxAuthor.Text = GlobalObjects.CasEnvironment.IdentityUser.ToString();
			textBoxRemarks.Text = _order.Remarks;
		}

		#endregion

		#region private void UpdateControls()

		private void UpdateControls()
		{
			comboBoxMeasure.Items.Clear();
			//comboBoxMeasure.Items.AddRange(Measure.GetByCategories(new[] { MeasureCategory.Mass, MeasureCategory.EconomicEntity }));
			comboBoxMeasure.Items.AddRange(Measure.Items.ToArray());

			comboBoxCondition.Items.Clear();
			comboBoxCondition.DataSource = Enum.GetValues(typeof(ComponentStatus));

			comboBoxCurrency.Items.Clear();
			comboBoxCurrency.Items.AddRange(Сurrency.Items.ToArray());
		}

		#endregion

		#region private void ButtonAdd_Click(object sender, EventArgs e)

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			foreach (var price in quatationSupplierPriceListView1.SelectedItems.ToArray())
			{
				var newRequest = new PurchaseRequestRecord(-1, price.Parent.Product, 1);
				newRequest.CostCondition = price.Parent.CostCondition;
				newRequest.Product = price.Parent.Product;
				newRequest.Supplier = price.Supplier;
				newRequest.Quantity = 1;
				newRequest.SupplierId = price.Supplier.ItemId;
				newRequest.Price = price;
				newRequest.Cost = (double) price.CostNew;
				newRequest.Currency = price.СurrencyNew;


				if (_addedRecord.Any(i =>
					i.Product.ItemId == price.Parent.Product.ItemId && i.SupplierId == price.SupplierId))
				{
					MessageBox.Show("Supplier price for product alredy added!", (string)new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					return;
				}

				var res = purchaseRecordListView1.GetItemsArray().Where(i =>
					i.Product.ItemId == price.Parent.Product.ItemId).ToArray().Select(i => i.Quantity).Sum();

				if (newRequest.Price.Parent.Quantity < newRequest.Quantity + res)
				{
					MessageBox.Show($"Q-ty is greathe then need for this product!", (string)new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					return;
				}

				_addedRecord.Add(newRequest);
			}

			purchaseRecordListView1.SetItemsArray(_addedRecord.ToArray());
		}

		#endregion

		#region private void ButtonDelete_Click(object sender, EventArgs e)

		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			if (purchaseRecordListView1.SelectedItems.Count == 0) return;

			foreach (var item in purchaseRecordListView1.SelectedItems.ToArray())
				_addedRecord.Remove(item);

			purchaseRecordListView1.SetItemsArray(_addedRecord.ToArray());
		}

		#endregion

		#region private void ButtonCancel_Click(object sender, EventArgs e)

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#region private void NumericUpDownQuantity_ValueChanged(object sender, EventArgs e)

		private void NumericUpDownQuantity_ValueChanged(object sender, EventArgs e)
		{
			SetForMeasure();
		}

		#endregion

		#region private void SetForMeasure()
		/// <summary>
		/// Изменяет контрол в соотствествии с выбранной единицей измерения
		/// </summary>
		private void SetForMeasure()
		{
			var measure = comboBoxMeasure.SelectedItem as Measure;
			if (measure == null || measure.MeasureCategory != MeasureCategory.Mass)
				numericUpDownQuantity.DecimalPlaces = 0;
			else numericUpDownQuantity.DecimalPlaces = 2;

			var quantity = numericUpDownQuantity.Value;
			var cost = numericUpDown1.Value;
			
			textBoxTotal.Text = $"{quantity * cost:0.##} {(Сurrency)comboBoxCurrency.SelectedItem}";
		}
		#endregion

		#region private void ComboBoxMeasure_SelectedIndexChanged(object sender, EventArgs e)

		private void ComboBoxMeasure_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetForMeasure();
		}

		#endregion

		#region private void ComboBoxCondition_SelectedIndexChanged(object sender, EventArgs e)

		private void ComboBoxCondition_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(comboBoxCondition.SelectedItem == null) return;
			if (purchaseRecordListView1.SelectedItem == null) return;

			var selected = (ComponentStatus)comboBoxCondition.SelectedItem;

			if (selected == ComponentStatus.New)
			{
				numericUpDown1.Value = purchaseRecordListView1.SelectedItem.Price.CostNew;
				comboBoxCurrency.SelectedItem = purchaseRecordListView1.SelectedItem.Price.СurrencyNew;
			}
			else if (selected == ComponentStatus.Overhaul)
			{
				numericUpDown1.Value = purchaseRecordListView1.SelectedItem.Price.CostOverhaul;
				comboBoxCurrency.SelectedItem = purchaseRecordListView1.SelectedItem.Price.СurrencyOH;
			}
			else if (selected == ComponentStatus.Repair)
			{
				numericUpDown1.Value = purchaseRecordListView1.SelectedItem.Price.CostRepair;
				comboBoxCurrency.SelectedItem = purchaseRecordListView1.SelectedItem.Price.СurrencyRepair;
			}
			else if (selected == ComponentStatus.Serviceable)
			{
				numericUpDown1.Value = purchaseRecordListView1.SelectedItem.Price.CostServiceable;
				comboBoxCurrency.SelectedItem = purchaseRecordListView1.SelectedItem.Price.СurrencyServ;
			}

		}

		#endregion

		#region private void PurchaseRecordListView1_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void PurchaseRecordListView1_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			button1.Enabled = purchaseRecordListView1.SelectedItem != null;
			if (purchaseRecordListView1.SelectedItem == null) return;

			comboBoxCondition.SelectedItem = purchaseRecordListView1.SelectedItem.CostCondition;
			comboBoxMeasure.SelectedItem = purchaseRecordListView1.SelectedItem.Measure;
			numericUpDownQuantity.Value = (decimal)purchaseRecordListView1.SelectedItem.Quantity;

			var selected = (ComponentStatus)comboBoxCondition.SelectedItem;

			if (selected == ComponentStatus.New)
			{
				numericUpDown1.Value = purchaseRecordListView1.SelectedItem.Price.CostNew;
				comboBoxCurrency.SelectedItem = purchaseRecordListView1.SelectedItem.Price.СurrencyNew;
			}
			else if (selected == ComponentStatus.Overhaul)
			{
				numericUpDown1.Value = purchaseRecordListView1.SelectedItem.Price.CostOverhaul;
				comboBoxCurrency.SelectedItem = purchaseRecordListView1.SelectedItem.Price.СurrencyOH;
			}
			else if (selected == ComponentStatus.Repair)
			{
				numericUpDown1.Value = purchaseRecordListView1.SelectedItem.Price.CostRepair;
				comboBoxCurrency.SelectedItem = purchaseRecordListView1.SelectedItem.Price.СurrencyRepair;
			}
			else if (selected == ComponentStatus.Serviceable)
			{
				numericUpDown1.Value = purchaseRecordListView1.SelectedItem.Price.CostServiceable;
				comboBoxCurrency.SelectedItem = purchaseRecordListView1.SelectedItem.Price.СurrencyServ;
			}

			SetForMeasure();
		}
		#endregion

		#region private void Button1_Click(object sender, EventArgs e)

		private void Button1_Click(object sender, EventArgs e)
		{
			if (purchaseRecordListView1.SelectedItem == null) return;

			var res = _addedRecord.Where(i =>
				i.Product.ItemId == purchaseRecordListView1.SelectedItem.Product.ItemId && i.Price != purchaseRecordListView1.SelectedItem.Price).Select(i => i.Quantity).Sum();

			if (purchaseRecordListView1.SelectedItem.Price.Parent.Quantity < (double) numericUpDownQuantity.Value + res)
			{
				MessageBox.Show($"Q-ty is greathe then need for this product!", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				return;
			}

			var q = purchaseRecordListView1.SelectedItem.Price.Parent?.ParentInitialRecord?.CostCondition.ToString().Replace(" ", "").Split(',');
			var q1 = ((ComponentStatus)comboBoxCondition.SelectedItem).ToString();
			bool flag = false;
			foreach (var s in q)
			{
				if (q1.Contains(s))
					flag = true;
			}

			if (!q.Any(i => q1.Contains(i)))
			{
				if (MessageBox.Show(
					    $"You ordered {purchaseRecordListView1.SelectedItem.Price.Parent?.CostCondition}! Do you really want ordered {(ComponentStatus) comboBoxCondition.SelectedItem}?",
					    (string) new GlobalTermsProvider()["SystemName"],
					    MessageBoxButtons.YesNo,
					    MessageBoxIcon.Exclamation) == DialogResult.No)
				{
					return;
				}
			}

			purchaseRecordListView1.SelectedItem.CostCondition = (ComponentStatus) comboBoxCondition.SelectedItem;
			purchaseRecordListView1.SelectedItem.Measure = (Measure) comboBoxMeasure.SelectedItem;
			purchaseRecordListView1.SelectedItem.Quantity = (double) numericUpDownQuantity.Value;
			purchaseRecordListView1.SelectedItem.Cost = (double)numericUpDown1.Value;
			purchaseRecordListView1.SelectedItem.Currency = (Сurrency) comboBoxCurrency.SelectedItem;

			purchaseRecordListView1.SetItemsArray(_addedRecord.ToArray());
		}

		#endregion

		#region private void Reset()

		private void Reset()
		{
			button1.Enabled = false;
			comboBoxCondition.SelectedItem = null;
			comboBoxMeasure.SelectedItem = null;
			numericUpDownQuantity.Value = 0;
			numericUpDown1.Value = 0;
		}

		#endregion

		#region private void ButtonOk_Click(object sender, EventArgs e)

		private void ButtonOk_Click(object sender, EventArgs e)
		{
			if (textBoxTitle.Text == "")
			{
				MessageBox.Show("Please, enter a Title", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}

			else if (purchaseRecordListView1.ItemsCount <= 0)
			{
				MessageBox.Show("Please select a price for purchase order", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}
			else
			{
				//запись новой информации в запросный ордер
				ApplyPurchaseData();
				//для каждого supplier свой ордер!
				foreach (var g in _addedRecord.GroupBy(i => i.Supplier))
				{
					var copy = (PurchaseOrder)_order.GetCopyUnsaved();
					copy.Title += g.Key.ToString();

					//сохранение запросного ордера
					GlobalObjects.CasEnvironment.NewKeeper.Save(_order);

					foreach (var record in g)
					{
						record.ParentPackageId = copy.ItemId;
						GlobalObjects.CasEnvironment.NewKeeper.Save(record);
					}
				}

				DialogResult = DialogResult.OK;
			}
			
		}

		#endregion

		#region private void ApplyOrderData()
		private void ApplyPurchaseData()
		{
			_order.Title = textBoxTitle.Text;
			_order.Number = metroTextBoxNumber.Text;
			_order.Status = (WorkPackageStatus)comboBoxStatus.SelectedItem;
			_order.Remarks = textBoxRemarks.Text;

			if (_order.ItemId <= 0)
				_order.Author = GlobalObjects.CasEnvironment.IdentityUser.ToString();

			if (_order.Status == WorkPackageStatus.All)
			{
				_order.OpeningDate = dateTimePickerOpeningDate.Value;
				_order.ClosingDate = dateTimePickerClosingDate.Value;
				_order.PublishingDate = dateTimePickerPublishDate.Value;
			}
			else if (_order.Status == WorkPackageStatus.Opened)
			{
				_order.OpeningDate = dateTimePickerOpeningDate.Value;
			}
			else if (_order.Status == WorkPackageStatus.Closed)
			{
				_order.ClosingDate = dateTimePickerClosingDate.Value;
			}
			else if (_order.Status == WorkPackageStatus.Published)
			{
				_order.PublishingDate = dateTimePickerPublishDate.Value;
			}
		}
		#endregion
	}
}
