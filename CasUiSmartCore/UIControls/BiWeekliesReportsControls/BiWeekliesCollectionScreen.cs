using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.OpepatorsControls;
using CAS.UI.UIControls.Auxiliary;
using Controls.AvButtonT;

namespace CAS.UI.UIControls.BiWeekliesReportsControls
{
    /// <summary>
    /// Скрин, для отображения Bi-Weekly-отчетов
    /// </summary>
    public class BiWeekliesCollectionScreen : Control, IReference
    {
        #region Fields

        private BiWeekliesCollection biWeekliesCollection;
        private readonly BiWeekliesListView listViewBiWeeklies = new BiWeekliesListView();
        private readonly HeaderControl headerControl = new HeaderControl();
        private readonly BiWeekliesHeaderControl biWeekliesHeaderControl = new BiWeekliesHeaderControl();
        private readonly FooterControl footerControl = new FooterControl();
        private readonly Panel mainPanel = new Panel();
        private readonly AvButtonT buttonAddReport = new AvButtonT();
        private readonly AvButtonT buttonSaveToFile = new AvButtonT();
        private readonly AvButtonT buttonDeleteReport = new AvButtonT();
        private readonly ReferenceLinkLabel linkOperators = new ReferenceLinkLabel();
        protected readonly List<Process> processes = new List<Process>();
        private readonly Icons icons = new Icons();
        private const int MARGIN = 10;
        private const int HEIGHT_INTERVAL = 10;
        private bool permissionForDelete = true;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem toolStripMenuItemOpen;
        private ToolStripMenuItem toolStripMenuItemSaveAs;
        private ToolStripMenuItem toolStripMenuItemAddNew;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuItemProperties;

        #endregion

        #region Construstor

        /// <summary>
        /// Создает скрин, для отображения Bi-Weekly-отчетов
        /// </summary>
        public BiWeekliesCollectionScreen()
        {
            InitializeComponent();
            DisplayItems();
        }

        #endregion

        #region Properties

        #region public BiWeekliesCollection BiWeekliesCollection

        /// <summary>
        /// Вовзращает или устанавливает коллекцию BiWeekly-отчетов
        /// </summary>
        public BiWeekliesCollection BiWeekliesCollection
        {
            get { return biWeekliesCollection; }
            set { biWeekliesCollection = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            BiWeekliesCollection = BiWeekliesCollection.Instance;
            BiWeekliesCollection.Changed += BiWeekliesCollection_Changed;
            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemOpen = new ToolStripMenuItem();
            toolStripMenuItemSaveAs = new ToolStripMenuItem();
            toolStripMenuItemAddNew = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemProperties = new ToolStripMenuItem();
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(179, 176);
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    toolStripMenuItemOpen,
                                                    toolStripMenuItemSaveAs,
                                                    toolStripMenuItemAddNew,
                                                    toolStripSeparator1,
                                                    toolStripMenuItemDelete,
                                                    toolStripSeparator2,
                                                    toolStripMenuItemProperties,
                                                });
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
            // listViewBiWeeklies
            //
            listViewBiWeeklies.Dock = DockStyle.Top;
            listViewBiWeeklies.ListViewBiWeeklies.ContextMenuStrip = contextMenuStrip;
            listViewBiWeeklies.SelectedItemsChanged += listViewBiWeeklies_SelectedItemsChanged;
            //
            // headerControl
            //
            headerControl.Controls.Add(biWeekliesHeaderControl);
            headerControl.ReloadRised += headerControl_ReloadRised;
            headerControl.EditDisplayerRequested += headerControl_EditDisplayerRequested;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "bi_weekly_reports";
            //
            // buttonAddReport
            //
            buttonAddReport.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddReport.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddReport.Icon = icons.Add;
            buttonAddReport.IconNotEnabled = icons.AddGray;
            buttonAddReport.Width = 150;
            buttonAddReport.TextMain = "Add Report";
            buttonAddReport.Click += buttonAddReport_Click;
            //
            // buttonSaveToFile
            //
            buttonSaveToFile.Enabled = false;
            buttonSaveToFile.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonSaveToFile.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonSaveToFile.Icon = icons.Save;
            buttonSaveToFile.IconNotEnabled = icons.SaveGray;
            buttonSaveToFile.Width = 150;
            buttonSaveToFile.TextMain = "Save to file";
            buttonSaveToFile.Click += buttonSaveToFile_Click;
            // 
            // buttonDeleteReport
            // 
            buttonDeleteReport.Enabled = false;
            buttonDeleteReport.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteReport.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteReport.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteReport.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteReport.Icon = icons.Delete;
            buttonDeleteReport.IconNotEnabled = icons.DeleteGray;
            buttonDeleteReport.Width = 150;
            buttonDeleteReport.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonDeleteReport.TextMain = "Delete";
            buttonDeleteReport.Click += buttonDeleteReport_Click;
            //
            // linkOperators
            //
            linkOperators.AutoSize = true;
            linkOperators.Location = new Point(950, 200);
            linkOperators.Font = Css.SimpleLink.Fonts.Font;
            linkOperators.ForeColor = Css.SimpleLink.Colors.LinkColor;
            linkOperators.Text = "Main Menu (Operators)";
            linkOperators.DisplayerRequested += linkOperators_DisplayerRequested;
            //
            // mainPanel
            //
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(listViewBiWeeklies);
            mainPanel.Controls.Add(buttonAddReport);
            mainPanel.Controls.Add(buttonSaveToFile);
            mainPanel.Controls.Add(buttonDeleteReport);

            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(mainPanel);
            Controls.Add(headerControl);
            Controls.Add(footerControl);
        }

        #endregion

        #region private void DisplayItems()

        private void DisplayItems()
        {
            try
            {
                BiWeekliesCollection.Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading data" + Environment.NewLine + ex.Message,
                                (string) new TermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            permissionForDelete = BiWeekliesCollection.HasPermission(Users.CurrentUser, DataEvent.Remove);
            buttonAddReport.Enabled = BiWeekliesCollection.HasPermission(Users.CurrentUser, DataEvent.Create);
            if (BiWeekliesCollection.HasPermission(Users.CurrentUser, DataEvent.Update))
                headerControl.ActionControl.ButtonEdit.TextMain = "Edit";
            else
                headerControl.ActionControl.ButtonEdit.TextMain = "View";
            listViewBiWeeklies.UpdateItems(BiWeekliesCollection);
        }

        #endregion

        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            DisplayItems();
        }

        #endregion

        #region private void headerControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)

        private void headerControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            OpenReportProperties();
            e.Cancel = true;
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
            listViewBiWeeklies.Height = Height - headerControl.Height - footerControl.Height - buttonAddReport.Height -
                                        HEIGHT_INTERVAL;
            buttonAddReport.Location = new Point(MARGIN, listViewBiWeeklies.Bottom + MARGIN);
            buttonSaveToFile.Location = new Point(buttonAddReport.Right, listViewBiWeeklies.Bottom + MARGIN);
            buttonDeleteReport.Location = new Point(buttonSaveToFile.Right, listViewBiWeeklies.Bottom + MARGIN);
        }

        #endregion

        #region protected void OnDisplayerRequested()

        /// <summary>
        /// </summary>
        protected void OnDisplayerRequested(ReferenceEventArgs e)
        {
            if (null != DisplayerRequested)
            {
                DisplayerRequested(this, e);
            }
        }

        #endregion

        #region private void buttonAddReport_Click(object sender, EventArgs e)

        private void buttonAddReport_Click(object sender, EventArgs e)
        {
            AddReport();
        }

        #endregion

        #region private void buttonSaveToFile_Click(object sender, EventArgs e)

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            SaveReportToFile();
        }

        #endregion

        #region private void buttonDeleteReport_Click(object sender, EventArgs e)

        private void buttonDeleteReport_Click(object sender, EventArgs e)
        {
            DeleteReports();
        }

        #endregion

        #region private void listViewBiWeeklies_SelectedItemsChanged(object sender, EventArgs e)

        private void listViewBiWeeklies_SelectedItemsChanged(object sender, EventArgs e)
        {
            int count = listViewBiWeeklies.SelectedItems.Count;
            buttonDeleteReport.Enabled = (count != 0 && permissionForDelete);
            buttonSaveToFile.Enabled = 
            headerControl.ActionControl.ButtonEdit.Enabled =
            toolStripMenuItemOpen.Enabled =
            toolStripMenuItemSaveAs.Enabled = 
            toolStripMenuItemProperties.Enabled = (count == 1);
            toolStripMenuItemDelete.Enabled = (count > 0 && permissionForDelete);
        }

        #endregion

        #region private void BiWeekliesCollection_Changed(object sender, EventArgs e)

        private void BiWeekliesCollection_Changed(object sender, EventArgs e)
        {
            DisplayItems();
        }

        #endregion

        #region private void linkOperators_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkOperators_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = "Operators";
            e.RequestedEntity = new DispatcheredOperatorCollectionScreen();
        }

        #endregion


        #region private void AddReport()

        private void AddReport()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Adobe PDF Files|*.pdf";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                BiWeeklyForm form = new BiWeeklyForm(dialog.FileName);
                form.Saved += form_Saved;
                form.ShowDialog();
            }
        }

        #endregion
        
        #region private void SaveReportToFile()

        private void SaveReportToFile()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Adobe PDF Files|*.pdf";
            dialog.FileName = listViewBiWeeklies.SelectedItem.ShortName;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                listViewBiWeeklies.SelectedItem.SaveReportToFile(dialog.FileName);
            }
        }

        #endregion

        #region private void DeleteReports()

        private void DeleteReports()
        {
            string message = "Are sure you want to delete this BiWeekly Report";
            string caption = "Confirm deleting";
            if (listViewBiWeeklies.SelectedItems.Count == 1)
            {
                message += "?";
                caption += " " + listViewBiWeeklies.SelectedItem.RealName;
            }
            else
                message += "s?";
            if (
                MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    List<BiWeekly> biWeekliesForRemoving = new List<BiWeekly>();
                    biWeekliesForRemoving.AddRange(listViewBiWeeklies.SelectedItems);
                    for (int i = 0; i < biWeekliesForRemoving.Count; i++)
                        BiWeekliesCollection.Instance.Remove(biWeekliesForRemoving[i]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting data" + Environment.NewLine + ex.Message,
                                    (string)new TermsProvider()["SystemName"],
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region private void OpenReportProperties()

        private void OpenReportProperties()
        {
            BiWeeklyForm form = new BiWeeklyForm(listViewBiWeeklies.SelectedItem);
            form.Saved += form_Saved;
            form.ShowDialog();
        }

        #endregion

        #region private void form_Saved(object sender, EventArgs e)

        private void form_Saved(object sender, EventArgs e)
        {
            listViewBiWeeklies.UpdateItems(BiWeekliesCollection);
        }

        #endregion


        #region private void toolStripMenuItemOpen_Click(object sender, EventArgs e)

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            listViewBiWeeklies.OnMouseDoubleClicked();
        }

        #endregion

        #region private void toolStripMenuItemSaveAs_Click(object sender, EventArgs e)

        private void toolStripMenuItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveReportToFile();
        }

        #endregion

        #region private void toolStripMenuItemAddNew_Click(object sender, EventArgs e)

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            AddReport();
        }

        #endregion

        #region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            DeleteReports();
        }

        #endregion

        #region private void toolStripMenuItemProperties_Click(object sender, EventArgs e)

        private void toolStripMenuItemProperties_Click(object sender, EventArgs e)
        {
            OpenReportProperties();
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