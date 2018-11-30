using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CASReports.Builders;
using CASTerms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ReferenceControls;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using TempUIExtentions;

namespace CAS.UI.UIControls.DetailsControls
{
    /// <summary>
    /// Ёлемент управлени€ дл€ отображени€ отдельного агрегата
    /// </summary>
    [ToolboxItem(false)]
	//TODO(Evgenii Babak): этот скрин нужно удалить т.к скрин ни где не вызываетс€
    public class DetailScreen : ScreenControl
    {

        #region Fields

        private Detail _currentDetail;
        private ContextMenuStrip buttonPrintMenuStrip;
        private ToolStripMenuItem itemPrintReportRecords;
        private ToolStripMenuItem itemPrintReportHistory;

        private readonly BaseDetailHeaderControl _baseDetailHeaderControl;

        private FlowLayoutPanel _flowLayoutPanelMain;

        private readonly DetailSummary _summaryControl;
        private readonly PowerUnitWorkInRegimeListControl _detailWorkParamsControl;
        private readonly DetailGeneralInformationControl _generalDataAndPerformanceControl;
        private readonly DetailCompliancePerformanceListControl _compliancePerformanceControl;
        private readonly DetailComplianceControl _complianceControl;

        private readonly ExtendableRichContainer _extendableRichContainerSummary;
        private readonly ExtendableRichContainer _extendableRichContainerGeneral;
        private readonly ExtendableRichContainer _extendableRichContainerWorkInRegimes;
        private readonly ExtendableRichContainer _extendableRichContainerPerformance;
        private readonly Icons _icons = new Icons();

        #endregion

        #region Constructors

        /// <summary>
        /// —оздает элемент управлени€ дл€ отображени€ отдельного агрегата
        /// </summary>
        /// <param name="sourceDetail"></param>
        public DetailScreen(Detail sourceDetail)
        {
            if (sourceDetail == null)
                throw new ArgumentNullException("sourceDetail", "Argument cannot be null");

            //currentDetail = detail; 
            Detail detail;
            if (sourceDetail is BaseDetail)
            {
                _currentDetail = GlobalObjects.ComponentCore.GetBaseComponentById(sourceDetail.ItemId);
                detail = _currentDetail;
                
            }
            else
            {
                _currentDetail = GlobalObjects.ComponentCore.GetDetailById(sourceDetail.ItemId);
                detail = _currentDetail;
            }
            
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Dock = DockStyle.Fill;
			var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentDetail.ParentAircraftId);
			var parentStore = GlobalObjects.StoreCore.GetStoreById(_currentDetail.ParentStoreId);
			if (_currentDetail is BaseDetail && parentAircraft != null)
            {
                this.aircraftHeaderControl1.Aircraft = parentAircraft;
				this.aircraftHeaderControl1.OperatorClickable = true;
                this.aircraftHeaderControl1.ChildClickable = true;
                this.aircraftHeaderControl1.NextClickable = true;
                this.aircraftHeaderControl1.PrevClickable = true;
	            this.statusControl.Aircraft = parentAircraft;
				_baseDetailHeaderControl = new BaseDetailHeaderControl(_currentDetail);
            }
            else if (_currentDetail != null && parentAircraft != null)
            {
	            this.aircraftHeaderControl1.Aircraft = parentAircraft;
				this.aircraftHeaderControl1.OperatorClickable = true;
                this.aircraftHeaderControl1.ChildClickable = true;
                this.aircraftHeaderControl1.NextClickable = true;
                this.aircraftHeaderControl1.PrevClickable = true;
	            this.statusControl.Aircraft = parentAircraft;
            }
            else if (_currentDetail is BaseDetail && parentStore != null)
            {
                aircraftHeaderControl1.Store = parentStore;
				aircraftHeaderControl1.OperatorClickable = true;
                aircraftHeaderControl1.NextClickable = true;
                aircraftHeaderControl1.PrevClickable = true;
                aircraftHeaderControl1.ChildClickable = true;
                _baseDetailHeaderControl = new BaseDetailHeaderControl(_currentDetail);
            }
            else if (_currentDetail != null && parentStore != null)
            {
                aircraftHeaderControl1.Store = parentStore;
				aircraftHeaderControl1.OperatorClickable = true;
                aircraftHeaderControl1.NextClickable = true;
                aircraftHeaderControl1.PrevClickable = true;
                aircraftHeaderControl1.ChildClickable = true;
            }

            if (_currentDetail is BaseDetail &&
                (((BaseDetail)_currentDetail).BaseDetailType == BaseDetailType.Engine ||
                ((BaseDetail)_currentDetail).BaseDetailType == BaseDetailType.Apu))
            {
                this._detailWorkParamsControl = new PowerUnitWorkInRegimeListControl();
                this._detailWorkParamsControl.AutoSize = true;
                this._detailWorkParamsControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                this._detailWorkParamsControl.Visible = false;
                this._detailWorkParamsControl.MaximumSize = new System.Drawing.Size(1280, 640);
                this._detailWorkParamsControl.MinimumSize = new System.Drawing.Size(1168, 545);
                this._detailWorkParamsControl.Size = new System.Drawing.Size(1168, 545);
 
               
                _extendableRichContainerWorkInRegimes = new ExtendableRichContainer(); 
                this._extendableRichContainerWorkInRegimes.AfterCaptionControl = null;
                this._extendableRichContainerWorkInRegimes.AfterCaptionControl2 = null;
                this._extendableRichContainerWorkInRegimes.AfterCaptionControl3 = null;
                this._extendableRichContainerWorkInRegimes.AutoSize = true;
                this._extendableRichContainerWorkInRegimes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                this._extendableRichContainerWorkInRegimes.BackColor = System.Drawing.Color.Transparent;
                this._extendableRichContainerWorkInRegimes.Caption = "Work Params";
                this._extendableRichContainerWorkInRegimes.DescriptionTextColor = System.Drawing.Color.DimGray;
                this._extendableRichContainerWorkInRegimes.Extendable = true;
                this._extendableRichContainerWorkInRegimes.Extended = true;
                this._extendableRichContainerWorkInRegimes.Location = new System.Drawing.Point(3, 715);
                this._extendableRichContainerWorkInRegimes.MainControl = null;
                this._extendableRichContainerWorkInRegimes.Name = "_extendableRichContainerWorkInRegimes";
                this._extendableRichContainerWorkInRegimes.Size = new System.Drawing.Size(252, 40);
                this._extendableRichContainerWorkInRegimes.TabIndex = 11;
                this._extendableRichContainerWorkInRegimes.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
                this._extendableRichContainerWorkInRegimes.Visible = true;
                this._extendableRichContainerWorkInRegimes.Extending += new System.EventHandler(this.ExtendableRichContainerWorkParamsExtending);
            }
            _complianceControl = new DetailComplianceControl();
            _compliancePerformanceControl = new DetailCompliancePerformanceListControl(_currentDetail);
            _compliancePerformanceControl.DirectiveRemoved += CompliancePerformanceControlDirectiveRemoved;
            _compliancePerformanceControl.LLPLifeLimitChanged += CompliancePerformanceControlLLPLifeLimitChanged;
            _generalDataAndPerformanceControl = new DetailGeneralInformationControl(_currentDetail);
            _generalDataAndPerformanceControl.LLPMarkChecked += GeneralDataAndPerformanceControlLLPMarkChecked;
            _generalDataAndPerformanceControl.ComponentTypeChanged += new Auxiliary.Events.ValueChangedEventHandler(GeneralDataAndPerformanceControlComponentTypeChanged);
            _summaryControl = new DetailSummary(_currentDetail);

            _extendableRichContainerSummary = new ExtendableRichContainer();
            _extendableRichContainerGeneral = new ExtendableRichContainer();
            _extendableRichContainerPerformance = new ExtendableRichContainer();
            StatusTitle = "Component Status";
            
            _flowLayoutPanelMain = new FlowLayoutPanel();
            //
            // aircraftHeader
            //
            //if(aircraftHeader!=null)
            //aircraftHeader.AircraftClickable = true;
            //
            // headerControl
            //
            this.headerControl.ShowPrintButton = true;
            this.headerControl.ShowSaveButton = true;
            this.headerControl.Size = new System.Drawing.Size(985, 58);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlReloadRised);
            this.headerControl.SaveButtonClick += new System.EventHandler(this.ButtonSaveDisplayerRequested);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ButtonPrintDisplayerRequested);
            this.headerControl.Controls.Add(this.aircraftHeaderControl1);
            this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._flowLayoutPanelMain);
            this.panel1.Size = new System.Drawing.Size(973, 478);
            // 
            // aircraftHeaderControl1
            // 
            this.aircraftHeaderControl1.ChildClickable = true;
            this.aircraftHeaderControl1.OperatorClickable = true;
            this.aircraftHeaderControl1.NextClickable = true;
            this.aircraftHeaderControl1.PrevClickable = true;
            // 
            // statusControl
            // 
            this.statusControl.MinimumSize = new System.Drawing.Size(1000, 35);
            this.statusControl.Size = new System.Drawing.Size(1000, 35);
            // 
            // flowLayoutPanelMain
            //  
            this._flowLayoutPanelMain.AutoScroll = true;
            this._flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            if (_baseDetailHeaderControl != null) this._flowLayoutPanelMain.Controls.Add(_baseDetailHeaderControl);
            this._flowLayoutPanelMain.Controls.Add(this._extendableRichContainerSummary);
            this._flowLayoutPanelMain.Controls.Add(this._summaryControl);
            this._flowLayoutPanelMain.Controls.Add(this._extendableRichContainerGeneral);
            this._flowLayoutPanelMain.Controls.Add(this._generalDataAndPerformanceControl);
            if (_extendableRichContainerWorkInRegimes != null) this._flowLayoutPanelMain.Controls.Add(this._extendableRichContainerWorkInRegimes);
            if (_detailWorkParamsControl != null) this._flowLayoutPanelMain.Controls.Add(this._detailWorkParamsControl);
            this._flowLayoutPanelMain.Controls.Add(this._extendableRichContainerPerformance);
            this._flowLayoutPanelMain.Controls.Add(this._compliancePerformanceControl);
            this._flowLayoutPanelMain.Controls.Add(this._complianceControl);
            this._flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this._flowLayoutPanelMain.Name = "_flowLayoutPanelMain";
            this._flowLayoutPanelMain.Size = new System.Drawing.Size(973, 478);
            this._flowLayoutPanelMain.TabIndex = 0;
            this._flowLayoutPanelMain.WrapContents = false;
            // 
            // extendableRichContainerSummary
            // 
            this._extendableRichContainerSummary.AfterCaptionControl = null;
            this._extendableRichContainerSummary.AfterCaptionControl2 = null;
            this._extendableRichContainerSummary.AfterCaptionControl3 = null;
            this._extendableRichContainerSummary.AutoSize = true;
            this._extendableRichContainerSummary.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._extendableRichContainerSummary.BackColor = System.Drawing.Color.Transparent;
            this._extendableRichContainerSummary.Caption = "Summary";
            this._extendableRichContainerSummary.DescriptionTextColor = System.Drawing.Color.DimGray;
            this._extendableRichContainerSummary.Extendable = true;
            this._extendableRichContainerSummary.Extended = true;
            this._extendableRichContainerSummary.Location = new System.Drawing.Point(3, 3);
            this._extendableRichContainerSummary.MainControl = null;
            this._extendableRichContainerSummary.Name = "extendableRichContainerSummary";
            this._extendableRichContainerSummary.Size = new System.Drawing.Size(200, 40);
            this._extendableRichContainerSummary.TabIndex = 7;
            this._extendableRichContainerSummary.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this._extendableRichContainerSummary.Extending += new System.EventHandler(this.ExtendableRichContainerSummaryExtending);
            // 
            // extendableRichContainerGeneral
            // 
            this._extendableRichContainerGeneral.AfterCaptionControl = null;
            this._extendableRichContainerGeneral.AfterCaptionControl2 = null;
            this._extendableRichContainerGeneral.AfterCaptionControl3 = null;
            this._extendableRichContainerGeneral.AutoSize = true;
            this._extendableRichContainerGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._extendableRichContainerGeneral.BackColor = System.Drawing.Color.Transparent;
            this._extendableRichContainerGeneral.Caption = "General Data";
            this._extendableRichContainerGeneral.DescriptionTextColor = System.Drawing.Color.DimGray;
            this._extendableRichContainerGeneral.Extendable = true;
            this._extendableRichContainerGeneral.Extended = true;
            this._extendableRichContainerGeneral.Location = new System.Drawing.Point(3, 363);
            this._extendableRichContainerGeneral.MainControl = null;
            this._extendableRichContainerGeneral.Name = "extendableRichContainerGeneral";
            this._extendableRichContainerGeneral.Size = new System.Drawing.Size(252, 40);
            this._extendableRichContainerGeneral.TabIndex = 9;
            this._extendableRichContainerGeneral.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this._extendableRichContainerGeneral.Extending += new System.EventHandler(this.ExtendableRichContainerGeneralExtending);
            //
            //GeneralDataAndPerformanceControl
            //
            this._generalDataAndPerformanceControl.Visible = false;

            // 
            // extendableRichContainerPerformance
            // 
            this._extendableRichContainerPerformance.AfterCaptionControl = null;
            this._extendableRichContainerPerformance.AfterCaptionControl2 = null;
            this._extendableRichContainerPerformance.AfterCaptionControl3 = null;
            this._extendableRichContainerPerformance.AutoSize = true;
            this._extendableRichContainerPerformance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._extendableRichContainerPerformance.BackColor = System.Drawing.Color.Transparent;
            this._extendableRichContainerPerformance.Caption = "Performance";
            this._extendableRichContainerPerformance.DescriptionTextColor = System.Drawing.Color.DimGray;
            this._extendableRichContainerPerformance.Extendable = true;
            this._extendableRichContainerPerformance.Extended = true;
            this._extendableRichContainerPerformance.Location = new System.Drawing.Point(3, 1100);
            this._extendableRichContainerPerformance.MainControl = null;
            this._extendableRichContainerPerformance.Name = "extendableRichContainerPerformance";
            this._extendableRichContainerPerformance.Size = new System.Drawing.Size(242, 40);
            this._extendableRichContainerPerformance.TabIndex = 13;
            this._extendableRichContainerPerformance.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this._extendableRichContainerPerformance.Extending += new System.EventHandler(this.ExtendableRichContainerPerformanceExtending);
            //
            //CompliancePerformanceControl
            //
            this._compliancePerformanceControl.Visible = false;
            //
            // _complianceControl
            //
            _complianceControl.panelContainer.Visible = false;
            _complianceControl.ButtonAdd.Enabled = false;
            _complianceControl.ComplianceAdded += new EventHandler(ComplianceControlComplianceAdded);
            //
            // baseDetailHeaderControl
            //
            if(_baseDetailHeaderControl != null) _baseDetailHeaderControl.TabIndex = 0;

            // 
            // DirectiveAddingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ShowTopPanelContainer = false;
            this.Name = "DetailScreen";
            this.Size = new System.Drawing.Size(973, 621);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.headerControl.ResumeLayout(false);
            this.headerControl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this._flowLayoutPanelMain.ResumeLayout(false);
            this._flowLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            //обновление нижней шапки(через базовый скрин)
            //CurrentAircraft = _detail.ParentAircraft;
            StatusTitle = "Component Status";
            statusControl.ConditionState =
                GlobalObjects.PerformanceCalculator.GetConditionState(detail);
            //if (_detail.ParentBaseDetail.DetailType != DetailType.Frame)
            //    _currentBaseDetail = outOfPhase.ParentBaseDetail;
            #region ButtonPrintContextMenu

            buttonPrintMenuStrip = new ContextMenuStrip();
            itemPrintReportRecords = new ToolStripMenuItem { Text = "Records" };
            itemPrintReportHistory = new ToolStripMenuItem { Text = "Compliance history" };
            buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { itemPrintReportRecords, itemPrintReportHistory });

            ButtonPrintMenuStrip = buttonPrintMenuStrip;
            #endregion

        //    UpdateDetail(false);
        }

        #endregion

        #region Properties

        #region public Detail Detail

        /// <summary>
        /// ¬озвращает или устанавливает агрегат, с которым работает данный элемент управлени€
        /// </summary>
        public Detail Detail
        {
            get
            {
                return _currentDetail;
            }
            set
            {
                _currentDetail = value;
                _generalDataAndPerformanceControl.UpdateInformation();
                UpdateDetail();
            }
        }

        #endregion

        #region public AbstractRecord [] DisplayedDetailRecords

        /// <summary>
        /// ¬озвращает список отображаемых записей Compliance по данному агрегату
        /// </summary>
        public AbstractRecord[] DisplayedDetailRecords
        {
            get
            {
                List<AbstractRecord> detailRecords = new List<AbstractRecord>();
                foreach (DetailDirective directive in _currentDetail.DetailDirectives)
                {
                    detailRecords.AddRange(directive.PerformanceRecords.ToArray());
                }
                detailRecords.AddRange(_currentDetail.ActualStateRecords.ToArray());
                detailRecords.AddRange(_currentDetail.TransferRecords.ToArray());
                    
                return detailRecords.ToArray();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region protected override void CancelAsync()
        /// <summary>
        /// ѕровер€ет, выполн€ет ли AnimatedThreadWorker задачу, и производит отмену выполнени€
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

        #region public override void DisposeScreen()
        public override void DisposeScreen()
        {
            CancelAsync();

            if (AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.CancelAsync();
            AnimatedThreadWorker.Dispose();

            _currentDetail = null;

            Dispose(true);
        }

        #endregion

        #region public override void OnInitCompletion(object sender)
        public override void OnInitCompletion(object sender)
        {
            UpdateDetail(false);
        }
        #endregion

        #region private void ButtonSaveDisplayerRequested(object sender, EventArgs e)
        /// <summary>
        /// ћетод обработки событи€ нажати€ кнопки Save
        /// </summary>
        private void ButtonSaveDisplayerRequested(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        #endregion

        #region private void HeaderControlReloadRised(object sender, EventArgs e)

        private void HeaderControlReloadRised(object sender, EventArgs e)
        {
            if (_generalDataAndPerformanceControl.GetChangeStatus() || _compliancePerformanceControl.GetChangeStatus() ||
                (_detailWorkParamsControl != null && _detailWorkParamsControl.GetChangeStatus()))
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    CancelAsync();
                    UpdateDetail();
                }
            }
            else
            {
                CancelAsync();
                UpdateDetail();
            }
        }

        #endregion

        #region public bool SaveData()

        /// <summary>
        /// —охранение измененных данных в редактируемом элементе
        /// </summary>
        public bool SaveData()
        {
/*            string message = "";
            if (generalInformationControl.PartNumber == "")
            {
                GetMessage(ref message, "Part Number");
            }
            if (generalInformationControl.SerialNumber == "")
            {
                GetMessage(ref message, "Serial Number");
            }
            if (generalInformationControl.Description == "")
            {
                GetMessage(ref message, "Description");
            }
            if (message != "")
            {
                MessageBox.Show(message, new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return false;
            }*/
            _generalDataAndPerformanceControl.Focus();
            if (_baseDetailHeaderControl != null) _baseDetailHeaderControl.SaveData();
            _generalDataAndPerformanceControl.SaveData();
            if (_detailWorkParamsControl != null && _detailWorkParamsControl.GetChangeStatus())
            {
                _detailWorkParamsControl.ApplyChanges();    
                _detailWorkParamsControl.SaveData();
            }
            _compliancePerformanceControl.SaveData();
            //easaControl.SaveData();
            //if (!currentDetail.InUse)
                //storeControl.SaveData();

            try
            {
                //currentDetail.Save(true);
                if (_currentDetail is BaseDetail)
                    GlobalObjects.ComponentCore.Save(_currentDetail);
                else
                {
                   // ((BaseDetail) currentDetail).ATAChapter = 21;
                    GlobalObjects.ComponentCore.Save(_currentDetail);
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return false;
            }
            CancelAsync();
            UpdateDetail(false);
            return true;
        }

        #endregion

        #region private void UpdateDetail()

        private void UpdateDetail()
        {
            UpdateDetail(true);
        }

        #endregion

        #region private void UpdateDetail(bool reloadDetail)

        private void UpdateDetail(bool reloadDetail)
        {
            try
            {
                if (reloadDetail)
                    if (_currentDetail is BaseDetail)
                        _currentDetail =
                            GlobalObjects.ComponentCore.GetFullBaseComponent(_currentDetail.ItemId);
                    else
                        _currentDetail =
                            GlobalObjects.ComponentCore.GetDetailById(_currentDetail.ItemId);

            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex); 
                return;
            }
            bool permission = true;//currentDetail.HasPermission(Users.CurrentUser, DataEvent.Update);
            _extendableRichContainerSummary.Caption = "Summary P/N:" + _currentDetail.PartNumber
                                          + " S/N:" + _currentDetail.SerialNumber
                                          + " M/T:" + _currentDetail.MaintenanceControlProcess.ShortName
                                          + " Pos:" + _currentDetail.TransferRecords.GetLast().Position;
            if (_baseDetailHeaderControl != null)
            {
                _baseDetailHeaderControl.UpdateInformation();
            }
            _summaryControl.CurrentDetail = _currentDetail;
            //_summaryControl.UpdateInformation();
            
            _generalDataAndPerformanceControl.CurrentDetail = _currentDetail;
            _generalDataAndPerformanceControl.UpdateInformation();
            
            if (_currentDetail is BaseDetail && _detailWorkParamsControl != null)
            {
                _detailWorkParamsControl.BaseDetail = (BaseDetail)_currentDetail;
                _detailWorkParamsControl.UpdateInformation();
            }
            _compliancePerformanceControl.CurrentDetail = _currentDetail;

            _complianceControl.CurrentDetail = _currentDetail;
            //_complianceControl.UpdateInformation();
            
            headerControl.PrintButtonEnabled = DisplayedDetailRecords.Length != 0;
        }

        #endregion

        #region private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            BaseDetail baseDetail;
            Operator reportedOperator;
            var reportedDetail = _currentDetail;
            var directiveList = new List<DetailDirective>(_currentDetail.DetailDirectives.ToArray());
            if (_currentDetail is BaseDetail)
            {
                baseDetail = (BaseDetail)_currentDetail;
				//TODO:(Evgenii Babak) нужно новое свойство OperatorId в классе Detail
	            var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(baseDetail.ParentAircraftId);
	            var parentStore = GlobalObjects.StoreCore.GetStoreById(baseDetail.ParentStoreId);
                reportedOperator = parentAircraft != null
                                       ? GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == parentAircraft.OperatorId)
									   : parentStore.Operator;
			}
            else
            {
                baseDetail = _currentDetail.ParentBaseDetail;//TODO:(Evgenii Babak) заменить на использование ComponentCore 
				if (baseDetail == null) return;
				//TODO:(Evgenii Babak) нужно новое свойство OperatorId в классе Detail
				var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(baseDetail.ParentAircraftId);
	            var parentStore = GlobalObjects.StoreCore.GetStoreById(baseDetail.ParentStoreId);
				reportedOperator = parentAircraft != null
                                       ? GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == parentAircraft.OperatorId)
									   : parentStore.Operator;

			}
            var psn = _currentDetail.PartNumber;
            string caption;
            if(baseDetail.ParentAircraftId > 0)
                caption = $"{baseDetail.GetParentAircraftRegNumber()}. Component {psn}. Compliance List";
			else
                caption= $"{baseDetail.ParentStoreId}. Component {psn}. Compliance List";

			var builder = new ComponentTasksReportBuilder();

            e.DisplayerText = caption;
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;

            builder.DateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            builder.ReportedDetail = reportedDetail;
            builder.OperatorLogotype = reportedOperator.LogoTypeWhite;
            if (baseDetail.BaseDetailType == BaseDetailType.Frame)
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
                if (baseDetail.BaseDetailType == BaseDetailType.LandingGear)
                    selection = baseDetail.TransferRecords.GetLast().Position;
                if (baseDetail.BaseDetailType == BaseDetailType.Engine)
                    selection = BaseDetailType.Engine + " " + baseDetail.TransferRecords.GetLast().Position;
                if (baseDetail.BaseDetailType == BaseDetailType.Apu)
                    selection = BaseDetailType.Apu.ToString();
                builder.LifelengthAircraftSinceNew =
                    GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
                //if (filteredDirectives.Length != notFilteredDirectives.Length)
                builder.FilterSelection = selection;
                builder.AddDirectives(directiveList.ToArray());
                builder.ForecastData = null;
                e.RequestedEntity = new ReportScreen(builder);
            }
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
            _generalDataAndPerformanceControl.Visible = !_generalDataAndPerformanceControl.Visible;
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
            _compliancePerformanceControl.Visible = !_compliancePerformanceControl.Visible;
        }
        #endregion

        #region private void ComplianceControlComplianceAdded(object sender, EventArgs e)
        private void ComplianceControlComplianceAdded(object sender, EventArgs e)
        {
            CancelAsync();
            UpdateDetail();
        }
        #endregion

        #region void CompliancePerformanceControlLLPLifeLimitChanged(object sender, EventArgs e)
        void CompliancePerformanceControlLLPLifeLimitChanged(object sender, EventArgs e)
        {
            _summaryControl.UpdateInformation();
            _complianceControl.UpdateInformation();
        }
        #endregion

        #region void CompliancePerformanceControlDirectiveRemoved(object sender, EventArgs e)
        void CompliancePerformanceControlDirectiveRemoved(object sender, EventArgs e)
        {
            CancelAsync();
            UpdateDetail(true);
        }
        #endregion

        #region void GeneralDataAndPerformanceControlLLPMarkChecked(object sender, EventArgs e)
        void GeneralDataAndPerformanceControlLLPMarkChecked(object sender, EventArgs e)
        {
            _compliancePerformanceControl.UpdateInformation();
        }
        #endregion

        #region void GeneralDataAndPerformanceControlComponentTypeChanged(Auxiliary.Events.ValueChangedEventArgs e)
        void GeneralDataAndPerformanceControlComponentTypeChanged(Auxiliary.Events.ValueChangedEventArgs e)
        {
            _compliancePerformanceControl.ChangeDirectivesTasksForComponentType(e.Value as GoodsClass ?? GoodsClass.Unknown);
        }
        #endregion

        #endregion
    }
}