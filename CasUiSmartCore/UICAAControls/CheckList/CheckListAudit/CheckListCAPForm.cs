﻿using System.Collections.Generic;
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
            foreach (var status in new []{WorkFlowStatus.IA,WorkFlowStatus.FAT,WorkFlowStatus.IA,WorkFlowStatus.VOI,WorkFlowStatus.Closed,})
            {
                var control = new CheckListCAPItem(_currentAuditCheck ,status);
                flowLayoutPanel1.Controls.Add(control);
            }
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