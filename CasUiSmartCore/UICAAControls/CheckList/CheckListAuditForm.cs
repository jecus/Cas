using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.CAA.Audit;
using SmartCore.CAA.Check;
using SmartCore.CAA.FindingLevel;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class CheckListAuditForm : MetroForm
    {
        private CheckLists _currentCheck;
        private readonly int _auditId;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private IList<FindingLevels> _levels = new List<FindingLevels>();
        private AuditCheck _currentAuditCheck;
        private List<AuditCheckRecord> _currentAuditCheckRecords = new List<AuditCheckRecord>();
        private IList<RootCause> _rootCase = new List<RootCause>();

        #region Constructors
        public CheckListAuditForm()
        {
            InitializeComponent();
        }

        public CheckListAuditForm(CheckLists currentCheck, int auditId) : this()
        {
            _currentCheck = currentCheck;
            _auditId = auditId;
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
        }

        #endregion

        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateControls();
            UpdateInformation();
        }

        private void UpdateControls()
        {

            comboBoxWorkFlowStatus.Items.Clear();
            comboBoxWorkFlowStatus.Items.AddRange(WorkFlowStatus.Items.ToArray());

            checkedListBoxRoot.Items.Clear();
            checkedListBoxRoot.Items.AddRange(_rootCase.ToArray());


            radioButtonNotSatisfactory.CheckedChanged += RadioButtonSatisfactory_CheckedChange;
            radioButtonSatisfactory.CheckedChanged += RadioButtonSatisfactory_CheckedChange;

            radioButtonNotSatisfactory.Enabled =
                radioButtonSatisfactory.Enabled =
                    metroTextBoxReference.Enabled =
                        checkedListBoxRoot.Enabled =
                            metroTextBoxComments.Enabled = !checkBoxNotApplicable.Checked;

            checkedListBoxRoot.Enabled = !radioButtonSatisfactory.Checked;

            foreach (var control in flowLayoutPanel1.Controls.OfType<AuditCheckControl>())
                control.EnableCheckBox(!checkBoxNotApplicable.Checked);
        }

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            if (_currentCheck == null) return;


            _rootCase = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<RootCauseDTO, RootCause>();

            _currentCheck =
                GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CheckListDTO, CheckLists>(_currentCheck.ItemId);
            _currentAuditCheck =
                GlobalObjects.CaaEnvironment.NewLoader.GetObject<AuditCheckDTO, AuditCheck>(new List<Filter>()
                {
                    new Filter("AuditId", _auditId),
                    new Filter("CheckListId", _currentCheck.ItemId),
                });
            if (_currentAuditCheck == null)
            {
                _currentAuditCheck = new AuditCheck()
                {
                    CheckListId = _currentCheck.ItemId,
                    AuditId = _auditId
                };
                GlobalObjects.CaaEnvironment.NewKeeper.Save(_currentAuditCheck);
            }

            if (_currentAuditCheck.ItemId > 0)
                _currentAuditCheckRecords = new List<AuditCheckRecord>(
                    GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<AuditCheckRecordDTO, AuditCheckRecord>(
                        new Filter("AuditRecordId", _currentAuditCheck.ItemId)));
            else _currentAuditCheckRecords = new List<AuditCheckRecord>();


            var records =
                GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRecordDTO, CheckListRecords>(
                    new Filter("CheckListId", _currentCheck.ItemId));


            foreach (var rec in records)
            {
                var find = _currentAuditCheckRecords.FirstOrDefault(i => i.CheckListRecordId == rec.ItemId);
                if (find == null)
                {
                    var newRecord = new AuditCheckRecord()
                    {
                        CheckListRecordId = rec.ItemId,
                        AuditRecordId = _currentAuditCheck.ItemId,
                        CheckListRecord = rec
                    };
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(newRecord);

                    _currentAuditCheckRecords.Add(newRecord);
                }
                else find.CheckListRecord = rec;
            }

            _currentCheck.CheckListRecords.Clear();
            _currentCheck.CheckListRecords.AddRange(records);

            _levels.Clear();
            _levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>();
            _currentCheck.Level = _levels.FirstOrDefault(i => i.ItemId == _currentCheck.Settings.LevelId) ??
                                  FindingLevels.Unknown;
        }

        private void UpdateInformation()
        {
            labelSourceText.Text = _currentCheck.Source;
            labelEditorText.Text = _currentCheck.EditionNumber;
            labelRevisionText.Text = _currentCheck.RevisionNumber;
            labelLevelText.Text = _currentCheck.Level.ToString();

            metroTextBoxSection.Text = $"{_currentCheck.SectionNumber} {_currentCheck.SectionName}";
            metroTextBoxPart.Text = $"{_currentCheck.PartNumber} {_currentCheck.PartName}";
            metroTextBoxSubPart.Text = $"{_currentCheck.SubPartNumber} {_currentCheck.SubPartName}";
            metroTextBoxItem.Text = $"{_currentCheck.ItemNumber} {_currentCheck.ItemName}";
            metroTextBoxRequirement.Text = _currentCheck.Requirement;

            checkBoxNotApplicable.Checked = _currentAuditCheck.Settings.IsApplicable ;

            radioButtonSatisfactory.Checked = _currentAuditCheck.Settings.IsSatisfactory;
            radioButtonNotSatisfactory.Checked = !radioButtonSatisfactory.Checked;
            metroTextBoxReference.Text = _currentAuditCheck.Settings.SubReference;
            metroTextBoxComments.Text = _currentAuditCheck.Settings.Comments;

            comboBoxWorkFlowStatus.SelectedItem = WorkFlowStatus.GetItemById(_currentAuditCheck.Settings.WorkflowStatusId);

            for (int i = 0; i < checkedListBoxRoot.Items.Count; i++)
            {
                if (!string.IsNullOrEmpty(_currentAuditCheck.Settings.RootCause) &&_currentAuditCheck.Settings.RootCause.Contains(checkedListBoxRoot.Items[i].ToString()))
                    checkedListBoxRoot.SetItemChecked(i, true);
            }

            foreach (var group in _currentCheck.CheckListRecords.GroupBy(i => i.OptionNumber))
            {
                flowLayoutPanel1.Controls.Add(new Label()
                {
                    Text = $"Option: {group.Key}",
                    Font = new System.Drawing.Font("Verdana", 9F),
                    ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))))
                });
                foreach (var record in group)
                {
                    var control = new AuditCheckControl(_currentAuditCheckRecords.FirstOrDefault(i => i.CheckListRecordId == record.ItemId));
                    flowLayoutPanel1.Controls.Add(control);
                }
            }

        }

        private void ApplyChanges()
        {
            _currentAuditCheck.Settings.IsApplicable = checkBoxNotApplicable.Checked;
            _currentAuditCheck.Settings.IsSatisfactory = radioButtonSatisfactory.Checked;
            _currentAuditCheck.Settings.SubReference = metroTextBoxReference.Text;
            _currentAuditCheck.Settings.Comments = metroTextBoxComments.Text;
            _currentAuditCheck.Settings.WorkflowStatusId = ((WorkFlowStatus)comboBoxWorkFlowStatus.SelectedItem).ItemId;

            foreach (var item in checkedListBoxRoot.CheckedItems)
                _currentAuditCheck.Settings.RootCause += $"{item}, ";
        }


        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            try
            {

                ApplyChanges();

                GlobalObjects.CaaEnvironment.NewKeeper.Save(_currentAuditCheck);


                foreach (var control in flowLayoutPanel1.Controls.OfType<AuditCheckControl>())
                {
                    control.ApplyChanges();
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(control.AuditCheckRecord, true);
                }


                DialogResult = DialogResult.OK;
                Close();
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

        

        private void checkBoxNotApplicable_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonNotSatisfactory.Enabled =
                radioButtonSatisfactory.Enabled =
                    metroTextBoxReference.Enabled =
                        checkedListBoxRoot.Enabled = 
                metroTextBoxComments.Enabled = !checkBoxNotApplicable.Checked;

            checkedListBoxRoot.Enabled = !radioButtonSatisfactory.Checked;

            foreach (var control in flowLayoutPanel1.Controls.OfType<AuditCheckControl>())
                control.EnableCheckBox(!checkBoxNotApplicable.Checked);
        }



        private void RadioButtonSatisfactory_CheckedChange(object sender, EventArgs e)
        {
            if(radioButtonSatisfactory.Checked)
                checkedListBoxRoot.SelectionMode = SelectionMode.None;
            else checkedListBoxRoot.SelectionMode = SelectionMode.One;
            checkedListBoxRoot.Enabled = !radioButtonSatisfactory.Checked;
        }
    }
}
