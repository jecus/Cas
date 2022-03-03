using System;
using System.Windows.Forms;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using SmartCore.CAA.Audit;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class ExtationControl : UserControl
    {
        public readonly Extation Record;
        private readonly CAAAudit _audit;

        public ExtationControl()
        {
            InitializeComponent();
        }


        public ExtationControl(Extation record, CAAAudit caaAudit) : this()
        {
            Record = record;
            _audit = caaAudit;
            UpdateInformation();
        }

        
        public void ApplyChanges()
        {
            Record.Remark = textBoxRemarks.Text;
            Record.ExtationString = metroTextBoxExtation.Text;
            if (documentControl1.CurrentDocument != null)
                Record.DocumenttId = documentControl1.CurrentDocument.ItemId;
        }
        
        private void UpdateInformation()
        {
            textBoxRemarks.Text = Record.Remark;
            metroTextBoxExtation.Text = Record.ExtationString;
            documentControl1.CurrentDocument = Record.Document;
            documentControl1.Added += DocumentControl1_Added;
        }

        private void DocumentControl1_Added(object sender, EventArgs e)
        {
            var newDocument = new SmartCore.Entities.General.Document
            {
                Parent = _audit,
                ParentId = _audit.ItemId,
                ParentTypeId = _audit.SmartCoreObjectType.ItemId,
                DocType = DocumentType.Document,
                IsClosed = false,
            };

            var form = new DocumentForm(newDocument, _audit ,_audit.OperatorId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Record.Document = newDocument;
                documentControl1.CurrentDocument = newDocument;

            }
        }

        public event EventHandler<EventArgs> AddDocument;
        
        
        public event EventHandler<EventArgs> Deleted;
        
        private void linkLabelAddNew_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(Deleted != null)
                Deleted.Invoke(this, EventArgs.Empty);
        }
    }
}