using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types;
using CAS.UI.Management;
using CAS.Core.Core.Interfaces;
using CAS.Core.Management;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.OpepatorsControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.UIControls.OpepatorsControls
{

    /// <summary>
    /// Отображает список ВС, относящихся к заданному эксплуатанту
    /// </summary>
    [ToolboxItem(true)]
    public class OperatorsCollectionScreen : UserControl
    {

        #region Fields

        private HeaderControl header;
        private OperatorHeaderControl operatorHeaderControl;
        private FooterControl footer;
        private Panel mainPanel;
        private FlowLayoutPanel flowLayoutPanelRight;
        protected OperatorCollectionControl operatorCollectionControl;
        private BiWeeklyReportsReference biWeeklyReference;
        //private UsersReference usersReference;
        private OperatorCollection operators;
        private TemplatesReference templatesReference;
        private RichReferenceButton buttonAddOperator;
        
        private readonly Icons icons = new Icons();
        private const int RIGHT_PANEL_WIDTH = 400;

        #endregion

        #region Constructors
        /// <summary>
        /// Creates new instance of operators' displayer
        /// </summary>
        public OperatorsCollectionScreen()
        {
            Initialize();
        }

        #endregion

        #region Properties

        #region public OperatorCollection Operators
        /// <summary>
        /// Gets or sets current collection of operators
        /// </summary>
        public OperatorCollection Operators
        {
            get { return operators; }
            set { operators = value; }
        }
        #endregion

        #endregion

        #region Methods

        #region private void Initialize()

        private void Initialize()
        {
            header = new HeaderControl();            
            operatorHeaderControl = new OperatorHeaderControl("Operators", icons.Operators);
            footer = new FooterControl();
            mainPanel = new Panel();
            flowLayoutPanelRight = new FlowLayoutPanel();
            operatorCollectionControl = new OperatorCollectionControl();
            biWeeklyReference = new BiWeeklyReportsReference();
            //usersReference = new UsersReference();
            templatesReference = new TemplatesReference("Templates");
            buttonAddOperator = new RichReferenceButton();
            operatorCollectionControl.SizeChanged += operatorCollectionControl_SizeChanged;
            //
            // header
            //
            header.ActionControl.ShowEditButton = false;
            header.Controls.Add(operatorHeaderControl);
            header.ReloadRised += header_ReloadRised;
            header.ContextActionControl.ButtonHelp.TopicID = "aircrafts_of_the_operator";
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.SizeChanged += mainPanel_SizeChanged;
            //
            // biWeeklyReference
            //
            //biWeeklyReference.ShowAllReference.Text = "Show all BiWeeklies";
            biWeeklyReference.AutoSize = true;
            biWeeklyReference.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            //biWeeklyReference.Caption = "BiWeekly Reports";
            biWeeklyReference.DescriptionTextColor = Color.DimGray;
            biWeeklyReference.Location = new Point(30, 60);
            biWeeklyReference.Margin = new Padding(30, 60, 30, 30);
            biWeeklyReference.Size = new Size(297, 101);
            biWeeklyReference.TabIndex = 7;
            biWeeklyReference.UpperLeftIcon = new Icons().GrayArrow;
            //biWeeklyReference.ShowAllReference.DisplayerRequested += new EventHandler<ReferenceEventArgs>(ShowAllReference_DisplayerRequested);
            //
            // templatesReference
            //
            templatesReference.Caption = "Templates";
            templatesReference.Margin = new Padding(30, 20, 30, 10);
            //
            // usersReference
            //
            //usersReference.Margin = new Padding(30, 0, 30, 30);
            //
            // flowLayoutPanelRight
            //
            flowLayoutPanelRight.Controls.Add(biWeeklyReference);
            flowLayoutPanelRight.Controls.Add(templatesReference);
            //flowLayoutPanelRight.Controls.Add(usersReference);
            flowLayoutPanelRight.Dock = DockStyle.Right;
            flowLayoutPanelRight.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelRight.Location = new Point(612, 0);
            flowLayoutPanelRight.Size = new Size(RIGHT_PANEL_WIDTH, 100);
            //
            // buttonAddOperator
            //
            buttonAddOperator.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonAddOperator.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddOperator.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddOperator.Icon = icons.Add;
            buttonAddOperator.IconNotEnabled = icons.AddGray;
            buttonAddOperator.Width = 200;
            buttonAddOperator.Location = new Point(operatorCollectionControl.Left, operatorCollectionControl.Bottom);
            buttonAddOperator.TextMain = "Add Operator";
            buttonAddOperator.DisplayerRequested += buttonAddOperator_DisplayerRequested;
            if (Users.CurrentUser.Role != UserRole.Administrator) buttonAddOperator.Visible = false;
            //
            // OperatorsCollectionScreen
            //
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(mainPanel);
            Controls.Add(footer);
            Controls.Add(header);
            mainPanel.Controls.Add(operatorCollectionControl);
            mainPanel.Controls.Add(buttonAddOperator);
            mainPanel.Controls.Add(flowLayoutPanelRight);
            buttonAddOperator.Enabled = (OperatorCollection.Instance.HasPermission(Users.CurrentUser, DataEvent.Update));
            UpdateInformation();
        }

        #endregion

        #region private void mainPanel_SizeChanged(object sender, EventArgs e)

        private void mainPanel_SizeChanged(object sender, EventArgs e)
        {
            operatorCollectionControl.SetWidthLimitation(Width - flowLayoutPanelRight.Width, Height - header.Height - footer.Height);
        }

        #endregion

        #region private void header_ReloadRised(object sender, EventArgs e)

        private void header_ReloadRised(object sender, EventArgs e)
        {
            UpdateInformation();
        }

        #endregion

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            operatorCollectionControl.UpdateOperators();
        }
        
        #endregion

        #region private void buttonAddOperator_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonAddOperator_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = "New Operator. Summary";
            e.RequestedEntity = new DispatcheredOperatorScreen();
        }

        #endregion

        #region private void operatorCollectionControl_SizeChanged(object sender, EventArgs e)

        private void operatorCollectionControl_SizeChanged(object sender, EventArgs e)
        {
            buttonAddOperator.Location = new Point(operatorCollectionControl.Left, operatorCollectionControl.Bottom);
        }

        #endregion

        #region protected void SetEnbaledToControls(bool isEnabled)

        protected void SetEnbaledToControls(bool isEnabled)
        {
            operatorCollectionControl.SetEnabaledToOperatorButtons(isEnabled);
            header.ActionControl.ButtonReload.Enabled = isEnabled;
            biWeeklyReference.Enabled = isEnabled;
            templatesReference.Enabled = isEnabled;
            //usersReference.Enabled = isEnabled;
            buttonAddOperator.Enabled = isEnabled;
            header.ContextActionControl.ButtonClose.Enabled = isEnabled;
        }

        #endregion

        #endregion

    }
}