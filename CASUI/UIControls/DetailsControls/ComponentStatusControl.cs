using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Management;
using CAS.UI.Properties;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.BiWeekliesReportsControls;
using CAS.UI.UIControls.StoresControls;
using CASReports.Builders;
using Controls.AvMultitabControl.Auxiliary;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.DetailsControls.FilterControls;
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
    public class ComponentStatusControl : Control, IReference
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
        private ComponentStatusListView componentStatusesViewer;
        private ContextMenuStrip contextMenuStrip1;
        private FooterControl footerControl1;
        private HeaderControl headerControl1;
        private Label labelDate;
        private LinkLabel linkSetDate;
        private Label labelTSNCSN;
        private QuickSearchControl quickSearchControl;
        private Label labelTotal;
        private readonly string quickSearchDefaultText = "Quick Search";
        private int searchStartIndex = 0;
        private bool clearSearch = false;
        /// <summary>
        /// Панель содержащая общее количество отображаемых элементов
        /// </summary>
        protected Panel panelBottomContainer;
        /// <summary>
        /// Панель содержащая кнопки управления
        /// </summary>
        protected Panel panelTopContainer;
        private StatusImageLinkLabel statusImageLinkLabel;

        private ToolStripMenuItem toolStripMenuItemAdd;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private ToolStripMenuItem toolStripMenuItemHotSectionInspection;
        private ToolStripMenuItem toolStripMenuItemInspection;
        private ToolStripMenuItem toolStripMenuItemOverhaul;
        private ToolStripMenuItem toolStripMenuItemShopVisit;
        private ToolStripMenuItem toolStripMenuItemSetActualState; 
        private ToolStripMenuItem toolStripMenuItemTitle;
        private ToolStripMenuItem toolStripMenuItemPickOffToStore;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;

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

        #region public ComponentStatusControl()

        ///<summary>
        /// Создает элемент управления для отображения списка агрегатов
        ///</summary>
        protected ComponentStatusControl()
        {
            permissionForCreate = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            permissionForDelete = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Remove);
            permissionForUpdate = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Update);
            InitializeComponent();
            ((DispatcheredComponentStatusControl)this).InitComplition+=ComponentStatusControl_InitComplition; 
        }

        #endregion

        #region public ComponentStatusControl(BaseDetail currentBaseDetail, DetailCollectionFilter viewFilter)

        ///<summary>
        /// Создает элемент управления для отображения списка агрегатов
        ///</summary>
        ///<param name="currentBaseDetail">Базовый агрегат, содержащий агрегаты</param>
        ///<param name="viewFilter">Фильтр отображения</param>
        public ComponentStatusControl(BaseDetail currentBaseDetail, DetailCollectionFilter viewFilter):this()
        {
            if (currentBaseDetail == null)
                throw new ArgumentNullException("currentBaseDetail", "Cannot display null-baseDetail");
            this.currentBaseDetail = currentBaseDetail;
            UnHookDetailCollection(currentBaseDetail.DetailCollection);
            HookDetailCollection(currentBaseDetail.DetailCollection);
            HookDetails(currentBaseDetail.ContainedDetails);
            filterSelection = new DetailFilterSelection(currentBaseDetail.ParentAircraft);
            filterSelection.ApplyFilter -= filterSelection_ApplyFilter;
            filterSelection.ApplyFilter += filterSelection_ApplyFilter;
            filterSelection.ReloadForDate -= filterSelection_ReloadForDate;
            filterSelection.ReloadForDate += filterSelection_ReloadForDate;

            initialFilter = viewFilter;
            //InitializeComponent();
            UpdateElements();
        }

        #endregion

        #region public ComponentStatusControl(Aircraft currentAircraft, DetailCollectionFilter initialFilter)

        ///<summary>
        /// Создает элемент управления для отображения списка агрегатов
        ///</summary>
        ///<param name="currentAircraft">ВС, содержащее агрегаты</param>
        /// ///<param name="initialFilter">Фильтр отображения</param>
        public ComponentStatusControl(Aircraft currentAircraft, DetailCollectionFilter initialFilter):this()
        {

            if (currentAircraft == null) 
                throw new ArgumentNullException("currentAircraft");
            this.currentAircraft = currentAircraft;          
            HookDetailCollections(currentAircraft);
            HookDetails(currentAircraft.ContainedDetails);
            this.initialFilter = initialFilter;
            filterSelection = new DetailFilterSelection(currentAircraft);
            filterSelection.ApplyFilter -= filterSelection_ApplyFilter;
            filterSelection.ApplyFilter += filterSelection_ApplyFilter;
            filterSelection.ReloadForDate -= filterSelection_ReloadForDate;
            filterSelection.ReloadForDate += filterSelection_ReloadForDate;

            //InitializeComponent();
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
            get { return statusImageLinkLabel.Status; }
            set { statusImageLinkLabel.Status = value; }
        }

        #endregion

        #region public string StatusText

        /// <summary>
        /// Возвращает или устанавливает текст статуса
        /// </summary>
        public string StatusText
        {
            get { return statusImageLinkLabel.Text; }
            set { statusImageLinkLabel.Text = value; }
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

        #region Events

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            panelTopContainer = new Panel();
            panelBottomContainer = new Panel();
            buttonDeleteSelected = new AvButtonT();
            buttonApplyFilter = new AvButtonT();
            buttonAddDetail = new RichReferenceButton();
            footerControl1 = new FooterControl();
            headerControl1 = new HeaderControl();
            aircraftHeaderControl = new AircraftHeaderControl();
            statusImageLinkLabel = new StatusImageLinkLabel();
            labelDate = new Label();
            linkSetDate = new LinkLabel();
            labelTSNCSN = new Label();
            quickSearchControl = new QuickSearchControl();
            labelTotal = new Label();
            panelTopContainer.SuspendLayout();
            headerControl1.SuspendLayout();
            SuspendLayout();

            #region Context menu

            contextMenuStrip1 = new ContextMenuStrip();
            toolStripMenuItemTitle = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemAdd = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemOverhaul = new ToolStripMenuItem();
            toolStripMenuItemInspection = new ToolStripMenuItem();
            toolStripMenuItemShopVisit = new ToolStripMenuItem();
            toolStripMenuItemSetActualState = new ToolStripMenuItem();
            toolStripMenuItemHotSectionInspection = new ToolStripMenuItem();
            toolStripMenuItemPickOffToStore = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[]
                                                 {
                                                     toolStripMenuItemTitle,
                                                     toolStripSeparator1,
                                                     toolStripMenuItemAdd,
                                                     toolStripSeparator2,
                                                     toolStripMenuItemSetActualState,
                                                     toolStripMenuItemOverhaul,
                                                     toolStripMenuItemInspection,
                                                     toolStripMenuItemShopVisit,
                                                     toolStripMenuItemHotSectionInspection,
                                                     toolStripMenuItemPickOffToStore,
                                                     toolStripSeparator3,
                                                     toolStripMenuItemDelete
                                                 });
            contextMenuStrip1.Size = new Size(179, 176);
            // 
            // toolStripMenuItemTitle
            // 
            toolStripMenuItemTitle.Size = new Size(178, 22);
            toolStripMenuItemTitle.Text = "Component";
            toolStripMenuItemTitle.Click += toolStripMenuItemEdit_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Size = new Size(175, 6);
            // 
            // toolStripMenuItemAdd
            // 
            toolStripMenuItemAdd.Size = new Size(178, 22);
            toolStripMenuItemAdd.Text = "Add Component ";
            toolStripMenuItemAdd.Click += toolStripMenuItemAdd_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Size = new Size(175, 6);
            // 
            // toolStripMenuItemOverhaul
            // 
            toolStripMenuItemOverhaul.Size = new Size(178, 22);
            toolStripMenuItemOverhaul.Text = "Register Overhaul";
            toolStripMenuItemOverhaul.Click += toolStripMenuItemOverhaul_Click;
            // 
            // toolStripMenuItemSetActualState
            // 
            toolStripMenuItemSetActualState.Size = new Size(178, 22);
            toolStripMenuItemSetActualState.Text = "Set Actual State";
            toolStripMenuItemSetActualState.Click += toolStripMenuItemSetActualState_Click;
            // 
            // toolStripMenuItemInspection
            // 
            toolStripMenuItemInspection.Size = new Size(178, 22);
            toolStripMenuItemInspection.Text = "Register Inspection";
            toolStripMenuItemInspection.Click += toolStripMenuItemInspection_Click;
            // 
            // toolStripMenuItemHotSectionInspection
            // 
            toolStripMenuItemHotSectionInspection.Size = new Size(178, 22);
            toolStripMenuItemHotSectionInspection.Text = "Register HotSectionInspection";
            toolStripMenuItemHotSectionInspection.Click += toolStripMenuItemHotSectionInspection_Click;
            // 
            // toolStripMenuItemShopVisit
            // 
            toolStripMenuItemShopVisit.Size = new Size(178, 22);
            toolStripMenuItemShopVisit.Text = "Register ShopVisit";
            toolStripMenuItemShopVisit.Click += toolStripMenuItemShopVisit_Click;
            // 
            // toolStripMenuItemPickOffToStore
            // 
            toolStripMenuItemPickOffToStore.Size = new Size(178, 22);
            toolStripMenuItemPickOffToStore.Text = "Pick-off to Store";
            toolStripMenuItemPickOffToStore.Click += toolStripMenuItemPickOffToStore_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(175, 6);
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Size = new Size(178, 22);
            toolStripMenuItemDelete.Text = "Delete";
            toolStripMenuItemDelete.Click += toolStripMenuItemDelete_Click;

            #endregion

            // 
            // panelTopContainer
            // 
            panelTopContainer.AutoSize = true;
            panelTopContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelTopContainer.BackColor = Color.FromArgb(211,211,211);
            panelTopContainer.Controls.Add(labelTotal);
            panelTopContainer.Controls.Add(labelDate);
            panelTopContainer.Controls.Add(linkSetDate);
            panelTopContainer.Controls.Add(labelTSNCSN);
            panelTopContainer.Controls.Add(statusImageLinkLabel);
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
            buttonAddDetail.DisplayerRequested += buttonAddDetail_DisplayerRequested;
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
            buttonDeleteSelected.Click += buttonDeleteSelected_Click;
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
            headerControl1.EditDisplayerRequested += headerControl1_EditDisplayerRequested;
            headerControl1.Location = new Point(0, 0);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new Size(1042, 58);
            headerControl1.TabIndex = 6;
            headerControl1.ContextActionControl.ButtonPrint.DisplayerRequested += PrintButton_DisplayerRequested;
            headerControl1.ReloadRised += headerControl1_ReloadRised;
            headerControl1.ContextActionControl.ButtonHelp.TopicID = "component-status.html";
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
            // statusImageLinkLabel1
            // 
            statusImageLinkLabel.ActiveLinkColor = Color.Black;
            statusImageLinkLabel.Enabled = false;
            statusImageLinkLabel.HoveredLinkColor = Color.Black;
            statusImageLinkLabel.ImageBackColor = Color.Transparent;
            statusImageLinkLabel.ImageLayout = ImageLayout.Center;
            statusImageLinkLabel.LinkColor = Color.DimGray;
            statusImageLinkLabel.LinkMouseCapturedColor = Color.Empty;
            statusImageLinkLabel.Location = new Point(28, 3);
            statusImageLinkLabel.Margin = new Padding(0);
            statusImageLinkLabel.Name = "statusImageLinkLabel";
            statusImageLinkLabel.Size = new Size(412, 27);
            statusImageLinkLabel.TabIndex = 16;
            statusImageLinkLabel.Text = "Component Status";
            statusImageLinkLabel.TextAlign = ContentAlignment.MiddleLeft;
            statusImageLinkLabel.TextFont = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
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
            labelDate.SizeChanged += new EventHandler(labelDate_SizeChanged);
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
            // quickSearchControl
            //
            quickSearchControl.Text = quickSearchDefaultText;
            //
            // labelTotal
            //
            labelTotal.AutoSize = true;
            labelTotal.Font = Css.SmallHeader.Fonts.RegularFont;
            labelTotal.ForeColor = Css.SmallHeader.Colors.ForeColor;
            labelTotal.Dock = DockStyle.Right;
            labelTotal.Name = "labelTotal";
            labelTotal.Padding = new Padding(0, 5, 25, 0);
            labelTotal.Size = new Size(47, 19);
            labelTotal.TabIndex = 21;
            labelTotal.Text = "Total: ";
            //
            // panelBottomContainer
            //
            panelBottomContainer.Dock = DockStyle.Bottom;
            panelBottomContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            panelBottomContainer.Name = "panelBottomContainer";
            panelBottomContainer.Size = new Size(Width, 25);
            panelBottomContainer.Controls.Add(labelTotal);
            panelBottomContainer.Controls.Add(quickSearchControl);
            // 
            // ComponentStatusControl
            // 
            BackColor = Color.FromArgb(241, 241, 241);
            Controls.Add(panelBottomContainer);
            Controls.Add(footerControl1);
            Controls.Add(panelTopContainer);
            Controls.Add(headerControl1);
            Name = "ComponentStatusControl";
            Size = new Size(1042, 616);
            panelTopContainer.ResumeLayout(false);
            panelTopContainer.PerformLayout();
            headerControl1.ResumeLayout(false);
            headerControl1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        #region private void buttonDeleteSelected_Click(object sender, EventArgs e)

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            if ((componentStatusesViewer.SelectedItems == null) && (componentStatusesViewer.SelectedItem == null))
                return;
            DialogResult confirmResult =
                MessageBox.Show(
                    componentStatusesViewer.SelectedItem != null
                        ? "Do you really want to delete component " + componentStatusesViewer.SelectedItem.SerialNumber +
                          "?"
                        : "Do you really want to delete selected components? ", "Confirm delete operation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                IDetailContainer parent = componentStatusesViewer.SelectedItems[0].Parent as IDetailContainer;
                if (parent != null)
                {
                    int count = componentStatusesViewer.SelectedItems.Count;

#if RELEASE
                    try
                    {

#endif
                    List<Detail> selectedItems = new List<Detail>(componentStatusesViewer.SelectedItems);
                        componentStatusesViewer.ItemsListView.BeginUpdate();
                        for (int i = 0; i < count; i++)
                             parent.Remove(selectedItems[i]);
                        componentStatusesViewer.ItemsListView.EndUpdate();

#if RELEASE

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while deleting data" + Environment.NewLine + ex.Message,
                                        (string) new StaticProjectTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

#endif
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

        #region public virtual void UpdateElements()

        /// <summary>
        /// Происходит обновление отображения элементов
        /// </summary>
        public virtual void UpdateElements()
        {
            if (currentAircraft != null)
                statusImageLinkLabel.Text = currentAircraft.RegistrationNumber + ". Component Status";
            else
                statusImageLinkLabel.Text = currentBaseDetail.SerialNumber + ". LLP Disk Sheet Status";
            filterSelection.PageTitle = statusImageLinkLabel.Text;
            Statuses status = Statuses.Satisfactory;
            Detail[] details = DetailSource.ContainedDetails;
            for (int i = 0; i < details.Length; i++)
            {
                Detail detail = details[i];
                if (detail.LimitationCondition == DirectiveConditionState.NotSatisfactory)
                {
                    status = Statuses.NotSatisfactory;
                    break;
                }
                if (detail.LimitationCondition == DirectiveConditionState.Notify)
                    status = Statuses.Notify;
            }
            statusImageLinkLabel.Status = status;
            UpdateHeader();
            ShowDetails();
        }

        #endregion

        #region private void UpdateHeader()

        private void UpdateHeader()
        {
            aircraftHeaderControl.Aircraft = CurrentAircraft;
            aircraftHeaderControl.OperatorClickable = true;
        }

        #endregion

        #region private void headerControl1_ReloadRised(object sender, EventArgs e)

        private void headerControl1_ReloadRised(object sender, EventArgs e)
        {
            ReloadElements();
        }

        #endregion

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

        #region private void headerControl1_EditDisplayerRequested(object sender, ReferenceEventArgs e)

        private void headerControl1_EditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            OnViewEditScreen();
            e.Cancel = true;
        }

        #endregion

        #region private void OnViewEditScreen()

        private void OnViewEditScreen()
        {
            List<Detail> selectedDetails = componentStatusesViewer.SelectedItems;
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

        #region private void buttonAddDetail_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonAddDetail_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredDetailAdding(DetailSource);
            if (currentAircraft != null)
                e.DisplayerText = currentAircraft.RegistrationNumber + ". New Component";
            else
                e.DisplayerText = currentBaseDetail.SerialNumber + ". New Component";
        }

        #endregion

        #region private void ShowDetails()

        private void ShowDetails()
        {
            if (componentStatusesViewer == null)
            {
                if (currentBaseDetail != null)
                    componentStatusesViewer = new ComponentStatusListView(GatherDetails(), currentBaseDetail);
                else
                    componentStatusesViewer = new ComponentStatusListView(GatherDetails(), currentAircraft.AircraftFrame);

                componentStatusesViewer.ContextMenuStrip = contextMenuStrip1;
                componentStatusesViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                componentStatusesViewer.Size =
                    new Size(Width,
                             Height - headerControl1.Height - footerControl1.Height - panelBottomContainer.Height -
                             panelTopContainer.Height);
                componentStatusesViewer.SelectedItemsChanged += componentStatusesViewer_SelectedItemsChanged;
                componentStatusesViewer.ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
                componentStatusesViewer.ItemsListView.KeyPress += ItemsListView_KeyPress;
                componentStatusesViewer.ItemsListView.MouseClick += ItemsListView_MouseClick;
                Controls.Add(componentStatusesViewer);
            }
            else
            {
                componentStatusesViewer.SetItemsArray(GatherDetails());
            }

            labelTotal.Text = "Total: " + componentStatusesViewer.TotalItems;
            labelDate.Text = "Date as of: " + filterSelection.DateSelected.ToString(new StaticProjectTermsProvider()["DateFormat"].ToString());
            if (currentAircraft != null)
                labelTSNCSN.Text = "     " + currentAircraft + " TSN/CSN: " + currentAircraft.Limitation.ResourceSinceNew.ToComplianceItemString();
            else if (currentBaseDetail != null)
                labelTSNCSN.Text = "     " + currentBaseDetail + " TSN/CSN: " + currentBaseDetail.Limitation.ResourceSinceNew.ToComplianceItemString();

            buttonAddDetail.Enabled = permissionForCreate;
            toolStripMenuItemAdd.Enabled = permissionForCreate;
            if (!permissionForUpdate)
            {
                headerControl1.ActionControl.ButtonEdit.TextMain = "View";// ShowEditButton = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Update);
                headerControl1.ActionControl.ButtonEdit.Icon = icons.View;
                headerControl1.ActionControl.ButtonEdit.IconNotEnabled = icons.ViewGray;
            }

            SetContextMenuParameters(componentStatusesViewer.SelectedItems.Count);

            headerControl1.ContextActionControl.ButtonPrint.Enabled = componentStatusesViewer.ItemsListView.Items.Count != 0;
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

        void animatedThreadWorker_WorkFinished(object sender, EventArgs e)
        {
            animatedThreadWorker.StopThread();
            animatedThreadWorker = null;
            dispatcheredMultitabControl.SetEnabledToAllEntityes(true);
            UpdateHeader();
            ShowDetails();
        }

        private void BackgroundComponentStatusScreenReload()
        {
#if RELEASE
            try
            {
#endif
            CurrentAircraft.Reload(true);
#if RELEASE
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading data" + Environment.NewLine + ex.Message,
                                (string) new StaticProjectTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
#endif
        }

        #endregion

        #region private void ReloadForDate(DateTime date)

        private void ReloadForDate(DateTime date, bool provideCurrentData)
        {
            ProxyType detailSource = ((ProxyType) DetailSource);
            if (!provideCurrentData)//todo Исправил !provideCurrentData, по аналогии с DirectiveListControl
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
            labelDate.Text = "Date as of: " + date.ToString(new StaticProjectTermsProvider()["DateFormat"].ToString());
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void PrintButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            DetailListReportBuilder reportBuilder = filterSelection.ReportBuilder;
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            string dateSelected = filterSelection.DateSelected.ToString(new StaticProjectTermsProvider()["DateFormat"].ToString());

            reportBuilder.AddResources(currentAircraft ?? currentBaseDetail.ParentAircraft, componentStatusesViewer.GetItemsArray(), dateSelected);
            e.DisplayerText = filterSelection.ReportBuilder.ReportTitle + ". Report";
            e.RequestedEntity = new DispatcheredDetailListReport(reportBuilder);
        }

        #endregion

        #region private void buttonApplyFilter_Click(object sender, EventArgs e)

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            filterSelection.SetFilterParameters(additionalFilter);
            filterSelection.Show();
            filterSelection.BringToFront();
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
            IFilter[] filters = additionalFilter.Filters;
            componentStatusesViewer.GroupByLandingGearPostionNumbers = false;
            statusImageLinkLabel.Text = TitleOfCurrentDetailSource + ". Component Status";
            for (int i = 0; i < filters.Length; i++)
            {
                if (filters[i] is LandingGearsFilter)
                {
                    componentStatusesViewer.GroupByLandingGearPostionNumbers = true;
                    statusImageLinkLabel.Text = TitleOfCurrentDetailSource + ". Landing Gear Status";
                }
            }
            ShowDetails();
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

            if (componentStatusesViewer != null)
            {
                componentStatusesViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                componentStatusesViewer.Size =
                    new Size(Width,
                             Height - headerControl1.Height - footerControl1.Height - panelTopContainer.Height -
                             panelBottomContainer.Height);
            }
        }

        #endregion

        #region private void componentStatusesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void componentStatusesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            SetContextMenuParameters(e.ItemsCount);

            if (componentStatusesViewer.SelectedItem != null)
                toolStripMenuItemTitle.Text = componentStatusesViewer.SelectedItem.SerialNumber;
            else
                toolStripMenuItemTitle.Text = "Components";
        }

        #endregion

        #region private void SetContextMenuParameters(int count)

        private void SetContextMenuParameters(int count)
        {
            bool permission = DetailRecordsCollection<DetailRecord>.HasAccess(Users.CurrentUser.Role, DataEvent.Create);// && (count == 1); Убрал Сергей Д.
            toolStripMenuItemInspection.Enabled = permission;
            toolStripMenuItemHotSectionInspection.Enabled = permission;
            toolStripMenuItemOverhaul.Enabled = permission;
            toolStripMenuItemShopVisit.Enabled = permission;

            toolStripMenuItemTitle.Enabled = count > 0;

            headerControl1.ActionControl.ButtonEdit.Enabled = (count == 1);
            buttonDeleteSelected.Enabled = permissionForDelete && (count > 0);
            toolStripMenuItemDelete.Enabled = buttonDeleteSelected.Enabled;
        }

        #endregion

        #region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            buttonDeleteSelected_Click(sender, e);
        }

        #endregion

        #region private void toolStripMenuItemEdit_Click(object sender, EventArgs e)

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            OnViewEditScreen();
        }

        #endregion

        #region private void toolStripMenuItemAdd_Click(object sender, EventArgs e)

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            buttonAddDetail_DisplayerRequested(this, arguments);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private void toolStripMenuItemSetActualState_Click(object sender, EventArgs e)

        private void toolStripMenuItemSetActualState_Click(object sender, EventArgs e)
        {
            if (componentStatusesViewer.SelectedItems.Count == 0)
                return;
            FormAddRecord formAddRecords = new FormAddRecord(componentStatusesViewer.SelectedItems, ScreenMode.Add, DetailRecordFormView.ActualData);
            if (formAddRecords.ShowDialog() == DialogResult.OK)
            {
                if (currentBaseDetail != null)
                    currentBaseDetail.LocalReload();
                else 
                    currentAircraft.LocalReload();
            }
            UpdateElements();
        }

        #endregion

        #region protected void OnAddRecord(DetailRecordType recordType)

        /// <summary>
        /// Добавление записи для данного агрегата   
        /// </summary>
        /// <param name="recordType"></param>
        protected void OnAddRecord(DetailRecordType recordType)
        {
            FormAddRecord formAddRecords = new FormAddRecord(componentStatusesViewer.SelectedItems, ScreenMode.Add, DetailRecordFormView.Compliance);
            formAddRecords.WorkType = recordType;
            if (formAddRecords.ShowDialog() == DialogResult.OK)
            {
                if (currentBaseDetail != null)
                    currentBaseDetail.LocalReload();
                else
                    currentAircraft.LocalReload();
            }
            UpdateElements();
        }

        #endregion

        #region private void toolStripMenuItemShopVisit_Click(object sender, EventArgs e)

        private void toolStripMenuItemShopVisit_Click(object sender, EventArgs e)
        {
            OnAddRecord(DetailRecordTypesCollection.Instance.ShopVisitRecordType);
        }

        #endregion

        #region private void toolStripMenuItemHotSectionInspection_Click(object sender, EventArgs e)

        private void toolStripMenuItemHotSectionInspection_Click(object sender, EventArgs e)
        {
            OnAddRecord(DetailRecordTypesCollection.Instance.HotSectionInspectionRecordType);
        }

        #endregion

        #region private void toolStripMenuItemInspection_Click(object sender, EventArgs e)

        private void toolStripMenuItemInspection_Click(object sender, EventArgs e)
        {
            OnAddRecord(DetailRecordTypesCollection.Instance.InspectionRecordType);
        }

        #endregion

        #region private void toolStripMenuItemOverhaul_Click(object sender, EventArgs e)

        private void toolStripMenuItemOverhaul_Click(object sender, EventArgs e)
        {
            OnAddRecord(DetailRecordTypesCollection.Instance.OverhaulRecordType);
        }

        #endregion

        #region private void toolStripMenuItemPickOffToStore_Click(object sender, EventArgs e)

        private void toolStripMenuItemPickOffToStore_Click(object sender, EventArgs e)
        {
            PickOffDetailForm form = new PickOffDetailForm(componentStatusesViewer.SelectedItem);
            if (form.ShowDialog() == DialogResult.OK)
                ShowDetails();
            
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


        #region public void CloseFilter()

        /// <summary>
        /// Закрытие формы выбора фильтра
        /// </summary>
        public void CloseFilter()
        {
            filterSelection.Close();
        }

        #endregion

        #region private void DetailCollection_Removed(object sender, CollectionChangeEventArgs e)

        private void DetailCollection_Removed(object sender, CollectionChangeEventArgs e)
        {
            componentStatusesViewer.DeleteItem((Detail)e.Element);
        }

        #endregion

        #region private void ComponentStatusControl_Saved(object sender, EventArgs e)

        private void ComponentStatusControl_Saved(object sender, EventArgs e)
        {
            componentStatusesViewer.EditItem(detailBeforeSave, (Detail) sender);
        }

        #endregion

        #region private void ComponentStatusControl_Saving(object sender, CancelEventArgs e)

        private void ComponentStatusControl_Saving(object sender, CancelEventArgs e)
        {
            detailBeforeSave = (Detail) sender;
        }

        #endregion

        #region private void ComponentStatusControl_Reloading(object sender, CancelEventArgs e)

        private void ComponentStatusControl_Reloading(object sender, CancelEventArgs e)
        {
            if (!InvokeRequired) 
                detailBeforeReload = (Detail)sender;
        }

        #endregion

        #region private void ComponentStatusControl_Reloaded(object sender, EventArgs e)

        private void ComponentStatusControl_Reloaded(object sender, EventArgs e)
        {
            if (!InvokeRequired) 
                componentStatusesViewer.EditItem(detailBeforeReload, (Detail)sender);
        }

        #endregion


        #region private void DetailCollection_Added(object sender, CollectionChangeEventArgs e)

        private void DetailCollection_Added(object sender, CollectionChangeEventArgs e)
        {
            ShowDetails();
        }

        #endregion

        #region private void ItemsListView_MouseClick(object sender, MouseEventArgs e)

        private void ItemsListView_MouseClick(object sender, MouseEventArgs e)
        {
            clearSearch = true;
        }

        #endregion

        #region private void ItemsListView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void ItemsListView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.F3)
                ItemsListView_KeyPress(sender, new KeyPressEventArgs((char)255));
        }

        #endregion

        #region private void ItemsListView_KeyPress(object sender, KeyPressEventArgs e)

        private void ItemsListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (quickSearchControl.Text == quickSearchDefaultText || clearSearch)
            {
                quickSearchControl.Text = "";
                clearSearch = false;
                searchStartIndex = 0;
            }
            if (e.KeyChar == 8)
            {
                if (quickSearchControl.Text.Length > 0)
                {
                    quickSearchControl.Text = quickSearchControl.Text.Substring(0, quickSearchControl.Text.Length - 1);
                    searchStartIndex = 0;
                    SearchItem(quickSearchControl.Text, searchStartIndex);
                }
            }
            else if (e.KeyChar == 27)
            {
                quickSearchControl.Text = quickSearchDefaultText;
                quickSearchControl.SuccessBackgroundColor = true; 
                searchStartIndex = 0;
            }
            else if (e.KeyChar == 255)
            {
                SearchItem(quickSearchControl.Text, searchStartIndex);
            }
            else if (e.KeyChar != 13)
            {
                quickSearchControl.Text += e.KeyChar;
                searchStartIndex = 0;
                SearchItem(quickSearchControl.Text, searchStartIndex);
            }
            e.Handled = true;
        }

        #endregion

        #region private void SearchItem(string stringToSearch, int startIndex)

        private void SearchItem(string stringToSearch, int startIndex)
        {
            componentStatusesViewer.ItemsListView.SelectedItems.Clear();
            if (searchStartIndex > componentStatusesViewer.ItemsListView.Items.Count - 1)
                return;
            ListViewItem item = componentStatusesViewer.ItemsListView.FindItemWithText(stringToSearch, true, startIndex);
            if (item != null)
            {
                item.Selected = true;
                componentStatusesViewer.ItemsListView.Focus();
                item.EnsureVisible();
                searchStartIndex = componentStatusesViewer.ItemsListView.Items.IndexOf(item) + 1;
                quickSearchControl.SuccessBackgroundColor = true;
            }
            else
            {
                quickSearchControl.SuccessBackgroundColor = false;
            }
        }

        #endregion



        #region private void ComponentStatusControl_InitComplition(object sender, EventArgs e)

        private void ComponentStatusControl_InitComplition(object sender, EventArgs e)
        {
            dispatcheredMultitabControl = (DispatcheredMultitabControl) sender;
            ((DispatcheredMultitabControl)sender).Closed += control_Closed;
            ((AvMultitabControl)sender).Selected += ComponentStatusControl_Selected;
        }

        #endregion
        
        #region private void ComponentStatusControl_Selected(object sender, AvMultitabControlEventArgs e)

        private void ComponentStatusControl_Selected(object sender, AvMultitabControlEventArgs e)
        {
            componentStatusesViewer.ItemsListView.Focus();
        }

        #endregion
        
        #region private void control_Closed(object sender, AvMultitabControlEventArgs e)

        private void control_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == Parent as DispatcheredTabPage)
            {
                UnHookDetails(DetailSource.ContainedDetails);
                if (currentBaseDetail!=null)
                    UnHookDetailCollection(currentBaseDetail.DetailCollection);
                if (currentAircraft!=null)
                    UnHookDetailCollections(currentAircraft);
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

        #region private void UnHookDetailCollections(Aircraft currentAircraft)

        private void UnHookDetailCollections(Aircraft currentAircraft)
        {
            int length = currentAircraft.BaseDetails.Length;
            for (int i = 0; i < length; i++)
            {
                UnHookDetailCollection(currentAircraft.BaseDetails[i].DetailCollection);
            }
        }

        #endregion

        #region private void HookDetailCollections(Aircraft currentAircraft)

        private void HookDetailCollections(Aircraft currentAircraft)
        {
            int length = currentAircraft.BaseDetails.Length;
            for (int i = 0; i < length; i++)
            {
                UnHookDetailCollection(currentAircraft.BaseDetails[i].DetailCollection);
                HookDetailCollection(currentAircraft.BaseDetails[i].DetailCollection);
            }
        }

        #endregion

        #region private void HookDetailCollection(DetailCollection detailCollection)

        private void HookDetailCollection(DetailCollection detailCollection)
        {
            detailCollection.Removed += DetailCollection_Removed;
            detailCollection.Added += DetailCollection_Added;
        }

        #endregion

        #region private void UnHookDetailCollection(DetailCollection detailCollection)

        private void UnHookDetailCollection(DetailCollection detailCollection)
        {
            detailCollection.Removed -= DetailCollection_Removed;
            detailCollection.Added -= DetailCollection_Added;
        }

        #endregion




        #region protected void SetPageEnable(bool isEnable)
        /// <summary>
        /// Set page enable
        /// </summary>
        /// <param name="isEnable"></param>
        protected void SetPageEnable(bool isEnable)
        {
            componentStatusesViewer.Enabled = isEnable;
            panelTopContainer.Enabled = isEnable;
            panelBottomContainer.Enabled = isEnable;
            buttonDeleteSelected.Enabled = isEnable; 
            buttonApplyFilter.Enabled = isEnable;
            buttonAddDetail.Enabled = isEnable;
            footerControl1.Enabled = isEnable;
            headerControl1.Enabled = isEnable;
            aircraftHeaderControl.Enabled = isEnable;
            labelDate.Enabled = isEnable;
            quickSearchControl.Enabled = isEnable;
            labelTotal.Enabled = isEnable;
                
        }
        #endregion



        #endregion


    }
}