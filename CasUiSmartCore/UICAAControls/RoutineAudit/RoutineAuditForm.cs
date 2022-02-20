using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.CAA.Check;
using SmartCore.CAA.FindingLevel;
using SmartCore.CAA.RoutineAudits;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UICAAControls.RoutineAudit
{
    public partial class RoutineAuditForm : MetroForm
    {
        private SmartCore.CAA.RoutineAudits.RoutineAudit _audit;
        private List<CheckLists> _addedChecks = new List<CheckLists>();
        private List<CheckLists> _updateChecks = new List<CheckLists>();
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private IList<FindingLevels> _levels = new List<FindingLevels>();
        private List<RoutineAuditRecord> _records = new List<RoutineAuditRecord>();

        public RoutineAuditForm()
        {
            InitializeComponent();
        }

        public RoutineAuditForm(SmartCore.CAA.RoutineAudits.RoutineAudit audit) : this()
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
            _updateChecks.Clear();
            _addedChecks.Clear();
            
            var editions = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionDTO, CheckListRevision>(new List<Filter>()
            {
                new Filter("Status", (byte)EditionRevisionStatus.Open),
                new Filter("Type", (byte)RevisionType.Edition),
            });
            if (editions.Any())
            {
                var edition = editions.FirstOrDefault();
                _addedChecks.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CheckListDTO, CheckLists>(new Filter("EditionId", edition.ItemId), loadChild:true));
		            
                foreach (var check in _addedChecks)
                    check.EditionNumber = edition.Number;
            }
            _levels.Clear();
            _levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new Filter("OperatorId", _audit.OperatorId));

            foreach (var check in _addedChecks)
            {
                check.Level = _levels.FirstOrDefault(i => i.ItemId == check.Settings.LevelId) ??
                              FindingLevels.Unknown;


                check.Remains = Lifelength.Null;
                check.Condition = ConditionState.Satisfactory;
            }


            if (_audit.ItemId > 0)
            {
                _records = GlobalObjects.CaaEnvironment.NewLoader
                    .GetObjectListAll<RoutineAuditRecordDTO, RoutineAuditRecord>(new Filter("RoutineAuditId", _audit.ItemId), loadChild: true).ToList();

                var ids = _records.Select(i => i.CheckListId);
                _updateChecks.AddRange(_addedChecks.Where(i => ids.Contains(i.ItemId)));


                foreach (var check in _updateChecks)
                    _addedChecks.Remove(check);
            }

        }

        private void UpdateInformation()
        {
            comboBoxProgramType.Items.Clear();
            comboBoxProgramType.Items.AddRange(ProgramType.Items.OrderBy(i => i.FullName).ToArray());
            comboBoxProgramType.SelectedItem = _audit.Type;

            comboBoxObject.Items.Clear();
            comboBoxObject.Items.AddRange(RoutineObject.Items.OrderBy(i => i.FullName).ToArray());
            comboBoxObject.SelectedItem = _audit.RoutineObject;

            metroTextBoxTitle.Text = _audit.Title;
            metroTextBoxDescription.Text = _audit.Description;
            metroTextBoxRemark.Text = _audit.Remark;

            _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
            _tocheckListView.SetItemsArray(_updateChecks.ToArray());
        }


        private void buttonOk_Click(object sender, EventArgs e)
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

        private void ApplyChanges()
        {
            _audit.Title = metroTextBoxTitle.Text;
            _audit.Type = (ProgramType)comboBoxProgramType.SelectedItem;
            _audit.RoutineObject = (RoutineObject)comboBoxObject.SelectedItem;
            _audit.Description = metroTextBoxDescription.Text;
            _audit.Remark = metroTextBoxRemark.Text;
        }

        private void Save()
        {
            ApplyChanges();
            GlobalObjects.CaaEnvironment.NewKeeper.Save(_audit);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (_fromcheckListView.SelectedItems.Count == 0) return;

            if (string.IsNullOrEmpty(_audit.Title))
                metroTextBoxTitle.Text = $"{GlobalObjects.CaaEnvironment.IdentityUser.Name} ({SmartCore.Auxiliary.Convert.GetDateFormat(_audit.Settings.Created)} {_audit.Settings.Created.TimeOfDay.Hours}:{_audit.Settings.Created.TimeOfDay.Minutes}:{_audit.Settings.Created.TimeOfDay.Seconds})";

            if(_audit.ItemId <= 0)
                Save();

            foreach (var item in _fromcheckListView.SelectedItems.ToArray())
            {
                _updateChecks.Add(item);
                _addedChecks.Remove(item);

                var rec = new RoutineAuditRecord()
                {
                    CheckListId = item.ItemId,
                    RoutineAuditId = _audit.ItemId
                };

                GlobalObjects.CaaEnvironment.NewKeeper.Save(rec);
                _records.Add(rec);
            }

            _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
            _tocheckListView.SetItemsArray(_updateChecks.ToArray());
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_tocheckListView.SelectedItems.Count == 0) return;


            var dialog = MessageBox.Show("Do you really wand delete records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (dialog == DialogResult.Yes)
            {
                foreach (var item in _tocheckListView.SelectedItems.ToArray())
                {
                    _updateChecks.Remove(item);
                    _addedChecks.Add(item);

                    var delete = _records.FirstOrDefault(i => i.CheckListId == item.ItemId);
                    if(delete != null)
                        GlobalObjects.CaaEnvironment.NewKeeper.Delete(delete);
                }

                _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
                _tocheckListView.SetItemsArray(_updateChecks.ToArray());
            }
            
        }

        private void RoutineAuditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
