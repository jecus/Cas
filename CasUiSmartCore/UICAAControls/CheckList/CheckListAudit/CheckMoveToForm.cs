using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.CAA.Check;
using SmartCore.CAA.PEL;

namespace CAS.UI.UICAAControls.CheckList.CheckListAudit
{
    public partial class CheckMoveToForm : MetroForm
    {
        private readonly int _checkListId;
        private readonly int _auditId;
        private readonly int _to;

        public CheckMoveToForm(int checkListId, int auditId)
        {
            _checkListId = checkListId;
            _auditId = auditId;
            InitializeComponent();

            var record = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<AuditPelRecordDTO, AuditPelRecord>(new List<Filter>()
            {
                new Filter("AuditId", _auditId),
                new Filter("CheckListId", checkListId),
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
            
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            var rec = new CheckListTransfer()
            {
                Created = DateTime.Now,
                From = GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId,
                To = _to,
                AuditId = _auditId,
                CheckListId = _checkListId,
                FileId = attachedFileControl1.AttachedFile.ItemId,
                Settings = new CheckListTransferSettings()
                {
                    Remark = metroTextBoxRemark.Text
                }
            };
            
            GlobalObjects.CaaEnvironment.NewKeeper.Save(rec);
            
            if (fileControl.GetChangeStatus())
            {
                fileControl.ApplyChanges();
                rec.AttachedFile = fileControl.AttachedFile;
            }
            
            GlobalObjects.CaaEnvironment.NewKeeper.SaveAttachedFile(rec);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}