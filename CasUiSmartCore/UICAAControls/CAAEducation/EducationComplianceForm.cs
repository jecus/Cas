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
        private readonly LastCompliance _compliance;

        public EducationComplianceForm(CAAEducationRecord record, LastCompliance compliance)
        {
            _record = record;
            _compliance = compliance;
            InitializeComponent();
            UpdateInformation();
        }
        
        
        private void UpdateInformation()
        {
            if (_compliance.LastDate.HasValue)
            {
                dateTimePickeValidTo.Value = _compliance.LastDate.Value;
                metroTextBoxRemark.Text = _compliance.Remark;
            }
            else dateTimePickeValidTo.Value = _record.Settings.Next.Value;
        }

        private void ApplyChanges()
        {
            _compliance.Remark = metroTextBoxRemark.Text;
            _compliance.LastDate = dateTimePickeValidTo.Value;
            
            _record.Settings.LastCompliances.Add(_compliance);
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