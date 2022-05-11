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

        public EditConcessionRequestForm(SmartCore.CAA.ConcessionRequest  concessionRequest ) : this()
        {
            _concessionRequest = concessionRequest;
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
        }


        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Text += $" No: {_concessionRequest.Settings.Number}";
            UpdateInformation();
        }

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            _caa.Clear();

            if (_concessionRequest.ItemId > 0)
                _concessionRequest = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<ConcessionRequestDTO, SmartCore.CAA.ConcessionRequest>(_auditId);
            else _concessionRequest.Settings.Number = $"CR.B-{GlobalObjects.CaaEnvironment.ObtainId()}";

            
            _from = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAASpecialistDTO, Specialist>(_concessionRequest.From);
            _caa.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAASpecialistDTO, Specialist>(new Filter("OperatorId", -1)));
            
        }


        private void UpdateInformation()
        {
            metroTextBoxFrom.Text = _from.ToString();
            dateTimePickerCreated.Value = _concessionRequest.Created;
            metroTextBoxFromTel.Text = _from.PhoneMobile;
            metroTextBoxStation.Text = _concessionRequest.Settings.Station;
            metroTextBoxReason.Text = _concessionRequest.Settings.Reason;
            
            comboBoxProvider.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(Provider)).Cast<Provider>())
                comboBoxProvider.Items.Add(o);
            comboBoxProvider.SelectedItem = _concessionRequest.Settings.Provider;
            
            
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
            var to = comboBoxTo.SelectedItem as Specialist;
            _concessionRequest.To = to.ItemId;
            _concessionRequest.Settings.Station = metroTextBoxStation.Text;
            _concessionRequest.Settings.Reason = metroTextBoxReason.Text;
            _concessionRequest.Settings.Provider = (Provider)comboBoxProvider.SelectedItem;

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

        private void comboBoxTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var to = comboBoxTo.SelectedItem as Specialist;
            if (to != null)
                metroTextBoxToTel.Text = to.PhoneMobile;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
