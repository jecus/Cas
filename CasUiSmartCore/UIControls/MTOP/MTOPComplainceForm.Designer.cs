using MetroFramework.Controls;

namespace CAS.UI.UIControls.MTOP
{
	partial class MTOPComplainceForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MTOPComplainceForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.labelControlPoint = new MetroFramework.Controls.MetroLabel();
			this.checkBoxControlPoint = new MetroFramework.Controls.MetroCheckBox();
			this.lifelengthViewer_LastCompliance = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.delimiter2 = new SmartControls.General.Delimiter();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.delimiter1 = new SmartControls.General.Delimiter();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label2 = new MetroFramework.Controls.MetroLabel();
			this.textBox_Remarks = new MetroFramework.Controls.MetroTextBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.checkedListBox1);
			this.groupBox1.Controls.Add(this.labelControlPoint);
			this.groupBox1.Controls.Add(this.checkBoxControlPoint);
			this.groupBox1.Controls.Add(this.lifelengthViewer_LastCompliance);
			this.groupBox1.Controls.Add(this.delimiter2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.delimiter1);
			this.groupBox1.Controls.Add(this.dateTimePicker1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox_Remarks);
			this.groupBox1.Location = new System.Drawing.Point(5, 63);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(685, 253);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(499, 37);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(186, 199);
			this.checkedListBox1.TabIndex = 14;
			this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
			// 
			// labelControlPoint
			// 
			this.labelControlPoint.AutoSize = true;
			this.labelControlPoint.ForeColor = System.Drawing.Color.DimGray;
			this.labelControlPoint.Location = new System.Drawing.Point(7, 102);
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
			this.checkBoxControlPoint.Location = new System.Drawing.Point(141, 106);
			this.checkBoxControlPoint.Name = "checkBoxControlPoint";
			this.checkBoxControlPoint.Size = new System.Drawing.Size(16, 0);
			this.checkBoxControlPoint.TabIndex = 12;
			this.checkBoxControlPoint.UseSelectable = true;
			this.checkBoxControlPoint.Visible = false;
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
			this.lifelengthViewer_LastCompliance.Location = new System.Drawing.Point(16, 13);
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
			this.delimiter2.Location = new System.Drawing.Point(7, 245);
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
			this.label1.Location = new System.Drawing.Point(87, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Date:";
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(7, 126);
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
			this.dateTimePicker1.Location = new System.Drawing.Point(141, 70);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(347, 20);
			this.dateTimePicker1.TabIndex = 2;
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.DimGray;
			this.label2.Location = new System.Drawing.Point(56, 134);
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
			this.textBox_Remarks.Location = new System.Drawing.Point(143, 132);
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
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(534, 332);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 244;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button1.Location = new System.Drawing.Point(615, 332);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 33);
			this.button1.TabIndex = 245;
			this.button1.Text = "Сancel";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MTOPComplainceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(695, 377);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MTOPComplainceForm";
			this.Resizable = false;
			this.Text = "MTOP Complaince Form";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.GroupBox groupBox1;
		public MetroLabel labelControlPoint;
		private MetroCheckBox checkBoxControlPoint;
		public Auxiliary.LifelengthViewer lifelengthViewer_LastCompliance;
		public SmartControls.General.Delimiter delimiter2;
		public MetroLabel label1;
		public SmartControls.General.Delimiter delimiter1;
		public System.Windows.Forms.DateTimePicker dateTimePicker1;
		public MetroLabel label2;
		public MetroTextBox textBox_Remarks;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
	}
}