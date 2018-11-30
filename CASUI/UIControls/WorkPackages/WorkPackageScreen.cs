using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.Core.Types.WorkPackages;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.EngineeringOrdersDirectives;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.WorkPackages;
using CAS.UI.Properties;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CASReports.Builders;
using CASReports;
using CASTerms;
using Controls.AvButtonT;
using Controls.AvMultitabControl;
using Controls.AvMultitabControl.Auxiliary;
using Controls.StatusImageLink;
using Auxiliary;
using CAS.UI.UIControls.MaintenanceStatusControls;

namespace CAS.UI.UIControls.WorkPackages
{
    ///<summary>
    /// Элемент управления для отображения списка работ рабочего пакета
    ///</summary>
    [ToolboxItem(false)]
    public class WorkPackageScreen : UserControl, IReference
    {

        #region Fields

        protected WorkPackage currentWorkPackage;
        private readonly Aircraft parentAircraft;

        private JobCard jobCardBeforeSaving;
        private NonRoutineJob nonRoutineJobBeforeSaving;
        private IMaintainable workPackageBeforeSaving;
        private IMaintainable workPackageBeforeReloading;
        private AnimatedThreadWorker animatedThreadWorker;
        private readonly Icons icons = new Icons();
        private readonly bool permissionForUpdate = true;
        private readonly bool permissionForDelete = true;
        private readonly bool permissionForCreate = true;

        private HeaderControl headerControl;
        private FooterControl footerControl1;
        private AircraftHeaderControl aircraftHeaderControl;
        private Panel panelTopContainer;
        private StatusImageLinkLabel labelTitle;
        //private Label labelDescription;
        private Label labelStatus;
        private LinkLabel linkChange;
        private RichReferenceButton buttonReleaseToService;
        private RichReferenceButton buttonCoverSheet;
        private AvButtonT buttonSaveToDisk;
        private AvButtonT buttonAddNonRoutineJob;
        private AvButtonT buttonPublishWorkPackage;
        private AvButtonT buttonCloseWorkPackage;
        private WorkPackageListView workPackageViewer;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem toolStripMenuItemOpen;
        private ToolStripMenuItem toolStripMenuItemAddNonRoutineJob;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem toolStripMenuItemCopy;
        private ToolStripMenuItem toolStripMenuItemPaste;
        private ToolStripMenuItem toolStripMenuItemDelete;
        
        private IDisplayer displayer;
        private IDisplayingEntity entity;
        private string displayerText;
        private ReflectionTypes reflectionType;
        private DispatcheredMultitabControl dispatcheredMultitabControl;
        private const int LABEL_STATUS_TOP = 30;
        
        #endregion

        #region Constructor

        ///<summary>
        /// Создаёт элемент управления для отображения списка рабочих пакетов
        ///</summary>
        ///<param name="workPackage">Рабочий пакет</param>
        public WorkPackageScreen(WorkPackage workPackage)
        {
            if (workPackage == null)
                throw new ArgumentNullException("workPackage");
            currentWorkPackage = workPackage;
            parentAircraft = (Aircraft) workPackage.Parent;
            permissionForCreate = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            permissionForDelete = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Remove);
            permissionForUpdate = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Update);
            ((DispatcheredWorkPackageScreen)this).InitComplition += WorkPackageScreen_InitComplition;
            CASClipboard.Instance.ClipboardContentsChanged += ClipboardContentsChanged;
            HookItems();
            HookAddedAndRemovedItemsEvents();
            InitializeComponent();
            UpdateInformation();
        }



        #endregion

        #region Properties

/*
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

        #endregion*/

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

/*        #region public DirectiveListReportBuilder ReportBuilder

        /// <summary>
        /// Создатель отчетов списка директив
        /// </summary>
        public DirectiveListReportBuilder ReportBuilder
        {
            get { return reportBuilder; }
            set { reportBuilder = value; }
        }

        #endregion*/
/*
        #region public ListView ItemsListView

        /// <summary>
        /// Возвращает ListView с директивами
        /// </summary>
        public ListView ItemsListView
        {
            get
            {
                return workPackagesViewer.ItemsListView;
            }
        }

        #endregion*/

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            workPackageViewer = new WorkPackageListView(currentWorkPackage);
            panelTopContainer = new Panel();
            buttonReleaseToService = new RichReferenceButton();
            buttonCoverSheet = new RichReferenceButton();
            buttonSaveToDisk = new AvButtonT();
            buttonAddNonRoutineJob = new AvButtonT();
            buttonCloseWorkPackage = new AvButtonT();
            buttonPublishWorkPackage = new AvButtonT();
            labelTitle = new StatusImageLinkLabel();
            //labelDescription = new Label();
            labelStatus = new Label();
            linkChange = new LinkLabel();
            footerControl1 = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeaderControl = new AircraftHeaderControl();

            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemOpen = new ToolStripMenuItem();
            toolStripMenuItemAddNonRoutineJob = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            toolStripMenuItemCopy = new ToolStripMenuItem();
            toolStripMenuItemPaste = new ToolStripMenuItem();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            // 
            // headerControl
            // 
            headerControl.ActionControlSplitterVisible = true;
            headerControl.BackgroundImage = Resources.HeaderBar;
            headerControl.Controls.Add(aircraftHeaderControl);
            headerControl.Dock = DockStyle.Top;
            headerControl.ContextActionControl.ShowPrintButton = true;
            headerControl.Size = new Size(1042, 58);
            headerControl.TabIndex = 0;
            headerControl.ReloadRised += ButtonReload_Click;
            headerControl.EditDisplayerRequested += headerControl_EditDisplayerRequested;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "airworthiness-directives-status.html";
            headerControl.ContextActionControl.ButtonPrint.DisplayerRequested += ButtonPrint_DisplayerRequested;
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
            aircraftHeaderControl.OperatorClickable = true;
            aircraftHeaderControl.Size = new Size(381, 58);
            // 
            // footerControl1
            // 
            footerControl1.AutoSize = true;
            footerControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            footerControl1.BackColor = Color.Transparent;
            footerControl1.Dock = DockStyle.Bottom;
            footerControl1.Location = new Point(0, 568);
            footerControl1.Margin = new Padding(0);
            footerControl1.MaximumSize = new Size(0, 48);
            footerControl1.MinimumSize = new Size(0, 48);
            footerControl1.Size = new Size(1042, 48);
            footerControl1.TabIndex = 4;
            // 
            // panelTopContainer
            // 
            panelTopContainer.AutoSize = true;
            panelTopContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelTopContainer.BackColor = Color.LightGray;
            panelTopContainer.Controls.Add(buttonCloseWorkPackage);
            panelTopContainer.Controls.Add(buttonPublishWorkPackage);
            panelTopContainer.Controls.Add(buttonAddNonRoutineJob);
            panelTopContainer.Controls.Add(buttonSaveToDisk);
            panelTopContainer.Controls.Add(buttonReleaseToService);
            panelTopContainer.Controls.Add(buttonCoverSheet);
            panelTopContainer.Controls.Add(linkChange);
            panelTopContainer.Controls.Add(labelStatus);
            //panelTopContainer.Controls.Add(labelDescription);
            panelTopContainer.Controls.Add(labelTitle);
            panelTopContainer.Dock = DockStyle.Top;
            panelTopContainer.Size = new Size(1042, 62);
            panelTopContainer.TabIndex = 1;
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
/*            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDescription.Location = new Point(57, 30);*/
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelStatus.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelStatus.Location = new Point(57, LABEL_STATUS_TOP);
            labelStatus.SizeChanged += labelStatus_SizeChanged;
            // 
            // linkChange
            // 
            linkChange.AutoSize = true;
            linkChange.Font = Css.SimpleLink.Fonts.Font;
            linkChange.ForeColor = Css.SimpleLink.Colors.LinkColor;
            linkChange.Location = new Point(labelStatus.Right, LABEL_STATUS_TOP);
            linkChange.Text = "Change";
            linkChange.LinkClicked += linkSetDate_LinkClicked;
            // 
            // buttonCoverSheet
            // 
            buttonCoverSheet.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonCoverSheet.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonCoverSheet.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonCoverSheet.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonCoverSheet.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonCoverSheet.Icon = icons.Print;
            buttonCoverSheet.IconNotEnabled = icons.Report;
            buttonCoverSheet.Size = new Size(170, 59);
            buttonCoverSheet.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonCoverSheet.TextMain = "Cover Sheet";
            buttonCoverSheet.DisplayerRequested += buttonCoverSheet_DisplayerRequested;
            // 
            // buttonReleaseToService
            // 
            buttonReleaseToService.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonReleaseToService.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonReleaseToService.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonReleaseToService.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonReleaseToService.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonReleaseToService.Icon = icons.Print;
            buttonReleaseToService.IconNotEnabled = icons.PrintGray;
            buttonReleaseToService.Size = new Size(170, 59);
            buttonReleaseToService.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonReleaseToService.TextMain = "Release To Service";
            buttonReleaseToService.DisplayerRequested += buttonReleaseToService_DisplayerRequested;
            // 
            // buttonSaveToDisk
            // 
            buttonSaveToDisk.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonSaveToDisk.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonSaveToDisk.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonSaveToDisk.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonSaveToDisk.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonSaveToDisk.Icon = icons.Save;
            buttonSaveToDisk.IconNotEnabled = icons.SaveGray;
            buttonSaveToDisk.Size = new Size(170, 59);
            buttonSaveToDisk.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonSaveToDisk.TextMain = "Save to disk";
            buttonSaveToDisk.Click += buttonSaveToDisk_Click;
            // 
            // buttonAddNonRoutineJob
            // 
            buttonAddNonRoutineJob.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonAddNonRoutineJob.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddNonRoutineJob.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddNonRoutineJob.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddNonRoutineJob.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddNonRoutineJob.Icon = icons.Add;
            buttonAddNonRoutineJob.IconNotEnabled = icons.AddGray;
            buttonAddNonRoutineJob.Size = new Size(200, 59);
            buttonAddNonRoutineJob.TabIndex = 17;
            buttonAddNonRoutineJob.TextAlignMain = ContentAlignment.BottomCenter;
            buttonAddNonRoutineJob.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddNonRoutineJob.TextMain = "Add";
            buttonAddNonRoutineJob.TextSecondary = "Non-Routine Job";
            buttonAddNonRoutineJob.Click += buttonAddNonRoutineJob_Click;
            // 
            // buttonPublishWorkPackage
            // 
            buttonPublishWorkPackage.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonPublishWorkPackage.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonPublishWorkPackage.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonPublishWorkPackage.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonPublishWorkPackage.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonPublishWorkPackage.Icon = icons.Add;
            buttonPublishWorkPackage.IconNotEnabled = icons.AddGray;
            buttonPublishWorkPackage.Size = new Size(150, 59);
            buttonPublishWorkPackage.TabIndex = 19;
            buttonPublishWorkPackage.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonPublishWorkPackage.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonPublishWorkPackage.TextMain = "Publish";
            //buttonPublishWorkPackage.TextSecondary = "Work Package";
            buttonPublishWorkPackage.Click += buttonPublishWorkPackage_Click;
            // 
            // buttonCloseWorkPackage
            // 
            buttonCloseWorkPackage.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonCloseWorkPackage.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonCloseWorkPackage.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonCloseWorkPackage.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonCloseWorkPackage.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonCloseWorkPackage.Icon = icons.Add;
            buttonCloseWorkPackage.IconNotEnabled = icons.AddGray;
            buttonCloseWorkPackage.PaddingSecondary = new Padding(4, 0, 0, 0);
            buttonCloseWorkPackage.Size = new Size(145, 59);
            buttonCloseWorkPackage.TabIndex = 20;
            buttonCloseWorkPackage.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonCloseWorkPackage.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonCloseWorkPackage.TextMain = "Close";
            //buttonCloseWorkPackage.TextSecondary = "selected";
            buttonCloseWorkPackage.Click += ButtonCloseWorkPackage_Click;
            //
            // workPackagesViewer
            //
            workPackageViewer.ItemsListView.ContextMenuStrip = contextMenuStrip;
            workPackageViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
            workPackageViewer.SelectedItemsChanged += directivesViewer_SelectedItemsChanged;
            workPackageViewer.ItemsPasted += workPackageViewer_ItemsPasted;
            workPackageViewer.ItemsDeleted += toolStripMenuItemDelete_Click;
            Controls.Add(workPackageViewer);
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    toolStripMenuItemOpen,
                                                    toolStripMenuItemAddNonRoutineJob,
                                                    toolStripSeparator,
                                                    toolStripMenuItemCopy,
                                                    toolStripMenuItemPaste,
                                                    toolStripMenuItemDelete
                                                });
            contextMenuStrip.Size = new Size(179, 176);
            // 
            // toolStripMenuItemOpen
            // 
            toolStripMenuItemOpen.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            toolStripMenuItemOpen.Size = new Size(178, 22);
            toolStripMenuItemOpen.Click += toolStripMenuItemView_Click;
            // 
            // toolStripMenuItemAddNonRoutineJob
            // 
            toolStripMenuItemAddNonRoutineJob.Size = new Size(178, 22);
            toolStripMenuItemAddNonRoutineJob.Text = "Add Non-Routine Job";
            toolStripMenuItemAddNonRoutineJob.Click += toolStripMenuItemAddNonRoutineJob_Click;
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
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Size = new Size(178, 22);
            toolStripMenuItemDelete.Text = "Delete";
            toolStripMenuItemDelete.Click += toolStripMenuItemDelete_Click;
            // 
            // DirectiveListViewer
            // 
            AutoScroll = true;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(panelTopContainer);
            Controls.Add(footerControl1);
            Controls.Add(headerControl);
        }

        #endregion

        #region private void CopyItems()

        private void CopyItems()
        {
            try
            {
                if (CASClipboard.Instance.Contents.Count > 0 && CASClipboard.Instance.Contains(typeof(IMaintainable)))
                {
                    for (int i = 0; i < CASClipboard.Instance.Contents.Count; i++)
                    {
                        if (CASClipboard.Instance.Contents[i] is IMaintainable)
                        {
                            IMaintainable itemLink = (IMaintainable)CASClipboard.Instance.Contents[i];
                            //IMaintainable item = itemLink.DeepCopy();
                            //currentWorkPackage.AddItem(item); //todo
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

        #region protected virtual void ReloadElements()

        /// <summary>
        /// Происходит перезагрузка элементов и синхронизация с базой данных
        /// </summary>
        protected virtual void ReloadElements()
        {
            if (animatedThreadWorker == null)
            {
                animatedThreadWorker = new AnimatedThreadWorker(BackgroundDirectiveSourceReload, this);
                animatedThreadWorker.State = "Reloading work packages";
                animatedThreadWorker.WorkFinished += animatedThreadWorker_WorkFinished;
                dispatcheredMultitabControl.SetEnabledToAllEntityes(false);
                animatedThreadWorker.StartThread();
            }
        }

        #endregion

        #region private void BackgroundDirectiveSourceReload()

        private void BackgroundDirectiveSourceReload()
        {
            try
            {
                currentWorkPackage.Reload(true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex); 
                return;
            }
        }

        #endregion

        #region private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)

        private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)
        {
            animatedThreadWorker.StopThread();
            animatedThreadWorker = null;
            dispatcheredMultitabControl.SetEnabledToAllEntityes(true);
            UpdateInformation();
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет информацию рабочего пакета
        /// </summary>
        public void UpdateInformation()
        {
            labelTitle.Text =  parentAircraft.RegistrationNumber + ". " + currentWorkPackage.Title;
            //labelDescription.Text = currentWorkPackage.Description;
            string status;
            if (currentWorkPackage.Status == WorkPackageStatus.Open)
                status = "Open";
            else if (currentWorkPackage.Status == WorkPackageStatus.Published)
                status = "Published (" + currentWorkPackage.PublishingDate.ToString(new TermsProvider()["DateFormat"].ToString()) + ")";
            else
                status = "Closed (" + currentWorkPackage.ClosingDate.ToString(new TermsProvider()["DateFormat"].ToString()) + ")";
            labelStatus.Text = "Status: " + status;
            aircraftHeaderControl.Aircraft = parentAircraft;
            
            workPackageViewer.UpdateItems();
            
            CheckButtons();
            CheckContextMenu(workPackageViewer.SelectedItems.Count);
        }

        #endregion

        #region private Statuses GetStatus(BaseDetailDirective[] directives)
        /*
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
*/
        #endregion

        #region private Statuses GetStatus(BaseDetailDirective directive)
/*
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
*/
        #endregion

        #region private void ButtonReload_Click(object sender, EventArgs e)

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            ReloadElements();
        }

        #endregion

        #region private void headerControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)

        private void headerControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
//            e.Cancel = true;
            WorkPackageForm form = new WorkPackageForm(currentWorkPackage);
            form.WorkPackageChanged += WorkPackageForm_WorkPackageChanged;
            form.ShowDialog();
        }

        #endregion
        
        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = parentAircraft.RegistrationNumber + ". " + currentWorkPackage.Title + ". Report";
            e.RequestedEntity = new DispatcheredWorkPackageReport(new WorkPackageBuilder(currentWorkPackage));
 
        }

        #endregion

        #region private void buttonReleaseToService_DisplayerRequested(object sender, ReferenceEventArgs e)
        
        private void buttonReleaseToService_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = parentAircraft.RegistrationNumber + ". " + currentWorkPackage.Title + ". Release To Service " + currentWorkPackage.ReleaseCertificateNo;
            e.RequestedEntity = new DispatcheredWorkPackageReleaseToServiceReport(new WorkPackageReleaseToServiceBuilder(currentWorkPackage));
        }

        #endregion

        #region private void buttonCoverSheet_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonCoverSheet_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = parentAircraft.RegistrationNumber + ". " + currentWorkPackage.Title + ". Cover Sheet " + currentWorkPackage.ReleaseCertificateNo;
            e.RequestedEntity = new DispatcheredWorkPackageCoverSheetReport(new WorkPackageCoverSheetBuilder(currentWorkPackage));
        }

        #endregion

        #region private void buttonSaveToDisk_Click(object sender, EventArgs e)

        private void buttonSaveToDisk_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select directory where to store files";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ComposeWorkPackagePDF composer = new ComposeWorkPackagePDF(currentWorkPackage);         
                composer.SaveToDisk(dialog.SelectedPath);
                Process.Start(dialog.SelectedPath);
            }
            
        }

        #endregion

        #region private void buttonAddNonRoutineJob_Click(object sender, EventArgs e)

        private void buttonAddNonRoutineJob_Click(object sender, EventArgs e)
        {
            NonRoutineJobForm form = new NonRoutineJobForm(currentWorkPackage);
            form.ShowDialog();
        }

        #endregion

        #region private void buttonPublishWorkPackage_Click(object sender, EventArgs e)

        private void buttonPublishWorkPackage_Click(object sender, EventArgs e)
        {
            WorkPackageForm form = new WorkPackageForm(currentWorkPackage);
            form.WorkPackageChanged += WorkPackageForm_WorkPackageChanged;
            form.ShowDialog();
        }

        #endregion

        #region private void ButtonCloseWorkPackage_Click(object sender, EventArgs e)

        private void ButtonCloseWorkPackage_Click(object sender, EventArgs e)
        {
            WorkPackageForm form = new WorkPackageForm(currentWorkPackage);
            form.WorkPackageChanged += WorkPackageForm_WorkPackageChanged;
            form.ShowDialog();
        }

        #endregion

        #region private void workPackagesViewer_SelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)

        private void directivesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            CheckContextMenu(e.ItemsCount);
        }

        #endregion

        #region private void WorkPackageForm_WorkPackageChanged(object sender, EventArgs e)

        private void WorkPackageForm_WorkPackageChanged(object sender, EventArgs e)
        {
            UpdateInformation();
        }

        #endregion

        #region private void toolStripMenuItemOpen_Click(object sender, EventArgs e)

        private void toolStripMenuItemView_Click(object sender, EventArgs e)
        {
            OpenElements();
        }

        #endregion


        #region private void toolStripMenuItemCopy_Click(object sender, EventArgs e)

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            int count = workPackageViewer.SelectedItems.Count;
            if (count > 0)
            {
                List<object> contents = new List<object>();

                for (int i = 0; i < count; i++)
                    contents.Add(workPackageViewer.SelectedItems[i]);
                CASClipboard.Instance.CopyToClipboard(contents);
            }
        }

        #endregion

        #region private void toolStripMenuItemPaste_Click(object sender, EventArgs e)

        private void toolStripMenuItemPaste_Click(object sender, EventArgs e)
        {
            CopyItems();
        }

        #endregion

        #region private void workPackageViewer_ItemsPasted(List<IMaintainable> pastedItems)

        private void workPackageViewer_ItemsPasted(List<IMaintainable> pastedItems)
        {
            CopyItems();
        }

        #endregion


        #region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if ((workPackageViewer.SelectedItems == null) && (workPackageViewer.SelectedItem == null)) return;
            DialogResult confirmResult =
                MessageBox.Show(workPackageViewer.SelectedItem != null
                        ? "Do you really want to delete item from the work package?"
                        : "Do you really want to delete selected items from the work package? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                int count = workPackageViewer.SelectedItems.Count;

                List<IMaintainable> selectedItems = new List<IMaintainable>(workPackageViewer.SelectedItems);
                workPackageViewer.ItemsListView.BeginUpdate();
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        currentWorkPackage.RemoveItem(selectedItems[i]);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex);
                        return;
                    }

                }
                workPackageViewer.ItemsListView.EndUpdate();
                //ReloadElements();
            }
        }

        #endregion

        #region private void toolStripMenuItemAddNonRoutineJob_Click(object sender, EventArgs e)

        private void toolStripMenuItemAddNonRoutineJob_Click(object sender, EventArgs e)
        {
            NonRoutineJobForm form = new NonRoutineJobForm(currentWorkPackage);
            form.ShowDialog();
        }

        #endregion

        #region protected void OpenElements()

        /// <summary>
        /// Обработка запроса открытия нескольких рабочих пакетов
        /// </summary>
        protected void OpenElements()
        {
            for (int i = 0; i < workPackageViewer.SelectedItems.Count; i++)
            {
                ReferenceEventArgs e = new ReferenceEventArgs();
                if (workPackageViewer.SelectedItems[i] is NonRoutineJob)
                {
                    e.Cancel = true;
                    nonRoutineJobBeforeSaving = (NonRoutineJob)workPackageViewer.SelectedItems[i];
                    NonRoutineJobForm form = new NonRoutineJobForm(nonRoutineJobBeforeSaving);
                    form.Saved += form_Saved;
                    form.ShowDialog();
                }
                else if (workPackageViewer.SelectedItems[i] is JobCard)
                {
                    e.Cancel = true;
                    jobCardBeforeSaving = (JobCard)workPackageViewer.SelectedItems[i];
                    MaintenanceJobCardForm form = new MaintenanceJobCardForm(jobCardBeforeSaving);
                    form.Saved += formJobCard_Saved;
                    form.ShowDialog();
                }
                else if (workPackageViewer.SelectedItems[i] is AbstractDetail)
                {
                    AbstractDetail detail = (AbstractDetail)workPackageViewer.SelectedItems[i];
                    e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                    if (detail is BaseDetail)
                        e.DisplayerText = ((Aircraft)workPackageViewer.SelectedItems[i].Parent).RegistrationNumber + ". Component SN " + detail.SerialNumber;
                    else
                        e.DisplayerText = ((Aircraft)workPackageViewer.SelectedItems[i].Parent.Parent).RegistrationNumber + ". Component SN " + detail.SerialNumber;
                    e.RequestedEntity = new DispatcheredDetailScreen(detail);
                }
                else
                {
                    BaseDetailDirective directive = (BaseDetailDirective)workPackageViewer.SelectedItems[i];
                    e.TypeOfReflection = ReflectionTypes.DisplayInNew;

                    string regNumber = "";
                    if (workPackageViewer.SelectedItems[i].Parent is AircraftFrame)
                        regNumber = workPackageViewer.SelectedItems[i].Parent.ToString();
                    else
                    {
                        if ((workPackageViewer.SelectedItems[i].Parent).Parent is Aircraft)
                            regNumber = ((Aircraft)((workPackageViewer.SelectedItems[i].Parent).Parent)).RegistrationNumber + ". " + workPackageViewer.SelectedItems[i].Parent;
                    }
                    e.DisplayerText = regNumber + ". " + directive.DirectiveType.CommonName + ". " + directive.Title;
                    if (directive is EngineeringOrderDirective)
                        e.RequestedEntity = new DispatcheredEngineeringOrderDirectiveScreen((EngineeringOrderDirective)directive);
                    else if (directive.DirectiveType == DirectiveTypeCollection.Instance.OutOffPhaseDirectiveType)
                        e.RequestedEntity = new DispatcheredOutOffPhaseReferenceScreen(directive);
                    else if (directive.DirectiveType == DirectiveTypeCollection.Instance.CPCPDirectiveType)
                        e.RequestedEntity = new DispatcheredCPCPDirectiveScreen(directive);
                    else
                        e.RequestedEntity = new DispatcheredDirectiveScreen(directive);
                }
                OnDisplayerRequested(e);
            }
        }

        #endregion

        #region private void form_Saved(NonRoutineJob nonRoutineJobAfterSaving)

        private void form_Saved(NonRoutineJob nonRoutineJobAfterSaving)
        {
            workPackageViewer.EditItem(nonRoutineJobBeforeSaving, nonRoutineJobAfterSaving);
        }

        #endregion

        #region private void formJobCard_Saved(NonRoutineJob nonRoutineJobAfterSaving)

        private void formJobCard_Saved(JobCard jobCardAfterSaving)
        {
            workPackageViewer.EditItem(jobCardBeforeSaving, jobCardAfterSaving);
        }

        #endregion

        #region private void labelStatus_SizeChanged(object sender, EventArgs e)

        private void labelStatus_SizeChanged(object sender, EventArgs e)
        {
            linkChange.Location = new Point(labelStatus.Right, LABEL_STATUS_TOP);
        }

        #endregion

        #region private void linkChange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkSetDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            headerControl_EditDisplayerRequested(this, new ReferenceEventArgs());
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
            toolStripMenuItemOpen.Enabled = count > 0;
            toolStripMenuItemDelete.Enabled = count > 0 && permissionForDelete && currentWorkPackage.Status == WorkPackageStatus.Open;
            toolStripMenuItemPaste.Enabled = CASClipboard.Instance.Contains(typeof(IMaintainable));
            
            headerControl.ContextActionControl.ButtonPrint.Enabled = workPackageViewer.ItemsListView.Items.Count != 0;
            if (count == 1)
            {
                toolStripMenuItemOpen.Text = "Open " + workPackageViewer.SelectedItems[0].Title;
            }
            else
            {
                if (count == 0)
                    toolStripMenuItemOpen.Text = "Nothing selected";
                else
                    toolStripMenuItemOpen.Text = "Open Items";
            }
        }

        #endregion

        #region private void CheckButtons()

        private void CheckButtons()
        {
            buttonCloseWorkPackage.Enabled = (permissionForUpdate && currentWorkPackage.Status == WorkPackageStatus.Published && workPackageViewer.Items.Length > 0);
            buttonPublishWorkPackage.Enabled = (permissionForUpdate && currentWorkPackage.Status == WorkPackageStatus.Open && workPackageViewer.Items.Length > 0);
            buttonAddNonRoutineJob.Enabled = toolStripMenuItemAddNonRoutineJob.Enabled = (permissionForCreate && currentWorkPackage.Status == WorkPackageStatus.Open);
        }

        #endregion




        #region private void HookAddedAndRemovedItemsEvents()

        private void HookAddedAndRemovedItemsEvents()
        {
            currentWorkPackage.OverallItemRemoved += CurrentWorkPackage_ItemRemoved;
            currentWorkPackage.OverallItemAdded += CurrentWorkPackage_ItemAdded;
        }

        #endregion

        #region private void UnHookAddedAndRemovedItemsEvents()

        private void UnHookAddedAndRemovedItemsEvents()
        {
            currentWorkPackage.OverallItemRemoved -= CurrentWorkPackage_ItemRemoved;
            currentWorkPackage.OverallItemAdded -= CurrentWorkPackage_ItemAdded;
        }

        #endregion

        #region private void HookItems()

        private void HookItems()
        {
            for (int i = 0; i < currentWorkPackage.Details.Count; i++)
                HookDetail(currentWorkPackage.Details[i]);
            for (int i = 0; i < currentWorkPackage.Directives.Count; i++)
                HookDirective(currentWorkPackage.Directives[i]);
            for (int i = 0; i < currentWorkPackage.NonRoutineJobs.Count; i++)
                HookNonRoutineJob(currentWorkPackage.NonRoutineJobs[i]);
        }

        #endregion

        #region private void HookDetail(AbstractDetail detail)

        private void HookDetail(AbstractDetail detail)
        {
            UnHookDetail(detail);
            detail.Saving += Item_Saving;
            detail.Saved += Item_Saved;
            detail.Reloading += Item_Reloading;
            detail.Reloaded += Item_Reloaded;
        }

        #endregion

        #region private void HookDirective(BaseDetailDirective directive)

        private void HookDirective(BaseDetailDirective directive)
        {
            directive.Saved += Item_Saved;
            directive.Saving += Item_Saving;
            directive.Reloading += Item_Reloading;
            directive.Reloaded += Item_Reloaded;
        }

        #endregion

        #region private void HookNonRoutineJob(NonRoutineJob nonRoutineJob)

        private void HookNonRoutineJob(NonRoutineJob nonRoutineJob)
        {
            nonRoutineJob.Saved += Item_Saved;
            nonRoutineJob.Saving += Item_Saving;
            nonRoutineJob.Reloading += Item_Reloading;
            nonRoutineJob.Reloaded += Item_Reloaded;
        }

        #endregion

        #region public void UnHookItems()

        /// <summary>
        /// Отписка событий Saving и Saved
        /// </summary>
        public void UnHookItems()
        {
            for (int i = 0; i < currentWorkPackage.Details.Count; i++)
                UnHookDetail(currentWorkPackage.Details[i]);
            for (int i = 0; i < currentWorkPackage.Directives.Count; i++)
                UnHookDirective(currentWorkPackage.Directives[i]);
            for (int i = 0; i < currentWorkPackage.NonRoutineJobs.Count; i++)
                UnHookNonRoutineJob(currentWorkPackage.NonRoutineJobs[i]);
        }

        #endregion

        #region private void UnHookDetail(AbstractDetail item)

        private void UnHookDetail(AbstractDetail detail)
        {
            detail.Saved -= Item_Saved;
            detail.Saving -= Item_Saving;
            detail.Reloading -= Item_Reloading;
            detail.Reloaded -= Item_Reloaded;
        }

        #endregion

        #region private void UnHookDirective(BaseDetailDirective directive)

        private void UnHookDirective(BaseDetailDirective directive)
        {
            directive.Saved -= Item_Saved;
            directive.Saving -= Item_Saving;
            directive.Reloading -= Item_Reloading;
            directive.Reloaded -= Item_Reloaded;
        }

        #endregion

        #region private void UnHookNonRoutineJob(NonRoutineJob nonRoutineJob)

        private void UnHookNonRoutineJob(NonRoutineJob nonRoutineJob)
        {
            nonRoutineJob.Saved -= Item_Saved;
            nonRoutineJob.Saving -= Item_Saving;
            nonRoutineJob.Reloading -= Item_Reloading;
            nonRoutineJob.Reloaded -= Item_Reloaded;
        }

        #endregion

        #region private void HookItem(IMaintainable item)

        private void HookItem(IMaintainable item)
        {
            if (item is AbstractDetail)
                HookDetail((AbstractDetail)item);
            else if (item is BaseDetailDirective)
                HookDirective((BaseDetailDirective)item);
            else 
                HookNonRoutineJob((NonRoutineJob)item);
        }

        #endregion

        

        #region private void CurrentWorkPackage_ItemAdded(object sender, EventArgs e)

        private void CurrentWorkPackage_ItemAdded(object sender, CollectionChangeEventArgs e)
        {
            workPackageViewer.AddNewItem((IMaintainable)e.Element);
            HookItem((IMaintainable)e.Element);
        }


        #endregion

        #region private void CurrentWorkPackage_ItemRemoved(object sender, EventArgs e)

        private void CurrentWorkPackage_ItemRemoved(object sender, CollectionChangeEventArgs e)
        {
            workPackageViewer.DeleteItem((IMaintainable)e.Element);
        }

        #endregion
        
        #region private void Item_Saving(object sender, CancelEventArgs e)

        private void Item_Saving(object sender, CancelEventArgs e)
        {
            workPackageBeforeSaving = (IMaintainable)sender;
        }

        #endregion

        #region private void Item_Saved(object sender, EventArgs e)

        private void Item_Saved(object sender, EventArgs e)
        {
            workPackageViewer.EditItem(workPackageBeforeSaving, (IMaintainable)sender);
        }

        #endregion

        #region private void Item_Reloading(object sender, CancelEventArgs e)

        private void Item_Reloading(object sender, CancelEventArgs e)
        {
            if (!InvokeRequired)
                workPackageBeforeReloading = (IMaintainable)sender;
        }

        #endregion

        #region private void Item_Reloaded(object sender, EventArgs e)

        private void Item_Reloaded(object sender, EventArgs e)
        {
            if (!InvokeRequired)
            {
                workPackageViewer.EditItem(workPackageBeforeReloading, (IMaintainable)sender);
            }
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

            buttonCloseWorkPackage.Enabled = (permissionForUpdate && currentWorkPackage.Status == WorkPackageStatus.Published && workPackageViewer.Items.Length > 0 && enable);
            buttonPublishWorkPackage.Enabled = (permissionForUpdate && currentWorkPackage.Status == WorkPackageStatus.Open && workPackageViewer.Items.Length > 0 && enable);
            buttonAddNonRoutineJob.Enabled = toolStripMenuItemAddNonRoutineJob.Enabled = (permissionForCreate && currentWorkPackage.Status == WorkPackageStatus.Open && enable);
            workPackageViewer.Enabled = enable;
            headerControl.Enabled = enable;
            footerControl1.Enabled = enable;
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
            if (buttonCloseWorkPackage != null)
                buttonCloseWorkPackage.Location = new Point(Width - buttonCloseWorkPackage.Width - 5, 0);
            if (buttonPublishWorkPackage != null)
                buttonPublishWorkPackage.Location = new Point(buttonCloseWorkPackage.Left - buttonPublishWorkPackage.Width - 5, 0);
            if (buttonAddNonRoutineJob != null)
                buttonAddNonRoutineJob.Location = new Point(buttonPublishWorkPackage.Left - buttonAddNonRoutineJob.Width - 5, 0);
            if (buttonSaveToDisk != null)
                buttonSaveToDisk.Location = new Point(buttonAddNonRoutineJob.Left - buttonSaveToDisk.Width - 5, 0);
            if (buttonReleaseToService != null)
                buttonReleaseToService.Location = new Point(buttonSaveToDisk.Left - buttonReleaseToService.Width - 5, 0);
            if (buttonCoverSheet != null)
                buttonCoverSheet.Location = new Point(buttonReleaseToService.Left - buttonCoverSheet.Width - 5, 0);
            if (workPackageViewer != null)
            {
                workPackageViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                workPackageViewer.Size = new Size(Width, Height - headerControl.Height - footerControl1.Height - panelTopContainer.Height);
            }
        }

        #endregion

        #region private void ClipboardContentsChanged(object sender, EventArgs e)

        private void ClipboardContentsChanged(object sender, EventArgs e)
        {
            toolStripMenuItemPaste.Enabled = CASClipboard.Instance.Contains(typeof(IMaintainable));
        }

        #endregion

        #region private void WorkPackageScreen_InitComplition(object sender, EventArgs e)

        private void WorkPackageScreen_InitComplition(object sender, EventArgs e)
        {
            dispatcheredMultitabControl = (DispatcheredMultitabControl)sender;
            ((DispatcheredMultitabControl)sender).Closed += control_Closed;
            ((AvMultitabControl)sender).Selected += WorkPackageScreen_Selected;
        }

        #endregion

        #region private void WorkPackageScreen_Selected(object sender, AvMultitabControlEventArgs e)

        private void WorkPackageScreen_Selected(object sender, AvMultitabControlEventArgs e)
        {
            workPackageViewer.ItemsListView.Focus();
        }

        #endregion

        #region private void control_Closed(object sender, AvMultitabControlEventArgs e)

        private void control_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == Parent as DispatcheredTabPage)
            {
                UnHookItems();
                UnHookAddedAndRemovedItemsEvents();
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