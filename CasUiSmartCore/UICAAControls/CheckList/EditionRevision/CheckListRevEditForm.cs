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
        private readonly int _revisionId;
        private IList<FindingLevels> _levels = new List<FindingLevels>();
        private CheckListRevisionRecord _record;

        #region Constructors
        public CheckListRevEditForm(CheckLists check, int revisionId)
        {
            
            InitializeComponent();
            _currentCheck = check;
            _revisionId = revisionId;
            UpdateInformation();

        }
        
        #endregion
        
         private void UpdateInformation()
         {
             _record = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionRecordDTO, CheckListRevisionRecord>(new List<Filter>()
             {
                 new Filter("CheckListId", _currentCheck.ItemId),
                 new Filter("ParentId", _revisionId),
             }).FirstOrDefault();
            
            _levels.Clear();
            _levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new Filter("OperatorId", _currentCheck.OperatorId));

            var phase = new List<string> { "1", "2", "3", "4", "5", "6", "N/A" };
            comboBoxPhase.Items.Clear();
            foreach (var i in phase)
                comboBoxPhase.Items.Add(i);
            
            var records =
                GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRecordDTO, CheckListRecords>(new Filter("CheckListId", _currentCheck.ItemId));

            _currentCheck.CheckListRecords.Clear();
            _currentCheck.CheckListRecords.AddRange(records);
            
            
            
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
            
            comboBoxPhase.SelectedItem = _currentCheck.Settings.Phase;


            comboBoxLevel.Items.Clear();
            comboBoxLevel.Items.AddRange(_levels.ToArray());
            comboBoxLevel.Items.Add(FindingLevels.Unknown);

            comboBoxLevel.SelectedItem = _levels.FirstOrDefault(i => i.ItemId == _currentCheck.Settings.LevelId) ??
                                         FindingLevels.Unknown;
            

            if (_record.Settings.ModData.ContainsKey("Source"))
            {
                checkBoxSource.Checked = true;
                metroTextSource.Text = (string)_record.Settings.ModData["Source"];
            }
            
            if (_record.Settings.ModData.ContainsKey("Reference"))
            {
                checkBoxRef.Checked = true;
                metroTextBoxReference.Text = (string)_record.Settings.ModData["Reference"];
            }
            
            if (_record.Settings.ModData.ContainsKey("Findings"))
            {
                checkBoxFindings.Checked = true;
                metroTextBoxDescribed.Text = (string)_record.Settings.ModData["Findings"];
            }
            
            if (_record.Settings.ModData.ContainsKey("Instructions"))
            {
                checkBoxInstructions.Checked = true;
                metroTextBoxInstructions.Text = (string)_record.Settings.ModData["Instructions"];
            }
            
            if (_record.Settings.ModData.ContainsKey("Check/ValidTo"))
            {
                checkBoxCheck.Checked = true;
                dateTimePickeValidTo.Value = (DateTime)_record.Settings.ModData["Check/ValidTo"];
            }
            
            if (_record.Settings.ModData.ContainsKey("Notify"))
            {
                checkBoxNotify.Checked = true;
                numericUpNotify.Value = (int)_record.Settings.ModData["Notify"];
            }
            
            if (_record.Settings.ModData.ContainsKey("Level"))
            {
                checkBoxLevel.Checked = true;
                comboBoxLevel.SelectedItem = _levels.FirstOrDefault(i => i.ItemId == (int)_record.Settings.ModData["Level"]);
            }
            
            if (_record.Settings.ModData.ContainsKey("Phase"))
            {
                checkBoxPhase.Checked = true;
                comboBoxPhase.SelectedItem = (string)_record.Settings.ModData["Phase"];
            }
            
            
            if (_record.Settings.ModData.ContainsKey("Requirement"))
            {
                checkBoxPhase.Checked = true;
                metroTextBoxRequirement.Text = (string)_record.Settings.ModData["Requirement"];
            }
            
            if (_record.Settings.ModData.ContainsKey("Section"))
            {
                checkBoxSection.Checked = true;
                var data = ((string)_record.Settings.ModData["Section"]).Split(new[]{"||"}, StringSplitOptions.None);
                metroTextBoxSectionNumber.Text = data.FirstOrDefault();
                metroTextBoxSectionName.Text = data.LastOrDefault();
            }
            
            if (_record.Settings.ModData.ContainsKey("Part"))
            {
                checkBoxPart.Checked = true;
                var data = ((string)_record.Settings.ModData["Part"]).Split(new[]{"||"}, StringSplitOptions.None);
                metroTextBoxPartNumber.Text = data.FirstOrDefault();
                metroTextBoxPartName.Text = data.LastOrDefault();
            }
            
            if (_record.Settings.ModData.ContainsKey("Subpart"))
            {
                checkBoxSubpart.Checked = true;
                var data = ((string)_record.Settings.ModData["Subpart"]).Split(new[]{"||"}, StringSplitOptions.None);
                metroTextBoxSubPartNumber.Text = data.FirstOrDefault();
                metroTextBoxSubPartName.Text = data.LastOrDefault();
            }
            
            if (_record.Settings.ModData.ContainsKey("Item"))
            {
                checkBoxItem.Checked = true;
                var data = ((string)_record.Settings.ModData["Item"]).Split(new[]{"||"}, StringSplitOptions.None);
                metroTextBoxItemNumber.Text = data.FirstOrDefault();
                metroTextBoxItemName.Text = data.LastOrDefault();
            }
            
            if (_record.Settings.ModData.ContainsKey("MH"))
            {
                checkBoxMh.Checked = true;
                comboBoxPhase.SelectedItem = (int)_record.Settings.ModData["MH"];
            }
            
            foreach (var rec in _currentCheck.CheckListRecords)
                UpdateRecords(rec);
        }

        private bool ApplyChanges()
        {

            if (checkBoxSource.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Source"))
                    _record.Settings.ModData.Add("Source", metroTextSource.Text);
                else _record.Settings.ModData["Source"] = metroTextSource.Text;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Source"))
                    _record.Settings.ModData.Remove("Source");
            }
            
            if (checkBoxRef.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Reference"))
                    _record.Settings.ModData.Add("Reference", metroTextBoxReference.Text);
                else _record.Settings.ModData["Reference"] = metroTextBoxReference.Text;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Reference"))
                    _record.Settings.ModData.Remove("Reference");
            }
            
            if (checkBoxFindings.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Findings"))
                    _record.Settings.ModData.Add("Findings", metroTextBoxDescribed.Text);
                else _record.Settings.ModData["Findings"] = metroTextBoxDescribed.Text;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Findings"))
                    _record.Settings.ModData.Remove("Findings");
            }
            
            if (checkBoxInstructions.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Instructions"))
                    _record.Settings.ModData.Add("Instructions", metroTextBoxInstructions.Text);
                else _record.Settings.ModData["Instructions"] = metroTextBoxInstructions.Text;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Instructions"))
                    _record.Settings.ModData.Remove("Instructions");
            }
            
            if (checkBoxCheck.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Check/ValidTo"))
                    _record.Settings.ModData.Add("Check/ValidTo", dateTimePickeValidTo.Value);
                else _record.Settings.ModData["Check/ValidTo"] = dateTimePickeValidTo.Value;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Check/ValidTo"))
                    _record.Settings.ModData.Remove("Check/ValidTo");
            }
            
            if (checkBoxNotify.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Notify"))
                    _record.Settings.ModData.Add("Notify", (int)numericUpNotify.Value);
                else _record.Settings.ModData["Notify"] =(int)numericUpNotify.Value;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Notify"))
                    _record.Settings.ModData.Remove("Notify");
            }
            
            if (checkBoxLevel.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Level"))
                    _record.Settings.ModData.Add("Level", ((FindingLevels) comboBoxLevel.SelectedItem).ItemId);
                else _record.Settings.ModData["Level"] = ((FindingLevels) comboBoxLevel.SelectedItem).ItemId;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Level"))
                    _record.Settings.ModData.Remove("Level");
            }
            
            if (checkBoxPhase.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Phase"))
                    _record.Settings.ModData.Add("Phase", (string)comboBoxPhase.SelectedItem);
                else _record.Settings.ModData["Phase"] = (string)comboBoxPhase.SelectedItem;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Phase"))
                    _record.Settings.ModData.Remove("Phase");
            }
            
            if (checkBoxReq.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Requirement"))
                    _record.Settings.ModData.Add("Requirement", metroTextBoxRequirement.Text);
                else _record.Settings.ModData["Requirement"] = metroTextBoxRequirement.Text;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Requirement"))
                    _record.Settings.ModData.Remove("Requirement");
            }
            
            if (checkBoxSection.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Section"))
                    _record.Settings.ModData.Add("Section", $"{metroTextBoxSectionNumber.Text} || {metroTextBoxSectionName.Text}");
                else _record.Settings.ModData["Section"] = $"{metroTextBoxSectionNumber.Text} || {metroTextBoxSectionName.Text}";
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Section"))
                    _record.Settings.ModData.Remove("Section");
            }
            
            if (checkBoxPart.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Part"))
                    _record.Settings.ModData.Add("Part", $"{metroTextBoxPartNumber.Text} || {metroTextBoxPartName.Text}");
                else _record.Settings.ModData["Part"] = $"{metroTextBoxPartNumber.Text} || {metroTextBoxPartName.Text}";
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Part"))
                    _record.Settings.ModData.Remove("Part");
            }
            
            if (checkBoxSubpart.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Subpart"))
                    _record.Settings.ModData.Add("Subpart", $"{metroTextBoxSubPartNumber.Text} || {metroTextBoxSubPartName.Text}");
                else _record.Settings.ModData["Subpart"] = $"{metroTextBoxSubPartNumber.Text} || {metroTextBoxSubPartName.Text}";
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Subpart"))
                    _record.Settings.ModData.Remove("Subpart");
            }
            
            if (checkBoxItem.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Item"))
                    _record.Settings.ModData.Add("Item", $"{metroTextBoxItemNumber.Text} || {metroTextBoxItemName.Text}");
                else _record.Settings.ModData["Item"] = $"{metroTextBoxItemNumber.Text} || {metroTextBoxItemName.Text}";
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Item"))
                    _record.Settings.ModData.Remove("Item");
            }
            
            if (checkBoxMh.Checked)
            {
                double manHours;
                if (!CheckManHours(out manHours))
                    return false;
                
                if (!_record.Settings.ModData.ContainsKey("MH"))
                    _record.Settings.ModData.Add("MH", manHours);
                else _record.Settings.ModData["MH"] = manHours;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("MH"))
                    _record.Settings.ModData.Remove("MH");
            }
            
            
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
                ApplyChanges();
                _record.Settings.RevisionCheckType = RevisionCheckType.Mod;
                GlobalObjects.CaaEnvironment.NewKeeper.Save(_record);
                
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
