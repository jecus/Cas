using System.Drawing;
using System.Windows.Forms;
using Controls.AvButtonT;
using LTR.UI.Appearance;

namespace LTR.UI.UIControls.MaintenanceStatusControls
{
    partial class MaintenanceStatusComplianceControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAddRecord = new Controls.AvButtonT.AvButtonT();
            this.buttonDeleteRecord = new Controls.AvButtonT.AvButtonT();
            this.buttonEditRecord = new Controls.AvButtonT.AvButtonT();
            this.maintenanceComplianceListView = new LTR.UI.UIControls.MaintenanceStatusControls.MaintenanceComplianceListView();
            this.dateTimePickerSince = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTill = new System.Windows.Forms.DateTimePicker();
            this.labelSince = new System.Windows.Forms.Label();
            this.labelTill = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAddRecord
            // 
            this.buttonAddRecord.ActiveBackColor = System.Drawing.Color.Transparent;
            this.buttonAddRecord.ActiveBackgroundImage = null;
            this.buttonAddRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddRecord.BackColor = System.Drawing.Color.Transparent;
            this.buttonAddRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddRecord.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.buttonAddRecord.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.buttonAddRecord.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.buttonAddRecord.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.buttonAddRecord.Icon = null;
            this.buttonAddRecord.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAddRecord.Location = new System.Drawing.Point(3, 160);
            this.buttonAddRecord.Name = "buttonAddRecord";
            this.buttonAddRecord.NormalBackgroundImage = null;
            this.buttonAddRecord.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonAddRecord.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonAddRecord.Size = new System.Drawing.Size(150, 50);
            this.buttonAddRecord.TabIndex = 16;
            this.buttonAddRecord.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddRecord.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddRecord.TextMain = "Add New";
            this.buttonAddRecord.TextSecondary = "";
            this.buttonAddRecord.Click += new System.EventHandler(this.buttonAddRecord_Click);
            // 
            // buttonDeleteRecord
            // 
            this.buttonDeleteRecord.ActiveBackColor = System.Drawing.Color.Transparent;
            this.buttonDeleteRecord.ActiveBackgroundImage = null;
            this.buttonDeleteRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteRecord.BackColor = System.Drawing.Color.Transparent;
            this.buttonDeleteRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteRecord.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.buttonDeleteRecord.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.buttonDeleteRecord.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.buttonDeleteRecord.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.buttonDeleteRecord.Icon = null;
            this.buttonDeleteRecord.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDeleteRecord.Location = new System.Drawing.Point(295, 160);
            this.buttonDeleteRecord.Name = "buttonDeleteRecord";
            this.buttonDeleteRecord.NormalBackgroundImage = null;
            this.buttonDeleteRecord.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonDeleteRecord.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonDeleteRecord.Size = new System.Drawing.Size(150, 50);
            this.buttonDeleteRecord.TabIndex = 16;
            this.buttonDeleteRecord.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteRecord.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDeleteRecord.TextMain = "Remove";
            this.buttonDeleteRecord.TextSecondary = "";
            this.buttonDeleteRecord.Click += new System.EventHandler(this.buttonDeleteRecord_Click);
            // 
            // buttonEditRecord
            // 
            this.buttonEditRecord.ActiveBackColor = System.Drawing.Color.Transparent;
            this.buttonEditRecord.ActiveBackgroundImage = null;
            this.buttonEditRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEditRecord.BackColor = System.Drawing.Color.Transparent;
            this.buttonEditRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditRecord.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.buttonEditRecord.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.buttonEditRecord.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.buttonEditRecord.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.buttonEditRecord.Icon = null;
            this.buttonEditRecord.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonEditRecord.Location = new System.Drawing.Point(159, 160);
            this.buttonEditRecord.Name = "buttonEditRecord";
            this.buttonEditRecord.NormalBackgroundImage = null;
            this.buttonEditRecord.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonEditRecord.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonEditRecord.Size = new System.Drawing.Size(130, 50);
            this.buttonEditRecord.TabIndex = 16;
            this.buttonEditRecord.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditRecord.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.buttonEditRecord.TextMain = "Edit";
            this.buttonEditRecord.TextSecondary = "";
            this.buttonEditRecord.Click += new System.EventHandler(this.buttonEditRecord_Click);
            // 
            // maintenanceComplianceListView
            // 
            this.maintenanceComplianceListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.maintenanceComplianceListView.DoubleClickEnable = true;
            this.maintenanceComplianceListView.Location = new System.Drawing.Point(0, 0);
            this.maintenanceComplianceListView.Name = "maintenanceComplianceListView";
            this.maintenanceComplianceListView.Scrollable = true;
            this.maintenanceComplianceListView.ShowGroups = true;
            this.maintenanceComplianceListView.Size = new System.Drawing.Size(900, 154);
            this.maintenanceComplianceListView.TabIndex = 0;
            this.maintenanceComplianceListView.SizeChanged += new System.EventHandler(this.maintenanceComplianceListView1_SizeChanged);
            // 
            // dateTimePickerSince
            // 
            this.dateTimePickerSince.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerSince.CustomFormat = "MMM, dd yyyy";
            this.dateTimePickerSince.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerSince.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSince.Location = new System.Drawing.Point(531, 175);
            this.dateTimePickerSince.Name = "dateTimePickerSince";
            this.dateTimePickerSince.Size = new System.Drawing.Size(151, 23);
            this.dateTimePickerSince.TabIndex = 17;
            this.dateTimePickerSince.ValueChanged += new System.EventHandler(this.dateTimePickerSince_ValueChanged);
            // 
            // dateTimePickerTill
            // 
            this.dateTimePickerTill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerTill.CustomFormat = "MMM, dd yyyy";
            this.dateTimePickerTill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerTill.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTill.Location = new System.Drawing.Point(734, 175);
            this.dateTimePickerTill.Name = "dateTimePickerTill";
            this.dateTimePickerTill.Size = new System.Drawing.Size(145, 23);
            this.dateTimePickerTill.TabIndex = 18;
            this.dateTimePickerTill.ValueChanged += new System.EventHandler(this.dateTimePickerTill_ValueChanged);
            // 
            // labelSince
            // 
            this.labelSince.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSince.AutoSize = true;
            this.labelSince.Location = new System.Drawing.Point(469, 180);
            this.labelSince.Name = "labelSince";
            this.labelSince.Size = new System.Drawing.Size(37, 13);
            this.labelSince.TabIndex = 19;
            this.labelSince.Text = "Date From:";
            // 
            // labelTill
            // 
            this.labelTill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTill.AutoSize = true;
            this.labelTill.Location = new System.Drawing.Point(688, 180);
            this.labelTill.Name = "labelTill";
            this.labelTill.Size = new System.Drawing.Size(23, 13);
            this.labelTill.TabIndex = 20;
            this.labelTill.Text = "Date To:";
            // 
            // MaintenanceStatusComplianceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTill);
            this.Controls.Add(this.labelSince);
            this.Controls.Add(this.dateTimePickerTill);
            this.Controls.Add(this.dateTimePickerSince);
            this.Controls.Add(this.maintenanceComplianceListView);
            this.Controls.Add(this.buttonAddRecord);
            this.Controls.Add(this.buttonDeleteRecord);
            this.Controls.Add(this.buttonEditRecord);
            this.Margin = new System.Windows.Forms.Padding(30);
            this.Name = "MaintenanceStatusComplianceControl";
            this.Size = new System.Drawing.Size(900, 213);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaintenanceComplianceListView maintenanceComplianceListView;
        private AvButtonT buttonAddRecord;
        private AvButtonT buttonDeleteRecord;
        private AvButtonT buttonEditRecord;
        private DateTimePicker dateTimePickerSince;
        private DateTimePicker dateTimePickerTill;
        private Label labelSince;
        private Label labelTill;
    }
}
