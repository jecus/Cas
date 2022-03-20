using System;
using System.Collections.Generic;
using System.Linq;
using CAA.Entity.Models.DTO;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.CAA.Check;
using SmartCore.CAA.PEL;
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

        public CheckMoveToForm(int checkListId, int auditId, int stageId)
        {
            InitializeComponent();
            LoadData();
            InitChart();
            
            _checkListId = checkListId;
            _auditId = auditId;
            _stageId = stageId;
        }

        private void LoadData()
        {
            var record = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<AuditPelRecordDTO, AuditPelRecord>(new List<Filter>()
            {
                new Filter("AuditId", _auditId),
                new Filter("CheckListId", _checkListId),
            });

            if (record.Any())
            {
                var pel = record.FirstOrDefault();
                var auditee = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<PelSpecialistDTO, PelSpecialist>(pel.AuditeeId);
                if (auditee != null && auditee.SpecialistId != GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
                    _to = auditee.SpecialistId;
                else
                {
                    var auditor = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<PelSpecialistDTO, PelSpecialist>(pel.AuditorId);
                    if (auditor != null && auditor.SpecialistId != GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
                        _to = auditor.SpecialistId;
                }
            }
            else
            {
                _to = -1;
            }


            var records = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListTransferDTO, CheckListTransfer>(new List<Filter>()
            {
                new Filter("AuditId", _auditId),
                new Filter("CheckListId", _checkListId),
                new Filter("WorkflowStageId", _stageId),
            });

        }

        private void InitChart()
        {
            this.radChat2.AutoAddUserMessages = false;
            this.radChat2.SendMessage += radChat1_SendMessage;
            this.radChat2.CardActionClicked += radChat1_CardActionClicked;

            radChat2.ChatElement.SendButtonElement.Enabled = false;
            radChat2.ChatElement.ShowToolbarButtonElement.Visibility = ElementVisibility.Hidden;
        }

        private void radChat1_CardActionClicked(object sender, CardActionEventArgs e)
        {
            
        }

        private void radChat1_SendMessage(object sender, SendMessageEventArgs e)
        {
            
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            // var rec = new CheckListTransfer()
            // {
            //     Created = DateTime.Now,
            //     From = GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId,
            //     To = _to,
            //     AuditId = _auditId,
            //     CheckListId = _checkListId,
            //     Settings = new CheckListTransferSettings()
            //     {
            //         Remark = metroTextBoxRemark.Text
            //     }
            // };
            //
            // GlobalObjects.CaaEnvironment.NewKeeper.Save(rec);
            //
            // if (fileControl.GetChangeStatus())
            // {
            //     fileControl.ApplyChanges();
            //     rec.AttachedFile = fileControl.AttachedFile;
            // }
            // GlobalObjects.CaaEnvironment.NewKeeper.SaveAttachedFile(rec);
            //
            // DialogResult = DialogResult.OK;
            // Close();
        }
    }
}