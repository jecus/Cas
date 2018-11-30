using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.ModificationsPerformed;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.Properties;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CASReports.Builders;
using Controls;
using Controls.AvButtonT;
using Controls.AvMultitabControl;
using Controls.AvMultitabControl.Auxiliary;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.ModificationsPerformed
{
    /// <summary>
    /// Элемент управления для работы со списком <see cref="Core.Types.Directives.ModificationItem"/> 
    /// </summary>
    [ToolboxItem(false)]
    public class ModificationsPerformedListScreen : UserControl, IReference
    {

        #region Fields

        private Aircraft currentAircraft;
        private AnimatedThreadWorker animatedThreadWorker;
        private readonly DirectiveCollectionFilter additionalFilter = new DirectiveCollectionFilter(new DirectiveFilter[0]);
        private ModificationsPerformedListView modificationItemsViewer;
        private ModificationItem modificationItemBeforeSaving;
        private ModificationItem modificationItemBeforeReloading;


        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem toolStripMenuItemOpen;
        private ToolStripMenuItem toolStripMenuItemAddNew;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private HeaderControl headerControl1;
        private FooterControl footerControl1;
        private AircraftHeaderControl aircraftHeaderControl;
        private Panel panelTopContainer;
        private AvButtonT buttonApplyFilter;
        private RichReferenceButton buttonAddDirective;
        private AvButtonT buttonDeleteSelected;
        private StatusImageLinkLabel labelTitle;

        private readonly Icons icons = new Icons();


        private IDisplayer displayer;
        private IDisplayingEntity entity;
        private string displayerText;
        private ReflectionTypes reflectionType;

        private bool permissionForUpdate = true;
        private bool permissionForDelete = true;
        private bool permissionForCreate = true;

        #endregion

        #region Constructor

        #region public ModificationsPerformedListScreen(Aircraft currentAircraft)

        /// <summary>
        /// Создает элемент управления для работы со списком <see cref="Core.Types.Directives.ModificationItem"/> 
        /// </summary>
        ///<param name="currentAircraft">ВС, которому принадлежат ModificationItems</param>
        public ModificationsPerformedListScreen(Aircraft currentAircraft)
        {
            if (currentAircraft == null)
                throw new ArgumentNullException("currentAircraft");
            this.currentAircraft = currentAircraft;
            ((DispatcheredModificationsPerformedListScreen)this).InitComplition += ModificationsPerformedListScreen_InitComplition;
            InitializeComponent();
            CheckPermission();
            HookModificationItemsCollection();
            UpdateElements();
        }

        #endregion

        #endregion

        #region Properties

        #region public Aircraft CurrentAircraft

        /// <summary>
        /// ВС для которого отображаются элементы( базовый агрегат, или все директивы)
        /// </summary>
        public Aircraft CurrentAircraft
        {
            get { return currentAircraft; }
            set
            {
                currentAircraft = value;
                UpdateElements();
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

        #region public DirectiveCollectionFilter AdditionalFilter

        /// <summary>
        /// Примененный фильтр
        /// </summary>
        public DirectiveCollectionFilter AdditionalFilter
        {
            get { return additionalFilter; }
        }

        #endregion

        #region public ListView ItemsListView

        /// <summary>
        /// Возвращает ListView с директивами
        /// </summary>
        public ListView ItemsListView
        {
            get { return modificationItemsViewer.ItemsListView; }
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
            labelTitle = new StatusImageLinkLabel();
            footerControl1 = new FooterControl();
            headerControl1 = new HeaderControl();
            aircraftHeaderControl = new AircraftHeaderControl();
            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemAddNew = new ToolStripMenuItem();
            toolStripMenuItemOpen = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    toolStripMenuItemOpen,
                                                    toolStripMenuItemAddNew,
                                                    toolStripSeparator1,
                                                    toolStripMenuItemDelete
                                                });
            contextMenuStrip.Size = new Size(179, 176);
            // 
            // toolStripMenuItemOpen
            // 
            toolStripMenuItemOpen.Size = new Size(178, 22);
            toolStripMenuItemOpen.Click += toolStripMenuItemOpen_Click;
            // 
            // toolStripMenuItemAddNew
            // 
            toolStripMenuItemAddNew.Size = new Size(178, 22);
            toolStripMenuItemAddNew.Text = "Add New Modification Item";
            toolStripMenuItemAddNew.Click += toolStripMenuItemAddNew_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Size = new Size(175, 6);
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Size = new Size(178, 22);
            toolStripMenuItemDelete.Text = "Delete";
            toolStripMenuItemDelete.Click += toolStripMenuItemDelete_Click;
            // 
            // panelTopContainer
            // 
            panelTopContainer.AutoSize = true;
            panelTopContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelTopContainer.BackColor = Color.LightGray;
            panelTopContainer.Controls.Add(buttonDeleteSelected);
            panelTopContainer.Controls.Add(buttonApplyFilter);
            panelTopContainer.Controls.Add(buttonAddDirective);
            panelTopContainer.Controls.Add(labelTitle);
            panelTopContainer.Dock = DockStyle.Top;
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
            buttonApplyFilter.Visible = false;
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
            buttonAddDirective.Size = new Size(140, 59);
            buttonAddDirective.TabIndex = 19;
            buttonAddDirective.TextAlignMain = ContentAlignment.BottomCenter;
            buttonAddDirective.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddDirective.TextMain = "Add new";
            buttonAddDirective.TextSecondary = "record";
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
            labelTitle.Size = new Size(600, 27);
            labelTitle.TabIndex = 16;
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // headerControl1
            // 
            headerControl1.ActionControlSplitterVisible = true;

            headerControl1.BackColor = Color.Transparent;
            headerControl1.BackgroundImage = Resources.HeaderBar;
            headerControl1.Controls.Add(aircraftHeaderControl);
            headerControl1.Dock = DockStyle.Top;
            headerControl1.EditDisplayerText = "Edit operator";
            headerControl1.ContextActionControl.ShowPrintButton = true;
            headerControl1.ContextActionControl.ButtonPrint.DisplayerRequested += ButtonPrint_DisplayerRequested;
            headerControl1.EditReflectionType = ReflectionTypes.DisplayInNew;
            headerControl1.Location = new Point(0, 0);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new Size(1042, 58);
            headerControl1.TabIndex = 0;
            headerControl1.EditDisplayerRequested += ButtonEdit_DisplayerRequested;
            headerControl1.ReloadRised += ButtonReload_Click;
            if (!permissionForUpdate)
            {
                headerControl1.ActionControl.ButtonEdit.TextMain = "View";
                headerControl1.ActionControl.ButtonEdit.Icon = icons.View;
                headerControl1.ActionControl.ButtonEdit.IconNotEnabled = icons.ViewGray;
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
            Controls.Add(footerControl1);
            Controls.Add(headerControl1);
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
                animatedThreadWorker.State = "Reloading records";
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
                CurrentAircraft.Reload(true);
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

        #region public override void UpdateElements()

        /// <summary>
        /// Происзодит обновление отображения элементов
        /// </summary>
        public void UpdateElements()
        {
            if (currentAircraft != null)
            {
                labelTitle.Text = currentAircraft.RegistrationNumber + ". List of Modifications Performed";
                //filterSelection.PageTitle = labelTitle.Text;
            }
            else
            {
                labelTitle.Text = "List of Modifications Performed";
                labelTitle.Status = Statuses.NotActive;
            }

            UpdateHeader();
            UpdateDirectives();
        }

        #endregion

        #region private void UpdateDirectives()

        private void UpdateDirectives()
        {
            HookModificationItems(currentAircraft.ModificationItems);
            if (modificationItemsViewer == null)
            {
                modificationItemsViewer = new ModificationsPerformedListView(currentAircraft);
                modificationItemsViewer.TabIndex = 2;
                modificationItemsViewer.ItemsListView.ContextMenuStrip = contextMenuStrip;
                modificationItemsViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                modificationItemsViewer.SelectedItemsChanged += directivesViewer_SelectedItemsChanged;
                Controls.Add(modificationItemsViewer);
            }
            else
            {
                modificationItemsViewer.UpdateItems();
                modificationItemsViewer.PreviousSort();
            }
            buttonAddDirective.Enabled = toolStripMenuItemAddNew.Enabled = permissionForCreate;
            headerControl1.ContextActionControl.ButtonPrint.Enabled = modificationItemsViewer.ItemsListView.Items.Count > 0;
            CheckContextMenu(modificationItemsViewer.SelectedItems.Count);
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

        #region private void ButtonReload_Click(object sender, EventArgs e)

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            ReloadElements();
        }

        #endregion

        #region private void ButtonEdit_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonEdit_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = currentAircraft.RegistrationNumber + ". " + modificationItemsViewer.SelectedItem.SbNo +
                              " " + modificationItemsViewer.SelectedItem.EngineeringOrderNo + " " +
                              modificationItemsViewer.SelectedItem.AirworthinessDirectiveNo + " Record";
            e.RequestedEntity = new DispatcheredModificationItemScreen(modificationItemsViewer.SelectedItem);
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". List of Modifications Performed Report";
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            ModificationItemsReportBuilder reportBuilder = new ModificationItemsReportBuilder(currentAircraft);
            e.RequestedEntity = new DispatcheredModificationItemsReport(reportBuilder);
        }

        #endregion

        #region private void ButtonApplyFilter_Click(object sender, EventArgs e)

        private void ButtonApplyFilter_Click(object sender, EventArgs e)
        {
/*            filterSelection.PageTitle = labelTitle.Text;
            filterSelection.SetFilterParameters(additionalFilter);
            filterSelection.Show();
            filterSelection.BringToFront();*/
/*            filterSelection.ReloadForDate -= filterSelection_ReloadForDate;
            filterSelection.ApplyFilter -= filterSelection_ApplyFilter;
            filterSelection.ReloadForDate += filterSelection_ReloadForDate;
            filterSelection.ApplyFilter += filterSelection_ApplyFilter;*/
        }

        #endregion

        #region private void ButtonAddDirective_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonAddDirective_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = CurrentAircraft.RegistrationNumber + ". New Record";
            e.RequestedEntity = new DispatcheredModificationItemAdding(CurrentAircraft);
        }

        #endregion

        #region private void ButtonDelete_Click(object sender, EventArgs e)

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if ((modificationItemsViewer.SelectedItems == null) && (modificationItemsViewer.SelectedItem == null))
                return;
            DialogResult confirmResult =
                MessageBox.Show(
                    modificationItemsViewer.SelectedItem != null
                        ? "Do you really want to delete current item?"
                        : "Do you really want to delete selected items? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                int count = modificationItemsViewer.SelectedItems.Count;
                List<ModificationItem> selectedItems = new List<ModificationItem>(modificationItemsViewer.SelectedItems);
                modificationItemsViewer.ItemsListView.BeginUpdate();
                for (int i = 0; i < count; i++)
                {

                    try
                    {
                        currentAircraft.RemoveModificationItem(selectedItems[i]);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex); return;
                    }
                }
                modificationItemsViewer.ItemsListView.EndUpdate();
            }
        }

        #endregion

        #region public void CloseFilter()

        /// <summary>
        /// Закрытие формы выбора фильтра
        /// </summary>
        public void CloseFilter()
        {
            // filterSelection.Close();
        }

        #endregion

        #region private void modificationItemsViewer_SelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)

        private void directivesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            CheckContextMenu(e.ItemsCount);
        }

        #endregion



        #region private void toolStripMenuItemOpen_Click(object sender, EventArgs e)

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            OnOpenModificationsPerformed();
        }

        #endregion

        #region private void toolStripMenuItemAddNew_Click(object sender, EventArgs e)

        private void toolStripMenuItemAddNew_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs argumetns = new ReferenceEventArgs();
            argumetns.TypeOfReflection = ReflectionTypes.DisplayInNew;
            argumetns.DisplayerText = CurrentAircraft.RegistrationNumber + ". New Record";
            argumetns.RequestedEntity = new DispatcheredModificationItemAdding(CurrentAircraft);
            OnDisplayerRequested(argumetns);
        }

        #endregion

        #region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            ButtonDelete_Click(sender, e);
        }

        #endregion

        
        #region private void OnOpenModificationsPerformed()

        private void OnOpenModificationsPerformed()
        {
            List<ModificationItem> selected = modificationItemsViewer.SelectedItems;

            for (int i = 0; i < selected.Count; i++)
            {
                ReferenceEventArgs e = new ReferenceEventArgs();
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = currentAircraft.RegistrationNumber + ". " + selected[i].SbNo + " " + selected[i].EngineeringOrderNo + " " + selected[i].AirworthinessDirectiveNo + " Record";
                e.RequestedEntity = new DispatcheredModificationItemScreen(selected[i]);
                OnDisplayerRequested(e);
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
            buttonDeleteSelected.Enabled = toolStripMenuItemDelete.Enabled = (count > 0) && permissionForDelete;
            headerControl1.ActionControl.ButtonEdit.Enabled = (count == 1);

            toolStripMenuItemOpen.Enabled = count > 0;

            if (count == 1)
            {
                toolStripMenuItemOpen.Text = "Go to " + modificationItemsViewer.SelectedItem.SbNo + " " + modificationItemsViewer.SelectedItem.EngineeringOrderNo + " " + modificationItemsViewer.SelectedItem.AirworthinessDirectiveNo + " Record";
            }
            else
            {
                if (count == 0)
                    toolStripMenuItemOpen.Text = "Nothing selected";
                else
                    toolStripMenuItemOpen.Text = "Open records";
            }
        }

        #endregion




        #region private void HookModificationItemsCollection()

        private void HookModificationItemsCollection()
        {
            currentAircraft.ModificationItemRemoved += currentAircraft_ModificationItemRemoved;
            currentAircraft.ModificationItemAdded += currentAircraft_ModificationItemAdded;
        }

        #endregion

        #region private void UnHookModificationItemsCollection()

        private void UnHookModificationItemsCollection()
        {
            currentAircraft.ModificationItemRemoved -= currentAircraft_ModificationItemRemoved;
            currentAircraft.ModificationItemAdded -= currentAircraft_ModificationItemAdded;
        }

        #endregion

        #region private void HookModificationItems(ModificationItem[] modificationItemsArray)

        private void HookModificationItems(ModificationItem [] modificationItemsArray)
        {
            int length = modificationItemsArray.Length;
            for (int j = 0; j < length; j++)
            {
                HookModificationItem(modificationItemsArray[j]);
            }
        }

        #endregion

        #region private void HookModificationItem(ModificationItem directive )

        private void HookModificationItem(ModificationItem directive)
        {
            UnHookModificationItem(directive);
            directive.Saving += ModificationItemListControl_Saving;
            directive.Saved += ModificationItemListControl_Saved;
            directive.Reloading += modificationItem_Reloading;
            directive.Reloaded += modificationItem_Reloaded;
        }

        #endregion

        #region public void UnHookModificationItems()

        /// <summary>
        /// Отписка событий Saveing Saved
        /// </summary>
        public void UnHookModificationItems()
        {
            ModificationItem [] modificationItems = currentAircraft.ModificationItems;

            for (int i = 0; i < modificationItems.Length; i++)
            {
                UnHookModificationItem(modificationItems[i]);
            }
        }

        #endregion

        #region private void UnHookModificationItem(BaseDetailDirective directive)

        private void UnHookModificationItem(ModificationItem modificationItem)
        {
            modificationItem.Saved -= ModificationItemListControl_Saved;
            modificationItem.Saving -= ModificationItemListControl_Saving;
            modificationItem.Reloading -= modificationItem_Reloading;
            modificationItem.Reloaded -= modificationItem_Reloaded;
        }

        #endregion




        #region private void currentAircraft_ModificationItemRemoved(object sender, EventArgs e)

        private void currentAircraft_ModificationItemRemoved(object sender, CollectionChangeEventArgs e)
        {
            modificationItemsViewer.DeleteItem((ModificationItem)e.Element);
        }

        #endregion

        #region private void currentAircraft_ModificationItemAdded(object sender, EventArgs e)

        private void currentAircraft_ModificationItemAdded(object sender, CollectionChangeEventArgs e)
        {
            modificationItemsViewer.AddNewItem((ModificationItem)e.Element);
            HookModificationItem((ModificationItem)e.Element);
        }

        #endregion

        #region private void DirectiveListScreen_Saving(object sender, CancelEventArgs e)

        private void ModificationItemListControl_Saving(object sender, CancelEventArgs e)
        {
            modificationItemBeforeSaving = (ModificationItem)sender;
        }

        #endregion

        #region private void DirectiveListScreen_Saved(object sender, EventArgs e)

        private void ModificationItemListControl_Saved(object sender, EventArgs e)
        {
            modificationItemsViewer.EditItem(modificationItemBeforeSaving, (ModificationItem)sender);
        }

        #endregion

        #region private void modificationItem_Reloading(object sender, CancelEventArgs e)

        private void modificationItem_Reloading(object sender, CancelEventArgs e)
        {
            if (!InvokeRequired) modificationItemBeforeReloading = (ModificationItem) sender;
        }

        #endregion

        #region private void modificationItem_Reloaded(object sender, EventArgs e)

        private void modificationItem_Reloaded(object sender, EventArgs e)
        {
            if (!InvokeRequired)
            {
                modificationItemsViewer.EditItem(modificationItemBeforeReloading, (ModificationItem) sender);
            }
        }

        #endregion


        #region private void ModificationsPerformedListScreen_InitComplition(object sender, EventArgs e)

        private void ModificationsPerformedListScreen_InitComplition(object sender, EventArgs e)
        {
            ((DispatcheredMultitabControl)sender).Closed += control_Closed;
            ((AvMultitabControl)sender).Selected += ModificationsPerformedListScreen_Selected;
        }

        #endregion

        #region private void ModificationsPerformedListScreen_Selected(object sender, AvMultitabControlEventArgs e)

        private void ModificationsPerformedListScreen_Selected(object sender, AvMultitabControlEventArgs e)
        {
            modificationItemsViewer.ItemsListView.Focus();
        }

        #endregion

        #region private void control_Closed(object sender, AvMultitabControlEventArgs e)

        private void control_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == Parent as DispatcheredTabPage)
            {
                UnHookModificationItems();
                UnHookModificationItemsCollection();
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
            buttonApplyFilter.Enabled = enable;
            buttonAddDirective.Enabled = enable;
            //labelDateAsOf.Enabled = enable;
            //linkSetDate.Enabled = enable;
            //labelTSNCSN.Enabled = enable;
            modificationItemsViewer.Enabled = enable;
            headerControl1.Enabled = enable;
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
            if (buttonAddDirective != null)
                buttonAddDirective.Location = new Point(buttonDeleteSelected.Left - buttonAddDirective.Width - 5, 0);
            if (buttonApplyFilter != null)
                buttonApplyFilter.Location = new Point(buttonAddDirective.Left - buttonApplyFilter.Width - 5, 0);

            if (modificationItemsViewer != null)
            {
                modificationItemsViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                modificationItemsViewer.Size =
                    new Size(Width,
                             Height - headerControl1.Height - footerControl1.Height - // panelBottomContainer.Height -
                             panelTopContainer.Height);
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