using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.CAA.RoutineAudits;

namespace CAS.UI.UICAAControls.StandartManual
{
    public partial class StandartManualForm : MetroForm
    {
        private readonly SmartCore.CAA.StandartManual.StandartManual _standartManual;
        private readonly IEnumerable<ProgramType> _existTypes;

        public StandartManualForm()
        {
            InitializeComponent();
        }
        
        public StandartManualForm(SmartCore.CAA.StandartManual.StandartManual standartManual, IEnumerable<ProgramType> existTypes)
        {
            _standartManual = standartManual;
            _existTypes = existTypes;
            InitializeComponent();
            UpdateInformation();
        }

        private void UpdateInformation()
        {
            comboBoxProgramType.Items.Clear();
            comboBoxProgramType.Items.AddRange(ProgramType.Items.Except(_existTypes).ToArray());
            if (_standartManual.ItemId > 0)
                comboBoxProgramType.Items.Add(_standartManual.ProgramType);
            
            comboBoxProgramType.SelectedItem = _standartManual.ProgramType;

            metroTextSource.Text = _standartManual.Source;
            metroTextBoxDescription.Text = _standartManual.Description;
            metroTextBoxRemark.Text = _standartManual.Remark;
            dateTimePickeValidTo.Value = _standartManual.ValidTo;
            numericUpNotify.Value = _standartManual.Notify;
        }

        private void ApplyChanges()
        {
            _standartManual.Settings.ProgramTypeId = (comboBoxProgramType.SelectedItem as ProgramType).ItemId;

            _standartManual.Source = metroTextSource.Text ;
            _standartManual.Settings.Description = metroTextBoxDescription.Text;
            _standartManual.Settings.Remark = metroTextBoxRemark.Text;
            _standartManual.Settings.ValidTo = dateTimePickeValidTo.Value;
            _standartManual.Settings.Notify = (int)numericUpNotify.Value;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                ApplyChanges();
                GlobalObjects.CaaEnvironment.NewKeeper.Save(_standartManual);
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
        
        private void AuditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}