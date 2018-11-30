using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
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
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.EngineeringOrdersDirectives;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.WorkPackages;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.WorkPackages;
using CASReports.Builders;
using Controls;
using Controls.AvButtonT;
using Controls.AvMultitabControl.Auxiliary;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.EngineeringOrdersDirectives
{
    /// <summary>
    /// Элемент управления для работы со списком директив <see cref="EngineeringOrderDirective"/> 
    /// </summary>
    public class EngineeringOrdersDirectiveListScreen : Control, IReference
    {

        #region Fields


        protected BaseDetail parentBaseDetail;
        private readonly DirectiveCollectionFilter directiveFilter;
        private DirectiveCollectionFilter additionalFilter = new DirectiveCollectionFilter(new DirectiveFilter[0]); 
        private EngineeringOrdersDirectiveListView directiveListView;
        private readonly DirectiveFilterSelectionForm filterSelection = new DirectiveFilterSelectionForm(DirectiveTypeCollection.Instance.EngineeringOrdersDirectiveType, null);
        private EngineeringOrderDirective editedDirective; 

        private readonly Icons icons = new Icons();
        private AnimatedThreadWorker animatedThreadWorker;
        private DispatcheredMultitabControl dispatcheredMultitabControl;

        private AircraftHeaderControl aircraftHeaderControl;
        private RichReferenceButton buttonAddDirective;
        private AvButtonT buttonApplyFilter;
        private AvButtonT buttonDeleteSelected;
        private ContextMenuStrip contextMenuStrip;
        private FooterControl footerControl1;
        private HeaderControl headerControl;
        private Label labelDateAsOf;
        private StatusImageLinkLabel labelTitle;
        /// <summary>
        /// Панель, содержащая кнопки управления
        /// </summary>
        protected Panel panelTopContainer;
        private ToolStripMenuItem toolStripMenuItemOpen;
        private ToolStripMenuItem toolStripMenuItemCreateNew;
        private List<ToolStripMenuItem> toolStripMenuItemsWorkPackages;
        private ToolStripMenuItem toolStripMenuItemComposeWorkPackage;
        private ToolStripMenuItem toolStripMenuItemCopy;
        private ToolStripMenuItem toolStripMenuItemPaste;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        
        private readonly bool permissionForUpdate = true;
        private readonly bool permissionForDelete = true;
        private readonly bool permissionForCreate = true;
        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        #endregion

        #region Constructor

        #region public EngineeringOrdersDirectiveListScreen(BaseDetail parentBaseDetail)

        ///<summary>
        /// Создаёт элемент управления для работы со списком директив <see cref="EngineeringOrderDirective"/> 
        ///</summary>
        ///<param name="parentBaseDetail">Базовый агрегат, к которому принадлежат директивы</param>
        public EngineeringOrdersDirectiveListScreen(BaseDetail parentBaseDetail)
        {
            if (parentBaseDetail == null)
                throw new ArgumentNullException("parentBaseDetail");
            ((DispatcheredEngeneeringOrdersDirectiveListScreen)this).InitComplition += EngineeringOrdersDirectiveListScreen_InitComplition;
            CASClipboard.Instance.ClipboardContentsChanged += ClipboardContentsChanged;
            permissionForCreate = DirectiveCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            permissionForDelete = DirectiveCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Remove);
            permissionForUpdate = DirectiveCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Update);
            this.parentBaseDetail = parentBaseDetail;
            directiveFilter = new DirectiveCollectionFilter(new DirectiveFilter[1] { new EngeneeringOrderFilter() });
            InitializeComponent();
            SetToolStripMenuItems();
            HookWorkPackageEvents();
            UpdateScreen();
        }

        #endregion

        #endregion

        #region Properties

        #region public DirectiveCollectionFilter AdditionalFilter

        /// <summary>
        /// Примененный фильтр
        /// </summary>
        public DirectiveCollectionFilter AdditionalFilter
        {
            get
            {
                return additionalFilter;
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
            panelTopContainer = new Panel();
            buttonDeleteSelected = new AvButtonT();
            buttonApplyFilter = new AvButtonT();
            buttonAddDirective = new RichReferenceButton();
            labelDateAsOf = new Label();

            labelTitle = new StatusImageLinkLabel();


            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemOpen = new ToolStripMenuItem();
            toolStripMenuItemCreateNew = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemsWorkPackages = new List<ToolStripMenuItem>();
            toolStripMenuItemComposeWorkPackage = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemCopy = new ToolStripMenuItem();
            toolStripMenuItemPaste = new ToolStripMenuItem();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            // 
            // toolStripMenuItemOpen
            // 
            toolStripMenuItemOpen.Click += toolStripMenuItemOpen_Click;
            // 
            // toolStripMenuItemCreateNew
            // 
            toolStripMenuItemCreateNew.Text = "Create a new engineering order";
            toolStripMenuItemCreateNew.Click += toolStripMenuItemCreateNew_Click;
            // 
            // toolStripMenuItemComposeWorkPackage
            // 
            toolStripMenuItemComposeWorkPackage.Text = "Compose a work package";
            toolStripMenuItemComposeWorkPackage.Click += toolStripMenuItemComposeWorkPackage_Click;
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
            toolStripMenuItemDelete.Text = "Delete";
            toolStripMenuItemDelete.Click += toolStripMenuItemDelete_Click;

            footerControl1 = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeaderControl = new AircraftHeaderControl();
            directiveListView = new EngineeringOrdersDirectiveListView(parentBaseDetail);
            
            // 
            // panelTopContainer
            // 
            panelTopContainer.AutoSize = true;
            panelTopContainer.Dock = DockStyle.Top;
            panelTopContainer.TabIndex = 1;
            panelTopContainer.BackColor = Css.SmallHeader.Colors.DarkForeColor;
            panelTopContainer.Controls.Add(buttonDeleteSelected);
            panelTopContainer.Controls.Add(buttonApplyFilter);
            panelTopContainer.Controls.Add(buttonAddDirective);
            panelTopContainer.Controls.Add(labelDateAsOf);
            panelTopContainer.Controls.Add(labelTitle);
            // 
            // buttonApplyFilter
            // 
            buttonApplyFilter.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonApplyFilter.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonApplyFilter.Icon = icons.ApplyFilter;
            buttonApplyFilter.Location = new Point(600, 0);
            buttonApplyFilter.Size = new Size(145, 59);
            buttonApplyFilter.TabIndex = 18;
            buttonApplyFilter.TextMain = "Apply filter";
            buttonApplyFilter.Click += buttonApplyFilter_Click;
            // 
            // buttonAddDirective
            // 
            buttonAddDirective.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddDirective.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddDirective.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddDirective.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddDirective.Icon = icons.Add;
            buttonAddDirective.IconNotEnabled = icons.AddGray;
            buttonAddDirective.Location = new Point(770, 0);
            buttonAddDirective.ReflectionType = ReflectionTypes.DisplayInNew;
            buttonAddDirective.Size = new Size(220, 59);
            buttonAddDirective.TabIndex = 19;
            buttonAddDirective.TextAlignMain = ContentAlignment.BottomCenter;
            buttonAddDirective.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddDirective.TextMain = "Add new";
            buttonAddDirective.TextSecondary = "engineering order";
            buttonAddDirective.DisplayerRequested += buttonAddDirective_DisplayerRequested;
            buttonAddDirective.Enabled = permissionForCreate;
            // 
            // buttonDeleteSelected
            // 
            buttonDeleteSelected.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.Enabled = false;
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
            buttonDeleteSelected.Click += buttonDeleteSelected_Click;
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
            labelDateAsOf.Size = new Size(47, 19);
            labelDateAsOf.TabIndex = 21;
            labelDateAsOf.Text = "Date as of: ";
            // 
            // headerControl
            // 
            headerControl.Controls.Add(aircraftHeaderControl);
            headerControl.ContextActionControl.ShowPrintButton = true;
            headerControl.ActionControl.ButtonEdit.Enabled = false;
            headerControl.ReloadRised += headerControl_ReloadRised;
            headerControl.EditDisplayerRequested += headerControl_EditDisplayerRequested;
            headerControl.ContextActionControl.ButtonPrint.DisplayerRequested += ButtonPrint_DisplayerRequested;
            headerControl.TabIndex = 0;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "directives_aircraft_operations";
            if (!permissionForUpdate)
            {
                headerControl.ActionControl.ButtonEdit.TextMain = "View";
                headerControl.ActionControl.ButtonEdit.Icon = icons.View;
                headerControl.ActionControl.ButtonEdit.IconNotEnabled = icons.ViewGray;
            }
            // 
            // footerControl1
            // 
            footerControl1.TabIndex = 4;
            // 
            // aircraftHeaderControl
            // 
            aircraftHeaderControl.AircraftClickable = true;
            aircraftHeaderControl.OperatorClickable = true;
            //
            // directiveListView
            //
            directiveListView.TabIndex = 2;
            directiveListView.ItemsListView.ContextMenuStrip = contextMenuStrip;
            directiveListView.Dock = DockStyle.Fill;
            directiveListView.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
            directiveListView.SelectedItemsChanged += directiveListView_SelectedItemsChanged;
            directiveListView.ItemsPasted += directivesViewer_ItemsPasted;
            directiveListView.ItemsDeleted += buttonDeleteSelected_Click;
            PerformEvents(true);
            Controls.Add(directiveListView);
            // 
            // DirectiveListViewer
            // 
            //this.AutoScroll = true;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(panelTopContainer);
            Controls.Add(footerControl1);
            Controls.Add(headerControl);
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
                animatedThreadWorker = new AnimatedThreadWorker(BackgroundReload, this);
                animatedThreadWorker.State = "Reloading Directives";
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
            UpdateScreen();
        }

        #endregion


        #region private void BackgroundReload()

        private void BackgroundReload()
        {
            try
            {
                parentBaseDetail.Reload(true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }
        }

        #endregion


        #region public void UpdateScreen(bool reloadBaseDetail)

        /// <summary>
        /// Обновляет отображаемую информацию в элементе управления
        /// </summary>
        public void UpdateScreen()
        {
            labelTitle.Text = parentBaseDetail + ". Engineering Orders";
            aircraftHeaderControl.Aircraft = parentBaseDetail.ParentAircraft;
            UpdateDirectives();
        }

        #endregion

        #region private void UpdateDirectives()

        private void UpdateDirectives()
        {
            directiveFilter.InitialCollection = parentBaseDetail.ContainedDirectives;
            BaseDetailDirective[] baseDetailDirectiveArray = GatherDirectives();
            List<EngineeringOrderDirective> directives = new List<EngineeringOrderDirective>();
            for (int i = 0; i < baseDetailDirectiveArray.Length; i++ )
                directives.Add((EngineeringOrderDirective)baseDetailDirectiveArray[i]);
            directiveListView.UpdateItems();
            
            labelDateAsOf.Text = "Date as of: " + filterSelection.DateSelected.ToString(new TermsProvider()["DateFormat"].ToString());
            buttonAddDirective.Enabled = toolStripMenuItemCreateNew.Enabled = permissionForUpdate; 
            
            
            labelTitle.Status = GetStatus(directives.ToArray());
            headerControl.ContextActionControl.ButtonPrint.Enabled = directiveListView.ItemsListView.Items.Count > 0;
            CheckContextMenu(directiveListView.SelectedItems.Count);
        }

        #endregion

        #region private void SetToolStripMenuItems(Aircraft aircraft)

        private void SetToolStripMenuItems()
        {
            contextMenuStrip.Items.Clear();
            toolStripMenuItemsWorkPackages.Clear();
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                 {
                                                     toolStripMenuItemOpen,
                                                     toolStripMenuItemCreateNew,
                                                     toolStripSeparator1,
                                                 });
            List<WorkPackage> workPackages = new List<WorkPackage>(parentBaseDetail.ParentAircraft.WorkPackages);
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
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    toolStripMenuItemComposeWorkPackage, 
                                                    toolStripSeparator2, 
                                                    toolStripMenuItemCopy,
                                                    toolStripMenuItemPaste,
                                                    toolStripMenuItemDelete
                                                });
        }

        #endregion

        #region private void CopyDirectives()

        private void CopyDirectives()
        {
            try
            {
                if (CASClipboard.Instance.Contents.Count > 0 && CASClipboard.Instance.Contains(typeof(EngineeringOrderDirective)))
                {
                    for (int i = 0; i < CASClipboard.Instance.Contents.Count; i++)
                    {
                        if (CASClipboard.Instance.Contents[i] is EngineeringOrderDirective)
                        {
                            EngineeringOrderDirective directiveLink = (EngineeringOrderDirective)CASClipboard.Instance.Contents[i];
                            EngineeringOrderDirective directive = directiveLink.DeepCopy();
                            parentBaseDetail.Add(directive);
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

        #region private void ComposeWorkPackage()

        private void ComposeWorkPackage()
        {
            bool exclamation = false;
            for (int i = 0; i < directiveListView.SelectedItems.Count; i++)
            {
                if (directiveListView.SelectedItems[i].Closed)
                {
                    exclamation = true;
                    break;
                }
            }
            if (exclamation)
            {
                if (MessageBox.Show("Closed engineering orders will not be added to the work package." + Environment.NewLine + "Continue?",
                        new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return;
            }
            WorkPackage workPackage = new WorkPackage();
            workPackage.Title = parentBaseDetail.ParentAircraft.GetNewWorkPackageTitle();

            try
            {
                parentBaseDetail.ParentAircraft.AddWorkPackage(workPackage);
                for (int i = 0; i < directiveListView.SelectedItems.Count; i++)
                    if (!(directiveListView.SelectedItems[i].Closed)) workPackage.AddItem(directiveListView.SelectedItems[i]);
                if (MessageBox.Show("Work Package " + workPackage.Title + " created successfully." + Environment.NewLine + "Open work package screen?",
                    new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    OnDisplayerRequested(new ReferenceEventArgs(new DispatcheredWorkPackageScreen(workPackage), ReflectionTypes.DisplayInNew, parentBaseDetail.ParentAircraft.RegistrationNumber + ". " + workPackage.Title));
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
                for (int i = 0; i < directiveListView.SelectedItems.Count; i++)
                {
                    if (workPackage.Directives.Contains(directiveListView.SelectedItems[i]) || directiveListView.SelectedItems[i].Closed)
                    {
                        exclamation = true;
                        break;
                    }
                }
                if (exclamation)
                {
                    if (MessageBox.Show("Some engineering orders will not be added to a work package." + Environment.NewLine + "Continue?",
                            new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                        return;
                }
                int directiveAdded = 0;
                for (int i = 0; i < directiveListView.SelectedItems.Count; i++)
                {
                    if (!(directiveListView.SelectedItems[i].Closed) && !workPackage.Directives.Contains(directiveListView.SelectedItems[i]))
                    {
                        workPackage.AddItem(directiveListView.SelectedItems[i]);
                        directiveAdded++;
                    }
                }
                string message;
                if (directiveAdded <= 0)
                {
                    if (directiveListView.SelectedItems.Count == 1)
                        message = "Engineering order is already added to the work package";
                    else
                        message = "Engineering orders are already added to the work package";
                }
                else if (directiveAdded == 1)
                    message = "Engineering order added successfully";
                else
                    message = "Engineering orders added successfully";
                if (MessageBox.Show(message + ". Open work package screen?", new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    OnDisplayerRequested(new ReferenceEventArgs(new DispatcheredWorkPackageScreen(workPackage), ReflectionTypes.DisplayInNew, parentBaseDetail.ParentAircraft.RegistrationNumber + ". " + workPackage.Title));
                }

            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while adding items to work package", ex);
            }


        }

        #endregion

        #region private void OnDisplayerRequested(ReferenceEventArgs e)

        private void OnDisplayerRequested(ReferenceEventArgs e)
        {
            if (null != DisplayerRequested)
            {
                DisplayerRequested(this, e);
            }
        }

        #endregion

        #region private void OnOpenDirectives()

        private void OnOpenDirectives()
        {
            List<EngineeringOrderDirective> selected = directiveListView.SelectedItems;

            for (int i = 0; i < selected.Count; i++)
            {
                ReferenceEventArgs e = new ReferenceEventArgs();
                string regNumber = "";
                if (selected[i].Parent is AircraftFrame)
                    regNumber = selected[i].Parent.ToString();
                else
                {
                    if ((selected[i].Parent).Parent is Aircraft)
                        regNumber = ((Aircraft)((selected[i].Parent).Parent)).RegistrationNumber + ". " + selected[i].Parent;
                }
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = regNumber + ". " + selected[i].DirectiveType.CommonName + ". " + selected[i].Title;
                e.RequestedEntity = new DispatcheredEngineeringOrderDirectiveScreen(selected[i]);
                OnDisplayerRequested(e);
            }
        }

        #endregion



        #region private BaseDetailDirective[] GatherDetails()

        private BaseDetailDirective[] GatherDirectives()
        {
            return GatherDirectives(additionalFilter);
        }

        #endregion

        #region private BaseDetailDirective[] GatherDirectives(DirectiveCollectionFilter additionalFilter)

        private BaseDetailDirective[] GatherDirectives(DirectiveCollectionFilter _additionalFilter)
        {
            List<DirectiveFilter> filters = new List<DirectiveFilter>(directiveFilter.Filters);
            if (_additionalFilter != null)
                filters.AddRange(_additionalFilter.Filters);
            DirectiveCollectionFilter filter =
                new DirectiveCollectionFilter(parentBaseDetail.ContainedDirectives, filters.ToArray());
            BaseDetailDirective[] directives = filter.GatherDirectives();
            labelTitle.Status = GetStatus(directives);
            return directives;
        }

        #endregion
        

        #region private void directiveListView_SelectedItemsChanged(object sender, EventArgs e)

        private void directiveListView_SelectedItemsChanged(object sender, EventArgs e)
        {
            CheckContextMenu(directiveListView.SelectedItems.Count);
        }

        #endregion

        #region private void CheckContextMenu(int count)

        private void CheckContextMenu(int count)
        {
            headerControl.ActionControl.ButtonEdit.Enabled = count == 1;
            
            toolStripMenuItemOpen.Enabled = count > 0;
            toolStripMenuItemComposeWorkPackage.Enabled = count > 0 && permissionForUpdate;
            for (int i = 0; i < toolStripMenuItemsWorkPackages.Count; i++)
                toolStripMenuItemsWorkPackages[i].Enabled = count > 0 && permissionForUpdate;
            toolStripMenuItemPaste.Enabled = CASClipboard.Instance.Contains(typeof(EngineeringOrderDirective));
            buttonDeleteSelected.Enabled = (count > 0) && permissionForDelete;
            toolStripMenuItemDelete.Enabled = buttonDeleteSelected.Enabled;
            if (count == 1)
            {
                toolStripMenuItemOpen.Text = "Go to " + directiveListView.SelectedItems[0].Title;
            }
            else
            {
                if (count == 0)
                    toolStripMenuItemOpen.Text = "Nothing selected";
                else
                    toolStripMenuItemOpen.Text = "Open engineering orders";
            }


        }
        #endregion

        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            ReloadElements();
        }

        #endregion

        #region private void headerControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)

        private void headerControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            string regNumber = "";
            if (directiveListView.SelectedItem.Parent is AircraftFrame)
                regNumber = directiveListView.SelectedItem.Parent.ToString();
            else
            {
                if ((directiveListView.SelectedItem.Parent).Parent is Aircraft)
                    regNumber = ((Aircraft)((directiveListView.SelectedItem.Parent).Parent)).RegistrationNumber + ". " + directiveListView.SelectedItem.Parent;
            }
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = regNumber + ". " + directiveListView.SelectedItem.DirectiveType.CommonName + ". " + directiveListView.SelectedItem.Title;
            e.RequestedEntity = new DispatcheredEngineeringOrderDirectiveScreen(directiveListView.SelectedItem);
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
        }

        #endregion

        #region private void buttonDeleteSelected_Click(object sender, EventArgs e)

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show(directiveListView.SelectedItem != null ? "Do you really want to delete engineering order " + directiveListView.SelectedItem.Title + "?" : "Do you really want to delete selected engineering orders? ", "Confirm delete operation",
                                                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                IDirectiveContainer parent = directiveListView.SelectedItems[0].Parent as IDirectiveContainer;
                if (parent != null)
                {
                    int count = directiveListView.SelectedItems.Count;
                    List<EngineeringOrderDirective> selectedItems = new List<EngineeringOrderDirective>(directiveListView.SelectedItems);
                    directiveListView.ItemsListView.BeginUpdate();
                    for (int i = 0; i < count; i++)
                    {

                        try
                        {
                            parent.Remove(selectedItems[i]);
                        }
                        catch (Exception ex)
                        {
                            Program.Provider.Logger.Log("Error while deleting data", ex); return;
                        }

                    }
                    directiveListView.ItemsListView.EndUpdate();
                    UpdateScreen();
                }
                else
                {
                    MessageBox.Show("Failed to delete engineering order: Parent container is invalid", "Operation failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            string headerText;
            if (parentBaseDetail is AircraftFrame)
                headerText = parentBaseDetail.ToString();
            else
                headerText = parentBaseDetail.ParentAircraft.RegistrationNumber + ". " + parentBaseDetail;
            e.DisplayerText = headerText + ". Engineering Orders. Report";
            e.RequestedEntity = new DispatcheredEngineeringOrdersReport(new EngineeringOrdersReportBuilder(parentBaseDetail));
        }

        #endregion

        #region private void buttonAddDirective_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonAddDirective_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            string title = parentBaseDetail.Parent.ToString();
            if (!(parentBaseDetail is AircraftFrame))
                title += ". " + parentBaseDetail;
            e.DisplayerText = title + ". " + DirectiveTypeCollection.Instance.EngineeringOrdersDirectiveType.CommonName + ". New engineering order";
            e.RequestedEntity = new DispatcheredEngineeringOrderDirectiveAddingScreen(parentBaseDetail);
        }

        #endregion

        #region private void buttonApplyFilter_Click(object sender, EventArgs e)

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            filterSelection.PageTitle = labelTitle.Text;
            filterSelection.SetFilterParameters(additionalFilter); 
            filterSelection.Show();
            filterSelection.BringToFront();
            filterSelection.ReloadForDate += filterSelection_ReloadForDate;
            filterSelection.ApplyFilter += filterSelection_ApplyFilter;
        }

        #endregion

        #region private void filterSelection_ReloadForDate(object sender, EventArgs e)

        private void filterSelection_ReloadForDate(object sender, EventArgs e)
        {
            ProxyType directiveSource = parentBaseDetail;
            if (!filterSelection.ReloadAsDateOf)
            {
                if (directiveSource.ProvideCurrentData)
                    return;
                directiveSource = directiveSource.CloneForCurrentData();
            }
            else
            {
                if (directiveSource.DateAsOf != filterSelection.DateSelected || !directiveSource.ProvideCurrentData)
                    directiveSource = directiveSource.CloneAsDateOf(filterSelection.DateSelected);
                else
                    return;
            }
            parentBaseDetail = (BaseDetail) directiveSource;
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



        #region private void toolStripMenuItemOpen_Click(object sender, EventArgs e)

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            OnOpenDirectives();
        }

        #endregion

        #region private void toolStripMenuItemCreateNew_Click(object sender, EventArgs e)

        private void toolStripMenuItemCreateNew_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs args = new ReferenceEventArgs();
            args.TypeOfReflection = ReflectionTypes.DisplayInNew;
            string title = parentBaseDetail.Parent.ToString();
            if (!(parentBaseDetail is AircraftFrame))
                title += ". " + parentBaseDetail;
            args.DisplayerText = title + ". " + DirectiveTypeCollection.Instance.EngineeringOrdersDirectiveType.CommonName + ". New engineering order";
            args.RequestedEntity = new DispatcheredEngineeringOrderDirectiveAddingScreen(parentBaseDetail);
            OnDisplayerRequested(args);
        }

        #endregion

        #region private void WorkPackageItem_Click(object sender, EventArgs e)

        private void WorkPackageItem_Click(object sender, EventArgs e)
        {
            WorkPackage workPackage = (WorkPackage)((ToolStripMenuItem)sender).Tag;
            AddItemsToWorkPackage(workPackage);
        }

        #endregion

        #region private void toolStripMenuItemComposeWorkPackage_Click(object sender, EventArgs e)

        private void toolStripMenuItemComposeWorkPackage_Click(object sender, EventArgs e)
        {
            ComposeWorkPackage();
        }

        #endregion

        #region private void toolStripMenuItemCopy_Click(object sender, EventArgs e)

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            int count = directiveListView.SelectedItems.Count;
            if (count > 0)
            {
                List<object> contents = new List<object>();

                for (int i = 0; i < count; i++)
                    contents.Add(directiveListView.SelectedItems[i]);
                CASClipboard.Instance.CopyToClipboard(contents);
            }
        }

        #endregion

        #region private void toolStripMenuItemPaste_Click(object sender, EventArgs e)

        private void toolStripMenuItemPaste_Click(object sender, EventArgs e)
        {
            CopyDirectives();
        }

        #endregion

        #region private void directivesViewer_ItemsPasted(List<EngineeringOrderDirective> pastedItems)

        private void directivesViewer_ItemsPasted(List<EngineeringOrderDirective> pastedItems)
        {
            CopyDirectives();
        }

        #endregion

        #region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            buttonDeleteSelected_Click(sender, e);
        }

        #endregion





        #region public void PerformEvents(bool addTo)

        ///<summary>
        /// Подписывает и отписывает собития добавления, редактирования и удаления директив
        ///</summary>
        ///<param name="addTo"></param>
        public void PerformEvents(bool addTo)
        {
            if (addTo)
            {
                parentBaseDetail.DirectiveAdded += parentBaseDetail_DirectiveAdded;
                parentBaseDetail.DirectiveRemoved += parentBaseDetail_DirectiveRemoved;
                
            }
            else
            {
                parentBaseDetail.DirectiveAdded -= parentBaseDetail_DirectiveAdded;
                parentBaseDetail.DirectiveRemoved -= parentBaseDetail_DirectiveRemoved;
                
            }
            directiveFilter.InitialCollection = parentBaseDetail.ContainedDirectives;
            BaseDetailDirective[] baseDetailDirectiveArray = directiveFilter.GatherDirectives();
            List<EngineeringOrderDirective> directives = new List<EngineeringOrderDirective>();
            for (int i = 0; i < baseDetailDirectiveArray.Length; i++)
                directives.Add((EngineeringOrderDirective)baseDetailDirectiveArray[i]);
            for (int i = 0; i < directives.Count; i++)
                HookDirective(directives[i], addTo);
        }

        #endregion

        #region private void HookDirective(EngineeringOrderDirective directive, bool addTo)

        private void HookDirective(EngineeringOrderDirective directive, bool addTo)
        {
            if (addTo)
            {
                directive.Saved += EngineeringOrdersDirectiveListScreen_Saved;
                directive.Saving += EngineeringOrdersDirectiveListScreen_Saving;
            }
            else
            {
                directive.Saved -= EngineeringOrdersDirectiveListScreen_Saved;
                directive.Saving -= EngineeringOrdersDirectiveListScreen_Saving;
            }
        }

        #endregion

        #region private void HookWorkPackageEvents()

        private void HookWorkPackageEvents()
        {
            parentBaseDetail.ParentAircraft.WorkPackageAdded += CurrentAircraft_WorkPackagesChanged;
            parentBaseDetail.ParentAircraft.WorkPackageRemoved += CurrentAircraft_WorkPackagesChanged;
        }

        #endregion

        #region private void UnHookWorkPackageEvents()

        private void UnHookWorkPackageEvents()
        {
            parentBaseDetail.ParentAircraft.WorkPackageAdded -= CurrentAircraft_WorkPackagesChanged;
            parentBaseDetail.ParentAircraft.WorkPackageRemoved -= CurrentAircraft_WorkPackagesChanged;
        }

        #endregion




        

        #region private void EngineeringOrdersDirectiveListScreen_InitComplition(object sender, EventArgs e)

        private void EngineeringOrdersDirectiveListScreen_InitComplition(object sender, EventArgs e)
        {
            dispatcheredMultitabControl = (DispatcheredMultitabControl)sender;
            ((DispatcheredMultitabControl)sender).Closed += EngineeringOrdersDirectiveListScreen_Closed;
        }

        #endregion

        #region private void ClipboardContentsChanged(object sender, EventArgs e)

        private void ClipboardContentsChanged(object sender, EventArgs e)
        {
            toolStripMenuItemPaste.Enabled = CASClipboard.Instance.Contains(typeof(EngineeringOrderDirective));
        }

        #endregion

        #region private void EngineeringOrdersDirectiveListScreen_Closed(object sender, AvMultitabControlEventArgs e)

        private void EngineeringOrdersDirectiveListScreen_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == (DispatcheredTabPage)Parent)
            {
                PerformEvents(false);
                UnHookWorkPackageEvents();
            }
        }

        #endregion

        #region private void EngineeringOrdersDirectiveListScreen_Saved(object sender, EventArgs e)

        private void EngineeringOrdersDirectiveListScreen_Saved(object sender, EventArgs e)
        {
            directiveListView.EditItem(editedDirective, (EngineeringOrderDirective)sender);
            GatherDirectives();
        }

        #endregion

        #region private void EngineeringOrdersDirectiveListScreen_Saving(object sender, CancelEventArgs e)

        private void EngineeringOrdersDirectiveListScreen_Saving(object sender, CancelEventArgs e)
        {
            editedDirective = (EngineeringOrderDirective)sender;
        }

        #endregion

        #region private void parentBaseDetail_DirectiveAdded(object sender, EventArgs e)

        private void parentBaseDetail_DirectiveAdded(object sender, CollectionChangeEventArgs e)
        {
            if (!(e.Element is EngineeringOrderDirective))
                return;
            EngineeringOrderDirective directive = (EngineeringOrderDirective)e.Element;
            directiveListView.AddNewItem(directive);
            HookDirective(directive, true);
            GatherDirectives();
        }

        #endregion

        #region private void parentBaseDetail_DirectiveRemoved(object sender, EventArgs e)

        private void parentBaseDetail_DirectiveRemoved(object sender, CollectionChangeEventArgs e)
        {
            if (e.Element is EngineeringOrderDirective) directiveListView.DeleteItem((EngineeringOrderDirective)e.Element);
        }

        #endregion

        #region private void CurrentAircraft_WorkPackagesChanged(object sender, CollectionChangeEventArgs e)

        private void CurrentAircraft_WorkPackagesChanged(object sender, CollectionChangeEventArgs e)
        {
            SetToolStripMenuItems();
        }

        #endregion

        #region protected void SetPageEnable(bool isEnable)
        /// <summary>
        /// Set page enable
        /// </summary>
        /// <param name="isEnable"></param>
        protected void SetPageEnable(bool isEnable)
        {
            directiveListView.Enabled = isEnable;
            panelTopContainer.Enabled = isEnable;
            footerControl1.Enabled = isEnable;
            headerControl.Enabled = isEnable;
            aircraftHeaderControl.Enabled = isEnable;
            CheckContextMenu(directiveListView.SelectedItems.Count);
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