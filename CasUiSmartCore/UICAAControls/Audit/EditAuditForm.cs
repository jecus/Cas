using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.CAA;
using SmartCore.CAA.Audit;
using SmartCore.CAA.RoutineAudits;

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
            if (_audit == null) return;

            _operators = GlobalObjects.CaaEnvironment.AllOperators;
            _audit = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAAAuditDTO, CAAAudit>(_auditId);
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

            textBoxAuthor.Text = GlobalObjects.CaaEnvironment?.GetCorrector(_audit.Settings.AuthorId);
            textBoxPublishedBy.Text = GlobalObjects.CaaEnvironment?.GetCorrector(_audit.Settings.PublishedId);
            textBoxClosedBy.Text = GlobalObjects.CaaEnvironment?.GetCorrector(_audit.Settings.ClosedId);

            comboBoxWorkFlow.Items.Clear();
            comboBoxWorkFlow.Items.AddRange(WorkFlowStage.Items.ToArray());
            comboBoxWorkFlow.SelectedItem = WorkFlowStage.GetItemById(_audit.Settings.WorkflowStageId);

            comboBoxOperator.Items.Clear();
            comboBoxOperator.Items.AddRange(_operators.ToArray());
            comboBoxOperator.SelectedItem = _operators.FirstOrDefault(i => i.ItemId == _audit.Settings.OperatorId) ?? _operators.FirstOrDefault();
            metroTextBoxAuditNumber.Text = _audit.AuditNumber;
        }

        private void ApplyChanges()
        {
            _audit.Settings.OperatorId = ((AllOperators) comboBoxOperator.SelectedItem).ItemId;
            _audit.AuditNumber =  metroTextBoxAuditNumber.Text;
            _audit.Settings.WorkflowStageId = (comboBoxWorkFlow.SelectedItem as WorkFlowStage).ItemId;
            _audit.Settings.KMH = numericUpDown1.Value;

            var status = (RoutineStatus)comboBoxStatus.SelectedItem;
            if (status == RoutineStatus.Published)
            {
                _audit.Settings.PublishingDate = DateTime.Now;
                _audit.Settings.PublishedId = GlobalObjects.CaaEnvironment.IdentityUser.ItemId;
            }
            else if (status == RoutineStatus.Closed)
            {
                _audit.Settings.ClosingDate = DateTime.Now;
                _audit.Settings.ClosedId = GlobalObjects.CaaEnvironment.IdentityUser.ItemId;
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
    }
}
