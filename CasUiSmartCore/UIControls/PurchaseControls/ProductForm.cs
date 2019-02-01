using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Files;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    /// Форма для редактирования данных о продукте
    ///</summary>
    public partial class ProductForm : CommonEditorForm
    {
        #region Fields
        private Product _currentItem;
        #endregion

	    public Product CurrentProdcuct
	    {
		    get { return _currentItem; } 
		    set { _currentItem = value; }
	    }

	    #region Constructors

        #region public AccessoryDescriptionForm()

        /// <summary>
        /// Простой конструктор без параметров
        /// </summary>
        public ProductForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public AccessoryDescriptionForm(Product currentKit) : this()

        /// <summary>
        /// Создает форму длч редактирования переданного элемента
        /// </summary>
        /// <param name="currentKit">Элемент для редактирования</param>
        /// <param name="comboboxStandartEnabled"></param>
        public ProductForm(Product currentKit, bool comboboxStandartEnabled = true) : this()
        {
            _currentItem = currentKit;
            comboBoxAccessoryStandard.Enabled = comboboxStandartEnabled;

            Task.Run(() =>
            {
                DoLoad();
            }).ContinueWith(task => UpdateInformation(), TaskScheduler.FromCurrentSynchronizationContext());

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

        private void DoLoad()
        {
            var links = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<ItemFileLinkDTO, ItemFileLink>(new List<Filter>()
            {
                new Filter("ParentId",_currentItem.ItemId),
                new Filter("ParentTypeId",_currentItem.SmartCoreObjectType.ItemId)
            }, true);

            _currentItem.Files.AddRange(links);
        }

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            textBoxRemarks.Text = string.Empty;

            comboBoxAccessoryStandard.SelectedIndexChanged -= DictComboStandardSelectedIndexChanged;
			comboBoxAccessoryStandard.SelectedIndexChanged -= ComboBoxAccessoryStandard_SelectedIndexChanged;

			fileControlImage.UpdateInfo(_currentItem.ImageFile,
										   "Image Files|*.jpg;*.jpeg;*.png",
										   "This record does not contain a image. Enclose Image file to prove the compliance.",
										   "Attached file proves the Image.");

            fileControl.UpdateInfo(_currentItem.AttachedFile, "Adobe PDF Files|*.pdf",
                "This record does not contain a file proving the Document. Enclose PDF file to prove the Document.",
                "Attached file proves the Document.");

            textBoxRemarks.Text = string.Empty;
            comboBoxAccessoryStandard.Type = typeof(GoodStandart);
            Program.MainDispatcher.ProcessControl(comboBoxAccessoryStandard);

			comboBoxDetailClass.RootNodesNames = new[] { "OfficeEquipment", "MaintenanceMaterials", "ProductionAuxiliaryEquipment", "Tools", "Protection" };
			comboBoxDetailClass.Type = typeof(GoodsClass);

            comboBoxMeasure.Items.Clear();
            comboBoxMeasure.Items.AddRange(Measure.GetByCategories(new[] { MeasureCategory.Mass, MeasureCategory.EconomicEntity }));

			comboBoxMeasure.Items.Add(Measure.Liter);
			comboBoxMeasure.Items.Add(Measure.Gallon);
			comboBoxMeasure.Items.Add(Measure.Quart);
			comboBoxMeasure.Items.Add(Measure.SquareMeter);
			comboBoxMeasure.Items.Add(Measure.Foot);
			comboBoxMeasure.Items.Add(Measure.Miles);
			comboBoxMeasure.Items.Add(Measure.SquareFoot);
			comboBoxMeasure.Items.Add(Measure.Metres);
			comboBoxMeasure.Items.Add(Measure.Centimeters);

			comboBoxAtaChapter.UpdateInformation();
			comboBoxAtaChapter.ATAChapter = _currentItem.ATAChapter;

	        checkBoxDangerous.Checked = _currentItem.IsDangerous;

			dataGridViewControlSuppliers.ViewedTypeProperties.AddRange(new[]
            {
                KitSuppliersRelation.SupplierProperty,
            });
            dataGridViewControlSuppliers.ViewedType = typeof (KitSuppliersRelation);

            if (_currentItem == null) return;

            comboBoxDetailClass.SelectedItem = _currentItem.GoodsClass;
            comboBoxMeasure.SelectedItem = _currentItem.Measure;
            comboBoxAccessoryStandard.SelectedItem = _currentItem.Standart;
            textBoxName.Text = _currentItem.Name;
            textBoxPartNumber.Text = _currentItem.PartNumber;
            textBoxProductCode.Text = _currentItem.Code;
            textBoxDescription.Text = _currentItem.Description;
            textBoxDescRus.Text = _currentItem.DescRus;
            textBoxHTS.Text = _currentItem.HTS;
            textBoxManufacturer.Text = _currentItem.Manufacturer;
            textBoxRemarks.Text = _currentItem.Remarks;
            textBoxReference.Text = _currentItem.Reference;
            dataGridViewControlSuppliers.SetItemsArray((ICommonCollection) _currentItem.SupplierRelations);

            GoodStandart goodStandart;
            if ((goodStandart = _currentItem.Standart) != null && _currentItem.ItemId <= 0)
            {
                comboBoxDetailClass.SelectedItem = goodStandart.GoodsClass;

                comboBoxDetailClass.Enabled = false;
                //comboBoxMeasure.Enabled = false;
                //textBoxPartNumber.ReadOnly = true;
                //textBoxDescription.ReadOnly = true;

                //comboBoxMeasure.SelectedItem = goodStandart.Measure;
                textBoxName.Text = goodStandart.FullName;
                textBoxPartNumber.Text = goodStandart.PartNumber;
                textBoxDescription.Text = goodStandart.Description;

                //numericCostNew.Value = (decimal)goodStandart.CostNew;
                //numericCostServiceable.Value = (decimal)goodStandart.CostServiceable;
                //numericCostOverhaul.Value = (decimal)goodStandart.CostOverhaul;
            }
            else
            {
                comboBoxDetailClass.SelectedItem = _currentItem.GoodsClass;
                comboBoxDetailClass.Enabled = true;
                //comboBoxMeasure.Enabled = true;
                //textBoxPartNumber.ReadOnly = true;
                //textBoxDescription.ReadOnly = true;

                //comboBoxMeasure.SelectedItem = _currentItem.Measure;
                textBoxPartNumber.Text = _currentItem.PartNumber;
                textBoxDescription.Text = _currentItem.Description;
                textBoxName.Text = _currentItem.Name;

                //numericCostNew.Value = (decimal)_currentItem.CostNew;
                //numericCostServiceable.Value = (decimal)_currentItem.CostServiceable;
                //numericCostOverhaul.Value = (decimal)_currentItem.CostOverhaul;    
            }
            comboBoxMeasure.SelectedItem = _currentItem.Measure;
            textBoxRemarks.Text = _currentItem.Remarks;
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

            comboBoxAccessoryStandard.SelectedIndexChanged += DictComboStandardSelectedIndexChanged;
			comboBoxAccessoryStandard.SelectedIndexChanged += ComboBoxAccessoryStandard_SelectedIndexChanged;

		}
		#endregion

		#region protected override void SetFormControls()
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
            if (comboBoxMeasure.SelectedItem != _currentItem.Measure
                || comboBoxAccessoryStandard.SelectedItem != _currentItem.Standart
                || textBoxPartNumber.Text != _currentItem.PartNumber
                || textBoxProductCode.Text != _currentItem.Code
                || textBoxDescription.Text != _currentItem.Description
                || textBoxDescRus.Text != _currentItem.DescRus
                || textBoxHTS.Text != _currentItem.HTS
                || textBoxManufacturer.Text != _currentItem.Manufacturer
                || textBoxRemarks.Text != _currentItem.Remarks
                || textBoxName.Text != _currentItem.Name
                || textBoxReference.Text != _currentItem.Reference
                || comboBoxAtaChapter.ATAChapter != _currentItem.ATAChapter
                || (comboBoxDetailClass.SelectedItem != _currentItem.GoodsClass)
                || (checkBoxDangerous.Checked != _currentItem.IsDangerous)
                || dataGridViewControlSuppliers.GetChangeStatus()
                || fileControl.GetChangeStatus()
				|| fileControlImage.GetChangeStatus())
                return true;

            if (_currentItem.SupplierRelations.Any(sr => sr.ItemId < 0))
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

			string validateFiles;
			if (!fileControlImage.ValidateData(out validateFiles))
			{
				if (message != "") message += "\n ";
				message += "Image File: " + validateFiles;
			}

			if (comboBoxMeasure.SelectedItem == null)
            {
                if (message != "") message += "\n ";
                message += "Not set measure";
                return false;
            }
            if (textBoxPartNumber.Text == "" && 
                comboBoxAccessoryStandard.Text == "" && 
                comboBoxAccessoryStandard.SelectedItem == null)
            {
                if (message != "") message += "\n ";
                message += "Not set Standart or Part Number";
                return false;
            }
            if (textBoxName.Text == "")
            {
                if (message != "") message += "\n ";
                message += "Not set Name";
                return false;
            }
            if (textBoxManufacturer.Text == "" 
                //&& textBoxSuppliers.Text == ""
                && dataGridViewControlSuppliers.Count == 0)
            {
                if (message != "") message += "\n ";
                message += "Not set Manufacturer or Suppliers";
                return false;
            }

            string m;
            if (!dataGridViewControlSuppliers.ValidateData(out m))
            {
                if (message != "") message += "\n ";
                message += m;
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

        #region protected override void AbortChanges()
        protected override void AbortChanges()
        {
            try
            {
                if (_currentItem.ItemId <= 0)
                {
                    foreach (KitSuppliersRelation relation in _currentItem.SupplierRelations)
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
        protected override void Save()
        {
            try
            {
                GoodStandart standart = comboBoxAccessoryStandard.SelectedItem as GoodStandart;
                string partNumber = textBoxPartNumber.Text.Replace(" ", "").ToLower();
                string standartName = comboBoxAccessoryStandard.Text;
                //string description = textBoxDescription.Text.Replace(" ", "").ToLower();

                List<Product> products = null;
                List<GoodStandart> goodStandarts = null;
                GoodStandart goodStandart = null;
                try
                {
                    goodStandarts = new List<GoodStandart>(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<GoodStandartDTO, GoodStandart>());
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Not Find dictionary of type " + typeof(GoodStandart).Name, ex);
                }

                if (goodStandarts != null)
                {
                    goodStandart = goodStandarts
                        .FirstOrDefault(gs => gs.PartNumber.Replace(" ", "").ToLower() == partNumber
                                           && standart != null && gs.FullName.Replace(" ", "").ToLower() == standart.FullName.Replace(" ", "").ToLower());
                    if (goodStandart == null)
                    {
                        goodStandart = new GoodStandart();
                        goodStandart.GoodsClass = comboBoxDetailClass.SelectedItem as GoodsClass;
                        goodStandart.PartNumber = textBoxPartNumber.Text;
                        goodStandart.Description = textBoxDescription.Text;
                        goodStandart.FullName = standartName.ToLower() == "select item" || standartName.ToLower() == "n/a" ? "N/A" : standartName;
                        //goodStandart.CostNew = (double)numericCostNew.Value;
                        //goodStandart.CostServiceable = (double)numericCostServiceable.Value;
                        //goodStandart.CostOverhaul = (double)numericCostOverhaul.Value;
                        goodStandart.Remarks = textBoxRemarks.Text;
                        //goodStandart.Measure = comboBoxMeasure.SelectedItem as Measure;

                        GlobalObjects.CasEnvironment.Manipulator.Save(goodStandart);
                    }
                    _currentItem.Standart = goodStandart;
                }
                    _currentItem.GoodsClass = comboBoxDetailClass.SelectedItem as GoodsClass;
                    _currentItem.PartNumber = textBoxPartNumber.Text;
                    _currentItem.Description = textBoxDescription.Text;
                    _currentItem.Manufacturer = textBoxManufacturer.Text;
                    _currentItem.Standart = goodStandart;
                    _currentItem.Name = textBoxName.Text;
                    _currentItem.Reference = textBoxReference.Text;
                    _currentItem.Remarks = textBoxRemarks.Text;
                    _currentItem.Measure = comboBoxMeasure.SelectedItem as Measure;

                    fileControl.ApplyChanges();
                    _currentItem.AttachedFile = fileControl.AttachedFile;

                GlobalObjects.CasEnvironment.Manipulator.Save(_currentItem);

                    foreach (KitSuppliersRelation ksr in _currentItem.SupplierRelations)
                    {
                        //if (ksr.ItemId <= 0)
                        //{
                        //    if (ksr.CostNew == 0)
                        //        ksr.CostNew = _currentItem.CostNew;
                        //    if (ksr.CostServiceable == 0)
                        //        ksr.CostServiceable = _currentItem.CostServiceable;
                        //    if (ksr.CostOverhaul == 0)
                        //        ksr.CostOverhaul = _currentItem.CostOverhaul;
                        //}
                        if (ksr.SupplierId != 0)
                        {

                            //_currentKit.SupplierRelations.Add(ksr);
                            ksr.KitId = _currentItem.ItemId;
                            ksr.ParentTypeId = _currentItem.SmartCoreObjectType.ItemId;

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

        #region private void DictComboStandardSelectedIndexChanged(object sender, EventArgs e)
        private void DictComboStandardSelectedIndexChanged(object sender, EventArgs e)
        {
            GoodStandart standart;
            if ((standart = comboBoxAccessoryStandard.SelectedItem as GoodStandart) != null)
            {
                comboBoxDetailClass.SelectedItem = standart.GoodsClass;
                comboBoxDetailClass.Enabled = false;
                //comboBoxMeasure.Enabled = false;
                //textBoxPartNumber.ReadOnly = true;
                //textBoxDescription.ReadOnly = true;
                //textBoxRemarks.ReadOnly = true;

                //comboBoxMeasure.SelectedItem = accessoryDescription.Measure;

                if (_currentItem.ItemId <= 0)
                {
                    textBoxName.Text = standart.FullName;
                    textBoxPartNumber.Text = standart.PartNumber;
                    //numericCostNew.Value = (decimal)accessoryDescription.CostNew;
                    //numericCostServiceable.Value = (decimal)accessoryDescription.CostServiceable;
                    //numericCostOverhaul.Value = (decimal)accessoryDescription.CostOverhaul;
                }
                //if(string.IsNullOrEmpty(_currentKit.Description) || _currentKit.ItemId <= 0)
                //    textBoxDescription.Text = accessoryDescription.Description;
                //textBoxRemarks.Text = accessoryDescription.Remarks;
            }

            if (_currentItem.ItemId > 0)
            {
                textBoxRemarks.Text = _currentItem.Remarks;

				if (standart != null)
                {
                    comboBoxDetailClass.Enabled = false;
                    //comboBoxMeasure.Enabled = false;
                    //textBoxPartNumber.ReadOnly = true;
                    //textBoxDescription.ReadOnly = true;
                }
                else
                {
                    comboBoxDetailClass.Enabled = true;
                    //comboBoxMeasure.Enabled = true;
                    textBoxPartNumber.ReadOnly = false;
                    textBoxName.ReadOnly = false;
                    //textBoxDescription.ReadOnly = false;
                    //textBoxRemarks.ReadOnly = false;
                    //numericCostNew.ReadOnly = false;
                    //numericCostServiceable.ReadOnly = false;
                    //numericCostOverhaul.ReadOnly = false;
                }
            }
            else
            {
                if (standart != null)
                {
                    textBoxRemarks.Text = standart.Remarks;
                }
                comboBoxDetailClass.Enabled = true;
                //comboBoxMeasure.Enabled = true;
                textBoxPartNumber.ReadOnly = false;
                textBoxName.ReadOnly = false;
                //textBoxDescription.ReadOnly = false;
                //textBoxRemarks.ReadOnly = false;
                //numericCostNew.ReadOnly = false;
                //numericCostServiceable.ReadOnly = false;
                //numericCostOverhaul.ReadOnly = false;
            }
        }
		#endregion

		#region private void ComboBoxAccessoryStandard_SelectedIndexChanged(object sender, EventArgs e)

		private void ComboBoxAccessoryStandard_SelectedIndexChanged(object sender, EventArgs e)
		{
			var standart = comboBoxAccessoryStandard.SelectedItem as GoodStandart;

			if (standart != null)
			{
				comboBoxDetailClass.SelectedItem = standart.GoodsClass;
			}
		}

		#endregion


		#endregion
	}
}
