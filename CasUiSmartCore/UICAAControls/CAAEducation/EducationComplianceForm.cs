using System;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.CAA.CAAEducation;

namespace CAS.UI.UICAAControls.CAAEducation
{
    public partial class EducationComplianceForm : MetroForm
    {
        private readonly CAAEducationRecord _record;

        public EducationComplianceForm(CAAEducationRecord record)
        {
            _record = record;
            InitializeComponent();
            UpdateInformation();
        }
        
        
        private void UpdateInformation()
        {
            dateTimePickeValidTo.Value = _record.Settings.Next.Value;
        }

        private void ApplyChanges()
        {
            _record.Settings.LastCompliances.Add(new LastCompliance()
            {
                Remark = metroTextBoxRemark.Text,
                LastDate = dateTimePickeValidTo.Value
            });
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                ApplyChanges();
                GlobalObjects.CaaEnvironment.NewKeeper.Save(_record);
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