using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.Core.Types.ReportFilters;
using CAS.Core.Types.WorkPackages;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.WorkPackages;
using CAS.UI.Properties;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.BiWeekliesReportsControls;
using CAS.UI.UIControls.ComplianceControls;
using CAS.UI.UIControls.DetailsControls;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.WorkPackages;
using CASReports.Builders;
using Controls;
using Controls.AvButtonT;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.MasterListControls
{
    ///<summary>
    /// Элемент управления, отображающий список директив
    ///</summary>
    [ToolboxItem(false)]
    public class AircraftDocumentsScreen : UserControl, IReference
    {
        #region Fields

        protected Aircraft currentAircraft;


        /// <summary>
        /// Текущий отображаемый базовый агрегат
        /// </summary>
        protected BaseDetail currentBaseDetail;

        private AnimatedThreadWorker animatedThreadWorker;

        private readonly DirectiveCollectionFilter viewFilter;
        private DirectiveCollectionFilter additionalFilter = new DirectiveCollectionFilter(new DirectiveFilter[0]);
        private SDList<BaseDetailDirective> directivesViewer;
        private readonly DirectiveFilterSelectionForm filterSelection;
        private DirectiveListReportBuilder reportBuilder;

        private BaseDetailDirective directiveBeforeSaving;
        private BaseDetailDirective directiveBeforeReloading;
        private readonly List<ToolStripMenuItem> toolStripMenuItemsWorkPackages = new List<ToolStripMenuItem>();

        private string reportText;
        private readonly Icons icons = new Icons();


        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem toolStripMenuItemAdd;
        private ToolStripMenuItem toolStripMenuItemView;
        private ToolStripMenuItem toolStripMenuItemPerform;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuItemClose;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem toolStripMenuItemComposeWorkPackage;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private HeaderControl headerControl;
        private FooterControl footerControl;
        private AircraftHeaderControl aircraftHeaderControl;

        /// <summary>
        /// Панель, содержащая кнопки управления
        /// </summary>
        protected Panel panelTopContainer;

        /// <summary>
        /// Панель, содержащая общее количество элементов
        /// </summary>
        // protected Panel panelBottomContainer;
        private AvButtonT buttonApplyFilter;

        private RichReferenceButton buttonAddDirective;
        private AvButtonT buttonDeleteSelected;
        private Label labelDateAsOf;
        private StatusImageLinkLabel labelTitle;
        private LinkLabel linkSetDate;
        private Label labelTSNCSN;


        /// <summary>
        /// Тип директив по умолчанию
        /// </summary>
        private DirectiveType currentDirectiveType;

        private IDisplayer displayer;
        private IDisplayingEntity entity;
        private string displayerText;
        private ReflectionTypes reflectionType;

        private bool permissionForUpdate = true;
        private bool permissionForDelete = true;
        private bool permissionForCreate = true;
        private readonly int LABEL_TSNCSN_LEFT_MARGIN = 20;

        #endregion

        #region Constructors

        #region public AircraftDocumentsScreen(BaseDetail currentBaseDetail, DirectiveCollectionFilter viewFilter, DirectiveType directiveType, string reportText, SDList<BaseDetailDirective> directiveList)

        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список директив
        ///</summary>
        ///<param name="currentBaseDetail">Базовый агрегат, которому принадлежат директивы</param>
        ///<param name="viewFilter">Фильтр</param>
        ///<param name="directiveType"></param>
        ///<param name="reportText">Текст отчета</param>
        ///<param name="directiveList"></param>
        public AircraftDocumentsScreen(BaseDetail currentBaseDetail, DirectiveCollectionFilter viewFilter,
                                       DirectiveType directiveType, string reportText,
                                       SDList<BaseDetailDirective> directiveList)
        {
            if (currentBaseDetail == null)
                throw new ArgumentNullException("currentBaseDetail", "Cannot display null-baseDetail");
            CheckPermission();
            this.currentBaseDetail = currentBaseDetail;
            this.viewFilter = viewFilter;
            CurrentDirectiveType = directiveType;
            this.reportText = reportText;
            HookDirectiveCollection(currentBaseDetail);
            InitializeComponent();
            SetToolStripMenuItems(currentBaseDetail.ParentAircraft);
            InitListView(directiveList);
            filterSelection = new DirectiveFilterSelectionForm(directiveType, null);
            HookWorkPackageEvents(currentBaseDetail.ParentAircraft);
            UpdateElements();
        }

        #endregion

        #region public AircraftDocumentsScreen(Aircraft currentAircraft, DirectiveCollectionFilter viewFilter, DirectiveType directiveType, string reportText, SDList<BaseDetailDirective> directiveList)

        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список директив
        ///</summary>
        ///<param name="currentAircraft">ВС, которому принадлежат директивы</param>
        ///<param name="viewFilter">Фильтр</param>
        ///<param name="directiveType"></param>
        ///<param name="reportText">Текст отчета</param>
        ///<param name="directiveList"></param>
        public AircraftDocumentsScreen(Aircraft currentAircraft, DirectiveCollectionFilter viewFilter,
                                       DirectiveType directiveType, string reportText,
                                       SDList<BaseDetailDirective> directiveList)
        {
            if (currentAircraft == null) throw new ArgumentNullException("currentAircraft");
            CheckPermission();
            this.currentAircraft = currentAircraft;
            this.viewFilter = viewFilter;
            this.reportText = reportText;
            HookDirectiveCollection(currentAircraft);

            InitializeComponent();
            SetToolStripMenuItems(currentAircraft);
            InitListView(directiveList);
            filterSelection = new DirectiveFilterSelectionForm(directiveType, null);
            HookWorkPackageEvents(currentAircraft);
            UpdateElements();
        }

        #endregion

        #endregion

        #region Properties

        #region public DirectiveType CurrentDirectiveType

        /// <summary>
        /// Тип директив по умолчанию
        /// </summary>
        public DirectiveType CurrentDirectiveType
        {
            get { return currentDirectiveType; }
            set { currentDirectiveType = value; }
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
        /// ВС для которого отображаются элементы( базовый агрегат, или все директивы)
        /// </summary>
        public Aircraft CurrentAircraft
        {
            get
            {
                if (currentBaseDetail != null) return currentBaseDetail.ParentAircraft;
                return currentAircraft;
            }
            set
            {
                currentAircraft = value;
                currentBaseDetail = null;
                UpdateElements();
            }
        }

        #endregion

        #region public IDirectiveContainer DirectiveSource

        /// <summary>
        /// Контейнер директив
        /// </summary>
        public IDirectiveContainer DirectiveSource
        {
            get
            {
                if (CurrentBaseDetail != null)
                    return CurrentBaseDetail;
                return CurrentAircraft;
            }
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

        #endregion

        #region public string DisplayerText

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

        #endregion

        #region public ReflectionTypes ReflectionType

        /// <summary>
        /// Type of reflection [:|||:]
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        #endregion

        #region public DirectiveListReportBuilder ReportBuilder

        /// <summary>
        /// Создатель отчетов списка директив
        /// </summary>
        public DirectiveListReportBuilder ReportBuilder
        {
            get { return reportBuilder; }
            set { reportBuilder = value; }
        }

        #endregion

        #region public string ReportText

        /// <summary>
        /// Название отчета
        /// </summary>
        public string ReportText
        {
            get { return reportText; }
            set { reportText = value; }
        }

        #endregion

        #region public DirectiveCollectionFilter AdditionalFilter

        /// <summary>
        /// Примененный фильтр
        /// </summary>
        public DirectiveCollectionFilter AdditionalFilter
        {
            get { return additionalFilter; }
        }

        #endregion

        #region public DirectiveCollectionFilter ViewFilter

        /// <summary>
        /// Изначальный фильтр отображения
        /// </summary>
        public DirectiveCollectionFilter ViewFilter
        {
            get { return viewFilter; }
        }

        #endregion

        #region public ListView ItemsListView

        /// <summary>
        /// Возвращает ListView с директивами
        /// </summary>
        public ListView ItemsListView
        {
            get { return directivesViewer.ItemsListView; }
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
            buttonAddDirective = new RichReferenceButton();
            labelDateAsOf = new Label();
            labelTitle = new StatusImageLinkLabel();
            linkSetDate = new LinkLabel();
            labelTSNCSN = new Label();

            #region Context menu

            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemAdd = new ToolStripMenuItem();
            toolStripMenuItemView = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemPerform = new ToolStripMenuItem();
            toolStripMenuItemClose = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripMenuItemComposeWorkPackage = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(179, 176);
            // 
            // toolStripMenuItemAdd
            // 
            toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            toolStripMenuItemAdd.Size = new Size(178, 22);
            toolStripMenuItemAdd.Text = "Add Directive ";
            toolStripMenuItemAdd.Click += toolStripMenuItemAdd_Click;
            // 
            // toolStripMenuItemView
            // 
            toolStripMenuItemView.Name = "toolStripMenuItemView";
            toolStripMenuItemView.Size = new Size(178, 22);
            toolStripMenuItemView.Text = "Open directives";
            toolStripMenuItemView.Click += toolStripMenuItemView_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(175, 6);
            // 
            // toolStripMenuItemPerform
            // 
            toolStripMenuItemPerform.Name = "toolStripMenuItemPerform";
            toolStripMenuItemPerform.Size = new Size(178, 22);
            toolStripMenuItemPerform.Text = "Register performance";
            toolStripMenuItemPerform.Click += toolStripMenuItemPerform_Click;
            // 
            // toolStripMenuItemClose
            // 
            toolStripMenuItemClose.Name = "toolStripMenuItemClose";
            toolStripMenuItemClose.Size = new Size(178, 22);
            toolStripMenuItemClose.Text = "Close directive";
            toolStripMenuItemClose.Click += toolStripMenuItemClose_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(175, 6);
            //
            // toolStripMenuItemComposeWorkPackage
            //
            toolStripMenuItemComposeWorkPackage.Text = "Compose a work package";
            toolStripMenuItemComposeWorkPackage.Click += ComposeWorkPackageItem_Click;
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            toolStripMenuItemDelete.Size = new Size(178, 22);
            toolStripMenuItemDelete.Text = "Delete";
            toolStripMenuItemDelete.Click += toolStripMenuItemDelete_Click;

            #endregion

            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeaderControl = new AircraftHeaderControl();
            // 
            // panelTopContainer
            // 
            panelTopContainer.AutoSize = true;
            panelTopContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelTopContainer.BackColor = Color.LightGray;
            panelTopContainer.Controls.Add(buttonDeleteSelected);
            panelTopContainer.Controls.Add(buttonApplyFilter);
            panelTopContainer.Controls.Add(buttonAddDirective);
            panelTopContainer.Controls.Add(labelDateAsOf);
            panelTopContainer.Controls.Add(labelTitle);
            panelTopContainer.Controls.Add(linkSetDate);
            panelTopContainer.Controls.Add(labelTSNCSN);
            panelTopContainer.Dock = DockStyle.Top;
            panelTopContainer.Location = new Point(0, 0);
            panelTopContainer.Name = "panelTopContainer";
            panelTopContainer.Size = new Size(1042, 62);
            panelTopContainer.TabIndex = 1;
            // 
            // buttonApplyFilter
            // 
            buttonApplyFilter.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonApplyFilter.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonApplyFilter.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonApplyFilter.Icon = icons.ApplyFilter;
            buttonApplyFilter.Location = new Point(600, 0);
            buttonApplyFilter.Size = new Size(145, 59);
            buttonApplyFilter.TabIndex = 18;
            buttonApplyFilter.TextMain = "Apply filter";
            buttonApplyFilter.Click += ButtonApplyFilter_Click;
            // 
            // buttonAddDirective
            // 
            buttonAddDirective.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonAddDirective.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddDirective.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddDirective.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddDirective.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddDirective.Icon = icons.Add;
            buttonAddDirective.IconNotEnabled = icons.AddGray;
            buttonAddDirective.Location = new Point(770, 0);
            buttonAddDirective.ReflectionType = ReflectionTypes.DisplayInNew;
            buttonAddDirective.Size = new Size(170, 59);
            buttonAddDirective.TabIndex = 19;
            buttonAddDirective.TextAlignMain = ContentAlignment.BottomCenter;
            buttonAddDirective.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddDirective.TextMain = "Add new";
            if (CurrentDirectiveType == DirectiveTypeCollection.Instance.OutOffPhaseDirectiveType)
                buttonAddDirective.TextSecondary = "requirement";
            else
                buttonAddDirective.TextSecondary = "directive";
            buttonAddDirective.DisplayerRequested += ButtonAddDirective_DisplayerRequested;
            // 
            // buttonDeleteSelected
            // 
            buttonDeleteSelected.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonDeleteSelected.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.Click += ButtonDelete_Click;
            buttonDeleteSelected.Icon = icons.Delete;
            buttonDeleteSelected.IconNotEnabled = icons.DeleteGray;
            buttonDeleteSelected.Location = new Point(920, 0);
            buttonDeleteSelected.PaddingSecondary = new Padding(4, 0, 0, 0);
            buttonDeleteSelected.Size = new Size(145, 59);
            buttonDeleteSelected.TabIndex = 20;
            buttonDeleteSelected.TextAlignMain = ContentAlignment.BottomLeft;
            buttonDeleteSelected.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonDeleteSelected.TextMain = "Delete";
            buttonDeleteSelected.TextSecondary = "selected";
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
            // labelDateAsOf
            // 
            labelDateAsOf.AutoSize = true;
            labelDateAsOf.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDateAsOf.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDateAsOf.Location = new Point(57, 30);
            labelDateAsOf.Name = "labelDateAsOf";
            labelDateAsOf.Size = new Size(47, 19);
            labelDateAsOf.TabIndex = 21;
            labelDateAsOf.Text = "Date as of: ";
            labelDateAsOf.SizeChanged += labelDateAsOf_SizeChanged;
            // 
            // linkSetDate
            // 
            linkSetDate.AutoSize = true;
            linkSetDate.Font = Css.SimpleLink.Fonts.Font;
            linkSetDate.ForeColor = Css.SimpleLink.Colors.LinkColor;
            linkSetDate.Location = new Point(labelDateAsOf.Right, labelDateAsOf.Top);
            linkSetDate.Text = "Set date";
            linkSetDate.LinkClicked += ButtonApplyFilter_Click;
            linkSetDate.SizeChanged += linkSetDate_SizeChanged;
            linkSetDate.LocationChanged += linkSetDate_SizeChanged;
            // 
            // labelTSNCSN
            // 
            labelTSNCSN.AutoSize = true;
            labelTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelTSNCSN.Location = new Point(linkSetDate.Right + LABEL_TSNCSN_LEFT_MARGIN, labelDateAsOf.Top);
            // 
            // footerControl
            // 
            footerControl.AutoSize = true;
            footerControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            footerControl.BackColor = Color.Transparent;
            footerControl.Dock = DockStyle.Bottom;
            footerControl.Location = new Point(0, 568);
            footerControl.Margin = new Padding(0);
            footerControl.MaximumSize = new Size(0, 48);
            footerControl.MinimumSize = new Size(0, 48);
            footerControl.Name = "footerControl";
            footerControl.Size = new Size(1042, 48);
            footerControl.TabIndex = 4;
            // 
            // headerControl
            // 
            headerControl.ActionControlSplitterVisible = true;

            headerControl.BackColor = Color.Transparent;
            headerControl.BackgroundImage = Resources.HeaderBar;
            headerControl.Controls.Add(aircraftHeaderControl);
            headerControl.Dock = DockStyle.Top;
            headerControl.EditDisplayerText = "Edit operator";
            headerControl.ContextActionControl.ShowPrintButton = true;
            headerControl.ContextActionControl.ButtonPrint.DisplayerRequested += ButtonPrint_DisplayerRequested;
            headerControl.EditReflectionType = ReflectionTypes.DisplayInNew;
            headerControl.Location = new Point(0, 0);
            headerControl.Size = new Size(1042, 58);
            headerControl.TabIndex = 0;
            headerControl.EditDisplayerRequested += ButtonEdit_DisplayerRequested;
            headerControl.ReloadRised += ButtonReload_Click;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "directives_aircraft_operations";
            if (!permissionForUpdate)
            {
                headerControl.ActionControl.ButtonEdit.TextMain = "View";
                headerControl.ActionControl.ButtonEdit.Icon = icons.View;
                headerControl.ActionControl.ButtonEdit.IconNotEnabled = icons.ViewGray;
            }
            // 
            // aircraftHeaderControl
            // 
            aircraftHeaderControl.AircraftClickable = true;
            aircraftHeaderControl.BackColor = Color.Transparent;
            aircraftHeaderControl.Location = new Point(0, 0);
            aircraftHeaderControl.Name = "aircraftHeaderControl";
            aircraftHeaderControl.OperatorClickable = true;
            aircraftHeaderControl.Size = new Size(381, 58);
            // 
            // DirectiveListViewer
            // 
            AutoScroll = true;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(panelTopContainer);
            Controls.Add(footerControl);
            Controls.Add(headerControl);
        }

        #endregion

        #region private void SetToolStripMenuItems(Aircraft aircraft)

        private void SetToolStripMenuItems(Aircraft aircraft)
        {
            contextMenuStrip.Items.Clear();
            toolStripMenuItemsWorkPackages.Clear();
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    toolStripMenuItemView,
                                                    toolStripMenuItemAdd,
                                                    toolStripSeparator2,
                                                    toolStripMenuItemPerform,
                                                    toolStripMenuItemClose,
                                                    toolStripSeparator3
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
                contextMenuStrip.Items.Add(item);
            }

            contextMenuStrip.Items.AddRange(
                new ToolStripItem[]
                    {toolStripMenuItemComposeWorkPackage, toolStripSeparator4, toolStripMenuItemDelete});
        }

        #endregion

        #region private void UpdateHeader()

        private void UpdateHeader()
        {
            aircraftHeaderControl.Aircraft = CurrentAircraft;
        }

        #endregion

        #region protected virtual void ReloadElements()

        /// <summary>
        /// Происходит перезагрузка элементов и синхронизация с базой данных
        /// </summary>
        protected virtual void ReloadElements()
        {
            if (animatedThreadWorker == null)
            {
                animatedThreadWorker = new AnimatedThreadWorker(BackgroundDirectiveSourceReload, this);
                animatedThreadWorker.State = "Reloading directives";
                animatedThreadWorker.WorkFinished += animatedThreadWorker_WorkFinished;
                if (BackgroundWorkStart != null)
                    BackgroundWorkStart(this, new EventArgs());
                animatedThreadWorker.StartThread();
            }
        }

        #endregion

        #region private void BackgroundDirectiveSourceReload()

        private void BackgroundDirectiveSourceReload()
        {

            try
            {
                if (DirectiveSource != null)
                    ((CoreType) DirectiveSource).Reload(true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }
            UpdateElements();
        }

        #endregion

        #region private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)

        private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)
        {
            animatedThreadWorker.StopThread();
            animatedThreadWorker = null;
            if (BackgroundWorkEnd != null)
                BackgroundWorkEnd(this, new EventArgs());
            UpdateElements();
        }

        #endregion

        #region private void InitListView(SDList<BaseDetailDirective> directiveList)

        private void InitListView(SDList<BaseDetailDirective> directiveList)
        {
            directivesViewer = directiveList;
            directivesViewer.TabIndex = 2;
            directivesViewer.ItemsListView.ContextMenuStrip = contextMenuStrip;
            directivesViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
            directivesViewer.SelectedItemsChanged += directivesViewer_SelectedItemsChanged;
            Controls.Add(directivesViewer);
        }

        #endregion

        #region public override void UpdateElements()

        /// <summary>
        /// Происзодит обновление отображения элементов
        /// </summary>
        public void UpdateElements()
        {
            if (currentAircraft != null)
            {
                labelTitle.Text = currentAircraft.RegistrationNumber + ". " + reportText;
                filterSelection.PageTitle = labelTitle.Text;
            }
            else if (currentBaseDetail != null)
            {
                labelTitle.Text = currentBaseDetail + ". " + reportText;
                filterSelection.PageTitle = labelTitle.Text;
            }
            else
            {
                labelTitle.Text = reportText;
                labelTitle.Status = Statuses.NotActive;
            }


            UpdateHeader();
            UpdateDirectives();
        }

        #endregion

        #region private void UpdateDirectives()

        private void UpdateDirectives()
        {
 /*           BaseDetailDirective[] directiveArray = GatherDirectives();

            HookDirectives(directiveArray);
            directivesViewer.SetItemsArray(directiveArray);

            labelDateAsOf.Text = "Date as of: " +
                                 filterSelection.DateSelected.ToString(new TermsProvider()["DateFormat"].ToString());
            if (currentAircraft != null)
                labelTSNCSN.Text = "     " + currentAircraft + " TSN/CSN: " +
                                   currentAircraft.Limitation.ResourceSinceNew.ToComplianceItemString();
            else if (currentBaseDetail != null)
                labelTSNCSN.Text = "     " + currentBaseDetail + " TSN/CSN: " +
                                   currentBaseDetail.Limitation.ResourceSinceNew.ToComplianceItemString();

            CheckContextMenu(directivesViewer.SelectedItems.Count);

            buttonAddDirective.Enabled = permissionForCreate;
            toolStripMenuItemAdd.Enabled = buttonAddDirective.Enabled;

            headerControl.ContextActionControl.ButtonPrint.Enabled = directivesViewer.ItemsListView.Items.Count != 0;*/
        }

        #endregion

        #region private void ComposeWorkPackage(Aircraft aircraft)

        private void ComposeWorkPackage(Aircraft aircraft)
        {
            bool exclamation = false;
            for (int i = 0; i < directivesViewer.SelectedItems.Count; i++)
            {
                if (directivesViewer.SelectedItems[i].Closed)
                {
                    exclamation = true;
                    break;
                }
            }
            if (exclamation)
            {
                if (MessageBox.Show(
                        "Closed directives will not be added to the work package." + Environment.NewLine + "Continue?",
                        new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return;
            }
            WorkPackage workPackage = new WorkPackage();
            workPackage.Title = aircraft.GetNewWorkPackageTitle();

            try
            {
                aircraft.AddWorkPackage(workPackage);
                for (int i = 0; i < directivesViewer.SelectedItems.Count; i++)
                    if (!(directivesViewer.SelectedItems[i].Closed)) workPackage.AddItem(directivesViewer.SelectedItems[i]);
                if (MessageBox.Show(
                        "Work Package " + workPackage.Title + " created successfully." + Environment.NewLine +
                        "Open work package screen?",
                        new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    OnDisplayerRequested(
                        new ReferenceEventArgs(new DispatcheredWorkPackageScreen(workPackage), ReflectionTypes.DisplayInNew,
                                               aircraft.RegistrationNumber + ". " + workPackage.Title));
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while creating work package", ex);
            }
        }

        #endregion

        #region private void AddItemsToWorkPackage(WorkPackage workPackage)

        private void AddItemsToWorkPackage(WorkPackage workPackage)
        {
            try
            {
                bool exclamation = false;
                for (int i = 0; i < directivesViewer.SelectedItems.Count; i++)
                {
                    if (workPackage.Directives.Contains(directivesViewer.SelectedItems[i]) ||
                        directivesViewer.SelectedItems[i].Closed)
                    {
                        exclamation = true;
                        break;
                    }
                }
                if (exclamation)
                {
                    if (MessageBox.Show(
                            "Some directives will not be added to a work package." + Environment.NewLine + "Continue?",
                            new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                        return;
                }
                int directiveAdded = 0;
                for (int i = 0; i < directivesViewer.SelectedItems.Count; i++)
                {
                    if (!(directivesViewer.SelectedItems[i].Closed) &&
                        !workPackage.Directives.Contains(directivesViewer.SelectedItems[i]))
                    {
                        workPackage.AddItem(directivesViewer.SelectedItems[i]);
                        directiveAdded++;
                    }
                }
                string message = directiveAdded == 1 ? "Directive added successfully" : "Directives added successfully";
                if (
                    MessageBox.Show(message + ". Open work package screen?", new TermsProvider()["SystemName"].ToString(),
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    OnDisplayerRequested(
                        new ReferenceEventArgs(new DispatcheredWorkPackageScreen(workPackage), ReflectionTypes.DisplayInNew,
                                               currentAircraft == null
                                                   ? currentBaseDetail.ParentAircraft.RegistrationNumber
                                                   : currentAircraft.RegistrationNumber + ". " + workPackage.Title));
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while adding items to work package", ex);
            }
        }

        #endregion

        #region private Statuses GetStatus(BaseDetailDirective[] directives)

        /// <summary>
        /// Возвращает общий статус, по массиву директив
        /// </summary>
        /// <param name="directives"></param>
        /// <returns></returns>
        private Statuses GetStatus(BaseDetailDirective[] directives)
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

        #region private Statuses GetStatus(BaseDetailDirective directive)

        private Statuses GetStatus(BaseDetailDirective directive)
        {
            if (directive.Condition == DirectiveConditionState.NotSatisfactory)
            {
                return Statuses.NotSatisfactory;
            }
            if (directive.Condition == DirectiveConditionState.Notify)
            {
                return Statuses.Notify;
            }
            return Statuses.Satisfactory;
        }

        #endregion

        #region private void CheckPermission()

        private void CheckPermission()
        {
            permissionForCreate = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            permissionForDelete = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Remove);
            permissionForUpdate = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Update);
        }

        #endregion

        #region private BaseDetailDirective[] GatherDirectives()

        private BaseDetailDirective[] GatherDirectives()
        {
            return GatherDirectives(additionalFilter);
        }

        #endregion

        #region private BaseDetailDirective[] GatherDirectives(DirectiveCollectionFilter _additionalFilter)

        private BaseDetailDirective[] GatherDirectives(DirectiveCollectionFilter _additionalFilter)
        {
            List<DirectiveFilter> filters = new List<DirectiveFilter>(viewFilter.Filters);
            if (_additionalFilter != null)
                filters.AddRange(_additionalFilter.Filters);
            DirectiveCollectionFilter filter =
                new DirectiveCollectionFilter(DirectiveSource.ContainedDirectives, filters.ToArray());
            BaseDetailDirective[] directives = filter.GatherDirectives();
            labelTitle.Status = GetStatus(directives);
            return directives;
        }

        #endregion

        #region private BaseDetailDirective[] GatherBaseDetailDirectives()

        private BaseDetailDirective[] GatherBaseDetailDirectives()
        {
            return GatherBaseDetailDirectives(additionalFilter);
        }

        #endregion

        #region private BaseDetailDirective[] GatherBaseDetailDirectives(DirectiveCollectionFilter _additionalFilter)

        private BaseDetailDirective[] GatherBaseDetailDirectives(DirectiveCollectionFilter _additionalFilter)
        {
            BaseDetailDirective[] directives = GatherDirectives(_additionalFilter);
            List<BaseDetailDirective> baseDtailDirectives = new List<BaseDetailDirective>(directives.Length);
            for (int i = 0; i < directives.Length; i++)
            {
                baseDtailDirectives.Add(directives[i]);
            }
            return baseDtailDirectives.ToArray();
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
            if (directivesViewer.SelectedItem == null)
                return;
            string regNumber = "";
            if (directivesViewer.SelectedItem.Parent is AircraftFrame)
                regNumber = directivesViewer.SelectedItem.Parent.ToString();
            else
            {
                if ((directivesViewer.SelectedItem.Parent).Parent is Aircraft)
                    regNumber = ((Aircraft) ((directivesViewer.SelectedItem.Parent).Parent)).RegistrationNumber + ". " +
                                directivesViewer.SelectedItem.Parent;
            }
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = regNumber + ". " + directivesViewer.SelectedItem.DirectiveType.CommonName + ". " +
                              directivesViewer.SelectedItem.Title;
            e.RequestedEntity = new DispatcheredDirectiveScreen(directivesViewer.SelectedItem);
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (currentAircraft != null)
                e.DisplayerText = currentAircraft.RegistrationNumber + ". " + ReportText + " Report";
            else if (currentBaseDetail != null)
                e.DisplayerText = currentBaseDetail + ". " + ReportText + " Report";
            else
                e.DisplayerText = ReportText + " Report";
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            reportBuilder.DateAsOf = filterSelection.DateSelected.ToString(new TermsProvider()["DateFormat"].ToString());
            BaseDetailDirective[] filteredBaseDetailDirectives = GatherBaseDetailDirectives();
            BaseDetailDirective[] notFilteredDirectives = GatherBaseDetailDirectives(null);
            if (currentAircraft != null)
            {
                //reportBuilder.LifelengthAircraftSinceNew = CurrentAircraft.Limitation.ResourceSinceNew;
                //reportBuilder.LifelengthAircraftSinceOverhaul = CurrentAircraft.Limitation.ResourceSinceOverhaul;

                if (filteredBaseDetailDirectives.Length != notFilteredDirectives.Length)
                    reportBuilder.IsFiltered = true;
                reportBuilder.ReportedAircraft = CurrentAircraft;
                e.RequestedEntity = new DispatcheredDirectiveListReport(directivesViewer.GetItemsArray(), reportBuilder);
            }
            else
            {
                if (currentBaseDetail != null)
                {
                    /*    CurrentAircraft.DateAsOf = filterSelection.DateSelected;
                    CurrentAircraft.ProvideCurrentData = false;*/
                    //todo

                    //reportBuilder.LifelengthAircraftSinceNew = CurrentAircraft.Limitation.ResourceSinceNew;
                    reportBuilder.LifelengthAircraftSinceNew =
                        CurrentAircraft.GetLifelength(filterSelection.DateSelected);
                    //reportBuilder.LifelengthAircraftSinceOverhaul = CurrentAircraft.Limitation.ResourceSinceOverhaul;


                    if (filteredBaseDetailDirectives.Length != notFilteredDirectives.Length)
                        reportBuilder.IsFiltered = true;
                    reportBuilder.ReportedBaseDetail = currentBaseDetail;
                    e.RequestedEntity =
                        new DispatcheredDirectiveListReport(directivesViewer.GetItemsArray(), reportBuilder);
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region private void ButtonApplyFilter_Click(object sender, EventArgs e)

        private void ButtonApplyFilter_Click(object sender, EventArgs e)
        {
            filterSelection.PageTitle = labelTitle.Text;
            filterSelection.SetFilterParameters(additionalFilter);
            filterSelection.Show();
            filterSelection.BringToFront();
            filterSelection.ReloadForDate -= filterSelection_ReloadForDate;
            filterSelection.ApplyFilter -= filterSelection_ApplyFilter;
            filterSelection.ReloadForDate += filterSelection_ReloadForDate;
            filterSelection.ApplyFilter += filterSelection_ApplyFilter;
        }

        #endregion

        #region private void ButtonAddDirective_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonAddDirective_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = CurrentAircraft.RegistrationNumber;
            if (!(currentBaseDetail is AircraftFrame) && currentBaseDetail != null)
                e.DisplayerText += ". " + currentBaseDetail;
            e.DisplayerText += ". " + CurrentDirectiveType.CommonName + ". New Directive";
            if (CurrentBaseDetail != null)
            {
                if (currentDirectiveType == DirectiveTypeCollection.Instance.OutOffPhaseDirectiveType)
                    e.RequestedEntity = new DispatcheredOutOffPhaseReferencAdding(CurrentBaseDetail);
                else if (currentDirectiveType == DirectiveTypeCollection.Instance.CPCPDirectiveType)
                    e.RequestedEntity = new DispatcheredCPCPDirectiveAddingScreen(CurrentBaseDetail);
                else if (currentDirectiveType == DirectiveTypeCollection.Instance.DamageRequiringInspectionDirectiveType)
                    e.RequestedEntity = new DispatcheredDamageDirectiveAddingScreen(CurrentBaseDetail);
                else
                    e.RequestedEntity = new DispatcheredDirectiveAddingScreen(CurrentBaseDetail, currentDirectiveType);
            }
            else
            {
                if (currentDirectiveType == DirectiveTypeCollection.Instance.OutOffPhaseDirectiveType)
                    e.RequestedEntity = new DispatcheredOutOffPhaseReferencAdding(CurrentAircraft);
                else if (currentDirectiveType == DirectiveTypeCollection.Instance.CPCPDirectiveType)
                    e.RequestedEntity = new DispatcheredCPCPDirectiveAddingScreen(CurrentAircraft);
                else if (currentDirectiveType == DirectiveTypeCollection.Instance.DamageRequiringInspectionDirectiveType)
                    e.RequestedEntity = new DispatcheredDamageDirectiveAddingScreen(CurrentAircraft);
                else
                    e.RequestedEntity = new DispatcheredDirectiveAddingScreen(CurrentAircraft, currentDirectiveType);
            }
        }

        #endregion

        #region private void ButtonDelete_Click(object sender, EventArgs e)

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if ((directivesViewer.SelectedItems == null) && (directivesViewer.SelectedItem == null)) return;
            DialogResult confirmResult =
                MessageBox.Show(
                    directivesViewer.SelectedItem != null
                        ? "Do you really want to delete directive " + directivesViewer.SelectedItem.Title + "?"
                        : "Do you really want to delete selected directives? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                IDirectiveContainer parent = directivesViewer.SelectedItems[0].Parent as IDirectiveContainer;
                if (parent != null)
                {
                    int count = directivesViewer.SelectedItems.Count;

                    List<BaseDetailDirective> selectedItems =
                        new List<BaseDetailDirective>(directivesViewer.SelectedItems);
                    directivesViewer.ItemsListView.BeginUpdate();
                    for (int i = 0; i < count; i++)
                    {
                        try
                        {
                            parent.Remove(selectedItems[i]);
                        }
                        catch (Exception ex)
                        {
                            Program.Provider.Logger.Log("Error while deleting data", ex); 
                            return;
                        }
                    }
                    directivesViewer.ItemsListView.EndUpdate();
                    //ReloadElements();
                }
                else
                {
                    MessageBox.Show("Failed to delete directive: Parent container is invalid", "Operation failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region private void filterSelection_ReloadForDate(object sender, EventArgs e)

        private void filterSelection_ReloadForDate(object sender, EventArgs e)
        {
            ProxyType detailSource = ((ProxyType) DirectiveSource);
            if (!filterSelection.ReloadAsDateOf)
            {
                if (detailSource.ProvideCurrentData)
                    return;
                detailSource = detailSource.CloneForCurrentData();
            }
            else
            {
                if (detailSource.DateAsOf != filterSelection.DateSelected || !detailSource.ProvideCurrentData)
                    detailSource = detailSource.CloneAsDateOf(filterSelection.DateSelected);
                else
                    return;
            }
            if (detailSource is Aircraft)
                CurrentAircraft = detailSource as Aircraft;
            if (detailSource is BaseDetail)
                CurrentBaseDetail = detailSource as BaseDetail;
            UpdateDirectives();
        }

        #endregion

        #region private void filterSelection_ApplyFilter(DirectiveCollectionFilter filter)

        private void filterSelection_ApplyFilter(DirectiveCollectionFilter filter)
        {
            additionalFilter = filter;
            UpdateDirectives();
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

        #region private void directivesViewer_SelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)

        private void directivesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            CheckContextMenu(e.ItemsCount);
        }

        #endregion

        #region private void toolStripMenuItemView_Click(object sender, EventArgs e)

        private void toolStripMenuItemView_Click(object sender, EventArgs e)
        {
            OnOpenDirectives();
        }

        #endregion

        #region private void toolStripMenuItemPerform_Click(object sender, EventArgs e)

        private void toolStripMenuItemPerform_Click(object sender, EventArgs e)
        {
            if (directivesViewer.SelectedItem != null)
                OnAddRecord(RecordTypesCollection.Instance.DirectivePerformanceRecordType);
        }

        #endregion

        #region private void toolStripMenuItemClose_Click(object sender, EventArgs e)

        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            if (directivesViewer.SelectedItem != null)
                OnAddRecord(RecordTypesCollection.Instance.DirectiveClosingRecordType);
        }

        #endregion

        #region private void toolStripMenuItemAdd_Click(object sender, EventArgs e)

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs argumetns = new ReferenceEventArgs();
            ButtonAddDirective_DisplayerRequested(this, argumetns);
            OnDisplayerRequested(argumetns);
        }

        #endregion

        #region private void WorkPackageItem_Click(object sender, EventArgs e)

        private void WorkPackageItem_Click(object sender, EventArgs e)
        {
            WorkPackage workPackage = (WorkPackage) ((ToolStripMenuItem) sender).Tag;
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

        #region private void OnOpenDirectives()

        private void OnOpenDirectives()
        {
            List<BaseDetailDirective> selected = directivesViewer.SelectedItems;

            for (int i = 0; i < selected.Count; i++)
            {
                ReferenceEventArgs e = new ReferenceEventArgs();
                string regNumber = "";
                if (selected[i].Parent is AircraftFrame)
                    regNumber = selected[i].Parent.ToString();
                else
                {
                    if ((selected[i].Parent).Parent is Aircraft)
                        regNumber = ((Aircraft) ((selected[i].Parent).Parent)).RegistrationNumber + ". " +
                                    selected[i].Parent;
                }
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = regNumber + ". " + selected[i].DirectiveType.CommonName + ". " + selected[i].Title;
                e.RequestedEntity = new DispatcheredDirectiveScreen(selected[i]);
            }
        }

        #endregion

        #region protected void OnAddRecord(RecordType recordType)

        /// <summary>
        /// Добавление записи для данной дuрективы
        /// </summary>
        protected void OnAddRecord(RecordType recordType)
        {
            ComplianceForm form = new ComplianceForm(directivesViewer.SelectedItem);
            form.RecordType = RecordTypesCollection.Instance.DirectivePerformanceRecordType;
            if (form.ShowDialog() == DialogResult.OK)
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

        #region private void CheckContextMenu(int count)

        private void CheckContextMenu(int count)
        {
            headerControl.ActionControl.ButtonEdit.Enabled = (count == 1);
            buttonDeleteSelected.Enabled = (count > 0) && permissionForDelete;

            toolStripMenuItemDelete.Enabled = buttonDeleteSelected.Enabled;
            toolStripMenuItemView.Enabled = count > 0;
            toolStripMenuItemPerform.Enabled = (count == 1) && permissionForCreate;
            toolStripMenuItemClose.Enabled = toolStripMenuItemPerform.Enabled;
            toolStripMenuItemComposeWorkPackage.Enabled = count > 0 && permissionForUpdate;
            for (int i = 0; i < toolStripMenuItemsWorkPackages.Count; i++)
                toolStripMenuItemsWorkPackages[i].Enabled = count > 0 && permissionForUpdate;

            if (count == 1)
            {
                toolStripMenuItemView.Text = "Go to " + directivesViewer.SelectedItems[0].Title;
            }
            else
            {
                if (count == 0)
                    toolStripMenuItemView.Text = "Nothing selected";
                else
                    toolStripMenuItemView.Text = "Open directives";
            }
        }

        #endregion

        #region private void HookDirectiveCollection(BaseDetail baseDetail)

        private void HookDirectiveCollection(IDetailDirectiveContainer baseDetail)
        {
            baseDetail.DirectiveRemoved += currentBaseDetail_DirectiveRemoved;
            baseDetail.DirectiveAdded += currentBaseDetail_DirectiveAdded;
        }

        #endregion

        #region public void UnHookDirectiveCollection(IDetailDirectiveContainer baseDetail)

        /// <summary>
        /// Отписывает события добавления и удаления директив
        /// </summary>
        /// <param name="baseDetail"></param>
        public void UnHookDirectiveCollection(IDetailDirectiveContainer baseDetail)
        {
            baseDetail.DirectiveRemoved -= currentBaseDetail_DirectiveRemoved;
            baseDetail.DirectiveAdded -= currentBaseDetail_DirectiveAdded;
        }

        #endregion

        #region private void HookDirectives(BaseDetailDirective[] directivesArray)

        private void HookDirectives(BaseDetailDirective[] directivesArray)
        {
            int length = directivesArray.Length;
            for (int j = 0; j < length; j++)
            {
                HookDirective(directivesArray[j]);
            }
        }

        #endregion

        #region private void HookDirective(BaseDetailDirective directive )

        private void HookDirective(BaseDetailDirective directive)
        {
            UnHookDirective(directive);
            directive.Saving += DirectiveListControl_Saving;
            directive.Saved += DirectiveListControl_Saved;
            directive.Reloading += directive_Reloading;
            directive.Reloaded += directive_Reloaded;
        }

        #endregion

        #region public void UnHookDirectives()

        /// <summary>
        /// Отписка событий Saving, Saved, Reloaded & Reloading
        /// </summary>
        public void UnHookDirectives()
        {
            BaseDetailDirective[] directives = DirectiveSource.ContainedDirectives;
            int length = directives.Length;
            for (int i = 0; i < length; i++)
            {
                UnHookDirective(directives[i]);
            }
        }

        #endregion

        #region private void UnHookDirective(BaseDetailDirective directive)

        private void UnHookDirective(BaseDetailDirective directive)
        {
            directive.Saved -= DirectiveListControl_Saved;
            directive.Saving -= DirectiveListControl_Saving;
            directive.Reloading -= directive_Reloading;
            directive.Reloaded -= directive_Reloaded;
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

        /// <summary>
        /// Отписывает события добавления и удаления рабочих пакетов
        /// </summary>
        /// <param name="aircraft"></param>
        public void UnHookWorkPackageEvents(Aircraft aircraft)
        {
            aircraft.WorkPackageAdded -= CurrentAircraft_WorkPackagesChanged;
            aircraft.WorkPackageRemoved -= CurrentAircraft_WorkPackagesChanged;
        }

        #endregion

        #region private void currentBaseDetail_DirectiveRemoved(object sender, EventArgs e)

        private void currentBaseDetail_DirectiveRemoved(object sender, CollectionChangeEventArgs e)
        {
            if (e.Element is BaseDetailDirective) directivesViewer.DeleteItem((BaseDetailDirective) e.Element);
        }

        #endregion

        #region private void currentBaseDetail_DirectiveAdded(object sender, EventArgs e)

        private void currentBaseDetail_DirectiveAdded(object sender, CollectionChangeEventArgs e)
        {
            if (!(e.Element is BaseDetailDirective)) return;
            directivesViewer.AddNewItem((BaseDetailDirective) e.Element);
            GatherDirectives();
            HookDirective((BaseDetailDirective) e.Element);
        }

        #endregion

        #region private void DirectiveListScreen_Saving(object sender, CancelEventArgs e)

        private void DirectiveListControl_Saving(object sender, CancelEventArgs e)
        {
            directiveBeforeSaving = (BaseDetailDirective) sender;
        }

        #endregion

        #region private void DirectiveListScreen_Saved(object sender, EventArgs e)

        private void DirectiveListControl_Saved(object sender, EventArgs e)
        {
            directivesViewer.EditItem(directiveBeforeSaving, (BaseDetailDirective) sender);
            GatherDirectives();
        }

        #endregion

        #region private void directive_Reloading(object sender, CancelEventArgs e)

        private void directive_Reloading(object sender, CancelEventArgs e)
        {
            if (!InvokeRequired) directiveBeforeReloading = (BaseDetailDirective) sender;
        }

        #endregion

        #region private void directive_Reloaded(object sender, EventArgs e)

        private void directive_Reloaded(object sender, EventArgs e)
        {
            if (!InvokeRequired)
            {
                directivesViewer.EditItem(directiveBeforeReloading, (BaseDetailDirective) sender);
            }
        }

        #endregion

        #region private void CurrentAircraft_WorkPackagesChanged(object sender, CollectionChangeEventArgs e)

        private void CurrentAircraft_WorkPackagesChanged(object sender, CollectionChangeEventArgs e)
        {
            SetToolStripMenuItems((Aircraft) sender);
        }

        #endregion

        #region public void SetPageEnable(bool enable)

        /// <summary>
        /// Set page enable
        /// </summary>
        /// <param name="enable"></param>
        public void SetPageEnable(bool enable)
        {
            panelTopContainer.Enabled = enable;
            //panelBottomContainer.Enabled = enable;
            buttonDeleteSelected.Enabled = enable;
            buttonApplyFilter.Enabled = enable;
            buttonAddDirective.Enabled = enable;
            labelDateAsOf.Enabled = enable;
            //labelTotal.Enabled = enable;
            //quickSearchControl.Enabled = enable;//todo
            linkSetDate.Enabled = enable;
            labelTSNCSN.Enabled = enable;
            directivesViewer.Enabled = enable;
            headerControl.Enabled = enable;
            footerControl.Enabled = enable;
            aircraftHeaderControl.Enabled = enable;
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
            if (buttonAddDirective != null)
                buttonAddDirective.Location = new Point(buttonDeleteSelected.Left - buttonAddDirective.Width - 5, 0);
            if (buttonApplyFilter != null)
                buttonApplyFilter.Location = new Point(buttonAddDirective.Left - buttonApplyFilter.Width - 5, 0);

            if (directivesViewer != null)
            {
                directivesViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                directivesViewer.Size =
                    new Size(Width,
                             Height - headerControl.Height - footerControl.Height - // panelBottomContainer.Height -
                             panelTopContainer.Height);
            }
        }

        #endregion

        #region private void labelDateAsOf_SizeChanged(object sender, EventArgs e)

        private void labelDateAsOf_SizeChanged(object sender, EventArgs e)
        {
            linkSetDate.Location = new Point(labelDateAsOf.Right, labelDateAsOf.Top);
        }

        #endregion

        #region private void linkSetDate_SizeChanged(object sender, EventArgs e)

        private void linkSetDate_SizeChanged(object sender, EventArgs e)
        {
            labelTSNCSN.Location = new Point(linkSetDate.Right + LABEL_TSNCSN_LEFT_MARGIN, labelDateAsOf.Top);
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

        /// <summary>
        /// Событие повествующие о начале работы алгоритма в другом потоке
        /// </summary>
        public event EventHandler BackgroundWorkStart;

        /// <summary>
        /// Событие повествующие о конце работы алгоритма в другом потоке
        /// </summary>
        public event EventHandler BackgroundWorkEnd;

        #endregion
    }
}