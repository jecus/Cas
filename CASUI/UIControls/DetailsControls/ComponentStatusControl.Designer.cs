using System.Drawing;
using System.Windows.Forms;
using Controls.AvButtonT;
using LTR.Core;
using LTR.UI.Appearance;
using LTR.UI.Management;
using LTR.UI.Management.Dispatchering;
using LTR.UI.Properties;
using LTR.UI.UIControls.AircraftsControls;
using LTR.UI.UIControls.Auxiliary;
using LTR.UI.UIControls.DetailsControls.FilterControls;
using LTR.UI.UIControls.OpepatorsControls;
using LTR.UI.UIControls.ReferenceControls;

namespace LTR.UI.UIControls.DetailsControls
{
    partial class ComponentStatusControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region private void InitializeComponent()
        private void InitializeComponent()
        {
            this.panelTopContainer = new System.Windows.Forms.Panel();
            panelBottomContainer = new Panel();
            this.buttonDeleteSelected = new AvButtonT();
            this.buttonApplyFilter = new AvButtonT();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAddDetail = new ReferenceAvButtonT();
            this.footerControl1 = new LTR.UI.UIControls.Auxiliary.FooterControl();
            this.headerControl1 = new LTR.UI.UIControls.Auxiliary.HeaderControl();
            this.aircraftHeaderControl = new AircraftHeaderControl();
            this.statusImageLinkLabel1 = new Controls.StatusImageLink.StatusImageLinkLabel();
            this.labelDate = new System.Windows.Forms.Label();
            labelTotal = new Label();
            this.panelTopContainer.SuspendLayout();
            this.headerControl1.SuspendLayout();
            this.SuspendLayout();

            #region Context menu
            this.contextMenuStrip1 = new ContextMenuStrip();
            this.toolStripMenuItemTitle = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.toolStripMenuItemAdd = new ToolStripMenuItem();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.toolStripMenuItemOverhaul = new ToolStripMenuItem();
            this.toolStripMenuItemInspection = new ToolStripMenuItem();
            this.toolStripMenuItemShopVisit = new ToolStripMenuItem();
            this.toolStripMenuItemHotSectionInspection = new ToolStripMenuItem();
            this.toolStripSeparator3 = new ToolStripSeparator();
            this.toolStripMenuItemDelete = new ToolStripMenuItem();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[]
                                                 {
                                                     toolStripMenuItemTitle,
                                                     toolStripSeparator1,
                                                     toolStripMenuItemAdd,
                                                     toolStripSeparator2,
                                                     toolStripMenuItemOverhaul,
                                                     toolStripMenuItemInspection,
                                                     toolStripMenuItemShopVisit,
                                                     toolStripMenuItemHotSectionInspection,
                                                     toolStripSeparator3,
                                                     toolStripMenuItemDelete
                                                 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(179, 176);
            // 
            // toolStripMenuItemTitle
            // 
            toolStripMenuItemTitle.Name = "toolStripMenuItemTitle";
            toolStripMenuItemTitle.Size = new Size(178, 22);
            toolStripMenuItemTitle.Text = "Component";
            toolStripMenuItemTitle.Click += new System.EventHandler(toolStripMenuItemEdit_Click);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(175, 6);
            // 
            // toolStripMenuItemAdd
            // 
            toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            toolStripMenuItemAdd.Size = new Size(178, 22);
            toolStripMenuItemAdd.Text = "Add Component ";
            toolStripMenuItemAdd.Click += new System.EventHandler(toolStripMenuItemAdd_Click);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(175, 6);
            // 
            // toolStripMenuItemOverhaul
            // 
            toolStripMenuItemOverhaul.Name = "toolStripMenuItemPerform";
            toolStripMenuItemOverhaul.Size = new Size(178, 22);
            toolStripMenuItemOverhaul.Text = "Register Overhaul";
            toolStripMenuItemOverhaul.Click += new System.EventHandler(toolStripMenuItemOverhaul_Click);
            // 
            // toolStripMenuItemInspection
            // 
            toolStripMenuItemInspection.Name = "toolStripMenuItemClose";
            toolStripMenuItemInspection.Size = new Size(178, 22);
            toolStripMenuItemInspection.Text = "Register Inspection";
            toolStripMenuItemInspection.Click += new System.EventHandler(toolStripMenuItemInspection_Click);
            // 
            // toolStripMenuItemHotSectionInspection
            // 
            toolStripMenuItemHotSectionInspection.Name = "toolStripMenuItemClose";
            toolStripMenuItemHotSectionInspection.Size = new Size(178, 22);
            toolStripMenuItemHotSectionInspection.Text = "Register HotSectionInspection";
            toolStripMenuItemHotSectionInspection.Click +=
                new System.EventHandler(toolStripMenuItemHotSectionInspection_Click);
            // 
            // toolStripMenuItemShopVisit
            // 
            toolStripMenuItemShopVisit.Name = "toolStripMenuItemClose";
            toolStripMenuItemShopVisit.Size = new Size(178, 22);
            toolStripMenuItemShopVisit.Text = "Register ShopVisit";
            toolStripMenuItemShopVisit.Click += new System.EventHandler(toolStripMenuItemShopVisit_Click);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(175, 6);
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            toolStripMenuItemDelete.Size = new System.Drawing.Size(178, 22);
            toolStripMenuItemDelete.Text = "Delete";
            toolStripMenuItemDelete.Click += new System.EventHandler(toolStripMenuItemDelete_Click);
            #endregion

            // 
            // panelTopContainer
            // 
            this.panelTopContainer.AutoSize = true;
            this.panelTopContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTopContainer.BackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (211)))), ((int) (((byte) (211)))),
                                              ((int) (((byte) (211)))));
            this.panelTopContainer.Controls.Add(this.labelTotal);
            this.panelTopContainer.Controls.Add(this.labelDate);
            this.panelTopContainer.Controls.Add(this.statusImageLinkLabel1);
            this.panelTopContainer.Controls.Add(this.panel1);
            this.panelTopContainer.Controls.Add(this.buttonDeleteSelected);
            this.panelTopContainer.Controls.Add(this.buttonApplyFilter);
            this.panelTopContainer.Controls.Add(this.buttonAddDetail);

            this.panelTopContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopContainer.Location = new System.Drawing.Point(0, 0);
            this.panelTopContainer.Name = "panelTopContainer";
            this.panelTopContainer.Size = new System.Drawing.Size(1042, 62);
            this.panelTopContainer.TabIndex = 14;


            // 
            // buttonApplyFilter
            // 
            buttonApplyFilter.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonApplyFilter.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonApplyFilter.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonApplyFilter.Icon = icons.ApplyFilter;

            buttonApplyFilter.Size = new Size(145, 59);

            buttonApplyFilter.TabIndex = 19;
            buttonApplyFilter.TextMain = "Apply filter";
            buttonApplyFilter.Click += this.buttonApplyFilter_Click;
            // 
            // buttonAddDetail
            // 
            buttonAddDetail.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonAddDetail.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddDetail.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddDetail.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddDetail.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddDetail.Icon = icons.Add;
            buttonAddDetail.ReflectionType = ReflectionTypes.DisplayInNew;
            buttonAddDetail.Size = new Size(152, 59);
            buttonAddDetail.TabIndex = 15;
            buttonAddDetail.TextAlignMain = ContentAlignment.BottomCenter;
            buttonAddDetail.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddDetail.TextMain = "Add new";
            buttonAddDetail.TextSecondary = "component";
            buttonAddDetail.DisplayerRequested += this.buttonAddDetail_DisplayerRequested;
            // 
            // buttonDeleteSelected
            // 
            buttonDeleteSelected.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonDeleteSelected.Enabled = false;
            buttonDeleteSelected.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.Icon = icons.Delete;
            buttonDeleteSelected.PaddingSecondary = new Padding(4, 0, 0, 0);
            buttonDeleteSelected.Size = new Size(145, 59);

            buttonDeleteSelected.TabIndex = 20;
            buttonDeleteSelected.TextAlignMain = ContentAlignment.BottomLeft;
            buttonDeleteSelected.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonDeleteSelected.TextMain = "Delete";
            buttonDeleteSelected.TextSecondary = "selected";
            buttonDeleteSelected.Click += this.buttonDeleteSelected_Click;
            // 
            // panel1
            // 
            this.panel1.BackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (241)))), ((int) (((byte) (241)))),
                                              ((int) (((byte) (241)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 1);
            this.panel1.TabIndex = 20;
            // 
            // footerControl1
            // 
            this.footerControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.footerControl1.BackColor = System.Drawing.Color.Transparent;
            this.footerControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerControl1.Location = new System.Drawing.Point(0, 568);
            this.footerControl1.Margin = new System.Windows.Forms.Padding(0);
            this.footerControl1.MaximumSize = new System.Drawing.Size(0, 48);
            this.footerControl1.MinimumSize = new System.Drawing.Size(0, 48);
            this.footerControl1.Name = "footerControl1";
            this.footerControl1.Size = new System.Drawing.Size(1042, 48);
            this.footerControl1.TabIndex = 10;
            // 
            // headerControl1
            // 
            this.headerControl1.ActionControlSplitterVisible = true;
            this.headerControl1.ActionControl.ButtonEdit.Enabled = false;
            this.headerControl1.ContextActionControl.ShowPrintButton = true;
            this.headerControl1.BackColor = System.Drawing.Color.Transparent;
            headerControl1.BackgroundImage = global::LTR.UI.Properties.Resources.HeaderBar;
            headerControl1.Controls.Add(this.aircraftHeaderControl);
            headerControl1.Dock = DockStyle.Top;
            this.headerControl1.EditDisplayerText = "Component Status Operator";
            this.headerControl1.EditReflectionType = LTR.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.headerControl1.EditDisplayerRequested += headerControl1_EditDisplayerRequested;
            this.headerControl1.Location = new System.Drawing.Point(0, 0);
            this.headerControl1.Name = "headerControl1";
            this.headerControl1.Size = new System.Drawing.Size(1042, 58);
            this.headerControl1.TabIndex = 6;
            this.headerControl1.ContextActionControl.ButtonPrint.DisplayerRequested +=
                new System.EventHandler<LTR.UI.Interfaces.ReferenceEventArgs>(PrintButton_DisplayerRequested);
            this.headerControl1.ReloadRised += new System.EventHandler(this.headerControl1_ReloadRised);
            // 
            // aircraftHeaderControl
            // 
            this.aircraftHeaderControl.Aircraft = null;
            this.aircraftHeaderControl.AircraftClickable = true;
            this.aircraftHeaderControl.BackColor = System.Drawing.Color.Transparent;
            this.aircraftHeaderControl.Location = new System.Drawing.Point(0, 0);
            this.aircraftHeaderControl.Name = "aircraftHeaderControl";
            this.aircraftHeaderControl.OperatorClickable = true;
            this.aircraftHeaderControl.Size = new System.Drawing.Size(381, 58);
            // 
            // statusImageLinkLabel1
            // 
            this.statusImageLinkLabel1.ActiveLinkColor = System.Drawing.Color.Black;
            this.statusImageLinkLabel1.Enabled = false;
            this.statusImageLinkLabel1.HoveredLinkColor = System.Drawing.Color.Black;
            this.statusImageLinkLabel1.ImageBackColor = System.Drawing.Color.Transparent;
            this.statusImageLinkLabel1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.statusImageLinkLabel1.LinkColor = System.Drawing.Color.DimGray;
            this.statusImageLinkLabel1.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.statusImageLinkLabel1.Location = new System.Drawing.Point(28, 3);
            this.statusImageLinkLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.statusImageLinkLabel1.Name = "statusImageLinkLabel1";
            this.statusImageLinkLabel1.Size = new System.Drawing.Size(412, 27);
            this.statusImageLinkLabel1.TabIndex = 16;
            this.statusImageLinkLabel1.Text = "Component Status";
            this.statusImageLinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusImageLinkLabel1.TextFont =
                new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular,
                                        System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font =
                new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular,
                                        System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.labelDate.ForeColor = System.Drawing.Color.DimGray;
            this.labelDate.Location = new System.Drawing.Point(57, 30);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(47, 19);
            this.labelDate.TabIndex = 21;
            this.labelDate.Text = "Date as of: ";
            //
            // 
            //
            labelTotal.AutoSize = true;
            labelTotal.Font = Css.SmallHeader.Fonts.RegularFont;
            labelTotal.ForeColor = Css.SmallHeader.Colors.ForeColor;
            labelTotal.Dock = DockStyle.Right;
            labelTotal.Name = "labelTotal";
            labelTotal.Padding = new Padding(0, 5, 25, 0);
            labelTotal.Size = new System.Drawing.Size(47, 19);
            labelTotal.TabIndex = 21;
            labelTotal.Text = "Total: ";

            panelBottomContainer.Dock = DockStyle.Bottom;
            panelBottomContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            panelBottomContainer.Name = "panelBottomContainer";
            panelBottomContainer.Size = new Size(Width, 25);
            panelBottomContainer.Controls.Add(labelTotal);
            // 
            // ComponentStatusControl
            // 

            this.BackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (241)))), ((int) (((byte) (241)))),
                                              ((int) (((byte) (241)))));
            Controls.Add(panelBottomContainer);
            Controls.Add(footerControl1);
            Controls.Add(panelTopContainer);
            Controls.Add(headerControl1);
            this.Name = "ComponentStatusControl";
            this.Size = new System.Drawing.Size(1042, 616);
            this.panelTopContainer.ResumeLayout(false);
            this.panelTopContainer.PerformLayout();
            this.headerControl1.ResumeLayout(false);
            this.headerControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItemTitle;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItemAdd;
        private ToolStripMenuItem toolStripMenuItemOverhaul;
        private ToolStripMenuItem toolStripMenuItemInspection;
        private ToolStripMenuItem toolStripMenuItemShopVisit;
        private ToolStripMenuItem toolStripMenuItemHotSectionInspection;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem toolStripMenuItemDelete;

        private HeaderControl headerControl1;
        private FooterControl footerControl1;
        private AircraftHeaderControl aircraftHeaderControl;
        /// <summary>
        /// Панель содержащая кнопки управления
        /// </summary>
        protected Panel panelTopContainer;
        /// <summary>
        /// Панель содержащая общее количество отображаемых элементов
        /// </summary>
        protected Panel panelBottomContainer;
        private ReferenceAvButtonT buttonAddDetail;
        private AvButtonT buttonApplyFilter;
        private AvButtonT buttonDeleteSelected;
        private Panel panel1;
        private Label labelDate;
        private Label labelTotal;
        private Controls.StatusImageLink.StatusImageLinkLabel statusImageLinkLabel1;
    }
}
