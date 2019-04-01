using System;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    ///</summary>
    public partial class RequestForQuotationClosingForm : Form
    {
        #region Fields

        private readonly RequestForQuotation _currentRfq;

        #endregion

        #region Constructors
        ///<summary>
        ///</summary>
        public RequestForQuotationClosingForm()
        {
            InitializeComponent();
        }

        ///<summary>
        ///</summary>
        public RequestForQuotationClosingForm(RequestForQuotation rfq)
        {
            _currentRfq = rfq;
            InitializeComponent();

            UpdateInformation();
        }

        #endregion

        #region Properties

        #region private DateTime ClosingDate
        private DateTime ClosingDate
        {
            get { return dateTimePickerClosingDate.Value; }
        }
        #endregion

        #region public bool CreatePurchaseOrder
        ///<summary>
        /// Создавать ли закупочный ордер
        ///</summary>
        public bool CreatePurchaseOrder
        {
            get { return checkBoxCreatePurchaseOrder.Checked; }
        }
        #endregion

        #endregion

        #region Methods

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            if(_currentRfq == null)return;

            textBox_Remarks.Text = _currentRfq.Remarks;
            fileControl.UpdateInfo(_currentRfq.AttachedFile, "Adobe PDF Files|*.pdf",
                                                "This record does not contain a file proving the RfQ file. Enclose PDF file to prove the compliance.",
                                                "Attached file proves the RfQ file.");
        }
        #endregion

        #region private bool GetChangeStatus()

        private bool GetChangeStatus()
        {
            if (_currentRfq.Remarks != "" 
                || _currentRfq.Remarks != textBox_Remarks.Text 
                || fileControl.GetChangeStatus())
                return true;
            return false;
        }
        #endregion

        #region private void SaveData()

        private void SaveData()
        {
            _currentRfq.Remarks = textBox_Remarks.Text;

            if(fileControl.GetChangeStatus())
            {
                fileControl.ApplyChanges();
                _currentRfq.AttachedFile = fileControl.AttachedFile;
            }
        }
        #endregion

        #region private bool ValidateData(out string message)

        private bool ValidateData(out string message)
        {
            if (textBox_Remarks.Text.Trim() == "" &&
                fileControl.AttachedFile == null)
            {
                message = "Not enter remarks and not set invoice file";
                return false;    
            }
            message = "";
            return true;
        }
        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)
        private void ButtonOkClick(object sender, EventArgs e)
        {
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(GetChangeStatus())
            {
               SaveData();
               GlobalObjects.PurchaseCore.Close(_currentRfq,ClosingDate,textBox_Remarks.Text);    
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

        #region private void DateTimePickerClosingDateValueChanged(object sender, EventArgs e)

        private void DateTimePickerClosingDateValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerClosingDate.Value > DateTime.Today)
            {
                dateTimePickerClosingDate.Value = DateTime.Today;
            }
        }
        #endregion

        #endregion
    }
}
