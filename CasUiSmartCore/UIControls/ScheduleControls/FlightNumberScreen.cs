using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EntityCore.DTO.Dictionaries;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls
{
    ///<summary>
    /// Экран для отображения рейса в системе расписания
    ///</summary>
    public partial class FlightNumberScreen : ScreenControl
    {
        #region Fields

        private FlightNumber _currentDirective;
	    private readonly FlightNumberScreenType _screenType;
	    private ContextMenuStrip _buttonPrintMenuStrip;
        private ToolStripMenuItem _itemPrintReportRecords;
        private ToolStripMenuItem _itemPrintReportHistory;
	    private List<SchedulePeriods> _schedulePeriods = new List<SchedulePeriods>();

	    #endregion

        #region Constructors

        #region public FlightNumberScreen()
        ///<summary>
        ///</summary>
        public FlightNumberScreen()
        {
            InitializeComponent();

            _currentDirective = new FlightNumber();

            Initialize();
        }
        #endregion

        #region public FlightNumberScreen(FlightNumber flightNumber) : this ()

	    /// <summary>
	    ///  Создает страницу для отображения информации об одном планируемом рейсе
	    /// </summary>
	    /// <param name="flightNumber">рейс</param>
	    /// <param name="screenType"></param>
	    public FlightNumberScreen(FlightNumber flightNumber, FlightNumberScreenType screenType)
            : this()
        {
            if (flightNumber == null)
                throw new ArgumentNullException("flightNumber", "Argument cannot be null");

            _currentDirective = flightNumber;
	        _screenType = screenType;

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

            _currentDirective = null;

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AnimatedThreadWorker.CancellationPending)
                return;
            if(_currentDirective == null)
                return;
            if(_currentDirective.ItemId <= 0)
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

            extendableRichContainerSummary.LabelCaption.Text = "Summary " + _currentDirective.FlightNo
                                                           + " Status: " + _currentDirective.Status;

            _directiveGeneralInformation.UpdateInformation(_currentDirective, _schedulePeriods, _screenType);
	        _flightNumberIPerformanceControl.UpdateInformation(_currentDirective);
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            #region Загрузка элементов

            AnimatedThreadWorker.ReportProgress(0, "load directives");

            try
            {
	            if (_currentDirective.ItemId > 0)
		            _currentDirective = GlobalObjects.AircraftFlightsCore.GetFlightNumberById(_currentDirective.ItemId, true);
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

	        _schedulePeriods.Clear();
			_schedulePeriods.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<SchedulePeriodDTO, SchedulePeriods>());

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

            #region ButtonPrintContextMenu

            _buttonPrintMenuStrip = new ContextMenuStrip();
            _itemPrintReportRecords = new ToolStripMenuItem { Text = "Records" };
            _itemPrintReportHistory = new ToolStripMenuItem { Text = "Compliance history" };
            _buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { _itemPrintReportRecords, _itemPrintReportHistory });

            ButtonPrintMenuStrip = _buttonPrintMenuStrip;
            
            #endregion

            //обновление нижней шапки(через базовый скрин)
            aircraftHeaderControl1.Operator = GlobalObjects.CasEnvironment.Operators[0]; 
            //обновление суммарной информацию по директиве и суммарную информацию по её подзадачам
            StatusTitle = "Flight schedule";  

        }
        #endregion

        #region private bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool ValidateData(out string message)
        {
            if (!_directiveGeneralInformation.ValidateData(out message) || !_flightNumberIPerformanceControl.ValidateData(out message))
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
            if (_directiveGeneralInformation.GetChangeStatus(_currentDirective) || _flightNumberIPerformanceControl.GetChangeStatus(_currentDirective))
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
	        _flightNumberIPerformanceControl.ApplyChanges(_currentDirective);
            _directiveGeneralInformation.ApplyChanges(_currentDirective);

			try
            {
                GlobalObjects.AircraftFlightsCore.Save(_currentDirective);
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
            _directiveGeneralInformation.ClearFields();
	        _flightNumberIPerformanceControl.ClearFields();
        }
        #endregion

        #region private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //BaseDetail baseDetail = _currentDirective.ParentBaseDetail;
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
            //    builder.AddDirectives(new object[] { _currentDirective });
            //    builder.ForecastData = null;
            //    e.DisplayerText = caption;
            //    e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            //    e.RequestedEntity = new ReportScreen(builder);
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }

        #endregion

        #region void ComplianceControlComplianceAdded(object sender, EventArgs e)
        void ComplianceControlComplianceAdded(object sender, EventArgs e)
        {
            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void HeaderControl1ReloadRised(object sender, EventArgs e)

        private void HeaderControl1ReloadRised(object sender, EventArgs e)
        {
            CancelAsync();

            if (_directiveGeneralInformation.GetChangeStatus(_currentDirective))
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    AnimatedThreadWorker.RunWorkerAsync();
                }
            }
            else
            {
                AnimatedThreadWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)

        private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)
        {
            //_directiveSummary.Visible = !_directiveSummary.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)

        private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)
        {
            _directiveGeneralInformation.Visible = !_directiveGeneralInformation.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)

        private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)
        {
	        _flightNumberIPerformanceControl.Visible = !_flightNumberIPerformanceControl.Visible;
        }
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

            if (MessageBox.Show("Flight added successfully" + "\nClear Fields before add new Flight?",
                                       new GlobalTermsProvider()["SystemName"].ToString(),
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ClearFields();
            }
            _currentDirective = new FlightNumber();
	        _directiveGeneralInformation.UpdatePeriodControl(_currentDirective);
		}

        #endregion

        #endregion
    }
}
