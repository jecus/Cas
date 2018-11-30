using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Events;
using CASReports.Builders;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using TempUIExtentions;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class OutOfPhaseReferenceScreen : ScreenControl
    {

        #region Fields

        private bool _needReload;

        private DirectiveType _directiveType;

        private Directive _currentOutOfPhase;
        private BaseComponent _currentBaseComponent;
        private ContextMenuStrip _buttonPrintMenuStrip;
        private ToolStripMenuItem _itemPrintReportRecords;
        private ToolStripMenuItem _itemPrintReportHistory;
        
        #endregion

        #region Constructors

        #region public OutOffPhaseReferenceScreen()
        ///<summary>
        ///</summary>
        public OutOfPhaseReferenceScreen()
        {
            InitializeComponent();
        }
        
        #endregion

        #region public OutOfPhaseReferenceScreen(BaseSmartCoreObject directiveContainer)
        ///<summary>
        /// Создается объект, описывающий отображение добавления директивы
        ///</summary>
        /// <param name="directiveContainer">Родительский объект, в который добавляется директива</param>
        public OutOfPhaseReferenceScreen(BaseEntityObject directiveContainer)
            : this()
        {
            if (directiveContainer == null) throw new ArgumentNullException("directiveContainer");

            _directiveType = DirectiveType.OutOfPhase;

            if (directiveContainer is BaseComponent)
            {
                var baseComponent = (BaseComponent) directiveContainer;
                _currentBaseComponent = baseComponent;
                _currentOutOfPhase = new Directive { ParentBaseComponent = baseComponent, DirectiveType = _directiveType };
            }
            else
            {
	            var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(((Aircraft) directiveContainer).AircraftFrameId);
                _currentOutOfPhase = new Directive { ParentBaseComponent = aircraftFrame, DirectiveType = _directiveType };
            }
            Initialize();
        }

        #endregion

        #region public OutOffPhaseReferenceScreen(Directive outOfPhase) : this()
        ///<summary>
        /// Создает страницу для отображения информации об одной директиве
        ///</summary>
        /// <param name="outOfPhase">Директива</param>
        public OutOfPhaseReferenceScreen(Directive outOfPhase) : this()
        {
            if (outOfPhase == null)
                throw new ArgumentNullException("outOfPhase", "Argument cannot be null");

            _directiveType = outOfPhase.DirectiveType;
            _currentOutOfPhase = outOfPhase;

            Initialize();
        }

        #endregion
        
        #endregion

        #region Methods

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
            if (_currentOutOfPhase.ParentBaseComponent != null)
            {
				var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentOutOfPhase.ParentBaseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
	            var parentStore = GlobalObjects.StoreCore.GetStoreById(_currentOutOfPhase.ParentBaseComponent.ParentStoreId);

				if (parentAircraft != null)
                    CurrentAircraft = parentAircraft;
				else if (parentStore != null)
                    CurrentStore = parentStore;
			}

            //обновление суммарной информацию по директиве и суммарную информацию по её подзадачам
            StatusTitle = "Out of phase Status";

            if (_currentOutOfPhase.ItemId <= 0)
            {
                _outOfPhaseSummary.Visible = false;
                _outOfPhaseReferenceGeneralInformation.Visible = true;
                _performanceControl.Visible = true;
            }
            else
            {
                _outOfPhaseSummary.Visible = true;
                _outOfPhaseReferenceGeneralInformation.Visible = false;
                _performanceControl.Visible = false;
            }
        }
        #endregion

        #region public override void DisposeScreen()
        public override void DisposeScreen()
        {
            CancelAsync();

            if (AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.CancelAsync();
            AnimatedThreadWorker.Dispose();

            _currentOutOfPhase = null;

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AnimatedThreadWorker.CancellationPending)
                return;
            if (_currentOutOfPhase == null)
                return;
            if (_currentOutOfPhase.ItemId <= 0)
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

            statusControl.ConditionState = _currentOutOfPhase.Condition;

            extendableRichContainerSummary.LabelCaption.Text = "Summary " + _currentOutOfPhase.Title
                                                           + " Status: " + _currentOutOfPhase.Status;

            _outOfPhaseSummary.CurrentOutOfPhase = _currentOutOfPhase;
            //обновление главной информацию по директиве
            _outOfPhaseReferenceGeneralInformation.CurrentOutOfPhaseItem = _currentOutOfPhase;
            //обновление информации подзадач директивы
            _performanceControl.CurrentDirective = _currentOutOfPhase;
            //обновление информации об выполнении директивы
            _complianceControl.CurrentDirective = _currentOutOfPhase;
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            #region Загрузка элементов

            AnimatedThreadWorker.ReportProgress(0, "load directives");

            try
            {
                if (_currentOutOfPhase.ItemId > 0 && _needReload)
                {
                    _currentOutOfPhase = GlobalObjects.DirectiveCore.GetDirectiveById(_currentOutOfPhase.ItemId, _currentOutOfPhase.DirectiveType);
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

            if (_needReload)
            {
                GlobalObjects.PerformanceCalculator.GetNextPerformance(_currentOutOfPhase);
            }

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

            if (_complianceControl != null)
            {
                _complianceControl.CalcelAsync();
            }
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

        #region private bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool ValidateData(out string message)
        {
            if (!_outOfPhaseReferenceGeneralInformation.ValidateData(out message))
            {
                return false;
            }
            if (!_performanceControl.ValidateData(out message))
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
            if (_outOfPhaseReferenceGeneralInformation.GetChangeStatus(_currentOutOfPhase.ItemId > 0) || _performanceControl.GetChangeStatus())
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
        private bool SaveData(bool changePageTitle = true)
        {
            //Не менять функции местами - сбивается Threshold
            _performanceControl.ApplyChanges(_currentOutOfPhase);
            _outOfPhaseReferenceGeneralInformation.ApplyChanges(_currentOutOfPhase, changePageTitle);

            try
            {
                GlobalObjects.DirectiveCore.Save(_currentOutOfPhase);
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
            _outOfPhaseReferenceGeneralInformation.ClearFields();
            _performanceControl.ClearFields();
        }
        #endregion

        #region private void SetFieldsUnsaved()
        /// <summary>
        /// Проставляет всем сохраняемым объектам id = -1
        /// </summary>
        private void SetFieldsUnsaved()
        {
            _outOfPhaseReferenceGeneralInformation.SetFieldsUnsaved();
        }
        #endregion

        #region private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)

        private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)
        {
            _outOfPhaseSummary.Visible = !_outOfPhaseSummary.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)

        private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)
        {
            _outOfPhaseReferenceGeneralInformation.Visible =
                !_outOfPhaseReferenceGeneralInformation.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)

        private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)
        {
            _performanceControl.Visible = !_performanceControl.Visible;
        }
        #endregion

        #region private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
			if (_currentOutOfPhase.ParentBaseComponent.ParentAircraftId == 0) return;
            if (sender == _itemPrintReportRecords)
            {
                var caption = _currentOutOfPhase.ParentBaseComponent.GetParentAircraftRegNumber() + ". " + _currentOutOfPhase.DirectiveType.CommonName + ". " +
                _currentOutOfPhase.Title + ". Compliance List";
                var builder = new DirectiveTasksReportBuilder();
                if (_currentBaseComponent == null)
                {
                    builder.ReportedAircraft = CurrentAircraft;
                    builder.ReportTitle = "OUT OF PHASE RECORD";
                    builder.FilterSelection = "All";
                }
                else
                {
                    builder.ReportedBaseComponent = _currentBaseComponent;
                    String selection = "";
                    if (_currentBaseComponent.BaseComponentType == BaseComponentType.LandingGear)
                    {
                        selection = _currentBaseComponent.TransferRecords.GetLast().Position;
                        builder.ReportTitle = "LANDING GEAR RECORD";
                    }
                    if (_currentBaseComponent.BaseComponentType == BaseComponentType.Engine)
                    {
                        selection = BaseComponentType.Engine + " " + _currentBaseComponent.TransferRecords.GetLast().Position;
                        builder.ReportTitle = "ENGINE RECORD";
                    }
                    if (_currentBaseComponent.BaseComponentType == BaseComponentType.Apu)
                    {
                        selection = BaseComponentType.Apu.ToString();
                        builder.ReportTitle = "APU RECORD";
                    }
                    builder.LifelengthAircraftSinceNew =
                        GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
                    builder.FilterSelection = selection;
                }

                builder.AddDirectives(new [] { _currentOutOfPhase });
                builder.ForecastData = null;
                e.DisplayerText = caption;
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.RequestedEntity = new ReportScreen(builder);
            }
        }

        #endregion

        #region  private void ComplianceControlComplianceAdded(object sender, EventArgs e)
        private void ComplianceControlComplianceAdded(object sender, EventArgs e)
        {
            CancelAsync();
            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void HeaderControl1ReloadRised(object sender, EventArgs e)

        private void HeaderControl1ReloadRised(object sender, EventArgs e)
        {
            if (_outOfPhaseReferenceGeneralInformation.GetChangeStatus(true) || _performanceControl.GetChangeStatus())
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.YesNo,
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
                if (SaveData())
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
                SaveData(false);
            }

            if (MessageBox.Show("Directive added successfully" + "\nClear Fields before add new directive?",
                                       new GlobalTermsProvider()["SystemName"].ToString(),
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ClearFields();
            }
            else
            {
                SetFieldsUnsaved();
            }

            BaseComponent bd = _currentOutOfPhase.ParentBaseComponent;
            _currentOutOfPhase = new Directive { ParentBaseComponent = bd, DirectiveType = _directiveType };
        }

        #endregion

        #region private void FlightDateRouteControl1FlightDateChanget(Auxiliary.Events.DateChangedEventArgs e)

        private void FlightDateRouteControl1FlightDateChanget(DateChangedEventArgs e)
        {
            _performanceControl.EffectiveDate = e.Date;
        }
        #endregion

        #endregion

    }
}
