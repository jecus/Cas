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
using SmartCore.CAA.PEL;
using SmartCore.CAA.RoutineAudits;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UICAAControls.Audit.PEL
{
    public partial class AuditTeamForm : MetroForm
    {
        private readonly int _auditId;
        private readonly CommonCollection<Specialist> _specialists;
        
        
        private CommonCollection<PelSpecialist> _addedChecks = new CommonCollection<PelSpecialist>();
        private CommonCollection<PelSpecialist> _updateChecks = new CommonCollection<PelSpecialist>();
        
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        
        
        public AuditTeamForm(CommonCollection<Specialist> specialists, int auditId) 
        {
            
            InitializeComponent();
            
            _specialists = specialists;
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
            _updateChecks.Clear();
            _updateChecks.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<PelSpecialistDTO, PelSpecialist>(new Filter("AuditId", _auditId)));

            foreach (var rec in _updateChecks)
                rec.Specialist = _specialists.FirstOrDefault(i => i.ItemId == rec.SpecialistId);

            var ids = _updateChecks.Select(i => i.ItemId);

            if (ids.Any())
            {
                _addedChecks.AddRange(_specialists.Where(q => !ids.Contains(q.ItemId)).Select(i => new PelSpecialist
                {
                    SpecialistId = i.ItemId,
                    Specialist = i,
                    AuditId = _auditId
                }));
            }
            else
            {
                _addedChecks.AddRange(_specialists.Select(i => new PelSpecialist
                {
                    SpecialistId = i.ItemId,
                    Specialist = i,
                    AuditId = _auditId
                }));
            }
            
           
            
        }

        private void UpdateInformation()
        {
            comboBoxRoles.Items.Clear();
            comboBoxRoles.Items.AddRange(PELRole.Items.ToArray());
            comboBoxRoles.SelectedItem = PELRole.Unknown;
            
            comboBoxResponsibilities.Items.Clear();
            comboBoxResponsibilities.Items.AddRange(PELResponsibilities.Items.ToArray());
            comboBoxResponsibilities.SelectedItem = PELResponsibilities.Unknown;
            
            comboBoxPosition.Items.Clear();
            comboBoxPosition.Items.AddRange(PELPosition.Items.ToArray());
            comboBoxPosition.SelectedItem = PELPosition.Unknown;
            
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
                    item.Role = comboBoxRoles.SelectedItem as PELRole;
                    item.PELResponsibilities = comboBoxResponsibilities.SelectedItem as PELResponsibilities;
                    item.PELPosition = comboBoxPosition.SelectedItem as PELPosition;

                    GlobalObjects.CaaEnvironment.NewKeeper.Save(item);
                    
                    _updateChecks.Add(item);
                    _addedChecks.Remove(item);
                }

                comboBoxRoles.SelectedItem = PELRole.Unknown;
                comboBoxResponsibilities.SelectedItem = PELResponsibilities.Unknown;
                comboBoxPosition.SelectedItem = PELPosition.Unknown;
                
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
                    item.Role = PELRole.Unknown;
                    item.PELResponsibilities = PELResponsibilities.Unknown;
                    item.PELPosition = PELPosition.Unknown;
                    
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
