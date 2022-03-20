﻿using System;
using System.Collections.Generic;
using System.Linq;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.General;
using CASTerms;
using MetroFramework.Forms;
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
        private readonly int _checkListId;
        private readonly int _auditId;
        private readonly int _stageId;
        
        private int _to;
        private bool _isAuditor;
        
        private  Author _author1;
        private  Author _author2;
        private PelSpecialist _auditor;

        public CheckMoveToForm(int checkListId, int auditId, int stageId, bool isAuditor)
        {
            InitializeComponent();
            
            _checkListId = checkListId;
            _auditId = auditId;
            _stageId = stageId;
            _isAuditor = isAuditor;
            
            
            InitChart();
            LoadData();
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
                _auditor = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<PelSpecialistDTO, PelSpecialist>(pel.AuditorId);
                
                if (auditee != null && auditee.SpecialistId != GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
                    _to = auditee.SpecialistId;
                else
                {
                    if (_auditor != null && _auditor.SpecialistId != GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
                        _to = _auditor.SpecialistId;
                }


            var records = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListTransferDTO, CheckListTransfer>(new List<Filter>()
            {
                new Filter("AuditId", _auditId),
                new Filter("CheckListId", _checkListId),
                new Filter("WorkflowStageId", _stageId),
            });


            var spec = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<SpecialistDTO, Specialist>(_to);
            
            if (_auditor.SpecialistId == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
            {
                _author1 = new Author(null, GlobalObjects.CaaEnvironment.IdentityUser.ToString());
                _author2 = new Author(null, spec.ToString());
            }
            else
            {
                _author2 = new Author(null, GlobalObjects.CaaEnvironment.IdentityUser.ToString());
                _author1 = new Author(null, spec.ToString());
            }
            
            
            radChat2.Author = _author1;

            var last = records.Count > 1 ? records.LastOrDefault() : null;
            foreach (var message in records.Where(i => i.To > -1 && i.From > -1))
            {
                if (message.From == _auditor.SpecialistId)
                {
                    AddAuditorMsg(message.Settings.Remark);
                }
                else
                {
                    AddAuditeeMsg(message.Settings.Remark);
                    if (last?.To == _auditor.SpecialistId)
                        AddBotMsg();
                }
            }
        }

        private void AddBotMsg()
        {
            var actions = new List<ChatCardAction>();
            actions.Add(new ChatCardAction("Accept"));
            var imageCard = new ChatImageCardDataItem(null, "можно тут текст ", "и вот тут","Подтвердить что задача верна!", actions, null);
            var message = new ChatCardMessage(imageCard, _author1, DateTime.Now);
            this.radChat2.AddMessage(message);;
            
        }
        
        private void AddAuditorMsg(string text)
        {
            this.radChat2.AddMessage(new ChatTextMessage(text, _author1, DateTime.Now));
        }
        private void AddAuditeeMsg(string text)
        {
            this.radChat2.AddMessage(new ChatTextMessage(text, _author2, DateTime.Now));
        }

        private void InitChart()
        {
            this.radChat2.AutoAddUserMessages = false;
            this.radChat2.SendMessage += radChat1_SendMessage;
            this.radChat2.CardActionClicked += radChat1_CardActionClicked;

            radChat2.ChatElement.SendButtonElement.Enabled = _isAuditor;
            radChat2.ChatElement.ShowToolbarButtonElement.Visibility = ElementVisibility.Hidden;
            radChat2.ChatElement.ShowToolbarButtonElement.TextWrap = true;
        }
        
        private void radChat1_CardActionClicked(object sender, CardActionEventArgs e)
        {
            
        }

        private void radChat1_SendMessage(object sender, SendMessageEventArgs e)
        {
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
            
            if (_auditor.SpecialistId == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
                AddAuditorMsg(textMessage.Message);
            else AddAuditeeMsg(textMessage.Message);

        }
    }
}