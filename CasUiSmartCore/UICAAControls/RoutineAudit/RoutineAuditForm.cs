using System;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.CAA.Check;
using SmartCore.CAA.RoutineAudits;

namespace CAS.UI.UICAAControls.RoutineAudit
{
    public partial class RoutineAuditForm : MetroForm
    {
        private SmartCore.CAA.RoutineAudits.RoutineAudit _audit;

        public RoutineAuditForm()
        {
            InitializeComponent();
        }

        public RoutineAuditForm(SmartCore.CAA.RoutineAudits.RoutineAudit audit) : this()
        {
            _audit = audit;
            UpdateInformation();
        }
        
        private void UpdateInformation()
        {
            comboBoxProgramType.Items.Clear();
            comboBoxProgramType.Items.AddRange(ProgramType.Items.OrderBy(i => i.FullName).ToArray());
            comboBoxProgramType.SelectedItem = _audit.Type;

            comboBoxObject.Items.Clear();
            comboBoxObject.Items.AddRange(RoutineObject.Items.OrderBy(i => i.FullName).ToArray());
            comboBoxObject.SelectedItem = _audit.RoutineObject;

            metroTextBoxTitle.Text = _audit.Title;
            metroTextBoxDescription.Text = _audit.Description;
            metroTextBoxRemark.Text = _audit.Remark;
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                    Save();
                    MessageBox.Show("All records updated successfull!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    DialogResult = DialogResult.OK;
                    Close();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save checkList", ex);
            }
        }

        private void ApplyChanges()
        {
            _audit.Title = metroTextBoxTitle.Text;
            _audit.Type = (ProgramType)comboBoxProgramType.SelectedItem;
            _audit.RoutineObject = (RoutineObject)comboBoxObject.SelectedItem;
            _audit.Description = metroTextBoxDescription.Text;
            _audit.Remark = metroTextBoxRemark.Text;
        }

        private void Save()
        {
            ApplyChanges();
            GlobalObjects.CaaEnvironment.NewKeeper.Save(_audit);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        private void RoutineAuditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
