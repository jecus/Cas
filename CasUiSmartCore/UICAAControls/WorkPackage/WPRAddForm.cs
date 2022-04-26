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
using SmartCore.CAA.CAAEducation;
using SmartCore.CAA.CAAWP;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UICAAControls.WorkPackage
{
    public partial class WPRAddForm : MetroForm
    {
        private readonly CAAWorkPackage _package;
        private readonly CommonCollection<Specialist> _specialists;
        
        private CommonCollection<CAAWorkPackageRecord> _addedChecks = new CommonCollection<CAAWorkPackageRecord>();
        private CommonCollection<CAAWorkPackageRecord> _updateChecks = new CommonCollection<CAAWorkPackageRecord>();
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        
        public WPRAddForm(CAAWorkPackage package) 
        {
            _package = package;

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
            _updateChecks.Clear();
            
            var wpr = GlobalObjects.CaaEnvironment.NewLoader
                .GetObjectListAll<CAAWorkPackageRecordDTO, CAAWorkPackageRecord>(new Filter("WorkPackageId", _package.ItemId));
            
            
            var educationRecords = new List<CAAEducationRecord>();
            if (_package.OperatorId > 0)
                educationRecords.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<EducationRecordsDTO, CAAEducationRecord>(new Filter("OperatorId",_package.OperatorId)));
            else
                educationRecords.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<EducationRecordsDTO, CAAEducationRecord>());

            
            var edIds = educationRecords.Select(i => i.EducationId);
            var educations = GlobalObjects.CaaEnvironment.NewLoader
                .GetObjectListAll<EducationDTO, SmartCore.CAA.CAAEducation.CAAEducation>(new Filter("ItemId", edIds),loadChild:true);
            var spIds = educationRecords.Select(i => i.SpecialistId);
            var specialists = GlobalObjects.CaaEnvironment.NewLoader
                .GetObjectListAll<CAASpecialistDTO, Specialist>(new Filter("ItemId", spIds));
            
            foreach (var r in educationRecords)
            {
                EducationCalculator.CalculateEducation(r);
                var item = new CAAEducationManagment()
                {
                    Specialist = specialists.FirstOrDefault(i => i.ItemId == r.SpecialistId),
                    Education = educations.FirstOrDefault(i => i.ItemId == r.EducationId),
                    Record = r,
                };
                item.Occupation = item.Education.Occupation;
                item.IsCombination = item.Record.Settings.IsCombination;

                
                _addedChecks.Add(new CAAWorkPackageRecord()
                {
                    Parent = item,
                    ObjectId = item.Record.ItemId,
                    WorkPackageId = _package.ItemId
                });


                foreach (var record in wpr)
                {
                    var find = _addedChecks.FirstOrDefault(i => i.ObjectId == record.ObjectId);
                    if (find != null)
                    {
                        find.ItemId = record.ItemId;
                        _addedChecks.Remove(find);
                        _updateChecks.Add(find);
                    }
                }
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
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (_fromcheckRevisionListView.SelectedItems.Count > 0)
            {
                foreach (var item in _fromcheckRevisionListView.SelectedItems.ToArray())
                {
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(item);
                    
                    _updateChecks.Add(item);
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
                    GlobalObjects.CaaEnvironment.NewKeeper.Delete(item);
                    
                    _updateChecks.Remove(item);
                    _addedChecks.Add(item);
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
