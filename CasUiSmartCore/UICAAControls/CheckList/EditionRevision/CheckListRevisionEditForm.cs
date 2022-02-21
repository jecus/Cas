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
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UICAAControls.CheckList.EditionRevision
{
    public partial class CheckListRevisionEditForm : MetroForm
    {
        private readonly int _operatorId;
        private readonly CheckListRevision _parent;
        private CommonCollection<CheckLists> _addedChecks = new CommonCollection<CheckLists>();
        private CommonCollection<CheckLists> _updateChecks = new CommonCollection<CheckLists>();
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private IList<FindingLevels> _levels = new List<FindingLevels>();

        public CheckListRevisionEditForm(int operatorId, CheckListRevision parent, CommonCollection<CheckLists> added)
        {
            _operatorId = operatorId;
            _parent = parent;
            _updateChecks.AddRange(added.ToList());
            InitializeComponent();
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
        }

        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_addedChecks.Any(i => i.CheckUIType == CheckUIType.Iosa))
            {
                _fromcheckListView = new CheckListView();
                _tocheckListView = new CheckListView();
            }
            else if (_addedChecks.Any(i => i.CheckUIType == CheckUIType.Safa))
            {
                _fromcheckListView = new CheckListSAFAView();
                _tocheckListView = new CheckListSAFAView();
            }
            
            // 
            // _fromcheckListView
            // 
            this._fromcheckListView.Location = new System.Drawing.Point(5, 53);
            this._fromcheckListView.Name = "_fromcheckListView";
            this._fromcheckListView.Size = new System.Drawing.Size(1510, 306);
            // 
            // _tocheckListView
            // 
            this._tocheckListView.Location = new System.Drawing.Point(5, 406);
            this._tocheckListView.Name = "_tocheckListView";
            this._tocheckListView.Size = new System.Drawing.Size(1510, 346);

            this.Controls.Add(this._tocheckListView);
            this.Controls.Add(this._fromcheckListView);
            
            UpdateInformation();
        }

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            _addedChecks.Clear();
            
            _addedChecks.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CheckListDTO, CheckLists>(new Filter("EditionId", _parent.EditionId), loadChild: true)
                    .ToList());
            _levels.Clear();
            _levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new Filter("OperatorId", _operatorId));

            foreach (var check in _addedChecks)
            {
                check.EditionNumber = _parent.Number;
                check.RevisionNumber = _parent.Number;
                
                check.Level = _levels.FirstOrDefault(i => i.ItemId == check.Settings.LevelId) ??
                              FindingLevels.Unknown;


                check.Remains = Lifelength.Null;
                check.Condition = ConditionState.Satisfactory;
            }
            
            _addedChecks = new CommonCollection<CheckLists>(_addedChecks.Except(_updateChecks));
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
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save checkList", ex);
            }
        }
        
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
             if (_fromcheckListView.SelectedItems.Count > 0)
            {
                foreach (var item in _fromcheckListView.SelectedItems.ToArray())
                {
                    _updateChecks.Add(item);
                    _addedChecks.Remove(item);
                    
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(new CheckListRevisionRecord
                    {
                        CheckListId = item.ItemId,
                        ParentId = _parent.ItemId
                    });
                }
                
                _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
                _tocheckListView.SetItemsArray(_updateChecks.ToArray());
            }
            
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_tocheckListView.SelectedItems.Count > 0)
            {
                foreach (var item in _tocheckListView.SelectedItems.ToArray())
                {
                    _updateChecks.Remove(item);
                    _addedChecks.Add(item);
                }
                
                GlobalObjects.CaaEnvironment.NewLoader.Execute(
                    $"delete from  dbo.CheckListRevisionRecord where ParentId = {_parent.EditionId} and CheckListId in ({string.Join(",",_tocheckListView.SelectedItems.Select(i => i.ItemId))})");
            }
        }

        private void CheckListRevisionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
