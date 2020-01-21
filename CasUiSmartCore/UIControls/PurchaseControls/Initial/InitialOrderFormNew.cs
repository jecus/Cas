using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EntityCore.DTO.Dictionaries;
using EntityCore.DTO.General;
using EntityCore.Filter;
using MetroFramework.Forms;
using SmartCore.Auxiliary;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Filters;
using SmartCore.Purchase;
using SmartCore.Queries;

namespace CAS.UI.UIControls.PurchaseControls.Initial
{
	public partial class InitialOrderFormNew : MetroForm
	{
		#region Fields

		private List<InitialOrderRecord> _addedInitialOrderRecords = new List<InitialOrderRecord>();
		private List<InitialOrderRecord> _deleteExistInitialOrderRecords = new List<InitialOrderRecord>();
		private readonly InitialOrder _order;
		private List<BaseEntityObject> destinations = new List<BaseEntityObject>();
		private DefferedCategoriesCollection _defferedCategories = new DefferedCategoriesCollection();
		private readonly ProductPartNumberFilter _partNumberFilter = new ProductPartNumberFilter();
		private readonly ProductCollectionFilter _collectionFilter = new ProductCollectionFilter();
		private readonly ProductStandartFilter _standartFilter = new ProductStandartFilter();
		private List<Product> _currentAircraftKits = new List<Product>();
		private List<AirportsCodes> _airportsCodes = new List<AirportsCodes>();

		#endregion

		#region Properties

		public InitialOrder AddedInitial
		{
			get { return _order; }
		}

		#endregion

		#region Constructor

		public InitialOrderFormNew()
		{
			InitializeComponent();
		}

		public InitialOrderFormNew(InitialOrder order, IEnumerable<Product> selectedProducts = null) : this()
		{
			if (selectedProducts != null)
			{
				foreach (var product in selectedProducts)
				{
					var newRequest = new InitialOrderRecord(-1, product, 1);
					newRequest.Product = product;
					_addedInitialOrderRecords.Add(newRequest);
				}
			}

			_order = order;

			_collectionFilter.Filters.Add(_partNumberFilter);
			_collectionFilter.Filters.Add(_standartFilter);
			
			Task.Run(() => DoWork())
				.ContinueWith(task => Completed(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion

		#region private void Completed()

		private void Completed()
		{
			UpdateControls();
			UpdateInitialControls();

			_formListViewInitialItems.SetItemsArray(_addedInitialOrderRecords.ToArray());
		}

		#endregion

		#region private void DoWork()

		private void DoWork()
		{
			destinations.Clear();
			if (_order != null && _order.ItemId > 0)
			{
				_addedInitialOrderRecords.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderRecordDTO, InitialOrderRecord>(new Filter("ParentPackageId", _order.ItemId)));
				var ids = _addedInitialOrderRecords.Select(i => i.ProductId);
				var products = GlobalObjects.CasEnvironment.Loader.GetObjectList<Product>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()), true);

				if (ids.Count() > 0)
				{
					foreach (var addedInitialOrderRecord in _addedInitialOrderRecords)
						addedInitialOrderRecord.Product = products.FirstOrDefault(i => i.ItemId == addedInitialOrderRecord.ProductId);
				}
				var documents = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<DocumentDTO, Document>(new Filter("ParentID", _order.ItemId), true);
				_order.ClosingDocument.Clear();
				_order.ClosingDocument.AddRange(documents);
			}
			else
			{
				_order.Number = GlobalObjects.CasEnvironment.ApiProvider.GetInitialSequence().ToString();
			}

			_defferedCategories.Clear();
			_defferedCategories.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<DefferedCategorieDTO, DeferredCategory>(loadChild: true));

			_airportsCodes.Clear();
			_airportsCodes.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<AirportCodeDTO, AirportsCodes>().OrderBy(i => i.ShortName));
			_airportsCodes.Add(AirportsCodes.Unknown);

			destinations.AddRange(GlobalObjects.AircraftsCore.GetAllAircrafts().ToArray());
			destinations.AddRange(GlobalObjects.CasEnvironment.Stores.GetValidEntries());
			destinations.AddRange(GlobalObjects.CasEnvironment.Hangars.GetValidEntries());

		}

		#endregion

		#region private void UpdateControls()

		private void UpdateControls()
		{
			comboBoxMeasure.Items.Clear();
			//comboBoxMeasure.Items.AddRange(Measure.GetByCategories(new[] { MeasureCategory.Mass, MeasureCategory.EconomicEntity }));
			comboBoxMeasure.Items.AddRange(Measure.Items.ToArray());

			comboBoxDestination.Items.Clear();
			comboBoxDestination.Items.AddRange(destinations.ToArray());

			comboBoxPriority.Items.Clear();
			comboBoxPriority.Items.AddRange(Priority.Items.ToArray());

			comboBoxStation.Items.Clear();
			comboBoxStation.Items.AddRange(_airportsCodes.ToArray());
		}

		#endregion

		#region private void comboBoxMeasure_SelectedIndexChanged(object sender, System.EventArgs e)

		private void comboBoxMeasure_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		#endregion

		#region private void numericUpDownQuantity_ValueChanged(object sender, System.EventArgs e)

		private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
		{
			
		}

		#endregion

		#region private void UpdateInitialControls()

		private void UpdateInitialControls()
		{
			comboBoxStatus.Items.Clear();
			comboBoxStatus.DataSource = Enum.GetValues(typeof(WorkPackageStatus));
			comboBoxStatus.SelectedItem = _order.Status;

			metroTextBoxNumber.Text = _order.Number;

			if (_order.ItemId > 0)
			{
				textBoxTitle.Text = _order.Title;
				
				dateTimePickerOpeningDate.Value = _order.OpeningDate;
				dateTimePickerClosingDate.Value = _order.ClosingDate;
				dateTimePickerPublishDate.Value = _order.PublishingDate;
				textBoxClosingBy.Text = _order.CloseByUser;
				textBoxPublishedBy.Text = _order.PublishedByUser;
				textBoxAuthor.Text = _order.Author;
				textBoxRemarks.Text = _order.Remarks;
			}
			else
			{
				dateTimePickerClosingDate.Enabled = false;
				dateTimePickerPublishDate.Enabled = false;

				textBoxAuthor.Text = GlobalObjects.CasEnvironment.IdentityUser.ToString();
			}
		}

		#endregion

		#region private void buttonCancel_Click(object sender, EventArgs e)

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			if (textBoxTitle.Text == "")
			{
				MessageBox.Show("Please, enter a Title", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}

			else if (_formListViewInitialItems.ItemsCount <= 0)
			{
				MessageBox.Show("Please select a kits for initional order", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}
			else
			{
				//запись новой информации в запросный ордер
				ApplyInitialData();
				//сохранение запросного ордера
				GlobalObjects.CasEnvironment.NewKeeper.Save(_order);

				foreach (var record in _addedInitialOrderRecords)
				{
					record.ParentPackageId = _order.ItemId;
					GlobalObjects.CasEnvironment.NewKeeper.Save(record);

					if (record.Product != null)
					{
						foreach (var ksr in record.Product.SupplierRelations)
						{
							if (ksr.SupplierId != 0)
							{
								ksr.KitId = record.Product.ItemId;
								ksr.ParentTypeId = record.Product.SmartCoreObjectType.ItemId;

								try
								{
									GlobalObjects.CasEnvironment.NewKeeper.Save(ksr);
								}
								catch (Exception ex)
								{
									Program.Provider.Logger.Log("Error while saving data", ex);
									return;
								}
							}
						}
					}
				}

				foreach (var record in _deleteExistInitialOrderRecords)
					GlobalObjects.CasEnvironment.NewKeeper.Delete(record);
				DialogResult = DialogResult.OK;
			}
			
		}

		#endregion

		#region private void ApplyOrderData()
		private void ApplyInitialData()
		{
			_order.Title = textBoxTitle.Text;
			_order.Number = metroTextBoxNumber.Text;
			_order.Status = (WorkPackageStatus)comboBoxStatus.SelectedItem;
			_order.Remarks = textBoxRemarks.Text;

			if (_order.ItemId <= 0)
			{
				_order.Author = GlobalObjects.CasEnvironment.IdentityUser.ToString();
				_order.AuthorId = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
			}

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

		#region private void ButtonAdd_Click(object sender, EventArgs e)

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			foreach (var product in listViewKits.SelectedItems.ToArray())
			{
				var newRequest = new InitialOrderRecord(-1, product, 1);
				newRequest.Product = product;
				newRequest.Measure = product.Measure;
				_addedInitialOrderRecords.Add(newRequest);
			}

			_formListViewInitialItems.SetItemsArray(_addedInitialOrderRecords.ToArray());
		}

		#endregion

		#region private void ButtonDelete_Click(object sender, EventArgs e)

		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			if(_formListViewInitialItems.SelectedItems.Count == 0) return;

			foreach (var item in _formListViewInitialItems.SelectedItems.ToArray())
			{
				if (item.ItemId > 0)
					_deleteExistInitialOrderRecords.Add(item);

				_addedInitialOrderRecords.Remove(item);
			}

			_formListViewInitialItems.SetItemsArray(_addedInitialOrderRecords.ToArray());
		}


		#endregion

		#region private void listViewInitialItems_SelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)

		private void listViewInitialItems_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			button1.Enabled = _formListViewInitialItems.SelectedItem != null;
			if (_formListViewInitialItems.SelectedItem == null) return;

			var product = _formListViewInitialItems.SelectedItem.Product;

			comboBoxMeasure.SelectedItem = product.Measure;
			numericUpDownQuantity.Value = (decimal)_formListViewInitialItems.SelectedItem.Quantity;
			checkBoxNew.Checked = (_formListViewInitialItems.SelectedItem.CostCondition & ComponentStatus.New) != 0;
			checkBoxOverhaul.Checked = (_formListViewInitialItems.SelectedItem.CostCondition & ComponentStatus.Overhaul) != 0;
			checkBoxRepair.Checked = (_formListViewInitialItems.SelectedItem.CostCondition & ComponentStatus.Repair) != 0;
			checkBoxServiceable.Checked = (_formListViewInitialItems.SelectedItem.CostCondition & ComponentStatus.Serviceable) != 0;

			var destination =
				destinations.FirstOrDefault(d => d.SmartCoreObjectType == _formListViewInitialItems.SelectedItem.DestinationObjectType
												 && d.ItemId == _formListViewInitialItems.SelectedItem.DestinationObjectId);

			comboBoxDestination.SelectedItem = destination;
			comboBoxPriority.SelectedItem = _formListViewInitialItems.SelectedItem.Priority;
			metroTextBox1.Text = _formListViewInitialItems.SelectedItem.Remarks;
			comboBoxStation.SelectedItem =
				_airportsCodes.FirstOrDefault(i => _formListViewInitialItems.SelectedItem.AirportCodeId == i.ItemId);
			metroTextBoxReference.Text = _formListViewInitialItems.SelectedItem.Reference;
		}

		#endregion

		#region private void button1_Click(object sender, EventArgs e)

		private void button1_Click(object sender, EventArgs e)
		{
			if (_formListViewInitialItems.SelectedItem == null) return;

			_formListViewInitialItems.SelectedItem.Priority = comboBoxPriority.SelectedItem as Priority ?? Priority.UNK;
			_formListViewInitialItems.SelectedItem.Measure = comboBoxMeasure.SelectedItem as Measure ?? Measure.Unknown;
			_formListViewInitialItems.SelectedItem.Quantity = (double)numericUpDownQuantity.Value;
			_formListViewInitialItems.SelectedItem.Remarks = metroTextBox1.Text;
			_formListViewInitialItems.SelectedItem.AirportCodeId = ((AirportsCodes)comboBoxStation.SelectedItem)?.ItemId ?? -1;
			_formListViewInitialItems.SelectedItem.Reference = metroTextBoxReference.Text;

			ComponentStatus costCondition = ComponentStatus.Unknown;
			if (checkBoxNew.Checked)
				costCondition = costCondition | ComponentStatus.New;
			if (checkBoxServiceable.Checked)
				costCondition = costCondition | ComponentStatus.Serviceable;
			if (checkBoxOverhaul.Checked)
				costCondition = costCondition | ComponentStatus.Overhaul;
			if (checkBoxRepair.Checked)
				costCondition = costCondition | ComponentStatus.Repair;

			_formListViewInitialItems.SelectedItem.CostCondition = costCondition;

			if (comboBoxDestination.SelectedItem != null)
			{
				var destination = comboBoxDestination.SelectedItem as BaseEntityObject;
				if (destination != null)
				{
					_formListViewInitialItems.SelectedItem.DestinationObjectType = destination.SmartCoreObjectType;
					_formListViewInitialItems.SelectedItem.DestinationObjectId = destination.ItemId;
				}
				else
				{
					_formListViewInitialItems.SelectedItem.DestinationObjectType = SmartCoreType.Unknown;
					_formListViewInitialItems.SelectedItem.DestinationObjectId = -1;
				}
			}
			
			_formListViewInitialItems.SetItemsArray(_addedInitialOrderRecords.ToArray());

			_formListViewInitialItems.radGridView1.ClearSelection();
			Reset();
		}

		#endregion

		#region private void Reset()

		private void Reset()
		{
			button1.Enabled = false;
			comboBoxMeasure.SelectedItem = null;
			metroTextBox1.Text = "";
			numericUpDownQuantity.Value = 0;
			checkBoxNew.Checked = false;
			checkBoxOverhaul.Checked = false;
			checkBoxRepair.Checked = false;
			checkBoxServiceable.Checked = false;
			comboBoxDestination.SelectedItem = null;
		}

		#endregion

		#region private void dateTimePickerOpeningDate_ValueChanged(object sender, EventArgs e)

		private void dateTimePickerOpeningDate_ValueChanged(object sender, EventArgs e)
		{
			if (dateTimePickerOpeningDate.Value < DateTimeExtend.GetCASMinDateTime())
				dateTimePickerOpeningDate.Value = DateTimeExtend.GetCASMinDateTime();
			if (dateTimePickerOpeningDate.Value > DateTime.Now)
				dateTimePickerOpeningDate.Value = DateTime.Now;
		}

		#endregion

		private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
			var status = (WorkPackageStatus)comboBoxStatus.SelectedItem;
			if (status == WorkPackageStatus.Opened)
			{
				dateTimePickerOpeningDate.Enabled = true;
				dateTimePickerPublishDate.Enabled = false;
				dateTimePickerClosingDate.Enabled = false;
			}
			else if (status == WorkPackageStatus.Published)
			{
				dateTimePickerOpeningDate.Enabled = false;
				dateTimePickerPublishDate.Enabled = true;
				dateTimePickerClosingDate.Enabled = false;
			}
			else if (status == WorkPackageStatus.Closed)
			{
				dateTimePickerOpeningDate.Enabled = false;
				dateTimePickerPublishDate.Enabled = false;
				dateTimePickerClosingDate.Enabled = true;
			}
			else
			{
				dateTimePickerOpeningDate.Enabled = true;
				dateTimePickerPublishDate.Enabled = true;
				dateTimePickerClosingDate.Enabled = true;
			}
		}

		#region private void Button2_Click(object sender, EventArgs e)

		private void Button2_Click(object sender, EventArgs e)
		{
			metroProgressSpinner1.Visible = true;
			Task.Run(() =>
				{
					_currentAircraftKits.Clear();
					var res = BaseQueries.GetSelectQueryWithWhere<Product>(loadChild:true) + $" AND ( AccessoryDescriptions.Model like '%{textBoxSearchPartNumber.Text}%' OR " +
							  $"AccessoryDescriptions.PartNumber like '%{textBoxSearchPartNumber.Text}%' OR " +
							  $"AccessoryDescriptions.Description like '%{textBoxSearchPartNumber.Text}%' OR " +
							  $"AccessoryDescriptions.AltPartNumber like '%{textBoxSearchPartNumber.Text}%' OR " +
							  $"AccessoryDescriptions.Reference like '%{textBoxSearchPartNumber.Text}%')";

					var ds = GlobalObjects.CasEnvironment.Execute(res);
					_currentAircraftKits.AddRange(BaseQueries.GetObjectList<Product>(ds.Tables[0],true));
				})
				.ContinueWith(task =>
				{
					listViewKits.SetItemsArray(_currentAircraftKits.ToArray());
					metroProgressSpinner1.Visible = false;
				}, TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion

		private void InitialOrderFormNew_Load(object sender, EventArgs e)
		{

		}

		

		private void ButtonAddProduct_Click(object sender, EventArgs e)
		{
			var form = new ProductForm(new Product());
			form.ShowDialog();
		}
	}
}
