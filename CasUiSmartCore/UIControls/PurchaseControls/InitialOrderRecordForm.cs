using System;
using System.Collections.Generic;
using System.Linq;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EFCore.DTO.Dictionaries;
using EFCore.Filter;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Store;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    /// Форма для редактирования данных о записи в начальном акте
    ///</summary>
    public partial class InitialOrderRecordForm : CommonEditorForm
    {
        #region Fields

        private InitialOrderRecord _currentItem;

        DefferedCategoriesCollection _defferedCategories = new DefferedCategoriesCollection();

        #endregion

        #region Constructors

        #region public InitialOrderRecordForm()

        /// <summary>
        /// Простой конструктор без параметров
        /// </summary>
        public InitialOrderRecordForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public InitialOrderRecordForm(InitionalOrderRecord currentItem, bool comboboxStandartEnabled = true) : this()

        /// <summary>
        /// Создает форму для редактирования записи акта
        /// </summary>
        /// <param name="currentItem">Редактируемая запись акта</param>
        /// <param name="comboboxStandartEnabled"></param>
        public InitialOrderRecordForm(InitialOrderRecord currentItem, bool comboboxStandartEnabled = true)
            : this()
        {
            _currentItem = currentItem;
            dictionaryComboStandard.Enabled = comboboxStandartEnabled;

            UpdateInformation();
        }
        #endregion

        #endregion

        #region Properties

        ///<summary>
        /// Возвращает редактируемый объект
        ///</summary>
        public override BaseEntityObject CurrentObject
        {
            get { return _currentItem; }
        }

        #endregion

        #region Methods

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            textBoxRemarks.Text = string.Empty;

            dictionaryComboStandard.SelectedIndexChanged -= DictComboDescriptionSelectedIndexChanged;
            dictionaryComboProduct.SelectedIndexChanged -= DictionaryComboProductSelectedIndexChanged;

            textBoxRemarks.Text = string.Empty;
            dictionaryComboProduct.SetType(typeof(Product), true);
            dictionaryComboStandard.Type = typeof(GoodStandart);
            Program.MainDispatcher.ProcessControl(dictionaryComboStandard);
            Program.MainDispatcher.ProcessControl(dictionaryComboProduct);

            FormControlAttribute fca = (FormControlAttribute)
                typeof(Product)
                    .GetProperty("GoodsClass")
                    .GetCustomAttributes(typeof(FormControlAttribute), false)
                    .FirstOrDefault();
            if (fca != null)
                comboBoxDetailClass.RootNodesNames = fca.TreeDictRootNodes;
            comboBoxDetailClass.Type = typeof(GoodsClass);

            comboBoxMeasure.Items.Clear();
            comboBoxMeasure.Items.AddRange(Measure.GetByCategories(new[] { MeasureCategory.Mass, MeasureCategory.EconomicEntity }));

            dataGridViewControlSuppliers.ViewedTypeProperties.AddRange(new[]
            {
                KitSuppliersRelation.SupplierProperty,
            });
            dataGridViewControlSuppliers.ViewedType = typeof(KitSuppliersRelation);

            _defferedCategories.Clear();
            _defferedCategories.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<DefferedCategorieDTO, DeferredCategory>(loadChild:true));


            List<BaseEntityObject> destinations = new List<BaseEntityObject>();
            destinations.AddRange(GlobalObjects.AircraftsCore.GetAllAircrafts().ToArray());
            destinations.AddRange(GlobalObjects.CasEnvironment.Stores.GetValidEntries());
            destinations.AddRange(GlobalObjects.CasEnvironment.Hangars.GetValidEntries());

            comboBoxDestination.Items.Clear();
            comboBoxDestination.Items.AddRange(destinations.ToArray());

            comboBoxReason.Items.Clear();
            comboBoxReason.Items.AddRange(InitialReason.Items.ToArray());

            //comboBoxDefferedCategory.Items.Clear();
            //comboBoxDefferedCategory.Items.AddRange(defferedCategories.ToArray());
            //comboBoxDefferedCategory.SelectedItem = _currentKit.DeferredCategory;

            if (_currentItem == null) return;

            Product product = _currentItem.Product;

            comboBoxDetailClass.SelectedItem = product.GoodsClass;
            dictionaryComboProduct.SelectedItem = product;
            comboBoxMeasure.SelectedItem = product.Measure;
            comboBoxReason.SelectedItem = _currentItem.InitialReason;
            dictionaryComboStandard.SelectedItem = product.Standart;
            textBoxPartNumber.Text = product.PartNumber;
            textBoxDescription.Text = product.Description;
            textBoxManufacturer.Text = product.Manufacturer;
            numericUpDownQuantity.Value = (decimal)_currentItem.Quantity;
            textBoxRemarks.Text = product.Remarks;
            dataGridViewControlSuppliers.SetItemsArray((ICommonCollection) product.SupplierRelations);
            dateTimePickerEffDate.Value = _currentItem.EffectiveDate;
            checkBoxNew.Checked = (_currentItem.CostCondition & ComponentStatus.New) != 0;
            checkBoxOverhaul.Checked = (_currentItem.CostCondition & ComponentStatus.Overhaul) != 0;
            checkBoxRepair.Checked = (_currentItem.CostCondition & ComponentStatus.Repair) != 0;
            checkBoxServiceable.Checked = (_currentItem.CostCondition & ComponentStatus.Serviceable) != 0;

            BaseEntityObject destination = 
                destinations.FirstOrDefault(d => d.SmartCoreObjectType == _currentItem.DestinationObjectType 
                                              && d.ItemId == _currentItem.DestinationObjectId);

            comboBoxDestination.SelectedItem = destination;

            lifelengthViewerLifeLimit.Lifelength = new Lifelength(_currentItem.LifeLimit);
            lifelengthViewerNotify.Lifelength = new Lifelength(_currentItem.LifeLimitNotify);

            GoodStandart goodStandart;
            if ((goodStandart = product.Standart) != null)
            {
                if (_currentItem.ItemId <= 0)
                {
                    comboBoxDetailClass.SelectedItem = goodStandart.GoodsClass;

                    comboBoxDetailClass.Enabled = false;
                    //comboBoxMeasure.Enabled = false;
                    //textBoxPartNumber.ReadOnly = true;
                    //textBoxDescription.ReadOnly = true;

                    //comboBoxMeasure.SelectedItem = goodStandart.Measure;
                    textBoxPartNumber.Text = goodStandart.PartNumber;
                    textBoxDescription.Text = goodStandart.Description;

                    numericUpDownQuantity.Value = (decimal)_currentItem.Quantity;
                    //numericCostNew.Value = (decimal)goodStandart.CostNew;
                    //numericCostServiceable.Value = (decimal)goodStandart.CostServiceable;
                    //numericCostOverhaul.Value = (decimal)goodStandart.CostOverhaul;    
                }
                else
                {
                    comboBoxDetailClass.SelectedItem = goodStandart.GoodsClass;

                    comboBoxDetailClass.Enabled = false;
                    //comboBoxMeasure.Enabled = false;
                    //textBoxPartNumber.ReadOnly = true;
                    //textBoxDescription.ReadOnly = true;

                    //comboBoxMeasure.SelectedItem = goodStandart.Measure;
                    textBoxPartNumber.Text = goodStandart.PartNumber;
                    textBoxDescription.Text = goodStandart.Description;

                    numericUpDownQuantity.Value = (decimal)_currentItem.Quantity;
                    //numericCostNew.Value = (decimal)goodStandart.CostNew;
                    //numericCostServiceable.Value = (decimal)goodStandart.CostServiceable;
                    //numericCostOverhaul.Value = (decimal)goodStandart.CostOverhaul;
                }
            }
            else
            {
                comboBoxDetailClass.SelectedItem = product.GoodsClass;

                comboBoxDetailClass.Enabled = true;
                comboBoxMeasure.Enabled = true;
                //textBoxPartNumber.ReadOnly = true;
                //textBoxDescription.ReadOnly = true;

                comboBoxMeasure.SelectedItem = product.Measure;
                textBoxPartNumber.Text = product.PartNumber;
                textBoxDescription.Text = product.Description;

                numericUpDownQuantity.Value = (decimal)_currentItem.Quantity;   
            }
            textBoxRemarks.Text = product.Remarks;
            //else
            //{
            //    //comboBoxDetailClass.SelectedItem = DetailClass.Kit;
            //    //comboBoxDetailClass.Enabled = true;
            //    //textBoxPartNumber.ReadOnly = true;
            //    //textBoxDescription.ReadOnly = true;
            //    //textBoxManufacturer.ReadOnly = true;
            //    //textBoxRemarks.ReadOnly = true;
            //    //numericCostNew.ReadOnly = true;
            //    //numericCostServiceable.ReadOnly = true;
            //    //numericCostOverhaul.ReadOnly = true;
            //    //textBoxSuppliers.ReadOnly = true;
            //    //linkLabelEditSupplier.Enabled = true;
            //}
            //if (_currentKit.ItemId > 0)
            //{
            //    Product accessoryDescription;
            //    if((accessoryDescription = comboBoxAccessoryDescription.SelectedItem as Product) != null)
            //    {
            //        comboBoxAccessoryDescription.Enabled = accessoryDescription.IsDeleted;
            //    }
            //    else comboBoxAccessoryDescription.Enabled = true;

            //    //////////////////////////////////////////////
            //    ////загрузка котировочных ордеров для определения 
            //    ////того, можно ли менять партийный и серийный номер данного агрегата
            //    //List<RequestForQuotation> closedQuotations = new List<RequestForQuotation>();
            //    //List<PurchaseOrder> closedPurchases = new List<PurchaseOrder>();
            //    //try
            //    //{
            //    //    closedQuotations.AddRange(GlobalObjects.CasEnvironment.Loader.GetRequestForQuotation(null,
            //    //                                                                         WorkPackageStatus.Closed,
            //    //                                                                         false,
            //    //                                                                         new CommonCollection<AbstractAccessory> { _currentKit }));
            //    //    closedPurchases.AddRange(GlobalObjects.CasEnvironment.Loader.GetPurchaseOrders(null,
            //    //                                                                         WorkPackageStatus.Closed,
            //    //                                                                         false,
            //    //                                                                         new CommonCollection<AbstractAccessory> { _currentKit }));
            //    //    textBoxPartNumber.ReadOnly = (closedQuotations.Count > 0 || closedPurchases.Count > 0);
            //    //}
            //    //catch (Exception exception)
            //    //{
            //    //    Program.Provider.Logger.Log("Error while loading requestes for detail", exception);
            //    //}
            //}

            dictionaryComboStandard.SelectedIndexChanged += DictComboDescriptionSelectedIndexChanged;
            dictionaryComboProduct.SelectedIndexChanged += DictionaryComboProductSelectedIndexChanged;
        }
        #endregion

        #region protected override void SetFormControls()
        /// <summary>
        /// производит генерацию элементов управления
        /// </summary>
        protected override void SetFormControls()
        {
            
        }
        #endregion

        #region protected override bool GetChangeStatus()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        protected override bool GetChangeStatus()
        {
            Product product = _currentItem.Product;

            if (dictionaryComboProduct.SelectedItem != _currentItem.Product 
                || comboBoxMeasure.SelectedItem != _currentItem.Measure
                || comboBoxDefferedCategory.SelectedItem != _currentItem.DeferredCategory
                || comboBoxDestination.SelectedItem != _currentItem.DestinationObject
                || comboBoxReason.SelectedItem != _currentItem.InitialReason
                || !lifelengthViewerLifeLimit.Lifelength.Equals(_currentItem.LifeLimit)
                || !lifelengthViewerNotify.Lifelength.Equals(_currentItem.LifeLimitNotify)
                || dictionaryComboStandard.SelectedItem != product.Standart
                || textBoxPartNumber.Text != product.PartNumber
                || textBoxDescription.Text != product.Description
                || textBoxManufacturer.Text != product.Manufacturer
                || textBoxRemarks.Text != product.Remarks
                || numericUpDownQuantity.Value != (decimal)_currentItem.Quantity
                || (comboBoxDetailClass.SelectedItem != product.GoodsClass)
                || dateTimePickerEffDate.Value != _currentItem.EffectiveDate
                || comboBoxMeasure.SelectedItem != _currentItem.Measure
                || checkBoxNew.Checked != ((_currentItem.CostCondition & ComponentStatus.New) != 0)
                || checkBoxOverhaul.Checked != ((_currentItem.CostCondition & ComponentStatus.Overhaul) != 0)
                || checkBoxRepair.Checked != ((_currentItem.CostCondition & ComponentStatus.Repair) != 0)
                || checkBoxServiceable.Checked != ((_currentItem.CostCondition & ComponentStatus.Serviceable) != 0))
                return true;

            if (product.SupplierRelations.Any(sr => sr.ItemId < 0))
                return true;
            return false;
        }
        #endregion

        #region protected override public ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        protected override bool ValidateData(out string message)
        {
            message = "";

            if (dictionaryComboProduct.Text == "N/A" || dictionaryComboProduct.Text == "Select Item" ||
                dictionaryComboProduct.SelectedItem == null && _currentItem.ItemId > 0)
            {
                if (message != "") message += "\n ";
                message += "Not set Product";
                return false;
            }
            if (comboBoxMeasure.SelectedItem == null)
            {
                if (message != "") message += "\n ";
                message += "Not set measure";
                return false;
            }
            if (textBoxPartNumber.Text == "" && 
                dictionaryComboStandard.Text == "" && 
                dictionaryComboStandard.SelectedItem == null)
            {
                if (message != "") message += "\n ";
                message += "Not set Standart or Part Number";
                return false;
            }
            if (textBoxDescription.Text == "")
            {
                if (message != "") message += "\n ";
                message += "Not set Description";
                return false;
            }
            if (textBoxManufacturer.Text == "")
            {
                if (message != "") message += "\n ";
                message += "Not set Manufacturer";
                return false;
            }
            if (comboBoxMeasure.SelectedItem as Measure == null)
            {
                if (message != "") message += "\n ";
                message += "Not set Measure";
                return false;
            }

            return true;
        }

        #endregion

        #region protected override bool ApplyChanges()
        ///<summary>
        /// Прозводит присванивание значений из контролов в с свойства редактируемого объекта
        ///</summary>
        ///<returns></returns>
        protected override void ApplyChanges()
        {
            //DetailClass detailClass = DetailClass.Component;
            //DetailType detailType = DetailType.Unknown;
            //if (comboBoxDetailClass.SelectedItem is DetailClass)
            //{
            //    detailClass = (DetailClass)comboBoxDetailClass.SelectedItem;
            //    detailType = DetailType.Unknown;
            //}
            //else if (comboBoxDetailClass.SelectedItem is DetailType)
            //{
            //    detailType = (DetailType)comboBoxDetailClass.SelectedItem;
            //    detailClass = DetailClass.Component;
            //}

            //_currentKit.DetailClass = detailClass;
            //_currentKit.DetailType = detailType;
            //_currentKit.Standart = comboBoxAccessoryDescription.SelectedItem as GoodStandart ?? GoodStandart.Unknown;
            //_currentKit.PartNumber = string.IsNullOrEmpty(textBoxPartNumber.Text) ? "N/A" : textBoxPartNumber.Text;
            //_currentKit.Description = textBoxDescription.Text;
            _currentItem.Product = dictionaryComboProduct.SelectedItem as Product;
            //_currentKit.Manufacturer = textBoxManufacturer.Text;
            _currentItem.Measure = comboBoxMeasure.SelectedItem as Measure ?? Measure.Unknown;
            _currentItem.Quantity = (double)numericUpDownQuantity.Value;
            _currentItem.DeferredCategory = comboBoxDefferedCategory.SelectedItem as DeferredCategory ?? DeferredCategory.Unknown;

            ComponentStatus costCondition = ComponentStatus.Unknown;
            if (checkBoxNew.Checked)
                costCondition = costCondition | ComponentStatus.New;
            if (checkBoxServiceable.Checked)
                costCondition = costCondition | ComponentStatus.Serviceable;
            if (checkBoxOverhaul.Checked)
                costCondition = costCondition | ComponentStatus.Overhaul;
            if (checkBoxRepair.Checked)
                costCondition = costCondition | ComponentStatus.Repair;

            _currentItem.CostCondition = costCondition;

            BaseEntityObject destination = comboBoxDestination.SelectedItem as BaseEntityObject;
            if (destination != null)
            {
                _currentItem.DestinationObjectType = destination.SmartCoreObjectType;
                _currentItem.DestinationObjectId = destination.ItemId;
            }
            else
            {
                _currentItem.DestinationObjectType = SmartCoreType.Unknown;
                _currentItem.DestinationObjectId = -1;
            }
            _currentItem.InitialReason = comboBoxReason.SelectedItem as InitialReason ?? InitialReason.Unknown;
            _currentItem.LifeLimit = lifelengthViewerLifeLimit.Lifelength;
            _currentItem.LifeLimitNotify = lifelengthViewerNotify.Lifelength;
            _currentItem.EffectiveDate = dateTimePickerEffDate.Value;
            //_currentKit.Remarks = textBoxRemarks.Text;
        }
        #endregion

        #region protected override void AbortChanges()
        /// <summary>
        /// Производит отмену примененных изменений
        /// </summary>
        protected override void AbortChanges()
        {
            try
            {
                Product product = _currentItem.Product;

                if (_currentItem.ItemId <= 0)
                {
                    foreach (KitSuppliersRelation relation in product.SupplierRelations)
                    {
                        GlobalObjects.CasEnvironment.Manipulator.Delete(relation, false);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save consumable part", ex);
            }
        }
        #endregion

        #region protected override void Save()
        /// <summary>
        /// Производит сохранение информации
        /// </summary>
        protected override void Save()
        {
            try
            {
                //DetailClass detailClass = DetailClass.Component;
                //DetailType detailType = DetailType.Unknown;
                GoodStandart standart = dictionaryComboStandard.SelectedItem as GoodStandart;
                string partNumber = textBoxPartNumber.Text.Replace(" ", "").ToLower();
                //string standartName = comboBoxAccessoryDescription.Text;
                ////string description = textBoxDescription.Text.Replace(" ", "").ToLower();
                //if (comboBoxDetailClass.SelectedItem is DetailClass)
                //{
                //    detailClass = (DetailClass)comboBoxDetailClass.SelectedItem;
                //    detailType = DetailType.Unknown;
                //}
                //else if (comboBoxDetailClass.SelectedItem is DetailType)
                //{
                //    detailType = (DetailType)comboBoxDetailClass.SelectedItem;
                //    detailClass = DetailClass.Component;
                //}

                List<Product> products = null;
                //List<GoodStandart> goodStandarts = null;
                //GoodStandart goodStandart = null;
                //try
                //{
                //    goodStandarts = GlobalObjects.CasEnvironment.Loader.GetObjectList<GoodStandart>();
                //}
                //catch (Exception ex)
                //{
                //    Program.Provider.Logger.Log("Not Find dictionary of type " + typeof(GoodStandart).Name, ex);
                //}
                try
                {
                    products = new List<Product>(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<AccessoryDescriptionDTO, Product>(new Filter("ModelingObjectTypeId", -1),true));
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Not Find dictionary of type " + typeof(Product).Name, ex);
                }
                //if (goodStandarts != null)
                //{
                //    goodStandart = goodStandarts
                //        .FirstOrDefault(ad => ad.PartNumber.Replace(" ", "").ToLower() == partNumber
                //                           && standart != null && ad.FullName.Replace(" ", "").ToLower() == standart.FullName.Replace(" ", "").ToLower());
                //    if (goodStandart == null)
                //    {
                //        goodStandart = new GoodStandart();
                //        goodStandart.DetailClass = detailClass;
                //        goodStandart.DetailType = detailType;
                //        goodStandart.PartNumber = textBoxPartNumber.Text;
                //        goodStandart.Description = textBoxDescription.Text;
                //        goodStandart.FullName = standartName.ToLower() == "select item" || standartName.ToLower() == "n/a" ? "N/A" : standartName;
                //        goodStandart.CostNew = (double)numericCostNew.Value;
                //        goodStandart.CostServiceable = (double)numericCostServiceable.Value;
                //        goodStandart.CostOverhaul = (double)numericCostOverhaul.Value;
                //        goodStandart.Remarks = textBoxRemarks.Text;
                //        goodStandart.Measure = comboBoxMeasure.SelectedItem as Measure;

                //        GlobalObjects.CasEnvironment.Manipulator.Save(goodStandart);
                //    }
                //    _currentKit.Standart = goodStandart;
                //}
                if (products != null)
                {
                    Product exist = products
                        .FirstOrDefault(p => p.PartNumber.Replace(" ", "").ToLower() == partNumber
                                             && (standart != null && p.Standart != null && p.Standart.FullName.Replace(" ", "").ToLower() == standart.FullName.Replace(" ", "").ToLower()));
                    if (exist != null)
                    {
                        _currentItem.Product = exist;
                    }
                    //_currentKit.DetailClass = detailClass;
                    //_currentKit.DetailType = detailType;
                    //_currentKit.PartNumber = textBoxPartNumber.Text;
                    //_currentKit.Description = textBoxDescription.Text;
                    //_currentKit.Manufacturer = textBoxManufacturer.Text;
                    //_currentKit.Standart = goodStandart;
                    _currentItem.Quantity = (double)numericUpDownQuantity.Value;
                    //_currentKit.Remarks = textBoxRemarks.Text;
                    _currentItem.Measure = comboBoxMeasure.SelectedItem as Measure;

                    GlobalObjects.CasEnvironment.Manipulator.Save(_currentItem);

                    Product product = _currentItem.Product;

                    foreach (KitSuppliersRelation ksr in product.SupplierRelations)
                    {
                        if (ksr.SupplierId != 0)
                        {

                            //_currentKit.SupplierRelations.Add(ksr);
                            ksr.KitId = product.ItemId;
                            ksr.ParentTypeId = product.SmartCoreObjectType.ItemId;

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

                //GlobalObjects.CasEnvironment.Manipulator.Save(_currentKit);

                //foreach (KitSuppliersRelation relation in _currentKit.SupplierRelations)
                //{
                //    if (relation.SupplierId != 0)
                //    {
                //        relation.KitId = _currentKit.ItemId;
                //        GlobalObjects.CasEnvironment.Keeper.Save(relation);
                //    }
                //}
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
            }
        }
        #endregion

        #region private void DictComboDescriptionSelectedIndexChanged(object sender, EventArgs e)
        private void DictComboDescriptionSelectedIndexChanged(object sender, EventArgs e)
        {
            GoodStandart accessoryDescription;
            if ((accessoryDescription = dictionaryComboStandard.SelectedItem as GoodStandart) != null)
            {
                comboBoxDetailClass.SelectedItem = accessoryDescription.GoodsClass;

                comboBoxDetailClass.Enabled = false;
                comboBoxMeasure.Enabled = false;
                //textBoxPartNumber.ReadOnly = true;
                //textBoxDescription.ReadOnly = true;
                //textBoxRemarks.ReadOnly = true;

                //comboBoxMeasure.SelectedItem = accessoryDescription.Measure;

                if (_currentItem.ItemId <= 0)
                    textBoxPartNumber.Text = accessoryDescription.PartNumber;
                //if(string.IsNullOrEmpty(_currentKit.Description) || _currentKit.ItemId <= 0)
                //    textBoxDescription.Text = accessoryDescription.Description;
                //textBoxRemarks.Text = accessoryDescription.Remarks;
                numericUpDownQuantity.Value = (decimal)_currentItem.Quantity;
                //numericCostNew.Value = (decimal)accessoryDescription.CostNew;
                //numericCostServiceable.Value = (decimal)accessoryDescription.CostServiceable;
                //numericCostOverhaul.Value = (decimal)accessoryDescription.CostOverhaul;
            }

            if (_currentItem.ItemId > 0)
            {
                textBoxRemarks.Text = _currentItem.Product != null ? _currentItem.Product.Remarks : "";

                if (accessoryDescription != null)
                {
                    comboBoxDetailClass.Enabled = false;
                    comboBoxMeasure.Enabled = false;
                    //textBoxPartNumber.ReadOnly = true;
                    //textBoxDescription.ReadOnly = true;
                }
                else
                {
                    comboBoxDetailClass.Enabled = true;
                    comboBoxMeasure.Enabled = true;
                    textBoxPartNumber.ReadOnly = false;
                    //textBoxDescription.ReadOnly = false;
                    //textBoxRemarks.ReadOnly = false;
                }
            }
            else
            {
                if (accessoryDescription != null)
                {
                    textBoxRemarks.Text = accessoryDescription.Remarks;
                }
                comboBoxDetailClass.Enabled = true;
                comboBoxMeasure.Enabled = true;
                textBoxPartNumber.ReadOnly = false;
                //textBoxDescription.ReadOnly = false;
                //textBoxRemarks.ReadOnly = false;
            }
        }
        #endregion

        #region private void DictionaryComboProductSelectedIndexChanged(object sender, EventArgs e)
        private void DictionaryComboProductSelectedIndexChanged(object sender, EventArgs e)
        {
            dictionaryComboStandard.SelectedIndexChanged -= DictComboDescriptionSelectedIndexChanged;

            Product accessoryDescription;
            if ((accessoryDescription = dictionaryComboProduct.SelectedItem as Product) != null)
            {
                comboBoxDetailClass.SelectedItem = accessoryDescription.GoodsClass;

                comboBoxDetailClass.Enabled = false;
                comboBoxMeasure.Enabled = false;
                dictionaryComboStandard.Enabled = false;
                textBoxPartNumber.ReadOnly = true;
                textBoxDescription.ReadOnly = true;
                textBoxManufacturer.ReadOnly = true;
                //textBoxProductCode.ReadOnly = true;
                dataGridViewControlSuppliers.ReadOnly = true;
                //textBoxRemarks.ReadOnly = true;

                comboBoxMeasure.SelectedItem = accessoryDescription.Measure;
                dictionaryComboStandard.SelectedItem = accessoryDescription.Standart;
                textBoxPartNumber.Text = accessoryDescription.PartNumber;
                textBoxDescription.Text = accessoryDescription.Description;
                //textBoxProductCode.Text = accessoryDescription.Code;
                textBoxManufacturer.Text = accessoryDescription.Manufacturer;
                dataGridViewControlSuppliers.SetItemsArray((ICommonCollection) accessoryDescription.SupplierRelations);
                //textBoxRemarks.Text = accessoryDescription.Remarks;
            }

            if (_currentItem.ItemId > 0)
            {
                textBoxRemarks.Text = _currentItem.AccessoryRemarks;

                if (accessoryDescription != null)
                {
                    comboBoxDetailClass.Enabled = false;
                    comboBoxMeasure.Enabled = false;
                    dictionaryComboStandard.Enabled = false;
                    textBoxPartNumber.ReadOnly = true;
                    textBoxDescription.ReadOnly = true;
                    textBoxManufacturer.ReadOnly = true;
                    //textBoxProductCode.ReadOnly = true;
                    dataGridViewControlSuppliers.ReadOnly = true;
                    //textBoxRemarks.ReadOnly = true;

                    dataGridViewControlSuppliers.SetItemsArray((ICommonCollection) accessoryDescription.SupplierRelations);
                }
                else
                {
                    comboBoxDetailClass.Enabled = true;
                    comboBoxMeasure.Enabled = true;
                    dictionaryComboStandard.Enabled = true;
                    textBoxPartNumber.ReadOnly = false;
                    textBoxDescription.ReadOnly = false;
                    textBoxManufacturer.ReadOnly = false;
                    //textBoxProductCode.ReadOnly = false;
                    dataGridViewControlSuppliers.ReadOnly = false;
                    //textBoxRemarks.ReadOnly = false;
                    //numericCostNew.ReadOnly = false;
                    //numericCostServiceable.ReadOnly = false;
                    //numericCostOverhaul.ReadOnly = false;
                }
            }
            else
            {
                if (accessoryDescription != null)
                {
                    textBoxRemarks.Text = accessoryDescription.Remarks;
                    dataGridViewControlSuppliers.SetItemsArray((ICommonCollection) accessoryDescription.SupplierRelations);
                }
                comboBoxDetailClass.Enabled = true;
                comboBoxMeasure.Enabled = true;
                dictionaryComboStandard.Enabled = true;
                textBoxPartNumber.ReadOnly = false;
                textBoxDescription.ReadOnly = false;
                //textBoxProductCode.ReadOnly = false;
                dataGridViewControlSuppliers.ReadOnly = false;
                //textBoxRemarks.ReadOnly = false;
                //numericCostNew.ReadOnly = false;
                //numericCostServiceable.ReadOnly = false;
                //numericCostOverhaul.ReadOnly = false;
            }

            dictionaryComboStandard.SelectedIndexChanged += DictComboDescriptionSelectedIndexChanged;
        }
        #endregion

        #region private void SetForDetailClass()
        /// <summary>
        /// Изменяет контрол в соотствествии с выбранным классом детали
        /// </summary>
        private void SetForDetailClass()
        {
            GoodsClass dc = comboBoxDetailClass.SelectedItem as GoodsClass;
            if (dc == null)
            {
                comboBoxMeasure.Enabled = true;
                comboBoxMeasure.SelectedItem = _currentItem.Measure;
                numericUpDownQuantity.DecimalPlaces = 2;
            }
            else if (dc.IsNodeOrSubNodeOf(GoodsClass.ComponentsAndParts))
            {
                comboBoxMeasure.Enabled = false;
                comboBoxMeasure.SelectedItem = Measure.Unit;
                numericUpDownQuantity.DecimalPlaces = 0;
            }
            else if (dc.IsNodeOrSubNodeOf(GoodsClass.ComponentsAndParts))
            {
                comboBoxMeasure.Enabled = false;
                comboBoxMeasure.SelectedItem = Measure.Unit;
                numericUpDownQuantity.DecimalPlaces = 0;
            }
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

        #region private void EnableLifelengthControls(bool isEnable)
        ///<summary>
        ///</summary>
        ///<param name="isEnable"></param>
        private void EnableLifelengthControls(bool isEnable)
        {
            lifelengthViewerLifeLimit.Enabled = isEnable;
            lifelengthViewerNotify.Enabled = isEnable;
        }
        #endregion

        #region private void ComboBoxDetailClassSelectedIndexChanged(object sender, EventArgs e)

        private void ComboBoxDetailClassSelectedIndexChanged(object sender, EventArgs e)
        {
            SetForDetailClass();
        }
        #endregion

        #region private void ComboBoxMeasureSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxMeasureSelectedIndexChanged(object sender, EventArgs e)
        {
            SetForMeasure();
        }
        #endregion

        #region private void ComboBoxDestinationSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxDestinationSelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDefferedCategory.Items.Clear();
            
            Aircraft a = comboBoxDestination.SelectedItem as Aircraft;

            if (a != null)
            {
                comboBoxDefferedCategory.Enabled = true;

                if (a.Model != null)
                {
                    List<DeferredCategory> categories =
                        _defferedCategories.Where(c => a.Model.Equals(c.AircraftModel)).ToList();
                    categories.Add(DeferredCategory.Unknown);
                    DeferredCategory selected =
                        categories.FirstOrDefault(c => c.Equals(_currentItem.DeferredCategory));

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

        #region private void ComboBoxReasonSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxReasonSelectedIndexChanged(object sender, EventArgs e)
        {
            //if(comboBoxReason.SelectedItem == InitionalReason.DefectCrew)
        }
        #endregion

        #region private void ComboBoxDeferredCategorySelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxDeferredCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            DeferredCategory selectedCategory = comboBoxDefferedCategory.SelectedItem as DeferredCategory;

            if (selectedCategory == null)
            {
                EnableLifelengthControls(true);
            }
            else
            {
                char name = char.ToUpper(selectedCategory.FullName.ToCharArray()[0]);

                if (name == 'A' || selectedCategory == DeferredCategory.Unknown) EnableLifelengthControls(true);
                else
                {
                    selectedCategory.Threshold.FirstPerformanceConditionType = ThresholdConditionType.WhicheverFirst;
                    selectedCategory.Threshold.RepeatPerformanceConditionType = ThresholdConditionType.WhicheverFirst;
                    selectedCategory.Threshold.PerformRepeatedly = true;
                    selectedCategory.Threshold.PerformSinceEffectiveDate = true;
                    selectedCategory.Threshold.PerformSinceNew = true;

                    lifelengthViewerLifeLimit.Lifelength = new Lifelength(selectedCategory.Threshold.FirstPerformanceSinceEffectiveDate);
                    lifelengthViewerNotify.Lifelength = new Lifelength(selectedCategory.Threshold.FirstNotification);

                    EnableLifelengthControls(false);
                }
            }
        }
        #endregion

        #region private void NumericUpDownQuantityValueChanged(object sender, EventArgs e)

        private void NumericUpDownQuantityValueChanged(object sender, EventArgs e)
        {
            SetForMeasure();
        }
        #endregion

        #endregion

    }
}
