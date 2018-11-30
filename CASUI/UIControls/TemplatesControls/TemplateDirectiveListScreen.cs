using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Directives;
using CAS.UI.Management;
using CAS.UI.Properties;
using CAS.UI.UIControls.TemplatesControls.Forms;
using CASReports.Builders;
using CASTerms;
using Controls;
using Controls.AvButtonT;
using CAS.Core;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives.Templates;
using CAS.Core.Types.ReportFilters.Templates;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.TemplatesControls;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.TemplatesControls
{
    ///<summary>
    /// Элемент управления, отображающий список шаблонных директив
    ///</summary>
    [ToolboxItem(false)]
    public class TemplateDirectiveListScreen : UserControl, IReference
    {

        #region Fields

        private TemplateAircraft currentAircraft;
        /// <summary>
        /// Текущий отображаемый базовый агрегат
        /// </summary>
        protected TemplateBaseDetail currentBaseDetail;
        /// <summary>
        /// Тип директив по умолчанию
        /// </summary>
        private DirectiveType currentDirectiveType;
        private TemplateBaseDetailDirective editedDirective;
        private readonly TemplateDirectiveFilterSelectionForm filterSelection = new TemplateDirectiveFilterSelectionForm();
        private readonly TemplateDirectiveCollectionFilter viewFilter;
        private TemplateDirectiveCollectionFilter additionalFilter = new TemplateDirectiveCollectionFilter(new TemplateDirectiveFilter[0]);
        private DirectiveListReportBuilder reportBuilder;

        private TemplateDirectiveListView directivesViewer;
        private TemplateAircraftHeaderControl aircraftHeaderControl;
        private RichReferenceButton buttonAddDirective;
        private AvButtonT buttonApplyFilter;
        private AvButtonT buttonDeleteSelected;
        private ContextMenuStrip contextMenuStrip;
        private FooterControl footerControl1;
        private HeaderControl headerControl1;
        private StatusImageLinkLabel labelTitle;
        /// <summary>
        /// Панель, содержащая кнопки управления
        /// </summary>
        protected Panel panelTopContainer;

        private ToolStripMenuItem toolStripMenuItemAdd;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private ToolStripMenuItem toolStripMenuItemView;
        private ToolStripSeparator toolStripSeparator2;


        private readonly Icons icons = new Icons();
        private string reportText;

        private IDisplayer displayer;
        private IDisplayingEntity entity;
        private string displayerText;
        private ReflectionTypes reflectionType;
        

        #endregion

        #region Constructors

        #region public TemplateDirectiveListScreen(TemplateBaseDetail currentBaseDetail, TemplateDirectiveCollectionFilter viewFilter, string reportText)

        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список шаблонных директив
        ///</summary>
        ///<param name="currentBaseDetail">Базовый агрегат, которому принадлежат шаблонные директивы</param>
        ///<param name="viewFilter">Фильтр</param>
        ///<param name="reportText">Текст отчета</param>
        public TemplateDirectiveListScreen(TemplateBaseDetail currentBaseDetail, TemplateDirectiveCollectionFilter viewFilter, string reportText)
        {
            if (currentBaseDetail == null)
                throw new ArgumentNullException("currentBaseDetail", "Cannot display null-baseDetail");
            this.currentBaseDetail = currentBaseDetail;
            this.viewFilter = viewFilter;
            this.reportText = reportText;
            InitializeComponent();
            UpdateElements();
        }

        #endregion

        #region public TemplateDirectiveListScreen(TemplateAircraft currentAircraft, TemplateDirectiveCollectionFilter viewFilter, string reportText)

        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список шаблонных директив
        ///</summary>
        ///<param name="currentAircraft">ВС, которому принадлежат шаблонные директивы</param>
        ///<param name="viewFilter">Фильтр</param>
        ///<param name="reportText">Текст отчета</param>
        public TemplateDirectiveListScreen(TemplateAircraft currentAircraft, TemplateDirectiveCollectionFilter viewFilter, string reportText)
        {
            if (currentAircraft == null) 
                throw new ArgumentNullException("currentAircraft");
            this.currentAircraft = currentAircraft;
            this.viewFilter = viewFilter;
            this.reportText = reportText;
            InitializeComponent();
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
        
        #region public TemplateBaseDetail CurrentBaseDetail

        /// <summary>
        /// Текущий шаблонный базовый агрегат, которому принадлежат директивы
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
        /// Текущее шаблонное ВС, которому принадлежат директивы
        /// </summary>
        public TemplateAircraft CurrentAircraft
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

        #region public ITemplateDirectiveContainer DirectiveSource

        /// <summary>
        /// Контейнер шаблонных директив
        /// </summary>
        public ITemplateDirectiveContainer DirectiveSource
        {
            get
            {
                if (CurrentBaseDetail != null)
                    return CurrentBaseDetail;
                return CurrentAircraft;
            }
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
        
        #region public TemplateDirectiveCollectionFilter AdditionalFilter

        /// <summary>
        /// Примененный фильтр
        /// </summary>
        public TemplateDirectiveCollectionFilter AdditionalFilter
        {
            get { return additionalFilter; }
        }

        #endregion

        #region public TemplateDirectiveCollectionFilter ViewFilter

        /// <summary>
        /// Изначальный фильтр отображения
        /// </summary>
        public TemplateDirectiveCollectionFilter ViewFilter
        {
            get { return viewFilter; }
        }

        #endregion

        #region public ListView ItemsListView

        /// <summary>
        /// Возвращает ListView с шаблонными директивами
        /// </summary>
        public ListView ItemsListView
        {
            get
            {
                return directivesViewer.ItemsListView;
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
            Lifelength lifelength4 = new Lifelength();
            panelTopContainer = new Panel();
            buttonDeleteSelected = new AvButtonT();
            buttonApplyFilter = new AvButtonT();
            buttonAddDirective = new RichReferenceButton();
            labelTitle = new StatusImageLinkLabel();

            #region Context menu

            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemAdd = new ToolStripMenuItem();
            toolStripMenuItemView = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    toolStripMenuItemView,
                                                    toolStripMenuItemAdd,
                                                    toolStripSeparator2,
                                                    toolStripMenuItemDelete
                                                });
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
            toolStripMenuItemView.Text = "View details";
            toolStripMenuItemView.Click += toolStripMenuItemView_Click;
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

            footerControl1 = new FooterControl();
            headerControl1 = new HeaderControl();
            aircraftHeaderControl = new TemplateAircraftHeaderControl();
            panelTopContainer.SuspendLayout();
            headerControl1.SuspendLayout();
            SuspendLayout();
            //
            // directivesViewer
            //
            directivesViewer = new TemplateDirectiveListView(DirectiveSource, viewFilter);
            directivesViewer.TabIndex = 2;
            directivesViewer.ItemsListView.ContextMenuStrip = contextMenuStrip;
            directivesViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
            directivesViewer.SelectedItemsChanged += directivesViewer_SelectedItemsChanged;
            PerformEvents(true);
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
            buttonApplyFilter.Click += buttonApplyFilter_Click;
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
            buttonAddDirective.TextSecondary = "directive";
            buttonAddDirective.DisplayerRequested += referenceAvalonButtonAddDirective_DisplayerRequested;
            // 
            // buttonDeleteSelected
            // 
            buttonDeleteSelected.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonDeleteSelected.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.Click += buttonDeleteSelected_Click;
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
            labelTitle.ActiveLinkColor = Color.Black;
            labelTitle.Enabled = false;
            labelTitle.HoveredLinkColor = Color.Black;
            labelTitle.ImageBackColor = Color.Transparent;
            labelTitle.ImageLayout = ImageLayout.Center;
            labelTitle.LinkColor = Color.DimGray;
            labelTitle.LinkMouseCapturedColor = Color.Empty;
            labelTitle.Location = new Point(28, 3);
            labelTitle.Margin = new Padding(0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(600, 27);
            labelTitle.Status = Statuses.Pending;
            labelTitle.TabIndex = 16;
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            labelTitle.TextFont = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            //
            // lifelength4
            //
            lifelength4.Applicable = false;
            lifelength4.Calendar = TimeSpan.Parse("00:00:00");
            lifelength4.Cycles = 0;
            lifelength4.Hours = TimeSpan.Parse("00:00:00");
            lifelength4.IsCalendarApplicable = false;
            lifelength4.IsCyclesApplicable = false;
            lifelength4.IsHoursApplicable = false;
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
            footerControl1.Name = "footerControl1";
            footerControl1.Size = new Size(1042, 48);
            footerControl1.TabIndex = 4;
            // 
            // headerControl1
            // 
            headerControl1.ActionControlSplitterVisible = true;

            headerControl1.BackColor = Color.Transparent;
            headerControl1.BackgroundImage = Resources.HeaderBar;
            headerControl1.Controls.Add(aircraftHeaderControl);
            headerControl1.Dock = DockStyle.Top;
            headerControl1.EditDisplayerText = "Edit operator";
            headerControl1.ContextActionControl.ShowPrintButton = false;
            headerControl1.ContextActionControl.ButtonPrint.DisplayerRequested += ButtonPrint_DisplayerRequested;
            headerControl1.EditReflectionType = ReflectionTypes.DisplayInNew;
            headerControl1.Location = new Point(0, 0);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new Size(1042, 58);
            headerControl1.TabIndex = 0;
            headerControl1.EditDisplayerRequested += headerControl1_EditDisplayerRequested;
            headerControl1.ReloadRised += ButtonReload_ReloadRised;
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
            // DirectiveListViewer
            // 
            AutoScroll = true;
            BackColor = Color.FromArgb(241, 241, 241);
            Controls.Add(directivesViewer);
            Controls.Add(panelTopContainer);
            Controls.Add(footerControl1);
            Controls.Add(headerControl1);
            Name = "DirectiveListViewer";
            Size = new Size(1042, 616);
            panelTopContainer.ResumeLayout(false);
            panelTopContainer.PerformLayout();
            headerControl1.ResumeLayout(false);
            headerControl1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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

        #region public override void UpdateElements()

        /// <summary>
        /// Происзодит обновление отображения элементов
        /// </summary>
        public void UpdateElements()
        {
            if (currentAircraft != null)
            {
                labelTitle.Text = currentAircraft.Model + ". " + reportText;
                filterSelection.PageTitle = reportText;
                aircraftHeaderControl.Aircraft = currentAircraft;
            }
            else if (currentBaseDetail != null)
            {
                labelTitle.Text = currentBaseDetail + ". " + reportText;
                filterSelection.PageTitle = reportText;
                aircraftHeaderControl.Aircraft = currentBaseDetail.ParentAircraft;
            }
            else
            {
                labelTitle.Text = reportText;
            }


            UpdateHeader();
            UpdateDirectives();
        }

        #endregion

        #region private void UpdateDirectives()

        private void UpdateDirectives()
        {
            directivesViewer.AdditionalFilter = additionalFilter;
            directivesViewer.UpdateItems();

            CheckContextMenu(directivesViewer.SelectedItems.Count);
            buttonAddDirective.Enabled = DirectiveCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            toolStripMenuItemAdd.Enabled = buttonAddDirective.Enabled;
            headerControl1.ContextActionControl.ButtonPrint.Enabled = directivesViewer.ItemsListView.Items.Count != 0;
        }

        #endregion

        #region private void ButtonReload_ReloadRised(object sender, EventArgs e)

        private void ButtonReload_ReloadRised(object sender, EventArgs e)
        {
            ReloadElements();
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
            //if (currentAircraft != null)
            //    e.DisplayerText = currentAircraft.Model + ". " + ReportText + " Report";
            //else if (currentBaseDetail != null)
            //    e.DisplayerText = currentBaseDetail + ". " + ReportText + " Report";
            //else
            //    e.DisplayerText = ReportText + " Report";
            //e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            //reportBuilder.Clear();
            //reportBuilder.DateAsOf = filterSelection.DateSelected.ToString(new TermsProvider()["DateFormat"].ToString());
            //BaseDetailDirective[] filteredBaseDetailDirectives = GatherBaseDetailDirectives();
            //BaseDetailDirective[] notFilteredDirectives = GatherBaseDetailDirectives(null);
            //if (currentAircraft != null)
            //{
            //    reportBuilder.Model = currentAircraft.Model;
            //    if (filteredBaseDetailDirectives.Length != notFilteredDirectives.Length)
            //        reportBuilder.ReportTitle += ". Filtered";
            //    reportBuilder.IsAircraftReport = true;
            //    e.RequestedEntity = new DispatcheredDirectiveListReport(directivesViewer.GetItemsArray(), reportBuilder);
            //}
            //else
            //{
            //    if (currentBaseDetail != null)
            //    {
            //        reportBuilder.Model = currentBaseDetail.Model;
            //        if (filteredBaseDetailDirectives.Length != notFilteredDirectives.Length)
            //            reportBuilder.ReportTitle += ". Filtered";
            //        reportBuilder.IsAircraftReport = false;
            //        e.RequestedEntity =
            //            new DispatcheredDirectiveListReport(directivesViewer.GetItemsArray(), reportBuilder);
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }

        #endregion

        #region private void headerControl1_EditDisplayerRequested(object sender, ReferenceEventArgs e)

        private void headerControl1_EditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            if (directivesViewer.SelectedItem == null)
                return;
            string model = CurrentAircraft.Model;
            if (!(directivesViewer.SelectedItem.Parent is TemplateAircraftFrame))
                model += ". " + directivesViewer.SelectedItem.Parent;
            e.RequestedEntity = new DispatcheredTemplateDirectiveScreen(directivesViewer.SelectedItem);
           // e.DisplayerText = "Templates. " + model + ". " + directivesViewer.SelectedItem.DirectiveType.CommonName + ". " +
            e.DisplayerText = model + ". " + directivesViewer.SelectedItem.DirectiveType.CommonName + ". " +
                              directivesViewer.SelectedItem.Title;
        }

        #endregion

        #region private void buttonApplyFilter_Click(object sender, EventArgs e)

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            filterSelection.PageTitle = reportText;
            filterSelection.SetFilterParameters(additionalFilter);
            filterSelection.Show();
            filterSelection.BringToFront();
            filterSelection.ApplyFilter += filterSelection_ApplyFilter;
        }

        #endregion

        #region private void referenceAvalonButtonAddDirective_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void referenceAvalonButtonAddDirective_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = CurrentAircraft.Model;
            if (!(currentBaseDetail is AircraftFrame) && currentBaseDetail != null)
                e.DisplayerText += ". " + currentBaseDetail;
            e.DisplayerText += ". " + CurrentDirectiveType.CommonName + ". New Directive";
            if (CurrentBaseDetail != null)
            {
                e.RequestedEntity = new DispatcheredTemplateDirectiveAdding(CurrentBaseDetail, currentDirectiveType);
            }
            else
            {
                e.RequestedEntity = new DispatcheredTemplateDirectiveAdding(CurrentAircraft, currentDirectiveType);
            }
        }

        #endregion

        #region private void filterSelection_ApplyFilter(object sender, EventArgs e)

        private void filterSelection_ApplyFilter(object sender, EventArgs e)
        {
            additionalFilter = filterSelection.GetDirectiveCollectionFilter();
            UpdateDirectives();
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
                             Height - headerControl1.Height - footerControl1.Height - panelTopContainer.Height);
            }
        }

        #endregion

        #region private void directivesViewer_SelectedItemsChanged(object sender, Auxiliary.SelectedItemsChangeEventArgs e)

        private void directivesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            CheckContextMenu(e.ItemsCount);
        }

        #endregion

        #region private void CheckContextMenu(int count)

        private void CheckContextMenu(int count)
        {
            buttonDeleteSelected.Enabled = (count > 0) &&
                                           TemplateBaseDetailDirectiveCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Remove);

            toolStripMenuItemDelete.Enabled = buttonDeleteSelected.Enabled;

            toolStripMenuItemView.Enabled = count > 0;
            headerControl1.ActionControl.ButtonEdit.Enabled = count == 1;

            if (count == 1)
            {
                toolStripMenuItemView.Text = "Go to " + directivesViewer.SelectedItems[0].Title;
            }
            else
            {
                if (count == 0)
                    toolStripMenuItemView.Text = "Nothing selected";
                else
                    toolStripMenuItemView.Text = "View directives";
            }
        }

        #endregion

        #region void buttonDeleteSelected_Click(object sender, EventArgs e) 

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
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
                ITemplateDirectiveContainer parent = directivesViewer.SelectedItems[0].Parent as ITemplateDirectiveContainer;
                if (parent != null)
                {
                    int count = directivesViewer.SelectedItems.Count;
                    try
                    {


                        List<TemplateBaseDetailDirective> selectedItems =
                            new List<TemplateBaseDetailDirective>(directivesViewer.SelectedItems);
                        for (int i = 0; i < count; i++)
                            parent.Remove(selectedItems[i]);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex); 
                        return;
                    }


                    ReloadElements();
                }
                else
                {
                    MessageBox.Show("Failed to delete directive: Parent container is invalid", "Operation failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        #region private void toolStripMenuItemView_Click(object sender, EventArgs e)

        private void toolStripMenuItemView_Click(object sender, EventArgs e)
        {
            OnViewDetails();
        }

        #endregion

        #region protected void OnViewDetails()

        /// <summary>
        /// Обработка запроса открытия отображения директивы
        /// </summary>
        protected void OnViewDetails()
        {
            List<TemplateBaseDetailDirective> selected = directivesViewer.SelectedItems;

            for (int i = 0; i < selected.Count; i++)
            {
                TemplateBaseDetailDirective directive = selected[i];
                string tabHeader = "";
                if (directive.Parent is TemplateAircraftFrame)
                    tabHeader = directive.Parent.ToString();
                else
                {
                    if ((directive.Parent).Parent is TemplateAircraft)
                        tabHeader = ((TemplateAircraft) ((directive.Parent).Parent)).Model + ". " +
                                    directive.Parent;
                }
                OnDisplayerRequested(
                    new ReferenceEventArgs(
                        new DispatcheredTemplateDirectiveScreen(directive),
                        ReflectionTypes.DisplayInNew, null,
                        tabHeader + ". " + directive.DirectiveType.CommonName + ". " + directive.Title));
            }
        }

        #endregion

        #region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            buttonDeleteSelected_Click(sender, e);
        }

        #endregion

        #region private void toolStripMenuItemAdd_Click(object sender, EventArgs e)

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs argumetns = new ReferenceEventArgs();
            referenceAvalonButtonAddDirective_DisplayerRequested(this, argumetns);
            OnDisplayerRequested(argumetns);
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

        #region private void TemplateDirectiveListScreen_Saved(object sender, EventArgs e)

        private void TemplateDirectiveListScreen_Saved(object sender, EventArgs e)
        {
            directivesViewer.EditItem(editedDirective, (TemplateBaseDetailDirective)sender);
        }

        #endregion

        #region private void TemplateDirectiveListScreen_Saving(object sender, CancelEventArgs e)

        private void TemplateDirectiveListScreen_Saving(object sender, CancelEventArgs e)
        {
            editedDirective = (TemplateBaseDetailDirective)sender;
        }

        #endregion

        #region private void TemplateDirectiveListScreen_DirectiveAdded(object sender, CancelCollectionChangeEventArgs args)

        private void TemplateDirectiveListScreen_DirectiveAdded(object sender, CollectionChangeEventArgs args)
        {
            TemplateBaseDetailDirective directive = (TemplateBaseDetailDirective) args.Element;
            directivesViewer.AddNewItem(directive);
            HookDirective(directive, true);
        }

        #endregion

        #region private void TemplateDirectiveListScreen_DirectiveRemoved(object sender, CancelCollectionChangeEventArgs args)

        private void TemplateDirectiveListScreen_DirectiveRemoved(object sender, CollectionChangeEventArgs args)
        {
            directivesViewer.DeleteItem((TemplateBaseDetailDirective)args.Element);
        }

        #endregion
        
        #region public void PerformEvents(bool addTo)

        ///<summary>
        /// Подписывает и отписывает собития добавления, редактирования и удаления директив
        ///</summary>
        ///<param name="addTo"></param>
        public void PerformEvents(bool addTo)
        {
            if (currentAircraft != null)
            {
                if (addTo)
                {
                    for (int i = 0; i < currentAircraft.BaseDetails.Length; i++)
                    {
                        currentAircraft.BaseDetails[i].DirectiveAdded += TemplateDirectiveListScreen_DirectiveAdded;
                        currentAircraft.BaseDetails[i].DirectiveRemoved += TemplateDirectiveListScreen_DirectiveRemoved;
                    }
                }
                else
                {
                    for (int i = 0; i < currentAircraft.BaseDetails.Length; i++)
                    {
                        currentAircraft.BaseDetails[i].DirectiveAdded -= TemplateDirectiveListScreen_DirectiveAdded;
                        currentAircraft.BaseDetails[i].DirectiveRemoved -= TemplateDirectiveListScreen_DirectiveRemoved;
                    }
                }
                for (int i = 0; i < currentAircraft.ContainedDirectives.Length; i++)
                    HookDirective(currentAircraft.ContainedDirectives[i], addTo);
            }
            else
            {
                if (addTo)
                {
                    currentBaseDetail.DirectiveAdded += TemplateDirectiveListScreen_DirectiveAdded;
                    currentBaseDetail.DirectiveRemoved += TemplateDirectiveListScreen_DirectiveRemoved;
                }
                else
                {
                    currentBaseDetail.DirectiveAdded -= TemplateDirectiveListScreen_DirectiveAdded;
                    currentBaseDetail.DirectiveRemoved -= TemplateDirectiveListScreen_DirectiveRemoved;
                }
                for (int i = 0; i < currentBaseDetail.ContainedDirectives.Length; i++)
                    HookDirective(currentBaseDetail.ContainedDirectives[i], addTo);
            }


        }

        #endregion

        #region private void HookDirective(TemplateBaseDetailDirective directive, bool addTo)

        private void HookDirective(TemplateBaseDetailDirective directive, bool addTo)
        {
            if (addTo)
            {
                directive.Saved += TemplateDirectiveListScreen_Saved;
                directive.Saving += TemplateDirectiveListScreen_Saving;
            }
            else
            {
                directive.Saved -= TemplateDirectiveListScreen_Saved;
                directive.Saving -= TemplateDirectiveListScreen_Saving;
            }
        }

        #endregion
        
        #endregion
    }
}