using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using AvControls;
using AvControls.StatusImageLink;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls;
using CAS.UI.UIControls.StoresControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using TempUIExtentions;
using Component = SmartCore.Entities.General.Accessory.Component;

namespace CAS.UI.UIControls.ComponentControls
{
    /// <summary>
    /// Элемент управления для отображения отчетов базовых агрегатов ВС
    /// </summary>
    public class BaseComponentControl : UserControl, IReference
    {
        #region Fields

        /// <summary>
        /// Базовый агрегат, отображаемый элементом управления
        /// </summary>
        private BaseComponent _currentBaseComponent;
        /// <summary>
        /// Кнопка отображения статуса и параметров базового агрегата
        /// </summary>
        private ReferenceAvalonButtonM baseDetailButton = new ReferenceAvalonButtonM();
        /// <summary>
        /// Состояние отображаемого базового агрегата
        /// </summary>
        private ConditionState _conditionState;

        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem titleToolStripMenuItem;
        private ToolStripMenuItem registerToolStripMenuItem;
        private ToolStripMenuItem overhaulToolStripMenuItem;
        private ToolStripMenuItem inspectionToolStripMenuItem;
        private ToolStripMenuItem shopVisitToolStripMenuItem;
        private ToolStripMenuItem hotSectionInspectionToolStripMenuItem;
        private ToolStripMenuItem logBookToolStripMenuItem;
        private ToolStripMenuItem addComponentToolStripMenuItem1;
        private ToolStripMenuItem aDStatusToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItemLLPDiskSheet;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItemMoveToStore;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem discrepanciesToolStripMenuItem;
        private ToolStripMenuItem sBStatusToolStripMenuItem;
        private ToolStripMenuItem engeneeringOrdersToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;

        private readonly int bottomPadding = 10;
        private readonly int splitterDistance = 240;
        private BaseComponentLinksFlowLayoutPanel contentPanel;
        private Panel paddingPanel = new Panel();
        private SplitContainer splitContainer = new SplitContainer();
        private readonly Size defaultSize = new Size(750, 250);
        #endregion

        #region Properties

        #region public ConditionState BaseDetailCondition
        ///<summary>
        /// Возвращает или задает состояние переданного базового агрегата
        ///</summary>
        public ConditionState BaseComponentCondition
        {
            get { return _conditionState; }
            set
            {
                _conditionState = value;
                if (InvokeRequired)
                    Invoke(new Action(UpdateBaseDetailCondition));
                else UpdateBaseDetailCondition();
            }
        }
        #endregion

        #region public Statuses ComponentsStatus
        ///<summary>
        /// Возвращает или задает состояние компонентов переданного базового агрегата
        ///</summary>
        public Statuses ComponentsStatus
        {
            get { return contentPanel.LinkComponentStatus; }
            set
            {
                if (InvokeRequired)
                    Invoke(new Action<Statuses>(s => contentPanel.LinkComponentStatus = value), value);
                else contentPanel.LinkComponentStatus = value;

                InvokeStatusChanged(value);
            }
        }
        #endregion

        #region public Statuses ComponentsLLPStatus
        ///<summary>
        /// Возвращает или задает состояние вращающихся компонентов переданного базового агрегата
        ///</summary>
        public Statuses ComponentsLLPStatus
        {
            get { return contentPanel.LinkLLPDiscSheetStatus; }
            set
            {
                if (InvokeRequired)
                    Invoke(new Action<Statuses>(s => contentPanel.LinkLLPDiscSheetStatus = value), value);
                else contentPanel.LinkLLPDiscSheetStatus = value;

                InvokeStatusChanged(value);
            }
        }
        #endregion

        #region  public Statuses ADStatus
        ///<summary>
        /// Возвращает или задает состояние директив летной годности переданного базового агрегата
        ///</summary>
        public Statuses ADStatus
        {
            get { return contentPanel.LinkADStatus; }
            set
            {
                if (InvokeRequired)
                    Invoke(new Action<Statuses>(s => contentPanel.LinkADStatus = value), value);
                else contentPanel.LinkADStatus = value;

                InvokeStatusChanged(value);
            }
        }
        #endregion

        #region public Statuses EOStatus
        ///<summary>
        /// Возвращает или задает состояние инженерных ордеров переданного базового агрегата
        ///</summary>
        public Statuses EOStatus
        {
            get { return contentPanel.LinkEOStatus; }
            set
            {
                if (InvokeRequired)
                    Invoke(new Action<Statuses>(s => contentPanel.LinkEOStatus = value), value);
                else contentPanel.LinkEOStatus = value;

                InvokeStatusChanged(value);
            }
        }
        #endregion

        #region public Statuses SBStatus
        ///<summary>
        /// Возвращает или задает состояние сервисных бюллетеней переданного базового агрегата
        ///</summary>
        public Statuses SBStatus
        {
            get { return contentPanel.LinkSBStatus; }
            set
            {
                if (InvokeRequired)
                    Invoke(new Action<Statuses>(s => contentPanel.LinkSBStatus = value), value);
                else contentPanel.LinkSBStatus = value;

                InvokeStatusChanged(value);
            }
        }
        #endregion

        #region public BaseDetail BaseDetail
        ///<summary>
        /// Возвращает базовый агрегат, с которым связан контрол
        ///</summary>
        public BaseComponent BaseComponent
        {
            get { return _currentBaseComponent; }
        }
        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Создается объект для отображения базового агрегата
        /// </summary>
        /// <param name="componentтображаемый объект</param>
        public BaseComponentControl(BaseComponent component)
        {
            if (null == component) 
                throw new ArgumentNullException("component", "Cannot be null");
            _currentBaseComponent = component;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            splitContainer = new SplitContainer();
            contentPanel = new BaseComponentLinksFlowLayoutPanel(_currentBaseComponent);
            contextMenuStrip1 = new ContextMenuStrip();
            titleToolStripMenuItem = new ToolStripMenuItem();
            registerToolStripMenuItem = new ToolStripMenuItem();
            overhaulToolStripMenuItem = new ToolStripMenuItem();
            inspectionToolStripMenuItem = new ToolStripMenuItem();
            shopVisitToolStripMenuItem = new ToolStripMenuItem();
            hotSectionInspectionToolStripMenuItem = new ToolStripMenuItem();
            logBookToolStripMenuItem = new ToolStripMenuItem();
            addComponentToolStripMenuItem1 = new ToolStripMenuItem();
            aDStatusToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItemLLPDiskSheet = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            discrepanciesToolStripMenuItem = new ToolStripMenuItem();
            sBStatusToolStripMenuItem = new ToolStripMenuItem();
            engeneeringOrdersToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemMoveToStore = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripSeparator4 = new ToolStripSeparator();
            // 
            // titleToolStripMenuItem
            // 
            titleToolStripMenuItem.Text = "[Title]";
            titleToolStripMenuItem.Click += TitleToolStripMenuItemClick;
            // 
            // registerToolStripMenuItem
            // 
            registerToolStripMenuItem.Text = "Register";
            // 
            // overhaulToolStripMenuItem
            // 
            overhaulToolStripMenuItem.Text = "Overhaul";
            overhaulToolStripMenuItem.Click += overhaulToolStripMenuItem_Click;
            // 
            // inspectionToolStripMenuItem
            // 
            inspectionToolStripMenuItem.Text = "Inspection";
            inspectionToolStripMenuItem.Click += inspectionToolStripMenuItem_Click;
            // 
            // shopVisitToolStripMenuItem
            // 
            shopVisitToolStripMenuItem.Text = "Shop visit";
            shopVisitToolStripMenuItem.Click += shopVisitToolStripMenuItem_Click;
            // 
            // hotSectionInspectionToolStripMenuItem
            // 
            hotSectionInspectionToolStripMenuItem.Text = "Hot section inspection";
            hotSectionInspectionToolStripMenuItem.Click += hotSectionInspectionToolStripMenuItem_Click;
            // 
            // logBookToolStripMenuItem
            // 
            logBookToolStripMenuItem.Text = "Log book";
            logBookToolStripMenuItem.Click += logBookToolStripMenuItem_Click;
            // 
            // addComponentToolStripMenuItem1
            // 
            addComponentToolStripMenuItem1.Text = "Add component";
            addComponentToolStripMenuItem1.Click += addComponentToolStripMenuItem1_Click;
            // 
            // aDStatusToolStripMenuItem
            // 
            aDStatusToolStripMenuItem.Text = "AD Status";
            aDStatusToolStripMenuItem.Click += aDStatusToolStripMenuItem_Click;
            // 
            // ToolStripMenuItemLLPDiskSheet
            // 
            ToolStripMenuItemLLPDiskSheet.Text = "LLP Disk Sheet Status";
            ToolStripMenuItemLLPDiskSheet.Click += toolStripMenuItemLLPDiskSheet_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // discrepanciesToolStripMenuItem
            // 
            discrepanciesToolStripMenuItem.Text = "Discrepancies";
            discrepanciesToolStripMenuItem.Click += discrepanciesToolStripMenuItem_Click;
            // 
            // sBStatusToolStripMenuItem
            // 
            sBStatusToolStripMenuItem.Text = "SB Status";
            sBStatusToolStripMenuItem.Click += sBStatusToolStripMenuItem_Click;
            // 
            // engeneeringOrdersToolStripMenuItem
            // 
            engeneeringOrdersToolStripMenuItem.Text = "Engineering Orders Status";
            engeneeringOrdersToolStripMenuItem.Click += engeneeringOrdersToolStripMenuItem_Click;
            // 
            // engeneeringOrdersToolStripMenuItem
            // 
            toolStripMenuItemMoveToStore.Text = "Move to Store";
            toolStripMenuItemMoveToStore.Click += toolStripMenuItemMoveToStore_Click;
            //
            // baseDetailButton
            //
            baseDetailButton.ActiveColor = Css.BaseDetailInfoControl.Colors.InactiveTopColorHovered;
            baseDetailButton.ExtendedColor = Css.BaseDetailInfoControl.Colors.InactiveBottomColor;
            baseDetailButton.Font = Css.BaseDetailInfoControl.Fonts.PrimaryFont;
            baseDetailButton.ForeColor = Css.BaseDetailInfoControl.Colors.PrimaryForeColor;
            baseDetailButton.Icon = new Icons().GrayArrow;
            baseDetailButton.MouseDownColor = Css.BaseDetailInfoControl.Colors.InactiveTopColorPressed;
            baseDetailButton.NormalColor = Css.BaseDetailInfoControl.Colors.InactiveTopColor;
           // baseDetailButton.ReflectionType = ReflectionTypes.DisplayInNew;
            baseDetailButton.SecondFont = Css.BaseDetailInfoControl.Fonts.SecondaryFont;
            baseDetailButton.SecondForeColor = Css.BaseDetailInfoControl.Colors.SecondaryForeColor;
            baseDetailButton.SecondTextAlign = ContentAlignment.TopLeft;
            baseDetailButton.SecondTextPadding = new Padding(10, 0, 0, 0);
            baseDetailButton.Size = new Size(235, 90);
            baseDetailButton.TextAlign = ContentAlignment.TopLeft;
            baseDetailButton.TextPadding = new Padding(0, 6, 0, 0);
            baseDetailButton.SecondaryTextPosition = 44;
            baseDetailButton.DisplayerRequested += AircraftButtonDisplayerRequested;
            baseDetailButton.ContextMenuStrip = contextMenuStrip1;
            //
            // splitter
            //
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitter";
            splitContainer.IsSplitterFixed = true;
            splitContainer.SplitterDistance = 230;
            //
            // paddingPanel
            //
            paddingPanel = new Panel();
            paddingPanel.Size = new Size(0, 0);
            paddingPanel.Dock = DockStyle.Top;
            paddingPanel.BringToFront();
            // 
            // splitter.Panel1
            // 
            splitContainer.Panel1.Controls.Add(baseDetailButton);
            splitContainer.Panel2.BackColor = Color.Transparent;
            // 
            // splitter.Panel2
            // 
            splitContainer.Panel2.Controls.Add(contentPanel);
            splitContainer.Panel2.Controls.Add(paddingPanel);
            splitContainer.Panel2.BackColor = Color.Transparent;
            //this.splitContainer.Size = new System.Drawing.Size(641, 100);
            splitContainer.TabIndex = 0;
            // 
            // contentPanel
            // 
            contentPanel.AutoSize = true;
            contentPanel.Dock = DockStyle.Top;
            contentPanel.Location = new Point(0, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.TabIndex = 0;
            contentPanel.SizeChanged += contentPanel_SizeChanged;
            //
            // BaseDetailControl
            //
            Controls.Add(splitContainer);
            Size = defaultSize;
            registerToolStripMenuItem.Enabled =true; //DirectiveCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            addComponentToolStripMenuItem1.Enabled =true; //DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            deleteToolStripMenuItem.Enabled =true; //BaseDetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Remove);
            // 
            // BaseDetailControl
            // 
            registerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
                                                                 {
                                                                     overhaulToolStripMenuItem,
                                                                     inspectionToolStripMenuItem,
                                                                     shopVisitToolStripMenuItem,
                                                                     hotSectionInspectionToolStripMenuItem
                                                                 });
            contextMenuStrip1.Items.AddRange(new ToolStripItem[]
                                                 {
                                                     titleToolStripMenuItem,
                                                     toolStripSeparator1,
                                                     logBookToolStripMenuItem,
                                                     registerToolStripMenuItem,
                                                     toolStripSeparator3,
                                                     aDStatusToolStripMenuItem,
                                                     discrepanciesToolStripMenuItem,
                                                     engeneeringOrdersToolStripMenuItem,
                                                     ToolStripMenuItemLLPDiskSheet,
                                                     sBStatusToolStripMenuItem,
                                                     toolStripSeparator2,
                                                     toolStripMenuItemMoveToStore,
                                                     toolStripSeparator4,
                                                     addComponentToolStripMenuItem1,
                                                     deleteToolStripMenuItem
                                                 });
            baseDetailButton.ContextMenuStrip = contextMenuStrip1;

        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет информацию 
        /// </summary>
        public void UpdateInformation()
        {
            if (_currentBaseComponent.BaseComponentType != BaseComponentType.Frame
                && _currentBaseComponent.BaseComponentType != BaseComponentType.Apu)
            {
                baseDetailButton.Text = _currentBaseComponent.BaseComponentType.ShortName + " " + _currentBaseComponent.TransferRecords.GetLast().Position;
            }
            else
            {
                hotSectionInspectionToolStripMenuItem.Visible = false;
                ToolStripMenuItemLLPDiskSheet.Visible = false;
                baseDetailButton.Text = _currentBaseComponent.BaseComponentType.ShortName;
                if (_currentBaseComponent.BaseComponentType == BaseComponentType.Frame)
                {
                    toolStripSeparator4.Visible = false;
                    toolStripMenuItemMoveToStore.Visible = false;
                }
            }

            //contentPanel.UpdateInformation();
            titleToolStripMenuItem.Text = _currentBaseComponent.ToString();
            baseDetailButton.SecondText = "P/N: " + _currentBaseComponent.PartNumber + Environment.NewLine + "S/N: " + _currentBaseComponent.SerialNumber;
            //UpdateStatus(/*DirectiveConditionState.*/);
        }

        #endregion

        #region public void UpdateBaseDetailCondition()

        /// <summary>
        /// Обновляет иконку статуса базовой детали
        /// </summary>
        public void UpdateBaseDetailCondition()
        {
            Icons icons = new Icons();
            Statuses status = Statuses.Pending;
            if (_conditionState == ConditionState.NotEstimated)
            {
                baseDetailButton.Icon = icons.BlueArrow;
                status = Statuses.NotActive;
            }
            if (_conditionState == ConditionState.Satisfactory)
            {
                baseDetailButton.Icon = icons.GreenArrow;
                status = Statuses.Satisfactory;
            }
            if (_conditionState == ConditionState.Notify)
            {
                baseDetailButton.Icon = icons.OrangeArrow;
                status = Statuses.Notify;
            }
            if (_conditionState == ConditionState.Overdue)
            {
                baseDetailButton.Icon = icons.RedArrow;
                status = Statuses.NotSatisfactory;
            }
            InvokeStatusChanged(status);
        }

        #endregion

        #region private void logBookToolStripMenuItem_Click(object sender, EventArgs e)

        private void logBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
/*
            ReferenceEventArgs arguments =
                new ReferenceEventArgs(new DispatcheredBaseDetailLogBookScreen(currentBaseDetail),
                                       ReflectionTypes.DisplayInNew, currentBaseDetail + ". Log book");
            OnDisplayerRequested(arguments);
*/
        }

        #endregion

    /*    #region private void AddRecord(RecordType recordType)

        private void AddRecord(RecordType recordType)
        {
/*
            ComplianceForm form = new ComplianceForm(currentBaseDetail);
            form.WorkType = recordType;
            form.ShowDialog(); todo
♥1♥
        }

        #endregion*/

        #region private void AircraftButtonDisplayerRequested(object sender, ReferenceEventArgs e)

        private void AircraftButtonDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = $"{_currentBaseComponent.GetParentAircraftRegNumber()}. Component SN {_currentBaseComponent.SerialNumber}";
			e.RequestedEntity = new ComponentScreenNew(_currentBaseComponent);
        }

        #endregion

        #region private void overhaulToolStripMenuItem_Click(object sender, EventArgs e)

        private void overhaulToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // AddRecord(RecordTypesCollection.Instance.OverhaulRecordType);
        }

        #endregion

        #region private void inspectionToolStripMenuItem_Click(object sender, EventArgs e)

        private void inspectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // AddRecord(RecordTypesCollection.Instance.InspectionRecordType);
        }

        #endregion

        #region private void shopVisitToolStripMenuItem_Click(object sender, EventArgs e)

        private void shopVisitToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   AddRecord(RecordTypesCollection.Instance.ShopVisitRecordType);
        }

        #endregion

        #region private void hotSectionInspectionToolStripMenuItem_Click(object sender, EventArgs e)

        private void hotSectionInspectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddRecord(RecordTypesCollection.Instance.HotSectionInspectionRecordType);
        }

        #endregion

        #region private void aDStatusToolStripMenuItem_Click(object sender, EventArgs e)

        private void aDStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            contentPanel.OnAdStatusLinkDisplayRequested(arguments);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private void TitleToolStripMenuItemClick(object sender, EventArgs e)

        private void TitleToolStripMenuItemClick(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            //arguments.TypeOfReflection = ReflectionTypes.DisplayInNew;
            arguments.DisplayerText = $"{_currentBaseComponent.GetParentAircraftRegNumber()}. Component SN {_currentBaseComponent.SerialNumber}";
			arguments.RequestedEntity = new ComponentScreenNew(_currentBaseComponent);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private void engeneeringOrdersToolStripMenuItem_Click(object sender, EventArgs e)

        private void engeneeringOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            contentPanel.OnEngineeringOrdersLinkDisplayRequested(arguments);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private void discrepanciesToolStripMenuItem_Click(object sender, EventArgs e)

        private void discrepanciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            contentPanel.OnDiscrepanciesLinkDisplayRequested(arguments);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private void sBStatusToolStripMenuItem_Click(object sender, EventArgs e)

        private void sBStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            contentPanel.OnSBStatusLinkDisplayRequested(arguments);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private void deleteToolStripMenuItem_Click(object sender, EventArgs e)

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult choice =
                MessageBox.Show("Delete " + _currentBaseComponent.SerialNumber + " item?", "Confirm deleting",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (choice == DialogResult.Yes)
            {
                try
                {

                //if (currentBaseDetail.ParentAircraft != null)
                  //  currentBaseDetail.ParentAircraft.RemoveBaseDetail(currentBaseDetail);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex);
                    return;
                }

            }
        }

        #endregion

        #region private void addComponentToolStripMenuItem1_Click(object sender, EventArgs e)

        private void addComponentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            if (_currentBaseComponent.BaseComponentType==BaseComponentType.Frame)
                arguments.DisplayerText = _currentBaseComponent + ". Add component";
            else 
                arguments.DisplayerText = /*currentBaseDetail.ParentAircraft.RegistrationNumber + */". " + _currentBaseComponent + ". Add component";
            arguments.TypeOfReflection = ReflectionTypes.DisplayInNew;
            //arguments.RequestedEntity = new DispatcheredDetailAddingScreen(currentBaseDetail);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private void toolStripMenuItemLLPDiskSheet_Click(object sender, EventArgs e)

        private void toolStripMenuItemLLPDiskSheet_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            contentPanel.OnLLPDiskSheetStatusLinkDisplayRequested(arguments);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private void toolStripMenuItemMoveToStore_Click(object sender, EventArgs e)

        private void toolStripMenuItemMoveToStore_Click(object sender, EventArgs e)
        {
	        var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentBaseComponent.ParentAircraftId);
	        var form = new MoveComponentForm(new Component[] {_currentBaseComponent}, aircraft);
	        if (form.ShowDialog() == DialogResult.OK)
		        InvokeComponentMovedTo();

        }

        #endregion


        #region protected override void OnEnabledChanged(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.EnabledChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            contentPanel.SetEnabled(Enabled);
        }

        #endregion

        #region private void contentPanel_SizeChanged(object sender, EventArgs e)

        /// <summary>
        /// Occurs when size of content panel been changed
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Parameters</param>
        private void contentPanel_SizeChanged(object sender, EventArgs e)
        {
            splitContainer.Height = contentPanel.Height > baseDetailButton.Height
                                        ? contentPanel.Height
                                        : baseDetailButton.Height;
            if ((contentPanel.Height + bottomPadding) < baseDetailButton.Height)
                Height = baseDetailButton.Height;
            else
                Height = contentPanel.Height + bottomPadding;
        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        /// <summary>
        /// Метод, презназначенный для корректного отображения данного элемента управления
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if ((splitterDistance > splitContainer.Panel1MinSize) &&
                (splitterDistance < Width - splitContainer.Panel2MinSize))
                splitContainer.SplitterDistance = splitterDistance;
        }

        #endregion

        #endregion

        #region IReference items

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return ""; }
            set { }
        }

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return ReflectionTypes.DisplayInNew; }
            set { }
        }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        /// <summary>
        /// Вызов события DisplayerRequested
        /// </summary>
        /// <param name="e">Параметры события</param>
        protected void OnDisplayerRequested(ReferenceEventArgs e)
        {
            if (DisplayerRequested != null)
                DisplayerRequested(this, e);
        }

        #endregion

        #region Events

        #region public event StatusEventHandler StatusChanged;
        ///<summary>
        /// Возбуждает событие оповещающее об изменении статуса одного из показателей агрегата
        ///</summary>
        private void InvokeStatusChanged(Statuses status)
        {
            if (StatusChanged == null) return;
                StatusChanged(this, new StatusEventArgs(status));
        }
        ///<summary>
        /// Возикает о время изменения статуса одного из показателей базового агрегата
        ///</summary>
        [Description("Событие вызываемое при изменении статуса"), Category("Property Changed")]
        public event StatusImageLinkLabel.StatusEventHandler StatusChanged;
		#endregion


		[Description("Событие вызываемое при отправки компонента на склад или ВС"), Category("Property Changed")]
		public event EventHandler ComponentMovedTo;

	    private void InvokeComponentMovedTo()
	    {
		    if (ComponentMovedTo == null) return;
		    ComponentMovedTo(this, EventArgs.Empty);
	    }

		#endregion
	}
}