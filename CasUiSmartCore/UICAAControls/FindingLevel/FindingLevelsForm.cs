using System;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using Entity.Abstractions;
using MetroFramework.Forms;
using SmartCore.CAA.FindingLevel;
using SmartCore.CAA.RoutineAudits;

namespace CAS.UI.UICAAControls.FindingLevel
{
    public partial class FindingLevelsForm : MetroForm
    {
        private readonly FindingLevels _level;

        public FindingLevelsForm()
        {
            InitializeComponent();
        }
        
        public FindingLevelsForm(FindingLevels level)
        {
            _level = level;
            InitializeComponent();
            UpdateInformation();
        }

        private void UpdateInformation()
        {
            this.comboBoxProgramType.SelectedIndexChanged -= new System.EventHandler(this.comboBoxProgramType_SelectedIndexChanged);
            comboBoxProgramType.Items.Clear();
            comboBoxProgramType.Items.AddRange(ProgramType.Items.ToArray());
            comboBoxProgramType.SelectedItem = _level.ProgramType;

            metroTextLevel.Text = _level.LevelName;
            metroTextBoxRemark.Text = _level.Remark;
            
            comboBoxColor.DataSource = Enum.GetValues(typeof(LevelColor));
            comboBoxColor.SelectedItem = _level.LevelColor;
            
            comboBoxClass.DataSource = Enum.GetValues(typeof(LevelClass));
            comboBoxClass.SelectedItem = _level.LevelClass;

            lifelengthCorrective.Lifelength = _level.CorrectiveAction;
            lifelengthViewerFinal.Lifelength = _level.FinalAction;
            
            comboBoxAction.Items.Clear();
            comboBoxAction.Items.AddRange(ActionProgramType.Items.Where(i => i.ProgramTypes.Contains(_level.ProgramType)).ToArray());
            comboBoxAction.Items.Add(ActionProgramType.Unknown);
            comboBoxAction.SelectedItem = _level.ActionProgramType;
            
            if (comboBoxAction.SelectedItem == null)
                comboBoxAction.SelectedItem = ActionProgramType.Unknown;
            
            this.comboBoxProgramType.SelectedIndexChanged += new System.EventHandler(this.comboBoxProgramType_SelectedIndexChanged);
            
        }

        private void ApplyChanges()
        {
            _level.ProgramType = (ProgramType)comboBoxProgramType.SelectedItem;
            _level.LevelName = metroTextLevel.Text;
            _level.Remark = metroTextBoxRemark.Text;
            _level.LevelColor = (LevelColor)comboBoxColor.SelectedItem ;
            _level.LevelClass = (LevelClass)comboBoxClass.SelectedItem ;
            
            _level.CorrectiveAction = lifelengthCorrective.Lifelength;
            _level.FinalAction = lifelengthViewerFinal.Lifelength;
            
            _level.ActionProgramType = (ActionProgramType)comboBoxAction.SelectedItem;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                ApplyChanges();
                GlobalObjects.CaaEnvironment.NewKeeper.Save(_level);
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

        private void comboBoxProgramType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxAction.Items.Clear();
            comboBoxAction.Items.AddRange(ActionProgramType.Items.Where(i => i.ProgramTypes.Contains((ProgramType)comboBoxProgramType.SelectedItem)).ToArray());
            comboBoxAction.Items.Add(ActionProgramType.Unknown);
            comboBoxAction.SelectedItem = _level.ActionProgramType;
            
            if (comboBoxAction.SelectedItem == null)
                comboBoxAction.SelectedItem = ActionProgramType.Unknown;
        }
    }
}