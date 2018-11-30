using System;
using System.Drawing;
using System.Windows.Forms;
using SmartCore.Entities.General;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    ///</summary>
    public partial class SupplierDocFileControl : UserControl
    {
        #region Fields

        private Supplier _currentSupplier;
        private SupplierDocument _currentDocument;
        #endregion

        #region Properties

        #region public bool ButtonDeleteVisible
        ///<summary>
        ///</summary>
        public bool ButtonDeleteVisible
        {
            get { return ButtonDelete.Visible; }
            set { ButtonDelete.Visible = value; }
        }
        #endregion

        #region public SupplierDocument SupplierDocument
        ///<summary>
        ///</summary>
        public SupplierDocument SupplierDocument
        {
            get { return _currentDocument; }
            set { _currentDocument = value; }
        }
        #endregion

        #region  public bool Extended
        ///<summary>
        ///</summary>
        public bool Extended
        {
            get { return extendableRichContainer1.Extended; }
            set { extendableRichContainer1.Extended = value;  }
        }
        #endregion

        #endregion

        #region Constructors

        #region public SupplierDocFileControl()
        ///<summary>
        ///</summary>
        public SupplierDocFileControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public SupplierDocFileControl(Supplier supplier, SupplierDocument doc)
        ///<summary>
        ///</summary>
        public SupplierDocFileControl(Supplier supplier, SupplierDocument doc)
        {
            _currentDocument = doc;
            _currentSupplier = supplier;
            InitializeComponent();
            UpdateInformation();
        }
        #endregion
       
        #endregion

        #region Methods

        #region  public bool GetChangeStatus()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public bool GetChangeStatus()
        {
            return (_currentDocument.Name != textBoxDocumentName.Text ||
                    FileControlChartFile.GetChangeStatus() ||
                    _currentDocument.DocumentType != textBoxDocType.Text);
        }
        #endregion

        #region public void SaveData()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public void SaveData()
        {
            _currentDocument.Name = textBoxDocumentName.Text;
            _currentDocument.DocumentType = textBoxDocType.Text;
            _currentDocument.SupplierId = _currentSupplier.ItemId;

            if(FileControlChartFile.GetChangeStatus())
            {
                FileControlChartFile.ApplyChanges();
                _currentDocument.AttachedFile = FileControlChartFile.AttachedFile;
            }
        }
        #endregion

        #region public void UpdateInformation()
        ///<summary>
        ///</summary>
        public void UpdateInformation()
        {
            extendableRichContainer1.Caption = _currentDocument.AttachedFile != null
                                                   ? _currentDocument.AttachedFile.FileName
                                                   : "Please, add file";
            textBoxDocumentName.Text = _currentDocument.Name;
            FileControlChartFile.UpdateInfo(_currentDocument.AttachedFile, "Adobe PDF Files|*.pdf",
                                                "This record does not contain a file proving the Supplier doc File. Enclose PDF file to prove the compliance.",
                                                "Attached file proves the Supplier doc file.");
            textBoxDocType.Text = _currentDocument.DocumentType;
        }
        #endregion

        #region private void ExtendableRichContainer1Extending(object sender, EventArgs e)
        private void ExtendableRichContainer1Extending(object sender, EventArgs e)
        {
            panelMain.Visible = extendableRichContainer1.Extended;
            if (panelMain.Visible == false)
            {
                panelMain.Controls.Remove(ButtonDelete);
                panelLabel.Controls.Add(ButtonDelete);
                ButtonDelete.Location = new Point(438,3);
            }
            else
            {
                panelLabel.Controls.Remove(ButtonDelete);
                panelMain.Controls.Add(ButtonDelete);
                ButtonDelete.Location = new Point(438,115);
            }
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this file?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (Deleted != null)
                    Deleted(this, EventArgs.Empty);
            }
        }
        #endregion

        #region private void FileControlChartFileFileChanged(string fileName)
        private void FileControlChartFileFileChanged(string fileName)
        {
            if (fileName == "") extendableRichContainer1.Caption = "please, add file";
            else extendableRichContainer1.Caption = fileName;
        }
        #endregion

        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        #endregion
    }
}
