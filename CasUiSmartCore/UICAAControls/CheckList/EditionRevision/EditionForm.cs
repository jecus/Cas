using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
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
            InitializeComponent();
            
            _edition = edition;
            if (_edition.Type == RevisionType.Edition)
            {
                Text = "Edition Form";
                label3.Text = "Edition";
            }
            else
            {
                label3.Text = "Revision";
                Text = "Revision Form";
            }
            
            
            metroTextBoxEditionNumber.Enabled =
                dateTimePickerEditionDate.Enabled =
                    dateTimePickerEditionEff.Enabled =
                        edition.Status == EditionRevisionStatus.Temporary || edition.Status == EditionRevisionStatus.Current;
            
            
            UpdateInformation();
        }
        
        private void UpdateInformation()
        {
            metroTextBoxEditionNumber.Text = _edition.Number.ToString();
            dateTimePickerEditionDate.Value = _edition.Date;
            dateTimePickerEditionEff.Value = _edition.EffDate;
        }

        private bool ApplyChanges()
        {
            
            _edition.Date = dateTimePickerEditionDate.Value;
            _edition.EffDate = dateTimePickerEditionEff.Value;
            
            int number;
            if (!CheckNumber(out number))
                return false;
            _edition.Number = number;
            
            return true;
        }
        
        
        public bool CheckNumber(out int number)
        {
            if (int.TryParse(metroTextBoxEditionNumber.Text, NumberStyles.Number, new NumberFormatInfo(),  out number) == false)
            {
                MessageBox.Show("Number of edition. Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogResult = MessageBox.Show("Do you really want savae edition?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {
                    var ds = GlobalObjects.CaaEnvironment.Execute($"select top 1 EffDate from [dbo].[CheckListRevision] where EffDate >= '{dateTimePickerEditionEff.Value:yyyy-MM-dd}' and ItemId != {_edition.ItemId} and IsDeleted = 0 and Type = {(int)_edition.Type} and ManualId = {_edition.ManualId} order by EffDate desc");
                    var data = ds.Tables[0].AsEnumerable().Select(dataRow => new
                    {
                        EffDate = dataRow.Field<DateTime?>("EffDate")
                    });
                    if (!data.Any())
                    {
                        if (ApplyChanges())
                        {
                            GlobalObjects.CaaEnvironment.NewKeeper.Save(_edition);
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Edition eff date should grather than {data.FirstOrDefault().EffDate}", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    
                    
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

        private void dateTimePickerEditionDate_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerEditionEff.Value = dateTimePickerEditionDate.Value;
        }

        private void dateTimePickerEditionEff_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePickerEditionDate.Value > dateTimePickerEditionEff.Value)
                dateTimePickerEditionEff.Value = dateTimePickerEditionDate.Value;
        }
    }
}
