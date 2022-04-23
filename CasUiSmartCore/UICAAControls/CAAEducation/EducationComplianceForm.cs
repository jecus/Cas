using System;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.CAA.CAAEducation;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UICAAControls.CAAEducation
{
    public partial class EducationComplianceForm : MetroForm
    {
        private readonly CAAEducationRecord _record;
        private readonly LastCompliance _compliance;

        public EducationComplianceForm(CAAEducationRecord record, LastCompliance compliance)
        {
            _record = record;
            _compliance = compliance;
            InitializeComponent();
            UpdateInformation();
        }
        
        
        private void UpdateInformation()
        {
            if (_compliance.DocumentId.HasValue)
            {
                var document = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAADocumentDTO, SmartCore.Entities.General.Document>(_compliance.DocumentId.Value);
                _compliance.Document = document;
                documentControl1.CurrentDocument = document;
            }
            
            if (_compliance.LastDate.HasValue)
            {
                dateTimePickeValidTo.Value = _compliance.LastDate.Value;
                metroTextBoxRemark.Text = _compliance.Remark;
            }
            else dateTimePickeValidTo.Value = _record.Settings.Next.Value;
            documentControl1.Added += DocumentControl1_Added;
        }
        
        
        private void DocumentControl1_Added(object sender, EventArgs e)
        {
            var newDocument = new SmartCore.Entities.General.Document
            {
                Parent = _record,
                ParentId = _record.ItemId,
                ParentTypeId = _record.SmartCoreObjectType.ItemId,
                DocType = DocumentType.Document,
                IsClosed = false,
            };
            
            var form = new DocumentForm(newDocument, _record ,_record.OperatorId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _compliance.Document = newDocument;
                documentControl1.CurrentDocument = newDocument;
            }
        }

        private void ApplyChanges()
        {
            _compliance.Remark = metroTextBoxRemark.Text;
            _compliance.LastDate = dateTimePickeValidTo.Value;
            if (documentControl1.CurrentDocument != null)
                _compliance.DocumentId = documentControl1.CurrentDocument.ItemId;
            
            _record.Settings.LastCompliances.Add(_compliance);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                ApplyChanges();
                GlobalObjects.CaaEnvironment.NewKeeper.Save(_record);
                DialogResult = DialogResult.OK;
                Close();
                
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save checkList", ex);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        private void AuditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}