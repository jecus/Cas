using System;
using System.Collections.Generic;
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
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.MaintenanceStatusControls;
using CAS.UI.UIControls.Auxiliary;
using Controls;
using Controls.AvButtonT;
using Controls.AvMultitabControl.Auxiliary;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.MaintenanceStatusControls
{
    /// <summary>
    /// Элемент управлени ядл яотображения списка подчеков
    /// </summary>
    public class MaintenanceSubChecksCollectionScreen : Control
    {

        #region Fields

        protected MaintenanceDirective directive;
        private readonly HeaderControl headerControl = new HeaderControl();
        private readonly AircraftHeaderControl aircraftHeaderControl;
        private readonly Panel mainPanel = new Panel();
        private readonly Panel panelTopContainer = new Panel();
        private readonly FooterControl footerControl = new FooterControl();
        private readonly StatusImageLinkLabel labelTitle = new StatusImageLinkLabel();
        private readonly AvButtonT buttonAddSubcheck = new AvButtonT();
        private readonly RichReferenceButton buttonEditSubCheck = new RichReferenceButton();
        private readonly AvButtonT buttonDeleteSelected = new AvButtonT();
        private readonly Icons icons = new Icons();
        private readonly MaintenanceSubChecksListView maintenanceSubChecksListView;
        private readonly bool permissionForRemove;
        private readonly bool permissionForUpdate;

        private MaintenanceSubCheck maintenanceSubCheck;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения списка подчеков
        /// </summary>
        /// <param name="directive"></param>
        public MaintenanceSubChecksCollectionScreen(MaintenanceDirective directive)
        {
            ((DispatcheredSubChecksCollectionScreen)this).InitComplition += MaintenanceSubChecksCollectionScreen_InitComplition;
            this.directive = directive;
            permissionForRemove = directive.HasPermission(Users.CurrentUser, DataEvent.Remove);
            permissionForUpdate = directive.HasPermission(Users.CurrentUser, DataEvent.Update);
            aircraftHeaderControl = new AircraftHeaderControl((Aircraft)directive.Parent, true, true);
            PerformEvents(true);
            //
            // headerControl
            //
            headerControl.Controls.Add(aircraftHeaderControl);
            headerControl.ActionControl.ShowEditButton = false;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "job_cards";
            headerControl.ReloadRised += headerControl_ReloadRised;
            //
            // maintenanceSubChecksListView
            //
            maintenanceSubChecksListView = new MaintenanceSubChecksListView(directive);
            maintenanceSubChecksListView.Location =new Point(30,30);
            maintenanceSubChecksListView.SelectedItemsChanged += maintenanceSubChecksListView_SelectedItemsChanged;
            //maintenanceSubChecksListView.PreviousSort();
            maintenanceSubChecksListView.TabIndex = 22;
            //
            // mainPanel
            //
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(maintenanceSubChecksListView);
            mainPanel.TabIndex = 2;
            //
            // panelTopContainer
            //
            panelTopContainer.Dock = DockStyle.Top;
            panelTopContainer.Location = new Point(0, 0);
            panelTopContainer.Size = new Size(1042, 62);
            panelTopContainer.TabIndex = 1;
            // 
            // labelTitle
            // 
            labelTitle.ActiveLinkColor = Color.Black;
            labelTitle.Enabled = false;
            labelTitle.HoveredLinkColor = Color.Black;
            labelTitle.ImageBackColor = Color.Transparent;
            labelTitle.ImageLayout = ImageLayout.Center;
            labelTitle.LinkColor = Color.DimGray;
            labelTitle.LinkMouseCapturedColor = Color.Empty;
            labelTitle.Location = new Point(28, 17);
            labelTitle.Margin = new Padding(0);
            labelTitle.Size = new Size(412, 27);
            labelTitle.TabIndex = 16;
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            labelTitle.TextFont = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTitle.Status = Statuses.NotActive;
            labelTitle.Text = ((Aircraft)directive.Parent).RegistrationNumber + ". Checks";
            // 
            // buttonAddSubcheck
            // 
            buttonAddSubcheck.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddSubcheck.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddSubcheck.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddSubcheck.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddSubcheck.Icon =  icons.Add;
            buttonAddSubcheck.IconNotEnabled = icons.AddGray;
            buttonAddSubcheck.Size = new Size(140, 59);
            buttonAddSubcheck.TabIndex = 19;
            buttonAddSubcheck.TextAlignMain = ContentAlignment.BottomCenter;
            buttonAddSubcheck.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddSubcheck.TextMain = "Add new";
            buttonAddSubcheck.TextSecondary = "subcheck";
            buttonAddSubcheck.Click += buttonAddSubcheck_Click;
            buttonAddSubcheck.Enabled = permissionForUpdate;
            // 
            // buttonEditSubCheck
            // 
            buttonEditSubCheck.Enabled = false;
            buttonEditSubCheck.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonEditSubCheck.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonEditSubCheck.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonEditSubCheck.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonEditSubCheck.Size = new Size(140, 59);
            buttonEditSubCheck.TabIndex = 20;
            buttonEditSubCheck.TextAlignMain = ContentAlignment.BottomCenter;
            buttonEditSubCheck.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonEditSubCheck.TextSecondary = "subcheck";
            buttonEditSubCheck.DisplayerRequested += buttonEditSubCheck_DisplayerRequested;
            if (permissionForUpdate)
            {
                buttonEditSubCheck.Icon = icons.Edit;
                buttonEditSubCheck.IconNotEnabled = icons.EditGray;
                buttonEditSubCheck.TextMain = "Edit";
            }
            else
            {
                buttonEditSubCheck.Icon = icons.View;
                buttonEditSubCheck.IconNotEnabled = icons.ViewGray;
                buttonEditSubCheck.TextMain = "View";
            }
            // 
            // buttonDeleteSelected
            // 
            buttonDeleteSelected.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.Icon = icons.Delete;
            buttonDeleteSelected.IconNotEnabled = icons.DeleteGray;
            buttonDeleteSelected.PaddingSecondary = new Padding(4, 0, 0, 0);
            buttonDeleteSelected.Size = new Size(150, 59);
            buttonDeleteSelected.TabIndex = 21;
            buttonDeleteSelected.TextAlignMain = ContentAlignment.BottomLeft;
            buttonDeleteSelected.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonDeleteSelected.TextMain = "Delete";
            buttonDeleteSelected.TextSecondary = "selected";
            buttonDeleteSelected.Enabled = false;
            buttonDeleteSelected.Click += buttonDeleteSelected_Click;
            
            BackColor = Css.CommonAppearance.Colors.BackColor;

            panelTopContainer.Controls.Add(labelTitle);
            panelTopContainer.Controls.Add(buttonAddSubcheck);
            panelTopContainer.Controls.Add(buttonEditSubCheck);
            panelTopContainer.Controls.Add(buttonDeleteSelected);

            mainPanel.Controls.Add(panelTopContainer);
            Controls.Add(mainPanel);
            Controls.Add(headerControl);
            Controls.Add(footerControl);

            UpdateInformation(false);
        }


        #endregion

        #region Methods

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            UpdateInformation(true);
        }

        #endregion
        
        #region private void UpdateInformation()

        private void UpdateInformation(bool reloadDirective)
        {
            if (reloadDirective)
            {
                try
                {
                    directive.Reload();
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while loading data", ex);
                    return;
                }
            }
            maintenanceSubChecksListView.UpdateItems();
        }

        #endregion

        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            UpdateInformation();
        }

        #endregion

        #region private void buttonAddSubcheck_Click(object sender, EventArgs e)

        private void buttonAddSubcheck_Click(object sender, EventArgs e)
        {
            MaintenanceSubCheckForm form = new MaintenanceSubCheckForm(directive);
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateInformation();
            }
        }

        #endregion

        #region private void buttonEditSubCheck_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonEditSubCheck_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = ((Aircraft)maintenanceSubChecksListView.SelectedItem.Parent.Parent.Parent).RegistrationNumber + ". " + maintenanceSubChecksListView.SelectedItem.Name + ". Maintenance Job Cards";
            e.RequestedEntity = new DispatcheredJobCardsCollectionScreen(maintenanceSubChecksListView.SelectedItem);
        }

        #endregion 

        #region private void buttonDeleteSelected_Click(object sender, EventArgs e)

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            string message;
            if (maintenanceSubChecksListView.SelectedItems.Count == 1)
                message = string.Format(new TermsProvider()["DeleteQuestion"].ToString(), "sub check");
            else
                message = string.Format(new TermsProvider()["DeleteQuestionSeveral"].ToString(), "sub checks");
            DialogResult result = MessageBox.Show(message, "Deleting confirmation", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {

                try
                {
                    for (int i = 0; i < maintenanceSubChecksListView.SelectedItems.Count; i++)
                    {
                        ((MaintenanceLimitation)maintenanceSubChecksListView.SelectedItems[i].Parent).RemoveSubCheck(maintenanceSubChecksListView.SelectedItems[i]);
                    }
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); return;
                }
                UpdateInformation();
            }

            /*
            maintenanceSubChecksListView.ItemsListView.BeginUpdate();
            List<MaintenanceSubCheck> subCheckList = maintenanceSubChecksListView.SelectedItems;
            for (int i = 0; i < subCheckList.Count; i++)
            {
                check.RemoveSubCheck(subCheckList[i]);
                maintenanceSubChecksListView.DeleteItem(subCheckList[i]);
            } 
            maintenanceSubChecksListView.ItemsListView.EndUpdate();
            labelTotal.Text = "Total: " + maintenanceSubChecksListView.TotalItems;*/
        }
        #endregion

        #region private void maintenanceSubChecksListView_SelectedItemsChanged(object sender, EventArgs e)

        private void maintenanceSubChecksListView_SelectedItemsChanged(object sender, EventArgs e)
        {
            buttonEditSubCheck.Enabled = (maintenanceSubChecksListView.SelectedItems.Count == 1);
            buttonDeleteSelected.Enabled = (maintenanceSubChecksListView.SelectedItems.Count > 0 && permissionForRemove);
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

            if (buttonAddSubcheck != null && buttonEditSubCheck != null && buttonDeleteSelected != null)
            {
                buttonDeleteSelected.Location = new Point(Width - buttonDeleteSelected.Width - 5, 0);
                buttonEditSubCheck.Location = new Point(buttonDeleteSelected.Left - buttonEditSubCheck.Width - 5, 0);
                buttonAddSubcheck.Location = new Point(buttonDeleteSelected.Left - buttonEditSubCheck.Width - buttonAddSubcheck.Width - 10, 0);
            }
            if (maintenanceSubChecksListView != null)
            {
                maintenanceSubChecksListView.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                maintenanceSubChecksListView.Size = new Size(Width, Height - headerControl.Height - footerControl.Height - panelTopContainer.Height);
            }
        }

        #endregion

        #region private void MaintenanceSubChecksCollectionScreen_InitComplition(object sender, EventArgs e)

        private void MaintenanceSubChecksCollectionScreen_InitComplition(object sender, EventArgs e)
        {
            ((DispatcheredMultitabControl)sender).Closed += MaintenanceSubChecksCollectionScreen_Closed;
        }

        
        #endregion

        #region private void MaintenanceSubChecksCollectionScreen_Closed(object sender, AvMultitabControlEventArgs e)

        private void MaintenanceSubChecksCollectionScreen_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == (DispatcheredTabPage)Parent)
                PerformEvents(false);
        }


        #endregion

        #region private void PerformEvents(bool addTo)

        private void PerformEvents(bool addTo)
        {
            List<MaintenanceSubCheck> maintenanceSubChecks = new List<MaintenanceSubCheck>();
            for (int i = 0; i < directive.Limitations.Length; i++)
                maintenanceSubChecks.AddRange(directive.Limitations[i].SubChecks);
            for (int i = 0; i < maintenanceSubChecks.Count; i++)
            {
                if (addTo)
                {
                    maintenanceSubChecks[i].Saving += MaintenanceSubChecksCollectionScreen_Saving;
                    maintenanceSubChecks[i].Saved += MaintenanceSubChecksCollectionScreen_Saved;
                    maintenanceSubChecks[i].SubcheckJoined += MaintenanceSubChecksCollectionScreen_SubcheckJoined;
                    maintenanceSubChecks[i].SubcheckReleased += MaintenanceSubChecksCollectionScreen_SubcheckReleased;
                }
                else
                {
                    maintenanceSubChecks[i].Saving -= MaintenanceSubChecksCollectionScreen_Saving;
                    maintenanceSubChecks[i].Saved -= MaintenanceSubChecksCollectionScreen_Saved;
                    maintenanceSubChecks[i].SubcheckJoined -= MaintenanceSubChecksCollectionScreen_SubcheckJoined;
                    maintenanceSubChecks[i].SubcheckReleased -= MaintenanceSubChecksCollectionScreen_SubcheckReleased;

                }
            }
        }

        #endregion

        #region private void MaintenanceSubChecksCollectionScreen_SubcheckReleased(object sender, CollectionChangeEventArgs e)

        private void MaintenanceSubChecksCollectionScreen_SubcheckReleased(object sender, CollectionChangeEventArgs e)
        {
            UpdateInformation(false);
        }

        #endregion

        #region private void MaintenanceSubChecksCollectionScreen_SubcheckJoined(object sender, CollectionChangeEventArgs e)

        private void MaintenanceSubChecksCollectionScreen_SubcheckJoined(object sender, CollectionChangeEventArgs e)
        {
            UpdateInformation(false);
        }

        #endregion

        #region private void MaintenanceSubChecksCollectionScreen_Saved(object sender, EventArgs e)

        private void MaintenanceSubChecksCollectionScreen_Saved(object sender, EventArgs e)
        {
            maintenanceSubChecksListView.EditItem(maintenanceSubCheck, (MaintenanceSubCheck) sender);
        }

        #endregion

        #region private void MaintenanceSubChecksCollectionScreen_Saving(object sender, CancelEventArgs e)

        private void MaintenanceSubChecksCollectionScreen_Saving(object sender, CancelEventArgs e)
        {
            maintenanceSubCheck = (MaintenanceSubCheck) sender;
        }

        #endregion


        #endregion

    }
}
