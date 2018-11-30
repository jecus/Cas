using System.Drawing;
using System.Windows.Forms;
using Controls;
using Controls.StatusImageLink;
using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.Core.Types.Dictionaries;
using LTR.UI.Appearance;
using LTR.UI.Management;
using LTR.UI.Management.Dispatchering;
using LTR.UI.Management.Dispatchering.DispatcheredUIControls;
using LTR.UI.Properties;
using LTR.UI.UIControls.AircraftsControls;
using LTR.UI.UIControls.Auxiliary;
using LTR.UI.UIControls.OpepatorsControls;
using LTR.UI.UIControls.ReferenceControls;

namespace LTR.UI.UIControls.DirectivesControls
{
    partial class DirectiveListViewer
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
            LTR.Core.Types.Aircrafts.Parts.Lifelength lifelength4 = new LTR.Core.Types.Aircrafts.Parts.Lifelength();
            panelTopContainer = new System.Windows.Forms.Panel();
            buttonDeleteSelected = new ReferenceAvButtonT();
            buttonApplyFilter = new ReferenceAvButtonT();
            buttonAddDirective = new LTR.UI.Management.Dispatchering.DispatcheredUIControls.ReferenceAvButtonT();
            labelDateAsOf = new Label();
            labelTitle = new StatusImageLinkLabel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelScrollContainer = new System.Windows.Forms.Panel();
            this.panelDirectiveColletionContainer = new System.Windows.Forms.Panel();
            
            
            this.footerControl1 = new LTR.UI.UIControls.Auxiliary.FooterControl();
            this.headerControl1 = new LTR.UI.UIControls.Auxiliary.HeaderControl();
            this.aircraftHeaderControl = new LTR.UI.UIControls.AircraftsControls.AircraftHeaderControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTopContainer.SuspendLayout();
            this.panelScrollContainer.SuspendLayout();
            this.headerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopContainer
            // 
            this.panelTopContainer.AutoSize = true;
            this.panelTopContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTopContainer.BackColor = System.Drawing.Color.LightGray;
            this.panelTopContainer.Controls.Add(this.panel1);
            this.panelTopContainer.Controls.Add(this.buttonDeleteSelected);
            this.panelTopContainer.Controls.Add(this.buttonApplyFilter);
            this.panelTopContainer.Controls.Add(this.buttonAddDirective);
            this.panelTopContainer.Controls.Add(labelDateAsOf);
            this.panelTopContainer.Controls.Add(labelTitle);
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
            buttonApplyFilter.Hoverable = true;
            buttonApplyFilter.Icon = Resources.ApplyFilterIcon;
            buttonApplyFilter.Location = new Point(600, 0);
            buttonApplyFilter.Size = new Size(170, 59);
            buttonApplyFilter.TabIndex = 19;
            buttonApplyFilter.TextMain = "Apply filter";
            buttonApplyFilter.Click += this.buttonApplyFilter_Click;
            // 
            // buttonAddDirective
            // 
            buttonAddDirective.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonAddDirective.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddDirective.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddDirective.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddDirective.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddDirective.Hoverable = true;
            buttonAddDirective.Icon = Resources.AddIcon;
            buttonAddDirective.Location = new Point(770, 0);
            buttonAddDirective.ReflectionType = ReflectionTypes.DisplayInNew;
            buttonAddDirective.Size = new Size(140, 59);
            buttonAddDirective.TabIndex = 15;
            buttonAddDirective.TextAlignMain = ContentAlignment.BottomCenter;
            buttonAddDirective.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddDirective.TextMain = "Add new";
            buttonAddDirective.TextSecondary = "directive";
            buttonAddDirective.DisplayerRequested += this.referenceAvalonButtonAddDirective_DisplayerRequested;
            // 
            // buttonDeleteSelected
            // 
            buttonDeleteSelected.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonDeleteSelected.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.Hoverable = true;
            buttonDeleteSelected.Icon = Resources.DeleteIcon;
            buttonDeleteSelected.Location = new Point(920, 0);
            buttonDeleteSelected.PaddingSecondary = new Padding(4, 0, 0, 0);
            buttonDeleteSelected.Size = new Size(170, 59);
            buttonDeleteSelected.TabIndex = 20;
            buttonDeleteSelected.TextAlignMain = ContentAlignment.BottomLeft;
            buttonDeleteSelected.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonDeleteSelected.TextMain = "Delete";
            buttonDeleteSelected.TextSecondary = "selected";
            // 
            // labelDateAsOf
            // 
            this.labelDateAsOf.AutoSize = true;
            this.labelDateAsOf.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDateAsOf.ForeColor = System.Drawing.Color.DimGray;
            this.labelDateAsOf.Location = new System.Drawing.Point(62, 30);
            this.labelDateAsOf.Name = "labelDateAsOf";
            this.labelDateAsOf.Size = new System.Drawing.Size(47, 19);
            this.labelDateAsOf.TabIndex = 21;
            this.labelDateAsOf.Text = "Date as of: ";
            // 
            // labelTitle
            // 
            this.labelTitle.ActiveLinkColor = System.Drawing.Color.Black;
            this.labelTitle.Enabled = false;
            this.labelTitle.HoveredLinkColor = System.Drawing.Color.Black;
            this.labelTitle.ImageBackColor = System.Drawing.Color.Transparent;
            this.labelTitle.ImageLayout = ImageLayout.Center;
            this.labelTitle.LinkColor = System.Drawing.Color.DimGray;
            this.labelTitle.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.labelTitle.Location = new System.Drawing.Point(28, 3);
            this.labelTitle.Margin = new Padding(0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(412, 27);
            this.labelTitle.TabIndex = 16;
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitle.TextFont = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 62);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1042, 0);
            this.panelMain.TabIndex = 15;
            // 
            // panelScrollContainer
            // 
            this.panelScrollContainer.AutoScroll = true;
            this.panelScrollContainer.Controls.Add(this.panelDirectiveColletionContainer);
            this.panelScrollContainer.Controls.Add(this.panelMain);
            this.panelScrollContainer.Controls.Add(this.panelTopContainer);
            this.panelScrollContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScrollContainer.Location = new System.Drawing.Point(0, 58);
            this.panelScrollContainer.Name = "panelScrollContainer";
            this.panelScrollContainer.Size = new System.Drawing.Size(1042, 510);
            this.panelScrollContainer.TabIndex = 0;
            // 
            // panelDirectiveColletionContainer
            // 
            this.panelDirectiveColletionContainer.AutoSize = true;
            this.panelDirectiveColletionContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDirectiveColletionContainer.Location = new System.Drawing.Point(0, 62);
            this.panelDirectiveColletionContainer.MinimumSize = new System.Drawing.Size(40, 40);
            this.panelDirectiveColletionContainer.Name = "panelDirectiveColletionContainer";
            this.panelDirectiveColletionContainer.Size = new System.Drawing.Size(1042, 40);
            this.panelDirectiveColletionContainer.TabIndex = 17;
            //
            // lifelength4
            //
            lifelength4.Applicable = false;
            lifelength4.Calendar = System.TimeSpan.Parse("00:00:00");
            lifelength4.Cycles = 0;
            lifelength4.Hours = System.TimeSpan.Parse("00:00:00");
            lifelength4.IsCalendarApplicable = false;
            lifelength4.IsCyclesApplicable = false;
            lifelength4.IsHoursApplicable = false;
            // 
            // footerControl1
            // 
            this.footerControl1.AutoSize = true;
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
            this.headerControl1.BackColor = System.Drawing.Color.Transparent;
            this.headerControl1.BackgroundImage = global::LTR.UI.Properties.Resources.HeaderBar;
            this.headerControl1.Controls.Add(this.aircraftHeaderControl);
            this.headerControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerControl1.EditDisplayerText = "Edit operator";
            this.headerControl1.ContextActionControl.ShowPrintButton = true;
            this.headerControl1.ContextActionControl.PrintButton.DisplayerRequested += new System.EventHandler<LTR.UI.Interfaces.ReferenceEventArgs>(this.ButtonPrint_DisplayerRequested);
            this.headerControl1.ButtonEdit.Visible = false;
            this.headerControl1.EditReflectionType = LTR.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.headerControl1.Location = new System.Drawing.Point(0, 0);
            this.headerControl1.Name = "headerControl1";
            this.headerControl1.Size = new System.Drawing.Size(1042, 58);
            this.headerControl1.TabIndex = 6;
            this.headerControl1.TopicID = "Detail info";
            this.headerControl1.EditDisplayerRequested += new System.EventHandler<LTR.UI.Interfaces.ReferenceEventArgs>(this.ButtonPrint_DisplayerRequested);
            this.headerControl1.ReloadRised += new System.EventHandler(this.ButtonReload_ReloadRised);
            // 
            // aircraftHeaderControl
            // 
            this.aircraftHeaderControl.Aircraft = null;
            this.aircraftHeaderControl.AircraftClickable = true;
            this.aircraftHeaderControl.BackColor = System.Drawing.Color.Transparent;
            this.aircraftHeaderControl.Displayer = null;
            this.aircraftHeaderControl.DisplayerText = "Aircraft";
            this.aircraftHeaderControl.Entity = null;
            this.aircraftHeaderControl.Location = new System.Drawing.Point(0, 0);
            this.aircraftHeaderControl.Name = "aircraftHeaderControl";
            this.aircraftHeaderControl.Operator = null;
            this.aircraftHeaderControl.OperatorClickable = true;
            this.aircraftHeaderControl.ReflectionType = LTR.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.aircraftHeaderControl.Size = new System.Drawing.Size(381, 58);
            this.aircraftHeaderControl.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 1);
            this.panel1.TabIndex = 22;
            // 
            // DirectiveListViewer
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.panelScrollContainer);
            this.Controls.Add(this.footerControl1);
            this.Controls.Add(this.headerControl1);
            this.Name = "DirectiveListViewer";
            this.Size = new System.Drawing.Size(1042, 616);
            this.panelTopContainer.ResumeLayout(false);
            this.panelTopContainer.PerformLayout();
            this.panelScrollContainer.ResumeLayout(false);
            this.panelScrollContainer.PerformLayout();
            this.headerControl1.ResumeLayout(false);
            this.headerControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private HeaderControl headerControl1;
        private FooterControl footerControl1;
        private AircraftHeaderControl aircraftHeaderControl;
        protected Panel panelTopContainer;
        protected Panel panelMain;
        private Panel panelScrollContainer;
        private Panel panelDirectiveColletionContainer;
        private ReferenceAvButtonT buttonApplyFilter;
        private ReferenceAvButtonT buttonAddDirective;
        private ReferenceAvButtonT buttonDeleteSelected;
        private Label labelDateAsOf;
        private StatusImageLinkLabel labelTitle;
        private Panel panel1;
    }
}