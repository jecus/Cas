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
using SmartCore.CAA.Audit;
using SmartCore.CAA.Check;
using SmartCore.CAA.FindingLevel;
using SmartCore.CAA.PEL;

namespace CAS.UI.UICAAControls.CheckList.CheckListAudit
{
    public partial class CheckListCAPForm : MetroForm
    {
        private  CheckLists _currentCheck;
        private readonly int _auditId;
        private AuditCheck _currentAuditCheck;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private PelSpecialist _auditor;
        
        
        public CheckListCAPForm(CheckLists currentCheck, int auditId, bool editable = false)
        {
            _currentCheck = currentCheck;
            _auditId = auditId;
            InitializeComponent();
            
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
        }

        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateInformation();
        }

        private void UpdateInformation()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var status in new []{WorkFlowStatus.IA,WorkFlowStatus.FAT,WorkFlowStatus.VOI,WorkFlowStatus.Closed,})
            {
                var control = new CheckListCAPItem(_currentAuditCheck ,status);

                if (_currentAuditCheck.WorkflowStatusId == WorkFlowStatus.Open.ItemId && status.ItemId == WorkFlowStatus.IA.ItemId)
                    control.EnableControls(true);
                
                control.Accept += ControlOnAccept;
                control.Reject+= ControlOnReject;
                
                flowLayoutPanel1.Controls.Add(control);
            }
        }

        private void ControlOnAccept(object sender, EventArgs e)
        {
            var wf = sender as WorkFlowStatus;
            
            var res = MessageBox.Show(wf == WorkFlowStatus.Open ?  $"Do you really want move to next status({WorkFlowStatus.GetItemById(_currentAuditCheck.Settings.WorkflowStatusId)})?" :
                $"Do you really want move to next status({WorkFlowStatus.GetItemById(_currentAuditCheck.Settings.WorkflowStatusId + 1)})?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                _currentAuditCheck.Settings.FromWorkflowStatusId = wf.ItemId - 1;
                _currentAuditCheck.Settings.WorkflowStatusId = wf.ItemId;
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
                        Remark = $"Workflow status Updated to {wf}!",
                        WorkflowStageId = _currentAuditCheck.WorkflowStageId,
                        IsWorkFlowChanged = true,
                    }
                };
                GlobalObjects.CaaEnvironment.NewKeeper.Save(rec);
                _animatedThreadWorker.RunWorkerAsync();
                
            }
            Focus();
        }
        
        private void ControlOnReject(object sender, EventArgs e)
        {
            var wf = sender as WorkFlowStatus;
            
            var res = MessageBox.Show(wf == WorkFlowStatus.IA ? $"Do you really want move to previous stage({WorkFlowStage.GetItemById(_currentAuditCheck.Settings.WorkflowStageId - 1)})?": 
                $"Do you really want move to previous status({WorkFlowStatus.GetItemById(wf.ItemId - 1)})?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                if (wf == WorkFlowStatus.IA)
                {
                    _currentAuditCheck.Settings.FromWorkflowStageId = _currentAuditCheck.WorkflowStageId;
                    _currentAuditCheck.Settings.WorkflowStageId = _currentAuditCheck.WorkflowStageId- 1;
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
                            Remark = $"Workflow stage Updated to {WorkFlowStage.GetItemById(_currentAuditCheck.WorkflowStageId- 1)}!",
                            WorkflowStageId = _currentAuditCheck.WorkflowStageId,
                            IsWorkFlowChanged = true,
                        }
                    };
                    
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(rec);
                }
                else
                {
                    _currentAuditCheck.Settings.FromWorkflowStatusId = wf.ItemId;
                    _currentAuditCheck.Settings.WorkflowStatusId = wf.ItemId - 1;
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
                            Remark = $"Workflow status Updated to {wf}!",
                            WorkflowStageId = _currentAuditCheck.WorkflowStageId,
                            IsWorkFlowChanged = true,
                        }
                    };
                    
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(rec);
                }
                
                
                
                _animatedThreadWorker.RunWorkerAsync();
            }
            Focus();
        }

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            if (_currentCheck == null) return;

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
            
        }
    }
}