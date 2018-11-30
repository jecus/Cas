using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Management;
using CAS.Core;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.DetailsControls;
using CAS.UI.UIControls.ReferenceControls;
using CAS.UI.UIControls.TemplatesControls;

namespace CAS.UI.UIControls.TemplatesControls
{
    /// <summary>
    ///  ласс, описываюший отображение добавлени€ агрегата
    /// </summary>
    [ToolboxItem(false)]
    public class TemplateDetailAdding : UserControl
    {

        #region Fields

        /// <summary>
        /// Ѕазовый агрегат д€л которого будет происходить добавление агрегата
        /// </summary>
        private ITemplateDetailContainer parentDetail;

        /// <summary>
        /// ƒобавл€емый агрегат
        /// </summary>
        protected TemplateDetail addedDetail;

        private readonly HeaderControl headerControl;
        private readonly TemplateAircraftHeaderControl aircraftHeader;
        private readonly FooterControl footerControl;
        private readonly Panel mainPanel;
        private readonly Panel panelFooterMenu;
        protected readonly TemplateDetailGeneralInformationControl generalInformationControl;
        protected readonly TemplateDatailLimitationsMaxResourcesControl limitationControl;
        protected readonly TemplateDetailParametersControl parametersControl;
        private readonly TemplateAddNewComponentControl addnewcomponentControl;
        private readonly ExtendableRichContainer addNewComponentContainer;
        private readonly ExtendableRichContainer generalInformationContainer;
        private readonly ExtendableRichContainer limitationsContainer;
        private readonly ExtendableRichContainer parametersContainer;
        private readonly Icons icons = new Icons();

        #endregion

        #region Constructors

        #region public TemplateDetailAdding()

        ///<summary>
        /// —оздаетс€ элемент отображени€ добавлени€ шаблонного агрегата
        ///</summary>
        public TemplateDetailAdding()
        {
            Dock = DockStyle.Fill;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            footerControl = new FooterControl();
            footerControl.TabIndex = 2;

            headerControl = new HeaderControl();
            aircraftHeader = new TemplateAircraftHeaderControl();
            mainPanel = new Panel();

            generalInformationControl = new TemplateDetailGeneralInformationControl();
            limitationControl = new TemplateDatailLimitationsMaxResourcesControl();
            parametersControl = new TemplateDetailParametersControl();
            parametersControl.ShowHushKit = false;

            generalInformationContainer = new ExtendableRichContainer();
            limitationsContainer = new ExtendableRichContainer();
            
            panelFooterMenu = new Panel();

            aircraftHeader.AircraftClickable = true;
            //
            // headerControl
            //
            headerControl.Controls.Add(aircraftHeader);
            headerControl.TabIndex = 0;
            

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

            //
            // mainPanel
            //
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.AutoScroll = true;
            mainPanel.TabIndex = 1;
            //
            // generalInformationContainer
            //
            generalInformationContainer.Dock = DockStyle.Top;
            generalInformationContainer.UpperLeftIcon = icons.GrayArrow;
            generalInformationContainer.Caption = "Component general information";
            generalInformationContainer.MainControl = generalInformationControl;
            //
            // limitationsContainer
            //
            limitationsContainer.Dock = DockStyle.Top;
            limitationsContainer.UpperLeftIcon = icons.GrayArrow;
            limitationsContainer.Caption = "Limitations. Max resources";
            limitationsContainer.MainControl = limitationControl;
            limitationsContainer.Extended = false;
           
            panelFooterMenu.AutoSize = true;
            panelFooterMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelFooterMenu.Dock = DockStyle.Bottom;

            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);
        }

      
        #endregion

        #region public TemplateDetailAdding(ITemplateDetailContainer parentBaseDetail):this()

        ///<summary>
        /// —оздаетс€ элемент отображени€ добавлени€ шаблонного агрегата
        ///</summary>
        /// <param name="parentDetail">Ѕазовый агрегат дл€ которго добавл€етс€ шаблонный агрегат</param>
        public TemplateDetailAdding(ITemplateDetailContainer parentDetail) : this()
        {
            if (parentDetail == null) 
                throw new ArgumentNullException("parentDetail");
            this.parentDetail = parentDetail;
            if (parentDetail is TemplateAircraft)
                aircraftHeader.Aircraft = parentDetail as TemplateAircraft;
            if (parentDetail is TemplateBaseDetail)
                aircraftHeader.Aircraft = (parentDetail as TemplateBaseDetail).ParentAircraft;
            aircraftHeader.AircraftClickable = true;
            aircraftHeader.OperatorClickable = true;

            addNewComponentContainer = new ExtendableRichContainer();
            addnewcomponentControl = new TemplateAddNewComponentControl(parentDetail);
            //
            // addNewComponentContainer
            //
            addNewComponentContainer.labelCaption.Margin = new Padding(3, 20, 3, 3);
            addNewComponentContainer.PictureBoxIcon.Margin = new Padding(3, 20, 3, 3);
            addNewComponentContainer.Dock = DockStyle.Top;
            addNewComponentContainer.UpperLeftIcon = icons.GrayArrow;
            addNewComponentContainer.Caption = "Base component";
            addNewComponentContainer.MainControl = addnewcomponentControl;
            addNewComponentContainer.TabIndex = 0;
            addnewcomponentControl.BaseDetailAddTo = parentDetail;
            //
            // generalInformationContainer
            //
            generalInformationContainer.TabIndex = 1;
            //
            // limitationsContainer
            //
            limitationsContainer.TabIndex = 2;
            //
            // parametersContainer
            //
            parametersContainer = new ExtendableRichContainer();
            parametersContainer.Dock = DockStyle.Top;
            parametersContainer.UpperLeftIcon = icons.GrayArrow;
            parametersContainer.Caption = "Parameters";
            parametersContainer.MainControl = parametersControl;
            parametersContainer.Extended = false;
            parametersContainer.TabIndex = 3;


            mainPanel.Controls.Add(panelFooterMenu);
            mainPanel.Controls.Add(parametersContainer);
            mainPanel.Controls.Add(limitationsContainer);
            mainPanel.Controls.Add(generalInformationContainer);
            mainPanel.Controls.Add(addNewComponentContainer);

            ClearFields();

            addNewComponentContainer.Focus();
        }

        #endregion

        #endregion

        #region Properties

        #region public object ContainedData

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return parentDetail; }
            set
            {
                if (value is TemplateBaseDetail)
                    parentDetail = (TemplateBaseDetail)value;
            }
        }

        #endregion

        #endregion
        
        #region Methods

        #region public bool ContainedDataEquals(IDisplayingEntity obj)
        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredDetailAddingScreen))
                return false;
            if (!(obj.ContainedData is BaseDetail))
                return false;
            if (!(parentDetail is CoreType)) return false;
            return ((CoreType) parentDetail).ID == ((BaseDetail) obj.ContainedData).ID;
        }
        #endregion
        
        #region private void buttonSaveAndEdit_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonSaveAndEdit_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (AddNewDetail(true))
            {
                e.RequestedEntity = new DispatcheredTemplateDetailScreen(addedDetail);
                if (addedDetail.Parent.Parent is TemplateAircraft)
                    //e.DisplayerText = "Templates. " + ((TemplateAircraft)addedDetail.Parent.Parent).Model + ". Component PN " + addedDetail.PartNumber;
                    e.DisplayerText = ((TemplateAircraft)addedDetail.Parent.Parent).Model + ". Component PN " + addedDetail.PartNumber;
            }
            else
                e.Cancel = true;

        }
        #endregion

        #region private void buttonSaveAndAdd_Click(object sender, EventArgs e)
        
        private void buttonSaveAndAdd_Click(object sender, EventArgs e)
        {
            if (AddNewDetail(false))
            {
                MessageBox.Show("Component added successfully", new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
        }
                
        #endregion

        #region protected bool AddNewDetail(bool changePageName)

        protected bool AddNewDetail(bool changePageName)
        {
            string message = "";
            if (addnewcomponentControl.BaseDetailAddTo == null)
            {
                message += "Please choose base component";
            }
            if (generalInformationControl.PartNumber == "")
            {
                if (message == "")
                    message += "Please fill Part Number";
                else
                    message += " and fill Part Number";
            }
            if (generalInformationControl.ATAChapter == null)
            {
                GetMessage(ref message, "ATA Chapter");    
            }
            if (generalInformationControl.MaintenanceType == null)
            {
                GetMessage(ref message, "Maintenance Type");
            }
            if (parametersControl.LandingGearMark && parametersControl.LandingGearMarkType == LandingGearMarkType.None)
            {
                GetMessage(ref message, "Landing Gears");
            }
            if (parametersControl.AvionicsInventoryMark && parametersControl.AvionicsInventoryMarkType == AvionicsInventoryMarkType.None)
            {
                GetMessage(ref message, "Avionics Inventory");
            }
            if (message != "")
            {
                MessageBox.Show(message, new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                generalInformationControl.SaveData(addedDetail, changePageName);
                limitationControl.SaveData(addedDetail);
                parametersControl.SaveData(addedDetail);
                parentDetail = addnewcomponentControl.BaseDetailAddTo;
                parentDetail.Add(addedDetail);
                return true;
            }
        }

        #endregion

        #region private void GetMessage(ref string message, string field)
        /// <summary>
        /// ћетод, предназначенный дл€ формировани€ сообщени€ дл€ MessageBox
        /// </summary>6
        private void GetMessage(ref string message, string field)
        {
            if (message == "")
                message += "Please fill " + field;
            else if (message == "Please choose base component")
                message += " and fill " + field;
            else
                message += ", " + field;
        }

        #endregion

        #region private void ClearFields()

        private void ClearFields()
        {
            generalInformationControl.ClearAllFields();
            limitationControl.ClearAllFields();
            parametersControl.ClearAllFields();
            addedDetail = new TemplateDetail();
            addedDetail.Amount = 1;
            addedDetail.MaintenanceType = generalInformationControl.MaintenanceType;
            addedDetail.Lifelength.IsHoursApplicable = false;
            addedDetail.Lifelength.IsCyclesApplicable = false;
            addedDetail.Lifelength.IsCalendarApplicable = false;
        }

        #endregion
        
        #endregion
    }
}