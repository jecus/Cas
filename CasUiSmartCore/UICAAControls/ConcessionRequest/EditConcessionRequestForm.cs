using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.UICAAControls.CheckList;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.Auxiliary;
using SmartCore.CAA;
using SmartCore.CAA.Audit;

namespace CAS.UI.UICAAControls.ConcessionRequest
{
    public partial class EditConcessionRequestForm : MetroForm
    {
        private readonly int _auditId;
        private SmartCore.CAA.ConcessionRequest _concessionRequest;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private List<AllOperators> _operators = new List<AllOperators>();

        public EditConcessionRequestForm()
        {
            InitializeComponent();
        }

        public EditConcessionRequestForm(int auditId) : this()
        {
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
            _operators = GlobalObjects.CaaEnvironment.AllOperators;
            _concessionRequest = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<ConcessionRequestDTO, SmartCore.CAA.ConcessionRequest>(_auditId);
        }


        private void UpdateInformation()
        {
            
        }

        private void ApplyChanges()
        {
            

        }

        private void Save()
        {
            ApplyChanges();
            GlobalObjects.CaaEnvironment.NewKeeper.Save(_concessionRequest);
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


        private void AuditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
