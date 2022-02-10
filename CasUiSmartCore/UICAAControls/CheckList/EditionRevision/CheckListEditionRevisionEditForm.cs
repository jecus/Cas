using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
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
using SmartCore.Entities.General;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class CheckListEditionRevisionEditForm : MetroForm
    {
        private readonly int _parentId;
        private readonly int _operatorId;
        
        private CommonCollection<CheckLists> _addedChecks = new CommonCollection<CheckLists>();
        private CommonCollection<CheckLists> _updateChecks = new CommonCollection<CheckLists>();
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private IList<FindingLevels> _levels = new List<FindingLevels>();

        public CheckListEditionRevisionEditForm(int parentId, int operatorId)
        {
            _parentId = parentId;
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
            _levels.Clear();
            _addedChecks.Clear();
            _updateChecks.Clear();
            _addedChecks.AddRange(
                GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CheckListDTO, CheckLists>(new Filter("OperatorId", _operatorId), loadChild: true)
                    .ToList());
            _levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new Filter("OperatorId", _operatorId));
            
            var dsEdition = GlobalObjects.CaaEnvironment.Execute($@"
select c.ItemId as CheckId, res.Number, res.EffDate from dbo.CheckList c
cross apply
(
	select top 2 r.Number, r.EffDate from dbo.CheckListRevisionRecord  rec
	cross apply
	(
		select Number,EffDate, Type, OperatorId from dbo.CheckListRevision 
		where ItemId = rec.ParentId
	)r
	where c.IsDeleted = 0 and rec.CheckListId = c.ItemId and rec.IsDeleted = 0 and r.Type = 0 and r.OperatorId = {_operatorId}
	order by r.EffDate desc
) res");

            var dsRevision = GlobalObjects.CaaEnvironment.Execute($@"select c.ItemId as CheckId, res.Number, res.EffDate from dbo.CheckList c
cross apply
(
	select top 2 r.Number, r.EffDate from dbo.CheckListRevisionRecord  rec
	cross apply
	(
		select ItemId,EffDate, Number, Type, OperatorId from dbo.CheckListRevision 
		where ItemId = rec.ParentId
	)r
	where c.IsDeleted = 0 and rec.CheckListId = c.ItemId and rec.IsDeleted = 0 and r.Type = 1 and r.OperatorId = {_operatorId} and (r.ItemId > (select top 1 q.ItemId  from dbo.CheckListRevisionRecord r1
																																			cross apply
																																			(
																																				select top 1 ItemId, Type from dbo.CheckListRevision where ItemId = r1.ParentId
																																			)q
																																			where q.Type = 0 and r1.CheckListId = c.ItemId and IsDeleted = 0 
																																			order by ItemId desc))
	order by r.EffDate desc
) res
");
            
            var revisions = dsRevision.Tables[0].AsEnumerable()
                .Select(dataRow => new
                {
                    Id = dataRow.Field<int>("CheckId"),
                    Number = dataRow.Field<string>("Number"),
                    EffDate = dataRow.Field<DateTime?>("EffDate"),
                }).ToList();

            var editions = dsEdition.Tables[0].AsEnumerable()
                .Select(dataRow => new
                {
                    Id = dataRow.Field<int>("CheckId"),
                    Number = dataRow.Field<string>("Number"),
                    EffDate = dataRow.Field<DateTime?>("EffDate"),
                }).ToList();
            
            
            foreach (var check in _addedChecks)
            {
                var revision = revisions.Where(i => i.Id == check.ItemId).ToList();
                var edition = editions.Where(i => i.Id == check.ItemId).ToList();

                if (revision.Any())
                {
                    if (revision.Count == 1)
                        check.RevisionNumber = revision.LastOrDefault()?.Number;
                    else
                    {
                        check.NextRevisionNumber = revision.FirstOrDefault()?.Number;
                        check.RevisionNumber = revision.LastOrDefault()?.Number;
                    }
                }

                if (edition.Any())
                {
                    if (edition.Count == 1)
                        check.EditionNumber = edition.LastOrDefault()?.Number;
                    else
                    {
                        check.NextEditionNumber = edition.FirstOrDefault()?.Number;
                        check.EditionNumber = edition.LastOrDefault()?.Number;
                    }
                }


                check.Level = _levels.FirstOrDefault(i => i.ItemId == check.Settings.LevelId) ??
                              FindingLevels.Unknown;


                check.Remains = Lifelength.Null;
                check.Condition = ConditionState.Satisfactory;
            }


            var records = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionRecordDTO, CheckListRevisionRecord>(new Filter("ParentId", _parentId));
            var ids = records.Select(i => i.CheckListId);

            foreach (var id in ids)
            {
                var item = _addedChecks.FirstOrDefault(i => i.ItemId == id);
                if (item == null) continue;
                _addedChecks.Remove(item);
                _updateChecks.Add(item);
            }
        }

        private void UpdateInformation()
        {
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
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (_fromcheckRevisionListView.SelectedItems.Count > 0)
            {
                foreach (var item in _fromcheckRevisionListView.SelectedItems.ToArray())
                {
                    _updateChecks.Add(item);
                    _addedChecks.Remove(item);

                    var record = new CheckListRevisionRecord()
                    {
                        CheckListId = item.ItemId,
                        ParentId = _parentId
                    };
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(record);
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
                    _addedChecks.Add(item);
                    GlobalObjects.CaaEnvironment.Execute($@"delete from dbo.CheckListRevisionRecord where ParentId = {_parentId} and CheckListid = {item.ItemId}");
                }

                _fromcheckRevisionListView.SetItemsArray(_addedChecks.ToArray());
                _tocheckRevisionListView.SetItemsArray(_updateChecks.ToArray());
            }
        }
        
        private void CheckListRevisionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
