using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.General;
using CAS.UI.UICAAControls.CheckList.CheckListAudit.MoveToForms;
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
        public int _stageId => _auditCheck.Settings.WorkflowStageId;
        
        private readonly AuditCheck _auditCheck;
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

            UpdateChat();
            
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
            
        }

        void UpdateChat()
        {
            _bot = new Author(null, "bot");
        }
        
        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            
            foreach (var group in _records.Where(i => i.To > -1 && i.From > -1).GroupBy(i => i.WorkflowStageId))
            {
                var radChat = new RadChat()
                {
                    ThemeName = "TelerikMetroBlue"
                };
                radChat.ChatElement.MessagesViewElement.Items.Clear();
                radChat.ChatElement.ShowToolbarButtonElement.TextWrap = true;
                radChat.ChatElement.ShowToolbarButtonElement.Visibility = ElementVisibility.Hidden;
                radChat.ChatElement.SendButtonElement.Enabled = false;
                radChat.AutoAddUserMessages = false;
                radChat.Author = _author1;
                
                foreach (var transfer in group)
                {
                    if (transfer.From == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId && transfer.To == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId )
                        AddAuditorMsg(radChat,transfer);
                    else if (transfer.From == _auditor.SpecialistId)
                        AddAuditorMsg(radChat,transfer);
                    else
                        AddAuditeeMsg(radChat,transfer);
                }
                
                flowLayoutPanel1.Controls.Add(new RadCollapsiblePanel()
                {
                    Text = WorkFlowStage.GetItemById(group.Key).ToString(),
                    IsExpanded = false,
                    Dock = DockStyle.Fill,
                    ThemeName = "TelerikMetroBlue",
                    Controls = { radChat },
                });
                
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
            
            if(!record.Any())
                return;
            
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
        }
        
        private void AddAuditorMsg(RadChat chat, CheckListTransfer tag)
        {
            chat.AddMessage(new CustomChatTextMessage<CheckListTransfer>(tag, tag.Settings.Remark, _author1, DateTime.Now));
        }
        private void AddAuditeeMsg(RadChat chat,CheckListTransfer tag)
        {
            chat.AddMessage(new CustomChatTextMessage<CheckListTransfer>(tag, tag.Settings.Remark, _author2, DateTime.Now));
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