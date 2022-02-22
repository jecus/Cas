using System;
using System.Collections.Generic;
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

namespace CAS.UI.UICAAControls.CheckList.EditionRevision.Safa
{
    public partial class CheckListSAFARevEditForm : MetroForm
    {
        private readonly int _revisionId;
        private CheckLists _currentCheck;
        private IList<FindingLevels> _levels = new List<FindingLevels>();
        private CheckListRevisionRecord _record;

        #region Constructors
        public CheckListSAFARevEditForm()
        {
            InitializeComponent();
        }

        public CheckListSAFARevEditForm(CheckLists check, int revisionId)
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
            
            var manual = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<StandartManualDTO, SmartCore.CAA.StandartManual.StandartManual>(_currentCheck.ManualId);
            _levels.Clear();
            _levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new []
            {
                new Filter("OperatorId", _currentCheck.OperatorId),
                new Filter("ProgramTypeId", manual.ProgramTypeId),
            });
            
            comboBoxCategory.Items.Clear();
            comboBoxCategory.Items.AddRange(_levels.ToArray());
            comboBoxCategory.Items.Add(FindingLevels.Unknown);
            comboBoxCategory.SelectedItem = _currentCheck.Level;
            
            metroTextSource.Text = _currentCheck.Source;
            metroTextBoxItem.Text = _currentCheck.SettingsSafa.Item;
            metroTextBoxItemNumber.Text = _currentCheck.SettingsSafa.ItemNumber;
            metroTextBoxInspectionTitle.Text = _currentCheck.SettingsSafa.Title;
            metroTextBoxStandard.Text = _currentCheck.SettingsSafa.Standard;
            metroTextBoxStandardRef.Text = _currentCheck.SettingsSafa.StandardRef;
            metroTextBoxPdfCode.Text = _currentCheck.SettingsSafa.PdfCode;
            metroTextBoxStandardText.Text = _currentCheck.SettingsSafa.StandardText;
            metroTextBoxFindings.Text = _currentCheck.SettingsSafa.PreDescribedFinding;
            metroTextBoxInstruction.Text = _currentCheck.SettingsSafa.Instruction;

            if (Math.Abs(_currentCheck.SettingsSafa.MH) > 0.000001)
                metroTextBoxMH.Text = _currentCheck.SettingsSafa.MH.ToString();
            
            
            
            if (_record.Settings.ModData.ContainsKey("Source"))
            {
                checkBoxSource.Checked = true;
                metroTextSource.Text = (string)_record.Settings.ModData["Source"];
            }
            
            if (_record.Settings.ModData.ContainsKey("MH"))
            {
                checkBoxMH.Checked = true;
                metroTextBoxMH.Text = (string)_record.Settings.ModData["MH"];
            }
            
            if (_record.Settings.ModData.ContainsKey("Inspection Item"))
            {
                checkBoxInspection.Checked = true;
                var data = ((string)_record.Settings.ModData["Item"]).Split(new[]{"||"}, StringSplitOptions.None);
                metroTextBoxItem.Text = data.FirstOrDefault();
                metroTextBoxItemNumber.Text = data.LastOrDefault();
            }
            
            if (_record.Settings.ModData.ContainsKey("Inspection Title"))
            {
                checkBoxTitle.Checked = true;
                metroTextBoxInspectionTitle.Text = (string)_record.Settings.ModData["Inspection Title"];
            }
            
            if (_record.Settings.ModData.ContainsKey("Standard"))
            {
                checkBoxStandard.Checked = true;
                metroTextBoxStandard.Text = (string)_record.Settings.ModData["Standard"];
            }
            
            if (_record.Settings.ModData.ContainsKey("Standard Ref"))
            {
                checkBoxRef.Checked = true;
                metroTextBoxStandardRef.Text = (string)_record.Settings.ModData["Standard Ref"];
            }
            
            if (_record.Settings.ModData.ContainsKey("PDF Code"))
            {
                checkBoxPdf.Checked = true;
                metroTextBoxPdfCode.Text = (string)_record.Settings.ModData["PDF Code"];
            }
            
            if (_record.Settings.ModData.ContainsKey("Standard Text"))
            {
                checkBoxStandardText.Checked = true;
                metroTextBoxStandardText.Text = (string)_record.Settings.ModData["Standard Text"];
            }
            
            if (_record.Settings.ModData.ContainsKey("Finding"))
            {
                checkBoxFinding.Checked = true;
                metroTextBoxFindings.Text = (string)_record.Settings.ModData["Finding"];
            }
            
            if (_record.Settings.ModData.ContainsKey("Instruction"))
            {
                checkBoxInstruction.Checked = true;
                metroTextBoxInstruction.Text = (string)_record.Settings.ModData["Instruction"];
            }
            
            if (_record.Settings.ModData.ContainsKey("Category"))
            {
                checkBoxCategory.Checked = true;
                comboBoxCategory.SelectedItem = _levels.FirstOrDefault(i => i.ItemId == (int)_record.Settings.ModData["Category"]);
            }
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
            
            if (checkBoxInspection.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Inspection Item"))
                    _record.Settings.ModData.Add("Inspection Item", $"{metroTextBoxItem.Text} || {metroTextBoxItemNumber.Text}");
                else _record.Settings.ModData["Inspection Item"] = $"{metroTextBoxItem.Text} || {metroTextBoxItemNumber.Text}";
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Inspection Item"))
                    _record.Settings.ModData.Remove("Inspection Item");
            }
            
            if (checkBoxTitle.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Inspection Title"))
                    _record.Settings.ModData.Add("Inspection Title", metroTextBoxInspectionTitle.Text);
                else _record.Settings.ModData["Inspection Title"] = metroTextBoxInspectionTitle.Text;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Inspection Title"))
                    _record.Settings.ModData.Remove("Inspection Title");
            }
            
            if (checkBoxStandard.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Standard"))
                    _record.Settings.ModData.Add("Standard", metroTextBoxStandard.Text);
                else _record.Settings.ModData["Standard"] = metroTextBoxStandard.Text;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Standard"))
                    _record.Settings.ModData.Remove("Standard");
            }
            
            if (checkBoxRef.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Standard Ref"))
                    _record.Settings.ModData.Add("Standard Ref", metroTextBoxStandardRef.Text);
                else _record.Settings.ModData["Standard Ref"] = metroTextBoxStandardRef.Text;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Standard Ref"))
                    _record.Settings.ModData.Remove("Standard Ref");
            }
            
            if (checkBoxPdf.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("PDF Code"))
                    _record.Settings.ModData.Add("PDF Code", metroTextBoxPdfCode.Text);
                else _record.Settings.ModData["PDF Code"] = metroTextBoxPdfCode.Text;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("PDF Code"))
                    _record.Settings.ModData.Remove("PDF Code");
            }
            
            if (checkBoxStandardText.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Standard Text"))
                    _record.Settings.ModData.Add("Standard Text", metroTextBoxStandardText.Text);
                else _record.Settings.ModData["Standard Text"] = metroTextBoxStandardText.Text;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Standard Text"))
                    _record.Settings.ModData.Remove("Standard Text");
            }
            
            if (checkBoxFinding.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Finding"))
                    _record.Settings.ModData.Add("Finding", metroTextBoxFindings.Text);
                else _record.Settings.ModData["Finding"] = metroTextBoxFindings.Text;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Finding"))
                    _record.Settings.ModData.Remove("Finding");
            }
            
            if (checkBoxInstruction.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Instruction"))
                    _record.Settings.ModData.Add("Instruction", metroTextBoxInstruction.Text);
                else _record.Settings.ModData["Instruction"] = metroTextBoxInstruction.Text;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Instruction"))
                    _record.Settings.ModData.Remove("Instruction");
            }
            
            if (checkBoxCategory.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Category"))
                    _record.Settings.ModData.Add("Category", ((FindingLevels)comboBoxCategory.SelectedItem).ItemId);
                else _record.Settings.ModData["Category"] = ((FindingLevels)comboBoxCategory.SelectedItem).ItemId;
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Category"))
                    _record.Settings.ModData.Remove("Category");
            }
            
            
            if (checkBoxMH.Checked)
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxCategory.Enabled = checkBoxCategory.Checked;
        }

        private void checkBoxMH_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxMH.Enabled = checkBoxMH.Checked;
        }

        private void checkBoxInspection_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxItem.Enabled = metroTextBoxItemNumber.Enabled = checkBoxInspection.Checked;
        }

        private void checkBoxTitle_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxInspectionTitle.Enabled = checkBoxTitle.Checked;
        }

        private void checkBoxStandard_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxStandard.Enabled = checkBoxStandard.Checked;
        }

        private void checkBoxRef_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxStandardRef.Enabled = checkBoxRef.Checked;
        }

        private void checkBoxPdf_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxPdfCode.Enabled = checkBoxPdf.Checked;
        }

        private void checkBoxStandardText_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxStandardText.Enabled = checkBoxStandardText.Checked;
        }

        private void checkBoxFinding_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxFindings.Enabled = checkBoxFinding.Enabled;
        }

        private void checkBoxInstruction_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxInstruction.Enabled = checkBoxInstruction.Checked;
        }
    }
}
