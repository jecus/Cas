using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.DocumentationControls;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using CASTerms;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Store;
using SmartCore.Filters;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.SupplierControls
{
    ///<summary>
    ///</summary>
    public partial class SupplierForm : Form
    {
        #region Fields
        private readonly Supplier _currentSupplier;
        private readonly List<Document> _documents = new List<Document>();
        private readonly List<Product> _products = new List<Product>(); 
        #endregion

        #region Properties
        #endregion

        #region Constructors
        
        #region public SupplireForm()
        /// <summary>
        /// Пустой конструктор (вызывается при создании нового объекта)
        /// </summary>
        public SupplierForm()
        {
            _currentSupplier=new Supplier();
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region public SupplireForm(Supplier supplier)
        /// <summary>
        /// Конструктор (вызывается для редактирования элемента)
        /// </summary>
        /// <param name="supplier">Элемент который нужно редактировать</param>
        public SupplierForm(Supplier supplier)
        {
            _currentSupplier = supplier;
            InitializeComponent();
            UpdateInformation();

        }

        #endregion
        
        #endregion

        #region Methods

        #region private void UpdateInformation()
        /// <summary>
        /// Загружает данные из экзепляра Supplier в контролы для редактирования
        /// </summary>
        private void UpdateInformation()
        {
            textBoxName.Text = _currentSupplier.Name;
            textBoxShortName.Text = _currentSupplier.ShortName;
            textBoxAirCode.Text = _currentSupplier.AirCode;
            textBoxVendorCode.Text = _currentSupplier.VendorCode;
            textBoxPhone.Text = _currentSupplier.Phone;
            textBoxFax.Text = _currentSupplier.Fax;
            textBoxAddress.Text = _currentSupplier.Address;
            textBoxAccount.Text = _currentSupplier.ContactPerson;
            textBoxEmail.Text = _currentSupplier.Email;
            textBoxWebSite.Text = _currentSupplier.WebSite;
            textBoxRemarks.Text = _currentSupplier.Remarks;
            textBoxSubject.Text = _currentSupplier.Subject;

            checkBoxApproved.Checked = _currentSupplier.Approved;


			var fca = (FormControlAttribute)
				typeof(Supplier)
					.GetProperty("SupplierClass")
					.GetCustomAttributes(typeof(FormControlAttribute), false)
					.FirstOrDefault();
			if (fca != null)
				comboBoxSupplierClass.RootNodesNames = fca.TreeDictRootNodes;
			comboBoxSupplierClass.Type = typeof(SupplierClass);
			comboBoxSupplierClass.SelectedItem = _currentSupplier.SupplierClass;


			_documents.Clear();
            _documents.AddRange(_currentSupplier.SupplierDocs.ToArray());

            foreach (Document document in _documents)
                GlobalObjects.PerformanceCalculator.GetNextPerformance(document);

            documentationListView.SetItemsArray(_documents.ToArray());


			_products.Clear();
		    _products.AddRange(GlobalObjects.PurchaseCore.GetProducts(_currentSupplier).ToArray());

			dataGridViewControlSuppliers.ViewedTypeProperties.Clear();
			dataGridViewControlSuppliers.ViewedTypeProperties.AddRange(new[]
			{
				Product.NameProperty,
				Product.PartNumberProperty,
				Product.DescriptionProperty,
			});
			dataGridViewControlSuppliers.ViewedType = typeof(Product);
	        dataGridViewControlSuppliers.SetItemsArray(_products.ToArray());
			
			documentationListView.Focus();
        }                                                            

        #endregion

        #region private bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        private bool GetChangeStatus()
        {
            if (_currentSupplier.Name != textBoxName.Text
                || _currentSupplier.ShortName != textBoxShortName.Text
                || _currentSupplier.AirCode != textBoxAirCode.Text
                || _currentSupplier.Phone != textBoxPhone.Text
                || _currentSupplier.Address != textBoxAddress.Text
                || _currentSupplier.ContactPerson != textBoxAccount.Text
                || _currentSupplier.Email != textBoxEmail.Text
                || _currentSupplier.VendorCode != textBoxVendorCode.Text
                || _currentSupplier.Fax != textBoxFax.Text
                || _currentSupplier.WebSite != textBoxWebSite.Text
                || _currentSupplier.Remarks != textBoxRemarks.Text
                || _currentSupplier.Subject != textBoxSubject.Text
                || _currentSupplier.Approved != checkBoxApproved.Checked
				|| _currentSupplier.SupplierClass != comboBoxSupplierClass.SelectedItem as SupplierClass)
            {
                return true;
            }
	        return false;
        }

        #endregion

        #region private bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool ValidateData(out string message)
        {
            message = "";

            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                if (message != "")
                    message += "\n";
                message += "Not set Supplier Name";

                textBoxName.Focus();

                return false;
            }

            return true;
        }

        #endregion

        #region private void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        private void ApplyChanges()
        {
            _currentSupplier.Name = textBoxName.Text;
            _currentSupplier.ShortName = textBoxShortName.Text;
            _currentSupplier.AirCode = textBoxAirCode.Text;
            _currentSupplier.Phone = textBoxPhone.Text;
            _currentSupplier.Address = textBoxAddress.Text;
            _currentSupplier.ContactPerson = textBoxAccount.Text;
            _currentSupplier.Email = textBoxEmail.Text;
            _currentSupplier.VendorCode = textBoxVendorCode.Text;
            _currentSupplier.Fax = textBoxFax.Text;
            _currentSupplier.WebSite = textBoxWebSite.Text;
            _currentSupplier.Remarks = textBoxRemarks.Text;
            _currentSupplier.Subject = textBoxSubject.Text;
            _currentSupplier.Approved = checkBoxApproved.Checked;
            _currentSupplier.SupplierClass = comboBoxSupplierClass.SelectedItem as SupplierClass;
        }
        #endregion

        #region private void AbortChanges()
        private void AbortChanges()
        {
        }
        #endregion

        #region private void Save()
        /// <summary>
        /// Собирает данные с контролов и на их основе создает Supplier
        /// </summary>
        /// <returns></returns>
        private void Save()
        {
            try
            {
                GlobalObjects.CasEnvironment.NewKeeper.Save(_currentSupplier);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return;
            }

            foreach (Document document in _documents)
            {
                document.Parent = _currentSupplier;
                document.ParentId = _currentSupplier.ItemId;
                document.ParentTypeId = _currentSupplier.SmartCoreObjectType.ItemId;

                GlobalObjects.CasEnvironment.NewKeeper.Save(document);
            }
        }

        #endregion

        #region private void ButtonAddFileClick(object sender, EventArgs e)
        private void ButtonAddFileClick(object sender, EventArgs e)
        {
            DocumentForm form = new DocumentForm(new Document(), _currentSupplier);

            if (form.ShowDialog() == DialogResult.OK)
            {
                Document document = form.CurrentDocument;
                GlobalObjects.PerformanceCalculator.GetNextPerformance(document);

                _documents.Add(document);

                documentationListView.SetItemsArray(_documents.ToArray());
            }
        }
        #endregion   
        
        #region private void ButtonSaveClick(object sender, EventArgs e)
        private void ButtonSaveClick(object sender, EventArgs e)
        {
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GetChangeStatus())
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?",
                                                      (string)new GlobalTermsProvider()["SystemName"],
                                                      MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                                      MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Cancel)
                {
                    AcceptButton.DialogResult = DialogResult.Cancel;
                    return;
                }
                if (result == DialogResult.No)
                {
                    AbortChanges();
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
                else
                {
                    ApplyChanges();
                    Save();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
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

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (documentationListView.SelectedItems == null) return;

            DialogResult confirmResult =
                MessageBox.Show(
                    documentationListView.SelectedItem != null
                        ? "Do you really want to delete Document " + documentationListView.SelectedItem.Description + "?"
                        : "Do you really want to delete selected Documents? ", "Confirm delete operation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                int count = documentationListView.SelectedItems.Count;

                List<Document> selectedItems = new List<Document>();
                selectedItems.AddRange(documentationListView.SelectedItems.ToArray());
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        GlobalObjects.CasEnvironment.NewKeeper.Delete(selectedItems[i]);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex);
                        return;
                    }
                }

                foreach (Document document in selectedItems)
                {
                    _documents.Remove(document);
                    _currentSupplier.SupplierDocs.Remove(document);
                }

                documentationListView.SetItemsArray(_documents.ToArray());
            }
            else
            {
                MessageBox.Show("Failed to delete Documents: Parent container is invalid", "Operation failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #endregion

        #region Events



        //private void ButtonAddClick(object sender, EventArgs e)
        //{
        //    SaveData();
        //    CurrentSupplier.ItemID = -2;
        //    GlobalObjects.CasEnvironment.Keeper.Save(CurrentSupplier);
        //    MessageBox.Show("Save to coplete");
        //}

        

        #endregion
    }
}
