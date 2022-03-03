using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.UICAAControls.CheckList;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.Auxiliary;
using SmartCore.CAA;
using SmartCore.CAA.Audit;

namespace CAS.UI.UICAAControls.Audit
{
    public partial class EditAuditForm : MetroForm
    {
        private readonly int _auditId;
        private CAAAudit _audit;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private List<AllOperators> _operators = new List<AllOperators>();

        public EditAuditForm()
        {
            InitializeComponent();
        }

        public EditAuditForm(int auditId) : this()
        {
            _auditId = auditId;
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
        }


        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateInformation();
        }

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            _operators = GlobalObjects.CaaEnvironment.AllOperators;
            _audit = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAAAuditDTO, CAAAudit>(_auditId);

            var ids = _audit.Settings.Extations.Select(i => i.DocumenttId).Distinct();
            if (ids.Any())
            {
                var documents = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAADocumentDTO, SmartCore.Entities.General.Document>(new Filter("ItemId", ids));
                foreach (var extation in _audit.Settings.Extations)
                    extation.Document = documents.FirstOrDefault(i => i.ItemId == extation.DocumenttId);
                
            }
            
        }


        private void UpdateInformation()
        {
            comboBoxStatus.Items.Clear();
            comboBoxStatus.DataSource = Enum.GetValues(typeof(RoutineStatus)).Cast<RoutineStatus>().Where(i => i >= _audit.Settings.Status).ToList();
            comboBoxStatus.SelectedItem = _audit.Settings.Status;

            dateTimePickerIssueCreateDate.Value = _audit.Settings.CreateDate;
            dateTimePickerClosingDate.Value = _audit.Settings.ClosingDate;
            dateTimePickerPublishingDate.Value = _audit.Settings.PublishingDate;
            numericUpDown1.Value = _audit.Settings.KMH;

            dateTimePickerFrom.Value = _audit.Settings.From;
            dateTimePickerTo.Value = _audit.Settings.To;

            textBoxAuthor.Text = GlobalObjects.CaaEnvironment?.GetCorrector(_audit.Settings.AuthorId);
            textBoxPublishedBy.Text = GlobalObjects.CaaEnvironment?.GetCorrector(_audit.Settings.PublishedId);
            textBoxClosedBy.Text = GlobalObjects.CaaEnvironment?.GetCorrector(_audit.Settings.ClosedId);

            comboBoxWorkFlow.Items.Clear();
            comboBoxWorkFlow.Items.AddRange(WorkFlowStage.Items.ToArray());
            comboBoxWorkFlow.SelectedItem = WorkFlowStage.GetItemById(_audit.Settings.WorkflowStageId);


            comboBoxOperator.Items.Clear();
            comboBoxOperator.Items.AddRange(_operators.ToArray());
            comboBoxOperator.Items.Add(AllOperators.Unknown);
            comboBoxOperator.SelectedItem = _operators.FirstOrDefault(i => i.ItemId == _audit.OperatorId) ?? AllOperators.Unknown;
            metroTextBoxAuditNumber.Text = _audit.AuditNumber;
            
            
            foreach (var rec in _audit.Settings.Extations)
                UpdateRecords(rec);
        }

        private void ApplyChanges()
        {
            _audit.OperatorId = ((AllOperators) comboBoxOperator.SelectedItem).ItemId;
            _audit.AuditNumber =  metroTextBoxAuditNumber.Text;
            _audit.Settings.WorkflowStageId = (comboBoxWorkFlow.SelectedItem as WorkFlowStage).ItemId;
            _audit.Settings.KMH = numericUpDown1.Value;
            
            _audit.Settings.From =  dateTimePickerFrom.Value;
            _audit.Settings.To = dateTimePickerTo.Value;

            var status = (RoutineStatus)comboBoxStatus.SelectedItem;
            if (status == RoutineStatus.Published)
            {
                if (_audit.Settings.PublishingDate <= DateTimeExtend.GetCASMinDateTime())
                {
                    _audit.Settings.WorkflowStageId = WorkFlowStage.Open.ItemId;
                    _audit.Settings.PublishingDate = DateTime.Now;
                    _audit.Settings.PublishedId = GlobalObjects.CaaEnvironment.IdentityUser.ItemId;
                }
            }
            else if (status == RoutineStatus.Closed)
            {
                if(_audit.Settings.ClosingDate <= DateTimeExtend.GetCASMinDateTime())
                {
                    _audit.Settings.ClosingDate = DateTime.Now;
                    _audit.Settings.ClosedId = GlobalObjects.CaaEnvironment.IdentityUser.ItemId;
                }
                
            }
            
            _audit.Settings.Extations.Clear();
            foreach (var control in flowLayoutPanel1.Controls.OfType<ExtationControl>())
            {
                control.ApplyChanges();
                _audit.Settings.Extations.Add(control.Record);
            }

        }

        private void Save()
        {
            ApplyChanges();
            GlobalObjects.CaaEnvironment.NewKeeper.Save(_audit);
        }


        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            try
            {
                Save();
                MessageBox.Show("All records updated successfull!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
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


        private void AuditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateRecords(new Extation());
        }
        
        public void UpdateRecords(Extation record)
        {
            var control = new ExtationControl(record, _audit);
            control.Deleted += Control_Deleted;
            flowLayoutPanel1.Controls.Remove(linkLabel1);
            flowLayoutPanel1.Controls.Add(control);
            flowLayoutPanel1.Controls.Add(linkLabel1);
        }
        

        private void Control_Deleted(object sender, EventArgs e)
        {
            var control = sender as ExtationControl;
            flowLayoutPanel1.Controls.Remove(control);
            control.Deleted -= Control_Deleted;
            control.Dispose();
        }
    }
}
