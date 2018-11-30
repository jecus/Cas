using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.UIControls.ModificationsPerformed
{
    /// <summary>
    /// Элемент управления для отображения <see cref="ModificationItem"/>
    /// </summary>
    [ToolboxItem(false)]
    public class ModificationItemScreen : UserControl
    {
        #region Fields

        protected ModificationItem currentItem;
        //private Aircraft parentAircraft;

        private readonly HeaderControl headerControl;
        private readonly FooterControl footerControl;
        private readonly AircraftHeaderControl aircraftHeader;

        protected readonly ModificationItemControl modificationItemControl;
        private readonly ExtendableRichContainer modificationItemContainer;
        
        private readonly Panel mainPanel;
        private readonly FlowLayoutPanel containedPanel = new FlowLayoutPanel();
        private readonly Panel panelHeader;
        
        private readonly RichReferenceButton buttonDeleteDirective;

        private readonly Icons icons = new Icons();

        #endregion

        #region Constructor

        #region public ModificationItemScreen(ModificationItem item)

        ///<summary>
        /// Создает страницу для отображения информации об одной директиве
        ///</summary>
        /// <param name="item">ModificationItem</param>
        ///// <param name="parentAircraft">ВС, которому принадлежит ModificationItem</param>
        public ModificationItemScreen(ModificationItem item)//, Aircraft parentAircraft)
        {
            if (item == null)
                throw new ArgumentNullException("item", "Argument cannot be null");
            //this.parentAircraft = parentAircraft;
            currentItem = item;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Dock = DockStyle.Fill;

            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeader = new AircraftHeaderControl((Aircraft)item.Parent, true);
            modificationItemContainer = new ExtendableRichContainer();
            modificationItemControl = new ModificationItemControl(currentItem);
            mainPanel = new Panel();
            panelHeader = new Panel();
            buttonDeleteDirective = new RichReferenceButton();
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
            headerControl.ContextActionControl.ShowPrintButton = false;
            headerControl.ButtonEdit.DisplayerRequested += ButtonSave_DisplayerRequested;
            headerControl.ReloadRised += headerControl_ReloadRised;
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
            // modificationItemContainer
            //
            modificationItemContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            modificationItemContainer.LabelCaption.Text = "Modification Item";
            modificationItemContainer.MainControl = modificationItemControl;
            modificationItemContainer.UpperLeftIcon = icons.GrayArrow;
            modificationItemContainer.TabIndex = 1;
            //
            // panelHeader
            //
            panelHeader.Size = new Size(1250, 50);
            panelHeader.TabIndex = 0;
            panelHeader.Controls.Add(buttonDeleteDirective);
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
            buttonDeleteDirective.TextSecondary = "record";
            buttonDeleteDirective.DisplayerRequested += buttonDeleteDirective_DisplayerRequested;
            

           
            containedPanel.Controls.Add(panelHeader);
            containedPanel.Controls.Add(modificationItemContainer);


            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);

            UpdateItem();
        }

        #endregion

        #endregion

        #region Properties

/*        #region public Aircraft ParentAircraft

        /// <summary>
        /// Возвращает или устанавливает ВС, которому принадлежит ModificationItem
        /// </summary>
        public Aircraft ParentAircraft
        {
            get
            {
                return parentAircraft;
            }
            set
            {
                parentAircraft = value;
            }
        }

        #endregion*/
        
        #endregion

        #region Methods

        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            if (modificationItemControl.GetChangeStatus(true))
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new TermsProvider()["SystemName"], MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    ReloadItem();
                }
            }
            else
            {
                ReloadItem();
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
        /// Сохраняет данные текущего ModificationItem
        /// </summary>
        protected bool Save()
        {
            if (modificationItemControl.GetChangeStatus(true))
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
            modificationItemControl.SaveData();

            try
            {
                currentItem.Save(true);
                ReloadItem();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
            }

        }

        #endregion


        

        #region private void ReloadItem()

        private void ReloadItem()
        {
            try
            {
                currentItem.Reload();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }
            UpdateItem();
        }

        #endregion

        #region public void UpdateItem()

        /// <summary>
        /// Обновляется отображаемая информация
        /// </summary>
        public void UpdateItem()
        {
            buttonDeleteDirective.Enabled = currentItem.HasPermission(Users.CurrentUser, DataEvent.Remove);
            headerControl.ActionControl.ShowEditButton = currentItem.HasPermission(Users.CurrentUser, DataEvent.Update); ;

            modificationItemControl.UpdateInformation();
        }

        #endregion

        #region private void buttonDeleteDirective_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonDeleteDirective_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete current item?",
                                                  "Confirm deleting", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {

                try
                {
                    Aircraft parentDirectiveContainer = (Aircraft)currentItem.Parent;
                    parentDirectiveContainer.RemoveModificationItem(currentItem);

                    MessageBox.Show("Item was deleted successfully", "Item deleted",
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

        #endregion
    }
}