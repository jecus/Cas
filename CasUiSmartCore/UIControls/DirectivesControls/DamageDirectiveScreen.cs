using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Events;
using CASReports.Builders;
using CASTerms;
using EntityCore.DTO.General;
using EntityCore.Filter;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Files;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    ///</summary>
    public partial class DamageDirectiveScreen : ScreenControl
    {
        #region Fields

        private bool _needReload;

        private DamageItem _currentDamage;
        private BaseComponent _currentBaseComponent;
        private ContextMenuStrip _buttonPrintMenuStrip;
        private ToolStripMenuItem _itemPrintReportRecords;
        private ToolStripMenuItem _itemPrintReportHistory;
        
        #endregion

        #region Constructors

        #region public DamageDirectiveScreen()
        ///<summary>
        ///</summary>
        public DamageDirectiveScreen()
        {
            InitializeComponent();
        }
        
        #endregion

        #region public DamageDirectiveScreen(BaseSmartCoreObject directiveContainer)
        ///<summary>
        /// Создается объект, описывающий отображение добавления директивы
        ///</summary>
        /// <param name="directiveContainer">Родительский объект, в который добавляется директива</param>
        public DamageDirectiveScreen(BaseEntityObject directiveContainer)
            : this()
        {
            if (directiveContainer == null) throw new ArgumentNullException("directiveContainer");

            if (directiveContainer is BaseComponent)
            {
                var baseComponent = (BaseComponent) directiveContainer;
                _currentBaseComponent = baseComponent;
                _currentDamage = new DamageItem { ParentBaseComponent = baseComponent};
            }
            else
            {
	            var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(((Aircraft)directiveContainer).AircraftFrameId);
                _currentDamage = new DamageItem { ParentBaseComponent = aircraftFrame };
            }
            Initialize();
        }

        #endregion

        #region public DamageDirectiveScreen(DamageItem damage) : this()
        ///<summary>
        /// Создает страницу для отображения информации об одной директиве
        ///</summary>
        /// <param name="damage">Директива</param>
        public DamageDirectiveScreen(DamageItem damage) : this()
        {
            if (damage == null)
                throw new ArgumentNullException("damage", "Argument cannot be null");
            _currentDamage = damage;

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
            _needReload = true;

            #region ButtonPrintContextMenu

            _buttonPrintMenuStrip = new ContextMenuStrip();
            _itemPrintReportRecords = new ToolStripMenuItem { Text = "Records" };
            _itemPrintReportHistory = new ToolStripMenuItem { Text = "Compliance history" };
            _buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { _itemPrintReportRecords, _itemPrintReportHistory });

            ButtonPrintMenuStrip = _buttonPrintMenuStrip;
            #endregion

            //обновление нижней шапки(через базовый скрин)
            if (_currentDamage.ParentBaseComponent != null)
            {
	            var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentDamage.ParentBaseComponent.ParentAircraftId); //TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
	            var parentStore = GlobalObjects.StoreCore.GetStoreById(_currentDamage.ParentBaseComponent.ParentStoreId);
				if (parentAircraft != null)
                    CurrentAircraft = parentAircraft;
				else if (parentStore != null)
                    CurrentStore = parentStore;
			}

            //обновление суммарной информацию по директиве и суммарную информацию по её подзадачам
            StatusTitle = "Damage Status";

            if (_currentDamage.ItemId <= 0)
            {
                _damageSummary.Visible = false;
                _damageInformation.Visible = true;
                _performanceControl.Visible = true;
            }
            else
            {
                _damageSummary.Visible = true;
                _damageInformation.Visible = false;
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

            _currentDamage = null;

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AnimatedThreadWorker.CancellationPending)
                return;
            if (_currentDamage == null)
                return;
            if (_currentDamage.ItemId <= 0)
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

            statusControl.ConditionState = _currentDamage.Condition;

            extendableRichContainerSummary.LabelCaption.Text = "Summary " + _currentDamage.Title
                + " " +_currentDamage.DamageType 
                + " №: " + _currentDamage.Number
                + " Status: " + _currentDamage.Status;

            _damageSummary.CurrentDamageItem = _currentDamage;
            //обновление главной информацию по директиве
            _damageInformation.CurrentDamageItem = _currentDamage;
            //обновление информации подзадач директивы
            _performanceControl.CurrentDirective = _currentDamage;
            //обновление информации об выполнении директивы
            _complianceControl.CurrentDirective = _currentDamage;
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            #region Загрузка элементов

            AnimatedThreadWorker.ReportProgress(0, "load directives");

            try
            {
                if (_currentDamage.ItemId > 0 && _needReload)
                {
					_currentDamage = GlobalObjects.CasEnvironment.Loader.GetObject<DamageItem>(loadChild:true, itemId:_currentDamage.ItemId);

                    var links = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<ItemFileLinkDTO, ItemFileLink>(new List<Filter>()
                    {
	                    new Filter("ParentId",_currentDamage.ItemId),
	                    new Filter("ParentTypeId", 3053)
                    }, true);
                    _currentDamage.Files.AddRange(links);
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
                //GlobalObjects.PerformanceCalculator.GetNextPerformance(_currentDamage);
                GlobalObjects.MTOPCalculator.CalculateDirectiveNew(_currentDamage);
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
            if (!_damageInformation.ValidateData(out message))
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
            if (_damageInformation.GetChangeStatus(_currentDamage.ItemId > 0) || _performanceControl.GetChangeStatus())
            {
                return true;
            }
            return false;
        }

        #endregion

        #region private bool SaveData(bool changePageTitle = true)
        /// <summary>
        /// Сохранение измененных данных в редактируемом элементе
        /// </summary>
        private bool SaveData(bool changePageTitle = true)
        {
            //Не менять функции местами - сбивается Threshold
            _performanceControl.ApplyChanges(_currentDamage);
            _damageInformation.ApplyChanges(_currentDamage, changePageTitle);

            try
            {
                GlobalObjects.DirectiveCore.Save(_currentDamage);
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
            _damageInformation.ClearFields();
            _performanceControl.ClearFields();
        }
        #endregion

        #region private void SetFieldsUnsaved()
        /// <summary>
        /// Проставляет всем сохраняемым объектам id = -1
        /// </summary>
        private void SetFieldsUnsaved()
        {
            _damageInformation.SetFieldsUnsaved();
        }
        #endregion

        #region private void ComplianceControlComplianceAdded(object sender, EventArgs e)
        private void ComplianceControlComplianceAdded(object sender, EventArgs e)
        {
            CancelAsync();
            
            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)

        private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)
        {
            _damageSummary.Visible = !_damageSummary.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)

        private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)
        {
            _damageInformation.Visible = 
                !_damageInformation.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)

        private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)
        {
            _performanceControl.Visible = !_performanceControl.Visible;
        }
        #endregion

        #region private void HeaderControl1ReloadRised(object sender, EventArgs e)

        private void HeaderControl1ReloadRised(object sender, EventArgs e)
        {
            if (_damageInformation.GetChangeStatus(true) || _performanceControl.GetChangeStatus())
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

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            var aircraft = GlobalObjects.AircraftsCore.GetParentAircraft(_currentDamage);
            if (aircraft == null) return;

            if (sender == _itemPrintReportRecords)
            {
                string caption = aircraft.RegistrationNumber + ". " + _currentDamage.DirectiveType.CommonName + ". " +
                _currentDamage.Title + ". Compliance List";
                var builder = new DirectiveTasksReportBuilder();
                if (_currentBaseComponent == null)
                {
                    builder.ReportedAircraft = CurrentAircraft;
                    builder.ReportTitle = "DAMAGE RECORD";
                    builder.FilterSelection = "All";
                }
                else
                {
                    builder.ReportedBaseComponent = _currentBaseComponent;
                    var selection = "";
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

                builder.AddDirectives(new[] { _currentDamage });
                builder.ForecastData = null;
                e.DisplayerText = caption;
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.RequestedEntity = new ReportScreen(builder);
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

            BaseComponent bd = _currentDamage.ParentBaseComponent;
            _currentDamage = new DamageItem { ParentBaseComponent = bd };
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
