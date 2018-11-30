namespace CAS.UI.UIControls.PersonnelControls.EmployeeControls
{
	partial class EmployeeMedicalControl
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
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxClass = new System.Windows.Forms.ComboBox();
			this.labelIssue = new System.Windows.Forms.Label();
			this.dateTimePickerClassIssue = new System.Windows.Forms.DateTimePicker();
			this.lifelengthViewerRepeat = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(3, 10);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 14);
			this.label1.TabIndex = 79;
			this.label1.Text = "Class:";
			// 
			// comboBoxClass
			// 
			this.comboBoxClass.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxClass.FormattingEnabled = true;
			this.comboBoxClass.Location = new System.Drawing.Point(77, 5);
			this.comboBoxClass.Name = "comboBoxClass";
			this.comboBoxClass.Size = new System.Drawing.Size(88, 25);
			this.comboBoxClass.TabIndex = 80;
			// 
			// labelIssue
			// 
			this.labelIssue.AutoSize = true;
			this.labelIssue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelIssue.Location = new System.Drawing.Point(171, 10);
			this.labelIssue.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.labelIssue.Name = "labelIssue";
			this.labelIssue.Size = new System.Drawing.Size(47, 14);
			this.labelIssue.TabIndex = 81;
			this.labelIssue.Text = "Issue:";
			// 
			// dateTimePickerClassIssue
			// 
			this.dateTimePickerClassIssue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerClassIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerClassIssue.Location = new System.Drawing.Point(224, 5);
			this.dateTimePickerClassIssue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
			this.dateTimePickerClassIssue.Name = "dateTimePickerClassIssue";
			this.dateTimePickerClassIssue.Size = new System.Drawing.Size(166, 22);
			this.dateTimePickerClassIssue.TabIndex = 82;
			// 
			// lifelengthViewerRepeat
			// 
			this.lifelengthViewerRepeat.AutoSize = true;
			this.lifelengthViewerRepeat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerRepeat.CalendarApplicable = false;
			this.lifelengthViewerRepeat.CyclesApplicable = false;
			this.lifelengthViewerRepeat.EnabledCalendar = true;
			this.lifelengthViewerRepeat.EnabledCycle = true;
			this.lifelengthViewerRepeat.EnabledHours = true;
			this.lifelengthViewerRepeat.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerRepeat.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerRepeat.HeaderCalendar = "Calendar";
			this.lifelengthViewerRepeat.HeaderCycles = "Cycles";
			this.lifelengthViewerRepeat.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerRepeat.HeaderHours = "Hours";
			this.lifelengthViewerRepeat.HoursApplicable = false;
			this.lifelengthViewerRepeat.LeftHeader = "Repeat";
			this.lifelengthViewerRepeat.Location = new System.Drawing.Point(395, 0);
			this.lifelengthViewerRepeat.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerRepeat.Modified = false;
			this.lifelengthViewerRepeat.Name = "lifelengthViewerRepeat";
			this.lifelengthViewerRepeat.ReadOnly = false;
			this.lifelengthViewerRepeat.ShowCalendar = true;
			this.lifelengthViewerRepeat.ShowCalendarOnly = true;
			this.lifelengthViewerRepeat.ShowFormattedCalendar = false;
			this.lifelengthViewerRepeat.ShowHeaders = false;
			this.lifelengthViewerRepeat.ShowMinutes = true;
			this.lifelengthViewerRepeat.Size = new System.Drawing.Size(233, 35);
			this.lifelengthViewerRepeat.SystemCalculated = true;
			this.lifelengthViewerRepeat.TabIndex = 84;
			// 
			// lifelengthViewerNotify
			// 
			this.lifelengthViewerNotify.AutoSize = true;
			this.lifelengthViewerNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerNotify.CalendarApplicable = false;
			this.lifelengthViewerNotify.CyclesApplicable = false;
			this.lifelengthViewerNotify.EnabledCalendar = true;
			this.lifelengthViewerNotify.EnabledCycle = true;
			this.lifelengthViewerNotify.EnabledHours = true;
			this.lifelengthViewerNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerNotify.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewerNotify.HeaderCycles = "Cycles";
			this.lifelengthViewerNotify.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerNotify.HeaderHours = "Hours";
			this.lifelengthViewerNotify.HoursApplicable = false;
			this.lifelengthViewerNotify.LeftHeader = "Notify";
			this.lifelengthViewerNotify.Location = new System.Drawing.Point(632, 0);
			this.lifelengthViewerNotify.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerNotify.Modified = false;
			this.lifelengthViewerNotify.Name = "lifelengthViewerNotify";
			this.lifelengthViewerNotify.ReadOnly = false;
			this.lifelengthViewerNotify.ShowCalendar = true;
			this.lifelengthViewerNotify.ShowCalendarOnly = true;
			this.lifelengthViewerNotify.ShowFormattedCalendar = false;
			this.lifelengthViewerNotify.ShowHeaders = false;
			this.lifelengthViewerNotify.ShowMinutes = true;
			this.lifelengthViewerNotify.Size = new System.Drawing.Size(225, 35);
			this.lifelengthViewerNotify.SystemCalculated = true;
			this.lifelengthViewerNotify.TabIndex = 85;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(3, 35);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 14);
			this.label2.TabIndex = 86;
			this.label2.Text = "Remarks:";
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.BackColor = System.Drawing.Color.White;
			this.textBoxRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxRemarks.Location = new System.Drawing.Point(77, 32);
			this.textBoxRemarks.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxRemarks.Size = new System.Drawing.Size(314, 75);
			this.textBoxRemarks.TabIndex = 87;
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(458, 32);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(399, 41);
			this.documentControl1.TabIndex = 88;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label3.Location = new System.Drawing.Point(400, 35);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 14);
			this.label3.TabIndex = 89;
			this.label3.Text = "Form:";
			// 
			// EmployeeMedicalControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.documentControl1);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lifelengthViewerNotify);
			this.Controls.Add(this.lifelengthViewerRepeat);
			this.Controls.Add(this.labelIssue);
			this.Controls.Add(this.dateTimePickerClassIssue);
			this.Controls.Add(this.comboBoxClass);
			this.Controls.Add(this.label1);
			this.Name = "EmployeeMedicalControl";
			this.Size = new System.Drawing.Size(870, 113);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxClass;
		private System.Windows.Forms.Label labelIssue;
		private System.Windows.Forms.DateTimePicker dateTimePickerClassIssue;
		private Auxiliary.LifelengthViewer lifelengthViewerRepeat;
		private Auxiliary.LifelengthViewer lifelengthViewerNotify;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxRemarks;
		private DocumentationControls.DocumentControl documentControl1;
		private System.Windows.Forms.Label label3;
	}
}
