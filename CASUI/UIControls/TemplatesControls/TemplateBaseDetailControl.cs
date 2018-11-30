using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.UI.Management;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls;

namespace CAS.UI.UIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения отчетов базовых агрегатов ВС
    /// </summary>
    public class TemplateBaseDetailControl : UserControl, IReference
    {

        #region Fields

        /// <summary>
        /// Базовый агрегат, отображаемый элементом управления
        /// </summary>
        protected TemplateBaseDetail currentBaseDetail;
        /// <summary>
        /// Кнопка отображения статуса и параметров базового агрегата
        /// </summary>
        protected ReferenceAvalonButtonM baseDetailButton = new ReferenceAvalonButtonM();
        
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem titleToolStripMenuItem;
        private ToolStripMenuItem addComponentToolStripMenuItem1;
        private ToolStripMenuItem aDStatusToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItemLLPDiskSheet;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem sBStatusToolStripMenuItem;

        private readonly int bottomPadding = 10;
        private readonly int splitterDistance = 240;
        private TemplateBaseDetailLinksFlowLayoutPanel contentPanel;
        private Panel paddingPanel = new Panel();
        private SplitContainer splitContainer = new SplitContainer();
        private readonly Size defaultSize = new Size(750, 200);

        #endregion

        #region Constructor

        /// <summary>
        /// Создается объект для отображения базового агрегата
        /// </summary>
        /// <param name="detail">Отображаемый объект</param>
        public TemplateBaseDetailControl(TemplateBaseDetail detail)
        {
            if (null == detail) 
                throw new ArgumentNullException("detail", "Cannot be null");
            currentBaseDetail = detail;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            splitContainer = new SplitContainer();
            contentPanel = new TemplateBaseDetailLinksFlowLayoutPanel(currentBaseDetail);
            contextMenuStrip1 = new ContextMenuStrip();
            titleToolStripMenuItem = new ToolStripMenuItem();
            addComponentToolStripMenuItem1 = new ToolStripMenuItem();
            aDStatusToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItemLLPDiskSheet = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            sBStatusToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            // 
            // titleToolStripMenuItem
            // 
            titleToolStripMenuItem.Text = "[Title]";
            titleToolStripMenuItem.Click += new EventHandler(titleToolStripMenuItem_Click);
            // 
            // addComponentToolStripMenuItem1
            // 
            addComponentToolStripMenuItem1.Text = "Add component";
            addComponentToolStripMenuItem1.Click += new EventHandler(addComponentToolStripMenuItem1_Click);
            // 
            // aDStatusToolStripMenuItem
            // 
            aDStatusToolStripMenuItem.Text = "AD Status";
            aDStatusToolStripMenuItem.Click += new EventHandler(aDStatusToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemLLPDiskSheet
            // 
            ToolStripMenuItemLLPDiskSheet.Text = "LLP Disk Sheet Status";
            ToolStripMenuItemLLPDiskSheet.Click += new EventHandler(toolStripMenuItemLLPDiskSheet_Click);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += new EventHandler(deleteToolStripMenuItem_Click);
            // 
            // sBStatusToolStripMenuItem
            // 
            sBStatusToolStripMenuItem.Text = "SB Status";
            sBStatusToolStripMenuItem.Click += new EventHandler(sBStatusToolStripMenuItem_Click);
            //
            // baseDetailButton
            //
            baseDetailButton.ActiveColor = Css.BaseDetailInfoControl.Colors.InactiveTopColorHovered;
            baseDetailButton.ExtendedColor = Css.BaseDetailInfoControl.Colors.InactiveBottomColor;
            baseDetailButton.Font = Css.BaseDetailInfoControl.Fonts.PrimaryFont;
            baseDetailButton.ForeColor = Css.BaseDetailInfoControl.Colors.PrimaryForeColor;
            baseDetailButton.Icon = new Icons().GrayArrow;
            baseDetailButton.MouseDownColor = Css.BaseDetailInfoControl.Colors.InactiveTopColorPressed;
            baseDetailButton.NormalColor = Css.BaseDetailInfoControl.Colors.InactiveTopColor;
            baseDetailButton.ReflectionType = ReflectionTypes.DisplayInNew;
            baseDetailButton.SecondFont = Css.BaseDetailInfoControl.Fonts.SecondaryFont;
            baseDetailButton.SecondForeColor = Css.BaseDetailInfoControl.Colors.SecondaryForeColor;
            baseDetailButton.SecondTextAlign = ContentAlignment.TopLeft;
            baseDetailButton.SecondTextPadding = new Padding(10, 0, 0, 0);
            baseDetailButton.Size = new Size(235, 90);
            baseDetailButton.TextAlign = ContentAlignment.TopLeft;
            baseDetailButton.TextPadding = new Padding(0, 6, 0, 0);
            baseDetailButton.SecondaryTextPosition = 44;
            baseDetailButton.DisplayerRequested += aircraftButton_DisplayerRequested;
            baseDetailButton.ContextMenuStrip = contextMenuStrip1;
            //
            // splitter
            //
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitter";
            splitContainer.IsSplitterFixed = true;
            splitContainer.SplitterDistance = 230;
            //
            // paddingPanel
            //
            paddingPanel = new Panel();
            paddingPanel.Size = new Size(0, 0);
            paddingPanel.Dock = DockStyle.Top;
            paddingPanel.BringToFront();
            // 
            // splitter.Panel1
            // 
            splitContainer.Panel1.Controls.Add(baseDetailButton);
            splitContainer.Panel2.BackColor = Color.Transparent;
            // 
            // splitter.Panel2
            // 
            splitContainer.Panel2.Controls.Add(contentPanel);
            splitContainer.Panel2.Controls.Add(paddingPanel);
            splitContainer.Panel2.BackColor = Color.Transparent;
            splitContainer.TabIndex = 0;
            // 
            // contentPanel
            // 
            contentPanel.AutoSize = true;
            contentPanel.Dock = DockStyle.Top;
            contentPanel.Location = new Point(0, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.TabIndex = 0;
            contentPanel.SizeChanged += contentPanel_SizeChanged;
            //
            // BaseDetailControl
            //
            Controls.Add(splitContainer);
            Size = defaultSize;
            addComponentToolStripMenuItem1.Enabled = TemplateDetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            deleteToolStripMenuItem.Enabled = TemplateBaseDetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Remove);
            // 
            // BaseDetailControl
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[]
                                                 {
                                                     titleToolStripMenuItem,
                                                     toolStripSeparator1,
                                                     aDStatusToolStripMenuItem,
                                                     ToolStripMenuItemLLPDiskSheet,
                                                     sBStatusToolStripMenuItem,
                                                     toolStripSeparator2,
                                                     addComponentToolStripMenuItem1,
                                                     deleteToolStripMenuItem
                                                 });
            baseDetailButton.ContextMenuStrip = contextMenuStrip1;
            if (!(currentBaseDetail is TemplateEngine))
                ToolStripMenuItemLLPDiskSheet.Visible = false;
            baseDetailButton.Text = currentBaseDetail.DetailType.ShortName;
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет информацию 
        /// </summary>
        public void UpdateInformation()
        {
            titleToolStripMenuItem.Text = currentBaseDetail.ToString();
            baseDetailButton.SecondText = "P/N: " + currentBaseDetail.PartNumber;// +Environment.NewLine + "Amount: " + currentBaseDetail.Amount;
        }

        #endregion



        #region private void aircraftButton_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void aircraftButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentBaseDetail.ParentAircraft.Model + ". Component PN " + currentBaseDetail.PartNumber;
            e.RequestedEntity = new DispatcheredTemplateDetailScreen(currentBaseDetail);
        }

        #endregion

        #region private void aDStatusToolStripMenuItem_Click(object sender, EventArgs e)

        private void aDStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            contentPanel.OnADStatusLinkDisplayRequested(arguments);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private void titleToolStripMenuItem_Click(object sender, EventArgs e)

        private void titleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            arguments.TypeOfReflection = ReflectionTypes.DisplayInNew;
            arguments.DisplayerText = currentBaseDetail.ParentAircraft.Model + ". Component PN " + currentBaseDetail.PartNumber;
            arguments.RequestedEntity = new DispatcheredTemplateDetailScreen(currentBaseDetail);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private void sBStatusToolStripMenuItem_Click(object sender, EventArgs e)

        private void sBStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            contentPanel.OnSBStatusLinkDisplayRequested(arguments);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private void toolStripMenuItemLLPDiskSheet_Click(object sender, EventArgs e)

        private void toolStripMenuItemLLPDiskSheet_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            contentPanel.OnLLPDiskSheetStatusLinkDisplayRequested(arguments);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private void addComponentToolStripMenuItem1_Click(object sender, EventArgs e)

        private void addComponentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            if (currentBaseDetail is TemplateAircraftFrame)
                arguments.DisplayerText = currentBaseDetail + ". Add component";
            else
                arguments.DisplayerText = currentBaseDetail.ParentAircraft.Model + ". " + currentBaseDetail + ". Add component";
            arguments.TypeOfReflection = ReflectionTypes.DisplayInNew;
            arguments.RequestedEntity = new DispatcheredTemplateDetailAdding(currentBaseDetail);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private void deleteToolStripMenuItem_Click(object sender, EventArgs e)

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("Delete " + currentBaseDetail.PartNumber + " item?", "Confirm deleting",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (choice == DialogResult.Yes)
            {
                try
                {
                    if (currentBaseDetail.ParentAircraft != null)
                        currentBaseDetail.ParentAircraft.RemoveBaseDetail(currentBaseDetail);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); 
                    return;
                }
            }
        }

        #endregion

        
        #region protected override void OnEnabledChanged(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.EnabledChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            contentPanel.SetEnabled(Enabled);
        }

        #endregion

        #region private void contentPanel_SizeChanged(object sender, EventArgs e)

        /// <summary>
        /// Occurs when size of content panel been changed
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Parameters</param>
        private void contentPanel_SizeChanged(object sender, EventArgs e)
        {
            splitContainer.Height = contentPanel.Height > baseDetailButton.Height
                                        ? contentPanel.Height
                                        : baseDetailButton.Height;
            if ((contentPanel.Height + bottomPadding) < baseDetailButton.Height)
                Height = baseDetailButton.Height;
            else
                Height = contentPanel.Height + bottomPadding;
        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        /// <summary>
        /// Метод, презназначенный для корректного отображения данного элемента управления
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if ((splitterDistance > splitContainer.Panel1MinSize) &&
                (splitterDistance < Width - splitContainer.Panel2MinSize))
                splitContainer.SplitterDistance = splitterDistance;
        }

        #endregion

        #endregion

        #region IReference items

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return ""; }
            set { }
        }

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return ReflectionTypes.DisplayInNew; }
            set { }
        }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        /// <summary>
        /// Вызов события DisplayerRequested
        /// </summary>
        /// <param name="e">Параметры события</param>
        protected void OnDisplayerRequested(ReferenceEventArgs e)
        {
            if (DisplayerRequested != null)
                DisplayerRequested(this, e);
        }

        #endregion
    }
}