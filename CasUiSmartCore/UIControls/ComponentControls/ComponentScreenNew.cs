using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Helpers;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASReports.Builders;
using CASTerms;
using EntityCore.DTO.General;
using EntityCore.Filter;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Filters;
using Component = SmartCore.Entities.General.Accessory.Component;
using ComponentCollection = SmartCore.Entities.Collections.ComponentCollection;

namespace CAS.UI.UIControls.ComponentControls
{
    /// <summary>
    /// Экран для добавления компонента
    /// </summary>
    public partial class ComponentScreenNew : ScreenControl
    {
        private Component _currentComponent;
        private ComponentCollection _baseComponentComponents;
        private bool _needReload;
        private ContextMenuStrip _buttonPrintMenuStrip;
        private ToolStripMenuItem _itemPrintReportRecords;
        private ToolStripMenuItem _itemPrintReportEngineRecords;
        private ToolStripMenuItem _itemPrintReportHistory;

        private BaseComponentHeaderControl _baseComponentHeaderControl;
        private IList<ComponentWorkInRegimeParams> _workParams = new List<ComponentWorkInRegimeParams>();

        #region Constructors

        #region public DetailScreenNew()
        /// <summary>
        /// Простой конструктор без параметров
        /// </summary>
        public ComponentScreenNew()
        {
            InitializeComponent();
        }
        #endregion

        #region public DetailScreenNew(Detail detail) : this()
        /// <summary>
        /// Создает экран для редактирования переданного элемента
        /// </summary>
        /// <param name="componentедактируемый элемент</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ComponentScreenNew(Component component) : this()
        {
            if (component == null)
                throw new ArgumentNullException("component", "Argument cannot be null");

            _currentComponent = component;

            Initialize();
        }
        #endregion

        #endregion

        #region Properties

        #region public AbstractRecord [] DisplayedDetailRecords

        /// <summary>
        /// Возвращает список отображаемых записей Compliance по данному агрегату
        /// </summary>
        public AbstractRecord[] DisplayedDetailRecords
        {
            get
            {
                List<AbstractRecord> detailRecords = new List<AbstractRecord>();
                foreach (ComponentDirective directive in _currentComponent.ComponentDirectives)
                {
                    detailRecords.AddRange(directive.PerformanceRecords.ToArray());
                }
                detailRecords.AddRange(_currentComponent.ActualStateRecords.ToArray());
                detailRecords.AddRange(_currentComponent.TransferRecords.ToArray());

                return detailRecords.ToArray();
            }
        }

        #endregion
       
        #endregion

        #region Methods

        #region public override void DisposeScreen()
        /// <summary>
        /// Производит очистку ресурсов страницы
        /// </summary>
        public override void DisposeScreen()
        {
	        CancelAsync();

	        if(_performanceControl != null)
		        _performanceControl.CancelAsync();
	        if(_complianceControl != null)
		        _complianceControl.CalcelAsync();

	        AnimatedThreadWorker.Dispose();

	        if (_itemPrintReportHistory != null) _itemPrintReportHistory.Dispose();
	        if (_itemPrintReportRecords != null) _itemPrintReportRecords.Dispose();
	        if (_itemPrintReportEngineRecords != null) _itemPrintReportEngineRecords.Dispose();
	        if (_buttonPrintMenuStrip != null) _buttonPrintMenuStrip.Dispose();

	        _currentComponent = null;

	        if (_baseComponentComponents != null)
		        _baseComponentComponents.Clear();
	        _baseComponentComponents = null;

	        Dispose(true);
		}

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AnimatedThreadWorker.CancellationPending)
                return;
            if (_currentComponent == null)
                return;
            if (_currentComponent.ItemId <= 0)
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

            //statusControl.ConditionState = GlobalObjects.CasEnvironment.Calculator.GetConditionState(_currentDetail);

            extendableRichContainerSummary.Caption = "Summary P/N:" + _currentComponent.PartNumber
                                          + " S/N:" + _currentComponent.SerialNumber
                                          + " M/T:" + _currentComponent.MaintenanceControlProcess.ShortName
                                          + " Pos:" + _currentComponent.TransferRecords.GetLast().Position;

			//if (_baseDetailHeaderControl != null)
			//    _baseDetailHeaderControl.UpdateInformation();


			//Обновление суммарной информации о директиве
	        _summaryControl.SetParameters(_currentComponent, _baseComponentComponents);

            //обновление информации об ражимах работы агрегата
            if (_currentComponent is BaseComponent && _detailWorkParamsControl != null)
            {
	            var bc = _currentComponent as BaseComponent;

	            foreach (var param in _workParams)
		            param.Engine = bc;

	            bc.ComponentWorkParams.Clear(); 
	            bc.ComponentWorkParams.AddRange(_workParams); 
				_detailWorkParamsControl.BaseComponent = bc;
            }
	        //обновление информации подзадач директивы
	        _performanceControl.CurrentComponent = _currentComponent;
			//обновление информации об выполнении директивы
			_complianceControl.CurrentComponent = _currentComponent;
	        //обновление главной информацию по директиве
	        _generalInformation.CurrentComponent = _currentComponent;

			headerControl.PrintButtonEnabled = DisplayedDetailRecords.Length != 0;
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            #region Загрузка элементов

            AnimatedThreadWorker.ReportProgress(0, "load component");
			try
            {
                if (_currentComponent.ItemId > 0)
                {
                    if (_currentComponent is BaseComponent)
                    {
	                    if (AnimatedThreadWorker.CancellationPending)
	                    {
		                    e.Cancel = true;
		                    return;
	                    }
						_currentComponent = GlobalObjects.ComponentCore.GetFullBaseComponent(_currentComponent.ItemId);

	                    var types = new[] {SmartCoreType.BaseComponent.ItemId, SmartCoreType.ComponentDirective.ItemId};
	                    if (AnimatedThreadWorker.CancellationPending)
	                    {
		                    e.Cancel = true;
		                    return;
	                    }
						//Загрузка документов
						var documents = GlobalObjects.CasEnvironment.Loader.GetObjectList<Document>(new ICommonFilter[]
						{
							new CommonFilter<int>(Document.ParentIdProperty, _currentComponent.ItemId),
							new CommonFilter<int>(Document.ParentTypeIdProperty, FilterType.In, types)
						});

						_currentComponent.ChangeLLPCategoryRecords
							.AddRange(GlobalObjects.CasEnvironment.NewLoader
								.GetObjectList<ComponentLLPCategoryChangeRecordDTO, ComponentLLPCategoryChangeRecord>(new Filter("ParentId", _currentComponent.ItemId)));

						_workParams = GlobalObjects.CasEnvironment.NewLoader
							.GetObjectList<ComponentWorkInRegimeParamDTO, ComponentWorkInRegimeParams>(new List<Filter>()
							{
								new Filter("ComponentId", _currentComponent.ItemId)
							});


						if (documents.Count > 0)
	                    {
		                    var crs = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Component CRS Form") as DocumentSubType;
		                    var shipping = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Shipping document") as DocumentSubType;

		                    var docShipping = documents.FirstOrDefault(d => d.ParentId == _currentComponent.ItemId && d.ParentTypeId == SmartCoreType.BaseComponent.ItemId && d.DocumentSubType.ItemId == shipping.ItemId);
		                    if (docShipping != null)
		                    {
			                    _currentComponent.Document = docShipping;
			                    _currentComponent.Document.Parent = _currentComponent;
		                    }

		                    var docCrs = documents.FirstOrDefault(d => d.ParentId == _currentComponent.ItemId && d.ParentTypeId == SmartCoreType.BaseComponent.ItemId && d.DocumentSubType.ItemId == crs.ItemId);
		                    if (docCrs != null)
		                    {
			                    _currentComponent.DocumentCRS = docCrs;
			                    _currentComponent.DocumentCRS.Parent = _currentComponent;
		                    }

		                    if (_currentComponent.ComponentDirectives.Count > 0)
		                    {

			                    foreach (var directive in _currentComponent.ComponentDirectives)
			                    {
				                    var docCd = documents.FirstOrDefault(d => d.ParentId == directive.ItemId && d.ParentTypeId == SmartCoreType.ComponentDirective.ItemId);
				                    if (docCd != null)
				                    {
					                    directive.Document = docCd;
					                    directive.Document.Parent = directive;
				                    }
			                    }
		                    }
	                    }
                    }
                    else
                    {
	                    if (AnimatedThreadWorker.CancellationPending)
	                    {
		                    e.Cancel = true;
		                    return;
	                    }
						_currentComponent = GlobalObjects.ComponentCore.GetComponentById(_currentComponent.ItemId);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading component", ex);
            }

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            #region Калькуляция состояния директив

            AnimatedThreadWorker.ReportProgress(40, "calculation of component");

            ConditionState conditionState = GlobalObjects.PerformanceCalculator.GetConditionState(_currentComponent);
            Invoke(new Action<ConditionState>(cs => statusControl.ConditionState = cs), conditionState);

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            if(_baseComponentHeaderControl != null && _currentComponent is BaseComponent)
            {
                #region Проверка состояния компонентов

                if(_baseComponentComponents != null)
                    _baseComponentComponents.Clear();
                _baseComponentComponents = GlobalObjects.ComponentCore.GetComponents((BaseComponent)_currentComponent);
                if (_baseComponentComponents.Count == 0)
                {
                    _baseComponentHeaderControl.ComponentsStatus = Statuses.NotActive;
                    _baseComponentHeaderControl.ComponentsLLPStatus = Statuses.NotActive;
                }
                else
                {
                    #region проверка Component Status

                    if (AnimatedThreadWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    AnimatedThreadWorker.ReportProgress(47, "Check Components: Component Status");

                    Statuses allComponentStatus = Statuses.NotActive;
                    foreach (Component detail in _baseComponentComponents)
                    {
                        ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(detail);
                        if (directiveCond == ConditionState.NotEstimated && allComponentStatus == Statuses.NotActive)
                            allComponentStatus = Statuses.NotActive;
                        if (directiveCond == ConditionState.Satisfactory && allComponentStatus != Statuses.Notify)
                            allComponentStatus = Statuses.Satisfactory;
                        if (directiveCond == ConditionState.Notify)
                            allComponentStatus = Statuses.Notify;
                        if (directiveCond == ConditionState.Overdue)
                        {
                            allComponentStatus = Statuses.NotSatisfactory;
                            break;
                        }
                    }
                    _baseComponentHeaderControl.ComponentsStatus = allComponentStatus;

                    #endregion

                    #region проверка LLP Status

                    if (AnimatedThreadWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    AnimatedThreadWorker.ReportProgress(51, "Check Components: LLP Status");

                    IEnumerable<Component> llp = _baseComponentComponents
                        .Where(d => d.ParentBaseComponent != null && d.ParentBaseComponent.BaseComponentTypeId == BaseComponentType.Engine.ItemId);//TODO:(Evgenii Babak) заменить на использование ComponentCore 
					Statuses bdComponentLLPStatus = Statuses.NotActive;
                    foreach (Component llpDetail in llp)
                    {
                        ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(llpDetail);
                        if (directiveCond == ConditionState.NotEstimated && bdComponentLLPStatus == Statuses.NotActive)
                            bdComponentLLPStatus = Statuses.NotActive;
                        if (directiveCond == ConditionState.Satisfactory && bdComponentLLPStatus != Statuses.Notify)
                            bdComponentLLPStatus = Statuses.Satisfactory;
                        if (directiveCond == ConditionState.Notify)
                            bdComponentLLPStatus = Statuses.Notify;
                        if (directiveCond == ConditionState.Overdue)
                        {
                            bdComponentLLPStatus = Statuses.NotSatisfactory;
                            break;
                        }
                    }
                    _baseComponentHeaderControl.ComponentsStatus = bdComponentLLPStatus;

                    #endregion
                }

                if (AnimatedThreadWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                #endregion

                #region Проверка состояния директив

                AnimatedThreadWorker.ReportProgress(55, "Check Directives");
                DirectiveCollection directives = GlobalObjects.DirectiveCore.GetDirectives((BaseComponent)_currentComponent, DirectiveType.All);
                if (directives.Count == 0)
                {
                    _baseComponentHeaderControl.ADStatus = Statuses.NotActive;
                    _baseComponentHeaderControl.EOStatus = Statuses.NotActive;
                    _baseComponentHeaderControl.SBStatus = Statuses.NotActive;
                }
                else
                {
                    #region проверка ADStatus

                    if (AnimatedThreadWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    AnimatedThreadWorker.ReportProgress(55, "Check Directives: AD Status");

                    Statuses allADStatus = Statuses.NotActive;
                    IEnumerable<Directive> ads =
                        directives.Where(p => p.DirectiveType == DirectiveType.AirworthenessDirectives);

                    foreach (Directive primaryDirective in ads)
                    {
                        ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(primaryDirective);
                        if (directiveCond == ConditionState.NotEstimated && allADStatus == Statuses.NotActive)
                            allADStatus = Statuses.NotActive;
                        if (directiveCond == ConditionState.Satisfactory && allADStatus != Statuses.Notify)
                            allADStatus = Statuses.Satisfactory;
                        if (directiveCond == ConditionState.Notify)
                            allADStatus = Statuses.Notify;
                        if (directiveCond == ConditionState.Overdue)
                        {
                            allADStatus = Statuses.NotSatisfactory;
                            break;
                        }
                    }
                    _baseComponentHeaderControl.ADStatus = allADStatus;

                    #endregion

                    #region проверка EO Status

                    if (AnimatedThreadWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    AnimatedThreadWorker.ReportProgress(61, "Check Directives: Engineering order Status");

                    Statuses allEOStatus = Statuses.NotActive;
                    IEnumerable<Directive> eos =
                        directives.Where(p => p.DirectiveType == DirectiveType.EngineeringOrders || 
                                              p.EngineeringOrders != "" || 
                                              p.EngineeringOrderFile != null);
                    foreach (Directive primaryDirective in eos)
                    {
                        ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(primaryDirective);
                        if (directiveCond == ConditionState.NotEstimated && allEOStatus == Statuses.NotActive)
                            allEOStatus = Statuses.NotActive;
                        if (directiveCond == ConditionState.Satisfactory && allEOStatus != Statuses.Notify)
                            allEOStatus = Statuses.Satisfactory;
                        if (directiveCond == ConditionState.Notify)
                            allEOStatus = Statuses.Notify;
                        if (directiveCond == ConditionState.Overdue)
                        {
                            allEOStatus = Statuses.NotSatisfactory;
                            break;
                        }
                    }
                    _baseComponentHeaderControl.EOStatus = allEOStatus;

                    #endregion

                    #region проверка SB Status

                    if (AnimatedThreadWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    AnimatedThreadWorker.ReportProgress(66, "Check Directives: Service bulletins Status");

                    Statuses allSBStatus = Statuses.NotActive;
                    IEnumerable<Directive> sbs =
                        directives.Where(p => p.DirectiveType == DirectiveType.SB || 
                                              p.ServiceBulletinNo != "" || 
                                              p.ServiceBulletinFile != null);
                    foreach (Directive primaryDirective in sbs)
                    {
                        ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(primaryDirective);
                        if (directiveCond == ConditionState.NotEstimated && allSBStatus == Statuses.NotActive)
                            allSBStatus = Statuses.NotActive;
                        if (directiveCond == ConditionState.Satisfactory && allSBStatus != Statuses.Notify)
                            allSBStatus = Statuses.Satisfactory;
                        if (directiveCond == ConditionState.Notify)
                            allSBStatus = Statuses.Notify;
                        if (directiveCond == ConditionState.Overdue)
                        {
                            allSBStatus = Statuses.NotSatisfactory;
                            break;
                        }
                    }

                    _baseComponentHeaderControl.SBStatus = allSBStatus;

                    #endregion
                }
                //Очистка коллекции для предотвращения утечек памяти
                directives.Clear();

                #endregion
            }

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

            //if (_performanceControl != null)
            //{
            //    _performanceControl.CancelAsync();
            //}

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

        #region private void Initialize()
        /// <summary>
        /// Производит дополнительную инициализацию
        /// </summary>
        private void Initialize()
        {
            _needReload = false;

            if (_currentComponent is BaseComponent)
            {
                _baseComponentHeaderControl = new BaseComponentHeaderControl(_currentComponent);
                _baseComponentHeaderControl.TabIndex = 0;

                flowLayoutPanelMain.Controls.Add(_baseComponentHeaderControl);
                flowLayoutPanelMain.Controls.SetChildIndex(_baseComponentHeaderControl, 0);
            }
            BaseComponent bd = _currentComponent as BaseComponent;
            if (bd == null 
                || bd.BaseComponentType != BaseComponentType.Engine
                && bd.BaseComponentType != BaseComponentType.Apu)
                extendableRichContainerWorkParams.Visible = false;

            #region ButtonPrintContextMenu

            _buttonPrintMenuStrip = new ContextMenuStrip();
            _itemPrintReportRecords = new ToolStripMenuItem { Text = "Commercial" };
            _itemPrintReportEngineRecords = new ToolStripMenuItem { Text = "Records" };
            _itemPrintReportHistory = new ToolStripMenuItem { Text = "Compliance history" };
            _buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { _itemPrintReportRecords, _itemPrintReportEngineRecords, _itemPrintReportHistory });

            ButtonPrintMenuStrip = _buttonPrintMenuStrip;

            #endregion

            //обновление нижней шапки(через базовый скрин)
            if (_currentComponent.ParentBaseComponent != null)
            {
	            var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentComponent.ParentBaseComponent.ParentAircraftId);
	            var parentStore = GlobalObjects.StoreCore.GetStoreById(_currentComponent.ParentBaseComponent.ParentStoreId);
                if (parentAircraft != null)
                    CurrentAircraft = parentAircraft;
				else if (parentStore != null)
                    CurrentStore = parentStore;
				else if (_currentComponent.ParentOperator != null)
                    aircraftHeaderControl1.Operator = _currentComponent.ParentBaseComponent.ParentOperator;//TODO:(Evgenii Babak) заменить на использование OperatorCore    
			}
            else
            {
				var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentComponent.ParentAircraftId);
	            var parentStore = GlobalObjects.StoreCore.GetStoreById(_currentComponent.ParentStoreId);
	            if (parentAircraft != null)
		            CurrentAircraft = parentAircraft;
	            else if (parentStore != null)
		            CurrentStore = parentStore;
	            else if (_currentComponent.ParentOperator != null)
		            aircraftHeaderControl1.Operator = _currentComponent.ParentOperator;
	            else aircraftHeaderControl1.Operator = GlobalObjects.CasEnvironment.Operators[0];
			            //TODO:(Evgenii Babak) заменить на использование OperatorCore     
            }

            //обновление суммарной информацию по директиве и суммарную информацию по её подзадачам
            StatusTitle = "Component Status";

            if (_currentComponent.ItemId <= 0)
            {
                _summaryControl.Visible = false;
                _generalInformation.Visible = true;
                _performanceControl.Visible = true;
            }
            else
            {
                _summaryControl.Visible = true;
                _generalInformation.Visible = false;
                _performanceControl.Visible = false;
            }
        }
        #endregion

        #region private bool GetchangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool GetChangeStatus()
        {
            if (_generalInformation.GetChangeStatus() 
                || _performanceControl.GetChangeStatus()
                || (_detailWorkParamsControl != null && _detailWorkParamsControl.GetChangeStatus()))
            {
                return true;
            }
            return false;
        }

		#endregion

		#region private void ApplyChanges()

		private void ApplyChanges()
	    {
			//TODO:(Evgenii Babak) передавать деталь как параметр 
			_detailWorkParamsControl.ApplyChanges();
			_generalInformation.ApplyChanges(_currentComponent);
	    }

	    #endregion

        #region private bool SaveData()
        /// <summary>
        /// Сохранение измененных данных в редактируемом элементе
        /// </summary>
        private bool SaveData()
        {
            try
            {
	            var installationDate = _generalInformation.InstallationDate;
	            var position = _generalInformation.Position;
	            var state = _generalInformation.State;
	            Lifelength installationLifelength = null;

				//TODO:(Evgenii Babak) Расчетом ресурса агрегата на момент установки должен заниматься ComponentCore
				var lastTransferRecord = _currentComponent.TransferRecords.GetLast();
	            if (lastTransferRecord.Position != position || lastTransferRecord.TransferDate != installationDate)
	            {
		            if (_currentComponent is BaseComponent)
			            installationLifelength =GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay((BaseComponent) _currentComponent, installationDate);
		            else
			            installationLifelength = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(_currentComponent, installationDate);
	            }

	            var tr = _currentComponent.TransferRecords.GetLast();
	            if (tr.PreConfirmTransfer)
	            {
					tr.PreConfirmTransfer = false;
					GlobalObjects.CasEnvironment.NewKeeper.Save(tr);
				}

				if(_currentComponent is Component && _currentComponent.LLPCategories)
					installationLifelength = null;

				GlobalObjects.ComponentCore.UpdateComponent(_currentComponent, installationDate, position, state, installationLifelength);
	            _performanceControl.SaveData(_currentComponent);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return false;
            }
            return true;
        }

        #endregion

        #region private bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool ValidateData(out string message)
        {
            if (!_generalInformation.ValidateData(out message) 
			 || !_performanceControl.ValidateData(out message))
            {
                return false;
            }
            return true;
        }

        #endregion

        #region private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)

        private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)
        {
            _summaryControl.Visible = !_summaryControl.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)
        private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)
        {
            _generalInformation.Visible = !_generalInformation.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerWorkParamsExtending(object sender, EventArgs e)
        private void ExtendableRichContainerWorkParamsExtending(object sender, EventArgs e)
        {
            _detailWorkParamsControl.Visible = !_detailWorkParamsControl.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)

        private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)
        {
            _performanceControl.Visible = !_performanceControl.Visible;
        }
        #endregion

        #region private void ComplianceControlComplianceAdded(object sender, EventArgs e)
        private void ComplianceControlComplianceAdded(object sender, EventArgs e)
        {
            AnimatedThreadWorker.RunWorkerAsync();
        }
		#endregion

		#region private void LLPLifeLimitChanged(object sender, System.EventArgs e)

		private void LLPLifeLimitChanged(object sender, EventArgs e)
	    {
		    AnimatedThreadWorker.RunWorkerAsync();
	    }

	    #endregion

		#region private void GeneralInformationLLPMarkChecked(object sender, EventArgs e)
		private void GeneralInformationLLPMarkChecked(object sender, EventArgs e)
        {
            _complianceControl.UpdateInformation();
        }
        #endregion

        #region private void GeneralInformationComponentTypeChanged(Auxiliary.Events.ValueChangedEventArgs e)
        private void GeneralInformationComponentTypeChanged(Auxiliary.Events.ValueChangedEventArgs e)
        {
            _performanceControl.ChangeDirectivesTasksForComponentType(e.Value as GoodsClass ?? GoodsClass.Unknown);
        }
        #endregion

        #region private void HeaderControlPrintButtonDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
        private void HeaderControlPrintButtonDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
        {
	        BaseComponent baseComponent;
	        Operator reportedOperator;
	        var reportedDetail = _currentComponent;
	        var directiveList = new List<ComponentDirective>(_currentComponent.ComponentDirectives.ToArray());
	        if (_currentComponent is BaseComponent)
	        {
		        baseComponent = (BaseComponent)_currentComponent;

		        var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(baseComponent.ParentAircraftId);
		        var parentStore = GlobalObjects.StoreCore.GetStoreById(baseComponent.ParentStoreId);

		        reportedOperator = parentAircraft != null
			        ? GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == parentAircraft.OperatorId)
			        : parentStore.Operator;
	        }
	        else
	        {
		        baseComponent = _currentComponent.ParentBaseComponent;//TODO:(Evgenii Babak) заменить на использование ComponentCore 
		        if (baseComponent == null) return;

		        var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(baseComponent.ParentAircraftId);
		        var parentStore = GlobalObjects.StoreCore.GetStoreById(baseComponent.ParentStoreId);

		        reportedOperator = parentAircraft != null
			        ? GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == parentAircraft.OperatorId)
			        : parentStore.Operator;

	        }

	        var caption = $"{DestinationHelper.GetDestinationObjectString(baseComponent)}. Compliance List";

			if (sender == _itemPrintReportEngineRecords)
	        {
		        var selection = "";
		        var header = "";
		        var trust = "";

				if (baseComponent.BaseComponentType == BaseComponentType.Frame)
		        {
			        selection = "All";
			        header = "FRAME";
		        }

		        if (baseComponent.BaseComponentType == BaseComponentType.LandingGear)
		        {
			        selection = baseComponent.TransferRecords.GetLast().Position;
			        header = "LANDING GEAR";
		        }

		        if (baseComponent.BaseComponentType == BaseComponentType.Engine)
		        {
			        selection = BaseComponentType.Engine + " " + baseComponent.TransferRecords.GetLast().Position;
			        header = "ENGINE";
			        trust = $"Thrust: {baseComponent.Thrust}";
		        }

		        if (baseComponent.BaseComponentType == BaseComponentType.Apu)
		        {
			        selection = BaseComponentType.Apu.ToString();
			        header = "APU";
				}

				var builder = new ComponentTasksReportBuilderNew(header, trust);
		        e.DisplayerText = caption;
		        e.TypeOfReflection = ReflectionTypes.DisplayInNew;
		        builder.DateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
		        builder.ReportedComponent = reportedDetail;
		        builder.OperatorLogotype = reportedOperator.LogoTypeWhite;
		        builder.FilterSelection = selection;
		        builder.AddDirectives(directiveList.ToArray());
		        builder.ForecastData = null;
		        e.RequestedEntity = new ReportScreen(builder);
			}
	        else
	        {
		       

		        var builder = new ComponentTasksReportBuilder();

		        e.DisplayerText = caption;
		        e.TypeOfReflection = ReflectionTypes.DisplayInNew;

		        builder.DateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
		        builder.ReportedComponent = reportedDetail;
		        builder.OperatorLogotype = reportedOperator.LogoTypeWhite;
		        if (baseComponent.BaseComponentType == BaseComponentType.Frame)
		        {
			        var selection = "All";
			        builder.FilterSelection = selection;
			        builder.AddDirectives(directiveList.ToArray());
			        builder.ForecastData = null;
			        e.RequestedEntity = new ReportScreen(builder);
		        }
		        else
		        {
			        var selection = "";
			        if (baseComponent.BaseComponentType == BaseComponentType.LandingGear)
				        selection = baseComponent.TransferRecords.GetLast().Position;
			        if (baseComponent.BaseComponentType == BaseComponentType.Engine)
				        selection = BaseComponentType.Engine + " " + baseComponent.TransferRecords.GetLast().Position;
			        if (baseComponent.BaseComponentType == BaseComponentType.Apu)
				        selection = BaseComponentType.Apu.ToString();
			        builder.LifelengthAircraftSinceNew =
				        GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
			        builder.FilterSelection = selection;
			        builder.AddDirectives(directiveList.ToArray());
			        builder.ForecastData = null;
			        e.RequestedEntity = new ReportScreen(builder);
		        }

			} 
        }
        #endregion

        #region private void HeaderControlSaveButtonClick(object sender, EventArgs e)

        private void HeaderControlSaveButtonClick(object sender, EventArgs e)
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
				ApplyChanges();
				if (SaveData())
                {
                    MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);

                    _needReload = false;

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

        #region private void HeaderControlReloadButtonClick(object sender, EventArgs e)

        private void HeaderControlReloadButtonClick(object sender, EventArgs e)
        {
            CancelAsync();

            if (GetChangeStatus())
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    _needReload = true;
                    AnimatedThreadWorker.RunWorkerAsync();
                }
            }
            else
            {
                _needReload = true;
                AnimatedThreadWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region private void PerformanceControlDirectiveRemoved(object sender, EventArgs e)
        private void PerformanceControlDirectiveRemoved(object sender, EventArgs e)
        {
            if (GetChangeStatus())
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    _needReload = true;
                    AnimatedThreadWorker.RunWorkerAsync();
                }
            }
            else
            {
                _needReload = true;
                AnimatedThreadWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region private void PerformanceControlLLPLifeLimitChanged(object sender, EventArgs e)
        private void PerformanceControlLLPLifeLimitChanged(object sender, EventArgs e)
        {
            _summaryControl.UpdateInformation();
            _complianceControl.UpdateInformation();
        }
        #endregion

        #endregion
    }
}
