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
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.ComponentChangeControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DiscrepanciesControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.EngineeringOrdersDirectives;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.MaintenanceStatusControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.WorkPackages;
using CAS.UI.Properties;
using CAS.UI.UIControls.Auxiliary;
using Controls;
using Controls.AvButtonT;
using Controls.AvMultitabControl;
using Controls.AvMultitabControl.Auxiliary;
using Controls.StatusImageLink;
using CAS.UI.UIControls.AnimatedBackgroundWorker;

namespace CAS.UI.UIControls.DiscrepanciesControls
{
    /// <summary>
    /// Элемент управления для отображения списка отклонений
    /// </summary>
    public class DiscrepanciesScreen : UserControl, IReference
    {
        #region Fields

        private Aircraft currentAircraft;
        private Aircraft originalAircraft;
        private BaseDetail currentBaseDetail;
        private BaseDetail originalBaseDetail;
        private DiscrepanciesListView discrepanciesListView;
        private readonly string discrepanciesObject = "";
        private readonly string operatorName = "";
        private readonly Image logoTypeWhite;
        private DateTime lastUpdateTime;
        private UtilizationInterval lastAppliedUtilizationInterval;
        private UtilizationInterval utilizationInterval;
        
        private string reportName = "";
        private string screenName = "Discrepancies Report";
        private DateTime dateAsOf;
        private WorkPackage composedWorkPackage;

        private ContextMenuStrip contextMenuStrip;
        private readonly List<ToolStripMenuItem> toolStripMenuItemsWorkPackages = new List<ToolStripMenuItem>();
        private ToolStripMenuItem toolStripMenuItemOpen;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuItemComposeWorkPackage;
        private ToolStripMenuItem toolStripMenuItemCopy;
        private ToolStripMenuItem toolStripMenuItemPaste;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private AvButtonT buttonComposeWorkPackage;
        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;
        private AnimatedThreadWorker animatedThreadWorker;
        private DispatcheredMultitabControl dispatcheredMultitabControl;

        private readonly Icons icons = new Icons();


        private FooterControl footerControl;
        private AircraftHeaderControl aircraftHeaderControl;
        private HeaderControl headerControl;
        private Panel panelMain;
        private Panel panelControlPanel;
        private StatusImageLinkLabel labelTitle;
        private Label labelDateAsOf;
        private LinkLabel linkSetDate;
        private Label labelMonthlyUtilization;
        private LinkLabel linkSetUtilization;
        private ForecastReportOptionsForm formOptions;
/*        private bool permissionForUpdate = true;
        private bool permissionForDelete = true;
        private bool permissionForCreate = true;*/

        #endregion

        #region Constructors

        #region public DiscrepanciesScreen(Aircraft currentAircraft)

        /// <summary>
        /// Создается элемент отображения отклонений для ВС
        /// </summary>
        /// <param name="currentAircraft">Объект для которого производится отображение отклонение</param>
        ///<exception cref="ArgumentNullException"></exception>
        public DiscrepanciesScreen(Aircraft currentAircraft)
        {
            if (currentAircraft == null)
                throw new ArgumentNullException("currentAircraft");
            originalAircraft = CurrentAircraft = currentAircraft;
            dateAsOf = lastUpdateTime = currentAircraft.DateAsOf;
            discrepanciesObject = currentAircraft.RegistrationNumber;
            operatorName = currentAircraft.Operator.Name;
            logoTypeWhite = currentAircraft.Operator.LogoTypeWhite;
            InitializeComponent();
            SetToolStripMenuItems(currentAircraft);
            HookWorkPackageEvents(currentAircraft);
            Initialize();
            ShowElements();
        }

        #endregion

        #region public DiscrepanciesScreen(BaseDetail currentBaseDetail)

        ///<summary>
        /// Создается элемент отображения отклонений для базового агрегата
        ///</summary>
        ///<param name="currentBaseDetail">Базовый агрегат для которого создается отображение</param>
        ///<exception cref="ArgumentNullException"></exception>
        public DiscrepanciesScreen(BaseDetail currentBaseDetail)
        {
            if (currentBaseDetail == null)
                throw new ArgumentNullException("currentBaseDetail");
            originalBaseDetail = CurrentBaseDetail = currentBaseDetail;
            
            dateAsOf = lastUpdateTime = currentBaseDetail.DateAsOf;
            discrepanciesObject = currentBaseDetail is AircraftFrame
                                      ? currentBaseDetail + ". Aircraft Frame " +
                                        currentBaseDetail.SerialNumber
                                      : currentBaseDetail.ToString();
            operatorName = currentBaseDetail.ParentAircraft.Operator.Name;
            logoTypeWhite = currentBaseDetail.ParentAircraft.Operator.LogoTypeWhite;
            InitializeComponent();
            SetToolStripMenuItems(currentBaseDetail.ParentAircraft);
            HookWorkPackageEvents(currentBaseDetail.ParentAircraft);
            Initialize();
            ShowElements();
        }

        #endregion

        #endregion

        #region Properties

        #region public Aircraft CurrentAircraft

        /// <summary>
        /// Отображаемое ВС
        /// </summary>
        public Aircraft CurrentAircraft
        {
            get
            {
                if (currentAircraft != null)
                    return currentAircraft;
                if (currentBaseDetail != null)
                    return currentBaseDetail.ParentAircraft;
                return null;
            }
            set
            {
                if (value != null)
                    currentBaseDetail = null;
                currentAircraft = value;
            }
        }

        #endregion

        #region public BaseDetail CurrentBaseDetail

        /// <summary>
        /// Отображаемый базовый агрегат
        /// </summary>
        public BaseDetail CurrentBaseDetail
        {
            get { return currentBaseDetail; }
            set
            {
                if (value != null)
                    currentAircraft = null;
                currentBaseDetail = value;
            }
        }

        #endregion

        #region public CoreType CurrentCoreType

        /// <summary>
        /// Текущий отображаемый объект
        /// </summary>
        public CoreType CurrentCoreType
        {
            get { return CurrentContainer as CoreType; }
        }

        #endregion

        #region public IDetailDirectiveContainer CurrentContainer

        /// <summary>
        /// Текущий отображамеый объект
        /// </summary>
        public IDetailDirectiveContainer CurrentContainer
        {
            get
            {
                if (currentBaseDetail != null)
                    return currentBaseDetail;
                return currentAircraft;
            }
        }

        #endregion

        #region public IFilter AppliedFilter

        /// <summary>
        /// Примененный фильтр
        /// </summary>
        public IFilter AppliedFilter
        {
            get { return discrepanciesListView.Filter; }
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

        #region public IDisplayingEntity Entity

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
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            panelMain = new Panel();
            panelControlPanel = new Panel();
            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeaderControl = new AircraftHeaderControl();
            labelDateAsOf = new Label();
            labelTitle = new StatusImageLinkLabel();
            linkSetDate = new LinkLabel();
            labelMonthlyUtilization = new Label();
            linkSetUtilization = new LinkLabel();
            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemOpen = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemComposeWorkPackage = new ToolStripMenuItem();
            toolStripMenuItemCopy = new ToolStripMenuItem();
            toolStripMenuItemPaste = new ToolStripMenuItem();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            buttonComposeWorkPackage = new AvButtonT();
            if (currentBaseDetail != null)
            {
                formOptions = new ForecastReportOptionsForm(currentBaseDetail, dateAsOf,
                                                            currentBaseDetail.ParentAircraft.UtilizationInterval);
                lastAppliedUtilizationInterval =
                    new UtilizationInterval(
                        utilizationInterval =
                        new UtilizationInterval(currentBaseDetail.ParentAircraft.UtilizationInterval));
                
            }
            else
            {

                formOptions = new ForecastReportOptionsForm(currentAircraft.AircraftFrame, dateAsOf,
                                                            currentAircraft.UtilizationInterval);
                lastAppliedUtilizationInterval =
                    new UtilizationInterval(
                        utilizationInterval =
                        new UtilizationInterval(currentAircraft.UtilizationInterval));


            }

            formOptions.ApplyClick += form_ApplyClick;
            formOptions.StartPosition = FormStartPosition.CenterScreen;
            // 
            // panelMain
            // 
            panelMain.AutoScroll = true;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 117);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1053, 372);
            panelMain.TabIndex = 2;
            // 
            // panelControlPanel
            // 
            panelControlPanel.Controls.Add(labelTitle);
            panelControlPanel.Controls.Add(labelDateAsOf);
            panelControlPanel.Controls.Add(linkSetDate);
            panelControlPanel.Controls.Add(labelMonthlyUtilization);
            panelControlPanel.Controls.Add(linkSetUtilization);
            panelControlPanel.Controls.Add(buttonComposeWorkPackage);
            panelControlPanel.Dock = DockStyle.Top;
            panelControlPanel.Size = new Size(1053, 59);
            // 
            // headerControl
            // 
            headerControl.ActionControlSplitterVisible = true;
            headerControl.BackColor = Color.Transparent;
            headerControl.ContextActionControl.ShowPrintButton = true;
            headerControl.BackgroundImage = Resources.HeaderBar;
            headerControl.Controls.Add(aircraftHeaderControl);
            headerControl.Dock = DockStyle.Top;
            headerControl.ActionControl.ShowEditButton = false;
            headerControl.EditReflectionType = ReflectionTypes.DisplayInNew;
            headerControl.Location = new Point(0, 0);
            headerControl.Size = new Size(1053, 58);
            headerControl.TabIndex = 0;
            headerControl.ReloadRised += HeaderControl_ReloadRised;
            headerControl.ButtonEdit.Enabled = false;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "aircraft_discrepancies_discrepancies_report";
            // 
            // aircraftHeaderControl
            // 
            aircraftHeaderControl.Aircraft = null;
            aircraftHeaderControl.AircraftClickable = true;
            aircraftHeaderControl.AutoSize = true;
            aircraftHeaderControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            aircraftHeaderControl.BackColor = Color.Transparent;
            aircraftHeaderControl.Location = new Point(0, 0);
            aircraftHeaderControl.OperatorClickable = true;
            aircraftHeaderControl.Size = new Size(344, 60);
            // 
            // labelTitle
            // 
            Css.HeaderLinkLabel.Adjust(labelTitle);
            labelTitle.Enabled = false;
            labelTitle.ImageLayout = ImageLayout.Center;
            labelTitle.Location = new Point(28, 3);
            labelTitle.Margin = new Padding(0);
            labelTitle.Size = new Size(1000, 27);
            labelTitle.TabIndex = 16;
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            labelTitle.Status = Statuses.NotActive;
            // 
            // labelDateAsOf
            // 
            labelDateAsOf.AutoSize = true;
            labelDateAsOf.Font = Css.SimpleLink.Fonts.Font;
            labelDateAsOf.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDateAsOf.Location = new Point(57, 30);
            labelDateAsOf.Size = new Size(47, 19);
            labelDateAsOf.TabIndex = 21;
            labelDateAsOf.Text = "Date as of: " + DateTime.Today.ToString(new TermsProvider()["DateFormat"].ToString());
            labelDateAsOf.SizeChanged += labelDateAsOf_SizeChanged;
            // 
            // linkSetDate
            // 
            linkSetDate.AutoSize = true;
            linkSetDate.Font = Css.SimpleLink.Fonts.Font;
            linkSetDate.ForeColor = Css.SimpleLink.Colors.LinkColor;
            linkSetDate.Location = new Point(labelDateAsOf.Right, labelDateAsOf.Top);
            linkSetDate.Text = "Set date";
            linkSetDate.LinkClicked += linkSetDate_LinkClicked;
            // 
            // labelMonthlyUtilization
            // 
            labelMonthlyUtilization.AutoSize = true;
            labelMonthlyUtilization.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelMonthlyUtilization.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMonthlyUtilization.Location = new Point(400, labelDateAsOf.Top);
            labelMonthlyUtilization.SizeChanged += labelMonthlyUtilization_SizeChanged;
            // 
            // linkSetUtilization
            // 
            linkSetUtilization.AutoSize = true;
            linkSetUtilization.Font = Css.SimpleLink.Fonts.Font;
            linkSetUtilization.ForeColor = Css.SimpleLink.Colors.LinkColor;
            linkSetUtilization.Location = new Point(labelMonthlyUtilization.Right, labelDateAsOf.Top);
            linkSetUtilization.Text = "Set utilization";
            linkSetUtilization.LinkClicked += linkSetUtilization_LinkClicked;
            // 
            // buttonComposeWorkPackage
            // 
            buttonComposeWorkPackage.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonComposeWorkPackage.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonComposeWorkPackage.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonComposeWorkPackage.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonComposeWorkPackage.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonComposeWorkPackage.Icon = icons.Add;
            buttonComposeWorkPackage.IconNotEnabled = icons.AddGray;
            buttonComposeWorkPackage.Location = new Point(770, 0);
            buttonComposeWorkPackage.Width = 200;
            buttonComposeWorkPackage.TabIndex = 19;
            buttonComposeWorkPackage.TextAlignMain = ContentAlignment.BottomCenter;
            buttonComposeWorkPackage.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonComposeWorkPackage.TextMain = "Compose a";
            buttonComposeWorkPackage.TextSecondary = "work package";
            buttonComposeWorkPackage.Click += buttonComposeWorkPackage_Click;
            //
            // discrepanciesListView
            //
            discrepanciesListView = new DiscrepanciesListView();
            discrepanciesListView.Location = new Point(0, 0);
            discrepanciesListView.TabIndex = 0;
            discrepanciesListView.ContextMenuStrip = contextMenuStrip;
            discrepanciesListView.SelectedItemsChanged += discrepanciesListView_SelectedItemsChanged;
            panelMain.Controls.Add(discrepanciesListView);
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Size = new Size(179, 176);
            // 
            // toolStripMenuItemTitle
            // 
            toolStripMenuItemComposeWorkPackage.Text = "Compose a work package";
            toolStripMenuItemComposeWorkPackage.Click += ComposeWorkPackageItem_Click;
            // 
            // toolStripMenuItemOpen
            // 
            toolStripMenuItemOpen.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            toolStripMenuItemOpen.Click += toolStripMenuItemOpen_Click;
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Text = "Delete";
            toolStripMenuItemDelete.Enabled = false;
            // 
            // toolStripMenuItemCopy
            // 
            toolStripMenuItemCopy.Text = "Copy (Ctrl+C)";
            toolStripMenuItemCopy.Click += toolStripMenuItemCopy_Click;
            // 
            // toolStripMenuItemPaste
            // 
            toolStripMenuItemPaste.Text = "Paste (Ctrl+V)";
            toolStripMenuItemPaste.Enabled = false;
            // 
            // DiscrepanciesScreen
            // 
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(panelMain);
            Controls.Add(panelControlPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);
        }

        #endregion

        #region private void Initialize()

        private void Initialize()
        {
            reportName = screenName = "Forecast Report";
            headerControl.ContextActionControl.ButtonPrint.DisplayerRequested += PrintButton_DisplayerRequested;
            //headerControl.ButtonEdit.DisplayerRequested += ButtonEdit_DisplayerRequested;
            ((DispatcheredDiscrepanciesScreen) this).InitComplition += DiscrepanciesScreen_InitComplition;
        }

        #endregion

        #region private void SetToolStripMenuItems(Aircraft aircraft)

        private void SetToolStripMenuItems(Aircraft aircraft)
        {
            contextMenuStrip.Items.Clear();
            toolStripMenuItemsWorkPackages.Clear();
            contextMenuStrip.Items.AddRange(new ToolStripItem[] {toolStripMenuItemOpen, toolStripSeparator});
            for (int i = 0; i < aircraft.WorkPackages.Length; i++)
            {
                if (aircraft.WorkPackages[i].Status != WorkPackageStatus.Open)
                    continue;
                ToolStripMenuItem item = new ToolStripMenuItem("Move to " + aircraft.WorkPackages[i].Title);
                item.Tag = aircraft.WorkPackages[i];
                item.Click += WorkPackageItem_Click;
                toolStripMenuItemsWorkPackages.Add(item);
                contextMenuStrip.Items.Add(item);
            }

            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    toolStripMenuItemComposeWorkPackage, toolStripSeparator2,
                                                    toolStripMenuItemCopy, toolStripMenuItemPaste,
                                                    toolStripMenuItemDelete
                                                });
        }

        #endregion

        #region protected virtual void ReloadElements()

        /// <summary>
        /// Происходит перезагрузка элементов и синхронизация с базой данных
        /// </summary>
        protected void ReloadElements()
        {
            if (animatedThreadWorker == null)
            {
                animatedThreadWorker = new AnimatedThreadWorker(BackgroundReload, this);
                animatedThreadWorker.State = "Reloading";
                animatedThreadWorker.WorkFinished += animatedThreadWorker_WorkFinished;
                dispatcheredMultitabControl.SetEnabledToAllEntityes(false);
                animatedThreadWorker.StartThread();
            }
        }

        #endregion

        #region private void BackgroundReload()

        private void BackgroundReload()
        {
            try
            {
                if (CurrentCoreType != null)
                    CurrentCoreType.Reload(true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }

/*            if (!ApplyFilters())
                ShowElements();*/
        }

        #endregion

        #region private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)

        private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)
        {
            animatedThreadWorker.StopThread();
            animatedThreadWorker = null;
            dispatcheredMultitabControl.SetEnabledToAllEntityes(true);
            ShowElements();
        }

        #endregion

        #region public void ShowElements()

        /// <summary>
        /// Отображение элементов
        /// </summary>
        public void ShowElements()
        {
            aircraftHeaderControl.Aircraft = CurrentAircraft;
            labelTitle.Text = (currentBaseDetail != null)
                                  ? currentBaseDetail.ParentAircraft.RegistrationNumber + ". " + currentBaseDetail + ". " + screenName
                                  : currentAircraft.RegistrationNumber + ". " + screenName;
            labelDateAsOf.Text = "Date as of: " + dateAsOf.ToString(new TermsProvider()["DateFormat"].ToString());
            labelMonthlyUtilization.Text = "Monthly Utilization: " + utilizationInterval.Hours + "HRS, " +
                                           utilizationInterval.Cycles + "CYC";
                                           
            if (currentAircraft != null)
                discrepanciesListView.SetResource(currentAircraft);
            else
                discrepanciesListView.SetResource(currentBaseDetail);

            headerControl.ContextActionControl.ButtonPrint.Enabled = (discrepanciesListView.TotalItems != 0);
            CheckContextMenu(discrepanciesListView.SelectedItems.Count);
        }

        #endregion

        #region private bool ApplyFilters()

        private bool ApplyFilters()
        {
            if (lastUpdateTime != dateAsOf ||
                lastAppliedUtilizationInterval != utilizationInterval)
            {
                Lifelength applyingLifelength = Lifelength.ZeroLifelength;
                applyingLifelength.IsCalendarApplicable = false;
                if (utilizationInterval.UtilizationIntervalType == UtilizationIntervalType.MonthlyUtilization)
                {

                    applyingLifelength.Cycles = (int) (utilizationInterval.Cycles*
                                                       (dateAsOf - DateTime.Now).TotalDays/30);
                    applyingLifelength.IsCyclesApplicable = true;
                    applyingLifelength.Hours =
                        new TimeSpan(0,
                                     (int) (utilizationInterval.Hours*
                                            (dateAsOf - DateTime.Now).TotalDays/30), 0, 0);
                    applyingLifelength.IsHoursApplicable = true;

                }
                else
                {
                    applyingLifelength.Cycles = (int)(utilizationInterval.Cycles *
                                                       (dateAsOf - DateTime.Now).TotalDays );
                    applyingLifelength.IsCyclesApplicable = true;
                    applyingLifelength.Hours =
                        new TimeSpan(0,
                                     (int)(utilizationInterval.Hours *
                                            (dateAsOf - DateTime.Now).TotalDays), 0, 0);
                    applyingLifelength.IsHoursApplicable = true;
                    
                }
                if (
                    !discrepanciesListView.Filter.Equals(new DiscrepanciesFilter(applyingLifelength, false, true)) &&
                    (dateAsOf > DateTime.Now))
                {

                    lastAppliedUtilizationInterval = new UtilizationInterval(utilizationInterval);
                    discrepanciesListView.Filter =
                        new DiscrepanciesFilter(applyingLifelength, false, true);
                    ApplySettings(applyingLifelength);

                }
                
                if ((lastUpdateTime >= DateTime.MinValue) && (lastUpdateTime != dateAsOf))
                {
                    ApplySettings(applyingLifelength);
                    lastUpdateTime = dateAsOf;
                }
                ShowElements();
                return true;
            }
            return false;
        }

        private void ApplySettings(Lifelength lifelengthIncrement)
        {
            if (currentBaseDetail != null)
            {
                if (dateAsOf > DateTime.Now)
                    CurrentBaseDetail =
                        originalBaseDetail.CloneAsDateOf(dateAsOf, lifelengthIncrement) as BaseDetail;
                else
                    CurrentBaseDetail = originalBaseDetail.CloneAsDateOf(dateAsOf) as BaseDetail;
            }
            else
            {
                if (dateAsOf > DateTime.Now)
                    CurrentAircraft =
                        originalAircraft.CloneAsDateOf(dateAsOf, lifelengthIncrement) as Aircraft;
                else
                    CurrentAircraft = originalAircraft.CloneAsDateOf(dateAsOf) as Aircraft;
            }
        }

        #endregion

        #region private void ComposeWorkPackage()

        private void ComposeWorkPackage()
        {
            Aircraft aircraft;
            if (currentAircraft != null)
                aircraft = currentAircraft;
            else
                aircraft = currentBaseDetail.ParentAircraft;
            WorkPackage workPackage = new WorkPackage();
            workPackage.Title = aircraft.GetNewWorkPackageTitle();

            try
            {
                aircraft.AddWorkPackage(workPackage);
                for (int i = 0; i < discrepanciesListView.SelectedItems.Count; i++)
                    workPackage.AddItem(discrepanciesListView.SelectedItems[i]);
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
                for (int i = 0; i < discrepanciesListView.SelectedItems.Count; i++)
                {
                    if (discrepanciesListView.SelectedItems[i] is AbstractDetail)
                    {
                        if (workPackage.Details.Contains((AbstractDetail) discrepanciesListView.SelectedItems[i]))
                        {
                            exclamation = true;
                            break;
                        }
                    }
                    else if (discrepanciesListView.SelectedItems[i] is BaseDetailDirective)
                    {
                        if (workPackage.Directives.Contains((BaseDetailDirective) discrepanciesListView.SelectedItems[i]))
                        {
                            exclamation = true;
                            break;
                        }
                    }
                    else
                    {
                        if (workPackage.NonRoutineJobs.Contains((NonRoutineJob) discrepanciesListView.SelectedItems[i]))
                        {
                            exclamation = true;
                            break;
                        }
                    }
                }
                if (exclamation)
                {
                    if (MessageBox.Show(
                            "Some items will not be added to a work package." + Environment.NewLine + "Continue?",
                            new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                        return;
                }
                for (int i = 0; i < discrepanciesListView.SelectedItems.Count; i++)
                {
                    bool contains = false;
                    if ((discrepanciesListView.SelectedItems[i] is AbstractDetail &&
                         workPackage.Details.Contains((AbstractDetail) discrepanciesListView.SelectedItems[i])) ||
                        (discrepanciesListView.SelectedItems[i] is BaseDetailDirective &&
                         workPackage.Directives.Contains((BaseDetailDirective) discrepanciesListView.SelectedItems[i])) ||
                        (discrepanciesListView.SelectedItems[i] is NonRoutineJob &&
                         workPackage.NonRoutineJobs.Contains((NonRoutineJob) discrepanciesListView.SelectedItems[i])))
                        contains = true;
                    if (!contains)
                        workPackage.AddItem(discrepanciesListView.SelectedItems[i]);
                }
                string message = discrepanciesListView.SelectedItems.Count == 1
                                     ? "Item added successfully"
                                     : "Items added successfully";
                if (MessageBox.Show(message + ". Open work package screen?",
                                    new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Information) == DialogResult.Yes)
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

        #region private void CheckPermission()

/*
        private void CheckPermission()
        {
            permissionForCreate = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            permissionForDelete = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Remove);
            permissionForUpdate = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.UpdateInformation);
        }

*/

        #endregion

        #region private void CheckContextMenu(int count)

        private void CheckContextMenu(int count)
        {
            buttonComposeWorkPackage.Enabled = count > 0;
            toolStripMenuItemOpen.Enabled = count > 0;
            toolStripMenuItemComposeWorkPackage.Enabled = count > 0; // && permissionForUpdate;//todo
            for (int i = 0; i < toolStripMenuItemsWorkPackages.Count; i++)
                toolStripMenuItemsWorkPackages[i].Enabled = count > 0; // && permissionForUpdate;//todo 
            if (discrepanciesListView.SelectedItems.Count == 1)
                toolStripMenuItemOpen.Text = "Open " + discrepanciesListView.SelectedItems[0].Title;
            else
                toolStripMenuItemOpen.Text = "Open items";
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

        #region protected override void OnSizeChanged(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (buttonComposeWorkPackage != null)
                buttonComposeWorkPackage.Location = new Point(Width - buttonComposeWorkPackage.Width - 5, 0);
            if (discrepanciesListView != null)
            {
                discrepanciesListView.Width = Width;
                discrepanciesListView.Height = Height - (headerControl.Height + footerControl.Height + panelControlPanel.Height);
            }
        }

        #endregion

        #region private void DiscrepanciesScreen_InitComplition(object sender, EventArgs e)

        private void DiscrepanciesScreen_InitComplition(object sender, EventArgs e)
        {
            dispatcheredMultitabControl = (DispatcheredMultitabControl)sender;
            ((AvMultitabControl) sender).Selected += DiscrepanciesScreen_Selected;
            ((DispatcheredMultitabControl) sender).Closed += control_Closed;
        }

        #endregion

        #region private void control_Closed(object sender, AvMultitabControlEventArgs e)

        private void control_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == Parent as DispatcheredTabPage)
            {
                if (currentBaseDetail != null)
                    UnHookWorkPackageEvents(currentBaseDetail.ParentAircraft);
                else
                    UnHookWorkPackageEvents(currentAircraft);
            }
        }

        #endregion

        #region private void DiscrepanciesScreen_Selected(object sender, AvMultitabControlEventArgs e)

        private void DiscrepanciesScreen_Selected(object sender, AvMultitabControlEventArgs e)
        {
            discrepanciesListView.ItemsListView.Focus();
        }

        #endregion

        #region private void HeaderControl_ReloadRised(object sender, EventArgs e)

        private void HeaderControl_ReloadRised(object sender, EventArgs e)
        {
            ReloadElements();
        }

        #endregion

        #region protected void OpenItems()

        /// <summary>
        /// Обработка запроса открытия нескольких <see cref="IMaintainable"/>
        /// </summary>
        protected void OpenItems()
        {
            for (int i = 0; i < discrepanciesListView.SelectedItems.Count; i++)
            {
                ReferenceEventArgs e = new ReferenceEventArgs();
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                if (discrepanciesListView.SelectedItems[i] is AbstractDetail)
                {
                    e.DisplayerText = currentAircraft.RegistrationNumber + ". " +
                                      discrepanciesListView.SelectedItems[i].Title;
                    e.RequestedEntity =
                        new DispatcheredDetailScreen((AbstractDetail) discrepanciesListView.SelectedItems[i]);
                }
                else if (discrepanciesListView.SelectedItems[i] is BaseDetailDirective)
                {
                    BaseDetailDirective directive = (BaseDetailDirective) discrepanciesListView.SelectedItems[i];
                    string regNumber = "";
                    if (directive.Parent is AircraftFrame)
                        regNumber = directive.Parent.ToString();
                    else
                    {
                        if ((directive.Parent).Parent is Aircraft)
                            regNumber = ((Aircraft) ((directive.Parent).Parent)).RegistrationNumber + ". " +
                                        directive.Parent;
                    }
                    e.DisplayerText = regNumber + ". " + directive.DirectiveType.CommonName + ". " + directive.Title;
                    if (directive is EngineeringOrderDirective)
                        e.RequestedEntity =
                            new DispatcheredEngineeringOrderDirectiveScreen((EngineeringOrderDirective) directive);
                    else if (directive.DirectiveType == DirectiveTypeCollection.Instance.OutOffPhaseDirectiveType)
                        e.RequestedEntity = new DispatcheredOutOffPhaseReferenceScreen(directive);
                    else if (directive.DirectiveType == DirectiveTypeCollection.Instance.CPCPDirectiveType)
                        e.RequestedEntity = new DispatcheredCPCPDirectiveScreen(directive);
                    else
                        e.RequestedEntity = new DispatcheredDirectiveScreen(directive);
                }
                else if (discrepanciesListView.SelectedItems[i] is MaintenanceDirective)
                {
                    e.DisplayerText = currentAircraft.RegistrationNumber + ". Maintenance Program";
                    e.RequestedEntity =
                        new DispatcheredMaintenanceStatusControl(
                            (MaintenanceDirective) discrepanciesListView.SelectedItems[i]);
                }
                else
                    return;
                OnDisplayerRequested(e);
            }
        }

        #endregion

        #region private void discrepanciesListView_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void discrepanciesListView_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            CheckContextMenu(e.ItemsCount);
        }

        #endregion

        #region private void PrintButton_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void PrintButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = discrepanciesObject + ". " + reportName;
            UtilizationInterval interval = (currentAircraft != null)
                                               ? currentAircraft.UtilizationInterval
                                               : currentBaseDetail.ParentAircraft.UtilizationInterval;
            string monthlyUtilizationTSN = interval.Hours + " hrs";
            string monthlyUtilizationCSN = interval.Cycles + " cyc";
            DispathceredDiscrepanciesReport report =
                new DispathceredDiscrepanciesReport(reportName, lastUpdateTime, operatorName, logoTypeWhite,
                                                    monthlyUtilizationTSN, monthlyUtilizationCSN,
                                                    discrepanciesListView.Items);
            if (currentAircraft != null)
                report.ReportBuilder.ReportedAircraft = currentAircraft;
            if (currentBaseDetail != null)
                report.ReportBuilder.ReportedBaseDetail = currentBaseDetail;
            report.DisplayReport();
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = report;
        }

        #endregion

        #region private void labelDateAsOf_SizeChanged(object sender, EventArgs e)

        private void labelDateAsOf_SizeChanged(object sender, EventArgs e)
        {
            linkSetDate.Location = new Point(labelDateAsOf.Right, labelDateAsOf.Top);
        }

        #endregion

        #region private void labelMonthlyUtilization_SizeChanged(object sender, EventArgs e)

        private void labelMonthlyUtilization_SizeChanged(object sender, EventArgs e)
        {
            linkSetUtilization.Location = new Point(labelMonthlyUtilization.Right, labelDateAsOf.Top);
        }

        #endregion

        #region private void linkSetUtilization_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkSetUtilization_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formOptions.UpdateInformation(dateAsOf, utilizationInterval);
            formOptions.ShowDialog();
        }

        #endregion

        #region private void linkSetDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkSetDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formOptions.ShowDialog();
        }

        #endregion

        #region private void formOptions_ApplyClick(DateTime dateAsOf, Lifelength monthlyUtilizationsLifelength)

        private void form_ApplyClick(DateTime dateAsOfParameter, UtilizationInterval utilizationInterval)
        {
            dateAsOf = dateAsOfParameter;
            this.utilizationInterval = utilizationInterval;
            ApplyFilters();
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
            ComposeWorkPackage();
        }

        #endregion

        #region private void buttonComposeWorkPackage_Click(object sender, EventArgs e)

        private void buttonComposeWorkPackage_Click(object sender, EventArgs e)
        {
            Aircraft aircraft;
            if (currentAircraft != null)
                aircraft = currentAircraft;
            else
                aircraft = currentBaseDetail.ParentAircraft;
            ComposeWorkPackageForm form = new ComposeWorkPackageForm(aircraft);
            form.WorkPackageChoosed += ComposeWorkPackageForm_workPackageChoosed;
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (composedWorkPackage != null)
                    AddItemsToWorkPackage(composedWorkPackage);
                else
                    ComposeWorkPackage();
            }
            
        }

        #endregion

        #region private void ComposeWorkPackageForm_workPackageChoosed(WorkPackage workPackage)

        private void ComposeWorkPackageForm_workPackageChoosed(WorkPackage workPackage)
        {
            composedWorkPackage = workPackage;
        }

        #endregion

        #region private void toolStripMenuItemOpen_Click(object sender, EventArgs e)

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            OpenItems();
        }

        #endregion

        #region protected void SetPageEnable(bool isEnable)
        /// <summary>
        /// Set page enable
        /// </summary>
        /// <param name="isEnable"></param>
        protected void SetPageEnable(bool isEnable)
        {
            discrepanciesListView.Enabled = isEnable;
            panelControlPanel.Enabled = isEnable;
            footerControl.Enabled = isEnable;
            headerControl.Enabled = isEnable;
            aircraftHeaderControl.Enabled = isEnable;
            CheckContextMenu(discrepanciesListView.SelectedItems.Count);
        }
        #endregion


        #region private void toolStripMenuItemCopy_Click(object sender, EventArgs e)

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            int count = discrepanciesListView.SelectedItems.Count;
            if (count > 0)
            {
                List<object> contents = new List<object>();

                for (int i = 0; i < count; i++)
                    contents.Add(discrepanciesListView.SelectedItems[i]);
                CASClipboard.Instance.CopyToClipboard(contents);
            }
        }

        #endregion

        #region private void CurrentAircraft_WorkPackagesChanged(object sender, CollectionChangeEventArgs e)

        private void CurrentAircraft_WorkPackagesChanged(object sender, CollectionChangeEventArgs e)
        {
            SetToolStripMenuItems((Aircraft) sender);
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