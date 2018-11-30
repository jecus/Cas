using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.EngineeringOrdersDirectives;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.OpepatorsControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.UIControls.EngineeringOrdersDirectives
{
    /// <summary>
    /// Элемент упраления для добавления новой директивы <see cref="EngineeringOrderDirective"/>
    /// </summary>
    public class EngineeringOrderDirectiveAddingScreen : Control
    {

        #region Fields

        private readonly BaseDetail parentBaseDetail;
        private EngineeringOrderDirective addedDirective;

        private readonly AircraftHeaderControl aircraftHeader;
        private readonly ExtendableRichContainer generalInforationContainer;
        private readonly ExtendableRichContainer complianceDataContainer;
        private readonly ExtendableRichContainer complianceTermsContainer;
        private readonly ExtendableRichContainer incorporationPlaceContainer;
        
        private readonly EngineeringOrderDirectiveGeneralInformationControl generalInformationControl;
        private readonly EngineeringOrderDirectiveComplianceDataControl complianceDataControl;
        private readonly EngineeringOrderDirectiveComplianceTermsControl complianceTermsControl;
        private readonly EngineeringOrderDirectiveIncorporationPlaceControl incorporationPlaceControl;

        private readonly HeaderControl headerControl;
        private readonly FooterControl footerControl;
        private readonly Panel mainPanel = new Panel();
        private readonly FlowLayoutPanel containedPanel = new FlowLayoutPanel();
        private readonly Panel panelHeader = new Panel();
        private readonly Icons icons = new Icons();
        
        #endregion

        #region Constructor

        public EngineeringOrderDirectiveAddingScreen(BaseDetail parentBaseDetail)
        {
            this.parentBaseDetail = parentBaseDetail;

            headerControl = new HeaderControl();
            footerControl = new FooterControl();
            aircraftHeader = new AircraftHeaderControl(parentBaseDetail.ParentAircraft, true, true);
            generalInforationContainer = new ExtendableRichContainer();
            complianceDataContainer = new ExtendableRichContainer();
            complianceTermsContainer = new ExtendableRichContainer();
            incorporationPlaceContainer = new ExtendableRichContainer();
            
            generalInformationControl = new EngineeringOrderDirectiveGeneralInformationControl();
            complianceDataControl = new EngineeringOrderDirectiveComplianceDataControl();
            complianceTermsControl = new EngineeringOrderDirectiveComplianceTermsControl();
            incorporationPlaceControl = new EngineeringOrderDirectiveIncorporationPlaceControl();
            // 
            // aircraftHeader
            // 
            aircraftHeader.OperatorClickable = true;
            aircraftHeader.AircraftClickable = true;
            //
            // headerControl
            //
            headerControl.Controls.Add(aircraftHeader);
            headerControl.ButtonReload.Icon = icons.SaveAndAdd;
            headerControl.ButtonReload.IconNotEnabled = icons.SaveAndAddGray;
            headerControl.ButtonReload.IconLayout = ImageLayout.Center;
            headerControl.ButtonReload.TextMain = "Save and";
            headerControl.ButtonReload.TextSecondary = "add another";
            headerControl.ButtonReload.Click += buttonSaveAndAdd_Click;

            headerControl.ButtonEdit.Icon = icons.Save;
            headerControl.ButtonEdit.IconNotEnabled = icons.SaveGray;
            headerControl.ButtonEdit.IconLayout = ImageLayout.Center;
            headerControl.ButtonEdit.ReflectionType = ReflectionTypes.DisplayInCurrent;
            headerControl.ButtonEdit.TextMain = "Save";
            headerControl.ButtonEdit.TextSecondary = "and Edit";
            headerControl.ButtonEdit.DisplayerRequested += buttonSaveAndEdit_DisplayerRequested;
            headerControl.TabIndex = 0;
            //
            // footerControl
            //
            footerControl.TabIndex = 2;
            //
            // mainPanel
            //
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.TabIndex = 1;
            mainPanel.Controls.Add(containedPanel);
            //
            // containedPanel
            //
            containedPanel.AutoSize = true;
            containedPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            containedPanel.FlowDirection = FlowDirection.TopDown;
            containedPanel.TabIndex = 1;
            //
            // panelHeader
            //
            panelHeader.Size = new Size(1250, 50);
            panelHeader.TabIndex = 0;
            //
            // generalInforationContainer
            //
            generalInforationContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            generalInforationContainer.LabelCaption.Text = "General Information";
            generalInforationContainer.MainControl = generalInformationControl;
            generalInforationContainer.UpperLeftIcon = icons.GrayArrow;
            generalInforationContainer.TabIndex = 0;
            //
            // complianceDataContainer
            //
            complianceDataContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            complianceDataContainer.LabelCaption.Text = "Compliance Data";
            complianceDataContainer.MainControl = complianceDataControl;
            complianceDataContainer.UpperLeftIcon = icons.GrayArrow;
            complianceDataContainer.TabIndex = 1;
            //
            // complianceTermsContainer
            //
            complianceTermsContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            complianceTermsContainer.LabelCaption.Text = "Compliance Terms";
            complianceTermsContainer.MainControl = complianceTermsControl;
            complianceTermsContainer.UpperLeftIcon = icons.GrayArrow;
            complianceTermsContainer.TabIndex = 2;
            //
            // incorporationPlaceContainer
            //
            incorporationPlaceContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            incorporationPlaceContainer.LabelCaption.Text = "Incorporation Place";
            incorporationPlaceContainer.MainControl = incorporationPlaceControl;
            incorporationPlaceContainer.UpperLeftIcon = icons.GrayArrow;
            incorporationPlaceContainer.TabIndex = 3;

            containedPanel.Controls.Add(panelHeader);
            containedPanel.Controls.Add(generalInforationContainer);
            containedPanel.Controls.Add(complianceDataContainer);
            containedPanel.Controls.Add(complianceTermsContainer);
            containedPanel.Controls.Add(incorporationPlaceContainer);

            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);

            ClearFields();
        }

        #endregion

        #region Methods

        #region protected bool GetChangeStatus(bool directiveExist)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        protected bool GetChangeStatus()
        {
            return (generalInformationControl.GetChangeStatus(false) ||
                    complianceDataControl.GetChangeStatus(false) ||
                    complianceTermsControl.GetChangeStatus(false) ||
                    incorporationPlaceControl.GetChangeStatus(false));
        }

        #endregion

        #region private void buttonSaveAndAdd_Click(object sender, EventArgs e)

        private void buttonSaveAndAdd_Click(object sender, EventArgs e)
        {
            if (AddNewDirective(false))
            {
                MessageBox.Show("Directive added successfully", new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                generalInformationControl.ComboBoxATAChapter.Focus();
            }
        }

        #endregion

        #region private void buttonSaveAndEdit_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonSaveAndEdit_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (AddNewDirective(true))
            {
                e.RequestedEntity = new DispatcheredEngineeringOrderDirectiveScreen(addedDirective);//, parentBaseDetail);
                string title = addedDirective.Parent.Parent.ToString();
                if (!(addedDirective.Parent is AircraftFrame))
                    title += ". " + addedDirective.Parent;
                e.DisplayerText = title + ". " + addedDirective.DirectiveType.CommonName + ". " + addedDirective.Title;
            }
            else
                e.Cancel = true;
        }

        #endregion

        #region protected bool AddNewDirective(bool changePageName)

        protected bool AddNewDirective(bool changePageName)
        {
            if (generalInformationControl.ATAChapter == null)
            {
                MessageBox.Show("Please select ATA chapter", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                generalInformationControl.SaveData(addedDirective, changePageName);
                complianceDataControl.SaveData(addedDirective);
                complianceTermsControl.SaveData(addedDirective);
                incorporationPlaceControl.SaveData(addedDirective);
                parentBaseDetail.Add(addedDirective);
                
                return true;
            }
        }

        #endregion

        #region private void ClearFields()

        private void ClearFields()
        {
            addedDirective = new EngineeringOrderDirectiveReal(parentBaseDetail);
            //addedDirective.SetDirectiveType(addedDirective.DirectiveType); //todo! разобраться
            generalInformationControl.ClearFields();
            complianceDataControl.ClearFields();
            complianceTermsControl.ClearFields();
            incorporationPlaceControl.ClearFields();
        }

        #endregion

        #endregion

    }
}
