using System.Windows.Forms;
using SmartCore.Entities.General;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    ///</summary>
    public partial class RequestFileControl : UserControl
    {
        #region Fields

        private Supplier _currentSupplier;

        #endregion

        #region Properties

        ///<summary>
        /// возвращает текущего поставщика
        ///</summary>
        public Supplier CurrentSupplier
        {
            get { return _currentSupplier; }
        }


        ///<summary>
        /// возвращает файл, прикрепленный к записи
        ///</summary>
        public AttachedFile File
        {
            get
            {
                if(fileControl.GetChangeStatus())
                    fileControl.ApplyChanges();
                return fileControl.AttachedFile;
            }
            set { fileControl.AttachedFile = value; }
        }

        ///<summary>
        /// возвращает текст с замечаниями
        ///</summary>
        public string Remarks
        {
            get { return textBoxRemarks.Text; }
            set { textBoxRemarks.Text = value; }
        }

        #endregion

        #region Constructors
        ///<summary>
        ///</summary>
        public RequestFileControl()
        {
            InitializeComponent();
        }

        ///<summary>
        ///</summary>
        public RequestFileControl(Supplier currentSupplier)
        {
            if(currentSupplier == null)return;

            _currentSupplier = currentSupplier;
            
            InitializeComponent();

            UpdateInformation();
        }
        #endregion

        #region Methods

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            if (_currentSupplier == null) return;

            labelSupplierName.Text = "Invoice from " + _currentSupplier.Name;
            textBoxRemarks.Text = "";
            fileControl.UpdateInfo(null, "Adobe PDF Files|*.pdf",
                                                "This record does not contain a Invoice file. Enclose PDF file to prove the Invoice.",
                                                "Attached file proves the Invoice file.");
        }
        #endregion

        #region public bool Check()
        ///<summary>
        ///</summary>
        public bool Check()
        {
            if(fileControl.GetChangeStatus())
                fileControl.ApplyChanges();
            return (fileControl.AttachedFile != null || textBoxRemarks.Text != "");
        }
        #endregion

        #endregion
    }
}
