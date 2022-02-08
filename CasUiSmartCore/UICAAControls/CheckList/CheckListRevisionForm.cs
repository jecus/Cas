using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class CheckListRevisionForm : MetroForm
    {
        private readonly int _operatorId;
        private List<BaseEntityObject> _revisions = new List<BaseEntityObject>();
        private CommonCollection<CheckLists> _addedChecks = new CommonCollection<CheckLists>();
        private CommonCollection<CheckLists> _updateChecks = new CommonCollection<CheckLists>();
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private IList<FindingLevels> _levels = new List<FindingLevels>();

        public CheckListRevisionForm(int operatorId)
        {
            _operatorId = operatorId;
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
            var ids = _updateChecks.Select(i => i.ItemId).ToArray();
            _updateChecks.Clear();
            _revisions.Clear();
            _addedChecks.Clear();
            _addedChecks.AddRange(
                GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CheckListDTO, CheckLists>(new Filter("OperatorId", _operatorId), loadChild: true)
                    .ToList());
            _levels.Clear();
            _levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new Filter("OperatorId", _operatorId));

            var dsEdition = GlobalObjects.CaaEnvironment.Execute($@"
select c.ItemId as CheckId, edition.EditionNumber ,edition.EditionDate from dbo.CheckList c
cross apply
(
	select top 2 Number as EditionNumber, EffDate as EditionDate  from dbo.CheckListRevision 
	where CheckListId = c.ItemId and IsDeleted = 0 and Type = 0
	order by EffDate desc
)edition
where c.IsDeleted = 0 and c.OperatorId = {_operatorId}
order by c.ItemId");
            
            var dsRevision = GlobalObjects.CaaEnvironment.Execute($@"
select c.ItemId as CheckId,revision.RevisionNumber, revision.RevisionDate from dbo.CheckList c
cross apply
(
	select top 2 Number as RevisionNumber, EffDate as RevisionDate  from dbo.CheckListRevision 
	where CheckListId = c.ItemId and IsDeleted = 0 and Type = 1
	order by EffDate desc
)revision
where c.IsDeleted = 0 and c.OperatorId = {_operatorId}
order by c.ItemId");
            
            
            var revisions = dsRevision.Tables[0].AsEnumerable()
                .Select(dataRow => new 
                {
                    Id = dataRow.Field<int>("CheckId"),
                    RevisionNumber = dataRow.Field<string>("RevisionNumber"),
                    RevisionDate = dataRow.Field<DateTime?>("RevisionDate"),
                }).ToList();
            
            var editions = dsEdition.Tables[0].AsEnumerable()
                .Select(dataRow => new 
                {
                    Id = dataRow.Field<int>("CheckId"),
                    EditionNumber = dataRow.Field<string>("EditionNumber"),
                    EditionDate = dataRow.Field<DateTime?>("EditionDate"),
                }).ToList();
            
            
            
            foreach (var check in _addedChecks)
            {
                var revision = revisions.Where(i => i.Id == check.ItemId).ToList();
                var edition = editions.Where(i => i.Id == check.ItemId).ToList();

                if (revision.Any())
                {
                    if(revision.Count == 1)
                        check.RevisionNumber = revision.LastOrDefault()?.RevisionNumber;
                    else
                    {
                        check.NextRevisionNumber = revision.FirstOrDefault()?.RevisionNumber;
                        check.RevisionNumber = revision.LastOrDefault()?.RevisionNumber;
                    }
                }
                
                if (edition.Any())
                {
                    if (edition.Count == 1)
                        check.EditionNumber = edition.LastOrDefault()?.EditionNumber;  
                    else
                    {
                        check.NextEditionNumber = edition.FirstOrDefault()?.EditionNumber;
                        check.EditionNumber = edition.LastOrDefault()?.EditionNumber;  
                    }
                }
                
                
                check.Level = _levels.FirstOrDefault(i => i.ItemId == check.Settings.LevelId) ??
                              FindingLevels.Unknown;


                check.Remains = Lifelength.Null;
                check.Condition = ConditionState.Satisfactory;
            }

            if (ids.Any())
            {
                var checks = _addedChecks.ToArray();
                foreach (var check in checks)
                {
                    if (ids.Contains(check.ItemId))
                    {
                        _updateChecks.Add(check);
                        _addedChecks.Remove(check);
                    }
                }
            }
            
        }

        private void UpdateInformation()
        {
            SetEnableControl(false);

            comboBoxLevel.Items.Clear();
            comboBoxLevel.Items.AddRange(_levels.ToArray());
            comboBoxLevel.Items.Add(FindingLevels.Unknown);


            var phase = new List<string> { "1", "2", "3", "4", "5", "6", "N/A" };
            comboBoxPhase.Items.Clear();
            foreach (var i in phase)
                comboBoxPhase.Items.Add(i);
            comboBoxPhase.SelectedItem = "N/A";

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
                if(checkBoxEdition.Checked)
                {
                    _revisions.Add(new CheckListRevision()
                    {
                        CheckListId = checks.ItemId,
                        Date = dateTimePickerEditionDate.Value.Date,
                        EffDate = dateTimePickerEditionEff.Value.Date,
                        Number = metroTextBoxEditionNumber.Text,
                        Type = RevisionType.Edition
                    });
                }
                if (checkBoxRevisionValidTo.Checked)
                {
                    _revisions.Add(new CheckListRevision()
                    {
                        CheckListId = checks.ItemId,
                        Date = dateTimePickerRevisionDate.Value.Date,
                        EffDate = RevisionEff.Value.Date,
                        Number = metroTextBoxRevision.Text,
                        Type = RevisionType.Revision
                    });
                }
                if(checkBoxCheck.Checked)
                    checks.Settings.RevisonValidToDate = dateTimePickeValidTo.Value.Date;
                if (checkBoxNotify.Checked)
                    checks.Settings.RevisonValidToNotify = (int)numericUpNotify.Value;
                if(checkBoxReference.Checked)
                    checks.Settings.Reference = metroTextBoxReference.Text;
                if(checkBoxLevel.Checked)
                    checks.Settings.LevelId = ((FindingLevels)comboBoxLevel.SelectedItem).ItemId;
                if (checkBoxPhase.Checked)
                    checks.Settings.Phase = (string)comboBoxPhase.SelectedItem;
                if (checkBoxMH.Checked)
                {
                    double manHours;
                    if (!CheckManHours(out manHours))
                        return false;
                    checks.Settings.MH = manHours;
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
                checkBoxEdition.Checked =
                    checkBoxCheck.Checked =
                            checkBoxNotify.Checked =
                                checkBoxReference.Checked =
                                    checkBoxLevel.Checked =
                                        metroTextSource.Enabled = 
            metroTextBoxEditionNumber.Enabled =
            dateTimePickerEditionDate.Enabled =
                metroTextBoxRevision.Enabled = 
            dateTimePickerRevisionDate.Enabled =
                dateTimePickeValidTo.Enabled =
            numericUpNotify.Enabled =
                comboBoxPhase.Enabled =
                    dateTimePickerEditionEff.Enabled =
                        RevisionEff.Enabled =
                    metroTextBoxMH.Enabled =
            metroTextBoxReference.Enabled =
                comboBoxLevel.Enabled = state;
        }

        private void ClearControl()
        {
            metroTextSource.Text = "";
            metroTextBoxEditionNumber.Text = "";
            dateTimePickerEditionDate.Value = DateTime.Today;
            metroTextBoxRevision.Text = "";
            dateTimePickerRevisionDate.Value = DateTime.Today;
            checkBoxRevisionValidTo.Checked = false;
            dateTimePickeValidTo.Value = DateTime.Today;
            dateTimePickerEditionEff.Value = DateTime.Today;
            RevisionEff.Value = DateTime.Today;
            numericUpNotify.Value = 0;
            metroTextBoxReference.Text = "";
            comboBoxLevel.SelectedItem = FindingLevels.Unknown;
            comboBoxPhase.SelectedItem = "N/A";
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

                        GlobalObjects.CaaEnvironment.NewKeeper.BulkInsert(_revisions);


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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxPhase.Enabled = checkBoxPhase.Checked;
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

        private void avButtonT2_Click(object sender, EventArgs e)
        {
            var form = new CheckListRevEditForm();
            form.ShowDialog();
        }
    }
}
