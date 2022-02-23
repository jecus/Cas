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
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.CAA.Check;
using SmartCore.CAA.FindingLevel;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UICAAControls.CheckList.EditionRevision.Icao
{
    public partial class CheckListIcaoRevisionForm : MetroForm
    {
        private readonly int _operatorId;
        private readonly CheckListRevision _parent;
        private readonly SmartCore.CAA.StandartManual.StandartManual _manual;
        private List<CheckListRevisionRecord> _revisions = new List<CheckListRevisionRecord>();
        private CheckListRevision revisionedition = new CheckListRevision();
        private CommonCollection<CheckLists> _addedChecks = new CommonCollection<CheckLists>();
        private CommonCollection<CheckLists> _updateChecks = new CommonCollection<CheckLists>();
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private IList<FindingLevels> _levels = new List<FindingLevels>();

        public CheckListIcaoRevisionForm(int operatorId, CheckListRevision parent, SmartCore.CAA.StandartManual.StandartManual manual)
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
            revisionedition = new CheckListRevision();
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
            
            foreach (var check in _addedChecks)
            {
                check.EditionNumber = _parent.Number;
                check.Level = _levels.FirstOrDefault(i => i.ItemId == check.SettingsIosa.LevelId) ??
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
            
            _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
            _tocheckListView.SetItemsArray(_updateChecks.ToArray());
        }

        private bool ApplyChanges()
        {
            foreach (var checks in _updateChecks)
            {
                if(checkBoxSource.Checked)
                    checks.Source = metroTextSource.Text;
                
                if (!CheckNumber(out var  number))
                    return false;
                
                if (checkBoxRevisionValidTo.Checked)
                {
                    revisionedition = new CheckListRevision()
                    {
                        Number = number,
                        Type = RevisionType.Revision,
                        OperatorId = _operatorId,
                        Date = dateTimePickerRevisionDate.Value.Date,
                        EffDate = RevisionEff.Value.Date,
                        Status = _parent.Status,
                        ManualId = _manual.ItemId,
                        Settings = new CheckListRevisionSettings()
                        {
                            EditionId = _parent.Type == RevisionType.Edition  ? _parent.ItemId : _parent.Settings.EditionId
                        }
                    };
                    _revisions.Add(new CheckListRevisionRecord()
                    {
                        CheckListId = checks.ItemId,
                    });
                }
                if(checkBoxLevel.Checked)
                    checks.SettingsIosa.LevelId = ((FindingLevels)comboBoxLevel.SelectedItem).ItemId;
                if (checkBoxMH.Checked)
                {
                    double manHours;
                    if (!CheckManHours(out manHours))
                        return false;
                    checks.SettingsIosa.MH = manHours;
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

        
        public bool CheckNumber(out int number)
        {
            if (int.TryParse(metroTextBoxRevision.Text, NumberStyles.Number, new NumberFormatInfo(),  out number) == false)
            {
                MessageBox.Show("Number of edition. Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void SetEnableControl(bool state)
        {
            checkBoxSource.Checked =
                checkBoxLevel.Checked =
                                        metroTextSource.Enabled =
                                            metroTextBoxRevision.Enabled = 
            dateTimePickerRevisionDate.Enabled =
                RevisionEff.Enabled =
                    metroTextBoxMH.Enabled =
                        checkBoxRevisionValidTo.Checked =
                            checkBoxMH.Checked =
                comboBoxLevel.Enabled = state;
        }

        private void ClearControl()
        {
            metroTextSource.Text = "";
            metroTextBoxRevision.Text = "";
            dateTimePickerRevisionDate.Value = DateTime.Today;
            RevisionEff.Value = DateTime.Today;
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


                        var revision = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionDTO, CheckListRevision>(new[]
                        {
                            new Filter("Number",revisionedition.Number),
                            new Filter("EditionId", _parent.ItemId)
                        });
                        if (!revision.Any())
                        {
                            GlobalObjects.CaaEnvironment.NewKeeper.Save(revisionedition);
                            foreach (var r in _revisions)
                                r.ParentId = revisionedition.ItemId;
                        }
                        else
                        {
                            
                            
                            var id = revision.FirstOrDefault().ItemId;
                            var records = GlobalObjects.CaaEnvironment.NewLoader
                                .GetObjectList<CheckListRevisionRecordDTO, CheckListRevisionRecord>(new Filter("ParentId", id));

                            foreach (var r in records)
                            {
                                var find = _revisions.FirstOrDefault(i => i.CheckListId == r.CheckListId);
                                if (find != null)
                                    _revisions.Remove(find);
                            }
                            
                            foreach (var r in _revisions)
                                r.ParentId = id;
                        }
                        
                       if(_revisions.Any())
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
            metroTextBoxRevision.Enabled =
                    dateTimePickerRevisionDate.Enabled=
                        RevisionEff.Enabled 
                        = checkBoxRevisionValidTo.Checked;
        }

        private void dateTimePickerRevisionDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerRevisionDate.Value < _parent.Date)
                dateTimePickerRevisionDate.Value = _parent.Date;
        }

        private void RevisionEff_ValueChanged(object sender, EventArgs e)
        {
            if (RevisionEff.Value < dateTimePickerRevisionDate.Value)
                RevisionEff.Value = dateTimePickerRevisionDate.Value;
        }
        
    }
}
