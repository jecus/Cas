using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.General;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.Entities;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UICAAControls.ConcessionRequest
{
    public partial class EditConcessionRequestForm : MetroForm
    {
        private readonly int _auditId;
        private SmartCore.CAA.ConcessionRequest _concessionRequest;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private List<Specialist> _caa = new List<Specialist>();
        private Specialist _from;

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
            _caa.Clear();
            _concessionRequest = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<ConcessionRequestDTO, SmartCore.CAA.ConcessionRequest>(_auditId);

            
            _from = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAASpecialistDTO, Specialist>(_concessionRequest.From);
            _caa.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAASpecialistDTO, Specialist>(new Filter("OperatorId", -1)));

        }


        private void UpdateInformation()
        {
            metroTextBoxFrom.Text = _from.ToString();
            metroTextBoxFromTel.Text = _from.PhoneMobile;
            metroTextBoxStation.Text = _concessionRequest.Settings.Station;
            
            comboBoxTo.Items.Clear();
            comboBoxTo.Items.AddRange(_caa.ToArray());
            comboBoxTo.Items.Add( Specialist.Unknown);
            comboBoxTo.SelectedItem = Specialist.Unknown;
            var to = _caa.FirstOrDefault(i => i.ItemId == _concessionRequest.To);
            if (to != null)
            {
                comboBoxTo.SelectedItem = _caa.FirstOrDefault(i => i.ItemId == _concessionRequest.To);
                metroTextBoxToTel.Text = to.PhoneMobile;
            }
        }

        private void ApplyChanges()
        {
            _concessionRequest.Settings.Station = metroTextBoxStation.Text;

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
