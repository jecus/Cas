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
    public partial class CheckMoveToForm : MetroForm
    {
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        
        private bool _entedPressed;
        
        private readonly int _checkListId;
        private readonly int _auditId;
        private  int _stageId;
        
        private readonly AuditCheck _auditCheck;
        private bool _isAuditor;
        
        private  Author _author1;
        private  Author _author2;
        private  Author _author3;
        private PelSpecialist _opponent;
        private IList<CheckListTransfer> _records = new List<CheckListTransfer>();

        public CheckMoveToForm(AuditCheck auditCheck, bool isAuditor)
        {
            InitializeComponent();
            
            _checkListId = auditCheck.CheckListId;
            _auditId = auditCheck.AuditId;
            _stageId = auditCheck.Settings.WorkflowStageId;
            _auditCheck = auditCheck;
            _isAuditor = isAuditor;
            _entedPressed = !_isAuditor;
            
            UpdateChat();
            
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
            
        }

        void UpdateChat()
        {
            _author3 = new Author(null, "bot");
            radChat2.ChatElement.ShowToolbarButtonElement.TextWrap = true;
            radChat2.ChatElement.ShowToolbarButtonElement.Visibility = ElementVisibility.Hidden;
            radChat2.AutoAddUserMessages = false;
            radChat2.SendMessage += radChat1_SendMessage;
            radChat2.CardActionClicked += radChat1_CardActionClicked;
        }
        
        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            var last = _records.Count == 1 ? _records.FirstOrDefault() : _records.Count > 1 ? _records.LastOrDefault() : null;
            radChat2.ChatElement.SendButtonElement.Enabled = last?.To == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId;
            _entedPressed = last?.To != GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId;
                
            foreach (var message in _records.Where(i => i.To > -1 && i.From > -1))
            {
                if (message.From == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
                {
                    AddAuditorMsg(message.Settings.Remark);
                    if (last != null &&
                        last.ItemId == message.ItemId &&
                        last.From != _opponent.SpecialistId)
                        AddBotWaitMsg();
                }
                else
                {
                    AddAuditeeMsg(message.Settings.Remark);
                    if (last != null &&
                        last.ItemId == message.ItemId &&
                        last.To == _opponent.SpecialistId)
                        AddBotMsg();
                }
            }
        }
        
        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            radChat2.ChatElement.MessagesViewElement.Items.Clear();
            _records.Clear();
            
            var record = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<AuditPelRecordDTO, AuditPelRecord>(new List<Filter>()
            {
                new Filter("AuditId", _auditId),
                new Filter("CheckListId", _checkListId),
            });

            var pel = record.FirstOrDefault();
            var auditee = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<PelSpecialistDTO, PelSpecialist>(pel.AuditeeId);


            if (auditee != null && auditee.SpecialistId != GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
                _opponent = auditee;
            else
            {
                var auditor = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<PelSpecialistDTO, PelSpecialist>(pel.AuditorId);
                if (auditor != null && auditor.SpecialistId != GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
                    _opponent = auditor;
            }

            _records = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListTransferDTO, CheckListTransfer>(new List<Filter>()
            {
                new Filter("AuditId", _auditId),
                new Filter("CheckListId", _checkListId),
                new Filter("WorkflowStageId", _stageId),
            });


            var spec = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<SpecialistDTO, Specialist>(_opponent.SpecialistId);

            _author1 = new Author(null, GlobalObjects.CaaEnvironment.IdentityUser.ToString());
            _author2 = new Author(null, spec.ToString());
            radChat2.Author = _author1;
        }
        
        private void AddBotMsg()
        {
            var actions = new List<ChatCardAction>();
            actions.Add(new ChatCardAction("Accept"));
            var imageCard = new ChatImageCardDataItem(null, "", "",$"Move to next stage({WorkFlowStage.GetItemById(_stageId + 1).FullName})?", actions, null);
            var message = new ChatCardMessage(imageCard, _author1, DateTime.Now);
            radChat2.AddMessage(message);;
            
        }
        private void AddAuditorMsg(string text)
        {
            radChat2.AddMessage(new ChatTextMessage(text, _author1, DateTime.Now));
        }
        private void AddAuditeeMsg(string text)
        {
            radChat2.AddMessage(new ChatTextMessage(text, _author2, DateTime.Now));
        }
        
        private void AddBotWaitMsg()
        {
            radChat2.AddMessage(new ChatTextMessage($"Wait for a response from {_author2.Name}...", _author3, DateTime.Now));
        }
        
        
        private void radChat1_CardActionClicked(object sender, CardActionEventArgs e)
        {
            if (e.Action.Text == "Accept")
            {
                var res = MessageBox.Show($"Do you really want move to next stage({WorkFlowStage.GetItemById(_stageId + 1).FullName})?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes)
                {
                    _stageId = _stageId + 1;
                    _auditCheck.Settings.WorkflowStageId = _stageId;
                    _auditCheck.Settings.WorkflowStatusId = WorkFlowStatus.Open.ItemId;
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(_auditCheck);
                    
                    var rec = new CheckListTransfer()
                    {
                        Created = DateTime.Now,
                        From = GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId,
                        To = GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId,
                        AuditId = _auditId,
                        CheckListId = _checkListId,
                        Settings = new CheckListTransferSettings()
                        {
                            Remark = "Workflow stage Updated!",
                            WorkflowStageId = _stageId
                        }
                    };
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(rec);
                    
                }
            }
        }
        private void radChat1_SendMessage(object sender, SendMessageEventArgs e)
        {
            if(_entedPressed)
                return;
            
            var textMessage = e.Message as ChatTextMessage;
            
            var rec = new CheckListTransfer()
            {
                Created = DateTime.Now,
                From = GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId,
                To = _opponent.SpecialistId,
                AuditId = _auditId,
                CheckListId = _checkListId,
                Settings = new CheckListTransferSettings()
                {
                    Remark = textMessage.Message,
                    WorkflowStageId = _stageId
                }
            };
            GlobalObjects.CaaEnvironment.NewKeeper.Save(rec);

            if (_auditCheck.Settings.WorkflowStatusId != WorkFlowStatus.Review.ItemId)
            {
                _auditCheck.Settings.WorkflowStatusId = WorkFlowStatus.Review.ItemId;
                GlobalObjects.CaaEnvironment.NewKeeper.Save(_auditCheck);
            }
            
            
            radChat2.ChatElement.SendButtonElement.Enabled = false;
            
            if (_opponent.SpecialistId == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
                radChat2.ChatElement.MessagesViewElement.Items.Remove(radChat2.ChatElement.MessagesViewElement.Items.Last());
            
            AddAuditorMsg(textMessage.Message);
            AddBotWaitMsg();
           
            
            _entedPressed = true;

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