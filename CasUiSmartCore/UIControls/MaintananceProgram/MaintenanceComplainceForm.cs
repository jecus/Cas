using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    ///</summary>
    public partial class MaintenanceComplainceForm : Form
    {

        #region Fields

        private bool _isEdit;
        ///<summary>
        ///</summary>
        private List<MaintenanceCheckRecord> _compliance;

        private List<MaintenanceNextPerformance> _performances;
        ///<summary>
        /// Номер группы
        ///</summary>
        private int _numGroup;
        ///<summary>
        ///</summary>
        private List<MaintenanceCheck> _currentChecks;

        ///<summary>
        ///</summary>
        private readonly Aircraft _currentAircraft;
        /// <summary>
        /// 
        /// </summary>
        private readonly AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

        #endregion

        #region Constructors

        #region private MaintenanceComplainceForm()
        ///<summary>
        ///</summary>
        private MaintenanceComplainceForm()
        {
            InitializeComponent();
        }

        #endregion

        #region public MaintenanceComplainceForm(Aircraft currentAircraft, MaintenanceCheckGroupByType complianceGroup) : this()
        /// <summary>
        /// Создает форму для редактирования записей о выполнении группы чеков
        /// </summary>
        /// <param name="currentAircraft">ВС, которому пренадлежит группа чеков</param>
        /// <param name="complianceGroup">Группа чеков для редактирования</param>
        public MaintenanceComplainceForm(Aircraft currentAircraft, MaintenanceCheckGroupByType complianceGroup) : this()
        {
            if (currentAircraft == null)
                throw new ArgumentNullException("currentAircraft", "must be not null");
            if (complianceGroup == null)
                throw new ArgumentNullException("complianceGroup", "must be not null");
            
            _currentAircraft = currentAircraft;

            _numGroup = complianceGroup.GroupComplianceNum;

            _performances = complianceGroup.Checks
                .SelectMany(c => c.NextPerformances.OfType<MaintenanceNextPerformance>()
                                                    .Where(np => np.PerformanceGroupNum == _numGroup))
                .ToList();
            textBoxCheckName.Text = _performances.Count > 0
                ? _performances[0].PerformanceGroup.GetGroupName()
                : "";
            
            _currentChecks = complianceGroup.Checks;

            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoadForChecks;
            _animatedThreadWorker.RunWorkerCompleted += AnimatedThreadWorkerDoLoadForChecksCompleted;

        }
        #endregion

        #region public MaintenanceComplainceForm(Aircraft currentAircraft, NextPerformance nextPerformance) : this()

        /// <summary>
        /// Создает форму для редактирования записей о выполнении чека
        /// </summary>
        /// <param name="currentAircraft">ВС, которому пренадлежит чек</param>
        /// <param name="nextPerformance">Выполнение чека</param>
        public MaintenanceComplainceForm(Aircraft currentAircraft, NextPerformance nextPerformance)
            : this()
        {
            if (currentAircraft == null)
                throw new ArgumentNullException("currentAircraft", "must be not null");
            if (nextPerformance == null)
                throw new ArgumentNullException("nextPerformance", "must be not null");

            _currentAircraft = currentAircraft;

            _numGroup = nextPerformance.PerformanceNum;

            _currentChecks = new List<MaintenanceCheck> { nextPerformance.Parent as MaintenanceCheck };

            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoadForChecks;
            _animatedThreadWorker.RunWorkerCompleted += AnimatedThreadWorkerDoLoadForChecksCompleted;

        }
        #endregion

        #region public MaintenanceComplainceForm(Aircraft currentAircraft, NextPerformance nextPerformance) : this()

        /// <summary>
        /// Создает форму для редактирования записей о выполнении чеков
        /// </summary>
        /// <param name="currentAircraft">ВС, которому пренадлежит группа чеков</param>
        /// <param name="performanceRecords">Записи о выполнении группы чеков</param>
        public MaintenanceComplainceForm(Aircraft currentAircraft, List<MaintenanceCheckRecord> performanceRecords)
            : this()
        {
            if (currentAircraft == null)
                throw new ArgumentNullException("currentAircraft", "must be not null");
            if (performanceRecords == null)
                throw new ArgumentNullException("performanceRecords", "must be not null");

            _currentAircraft = currentAircraft;

            _numGroup = performanceRecords[0].NumGroup;

            _compliance = performanceRecords;
            
            _isEdit = true;

            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoadForRecords;
            _animatedThreadWorker.RunWorkerCompleted += AnimatedThreadWorkerDoLoadForRecordsCompleted;
        }
        #endregion

        #endregion

        #region Metods

        #region private void AnimatedThreadWorkerDoLoadForChecksCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void AnimatedThreadWorkerDoLoadForChecksCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dateTimePicker1.ValueChanged -= DateTimePicker1ValueChanged;

            dateTimePicker1.Value = DateTime.Today;
            lifelengthViewer_LastCompliance.Lifelength =
                GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(_currentAircraft, dateTimePicker1.Value);

            labelControlPoint.Visible =
            checkBoxControlPoint.Visible =
                _currentChecks.FirstOrDefault(c => !c.Grouping &&
                                                   c.CheckType.Priority > 0 &&
                                                   _currentAircraft.MSG >= MSG.MSG3) != null;
            checkBoxControlPoint.Checked = false;
            dateTimePicker1.ValueChanged += DateTimePicker1ValueChanged;   
    
        }
        #endregion

        #region private void AnimatedThreadWorkerDoLoadForChecks(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoLoadForChecks(object sender, DoWorkEventArgs e)
        {
            _animatedThreadWorker.ReportProgress(0, "Show Items");
   
            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            //Очистка панели от контролов
            Invoke(new Action(() => flowLayoutPanelContainer.Controls.Clear()));
            Thread.Sleep(200);

            if (_currentChecks.Count == 0)
            {
                return;
            }

            //подсчет кол-ва элементов
            int itemsCount = 0;
            int showedItems = 0;
            foreach (MaintenanceCheck check in _currentChecks)
            {
                //Добавление самого чека как элемента
                itemsCount += 1;
                //Добавление привязанных задач
                itemsCount += check.BindMpds.Count;
            }

            foreach (MaintenanceCheck check in _currentChecks)
            {
                _animatedThreadWorker.ReportProgress(showedItems / itemsCount, "Item showed");

                IAsyncResult asyncResult = BeginInvoke(new Action<MaintenanceCheck>(AddComplianceItem), check);
                while (!asyncResult.IsCompleted)
                {
                    Thread.Sleep(200);

                    if (_animatedThreadWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                showedItems += (check.BindMpds.Count + 1);
            }

            _animatedThreadWorker.ReportProgress(100, "Complete");
        }
        #endregion

        #region private void AnimatedThreadWorkerDoLoadForRecordsCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void AnimatedThreadWorkerDoLoadForRecordsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(_compliance == null || _compliance.Count == 0)
                return;

            dateTimePicker1.ValueChanged -= DateTimePicker1ValueChanged;

            lifelengthViewer_LastCompliance.Lifelength = _compliance[0].OnLifelength;
            dateTimePicker1.Value = _compliance[0].RecordDate;
            textBox_Remarks.Text = _compliance[0].Remarks;

            labelControlPoint.Visible =
            checkBoxControlPoint.Visible =
                _compliance.Where(r => r.ParentCheck != null)
                           .Select(r => r.ParentCheck)
                           .FirstOrDefault(c => !c.Grouping &&
                                                c.CheckType.Priority > 0 &&
                                                _currentAircraft.MSG >= MSG.MSG3)
                           != null;
            checkBoxControlPoint.Checked = _compliance.Any(r => r.IsControlPoint);
            textBoxCheckName.Text = _compliance.Any(r => !string.IsNullOrEmpty(r.ComplianceCheckName))
                ? _compliance.FirstOrDefault(r => !string.IsNullOrEmpty(r.ComplianceCheckName)).ComplianceCheckName
                : "";

            dateTimePicker1.ValueChanged += DateTimePicker1ValueChanged;

        }
        #endregion

        #region private void AnimatedThreadWorkerDoLoadForRecords(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoLoadForRecords(object sender, DoWorkEventArgs e)
        {
            _animatedThreadWorker.ReportProgress(0, "Show Items");

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            //Очистка панели от контролов
            Invoke(new Action(() => flowLayoutPanelContainer.Controls.Clear()));
            Thread.Sleep(200);

            if (_compliance.Count == 0 || 
                _compliance.Count(c=>c.ParentCheck != null) == 0)
            {
                return;
            }

            //подсчет кол-ва элементов
            int itemsCount = 0;
            int showedItems = 0;
            foreach (MaintenanceCheckRecord compliance in _compliance)
            {
                if(compliance.ParentCheck == null)
                    continue;
                //Добавление самого чека как элемента
                itemsCount += 1;
                //Добавление привязанных задач
                itemsCount += compliance.ParentCheck.BindMpds.Count;
            }
            foreach (MaintenanceCheckRecord compliance in _compliance)
            {
                _animatedThreadWorker.ReportProgress(showedItems / itemsCount, "Item showed");

                IAsyncResult asyncResult = BeginInvoke(new Action<MaintenanceCheckRecord>(AddComplianceItem), compliance);
                while (!asyncResult.IsCompleted)
                {
                    Thread.Sleep(200);

                    if (_animatedThreadWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                if(compliance.ParentCheck != null)
                    showedItems += (compliance.ParentCheck.BindMpds.Count + 1);
            }

            _animatedThreadWorker.ReportProgress(100, "Complete");
        }
        #endregion

        #region private void BackgroundWorkerRunWorkerSaveCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void BackgroundWorkerRunWorkerSaveCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region private void AnimatedThreadWorkerDoSave(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoSave(object sender, DoWorkEventArgs e)
        {
            _animatedThreadWorker.ReportProgress(0, "Saving");

            Save();

            _animatedThreadWorker.ReportProgress(100, "Saving Complete");
        }
        #endregion

        #region private void AddComplianceItem(MaintenanceCheck forCheck)
        private void AddComplianceItem(MaintenanceCheck forCheck)
        {
            CompliancePDFItem pdFitem = new CompliancePDFItem(forCheck);
            flowLayoutPanelContainer.Controls.Add(pdFitem);

            pdFitem.AutoSize = true;
            pdFitem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        #endregion

        #region private void AddComplianceItem(MaintenanceCheckRecord forCheckRecord)
        private void AddComplianceItem(MaintenanceCheckRecord forCheckRecord)
        {
            CompliancePDFItem pdFitem = new CompliancePDFItem(forCheckRecord);
            flowLayoutPanelContainer.Controls.Add(pdFitem);

            pdFitem.AutoSize = true;
            pdFitem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        #endregion

        #region public void Save()
        ///<summary>
        ///</summary>
        public void Save()
        {
            foreach (CompliancePDFItem pdFitem in flowLayoutPanelContainer.Controls)
            {
                pdFitem.ApplyChanges();

                MaintenanceCheckRecord lastPerformance;

                if (_isEdit == false)
                {
                    lastPerformance = new MaintenanceCheckRecord { ParentCheck = pdFitem.Check };
                    if (pdFitem.Check.Grouping)
                    {
                        MaintenanceNextPerformance mnp =
                            _performances.FirstOrDefault(p => p.Parent != null && p.Parent.ItemId == pdFitem.Check.ItemId);
                        lastPerformance.PerformanceNum = mnp != null ? mnp.PerformanceNum : _numGroup;
                    }
                    else
                    {
                        lastPerformance.PerformanceNum = _numGroup;
                    }
                    lastPerformance.NumGroup = _numGroup;
                    lastPerformance.CalculatedPerformanceSource = 
                        lastPerformance.ParentCheck.Interval * lastPerformance.PerformanceNum;
                }
                else
                {
                    lastPerformance = pdFitem.Record;
                }

                lastPerformance.AttachedFile = pdFitem.AttachedFile;
                lastPerformance.ComplianceCheckName = textBoxCheckName.Text.Trim();
                lastPerformance.RecordDate = dateTimePicker1.Value;
                lastPerformance.OnLifelength = lifelengthViewer_LastCompliance.Lifelength;
                lastPerformance.IsControlPoint = checkBoxControlPoint.Checked;
                lastPerformance.Remarks = textBox_Remarks.Text.Trim();

                try
                {
                    GlobalObjects.PerformanceCore.RegisterPerformance(pdFitem.Check, lastPerformance);

                    IEnumerable<DirectiveRecord> bindedDirectivesRecord = pdFitem.BindDirectivesRecords;
                    foreach (DirectiveRecord record in bindedDirectivesRecord)
                    {
                        if(record.ItemId > 0 && record.IsDeleted)
                            GlobalObjects.PerformanceCore.Delete(record);
                        else
                        {
                            record.MaintenanceCheckRecordId = lastPerformance.ItemId;
                            record.OnLifelength = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(_currentAircraft, record.RecordDate);
                            record.Remarks = string.IsNullOrEmpty(lastPerformance.Remarks)
                                                 ? "This performance added by " + pdFitem.Check.Name + " on " +
                                                   UsefulMethods.NormalizeDate(lastPerformance.RecordDate)
                                                 : lastPerformance.Remarks;

                            GlobalObjects.CasEnvironment.Manipulator.Save(record, false);    
                        }
                    }
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while save performance for maintenance check", ex);

                    break;
                }
            }
        }
        #endregion

        #region private void ResetAnimatedThreadWorkerEvents()
        /// <summary>
        /// Отписывает фоновый поток от подписчиков на события
        /// </summary>
        private void ResetAnimatedThreadWorkerEvents()
        {
            _animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoLoadForChecks;
            _animatedThreadWorker.RunWorkerCompleted -= AnimatedThreadWorkerDoLoadForChecksCompleted;
            _animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoLoadForRecords;
            _animatedThreadWorker.RunWorkerCompleted -= AnimatedThreadWorkerDoLoadForRecordsCompleted;
            _animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoSave;
            _animatedThreadWorker.RunWorkerCompleted -= BackgroundWorkerRunWorkerSaveCompleted;
                
        }
        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)

        private void ButtonOkClick(object sender, EventArgs e)
        {
            ResetAnimatedThreadWorkerEvents();

            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoSave;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerSaveCompleted;

            _animatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void DateTimePicker1ValueChanged(object sender, EventArgs e)
        private void DateTimePicker1ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.ValueChanged -= DateTimePicker1ValueChanged;

            if (dateTimePicker1.Value < DateTimeExtend.GetCASMinDateTime())
                dateTimePicker1.Value = DateTimeExtend.GetCASMinDateTime();
            if (dateTimePicker1.Value > DateTime.Now)
                dateTimePicker1.Value = DateTime.Now;

            lifelengthViewer_LastCompliance.Lifelength =
                GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(_currentAircraft, dateTimePicker1.Value);

            foreach (CompliancePDFItem pdFitem in flowLayoutPanelContainer.Controls.OfType<CompliancePDFItem>())
            {
                pdFitem.ComplianceDate = dateTimePicker1.Value;
            }

            dateTimePicker1.ValueChanged += DateTimePicker1ValueChanged;
        }
        #endregion

        #region private void MaintenanceComplianceFormLoad(object sender, EventArgs e)
        private void MaintenanceComplianceFormLoad(object sender, EventArgs e)
        {
            try
            {
                _animatedThreadWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building control", ex);
                return;
            }
        }
        #endregion

        #region private void MaintenanceComplainceFormFormClosing(object sender, FormClosingEventArgs e)
        private void MaintenanceComplainceFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if(_animatedThreadWorker != null && _animatedThreadWorker.IsBusy)
                _animatedThreadWorker.CancelAsync();
        }
        #endregion

        #region private void MaintenanceComplainceFormDeactivate(object sender, EventArgs e)

        private void MaintenanceComplainceFormDeactivate(object sender, EventArgs e)
        {
            StaticWaitFormProvider.WaitForm.Visible = false;
        }
        #endregion

        #region private void MaintenanceComplainceFormActivated(object sender, EventArgs e)
        private void MaintenanceComplainceFormActivated(object sender, EventArgs e)
        {
            if (StaticWaitFormProvider.IsActive)
                StaticWaitFormProvider.WaitForm.Visible = true;
        }
        #endregion

        #endregion
    }
}
