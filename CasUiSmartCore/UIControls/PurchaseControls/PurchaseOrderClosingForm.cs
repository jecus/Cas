using System;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    ///</summary>
    public partial class PurchaseOrderClosingForm : MetroForm
    {
        #region  Fields

        private PurchaseOrder _closedOrder;

        #endregion
       
        
        ///<summary>
        ///</summary>
        public PurchaseOrderClosingForm()
        {
            InitializeComponent();
        }

        ///<summary>
        ///</summary>
        public PurchaseOrderClosingForm(PurchaseOrder closedOrder)
        {
            if(closedOrder == null) return;
            
            _closedOrder = closedOrder;
            
            InitializeComponent();
            UpdateInformation();
        }

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            if(_closedOrder == null)return;

            //List<Supplier> requestSuppliers = new List<Supplier>();
            //foreach (PurchaseRequestRecord request in
            //    _closedOrder.PackageRecords.Where(request => !requestSuppliers.Contains(request.Supplier)))
            //{
            //    requestSuppliers.Add(request.Supplier);
            //}

            //flowLayoutPanelFileControls.Controls.Clear();
            //foreach (Supplier supplier in requestSuppliers)
            //{
            //    RequestFileControl newControl = new RequestFileControl(supplier);
            //    flowLayoutPanelFileControls.Controls.Add(newControl);
            //}
        }
        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)
        private void ButtonOkClick(object sender, EventArgs e)
        {
            //проверка записей 
            if (flowLayoutPanelFileControls.Controls.Cast<RequestFileControl>().Any(control => !control.Check()))
            {
                MessageBox.Show("You dont enter a Invoice file or remarks", (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            //формирование и сохранение
            //foreach (RequestFileControl control in flowLayoutPanelFileControls.Controls)
            //{
            //    List<PurchaseRequest> supplierRequests =
            //        _closedOrder.PurchaseRequests.Where(pr =>control.CurrentSupplier.Equals(pr.Supplier)).ToList();

            //    foreach (PurchaseRequest request in supplierRequests)
            //    {
            //        PurchaseRequestRecord newRecord =
            //            new PurchaseRequestRecord
            //                {
            //                    PurchaseRequestId = request.ItemId,
            //                    SupplierId = request.Supplier != null ? request.Supplier.ItemId : -1,
            //                    Remarks = control.Remarks,
            //                    AttachedFile = control.File,
            //                };

            //        GlobalObjects.CasEnvironment.Keeper.Save(newRecord);
            //    }
            //}

            GlobalObjects.PurchaseCore.Close(_closedOrder, dateTimePickerClosingDate.Value, textBox_Remarks.Text);

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

        #region private void DateTimePickerClosingDateValueChanged(object sender, EventArgs e)
        private void DateTimePickerClosingDateValueChanged(object sender, EventArgs e)
        {
            dateTimePickerClosingDate.ValueChanged -= DateTimePickerClosingDateValueChanged;

            if (dateTimePickerClosingDate.Value < _closedOrder.PublishingDate)
                dateTimePickerClosingDate.Value = _closedOrder.PublishingDate;
            if (dateTimePickerClosingDate.Value > DateTime.Today)
                dateTimePickerClosingDate.Value = DateTime.Today;

            dateTimePickerClosingDate.ValueChanged += DateTimePickerClosingDateValueChanged;
        }
        #endregion
    }
}
