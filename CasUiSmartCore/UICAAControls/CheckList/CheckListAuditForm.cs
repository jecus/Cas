using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.CAA.Check;
using SmartCore.CAA.FindingLevel;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class CheckListAuditForm : MetroForm
    {
        private CheckLists _currentCheck;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private IList<FindingLevels> _levels = new List<FindingLevels>();

        #region Constructors
        public CheckListAuditForm()
        {
            InitializeComponent();
        }

        public CheckListAuditForm(CheckLists currentCheck) : this()
        {
            _currentCheck = currentCheck;
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
        }

        #endregion

        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateControls();
            UpdateInformation();
        }

        private void UpdateControls()
        {
            radioButtonNotSatisfactory.Enabled =
                radioButtonSatisfactory.Enabled =
                    metroTextBoxReference.Enabled =
                        comboBoxRootCategory.Enabled =
                            metroTextBoxComments.Enabled = !checkBoxNotApplicable.Checked;

            comboBoxRootCategory.Enabled = radioButtonSatisfactory.Checked;
        }

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            if (_currentCheck == null) return;

            if (_currentCheck.ItemId > 0)
            {
                _currentCheck = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CheckListDTO, CheckLists>(_currentCheck.ItemId);
                var records =
                    GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRecordDTO, CheckListRecords>(new Filter("CheckListId", _currentCheck.ItemId));

                _currentCheck.CheckListRecords.Clear();
                _currentCheck.CheckListRecords.AddRange(records);

                _levels.Clear();
                _levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>();
                _currentCheck.Level = _levels.FirstOrDefault(i => i.ItemId == _currentCheck.Settings.LevelId) ??
                                      FindingLevels.Unknown;
            }
        }

        private void UpdateInformation()
        {
            radioButtonNotSatisfactory.CheckedChanged += RadioButtonSatisfactory_CheckedChange;
            radioButtonSatisfactory.CheckedChanged += RadioButtonSatisfactory_CheckedChange;

            labelSourceText.Text = _currentCheck.Source;
            labelEditorText.Text = _currentCheck.EditionNumber;
            labelRevisionText.Text = _currentCheck.RevisionNumber;
            labelLevelText.Text = _currentCheck.Level.ToString();

            metroTextBoxSection.Text = $"{_currentCheck.SectionNumber} {_currentCheck.SectionName}";
            metroTextBoxPart.Text = $"{_currentCheck.PartNumber} {_currentCheck.PartName}";
            metroTextBoxSubPart.Text = $"{_currentCheck.SubPartNumber} {_currentCheck.SubPartName}";
            metroTextBoxItem.Text = $"{_currentCheck.ItemNumber} {_currentCheck.ItemName}";
            metroTextBoxRequirement.Text = _currentCheck.Requirement;

            foreach (var group in _currentCheck.CheckListRecords.GroupBy(i => i.OptionNumber))
            {
                flowLayoutPanel1.Controls.Add(new Label()
                {
                    Text = $"Option: {group.Key}",
                    Font = new System.Drawing.Font("Verdana", 9F),
                    ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))))
                });
                foreach (var record in group)
                {
                    var control = new AuditCheckControl(record);
                    flowLayoutPanel1.Controls.Add(control);
                }
            }

        }

        private void ApplyChanges()
        {

        }


        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            try
            {

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

        

        private void checkBoxNotApplicable_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonNotSatisfactory.Enabled =
                radioButtonSatisfactory.Enabled =
                    metroTextBoxReference.Enabled =
                        comboBoxRootCategory.Enabled = 
                metroTextBoxComments.Enabled = !checkBoxNotApplicable.Checked;
        }



        private void RadioButtonSatisfactory_CheckedChange(object sender, EventArgs e)
        {
            comboBoxRootCategory.Enabled = radioButtonSatisfactory.Checked;
        }
    }
}
