﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.CAA.PEL;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UICAAControls.Audit.PEL
{
    public partial class AuditTeamForm : MetroForm
    {
        private readonly int _operatorId;
        
        private CommonCollection<PelSpecialist> _addedChecks = new CommonCollection<PelSpecialist>();
        private CommonCollection<PelSpecialist> _updateChecks = new CommonCollection<PelSpecialist>();
        
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

        public AuditTeamForm(int operatorId)
        {
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
            var specialists = new CommonCollection<Specialist>();
            if (_operatorId == -1)
            {
                specialists.AddRange(GlobalObjects.CaaEnvironment.NewLoader
                    .GetObjectListAll<CAASpecialistDTO, Specialist>(loadChild: true));
            }
            else
            {
                specialists.AddRange(GlobalObjects.CaaEnvironment.NewLoader
                    .GetObjectListAll<CAASpecialistDTO, Specialist>(new Filter("OperatorId", _operatorId),
                        loadChild: true));
            }
            
            _addedChecks.AddRange(specialists.Select(i => new PelSpecialist()
            {
                ItemId = i.ItemId,
                FirstName = i.FirstName,
                LastName = i.LastName,
                Specialization = i.Specialization
            }));
            
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
