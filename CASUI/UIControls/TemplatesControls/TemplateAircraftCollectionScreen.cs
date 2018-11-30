using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Management;
using Controls.AvButtonT;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ReferenceControls;
using CAS.UI.UIControls.TemplatesControls.Forms;

namespace CAS.UI.UIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения коллекции шаблонов ВС
    /// </summary>
    [ToolboxItem(false)]
    public class TemplateAircraftCollectionScreen : UserControl
    {

        #region Fields

        private readonly FlowLayoutPanel flowLayoutPanelRight;
        private readonly TemplateAircraftCollectionControl aircrafts;
        private readonly FooterControl footerControl;
        private readonly HeaderControl headerControl;
        private readonly TemplateHeaderControl operatorHeaderControl;
        private readonly AvButtonT buttonAddTemplate;
        private readonly Panel mainPanel;
        private readonly OperatorsReference operatorsReference;
        private readonly Icons icons = new Icons();
        private const int RIGHT_PANEL_WIDTH = 400;

        #endregion
        
        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения коллекций шаблонов
        /// </summary>
        public TemplateAircraftCollectionScreen()
        {
            aircrafts = new TemplateAircraftCollectionControl();
            buttonAddTemplate = new AvButtonT();
            flowLayoutPanelRight = new FlowLayoutPanel();
            operatorsReference = new OperatorsReference("Operators");
            //aircrafts.SizeChanged += aircrafts_SizeChanged;
            // 
            // mainPanel
            // 
            mainPanel = new Panel();
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            //
            // operatorHeaderControl
            //
            operatorHeaderControl = new TemplateHeaderControl("Templates", icons.Templates);
            // 
            // headerControl
            // 
            headerControl = new HeaderControl();
            headerControl.Controls.Add(operatorHeaderControl);
            headerControl.EditDisplayerText = "Edit Template";
            headerControl.EditReflectionType = ReflectionTypes.DisplayInNew;
            headerControl.EditDisplayerRequested += headerControl_EditDisplayerRequested;
            headerControl.ReloadRised += headerControl_ReloadRised;
            headerControl.ActionControl.ShowEditButton = false;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "entering_an_aircraft_to_the_cas_database";
            // 
            // footerControl
            // 
            footerControl = new FooterControl();
            footerControl.AutoSize = true;
            footerControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            footerControl.BackColor = Color.Transparent;
            footerControl.Dock = DockStyle.Bottom;
            //
            // operatorsReference
            //
            operatorsReference.Caption = "Operators";
            operatorsReference.Margin = new Padding(30, 60, 30, 30);
            // 
            // flowLayoutPanelRight
            // 
            flowLayoutPanelRight.Controls.Add(operatorsReference);
            flowLayoutPanelRight.Dock = DockStyle.Right;
            flowLayoutPanelRight.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelRight.Location = new Point(612, 0);
            flowLayoutPanelRight.Name = "flowLayoutPanelRight";
            flowLayoutPanelRight.Size = new Size(RIGHT_PANEL_WIDTH, 100);
            flowLayoutPanelRight.TabIndex = 12;
            //
            // buttonAddTemplate
            //
            buttonAddTemplate.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddTemplate.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddTemplate.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddTemplate.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddTemplate.Icon = icons.Add;
            buttonAddTemplate.IconNotEnabled = icons.AddGray;
            buttonAddTemplate.Width = 180;
            buttonAddTemplate.Location = new Point(aircrafts.Left, aircrafts.Bottom);
            buttonAddTemplate.TextMain = "Create";
            buttonAddTemplate.TextSecondary = "new template";
            buttonAddTemplate.TextAlignMain = ContentAlignment.BottomLeft;
            buttonAddTemplate.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonAddTemplate.Click += buttonAddTemplate_Click;
            //
            // aircrafts
            //
            aircrafts.Width = 800;
            // 
            // TemplateAircraftCollectionScreen
            // 
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(mainPanel);
            Controls.Add(headerControl);
            Controls.Add(footerControl);
            mainPanel.Controls.Add(aircrafts);
            mainPanel.Controls.Add(buttonAddTemplate);
            mainPanel.Controls.Add(flowLayoutPanelRight);
        }

        #endregion

        #region Methods

        #region private void headerControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)

        private void headerControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
        }

        #endregion

        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            UpdateElements();
        }

        #endregion

        #region private void UpdateElements()

        private void UpdateElements()
        {
            UpdateElements(true);
        }

        #endregion

        #region private void UpdateElements(bool reloadCollection)

        private void UpdateElements(bool reloadCollection)
        {

            try
            {
                if (reloadCollection)
                        TemplateAircraftCollection.Instance.Reload(true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }
            aircrafts.ReloadItems();
        }

        #endregion
        
        #region private void buttonAddTemplate_Click(object sender, EventArgs e)

        private void buttonAddTemplate_Click(object sender, EventArgs e)
        {
            TemplateAddAircraftForm form = new TemplateAddAircraftForm();
            form.Closed += form_Closed;
            form.ShowDialog();
        }

        #endregion

        #region private void form_Closed(object sender, EventArgs e)

        private void form_Closed(object sender, EventArgs e)
        {
            Form form = (Form) sender;
            if (form.DialogResult == DialogResult.OK)
                UpdateElements(false);
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
            //aircrafts.Height = Height - headerControl.Height - footerControl.Height - buttonAddTemplate.Height;
            buttonAddTemplate.Top = mainPanel.Bottom - footerControl.Height - buttonAddTemplate.Height - 10;
        }

        #endregion

        #region private void SetEnabled(bool isEnabled)

        protected virtual void SetEnabledToControls(bool isEnabled)
        {
            aircrafts.SetEnabledToAircraftButtons(isEnabled);
            operatorsReference.Enabled = isEnabled;
            buttonAddTemplate.Enabled = isEnabled;
            headerControl.ActionControl.ButtonReload.Enabled = isEnabled;
            headerControl.ActionControl.ButtonEdit.Enabled = isEnabled;
            headerControl.ContextActionControl.ButtonClose.Enabled = isEnabled;
            headerControl.ContextActionControl.ButtonHelp.Enabled = isEnabled;
            operatorHeaderControl.PreviousButton.Enabled = isEnabled;
            operatorHeaderControl.NextButton.Enabled = isEnabled;
        }

        #endregion

        #endregion


    }
}