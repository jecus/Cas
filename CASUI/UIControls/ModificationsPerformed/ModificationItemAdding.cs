using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.ModificationsPerformed;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.UIControls.ModificationsPerformed
{
    /// <summary>
    /// Класс, описывающий отображение добавления <see cref="ModificationItem"/>
    /// </summary>
    [ToolboxItem(false)]
    public class ModificationItemAdding : UserControl
    {

        #region Fields

        protected Aircraft parentAircraft;
        private ModificationItem addedModificationItem;

        private readonly HeaderControl headerControl;
        private readonly AircraftHeaderControl aircraftHeader;
        private readonly FooterControl footerControl;
        private readonly Panel mainPanel;

        private readonly ExtendableRichContainer modificationItemContainer;

        protected readonly ModificationItemControl modificationItemControl;
        private readonly Icons icons = new Icons();

        #endregion

        #region Constructors

        #region private ModificationItemAdding()

        ///<summary>
        /// Создается объект, описывающий отображение добавления <see cref="ModificationItem"/> 
        ///</summary>
        private ModificationItemAdding()
        {
            Dock = DockStyle.Fill;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeader = new AircraftHeaderControl();
            mainPanel = new Panel();
            
            modificationItemControl = new ModificationItemControl();
            
            modificationItemContainer = new ExtendableRichContainer();

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
            // mainPanel
            //
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.AutoScroll = true;
            mainPanel.TabIndex = 1;
            //
            // footerControl
            //
            footerControl.TabIndex = 2;
            //
            // modificationItemContainer
            //
            modificationItemContainer.Dock = DockStyle.Top;
            modificationItemContainer.UpperLeftIcon = icons.GrayArrow;
            modificationItemContainer.Caption = "Modification Item";
            modificationItemContainer.MainControl = modificationItemControl;
            modificationItemContainer.TabIndex = 0;


            mainPanel.Controls.Add(modificationItemContainer);

            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);
        }

        #endregion
        
        #region public ModificationItemAdding(Aircraft parentAircraft):this()

        ///<summary>
        /// Создается объект, описывающий отображение добавления <see cref="ModificationItem"/>
        ///</summary>
        /// <param name="parentAircraft">Родительский объект, в который добавляется ModificationItem</param>
        public ModificationItemAdding(Aircraft parentAircraft):this()
        {
            if (parentAircraft == null) 
                throw new ArgumentNullException("parentAircraft");
            this.parentAircraft = parentAircraft;

            aircraftHeader.Aircraft = parentAircraft;
            ClearFields();
        }

        #endregion

        #endregion

        #region Methods

        #region private void buttonSaveAndEdit_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonSaveAndEdit_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (AddNewModificationItem(true))
            {
                e.RequestedEntity = new DispatcheredModificationItemScreen(addedModificationItem);//, parentAircraft);
                e.DisplayerText = parentAircraft.RegistrationNumber + ". " + addedModificationItem.SbNo + " " + addedModificationItem.EngineeringOrderNo + " " + addedModificationItem.AirworthinessDirectiveNo + " Record";
            }
            else
                e.Cancel = true;
        }

        #endregion

        #region private void buttonSaveAndAdd_Click(object sender, EventArgs e)

        private void buttonSaveAndAdd_Click(object sender, EventArgs e)
        {
            if (AddNewModificationItem(false))
            {
                MessageBox.Show("Record added successfully", new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                modificationItemControl.TextBoxSBSLNo.Focus();
            }
        }

        #endregion

        #region protected bool AddNewModificationItem(bool changePageName)

        protected bool AddNewModificationItem(bool changePageName)
        {
            modificationItemControl.SaveData(addedModificationItem, changePageName);
            parentAircraft.AddModificationItem(addedModificationItem);
            return true;
        }

        #endregion

        #region private void ClearFields()

        private void ClearFields()
        {
            addedModificationItem = new ModificationItem(parentAircraft);
            modificationItemControl.ClearFields();
        }

        #endregion

        #endregion
                

    }
}