using System;
using System.Windows.Forms;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    ///</summary>
    public partial class DamageChartImageControl : UserControl
    {
        #region Fields

        private DamageDocument _currentDocument;
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

        #region public DamageDocument DamageDocument
        ///<summary>
        ///</summary>
        public DamageDocument DamageDocument
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
            set { extendableRichContainer1.Extended = value; }
        }
        #endregion

        #endregion

        #region Constructors

        #region public DamageChartImageControl()
        ///<summary>
        ///</summary>
        public DamageChartImageControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public DamageChartImageControl(DamageDocument doc)
        ///<summary>
        ///</summary>
        public DamageChartImageControl(DamageDocument doc)
        {
            _currentDocument = doc;
            
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
            return (FileControlChartFile.GetChangeStatus());
        }
        #endregion

        #region public void SaveData()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public void SaveData()
        {
            if(FileControlChartFile.GetChangeStatus())
            {
                FileControlChartFile.ApplyChanges();
                _currentDocument.DamageDocFile = FileControlChartFile.AttachedFile;
            }
        }
        #endregion

        #region private void UpdateInformation()
        ///<summary>
        ///</summary>
        private void UpdateInformation()
        {
            if (_currentDocument == null) return;

            extendableRichContainer1.Caption = _currentDocument.DamageDocFile != null
                                       ? _currentDocument.DamageDocFile.FileName
                                       : "Please, add file";

            FileControlChartFile.UpdateInfo(_currentDocument.DamageDocFile, "Image Files|*.jpg; *.png",
                                                "This record does not contain a file proving the Image file. Enclose PDF file to prove the compliance.",
                                                "Attached file proves the Chart file.");
        }
        #endregion

        #region private void ExtendableRichContainer1Extending(object sender, EventArgs e)
        private void ExtendableRichContainer1Extending(object sender, EventArgs e)
        {
            panelMain.Visible = extendableRichContainer1.Extended;

            if (panelMain.Visible == false)
            {
                panelButtons.Visible = false;
                panelButtons.Controls.Remove(ButtonDelete);
                panelLabel.Controls.Add(ButtonDelete);
                ButtonDelete.Location = new System.Drawing.Point(231, 3);
            }
            else
            {
                panelButtons.Visible = true;
                panelLabel.Controls.Remove(ButtonDelete);
                panelButtons.Controls.Add(ButtonDelete);
                ButtonDelete.Location = new System.Drawing.Point(231, 3);
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
            extendableRichContainer1.Caption = fileName == "" ? "please, add file" : fileName;
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
