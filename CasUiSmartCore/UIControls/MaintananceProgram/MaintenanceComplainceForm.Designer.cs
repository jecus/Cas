using MetroFramework.Controls;

namespace CAS.UI.UIControls.MaintananceProgram
{
    partial class MaintenanceComplainceForm
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

                if(_animatedThreadWorker != null)
                {
                    if(_animatedThreadWorker.IsBusy)
                    {
                        _animatedThreadWorker.CancelAsync();
                    }
                    
                    ResetAnimatedThreadWorkerEvents();

                    _animatedThreadWorker.Dispose();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintenanceComplainceForm));
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.flowLayoutPanelContainer = new System.Windows.Forms.FlowLayoutPanel();
			this.compliancePDFitem1 = new CAS.UI.UIControls.MaintananceProgram.CompliancePDFItem();
			this.compliancePDFitem2 = new CAS.UI.UIControls.MaintananceProgram.CompliancePDFItem();
			this.lifelengthViewer_LastCompliance = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.delimiter2 = new SmartControls.General.Delimiter();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labelCheckName = new MetroFramework.Controls.MetroLabel();
			this.textBoxCheckName = new MetroFramework.Controls.MetroTextBox();
			this.labelControlPoint = new MetroFramework.Controls.MetroLabel();
			this.checkBoxControlPoint = new MetroFramework.Controls.MetroCheckBox();
			this.delimiter1 = new SmartControls.General.Delimiter();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label2 = new MetroFramework.Controls.MetroLabel();
			this.textBox_Remarks = new MetroFramework.Controls.MetroTextBox();
			this.flowLayoutPanelContainer.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(457, 612);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 13;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(376, 612);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 12;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// flowLayoutPanelContainer
			// 
			this.flowLayoutPanelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanelContainer.AutoScroll = true;
			this.flowLayoutPanelContainer.Controls.Add(this.compliancePDFitem1);
			this.flowLayoutPanelContainer.Controls.Add(this.compliancePDFitem2);
			this.flowLayoutPanelContainer.Location = new System.Drawing.Point(11, 285);
			this.flowLayoutPanelContainer.Name = "flowLayoutPanelContainer";
			this.flowLayoutPanelContainer.Size = new System.Drawing.Size(498, 252);
			this.flowLayoutPanelContainer.TabIndex = 11;
			// 
			// compliancePDFitem1
			// 
			this.compliancePDFitem1.AutoSize = true;
			this.compliancePDFitem1.Location = new System.Drawing.Point(4, 4);
			this.compliancePDFitem1.Margin = new System.Windows.Forms.Padding(4);
			this.compliancePDFitem1.Name = "compliancePDFitem1";
			this.compliancePDFitem1.Size = new System.Drawing.Size(472, 112);
			this.compliancePDFitem1.TabIndex = 2;
			// 
			// compliancePDFitem2
			// 
			this.compliancePDFitem2.AutoSize = true;
			this.compliancePDFitem2.Location = new System.Drawing.Point(4, 124);
			this.compliancePDFitem2.Margin = new System.Windows.Forms.Padding(4);
			this.compliancePDFitem2.Name = "compliancePDFitem2";
			this.compliancePDFitem2.Size = new System.Drawing.Size(472, 112);
			this.compliancePDFitem2.TabIndex = 3;
			// 
			// lifelengthViewer_LastCompliance
			// 
			this.lifelengthViewer_LastCompliance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lifelengthViewer_LastCompliance.AutoSize = true;
			this.lifelengthViewer_LastCompliance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer_LastCompliance.CalendarApplicable = false;
			this.lifelengthViewer_LastCompliance.CyclesApplicable = false;
			this.lifelengthViewer_LastCompliance.EnabledCalendar = false;
			this.lifelengthViewer_LastCompliance.EnabledCycle = true;
			this.lifelengthViewer_LastCompliance.EnabledHours = true;
			this.lifelengthViewer_LastCompliance.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer_LastCompliance.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer_LastCompliance.HeaderCalendar = "Calendar";
			this.lifelengthViewer_LastCompliance.HeaderCycles = "Cycles";
			this.lifelengthViewer_LastCompliance.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer_LastCompliance.HeaderHours = "Hours";
			this.lifelengthViewer_LastCompliance.HoursApplicable = false;
			this.lifelengthViewer_LastCompliance.LeftHeader = "Last compliance";
			this.lifelengthViewer_LastCompliance.Location = new System.Drawing.Point(20, 13);
			this.lifelengthViewer_LastCompliance.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_LastCompliance.Modified = false;
			this.lifelengthViewer_LastCompliance.Name = "lifelengthViewer_LastCompliance";
			this.lifelengthViewer_LastCompliance.ReadOnly = false;
			this.lifelengthViewer_LastCompliance.ShowCalendar = true;
			this.lifelengthViewer_LastCompliance.ShowFormattedCalendar = false;
			this.lifelengthViewer_LastCompliance.ShowMinutes = true;
			this.lifelengthViewer_LastCompliance.Size = new System.Drawing.Size(477, 52);
			this.lifelengthViewer_LastCompliance.SystemCalculated = true;
			this.lifelengthViewer_LastCompliance.TabIndex = 0;
			// 
			// delimiter2
			// 
			this.delimiter2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter2.BackgroundImage")));
			this.delimiter2.Location = new System.Drawing.Point(7, 276);
			this.delimiter2.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter2.Name = "delimiter2";
			this.delimiter2.Orientation = SmartControls.General.DelimiterOrientation.Horizontal;
			this.delimiter2.Size = new System.Drawing.Size(472, 2);
			this.delimiter2.Style = SmartControls.General.DelimiterStyle.Solid;
			this.delimiter2.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(98, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Date:";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.labelCheckName);
			this.groupBox1.Controls.Add(this.textBoxCheckName);
			this.groupBox1.Controls.Add(this.labelControlPoint);
			this.groupBox1.Controls.Add(this.checkBoxControlPoint);
			this.groupBox1.Controls.Add(this.flowLayoutPanelContainer);
			this.groupBox1.Controls.Add(this.lifelengthViewer_LastCompliance);
			this.groupBox1.Controls.Add(this.delimiter2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.delimiter1);
			this.groupBox1.Controls.Add(this.dateTimePicker1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox_Remarks);
			this.groupBox1.Location = new System.Drawing.Point(12, 63);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(520, 543);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			// 
			// labelCheckName
			// 
			this.labelCheckName.AutoSize = true;
			this.labelCheckName.ForeColor = System.Drawing.Color.DimGray;
			this.labelCheckName.Location = new System.Drawing.Point(50, 101);
			this.labelCheckName.Name = "labelCheckName";
			this.labelCheckName.Size = new System.Drawing.Size(87, 19);
			this.labelCheckName.TabIndex = 15;
			this.labelCheckName.Text = "Check Name:";
			// 
			// textBoxCheckName
			// 
			// 
			// 
			// 
			this.textBoxCheckName.CustomButton.Image = null;
			this.textBoxCheckName.CustomButton.Location = new System.Drawing.Point(334, 2);
			this.textBoxCheckName.CustomButton.Name = "";
			this.textBoxCheckName.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxCheckName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxCheckName.CustomButton.TabIndex = 1;
			this.textBoxCheckName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxCheckName.CustomButton.UseSelectable = true;
			this.textBoxCheckName.CustomButton.Visible = false;
			this.textBoxCheckName.Lines = new string[0];
			this.textBoxCheckName.Location = new System.Drawing.Point(143, 101);
			this.textBoxCheckName.MaxLength = 128;
			this.textBoxCheckName.Name = "textBoxCheckName";
			this.textBoxCheckName.PasswordChar = '\0';
			this.textBoxCheckName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxCheckName.SelectedText = "";
			this.textBoxCheckName.SelectionLength = 0;
			this.textBoxCheckName.SelectionStart = 0;
			this.textBoxCheckName.ShortcutsEnabled = true;
			this.textBoxCheckName.Size = new System.Drawing.Size(352, 20);
			this.textBoxCheckName.TabIndex = 14;
			this.textBoxCheckName.UseSelectable = true;
			this.textBoxCheckName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxCheckName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelControlPoint
			// 
			this.labelControlPoint.AutoSize = true;
			this.labelControlPoint.ForeColor = System.Drawing.Color.DimGray;
			this.labelControlPoint.Location = new System.Drawing.Point(7, 131);
			this.labelControlPoint.Name = "labelControlPoint";
			this.labelControlPoint.Size = new System.Drawing.Size(101, 19);
			this.labelControlPoint.TabIndex = 13;
			this.labelControlPoint.Text = "Is Control Point:";
			this.labelControlPoint.Visible = false;
			// 
			// checkBoxControlPoint
			// 
			this.checkBoxControlPoint.AutoSize = true;
			this.checkBoxControlPoint.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxControlPoint.Location = new System.Drawing.Point(143, 135);
			this.checkBoxControlPoint.Name = "checkBoxControlPoint";
			this.checkBoxControlPoint.Size = new System.Drawing.Size(16, 0);
			this.checkBoxControlPoint.TabIndex = 12;
			this.checkBoxControlPoint.UseSelectable = true;
			this.checkBoxControlPoint.Visible = false;
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(7, 156);
			this.delimiter1.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = SmartControls.General.DelimiterOrientation.Horizontal;
			this.delimiter1.Size = new System.Drawing.Size(474, 2);
			this.delimiter1.Style = SmartControls.General.DelimiterStyle.Solid;
			this.delimiter1.TabIndex = 9;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePicker1.Location = new System.Drawing.Point(143, 70);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(351, 20);
			this.dateTimePicker1.TabIndex = 2;
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.DimGray;
			this.label2.Location = new System.Drawing.Point(75, 165);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 19);
			this.label2.TabIndex = 3;
			this.label2.Text = "Remarks:";
			// 
			// textBox_Remarks
			// 
			// 
			// 
			// 
			this.textBox_Remarks.CustomButton.Image = null;
			this.textBox_Remarks.CustomButton.Location = new System.Drawing.Point(250, 2);
			this.textBox_Remarks.CustomButton.Name = "";
			this.textBox_Remarks.CustomButton.Size = new System.Drawing.Size(99, 99);
			this.textBox_Remarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBox_Remarks.CustomButton.TabIndex = 1;
			this.textBox_Remarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBox_Remarks.CustomButton.UseSelectable = true;
			this.textBox_Remarks.CustomButton.Visible = false;
			this.textBox_Remarks.Lines = new string[0];
			this.textBox_Remarks.Location = new System.Drawing.Point(143, 165);
			this.textBox_Remarks.MaxLength = 32767;
			this.textBox_Remarks.Multiline = true;
			this.textBox_Remarks.Name = "textBox_Remarks";
			this.textBox_Remarks.PasswordChar = '\0';
			this.textBox_Remarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBox_Remarks.SelectedText = "";
			this.textBox_Remarks.SelectionLength = 0;
			this.textBox_Remarks.SelectionStart = 0;
			this.textBox_Remarks.ShortcutsEnabled = true;
			this.textBox_Remarks.Size = new System.Drawing.Size(352, 104);
			this.textBox_Remarks.TabIndex = 4;
			this.textBox_Remarks.UseSelectable = true;
			this.textBox_Remarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBox_Remarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// MaintenanceComplainceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(552, 656);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(552, 768);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(552, 499);
			this.Name = "MaintenanceComplainceForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Maintenance Compliance";
			this.Activated += new System.EventHandler(this.MaintenanceComplainceFormActivated);
			this.Deactivate += new System.EventHandler(this.MaintenanceComplainceFormDeactivate);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaintenanceComplainceFormFormClosing);
			this.Load += new System.EventHandler(this.MaintenanceComplianceFormLoad);
			this.flowLayoutPanelContainer.ResumeLayout(false);
			this.flowLayoutPanelContainer.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

        }
        #endregion

        public System.Windows.Forms.Button buttonCancel;
        public System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelContainer;
        private CompliancePDFItem compliancePDFitem1;
        private CompliancePDFItem compliancePDFitem2;
        public Auxiliary.LifelengthViewer lifelengthViewer_LastCompliance;
        public SmartControls.General.Delimiter delimiter2;
        public MetroLabel label1;
        public System.Windows.Forms.GroupBox groupBox1;
        public SmartControls.General.Delimiter delimiter1;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public MetroLabel label2;
        public MetroTextBox textBox_Remarks;
        public MetroLabel labelCheckName;
        public MetroTextBox textBoxCheckName;
        public MetroLabel labelControlPoint;
        private MetroCheckBox checkBoxControlPoint;
    }
}