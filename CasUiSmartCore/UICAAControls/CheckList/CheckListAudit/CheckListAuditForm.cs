using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using CAS.UI.UICAAControls.CheckList.CheckListAudit.MoveToForms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.CAA.Audit;
using SmartCore.CAA.Check;
using SmartCore.CAA.FindingLevel;
using SmartCore.CAA.PEL;

namespace CAS.UI.UICAAControls.CheckList.CheckListAudit
{
    public partial class CheckListAuditForm : MetroForm
    {
        private CheckLists _currentCheck;
        private readonly int _auditId;
        private readonly bool _editable;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private AuditCheck _currentAuditCheck;
        private List<AuditCheckRecord> _currentAuditCheckRecords = new List<AuditCheckRecord>();
        private IList<RootCause> _rootCase = new List<RootCause>();

        #region Constructors


        public CheckListAuditForm(CheckLists currentCheck, int auditId, bool editable = false) 
        {
            InitializeComponent();
            _currentCheck = currentCheck;
            _auditId = auditId;
            _editable = editable;

            ButtonWf.Visible = _editable;
            button1.Visible = _editable;

            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
        }

        #endregion

        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateControls();
            UpdateInformation();

            if (!_editable)
            {
                foreach (var c in this.Controls.OfType<Control>()
                             .Where(i => !(i.GetType() == typeof(Button) )))
                {
                    if(c.GetType() == typeof(AvControls.AvButtonT.AvButtonT))
                        continue;
                    
                    if(c.GetType().ToString() == "MetroFramework.Forms.MetroForm+MetroFormButton")
                        continue;
                    c.Enabled = false;
                }
            }
            
        }

        private void UpdateControls()
        {



            radioButtonNotSatisfactory.CheckedChanged += RadioButtonSatisfactory_CheckedChange;
            radioButtonSatisfactory.CheckedChanged += RadioButtonSatisfactory_CheckedChange;

            radioButtonNotSatisfactory.Enabled =
                radioButtonSatisfactory.Enabled =
                    metroTextBoxFindings.Enabled =
                        metroTextBoxComments.Enabled = !checkBoxNotApplicable.Checked;
            

            foreach (var control in flowLayoutPanel1.Controls.OfType<AuditCheckControl>())
                control.EnableCheckBox(!checkBoxNotApplicable.Checked);
        }

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            if (_currentCheck.AuditCheck.Settings.WorkflowStatusId == WorkFlowStatus.Open.ItemId 
                && _currentCheck.AuditCheck.Settings.WorkflowStageId == WorkFlowStage.View.ItemId)
            {
                if (_currentCheck.PelRecord?.Auditor.ItemId == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
                {
                    _currentCheck.AuditCheck.Settings.IsAuditorReview = true;
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(_currentCheck.AuditCheck);
                }
                else if (_currentCheck.PelRecord?.Auditee.ItemId == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
                {
                    _currentCheck.AuditCheck.Settings.IsAuditeeReview = true;
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(_currentCheck.AuditCheck);
                }

                if (_currentCheck.AuditCheck.Settings.IsAuditorReview.HasValue && _currentCheck.AuditCheck.Settings.IsAuditeeReview.HasValue &&
                    _currentCheck.AuditCheck.Settings.IsAuditorReview.Value && _currentCheck.AuditCheck.Settings.IsAuditeeReview.Value)
                {
                    _currentCheck.AuditCheck.Settings.WorkflowStatusId = WorkFlowStatus.Review.ItemId;
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(_currentCheck.AuditCheck);
                }
                
            }
            
            
            if (_currentCheck == null) return;


            _rootCase = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<RootCauseDTO, RootCause>();

            _currentCheck =
                GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CheckListDTO, CheckLists>(_currentCheck.ItemId);
            
            _currentCheck.EditionNumber = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CheckListRevisionDTO, CheckListRevision>(_currentCheck.EditionId)?.Number.ToString() ?? "";
            if(_currentCheck.RevisionId.HasValue)
                _currentCheck.RevisionNumber = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CheckListRevisionDTO, CheckListRevision>(_currentCheck.RevisionId.Value)?.Number.ToString() ?? "";
            
            _currentAuditCheck =
                GlobalObjects.CaaEnvironment.NewLoader.GetObject<AuditCheckDTO, AuditCheck>(new List<Filter>()
                {
                    new Filter("AuditId", _auditId),
                    new Filter("CheckListId", _currentCheck.ItemId),
                });
            if (_currentAuditCheck == null)
            {
                _currentAuditCheck = new AuditCheck()
                {
                    CheckListId = _currentCheck.ItemId,
                    AuditId = _auditId
                };
                GlobalObjects.CaaEnvironment.NewKeeper.Save(_currentAuditCheck);
            }

            if (_currentAuditCheck.ItemId > 0)
                _currentAuditCheckRecords = new List<AuditCheckRecord>(
                    GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<AuditCheckRecordDTO, AuditCheckRecord>(
                        new Filter("AuditRecordId", _currentAuditCheck.ItemId)));
            else _currentAuditCheckRecords = new List<AuditCheckRecord>();


            var records =
                GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRecordDTO, CheckListRecords>(
                    new Filter("CheckListId", _currentCheck.ItemId));


            foreach (var rec in records)
            {
                var find = _currentAuditCheckRecords.FirstOrDefault(i => i.CheckListRecordId == rec.ItemId);
                if (find == null)
                {
                    var newRecord = new AuditCheckRecord()
                    {
                        CheckListRecordId = rec.ItemId,
                        AuditRecordId = _currentAuditCheck.ItemId,
                        CheckListRecord = rec
                    };
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(newRecord);

                    _currentAuditCheckRecords.Add(newRecord);
                }
                else find.CheckListRecord = rec;
            }

            _currentCheck.CheckListRecords.Clear();
            _currentCheck.CheckListRecords.AddRange(records);
            
            _currentCheck.Level = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<FindingLevelsDTO, FindingLevels>(_currentCheck.Settings.LevelId) ??
                                  FindingLevels.Unknown;
        }
        
        
        

        private void UpdateInformation()
        {
            labelSourceText.Text = _currentCheck.Source;
            labelEditorText.Text = _currentCheck.EditionNumber?.ToString() ?? "";
            labelRevisionText.Text = _currentCheck.RevisionNumber?.ToString() ?? "";
            labelLevelText.Text = _currentCheck.Level.ToString();

            metroTextBoxSection.Text = $"{_currentCheck.SectionNumber} {_currentCheck.SectionName}";
            metroTextBoxPart.Text = $"{_currentCheck.PartNumber} {_currentCheck.PartName}";
            metroTextBoxSubPart.Text = $"{_currentCheck.SubPartNumber} {_currentCheck.SubPartName}";
            metroTextBoxItem.Text = $"{_currentCheck.ItemNumber} {_currentCheck.ItemName}";
            metroTextBoxRequirement.Text = _currentCheck.Requirement;

            if(_currentAuditCheck.Settings.IsApplicable.HasValue)
                checkBoxNotApplicable.Checked = _currentAuditCheck.Settings.IsApplicable.Value ;
            if (_currentAuditCheck.Settings.IsSatisfactory.HasValue)
            {
                radioButtonSatisfactory.Checked = _currentAuditCheck.Settings.IsSatisfactory.Value;
                radioButtonNotSatisfactory.Checked = !radioButtonSatisfactory.Checked;
            }

            metroTextBoxFindings.Text = _currentAuditCheck.Settings.Findings;
            metroTextBoxComments.Text = _currentAuditCheck.Settings.Comments;

            
            metroTextBoxWorkflowStage.Text = WorkFlowStage.GetItemById(_currentAuditCheck.Settings.WorkflowStageId).ToString();
            metroTextBoxWorkFlowStatus.Text = WorkFlowStatus.GetItemById(_currentAuditCheck.Settings.WorkflowStatusId).ToString();
            
            // for (int i = 0; i < checkedListBoxRoot.Items.Count; i++)
            // {
            //     if (!string.IsNullOrEmpty(_currentAuditCheck.Settings.RootCause) &&_currentAuditCheck.Settings.RootCause.Contains(checkedListBoxRoot.Items[i].ToString()))
            //         checkedListBoxRoot.SetItemChecked(i, true);
            // }
            
            
            flowLayoutPanel1.Controls.Clear();
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
                    var control = new AuditCheckControl(_currentAuditCheckRecords.FirstOrDefault(i => i.CheckListRecordId == record.ItemId));
                    flowLayoutPanel1.Controls.Add(control);
                }
            }

        }

        private void ApplyChanges()
        {
            _currentAuditCheck.Settings.IsApplicable = checkBoxNotApplicable.Checked;
            _currentAuditCheck.Settings.IsSatisfactory = radioButtonSatisfactory.Checked;
            _currentAuditCheck.Settings.Findings = metroTextBoxFindings.Text;
            _currentAuditCheck.Settings.Comments = metroTextBoxComments.Text;

            // foreach (var item in checkedListBoxRoot.CheckedItems)
            //     _currentAuditCheck.Settings.RootCause += $"{item}, ";
        }


        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (radioButtonNotSatisfactory.Checked && string.IsNullOrEmpty(metroTextBoxFindings.Text))
                {
                    MessageBox.Show($"Please input some text in Findings and then save current CheckList!", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    return;
                }
                
                
                ApplyChanges();
                GlobalObjects.CaaEnvironment.NewKeeper.Save(_currentAuditCheck);


                foreach (var control in flowLayoutPanel1.Controls.OfType<AuditCheckControl>())
                {
                    control.ApplyChanges();
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(control.AuditCheckRecord, true);
                }


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
                    metroTextBoxFindings.Enabled =
                        checkedListBoxRoot.Enabled = 
                metroTextBoxComments.Enabled = !checkBoxNotApplicable.Checked;

            checkedListBoxRoot.Enabled = !radioButtonSatisfactory.Checked;

            foreach (var control in flowLayoutPanel1.Controls.OfType<AuditCheckControl>())
                control.EnableCheckBox(!checkBoxNotApplicable.Checked);
        }



        private void RadioButtonSatisfactory_CheckedChange(object sender, EventArgs e)
        {
            if(radioButtonSatisfactory.Checked)
                checkedListBoxRoot.SelectionMode = SelectionMode.None;
            else checkedListBoxRoot.SelectionMode = SelectionMode.One;
            checkedListBoxRoot.Enabled = !radioButtonSatisfactory.Checked;
        }

        private void ButtonWf_Click(object sender, EventArgs e)
        {
            var form = new WorkflowCommentsForm(_currentAuditCheck);
            if (form.ShowDialog() == DialogResult.OK)
                _animatedThreadWorker.RunWorkerAsync();
            
            _currentCheck.AuditCheck = _currentAuditCheck;
            Focus();
        }

        private void avButtonWfTracking_Click(object sender, EventArgs e)
        {
            var form = new WorkflowCommentsTrackingForm(_currentAuditCheck);
            if (form.ShowDialog() == DialogResult.OK)
                _animatedThreadWorker.RunWorkerAsync();
            
            _currentCheck.AuditCheck = _currentAuditCheck;
            Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show($"Do you really want move to next stage({WorkFlowStage.GetItemById(_currentAuditCheck.Settings.WorkflowStageId + 1).FullName})?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                _currentAuditCheck.Settings.FromWorkflowStageId = _currentAuditCheck.Settings.WorkflowStageId;
                _currentAuditCheck.Settings.WorkflowStageId += 1;
                _currentAuditCheck.Settings.WorkflowStatusId = WorkFlowStatus.Open.ItemId;
                GlobalObjects.CaaEnvironment.NewKeeper.Save(_currentAuditCheck);
                    
                var rec = new CheckListTransfer()
                {
                    Created = DateTime.Now,
                    From = GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId,
                    To = GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId,
                    AuditId = _auditId,
                    CheckListId = _currentAuditCheck.CheckListId,
                    Settings = new CheckListTransferSettings()
                    {
                        Remark = $"Workflow stage Updated to {WorkFlowStage.GetItemById(_currentAuditCheck.Settings.WorkflowStageId)}!",
                        WorkflowStageId = _currentAuditCheck.Settings.WorkflowStageId,
                        IsWorkFlowChanged = true
                    }
                };
                GlobalObjects.CaaEnvironment.NewKeeper.Save(rec);
                _currentCheck.AuditCheck = _currentAuditCheck;
                _animatedThreadWorker.RunWorkerAsync();
                Focus();
            }
        }
    }
}
