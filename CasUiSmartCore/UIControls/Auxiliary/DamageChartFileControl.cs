using System;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    ///</summary>
    public partial class DamageChartFileControl : UserControl
    {
        #region Fields

        private DamageDocument _currentDocument;
        private Aircraft _currentAircraft;
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
            set { extendableRichContainer1.Extended = value;  }
        }
        #endregion

        #endregion

        #region Constructors

        #region public DamageChartFileControl()
        ///<summary>
        ///</summary>
        public DamageChartFileControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public DamageChartFileControl(DamageDocument doc, Aircraft currentAircraft)
        ///<summary>
        ///</summary>
        public DamageChartFileControl(DamageDocument doc, Aircraft currentAircraft)
        {
            _currentDocument = doc;
            _currentAircraft = currentAircraft;
            
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
            return ((comboBoxDamageCharts.SelectedItem != null &&
                     _currentDocument.DamageChartId != ((DamageChart) comboBoxDamageCharts.SelectedItem).ItemId) ||
                    (fileControlChartFile.GetChangeStatus()) ||
                    (_currentDocument.Location != textBoxLocation.Text));
        }
        #endregion

        #region public void SaveData()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public void SaveData()
        {
            _currentDocument.DamageChartId = comboBoxDamageCharts.SelectedItem != null
                                                 ? ((DamageChart) comboBoxDamageCharts.SelectedItem).ItemId
                                                 : -1;
            if (fileControlChartFile.GetChangeStatus() || (fileControlChartFile.AttachedFile != null && fileControlChartFile.AttachedFile.ItemId <= 0))
            {
                fileControlChartFile.ApplyChanges();
                _currentDocument.DamageDocFile = fileControlChartFile.AttachedFile;
            }
            else if (fileControlChartFile.AttachedFile != null)
                _currentDocument.DamageDocFile = fileControlChartFile.AttachedFile; 

            _currentDocument.Location = textBoxLocation.Text;
        }
        #endregion

        #region private void UpdateInformation()
        ///<summary>
        ///</summary>
        private void UpdateInformation()
        {
            if (_currentDocument == null || _currentAircraft == null) return;

            extendableRichContainer1.Caption = _currentDocument.DamageDocFile != null
                                                   ? _currentDocument.DamageDocFile.FileName
                                                   : "Please, add file";
            var damageCharts = 
                GlobalObjects.CasEnvironment.GetDamageChartsByAircraftModel(_currentAircraft.Model);
            comboBoxDamageCharts.Items.Clear();
            comboBoxDamageCharts.Items.AddRange(damageCharts.ToArray());
            comboBoxDamageCharts.SelectedItem =
                damageCharts.GetItemById(_currentDocument.DamageChartId);
           
            fileControlChartFile.UpdateInfo(_currentDocument.DamageDocFile, 
                                            "Adobe PDF Files|*.pdf",
                                            "This record does not contain a file proving the Chart file. Enclose PDF file to prove the compliance.",
                                            "Attached file proves the Chart file.");
            textBoxLocation.Text = _currentDocument.Location;
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
            if (fileName == "") extendableRichContainer1.Caption = "please, add file";
            else extendableRichContainer1.Caption = fileName;
        }
        #endregion

        #region private void ComboBoxDamageChartsSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxDamageChartsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDamageCharts.SelectedItem == null) return;

            DamageChart dc = (DamageChart) comboBoxDamageCharts.SelectedItem;
           
            if(dc.AttachedFile != null)
            {
               fileControlChartFile.AttachedFile = 
                   GlobalObjects.CasEnvironment.GetAttachedFileById(dc.AttachedFile.ItemId);
                fileControlChartFile.AttachedFile.ItemId = 0;
            }
            else fileControlChartFile.AttachedFile = dc.AttachedFile;
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
