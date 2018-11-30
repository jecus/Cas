using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.UI.Management;
using Controls.AvButtonT;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.Core.Types.Directives.Templates;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.DirectivesControls;
using CAS.UI.UIControls.ReferenceControls;
using CAS.UI.UIControls.TemplatesControls.Forms;

namespace CAS.UI.UIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения информации о шаблонной директиве
    /// </summary>
    [ToolboxItem(false)]
    public class TemplateDirectiveScreen : UserControl
    {

        #region Fields

        private readonly TemplateBaseDetailDirective currentDirective;

        private readonly TemplateAircraftHeaderControl aircraftHeader;
        private readonly FooterControl footerControl;
        /// <summary>
        /// </summary>
        protected TemplateDirectiveGeneralInformationControl generalDataAndPerformanceControl;
        /// <summary>
        /// </summary>
        protected TemplateDirectiveAttributesControl attributesAndParametersControl;
        private readonly ExtendableRichContainer generalDataAndPerformanceContainer;
        private readonly ExtendableRichContainer attributesAndParametersContainer;
        private readonly HeaderControl headerControl;
        private readonly Panel mainPanel;
        private readonly Panel panelHeader;
        private readonly RichReferenceButton buttonDeleteDirective;
        private readonly AvButtonT buttonAddTemplate;

        private readonly Icons icons = new Icons();
        
        #endregion

        #region Constructor
        
        /// <summary>
        /// Создает элемент управления для отображения информации о шаблонной директиве
        /// </summary>
        public TemplateDirectiveScreen(TemplateBaseDetailDirective directive)
        {
            if (directive == null)
                throw new ArgumentNullException("directive", "Argument cannot be null");
            currentDirective = directive;

            BackColor = Css.CommonAppearance.Colors.BackColor;
            Dock = DockStyle.Fill;

            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeader = new TemplateAircraftHeaderControl(currentDirective.Parent.Parent as TemplateAircraft, true, true);

            generalDataAndPerformanceContainer = new ExtendableRichContainer();
            attributesAndParametersContainer = new ExtendableRichContainer();

            generalDataAndPerformanceControl = new TemplateDirectiveGeneralInformationControl(currentDirective);
            attributesAndParametersControl = new TemplateDirectiveAttributesControl(currentDirective);
            mainPanel = new Panel();
            panelHeader = new Panel();
            buttonDeleteDirective = new RichReferenceButton();
            buttonAddTemplate = new AvButtonT();
            //
            // headerControl
            //
            headerControl.Controls.Add(aircraftHeader);
            headerControl.ButtonEdit.TextMain = "Save";
            headerControl.ButtonEdit.Icon = icons.Save;
            headerControl.ButtonEdit.IconNotEnabled = icons.SaveGray;
            headerControl.TabIndex = 0;
            headerControl.ButtonEdit.DisplayerRequested += ButtonSave_DisplayerRequested;
            headerControl.ReloadRised += headerControl_ReloadRised;
            //
            // generalDataAndPerformanceContainer
            //
            generalDataAndPerformanceContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            generalDataAndPerformanceContainer.Dock = DockStyle.Top;
            generalDataAndPerformanceContainer.LabelCaption.Text = "General Data And Performance";
            generalDataAndPerformanceContainer.MainControl = generalDataAndPerformanceControl;
            generalDataAndPerformanceContainer.UpperLeftIcon = icons.GrayArrow;
            generalDataAndPerformanceContainer.TabIndex = 1;
            //
            // attributesAndParametersContainer
            //
            attributesAndParametersContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            attributesAndParametersContainer.Dock = DockStyle.Top;
            attributesAndParametersContainer.LabelCaption.Text = "Attributes And Additional Parameters";
            attributesAndParametersContainer.MainControl = attributesAndParametersControl;
            attributesAndParametersContainer.UpperLeftIcon = icons.GrayArrow;
            attributesAndParametersContainer.TabIndex = 2;
            // 
            // buttonDeleteDirective
            // 
            buttonDeleteDirective.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            buttonDeleteDirective.BackColor = Color.Transparent;
            buttonDeleteDirective.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteDirective.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteDirective.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteDirective.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteDirective.Location = new Point(panelHeader.Right - 160, 0);
            buttonDeleteDirective.Icon = icons.Delete;
            buttonDeleteDirective.IconNotEnabled = icons.DeleteGray;
            buttonDeleteDirective.IconLayout = ImageLayout.Center;
            buttonDeleteDirective.PaddingMain = new Padding(3, 0, 0, 0);
            buttonDeleteDirective.ReflectionType = ReflectionTypes.CloseSelected;
            buttonDeleteDirective.Size = new Size(160, 50);
            buttonDeleteDirective.TabIndex = 16;
            buttonDeleteDirective.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonDeleteDirective.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonDeleteDirective.TextMain = "Delete";
            buttonDeleteDirective.TextSecondary = "directive";
            buttonDeleteDirective.DisplayerRequested += buttonDeleteDirective_DisplayerRequested;
            //
            // buttonAddTemplate
            //
            buttonAddTemplate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonAddTemplate.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddTemplate.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddTemplate.Icon = icons.Add;
            buttonAddTemplate.IconNotEnabled = icons.AddGray;
            buttonAddTemplate.Width = 160;
            buttonAddTemplate.Location = new Point(mainPanel.Right - buttonAddTemplate.Width - 10, mainPanel.Bottom - buttonAddTemplate.Height - 10);
            buttonAddTemplate.TextMain = "Add To Database";
            buttonAddTemplate.Click += buttonAddTemplate_Click;
            buttonAddTemplate.TabIndex = 3;
            buttonAddTemplate.Visible = false;
            //
            // panelHeader
            //
            panelHeader.AutoSize = true;
            panelHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Controls.Add(buttonDeleteDirective);
            panelHeader.TabIndex = 0;
            //
            // mainPanel
            //
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.TabIndex = 1;
            mainPanel.Controls.Add(buttonAddTemplate);
            mainPanel.Controls.Add(attributesAndParametersContainer);
            mainPanel.Controls.Add(generalDataAndPerformanceContainer);
            mainPanel.Controls.Add(panelHeader);
            //
            //  this 
            //
            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);


            UpdateDirective(false);
        }

        #endregion

        #region Methods

        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            //Lifelength l = currentDirective.NextPerformance;
            //l = currentDirective.SinceEffectivityDateLifelength;
            if (generalDataAndPerformanceControl.GetChangeStatus(true) || attributesAndParametersControl.GetChangeStatus(true))
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new TermsProvider()["SystemName"], MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    UpdateDirective();
                }
            }
            else
            {
                UpdateDirective();
            }
        }

        #endregion

        #region protected void ButtonSave_DisplayerRequested(object sender, ReferenceEventArgs e)

        /// <summary>
        /// Метод обработки события нажатия кнопки Save
        /// </summary>
        protected void ButtonSave_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
            Save();
        }

        #endregion

        #region protected bool Save()

        /// <summary>
        /// Сохраняет данные текущей шаблонной директивы
        /// </summary>
        protected bool Save()
        {
            double manHours;
            if (!generalDataAndPerformanceControl.CheckManHours(out manHours) || !generalDataAndPerformanceControl.CheckLifelengthes())
                return false;
            if (generalDataAndPerformanceControl.GetChangeStatus(true) || attributesAndParametersControl.GetChangeStatus(true) || currentDirective.Modified)
            {
                SaveData();
            }
            return true;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранение измененных данных в редактируемом элементе
        /// </summary>
        public void SaveData()
        {
            generalDataAndPerformanceControl.SaveData();
            attributesAndParametersControl.SaveData();
            try
            {
                currentDirective.Save(true);
                bool t = currentDirective.PerformSinceEffectivityDate;
                UpdateDirective();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
            }

        }

        #endregion

        #region public void UpdateDirective()

        /// <summary>
        /// Обновляется отображаемая информация
        /// </summary>
        public void UpdateDirective()
        {
            UpdateDirective(true);
        }

        #endregion

        #region public void UpdateDirective(bool reloadDirective)

        /// <summary>
        /// Обновляется отображаемая информация
        /// </summary>
        public void UpdateDirective(bool reloadDirective)
        {
            try
            {
                if (reloadDirective)
                        currentDirective.Reload();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }


            bool permission = currentDirective.HasPermission(Users.CurrentUser, DataEvent.Update);
            buttonDeleteDirective.Enabled = currentDirective.HasPermission(Users.CurrentUser, DataEvent.Remove);

            headerControl.ActionControl.ShowEditButton = permission;

            generalDataAndPerformanceControl.UpdateInformation();
            attributesAndParametersControl.UpdateInformation();

        }

        #endregion

        #region private void buttonDeleteDirective_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonDeleteDirective_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete current directive?",
                                                  "Confirm deleting", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {

                try
                {
                    TemplateBaseDetail containingDetail = (TemplateBaseDetail)currentDirective.Parent; 
                    containingDetail.Remove(currentDirective);
                    MessageBox.Show("Directive was deleted successfully", "Directive deleted",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); 
                    e.Cancel = true;
                }

            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region private void buttonAddTemplate_Click(object sender, EventArgs e)

        private void buttonAddTemplate_Click(object sender, EventArgs e)
        {
            TemplateDetailAddToDataBaseForm form = new TemplateDetailAddToDataBaseForm(currentDirective);
            form.ShowDialog();
        }

        #endregion


        #endregion

    }
}