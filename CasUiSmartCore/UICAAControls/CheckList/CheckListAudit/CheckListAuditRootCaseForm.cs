﻿using System;
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
using SmartCore.CAA;
using SmartCore.CAA.Audit;
using SmartCore.CAA.Check;
using SmartCore.CAA.FindingLevel;
using SmartCore.CAA.PEL;

namespace CAS.UI.UICAAControls.CheckList.CheckListAudit
{
    public partial class CheckListAuditRootCaseForm : MetroForm
    {
        private CheckLists _currentCheck;
        private readonly int _auditId;
        private readonly bool _editable;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private AuditCheck _currentAuditCheck;

        private List<RootCause> _fromList = new List<RootCause>();
        private List<RootCause> _toList = new List<RootCause>();
        private PelSpecialist _auditor;


        #region Constructors


        public CheckListAuditRootCaseForm(CheckLists currentCheck, int auditId, bool editable = false) 
        {
            InitializeComponent();
            _currentCheck = currentCheck;
            _auditId = auditId;
            _editable = editable;

            ButtonWf.Visible = _editable;
            button1.Visible = _editable;
            button2.Visible = _editable;

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
            
        }

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            if (_currentCheck == null) return;
            
            _fromList.Clear();
            _toList.Clear();
            
            _currentCheck = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CheckListDTO, CheckLists>(_currentCheck.ItemId);
            
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
            
            var records =
                GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRecordDTO, CheckListRecords>(
                    new Filter("CheckListId", _currentCheck.ItemId));

            
            _currentCheck.CheckListRecords.Clear();
            _currentCheck.CheckListRecords.AddRange(records);
            
            _currentCheck.Level = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<FindingLevelsDTO, FindingLevels>(_currentCheck.Settings.LevelId) ??
                                  FindingLevels.Unknown;
            
            
            var record = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<AuditPelRecordDTO, AuditPelRecord>(new List<Filter>()
            {
                new Filter("AuditId", _auditId),
                new Filter("CheckListId", _currentAuditCheck.CheckListId),
            });
            var pel = record.FirstOrDefault();
            _auditor = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<PelSpecialistDTO, PelSpecialist>(pel.AuditorId);
            
            
            var audit = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAAAuditDTO, CAAAudit>(_auditId);
            var roots = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<RootCauseDTO, RootCause>(new Filter("OperatorId", new List<int>() {audit.OperatorId,  AllOperators.Unknown.ItemId}));
            
            foreach (var root in roots)
            {
                if((bool)_currentAuditCheck.Settings.RootCauseIds?.Any(i => i == root.ItemId))
                    _toList.Add(root);
                else _fromList.Add(root);
            }
        }
        
        
        

        private void UpdateInformation()
        {
            labelSourceText.Text = _currentCheck.Source;
            labelEditorText.Text = _currentCheck.EditionNumber?.ToString() ?? "";
            labelRevisionText.Text = _currentCheck.RevisionNumber?.ToString() ?? "";
            labelLevelText.Text = _currentCheck.Level.ToString();
            
            _from.SetItemsArray(_fromList.ToArray());
            _to.SetItemsArray(_toList.ToArray());

            
            // for (int i = 0; i < checkedListBoxRoot.Items.Count; i++)
            // {
            //     if (!string.IsNullOrEmpty(_currentAuditCheck.Settings.RootCause) &&_currentAuditCheck.Settings.RootCause.Contains(checkedListBoxRoot.Items[i].ToString()))
            //         checkedListBoxRoot.SetItemChecked(i, true);
            // }
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
                    From = _auditor.SpecialistId,
                    To = _auditor.SpecialistId,
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
        
        private void button2_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show($"Do you really want move to previous stage({WorkFlowStage.GetItemById(_currentAuditCheck.Settings.WorkflowStageId + 1).FullName})?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                _currentAuditCheck.Settings.FromWorkflowStageId = _currentAuditCheck.Settings.WorkflowStageId;
                _currentAuditCheck.Settings.WorkflowStageId -= 1;
                _currentAuditCheck.Settings.WorkflowStatusId = WorkFlowStatus.Open.ItemId;
                GlobalObjects.CaaEnvironment.NewKeeper.Save(_currentAuditCheck);
                    
                var rec = new CheckListTransfer()
                {
                    Created = DateTime.Now,
                    From = _auditor.SpecialistId,
                    To = _auditor.SpecialistId,
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
                _animatedThreadWorker.RunWorkerAsync();
                Focus();
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_to.SelectedItems.Count == 0) return;
            
            foreach (var item in _to.SelectedItems.ToArray())
            {
                _fromList.Add(item);
                _toList.Remove(item);
            }

            _from.SetItemsArray(_fromList.ToArray());
            _to.SetItemsArray(_toList.ToArray());



            _currentAuditCheck.Settings.RootCauseIds = new List<int>(_toList.Select(i => i.ItemId));
            _currentAuditCheck.Settings.RootCause = string.Join(", " , _toList.Select(i => i.ToString()));
            GlobalObjects.CaaEnvironment.NewKeeper.Save(_currentAuditCheck);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (_from.SelectedItems.Count == 0) return;
            
            foreach (var item in _from.SelectedItems.ToArray())
            {
                _fromList.Remove(item);
                _toList.Add(item);
            }

            _from.SetItemsArray(_fromList.ToArray());
            _to.SetItemsArray(_toList.ToArray());
            
            _currentAuditCheck.Settings.RootCauseIds = new List<int>(_toList.Select(i => i.ItemId));
            _currentAuditCheck.Settings.RootCause = string.Join(", " , _toList.Select(i => i.ToString()));
            GlobalObjects.CaaEnvironment.NewKeeper.Save(_currentAuditCheck);
        }

        
    }
}
