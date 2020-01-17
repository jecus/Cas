using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Helpers;
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

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    ///</summary>
    public partial class DirectiveScreen : ScreenControl
    {
        #region Fields

        private bool _needReload;

        private Directive _currentDirective;
        private BaseComponent _currentBaseComponent;
        private ContextMenuStrip buttonPrintMenuStrip;
        private ToolStripMenuItem itemPrintReportRecords;
        private ToolStripMenuItem itemPrintReportHistory;
        private DirectiveType _directiveType;
        #endregion

        #region Constructors

        #region public DirectiveScreen()
        ///<summary>
        ///</summary>
        public DirectiveScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public DirectiveScreen(BaseSmartCoreObject directiveContainer, PrimaryDirectiveType directiveType)
        ///<summary>
        /// Создается объект, описывающий отображение добавления директивы
        ///</summary>
        /// <param name="directiveContainer">Родительский объект, в который добавляется директива</param>
        /// <param name="directiveType">Тип директивы</param>
        public DirectiveScreen(BaseEntityObject directiveContainer, DirectiveType directiveType) : this()
        {
            if (directiveContainer == null) throw new ArgumentNullException("directiveContainer");

            _directiveType = directiveType;
            if (directiveContainer is BaseComponent)
            {
                var baseComponent = (BaseComponent) directiveContainer;
                _currentBaseComponent = baseComponent;
                _currentDirective = new Directive { ParentBaseComponent = baseComponent, DirectiveType = _directiveType};
            }
            else
            {
	            var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(((Aircraft) directiveContainer).AircraftFrameId);
                _currentDirective = new Directive { ParentBaseComponent = aircraftFrame, DirectiveType = _directiveType };
            }
            Initialize();
        }

        #endregion

        #region public DirectiveScreen(Directive directive) : this ()

        ///<summary>
        /// Создает страницу для отображения информации об одной директиве
        ///</summary>
        /// <param name="directive">Директива</param>
        public DirectiveScreen(Directive directive) : this ()
        {
            if (directive == null)
                throw new ArgumentNullException("directive", "Argument cannot be null");

            _currentDirective = directive;
            _directiveType = directive.DirectiveType;

            Initialize();
        }

        #endregion

        #endregion

        #region Properties

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

            buttonPrintMenuStrip = new ContextMenuStrip();
            itemPrintReportRecords = new ToolStripMenuItem { Text = "Records" };
            itemPrintReportHistory = new ToolStripMenuItem { Text = "Compliance history" };
            buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { itemPrintReportRecords, itemPrintReportHistory });

            ButtonPrintMenuStrip = buttonPrintMenuStrip;
            #endregion

            //обновление нижней шапки(через базовый скрин)
            if (_currentDirective.ParentBaseComponent != null)
            {
	            var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentDirective.ParentBaseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
	            var parentStore = GlobalObjects.StoreCore.GetStoreById(_currentDirective.ParentBaseComponent.ParentStoreId);

				if (parentAircraft != null)
                    CurrentAircraft = parentAircraft;
				else if (parentStore != null)
                    CurrentStore = parentStore;
			}

            //обновление суммарной информацию по директиве и суммарную информацию по её подзадачам
            if (_currentDirective.DirectiveType.Equals(DirectiveType.AirworthenessDirectives))
            {
                StatusTitle = "AD Status";
            }
            if (_currentDirective.DirectiveType.Equals(DirectiveType.SB))
            {
                StatusTitle = "SB Status";
            }
            if (_currentDirective.DirectiveType.Equals(DirectiveType.EngineeringOrders))
            {
                StatusTitle = "EO Status";
            }

            if (_currentDirective.ItemId <= 0)
            {
                _directiveSummary.Visible = false;
                _directiveGeneralInformation.Visible = true;
                _performanceControl.Visible = true;
            }
            else
            {
                _directiveSummary.Visible = true;
                _directiveGeneralInformation.Visible = false;
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

            _currentDirective = null;

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AnimatedThreadWorker.CancellationPending)
                return;
            if (_currentDirective == null)
                return;
            if (_currentDirective.ItemId <= 0)
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

            statusControl.ConditionState = _currentDirective.Condition;

            extendableRichContainerSummary.LabelCaption.Text = "Summary " + _currentDirective.Title
                                                           + " Status: " + _currentDirective.Status;

            _directiveSummary.CurrentDirective = _currentDirective;
            //обновление главной информацию по директиве
            _directiveGeneralInformation.CurrentDirective = _currentDirective;
            //обновление информации подзадач директивы
            _performanceControl.CurrentDirective = _currentDirective;
            //обновление информации об выполнении директивы
            _complianceControl.CurrentDirective = _currentDirective;
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
	        GlobalObjects.ComponentCore.ReloadActualStateRecordForBaseComponents(_currentDirective.ParentAircraftId);

            #region Загрузка элементов

            AnimatedThreadWorker.ReportProgress(0, "load directives");

            try
            {
                if (_currentDirective.ItemId > 0 && _needReload)
                {
                    _currentDirective = GlobalObjects.DirectiveCore.GetDirectiveById(_currentDirective.ItemId, _currentDirective.DirectiveType);
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


	        GlobalObjects.MTOPCalculator.CalculateDirectiveNew(_currentDirective);
	        
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
            if (!_directiveGeneralInformation.ValidateData(out message))
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
            if (_directiveGeneralInformation.GetChangeStatus(_currentDirective.ItemId > 0) || _performanceControl.GetChangeStatus())
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
            _performanceControl.ApplyChanges(_currentDirective);
            _directiveGeneralInformation.ApplyChanges(_currentDirective, changePageTitle);

            try
            {
                GlobalObjects.DirectiveCore.Save(_currentDirective);
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
            _performanceControl.ClearFields();
        }
        #endregion

        #region private void SetFieldsUnsaved()
        /// <summary>
        /// Проставляет всем сохраняемым объектам id = -1
        /// </summary>
        private void SetFieldsUnsaved()
        {
            _directiveGeneralInformation.SetFieldsUnsaved();
        }
        #endregion

        #region private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            var baseDetail = _currentDirective.ParentBaseComponent;
            if (baseDetail == null)
                return;

            if(sender == itemPrintReportRecords)
            {
				var caption = "";
                if (baseDetail.ParentAircraftId > 0)
                    caption = $"{DestinationHelper.GetDestinationStringFromAircraft(baseDetail.ParentAircraftId, false, null)}. ";
				else if(baseDetail.ParentStoreId > 0)
                    caption = $"{DestinationHelper.GetDestinationStringFromStore(baseDetail.ParentStoreId, null, true)}. ";

				caption += _currentDirective.DirectiveType.CommonName + ". " +
                           _currentDirective.Title + ". Compliance List";

                var builder = new DirectiveTasksReportBuilder();
                if (_currentBaseComponent == null)
                {
                    builder.ReportedAircraft = CurrentAircraft;

                    if (_currentDirective.DirectiveType == DirectiveType.AirworthenessDirectives)
                        builder.ReportTitle = "AD RECORD";
                    if (_currentDirective.DirectiveType == DirectiveType.EngineeringOrders)
                        builder.ReportTitle = "EO STATUS";
                    if (_currentDirective.DirectiveType == DirectiveType.SB)
                        builder.ReportTitle = "SB STATUS";
                 
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
                
                builder.AddDirectives(new[]{_currentDirective});
                builder.ForecastData = null;
                e.DisplayerText = caption;
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.RequestedEntity = new ReportScreen(builder);
            }
            else
            {
                e.Cancel = true;
            }
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
            if (_directiveGeneralInformation.GetChangeStatus(true) || _performanceControl.GetChangeStatus())
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

        #region private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)

        private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)
        {
            _directiveSummary.Visible = !_directiveSummary.Visible;
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
            _performanceControl.Visible = !_performanceControl.Visible;
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

            BaseComponent bd = _currentDirective.ParentBaseComponent;
            _currentDirective = new Directive { ParentBaseComponent = bd, DirectiveType = _directiveType};
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
