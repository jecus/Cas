using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.Core.Types.WorkPackages;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.MaintenanceStatusControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.WorkPackages;
using CAS.UI.UIControls.WorkPackages;
using CASReports.Builders;
using Controls;
using Controls.AvButtonT;
using CAS.Core.ProjectTerms;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using Controls.AvMultitabControl.Auxiliary;
using Controls.StatusImageLink;


namespace CAS.UI.UIControls.MaintenanceStatusControls
{
    /// <summary>
    /// Элемент управления для отображения списка рабочих карт
    /// </summary>
    public class MaintenanceJobCardsCollectionScreen : Control, IReference
    {

        #region Fields

        protected MaintenanceSubCheck subCheck;
        private readonly Aircraft currentAircraft;
        
        private MaintenanceJobCardsListView listViewJobCards;
        private readonly HeaderControl headerControl = new HeaderControl();
        private AircraftHeaderControl aircraftHeaderControl;
        private readonly FooterControl footerControl = new FooterControl();
        private readonly Panel mainPanel = new Panel();
        private readonly Panel panelTopContainer = new Panel();
        private readonly StatusImageLinkLabel labelTitle = new StatusImageLinkLabel();
        private readonly AvButtonT buttonSaveToDisk = new AvButtonT();
        private readonly AvButtonT buttonAddJobCard = new AvButtonT();
        private readonly AvButtonT buttonJoinSubCheck = new AvButtonT();
        private readonly AvButtonT buttonEditJobCard = new AvButtonT();
        private readonly AvButtonT buttonCutOffSubCheck = new AvButtonT();
        private readonly AvButtonT buttonDeleteJobCard = new AvButtonT();
        private readonly Icons icons = new Icons();
        private bool permissionForUpdate = true;
        private bool permissionForDelete = true;
        private JobCard editedJobCard;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem toolStripMenuItemOpen;
        private ToolStripMenuItem toolStripMenuItemSaveAs;
        private ToolStripMenuItem toolStripMenuItemAddNew;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItemComposeWorkPackage;
        private readonly List<ToolStripMenuItem> toolStripMenuItemsWorkPackages = new List<ToolStripMenuItem>();
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem toolStripMenuItemProperties;
        

        #endregion

        #region Construstor

        /// <summary>
        /// Создает элемент управления для отображения списка рабочих карт
        /// </summary>
        /// <param name="subCheck"></param>
        public MaintenanceJobCardsCollectionScreen(MaintenanceSubCheck subCheck)
        {
            this.subCheck = subCheck;
            currentAircraft = (Aircraft)subCheck.Parent.Parent.Parent;
            InitializeComponent();
            SetToolStripMenuItems();
            HookWorkPackageEvents();
            UpdateInformation(false);
        }

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            ((DispatcheredJobCardsCollectionScreen)this).InitComplition += MaintenanceJobCardsCollectionScreen_InitComplition;
            permissionForDelete = subCheck.HasPermission(Users.CurrentUser, DataEvent.Remove);
            permissionForUpdate = subCheck.HasPermission(Users.CurrentUser, DataEvent.Update);
            aircraftHeaderControl = new AircraftHeaderControl((Aircraft)subCheck.Parent.Parent.Parent, true, true);
            listViewJobCards = new MaintenanceJobCardsListView(subCheck);
            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemOpen = new ToolStripMenuItem();
            toolStripMenuItemSaveAs = new ToolStripMenuItem();
            toolStripMenuItemAddNew = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemComposeWorkPackage = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripMenuItemProperties = new ToolStripMenuItem();
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(179, 176);
            // 
            // toolStripMenuItemOpen
            // 
            toolStripMenuItemOpen.Text = "Open";
            toolStripMenuItemOpen.Click += toolStripMenuItemOpen_Click;
            // 
            // toolStripMenuItemSaveAs
            // 
            toolStripMenuItemSaveAs.Text = "Save As...";
            toolStripMenuItemSaveAs.Click += toolStripMenuItemSaveAs_Click;
            // 
            // toolStripMenuItemAddNew
            // 
            toolStripMenuItemAddNew.Text = "Add New";
            toolStripMenuItemAddNew.Click += toolStripMenuItemAdd_Click;
            //
            // toolStripMenuItemComposeWorkPackage
            //
            toolStripMenuItemComposeWorkPackage.Text = "Compose a work package";
            toolStripMenuItemComposeWorkPackage.Click += toolStripMenuItemComposeWorkPackage_Click;
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Text = "Delete";
            toolStripMenuItemDelete.Click += toolStripMenuItemDelete_Click;
            // 
            // toolStripMenuItemProperties
            // 
            toolStripMenuItemProperties.Text = "Properties";
            toolStripMenuItemProperties.Click += toolStripMenuItemProperties_Click;
            //
            // listViewJobCards
            //
            listViewJobCards.Dock = DockStyle.Top;
            listViewJobCards.Height = 770;
            listViewJobCards.SelectedItemsChanged += listViewJobCards_SelectedItemsChanged;
            listViewJobCards.ItemsListView.ContextMenuStrip = contextMenuStrip;
            listViewJobCards.TabIndex = 20;
            PerformEvents(true);
            //
            // headerControl
            //
            headerControl.Controls.Add(aircraftHeaderControl);
            headerControl.ReloadRised += headerControl_ReloadRised;
            headerControl.EditDisplayerRequested += headerControl_EditDisplayerRequested;
            headerControl.ActionControl.ButtonEdit.Enabled = permissionForUpdate;
            headerControl.ContextActionControl.ShowPrintButton = true;
            headerControl.ContextActionControl.ButtonPrint.DisplayerRequested += ButtonPrint_DisplayerRequested;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "job_cards";
            headerControl.TabIndex = 0;
            // 
            // buttonSaveToDisk
            // 
            buttonSaveToDisk.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonSaveToDisk.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonSaveToDisk.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonSaveToDisk.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonSaveToDisk.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonSaveToDisk.Icon = icons.Save;
            buttonSaveToDisk.IconNotEnabled = icons.SaveGray;
            buttonSaveToDisk.Size = new Size(170, 59);
            buttonSaveToDisk.TabIndex = 17;
            buttonSaveToDisk.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonSaveToDisk.TextMain = "Save to disk";
            buttonSaveToDisk.Click += buttonSaveToDisk_Click;
            //
            // buttonAddJobCard
            //
            buttonAddJobCard.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddJobCard.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddJobCard.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddJobCard.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddJobCard.Icon = icons.Add;
            buttonAddJobCard.IconNotEnabled = icons.AddGray;
            buttonAddJobCard.Enabled = permissionForUpdate;
            buttonAddJobCard.Size = new Size(150, 59);
            buttonAddJobCard.TextAlignMain = ContentAlignment.BottomCenter;
            buttonAddJobCard.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddJobCard.TextMain = "Add new";
            buttonAddJobCard.TextSecondary = "Job Card";
            buttonAddJobCard.Click += buttonAddJobCard_Click;
            buttonAddJobCard.TabIndex = 1;
            //
            // buttonJoinSubCheck
            //
            buttonJoinSubCheck.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonJoinSubCheck.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonJoinSubCheck.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonJoinSubCheck.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonJoinSubCheck.Icon = icons.Add;
            buttonJoinSubCheck.IconNotEnabled = icons.AddGray;
            buttonJoinSubCheck.Enabled = permissionForUpdate;
            buttonJoinSubCheck.Size = new Size(150, 59);
            buttonJoinSubCheck.TextAlignMain = ContentAlignment.BottomCenter;
            buttonJoinSubCheck.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonJoinSubCheck.TextMain = "Join";
            buttonJoinSubCheck.TextSecondary = "Subcheck";
            buttonJoinSubCheck.Click += buttonJoinSubCheck_Click;
            buttonJoinSubCheck.TabIndex = 2;
            // 
            // buttonEditJobCard
            // 
            buttonEditJobCard.Enabled = false;
            buttonEditJobCard.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonEditJobCard.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonEditJobCard.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonEditJobCard.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonEditJobCard.Size = new Size(140, 59);
            buttonEditJobCard.TabIndex = 20;
            buttonEditJobCard.TextAlignMain = ContentAlignment.BottomCenter;
            buttonEditJobCard.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonEditJobCard.TextSecondary = "job card";
            buttonEditJobCard.Click += buttonEditJobCard_Click;
            if (permissionForUpdate)
            {
                buttonEditJobCard.Icon = icons.Edit;
                buttonEditJobCard.IconNotEnabled = icons.EditGray;
                buttonEditJobCard.TextMain = "Edit";
            }
            else
            {
                buttonEditJobCard.Icon = icons.View;
                buttonEditJobCard.IconNotEnabled = icons.ViewGray;
                buttonEditJobCard.TextMain = "View";
            }
            // 
            // buttonCutOffSubCheck
            // 
            buttonCutOffSubCheck.Enabled = false;
            buttonCutOffSubCheck.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonCutOffSubCheck.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonCutOffSubCheck.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonCutOffSubCheck.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonCutOffSubCheck.Icon = icons.Delete;
            buttonCutOffSubCheck.IconNotEnabled = icons.DeleteGray;
            buttonCutOffSubCheck.PaddingSecondary = new Padding(4, 0, 0, 0);
            buttonCutOffSubCheck.Size = new Size(150, 59);
            buttonCutOffSubCheck.TextAlignMain = ContentAlignment.BottomLeft;
            buttonCutOffSubCheck.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonCutOffSubCheck.TextMain = "Cutoff";
            buttonCutOffSubCheck.TextSecondary = "subcheck";
            buttonCutOffSubCheck.Click += buttonCutOffSubCheck_Click;
            // 
            // buttonDeleteJobCard
            // 
            buttonDeleteJobCard.Enabled = false;
            buttonDeleteJobCard.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteJobCard.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteJobCard.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteJobCard.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteJobCard.Icon = icons.Delete;
            buttonDeleteJobCard.IconNotEnabled = icons.DeleteGray;
            buttonDeleteJobCard.PaddingSecondary = new Padding(4, 0, 0, 0);
            buttonDeleteJobCard.Size = new Size(150, 59);
            buttonDeleteJobCard.TextAlignMain = ContentAlignment.BottomLeft;
            buttonDeleteJobCard.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonDeleteJobCard.TextMain = "Delete";
            buttonDeleteJobCard.TextSecondary = "selected";
            buttonDeleteJobCard.Click += buttonDeleteJobCard_Click;
            //
            // mainPanel
            //
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(listViewJobCards);
            mainPanel.TabIndex = 1;
            //
            // panelTopContainer
            //
            panelTopContainer.Dock = DockStyle.Top;
            panelTopContainer.Location = new Point(0, 0);
            panelTopContainer.Size = new Size(1042, 62);
            panelTopContainer.TabIndex = 2;
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
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            labelTitle.TextFont = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTitle.Status = Statuses.NotActive;

            BackColor = Css.CommonAppearance.Colors.BackColor;
            panelTopContainer.Controls.Add(labelTitle);
            panelTopContainer.Controls.Add(buttonSaveToDisk);
            panelTopContainer.Controls.Add(buttonAddJobCard);
            panelTopContainer.Controls.Add(buttonJoinSubCheck);
            panelTopContainer.Controls.Add(buttonEditJobCard);
            panelTopContainer.Controls.Add(buttonCutOffSubCheck);
            panelTopContainer.Controls.Add(buttonDeleteJobCard);

            mainPanel.Controls.Add(panelTopContainer);
            Controls.Add(mainPanel);
            Controls.Add(headerControl);
            Controls.Add(footerControl);
        }

        #endregion
        
        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            UpdateInformation(true);
        }

        #endregion

        #region private void UpdateInformation(bool reloadSubCheck)

        private void UpdateInformation(bool reloadSubCheck)
        {
            if (reloadSubCheck)
            {

                try
                {
                    subCheck.Reload();
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while loading data", ex);
                    return;
                }
            }
            labelTitle.Text = ((Aircraft)subCheck.Parent.Parent.Parent).RegistrationNumber + ". " + subCheck.Name + " check";
            listViewJobCards.UpdateItems();
            
            buttonCutOffSubCheck.Enabled = (subCheck.JoinedSubChecks.Count > 0 && permissionForDelete);
            headerControl.ContextActionControl.ButtonPrint.Enabled = (subCheck.JobCards.Count != 0 || subCheck.JoinedSubChecks.Count != 0);
            listViewJobCards_SelectedItemsChanged(this, EventArgs.Empty);
        }

        #endregion

        #region private void SetToolStripMenuItems()

        private void SetToolStripMenuItems()
        {
            contextMenuStrip.Items.Clear();
            toolStripMenuItemsWorkPackages.Clear();
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    toolStripMenuItemOpen,
                                                    toolStripMenuItemSaveAs,
                                                    toolStripMenuItemAddNew,
                                                    toolStripSeparator1,
                                                });
            List<WorkPackage> workPackages = new List<WorkPackage>(currentAircraft.WorkPackages);
            workPackages.Sort(new WorkPackageComparer());
            for (int i = 0; i < workPackages.Count; i++)
            {
                if (workPackages[i].Status != WorkPackageStatus.Open)
                    continue;
                ToolStripMenuItem item = new ToolStripMenuItem("Move to " + workPackages[i].Title);
                item.Tag = workPackages[i];
                item.Click += WorkPackageItem_Click;
                toolStripMenuItemsWorkPackages.Add(item);
                contextMenuStrip.Items.Add(item);
            }
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    toolStripMenuItemComposeWorkPackage, 
                                                    toolStripSeparator2,
                                                    toolStripMenuItemDelete,
                                                    toolStripSeparator3, 
                                                    toolStripMenuItemProperties
                                                });

        }

        #endregion

        #region private void ComposeWorkPackage(Aircraft aircraft)

        private void ComposeWorkPackage()
        {
            WorkPackage workPackage = new WorkPackage();
            workPackage.Title = currentAircraft.GetNewWorkPackageTitle();

            try
            {
                currentAircraft.AddWorkPackage(workPackage);
                for (int i = 0; i < listViewJobCards.SelectedItems.Count; i++)
                    workPackage.AddItem(listViewJobCards.SelectedItems[i]);
                if (MessageBox.Show("Work Package " + workPackage.Title + " created successfully." + Environment.NewLine + "Open work package screen?",
                    new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    OnDisplayerRequested(new ReferenceEventArgs(new DispatcheredWorkPackageScreen(workPackage), ReflectionTypes.DisplayInNew, currentAircraft.RegistrationNumber + ". " + workPackage.Title));
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while creating work package", ex);
            }

        }

        #endregion

        #region private void AddItemsToWorkPackage(WorkPackage workPackage)

        private void AddItemsToWorkPackage(WorkPackage workPackage)
        {
            try
            {

                bool exclamation = false;
                for (int i = 0; i < listViewJobCards.SelectedItems.Count; i++)
                {
                    if (workPackage.JobCards.Contains(listViewJobCards.SelectedItems[i]))
                    {
                        exclamation = true;
                        break;
                    }
                }
                if (exclamation)
                {
                    if (MessageBox.Show("Some job cards will not be added to a work package." + Environment.NewLine + "Continue?",
                            new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                        return;
                }
                int jobCardsAdded = 0;
                for (int i = 0; i < listViewJobCards.SelectedItems.Count; i++)
                {
                    if (!workPackage.JobCards.Contains(listViewJobCards.SelectedItems[i]))
                    {
                        workPackage.AddItem(listViewJobCards.SelectedItems[i]);
                        jobCardsAdded++;
                    }
                }
                string message;
                if (jobCardsAdded <= 0)
                {
                    if (listViewJobCards.SelectedItems.Count == 1)
                        message = "Job card is already added to the work package";
                    else
                        message = "Job cards are already added to the work package";
                }
                else if (jobCardsAdded == 1)
                    message = "Job card added successfully";
                else
                    message = "Job cards added successfully";
                if (MessageBox.Show(message + ". Open work package screen?", new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    OnDisplayerRequested(new ReferenceEventArgs(new DispatcheredWorkPackageScreen(workPackage), ReflectionTypes.DisplayInNew, currentAircraft.RegistrationNumber + ". " + workPackage.Title));
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while adding items to work package", ex);
            }


        }

        #endregion

        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            UpdateInformation();
        }

        #endregion

        #region private void headerControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)

        private void headerControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            MaintenanceSubCheckForm form = new MaintenanceSubCheckForm(subCheck);
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateInformation(false);
                string caption = ((Aircraft)subCheck.Parent.Parent.Parent).RegistrationNumber + ". " + subCheck.Name + ". Maintenance Job Cards";
                if (DisplayerRequested != null)
                    DisplayerRequested(this, new ReferenceEventArgs(null, ReflectionTypes.ChangeTextOfContainingDisplayer, caption));
            }
            e.Cancel = true;
        }

        #endregion

        #region private void buttonSaveToDisk_Click(object sender, EventArgs e)

        private void buttonSaveToDisk_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select directory where to store files";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<JobCard> jobCards = new List<JobCard>(subCheck.JobCards);
                for (int i = 0; i < subCheck.JoinedSubChecks.Count; i++ )
                    jobCards.AddRange(subCheck.JoinedSubChecks[i].JobCards);
                for (int i = 0; i < jobCards.Count; i++)
                {
                    UsefulMethods.SaveFileFromByteArray(jobCards[i].AttachedFile.FileData, dialog.SelectedPath + "\\ " + jobCards[i].AirlineCardNumber + ".pdf");
                }
                Process.Start(dialog.SelectedPath);
            }

        }

        #endregion

        #region private void buttonAddJobCard_Click(object sender, EventArgs e)

        private void buttonAddJobCard_Click(object sender, EventArgs e)
        {
            AddJobCard();
        }

        #endregion
        
        #region private void buttonJoinSubCheck_Click(object sender, EventArgs e)

        private void buttonJoinSubCheck_Click(object sender, EventArgs e)
        {
            JoinSubCheckForm form = new JoinSubCheckForm(subCheck, SubCheckFormView.Add);
            if (form.GetAvailableSubChecks().Count == 0)
                MessageBox.Show("There are no subchecks available", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateInformation(false);
                }
            }
        }

        #endregion

        #region private void buttonEditJobCard_Click(object sender, EventArgs e)

        private void buttonEditJobCard_Click(object sender, EventArgs e)
        {
            OpenJobCardProperties();
        }

        #endregion

        #region private void buttonCutOffSubCheck_Click(object sender, EventArgs e)

        private void buttonCutOffSubCheck_Click(object sender, EventArgs e)
        {
            JoinSubCheckForm form = new JoinSubCheckForm(subCheck, SubCheckFormView.Delete);
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateInformation(false);
            }
        }

        #endregion

        #region private void buttonDeleteJobCard_Click(object sender, EventArgs e)

        private void buttonDeleteJobCard_Click(object sender, EventArgs e)
        {
            DeleteJobCards();
        }

        #endregion

        #region private void listViewJobCards_SelectedItemsChanged(object sender, EventArgs e)

        private void listViewJobCards_SelectedItemsChanged(object sender, EventArgs e)
        {
            int count = listViewJobCards.SelectedItems.Count;
            buttonEditJobCard.Enabled = 
            toolStripMenuItemOpen.Enabled =
            toolStripMenuItemSaveAs.Enabled =
            toolStripMenuItemProperties.Enabled = (count == 1);
            buttonDeleteJobCard.Enabled =
            toolStripMenuItemDelete.Enabled = (count > 0 && permissionForDelete);
            toolStripMenuItemComposeWorkPackage.Enabled = count > 0 && permissionForUpdate;
            for (int i = 0; i < toolStripMenuItemsWorkPackages.Count; i++)
                toolStripMenuItemsWorkPackages[i].Enabled = count > 0 && permissionForUpdate;
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            MaintenanceSubCheckReportBuilder report = new MaintenanceSubCheckReportBuilder(subCheck, subCheck.JobCards);
            e.DisplayerText = ((Aircraft)subCheck.Parent.Parent.Parent).RegistrationNumber + ". " + subCheck.Name + ". Maintenance Job Cards Report";
            e.RequestedEntity = new DispatcheredMaintenanceSubCheckReport(report);
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;

        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (buttonAddJobCard != null && buttonJoinSubCheck != null && buttonEditJobCard != null && buttonCutOffSubCheck != null && buttonDeleteJobCard != null)
            {
                buttonDeleteJobCard.Location = new Point(Width - buttonDeleteJobCard.Width - 5, 0);
                buttonCutOffSubCheck.Location = new Point(buttonDeleteJobCard.Left - buttonCutOffSubCheck.Width - 5, 0);
                buttonEditJobCard.Location = new Point(buttonDeleteJobCard.Left - buttonCutOffSubCheck.Width - buttonEditJobCard.Width - 10, 0);
                buttonJoinSubCheck.Location = new Point(buttonDeleteJobCard.Left - buttonCutOffSubCheck.Width - buttonEditJobCard.Width - buttonJoinSubCheck.Width - 15, 0);
                buttonAddJobCard.Location = new Point(buttonDeleteJobCard.Left - buttonCutOffSubCheck.Width - buttonEditJobCard.Width - buttonJoinSubCheck.Width - buttonAddJobCard.Width - 20, 0);
                buttonSaveToDisk.Location = new Point(buttonAddJobCard.Left - buttonSaveToDisk.Width - 20, 0);
                buttonSaveToDisk.BringToFront();
            }
            if (listViewJobCards != null)
            {
                listViewJobCards.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                listViewJobCards.Size = new Size(Width, Height - headerControl.Height - footerControl.Height - panelTopContainer.Height);
            }
        }

        #endregion

        #region private void MaintenanceJobCardsCollectionScreen_Saving(object sender, CancelEventArgs e)

        private void MaintenanceJobCardsCollectionScreen_Saving(object sender, CancelEventArgs e)
        {
            editedJobCard = (JobCard) sender;
        }

        #endregion

        #region private void MaintenanceJobCardsCollectionScreen_Saved(object sender, EventArgs e)

        private void MaintenanceJobCardsCollectionScreen_Saved(object sender, EventArgs e)
        {
            listViewJobCards.EditItem(editedJobCard, (JobCard)sender);
        }

        #endregion

        #region private void MaintenanceJobCardsCollectionScreen_InitComplition(object sender, EventArgs e)

        private void MaintenanceJobCardsCollectionScreen_InitComplition(object sender, EventArgs e)
        {
            ((DispatcheredMultitabControl)sender).Closed += MaintenanceJobCardsCollectionScreen_Closed;
        }

        #endregion

        #region private void MaintenanceJobCardsCollectionScreen_Closed(object sender, AvMultitabControlEventArgs e)

        private void MaintenanceJobCardsCollectionScreen_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == (DispatcheredTabPage)Parent)
            {
                UnHookWorkPackageEvents();
                PerformEvents(false);
            }
        }

        #endregion

        #region private void PerformEvents(bool addTo)

        private void PerformEvents(bool addTo)
        {
            if (addTo)
            {
                subCheck.JobCardAdded += subCheck_JobCardAdded;
                subCheck.JobCardRemoved += subCheck_JobCardRemoved;
            }
            else
            {
                subCheck.JobCardAdded -= subCheck_JobCardAdded;
                subCheck.JobCardRemoved -= subCheck_JobCardRemoved;

            }
            List<JobCard> jobCards = new List<JobCard>(subCheck.JobCards);
            for (int i = 0; i < subCheck.JoinedSubChecks.Count; i++)
                jobCards.AddRange(subCheck.JoinedSubChecks[i].JobCards);
            for (int i = 0; i < jobCards.Count; i++)
            {
                HookJobCard(jobCards[i], addTo);
            }
        }

        #endregion

        #region private void HookJobCard(JobCard jobCard, bool addTo)

        private void HookJobCard(JobCard jobCard, bool addTo)
        {
            if (addTo)
            {
                jobCard.Saved += MaintenanceJobCardsCollectionScreen_Saved;
                jobCard.Saving += MaintenanceJobCardsCollectionScreen_Saving;
            }
            else
            {
                jobCard.Saved -= MaintenanceJobCardsCollectionScreen_Saved;
                jobCard.Saving -= MaintenanceJobCardsCollectionScreen_Saving;
            }
        }

        #endregion


        #region private void subCheck_JobCardAdded(object sender, CollectionChangeEventArgs e)

        private void subCheck_JobCardAdded(object sender, CollectionChangeEventArgs e)
        {
            JobCard jobCard = (JobCard) e.Element;
            listViewJobCards.AddNewItem(jobCard);
            HookJobCard(jobCard, true);
        }

        #endregion

        #region private void subCheck_JobCardRemoved(object sender, CollectionChangeEventArgs e)

        private void subCheck_JobCardRemoved(object sender, CollectionChangeEventArgs e)
        {
            listViewJobCards.DeleteItem((JobCard)e.Element);
        }

        #endregion

        #region private void HookWorkPackageEvents()

        private void HookWorkPackageEvents()
        {
            currentAircraft.WorkPackageAdded += CurrentAircraft_WorkPackagesChanged;
            currentAircraft.WorkPackageRemoved += CurrentAircraft_WorkPackagesChanged;
        }

        #endregion

        #region private void UnHookWorkPackageEvents()

        private void UnHookWorkPackageEvents()
        {
            currentAircraft.WorkPackageAdded -= CurrentAircraft_WorkPackagesChanged;
            currentAircraft.WorkPackageRemoved -= CurrentAircraft_WorkPackagesChanged;
        }

        #endregion

        #region private void CurrentAircraft_WorkPackagesChanged(object sender, CollectionChangeEventArgs e)

        private void CurrentAircraft_WorkPackagesChanged(object sender, CollectionChangeEventArgs e)
        {
            SetToolStripMenuItems();
        }

        #endregion

        #region protected void OnDisplayerRequested()
        /// <summary>
        /// 
        /// </summary>
        protected void OnDisplayerRequested(ReferenceEventArgs e)
        {
            if (null != DisplayerRequested)
            {
                DisplayerRequested(this, e);
            }
        }
        #endregion



        #region private void AddJobCard()

        private void AddJobCard()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Adobe PDF Files|*.pdf";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MaintenanceJobCardForm form = new MaintenanceJobCardForm(subCheck, dialog.FileName);
                //form.Saved += form_Saved;
                form.ShowDialog();
            }
        }

        #endregion

        #region private void SaveJobCardToFile()

        private void SaveJobCardToFile()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Adobe PDF Files|*.pdf";
            dialog.FileName = listViewJobCards.SelectedItem.AirlineCardNumber;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                UsefulMethods.SaveFileFromByteArray(listViewJobCards.SelectedItem.AttachedFile.FileData, dialog.FileName);
            }
        }

        #endregion

        #region private void DeleteJobCards()

        private void DeleteJobCards()
        {
            string message;
            if (listViewJobCards.SelectedItems.Count == 1)
                message = string.Format(new TermsProvider()["DeleteQuestion"].ToString(), "job card");
            else
                message = string.Format(new TermsProvider()["DeleteQuestionSeveral"].ToString(), "job cards");
            DialogResult result = MessageBox.Show(message, "Deleting confirmation", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {

                try
                {
                    for (int i = 0; i < listViewJobCards.SelectedItems.Count; i++)
                        subCheck.RemoveJobCard(listViewJobCards.SelectedItems[i]);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); 
                    return;
                }
                UpdateInformation();
            }
        }

        #endregion

        #region private void OpenJobCardProperties()

        private void OpenJobCardProperties()
        {
            MaintenanceJobCardForm form = new MaintenanceJobCardForm(listViewJobCards.SelectedItem);
            //form.Saved += form_Saved;
            form.ShowDialog();
        }

        #endregion

/*        #region private void form_Saved(JobCard jobCard)

        private void form_Saved(JobCard jobCard)
        {
            listViewJobCards.UpdateItems();
        }

        #endregion*/

        

        #region private void toolStripMenuItemOpen_Click(object sender, EventArgs e)

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            listViewJobCards.OnMouseDoubleClicked();
        }

        #endregion

        #region private void toolStripMenuItemSaveAs_Click(object sender, EventArgs e)

        private void toolStripMenuItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveJobCardToFile();
        }

        #endregion

        #region private void toolStripMenuItemAddNew_Click(object sender, EventArgs e)

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            AddJobCard();
        }

        #endregion

        #region private void WorkPackageItem_Click(object sender, EventArgs e)

        private void WorkPackageItem_Click(object sender, EventArgs e)
        {
            WorkPackage workPackage = (WorkPackage)((ToolStripMenuItem)sender).Tag;
            AddItemsToWorkPackage(workPackage);
        }

        #endregion

        #region private void toolStripMenuItemComposeWorkPackage_Click(object sender, EventArgs e)

        private void toolStripMenuItemComposeWorkPackage_Click(object sender, EventArgs e)
        {
            ComposeWorkPackage();
        }

        #endregion

        #region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            DeleteJobCards();
        }

        #endregion

        #region private void toolStripMenuItemProperties_Click(object sender, EventArgs e)

        private void toolStripMenuItemProperties_Click(object sender, EventArgs e)
        {
            OpenJobCardProperties();
        }

        #endregion

        #endregion

        #region IReference Members

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion
    }
}