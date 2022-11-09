using System;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.Dictionaries;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.CAA.CAAEducation;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UICAAControls.CAAEducation
{
    public partial class EducationComplianceForm : MetroForm
    {
        private readonly CAAEducationRecord _record;
        private readonly CAAEducationLastCompliance _compliance;

        public EducationComplianceForm(CAAEducationRecord record, CAAEducationLastCompliance compliance)
        {
            _record = record;
            _compliance = compliance;
            InitializeComponent();
            UpdateInformation();
        }
        
        
        private void UpdateInformation()
        {
            if (_compliance?.DocumentId != null)
            {
                var document = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAADocumentDTO, SmartCore.Entities.General.Document>(_compliance.DocumentId.Value);
                _compliance.Document = document;
                documentControl1.CurrentDocument = document;
            }
            
            if (_compliance?.LastDate != null)
            {
                dateTimePickeValidTo.Value = _compliance.LastDate.Value;
                metroTextBoxRemark.Text = _compliance.Remark;
                
                checkBoxAircraft.Checked = _compliance.IsAircraft;
                checkBoxRepeat.Checked = _compliance.IsRepeat;
                checkBoxLevel.Checked = _compliance.IsLevel;
                
                lifelengthViewer.Enabled = checkBoxRepeat.Checked;
                comboAircraft.Enabled = checkBoxAircraft.Checked;
                comboBoxLevel.Enabled = checkBoxLevel.Checked;
                
                var aircraftModels =  GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, AircraftModel>(new Filter("ModelingObjectTypeId", 7));
                comboAircraft.Items.Clear();
                foreach (var aircraftModel in aircraftModels.OrderBy(i => i.FullName))
                    comboAircraft.Items.Add(aircraftModel);
                comboAircraft.Items.Add(AircraftModel.Unknown);

                comboAircraft.SelectedItem = aircraftModels.FirstOrDefault(i => i.ItemId == _compliance.AircraftId) ?? AircraftModel.Unknown;
                lifelengthViewer.Lifelength = _compliance.Repeat;
                
                comboBoxLevel.Items.Clear();
                foreach (var level in EnglishLevel.Items)
                    comboBoxLevel.Items.Add(level);
                
                comboBoxLevel.SelectedItem = EnglishLevel.Items.FirstOrDefault(i => i.ItemId == _compliance.LevelId) ?? EnglishLevel.Unknown;
                
            }
            else
            {
                if (_record.Settings.NextCompliance != null && _record.Settings.NextCompliance.NextDate != null)
                    dateTimePickeValidTo.Value = _record.Settings.NextCompliance.NextDate.Value;
                else dateTimePickeValidTo.Value = DateTime.Now;
            }
            documentControl1.Added += DocumentControl1_Added;
        }
        
        
        private void DocumentControl1_Added(object sender, EventArgs e)
        {
            var newDocument = new SmartCore.Entities.General.Document
            {
                OperatorId = _record.OperatorId,
                Parent = _record,
                ParentId = _record.ItemId,
                ParentTypeId = _record.SmartCoreObjectType.ItemId,
                DocType = DocumentType.Document,
                IsClosed = false,
            };
            
            var form = new DocumentForm(newDocument, _record ,_record.OperatorId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _compliance.Document = newDocument;
                documentControl1.CurrentDocument = newDocument;
            }
        }

        private void ApplyChanges()
        {
            _compliance.Remark = metroTextBoxRemark.Text;
            _compliance.LastDate = dateTimePickeValidTo.Value;
            
            _compliance.IsAircraft = checkBoxAircraft.Checked;
            _compliance.IsRepeat = checkBoxRepeat.Checked;
            _compliance.IsLevel = checkBoxLevel.Checked;
            
            _compliance.Repeat = lifelengthViewer.Lifelength;
            _compliance.LevelId = (comboBoxLevel.SelectedItem as EnglishLevel).ItemId;
            _compliance.AircraftId = (comboAircraft.SelectedItem as AircraftModel).ItemId;
            
            
            if (documentControl1.CurrentDocument != null)
                _compliance.DocumentId = documentControl1.CurrentDocument.ItemId;

            if (_compliance.ItemId <= 0)
            {
                _compliance.ItemId = GlobalObjects.CaaEnvironment.ObtainId();
                _record.Settings.LastCompliances.Add(_compliance);
            }
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

        private void checkBoxRepeat_CheckedChanged(object sender, EventArgs e)
        {
            lifelengthViewer.Enabled = checkBoxRepeat.Checked;
        }

        private void checkBoxAircraft_CheckedChanged(object sender, EventArgs e)
        {
            comboAircraft.Enabled = checkBoxAircraft.Checked;
            
            if (checkBoxAircraft.Checked && checkBoxLevel.Checked)
                checkBoxLevel.Checked = false;
        }

        private void checkBoxLevel_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxLevel.Enabled = checkBoxLevel.Checked;
            
            if (checkBoxAircraft.Checked && checkBoxLevel.Checked)
                checkBoxAircraft.Checked = false;
            
            if (checkBoxRepeat.Checked && checkBoxLevel.Checked)
                checkBoxRepeat.Checked = false;
        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lvl = comboBoxLevel.SelectedItem as EnglishLevel;
            var ll = Lifelength.Zero;
            ll.CalendarType = CalendarTypes.Years;

            if (lvl == EnglishLevel.Four)
                ll.CalendarValue = 3;
            else if (lvl == EnglishLevel.Five)
                ll.CalendarValue = 5;
            else if (lvl == EnglishLevel.Six)
                ll = Lifelength.Null;

            lifelengthViewer.Lifelength = ll;
        }
    }
}