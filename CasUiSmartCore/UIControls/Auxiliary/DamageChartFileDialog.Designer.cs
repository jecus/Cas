using CASTerms;
using EFCore.DTO.General;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class DamageChartFileDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
	        var userType = GlobalObjects.CasEnvironment.IdentityUser.UserType;
			this.flowLayoutPanelCharts = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLabelCharts = new System.Windows.Forms.Panel();
            this.labelFilesCaption = new System.Windows.Forms.Label();
            this.panelButtonsFiles = new System.Windows.Forms.Panel();
            this.ButtonAddChart = new AvControls.AvButtonT.AvButtonT();
            this.flowLayoutPanelImages = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLabelImages = new System.Windows.Forms.Panel();
            this.labelImageCaption = new System.Windows.Forms.Label();
            this.panelButtonsImages = new System.Windows.Forms.Panel();
            this.ButtonAddImage = new AvControls.AvButtonT.AvButtonT();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanelCharts.SuspendLayout();
            this.panelLabelCharts.SuspendLayout();
            this.panelButtonsFiles.SuspendLayout();
            this.flowLayoutPanelImages.SuspendLayout();
            this.panelLabelImages.SuspendLayout();
            this.panelButtonsImages.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelCharts
            // 
            this.flowLayoutPanelCharts.AutoScroll = true;
            this.flowLayoutPanelCharts.Controls.Add(this.panelLabelCharts);
            this.flowLayoutPanelCharts.Controls.Add(this.panelButtonsFiles);
            this.flowLayoutPanelCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelCharts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelCharts.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelCharts.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelCharts.Name = "flowLayoutPanelCharts";
            this.flowLayoutPanelCharts.Size = new System.Drawing.Size(588, 507);
            this.flowLayoutPanelCharts.TabIndex = 0;
            this.flowLayoutPanelCharts.WrapContents = false;
            // 
            // panelLabelCharts
            // 
            this.panelLabelCharts.Controls.Add(this.labelFilesCaption);
            this.panelLabelCharts.Location = new System.Drawing.Point(4, 4);
            this.panelLabelCharts.Margin = new System.Windows.Forms.Padding(4);
            this.panelLabelCharts.Name = "panelLabelCharts";
            this.panelLabelCharts.Size = new System.Drawing.Size(420, 37);
            this.panelLabelCharts.TabIndex = 2;
            // 
            // labelFilesCaption
            // 
            this.labelFilesCaption.AutoSize = true;
            this.labelFilesCaption.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFilesCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelFilesCaption.Location = new System.Drawing.Point(169, 7);
            this.labelFilesCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFilesCaption.Name = "labelFilesCaption";
            this.labelFilesCaption.Size = new System.Drawing.Size(78, 25);
            this.labelFilesCaption.TabIndex = 3;
            this.labelFilesCaption.Text = "Charts";
            this.labelFilesCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelButtonsFiles
            // 
            this.panelButtonsFiles.Controls.Add(this.ButtonAddChart);
            this.panelButtonsFiles.Location = new System.Drawing.Point(4, 49);
            this.panelButtonsFiles.Margin = new System.Windows.Forms.Padding(4);
            this.panelButtonsFiles.Name = "panelButtonsFiles";
            this.panelButtonsFiles.Size = new System.Drawing.Size(420, 37);
            this.panelButtonsFiles.TabIndex = 1;
            // 
            // ButtonAddChart
            // 
            this.ButtonAddChart.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonAddChart.ActiveBackgroundImage = null;
            this.ButtonAddChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAddChart.FontMain = new System.Drawing.Font("Verdana", 8.25F);
            this.ButtonAddChart.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.ButtonAddChart.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.ButtonAddChart.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonAddChart.Icon = global::CAS.UI.Properties.Resources.AddIconSmall;
            this.ButtonAddChart.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonAddChart.IconNotEnabled = null;
            this.ButtonAddChart.Location = new System.Drawing.Point(149, 4);
            this.ButtonAddChart.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonAddChart.Name = "ButtonAddChart";
            this.ButtonAddChart.NormalBackgroundImage = null;
            this.ButtonAddChart.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonAddChart.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonAddChart.ShowToolTip = false;
            this.ButtonAddChart.Size = new System.Drawing.Size(132, 28);
            this.ButtonAddChart.TabIndex = 0;
            this.ButtonAddChart.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAddChart.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAddChart.TextMain = "Add new";
            this.ButtonAddChart.TextSecondary = "";
            this.ButtonAddChart.ToolTipText = "";
            this.ButtonAddChart.Click += new System.EventHandler(this.ButtonAddChartClick);
            this.ButtonAddChart.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// flowLayoutPanelImages
			// 
			this.flowLayoutPanelImages.AutoScroll = true;
            this.flowLayoutPanelImages.Controls.Add(this.panelLabelImages);
            this.flowLayoutPanelImages.Controls.Add(this.panelButtonsImages);
            this.flowLayoutPanelImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelImages.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelImages.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelImages.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            this.flowLayoutPanelImages.Size = new System.Drawing.Size(457, 507);
            this.flowLayoutPanelImages.TabIndex = 0;
            this.flowLayoutPanelImages.WrapContents = false;
            // 
            // panelLabelImages
            // 
            this.panelLabelImages.Controls.Add(this.labelImageCaption);
            this.panelLabelImages.Location = new System.Drawing.Point(4, 4);
            this.panelLabelImages.Margin = new System.Windows.Forms.Padding(4);
            this.panelLabelImages.Name = "panelLabelImages";
            this.panelLabelImages.Size = new System.Drawing.Size(420, 37);
            this.panelLabelImages.TabIndex = 4;
            // 
            // labelImageCaption
            // 
            this.labelImageCaption.AutoSize = true;
            this.labelImageCaption.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelImageCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelImageCaption.Location = new System.Drawing.Point(161, 10);
            this.labelImageCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelImageCaption.Name = "labelImageCaption";
            this.labelImageCaption.Size = new System.Drawing.Size(85, 25);
            this.labelImageCaption.TabIndex = 3;
            this.labelImageCaption.Text = "Images";
            this.labelImageCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelButtonsImages
            // 
            this.panelButtonsImages.Controls.Add(this.ButtonAddImage);
            this.panelButtonsImages.Location = new System.Drawing.Point(4, 49);
            this.panelButtonsImages.Margin = new System.Windows.Forms.Padding(4);
            this.panelButtonsImages.Name = "panelButtonsImages";
            this.panelButtonsImages.Size = new System.Drawing.Size(420, 37);
            this.panelButtonsImages.TabIndex = 2;
            // 
            // ButtonAddImage
            // 
            this.ButtonAddImage.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonAddImage.ActiveBackgroundImage = null;
            this.ButtonAddImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAddImage.FontMain = new System.Drawing.Font("Verdana", 8.25F);
            this.ButtonAddImage.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.ButtonAddImage.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.ButtonAddImage.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonAddImage.Icon = global::CAS.UI.Properties.Resources.AddIconSmall;
            this.ButtonAddImage.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonAddImage.IconNotEnabled = null;
            this.ButtonAddImage.Location = new System.Drawing.Point(149, 4);
            this.ButtonAddImage.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonAddImage.Name = "ButtonAddImage";
            this.ButtonAddImage.NormalBackgroundImage = null;
            this.ButtonAddImage.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonAddImage.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonAddImage.ShowToolTip = false;
            this.ButtonAddImage.Size = new System.Drawing.Size(132, 28);
            this.ButtonAddImage.TabIndex = 0;
            this.ButtonAddImage.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAddImage.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAddImage.TextMain = "Add new";
            this.ButtonAddImage.TextSecondary = "";
            this.ButtonAddImage.ToolTipText = "";
            this.ButtonAddImage.Click += new System.EventHandler(this.ButtonAddImageClick);
            this.ButtonAddImage.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// panelButtons
			// 
			this.panelButtons.Controls.Add(this.buttonOK);
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 507);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(4);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1049, 37);
            this.panelButtons.TabIndex = 2;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOK.Location = new System.Drawing.Point(890, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 33);
            this.buttonOK.TabIndex = 14;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
            this.buttonOK.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonCancel.Location = new System.Drawing.Point(971, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.flowLayoutPanelCharts);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.flowLayoutPanelImages);
            this.splitContainerMain.Size = new System.Drawing.Size(1049, 507);
            this.splitContainerMain.SplitterDistance = 588;
            this.splitContainerMain.TabIndex = 3;
            // 
            // DamageChartFileDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(1049, 544);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.panelButtons);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(927, 531);
            this.Name = "DamageChartFileDialog";
            this.ShowIcon = false;
            this.Text = "Damage files";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.flowLayoutPanelCharts.ResumeLayout(false);
            this.panelLabelCharts.ResumeLayout(false);
            this.panelLabelCharts.PerformLayout();
            this.panelButtonsFiles.ResumeLayout(false);
            this.flowLayoutPanelImages.ResumeLayout(false);
            this.panelLabelImages.ResumeLayout(false);
            this.panelLabelImages.PerformLayout();
            this.panelButtonsImages.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelButtonsFiles;
        private AvControls.AvButtonT.AvButtonT ButtonAddChart;
        private System.Windows.Forms.Panel panelButtonsImages;
        private AvControls.AvButtonT.AvButtonT ButtonAddImage;
        private System.Windows.Forms.Label labelImageCaption;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCharts;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImages;
        private System.Windows.Forms.Panel panelLabelCharts;
        private System.Windows.Forms.Label labelFilesCaption;
        private System.Windows.Forms.Panel panelLabelImages;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.SplitContainer splitContainerMain;

    }
}