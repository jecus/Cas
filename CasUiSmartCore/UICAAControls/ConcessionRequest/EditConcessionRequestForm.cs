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
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UICAAControls.ConcessionRequest
{
    public partial class EditConcessionRequestForm : MetroForm
    {
        private SmartCore.CAA.ConcessionRequest _concessionRequest;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private List<Specialist> _caa = new List<Specialist>();
        private List<Aircraft> _aircaraft = new List<Aircraft>();
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
            _aircaraft.Clear();

            if (_concessionRequest.ItemId > 0)
                _concessionRequest = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<ConcessionRequestDTO, SmartCore.CAA.ConcessionRequest>(_concessionRequest.ItemId);
            else _concessionRequest.Settings.Number = $"CR.B-{GlobalObjects.CaaEnvironment.ObtainId()}";

            
            _from = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAASpecialistDTO, Specialist>(_concessionRequest.FromId);
            _caa.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAASpecialistDTO, Specialist>(new Filter("OperatorId", -1)));
            _aircaraft.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAAAircraftDTO, Aircraft>());
            
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
            
            
            comboBoxAircraft.Items.Clear();
            comboBoxAircraft.Items.AddRange(_aircaraft.ToArray());
            comboBoxAircraft.Items.Add(Aircraft.Unknown);
            comboBoxAircraft.SelectedItem = _aircaraft.FirstOrDefault(i => i.ItemId == _concessionRequest.Settings.AircraftId) ?? Aircraft.Unknown;
            
            
            comboBoxTo.Items.Clear();
            comboBoxTo.Items.AddRange(_caa.ToArray());
            comboBoxTo.Items.Add(Specialist.Unknown);
            comboBoxTo.SelectedItem = Specialist.Unknown;
            var to = _caa.FirstOrDefault(i => i.ItemId == _concessionRequest.ToId);
            if (to != null)
            {
                comboBoxTo.SelectedItem = _caa.FirstOrDefault(i => i.ItemId == _concessionRequest.ToId);
                metroTextBoxToTel.Text = to.PhoneMobile;
            }
        }

        private void ApplyChanges()
        {
            var to = comboBoxTo.SelectedItem as Specialist;
            _concessionRequest.ToId = to.ItemId;
            _concessionRequest.Settings.Station = metroTextBoxStation.Text;
            _concessionRequest.Settings.Reason = metroTextBoxReason.Text;
            _concessionRequest.Settings.Provider = (Provider)comboBoxProvider.SelectedItem;
            _concessionRequest.Settings.AircraftId = (comboBoxAircraft.SelectedItem as Aircraft).ItemId;

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
            var aircraft = comboBoxAircraft.SelectedItem as Aircraft;
            if (aircraft != null)
                metroTextBoxAircraft.Text = $"Reg:{aircraft.RegistrationNumber} S/N:{aircraft.SerialNumber} MSG:{aircraft.MSG}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_concessionRequest.ToId > 0)
            {
                _concessionRequest.CurrentId = _concessionRequest.ToId;
                GlobalObjects.CaaEnvironment.NewKeeper.Save(_concessionRequest);
                DialogResult = DialogResult.OK;
            }
            else MessageBox.Show("Please select CAA!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        }
    }
}
