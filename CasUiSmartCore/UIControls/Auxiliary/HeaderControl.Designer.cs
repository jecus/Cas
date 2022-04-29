using CASTerms;

using Entity.Abstractions;
namespace CAS.UI.UIControls.Auxiliary
{
    partial class HeaderControl
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

            if(disposing)
            {
                if (_currentDisplayer != null)
                    _currentDisplayer.CountScreenChanget -= CurrentDisplayerScreenChanget;
                
                buttonPrint.DisplayerRequested -= this.ButtonPrintDisplayerRequested;
            
                EditButtonClick = null;
                ForecastContextMenuClick = null;
                PrintButtonDisplayerRequested = null;
                SaveButtonClick = null;
                SaveButtonDisplayerRequested = null;
                SaveButton2Click = null;
                ReloadButtonClick = null;
            }
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
	        var userType = GlobalObjects.CasEnvironment?.IdentityUser.UserType ?? GlobalObjects.CaaEnvironment?.IdentityUser.UserType;
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCloseTab = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.pictureBoxH = new System.Windows.Forms.PictureBox();
            this.buttonHelp = new CAS.UI.Management.Dispatchering.HelpRequestingButtonT();
            this.pictureBoxP = new System.Windows.Forms.PictureBox();
            this.buttonPrint = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.pictureBoxF = new System.Windows.Forms.PictureBox();
            this.forecastControl = new CAS.UI.UIControls.Auxiliary.ForecastControl();
            this.pictureBoxS2 = new System.Windows.Forms.PictureBox();
            this.richReferenceButtonSave2 = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.pictureBoxS = new System.Windows.Forms.PictureBox();
            this.richReferenceButtonSave = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.pictureBoxE = new System.Windows.Forms.PictureBox();
            this.richReferenceButtonEdit = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.avButtonReload = new AvControls.AvButtonT.AvButtonT();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.buttonCloseTab);
            this.flowLayoutPanel1.Controls.Add(this.pictureBoxH);
            this.flowLayoutPanel1.Controls.Add(this.buttonHelp);
            this.flowLayoutPanel1.Controls.Add(this.pictureBoxP);
            this.flowLayoutPanel1.Controls.Add(this.buttonPrint);
            this.flowLayoutPanel1.Controls.Add(this.pictureBoxF);
            this.flowLayoutPanel1.Controls.Add(this.forecastControl);
            this.flowLayoutPanel1.Controls.Add(this.pictureBoxS2);
            this.flowLayoutPanel1.Controls.Add(this.richReferenceButtonSave2);
            this.flowLayoutPanel1.Controls.Add(this.pictureBoxS);
            this.flowLayoutPanel1.Controls.Add(this.richReferenceButtonSave);
            this.flowLayoutPanel1.Controls.Add(this.pictureBoxE);
            this.flowLayoutPanel1.Controls.Add(this.richReferenceButtonEdit);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
            this.flowLayoutPanel1.Controls.Add(this.avButtonReload);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(560, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(668, 71);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // buttonCloseTab
            // 
            this.buttonCloseTab.ActiveBackColor = System.Drawing.Color.Transparent;
            this.buttonCloseTab.ActiveBackgroundImage = global::CAS.UI.Properties.Resources.HeaderBarClicked;
            this.buttonCloseTab.BackColor = System.Drawing.Color.Transparent;
            this.buttonCloseTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCloseTab.Displayer = null;
            this.buttonCloseTab.DisplayerText = null;
            this.buttonCloseTab.Entity = null;
            this.buttonCloseTab.FontMain = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel);
            this.buttonCloseTab.FontSecondary = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonCloseTab.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonCloseTab.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.buttonCloseTab.Icon = global::CAS.UI.Properties.Resources.CloseIcon;
            this.buttonCloseTab.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCloseTab.IconNotEnabled = global::CAS.UI.Properties.Resources.CloseIcon_gray;
            this.buttonCloseTab.Location = new System.Drawing.Point(598, 0);
            this.buttonCloseTab.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCloseTab.Name = "buttonCloseTab";
            this.buttonCloseTab.NormalBackgroundImage = null;
            this.buttonCloseTab.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonCloseTab.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonCloseTab.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.CloseSelected;
            this.buttonCloseTab.ShowToolTip = true;
            this.buttonCloseTab.Size = new System.Drawing.Size(70, 70);
            this.buttonCloseTab.TabIndex = 23;
            this.buttonCloseTab.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCloseTab.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
            this.buttonCloseTab.TextMain = "";
            this.buttonCloseTab.TextSecondary = "";
            this.buttonCloseTab.ToolTipText = "Close Tab";
            // 
            // pictureBoxH
            // 
            this.pictureBoxH.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
            this.pictureBoxH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxH.Location = new System.Drawing.Point(584, 4);
            this.pictureBoxH.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxH.Name = "pictureBoxH";
            this.pictureBoxH.Size = new System.Drawing.Size(10, 62);
            this.pictureBoxH.TabIndex = 24;
            this.pictureBoxH.TabStop = false;
            this.pictureBoxH.Visible = false;
            // 
            // buttonHelp
            // 
            this.buttonHelp.ActiveBackColor = System.Drawing.Color.Transparent;
            this.buttonHelp.ActiveBackgroundImage = global::CAS.UI.Properties.Resources.HeaderBarClicked;
            this.buttonHelp.BackColor = System.Drawing.Color.Transparent;
            this.buttonHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHelp.FontMain = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel);
            this.buttonHelp.FontSecondary = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonHelp.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonHelp.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.buttonHelp.Icon = global::CAS.UI.Properties.Resources.HelpIcon;
            this.buttonHelp.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonHelp.IconNotEnabled = global::CAS.UI.Properties.Resources.HelpIcon_gray;
            this.buttonHelp.Location = new System.Drawing.Point(510, 0);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(0);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.NormalBackgroundImage = null;
            this.buttonHelp.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonHelp.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonHelp.ShowToolTip = true;
            this.buttonHelp.Size = new System.Drawing.Size(70, 70);
            this.buttonHelp.TabIndex = 22;
            this.buttonHelp.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
            this.buttonHelp.TextMain = "";
            this.buttonHelp.TextSecondary = "";
            this.buttonHelp.ToolTipText = "Help";
            this.buttonHelp.TopicId = null;
            this.buttonHelp.Visible = false;
            // 
            // pictureBoxP
            // 
            this.pictureBoxP.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
            this.pictureBoxP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxP.Location = new System.Drawing.Point(499, 4);
            this.pictureBoxP.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxP.Name = "pictureBoxP";
            this.pictureBoxP.Size = new System.Drawing.Size(7, 62);
            this.pictureBoxP.TabIndex = 25;
            this.pictureBoxP.TabStop = false;
            this.pictureBoxP.Visible = false;
            // 
            // buttonPrint
            // 
            this.buttonPrint.ActiveBackColor = System.Drawing.Color.Transparent;
            this.buttonPrint.ActiveBackgroundImage = global::CAS.UI.Properties.Resources.HeaderBarClicked;
            this.buttonPrint.BackColor = System.Drawing.Color.Transparent;
            this.buttonPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrint.Displayer = null;
            this.buttonPrint.DisplayerText = null;
            this.buttonPrint.Entity = null;
            this.buttonPrint.FontMain = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel);
            this.buttonPrint.FontSecondary = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonPrint.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonPrint.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.buttonPrint.Icon = global::CAS.UI.Properties.Resources.PrintIcon;
            this.buttonPrint.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonPrint.IconNotEnabled = global::CAS.UI.Properties.Resources.PrintIcon_gray;
            this.buttonPrint.Location = new System.Drawing.Point(425, 0);
            this.buttonPrint.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.NormalBackgroundImage = null;
            this.buttonPrint.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonPrint.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonPrint.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.buttonPrint.ShowToolTip = true;
            this.buttonPrint.Size = new System.Drawing.Size(70, 70);
            this.buttonPrint.TabIndex = 21;
            this.buttonPrint.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPrint.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
            this.buttonPrint.TextMain = "";
            this.buttonPrint.TextSecondary = "";
            this.buttonPrint.ToolTipText = "Print Priview";
            this.buttonPrint.Visible = false;
            this.buttonPrint.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ButtonPrintDisplayerRequested);
            // 
            // pictureBoxF
            // 
            this.pictureBoxF.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
            this.pictureBoxF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxF.Location = new System.Drawing.Point(414, 4);
            this.pictureBoxF.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxF.Name = "pictureBoxF";
            this.pictureBoxF.Size = new System.Drawing.Size(7, 62);
            this.pictureBoxF.TabIndex = 16;
            this.pictureBoxF.TabStop = false;
            this.pictureBoxF.Visible = false;
            // 
            // forecastControl
            // 
            this.forecastControl.Displayer = null;
            this.forecastControl.DisplayerText = null;
            this.forecastControl.Entity = null;
            this.forecastControl.Location = new System.Drawing.Point(340, 0);
            this.forecastControl.Margin = new System.Windows.Forms.Padding(0);
            this.forecastControl.Name = "forecastControl";
            this.forecastControl.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.forecastControl.ShowNoForecastMenuItem = true;
            this.forecastControl.Size = new System.Drawing.Size(70, 70);
            this.forecastControl.TabIndex = 12;
            this.forecastControl.Visible = false;
            this.forecastControl.MenuClick += new System.EventHandler(this.ButtonForecatMenuClick);
            // 
            // pictureBoxS2
            // 
            this.pictureBoxS2.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
            this.pictureBoxS2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxS2.Location = new System.Drawing.Point(329, 4);
            this.pictureBoxS2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxS2.Name = "pictureBoxS2";
            this.pictureBoxS2.Size = new System.Drawing.Size(7, 62);
            this.pictureBoxS2.TabIndex = 20;
            this.pictureBoxS2.TabStop = false;
            this.pictureBoxS2.Visible = false;
            // 
            // richReferenceButtonSave2
            // 
            this.richReferenceButtonSave2.ActiveBackColor = System.Drawing.Color.Transparent;
            this.richReferenceButtonSave2.ActiveBackgroundImage = null;
            this.richReferenceButtonSave2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richReferenceButtonSave2.Displayer = null;
            this.richReferenceButtonSave2.DisplayerText = "";
            this.richReferenceButtonSave2.Entity = null;
            this.richReferenceButtonSave2.FontMain = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel);
            this.richReferenceButtonSave2.FontSecondary = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.richReferenceButtonSave2.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.richReferenceButtonSave2.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.richReferenceButtonSave2.Icon = global::CAS.UI.Properties.Resources.SaveAndAddIcon;
            this.richReferenceButtonSave2.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.richReferenceButtonSave2.IconNotEnabled = global::CAS.UI.Properties.Resources.SaveAndAddIcon_gray;
            this.richReferenceButtonSave2.Location = new System.Drawing.Point(255, 0);
            this.richReferenceButtonSave2.Margin = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonSave2.Name = "richReferenceButtonSave2";
            this.richReferenceButtonSave2.NormalBackgroundImage = null;
            this.richReferenceButtonSave2.PaddingMain = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonSave2.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonSave2.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.richReferenceButtonSave2.ShowToolTip = true;
            this.richReferenceButtonSave2.Size = new System.Drawing.Size(70, 70);
            this.richReferenceButtonSave2.TabIndex = 19;
            this.richReferenceButtonSave2.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
            this.richReferenceButtonSave2.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.richReferenceButtonSave2.TextMain = "";
            this.richReferenceButtonSave2.TextSecondary = "";
            this.richReferenceButtonSave2.ToolTipText = "Save And Add Another";
            this.richReferenceButtonSave2.Visible = false;
            this.richReferenceButtonSave2.Click += new System.EventHandler(this.ButtonSave2Click);
            this.richReferenceButtonSave2.Enabled = !(userType == UserType.ReadOnly);
			// 
			// pictureBoxS
			// 
			this.pictureBoxS.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
            this.pictureBoxS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxS.Location = new System.Drawing.Point(244, 4);
            this.pictureBoxS.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxS.Name = "pictureBoxS";
            this.pictureBoxS.Size = new System.Drawing.Size(7, 62);
            this.pictureBoxS.TabIndex = 14;
            this.pictureBoxS.TabStop = false;
            this.pictureBoxS.Visible = false;
            // 
            // richReferenceButtonSave
            // 
            this.richReferenceButtonSave.ActiveBackColor = System.Drawing.Color.Transparent;
            this.richReferenceButtonSave.ActiveBackgroundImage = null;
            this.richReferenceButtonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richReferenceButtonSave.Displayer = null;
            this.richReferenceButtonSave.DisplayerText = "";
            this.richReferenceButtonSave.Entity = null;
            this.richReferenceButtonSave.FontMain = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel);
            this.richReferenceButtonSave.FontSecondary = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.richReferenceButtonSave.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.richReferenceButtonSave.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.richReferenceButtonSave.Icon = global::CAS.UI.Properties.Resources.SaveIcon;
            this.richReferenceButtonSave.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.richReferenceButtonSave.IconNotEnabled = global::CAS.UI.Properties.Resources.SaveIcon_gray;
            this.richReferenceButtonSave.Location = new System.Drawing.Point(170, 0);
            this.richReferenceButtonSave.Margin = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonSave.Name = "richReferenceButtonSave";
            this.richReferenceButtonSave.NormalBackgroundImage = null;
            this.richReferenceButtonSave.PaddingMain = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonSave.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonSave.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.richReferenceButtonSave.ShowToolTip = true;
            this.richReferenceButtonSave.Size = new System.Drawing.Size(70, 70);
            this.richReferenceButtonSave.TabIndex = 17;
            this.richReferenceButtonSave.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
            this.richReferenceButtonSave.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.richReferenceButtonSave.TextMain = "";
            this.richReferenceButtonSave.TextSecondary = "";
            this.richReferenceButtonSave.ToolTipText = "Save Data";
            this.richReferenceButtonSave.Visible = false;
            this.richReferenceButtonSave.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ButtonSaveDisplayerRequested);
            this.richReferenceButtonSave.Click += new System.EventHandler(this.ButtonSaveClick);
            this.richReferenceButtonSave.Enabled = !(userType == UserType.ReadOnly);
			// 
			// pictureBoxE
			// 
			this.pictureBoxE.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
            this.pictureBoxE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxE.Location = new System.Drawing.Point(159, 4);
            this.pictureBoxE.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxE.Name = "pictureBoxE";
            this.pictureBoxE.Size = new System.Drawing.Size(7, 62);
            this.pictureBoxE.TabIndex = 18;
            this.pictureBoxE.TabStop = false;
            this.pictureBoxE.Visible = false;
            // 
            // richReferenceButtonEdit
            // 
            this.richReferenceButtonEdit.ActiveBackColor = System.Drawing.Color.Transparent;
            this.richReferenceButtonEdit.ActiveBackgroundImage = null;
            this.richReferenceButtonEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richReferenceButtonEdit.Displayer = null;
            this.richReferenceButtonEdit.DisplayerText = "";
            this.richReferenceButtonEdit.Entity = null;
            this.richReferenceButtonEdit.FontMain = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel);
            this.richReferenceButtonEdit.FontSecondary = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.richReferenceButtonEdit.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.richReferenceButtonEdit.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.richReferenceButtonEdit.Icon = global::CAS.UI.Properties.Resources.EditIcon;
            this.richReferenceButtonEdit.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.richReferenceButtonEdit.IconNotEnabled = global::CAS.UI.Properties.Resources.EditIcon_gray;
            this.richReferenceButtonEdit.Location = new System.Drawing.Point(85, 0);
            this.richReferenceButtonEdit.Margin = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonEdit.Name = "richReferenceButtonEdit";
            this.richReferenceButtonEdit.NormalBackgroundImage = null;
            this.richReferenceButtonEdit.PaddingMain = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonEdit.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonEdit.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.richReferenceButtonEdit.ShowToolTip = true;
            this.richReferenceButtonEdit.Size = new System.Drawing.Size(70, 70);
            this.richReferenceButtonEdit.TabIndex = 13;
            this.richReferenceButtonEdit.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
            this.richReferenceButtonEdit.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.richReferenceButtonEdit.TextMain = "";
            this.richReferenceButtonEdit.TextSecondary = "";
            this.richReferenceButtonEdit.ToolTipText = "Edit Data";
            this.richReferenceButtonEdit.Visible = false;
            this.richReferenceButtonEdit.Click += new System.EventHandler(this.ButtonEditClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(74, 4);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(7, 62);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // avButtonReload
            // 
            this.avButtonReload.ActiveBackColor = System.Drawing.Color.Transparent;
            this.avButtonReload.ActiveBackgroundImage = null;
            this.avButtonReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avButtonReload.FontMain = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel);
            this.avButtonReload.FontSecondary = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.avButtonReload.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.avButtonReload.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.avButtonReload.Icon = global::CAS.UI.Properties.Resources.ReloadIcon;
            this.avButtonReload.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.avButtonReload.IconNotEnabled = global::CAS.UI.Properties.Resources.ReloadIcon_gray;
            this.avButtonReload.Location = new System.Drawing.Point(0, 0);
            this.avButtonReload.Margin = new System.Windows.Forms.Padding(0);
            this.avButtonReload.Name = "avButtonReload";
            this.avButtonReload.NormalBackgroundImage = null;
            this.avButtonReload.PaddingMain = new System.Windows.Forms.Padding(0);
            this.avButtonReload.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.avButtonReload.ShowToolTip = true;
            this.avButtonReload.Size = new System.Drawing.Size(70, 70);
            this.avButtonReload.TabIndex = 11;
            this.avButtonReload.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.avButtonReload.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
            this.avButtonReload.TextMain = "";
            this.avButtonReload.TextSecondary = "";
            this.avButtonReload.ToolTipText = "Refresh";
            this.avButtonReload.Click += new System.EventHandler(this.ButtonReloadClick);
            // 
            // HeaderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::CAS.UI.Properties.Resources.HeaderBar;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HeaderControl";
            this.Size = new System.Drawing.Size(1228, 71);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxF;
        public ForecastControl forecastControl;
        private System.Windows.Forms.PictureBox pictureBoxS2;
        private Management.Dispatchering.RichReferenceButton richReferenceButtonSave2;
        private System.Windows.Forms.PictureBox pictureBoxS;
        private Management.Dispatchering.RichReferenceButton richReferenceButtonSave;
        private System.Windows.Forms.PictureBox pictureBoxE;
        private Management.Dispatchering.RichReferenceButton richReferenceButtonEdit;
        private System.Windows.Forms.PictureBox pictureBox2;
        private AvControls.AvButtonT.AvButtonT avButtonReload;
        private Management.Dispatchering.RichReferenceButton buttonCloseTab;
        private System.Windows.Forms.PictureBox pictureBoxH;
        private Management.Dispatchering.HelpRequestingButtonT buttonHelp;
        private System.Windows.Forms.PictureBox pictureBoxP;
        private Management.Dispatchering.RichReferenceButton buttonPrint;

    }
}
