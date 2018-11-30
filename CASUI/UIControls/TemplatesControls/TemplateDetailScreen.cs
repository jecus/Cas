using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.UI.Management;
using CASTerms;
using Controls.AvButtonT;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.DetailsControls;
using CAS.UI.UIControls.ReferenceControls;
using CAS.UI.UIControls.TemplatesControls.Forms;

namespace CAS.UI.UIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения отдельного агрегата
    /// </summary>
    [ToolboxItem(false)]
    public class TemplateDetailScreen : UserControl
    {

        #region Fields

        private TemplateAbstractDetail currentDetail;

        private readonly TemplateAircraftHeaderControl aircraftHeader;
        private readonly HeaderControl headerControl;
        private readonly FooterControl footerControl;
        /// <summary>
        /// </summary>
        protected readonly TemplateDetailGeneralInformationControl generalInformationControl;
        /// <summary>
        /// </summary>
        protected readonly TemplateDatailLimitationsMaxResourcesControl limitationControl;
        /// <summary>
        /// </summary>
        protected readonly TemplateDetailParametersControl parametersControl;
        private readonly ExtendableRichContainer generalInformationContainer;
        private readonly ExtendableRichContainer limitationsContainer;
        private readonly ExtendableRichContainer parametersContainer;
        private readonly Panel mainPanel = new Panel();
        private readonly Panel panelHeader = new Panel();
        private readonly RichReferenceButton buttonDeleteDetail;
        private readonly AvButtonT buttonAddTemplate;

        private readonly Icons icons = new Icons();

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения отдельного агрегата
        /// </summary>
        /// <param name="detail"></param>
        public TemplateDetailScreen(TemplateAbstractDetail detail)
        {
            if (detail == null)
                throw new ArgumentNullException("detail", "Argument cannot be null");

            currentDetail = detail;

            BackColor = Css.CommonAppearance.Colors.BackColor;
            Dock = DockStyle.Fill;
            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            if (currentDetail is TemplateDetail)
                aircraftHeader = new TemplateAircraftHeaderControl(currentDetail.Parent.Parent as TemplateAircraft, true);
            else
                aircraftHeader = new TemplateAircraftHeaderControl(((TemplateBaseDetail)currentDetail).ParentAircraft, true);
            generalInformationControl = new TemplateDetailGeneralInformationControl(currentDetail);
            limitationControl = new TemplateDatailLimitationsMaxResourcesControl(currentDetail);
            parametersControl = new TemplateDetailParametersControl(currentDetail);
            generalInformationContainer = new ExtendableRichContainer();
            limitationsContainer = new ExtendableRichContainer();
            parametersContainer = new ExtendableRichContainer();
            buttonDeleteDetail = new RichReferenceButton();
            buttonAddTemplate = new AvButtonT();
            //
            // aircraftHeader
            //
            aircraftHeader.AircraftClickable = true;
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
            // generalInformationContainer
            //
            generalInformationContainer.Dock = DockStyle.Top;
            generalInformationContainer.UpperLeftIcon = icons.GrayArrow;
            generalInformationContainer.Caption = "Component General Information";
            generalInformationContainer.MainControl = generalInformationControl;
            generalInformationContainer.TabIndex = 1;
            //
            // limitationsContainer
            //
            limitationsContainer.Dock = DockStyle.Top;
            limitationsContainer.UpperLeftIcon = icons.GrayArrow;
            limitationsContainer.Caption = "Limitations. Max resources";
            limitationsContainer.MainControl = limitationControl;
            limitationsContainer.TabIndex = 2;
            //
            // parametersContainer
            //
            parametersContainer.Dock = DockStyle.Top;
            parametersContainer.UpperLeftIcon = icons.GrayArrow;
            parametersContainer.Caption = "Parameters";
            parametersContainer.MainControl = parametersControl;
            parametersContainer.TabIndex = 3;
            //
            // panelHeader
            //
            panelHeader.AutoSize = true;
            panelHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelHeader.Dock = DockStyle.Top;
            panelHeader.TabIndex = 0;
            panelHeader.Controls.Add(buttonDeleteDetail);
            // 
            // buttonDeleteDetail
            // 
            buttonDeleteDetail.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            buttonDeleteDetail.BackColor = Color.Transparent;
            buttonDeleteDetail.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteDetail.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteDetail.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteDetail.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteDetail.Location = new Point(panelHeader.Right - 160, 0);
            buttonDeleteDetail.Icon = icons.Delete;
            buttonDeleteDetail.IconNotEnabled = icons.DeleteGray;
            buttonDeleteDetail.IconLayout = ImageLayout.Center;
            buttonDeleteDetail.Name = "buttonDeleteDetail";
            buttonDeleteDetail.NormalBackgroundImage = null;
            buttonDeleteDetail.PaddingMain = new Padding(3, 0, 0, 0);
            buttonDeleteDetail.ReflectionType = ReflectionTypes.CloseSelected;
            buttonDeleteDetail.Size = new Size(160, 50);
            buttonDeleteDetail.TabIndex = 16;
            buttonDeleteDetail.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonDeleteDetail.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonDeleteDetail.TextMain = "Delete";
            buttonDeleteDetail.TextSecondary = "component";
            buttonDeleteDetail.DisplayerRequested += avButtonDeleteDetail_DisplayerRequested;
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
            buttonAddTemplate.TabIndex = 4;
            buttonAddTemplate.Visible = false;
            //
            // mainPanel
            //
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.AutoScroll = true;
            mainPanel.TabIndex = 1;
            mainPanel.Controls.Add(buttonAddTemplate);
            if ((currentDetail is TemplateDetail) || (currentDetail is TemplateEngine))
                mainPanel.Controls.Add(parametersContainer);
            mainPanel.Controls.Add(limitationsContainer);
            mainPanel.Controls.Add(generalInformationContainer);
            mainPanel.Controls.Add(panelHeader);


            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);
            UpdateDetail(false);
        }

        #endregion

        #region Properties

        #region public TemplateAbstractDetail Detail

        /// <summary>
        /// Возвращает или устанавливает шаблонный агрегат, с которым работает данный элемент управления
        /// </summary>
        public TemplateAbstractDetail Detail
        {
            get
            {
                return currentDetail;
            }
            set
            {
                currentDetail = value;
                generalInformationControl.UpdateInformation();
                limitationControl.UpdateInformation();
                parametersControl.UpdateInformation();
                UpdateDetail();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region protected void ButtonSave_DisplayerRequested(object sender, ReferenceEventArgs e)

        /// <summary>
        /// Метод обработки события нажатия кнопки Save
        /// </summary>
        protected void ButtonSave_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            Save();
            e.Cancel = true;
        }

        #endregion

        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            if (generalInformationControl.GetChangeStatus() || limitationControl.GetChangeStatus() || parametersControl.GetChangeStatus())
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new TermsProvider()["SystemName"], MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    UpdateDetail();
                }
            }
            else
            {
                UpdateDetail();
            }
        }

        #endregion

        #region protected bool Save()

        /// <summary>
        /// Сохраняет данные текущего шаблонного агрегата
        /// </summary>
        protected bool Save()
        {
            int amount;
            if (!generalInformationControl.CheckAmount(out amount))
                return false;
            if (generalInformationControl.GetChangeStatus() || limitationControl.GetChangeStatus() || parametersControl.GetChangeStatus())
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
            generalInformationControl.SaveData();
            limitationControl.SaveData();
            parametersControl.SaveData();

            try
            {
                currentDetail.Save(true);
                    UpdateDetail(false);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
            }
        }

        #endregion

        #region private void UpdateDetail()

        private void UpdateDetail()
        {
            UpdateDetail(true);
        }

        #endregion

        #region private void UpdateDetail(bool reloadDetail)

        private void UpdateDetail(bool reloadDetail)
        {

            try
            {
                if (reloadDetail)
                        currentDetail.Reload(true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }

            bool permission = currentDetail.HasPermission(Users.CurrentUser, DataEvent.Update);
            buttonDeleteDetail.Enabled = currentDetail.HasPermission(Users.CurrentUser, DataEvent.Remove);

            headerControl.ActionControl.ShowEditButton = permission;

            generalInformationControl.UpdateInformation();
            limitationControl.UpdateInformation();
            parametersControl.UpdateInformation();
        }

        #endregion

        #region private void buttonDeleteDetail_DisplayerRequested(object sender, ReferenceEventArgs e)

        /// <summary>
        /// Удаляет текущий агрегат
        /// </summary>
        private void avButtonDeleteDetail_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete current component?",
                                                  //"Confirm deleting " + currentDetail.SerialNumber, MessageBoxButtons.YesNoCancel, //todo
                                                  "Confirm deleting " + currentDetail.PartNumber, MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (currentDetail is TemplateDetail)
                    {
                        TemplateBaseDetail containingDetail = (TemplateBaseDetail) currentDetail.Parent;
                        containingDetail.Remove(currentDetail);
                    }
                    else
                    {
                        TemplateAircraft containingAircraft = (TemplateAircraft)currentDetail.Parent;
                        containingAircraft.RemoveBaseDetail((TemplateBaseDetail)currentDetail);
                    }
                    MessageBox.Show("Component was deleted successfully", (string)new TermsProvider()["SystemName"],
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); e.Cancel = true;
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
            if (currentDetail is TemplateBaseDetail)
            {
                TemplateBaseDetailAddToDataBaseForm form = new TemplateBaseDetailAddToDataBaseForm((TemplateBaseDetail) currentDetail);
                form.ShowDialog();
            }
            else
            {
                TemplateDetailAddToDataBaseForm form = new TemplateDetailAddToDataBaseForm((TemplateDetail)currentDetail);
                form.ShowDialog();
            }
        }

        #endregion

        #endregion
    }
}