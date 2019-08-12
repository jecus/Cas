using MetroFramework.Controls;

namespace CAS.UI.UIControls.Auxiliary.Dialogs
{
    partial class ComplianceDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComplianceDialog));
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.label2 = new MetroFramework.Controls.MetroLabel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lifelengthViewer_LastCompliance = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.delimiter2 = new SmartControls.General.Delimiter();
			this.delimiter1 = new SmartControls.General.Delimiter();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.textBox_Remarks = new MetroFramework.Controls.MetroTextBox();
			this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonApply = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(62, 93);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Date:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.DimGray;
			this.label2.Location = new System.Drawing.Point(39, 125);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 19);
			this.label2.TabIndex = 3;
			this.label2.Text = "Remarks:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lifelengthViewer_LastCompliance);
			this.groupBox1.Controls.Add(this.delimiter2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.delimiter1);
			this.groupBox1.Controls.Add(this.dateTimePicker1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox_Remarks);
			this.groupBox1.Controls.Add(this.fileControl);
			this.groupBox1.Location = new System.Drawing.Point(11, 63);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(484, 353);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			// 
			// lifelengthViewer_LastCompliance
			// 
			this.lifelengthViewer_LastCompliance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lifelengthViewer_LastCompliance.AutoSize = true;
			this.lifelengthViewer_LastCompliance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer_LastCompliance.CalendarApplicable = false;
			this.lifelengthViewer_LastCompliance.CyclesApplicable = false;
			this.lifelengthViewer_LastCompliance.EnabledCalendar = true;
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
			this.lifelengthViewer_LastCompliance.Location = new System.Drawing.Point(5, 18);
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
			this.delimiter2.Location = new System.Drawing.Point(6, 236);
			this.delimiter2.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter2.Name = "delimiter2";
			this.delimiter2.Orientation = SmartControls.General.DelimiterOrientation.Horizontal;
			this.delimiter2.Size = new System.Drawing.Size(470, 2);
			this.delimiter2.Style = SmartControls.General.DelimiterStyle.Solid;
			this.delimiter2.TabIndex = 10;
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(8, 120);
			this.delimiter1.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = SmartControls.General.DelimiterOrientation.Horizontal;
			this.delimiter1.Size = new System.Drawing.Size(470, 2);
			this.delimiter1.Style = SmartControls.General.DelimiterStyle.Solid;
			this.delimiter1.TabIndex = 9;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePicker1.Location = new System.Drawing.Point(126, 93);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(352, 20);
			this.dateTimePicker1.TabIndex = 1;
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
			this.textBox_Remarks.Location = new System.Drawing.Point(126, 125);
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
			this.textBox_Remarks.TabIndex = 2;
			this.textBox_Remarks.UseSelectable = true;
			this.textBox_Remarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBox_Remarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// fileControl
			// 
			this.fileControl.AutoSize = true;
			this.fileControl.BackColor = System.Drawing.Color.Transparent;
			this.fileControl.Description1 = null;
			this.fileControl.Description2 = null;
			this.fileControl.Filter = "PDF file (*.pdf)|*.pdf";
			this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControl.IconNotEnabled = null;
			this.fileControl.Location = new System.Drawing.Point(126, 244);
			this.fileControl.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControl.Name = "fileControl";
			this.fileControl.ShowLinkLabelBrowse = true;
			this.fileControl.ShowLinkLabelRemove = false;
			this.fileControl.Size = new System.Drawing.Size(350, 37);
			this.fileControl.TabIndex = 5;
			// 
			// buttonOk
			// 
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(258, 422);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 6;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(339, 422);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonApply
			// 
			this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonApply.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonApply.Location = new System.Drawing.Point(420, 422);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 33);
			this.buttonApply.TabIndex = 8;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			// 
			// ComplianceDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(505, 463);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(505, 500);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(505, 428);
			this.Name = "ComplianceDialog";
			this.ShowIcon = false;
			this.Text = "ComplianceDialog";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        public CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthViewer_LastCompliance;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public MetroTextBox textBox_Remarks;
        public CAS.UI.UIControls.Auxiliary.AttachedFileControl fileControl;
        public System.Windows.Forms.Button buttonOk;
        public System.Windows.Forms.Button buttonCancel;
        public System.Windows.Forms.Button buttonApply;
        public SmartControls.General.Delimiter delimiter1;
        public SmartControls.General.Delimiter delimiter2;
        public System.Windows.Forms.GroupBox groupBox1;
        public MetroLabel label1;
        public MetroLabel label2;

    }
}