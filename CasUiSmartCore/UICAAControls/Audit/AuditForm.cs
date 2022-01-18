using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.CAA;
using SmartCore.CAA.Audit;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UICAAControls.Audit
{
    public partial class AuditForm : MetroForm
    {
        private  CAAAudit _audit;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private List<DocumentControl> DocumentControls = new List<DocumentControl>();
        private List<AllOperators> _operators = new List<AllOperators>();

        public AuditForm()
        {
            InitializeComponent();
        }

        public AuditForm(CAAAudit audit) : this()
        {
            
            
            _audit = audit;
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
        }

        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DocumentControls.AddRange(new[] { documentControl1, documentControl2, documentControl3, documentControl4, documentControl5, documentControl6, documentControl7, documentControl8, documentControl9, documentControl10 });
            UpdateInformation();
        }

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            if (_audit == null) return;

            _operators = (List<AllOperators>) GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<AllOperatorsDTO, AllOperators>();

            if (_audit.ItemId > 0)
            {
                _audit = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAAAuditDTO, CAAAudit>(_audit.ItemId);
            }
        }


        private void UpdateInformation()
        {
            comboBoxOperator.Items.Clear();
            comboBoxOperator.Items.AddRange(_operators.ToArray());
            comboBoxOperator.SelectedItem = _operators.FirstOrDefault(i => i.ItemId == _audit.OperatorId) ?? _operators.FirstOrDefault();

            comboBoxStatus.Items.Clear();
            foreach (var status in Enum.GetValues(typeof(CAARoutineStatus)).Cast<CAARoutineStatus>())
                comboBoxStatus.Items.Add(status);
            comboBoxStatus.SelectedItem = _audit.Settings.Status;

            comboBoxStage.Items.Clear();
            comboBoxStage.Items.AddRange(WorkFlowStage.Items.ToArray());
            comboBoxStage.SelectedItem = _audit.Settings.WorkflowStage;

            comboBoxWorkflowStatus.Items.Clear();
            comboBoxWorkflowStatus.Items.AddRange(WorkFlowStatus.Items.ToArray());
            comboBoxWorkflowStatus.SelectedItem = _audit.Settings.WorkflowStatus;

            
            comboBoxAuditType.Items.Clear();
            comboBoxAuditType.Items.AddRange(AuditType.Items.ToArray());
            comboBoxAuditType.SelectedItem = _audit.Settings.AuditType;


            metroTextBoxAuditNumber.Text = _audit.AuditNumber;
            metroTextBoxTitle.Text = _audit.Title;
            textBoxDescription.Text = _audit.Description;
            dateTimePickerIssueCreateDate.Value = _audit.Settings.CreateDate;
            dateTimePickerOpeningDate.Value = _audit.Settings.OpeningDate;
            dateTimePickerPublishingDate.Value = _audit.Settings.PublishingDate;
            dateTimePickerClosingDate.Value = _audit.Settings.ClosingDate;

            textBoxAuthor.Text = GlobalObjects.CaaEnvironment.GetCorrector(_audit.Settings.AuthorId);
            textBoxPublishedBy.Text = GlobalObjects.CaaEnvironment.GetCorrector(_audit.Settings.PublishedById);
            textBoxPublishingRemark.Text = _audit.Settings.PublishedRemark;
            textBoxClosedBy.Text = GlobalObjects.CaaEnvironment.GetCorrector(_audit.Settings.ClosedById);
            textBoxClosingRemarks.Text = _audit.Settings.ClosedRemark;
            numericUpDownMH.Value = _audit.Settings.KMH;
            textBoxRemarks.Text = _audit.Settings.Remark;

            if (_audit.ItemId > 0)
            {
                foreach (var control in DocumentControls)
                    control.Added += DocumentControl1_Added;

                for (int i = 0; i < _audit.Documents.Count; i++)
                {
                    var control = DocumentControls[i];
                    control.CurrentDocument = _audit.Documents[i];
                }
            }
            else
            {
                textBoxAuthor.Text = GlobalObjects.CaaEnvironment.IdentityUser.Name;
                dateTimePickerIssueCreateDate.Value = DateTime.Now;
            }

            
        }

        private void ApplyChanges()
        {
            _audit.OperatorId = ((AllOperators) comboBoxOperator.SelectedItem).ItemId;
            _audit.Settings.Status = (CAARoutineStatus) comboBoxStatus.SelectedItem;
            _audit.Settings.WorkflowStage = (WorkFlowStage)comboBoxStage.SelectedItem;
            _audit.Settings.WorkflowStatus = (WorkFlowStatus)comboBoxWorkflowStatus.SelectedItem;
            _audit.Settings.AuditType = (AuditType)comboBoxAuditType.SelectedItem;

            _audit.AuditNumber =  metroTextBoxAuditNumber.Text;
            _audit.Title = metroTextBoxTitle.Text;
            _audit.Description = textBoxDescription.Text;
            _audit.Settings.KMH = numericUpDownMH.Value;
            _audit.Settings.Remark = textBoxRemarks.Text;

            _audit.Settings.ClosedRemark = textBoxClosingRemarks.Text;
            _audit.Settings.PublishedRemark = textBoxPublishingRemark.Text;
        }


        private void DocumentControl1_Added(object sender, EventArgs e)
        {
            //var control = sender as DocumentControl;
            //var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Work package") as DocumentSubType;
            //var newDocument = new SmartCore.Entities.General.Document
            //{
            //    Parent = _audit,
            //    ParentId = _audit.ItemId,
            //    ParentTypeId = _audit.SmartCoreObjectType.ItemId,
            //    DocType = DocumentType.TechnicalRecords,
            //    DocumentSubType = docSubType,
            //    IsClosed = true,
            //    ContractNumber = $"{_audit.AuditNumber}",
            //    Description = _audit.Title,
            //};

            //var form = new DocumentForm(newDocument, false);
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    _audit.Documents.Add(newDocument);
            //    control.CurrentDocument = newDocument;

            //}
        }

        



        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            try
            {
                ApplyChanges();

                GlobalObjects.CaaEnvironment.NewKeeper.Save(_audit, true);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save checkList", ex);
            }
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
