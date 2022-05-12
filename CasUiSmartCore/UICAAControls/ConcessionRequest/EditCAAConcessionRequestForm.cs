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
    public partial class EditCAAConcessionRequestForm : MetroForm
    {
        private SmartCore.CAA.ConcessionRequest _concessionRequest;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private List<Specialist> _caa = new List<Specialist>();
        private List<Aircraft> _aircaraft = new List<Aircraft>();
        private Specialist _from;

        public EditCAAConcessionRequestForm()
        {
            InitializeComponent();
        }

        public EditCAAConcessionRequestForm(SmartCore.CAA.ConcessionRequest  concessionRequest ) : this()
        {
            _concessionRequest = concessionRequest;
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();

            button1.Enabled = concessionRequest.CurrentId == GlobalObjects.CaaEnvironment.IdentityUser.ItemId;
            if (concessionRequest.CurrentId != GlobalObjects.CaaEnvironment.IdentityUser.ItemId)
            {
                foreach (var control in groupBox6.Controls)
                {
                    var c = control as Control;
                    c.Enabled = false;
                }
            }

            foreach (var control in groupBox5.Controls)
            {
                var group = control as GroupBox;
                foreach (var g in group.Controls)
                {
                    var c = g as Control;
                    c.Enabled = false;
                }
            }
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
            if (_concessionRequest.Settings.CAA == null)
                _concessionRequest.Settings.CAA = new ConcessionRequestCAA();
            
            metroTextBoxFrom.Text = _from.ToString();
            dateTimePickerCreated.Value = _concessionRequest.Created;
            metroTextBoxFromTel.Text = _from.PhoneMobile;
            metroTextBoxStation.Text = _concessionRequest.Settings.Station;
            metroTextBoxReason.Text = _concessionRequest.Settings.Reason;
            
            comboBoxProvider.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(Provider)).Cast<Provider>())
                comboBoxProvider.Items.Add(o);
            comboBoxProvider.SelectedItem = _concessionRequest.Settings.Provider;
            
            
            comboBoxCOncession.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(Concession)).Cast<Concession>())
                comboBoxCOncession.Items.Add(o);
            comboBoxCOncession.SelectedItem = _concessionRequest.Settings.CAA.Concession;
            
            dateTimePickerPermitted.Value = _concessionRequest.Settings.CAA.Permitted;
            metroTextBoxRemark.Text = _concessionRequest.Settings.CAA.Remark;
            dateTimePickerCAACreated.Value = _concessionRequest.Settings.CAA.Created;
            
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
            _concessionRequest.Settings.CAA.Concession = (Concession)comboBoxCOncession.SelectedItem;
            _concessionRequest.Settings.CAA.Permitted = dateTimePickerPermitted.Value;
            _concessionRequest.Settings.CAA.Remark = metroTextBoxRemark.Text;

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
            _concessionRequest.CurrentId = _concessionRequest.FromId;
            _concessionRequest.Status = ConcessionRequestStatus.Operator;
            GlobalObjects.CaaEnvironment.NewKeeper.Save(_concessionRequest);
            DialogResult = DialogResult.OK;
        }
    }
}
