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
using SmartCore.CAA.Check;
using SmartCore.CAA.PEL;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UICAAControls.Audit.PEL
{
    public partial class PelItemForm : MetroForm
    {
        private readonly int _auditId;
        private readonly int _operatorId;
        
        private CommonCollection<CheckLists> _addedChecks = new CommonCollection<CheckLists>();
        private CommonCollection<AuditPelRecord> _updateChecks = new CommonCollection<AuditPelRecord>();
        private CommonCollection<Specialist> specialists = new CommonCollection<Specialist>();
        private List<PelSpecialist> pelSpec = new List<PelSpecialist>();
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

        public PelItemForm(int auditId, int operatorId, CommonCollection<CheckLists> initialDocumentArray)
        {
            InitializeComponent();
            _auditId = auditId;
            _operatorId = operatorId;
            _addedChecks.AddRange(initialDocumentArray.ToArray());
            
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
        }

        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
             if (_addedChecks.Any(i => i.CheckUIType == CheckUIType.Iosa))
            {
                _tocheckRevisionListView = new AuditPelRecordListView();
                _fromcheckRevisionListView = new PelItemListView();
            }
            else if (_addedChecks.Any(i => i.CheckUIType == CheckUIType.Safa))
            {
                _tocheckRevisionListView = new AuditPelRecordSafaListView();
                _fromcheckRevisionListView = new PelItemSafaListView();
            }
             else if (_addedChecks.Any(i => i.CheckUIType == CheckUIType.Safa))
             {
                 _tocheckRevisionListView = new AuditPelRecordICAOListView();
                 _fromcheckRevisionListView = new PelItemICAOListView();
             }
            
            // 
            // _fromcheckRevisionListView
            // 
            _fromcheckRevisionListView.Location = new System.Drawing.Point(5, 53);
            _fromcheckRevisionListView.Name = "_fromcheckRevisionListView";
            _fromcheckRevisionListView.Size = new System.Drawing.Size(1419, 317);
            // 
            // _tocheckRevisionListView
            // 
            _tocheckRevisionListView.Location = new System.Drawing.Point(5, 417);
            _tocheckRevisionListView.Name = "_tocheckRevisionListView";
            _tocheckRevisionListView.Size = new System.Drawing.Size(1419, 346);
            
            Controls.Add(_tocheckRevisionListView);
            Controls.Add(_fromcheckRevisionListView);
            
            UpdateInformation();
        }

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            pelSpec.Clear();
            var records = GlobalObjects.CaaEnvironment.NewLoader
                 .GetObjectListAll<AuditPelRecordDTO, AuditPelRecord>(new Filter("AuditId", _auditId));

            var audit = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAAAuditDTO, CAAAudit>(_auditId);
            
            
            specialists.AddRange(GlobalObjects.CaaEnvironment.NewLoader
                .GetObjectListAll<CAASpecialistDTO, Specialist>(new Filter("OperatorId",audit.OperatorId),
                    loadChild: true));
            
            
            foreach (var rec in records)
            {
                var item = _addedChecks.FirstOrDefault(i => i.ItemId == rec.CheckListId);
                if(item == null)
                    continue;

                rec.CheckList = item;
                rec.Auditor = specialists.FirstOrDefault(i => i.ItemId == rec.AuditorId) ?? Specialist.Unknown;
                rec.Auditee = specialists.FirstOrDefault(i => i.ItemId == rec.AuditeeId) ?? Specialist.Unknown;
                _addedChecks.Remove(item);
                _updateChecks.Add(rec);
            }


            foreach (var check in _updateChecks.GroupBy(i => i.AuditorId))
            {
                var s = check.FirstOrDefault();
                var spec = new PelSpecialist()
                {
                    ItemId = s.AuditorId,
                    FirstName = s.Auditor.FirstName,
                    LastName = s.Auditor.LastName,
                    Specialization = s.Auditor.Specialization,
                    Operator = GlobalObjects.CaaEnvironment.AllOperators.FirstOrDefault(o => o.ItemId == s.Auditor.OperatorId) ?? AllOperators.Unknown
                };
                pelSpec.Add(spec);
            }
            
            foreach (var check in _updateChecks.GroupBy(i => i.AuditeeId))
            {
                var s = check.FirstOrDefault();
                var spec = new PelSpecialist()
                {
                    ItemId = s.AuditeeId,
                    FirstName = s.Auditee.FirstName,
                    LastName = s.Auditee.LastName,
                    Specialization = s.Auditee.Specialization,
                    Operator = GlobalObjects.CaaEnvironment.AllOperators.FirstOrDefault(o => o.ItemId == s.Auditee.OperatorId) ?? AllOperators.Unknown
                };
                pelSpec.Add(spec);
            }
            
        }

        private void UpdateInformation()
        {
            comboBoxAuditor.Items.Clear();
            comboBoxAuditor.Items.AddRange(pelSpec.Where(i => i.Operator == AllOperators.Unknown).ToArray());
            
            comboBoxAuditee.Items.Clear();
            comboBoxAuditee.Items.AddRange(pelSpec.Where(i => i.Operator != AllOperators.Unknown).ToArray());


            _fromcheckRevisionListView.SetItemsArray(_addedChecks.ToArray());
            _tocheckRevisionListView.SetItemsArray(_updateChecks.ToArray());
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save checkList", ex);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxAuditor.SelectedItem == null|| comboBoxAuditee.SelectedItem == null)
            {
                MessageBox.Show("Please select staff!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (_fromcheckRevisionListView.SelectedItems.Count > 0)
            {
                var auditor = comboBoxAuditor.SelectedItem as PelSpecialist;
                var auditee = comboBoxAuditee.SelectedItem as PelSpecialist;
                
                foreach (var item in _fromcheckRevisionListView.SelectedItems.ToArray())
                {
                    var rec = new AuditPelRecord()
                    {
                        AuditId = _auditId,
                        CheckListId = item.ItemId,
                        AuditorId = auditor.ItemId,
                        AuditeeId = auditee.ItemId,
                        Settings = new AuditPelRecordSettings()
                        {
                            AuditorRoleId = auditor.Role.ItemId,
                            AuditorPELResponsibilitiesId = auditor.PELResponsibilities.ItemId,
                            AuditeeRoleId = auditee.Role.ItemId,
                            AuditeePELResponsibilitiesId = auditee.PELResponsibilities.ItemId,
                        }
                    };
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(rec);
                    rec.CheckList = item;
                    rec.Auditor = specialists.FirstOrDefault(i => i.ItemId == auditor.ItemId);
                    rec.Auditee = specialists.FirstOrDefault(i => i.ItemId == auditee.ItemId);;
                    _updateChecks.Add(rec);
                    _addedChecks.Remove(item);
                }
                
                _fromcheckRevisionListView.SetItemsArray(_addedChecks.ToArray());
                _tocheckRevisionListView.SetItemsArray(_updateChecks.ToArray());
            }
        }
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_tocheckRevisionListView.SelectedItems.Count > 0)
            {
                foreach (var item in _tocheckRevisionListView.SelectedItems.ToArray())
                {
                    _updateChecks.Remove(item);
                    _addedChecks.Add(item.CheckList);
                    GlobalObjects.CaaEnvironment.NewKeeper.Delete(item);
                }

                _fromcheckRevisionListView.SetItemsArray(_addedChecks.ToArray());
                _tocheckRevisionListView.SetItemsArray(_updateChecks.ToArray());
            }
        }
        private void CheckListRevisionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        
        private void avButtonT1_Click(object sender, EventArgs e)
        {
            var listSpec = new CommonCollection<Specialist>();
            foreach (var s in specialists)
            {
                if (pelSpec.Any(i => i.ItemId == s.ItemId))
                    continue;

                listSpec.Add(s);
            }
            
            var form = new AuditTeamForm(_operatorId,listSpec);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Focus();
                
                comboBoxAuditor.Items.Clear();
                comboBoxAuditor.Items.AddRange(pelSpec.Where(i => i.Operator == AllOperators.Unknown).ToArray());
                comboBoxAuditor.Items.AddRange(form.PelSpecialists.Where(i => i.Operator == AllOperators.Unknown).ToArray());
                
                comboBoxAuditee.Items.Clear();
                comboBoxAuditee.Items.AddRange(pelSpec.Where(i => i.Operator != AllOperators.Unknown).ToArray());
                comboBoxAuditee.Items.AddRange(form.PelSpecialists.Where(i => i.Operator != AllOperators.Unknown).ToArray());
                
                
                if(comboBoxAuditor.Items.Count > 0)
                    comboBoxAuditor.SelectedIndex = 0;
                
                if(comboBoxAuditee.Items.Count > 0)
                    comboBoxAuditee.SelectedIndex = 0;
            }
        }
    }
}
