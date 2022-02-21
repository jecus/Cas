using System.Windows.Forms;

namespace CAS.UI.UIControls.ComponentControls
{
    partial class PowerUnitWorkInRegimeListControl
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
            if(disposing)
            {
                foreach (Control control in flowLayoutPanelMain.Controls)
                {
                    if(control is PowerUnitWorkInRegimeParamsControl)
                    {
                        ((PowerUnitWorkInRegimeParamsControl) control).Deleted -= OilConditionControlDeleted;
                    }
                }
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
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAdd = new System.Windows.Forms.Panel();
            this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
            this.label = new System.Windows.Forms.Label();
            this.labelAcceleration = new System.Windows.Forms.Label();
            this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
            this.labelGround = new System.Windows.Forms.Label();
            this.labelAir = new System.Windows.Forms.Label();
            this.dateTimePickerAccelerationAir = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanelMain.SuspendLayout();
            this.panelAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.Controls.Add(this.panelAdd);
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 62);
            this.flowLayoutPanelMain.MaximumSize = new System.Drawing.Size(1600, 570);
            this.flowLayoutPanelMain.MinimumSize = new System.Drawing.Size(350, 24);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(1165, 480);
            this.flowLayoutPanelMain.TabIndex = 0;
            this.flowLayoutPanelMain.WrapContents = false;
            // 
            // panelAdd
            // 
            this.panelAdd.Controls.Add(this.linkLabelAddNew);
            this.panelAdd.Location = new System.Drawing.Point(0, 0);
            this.panelAdd.Margin = new System.Windows.Forms.Padding(0);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Size = new System.Drawing.Size(1138, 24);
            this.panelAdd.TabIndex = 4;
            // 
            // linkLabelAddNew
            // 
            this.linkLabelAddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabelAddNew.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelAddNew.Location = new System.Drawing.Point(494, 0);
            this.linkLabelAddNew.Name = "linkLabelAddNew";
            this.linkLabelAddNew.Size = new System.Drawing.Size(170, 20);
            this.linkLabelAddNew.TabIndex = 1;
            this.linkLabelAddNew.TabStop = true;
            this.linkLabelAddNew.Text = "Add new Time in regime";
            this.linkLabelAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelAddNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAddNewLinkClicked);
            // 
            // label
            // 
            this.label.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label.Location = new System.Drawing.Point(405, 48);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(170, 14);
            this.label.TabIndex = 7;
            this.label.Text = "Engine work in regime";
            this.label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelAcceleration
            // 
            this.labelAcceleration.AutoSize = true;
            this.labelAcceleration.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAcceleration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAcceleration.Location = new System.Drawing.Point(3, 28);
            this.labelAcceleration.Name = "labelAcceleration";
            this.labelAcceleration.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelAcceleration.Size = new System.Drawing.Size(117, 14);
            this.labelAcceleration.TabIndex = 23;
            this.labelAcceleration.Text = "Acceleration sec.:";
            this.labelAcceleration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerTime
            // 
            this.dateTimePickerTime.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerTime.CustomFormat = "ss";
            this.dateTimePickerTime.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTime.Location = new System.Drawing.Point(125, 22);
            this.dateTimePickerTime.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerTime.Name = "dateTimePickerTime";
            this.dateTimePickerTime.ShowUpDown = true;
            this.dateTimePickerTime.Size = new System.Drawing.Size(55, 22);
            this.dateTimePickerTime.TabIndex = 25;
            // 
            // labelGround
            // 
            this.labelGround.AutoSize = true;
            this.labelGround.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelGround.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelGround.Location = new System.Drawing.Point(122, 6);
            this.labelGround.Name = "labelGround";
            this.labelGround.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelGround.Size = new System.Drawing.Size(58, 14);
            this.labelGround.TabIndex = 26;
            this.labelGround.Text = "Ground:";
            this.labelGround.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAir
            // 
            this.labelAir.AutoSize = true;
            this.labelAir.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAir.Location = new System.Drawing.Point(186, 6);
            this.labelAir.Name = "labelAir";
            this.labelAir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelAir.Size = new System.Drawing.Size(28, 14);
            this.labelAir.TabIndex = 28;
            this.labelAir.Text = "Air:";
            this.labelAir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerAccelerationAir
            // 
            this.dateTimePickerAccelerationAir.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerAccelerationAir.CustomFormat = "ss";
            this.dateTimePickerAccelerationAir.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dateTimePickerAccelerationAir.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAccelerationAir.Location = new System.Drawing.Point(189, 22);
            this.dateTimePickerAccelerationAir.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerAccelerationAir.Name = "dateTimePickerAccelerationAir";
            this.dateTimePickerAccelerationAir.ShowUpDown = true;
            this.dateTimePickerAccelerationAir.Size = new System.Drawing.Size(55, 22);
            this.dateTimePickerAccelerationAir.TabIndex = 27;
            // 
            // PowerUnitWorkInRegimeListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.labelAir);
            this.Controls.Add(this.dateTimePickerAccelerationAir);
            this.Controls.Add(this.labelGround);
            this.Controls.Add(this.dateTimePickerTime);
            this.Controls.Add(this.labelAcceleration);
            this.Controls.Add(this.label);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1600, 640);
            this.MinimumSize = new System.Drawing.Size(840, 360);
            this.Name = "PowerUnitWorkInRegimeListControl";
            this.Size = new System.Drawing.Size(1168, 545);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.panelAdd.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Panel panelAdd;
        private System.Windows.Forms.LinkLabel linkLabelAddNew;
        private System.Windows.Forms.Label label;
        private Label labelAcceleration;
        private DateTimePicker dateTimePickerTime;
        private Label labelGround;
        private Label labelAir;
        private DateTimePicker dateTimePickerAccelerationAir;
    }
}
