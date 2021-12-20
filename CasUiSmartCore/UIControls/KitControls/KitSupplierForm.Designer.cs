using MetroFramework.Controls;
using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UIControls.KitControls
{
    partial class AccessorySupplierForm
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
	        var userType = GlobalObjects.CasEnvironment?.IdentityUser.UserType ?? GlobalObjects.CaaEnvironment?.IdentityUser.UserType;;
			this.flowLayoutPanelCharts = new System.Windows.Forms.FlowLayoutPanel();
			this.panelLabelCharts = new MetroFramework.Controls.MetroPanel();
			this.labelFilesCaption = new MetroFramework.Controls.MetroLabel();
			this.panelButtons = new MetroFramework.Controls.MetroPanel();
			this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.flowLayoutPanelCharts.SuspendLayout();
			this.panelLabelCharts.SuspendLayout();
			this.panelButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanelCharts
			// 
			this.flowLayoutPanelCharts.AutoScroll = true;
			this.flowLayoutPanelCharts.Controls.Add(this.panelLabelCharts);
			this.flowLayoutPanelCharts.Controls.Add(this.panelButtons);
			this.flowLayoutPanelCharts.Location = new System.Drawing.Point(0, 63);
			this.flowLayoutPanelCharts.Name = "flowLayoutPanelCharts";
			this.flowLayoutPanelCharts.Size = new System.Drawing.Size(275, 322);
			this.flowLayoutPanelCharts.TabIndex = 1;
			// 
			// panelLabelCharts
			// 
			this.panelLabelCharts.Controls.Add(this.labelFilesCaption);
			this.panelLabelCharts.HorizontalScrollbarBarColor = true;
			this.panelLabelCharts.HorizontalScrollbarHighlightOnWheel = false;
			this.panelLabelCharts.HorizontalScrollbarSize = 10;
			this.panelLabelCharts.Location = new System.Drawing.Point(3, 3);
			this.panelLabelCharts.Name = "panelLabelCharts";
			this.panelLabelCharts.Size = new System.Drawing.Size(269, 16);
			this.panelLabelCharts.TabIndex = 2;
			this.panelLabelCharts.VerticalScrollbarBarColor = true;
			this.panelLabelCharts.VerticalScrollbarHighlightOnWheel = false;
			this.panelLabelCharts.VerticalScrollbarSize = 10;
			// 
			// labelFilesCaption
			// 
			this.labelFilesCaption.AutoSize = true;
			this.labelFilesCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFilesCaption.Location = new System.Drawing.Point(103, -1);
			this.labelFilesCaption.Name = "labelFilesCaption";
			this.labelFilesCaption.Size = new System.Drawing.Size(62, 19);
			this.labelFilesCaption.TabIndex = 3;
			this.labelFilesCaption.Text = "Suppliers";
			this.labelFilesCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelButtons
			// 
			this.panelButtons.Controls.Add(this.ButtonAdd);
			this.panelButtons.HorizontalScrollbarBarColor = true;
			this.panelButtons.HorizontalScrollbarHighlightOnWheel = false;
			this.panelButtons.HorizontalScrollbarSize = 10;
			this.panelButtons.Location = new System.Drawing.Point(3, 25);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(269, 24);
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
			this.ButtonAdd.Location = new System.Drawing.Point(80, 0);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.NormalBackgroundImage = null;
			this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.ShowToolTip = false;
			this.ButtonAdd.Size = new System.Drawing.Size(111, 23);
			this.ButtonAdd.TabIndex = 0;
			this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextMain = "Add Supplier";
			this.ButtonAdd.TextSecondary = "";
			this.ButtonAdd.ToolTipText = "";
			this.ButtonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			this.ButtonAdd.Enabled = !(userType == UserType.ReadOnly);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(119, 394);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 11;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			this.buttonOk.Enabled = !(userType == UserType.ReadOnly);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(200, 394);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 12;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// AccessorySupplierForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(276, 431);
			this.Controls.Add(this.flowLayoutPanelCharts);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Name = "AccessorySupplierForm";
			this.Text = "Kit Supplier Form";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KitFormFormClosed);
			this.flowLayoutPanelCharts.ResumeLayout(false);
			this.panelLabelCharts.ResumeLayout(false);
			this.panelLabelCharts.PerformLayout();
			this.panelButtons.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCharts;
        private MetroPanel panelLabelCharts;
        private MetroLabel labelFilesCaption;
        private MetroPanel panelButtons;
        private AvControls.AvButtonT.AvButtonT ButtonAdd;
        public System.Windows.Forms.Button buttonOk;
        public System.Windows.Forms.Button buttonCancel;
    }
}