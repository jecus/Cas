using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SmartCore.Entities.Dictionaries;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    ///</summary>
    public partial class PurchaseRequestForm : Form
    {
        #region Fields

        private readonly PurchaseOrder _currentPurchaseOrder;
        private List<PurchaseRequestRecord> _purchaseOrderRequestRecords;

        #endregion

        #region Constructors

        #region public PurchaseRequestForm()
        /// <summary>
        /// Пустой конструктор (вызывается при создании нового объекта)
        /// </summary>
        public PurchaseRequestForm()
        {
            InitializeComponent();
        }

        #endregion

        #region public PurchaseRequestForm(PurchaseOrder currentPurchase)
        /// <summary>
        /// Конструктор (вызывается для редактирования элемента)
        /// </summary>
        /// <param name="currentPurchase">Элемент который нужно редактировать</param>
        public PurchaseRequestForm(PurchaseOrder currentPurchase)
        {
            InitializeComponent();
            _currentPurchaseOrder = currentPurchase;
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
            textBoxTitle.Text = _currentPurchaseOrder.Title;
            textBoxDescription.Text = _currentPurchaseOrder.Description;
            textBoxAuthor.Text = _currentPurchaseOrder.Author;

            dateTimePickerOpeningDate.Value = _currentPurchaseOrder.OpeningDate;
            dateTimePickerOpeningDate.Enabled = _currentPurchaseOrder.Status == WorkPackageStatus.Opened;
            dateTimePickerPublishDate.Value = _currentPurchaseOrder.PublishingDate;
            dateTimePickerPublishDate.Enabled = _currentPurchaseOrder.Status == WorkPackageStatus.Published;
            dateTimePickerClosingDate.Value = _currentPurchaseOrder.ClosingDate;
            dateTimePickerClosingDate.Enabled = _currentPurchaseOrder.Status == WorkPackageStatus.Closed;
           
            textBox_Remarks.Text = _currentPurchaseOrder.Remarks;

            if(_currentPurchaseOrder.Status == WorkPackageStatus.Closed)
            {
                flowLayoutPanelFileControls.Visible = true;

                List<Supplier> requestSuppliers = new List<Supplier>();
                //загрузка записей созданных при закрытии закупочного ордера
                _purchaseOrderRequestRecords = _currentPurchaseOrder.PackageRecords.ToList();

                //foreach (PurchaseRequest request in
                //    _currentPurchaseOrder.PurchaseRequests.Where(request => !requestSuppliers.Contains(request.Supplier)))
                //{
                //    requestSuppliers.Add(request.Supplier);
                //}

                //flowLayoutPanelFileControls.Controls.Clear();
                //foreach (Supplier supplier in requestSuppliers)
                //{
                //    //сбор записей соответствующих данному поставщику
                //    List<PurchaseRequestRecord> supplierRecords =
                //        _purchaseOrderRequestRecords.Where(r => r.SupplierId == supplier.ItemId).ToList();

                //    AttachedFile file = null;
                //    string remarks = "";
                //    if(supplierRecords.Count > 0)
                //    {
                //        file = GlobalObjects.CasEnvironment.Loader.GetAttachedFileById(supplierRecords[0].FileId);
                //        remarks = supplierRecords[0].Remarks;
                //    }
                //    RequestFileControl newControl = new RequestFileControl(supplier) {File = file, Remarks = remarks};
                //    flowLayoutPanelFileControls.Controls.Add(newControl);
                //}
            }
        }

        #endregion

        #region private bool GetChangeStatus()
        /// <summary>
        /// Собирает данные с контролов и на их основе создает Supplier
        /// </summary>
        /// <returns></returns>
        private bool GetChangeStatus()
        {
            //if ((from RequestFileControl control in flowLayoutPanelFileControls.Controls
            //     let supplierRequests = _purchaseOrderRequestRecords.Where(pr => pr.SupplierId == control.CurrentSupplier.ItemId).ToList()
            //     where supplierRequests.Count > 0 && (supplierRequests[0].AttachedFile != control.File || supplierRequests[0].Remarks != control.Remarks)
            //     select control).Any())
            //{
            //    return true;
            //}

            return (_currentPurchaseOrder.Title != textBoxTitle.Text ||
                        _currentPurchaseOrder.Description != textBoxDescription.Text ||
                        _currentPurchaseOrder.Author != textBoxAuthor.Text ||
                        _currentPurchaseOrder.OpeningDate != dateTimePickerOpeningDate.Value ||
                        _currentPurchaseOrder.PublishingDate != dateTimePickerPublishDate.Value ||
                        _currentPurchaseOrder.ClosingDate != dateTimePickerClosingDate.Value ||
                        _currentPurchaseOrder.Remarks != textBox_Remarks.Text);
        }

        #endregion

        #region private bool SaveData()
        /// <summary>
        /// Собирает данные с контролов и на их основе создает Supplier
        /// </summary>
        /// <returns></returns>
        private void SaveData()
        {
            _currentPurchaseOrder.Title = textBoxTitle.Text;
            _currentPurchaseOrder.Description = textBoxDescription.Text;
            _currentPurchaseOrder.Author = textBoxAuthor.Text;
            _currentPurchaseOrder.OpeningDate = dateTimePickerOpeningDate.Value;
            _currentPurchaseOrder.PublishingDate = dateTimePickerPublishDate.Value;
            _currentPurchaseOrder.ClosingDate = dateTimePickerClosingDate.Value;
            _currentPurchaseOrder.Remarks = textBox_Remarks.Text;

            //if (_currentPurchaseOrder.Status == WorkPackageStatus.Closed)
            //{
            //    foreach (RequestFileControl control in flowLayoutPanelFileControls.Controls)
            //    {
            //        List<PurchaseRequestRecord> supplierRequests =
            //            _purchaseOrderRequestRecords.Where(pr => pr.SupplierId == control.CurrentSupplier.ItemId).ToList
            //                ();

            //        foreach (PurchaseRequestRecord request in supplierRequests)
            //        {
            //            request.AttachedFile = control.File;
            //            request.Remarks = control.Remarks;

            //            GlobalObjects.CasEnvironment.Keeper.Save(request);
            //        }
            //    }
            //}
        }

        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)
        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (flowLayoutPanelFileControls.Controls.Cast<RequestFileControl>().Any(control => !control.Check()))
            {
                MessageBox.Show("You dont enter a Invoice file or remarks", (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }
            
            if(GetChangeStatus())
            {
                SaveData();
                GlobalObjects.CasEnvironment.NewKeeper.Save(_currentPurchaseOrder);
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region private void DateTimePickerOpeningDateValueChanged(object sender, EventArgs e)
        private void DateTimePickerOpeningDateValueChanged(object sender, EventArgs e)
        {
            if(dateTimePickerOpeningDate.Value < DateTimeExtend.GetCASMinDateTime())
                dateTimePickerOpeningDate.Value = DateTimeExtend.GetCASMinDateTime();
            if (dateTimePickerOpeningDate.Value > DateTime.Now)
                dateTimePickerOpeningDate.Value = DateTime.Now;
        }
        #endregion

        #region private void DateTimePickerPublishDateValueChanged(object sender, EventArgs e)
        private void DateTimePickerPublishDateValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerPublishDate.Value < dateTimePickerOpeningDate.Value)
                dateTimePickerPublishDate.Value = dateTimePickerOpeningDate.Value;
            if (dateTimePickerPublishDate.Value > DateTime.Now)
                dateTimePickerPublishDate.Value = DateTime.Now;
        }
        #endregion

        #region private void DateTimePickerClosingDateValueChanged(object sender, EventArgs e)
        private void DateTimePickerClosingDateValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerClosingDate.Value < dateTimePickerPublishDate.Value)
                dateTimePickerClosingDate.Value = dateTimePickerPublishDate.Value;
            if (dateTimePickerClosingDate.Value > DateTime.Now)
                dateTimePickerClosingDate.Value = DateTime.Now;
        }
        #endregion

        #endregion

    }
}
