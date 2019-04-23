using MetroFramework.Controls;
using CASTerms;
using EFCore.DTO.General;

namespace CAS.UI.UIControls.KitControls
{
    partial class KitForm
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
			this.panelLabel = new MetroFramework.Controls.MetroPanel();
			this.labelKits = new MetroFramework.Controls.MetroLabel();
			this.panelButtons = new MetroFramework.Controls.MetroPanel();
			this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.flowLayoutPanelCharts.SuspendLayout();
			this.panelLabel.SuspendLayout();
			this.panelButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanelCharts
			// 
			this.flowLayoutPanelCharts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanelCharts.AutoScroll = true;
			this.flowLayoutPanelCharts.Controls.Add(this.panelLabel);
			this.flowLayoutPanelCharts.Controls.Add(this.panelButtons);
			this.flowLayoutPanelCharts.Location = new System.Drawing.Point(4, 63);
			this.flowLayoutPanelCharts.Name = "flowLayoutPanelCharts";
			this.flowLayoutPanelCharts.Size = new System.Drawing.Size(647, 380);
			this.flowLayoutPanelCharts.TabIndex = 2;
			// 
			// panelLabel
			// 
			this.panelLabel.Controls.Add(this.labelKits);
			this.panelLabel.HorizontalScrollbarBarColor = true;
			this.panelLabel.HorizontalScrollbarHighlightOnWheel = false;
			this.panelLabel.HorizontalScrollbarSize = 10;
			this.panelLabel.Location = new System.Drawing.Point(3, 3);
			this.panelLabel.Name = "panelLabel";
			this.panelLabel.Size = new System.Drawing.Size(624, 16);
			this.panelLabel.TabIndex = 2;
			this.panelLabel.VerticalScrollbarBarColor = true;
			this.panelLabel.VerticalScrollbarHighlightOnWheel = false;
			this.panelLabel.VerticalScrollbarSize = 10;
			// 
			// labelKits
			// 
			this.labelKits.AutoSize = true;
			this.labelKits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelKits.Location = new System.Drawing.Point(296, -3);
			this.labelKits.Name = "labelKits";
			this.labelKits.Size = new System.Drawing.Size(28, 19);
			this.labelKits.TabIndex = 3;
			this.labelKits.Text = "Kits";
			this.labelKits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelButtons
			// 
			this.panelButtons.Controls.Add(this.ButtonAdd);
			this.panelButtons.HorizontalScrollbarBarColor = true;
			this.panelButtons.HorizontalScrollbarHighlightOnWheel = false;
			this.panelButtons.HorizontalScrollbarSize = 10;
			this.panelButtons.Location = new System.Drawing.Point(3, 25);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(569, 24);
			this.panelButtons.TabIndex = 4;
			this.panelButtons.VerticalScrollbarBarColor = true;
			this.panelButtons.VerticalScrollbarHighlightOnWheel = false;
			this.panelButtons.VerticalScrollbarSize = 10;
			// 
			// ButtonAdd
			// 
			this.ButtonAdd.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonAdd.ActiveBackgroundImage = null;
			this.ButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonAdd.FontMain = new System.Drawing.Font("Verdana", 8F);
			this.ButtonAdd.FontSecondary = new System.Drawing.Font("Verdana", 8F);
			this.ButtonAdd.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.ButtonAdd.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonAdd.Icon = global::CAS.UI.Properties.Resources.AddIconSmall;
			this.ButtonAdd.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.ButtonAdd.IconNotEnabled = null;
			this.ButtonAdd.Location = new System.Drawing.Point(271, 0);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.NormalBackgroundImage = null;
			this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.ShowToolTip = false;
			this.ButtonAdd.Size = new System.Drawing.Size(78, 23);
			this.ButtonAdd.TabIndex = 0;
			this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextMain = "Add Kit";
			this.ButtonAdd.TextSecondary = "";
			this.ButtonAdd.ToolTipText = "";
			this.ButtonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			this.ButtonAdd.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(495, 452);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 13;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			this.buttonOk.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(576, 452);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 14;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// KitForm
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(655, 493);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.flowLayoutPanelCharts);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(655, 1024);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(655, 300);
			this.Name = "KitForm";
			this.ShowIcon = false;
			this.Text = "Kit Form";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KitFormFormClosed);
			this.flowLayoutPanelCharts.ResumeLayout(false);
			this.panelLabel.ResumeLayout(false);
			this.panelLabel.PerformLayout();
			this.panelButtons.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCharts;
        private MetroPanel panelLabel;
        private MetroLabel labelKits;
        private MetroPanel panelButtons;
        private AvControls.AvButtonT.AvButtonT ButtonAdd;
        public System.Windows.Forms.Button buttonOk;
        public System.Windows.Forms.Button buttonCancel;
    }
}