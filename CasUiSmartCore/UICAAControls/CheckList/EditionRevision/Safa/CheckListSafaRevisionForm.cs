using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using Entity.Abstractions.Attributte;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.CAA.Check;
using SmartCore.CAA.FindingLevel;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UICAAControls.CheckList.EditionRevision.Safa
{
    public partial class CheckListSafaRevisionForm : MetroForm
    {
        private readonly int _operatorId;
        private readonly CheckListRevision _parent;
        private readonly SmartCore.CAA.StandartManual.StandartManual _manual;
        private List<CheckListRevisionRecord> _revisions = new List<CheckListRevisionRecord>();
        private CommonCollection<CheckLists> _addedChecks = new CommonCollection<CheckLists>();
        private CommonCollection<CheckLists> _updateChecks = new CommonCollection<CheckLists>();
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private IList<FindingLevels> _levels = new List<FindingLevels>();
        private IList<CheckListRevision> _currentRevisions = new List<CheckListRevision>();

        public CheckListSafaRevisionForm(int operatorId, CheckListRevision parent, SmartCore.CAA.StandartManual.StandartManual manual)
        {
            _operatorId = operatorId;
            _parent = parent;
            _manual = manual;
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
            _currentRevisions.Clear();
            _updateChecks.Clear();
            _revisions.Clear();
            _addedChecks.Clear();
            _addedChecks.AddRange(
                GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CheckListDTO, CheckLists>(new Filter("EditionId", _parent.ItemId), loadChild: true)
                    .ToList());
            
            _levels.Clear();
            _levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new []
            {
                new Filter("OperatorId", _operatorId),
                new Filter("ProgramTypeId", _manual.ProgramTypeId),
            });

            _currentRevisions = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionDTO, CheckListRevision>(new[]
            {
                new Filter("OperatorId", _operatorId),
                new Filter("ManualId", _manual.ItemId),
                new Filter("EditionId", _parent.ItemId),
                new Filter("Status",FilterType.In, new []{0,2})
            });
            
            foreach (var check in _addedChecks)
            {
                check.EditionNumber = _parent.Number.ToString();
                check.Level = _levels.FirstOrDefault(i => i.ItemId == check.SettingsSafa.LevelId) ??
                              FindingLevels.Unknown;
                check.Remains = Lifelength.Null;
                check.Condition = ConditionState.Satisfactory;
            }
        }

        private void UpdateInformation()
        {
            SetEnableControl(false);
            
            comboBoxLevel.Items.Clear();
            comboBoxLevel.Items.AddRange(_levels.ToArray());
            comboBoxLevel.Items.Add(FindingLevels.Unknown);
            comboBoxLevel.SelectedItem = FindingLevels.Unknown;
            
            comboBoxRevision.Items.Clear();
            comboBoxRevision.Items.AddRange(_currentRevisions.ToArray());
            
            if(_currentRevisions.Any())
                comboBoxRevision.SelectedIndex = 0;
            
            _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
            _tocheckListView.SetItemsArray(_updateChecks.ToArray());
        }

        private bool ApplyChanges()
        {
            foreach (var checks in _updateChecks)
            {
                if(checkBoxSource.Checked)
                    checks.Source = metroTextSource.Text;
                
                if (checkBoxRevisionValidTo.Checked)
                {
                    if (comboBoxRevision.SelectedItem != null)
                    {
                        _revisions.Add(new CheckListRevisionRecord()
                        {
                            CheckListId = checks.ItemId,
                            ParentId = (comboBoxRevision.SelectedItem as CheckListRevision).ItemId
                        });
                    }
                }
                
                if(checkBoxLevel.Checked)
                    checks.SettingsSafa.LevelId = ((FindingLevels)comboBoxLevel.SelectedItem).ItemId;
                if (checkBoxMH.Checked)
                {
                    double manHours;
                    if (!CheckManHours(out manHours))
                        return false;
                    checks.SettingsSafa.MH = manHours;
                }

            }

            return true;
        }

        #region public bool CheckManHours(out double manHours)

        /// <summary>
        /// Проверяет значение ManHours
        /// </summary>
        /// <param name="manHours">Значение ManHours</param>
        /// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        public bool CheckManHours(out double manHours)
        {
            if (metroTextBoxMH.Text == "")
            {
                manHours = 0;
                return true;
            }
            if (double.TryParse(metroTextBoxMH.Text, NumberStyles.Float, new NumberFormatInfo(), out manHours) == false)
            {
                MessageBox.Show("Man Hours. Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion
        
        private void SetEnableControl(bool state)
        {
            checkBoxSource.Checked =
                checkBoxLevel.Checked =
                                        metroTextSource.Enabled =
                                            comboBoxRevision.Enabled =
                    metroTextBoxMH.Enabled =
                        checkBoxRevisionValidTo.Checked =
                            checkBoxMH.Checked =
                comboBoxLevel.Enabled = state;
        }

        private void ClearControl()
        {
            metroTextSource.Text = "";
            if(_currentRevisions.Any())
                comboBoxRevision.SelectedIndex = 0;
            comboBoxLevel.SelectedItem = FindingLevels.Unknown;
            metroTextBoxMH.Text = "0.0";
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogResult = MessageBox.Show("Do you really want update records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {
                    if (ApplyChanges())
                    {
                        foreach (var checks in _updateChecks)
                            GlobalObjects.CaaEnvironment.NewKeeper.Save(checks);

                        if (_revisions.Any())
                            GlobalObjects.CaaEnvironment.NewKeeper.BulkInsert(_revisions.Cast<BaseEntityObject>().ToList());

                        MessageBox.Show("All records updated successfull!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                        
                        SetEnableControl(false);
                        ClearControl();
                        _animatedThreadWorker.RunWorkerAsync();
                    }
                    
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
             if (_fromcheckListView.SelectedItems.Count > 0)
            {
                foreach (var item in _fromcheckListView.SelectedItems.ToArray())
                {
                    _updateChecks.Add(item);
                    _addedChecks.Remove(item);
                }
                
                _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
                _tocheckListView.SetItemsArray(_updateChecks.ToArray());
            }
            
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_tocheckListView.SelectedItems.Count > 0)
            {
                foreach (var item in _tocheckListView.SelectedItems.ToArray())
                {
                    _updateChecks.Remove(item);
                    _addedChecks.Add(item);
                }
            }

            
        }

        private void checkBoxSource_CheckedChanged(object sender, EventArgs e)
        {
            metroTextSource.Enabled = checkBoxSource.Checked;
        }
        
        private void checkBoxLevel_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxLevel.Enabled = checkBoxLevel.Checked;
        }

        private void CheckListRevisionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxMH.Enabled = checkBoxMH.Checked;
        }

        private void checkBoxRevisionValidTo_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxRevision.Enabled = 
                checkBoxRevisionValidTo.Checked;
        }
        
        
    }
}
