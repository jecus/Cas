using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CAS.Core.Types.WorkPackages;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.WorkPackages;
using CAS.UI.Properties;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.BiWeekliesReportsControls;
using CAS.UI.UIControls.ComplianceControls;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.StoresControls;
using CAS.UI.UIControls.WorkPackages;
using CASReports.Builders;
using CASTerms;
using Controls.AvMultitabControl.Auxiliary;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.UIControls.Auxiliary;
using Controls.AvButtonT;
using Controls.StatusImageLink;
using Controls;
using Controls.AvMultitabControl;

namespace CAS.UI.UIControls.DetailsControls
{
    ///<summary>
    /// Элемент управления для отображения списка агрегатов
    ///</summary>
    [ToolboxItem(false)]
    public class DetailListScreen : Control, IReference
    {

        #region Fields

        private DispatcheredMultitabControl dispatcheredMultitabControl;

        private AnimatedThreadWorker animatedThreadWorker;
        /// <summary>
        /// Текущий отображаемый базовый агрегат
        /// </summary>
        protected BaseDetail currentBaseDetail;
        private Aircraft currentAircraft;
        private Detail detailBeforeSave;
        private Detail detailBeforeReload;

        private readonly DetailFilterSelection filterSelection;
        private readonly DetailCollectionFilter initialFilter;
        private DetailCollectionFilter additionalFilter = new DetailCollectionFilter(new DetailFilter[0]);

        private AircraftHeaderControl aircraftHeaderControl;
        private RichReferenceButton buttonAddDetail;
        private AvButtonT buttonApplyFilter;
        private AvButtonT buttonDeleteSelected;
        private DetailListView detailViewer;
        private ContextMenuStrip contextMenuStrip;
        private FooterControl footerControl1;
        private HeaderControl headerControl1;
        private Label labelDate;
        private LinkLabel linkSetDate;
        private Label labelTSNCSN;
        /// <summary>
        /// Панель содержащая кнопки управления
        /// </summary>
        protected Panel panelTopContainer;
        private StatusImageLinkLabel labelTitle;

        private ToolStripMenuItem toolStripMenuItemAdd;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private ToolStripMenuItem toolStripMenuItemCopy;
        private ToolStripMenuItem toolStripMenuItemPaste;
        private ToolStripMenuItem toolStripMenuItemHotSectionInspection;
        private ToolStripMenuItem toolStripMenuItemInspection;
        private ToolStripMenuItem toolStripMenuItemOverhaul;
        private ToolStripMenuItem toolStripMenuItemShopVisit;
        private ToolStripMenuItem toolStripMenuItemSetActualState; 
        private ToolStripMenuItem toolStripMenuItemTitle;
        private ToolStripMenuItem toolStripMenuItemMoveToStore;
        private ToolStripMenuItem toolStripMenuItemComposeWorkPackage;
        private ToolStripMenuItem toolStripMenuItemHighlight;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private readonly List<ToolStripMenuItem> toolStripMenuItemsWorkPackages = new List<ToolStripMenuItem>();
        //private readonly List<ToolStripMenuItem> toolStripMenuItemHighlightColorItems = new List<ToolStripMenuItem>();

        private readonly Icons icons = new Icons();

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;
        private readonly bool permissionForUpdate = true;
        private readonly bool permissionForDelete = true;
        private readonly bool permissionForCreate = true;
        private readonly int LABEL_TSNCSN_LEFT_MARGIN = 20;

        #endregion

        #region Constructors

        #region public DetailListScreen()

        ///<summary>
        /// Создает элемент управления для отображения списка агрегатов
        ///</summary>
        protected DetailListScreen()
        {
            permissionForCreate = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            permissionForDelete = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Remove);
            permissionForUpdate = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Update);
            ((DispatcheredComponentStatusScreen)this).InitComplition+=ComponentStatusControl_InitComplition;
            CASClipboard.Instance.ClipboardContentsChanged += ClipboardContentsChanged;
        }

        #endregion

        #region public DetailListScreen(BaseDetail currentBaseDetail, DetailCollectionFilter viewFilter)

        ///<summary>
        /// Создает элемент управления для отображения списка агрегатов
        ///</summary>
        ///<param name="currentBaseDetail">Базовый агрегат, содержащий агрегаты</param>
        ///<param name="viewFilter">Фильтр отображения</param>
        public DetailListScreen(BaseDetail currentBaseDetail, DetailCollectionFilter viewFilter):this()
        {
            if (currentBaseDetail == null)
                throw new ArgumentNullException("currentBaseDetail", "Cannot display null-baseDetail");
            this.currentBaseDetail = currentBaseDetail;
            initialFilter = viewFilter;
            InitializeComponent();
            SetToolStripMenuItems(currentBaseDetail.ParentAircraft);
            HookDetailCollection(currentBaseDetail);
            HookDetails(currentBaseDetail.ContainedDetails);
            filterSelection = new DetailFilterSelection(currentBaseDetail.ParentAircraft);
            SignEvents();
            HookWorkPackageEvents(currentBaseDetail.ParentAircraft);
            UpdateElements();
        }

        #endregion

        #region public DetailListScreen(Aircraft currentAircraft, DetailCollectionFilter initialFilter, DetailCollectionFilter additionalFilter): this()

        ///<summary>
        /// Создает элемент управления для отображения списка агрегатов
        ///</summary>
        ///<param name="currentAircraft">ВС, содержащее агрегаты</param>
        /// ///<param name="initialFilter">Фильтр отображения</param>
        ///<param name="additionalFilter">Дополнительный фильтр</param>
        public DetailListScreen(Aircraft currentAircraft, DetailCollectionFilter initialFilter, DetailCollectionFilter additionalFilter):this()
        {
            if (currentAircraft == null)
                throw new ArgumentNullException("currentAircraft");
            this.currentAircraft = currentAircraft;
            this.initialFilter = initialFilter;
            this.additionalFilter = additionalFilter;
            InitializeComponent();
            SetToolStripMenuItems(currentAircraft);
            HookDetailCollection(currentAircraft);
            HookDetails(currentAircraft.ContainedDetails);
            filterSelection = new DetailFilterSelection(currentAircraft);
            SignEvents();
            HookWorkPackageEvents(currentAircraft);
            UpdateElements();
        }

        #endregion

        #endregion

        #region Properties

        #region public Statuses Status

        /// <summary>
        /// Возвращает или устанавливает статус 
        /// </summary>
        public Statuses Status
        {
            get { return labelTitle.Status; }
            set { labelTitle.Status = value; }
        }

        #endregion

        #region public string StatusText

        /// <summary>
        /// Возвращает или устанавливает текст статуса
        /// </summary>
        public string StatusText
        {
            get { return labelTitle.Text; }
            set { labelTitle.Text = value; }
        }

        #endregion

        #region public IDisplayer Displayer

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        #endregion

        #region public DisplayingEntity Entity

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection [:|||:]
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        #endregion

        #region public BaseDetail CurrentBaseDetail

        /// <summary>
        /// Текущий отображаемый базовый агрегат
        /// </summary>
        public BaseDetail CurrentBaseDetail
        {
            get { return currentBaseDetail; }
            set
            {
                currentBaseDetail = value;
                currentAircraft = null;
                UpdateElements();
            }
        }

        #endregion

        #region public Aircraft CurrentAircraft

        /// <summary>
        /// Отображаемое ВС
        /// </summary>
        public Aircraft CurrentAircraft
        {
            get
            {
                if (currentBaseDetail == null)
                    return currentAircraft;
                else
                    return currentBaseDetail.ParentAircraft;
            }
            set
            {
                currentAircraft = value;
                currentBaseDetail = null;
                UpdateElements();
            }
        }

        #endregion

        #region public IDetailContainer DetailSource

        /// <summary>
        /// Источник агрегатов
        /// </summary>
        public IDetailContainer DetailSource
        {
            get
            {
                if (CurrentBaseDetail != null)
                    return CurrentBaseDetail;
                return CurrentAircraft;
            }
        }

        #endregion

        #region public DetailCollectionFilter AdditionalFilter

        /// <summary>
        /// Примененные фильтры
        /// </summary>
        public DetailCollectionFilter AdditionalFilter
        {
            get { return additionalFilter; }
        }

        #endregion

        #region public DetailListReportBuilder ReportBuilder

        /// <summary>
        /// Построитель отчетов
        /// </summary>
        public DetailListReportBuilder ReportBuilder
        {
            get
            {
                 return filterSelection.ReportBuilder;
            }
            set
            {
                filterSelection.ReportBuilder = value;
            }
        }

        #endregion

        #region private string TitleOfCurrentDetailSource

        private string TitleOfCurrentDetailSource
        {
            get
            {
                if (currentAircraft == null)
                    return currentBaseDetail.SerialNumber;
                return currentAircraft.RegistrationNumber;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            panelTopContainer = new Panel();
            buttonDeleteSelected = new AvButtonT();
            buttonApplyFilter = new AvButtonT();
            buttonAddDetail = new RichReferenceButton();
            footerControl1 = new FooterControl();
            headerControl1 = new HeaderControl();
            aircraftHeaderControl = new AircraftHeaderControl();
            labelTitle = new StatusImageLinkLabel();
            labelDate = new Label();
            linkSetDate = new LinkLabel();
            labelTSNCSN = new Label();
            panelTopContainer.SuspendLayout();
            headerControl1.SuspendLayout();
            SuspendLayout();

            #region Context menu

            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemTitle = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemAdd = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemOverhaul = new ToolStripMenuItem();
            toolStripMenuItemInspection = new ToolStripMenuItem();
            toolStripMenuItemShopVisit = new ToolStripMenuItem();
            toolStripMenuItemSetActualState = new ToolStripMenuItem();
            toolStripMenuItemHotSectionInspection = new ToolStripMenuItem();
            toolStripMenuItemMoveToStore = new ToolStripMenuItem();
            toolStripMenuItemComposeWorkPackage = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            toolStripMenuItemCopy = new ToolStripMenuItem();
            toolStripMenuItemPaste = new ToolStripMenuItem();
            toolStripMenuItemHighlight = new ToolStripMenuItem();
            // 
            // toolStripMenuItemTitle
            // 
            toolStripMenuItemTitle.Text = "Open";
            toolStripMenuItemTitle.Click += toolStripMenuItemEdit_Click;
            // 
            // toolStripMenuItemHighlight
            // 
            toolStripMenuItemHighlight.Text = "Highlight";
            // 
            // toolStripMenuItemAdd
            // 
            toolStripMenuItemAdd.Text = "Add Component ";
            toolStripMenuItemAdd.Click += toolStripMenuItemAdd_Click;
            // 
            // toolStripMenuItemOverhaul
            // 
            toolStripMenuItemOverhaul.Text = "Register Overhaul";
            toolStripMenuItemOverhaul.Click += toolStripMenuItemOverhaul_Click;
            // 
            // toolStripMenuItemSetActualState
            // 
            toolStripMenuItemSetActualState.Text = "Set Actual State";
            toolStripMenuItemSetActualState.Click += toolStripMenuItemSetActualState_Click;
            // 
            // toolStripMenuItemInspection
            // 
            toolStripMenuItemInspection.Text = "Register Inspection";
            toolStripMenuItemInspection.Click += toolStripMenuItemInspection_Click;
            // 
            // toolStripMenuItemHotSectionInspection
            // 
            toolStripMenuItemHotSectionInspection.Text = "Register HotSectionInspection";
            toolStripMenuItemHotSectionInspection.Click += toolStripMenuItemHotSectionInspection_Click;
            // 
            // toolStripMenuItemShopVisit
            // 
            toolStripMenuItemShopVisit.Text = "Register ShopVisit";
            toolStripMenuItemShopVisit.Click += toolStripMenuItemShopVisit_Click;
            // 
            // toolStripMenuItemMoveToStore
            // 
            toolStripMenuItemMoveToStore.Text = "Move to Store";
            toolStripMenuItemMoveToStore.Click += toolStripMenuItemPickOffToStore_Click;
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Text = "Delete";
            toolStripMenuItemDelete.Click += toolStripMenuItemDelete_Click;
            // 
            // toolStripMenuItemCopy
            // 
            toolStripMenuItemCopy.Text = "Copy (Ctrl+C)";
            toolStripMenuItemCopy.Click += toolStripMenuItemCopy_Click;
            // 
            // toolStripMenuItemPaste
            // 
            toolStripMenuItemPaste.Text = "Paste (Ctrl+V)";
            toolStripMenuItemPaste.Click += toolStripMenuItemPaste_Click;
            //
            // toolStripMenuItemComposeWorkPackage
            //
            toolStripMenuItemComposeWorkPackage.Text = "Compose a work package";
            toolStripMenuItemComposeWorkPackage.Click += ComposeWorkPackageItem_Click;
            #endregion

            // 
            // panelTopContainer
            // 
            panelTopContainer.AutoSize = true;
            panelTopContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelTopContainer.BackColor = Color.FromArgb(211,211,211);
            panelTopContainer.Controls.Add(labelDate);
            panelTopContainer.Controls.Add(linkSetDate);
            panelTopContainer.Controls.Add(labelTSNCSN);
            panelTopContainer.Controls.Add(labelTitle);
            panelTopContainer.Controls.Add(buttonDeleteSelected);
            panelTopContainer.Controls.Add(buttonApplyFilter);
            panelTopContainer.Controls.Add(buttonAddDetail);
            panelTopContainer.Dock = DockStyle.Top;
            panelTopContainer.Location = new Point(0, 0);
            panelTopContainer.Name = "panelTopContainer";
            panelTopContainer.Size = new Size(1042, 62);
            panelTopContainer.TabIndex = 14;
            // 
            // buttonApplyFilter
            // 
            buttonApplyFilter.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonApplyFilter.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonApplyFilter.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonApplyFilter.Icon = icons.ApplyFilter;
            buttonApplyFilter.Size = new Size(145, 59);
            buttonApplyFilter.TabIndex = 19;
            buttonApplyFilter.TextMain = "Apply filter";
            buttonApplyFilter.Click += buttonApplyFilter_Click;
            // 
            // buttonAddDetail
            // 
            buttonAddDetail.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonAddDetail.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddDetail.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddDetail.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddDetail.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddDetail.Icon = icons.Add;
            buttonAddDetail.IconNotEnabled = icons.AddGray;
            buttonAddDetail.ReflectionType = ReflectionTypes.DisplayInNew;
            buttonAddDetail.Size = new Size(152, 59);
            buttonAddDetail.TabIndex = 15;
            buttonAddDetail.TextAlignMain = ContentAlignment.BottomCenter;
            buttonAddDetail.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddDetail.TextMain = "Add new";
            buttonAddDetail.TextSecondary = "component";
            buttonAddDetail.DisplayerRequested += ButtonAddDetail_DisplayerRequested;
            // 
            // buttonDeleteSelected
            // 
            buttonDeleteSelected.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonDeleteSelected.Enabled = false;
            buttonDeleteSelected.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.Icon = icons.Delete;
            buttonDeleteSelected.IconNotEnabled = icons.DeleteGray;
            buttonDeleteSelected.PaddingSecondary = new Padding(4, 0, 0, 0);
            buttonDeleteSelected.Size = new Size(145, 59);
            buttonDeleteSelected.TabIndex = 20;
            buttonDeleteSelected.TextAlignMain = ContentAlignment.BottomLeft;
            buttonDeleteSelected.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonDeleteSelected.TextMain = "Delete";
            buttonDeleteSelected.TextSecondary = "selected";
            buttonDeleteSelected.Click += ButtonDelete_Click;
            // 
            // footerControl1
            // 
            footerControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            footerControl1.BackColor = Color.Transparent;
            footerControl1.Dock = DockStyle.Bottom;
            footerControl1.Location = new Point(0, 568);
            footerControl1.Margin = new Padding(0);
            footerControl1.MaximumSize = new Size(0, 48);
            footerControl1.MinimumSize = new Size(0, 48);
            footerControl1.Name = "footerControl1";
            footerControl1.Size = new Size(1042, 48);
            footerControl1.TabIndex = 10;
            // 
            // headerControl1
            // 
            headerControl1.ActionControlSplitterVisible = true;
            headerControl1.ActionControl.ButtonEdit.Enabled = false;
            headerControl1.ContextActionControl.ShowPrintButton = true;
            headerControl1.BackColor = Color.Transparent;
            headerControl1.BackgroundImage = Resources.HeaderBar;
            headerControl1.Controls.Add(aircraftHeaderControl);
            headerControl1.Dock = DockStyle.Top;
            headerControl1.EditDisplayerText = "Component Status Operator";
            headerControl1.EditReflectionType = ReflectionTypes.DisplayInNew;
            headerControl1.EditDisplayerRequested += ButtonEdit_DisplayerRequested;
            headerControl1.Location = new Point(0, 0);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new Size(1042, 58);
            headerControl1.TabIndex = 6;
            headerControl1.ContextActionControl.ButtonPrint.DisplayerRequested += PrintButton_DisplayerRequested;
            headerControl1.ReloadRised += ButtonReload_Click;
            headerControl1.ContextActionControl.ButtonHelp.TopicID = "component_status_aircraft_aggregates_title";
            // 
            // aircraftHeaderControl
            // 
            aircraftHeaderControl.Aircraft = null;
            aircraftHeaderControl.AircraftClickable = true;
            aircraftHeaderControl.BackColor = Color.Transparent;
            aircraftHeaderControl.Location = new Point(0, 0);
            aircraftHeaderControl.Name = "aircraftHeaderControl";
            aircraftHeaderControl.OperatorClickable = true;
            aircraftHeaderControl.Size = new Size(381, 58);
            // 
            // labelTitle
            // 
            Css.HeaderLinkLabel.Adjust(labelTitle);
            labelTitle.Enabled = false;
            labelTitle.ImageLayout = ImageLayout.Center;
            labelTitle.Location = new Point(28, 3);
            labelTitle.Margin = new Padding(0);
            labelTitle.Size = new Size(412, 27);
            labelTitle.TabIndex = 16;
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelDate.ForeColor = Color.DimGray;
            labelDate.Location = new Point(57, 30);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(47, 19);
            labelDate.TabIndex = 21;
            labelDate.Text = "Date as of: ";
            labelDate.SizeChanged += labelDate_SizeChanged;
            // 
            // linkSetDate
            // 
            linkSetDate.AutoSize = true;
            linkSetDate.Font = Css.SimpleLink.Fonts.Font;
            linkSetDate.ForeColor = Css.SimpleLink.Colors.LinkColor;
            linkSetDate.Location = new Point(labelDate.Right, labelDate.Top);
            linkSetDate.Text = "Set date";
            linkSetDate.LinkClicked += this.buttonApplyFilter_Click;
            linkSetDate.SizeChanged += linkSetDate_SizeChanged;
            linkSetDate.LocationChanged += linkSetDate_SizeChanged;
            // 
            // labelTSNCSN
            // 
            labelTSNCSN.AutoSize = true;
            labelTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelTSNCSN.Location = new Point(linkSetDate.Right + LABEL_TSNCSN_LEFT_MARGIN, labelDate.Top);
            //
            // detailViewer
            //
            if (currentBaseDetail != null)
                detailViewer = new DetailListView(currentBaseDetail);
            else
                detailViewer = new DetailListView(currentAircraft.AircraftFrame);
            detailViewer.ContextMenuStrip = contextMenuStrip;
            detailViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
            detailViewer.Size = new Size(Width, Height - headerControl1.Height - footerControl1.Height - panelTopContainer.Height);
            detailViewer.SelectedItemsChanged += componentStatusesViewer_SelectedItemsChanged;
            detailViewer.ItemsPasted += detailViewer_ItemsPasted;
            detailViewer.ItemsDeleted += ButtonDelete_Click;
            // 
            // DetailListScreen
            // 
            BackColor = Color.FromArgb(241, 241, 241);
            Controls.Add(footerControl1);
            Controls.Add(panelTopContainer);
            Controls.Add(headerControl1);
            Controls.Add(detailViewer);
            Name = "DetailListScreen";
            Size = new Size(1042, 616);
            panelTopContainer.ResumeLayout(false);
            panelTopContainer.PerformLayout();
            headerControl1.ResumeLayout(false);
            headerControl1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        #region private void CopyDetails()

        private void CopyDetails()
        {
            try
            {
                if (CASClipboard.Instance.Contents.Count > 0 && CASClipboard.Instance.Contains(typeof(Detail)))
                {
                    for (int i = 0; i < CASClipboard.Instance.Contents.Count; i++)
                    {
                        if (CASClipboard.Instance.Contents[i] is Detail)
                        {
                            Detail detailLink = (Detail)CASClipboard.Instance.Contents[i];
                            Detail detail = detailLink.DeepCopy();
                            if (currentAircraft != null)
                            {
                                currentAircraft.Add(detail);

                            }
                            else
                            {
                                currentBaseDetail.Add(detail);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
            }
        }

        #endregion
        
        #region private void SetToolStripMenuItems(Aircraft aircraft)

        private void SetToolStripMenuItems(Aircraft aircraft)
        {
            contextMenuStrip.Items.Clear();
            toolStripMenuItemsWorkPackages.Clear();
            toolStripMenuItemHighlight.DropDownItems.Clear();
            for (int i = 0; i < HighlightCollection.Instance.Count; i++ )
            {
                ToolStripMenuItem item = new ToolStripMenuItem(HighlightCollection.Instance[i].FullName);
                item.Click += HighlightItem_Click;
                item.Tag = HighlightCollection.Instance[i];
                toolStripMenuItemHighlight.DropDownItems.Add(item);
            }
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                 {
                                                     toolStripMenuItemTitle,
                                                     toolStripSeparator1,
                                                     toolStripMenuItemHighlight,
                                                     toolStripSeparator2,
                                                     toolStripMenuItemSetActualState,
                                                     //toolStripMenuItemOverhaul,
                                                     //toolStripMenuItemInspection,
                                                     //toolStripMenuItemShopVisit,
                                                     //toolStripMenuItemHotSectionInspection,
                                                     toolStripMenuItemMoveToStore,
                                                     toolStripSeparator3,
                                                 });
            List<WorkPackage> workPackages = new List<WorkPackage>(aircraft.WorkPackages);
            workPackages.Sort(new WorkPackageComparer());
            for (int i = 0; i < workPackages.Count; i++)
            {
                if (workPackages[i].Status != WorkPackageStatus.Open)
                    continue;
                ToolStripMenuItem item = new ToolStripMenuItem("Move to " + workPackages[i].Title);
                item.Tag = workPackages[i];
                item.Click += WorkPackageItem_Click;
                toolStripMenuItemsWorkPackages.Add(item);
                item.Enabled = false;//todo
                contextMenuStrip.Items.Add(item);
            }
            toolStripMenuItemComposeWorkPackage.Enabled = false;//todo
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { 
                toolStripMenuItemComposeWorkPackage, 
                toolStripSeparator4, 
                toolStripMenuItemAdd, 
                toolStripMenuItemCopy,
                toolStripMenuItemPaste,
                toolStripMenuItemDelete });
        }

        #endregion

        #region public virtual void UpdateElements()

        /// <summary>
        /// Происходит обновление отображения элементов
        /// </summary>
        public virtual void UpdateElements()
        {
            filterSelection.PageTitle = labelTitle.Text;
            labelTitle.Status = GetStatus(GatherDetails());
            UpdateHeader();
            ShowDetails();
        }

        #endregion

        #region private Statuses GetStatus(BaseDetailDirective[] directives)

        /// <summary>
        /// Возвращает общий статус, по массиву агрегатов
        /// </summary>
        /// <param name="directives"></param>
        /// <returns></returns>
        private Statuses GetStatus(Detail[] directives)
        {
            Statuses status = Statuses.Satisfactory;
            for (int i = 0; i < directives.Length; i++)
            {
                Statuses currentStatus = GetStatus(directives[i]);
                if (currentStatus == Statuses.NotSatisfactory)
                    return currentStatus;
                if (currentStatus == Statuses.Notify)
                {
                    if (status != currentStatus)
                        status = currentStatus;
                    continue;
                }
                if (currentStatus == Statuses.Pending)
                {
                    if (status != currentStatus)
                        status = currentStatus;
                    continue;
                }
            }
            return status;
        }

        #endregion

        #region private Statuses GetStatus(Detail detail)

        private Statuses GetStatus(Detail detail)
        {
            if (detail.ConditionState == DirectiveConditionState.NotSatisfactory)
            {
                return Statuses.NotSatisfactory;

            }
            if (detail.ConditionState == DirectiveConditionState.Notify)
            {
                return Statuses.Notify;
            }

            return Statuses.Satisfactory;
        }

        #endregion

        #region private void UpdateHeader()

        private void UpdateHeader()
        {
            aircraftHeaderControl.Aircraft = CurrentAircraft;
            aircraftHeaderControl.OperatorClickable = true;
        }

        #endregion

        #region private void OnViewEditScreen()

        private void OnViewEditScreen()
        {
            List<Detail> selectedDetails = detailViewer.SelectedItems;
            for (int i = 0; i < selectedDetails.Count; i++)
            {
                Detail detail = selectedDetails[i];
                DispatcheredDetailScreen requestedEntity =
                    new DispatcheredDetailScreen((AbstractDetail) detail.CloneForCurrentData());
                if (currentAircraft != null)
                    OnDisplayerRequested(
                        new ReferenceEventArgs(requestedEntity, ReflectionTypes.DisplayInNew, null,
                                               currentAircraft.RegistrationNumber + ". Component SN " +
                                               detail.SerialNumber));
                else
                    OnDisplayerRequested(
                        new ReferenceEventArgs(requestedEntity, ReflectionTypes.DisplayInNew, null,
                                               currentBaseDetail.SerialNumber + ". Component SN " +
                                               detail.SerialNumber));
            }
        }

        #endregion

        #region private void ShowDetails()

        private void ShowDetails()
        {
            SetGroupingAndTitle();
            Detail[] details = GatherDetails();
            detailViewer.SetItemsArray(details);
            HookDetails(details);
            labelDate.Text = "Date as of: " + filterSelection.DateSelected.ToString(new TermsProvider()["DateFormat"].ToString());
            if (currentAircraft != null)
                labelTSNCSN.Text = "     " + currentAircraft + " TSN/CSN: ";//+ currentAircraft.Limitation.ResourceSinceNew.ToComplianceItemString();//todo
            else if (currentBaseDetail != null)
                labelTSNCSN.Text = "     " + currentBaseDetail + " TSN/CSN: ";// +currentBaseDetail.Limitation.ResourceSinceNew.ToComplianceItemString();todo

            buttonAddDetail.Enabled = permissionForCreate;
            toolStripMenuItemAdd.Enabled = permissionForCreate;
            if (!permissionForUpdate)
            {
                headerControl1.ActionControl.ButtonEdit.TextMain = "View";// ShowEditButton = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.UpdateInformation);
                headerControl1.ActionControl.ButtonEdit.Icon = icons.View;
                headerControl1.ActionControl.ButtonEdit.IconNotEnabled = icons.ViewGray;
            }

            SetContextMenuParameters(detailViewer.SelectedItems.Count);

            headerControl1.ContextActionControl.ButtonPrint.Enabled = detailViewer.ItemsListView.Items.Count != 0;
        }

        #endregion

        #region private void SetGroupingAndTitle()

        private void SetGroupingAndTitle()
        {
            if (currentAircraft == null)
            {
                labelTitle.Text = currentBaseDetail.SerialNumber + ". LLP Disk Sheet Status";
                detailViewer.IsLLPDiskSheetStatus = true;
                return;
            }
            IFilter[] filters = additionalFilter.Filters;
            bool isLandingGearReport = false;
            for (int i = 0; i < filters.Length; i++)
            {
                if (filters[i] is LandingGearsFilter)
                {
                    isLandingGearReport = true;
                    break;
                }
            }
            if (isLandingGearReport)
            {
                detailViewer.GroupByLandingGearPostionNumbers = true;
                labelTitle.Text = TitleOfCurrentDetailSource + ". Landing Gear Status";
            }
            else
            {
                detailViewer.GroupByLandingGearPostionNumbers = false;
                labelTitle.Text = TitleOfCurrentDetailSource + ". Component Status";
            }
        }

        #endregion

        #region private Detail[] GatherDetails()

        private Detail[] GatherDetails()
        {
            List<DetailFilter> appliedFilters = new List<DetailFilter>(initialFilter.Filters);
            if (additionalFilter != null)
                appliedFilters.AddRange(additionalFilter.Filters);
            DetailCollectionFilter filter;
            filter = new DetailCollectionFilter(DetailSource.ContainedDetails, appliedFilters.ToArray());
            return filter.GatherDetails();
        }

        #endregion

        #region protected void ReloadElements()

        /// <summary>
        /// Происходит перезагрузка элементов и синхронизация с базой данных
        /// </summary>
        protected void ReloadElements()
        {
            if (animatedThreadWorker == null)
            {
                animatedThreadWorker = new AnimatedThreadWorker(BackgroundComponentStatusScreenReload, this);
                animatedThreadWorker.State = "Reloading Component Status";
                animatedThreadWorker.WorkFinished += animatedThreadWorker_WorkFinished;
                dispatcheredMultitabControl.SetEnabledToAllEntityes(false);
                animatedThreadWorker.StartThread();
            }

        }

        #endregion

        #region private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)

        private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)
        {
            animatedThreadWorker.StopThread();
            animatedThreadWorker = null;
            dispatcheredMultitabControl.SetEnabledToAllEntityes(true);
            UpdateHeader();
            ShowDetails();
        }

        #endregion


        #region private void BackgroundComponentStatusScreenReload()

        private void BackgroundComponentStatusScreenReload()
        {
            try
            {
                CurrentAircraft.Reload(true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }
        }

        #endregion


        #region private void ReloadForDate(DateTime date)

        private void ReloadForDate(DateTime date, bool provideCurrentData)
        {
            ProxyType detailSource = ((ProxyType) DetailSource);
            if (!provideCurrentData)//todo Исправил !provideCurrentData, по аналогии с DirectiveListScreen
            {
                if (!detailSource.ProvideCurrentData)
                    detailSource = detailSource.CloneForCurrentData();
                else
                    return;
            }
            else
            {
                if (!detailSource.ProvideCurrentData || detailSource.DateAsOf.Date != date.Date) //todo Исправил !detailSource.ProvideCurrentData, по аналогии с DirectiveListControl
                    detailSource = detailSource.CloneAsDateOf(date);
                else
                    return;
            }
            if (detailSource is Aircraft) CurrentAircraft = detailSource as Aircraft;
            if (detailSource is BaseDetail) CurrentBaseDetail = detailSource as BaseDetail;

            ShowDetails();
            labelDate.Text = "Date as of: " + date.ToString(new TermsProvider()["DateFormat"].ToString());
        }

        #endregion

        #region private void ComposeWorkPackage(Aircraft aircraft)

        private void ComposeWorkPackage(Aircraft aircraft)
        {
/*
            WorkPackage workPackage = new WorkPackage();
            workPackage.Title = aircraft.GetNewWorkPackageTitle();

            try
            {
                aircraft.AddWorkPackage(workPackage);
                for (int i = 0; i < detailViewer.SelectedItems.Count; i++)
                    workPackage.AddItem(detailViewer.SelectedItems[i]);
                if (MessageBox.Show("Work Package " + workPackage.Title + " created successfully." + Environment.NewLine + "Open work package screen?",
                                new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    OnDisplayerRequested(new ReferenceEventArgs(new DispatcheredWorkPackageScreen(workPackage), ReflectionTypes.DisplayInNew, aircraft.RegistrationNumber + ". " + workPackage.Title));
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while creating work package", ex);
            }
*/

        }

        #endregion

        #region private void AddItemsToWorkPackage(WorkPackage workPackage)

        private void AddItemsToWorkPackage(WorkPackage workPackage)
        {
/*
            try
            {

                bool exclamation = false;
                for (int i = 0; i < detailViewer.SelectedItems.Count; i++)
                {
                    if (workPackage.Details.Contains(detailViewer.SelectedItems[i]))
                    {
                        exclamation = true;
                        break;
                    }
                }
                if (exclamation)
                {
                    if (MessageBox.Show("Some details will not be added to a work package." + Environment.NewLine + "Continue?",
                            new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                        return;
                }
                int detailsAdded = 0;
                for (int i = 0; i < detailViewer.SelectedItems.Count; i++)
                {
                    if (!workPackage.Details.Contains(detailViewer.SelectedItems[i]))
                    {
                        workPackage.AddItem(detailViewer.SelectedItems[i]);
                        detailsAdded++;
                    }
                }
                string message;
                if (detailsAdded <= 0)
                {
                    if (detailViewer.SelectedItems.Count == 1)
                        message = "Detail is already added to the work package";
                    else
                        message = "Details are already added to the work package";
                }
                else if (detailsAdded == 1)
                    message = "Detail added successfully";
                else
                    message = "Details added successfully";
                if (MessageBox.Show(message + ". Open work package screen?",
                    new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    OnDisplayerRequested(new ReferenceEventArgs(new DispatcheredWorkPackageScreen(workPackage), ReflectionTypes.DisplayInNew, currentAircraft == null ? currentBaseDetail.ParentAircraft.RegistrationNumber : currentAircraft.RegistrationNumber + ". " + workPackage.Title));
                }

            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while adding items to work package", ex);
            }


*/

        }

        #endregion


        #region private void ButtonReload_Click(object sender, EventArgs e)

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            ReloadElements();
        }

        #endregion

        #region private void ButtonEdit_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonEdit_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            OnViewEditScreen();
            e.Cancel = true;
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void PrintButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            DetailListReportBuilder reportBuilder = filterSelection.ReportBuilder;
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            string dateSelected = filterSelection.DateSelected.ToString(new TermsProvider()["DateFormat"].ToString());

            reportBuilder.AddResources(currentAircraft ?? currentBaseDetail.ParentAircraft, detailViewer.GetItemsArray(), dateSelected);
            e.DisplayerText = reportBuilder.ReportTitle + ". Report";
            e.RequestedEntity = new DispatcheredDetailListReport(reportBuilder);
        }

        #endregion

        #region private void buttonApplyFilter_Click(object sender, EventArgs e)

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            filterSelection.Show();
            filterSelection.SetFilterParameters(additionalFilter);
            filterSelection.BringToFront();
        }

        #endregion

        #region private void ButtonAddDetail_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonAddDetail_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredDetailAddingScreen(DetailSource);
            if (currentAircraft != null)
                e.DisplayerText = currentAircraft.RegistrationNumber + ". New Component";
            else
                e.DisplayerText = currentBaseDetail.SerialNumber + ". New Component";
        }

        #endregion

        #region private void ButtonDelete_Click(object sender, EventArgs e)

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if ((detailViewer.SelectedItems == null) && (detailViewer.SelectedItem == null))
                return;
            DialogResult confirmResult =
                MessageBox.Show(
                    detailViewer.SelectedItem != null
                        ? "Do you really want to delete component " + detailViewer.SelectedItem.SerialNumber +
                          "?"
                        : "Do you really want to delete selected components? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                IDetailContainer parent = detailViewer.SelectedItems[0].Parent as IDetailContainer;
                if (parent != null)
                {
                    int count = detailViewer.SelectedItems.Count;

                    try
                    {

                        List<Detail> selectedItems = new List<Detail>(detailViewer.SelectedItems);
                        detailViewer.ItemsListView.BeginUpdate();
                        for (int i = 0; i < count; i++)
                            parent.Remove(selectedItems[i]);
                        detailViewer.ItemsListView.EndUpdate();


                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex);
                        return;
                    }

                    //ReloadElements();
                }
                else
                {
                    MessageBox.Show("Failed to delete component: Parent container is invalid", "Operation failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion



        #region private void filterSelection_ReloadForDate(DateTime dateAsOf)

        private void filterSelection_ReloadForDate(DateTime dateAsOf)
        {
            ReloadForDate(dateAsOf, filterSelection.DateAsOfFilterAppliance);
        }

        #endregion

        #region private void filterSelection_ApplyFilter(object sender, EventArgs e)

        private void filterSelection_ApplyFilter(object sender, EventArgs e)
        {
            additionalFilter = filterSelection.GetDetailCollectionFilter();
            //SetGroupingAndTitle();
            ShowDetails();
        }

        #endregion

        #region public void CloseFilter()

        /// <summary>
        /// Закрытие формы выбора фильтра
        /// </summary>
        public void CloseFilter()
        {
            filterSelection.Close();
        }

        #endregion
        

        
        #region private void componentStatusesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void componentStatusesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            SetContextMenuParameters(e.ItemsCount);
        }

        #endregion

        #region private void SetContextMenuParameters(int count)

        private void SetContextMenuParameters(int count)
        {
            bool permission = DirectiveCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);// && (count == 1); Убрал Сергей Д.
            toolStripMenuItemInspection.Enabled = permission;
            toolStripMenuItemHotSectionInspection.Enabled = permission;
            toolStripMenuItemOverhaul.Enabled = permission;
            toolStripMenuItemShopVisit.Enabled = permission;

            toolStripMenuItemTitle.Enabled =
            toolStripMenuItemHighlight.Enabled = count > 0;
            toolStripMenuItemMoveToStore.Enabled = count > 0;
            toolStripMenuItemSetActualState.Enabled = count > 0;
            toolStripMenuItemCopy.Enabled = count > 0;
            //toolStripMenuItemComposeWorkPackage.Enabled = count > 0 && permissionForUpdate;
         //   for (int i = 0; i < toolStripMenuItemsWorkPackages.Count; i++)
         //       toolStripMenuItemsWorkPackages[i].Enabled = count > 0 && permissionForUpdate;//todo
            headerControl1.ActionControl.ButtonEdit.Enabled = (count == 1);
            buttonDeleteSelected.Enabled = permissionForDelete && (count > 0);
            toolStripMenuItemPaste.Enabled = CASClipboard.Instance.Contains(typeof(Detail));
            toolStripMenuItemDelete.Enabled = buttonDeleteSelected.Enabled;
        }

        #endregion

        #region private void toolStripMenuItemEdit_Click(object sender, EventArgs e)

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            OnViewEditScreen();
        }

        #endregion

        #region private void HighlightItem_Click(object sender, EventArgs e)

        private void HighlightItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < detailViewer.SelectedItems.Count; i++)
            {
                detailViewer.SelectedItems[i].Highlight = (Highlight)((ToolStripMenuItem)sender).Tag;
                try
                {
                    detailViewer.SelectedItems[i].Save(true);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while saving data", ex);
                }

            }
        }

        #endregion

        #region private void toolStripMenuItemAdd_Click(object sender, EventArgs e)

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            ButtonAddDetail_DisplayerRequested(this, arguments);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private void toolStripMenuItemSetActualState_Click(object sender, EventArgs e)

        private void toolStripMenuItemSetActualState_Click(object sender, EventArgs e)
        {
            if (detailViewer.SelectedItems.Count == 0)
                return;
            ActualStateRecordForm formAddRecords = new ActualStateRecordForm(detailViewer.SelectedItems);
            if (formAddRecords.ShowDialog() == DialogResult.OK)
            {
                if (currentBaseDetail != null)
                    currentBaseDetail.Reload();
                else
                    currentAircraft.Reload();
                UpdateElements();
            }
        }

        #endregion

        #region private void toolStripMenuItemShopVisit_Click(object sender, EventArgs e)

        private void toolStripMenuItemShopVisit_Click(object sender, EventArgs e)
        {
            OnAddRecord(RecordTypesCollection.Instance.ShopVisitRecordType);
        }

        #endregion

        #region private void toolStripMenuItemHotSectionInspection_Click(object sender, EventArgs e)

        private void toolStripMenuItemHotSectionInspection_Click(object sender, EventArgs e)
        {
            OnAddRecord(RecordTypesCollection.Instance.HotSectionInspectionRecordType);
        }

        #endregion

        #region private void toolStripMenuItemInspection_Click(object sender, EventArgs e)

        private void toolStripMenuItemInspection_Click(object sender, EventArgs e)
        {
            OnAddRecord(RecordTypesCollection.Instance.InspectionRecordType);
        }

        #endregion

        #region private void toolStripMenuItemOverhaul_Click(object sender, EventArgs e)

        private void toolStripMenuItemOverhaul_Click(object sender, EventArgs e)
        {
            OnAddRecord(RecordTypesCollection.Instance.OverhaulRecordType);
        }

        #endregion

        #region private void toolStripMenuItemMoveToStore_Click(object sender, EventArgs e)

        private void toolStripMenuItemPickOffToStore_Click(object sender, EventArgs e)
        {
            List<AbstractDetail> details = new List<AbstractDetail>();
            for (int i = 0; i < detailViewer.SelectedItems.Count; i++)
                details.Add(detailViewer.SelectedItems[i]);
            MoveDetailForm form = new MoveDetailForm(details, MoveDetailFormMode.MoveToStore, null);
            form.ShowDialog();
        }

        #endregion

        #region private void WorkPackageItem_Click(object sender, EventArgs e)

        private void WorkPackageItem_Click(object sender, EventArgs e)
        {
            WorkPackage workPackage = (WorkPackage)((ToolStripMenuItem)sender).Tag;
            AddItemsToWorkPackage(workPackage);
        }

        #endregion

        #region private void ComposeWorkPackageItem_Click(object sender, EventArgs e)

        private void ComposeWorkPackageItem_Click(object sender, EventArgs e)
        {
            if (currentAircraft != null)
                ComposeWorkPackage(currentAircraft);
            else
                ComposeWorkPackage(currentBaseDetail.ParentAircraft);

        }

        #endregion

        #region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            ButtonDelete_Click(sender, e);
        }

        #endregion

        #region private void toolStripMenuItemCopy_Click(object sender, EventArgs e)

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            int count = detailViewer.SelectedItems.Count;
            if (count > 0)
            {
                List<object> contents = new List<object>();
                
                for (int i = 0; i < count; i++ )
                    contents.Add(detailViewer.SelectedItems[i]);
                CASClipboard.Instance.CopyToClipboard(contents);
            }
        }

        #endregion

        #region private void toolStripMenuItemPaste_Click(object sender, EventArgs e)

        private void toolStripMenuItemPaste_Click(object sender, EventArgs e)
        {
            CopyDetails();
        }

        #endregion

        #region private void detailViewer_ItemsPasted(List<Detail> pastedItems)

        private void detailViewer_ItemsPasted(List<Detail> pastedItems)
        {
            CopyDetails();
        }

        #endregion

        #region protected void OnAddRecord(RecordType recordType)

        /// <summary>
        /// Добавление записи для данного агрегата   
        /// </summary>
        /// <param name="recordType"></param>
        protected void OnAddRecord(RecordType recordType)
        {
          /*  if (detailViewer.SelectedItem != null)
            {
                ComplianceForm form = new ComplianceForm(detailViewer.SelectedItem);
                form.RecordType = recordType;
                form.Saved += form_Saved;
                form.ShowDialog();
            }
           FormAddRecord formAddRecords = new FormAddRecord(detailViewer.SelectedItems, ScreenMode.Add, DetailRecordFormView.Compliance);
            formAddRecords.WorkType = recordType;
            if (formAddRecords.ShowDialog() == DialogResult.OK)
            {
                if (currentBaseDetail != null)
                    currentBaseDetail.LocalReload();
                else
                    currentAircraft.LocalReload();
            }
            UpdateElements();*/
        }

        #endregion

/*
        #region private void form_Saved(DetailRecord record)

        private void form_Saved(DetailRecord record)
        {
            if (currentBaseDetail != null)
                currentBaseDetail.LocalReload();
            else
                currentAircraft.LocalReload();
        }

        #endregion
*/

        #region protected void OnDisplayerRequested()

        /// <summary>
        /// 
        /// </summary>
        protected void OnDisplayerRequested(ReferenceEventArgs e)
        {
            if (null != DisplayerRequested)
            {
                DisplayerRequested(this, e);
            }
        }

        #endregion


        #region private void UnHookDetails(Detail []  details)

        private void UnHookDetails(Detail[] details)
        {
            int length = details.Length;
            for (int i = 0; i < length; i++)
            {
                UnHookDetail(details[i]);
            }
        }


        #endregion
        
        #region private void UnHookDetail(Detail detail)

        private void UnHookDetail(Detail detail)
        {
            detail.Saving -= ComponentStatusControl_Saving;
            detail.Saved -= ComponentStatusControl_Saved;
            detail.Reloading -= ComponentStatusControl_Reloading;
            detail.Reloaded -= ComponentStatusControl_Reloaded;

        }

        #endregion

        #region private void HookDetails(Detail[] details)

        private void HookDetails(Detail[] details)
        {
            int length = details.Length;
            for (int i = 0; i < length; i++)
            {
                UnHookDetail(details[i]);
                HookDetail(details[i]);
            }
        }

        #endregion

        #region private void HookDetail(Detail detail)

        private void HookDetail(Detail detail)
        {
            detail.Saving += ComponentStatusControl_Saving;
            detail.Saved += ComponentStatusControl_Saved;
            detail.Reloading += ComponentStatusControl_Reloading;
            detail.Reloaded += ComponentStatusControl_Reloaded;

        }



        #endregion

        #region private void HookDetailCollection(DetailCollection detailCollection)

        private void HookDetailCollection(IDetailContainer detailContainer)
        {
            UnHookDetailCollection(detailContainer);
            detailContainer.DetailRemoved += DetailContainer_Removed;
            detailContainer.DetailAdded += DetailContainer_Added;
        }

        #endregion

        #region private void UnHookDetailCollection(DetailCollection detailCollection)

        private void UnHookDetailCollection(IDetailContainer detailContainer)
        {
            detailContainer.DetailRemoved -= DetailContainer_Removed;
            detailContainer.DetailAdded -= DetailContainer_Added;
        }

        #endregion

        #region private void SignEvents()

        private void SignEvents()
        {
            filterSelection.ApplyFilter -= filterSelection_ApplyFilter;
            filterSelection.ApplyFilter += filterSelection_ApplyFilter;
            filterSelection.ReloadForDate -= filterSelection_ReloadForDate;
            filterSelection.ReloadForDate += filterSelection_ReloadForDate;
        }

        #endregion

        #region private void HookWorkPackageEvents(Aircraft aircraft)

        private void HookWorkPackageEvents(Aircraft aircraft)
        {
            aircraft.WorkPackageAdded += CurrentAircraft_WorkPackagesChanged;
            aircraft.WorkPackageRemoved += CurrentAircraft_WorkPackagesChanged;
        }

        #endregion

        #region private void UnHookWorkPackageEvents(Aircraft aircraft)

        private void UnHookWorkPackageEvents(Aircraft aircraft)
        {
            aircraft.WorkPackageAdded -= CurrentAircraft_WorkPackagesChanged;
            aircraft.WorkPackageRemoved -= CurrentAircraft_WorkPackagesChanged;
        }

        #endregion


        #region private void ClipboardContentsChanged(object sender, EventArgs e)

        private void ClipboardContentsChanged(object sender, EventArgs e)
        {
            toolStripMenuItemPaste.Enabled = CASClipboard.Instance.Contains(typeof (Detail));
        }

        #endregion

        #region private void DetailListScreen_InitComplition(object sender, EventArgs e)

        private void ComponentStatusControl_InitComplition(object sender, EventArgs e)
        {
            dispatcheredMultitabControl = (DispatcheredMultitabControl)sender;
            ((DispatcheredMultitabControl)sender).Closed += control_Closed;
            ((AvMultitabControl)sender).Selected += ComponentStatusControl_Selected;
        }

        #endregion

        #region private void DetailListScreen_Selected(object sender, AvMultitabControlEventArgs e)

        private void ComponentStatusControl_Selected(object sender, AvMultitabControlEventArgs e)
        {
            detailViewer.ItemsListView.Focus();
        }

        #endregion

        #region private void control_Closed(object sender, AvMultitabControlEventArgs e)

        private void control_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == Parent as DispatcheredTabPage)
            {
                UnHookDetails(DetailSource.ContainedDetails);
                if (currentBaseDetail != null)
                {
                    UnHookDetailCollection(currentBaseDetail);
                    UnHookWorkPackageEvents(currentBaseDetail.ParentAircraft);
                }
                if (currentAircraft != null)
                {
                    UnHookDetailCollection(currentAircraft);
                    UnHookWorkPackageEvents(currentAircraft);
                }
            }
        }
        
        #endregion

        #region private void DetailContainer_Removed(object sender, CollectionChangeEventArgs e)

        private void DetailContainer_Removed(object sender, CollectionChangeEventArgs e)
        {
            detailViewer.DeleteItem((Detail)e.Element);
            UnHookDetail((Detail)e.Element);


        }

        #endregion

        #region private void DetailListScreen_Saved(object sender, EventArgs e)

        private void ComponentStatusControl_Saved(object sender, EventArgs e)
        {
            detailViewer.EditItem(detailBeforeSave, (Detail)sender);
            labelTitle.Status = GetStatus(GatherDetails());
        }

        #endregion

        #region private void DetailListScreen_Saving(object sender, CancelEventArgs e)

        private void ComponentStatusControl_Saving(object sender, CancelEventArgs e)
        {
            detailBeforeSave = (Detail)sender;
        }

        #endregion

        #region private void DetailListScreen_Reloading(object sender, CancelEventArgs e)

        private void ComponentStatusControl_Reloading(object sender, CancelEventArgs e)
        {
            if (!InvokeRequired)
                detailBeforeReload = (Detail)sender;
        }

        #endregion

        #region private void DetailListScreen_Reloaded(object sender, EventArgs e)

        private void ComponentStatusControl_Reloaded(object sender, EventArgs e)
        {
            if (!InvokeRequired)
                detailViewer.EditItem(detailBeforeReload, (Detail)sender);
        }

        #endregion

        #region private void DetailContainer_Added(object sender, CollectionChangeEventArgs e)

        private void DetailContainer_Added(object sender, CollectionChangeEventArgs e)
        {
            detailViewer.AddNewItem((Detail)e.Element);
            HookDetail((Detail)e.Element);
            labelTitle.Status = GetStatus(GatherDetails());
        }

        #endregion

        #region private void CurrentAircraft_WorkPackagesChanged(object sender, CollectionChangeEventArgs e)

        private void CurrentAircraft_WorkPackagesChanged(object sender, CollectionChangeEventArgs e)
        {
            SetToolStripMenuItems((Aircraft) sender);
        }

        #endregion

        #region protected void SetPageEnable(bool isEnable)
        /// <summary>
        /// Set page enable
        /// </summary>
        /// <param name="isEnable"></param>
        protected void SetPageEnable(bool isEnable)
        {
            detailViewer.Enabled = isEnable;
            panelTopContainer.Enabled = isEnable;
            buttonDeleteSelected.Enabled = isEnable; 
            buttonApplyFilter.Enabled = isEnable;
            buttonAddDetail.Enabled = isEnable;
            footerControl1.Enabled = isEnable;
            headerControl1.Enabled = isEnable;
            aircraftHeaderControl.Enabled = isEnable;
            labelDate.Enabled = isEnable;
        }
        #endregion


        #region private void labelDate_SizeChanged(object sender, EventArgs e)

        private void labelDate_SizeChanged(object sender, EventArgs e)
        {
            linkSetDate.Location = new Point(labelDate.Right, labelDate.Top);
        }

        #endregion

        #region private void linkSetDate_SizeChanged(object sender, EventArgs e)

        private void linkSetDate_SizeChanged(object sender, EventArgs e)
        {
            labelTSNCSN.Location = new Point(linkSetDate.Right + LABEL_TSNCSN_LEFT_MARGIN, labelDate.Top);
        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (buttonDeleteSelected != null)
                buttonDeleteSelected.Location = new Point(Width - buttonDeleteSelected.Width - 5, 0);
            if (buttonAddDetail != null)
                buttonAddDetail.Location = new Point(buttonDeleteSelected.Left - buttonAddDetail.Width - 5, 0);
            if (buttonApplyFilter != null)
                buttonApplyFilter.Location = new Point(buttonAddDetail.Left - buttonApplyFilter.Width - 5, 0);

            if (detailViewer != null)
            {
                detailViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                detailViewer.Size =
                    new Size(Width,
                             Height - headerControl1.Height - footerControl1.Height - panelTopContainer.Height);
            }
        }

        #endregion

        #endregion

        #region Events

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #endregion

    }
}