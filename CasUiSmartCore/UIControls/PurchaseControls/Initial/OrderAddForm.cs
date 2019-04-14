using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.DataGridViewElements;
using CASTerms;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Personnel;
using SmartCore.Filters;
using SmartCore.Purchase;
using Convert = System.Convert;

namespace CAS.UI.UIControls.PurchaseControls.Initial
{
    ///<summary>
    /// Форма для добавления нового ордера запроса и/или его китов
    ///</summary>
    public partial class OrderAddForm : Form
    {
	    private readonly OrderFormType _formType;

	    #region Fields

        private InitialOrder _addedInitial;
        private RequestForQuotation _addedQuotation;

	    private List<InitialOrderRecord> _addedInitialOrderRecords = new List<InitialOrderRecord>();
	    private List<InitialOrderRecord> _deleteExistInitialOrderRecords = new List<InitialOrderRecord>();

	    private List<RequestForQuotationRecord> _addedQuatationRecords = new List<RequestForQuotationRecord>();
	    private List<RequestForQuotationRecord> _deleteQuatationRecords = new List<RequestForQuotationRecord>();

	    private List<QuotationCost> _quotationCosts = new List<QuotationCost>();

	    private List<BaseEntityObject> destinations = new List<BaseEntityObject>();
	    private List<Supplier> _suppliers = new List<Supplier>();
	    private List<Specialist> _specialists = new List<Specialist>();
	    private DefferedCategoriesCollection _defferedCategories = new DefferedCategoriesCollection();

		private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

		private readonly ProductPartNumberFilter _partNumberFilter = new ProductPartNumberFilter();
        private readonly ProductSuppliersFilter _supplierFilter = new ProductSuppliersFilter();
        private readonly ProductManufacturerFilter _manufacturerFilter = new ProductManufacturerFilter();
        private readonly ProductCollectionFilter _collectionFilter = new ProductCollectionFilter();

        #endregion

        #region Properties
       
        ///<summary>
        ///</summary>
        public InitialOrder AddedInitial
        {
            get { return _addedInitial; }
        }

	    public RequestForQuotation Added
		{
		    get { return _addedQuotation; }
	    }

		#endregion

		#region Constructors

		#region private InitionalOrderAddForm()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private OrderAddForm()
        {
            InitializeComponent();
        }
		#endregion

		#region public InitionalOrderAddForm(InitialOrder rfq) : this()
	    ///<summary>
	    /// конструктор для добавления китов в ордер запроса
	    ///</summary>
	    public OrderAddForm(RequestForQuotation rfq, OrderFormType formType = OrderFormType.Quotation) : this()
	    {
		    if (rfq == null)
			    throw new ArgumentNullException("rfq");

		    _addedQuotation = rfq;
		    _formType = formType;
		    this.Text = "Quotation Order";
		    listViewQuatationItems.Visible = true;
		    dataGridView1.Visible = true;

			_collectionFilter.Filters.Add(_partNumberFilter);
		    _collectionFilter.Filters.Add(_supplierFilter);
		    _collectionFilter.Filters.Add(_manufacturerFilter);

		    _animatedThreadWorker.DoWork += _animatedThreadWorker_DoWork;
		    _animatedThreadWorker.RunWorkerCompleted += _animatedThreadWorker_RunWorkerCompleted;
		    _animatedThreadWorker.RunWorkerAsync();
	    }
	    #endregion

		#region public InitionalOrderAddForm(InitialOrder rfq) : this()
		///<summary>
		/// конструктор для добавления китов в ордер запроса
		///</summary>
		public OrderAddForm(InitialOrder rfq) : this()
        {
            if (rfq == null)
                throw new ArgumentNullException("rfq");

            _addedInitial = rfq;
	        _formType = OrderFormType.Initial;
	        this.Text = "Initional Order";
	        listViewInitialItems.Visible = true;
	        dataGridViewControlSuppliers.Visible = true;

			_collectionFilter.Filters.Add(_partNumberFilter);
            _collectionFilter.Filters.Add(_supplierFilter);
            _collectionFilter.Filters.Add(_manufacturerFilter);

			_animatedThreadWorker.DoWork += _animatedThreadWorker_DoWork;
	        _animatedThreadWorker.RunWorkerCompleted += _animatedThreadWorker_RunWorkerCompleted;
	        _animatedThreadWorker.RunWorkerAsync();
		}
        #endregion

        #region public InitionalOrderAddForm(Aircraft parentAircraft)  : this()
        ///<summary>
        /// конструктор для создания ордера запроса для определенноно самолета
        ///</summary>
        public OrderAddForm(BaseEntityObject parent, OrderFormType formType)
            : this()
        {
            if (parent == null)
                throw new ArgumentNullException("parent");
	        _formType = formType;

	        if (_formType == OrderFormType.Initial)
	        {
		        this.Text = "Initional Order";
				listViewInitialItems.Visible = true;
		        dataGridViewControlSuppliers.Visible = true;
		        _addedInitial = new InitialOrder { ParentId = parent.ItemId, ParentType = parent.SmartCoreObjectType };
	        }
	        else
	        {
		        this.Text = "Quotation Order";
				listViewQuatationItems.Visible = true;
				dataGridView1.Visible = true;
				_addedQuotation = new RequestForQuotation{ ParentId = parent.ItemId, ParentType = parent.SmartCoreObjectType };
	        }

            _collectionFilter.Filters.Add(_partNumberFilter);
            _collectionFilter.Filters.Add(_supplierFilter);
            _collectionFilter.Filters.Add(_manufacturerFilter);

			_animatedThreadWorker.DoWork += _animatedThreadWorker_DoWork;
	        _animatedThreadWorker.RunWorkerCompleted += _animatedThreadWorker_RunWorkerCompleted;
	        _animatedThreadWorker.RunWorkerAsync();

			textBoxTitle.Text = parent + "-IO-" + DateTime.Now;
            textBoxAuthor.Text = GlobalObjects.CasEnvironment.IdentityUser.ToString();

        }
		#endregion

		#endregion

		#region Methods

		#region private void _animatedThreadWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)

		private void _animatedThreadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			var filteredCollection = _collectionFilter.GatherDirectives();
			listViewKits.SetItemsArray(filteredCollection.ToArray());

			if(_formType == OrderFormType.Initial)
				listViewInitialItems.SetItemsArray(_addedInitialOrderRecords.ToArray());
			else listViewQuatationItems.SetItemsArray(_addedQuatationRecords.ToArray());

			UpdateInitialRecordsControls();

			if(_formType == OrderFormType.Initial)
				UpdateInitialControls();
			else UpdateRequestControls();

		}

		#endregion

	    #region private void UpdateInitialRecordsControls()

	    private void UpdateInitialRecordsControls()
	    {
		    dictionaryComboProduct.SetType(typeof(Product), true);
		    Program.MainDispatcher.ProcessControl(dictionaryComboProduct);

		    comboBoxMeasure.Items.Clear();
		    comboBoxMeasure.Items.AddRange(Measure.GetByCategories(new[] { MeasureCategory.Mass, MeasureCategory.EconomicEntity }));


		    if (_formType == OrderFormType.Initial)
		    {
			    dataGridViewControlSuppliers.ViewedTypeProperties.AddRange(new[]
			    {
				    KitSuppliersRelation.SupplierProperty,
			    });
			    dataGridViewControlSuppliers.ViewedType = typeof(KitSuppliersRelation);
			}
		    

		    comboBoxDestination.Items.Clear();
		    comboBoxDestination.Items.AddRange(destinations.ToArray());

		    comboBoxPriority.Items.Clear();
		    comboBoxPriority.Items.AddRange(Priority.Items.ToArray());

		    comboBoxReason.Items.Clear();
		    comboBoxReason.Items.AddRange(InitialReason.Items.ToArray());
	    }

		#endregion

		#region private void UpdateRequestControls()

		private void UpdateRequestControls()
	    {
		    comboBoxCountry.Items.Clear();
		    comboBoxCountry.Items.AddRange(Citizenship.Items.ToArray());
			comboBoxTypeOfOperation.Items.Clear();
		    comboBoxTypeOfOperation.Items.AddRange(TypeOfOperation.Items.ToArray());
		    comboBoxShipBy.Items.Clear();
		    comboBoxShipBy.Items.AddRange(ShipBy.Items.ToArray());
		    comboBoxIncoTerm.Items.Clear();
		    comboBoxIncoTerm.Items.AddRange(IncoTerm.Items.ToArray());
		    comboBoxCarrier.Items.Clear();
		    comboBoxCarrier.Items.AddRange(_suppliers.ToArray());
		    comboBoxCarrier.Items.Add(Supplier.Unknown);
		    comboBoxApprovedBy.Items.Clear();
		    comboBoxApprovedBy.Items.AddRange(_specialists.ToArray());
		    comboBoxPublishedBy.Items.Clear();
		    comboBoxPublishedBy.Items.AddRange(_specialists.ToArray());
			comboBoxClosedBy.Items.Clear();
		    comboBoxClosedBy.Items.AddRange(_specialists.ToArray());


		    if (_addedQuotation.ItemId > 0)
		    {
			    textBoxTitle.Text = _addedQuotation.Title;
			    textBoxDescription.Text = _addedQuotation.Description;
			    dateTimePickerOpeningDate.Value = _addedQuotation.OpeningDate;
			    textBoxAuthor.Text = _addedQuotation.Author;
			    textBoxRemarks.Text = _addedQuotation.Remarks;
			}
	    }

		#endregion

		#region private void UpdateInitialControls()

		private void UpdateInitialControls()
	    {
		    comboBoxCountry.Items.Clear();
		    comboBoxCountry.Items.AddRange(Citizenship.Items.ToArray());

		    comboBoxTypeOfOperation.Items.Clear();
		    comboBoxTypeOfOperation.Items.AddRange(TypeOfOperation.Items.ToArray());
		    
		    comboBoxShipBy.Items.Clear();
		    comboBoxShipBy.Items.AddRange(ShipBy.Items.ToArray());
		    
		    comboBoxIncoTerm.Items.Clear();
		    comboBoxIncoTerm.Items.AddRange(IncoTerm.Items.ToArray());
		    comboBoxCarrier.Items.Clear();
		    comboBoxCarrier.Items.AddRange(_suppliers.ToArray());
		    comboBoxCarrier.Items.Add(Supplier.Unknown);
		   
		    comboBoxApprovedBy.Items.Clear();
		    comboBoxApprovedBy.Items.AddRange(_specialists.ToArray());
		    
		    comboBoxPublishedBy.Items.Clear();
		    comboBoxPublishedBy.Items.AddRange(_specialists.ToArray());

		    comboBoxClosedBy.Items.Clear();
		    comboBoxClosedBy.Items.AddRange(_specialists.ToArray());


		    if (_addedInitial.ItemId > 0)
		    {
			    textBoxTitle.Text = _addedInitial.Title;
			    textBoxDescription.Text = _addedInitial.Description;
			    dateTimePickerOpeningDate.Value = _addedInitial.OpeningDate;
			    textBoxAuthor.Text = _addedInitial.Author;
			    textBoxRemarks.Text = _addedInitial.Remarks;
			}
	    }

	    #endregion

		#region private void _animatedThreadWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)

		private void _animatedThreadWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				var currentAircraftKits = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, Product>(loadChild:true).ToList();

				#region Загрузка Supplier для продуктов

				var supplierId = currentAircraftKits.SelectMany(i => i.SupplierRelations).Select(i => i.SupplierID).Distinct();
				if (supplierId.Count() > 0)
				{
					var suppliers = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<SupplierDTO, Supplier>(new Filter("ItemId", supplierId));
					if (suppliers.Count > 0)
					{
						foreach (var p in currentAircraftKits.Where(i => i.SupplierRelations.Any()))
						{
							foreach (var relation in p.SupplierRelations)
							{
								var currentSup = suppliers.FirstOrDefault(i => i.ItemId == relation.SupplierID);
								if (currentSup != null)
								{
									relation.Supplier = currentSup;
									if (!p.Suppliers.Contains(currentSup))
										p.Suppliers.Add(currentSup);
								}
							}
						}
					}
				}
				#endregion

				if (_addedInitial != null && _addedInitial.ItemId > 0)
				{
					_addedInitialOrderRecords.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderRecordDTO, InitialOrderRecord>(new Filter("ParentPackageId", _addedInitial.ItemId)));
					var ids = _addedInitialOrderRecords.Select(i => i.ProductId);
					if (ids.Count() > 0)
					{
						//var product = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, Product>(new Filter("ItemId", ids), true);
						foreach (var addedInitialOrderRecord in _addedInitialOrderRecords)
							addedInitialOrderRecord.Product = currentAircraftKits.FirstOrDefault(i => i.ItemId == addedInitialOrderRecord.ProductId);
					}
				}
				else if (_addedQuotation != null && _addedQuotation.ItemId > 0)
				{
					_quotationCosts.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<QuotationCostDTO, QuotationCost>(new Filter("QuotationId", _addedQuotation.ItemId)));
					_addedQuatationRecords.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<RequestForQuotationRecordDTO, RequestForQuotationRecord>(new Filter("ParentPackageId", _addedQuotation.ItemId)));
					var ids = _addedQuatationRecords.Select(i => i.PackageItemId);
					if (ids.Count() > 0)
					{
						//var product = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, Product>(new Filter("ItemId", ids), true);
						foreach (var addedInitialOrderRecord in _addedQuatationRecords)
						{
							var product = currentAircraftKits.FirstOrDefault(i => i.ItemId == addedInitialOrderRecord.PackageItemId);

							foreach (var relation in product.SupplierRelations)
							{
								var findCost = _quotationCosts.FirstOrDefault(i => i.ProductId == product.ItemId && i.SupplierId == relation.Supplier.ItemId);
								if (findCost != null)
								{
									findCost.SupplierName = relation.Supplier.Name;
									product.QuatationCosts.Add(findCost);
								}
								else product.QuatationCosts.Add(new QuotationCost{QuotationId = _addedQuotation .ItemId, ProductId = product.ItemId, SupplierId = relation.SupplierId, SupplierName = relation.Supplier.Name });
							}

							addedInitialOrderRecord.Product = product;
						}
					}
				}
				
				_collectionFilter.InitialCollection = currentAircraftKits;

				destinations.AddRange(GlobalObjects.AircraftsCore.GetAllAircrafts().ToArray());
				destinations.AddRange(GlobalObjects.CasEnvironment.Stores.GetValidEntries());
				destinations.AddRange(GlobalObjects.CasEnvironment.Hangars.GetValidEntries());

				var specIds = GlobalObjects.CasEnvironment.NewLoader.GetSelectColumnOnly<SpecializationDTO>( new[] {new Filter("DepartmentId", 4)}, "ItemId");
				if(specIds.Count > 0)
					_specialists.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SpecialistDTO, Specialist>(new Filter("SpecializationID", specIds)));

				_specialists.Add(Specialist.Unknown);

				_defferedCategories.Clear();
				_defferedCategories.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<DefferedCategorieDTO, DeferredCategory>(loadChild: true));

				_suppliers.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SupplierDTO, Supplier>(new List<Filter>()
				{
					new Filter("SupplierClassId", 11)
				}));
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("error while loading data", exception);
			}
		}

		#endregion

		#region private void UpdateListViewItems()
		private void UpdateListViewItems()
        {
			var filteredCollection = _collectionFilter.GatherDirectives();
	        listViewKits.SetItemsArray(filteredCollection.ToArray());
		}
        #endregion

        #region private void ApplyOrderData()
        private void ApplyInitialData()
        {
            _addedInitial.Title = textBoxTitle.Text;
            _addedInitial.Description = textBoxDescription.Text;
            _addedInitial.OpeningDate = dateTimePickerOpeningDate.Value;
            _addedInitial.Author = textBoxAuthor.Text;
            _addedInitial.Remarks = textBoxRemarks.Text;
		}
		#endregion

		#region private void ApplyRequeslData()

		private void ApplyRequeslData()
	    {
		    _addedQuotation.Title = textBoxTitle.Text;
		    _addedQuotation.Description = textBoxDescription.Text;
		    _addedQuotation.OpeningDate = dateTimePickerOpeningDate.Value;
		    _addedQuotation.Author = textBoxAuthor.Text;
		    _addedQuotation.Remarks = textBoxRemarks.Text;
		    //_addedQuotation.PublishedBy = comboBoxPublishedBy.SelectedItem as Specialist;
		    //_addedQuotation.ClosedBy = comboBoxClosedBy.SelectedItem as Specialist;
	    }

	    #endregion

		#region private void ButtonOkClick(object sender, EventArgs e)
		private void buttonOk_Click(object sender, EventArgs e)
		{   

                if(textBoxTitle.Text == "")
                {
                    MessageBox.Show("Please, enter a Title", (string) new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK, 
                                        MessageBoxIcon.Exclamation);
                    return;
                }
               

			if (_formType == OrderFormType.Initial)
			{

				if (listViewInitialItems.ListViewItemList.Count <= 0)
				{
					MessageBox.Show("Please select a kits for initional order", (string)new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					return;
				}
				//запись новой информации в запросный ордер
				ApplyInitialData();
				//сохранение запросного ордера
				GlobalObjects.CasEnvironment.NewKeeper.Save(_addedInitial);

				if (listViewKits.ListViewItemList.Count <= 0)
				{
					MessageBox.Show("Please select a kits for initional order", (string)new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					return;
				}

				foreach (var record in _addedInitialOrderRecords)
				{
					record.ParentPackageId = _addedInitial.ItemId;
					GlobalObjects.CasEnvironment.NewKeeper.Save(record);

					if (record.Product != null)
					{
						foreach (KitSuppliersRelation ksr in record.Product.SupplierRelations)
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
			}
			else if (_formType == OrderFormType.Quotation)
			{
				if (listViewQuatationItems.ListViewItemList.Count <= 0)
				{
					MessageBox.Show("Please select a kits for initional order", (string)new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					return;
				}
				ApplyRequeslData();
				GlobalObjects.CasEnvironment.NewKeeper.Save(_addedQuotation);

				if (listViewKits.ListViewItemList.Count <= 0)
				{
					MessageBox.Show("Please select a kits for initional order", (string)new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					return;
				}

				foreach (var record in _addedQuatationRecords)
				{
					record.ParentPackageId = _addedQuotation.ItemId;
					GlobalObjects.CasEnvironment.NewKeeper.Save(record);

					if (record.Product != null)
					{
						foreach (var cost in record.Product.QuatationCosts)
							GlobalObjects.CasEnvironment.NewKeeper.Save(cost);
					}
				}

				foreach (var record in _deleteQuatationRecords)
					GlobalObjects.CasEnvironment.NewKeeper.Delete(record);
			}

            DialogResult = DialogResult.OK;
            Close();
        }
		#endregion

		#region private void ButtonCancelClick(object sender, EventArgs e)
		private void buttonCancel_Click(object sender, EventArgs e)
		{
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)
        private void ButtonAddClick(object sender, EventArgs e)
        {
	        if (listViewKits.SelectedItems.Count == 0) return;

			if (_formType == OrderFormType.Initial)
	        {
				foreach (var product in listViewKits.SelectedItems.ToArray())
		        {
			        var newRequest = new InitialOrderRecord(-1, product, 1);
			        newRequest.Product = product;
			        _addedInitialOrderRecords.Add(newRequest);
		        }

		        listViewInitialItems.SetItemsArray(_addedInitialOrderRecords.ToArray());
			}
	        else
	        {
				foreach (var product in listViewKits.SelectedItems.ToArray())
		        {
			        var newRequest = new RequestForQuotationRecord(-1, product, 1);
			        newRequest.Product = product;
			        _addedQuatationRecords.Add(newRequest);
		        }

		        listViewQuatationItems.SetItemsArray(_addedQuatationRecords.ToArray());
			}
		}
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
	        if (_formType == OrderFormType.Initial)
	        {
		        if (listViewInitialItems.SelectedItems.Count == 0) return;

		        foreach (var item in listViewInitialItems.SelectedItems.ToArray())
		        {
			        if (item.ItemId > 0)
				        _deleteExistInitialOrderRecords.Add(item);

			        _addedInitialOrderRecords.Remove(item);
		        }

		        listViewInitialItems.SetItemsArray(_addedInitialOrderRecords.ToArray());
			}

	        else
	        {
				if (listViewQuatationItems.SelectedItems.Count == 0) return;

		        foreach (var item in listViewQuatationItems.SelectedItems.ToArray())
		        {
			        if (item.ItemId > 0)
				        _deleteQuatationRecords.Add(item);

			        _addedQuatationRecords.Remove(item);
		        }

		        listViewQuatationItems.SetItemsArray(_addedQuatationRecords.ToArray());
			}
			

		}
        #endregion

        #region private void TextBoxSearchPartNumberTextChanged(object sender, EventArgs e)
        private void TextBoxSearchPartNumberTextChanged(object sender, EventArgs e)
        {
            _partNumberFilter.Mask = textBoxSearchPartNumber.Text;
            UpdateListViewItems();
        }
        #endregion

        #region private void TextBoxSearchSupplierTextChanged(object sender, EventArgs e)
        private void TextBoxSearchSupplierTextChanged(object sender, EventArgs e)
        {
            _supplierFilter.Mask = textBoxSearchSupplier.Text;
            UpdateListViewItems();
        }
        #endregion

        #region private void DateTimePickerOpeningDateValueChanged(object sender, EventArgs e)
        private void DateTimePickerOpeningDateValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerOpeningDate.Value < DateTimeExtend.GetCASMinDateTime())
                dateTimePickerOpeningDate.Value = DateTimeExtend.GetCASMinDateTime();
            if (dateTimePickerOpeningDate.Value > DateTime.Now)
                dateTimePickerOpeningDate.Value = DateTime.Now;
        }

		#endregion

		#endregion

		#region private void listViewAddedItems_SelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)

		private void listViewAddedItems_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
	    {
		    if (listViewInitialItems.SelectedItem == null) return;

		    var product = listViewInitialItems.SelectedItem.Product;

		    dictionaryComboProduct.SelectedItem = product;
		    comboBoxMeasure.SelectedItem = product.Measure;
		    comboBoxReason.SelectedItem = listViewInitialItems.SelectedItem.InitialReason;
		    textBoxPartNumber.Text = product.PartNumber;
		    textBoxProductDesc.Text = product.Description;
		    numericUpDownQuantity.Value = (decimal)listViewInitialItems.SelectedItem.Quantity;
		    textBoxProductRemarks.Text = product.Remarks;
		    dataGridViewControlSuppliers.SetItemsArray((ICommonCollection)product.SupplierRelations);
		    checkBoxNew.Checked = (listViewInitialItems.SelectedItem.CostCondition & ComponentStatus.New) != 0;
		    checkBoxOverhaul.Checked = (listViewInitialItems.SelectedItem.CostCondition & ComponentStatus.Overhaul) != 0;
		    checkBoxRepair.Checked = (listViewInitialItems.SelectedItem.CostCondition & ComponentStatus.Repair) != 0;
		    checkBoxServiceable.Checked = (listViewInitialItems.SelectedItem.CostCondition & ComponentStatus.Serviceable) != 0;

		    var destination =
			    destinations.FirstOrDefault(d => d.SmartCoreObjectType == listViewInitialItems.SelectedItem.DestinationObjectType
			                                     && d.ItemId == listViewInitialItems.SelectedItem.DestinationObjectId);

		    comboBoxDestination.SelectedItem = destination;
		    comboBoxPriority.SelectedItem = listViewInitialItems.SelectedItem.Priority;

		    lifelengthViewerLifeLimit.Lifelength = new Lifelength(listViewInitialItems.SelectedItem.LifeLimit);
		    lifelengthViewerNotify.Lifelength = new Lifelength(listViewInitialItems.SelectedItem.LifeLimitNotify);
	    }

	    #endregion

		private void button1_Click(object sender, EventArgs e)
		{
			if (_formType == OrderFormType.Initial)
			{
				if (listViewInitialItems.SelectedItem == null) return;

				listViewInitialItems.SelectedItem.Priority = comboBoxPriority.SelectedItem as Priority;
				listViewInitialItems.SelectedItem.Product = dictionaryComboProduct.SelectedItem as Product;
				listViewInitialItems.SelectedItem.Measure = comboBoxMeasure.SelectedItem as Measure ?? Measure.Unknown;
				listViewInitialItems.SelectedItem.Quantity = (double)numericUpDownQuantity.Value;
				listViewInitialItems.SelectedItem.DeferredCategory = comboBoxDefferedCategory.SelectedItem as DeferredCategory ?? DeferredCategory.Unknown;

				ComponentStatus costCondition = ComponentStatus.Unknown;
				if (checkBoxNew.Checked)
					costCondition = costCondition | ComponentStatus.New;
				if (checkBoxServiceable.Checked)
					costCondition = costCondition | ComponentStatus.Serviceable;
				if (checkBoxOverhaul.Checked)
					costCondition = costCondition | ComponentStatus.Overhaul;
				if (checkBoxRepair.Checked)
					costCondition = costCondition | ComponentStatus.Repair;

				listViewInitialItems.SelectedItem.CostCondition = costCondition;

				var destination = comboBoxDestination.SelectedItem as BaseEntityObject;
				if (destination != null)
				{
					listViewInitialItems.SelectedItem.DestinationObjectType = destination.SmartCoreObjectType;
					listViewInitialItems.SelectedItem.DestinationObjectId = destination.ItemId;
				}
				else
				{
					listViewInitialItems.SelectedItem.DestinationObjectType = SmartCoreType.Unknown;
					listViewInitialItems.SelectedItem.DestinationObjectId = -1;
				}
				listViewInitialItems.SelectedItem.InitialReason = comboBoxReason.SelectedItem as InitialReason ?? InitialReason.Unknown;
				listViewInitialItems.SelectedItem.LifeLimit = lifelengthViewerLifeLimit.Lifelength;
				listViewInitialItems.SelectedItem.LifeLimitNotify = lifelengthViewerNotify.Lifelength;

				if (listViewInitialItems.SelectedItem.Product != null)
				{
					dataGridViewControlSuppliers.ApplyChanges();
					listViewInitialItems.SelectedItem.Product.SupplierRelations.Clear();
					listViewInitialItems.SelectedItem.Product.SupplierRelations.AddRange(dataGridViewControlSuppliers.GetItemsArray());
				}

				listViewInitialItems.SetItemsArray(_addedInitialOrderRecords.ToArray());
			}
			else
			{
				if (listViewQuatationItems.SelectedItem == null) return;

				listViewQuatationItems.SelectedItem.Priority = comboBoxPriority.SelectedItem as Priority;
				listViewQuatationItems.SelectedItem.Product = dictionaryComboProduct.SelectedItem as Product;
				listViewQuatationItems.SelectedItem.Measure = comboBoxMeasure.SelectedItem as Measure ?? Measure.Unknown;
				listViewQuatationItems.SelectedItem.Quantity = (double)numericUpDownQuantity.Value;
				listViewQuatationItems.SelectedItem.DeferredCategory = comboBoxDefferedCategory.SelectedItem as DeferredCategory ?? DeferredCategory.Unknown;

				ComponentStatus costCondition = ComponentStatus.Unknown;
				if (checkBoxNew.Checked)
					costCondition = costCondition | ComponentStatus.New;
				if (checkBoxServiceable.Checked)
					costCondition = costCondition | ComponentStatus.Serviceable;
				if (checkBoxOverhaul.Checked)
					costCondition = costCondition | ComponentStatus.Overhaul;
				if (checkBoxRepair.Checked)
					costCondition = costCondition | ComponentStatus.Repair;

				listViewQuatationItems.SelectedItem.CostCondition = costCondition;

				var destination = comboBoxDestination.SelectedItem as BaseEntityObject;
				if (destination != null)
				{
					listViewQuatationItems.SelectedItem.DestinationObjectType = destination.SmartCoreObjectType;
					listViewQuatationItems.SelectedItem.DestinationObjectId = destination.ItemId;
				}
				else
				{
					listViewQuatationItems.SelectedItem.DestinationObjectType = SmartCoreType.Unknown;
					listViewQuatationItems.SelectedItem.DestinationObjectId = -1;
				}
				listViewQuatationItems.SelectedItem.InitialReason = comboBoxReason.SelectedItem as InitialReason ?? InitialReason.Unknown;
				//listViewQuatationItems.SelectedItem.LifeLimit = lifelengthViewerLifeLimit.Lifelength;
				//listViewQuatationItems.SelectedItem.LifeLimitNotify = lifelengthViewerNotify.Lifelength;

				var items = dataGridView1.Rows.Cast<DataGridViewRow>().ToList();

				listViewQuatationItems.SelectedItem.Product.QuatationCosts.Clear();

				foreach (var row in items)
				{
					var cost = row.Cells[0].Tag as QuotationCost;
					if(cost == null)
						continue;

					cost.Cost = Convert.ToDouble(row.Cells[1].Value);
					cost.CostOverhaul = Convert.ToDouble(row.Cells[2].Value);
					cost.CostServisible = Convert.ToDouble(row.Cells[3].Value);
					cost.Currency = Сurrency.Items.FirstOrDefault( i => i.ShortName.Equals(row.Cells[4].Value.ToString()));

					listViewQuatationItems.SelectedItem.Product.QuatationCosts.Add(cost);
				}


				listViewQuatationItems.SetItemsArray(_addedQuatationRecords.ToArray());
			}

			Reset();
		}

		#region private void Reset()

		private void Reset()
	    {
		    dictionaryComboProduct.SelectedItem = null;
		    comboBoxMeasure.SelectedItem = null;
		    comboBoxReason.SelectedItem = null;
		    textBoxPartNumber.Text = "";
		    textBoxProductDesc.Text = "";
		    numericUpDownQuantity.Value = 0;
		    textBoxProductRemarks.Text = "";
		    dataGridViewControlSuppliers.ClearItems();
		    dataGridView1.Rows.Clear();
		    dataGridView1.Columns.Clear();
		    checkBoxNew.Checked = false;
		    checkBoxOverhaul.Checked = false;
		    checkBoxRepair.Checked = false;
		    checkBoxServiceable.Checked = false;
		    comboBoxDestination.SelectedItem = null;
		    lifelengthViewerLifeLimit.Lifelength = new Lifelength();
		    lifelengthViewerNotify.Lifelength = new Lifelength();
	    }

		#endregion

		#region private void comboBoxDestination_SelectedIndexChanged(object sender, EventArgs e)

		private void comboBoxDestination_SelectedIndexChanged(object sender, EventArgs e)
	    {
		    comboBoxDefferedCategory.Items.Clear();

		    var a = comboBoxDestination.SelectedItem as Aircraft;

		    if (a != null)
		    {
			    comboBoxDefferedCategory.Enabled = true;

			    if (a.Model != null)
			    {
				    var categories = _defferedCategories.Where(c => a.Model.Equals(c.AircraftModel)).ToList();
				    categories.Add(DeferredCategory.Unknown);
				    DeferredCategory selected;

				    if(_formType == OrderFormType.Initial)
					    selected = categories.FirstOrDefault(c => c.Equals(listViewInitialItems.SelectedItem.DeferredCategory));
				    else selected = categories.FirstOrDefault(c => c.Equals(listViewQuatationItems.SelectedItem.DeferredCategory));

				    comboBoxDefferedCategory.Items.AddRange(categories.ToArray());
				    comboBoxDefferedCategory.SelectedItem = selected ?? DeferredCategory.Unknown;
			    }
		    }
		    else
		    {
			    comboBoxDefferedCategory.Enabled = false;
		    }
	    }

	    #endregion

		#region private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)

		private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
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
		    Measure measure = comboBoxMeasure.SelectedItem as Measure;
		    if (measure == null || measure.MeasureCategory != MeasureCategory.Mass)
			    numericUpDownQuantity.DecimalPlaces = 0;
		    else numericUpDownQuantity.DecimalPlaces = 2;

		    decimal quantity = numericUpDownQuantity.Value;

		    textBoxTotal.Text = String.Format("{0:0.##}", quantity) + (measure != null ? " " + measure + "(s)" : "");
	    }
		#endregion

		#region private void comboBoxMeasure_SelectedIndexChanged(object sender, EventArgs e)

		private void comboBoxMeasure_SelectedIndexChanged(object sender, EventArgs e)
	    {
		    SetForMeasure();
	    }

		#endregion

		private void listViewQuatationItems_SelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)
		{
			if (listViewQuatationItems.SelectedItem == null) return;

			var product = listViewQuatationItems.SelectedItem.Product;

			dictionaryComboProduct.SelectedItem = product;
			comboBoxMeasure.SelectedItem = product.Measure;
			comboBoxReason.SelectedItem = listViewQuatationItems.SelectedItem.InitialReason;
			textBoxPartNumber.Text = product.PartNumber;
			textBoxProductDesc.Text = product.Description;
			numericUpDownQuantity.Value = (decimal)listViewQuatationItems.SelectedItem.Quantity;
			textBoxProductRemarks.Text = product.Remarks;

			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();

			if (_formType == OrderFormType.Quotation)
			{
				dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Supplier", Width = 170, ReadOnly = true});
				dataGridView1.Columns.Add(new DataGridViewNumericUpDownColumn { HeaderText = "Cost New", Width = 80 });
				dataGridView1.Columns.Add(new DataGridViewNumericUpDownColumn { HeaderText = "Cost OH", Width = 80 });
				dataGridView1.Columns.Add(new DataGridViewNumericUpDownColumn { HeaderText = "Cost Serv", Width = 80 });
				dataGridView1.Columns.Add(new DataGridViewComboBoxColumn() { HeaderText = "Currency" });
				foreach (var relation in product.QuatationCosts)
				{
					var row = new DataGridViewRow { Tag = relation };
					DataGridViewCell from = new DataGridViewTextBoxCell { Value = relation.SupplierName, Tag = relation };
					DataGridViewCell cost = new DataGridViewNumericUpDownCell { Value = relation.Cost, Tag = relation.Cost };
					DataGridViewCell costOH = new DataGridViewNumericUpDownCell { Value = relation.CostOverhaul, Tag = relation.CostOverhaul };
					DataGridViewCell costServ = new DataGridViewNumericUpDownCell { Value = relation.CostServisible, Tag = relation.CostServisible };
					DataGridViewComboBoxCell currence = new DataGridViewComboBoxCell();

					foreach (var c in Сurrency.Items.ToArray())
						currence.Items.Add(c.ToString());
					
					currence.Value = relation.Currency.ToString();
					currence.ValueMember = relation.Currency.ItemId.ToString();

					row.Cells.AddRange(from, cost, costOH, costServ, currence);
					dataGridView1.Rows.Add(row);
				}
			}
			else if (_formType == OrderFormType.Purchase)
			{
				dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn{ HeaderText = "", Width = 20});
				dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Supplier", Width = 140, ReadOnly = true});
				dataGridView1.Columns.Add(new DataGridViewNumericUpDownColumn { HeaderText = "Cost", ReadOnly = true});
				dataGridView1.Columns.Add(new DataGridViewNumericUpDownColumn { HeaderText = "Q-ty", ReadOnly = true});
				foreach (var relation in product.SupplierRelations)
				{
					var row = new DataGridViewRow { Tag = relation };
					DataGridViewCell check = new DataGridViewCheckBoxCell { Value = false };
					DataGridViewCell from = new DataGridViewTextBoxCell { Value = relation.Supplier.Name, Tag = relation.Supplier.Name };
					DataGridViewCell cost = new DataGridViewNumericUpDownCell() { Value = relation.CostNew, Tag = relation.CostNew };
					DataGridViewCell qty = new DataGridViewNumericUpDownCell();
					row.Cells.AddRange(check,from, cost, qty);
					dataGridView1.Rows.Add(row);
				}
			}

			checkBoxNew.Checked = (listViewQuatationItems.SelectedItem.CostCondition & ComponentStatus.New) != 0;
			checkBoxOverhaul.Checked = (listViewQuatationItems.SelectedItem.CostCondition & ComponentStatus.Overhaul) != 0;
			checkBoxRepair.Checked = (listViewQuatationItems.SelectedItem.CostCondition & ComponentStatus.Repair) != 0;
			checkBoxServiceable.Checked = (listViewQuatationItems.SelectedItem.CostCondition & ComponentStatus.Serviceable) != 0;

			var destination =
				destinations.FirstOrDefault(d => d.SmartCoreObjectType == listViewQuatationItems.SelectedItem.DestinationObjectType
				                                 && d.ItemId == listViewQuatationItems.SelectedItem.DestinationObjectId);

			comboBoxDestination.SelectedItem = destination;
			comboBoxPriority.SelectedItem = listViewQuatationItems.SelectedItem.Priority;

			//lifelengthViewerLifeLimit.Lifelength = new Lifelength(listViewQuatationItems.SelectedItem.LifeLimit);
			//lifelengthViewerNotify.Lifelength = new Lifelength(listViewQuatationItems.SelectedItem.LifeLimitNotify);
		}

	}
}
 