using System;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Management;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.UIControls.DetailsControls
{
    /// <summary>
    /// Элемент управления для добавления агрегата
    /// </summary>
    public class DetailAddingScreen : UserControl
    {

        #region Fields

        /// <summary>
        /// Базовый агрегат дял которого будет происходить добавление агрегата
        /// </summary>
        protected BaseDetail parentBaseDetail;
        protected Detail addedDetail;
        private readonly HeaderControl headerControl;
        private readonly AircraftHeaderControl aircraftHeader;
        private readonly FooterControl footerControl;
        private readonly Panel mainPanel;
        //private readonly Panel panelFooterMenu;
        protected readonly DetailAddingGeneralInformationControl generalInformationControl;
        protected readonly DetailCompliancePerformanceListControl compliancePerformanceListControl;
        protected readonly DetailWarrantyControl warrantyControl;
        protected readonly DetailStoreControl storeControl;
        private readonly AddNewComponentControl addnewcomponentControl;
        private readonly ExtendableRichContainer addNewComponentContainer;
        private readonly ExtendableRichContainer generalInformationContainer;
        private readonly ExtendableRichContainer compliancePerformanceContainer;
        private readonly ExtendableRichContainer warrantyContainer;
        private readonly ExtendableRichContainer storeContainer;
        private readonly Icons icons = new Icons();
        protected readonly bool isStore;

        #endregion

        #region Constructor

        ///<summary>
        /// Создается элемент отображения добавления агрегата
        ///</summary>
        /// <param name="parentDetail">Базовый агрегат для которго добавляется агрегат</param>
        public DetailAddingScreen(IDetailContainer parentDetail)
        {
            if (parentDetail == null) 
                throw new ArgumentNullException("parentDetail");
            if (parentDetail is BaseDetail)
                parentBaseDetail = (BaseDetail)parentDetail;
            else if (parentDetail is Aircraft)
                parentBaseDetail = ((Aircraft) parentDetail).AircraftFrame;
            else
                parentBaseDetail = ((Store)parentDetail).AircraftFrame;
            if (parentDetail is Aircraft)
                isStore = ((Aircraft)parentDetail).Type == AircraftType.Store;

            headerControl = new HeaderControl();
            aircraftHeader = new AircraftHeaderControl();
            if (parentDetail is Aircraft)
                aircraftHeader.Aircraft = parentDetail as Aircraft;
            if (parentDetail is BaseDetail)
                aircraftHeader.Aircraft = (parentDetail as BaseDetail).ParentAircraft;
            aircraftHeader.AircraftClickable = true;
            aircraftHeader.OperatorClickable = true;
            footerControl = new FooterControl();
            mainPanel = new Panel();
//            panelFooterMenu = new Panel();
                        
            addnewcomponentControl = new AddNewComponentControl(parentBaseDetail);
            generalInformationControl = new DetailAddingGeneralInformationControl(parentBaseDetail.ParentAircraft);
            compliancePerformanceListControl = new DetailCompliancePerformanceListControl(parentBaseDetail.ParentAircraft);
            warrantyControl = new DetailWarrantyControl();
            if (isStore)
                storeControl = new DetailStoreControl((Aircraft)parentDetail);

            addNewComponentContainer = new ExtendableRichContainer();
            generalInformationContainer = new ExtendableRichContainer();
            compliancePerformanceContainer = new ExtendableRichContainer();
            warrantyContainer = new ExtendableRichContainer();
            storeContainer = new ExtendableRichContainer();
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

            aircraftHeader.AircraftClickable = true;
            footerControl.TabIndex = 2;
            //
            // mainPanel
            //
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.AutoScroll = true;
            mainPanel.TabIndex = 1;
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
            addnewcomponentControl.BaseDetailAddTo = parentBaseDetail;
            //
            // generalInformationContainer
            //
            generalInformationContainer.Dock = DockStyle.Top;
            generalInformationContainer.UpperLeftIcon = icons.GrayArrow;
            generalInformationContainer.Caption = "Component general information";
            generalInformationContainer.MainControl = generalInformationControl;
            generalInformationContainer.TabIndex = 1;
            //
            // compliancePerformanceContainer
            //
            compliancePerformanceContainer.Dock = DockStyle.Top;
            compliancePerformanceContainer.UpperLeftIcon = icons.GrayArrow;
            compliancePerformanceContainer.Caption = "Compliance/Performance";
            compliancePerformanceContainer.MainControl = compliancePerformanceListControl;
            //compliancePerformanceContainer.Extended = false;
            compliancePerformanceContainer.TabIndex = 2;
            //
            // warrantyContainer
            //
            warrantyContainer.Dock = DockStyle.Top;
            warrantyContainer.UpperLeftIcon = icons.GrayArrow;
            warrantyContainer.Caption = "Warranty";
            warrantyContainer.MainControl = warrantyControl;
            warrantyContainer.TabIndex = 3;
            //
            // storeContainer
            //
            storeContainer.Dock = DockStyle.Top;
            storeContainer.UpperLeftIcon = icons.GrayArrow;
            storeContainer.Caption = "Store";
            storeContainer.MainControl = storeControl;
            //storeContainer.Extended = false;
            storeContainer.TabIndex = 5;
/*            //
            // panelFooterMenu
            // 
            panelFooterMenu.AutoSize = true;
            panelFooterMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelFooterMenu.Dock = DockStyle.Bottom;*/

            BackColor = Css.CommonAppearance.Colors.BackColor;
            //mainPanel.Controls.Add(panelFooterMenu);
            if (isStore)
                mainPanel.Controls.Add(storeContainer);
            mainPanel.Controls.Add(warrantyContainer);
            if (!isStore)
                mainPanel.Controls.Add(compliancePerformanceContainer);
            mainPanel.Controls.Add(generalInformationContainer);
            if (!isStore)
                mainPanel.Controls.Add(addNewComponentContainer);
            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);
            
            ClearFields();
            addNewComponentContainer.Focus();
        }

        #endregion

        #region Methods
                
        #region private void buttonSaveAndEdit_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonSaveAndEdit_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (AddNewDetail(true))
            {
                e.RequestedEntity = new DispatcheredDetailScreen(addedDetail);
                if (addedDetail.Parent.Parent is Aircraft)
                    e.DisplayerText = ((Aircraft) addedDetail.Parent.Parent).RegistrationNumber + ". Component SN " + addedDetail.SerialNumber;
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
                GetMessage(ref message, "Part Number");
            }
            if (generalInformationControl.SerialNumber == "")
            {
                GetMessage(ref message, "Serial Number");
            }
            if (generalInformationControl.ATAChapter == null)
            {
                GetMessage(ref message, "ATA Chapter");    
            }
            if (message != "")
            {
                MessageBox.Show(message, new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            generalInformationControl.SaveData(addedDetail);
            warrantyControl.SaveData(addedDetail);
            if (isStore)
            {
                storeControl.SaveData(addedDetail);
                if (generalInformationControl.ComponentTSNCSN != Lifelength.NullLifelength)
                {
                    ActualStateRecord record = new ActualStateRecord();
                    record.RecordDate = generalInformationControl.DateAsOf;
                    record.Lifelength = generalInformationControl.ComponentTSNCSN;
                    addedDetail.AddRecord(record);
                }
            }
            else
            {
                parentBaseDetail = addnewcomponentControl.BaseDetailAddTo;
                parentBaseDetail.Add(addedDetail, "", generalInformationControl.InstallationDate);//todo
                if (generalInformationControl.ComponentTSNCSN != Lifelength.NullLifelength)
                {
                    ActualStateRecord record = new ActualStateRecord();
                    record.RecordDate = generalInformationControl.InstallationDate;
                    record.Lifelength = generalInformationControl.ComponentTSNCSN;
                    addedDetail.AddRecord(record);
                }
                if (generalInformationControl.SetActualDataToAircraft)
                {
                    ActualStateRecord record = new ActualStateRecord();
                    record.RecordDate = generalInformationControl.InstallationDate;
                    record.Lifelength = generalInformationControl.AircraftTSNCSN;
                    parentBaseDetail.ParentAircraft.AddRecord(record);
                }
                if (generalInformationControl.SetCurrentComponentTSNCSN)
                {
                    ActualStateRecord record = new ActualStateRecord();
                    record.RecordDate = generalInformationControl.DateAsOf;
                    record.Lifelength = generalInformationControl.AircraftTSNCSN + (generalInformationControl.ComponentCurrentTSNCSN - generalInformationControl.ComponentTSNCSN);
                    parentBaseDetail.ParentAircraft.AddRecord(record);
                }
                compliancePerformanceListControl.SaveData(addedDetail);
                if (addedDetail.GetDetailDirectives().Length > 0 || addedDetail.LifeLimit != Lifelength.NullLifelength)
                    addedDetail.MaintenanceType = MaintenanceTypeCollection.Instance.HardTimeType;
                else
                    addedDetail.MaintenanceType = MaintenanceTypeCollection.Instance.OnConditionType;
                addedDetail.Save();

            }
            return true;
        }

        #endregion

        #region private static void GetMessage(ref string message, string field)
        /// <summary>
        /// Метод, предназначенный для формирования сообщения для MessageBox
        /// </summary>
        private static void GetMessage(ref string message, string field)
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
            generalInformationControl.ClearFields();
            compliancePerformanceListControl.ClearFields();
            warrantyControl.ClearFields();
            if (isStore)
            {
                storeControl.ClearFields();
                storeControl.CurrentStore = parentBaseDetail.ParentAircraft;
            }
            addedDetail = new DetailReal(new Lifelength(new TimeSpan(0), 0, new TimeSpan(0)));
            addedDetail.AtaChapter = null;
            addedDetail.MaintenanceType = MaintenanceTypeCollection.Instance.HardTimeType;//todo!
            addedDetail.Lifelength = Lifelength.NullLifelength;
            warrantyControl.DateTimePickerExpires.Value = addedDetail.ManufactureDate.AddDays(addedDetail.Warranty.Calendar.TotalDays);
        }

        #endregion
        
        #endregion
    }
}