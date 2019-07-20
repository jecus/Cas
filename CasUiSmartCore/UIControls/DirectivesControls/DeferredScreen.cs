using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class DeferredScreen : ScreenControl, IEditScreenControl
    {

        #region Fields

        private bool _needReload;

        private DeferredItem _defferedItem;

        private ContextMenuStrip _buttonPrintMenuStrip;
        private ToolStripMenuItem _itemPrintReportRecords;
        private ToolStripMenuItem _itemPrintReportHistory;

        #endregion

        #region Properties

        #region public bool SummaryAircraftClickable
        /// <summary>
        /// Возвращает или задает значение возможности перехода на род.самолет по ссылке
        /// <br/> из контрола суммарной информации
        /// </summary>
        public bool SummaryAircraftClickable
        {
            get { return _defferedSummary.AircraftClicable; }
            set { _defferedSummary.AircraftClicable = value; }
        }
        #endregion

        #region Implementation of IEditScreenControl

        /// <summary>
        /// Редактируемый элемент
        /// </summary>
        BaseEntityObject IEditScreenControl.EditedObject
        {
            get { return _defferedItem; }
        }

        #endregion

        #endregion

        #region Constructor

        #region public DefferedScreen()
        ///<summary>
        /// пустой конструктор
        ///</summary>
        public DeferredScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public DefferedScreen(int defferedItemId) : this ()
        ///<summary>
        /// Создает страницу для отображения информации об одной директиве
        /// <br/> Производя загрузку директивы с заданным ID
        ///</summary>
        /// <param name="defferedItemId">ID директивы, которую необходимо загрузить</param>
        public DeferredScreen(int defferedItemId): this()
        {
            if (defferedItemId <= 0)
                throw new ArgumentException( "must be >= 1", "defferedItemId");

            try
            {
                _defferedItem = GlobalObjects.CasEnvironment.NewLoader.GetObject<DirectiveDTO,DeferredItem>(new List<Filter>()
                {
					new Filter("ItemId",defferedItemId),
					new Filter("DirectiveType",5)
                } ,true);
                
                if(_defferedItem != null)
                {
                    //обновление нижней шапки(через базовый скрин)
                    CurrentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_defferedItem.ParentBaseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
					statusControl.ConditionState = GlobalObjects.PerformanceCalculator.GetConditionState(_defferedItem);

                    //обновление суммарной информацию по директиве и суммарной информации по её подзадачам
                    string summaryCaptionText = _defferedItem.Status.ToString();
                    extendableRichContainerSummary.LabelCaption.Text =
                        "Summary " + _defferedItem.Title +
                        " Category: " + _defferedItem.DeferredCategory +
                        " Status: " + summaryCaptionText;    
                }
                else
                {
                    //обновление нижней шапки(через базовый скрин)
                    statusControl.ConditionState = ConditionState.NotEstimated;
                    //обновление суммарной информацию по директиве и суммарную информацию по её подзадачам
                    string summaryCaptionText = DirectiveStatus.Closed.ToString();
                    extendableRichContainerSummary.LabelCaption.Text =
                        "Summary: Can't find item with id = " + defferedItemId +
                        " Status: " + summaryCaptionText;
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while load deffered Item with id = " + defferedItemId, ex);
            }

            StatusTitle = "Deffered Status";

            _defferedGeneralInformation.comboBoxDefferedCategory.SelectedIndexChanged += ComboBoxDefferedCategorySelectedIndexChanged;
        }
        #endregion
        
        #region public DeferredScreen(BaseSmartCoreObject directiveContainer)
        ///<summary>
        /// Создается объект, описывающий отображение добавления директивы
        ///</summary>
        /// <param name="directiveContainer">Родительский объект, в который добавляется директива</param>
        public DeferredScreen(BaseEntityObject directiveContainer) : this()
        {
            if (directiveContainer == null) throw new ArgumentNullException("directiveContainer");

            if (directiveContainer is BaseComponent)
            {
                var baseDetail = (BaseComponent) directiveContainer;
                _defferedItem = new DeferredItem { ParentBaseComponent = baseDetail};
            }
            else
            {
	            var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(((Aircraft) directiveContainer).AircraftFrameId); 
                _defferedItem = new DeferredItem { ParentBaseComponent = aircraftFrame };
            }
            Initialize();
        }

        #endregion

        #region public DeferredScreen(DeferredItem directive) : this ()

        ///<summary>
        /// Создает страницу для отображения информации об одной директиве
        ///</summary>
        /// <param name="directive">Директива</param>
        public DeferredScreen(DeferredItem directive) : this()
        {
            if (directive == null)
                throw new ArgumentNullException("directive", "Argument cannot be null");

            _defferedItem = directive;

            Initialize();
        }

        #endregion

        #region public DefferedScreen(Aircraft parentAircraft, AircraftFlight aircraftFlight) : this ()

        ///<summary>
        /// Создается объект, описывающий отображение добавления директивы
        /// (данный конструктор используется в DiscrepancyControl через Reflection)
        ///</summary>
        /// <param name="parentAircraft">Родительский объект, в который добавляется директива</param>
        ///<param name="aircraftFlight">Родительский полет, в рамках которого создается директива</param>
        public DeferredScreen(Aircraft parentAircraft, AircraftFlight aircraftFlight) : this ()
        {
            _defferedGeneralInformation.DiscoveryDateEnabled = false;
            _defferedGeneralInformation.EffectiveDate = aircraftFlight.FlightDate.Date;
	        var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircraft.AircraftFrameId);

            _defferedItem = new DeferredItem
                                {
                                    ParentBaseComponent = aircraftFrame,
                                    Threshold = {EffectiveDate = aircraftFlight.FlightDate.Date}
                                };

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
            if (_defferedItem.ParentBaseComponent != null)
            {
	            var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_defferedItem.ParentBaseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
	            var parentStore = GlobalObjects.StoreCore.GetStoreById(_defferedItem.ParentBaseComponent.ParentStoreId);

				if (parentAircraft != null)
                    CurrentAircraft = parentAircraft;
				else if (parentStore != null)
                    CurrentStore = parentStore;
			}

            //обновление суммарной информацию по директиве и суммарную информацию по её подзадачам
            StatusTitle = "Deffered Status";

            if (_defferedItem.ItemId <= 0)
            {
                _defferedSummary.Visible = false;
                _defferedGeneralInformation.Visible = true;
                _performanceControl.Visible = true;
            }
            else
            {
                _defferedSummary.Visible = true;
                _defferedGeneralInformation.Visible = false;
                _performanceControl.Visible = false;
            }

            _defferedGeneralInformation.comboBoxDefferedCategory.SelectedIndexChanged += ComboBoxDefferedCategorySelectedIndexChanged;
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

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AnimatedThreadWorker.CancellationPending)
                return;
            if (_defferedItem == null)
                return;
            if (_defferedItem.ItemId <= 0)
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

            statusControl.ConditionState = _defferedItem.Condition;

            string summaryCaptionText = _defferedItem.Status.ToString();
            extendableRichContainerSummary.LabelCaption.Text =
                "Summary " + _defferedItem.Title +
                " Category: " + _defferedItem.DeferredCategory +
                " Status: " + summaryCaptionText; 

            _defferedSummary.CurrentDefferedItem = _defferedItem;
            //обновление главной информацию по директиве
            _defferedGeneralInformation.CurrentDefferedItem = _defferedItem;
            //обновление информации подзадач директивы
            _performanceControl.CurrentDirective = _defferedItem;
            //обновление информации об выполнении директивы
            _complianceControl.CurrentDirective = _defferedItem;
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            #region Загрузка элементов

            AnimatedThreadWorker.ReportProgress(0, "load directives");

            try
            {
                if (_defferedItem.ItemId > 0 && _needReload)
                {
					_defferedItem = GlobalObjects.CasEnvironment.NewLoader.GetObject<DirectiveDTO, DeferredItem>(new List<Filter>()
					{
						new Filter("ItemId",_defferedItem.ItemId),
						new Filter("DirectiveType",5)
					});
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
                GlobalObjects.PerformanceCalculator.GetNextPerformance(_defferedItem);
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

        #region public override void DisposeScreen()
        public override void DisposeScreen()
        {
            CancelAsync();

            if (AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.CancelAsync();
            AnimatedThreadWorker.Dispose();

            Dispose(true);
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
            if (!_defferedGeneralInformation.ValidateData(out message))
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
            if (_defferedGeneralInformation.GetChangeStatus(_defferedItem.ItemId > 0) || _performanceControl.GetChangeStatus())
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
            _performanceControl.ApplyChanges(_defferedItem);
            _defferedGeneralInformation.ApplyChanges(_defferedItem, changePageTitle);

            try
            {
                GlobalObjects.DirectiveCore.Save(_defferedItem);
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
            _defferedGeneralInformation.ClearFields();
            _performanceControl.ClearFields();
        }
        #endregion

        #region private void SetFieldsUnsaved()
        /// <summary>
        /// Проставляет всем сохраняемым объектам id = -1
        /// </summary>
        private void SetFieldsUnsaved()
        {
            _defferedGeneralInformation.SetFieldsUnsaved();
        }
        #endregion

        #region private void ComboBoxDefferedCategorySelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxDefferedCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;

            DeferredCategory selectedCategory = (DeferredCategory)((ComboBox)sender).SelectedItem;
            _performanceControl.SetThresholdByCategory(selectedCategory);

        }
        #endregion

        #region private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)

        private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)
        {
            _defferedSummary.Visible = !_defferedSummary.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)

        private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)
        {
            _defferedGeneralInformation.Visible = !_defferedGeneralInformation.Visible;
        }
        #endregion

        #region private void extendableRichContainerPerformance_Extending(object sender, EventArgs e)

        private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)
        {
            _performanceControl.Visible = !_performanceControl.Visible;
        }
        #endregion

        #region void ComplianceControlComplianceAdded(object sender, EventArgs e)
        void ComplianceControlComplianceAdded(object sender, EventArgs e)
        {
            CancelAsync();
            
            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void HeaderControl1ReloadRised(object sender, EventArgs e)

        private void HeaderControl1ReloadRised(object sender, EventArgs e)
        {
            if (_defferedGeneralInformation.GetChangeStatus(true) || _performanceControl.GetChangeStatus())
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

        #region private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(_defferedItem.ParentBaseComponent.ParentAircraftId);
			if (_defferedItem.ParentBaseComponent.ParentAircraftId > 0) return;
            var caption = aircraft.RegistrationNumber + ". " + DirectiveType.DeferredItems.CommonName + ". " + _defferedItem.Title + ". Compliance List";
            var reportBuilder = new ComplianceListBuilder(_complianceControl.GetItemsArray());
            reportBuilder.ReportName = caption;
            reportBuilder.DateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());

            e.DisplayerText = caption;
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = new ReportScreen(reportBuilder);
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

            BaseComponent bd = _defferedItem.ParentBaseComponent;
            _defferedItem = new DeferredItem { ParentBaseComponent = bd };
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
