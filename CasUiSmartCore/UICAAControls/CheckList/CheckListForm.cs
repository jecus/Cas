using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.CAA.Check;
using SmartCore.CAA.FindingLevel;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Files;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class CheckListForm : MetroForm
    {
        private readonly int _revisionId;
        private CheckLists _currentCheck;
        private readonly bool _enable;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private IList<FindingLevels> _levels = new List<FindingLevels>();

        #region Constructors
        public CheckListForm()
        {
            InitializeComponent();
        }

        public CheckListForm(CheckLists currentCheck, bool enable = true) : this()
        {
            _currentCheck = currentCheck;
            _enable = enable;
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();

            EnabledControls(enable);
        }
        
        public CheckListForm(CheckLists currentCheck, int revisionId) : this(currentCheck, true)
        {
            _revisionId = revisionId;
        }

        private void EnabledControls(bool enable)
        {
            metroTextSource.Enabled =
                metroTextBoxSectionNumber.Enabled =
                    metroTextBoxSectionName.Enabled =
                        metroTextBoxPartNumber.Enabled =
                            metroTextBoxPartName.Enabled =
                                metroTextBoxSubPartNumber.Enabled =
                                    metroTextBoxSubPartName.Enabled =
                                        metroTextBoxItemNumber.Enabled =
                                            metroTextBoxItemName.Enabled =
                                                metroTextBoxRequirement.Enabled =
                                                    dateTimePickeValidTo.Enabled =
                                                        numericUpNotify.Enabled =
                                                            metroTextBoxReference.Enabled =
                                                                metroTextBoxDescribed.Enabled =
                                                                    metroTextBoxInstructions.Enabled =
                                                                        comboBoxPhase.Enabled =
                                                                        buttonOk.Enabled =
                                                                            linkLabel1.Enabled =
                                                                            comboBoxLevel.Enabled = enable;
        }

        #endregion

        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateInformation();
        }

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            _levels.Clear();
            _levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new Filter("OperatorId", _currentCheck.OperatorId));
            
            if (_currentCheck == null) return;

            if (_currentCheck.ItemId > 0)
            {
                _currentCheck = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CheckListDTO, CheckLists>(_currentCheck.ItemId);
                var records =
                    GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRecordDTO, CheckListRecords>(new Filter("CheckListId", _currentCheck.ItemId));

                _currentCheck.CheckListRecords.Clear();
                _currentCheck.CheckListRecords.AddRange(records);

                _currentCheck.AllRevisions.Clear();
                
                var edition =
                    GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CheckListRevisionDTO, CheckListRevision>(_currentCheck.EditionId);
                if (edition != null)
                {
                    _currentCheck.AllRevisions.Add(new EditionRevisionView()
                    {
                        Date = edition.Date,
                        Number = edition.Number,
                        Remark = edition.Settings.Remark,
                        Type = edition.Type,
                        EffDate = edition.EffDate
                    });
                }
                
                
                var revisionRec = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionRecordDTO, CheckListRevisionRecord>(new Filter("CheckListId", _currentCheck.ItemId));
                if (revisionRec.Any())
                {
                    var ids = revisionRec.Select(i => i.ParentId);
                    var revisions = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionDTO, CheckListRevision>(new Filter("ItemId", ids));

                    foreach (var rec in revisionRec)
                    {
                        var revision = revisions.FirstOrDefault(i => i.ItemId == rec.ParentId);
                        if(revision == null)
                            continue;
                        
                        _currentCheck.AllRevisions.Add(new EditionRevisionView()
                        {
                            Date = revision.Date,
                            Number = revision.Number,
                            Remark = string.Join(",", rec.Settings.ModData.Select(i => i.Key)),
                            Type = revision.Type,
                            EffDate = revision.EffDate
                        });
                    }
                }

                var links = GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAAItemFileLinkDTO, ItemFileLink>(new List<Filter>()
                {
                    new Filter("ParentId",_currentCheck.ItemId),
                    new Filter("ParentTypeId",_currentCheck.SmartCoreObjectType.ItemId)
                }, true);

                var fileIds = links.Where(i => i.FileId.HasValue).Select(i => i.FileId.Value);
                if (fileIds.Any())
                {
                    var files = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAAAttachedFileDTO, AttachedFile>(new Filter("ItemId", values: fileIds));
                    foreach (var file in links)
                    {
                        var f = files.FirstOrDefault(i => i.ItemId == file.FileId)?.GetCopyUnsaved(false);
                        if (f == null) continue;
                        f.ItemId = file.FileId.Value;
                        file.File = (AttachedFile)f;

                    }
                }
                _currentCheck.Files = new CommonCollection<ItemFileLink>(links);
                _currentCheck.Level = _levels.FirstOrDefault(i => i.ItemId == _currentCheck.Settings.LevelId) ??
                                      FindingLevels.Unknown;
            }
        }

        private void UpdateInformation()
        {
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

            fileControl.UpdateInfo(_currentCheck.File, "Adobe PDF Files|*.pdf",
                "This record does not contain a file proving the Document. Enclose PDF file to prove the Document.",
                "Attached file proves the Document.");


            foreach (var rec in _currentCheck.AllRevisions)
                UpdateRevision(rec);

            foreach (var rec in _currentCheck.CheckListRecords)
                UpdateRecords(rec);
        }
        
        private bool ApplyChanges()
        {

            //_currentCheck.Settings.EditionNumber = metroTextBoxEditionNumber.Text;
            //_currentCheck.Settings.EditionDate = dateTimePickerEditionDate.Value;
            //
            //_currentCheck.Settings.RevisonValidTo = checkBoxRevisionValidTo.Checked;
            //_currentCheck.Settings.RevisonValidToDate = dateTimePickeValidTo.Value;


            _currentCheck.Source = metroTextSource.Text;
            _currentCheck.Settings.SectionNumber = metroTextBoxSectionNumber.Text;
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

            if (fileControl.GetChangeStatus())
            {
                fileControl.ApplyChanges();
                _currentCheck.File = fileControl.AttachedFile;
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
            if(!_enable)
                control.DisableControls();
            flowLayoutPanel1.Controls.Remove(linkLabel1);
            flowLayoutPanel1.Controls.Add(control);
            flowLayoutPanel1.Controls.Add(linkLabel1);
        }
        

        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            try
            {
                if(ApplyChanges())
                {
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(_currentCheck, true);

                    if (_currentCheck.EditionId == -1)
                    {
                        GlobalObjects.CaaEnvironment.NewKeeper.Save(new CheckListRevisionRecord()
                        {
                            CheckListId = _currentCheck.ItemId,
                            ParentId = _revisionId,
                            Settings = new CheckListRevisionRecordSettings()
                            {
                                RevisionCheckType = RevisionCheckType.New
                            }
                        });
                    }


                    foreach (var control in flowLayoutPanel1.Controls.OfType<AuditControl>())
                    {
                        control.ApplyChanges();
                        control.Record.CheckListId = _currentCheck.ItemId;
                        GlobalObjects.CaaEnvironment.NewKeeper.Save(control.Record, true);
                    }


                    DialogResult = DialogResult.OK;
                    Close();
                }

                
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
        

        private void UpdateRevision(EditionRevisionView rec)
        {
            var control = new RevisionControl(rec);
            flowLayoutPanel2.Controls.Add(control);
        }
    }
}
