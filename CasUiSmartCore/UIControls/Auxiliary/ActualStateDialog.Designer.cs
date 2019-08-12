using MetroFramework.Controls;

namespace CAS.UI.UIControls.Auxiliary
{
	partial class ActualStateDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualStateDialog));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labelFlightRegime = new MetroFramework.Controls.MetroLabel();
			this.comboBoxFlightRegime = new System.Windows.Forms.ComboBox();
			this.lifelengthViewer_LastCompliance = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.delimiter1 = new SmartControls.General.Delimiter();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label2 = new MetroFramework.Controls.MetroLabel();
			this.textBox_Remarks = new MetroFramework.Controls.MetroTextBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labelFlightRegime);
			this.groupBox1.Controls.Add(this.comboBoxFlightRegime);
			this.groupBox1.Controls.Add(this.lifelengthViewer_LastCompliance);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.delimiter1);
			this.groupBox1.Controls.Add(this.dateTimePicker1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox_Remarks);
			this.groupBox1.Location = new System.Drawing.Point(6, 63);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(481, 262);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			// 
			// labelFlightRegime
			// 
			this.labelFlightRegime.AutoSize = true;
			this.labelFlightRegime.ForeColor = System.Drawing.Color.DimGray;
			this.labelFlightRegime.Location = new System.Drawing.Point(10, 110);
			this.labelFlightRegime.Name = "labelFlightRegime";
			this.labelFlightRegime.Size = new System.Drawing.Size(90, 19);
			this.labelFlightRegime.TabIndex = 11;
			this.labelFlightRegime.Text = "Flight regime:";
			// 
			// comboBoxFlightRegime
			// 
			this.comboBoxFlightRegime.Enabled = false;
			this.comboBoxFlightRegime.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.comboBoxFlightRegime.FormattingEnabled = true;
			this.comboBoxFlightRegime.Location = new System.Drawing.Point(126, 107);
			this.comboBoxFlightRegime.Name = "comboBoxFlightRegime";
			this.comboBoxFlightRegime.Size = new System.Drawing.Size(352, 26);
			this.comboBoxFlightRegime.TabIndex = 10;
			this.comboBoxFlightRegime.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFlightRegimeSelectedIndexChanged);
			// 
			// lifelengthViewer_LastCompliance
			// 
			this.lifelengthViewer_LastCompliance.Anchor = System.Windows.Forms.AnchorStyles.Right;
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
			this.lifelengthViewer_LastCompliance.LeftHeader = "Actual state:";
			this.lifelengthViewer_LastCompliance.Location = new System.Drawing.Point(22, 13);
			this.lifelengthViewer_LastCompliance.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_LastCompliance.Modified = false;
			this.lifelengthViewer_LastCompliance.Name = "lifelengthViewer_LastCompliance";
			this.lifelengthViewer_LastCompliance.ReadOnly = false;
			this.lifelengthViewer_LastCompliance.ShowCalendar = true;
			this.lifelengthViewer_LastCompliance.ShowFormattedCalendar = false;
			this.lifelengthViewer_LastCompliance.ShowMinutes = true;
			this.lifelengthViewer_LastCompliance.Size = new System.Drawing.Size(456, 52);
			this.lifelengthViewer_LastCompliance.SystemCalculated = true;
			this.lifelengthViewer_LastCompliance.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(70, 78);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Date:";
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(7, 140);
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
			this.dateTimePicker1.Location = new System.Drawing.Point(126, 76);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(352, 20);
			this.dateTimePicker1.TabIndex = 2;
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.DimGray;
			this.label2.Location = new System.Drawing.Point(39, 149);
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
			this.textBox_Remarks.CustomButton.Location = new System.Drawing.Point(248, 2);
			this.textBox_Remarks.CustomButton.Name = "";
			this.textBox_Remarks.CustomButton.Size = new System.Drawing.Size(99, 99);
			this.textBox_Remarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBox_Remarks.CustomButton.TabIndex = 1;
			this.textBox_Remarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBox_Remarks.CustomButton.UseSelectable = true;
			this.textBox_Remarks.CustomButton.Visible = false;
			this.textBox_Remarks.Lines = new string[0];
			this.textBox_Remarks.Location = new System.Drawing.Point(128, 149);
			this.textBox_Remarks.MaxLength = 32767;
			this.textBox_Remarks.Multiline = true;
			this.textBox_Remarks.Name = "textBox_Remarks";
			this.textBox_Remarks.PasswordChar = '\0';
			this.textBox_Remarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBox_Remarks.SelectedText = "";
			this.textBox_Remarks.SelectionLength = 0;
			this.textBox_Remarks.SelectionStart = 0;
			this.textBox_Remarks.ShortcutsEnabled = true;
			this.textBox_Remarks.Size = new System.Drawing.Size(350, 104);
			this.textBox_Remarks.TabIndex = 4;
			this.textBox_Remarks.UseSelectable = true;
			this.textBox_Remarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBox_Remarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(412, 326);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 19;
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
			this.buttonOk.Location = new System.Drawing.Point(331, 326);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 18;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// ActualStateDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 369);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.groupBox1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ActualStateDialog";
			this.ShowIcon = false;
			this.Text = "Actual State Dialog";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.GroupBox groupBox1;
		public LifelengthViewer lifelengthViewer_LastCompliance;
		public MetroLabel label1;
		public SmartControls.General.Delimiter delimiter1;
		public System.Windows.Forms.DateTimePicker dateTimePicker1;
		public MetroLabel label2;
		public MetroTextBox textBox_Remarks;
		public System.Windows.Forms.Button buttonCancel;
		public System.Windows.Forms.Button buttonOk;
		public MetroLabel labelFlightRegime;
		private System.Windows.Forms.ComboBox comboBoxFlightRegime;
	}
}