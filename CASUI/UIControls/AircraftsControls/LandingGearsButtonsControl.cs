using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CAS.UI.Management;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.ComplianceControls;
using CAS.UI.UIControls.StoresControls;

namespace CAS.UI.UIControls.AircraftsControls
{
    /// <summary>
    /// Элемент управления для отображения кнопок шасси
    /// </summary>
    public class LandingGearsButtonsControl : UserControl, IReference
    {

        #region Fields

        private readonly Aircraft currentAircraft;
        private List<ReferenceAvalonButtonM> landingGearButtons;
        private readonly FlowLayoutPanel panel = new FlowLayoutPanel();
        private readonly Icons icons = new Icons();
        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения кнопок шасси
        /// </summary>
        /// <param name="currentAircraft">Текущее ВС</param>
        public LandingGearsButtonsControl(Aircraft currentAircraft)
        {
            this.currentAircraft = currentAircraft;
            InitializeComponent();
            UpdateInformation();
        }

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

        #region private ContextMenuStrip CreateContextMenuToLandingGear(GearAssembly gearAssembly)

        private ContextMenuStrip CreateContextMenuToLandingGear(GearAssembly gearAssembly)
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem titleToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem registerToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem inspectionToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem logBookToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem addComponentToolStripMenuItem1 = new ToolStripMenuItem();
            ToolStripMenuItem deleteToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem toolStripMenuItemMoveToStore = new ToolStripMenuItem();
            ToolStripSeparator toolStripSeparator1 = new ToolStripSeparator();
            ToolStripSeparator toolStripSeparator2 = new ToolStripSeparator();
            ToolStripSeparator toolStripSeparator3 = new ToolStripSeparator();
            // 
            // titleToolStripMenuItem
            // 
            titleToolStripMenuItem.Text = gearAssembly.ToString();
            titleToolStripMenuItem.Click += titleToolStripMenuItem_Click;
            // 
            // registerToolStripMenuItem
            // 
            registerToolStripMenuItem.Text = "Register";
            // 
            // inspectionToolStripMenuItem
            // 
            inspectionToolStripMenuItem.Text = "Inspection";
            inspectionToolStripMenuItem.Tag = gearAssembly;
            inspectionToolStripMenuItem.Click += inspectionToolStripMenuItem_Click;
            // 
            // logBookToolStripMenuItem
            // 
            logBookToolStripMenuItem.Text = "Log book";
            logBookToolStripMenuItem.Click += logBookToolStripMenuItem_Click;
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
            // engeneeringOrdersToolStripMenuItem
            // 
            toolStripMenuItemMoveToStore.Text = "Move to Store";
            toolStripMenuItemMoveToStore.Click += toolStripMenuItemMoveToStore_Click;
            //
            // LandingGearsButtonsControl
            //
            registerToolStripMenuItem.Enabled = DirectiveCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            addComponentToolStripMenuItem1.Enabled = DetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            deleteToolStripMenuItem.Enabled = BaseDetailCollection.HasAccess(Users.CurrentUser.Role, DataEvent.Remove);
            registerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
                                                                 {
                                                                     inspectionToolStripMenuItem,
                                                                 });
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                 {
                                                     titleToolStripMenuItem,
                                                     toolStripSeparator1,
                                                     logBookToolStripMenuItem,
                                                     registerToolStripMenuItem,
                                                     toolStripSeparator2,
                                                     toolStripMenuItemMoveToStore,
                                                     toolStripSeparator3,
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
                button.SecondText = "S/N: " + currentAircraft.LandingGears[i].SerialNumber + Environment.NewLine + "P/N: " + currentAircraft.LandingGears[i].PartNumber;
                button.Tag = currentAircraft.LandingGears[i];
                button.DisplayerText = currentAircraft.RegistrationNumber + ". Component SN " + currentAircraft.LandingGears[i].SerialNumber;
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

                ChangeStatus(DirectiveConditionState.Satisfactory, button);//currentAircraft.LandingGears[i].LimitationCondition, button);
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
            Control control = (Control) sender;
            if (!(control.Tag is BaseDetail))
            {
                e.Cancel = true;
                return;
            }
            BaseDetail detail = (BaseDetail)control.Tag;
            e.RequestedEntity = new DispatcheredDetailScreen(detail);
        }

        #endregion


        #region private void logBookToolStripMenuItem_Click(object sender, EventArgs e)

        private void logBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
/*
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
            BaseDetail baseDetail = (BaseDetail)contextMenuStrip.Tag;
            ReferenceEventArgs arguments =  new ReferenceEventArgs(new DispatcheredBaseDetailLogBookScreen(baseDetail),
                                       ReflectionTypes.DisplayInNew, baseDetail + ". Log book");
            OnDisplayerRequested(arguments);
*/
        }

        #endregion

        #region private static void inspectionToolStripMenuItem_Click(object sender, EventArgs e)

        private static void inspectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            BaseDetail baseDetail = (BaseDetail)toolStripMenuItem.Tag;
            ComplianceForm form = new ComplianceForm(baseDetail);
            form.WorkType = RecordTypesCollection.Instance.InspectionRecordType;
            form.ShowDialog();*/
            
        }

        #endregion

        #region private void titleToolStripMenuItem_Click(object sender, EventArgs e)

        private void titleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
            BaseDetail baseDetail = (BaseDetail)contextMenuStrip.Tag;
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            arguments.DisplayerText = currentAircraft.RegistrationNumber + ". Component SN " + baseDetail.SerialNumber;
            arguments.TypeOfReflection = ReflectionTypes.DisplayInNew;
            arguments.RequestedEntity = new DispatcheredDetailScreen(baseDetail);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private static void deleteToolStripMenuItem_Click(object sender, EventArgs e)

        private static void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
            BaseDetail baseDetail = (BaseDetail)contextMenuStrip.Tag;
            DialogResult choice =
                MessageBox.Show("Delete " + baseDetail.SerialNumber + " item?", "Confirm deleting",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
            BaseDetail baseDetail = (BaseDetail)contextMenuStrip.Tag;
            ReferenceEventArgs arguments = new ReferenceEventArgs();
            arguments.DisplayerText = currentAircraft.RegistrationNumber + ". " + baseDetail + ". Add component";
            arguments.TypeOfReflection = ReflectionTypes.DisplayInNew;
            arguments.RequestedEntity = new DispatcheredDetailAddingScreen(baseDetail);
            OnDisplayerRequested(arguments);
        }

        #endregion

        #region private static void toolStripMenuItemMoveToStore_Click(object sender, EventArgs e)

        private static void toolStripMenuItemMoveToStore_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.Owner;
            BaseDetail baseDetail = (BaseDetail)contextMenuStrip.Tag;
            MoveDetailForm form = new MoveDetailForm(baseDetail, MoveDetailFormMode.MoveToStore, null);
            form.ShowDialog();
        }

        #endregion


        #region private void ChangeStatus(DirectiveConditionState status, ReferenceAvalonButtonM button)

        /// <summary>
        /// Меняет иконку заданной кнопки в зависимости от статуса
        /// </summary>
        /// <param name="status">Статус</param>
        /// <param name="button">Кнопка</param>
        private void ChangeStatus(DirectiveConditionState status, ReferenceAvalonButtonM button)
        {
            switch(status)
            {
                case DirectiveConditionState.NotSatisfactory:
                    button.Icon = icons.RedArrow;
                    break;
                case DirectiveConditionState.Notify:
                    button.Icon = icons.OrangeArrow;
                    break;
                case DirectiveConditionState.Satisfactory:
                    button.Icon = icons.GreenArrow;
                    break;
            }
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
