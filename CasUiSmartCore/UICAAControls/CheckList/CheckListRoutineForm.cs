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

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class CheckListRoutineForm : MetroForm
    {
        private readonly int _routineId;
        private readonly int _operatorId;
        private List<CheckLists> _addedChecks = new List<CheckLists>();
        private List<CheckLists> _updateChecks = new List<CheckLists>();
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private IList<FindingLevels> _levels = new List<FindingLevels>();

        public CheckListRoutineForm(int routineId, int operatorId)
        {
            _routineId = routineId;
            _operatorId = operatorId;
            InitializeComponent();
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
            _addedChecks.Clear();
            _addedChecks =
                GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CheckListDTO, CheckLists>(new Filter("OperatorId", _operatorId), loadChild: true).ToList();
            _levels.Clear();
            _levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new Filter("OperatorId", _operatorId));


            foreach (var check in _addedChecks)
            {
                check.Level = _levels.FirstOrDefault(i => i.ItemId == check.Settings.LevelId) ??
                              FindingLevels.Unknown;


                check.Remains = Lifelength.Null;
                check.Condition = ConditionState.Satisfactory;

                var days = (check.Settings.RevisonValidToDate - DateTime.Today).Days;
                var editionDays = 0;
                if (!check.Settings.RevisonValidTo)
                    editionDays = (check.Settings.EditionDate - DateTime.Today).Days;
                //else editionDays = (check.Settings.RevisonDate - DateTime.Today).Days;

                check.Remains = new Lifelength(days - editionDays, null, null);


                if (check.Remains.Days < 0)
                    check.Condition = ConditionState.Overdue;
                else if (check.Remains.Days >= 0 && check.Remains.Days <= check.Settings.RevisonValidToNotify)
                    check.Condition = ConditionState.Notify;
            }
            
            
            var records = GlobalObjects.CaaEnvironment.NewLoader
                .GetObjectListAll<RoutineAuditRecordDTO, RoutineAuditRecord>(new Filter("RoutineAuditId", _routineId), loadChild: true).ToList();

            var ids = records.Select(i => i.CheckListId);

            foreach (var id in ids)
            {
                var item = _addedChecks.FirstOrDefault(i => i.ItemId == id);
                if(item == null)
                    continue;

                _addedChecks.Remove(item);
                _updateChecks.Add(item);
            }
        }

        private void UpdateInformation()
        {
            _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
            _tocheckListView.SetItemsArray(_updateChecks.ToArray());
        }
        
        
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogResult = MessageBox.Show("Do you really want update records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (var checks in _updateChecks)
                        GlobalObjects.CaaEnvironment.NewKeeper.Save(checks);


                    MessageBox.Show("All records updated successfull!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    //DialogResult = DialogResult.OK;
                    //Close();

                    foreach (var item in _tocheckListView.SelectedItems.ToArray())
                    {
                        _updateChecks.Remove(item);
                        _addedChecks.Add(item);
                    }
                    _animatedThreadWorker.RunWorkerAsync();
                }
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

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (_fromcheckListView.SelectedItems.Count == 0) return;

            foreach (var item in _fromcheckListView.SelectedItems.ToArray())
            {
                _updateChecks.Add(item);
                _addedChecks.Remove(item);
                
                var rec = new RoutineAuditRecord()
                {
                    CheckListId = item.ItemId,
                    RoutineAuditId = _routineId
                };

                GlobalObjects.CaaEnvironment.NewKeeper.Save(rec);
            }

            _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
            _tocheckListView.SetItemsArray(_updateChecks.ToArray());
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_tocheckListView.SelectedItems.Count == 0) return;

            foreach (var item in _tocheckListView.SelectedItems.ToArray())
            {
                _updateChecks.Remove(item);
                _addedChecks.Add(item);
            }

            _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
            _tocheckListView.SetItemsArray(_updateChecks.ToArray());
        }
        
        private void CheckListRevisionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
