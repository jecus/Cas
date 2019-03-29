using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.KitControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.WorkPakage
{
    ///<summary>
    ///</summary>
    public partial class NonRoutineJobForm : Form
    {
        #region Fields
        private NonRoutineJob _currentJob = new NonRoutineJob();
        private readonly WorkPackageRecord _currentWorkPackageRecord;
	    private readonly WorkPackage _currentWorkPackage;
		#endregion

		#region Properties

		#region public NonRoutineJob CurrentJob { get; }

		public NonRoutineJob CurrentJob
	    {
		    get { return _currentJob; }
	    }

	    #endregion

	    #endregion

        #region Constructors

        #region public NonRoutineJobForm()
        ///<summary>
        ///</summary>
        public NonRoutineJobForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public NonRoutineJobForm(WorkPackageRecord wpr) : this ()
        ///<summary>
        ///</summary>
        public NonRoutineJobForm(WorkPackageRecord wpr, WorkPackage wp) : this ()
        {
	        _currentWorkPackage = wp;
            _currentWorkPackageRecord = wpr;
            ataChapterComboBox.UpdateInformation();
            UpdateControl();
        }
        #endregion

        #region public NonRoutineJobForm(NonRoutineJob job) : this()
        ///<summary>
        ///</summary>
        public NonRoutineJobForm(NonRoutineJob job) : this()
        {
            _currentJob = job;
            ataChapterComboBox.UpdateInformation();
            UpdateControl();
            UpdateInformation();
        }
        #endregion
        
        #endregion

        #region Methods

        #region private void UpdateControl()
        private void UpdateControl()
        {
            if (_currentWorkPackageRecord != null)
            {
                SetControlsEnable(false);
                labelNonRoutineJobCategory.Visible = true;
                comboBoxCategories.Visible = true;
                labelNumber.Visible = true;
                textBoxNumber.Visible = true;

	            var nrj = GlobalObjects.NonRoutineJobCore.GetNonRoutineJobs();
                comboBoxCategories.Items.Clear();
                comboBoxCategories.Items.AddRange(nrj.ToArray());

                if (_currentWorkPackageRecord.DirectiveId > 0)
                {
                    var job = nrj.FirstOrDefault(j => j.ItemId == _currentWorkPackageRecord.DirectiveId);
                    if (comboBoxCategories.Items.Count > 0) comboBoxCategories.SelectedItem = job;
                    else comboBoxCategories.SelectedIndex = 0;

                    textBoxNumber.Text = _currentWorkPackageRecord.JobCardNumber;
                }
                else
                {
                    if (comboBoxCategories.Items.Count > 0) comboBoxCategories.SelectedIndex = 0;
                }
            }

            buttonOk.Text = "Ok";
        }
        #endregion

        #region private void SetControlsEnable(bool enable)
        ///<summary>
        /// Делает все поля форма, кроме FileControls доступными/недоступными
        ///</summary>
        ///<param name="enable"></param>
        private void SetControlsEnable(bool enable)
        {
            foreach (Control control in _mainPanel.Controls)
            {
                if (control != labelNonRoutineJobCategory &&
                    control != comboBoxCategories &&
                    control != fileControl &&
                    control != _workPackageFileControl &&
                    control != textBoxNumber) 
                control.Enabled = enable;
            }
        }
        #endregion

        #region public void UpdateInformation()
        ///<summary>
        ///</summary>
        private void UpdateInformation()
        {
            if(_currentJob == null)
                return;

            textboxTitle.Text = _currentJob.Title;
            ataChapterComboBox.ATAChapter = _currentJob.ATAChapter;
            textboxDescription.Text = _currentJob.Description;
            textboxManHours.Text = _currentJob.ManHours.ToString();
            textboxCost.Text = _currentJob.Cost.ToString();
            textBoxKitRequired.Text = _currentJob.Kits.Count + " kits";

            fileControl.UpdateInfo(_currentJob.AttachedFile, "Adobe PDF Files|*.pdf",
									"This record does not contain a file proving the Non-Routine Job File. Enclose PDF file to prove the compliance.",
                                    "Attached file proves the Non-Routine Job File.");

            if (_currentWorkPackage != null &&
				_currentWorkPackage.Status == WorkPackageStatus.Closed &&
				_currentWorkPackage.AttachedFile != null)
            {
	            fileControl.Visible = false;
                _workPackageFileControl.Visible = true;
                _workPackageFileControl.UpdateInfo(_currentWorkPackage.AttachedFile, 
                           "Adobe PDF Files|*.pdf",
                           "This record does not contain a file proving the work package close file. Enclose PDF file to prove the compliance.",
                           "Attached file proves the work package close file.");
                //_workPackageFileControl.ShowLinkLabelOpen = true;
                _workPackageFileControl.ShowLinkLabelRemove = false;
                _workPackageFileControl.ShowLinkLabelBrowse = true;
            }
            else _workPackageFileControl.Visible = false;
        }
        #endregion

        #region private bool SaveData()
        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        private bool SaveData()
        {
            if (_currentJob == null)
                throw new ArgumentNullException();
            double manHours;
            double cost;
            if (!CheckManHours(out manHours))
                return false;
            if (!CheckCost(out cost))
                return false;
            if(ataChapterComboBox.ATAChapter == null)
            {
                MessageBox.Show("You don't select ATA Chapter", (string) new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return false;
            }

            _currentJob.Title = textboxTitle.Text;
            _currentJob.ATAChapter = ataChapterComboBox.ATAChapter;
            _currentJob.Description = textboxDescription.Text; 
            _currentJob.ManHours = manHours;
            _currentJob.Cost = cost;
            _currentJob.KitRequired = textBoxKitRequired.Text;

            if(fileControl.GetChangeStatus())
            {
                fileControl.ApplyChanges();
                _currentJob.AttachedFile = fileControl.AttachedFile;
            }


            try
            {
				GlobalObjects.NonRoutineJobCore.Save(_currentJob);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return false;
            }
            return true;
        }

        #endregion

        #region private bool SaveWorkPackageRecord()
        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        private bool SaveWorkPackageRecord()
        {
            if (_currentWorkPackageRecord == null || _currentJob == null )
                throw new ArgumentNullException();

            _currentWorkPackageRecord.DirectiveId = _currentJob.ItemId;
            _currentWorkPackageRecord.WorkPackageItemType = _currentJob.SmartCoreObjectType.ItemId;
            _currentWorkPackageRecord.JobCardNumber = textBoxNumber.Text;

            try
            {
                GlobalObjects.CasEnvironment.NewKeeper.Save(_currentWorkPackageRecord);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return false;
            }
            return true;
        }

        #endregion

        #region public bool CheckManHours(out double manHours)
        /// <summary>
        /// Проверяет значение ManHours
        /// </summary>
        /// <param name="manHours">Значение ManHours</param>
        /// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        public bool CheckManHours(out double manHours)
        {
            if (textboxManHours.Text == "")
            {
                manHours = 0;
                return true;
            }
            if (double.TryParse(textboxManHours.Text, NumberStyles.Float, new NumberFormatInfo(), out manHours) == false)
            {
                MessageBox.Show("Man Hours. Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region public bool CheckCost(out double cost)
        /// <summary>
        /// Проверяет значение Cost
        /// </summary>
        /// <param name="cost">Значение Cost</param>
        /// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        public bool CheckCost(out double cost)
        {
            if (textboxCost.Text == "")
            {
                cost = 0;
                return true;
            }
            if (double.TryParse(textboxCost.Text, NumberStyles.Float, new NumberFormatInfo(), out cost) == false)
            {
                MessageBox.Show("Cost. Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)
        private void ButtonOkClick(object sender, EventArgs e)
        {
            if(_currentWorkPackageRecord != null)
            {
                //просматривается или создается запись в рабочем пакете
                if(SaveWorkPackageRecord())
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                if (SaveData())
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
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

        #region private void ComboBoxCategoriesSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxCategoriesSelectedIndexChanged(object sender, EventArgs e)
        {
            _currentJob = (NonRoutineJob) comboBoxCategories.SelectedItem;
            UpdateInformation();
        }
        #endregion

        #region private void LinkLabelEditKitLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelEditKitLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KitForm dlg = new KitForm(_currentJob);
            if (dlg.ShowDialog() == DialogResult.OK)
                textBoxKitRequired.Text = _currentJob.Kits.Count + " kits";
        }
        #endregion

        #endregion
    }
}
