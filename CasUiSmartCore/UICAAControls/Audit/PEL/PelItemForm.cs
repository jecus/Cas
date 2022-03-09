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
            specialists.Clear();
            
            var records = GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<AuditPelRecordDTO, AuditPelRecord>(new Filter("AuditId", _auditId));
            var audit = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAAAuditDTO, CAAAudit>(_auditId);
            
            specialists.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAASpecialistDTO, Specialist>(new Filter("OperatorId", new []{audit.OperatorId, -1, _operatorId}.Distinct()), loadChild: true));

            pelSpec.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<PelSpecialistDTO, PelSpecialist>(new Filter("AuditId", _auditId)));
            
            foreach (var specialist in specialists)
                specialist.Operator = GlobalObjects.CaaEnvironment.AllOperators.FirstOrDefault(i => i.ItemId == specialist.OperatorId) ?? AllOperators.Unknown;
            
            foreach (var pel in pelSpec)
                pel.Specialist = specialists.FirstOrDefault(i => i.ItemId == pel.SpecialistId);

            
            foreach (var rec in records)
            {
                var item = _addedChecks.FirstOrDefault(i => i.ItemId == rec.CheckListId);
                if(item == null)
                    continue;

                rec.CheckList = item;
                rec.Auditor = pelSpec.FirstOrDefault(i => i.ItemId == rec.AuditorId)?.Specialist ?? Specialist.Unknown;
                rec.Auditee = pelSpec.FirstOrDefault(i => i.ItemId == rec.AuditeeId)?.Specialist ?? Specialist.Unknown;
                _addedChecks.Remove(item);
                _updateChecks.Add(rec);
            }
        }

        private void UpdateInformation()
        {
            comboBoxAuditor.Items.Clear();
            comboBoxAuditor.Items.AddRange(pelSpec.Where(i => i.Specialist.Operator == AllOperators.Unknown).ToArray());
            
            comboBoxAuditee.Items.Clear();
            comboBoxAuditee.Items.AddRange(pelSpec.Where(i => i.Specialist.Operator != AllOperators.Unknown).ToArray());
            
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
                            AuditorPELPosition = auditor.PELPosition.ItemId,
                            AuditeeRoleId = auditee.Role.ItemId,
                            AuditeePELPosition = auditee.PELPosition.ItemId,
                        }
                    };
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(rec);
                    rec.CheckList = item;
                    rec.Auditor = pelSpec.FirstOrDefault(i => i.ItemId == rec.AuditorId)?.Specialist ?? Specialist.Unknown;
                    rec.Auditee = pelSpec.FirstOrDefault(i => i.ItemId == rec.AuditeeId)?.Specialist ?? Specialist.Unknown;
                    
                    
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(new CheckListTransfer()
                    {
                        Created = DateTime.Now,
                        From = -1,
                        To = (pelSpec.FirstOrDefault(i => i.ItemId == rec.AuditorId)?.Specialist ?? Specialist.Unknown).ItemId,
                        AuditId = _auditId,
                        CheckListId = item.ItemId,
                        FileId = -1,
                    });
                    
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
            var form = new AuditTeamForm(specialists, _auditId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Focus();
                _animatedThreadWorker.RunWorkerAsync();
                Focus();
            }
        }
    }
}
