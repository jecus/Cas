using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Appearance;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls;
using CAS.UI.UIControls.Auxiliary.Comparers;

namespace CAS.UI.UIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения кнопок шасси
    /// </summary>
    public class TemplateLandingGearsButtonsControl : UserControl, IReference
    {

        #region Fields

        private readonly TemplateAircraft currentAircraft;
        private List<ReferenceAvalonButtonM> landingGearButtons;
        private readonly FlowLayoutPanel panel = new FlowLayoutPanel();
        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;
        private readonly Icons icons = new Icons();

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения кнопок шасси
        /// </summary>
        /// <param name="aircraft">ВС, которому принадлежат шасси</param>
        public TemplateLandingGearsButtonsControl(TemplateAircraft aircraft)
        {
            currentAircraft = aircraft;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region Methods

        #region Unused

/*        #region private void button_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void button_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (!(sender is Control))
                return;
            Control control = (Control) sender;
            if (!(control.Tag is TemplateDetail))
                return;
            TemplateDetail detail = (TemplateDetail)control.Tag;
            e.RequestedEntity = new DispatcheredTemplateDetailScreen(detail);
        }

        #endregion
        
        #region private void panel_SizeChanged(object sender, EventArgs e)

        private void panel_SizeChanged(object sender, EventArgs e)
        {
            Height = panel.Height + HEIGHT_MARGIN;
        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        /// <summary>
        /// Метод, необходимый для корректного отображения данного элемента управления
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            panel.MaximumSize = new Size(Width, MAX_HEIGHT);
        }

        #endregion

        #region private void UpdateControl()

        private void UpdateControl()
        {
            List<ReferenceAvalonButtonM> leftLandingGears = new List<ReferenceAvalonButtonM>();
            List<ReferenceAvalonButtonM> noseLandingGears = new List<ReferenceAvalonButtonM>();
            List<ReferenceAvalonButtonM> rightLandingGears = new List<ReferenceAvalonButtonM>();

            for (int i = 0; i < currentAircraft.Length; i++)
            {
                ReferenceAvalonButtonM button = new ReferenceAvalonButtonM();

                button.ActiveColor = Css.BaseDetailInfoControl.Colors.InactiveTopColorHovered;
                button.ExtendedColor = Css.BaseDetailInfoControl.Colors.InactiveBottomColor;
                button.Font = Css.BaseDetailInfoControl.Fonts.PrimaryFont;
                button.ForeColor = Css.BaseDetailInfoControl.Colors.PrimaryForeColor;
                button.MouseDownColor = Css.BaseDetailInfoControl.Colors.InactiveTopColorPressed;
                button.NormalColor = Css.BaseDetailInfoControl.Colors.InactiveTopColor;
                button.ReflectionType = ReflectionTypes.DisplayInNew;
                button.SecondFont = Css.BaseDetailInfoControl.Fonts.SecondaryFont;
                button.SecondForeColor = Css.BaseDetailInfoControl.Colors.SecondaryForeColor;
                button.SecondTextAlign = ContentAlignment.TopLeft;
                button.SecondTextPadding = new Padding(10, 0, 0, 0);
                button.TextAlign = ContentAlignment.TopLeft;
                button.TextPadding = new Padding(0, 6, 0, 0);
                button.SecondaryTextPosition = 44;
                button.SecondText = "P/N: " + currentAircraft[i].PartNumber + Environment.NewLine + "Amount: " + currentAircraft[i].Amount;
                button.Icon = icons.GrayArrow;
                button.Tag = currentAircraft[i];
                if (!(currentAircraft[i].Parent is TemplateBaseDetail))
                    return;
                // button.DisplayerText = "Templates. " + ((TemplateBaseDetail)currentAircraft[i].Parent).ParentAircraft.Model + ". Component PN " + currentAircraft[i].PartNumber;
                button.DisplayerText = ((TemplateBaseDetail)currentAircraft[i].Parent).ParentAircraft.Model + ". Component PN " + currentAircraft[i].PartNumber;
                button.DisplayerRequested += button_DisplayerRequested;
/*
                switch (currentAircraft[i].LandingGearMark)
                {
                    case LandingGearMarkType.Left:
                        button.Text = "LLG";
                        leftLandingGears.Add(button);
                        break;
                    case LandingGearMarkType.General:
                        button.Text = "NLG";
                        noseLandingGears.Add(button);
                        break;
                    case LandingGearMarkType.Right:
                        button.Text = "RLG";
                        rightLandingGears.Add(button);
                        break;
                }
*/
        /*    }
            leftLandingGears.Sort(new ReferenceAvalonButtonMComparer());
            noseLandingGears.Sort(new ReferenceAvalonButtonMComparer());
            rightLandingGears.Sort(new ReferenceAvalonButtonMComparer());

            panel.Controls.Clear();
            panel.Controls.AddRange(leftLandingGears.ToArray());
            panel.Controls.AddRange(noseLandingGears.ToArray());
            panel.Controls.AddRange(rightLandingGears.ToArray());
        }

        #endregion*/

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            landingGearButtons = new List<ReferenceAvalonButtonM>();
            //
            // panel
            //
            panel.Dock = DockStyle.Fill;
            panel.AutoScroll = true;
            panel.FlowDirection = FlowDirection.LeftToRight;

            Controls.Add(panel);
        }

        #endregion

        #region private ContextMenuStrip CreateContextMenuToLandingGear(TemplateGearAssembly gearAssembly)

        private ContextMenuStrip CreateContextMenuToLandingGear(TemplateGearAssembly gearAssembly)
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem titleToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem addComponentToolStripMenuItem1 = new ToolStripMenuItem();
            ToolStripMenuItem deleteToolStripMenuItem = new ToolStripMenuItem();
            ToolStripSeparator toolStripSeparator1 = new ToolStripSeparator();
            // 
            // titleToolStripMenuItem
            // 
            titleToolStripMenuItem.Text = gearAssembly.ToString();
            titleToolStripMenuItem.Click += titleToolStripMenuItem_Click;
            // 
            // addComponentToolStripMenuItem1
            // 
            addComponentToolStripMenuItem1.Text = "Add component";
            addComponentToolStripMenuItem1.Click += addComponentToolStripMenuItem1_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            //
            // LandingGearsButtonsControl
            //
            addComponentToolStripMenuItem1.Enabled = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            deleteToolStripMenuItem.Enabled = BaseDetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Remove);
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                 {
                                                     titleToolStripMenuItem,
                                                     toolStripSeparator1,
                                                     addComponentToolStripMenuItem1,
                                                     deleteToolStripMenuItem
                                                 });
            return contextMenuStrip;
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет информацию
        /// </summary>
        public void UpdateInformation()
        {
            List<ReferenceAvalonButtonM> leftLandingGears = new List<ReferenceAvalonButtonM>();
            List<ReferenceAvalonButtonM> noseLandingGears = new List<ReferenceAvalonButtonM>();
            List<ReferenceAvalonButtonM> rightLandingGears = new List<ReferenceAvalonButtonM>();
            List<ReferenceAvalonButtonM> noneLandingGears = new List<ReferenceAvalonButtonM>();

            for (int i = 0; i < currentAircraft.LandingGears.Length; i++)
            {
                ReferenceAvalonButtonM button = new ReferenceAvalonButtonM();

                button.ActiveColor = Css.BaseDetailInfoControl.Colors.InactiveTopColorHovered;
                button.ExtendedColor = Css.BaseDetailInfoControl.Colors.InactiveBottomColor;
                button.Font = Css.BaseDetailInfoControl.Fonts.PrimaryFont;
                button.ForeColor = Css.BaseDetailInfoControl.Colors.PrimaryForeColor;
                button.Icon = icons.GrayArrow;
                button.MouseDownColor = Css.BaseDetailInfoControl.Colors.InactiveTopColorPressed;
                button.NormalColor = Css.BaseDetailInfoControl.Colors.InactiveTopColor;
                button.ReflectionType = ReflectionTypes.DisplayInNew;
                button.SecondFont = Css.BaseDetailInfoControl.Fonts.SecondaryFont;
                button.SecondForeColor = Css.BaseDetailInfoControl.Colors.SecondaryForeColor;
                button.SecondTextAlign = ContentAlignment.TopLeft;
                button.SecondTextPadding = new Padding(10, 0, 0, 0);
                button.TextAlign = ContentAlignment.TopLeft;
                button.TextPadding = new Padding(0, 6, 0, 0);
                button.SecondaryTextPosition = 44;
                button.SecondText = "P/N: " + currentAircraft.LandingGears[i].PartNumber;// +Environment.NewLine + "Amount: " + currentAircraft.LandingGears[i].Amount;
                button.Tag = currentAircraft.LandingGears[i];
                button.DisplayerText = currentAircraft.Model + ". Component PN " + currentAircraft.LandingGears[i].PartNumber;
                button.DisplayerRequested += button_DisplayerRequested;
                if (currentAircraft.LandingGears[i].LandingGearMark == LandingGearMarkType.Left)
                {
                    button.Text = UsefulMethods.GetLandingGearPositionName(currentAircraft.LandingGears[i]);
                    leftLandingGears.Add(button);
                }
                else if (currentAircraft.LandingGears[i].LandingGearMark == LandingGearMarkType.General)
                {
                    button.Text = UsefulMethods.GetLandingGearPositionName(currentAircraft.LandingGears[i]);
                    noseLandingGears.Add(button);
                }
                else if (currentAircraft.LandingGears[i].LandingGearMark == LandingGearMarkType.Right)
                {
                    button.Text = UsefulMethods.GetLandingGearPositionName(currentAircraft.LandingGears[i]);
                    rightLandingGears.Add(button);
                }
                else
                {
                    button.Text = UsefulMethods.GetLandingGearPositionName(currentAircraft.LandingGears[i]);
                    noneLandingGears.Add(button);
                }
                ContextMenuStrip contextMenuStrip = CreateContextMenuToLandingGear(currentAircraft.LandingGears[i]);
                contextMenuStrip.Tag = currentAircraft.LandingGears[i];
                button.ContextMenuStrip = contextMenuStrip;
            }
            leftLandingGears.Sort(new ReferenceAvalonButtonMComparer());
            noseLandingGears.Sort(new ReferenceAvalonButtonMComparer());
            rightLandingGears.Sort(new ReferenceAvalonButtonMComparer());
            noneLandingGears.Sort(new ReferenceAvalonButtonMComparer());

            panel.Controls.Clear();
            landingGearButtons.Clear();
            panel.Controls.AddRange(leftLandingGears.ToArray());
            panel.Controls.AddRange(noseLandingGears.ToArray());
            panel.Controls.AddRange(rightLandingGears.ToArray());
            panel.Controls.AddRange(noneLandingGears.ToArray());
            landingGearButtons.AddRange(leftLandingGears);
            landingGearButtons.AddRange(noseLandingGears);
            landingGearButtons.AddRange(rightLandingGears);
            landingGearButtons.AddRange(noneLandingGears);

            if (landingGearButtons.Count > 0)
                Size = new Size(750, 100);
            else
                Size = new Size(750, 0);
        }

        #endregion

        #region private static void button_DisplayerRequested(object sender, ReferenceEventArgs e)

        private static void button_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (!(sender is Control))
            {
                e.Cancel = true;
                return;
            }
            Control control = (Control)sender;
            if (!(control.Tag is TemplateBaseDetail))
            {
                e.Cancel = true;
                return;
            }
            TemplateBaseDetail detail = (TemplateBaseDetail)control.Tag;
            e.RequestedEntity = new DispatcheredTemplateDetailScreen(detail);
        }

        #endregion

        #region private void titleToolStripMenuItem_Click(object sender, EventArgs e)

        private void titleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
            TemplateBaseDetail baseDetail = (TemplateBaseDetail)contextMenuStrip.Tag;
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            arguments.DisplayerText = currentAircraft.Model + ". Component PN " + baseDetail.PartNumber;
            arguments.TypeOfReflection = ReflectionTypes.DisplayInNew;
            arguments.RequestedEntity = new DispatcheredTemplateDetailScreen(baseDetail);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private static void deleteToolStripMenuItem_Click(object sender, EventArgs e)

        private static void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
            TemplateBaseDetail baseDetail = (TemplateBaseDetail)contextMenuStrip.Tag;
            DialogResult choice = MessageBox.Show("Delete " + baseDetail.PartNumber + " item?", "Confirm deleting", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (choice == DialogResult.Yes)
            {
                if (baseDetail.ParentAircraft != null)
                    baseDetail.ParentAircraft.RemoveBaseDetail(baseDetail);
            }
        }

        #endregion

        #region private void addComponentToolStripMenuItem1_Click(object sender, EventArgs e)

        private void addComponentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
            TemplateBaseDetail baseDetail = (TemplateBaseDetail)contextMenuStrip.Tag;
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            arguments.DisplayerText = currentAircraft.Model + ". " + baseDetail + ". Add component";
            arguments.TypeOfReflection = ReflectionTypes.DisplayInNew;
            arguments.RequestedEntity = new DispatcheredTemplateDetailAdding(baseDetail);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region protected override void OnEnabledChanged(EventArgs e)

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            for (int i = 0; i < landingGearButtons.Count; i++)
            {
                landingGearButtons[i].Enabled = Enabled;
            }
        }

        #endregion

        #endregion

        #endregion

        #region IReference Members

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

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
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