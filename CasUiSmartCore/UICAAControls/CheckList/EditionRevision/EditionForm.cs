using System;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.CAA.Check;

namespace CAS.UI.UICAAControls.CheckList.EditionRevision
{
    public partial class EditionForm : MetroForm
    {
        private readonly CheckListRevision _edition;

        public EditionForm(CheckListRevision edition)
        {
            _edition = edition;
            InitializeComponent();
            UpdateInformation();
        }
        
        private void UpdateInformation()
        {
            metroTextBoxEditionNumber.Text = _edition.Number;
            dateTimePickerEditionDate.Value = _edition.Date;
            dateTimePickerEditionEff.Value = _edition.EffDate;
        }

        private void ApplyChanges()
        {
            _edition.Number = metroTextBoxEditionNumber.Text;
            _edition.Date = dateTimePickerEditionDate.Value;
            _edition.EffDate = dateTimePickerEditionEff.Value;
        }
        
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogResult = MessageBox.Show("Do you really want savae edition?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {
                    ApplyChanges();
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(_edition);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save checkList", ex);
            }
        }
        private void CheckListRevisionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
