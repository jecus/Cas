using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Directives;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Management;
using CAS.UI.Properties;
using CAS.UI.UIControls.TemplatesControls.Forms;
using Controls;
using Controls.AvButtonT;
using Controls.AvMultitabControl;
using Controls.AvMultitabControl.Auxiliary;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters.Templates;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.TemplatesControls;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.TemplatesControls
{
    ///<summary>
    /// Элемент управления для отображения списка шаблонных агрегатов
    ///</summary>
    [ToolboxItem(false)]
    public class TemplateDetailListScreen : UserControl, IReference
    {

        #region Fields

        /// <summary>
        /// Шаблонный базовый агрегат, содержащий другие агрегаты
        /// </summary>
        protected TemplateBaseDetail currentBaseDetail;
        private TemplateAircraft currentAircraft;
        private TemplateDetail detailBeforeSave;

        private readonly TemplateDetailFilterSelection filterSelection;
        private readonly TemplateDetailCollectionFilter initialFilter;
        private TemplateDetailCollectionFilter additionalFilter = new TemplateDetailCollectionFilter(new TemplateDetailFilter[0]);
        private AvButtonT buttonAddSelectedToBaseDetail;

        private FooterControl footerControl1;
        private HeaderControl headerControl1;
        private TemplateAircraftHeaderControl aircraftHeaderControl;
        private RichReferenceButton buttonAddDetail;
        private AvButtonT buttonApplyFilter;
        private AvButtonT buttonDeleteSelected;
        private TemplateDetailListView detailListView;
        private ContextMenuStrip contextMenuStrip1;
        private StatusImageLinkLabel labelCaption;

        /// <summary>
        /// Панель содержащая кнопки управления
        /// </summary>
        protected Panel panelTopContainer;
        private ToolStripMenuItem toolStripMenuItemAdd;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private ToolStripMenuItem toolStripMenuItemHotSectionInspection;
        private ToolStripMenuItem toolStripMenuItemInspection;
        private ToolStripMenuItem toolStripMenuItemOverhaul;
        private ToolStripMenuItem toolStripMenuItemShopVisit;
        private ToolStripMenuItem toolStripMenuItemTitle;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        
        private readonly Icons icons = new Icons();

        private IDisplayer displayer;
        private IDisplayingEntity entity;
        private string displayerText;
        private ReflectionTypes reflectionType;
        
        #endregion

        #region Constructors

        #region public TemplateDetailListScreen(TemplateBaseDetail currentBaseDetail, TemplateDetailCollectionFilter viewFilter)

        ///<summary>
        /// Создает элемент управления для отображения списка шаблонных агрегатов
        ///</summary>
        ///<param name="currentBaseDetail">Базовый агрегат, содержащий агрегаты</param>
        ///<param name="viewFilter">Фильтр отображения</param>
        public TemplateDetailListScreen(TemplateBaseDetail currentBaseDetail, TemplateDetailCollectionFilter viewFilter)
        {
            ((DispatcheredTemplateDetailListScreen)this).InitComplition += ComponentStatusControl_InitComplition; 
            if (currentBaseDetail == null)
                throw new ArgumentNullException("currentBaseDetail", "Cannot display null-baseDetail");
            this.currentBaseDetail = currentBaseDetail;
            PerformEvents(true);
            filterSelection = new TemplateDetailFilterSelection(currentBaseDetail.ParentAircraft);
            initialFilter = viewFilter;
            InitializeComponent();
            UpdateElements();
        }

        #endregion

        #region public TemplateDetailListScreen(TemplateAircraft currentAircraft, TemplateDetailCollectionFilter initialFilter) : this()

        ///<summary>
        /// Создает элемент управления для отображения списка шаблонных агрегатов
        ///</summary>
        ///<param name="currentAircraft">Шаблонное ВС, содержащее агрегаты</param>
        /// ///<param name="initialFilter">Фильтр отображения</param>
        public TemplateDetailListScreen(TemplateAircraft currentAircraft, TemplateDetailCollectionFilter initialFilter) : this(currentAircraft, initialFilter, null)
        {
            
        }

        #endregion

        #region public TemplateDetailListScreen(TemplateAircraft currentAircraft, TemplateDetailCollectionFilter initialFilter, TemplateDetailCollectionFilter additionalFilter)

        ///<summary>
        /// Создает элемент управления для отображения списка шаблонных агрегатов
        ///</summary>
        ///<param name="currentAircraft">Шаблонное ВС, содержащее агрегаты</param>
        ///<param name="initialFilter">Фильтр отображения</param>
        /// <param name="additionalFilter">Дополнительный фильтр</param>
        public TemplateDetailListScreen(TemplateAircraft currentAircraft, TemplateDetailCollectionFilter initialFilter, TemplateDetailCollectionFilter additionalFilter)
        {
            ((DispatcheredTemplateDetailListScreen)this).InitComplition += ComponentStatusControl_InitComplition; 
            if (currentAircraft == null) throw new ArgumentNullException("currentAircraft");
            this.currentAircraft = currentAircraft;
            PerformEvents(true);
            this.initialFilter = initialFilter;
            if (additionalFilter != null)
                this.additionalFilter = additionalFilter;
            filterSelection = new TemplateDetailFilterSelection(currentAircraft);
            InitializeComponent();
            UpdateElements();
        }

        #endregion

        #endregion

        #region Properties

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

        #region public TemplateBaseDetail CurrentBaseDetail

        /// <summary>
        /// Текущий отображаемый базовый агрегат
        /// </summary>
        public TemplateBaseDetail CurrentBaseDetail
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

        #region public TemplateAircraft CurrentAircraft

        /// <summary>
        /// Шаблонное ВС, содержащее агрегаты
        /// </summary>
        public TemplateAircraft CurrentAircraft
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

        #region public ITemplateDetailContainer DetailSource

        /// <summary>
        /// Источник шаблонных агрегатов
        /// </summary>
        public ITemplateDetailContainer DetailSource
        {
            get
            {
                if (CurrentBaseDetail != null)
                    return CurrentBaseDetail;
                return CurrentAircraft;
            }
        }

        #endregion

        #region public TemplateDetailCollectionFilter AdditionalFilter

        /// <summary>
        /// Примененные фильтры
        /// </summary>
        public TemplateDetailCollectionFilter AdditionalFilter
        {
            get { return additionalFilter; }
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
            buttonDeleteSelected = new AvButtonT();
            buttonAddSelectedToBaseDetail = new AvButtonT();
            buttonApplyFilter = new AvButtonT();
            labelCaption = new StatusImageLinkLabel();
            buttonAddDetail = new RichReferenceButton();
            footerControl1 = new FooterControl();
            headerControl1 = new HeaderControl();
            aircraftHeaderControl = new TemplateAircraftHeaderControl(CurrentAircraft, true, true);
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
            toolStripMenuItemHotSectionInspection = new ToolStripMenuItem();
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
                                                     toolStripMenuItemDelete
                                                 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(179, 176);
            // 
            // toolStripMenuItemTitle
            // 
            toolStripMenuItemTitle.Name = "toolStripMenuItemTitle";
            toolStripMenuItemTitle.Size = new Size(178, 22);
            toolStripMenuItemTitle.Text = "Component";
            toolStripMenuItemTitle.Click += toolStripMenuItemEdit_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(175, 6);
            // 
            // toolStripMenuItemAdd
            // 
            toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            toolStripMenuItemAdd.Size = new Size(178, 22);
            toolStripMenuItemAdd.Text = "Add Component ";
            toolStripMenuItemAdd.Click += toolStripMenuItemAdd_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(175, 6);
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            toolStripMenuItemDelete.Size = new Size(178, 22);
            toolStripMenuItemDelete.Text = "Delete";
            toolStripMenuItemDelete.Click += toolStripMenuItemDelete_Click;

            #endregion
            //
            // detailListView
            //
            detailListView = new TemplateDetailListView(DetailSource, initialFilter);
            detailListView.ContextMenuStrip = contextMenuStrip1;
            detailListView.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
            detailListView.Size =
                new Size(Width,
                         Height - headerControl1.Height - footerControl1.Height - panelTopContainer.Height);
            detailListView.SelectedItemsChanged += componentStatusesViewer_SelectedItemsChanged;
            Controls.Add(detailListView);
            // 
            // panelTopContainer
            // 
            panelTopContainer.AutoSize = true;
            panelTopContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelTopContainer.BackColor = Color.FromArgb(211, 211, 211);
            panelTopContainer.Controls.Add(labelCaption);
            panelTopContainer.Controls.Add(buttonDeleteSelected);
            panelTopContainer.Controls.Add(buttonApplyFilter);
            panelTopContainer.Controls.Add(buttonAddSelectedToBaseDetail);
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
            // buttonAddSelectedToBaseDetail
            // 
            buttonAddSelectedToBaseDetail.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonAddSelectedToBaseDetail.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddSelectedToBaseDetail.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddSelectedToBaseDetail.Icon = icons.ApplyFilter;
            buttonAddSelectedToBaseDetail.Size = new Size(200, 59);
            buttonAddSelectedToBaseDetail.TabIndex = 22;
            buttonAddSelectedToBaseDetail.TextMain = "Add Selected To Base Component";
            buttonAddSelectedToBaseDetail.Click += buttonAddSelectedToBaseDetail_Click;
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
            // labelCaption
            // 
            labelCaption.ActiveLinkColor = Color.Black;
            labelCaption.Enabled = false;
            labelCaption.HoveredLinkColor = Color.Black;
            labelCaption.ImageBackColor = Color.Transparent;
            labelCaption.ImageLayout = ImageLayout.Center;
            labelCaption.LinkColor = Color.DimGray;
            labelCaption.LinkMouseCapturedColor = Color.Empty;
            labelCaption.Location = new Point(28, 3);
            labelCaption.Margin = new Padding(0);
            labelCaption.Size = new Size(600, 27);
            labelCaption.Status = Statuses.Pending;
            labelCaption.TabIndex = 16;
            labelCaption.TextAlign = ContentAlignment.MiddleLeft;
            labelCaption.TextFont = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
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
            headerControl1.ContextActionControl.ShowPrintButton = false;
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
            // DetailListScreen
            // 
            BackColor = Color.FromArgb(241, 241, 241);
            Controls.Add(footerControl1);
            Controls.Add(panelTopContainer);
            Controls.Add(headerControl1);
            Name = "ComponentStatusScreen";
            Size = new Size(1042, 616);
            panelTopContainer.ResumeLayout(false);
            panelTopContainer.PerformLayout();
            headerControl1.ResumeLayout(false);
            headerControl1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        #region void buttonAddSelectedToBaseDetail_Click(object sender, EventArgs e)
        void buttonAddSelectedToBaseDetail_Click(object sender, EventArgs e)
        {
            TemplateDetailsAddToDataBase detailsAddToDataBase = new TemplateDetailsAddToDataBase();
            detailsAddToDataBase.Closing += detailsAddToDataBase_Closing;
            detailsAddToDataBase.ShowDialog();
        }
        #endregion

        #region void detailsAddToDataBase_Closing(object sender, CancelEventArgs e)
        void detailsAddToDataBase_Closing(object sender, CancelEventArgs e)
        {
            TemplateDetailsAddToDataBase detailsAddToDataBase = (TemplateDetailsAddToDataBase)sender;
            if (detailsAddToDataBase.DialogResult == DialogResult.OK)
            {
                List<TemplateDetail> listSelectedDetails = detailListView.SelectedItems;
                int count = listSelectedDetails.Count;
                for (int i = 0; i < count; i++)
                {
                    listSelectedDetails[i].TransferData(true, detailsAddToDataBase.SelectedBaseDetail.ID);
                }
            }
        }
        #endregion
        
        #region void buttonDeleteSelected_Click(object sender, EventArgs e)

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            if ((detailListView.SelectedItems == null) && (detailListView.SelectedItem == null))
                return;
            DialogResult confirmResult =
                /*MessageBox.Show(
                    detailListView.SelectedItem != null
                        ? "Do you really want to delete component " + detailListView.SelectedItem.SerialNumber +
                          "?"
                        : "Do you really want to delete selected components? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);*/
                MessageBox.Show(
                    detailListView.SelectedItem != null
                        ? "Do you really want to delete component " + detailListView.SelectedItem.PartNumber +
                          "?"
                        : "Do you really want to delete selected components? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                ITemplateDetailContainer parent = detailListView.SelectedItems[0].Parent as ITemplateDetailContainer;
                if (parent != null)
                {
                    int count = detailListView.SelectedItems.Count;
                    detailListView.ItemsListView.BeginUpdate();
                    try
                    {
                        List<TemplateDetail> selectedItems = new List<TemplateDetail>(detailListView.SelectedItems);
                        for (int i = 0; i < count; i++)
                        {
                            parent.Remove(selectedItems[i]);
                            detailListView.DeleteItem(selectedItems[i]);
                        }
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex); 
                        return;
                    }
                    SetItemsInformation();
                    detailListView.ItemsListView.EndUpdate();
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
            UpdateHeader();
            ShowDetails();
        }

        #endregion

        #region private void UpdateHeader()

        private void UpdateHeader()
        {
            aircraftHeaderControl.Aircraft = CurrentAircraft;
            if (currentAircraft == null)
            {
                labelCaption.Text = currentBaseDetail + ". LLP Disk Sheet Status";
                return;
            }
            else
            {
                labelCaption.Text = currentAircraft.ToString();
                IFilter[] filters = additionalFilter.Filters;
                bool isLandingGearReport = false;
                for (int i = 0; i < filters.Length; i++)
                {
                    if (filters[i] is TemplateLandingGearsFilter)
                    {
                        isLandingGearReport = true;
                        break;
                    }
                }
                if (isLandingGearReport)
                    labelCaption.Text += ". Landing Gear Status";
                else
                    labelCaption.Text += ". Component Status";
            }
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
            List<TemplateDetail> selectedDetails = detailListView.SelectedItems;
            for (int i = 0; i < selectedDetails.Count; i++)
            {
                TemplateDetail detail = selectedDetails[i];
                DispatcheredTemplateDetailScreen requestedEntity =
                    new DispatcheredTemplateDetailScreen(detail);
                if (currentAircraft != null)
                    OnDisplayerRequested(
                        //new ReferenceEventArgs(requestedEntity, ReflectionTypes.DisplayInNew, null, "Templates. " + currentAircraft.Model + ". Component PN " + detail.PartNumber));
                        new ReferenceEventArgs(requestedEntity, ReflectionTypes.DisplayInNew, null, currentAircraft.Model + ". Component PN " + detail.PartNumber));
                else
                    OnDisplayerRequested(
                       // new ReferenceEventArgs(requestedEntity, ReflectionTypes.DisplayInNew, null, "Templates. " + currentAircraft.Model + ". " + currentBaseDetail.PartNumber + ". Component PN " + detail.PartNumber));
                        new ReferenceEventArgs(requestedEntity, ReflectionTypes.DisplayInNew, null, currentAircraft.Model + ". " + currentBaseDetail.PartNumber + ". Component PN " + detail.PartNumber));
            }
        }

        #endregion

        #region private void buttonAddDetail_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonAddDetail_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredTemplateDetailAdding(DetailSource);
            if (currentAircraft != null)
                //e.DisplayerText = "Templates. " + currentAircraft.Model + ". New Component";
                e.DisplayerText = currentAircraft.Model + ". New Component";
            else
                //e.DisplayerText = "Templates. " + currentBaseDetail.PartNumber + ". New Component";
                e.DisplayerText = currentBaseDetail.PartNumber + ". New Component";
        }

        #endregion

        #region private void ShowDetails()

        private void ShowDetails()
        {
            detailListView.AdditionalFilter = additionalFilter;
            detailListView.UpdateItems();

            SetItemsInformation();
        }


        #endregion

        #region private void SetRightsToControls()

        private void SetRightsToControls()
        {
            bool temp = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            buttonAddDetail.Enabled = temp;
            toolStripMenuItemAdd.Enabled = temp;
            headerControl1.ActionControl.ShowEditButton =
                DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Update);
        }

        #endregion

        #region protected void ReloadElements()

        /// <summary>
        /// Происходит перезагрузка элементов и синхронизация с базой данных
        /// </summary>
        protected void ReloadElements()
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
            UpdateHeader();
            ShowDetails();
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void PrintButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
            /*
            DetailListReportBuilder reportBuilder = filterSelection.ReportBuilder;
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            string dateSelected = filterSelection.DateSelected.ToString(new TermsProvider()["DateFormat"].ToString());

            reportBuilder.AddResources(currentAircraft, detailListView.GetItemsArray(), dateSelected);
            e.DisplayerText = filterSelection.ReportBuilder.ReportTitle + ". Report";
            e.RequestedEntity = new DispatcheredDetailListReport(reportBuilder);*/
        }

        #endregion

        #region private void buttonApplyFilter_Click(object sender, EventArgs e)

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            filterSelection.SetFilterParameters(additionalFilter);
            filterSelection.Show();
            filterSelection.BringToFront();
            filterSelection.ApplyFilter -= filterSelection_ApplyFilter;
            filterSelection.ApplyFilter += filterSelection_ApplyFilter;
        }

        #endregion

        #region private void filterSelection_ApplyFilter(object sender, EventArgs e)

        private void filterSelection_ApplyFilter(object sender, EventArgs e)
        {
            additionalFilter = filterSelection.GetDetailCollectionFilter();
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
            if (buttonAddSelectedToBaseDetail != null)
                buttonAddSelectedToBaseDetail.Location = new Point(buttonApplyFilter.Left - buttonAddSelectedToBaseDetail.Width - 5, 0);

            if (detailListView != null)
            {
                detailListView.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                detailListView.Size =
                    new Size(Width,
                             Height - headerControl1.Height - footerControl1.Height - panelTopContainer.Height);
            }
        }

        #endregion

        #region void detailListView_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void componentStatusesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            SetContextMenuParameters(e.ItemsCount);

            if (detailListView.SelectedItem != null)
                toolStripMenuItemTitle.Text = detailListView.SelectedItem.PartNumber;
            else
                toolStripMenuItemTitle.Text = "Components";
        }

        #endregion

        #region private void SetContextMenuParameters(int count)

        private void SetContextMenuParameters(int count)
        {
            bool temp = DirectiveCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create) && (count == 1);
            toolStripMenuItemInspection.Enabled = temp;
            toolStripMenuItemHotSectionInspection.Enabled = temp;
            toolStripMenuItemOverhaul.Enabled = temp;
            toolStripMenuItemShopVisit.Enabled = temp;

            toolStripMenuItemTitle.Enabled = count > 0;

            headerControl1.ActionControl.ButtonEdit.Enabled = (count == 1);

            buttonDeleteSelected.Enabled = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Remove) &&
                                           (count > 0);
            toolStripMenuItemDelete.Enabled = buttonDeleteSelected.Enabled;
        }

        #endregion

        #region void toolStripMenuItemDelete_Click(object sender, EventArgs e)

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            buttonDeleteSelected_Click(sender, e);
        }

        #endregion

        #region void toolStripMenuItemEdit_Click(object sender, EventArgs e)

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            OnViewEditScreen();
        }

        #endregion

        #region void toolStripMenuItemAdd_Click(object sender, EventArgs e)

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            buttonAddDetail_DisplayerRequested(this, arguments);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region protected void OnAddRecord(RecordType recordType)

        /// <summary>
        /// Добавление записи для данного агрегата   
        /// </summary>
        /// <param name="recordType"></param>
        protected void OnAddRecord(RecordType recordType)
        {
            /*FormAddRecord dialog = new FormAddRecord(detailListView.SelectedItem, DetailInformationMode.Add);
            dialog.WorkType = recordType;
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                detailListView.SelectedItem.Reload();
                ShowDetails();
            }*/
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

        #region private void DetailCollection_Added(object sender, CollectionChangeEventArgs e)

        private void DetailCollection_Added(object sender, CollectionChangeEventArgs e)
        {
            detailListView.AddNewItem((TemplateDetail)e.Element);
            HookDetail((TemplateDetail)e.Element, true);
        }

        #endregion

        #region private void DetailCollection_Removed(object sender, CollectionChangeEventArgs e)

        private void DetailCollection_Removed(object sender, CollectionChangeEventArgs e)
        {
            detailListView.DeleteItem((TemplateDetail)e.Element);
        }

        #endregion

        #region private void ComponentStatusScreen_InitComplition(object sender, EventArgs e)

        private void ComponentStatusControl_InitComplition(object sender, EventArgs e)
        {
            ((DispatcheredMultitabControl)sender).Closed += TemplateDetailListScreen_Closed;
            ((AvMultitabControl)sender).Selected += ComponentStatusControl_Selected;
        }

        #endregion

        #region private void ComponentStatusScreen_Selected(object sender, AvMultitabControlEventArgs e)

        private void ComponentStatusControl_Selected(object sender, AvMultitabControlEventArgs e)
        {
            detailListView.ItemsListView.Focus();
        }

        #endregion

        #region private void TemplateDetailListScreen_Saved(object sender, EventArgs e)

        private void TemplateDetailListScreen_Saved(object sender, EventArgs e)
        {
            detailListView.EditItem(detailBeforeSave, (TemplateDetail)sender);
        }

        #endregion

        #region private void TemplateDetailListScreen_Saving(object sender, CancelEventArgs e)

        private void TemplateDetailListScreen_Saving(object sender, CancelEventArgs e)
        {
            detailBeforeSave = (TemplateDetail)sender;
        }

        #endregion



        #region private void PerformEvents(bool addTo)

        private void PerformEvents(bool addTo)
        {
            if (currentAircraft != null)
            {
                if (addTo)
                {
                    for (int i = 0; i < currentAircraft.BaseDetails.Length; i++)
                    {
                        currentAircraft.BaseDetails[i].DetailCollection.Added +=  DetailCollection_Added;
                        currentAircraft.BaseDetails[i].DetailCollection.Removed += DetailCollection_Removed;
                    }
                }
                else
                {
                    for (int i = 0; i < currentAircraft.BaseDetails.Length; i++)
                    {
                        currentAircraft.BaseDetails[i].DetailCollection.Added -= DetailCollection_Added;
                        currentAircraft.BaseDetails[i].DetailCollection.Removed -= DetailCollection_Removed;
                    }
                }
                for (int i = 0; i < currentAircraft.ContainedDetails.Length; i++)
                    HookDetail(currentAircraft.ContainedDetails[i], addTo);
            }
            else
            {
                if (addTo)
                {
                    currentBaseDetail.DetailCollection.Added += DetailCollection_Added;
                    currentBaseDetail.DetailCollection.Removed += DetailCollection_Removed;
                }
                else
                {
                    currentBaseDetail.DetailCollection.Added -= DetailCollection_Added;
                    currentBaseDetail.DetailCollection.Removed -= DetailCollection_Removed;
                }
                for (int i = 0; i < currentBaseDetail.ContainedDetails.Length; i++)
                    HookDetail(currentBaseDetail.ContainedDetails[i], addTo);
            }
        }

        #endregion

        #region private void HookDetail(TemplateDetail detail, bool addTo)

        private void HookDetail(TemplateDetail detail, bool addTo)
        {
            if (addTo)
            {
                detail.Saved += TemplateDetailListScreen_Saved;
                detail.Saving += TemplateDetailListScreen_Saving;
            }
            else
            {
                detail.Saved -= TemplateDetailListScreen_Saved;
                detail.Saving -= TemplateDetailListScreen_Saving;
            }
        }

        #endregion


        #region private void TemplateDetailListScreen_Closed(object sender, AvMultitabControlEventArgs e)

        private void TemplateDetailListScreen_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == (DispatcheredTabPage)Parent)
                PerformEvents(false);
        }

        #endregion

        #region private void SetItemsInformation()

        private void SetItemsInformation()
        {
            SetRightsToControls();
            SetContextMenuParameters(detailListView.SelectedItems.Count);
            headerControl1.ContextActionControl.ButtonPrint.Enabled = detailListView.ItemsListView.Items.Count != 0;
        }

        #endregion


        #endregion
    }
}