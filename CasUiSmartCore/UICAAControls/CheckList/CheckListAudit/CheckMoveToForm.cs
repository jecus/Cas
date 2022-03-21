using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.General;
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
        private bool _entedPressed;
        private readonly int _checkListId;
        
        private readonly int _auditId;
        private readonly int _stageId;
        
        private int _to;
        private readonly AuditCheck _auditCheck;
        private bool _isAuditor;
        
        private  Author _author1;
        private  Author _author2;
        private PelSpecialist _opponent;
        
        public CheckMoveToForm(AuditCheck auditCheck, bool isAuditor)
        {
            InitializeComponent();
            
            _checkListId = auditCheck.CheckListId;
            _auditId = auditCheck.AuditId;
            _stageId = auditCheck.Settings.WorkflowStageId;
            _auditCheck = auditCheck;
            _isAuditor = isAuditor;
            _entedPressed = !_isAuditor;
            
            
            InitChart();
            LoadData();
        }

        private void InitChart()
        {
            radChat2.AutoAddUserMessages = false;
            radChat2.SendMessage += radChat1_SendMessage;
            radChat2.CardActionClicked += radChat1_CardActionClicked;

            radChat2.ChatElement.SendButtonElement.Enabled = _isAuditor;
            radChat2.ChatElement.ShowToolbarButtonElement.Visibility = ElementVisibility.Hidden;
            radChat2.ChatElement.ShowToolbarButtonElement.TextWrap = true;
        }

        private void LoadData()
        {
            var record = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<AuditPelRecordDTO, AuditPelRecord>(new List<Filter>()
            {
                new Filter("AuditId", _auditId),
                new Filter("CheckListId", _checkListId),
            });

            var pel = record.FirstOrDefault();
            var auditee = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<PelSpecialistDTO, PelSpecialist>(pel.AuditeeId);


            if (auditee != null && auditee.SpecialistId != GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
            {
                _opponent = auditee;
                _to = auditee.SpecialistId;
            }
            else
            {
                var auditor = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<PelSpecialistDTO, PelSpecialist>(pel.AuditorId);
                if (auditor != null && auditor.SpecialistId != GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
                {
                    _opponent = auditor;
                    _to = auditor.SpecialistId;
                }
            }

            var records = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListTransferDTO, CheckListTransfer>(new List<Filter>()
            {
                new Filter("AuditId", _auditId),
                new Filter("CheckListId", _checkListId),
                new Filter("WorkflowStageId", _stageId),
            });


            var spec = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<SpecialistDTO, Specialist>(_to);

            _author1 = new Author(null, GlobalObjects.CaaEnvironment.IdentityUser.ToString());
            _author2 = new Author(null, spec.ToString());
            
            
            radChat2.Author = _author1;

            var last = records.Count > 1 ? records.LastOrDefault() : null;
            foreach (var message in records.Where(i => i.To > -1 && i.From > -1))
            {
                if (message.From == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
                {
                    AddAuditorMsg(message.Settings.Remark);
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
        
        
        
        private void radChat1_CardActionClicked(object sender, CardActionEventArgs e)
        {
            if (e.Action.Text == "Accept")
            {
                var res = MessageBox.Show($"Do you really want move to next stage({WorkFlowStage.GetItemById(_stageId + 1).FullName})?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes)
                {
                    _auditCheck.Settings.WorkflowStageId = _stageId + 1;
                    _auditCheck.Settings.WorkflowStatusId = WorkFlowStatus.Open.ItemId;
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(_auditCheck);
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
                To = _to,
                AuditId = _auditId,
                CheckListId = _checkListId,
                Settings = new CheckListTransferSettings()
                {
                    Remark = textMessage.Message,
                    WorkflowStageId = _stageId
                }
            };
            GlobalObjects.CaaEnvironment.NewKeeper.Save(rec);
            
            radChat2.ChatElement.SendButtonElement.Enabled = false;
            
            if (_opponent.SpecialistId == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
            {
                radChat2.ChatElement.MessagesViewElement.Items.Remove(radChat2.ChatElement.MessagesViewElement.Items.Last());
                AddAuditorMsg(textMessage.Message);
            }
            else AddAuditeeMsg(textMessage.Message);

           
            
            _entedPressed = true;

        }

        
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}