using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EFCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Quality;

namespace CAS.UI.UIControls.JobCardControls
{
    ///<summary>
    ///</summary>
    public partial class JobCardScreen : ScreenControl
    {
        #region Fields

        private bool _needReload;
        private JobCard _currentItem;
        private ContextMenuStrip _buttonPrintMenuStrip;
        private ToolStripMenuItem _itemPrintReportRecords;
        private ToolStripMenuItem _itemPrintReportHistory;

        #endregion

        #region Constructors

        #region private JobCardScreen()
        ///<summary>
        ///</summary>
        private JobCardScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public JobCardScreen(Aircraft aircraft) : this ()

        ///<summary>
        /// Создает страницу для отображения информации об одной директиве
        ///</summary>
        /// <param name="operator">Директива</param>
        public JobCardScreen(Operator @operator)
            : this()
        {
            if (@operator == null)
                throw new ArgumentNullException("operator", "Argument cannot be null");

            aircraftHeaderControl1.Operator = @operator;

            _currentItem = new JobCard();

            Initialize();
        }

        #endregion

        #region public JobCardScreen(MaintenanceDirective parent) : this ()

        ///<summary>
        /// Создает страницу для отображения информации об одной директиве
        ///</summary>
        /// <param name="parent">Директива</param>
        public JobCardScreen(MaintenanceDirective parent)
            : this()
        {
            if (parent == null)
                throw new ArgumentNullException("parent", "Argument cannot be null");

            CurrentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(parent.ParentBaseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь

			_currentItem = new JobCard {Parent = parent};

            Initialize();
        }

        #endregion

        #region public JobCardScreen(Directive parent) : this ()

        ///<summary>
        /// Создает страницу для отображения информации об одной директиве
        ///</summary>
        /// <param name="parent">Директива</param>
        public JobCardScreen(Directive parent)
            : this()
        {
            if (parent == null)
                throw new ArgumentNullException("parent", "Argument cannot be null");

            CurrentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(parent.ParentBaseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь

			_currentItem = new JobCard { Parent = parent };

            Initialize();
        }

        #endregion

        #region public JobCardScreen(Procedure parent) : this ()

        ///<summary>
        /// Создает страницу для отображения информации об одной директиве
        ///</summary>
        /// <param name="parent">Директива</param>
        public JobCardScreen(Procedure parent)
            : this()
        {
            if (parent == null)
                throw new ArgumentNullException("parent", "Argument cannot be null");

            aircraftHeaderControl1.Operator = parent.ParentOperator;

            _currentItem = new JobCard { Parent = parent };

            Initialize();
        }

        #endregion

        #region public JobCardScreen(JobCard jobCard) : this ()

        ///<summary>
        /// Создает страницу для отображения информации об одной директиве
        ///</summary>
        /// <param name="jobCard">Директива</param>
        public JobCardScreen(JobCard jobCard)
            : this()
        {
            if (jobCard == null)
                throw new ArgumentNullException("jobCard", "Argument cannot be null");

            _currentItem = jobCard;

            if (_currentItem.Parent != null)
                CurrentAircraft = GlobalObjects.AircraftsCore.GetParentAircraft(_currentItem.Parent);
            else aircraftHeaderControl1.Operator = GlobalObjects.CasEnvironment.Operators[0];
           
            Initialize();
        }

        #endregion

        #endregion

        #region Properties

        #endregion

        #region Methods

        #region public override void DisposeScreen()
        public override void DisposeScreen()
        {
            CancelAsync();

            AnimatedThreadWorker.Dispose();

            if (_itemPrintReportHistory != null) _itemPrintReportHistory.Dispose();
            if (_itemPrintReportRecords != null) _itemPrintReportRecords.Dispose();
            if (_buttonPrintMenuStrip != null) _buttonPrintMenuStrip.Dispose();

            _currentItem = null;

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AnimatedThreadWorker.CancellationPending)
                return;
            if(_currentItem == null)
                return;
            if(_currentItem.ItemId <= 0)
            {
                headerControl.ShowReloadButton = false;
                headerControl.ShowPrintButton = false;
                headerControl.ShowSaveButton2 = true;
                headerControl.SaveButtonToolTipText = "Save and Edit";
            }
            else
            {
                headerControl.ShowReloadButton = true;
                headerControl.ShowPrintButton = true;
                headerControl.ShowSaveButton2 = false;
                headerControl.SaveButtonToolTipText = "Save";
            }

            statusControl.ConditionState = ConditionState.Satisfactory;// GlobalObjects.CasEnvironment.Calculator.GetConditionState(_currentItem);

            //extendableRichContainerSummary.LabelCaption.Text = "Summary " + _currentDirective.TaskNumberCheck
            //                                               + " Status: " + _currentDirective.Status;

            jobCardControl.CurrentDirective = _currentItem;
            //обновление главной информацию по директиве
            //_directiveGeneralInformation.CurrentItem = _currentItem;
            //обновление информации подзадач директивы
            //DocumentsControl.CurrentItem = _currentItem;
            //обновление информации подзадач директивы
            //CategoriesControl.CurrentItem = _currentItem;
            ////обновление информации об выполнении директивы
            //complianceControl.cu = _currentItem;
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            #region Загрузка элементов

            AnimatedThreadWorker.ReportProgress(0, "load directives");

            try
            {
                if (_currentItem.ItemId > 0 && _needReload)
                {
                    _currentItem = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<JobCardDTO,JobCard>(_currentItem.ItemId, true);
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading directives", ex);
            }

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            #region Калькуляция состояния директив

            AnimatedThreadWorker.ReportProgress(40, "calculation of directives");

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            #region Фильтрация директив
            AnimatedThreadWorker.ReportProgress(70, "filter directives");

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            #region Сравнение с рабочими пакетами

            AnimatedThreadWorker.ReportProgress(90, "comparison with the Work Packages");

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            AnimatedThreadWorker.ReportProgress(100, "Complete");
        }
        #endregion

        #region protected override void CancelAsync()
        /// <summary>
        /// Проверяет, выполняет ли AnimatedThreadWorker задачу, и производит отмену выполнения
        /// </summary>
        protected override void CancelAsync()
        {
            if (AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.CancelAsync();

            //if (jobCardControl != null)
            //{
            //    jobCardControl.CancelAsync();
            //}

            //if (_complianceControl != null)
            //{
            //    _complianceControl.CalcelAsync();
            //}
        }
        #endregion

        #region public override void OnInitCompletion(object sender)
        /// <summary>
        /// Метод, вызывается после добавления содежимого на отображатель(вкладку)
        /// </summary>
        /// <returns></returns>
        public override void OnInitCompletion(object sender)
        {
            AnimatedThreadWorker.RunWorkerAsync();

            base.OnInitCompletion(sender);
        }
        #endregion

        #region private void Initialize()
        /// <summary>
        /// Производит дополнительную инициализацию
        /// </summary>
        private void Initialize()
        {
            _needReload = false;

            #region ButtonPrintContextMenu

            _buttonPrintMenuStrip = new ContextMenuStrip();
            _itemPrintReportRecords = new ToolStripMenuItem { Text = "Records" };
            _itemPrintReportHistory = new ToolStripMenuItem { Text = "Compliance history" };
            _buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { _itemPrintReportRecords, _itemPrintReportHistory });

            ButtonPrintMenuStrip = _buttonPrintMenuStrip;
            
            #endregion

            //обновление нижней шапки(через базовый скрин)
            //if (_currentItem.ParentBaseDetail != null)
            //{
            //    if (_currentItem.ParentBaseDetail.ParentAircraft != null)
            //        CurrentAircraft = _currentItem.ParentBaseDetail.ParentAircraft;
            //    else if (_currentItem.ParentBaseDetail.ParentStore != null)
            //        CurrentStore = _currentItem.ParentBaseDetail.ParentStore;
            //}

            //обновление суммарной информацию по директиве и суммарную информацию по её подзадачам
            StatusTitle = "Job Card Status";

            if (_currentItem.ItemId <= 0)
            {
                //_directiveSummary.Visible = false;
                jobCardControl.Visible = true;
                //DocumentsControl.Visible = true;
            }
            else
            {
                //_directiveSummary.Visible = true;
                //jobCardControl.Visible = false;
                //DocumentsControl.Visible = false;
            }
        }
        #endregion

        #region private bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool ValidateData(out string message)
        {
            if (!jobCardControl.ValidateData(out message))
            {
                return false;
            }
            return true;
        }

        #endregion

        #region private bool GetchangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool GetChangeStatus()
        {
            if (jobCardControl.GetChangeStatus(_currentItem.ItemId > 0))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region private bool SaveData()
        /// <summary>
        /// Сохранение измененных данных в редактируемом элементе
        /// </summary>
        private bool SaveData()
        {
            //Не менять функции местами - сбивается Threshold
            jobCardControl.ApplyChanges();
            //_directiveGeneralInformation.ApplyChanges();
            //CategoriesControl.ApplyChanges();

            try
            {
                GlobalObjects.CasEnvironment.Manipulator.Save(_currentItem);

                foreach (JobCardTask categoryRecord in _currentItem.JobCardTasks)
                {
                    categoryRecord.JobCard = _currentItem;
                    GlobalObjects.CasEnvironment.Manipulator.Save(categoryRecord);
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return false;
            }
            return true;
        }

        #endregion

        #region private void ClearFields()

        private void ClearFields()
        {
            jobCardControl.ClearFields();
            //DocumentsControl.ClearFields();
            //CategoriesControl.ClearFields();
        }
        #endregion

        #region private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //BaseDetail baseDetail = _currentItem.ParentBaseDetail;
            //if (baseDetail == null)
            //    return;

            //if (sender == _itemPrintReportRecords)
            //{
            //    string caption = "";
            //    if (baseDetail.ParentAircraft != null)
            //        caption = baseDetail.ParentAircraft.RegistrationNumber + ". ";
            //    else if (baseDetail.ParentStore != null)
            //        caption = baseDetail.ParentStore.Name + ". ";
            //    caption += _currentDirective.WorkType + ". " + _currentDirective.MPDTaskNumber + ". Compliance List";

            //    DirectiveTasksReportBuilder builder = new DirectiveTasksReportBuilder();
            //    builder.ReportedBaseDetail = baseDetail;
            //    String selection = "";
            //    if (baseDetail.BaseDetailType == BaseDetailType.LandingGear)
            //    {
            //        selection = baseDetail.TransferRecords.GetLast().Position;
            //        builder.ReportTitle = "LANDING GEAR RECORD";
            //    }
            //    if (baseDetail.BaseDetailType == BaseDetailType.Engine)
            //    {
            //        selection = BaseDetailType.Engine + " " + baseDetail.TransferRecords.GetLast().Position;
            //        builder.ReportTitle = "ENGINE RECORD";
            //    }
            //    if (baseDetail.BaseDetailType == BaseDetailType.Apu)
            //    {
            //        selection = BaseDetailType.Apu.ToString();
            //        builder.ReportTitle = "APU RECORD";
            //    }
            //    builder.LifelengthAircraftSinceNew =
            //        GlobalObjects.CasEnvironment.Calculator.GetClosingFlightLifelength(CurrentAircraft, DateTime.Today);
            //    builder.FilterSelection = selection;
            //    builder.AddDirectives(new [] { _currentDirective });
            //    builder.ForecastData = null;
            //    e.DisplayerText = caption;
            //    e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            //    e.RequestedEntity = new ReportScreen(builder);
            //}
            //else
            //{
                e.Cancel = true;
            //}
        }

        #endregion

        #region private void ComplianceControlComplianceAdded(object sender, EventArgs e)
        private void ComplianceControlComplianceAdded(object sender, EventArgs e)
        {
            CancelAsync();

            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void HeaderControl1ReloadRised(object sender, EventArgs e)

        private void HeaderControl1ReloadRised(object sender, EventArgs e)
        {
            if (jobCardControl.GetChangeStatus(true))
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    _needReload = true;

                    CancelAsync();
                    AnimatedThreadWorker.RunWorkerAsync();
                }
            }
            else
            {
                _needReload = true;

                CancelAsync();
                AnimatedThreadWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)

        //private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)
        //{
        //    _directiveSummary.Visible = !_directiveSummary.Visible;
        //}
        #endregion

        #region private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)

        //private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)
        //{
        //    _directiveGeneralInformation.Visible = !_directiveGeneralInformation.Visible;
        //}
        #endregion

        #region private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)

        //private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)
        //{
        //    DocumentsControl.Visible = !DocumentsControl.Visible;
        //}
        #endregion

        #region private void ExtendableRichContainerCategoriesExtending(object sender, EventArgs e)

        //private void ExtendableRichContainerCategoriesExtending(object sender, EventArgs e)
        //{
        //    CategoriesControl.Visible = !CategoriesControl.Visible;
        //}
        #endregion

        #region private void HeaderControlButtonSaveClick(object sender, EventArgs e)

        private void HeaderControlButtonSaveClick(object sender, EventArgs e)
        {
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GetChangeStatus())
            {
                if(SaveData())
                {
                    MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);

                    _needReload = false;

                    CancelAsync();
                    AnimatedThreadWorker.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("No changes. Nothing to save", "Message infomation", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        #endregion

        #region private void HeaderControlButtonSaveAndAddClick(object sender, EventArgs e)

        private void HeaderControlButtonSaveAndAddClick(object sender, EventArgs e)
        {
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GetChangeStatus())
            {
                SaveData();
            }

            if (MessageBox.Show("Directive added successfully" + "\nClear Fields before add new directive?",
                                       new GlobalTermsProvider()["SystemName"].ToString(),
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ClearFields();
            }
            //BaseDetail bd = _currentItem.ParentBaseDetail;
            _currentItem = new JobCard();
        }

        #endregion

        #region private void FlightDateRouteControl1FlightDateChanget(Auxiliary.Events.DateChangedEventArgs e)

        //private void FlightDateRouteControl1FlightDateChanget(DateChangedEventArgs e)
        //{
        //    _performanceControl.EffectiveDate = e.Date;
        //}
        #endregion

        #endregion
    }
}
