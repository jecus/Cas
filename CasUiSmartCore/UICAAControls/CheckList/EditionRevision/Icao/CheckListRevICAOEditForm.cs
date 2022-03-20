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

namespace CAS.UI.UICAAControls.CheckList.EditionRevision.Icao
{
    public partial class CheckListRevICAOEditForm : MetroForm
    {
        private CheckLists _currentCheck;
        private readonly CheckListRevision _revision;
        private IList<FindingLevels> _levels = new List<FindingLevels>();
        private CheckListRevisionRecord _record;

        #region Constructors
        public CheckListRevICAOEditForm(CheckLists check, CheckListRevision revision)
        {
            
            InitializeComponent();
            _currentCheck = check;
            _revision = revision;
            UpdateInformation();
            
            if (_revision.Status == EditionRevisionStatus.Current || _revision.Status == EditionRevisionStatus.Previous)
            {
                foreach (var c in this.Controls.OfType<Control>().Where(i => !(i.GetType() ==  typeof(Button))))
                    c.Enabled = false;
            }

        }
        
        #endregion
        
         private void UpdateInformation()
         {
             _record = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionRecordDTO, CheckListRevisionRecord>(new List<Filter>()
             {
                 new Filter("CheckListId", _currentCheck.ItemId),
                 new Filter("ParentId", _revision.ItemId),
             }).FirstOrDefault();
            
             var manual = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<StandartManualDTO, SmartCore.CAA.StandartManual.StandartManual>(_currentCheck.ManualId);
            _levels.Clear();
            _levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new []
            {
                new Filter("OperatorId", _currentCheck.OperatorId),
                new Filter("ProgramTypeId", manual.ProgramTypeId),
            });
            
            var records =
                GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRecordDTO, CheckListRecords>(new Filter("CheckListId", _currentCheck.ItemId));

            _currentCheck.CheckListRecords.Clear();
            _currentCheck.CheckListRecords.AddRange(records);
            
            metroTextSource.Text = _currentCheck.Source;
            metroTextBoxAnnexRef.Text = _currentCheck.SettingsIcao.AnnexRef;
            metroTextBoxPartNumber.Text = _currentCheck.SettingsIcao.PartNumber;
            metroTextBoxPartName.Text = _currentCheck.SettingsIcao.PartName;
            metroTextBoxChapterNumber.Text = _currentCheck.SettingsIcao.ChapterNumber;
            metroTextBoxChapterName.Text = _currentCheck.SettingsIcao.ChapterName;
            metroTextBoxItemNumber.Text = _currentCheck.SettingsIcao.ItemNumber;
            metroTextBoxItemName.Text = _currentCheck.SettingsIcao.ItemtName;
            metroTextBoxStandard.Text = _currentCheck.SettingsIcao.Standard;

            metroTextBoxReference.Text = _currentCheck.SettingsIcao.Reference;



            if (Math.Abs(_currentCheck.SettingsIcao.MH) > 0.000001)
                metroTextBoxMH.Text = _currentCheck.SettingsIcao.MH.ToString();
            

            comboBoxLevel.Items.Clear();
            comboBoxLevel.Items.AddRange(_levels.ToArray());
            comboBoxLevel.Items.Add(FindingLevels.Unknown);

            comboBoxLevel.SelectedItem = _levels.FirstOrDefault(i => i.ItemId == _currentCheck.SettingsIcao.LevelId) ??
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
            
            if (_record.Settings.ModData.ContainsKey("Level"))
            {
                checkBoxLevel.Checked = true;
                comboBoxLevel.SelectedItem = _levels.FirstOrDefault(i => i.ItemId == (int)_record.Settings.ModData["Level"]);
            }
            
            if (_record.Settings.ModData.ContainsKey("Standard"))
            {
                checkBoxReq.Checked = true;
                metroTextBoxStandard.Text = (string)_record.Settings.ModData["Standard"];
            }
            
            if (_record.Settings.ModData.ContainsKey("AnnexRef"))
            {
                checkBoxAnnexRef.Checked = true;
                metroTextBoxAnnexRef.Text = (string)_record.Settings.ModData["AnnexRef"];
            }
            
            if (_record.Settings.ModData.ContainsKey("Part"))
            {
                checkBoxPart.Checked = true;
                var data = ((string)_record.Settings.ModData["Part"]).Split(new[]{"||"}, StringSplitOptions.None);
                metroTextBoxPartNumber.Text = data.FirstOrDefault();
                metroTextBoxPartName.Text = data.LastOrDefault();
            }
            
            if (_record.Settings.ModData.ContainsKey("Chapter"))
            {
                checkBoxSubpart.Checked = true;
                var data = ((string)_record.Settings.ModData["Chapter"]).Split(new[]{"||"}, StringSplitOptions.None);
                metroTextBoxChapterNumber.Text = data.FirstOrDefault();
                metroTextBoxChapterName.Text = data.LastOrDefault();
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
                metroTextBoxMH.Text = _record.Settings.ModData["MH"].ToString();
            }
            
            if (_record.Settings.RevisionCheckType == RevisionCheckType.Del)
            {
                radioButtonDel.Checked = true;
                CheckedCheckBox(false);
                DisableCheckBox(false);
            }
            else
            {
                radioButtonMod.Checked = true;
                DisableCheckBox(true);
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
            
            
            if (checkBoxReq.Checked)
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
            
            if (checkBoxAnnexRef.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("AnnexRef"))
                    _record.Settings.ModData.Add("AnnexRef", $"{metroTextBoxAnnexRef.Text}");
                else _record.Settings.ModData["AnnexRef"] = $"{metroTextBoxAnnexRef.Text}";
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("AnnexRef"))
                    _record.Settings.ModData.Remove("AnnexRef");
            }
            
            if (checkBoxPart.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Part"))
                    _record.Settings.ModData.Add("Part", $"{metroTextBoxPartNumber.Text}||{metroTextBoxPartName.Text}");
                else _record.Settings.ModData["Part"] = $"{metroTextBoxPartNumber.Text}||{metroTextBoxPartName.Text}";
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Part"))
                    _record.Settings.ModData.Remove("Part");
            }
            
            if (checkBoxSubpart.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Chapter"))
                    _record.Settings.ModData.Add("Chapter", $"{metroTextBoxChapterNumber.Text}||{metroTextBoxChapterName.Text}");
                else _record.Settings.ModData["Chapter"] = $"{metroTextBoxChapterNumber.Text}||{metroTextBoxChapterName.Text}";
            }
            else
            {
                if (_record.Settings.ModData.ContainsKey("Chapter"))
                    _record.Settings.ModData.Remove("Chapter");
            }
            
            if (checkBoxItem.Checked)
            {
                if (!_record.Settings.ModData.ContainsKey("Item"))
                    _record.Settings.ModData.Add("Item", $"{metroTextBoxItemNumber.Text}||{metroTextBoxItemName.Text}");
                else _record.Settings.ModData["Item"] = $"{metroTextBoxItemNumber.Text}||{metroTextBoxItemName.Text}";
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
        
        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            try
            {
                ApplyChanges();
                
                if (radioButtonDel.Checked)
                {
                    _record.Settings.RevisionCheckType = RevisionCheckType.Del;
                    _record.Settings.ModData.Clear();
                }
                else _record.Settings.RevisionCheckType = RevisionCheckType.Mod;
                
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
        
        private void checkBoxRef_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxReference.Enabled = checkBoxRef.Checked;
        }
        
        private void checkBoxLevel_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxLevel.Enabled = checkBoxLevel.Enabled;
        }
        
        private void checkBoxMh_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxMH.Enabled = checkBoxMh.Checked;
        }

        private void checkBoxSection_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxAnnexRef.Enabled = checkBoxAnnexRef.Checked;
        }

        private void checkBoxPart_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxPartNumber.Enabled =
                metroTextBoxPartName.Enabled = checkBoxPart.Checked;
        }

        private void checkBoxSubpart_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxChapterNumber.Enabled =
                metroTextBoxChapterName.Enabled = checkBoxSubpart.Checked;
        }

        private void checkBoxItem_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxItemNumber.Enabled =
                metroTextBoxItemName.Enabled = checkBoxItem.Checked;
        }

        private void checkBoxReq_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxStandard.Enabled = checkBoxReq.Checked;
        }

        private void radioButtonMod_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDel.Checked)
            {
                CheckedCheckBox(false);
                DisableCheckBox(false);
            }
            else DisableCheckBox(true);
        }
        
        private void CheckedCheckBox(bool flag = false)
        {
            checkBoxSource.Checked =
                checkBoxRef.Checked =
                    checkBoxLevel.Checked =
                        checkBoxMh.Checked =
                            checkBoxAnnexRef.Checked =
                                    checkBoxPart.Checked =
                                        checkBoxSubpart.Checked =
                                            checkBoxItem.Checked =
                                                checkBoxReq.Checked = flag;
        }
        
        private void DisableCheckBox(bool flag = true)
        {
            checkBoxSource.Enabled =
                checkBoxRef.Enabled =
                    checkBoxLevel.Enabled =
                        checkBoxMh.Enabled =
                            checkBoxAnnexRef.Enabled =
                                checkBoxPart.Enabled =
                                    checkBoxSubpart.Enabled =
                                        checkBoxItem.Enabled =
                                            checkBoxReq.Enabled = flag;
        }
    }
}
