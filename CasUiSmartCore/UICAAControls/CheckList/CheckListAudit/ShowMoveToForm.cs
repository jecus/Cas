using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.General;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.CAA.Audit;
using SmartCore.CAA.Check;
using SmartCore.CAA.PEL;
using SmartCore.Entities.General.Personnel;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Filter = Entity.Abstractions.Filters.Filter;

namespace CAS.UI.UICAAControls.CheckList.CheckListAudit
{
    public partial class ShowMoveToForm : MetroForm
    {
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        
        private IList<CheckListTransfer> _records = new List<CheckListTransfer>();
        public int _checkListId => _auditCheck.CheckListId; 
        public int _auditId => _auditCheck.AuditId;
        public int _stageId;
        
        private readonly AuditCheck _auditCheck;
        private readonly bool _isUser;
        private bool _isAuditor;
        private int _auditorId;

        private  Author _author1;
        private  Author _author2;
        private  Author _bot;
        private PelSpecialist _auditee;
        private PelSpecialist _auditor;

        public ShowMoveToForm(AuditCheck auditCheck)
        {
            InitializeComponent();
            _auditCheck = auditCheck;
            _stageId = _auditCheck.Settings.WorkflowStageId;
            
            UpdateChat();
            
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
            
        }

        void UpdateChat()
        {
            _bot = new Author(null, "bot");
            radChat2.ChatElement.ShowToolbarButtonElement.TextWrap = true;
            radChat2.ChatElement.ShowToolbarButtonElement.Visibility = ElementVisibility.Hidden;
            radChat2.ChatElement.SendButtonElement.Enabled = false;
            radChat2.AutoAddUserMessages = false;
        }
        
        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            radChat2.ChatElement.MessagesViewElement.Items.Clear();
            var last = _records.Count == 1 ? _records.FirstOrDefault() : _records.Count > 1 ? _records.LastOrDefault() : null;

            foreach (var message in _records.Where(i => i.To > -1 && i.From > -1))
            {
                if (message.From == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId && message.To == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId )
                {
                    AddAuditorMsg(message.Settings.Remark);
                }
                else if (message.From == _auditor.SpecialistId)
                {
                    AddAuditorMsg(message.Settings.Remark);
                }
                else
                {
                    AddAuditeeMsg(message.Settings.Remark);
                }
            }
        }
        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            _records.Clear();
            
            var record = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<AuditPelRecordDTO, AuditPelRecord>(new List<Filter>()
            {
                new Filter("AuditId", _auditId),
                new Filter("CheckListId", _checkListId),
            });

            var pel = record.FirstOrDefault();
            _auditee = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<PelSpecialistDTO, PelSpecialist>(pel.AuditeeId);
            _auditor = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<PelSpecialistDTO, PelSpecialist>(pel.AuditorId);
            
            _records = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListTransferDTO, CheckListTransfer>(new List<Filter>()
            {
                new Filter("AuditId", _auditId),
                new Filter("CheckListId", _checkListId),
                //new Filter("WorkflowStageId", _stageId),
            });
            
            var specs = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<SpecialistDTO, Specialist>(new Filter("ItemId", new [] {_auditee.SpecialistId, _auditor.SpecialistId}));

            _auditee.Specialist = specs.FirstOrDefault(i => i.ItemId == _auditee.SpecialistId);
            _auditor.Specialist = specs.FirstOrDefault(i => i.ItemId == _auditor.SpecialistId);
            
            
            _author1 = new Author(null, _auditee.Specialist.ToString());
            _author2 = new Author(null, _auditor.Specialist.ToString());
            radChat2.Author = _author1;
        }
        
        private void AddBotMsg()
        {
            if (_stageId > WorkFlowStage.View.ItemId && _stageId < WorkFlowStage.Closed.ItemId)
            {
                var actions = new List<ChatCardAction>();
                actions.Add(new ChatCardAction("Accept"));
                var imageCard = new ChatImageCardDataItem(null, "", "",$"Move to next stage({WorkFlowStage.GetItemById(_stageId + 1).FullName})?", actions, null);
                var message = new ChatCardMessage(imageCard, _author1, DateTime.Now);
                radChat2.AddMessage(message);
            }
        }
        private void AddAuditorMsg(string text)
        {
            radChat2.AddMessage(new ChatTextMessage(text, _author1, DateTime.Now));
        }
        private void AddAuditeeMsg(string text)
        {
            radChat2.AddMessage(new ChatTextMessage(text, _author2, DateTime.Now));
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _animatedThreadWorker.RunWorkerAsync();
            Focus();
        }
        private void CheckMoveToForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}