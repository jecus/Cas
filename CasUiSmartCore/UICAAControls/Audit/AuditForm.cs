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
    public partial class AuditForm : MetroForm
    {
        private CAAAudit _audit;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private List<AllOperators> _operators = new List<AllOperators>();
        private List<SmartCore.CAA.RoutineAudits.RoutineAudit> _addedChecks = new List<SmartCore.CAA.RoutineAudits.RoutineAudit>();
        private List<SmartCore.CAA.RoutineAudits.RoutineAudit> _updateChecks = new List<SmartCore.CAA.RoutineAudits.RoutineAudit>();
        private List<CAAAuditRecord> _records = new List<CAAAuditRecord>();

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
            UpdateInformation();
        }

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            if (_audit == null) return;

            _operators = GlobalObjects.CaaEnvironment.AllOperators;

            _updateChecks.Clear();
            _addedChecks.Clear();
            _addedChecks = GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<RoutineAuditDTO, SmartCore.CAA.RoutineAudits.RoutineAudit>(loadChild: true).ToList();

            if (_audit.ItemId > 0)
            {
                _audit = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAAAuditDTO, CAAAudit>(_audit.ItemId);

                _records = GlobalObjects.CaaEnvironment.NewLoader
                    .GetObjectListAll<CAAAuditRecordDTO, CAAAuditRecord>(new Filter("AuditId", _audit.ItemId), loadChild: true).ToList();

                var ids = _records.Select(i => i.RoutineAuditId);
                _updateChecks.AddRange(_addedChecks.Where(i => ids.Contains(i.ItemId)));

                foreach (var check in _updateChecks)
                    _addedChecks.Remove(check);

            }
        }


        private void UpdateInformation()
        {
            _fromroutineAuditListView.SetItemsArray(_addedChecks.ToArray());
            _toroutineAuditListView.SetItemsArray(_updateChecks.ToArray());

            comboBoxOperator.Items.Clear();
            comboBoxOperator.Items.AddRange(_operators.ToArray());
            
            comboBoxOperator.SelectedItem = _operators.FirstOrDefault(i => i.ItemId == _audit.Settings.OperatorId) ?? _operators.FirstOrDefault();
            metroTextBoxAuditNumber.Text = _audit.AuditNumber;
            textBoxRemarks.Text = _audit.Settings.Remark;
        }

        private void ApplyChanges()
        {
            _audit.Settings.OperatorId = ((AllOperators) comboBoxOperator.SelectedItem).ItemId;
            _audit.AuditNumber =  metroTextBoxAuditNumber.Text;
            _audit.Settings.Remark = textBoxRemarks.Text;
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

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (_fromroutineAuditListView.SelectedItems.Count == 0) return;


            if (_fromroutineAuditListView.SelectedItems.Count > 1)
            {
                MessageBox.Show("You can add only one Routine audit!!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }


            if (string.IsNullOrEmpty(_audit.AuditNumber))
                metroTextBoxAuditNumber.Text = $"{GlobalObjects.CaaEnvironment.IdentityUser.Name} ({SmartCore.Auxiliary.Convert.GetDateFormat(_audit.Settings.CreateDate)} {_audit.Settings.CreateDate.TimeOfDay.Hours}:{_audit.Settings.CreateDate.TimeOfDay.Minutes}:{_audit.Settings.CreateDate.TimeOfDay.Seconds})";

            if (_audit.ItemId <= 0)
                Save();


            if (_updateChecks.Any())
            {
                var form = MessageBox.Show("Do yoy really wand replace Routine audit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (form == DialogResult.No)
                    return;

                foreach (var check in _updateChecks.ToArray())
                {
                    GlobalObjects.CaaEnvironment.NewKeeper.Delete(check);
                    _updateChecks.Remove(check);
                    _addedChecks.Add(check);
                }
            }

            foreach (var item in _fromroutineAuditListView.SelectedItems.ToArray())
            {
                var rec = new CAAAuditRecord()
                {
                    AuditId = _audit.ItemId,
                    RoutineAuditId = item.ItemId
                };

                GlobalObjects.CaaEnvironment.NewKeeper.Save(rec);
                _records.Add(rec);


                _updateChecks.Add(item);
                _addedChecks.Remove(item);
            }

            _fromroutineAuditListView.SetItemsArray(_addedChecks.ToArray());
            _toroutineAuditListView.SetItemsArray(_updateChecks.ToArray());
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_toroutineAuditListView.SelectedItems.Count == 0) return;


            var dialog = MessageBox.Show("Do you really wand delete records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (dialog == DialogResult.Yes)
            {
                foreach (var item in _toroutineAuditListView.SelectedItems.ToArray())
                {
                    _updateChecks.Remove(item);
                    _addedChecks.Add(item);

                    var delete = _records.FirstOrDefault(i => i.RoutineAuditId == item.ItemId);
                    if (delete != null)
                        GlobalObjects.CaaEnvironment.NewKeeper.Delete(delete);
                }

                _fromroutineAuditListView.SetItemsArray(_addedChecks.ToArray());
                _toroutineAuditListView.SetItemsArray(_updateChecks.ToArray());
            }
        }

        private void AuditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
