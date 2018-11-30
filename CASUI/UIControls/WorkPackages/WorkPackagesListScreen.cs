using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.WorkPackages;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.WorkPackages;
using CAS.UI.Properties;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CASReports.Builders;
using CASTerms;
using Controls.AvButtonT;
using Controls.AvMultitabControl;
using Controls.AvMultitabControl.Auxiliary;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.WorkPackages
{
    ///<summary>
    /// Элемент управления для отображения списка рабочих пакетов
    ///</summary>
    [ToolboxItem(false)]
    public class WorkPackagesListScreen : UserControl, IReference
    {

        #region Fields

        protected Aircraft currentAircraft;

        //private WorkPackage workPackageBeforeSaving;
        private WorkPackage workPackageBeforeReloading;
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
        private RichReferenceButton buttonComposeWorkPackage;
        private AvButtonT buttonDeleteSelected;
        private WorkPackagesListView workPackagesViewer;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem toolStripMenuItemOpen;
        private ToolStripMenuItem toolStripMenuItemProperties;
        private ToolStripMenuItem toolStripMenuItemPublish;
        private ToolStripMenuItem toolStripMenuItemComposeWorkPackage;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItemClose;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuItemDelete;
        
        private IDisplayer displayer;
        private IDisplayingEntity entity;
        private string displayerText;
        private ReflectionTypes reflectionType;
        private DispatcheredMultitabControl dispatcheredMultitabControl;

        #endregion

        #region Constructor

        ///<summary>
        /// Создаёт элемент управления для отображения списка рабочих пакетов
        ///</summary>
        ///<param name="currentAircraft">ВС, которому принадлежат рабочие пакеты</param>
        public WorkPackagesListScreen(Aircraft currentAircraft)
        {
            if (currentAircraft == null)
                throw new ArgumentNullException("currentAircraft");
            this.currentAircraft = currentAircraft;
            permissionForCreate = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            permissionForDelete = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Remove);
            permissionForUpdate = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Update);
            ((DispatcheredWorkPackagesListScreen)this).InitComplition += WorkPackagesListScreen_InitComplition;
            currentAircraft.WorkPackageRemoved += CurrentAircraft_WorkPackageRemoved;
            currentAircraft.WorkPackageAdded += CurrentAircraft_WorkPackageAdded;
            InitializeComponent();
            UpdateElements();
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
            workPackagesViewer = new WorkPackagesListView(currentAircraft);
            panelTopContainer = new Panel();
            buttonDeleteSelected = new AvButtonT();
            buttonComposeWorkPackage = new RichReferenceButton();
            labelTitle = new StatusImageLinkLabel();
            footerControl1 = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeaderControl = new AircraftHeaderControl();

            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemOpen = new ToolStripMenuItem();
            toolStripMenuItemProperties = new ToolStripMenuItem();
            toolStripMenuItemPublish = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemComposeWorkPackage = new ToolStripMenuItem();
            toolStripMenuItemClose = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            // 
            // headerControl
            // 
            headerControl.ActionControlSplitterVisible = true;

            headerControl.BackColor = Color.Transparent;
            headerControl.BackgroundImage = Resources.HeaderBar;
            headerControl.Controls.Add(aircraftHeaderControl);
            headerControl.Dock = DockStyle.Top;
            headerControl.ActionControl.ShowEditButton = false;
            headerControl.ContextActionControl.ShowPrintButton = true;
            headerControl.ContextActionControl.ButtonPrint.DisplayerRequested += ButtonPrint_DisplayerRequested;
            headerControl.Location = new Point(0, 0);
            headerControl.Size = new Size(1042, 58);
            headerControl.TabIndex = 0;
            headerControl.ReloadRised += ButtonReload_Click;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "airworthiness-directives-status.html";
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
            panelTopContainer.Controls.Add(buttonDeleteSelected);
            panelTopContainer.Controls.Add(buttonComposeWorkPackage);
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
            buttonComposeWorkPackage.ReflectionType = ReflectionTypes.DisplayInNew;
            buttonComposeWorkPackage.Size = new Size(180, 59);
            buttonComposeWorkPackage.TabIndex = 19;
            buttonComposeWorkPackage.TextAlignMain = ContentAlignment.BottomCenter;
            buttonComposeWorkPackage.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonComposeWorkPackage.TextMain = "Compose a";
            buttonComposeWorkPackage.TextSecondary = "Work Package";
            buttonComposeWorkPackage.DisplayerRequested += ButtonComposeWorkPackage_DisplayerRequested;
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
            // workPackagesViewer
            //
            workPackagesViewer.ItemsListView.ContextMenuStrip = contextMenuStrip;
            workPackagesViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
            workPackagesViewer.SelectedItemsChanged += directivesViewer_SelectedItemsChanged;
            Controls.Add(workPackagesViewer);
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    toolStripMenuItemOpen,
                                                    toolStripMenuItemProperties,
                                                    toolStripSeparator1,
                                                    toolStripMenuItemPublish,
                                                    toolStripMenuItemClose,
                                                    toolStripSeparator2,
                                                    toolStripMenuItemComposeWorkPackage,
                                                    toolStripMenuItemDelete
                                                });
            contextMenuStrip.Size = new Size(179, 176);

            // 
            // toolStripMenuItemOpen
            // 
            toolStripMenuItemOpen.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            toolStripMenuItemOpen.Size = new Size(178, 22);
            //toolStripMenuItemOpen.Text = "View details";
            toolStripMenuItemOpen.Click += toolStripMenuItemOpen_Click;
            // 
            // toolStripMenuItemProperties
            // 
            toolStripMenuItemProperties.Size = new Size(178, 22);
            toolStripMenuItemProperties.Click += toolStripMenuItemProperties_Click;
            toolStripMenuItemProperties.Text = "Properties";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Size = new Size(175, 6);
            // 
            // toolStripMenuItemPublish
            // 
            toolStripMenuItemPublish.Size = new Size(178, 22);
            toolStripMenuItemPublish.Text = "Publish";
            toolStripMenuItemPublish.Click += toolStripMenuItemAdd_Click;
            // 
            // toolStripMenuItemClose
            // 
            toolStripMenuItemClose.Size = new Size(178, 22);
            toolStripMenuItemClose.Text = "Close";
            toolStripMenuItemClose.Click += toolStripMenuItemClose_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Size = new Size(175, 6);
            // 
            // toolStripMenuItemComposeWorkPackage
            // 
            toolStripMenuItemComposeWorkPackage.Size = new Size(178, 22);
            toolStripMenuItemComposeWorkPackage.Text = "Compose a Work Package";
            toolStripMenuItemComposeWorkPackage.Click += toolStripMenuItemPerform_Click;
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
                currentAircraft.Reload(true);
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
            dispatcheredMultitabControl.SetEnabledToAllEntityes(true);
            UpdateElements();
        }

        #endregion

        #region public override void UpdateElements()

        /// <summary>
        /// Происзодит обновление отображения элементов
        /// </summary>
        public void UpdateElements()
        {
            labelTitle.Text = currentAircraft.RegistrationNumber + ". Work Packages";
            aircraftHeaderControl.Aircraft = currentAircraft;
            
            HookWorkPackages();
            workPackagesViewer.UpdateItems();

            toolStripMenuItemComposeWorkPackage.Enabled = buttonComposeWorkPackage.Enabled = permissionForCreate;
            CheckContextMenu(workPackagesViewer.SelectedItems.Count);

            headerControl.ContextActionControl.ButtonPrint.Enabled = workPackagesViewer.ItemsListView.Items.Count != 0;
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

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". List of Work Packages. Report";
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            WorkPackagesReportBuilder builder = new WorkPackagesReportBuilder(currentAircraft);
            e.RequestedEntity = new DispatcheredWorkPackagesReport(builder);
        }

        #endregion

        #region private void ButtonComposeWorkPackage_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonComposeWorkPackage_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            WorkPackageForm form = new WorkPackageForm(currentAircraft);
            form.ShowDialog();
            e.Cancel = true;
        }

        #endregion

        #region private void ButtonDelete_Click(object sender, EventArgs e)

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if ((workPackagesViewer.SelectedItems == null) && (workPackagesViewer.SelectedItem == null)) return;
            DialogResult confirmResult =
                MessageBox.Show(
                    workPackagesViewer.SelectedItem != null
                        ? "Do you really want to delete work package " + workPackagesViewer.SelectedItem.Title + "?"
                        : "Do you really want to delete selected work packages? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                int count = workPackagesViewer.SelectedItems.Count;

                List<WorkPackage> selectedItems = new List<WorkPackage>(workPackagesViewer.SelectedItems);
                workPackagesViewer.ItemsListView.BeginUpdate();
                for (int i = 0; i < count; i++)
                {
                            try
                            {
                                currentAircraft.RemoveWorkPackage(selectedItems[i]);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error while deleting data" + Environment.NewLine + ex.Message,
                                                (string) new GlobalTermsProvider()["SystemName"],
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                }
                workPackagesViewer.ItemsListView.EndUpdate();
                //ReloadElements();
            }
        }

        #endregion

        #region private void workPackagesViewer_SelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)

        private void directivesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            CheckContextMenu(e.ItemsCount);
        }

        #endregion

        #region private void toolStripMenuItemOpen_Click(object sender, EventArgs e)

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            OpenWorkPackages();
        }

        #endregion

        #region private void toolStripMenuItemProperties_Click(object sender, EventArgs e)

        private void toolStripMenuItemProperties_Click(object sender, EventArgs e)
        {
            WorkPackageForm form = new WorkPackageForm(workPackagesViewer.SelectedItem);
            form.ShowDialog();
        }

        #endregion


        #region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            ButtonDelete_Click(sender, e);
        }

        #endregion

        #region private void toolStripMenuItemComposeWorkPackage_Click(object sender, EventArgs e)

        private void toolStripMenuItemPerform_Click(object sender, EventArgs e)
        {
            ButtonComposeWorkPackage_DisplayerRequested(sender, new ReferenceEventArgs());
        }

        #endregion

        #region private void toolStripMenuItemClose_Click(object sender, EventArgs e)

        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
  //          if (workPackagesViewer.SelectedItem != null)
//                OnAddRecord(RecordTypesCollection.Instance.DirectiveClosingRecordType);
        }

        #endregion

        #region private void toolStripMenuItemPublish_Click(object sender, EventArgs e)

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs argumetns = new ReferenceEventArgs();
            ButtonComposeWorkPackage_DisplayerRequested(this, argumetns);
            OnDisplayerRequested(argumetns);
        }

        #endregion

        #region protected void OpenWorkPackages()

        /// <summary>
        /// Обработка запроса открытия нескольких рабочих пакетов
        /// </summary>
        protected void OpenWorkPackages()
        {
            for (int i = 0; i < workPackagesViewer.SelectedItems.Count; i++)
            {
                OnDisplayerRequested(new ReferenceEventArgs(new DispatcheredWorkPackageScreen(workPackagesViewer.SelectedItems[i]), ReflectionTypes.DisplayInNew, null,
                        currentAircraft.RegistrationNumber + ". " + workPackagesViewer.SelectedItems[i].Title));
            }
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
            buttonDeleteSelected.Enabled = (count > 0) && permissionForDelete;
            toolStripMenuItemOpen.Enabled = toolStripMenuItemDelete.Enabled = (count > 0);
            toolStripMenuItemProperties.Enabled = (count == 1 && permissionForUpdate);
            toolStripMenuItemPublish.Enabled = (count == 1 && workPackagesViewer.SelectedItems[0].Status == WorkPackageStatus.Open);
            toolStripMenuItemClose.Enabled = (count == 1 && workPackagesViewer.SelectedItems[0].Status == WorkPackageStatus.Published);

            if (count == 1)
            {
                toolStripMenuItemOpen.Text = "Open " + workPackagesViewer.SelectedItems[0].Title;
            }
            else
            {
                if (count == 0)
                    toolStripMenuItemOpen.Text = "Nothing selected";
                else
                    toolStripMenuItemOpen.Text = "Open Work Packages";
            }
        }

        #endregion

        #region private void CurrentAircraft_WorkPackageRemoved(object sender, EventArgs e)

        private void CurrentAircraft_WorkPackageRemoved(object sender, CollectionChangeEventArgs e)
        {
            workPackagesViewer.DeleteItem((WorkPackage)e.Element);
        }

        #endregion

        #region private void CurrentAircraft_WorkPackageAdded(object sender, EventArgs e)

        private void CurrentAircraft_WorkPackageAdded(object sender, CollectionChangeEventArgs e)
        {
            workPackagesViewer.AddNewItem((WorkPackage) e.Element);
            HookWorkPackage((WorkPackage)e.Element);

        }

        #endregion

        #region private void WorkPackage_Saving(object sender, CancelEventArgs e)

        private void WorkPackage_Saving(object sender, CancelEventArgs e)
        {
//            workPackageBeforeSaving = (WorkPackage)sender;
        }

        #endregion

        #region private void WorkPackage_Saved(object sender, EventArgs e)

        private void WorkPackage_Saved(object sender, EventArgs e)
        {
            //WorkPackage workPackage = (WorkPackage) sender;
            //if (workPackageBeforeSaving.Status != workPackage.Status)
                workPackagesViewer.UpdateItems();
            //else 
                //workPackagesViewer.EditItem(workPackageBeforeSaving, workPackage);
        }

        #endregion

        #region private void HookWorkPackages()

        private void HookWorkPackages()
        {
            for (int j = 0; j < currentAircraft.WorkPackages.Length; j++)
            {
                HookWorkPackage(currentAircraft.WorkPackages[j]);
            }
        }

        #endregion

        #region private void HookWorkPackage(WorkPackage currentWorkPackage)

        private void HookWorkPackage(WorkPackage workPackage)
        {
            UnHookWorkPackage(workPackage);
            workPackage.Saving += WorkPackage_Saving;
            workPackage.Saved += WorkPackage_Saved;
            workPackage.Reloading += WorkPackage_Reloading;
            workPackage.Reloaded += WorkPackage_Reloaded;
        }

        #endregion

        #region public void UnHookWorkPackages()

        /// <summary>
        /// Отписка событий Saving и Saved
        /// </summary>
        public void UnHookWorkPackages()
        {
            for (int i = 0; i < currentAircraft.WorkPackages.Length; i++)
            {
                UnHookWorkPackage(currentAircraft.WorkPackages[i]);
            }
        }

        #endregion

        #region private void UnHookWorkPackage(WorkPackage currentWorkPackage)

        private void UnHookWorkPackage(WorkPackage workPackage)
        {
            workPackage.Saved -= WorkPackage_Saved;
            workPackage.Saving -= WorkPackage_Saving;
            workPackage.Reloading -= WorkPackage_Reloading;
            workPackage.Reloaded -= WorkPackage_Reloaded;
        }

        #endregion

        #region private void WorkPackage_Reloading(object sender, CancelEventArgs e)

        private void WorkPackage_Reloading(object sender, CancelEventArgs e)
        {
            if (!InvokeRequired) 
                workPackageBeforeReloading = (WorkPackage) sender;
        }

        #endregion

        #region private void WorkPackage_Reloaded(object sender, EventArgs e)

        private void WorkPackage_Reloaded(object sender, EventArgs e)
        {
            if (!InvokeRequired)
            {
                workPackagesViewer.EditItem(workPackageBeforeReloading, (WorkPackage) sender);
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
            buttonDeleteSelected.Enabled = enable;
            buttonComposeWorkPackage.Enabled = enable;
            workPackagesViewer.Enabled = enable;
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
            if (buttonDeleteSelected != null)
                buttonDeleteSelected.Location = new Point(Width - buttonDeleteSelected.Width - 5, 0);
            if (buttonComposeWorkPackage != null)
                buttonComposeWorkPackage.Location = new Point(buttonDeleteSelected.Left - buttonComposeWorkPackage.Width - 5, 0);

            if (workPackagesViewer != null)
            {
                workPackagesViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                workPackagesViewer.Size = new Size(Width, Height - headerControl.Height - footerControl1.Height - panelTopContainer.Height);
            }
        }

        #endregion

        #region private void WorkPackagesListScreen_InitComplition(object sender, EventArgs e)

        private void WorkPackagesListScreen_InitComplition(object sender, EventArgs e)
        {
            dispatcheredMultitabControl = (DispatcheredMultitabControl)sender;
            ((DispatcheredMultitabControl)sender).Closed += control_Closed;
            ((AvMultitabControl)sender).Selected += WorkPackagesListScreen_Selected;
        }

        #endregion

        #region private void WorkPackagesListScreen_Selected(object sender, AvMultitabControlEventArgs e)

        private void WorkPackagesListScreen_Selected(object sender, AvMultitabControlEventArgs e)
        {
            workPackagesViewer.ItemsListView.Focus();
        }

        #endregion

        #region private void control_Closed(object sender, AvMultitabControlEventArgs e)

        private void control_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == Parent as DispatcheredTabPage)
            {
                UnHookWorkPackages();
                currentAircraft.WorkPackageRemoved -= CurrentAircraft_WorkPackageRemoved;
                currentAircraft.WorkPackageAdded -= CurrentAircraft_WorkPackageAdded;
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

        #region public event EventHandler BackgroundWorkStart;

        /// <summary>
        /// Событие повествующие о начале работы алгоритма в другом потоке
        /// </summary>
        public event EventHandler BackgroundWorkStart;

        #endregion

        #region public event EventHandler BackgroundWorkEnd;

        /// <summary>
        /// Событие повествующие о конце работы алгоритма в другом потоке
        /// </summary>
        public event EventHandler BackgroundWorkEnd;

        #endregion
        
        #endregion
    }
}