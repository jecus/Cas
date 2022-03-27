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

namespace CAS.UI.UICAAControls.CheckList.CheckListAudit.MoveToForms
{
    public class ComboboxItem
    {
        public string Name { get; set; }
        public int? WorkflowId{ get; set; }
        
        private static ComboboxItem _all;

        public static ComboboxItem All =>
            _all ?? (_all = new ComboboxItem
            {
                Name = "All",
            });

        public override string ToString()
        {
            return Name;
        }
    }
    
    public partial class ShowMoveToForm : MetroForm
    {
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        
        private IList<CheckListTransfer> _records = new List<CheckListTransfer>();
        public int _checkListId => _auditCheck.CheckListId; 
        public int _auditId => _auditCheck.AuditId;
        public int? _stageId;
        
        private readonly AuditCheck _auditCheck;
        private bool _isAuditor;
        private int _auditorId;

        private  Author _author1;
        private  Author _author2;
        private PelSpecialist _auditee;
        private PelSpecialist _auditor;
        private List<ComboboxItem> _groups = new List<ComboboxItem>();
        private ComboboxItem _selectedItem = ComboboxItem.All;

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
            radChat2.ChatElement.ShowToolbarButtonElement.TextWrap = true;
            radChat2.ChatElement.ShowToolbarButtonElement.Visibility = ElementVisibility.Hidden;
            radChat2.ChatElement.SendButtonElement.Enabled = false;
            radChat2.AutoAddUserMessages = false;
        }
        
        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_groups.All(i => !i.WorkflowId.HasValue))
            {
                _groups.Add(ComboboxItem.All);
                _groups.AddRange(_records.Where(i => i.To > -1 && i.From > -1).GroupBy(i => i.WorkflowStageId)
                    .Select(i => new ComboboxItem() { Name = WorkFlowStage.GetItemById(i.Key).ToString(), WorkflowId = i.Key }));
                comboBoxWF.Items.Clear();
                comboBoxWF.Items.AddRange(_groups.ToArray());
                
                this.comboBoxWF.SelectedIndexChanged -= new System.EventHandler(this.comboBoxWF_SelectedIndexChanged);
                comboBoxWF.SelectedItem = _selectedItem; 
                this.comboBoxWF.SelectedIndexChanged += new System.EventHandler(this.comboBoxWF_SelectedIndexChanged);
            }
            
            radChat2.ChatElement.MessagesViewElement.Items.Clear();

            var chatData = _records.Where(i => i.To > -1 && i.From > -1);
            if (_selectedItem.WorkflowId.HasValue)
                chatData = chatData.Where(i => i.WorkflowStageId == _selectedItem.WorkflowId.Value);
            
            foreach (var transfer in chatData)
            {
                if (transfer.From == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId && transfer.To == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId )
                    AddAuditorMsg(transfer);
                else if (transfer.From == _auditor.SpecialistId)
                    AddAuditorMsg(transfer);
                else
                    AddAuditeeMsg(transfer);
            }
        }
        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            _records.Clear();
            _groups.Clear();
            
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
            radChat2.Author = _author1;
        }
        
        private void AddAuditorMsg(CheckListTransfer tag)
        {
            radChat2.AddMessage(new CustomChatTextMessage<CheckListTransfer>(tag, tag.Settings.Remark, _author1, DateTime.Now));
        }
        private void AddAuditeeMsg(CheckListTransfer tag)
        {
            radChat2.AddMessage(new CustomChatTextMessage<CheckListTransfer>(tag, tag.Settings.Remark, _author2, DateTime.Now));
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

        private void comboBoxWF_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedItem = comboBoxWF.SelectedItem as ComboboxItem;
            _animatedThreadWorker.RunWorkerAsync();
            Focus();
        }
    }
}