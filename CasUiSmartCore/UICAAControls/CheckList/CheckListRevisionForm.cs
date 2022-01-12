﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.CAA.Check;
using SmartCore.CAA.FindingLevel;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class CheckListRevisionForm : MetroForm
    {
        private List<CheckLists> _addedChecks = new List<CheckLists>();
        private List<CheckLists> _updateChecks = new List<CheckLists>();
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private IList<FindingLevels> _levels = new List<FindingLevels>();

        public CheckListRevisionForm()
        {
            InitializeComponent();
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
        }

        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateInformation();
        }

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            _addedChecks.Clear();
            _addedChecks =
                GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CheckListDTO, CheckLists>(loadChild: true).ToList();
            _levels.Clear();
            _levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>();

            foreach (var check in _addedChecks)
            {
                check.Level = _levels.FirstOrDefault(i => i.ItemId == check.Settings.LevelId) ??
                              FindingLevels.Unknown;


                check.Remains = Lifelength.Null;
                check.Condition = ConditionState.Satisfactory;

                var days = (check.Settings.RevisonValidToDate - DateTime.Today).Days;
                var editionDays = 0;
                if (!check.Settings.RevisonValidTo)
                    editionDays = (check.Settings.EffRevisonDate - DateTime.Today).Days;
                else editionDays = (check.Settings.RevisonDate - DateTime.Today).Days;

                check.Remains = new Lifelength(days - editionDays, null, null);


                if (check.Remains.Days < 0)
                    check.Condition = ConditionState.Overdue;
                else if (check.Remains.Days >= 0 && check.Remains.Days <= check.Settings.RevisonValidToNotify)
                    check.Condition = ConditionState.Notify;
            }
        }

        private void UpdateInformation()
        {
            SetEnableControl(false);

            comboBoxLevel.Items.Clear();
            comboBoxLevel.Items.AddRange(_levels.ToArray());
            comboBoxLevel.Items.Add(FindingLevels.Unknown);

            comboBoxLevel.SelectedItem = FindingLevels.Unknown;
            _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
            _updateChecks.Clear();
            _tocheckListView.SetItemsArray(_updateChecks.ToArray());
        }

        private void ApplyChanges()
        {
            foreach (var checks in _updateChecks)
            {
                if(checkBoxSource.Checked)
                    checks.Source = metroTextSource.Text;
                if(checkBoxEdition.Checked)
                {
                    checks.Settings.EditionNumber = metroTextBoxEditionNumber.Text;
                    checks.Settings.EditionDate = dateTimePickerEditionDate.Value;
                    checks.Settings.EffEditionDate = dateTimePickerEditionEff.Value;
                }
                if (checkBoxRevision.Checked)
                {
                    checks.Settings.RevisionNumber = metroTextBoxRevision.Text;
                    checks.Settings.RevisonDate = dateTimePickerRevisionDate.Value;
                    checks.Settings.EffRevisonDate = dateTimePickerRevisionEff.Value;
                    checks.Settings.RevisonValidTo = checkBoxRevisionValidTo.Checked;
                }
                if(checkBoxCheck.Checked)
                    checks.Settings.RevisonValidToDate = dateTimePickeValidTo.Value;
                if (checkBoxNotify.Checked)
                    checks.Settings.RevisonValidToNotify = (int)numericUpNotify.Value;
                if(checkBoxReference.Checked)
                    checks.Settings.Reference = metroTextBoxReference.Text;
                if(checkBoxLevel.Checked)
                    checks.Settings.LevelId = ((FindingLevels)comboBoxLevel.SelectedItem).ItemId;
            }
        }


        private void SetEnableControl(bool state)
        {
            checkBoxSource.Checked =
                checkBoxEdition.Checked =
                    checkBoxRevision.Checked =
                        checkBoxCheck.Checked =
                            checkBoxNotify.Checked =
                                checkBoxReference.Checked =
                                    checkBoxLevel.Checked = 
            metroTextSource.Enabled = 
            metroTextBoxEditionNumber.Enabled =
            dateTimePickerEditionDate.Enabled =
            dateTimePickerEditionEff.Enabled =
            metroTextBoxRevision.Enabled = 
            dateTimePickerRevisionDate.Enabled = 
            dateTimePickerRevisionEff.Enabled =
            checkBoxRevisionValidTo.Enabled =
            dateTimePickeValidTo.Enabled =
            numericUpNotify.Enabled =
            metroTextBoxReference.Enabled =
                comboBoxLevel.Enabled = state;
        }

        private void ClearControl()
        {
            metroTextSource.Text = "";
            metroTextBoxEditionNumber.Text = "";
            dateTimePickerEditionDate.Value = DateTime.Today;
            dateTimePickerEditionEff.Value = DateTime.Today;
            metroTextBoxRevision.Text = "";
            dateTimePickerRevisionDate.Value = DateTime.Today;
            dateTimePickerRevisionEff.Value = DateTime.Today;
            checkBoxRevisionValidTo.Checked = false;
            dateTimePickeValidTo.Value = DateTime.Today;
            numericUpNotify.Value = 0;
            metroTextBoxReference.Text = "";
            comboBoxLevel.SelectedItem = FindingLevels.Unknown;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {

                var dialogResult = MessageBox.Show("Do you really want update records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {
                    ApplyChanges();
                    foreach (var checks in _updateChecks)
                        GlobalObjects.CaaEnvironment.NewKeeper.Save(checks);


                    MessageBox.Show("All records updated successfull!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    //DialogResult = DialogResult.OK;
                    //Close();

                    foreach (var item in _tocheckListView.SelectedItems.ToArray())
                    {
                        _updateChecks.Remove(item);
                        _addedChecks.Add(item);
                    }
                    SetEnableControl(false);
                    ClearControl();
                    _animatedThreadWorker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save checkList", ex);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (_fromcheckListView.SelectedItems.Count == 0) return;

            foreach (var item in _fromcheckListView.SelectedItems.ToArray())
            {
                _updateChecks.Add(item);
                _addedChecks.Remove(item);
            }

            _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
            _tocheckListView.SetItemsArray(_updateChecks.ToArray());
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_tocheckListView.SelectedItems.Count == 0) return;

            foreach (var item in _tocheckListView.SelectedItems.ToArray())
            {
                _updateChecks.Remove(item);
                _addedChecks.Add(item);
            }

            _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
            _tocheckListView.SetItemsArray(_updateChecks.ToArray());
        }

        private void checkBoxSource_CheckedChanged(object sender, EventArgs e)
        {
            metroTextSource.Enabled = checkBoxSource.Checked;
        }

        private void checkBoxReference_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxReference.Enabled = checkBoxReference.Checked;
        }

        private void checkBoxEdition_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxEditionNumber.Enabled =
                dateTimePickerEditionDate.Enabled =
                dateTimePickerEditionEff.Enabled = 
                    checkBoxEdition.Checked;
        }

        private void checkBoxRevision_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxRevisionValidTo.Enabled =
                metroTextBoxRevision.Enabled =
                    dateTimePickerRevisionDate.Enabled =
                        dateTimePickerRevisionEff.Enabled = checkBoxRevision.Checked;
        }

        private void checkBoxCheck_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickeValidTo.Enabled = checkBoxCheck.Checked;
        }

        private void checkBoxNotify_CheckedChanged(object sender, EventArgs e)
        {
            numericUpNotify.Enabled = checkBoxNotify.Checked;
        }

        private void checkBoxLevel_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxLevel.Enabled = checkBoxLevel.Checked;
        }

        private void CheckListRevisionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}