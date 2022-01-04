using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.CAA.Check;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class CheckListForm : MetroForm
    {
        private CheckLists _currentCheck;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

        #region Constructors
        public CheckListForm()
        {
            InitializeComponent();
        }

        public CheckListForm(CheckLists currentCheck) : this()
        {
            _currentCheck = currentCheck;
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
        }

        #endregion

        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateInformation();
        }

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            if (_currentCheck == null) return;

            if (_currentCheck.ItemId > 0)
                _currentCheck = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CheckListDTO, CheckLists>(_currentCheck.ItemId);
        }

        private void UpdateInformation()
        {
            metroTextSource.Text = _currentCheck.Source;
            metroTextBoxEditionNumber.Text = _currentCheck.Settings.EditionNumber;
            dateTimePickerEditionDate.Value = _currentCheck.Settings.EditionDate;
            dateTimePickerEditionEff.Value = _currentCheck.Settings.EffEditionDate;
            metroTextBoxRevision.Text = _currentCheck.Settings.RevisonNumber;
            dateTimePickerRevisionDate.Value = _currentCheck.Settings.RevisonDate;
            dateTimePickerRevisionEff.Value = _currentCheck.Settings.EffRevisonDate;
            metroTextBoxSectionNumber.Text = _currentCheck.Settings.SectionNumber;
            metroTextBoxSectionName.Text = _currentCheck.Settings.SectionName;
            metroTextBoxPartNumber.Text = _currentCheck.Settings.PartNumber;
            metroTextBoxPartName.Text = _currentCheck.Settings.PartName;
            metroTextBoxSubPartNumber.Text = _currentCheck.Settings.SubPartNumber;
            metroTextBoxSubPartName.Text = _currentCheck.Settings.SubPartName;
            metroTextBoxItemNumber.Text = _currentCheck.Settings.ItemNumber;
            metroTextBoxItemName.Text = _currentCheck.Settings.ItemtName;
            metroTextBoxRequirement.Text = _currentCheck.Settings.Requirement;
        }

        private void ApplyChanges()
        {
            _currentCheck.Source = metroTextSource.Text;
            _currentCheck.Settings.EditionNumber = metroTextBoxEditionNumber.Text ;
            _currentCheck.Settings.EditionDate = dateTimePickerEditionDate.Value;
            _currentCheck.Settings.EffEditionDate = dateTimePickerEditionEff.Value;
            _currentCheck.Settings.RevisonNumber = metroTextBoxRevision.Text;
            _currentCheck.Settings.RevisonDate = dateTimePickerRevisionDate.Value;
            _currentCheck.Settings.EffRevisonDate = dateTimePickerRevisionEff.Value;
            _currentCheck.Settings.SectionNumber = metroTextBoxSectionNumber.Text;
            _currentCheck.Settings.SectionName =  metroTextBoxSectionName.Text;
            _currentCheck.Settings.PartNumber = metroTextBoxPartNumber.Text;
            _currentCheck.Settings.PartName = metroTextBoxPartName.Text;
            _currentCheck.Settings.SubPartNumber = metroTextBoxSubPartNumber.Text;
            _currentCheck.Settings.SubPartName =  metroTextBoxSubPartName.Text;
            _currentCheck.Settings.ItemNumber = metroTextBoxItemNumber.Text;
            _currentCheck.Settings.ItemtName = metroTextBoxItemName.Text;
            _currentCheck.Settings.Requirement =  metroTextBoxRequirement.Text;
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var control = new AuditControl();
            //control.UpdateInformation(training, _suppliers, aircraftModels, _employeeLicenceControl);
            //control.Deleted += Control_Deleted;
            flowLayoutPanel1.Controls.Remove(linkLabel1);
            flowLayoutPanel1.Controls.Add(control);
            flowLayoutPanel1.Controls.Add(linkLabel1);
        }

        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            try
            {
                ApplyChanges();

                GlobalObjects.CaaEnvironment.NewKeeper.Save(_currentCheck, true, isCaa: true);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save checkList", ex);
            }
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
