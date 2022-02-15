using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.CAA.Check;
using SmartCore.CAA.FindingLevel;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Files;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class CheckListRevEditForm : MetroForm
    {
        private CheckLists _currentCheck;
        private IList<FindingLevels> _levels = new List<FindingLevels>();

        #region Constructors
        public CheckListRevEditForm(CheckLists check)
        {
            
            InitializeComponent();
            _currentCheck = check;
            UpdateInformation();

        }
        
        #endregion
        
         private void UpdateInformation()
        {
            _levels.Clear();
            _levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new Filter("OperatorId", _currentCheck.OperatorId));
            
            metroTextSource.Text = _currentCheck.Source;
            metroTextBoxSectionNumber.Text = _currentCheck.Settings.SectionNumber;
            metroTextBoxSectionName.Text = _currentCheck.Settings.SectionName;
            metroTextBoxPartNumber.Text = _currentCheck.Settings.PartNumber;
            metroTextBoxPartName.Text = _currentCheck.Settings.PartName;
            metroTextBoxSubPartNumber.Text = _currentCheck.Settings.SubPartNumber;
            metroTextBoxSubPartName.Text = _currentCheck.Settings.SubPartName;
            metroTextBoxItemNumber.Text = _currentCheck.Settings.ItemNumber;
            metroTextBoxItemName.Text = _currentCheck.Settings.ItemtName;
            metroTextBoxRequirement.Text = _currentCheck.Settings.Requirement;
            dateTimePickeValidTo.Value = _currentCheck.Settings.RevisonValidToDate;
            numericUpNotify.Value = _currentCheck.Settings.RevisonValidToNotify;

            metroTextBoxReference.Text = _currentCheck.Settings.Reference;
            metroTextBoxDescribed.Text = _currentCheck.Settings.Described;
            metroTextBoxInstructions.Text = _currentCheck.Settings.Instructions;


            if (Math.Abs(_currentCheck.Settings.MH) > 0.000001)
                metroTextBoxMH.Text = _currentCheck.Settings.MH.ToString();

            var phase = new List<string> { "1", "2", "3", "4", "5", "6", "N/A" };
            comboBoxPhase.Items.Clear();
            foreach (var i in phase)
                comboBoxPhase.Items.Add(i);
            comboBoxPhase.SelectedItem = _currentCheck.Settings.Phase;


            comboBoxLevel.Items.Clear();
            comboBoxLevel.Items.AddRange(_levels.ToArray());
            comboBoxLevel.Items.Add(FindingLevels.Unknown);

            comboBoxLevel.SelectedItem = _levels.FirstOrDefault(i => i.ItemId == _currentCheck.Settings.LevelId) ??
                                         FindingLevels.Unknown;
            
            foreach (var rec in _currentCheck.CheckListRecords)
                UpdateRecords(rec);
        }

        private bool ApplyChanges()
        {
            _currentCheck.Source = metroTextSource.Text;
            _currentCheck.Settings.SectionName =  metroTextBoxSectionName.Text;
            _currentCheck.Settings.PartNumber = metroTextBoxPartNumber.Text;
            _currentCheck.Settings.PartName = metroTextBoxPartName.Text;
            _currentCheck.Settings.SubPartNumber = metroTextBoxSubPartNumber.Text;
            _currentCheck.Settings.SubPartName =  metroTextBoxSubPartName.Text;
            _currentCheck.Settings.ItemNumber = metroTextBoxItemNumber.Text;
            _currentCheck.Settings.ItemtName = metroTextBoxItemName.Text;
            _currentCheck.Settings.Requirement =  metroTextBoxRequirement.Text;


            _currentCheck.Settings.RevisonValidToNotify = (int) numericUpNotify.Value;

            _currentCheck.Settings.Reference = metroTextBoxReference.Text;
            _currentCheck.Settings.Described = metroTextBoxDescribed.Text;
            _currentCheck.Settings.Instructions = metroTextBoxInstructions.Text;


            _currentCheck.Settings.LevelId = ((FindingLevels) comboBoxLevel.SelectedItem).ItemId;
            _currentCheck.Settings.Phase = (string)comboBoxPhase.SelectedItem;


            double manHours;
            if (!CheckManHours(out manHours))
                return false;
            _currentCheck.Settings.MH = manHours;
            return true;
        }

        #region public bool CheckManHours(out double manHours)

        /// <summary>
        /// Проверяет значение ManHours
        /// </summary>
        /// <param name="manHours">Значение ManHours</param>
        /// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        public bool CheckManHours(out double manHours)
        {
            if (metroTextBoxMH.Text == "")
            {
                manHours = 0;
                return true;
            }
            if (double.TryParse(metroTextBoxMH.Text, NumberStyles.Float, new NumberFormatInfo(), out manHours) == false)
            {
                MessageBox.Show("Man Hours. Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateRecords(new CheckListRecords {CheckListId = _currentCheck.ItemId, OptionNumber = 1, Option =  OptionType.Unknown});
        }

        public void UpdateRecords(CheckListRecords record)
        {
            var control = new AuditControl(record);
            control.Deleted += Control_Deleted;
            flowLayoutPanel1.Controls.Remove(linkLabel1);
            flowLayoutPanel1.Controls.Add(control);
            flowLayoutPanel1.Controls.Add(linkLabel1);
        }

        private void Control_Deleted(object sender, EventArgs e)
        {
            var control = sender as AuditControl;

            var dialogResult = MessageBox.Show("Do you really want to delete record?", "Deleting confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                if (control.Record.ItemId > 0)
                {
                    try
                    {
                        GlobalObjects.CaaEnvironment.NewKeeper.Delete(control.Record);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while removing data", ex);
                    }
                }
                flowLayoutPanel1.Controls.Remove(control);
                control.Deleted -= Control_Deleted;
                control.Dispose();
            }
        }

        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            try
            {

                DialogResult = DialogResult.OK;
                Close();
                this.Focus();
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

        private void checkBoxSource_CheckedChanged(object sender, EventArgs e)
        {
            metroTextSource.Enabled = checkBoxSource.Checked;
        }
        
        private void checkBoxFindings_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxDescribed.Enabled = checkBoxFindings.Checked;
        }

        private void checkBoxRef_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxReference.Enabled = checkBoxRef.Checked;
        }

        private void checkBoxInstructions_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxInstructions.Enabled = checkBoxInstructions.Checked;
        }

        private void checkBoxCheck_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickeValidTo.Enabled = checkBoxCheck.Checked;
        }

        private void checkBoxNotify_CheckedChanged(object sender, EventArgs e)
        {
            numericUpNotify.Enabled = checkBoxNotify.Checked;
        }

        private void checkBoxLevel_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxLevel.Enabled = checkBoxLevel.Enabled;
        }

        private void checkBoxPhase_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxPhase.Enabled = checkBoxPhase.Checked;
        }

        private void checkBoxMh_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxMH.Enabled = checkBoxMh.Checked;
        }

        private void checkBoxSection_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxSectionNumber.Enabled =
                metroTextBoxSectionName.Enabled = checkBoxSection.Checked;
        }

        private void checkBoxPart_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxPartNumber.Enabled =
                metroTextBoxPartName.Enabled = checkBoxPart.Checked;
        }

        private void checkBoxSubpart_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxSubPartNumber.Enabled =
                metroTextBoxSubPartName.Enabled = checkBoxSubpart.Checked;
        }

        private void checkBoxItem_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxItemNumber.Enabled =
                metroTextBoxItemName.Enabled = checkBoxItem.Checked;
        }

        private void checkBoxReq_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxRequirement.Enabled = checkBoxReq.Checked;
        }

        private void checkBoxAudit_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
