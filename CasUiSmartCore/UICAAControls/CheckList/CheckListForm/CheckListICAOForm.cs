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
using SmartCore.CAA.RoutineAudits;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Files;

namespace CAS.UI.UICAAControls.CheckList.CheckListForm
{
    public partial class CheckListICAOForm : MetroForm
    {
        private readonly int _revisionId;
        private  SmartCore.CAA.StandartManual.StandartManual _manual;
        private CheckLists _currentCheck;
        private readonly bool _enable;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private IList<FindingLevels> _levels = new List<FindingLevels>();

        #region Constructors
        public CheckListICAOForm()
        {
            InitializeComponent();
        }

        public CheckListICAOForm(CheckLists currentCheck, bool enable = true) : this()
        {
            _currentCheck = currentCheck;
            _enable = enable;
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();

            EnabledControls(enable);
        }
        
        public CheckListICAOForm(CheckLists currentCheck, int revisionId) : this(currentCheck)
        {
            _revisionId = revisionId;
        }

        private void EnabledControls(bool enable)
        {
            metroTextSource.Enabled =
                metroTextBoxAnnexRef.Enabled =
                    metroTextBoxPartNumber.Enabled =
                            metroTextBoxPartName.Enabled =
                                metroTextBoxChapterNumber.Enabled =
                                    metroTextBoxMH.Enabled =
                                    metroTextBoxChapterName.Enabled =
                                        metroTextBoxItemNumber.Enabled =
                                            metroTextBoxItemName.Enabled =
                                                metroTextBoxRequirement.Enabled =
                                                    metroTextBoxReference.Enabled =
                                                        buttonOk.Enabled =
                                                                            comboBoxLevel.Enabled = enable;
        }

        #endregion

        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateInformation();
        }

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            _manual = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<StandartManualDTO, SmartCore.CAA.StandartManual.StandartManual>(_currentCheck.ManualId);
            
            _levels.Clear();
            _levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new []
            {
                new Filter("OperatorId", _currentCheck.OperatorId),
                new Filter("ProgramTypeId", _manual.ProgramTypeId),
            });
            
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
                            Remark = string.Join(",", rec.Settings.ModData.OrderBy(i => i.Key).Select(i => i.Key)),
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
            metroTextBoxAnnexRef.Text = _currentCheck.SettingsIosa.AnnexRef;
            metroTextBoxPartNumber.Text = _currentCheck.SettingsIosa.PartNumber;
            metroTextBoxPartName.Text = _currentCheck.SettingsIosa.PartName;
            metroTextBoxChapterNumber.Text = _currentCheck.SettingsIosa.ChapterNumber;
            metroTextBoxChapterName.Text = _currentCheck.SettingsIosa.ChapterName;
            metroTextBoxItemNumber.Text = _currentCheck.SettingsIosa.ItemNumber;
            metroTextBoxItemName.Text = _currentCheck.SettingsIosa.ItemtName;
            metroTextBoxRequirement.Text = _currentCheck.SettingsIosa.Standard;
            
            metroTextBoxReference.Text = _currentCheck.SettingsIosa.Reference;
            metroTextBoxProgramType.Text = (ProgramType.GetItemById(_currentCheck.SettingsIosa.ProgramTypeId) ?? ProgramType.Unknown).ToString();

            if (Math.Abs(_currentCheck.SettingsIosa.MH) > 0.000001)
                metroTextBoxMH.Text = _currentCheck.SettingsIosa.MH.ToString();
            
            comboBoxLevel.Items.Clear();
            comboBoxLevel.Items.AddRange(_levels.ToArray());
            comboBoxLevel.Items.Add(FindingLevels.Unknown);
            comboBoxLevel.SelectedItem = _currentCheck.Level;

            fileControl.UpdateInfo(_currentCheck.File, "Adobe PDF Files|*.pdf",
                "This record does not contain a file proving the Document. Enclose PDF file to prove the Document.",
                "Attached file proves the Document.");


            foreach (var rec in _currentCheck.AllRevisions)
                UpdateRevision(rec);
        }
        
        private bool ApplyChanges()
        {
            _currentCheck.Source = metroTextSource.Text;
            _currentCheck.SettingsIosa.AnnexRef = metroTextBoxAnnexRef.Text;
            _currentCheck.SettingsIosa.PartNumber = metroTextBoxPartNumber.Text;
            _currentCheck.SettingsIosa.PartName = metroTextBoxPartName.Text;
            _currentCheck.SettingsIosa.ChapterNumber = metroTextBoxChapterNumber.Text;
            _currentCheck.SettingsIosa.ChapterName =  metroTextBoxChapterName.Text;
            _currentCheck.SettingsIosa.ItemNumber = metroTextBoxItemNumber.Text;
            _currentCheck.SettingsIosa.ItemtName = metroTextBoxItemName.Text;
            _currentCheck.SettingsIosa.Standard =  metroTextBoxRequirement.Text;
            
            _currentCheck.SettingsIosa.Reference = metroTextBoxReference.Text;
            _currentCheck.SettingsIosa.LevelId = ((FindingLevels) comboBoxLevel.SelectedItem).ItemId;


            double manHours;
            if (!CheckManHours(out manHours))
                return false;
            _currentCheck.SettingsIosa.MH = manHours;

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
