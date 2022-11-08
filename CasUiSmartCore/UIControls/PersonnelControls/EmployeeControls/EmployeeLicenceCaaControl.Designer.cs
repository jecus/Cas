using System.Windows.Forms;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.PersonnelControls.EmployeeControls
{
	partial class EmployeeLicenceCaaControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeLicenceCaaControl));
			this.dateTimePickerValidToCAA = new System.Windows.Forms.DateTimePicker();
			this.labelIssueBy = new System.Windows.Forms.Label();
			this.comboBoxCAA = new System.Windows.Forms.ComboBox();
			this.labelCAA = new System.Windows.Forms.Label();
			this.textBoxCAANumber = new System.Windows.Forms.TextBox();
			this.labelNumber = new System.Windows.Forms.Label();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.dateTimePickerIssueDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.lifelengthViewer1 = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.checkBoxIsValid = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// dateTimePickerValidToCAA
			// 
			this.dateTimePickerValidToCAA.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerValidToCAA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerValidToCAA.Location = new System.Drawing.Point(83, 39);
			this.dateTimePickerValidToCAA.Name = "dateTimePickerValidToCAA";
			this.dateTimePickerValidToCAA.Size = new System.Drawing.Size(166, 22);
			this.dateTimePickerValidToCAA.TabIndex = 40;
			// 
			// labelIssueBy
			// 
			this.labelIssueBy.AutoSize = true;
			this.labelIssueBy.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelIssueBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelIssueBy.Location = new System.Drawing.Point(27, 43);
			this.labelIssueBy.Name = "labelIssueBy";
			this.labelIssueBy.Size = new System.Drawing.Size(59, 14);
			this.labelIssueBy.TabIndex = 39;
			this.labelIssueBy.Text = "Valid To:";
			// 
			// comboBoxCAA
			// 
			this.comboBoxCAA.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxCAA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxCAA.FormattingEnabled = true;
			this.comboBoxCAA.Location = new System.Drawing.Point(334, 0);
			this.comboBoxCAA.Name = "comboBoxCAA";
			this.comboBoxCAA.Size = new System.Drawing.Size(342, 25);
			this.comboBoxCAA.TabIndex = 38;
			this.comboBoxCAA.AutoCompleteMode = AutoCompleteMode.Suggest;
			this.comboBoxCAA.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBoxCAA.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelCAA
			// 
			this.labelCAA.AutoSize = true;
			this.labelCAA.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCAA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCAA.Location = new System.Drawing.Point(233, 4);
			this.labelCAA.Name = "labelCAA";
			this.labelCAA.Size = new System.Drawing.Size(95, 14);
			this.labelCAA.TabIndex = 37;
			this.labelCAA.Text = "Issue by CAA:";
			// 
			// textBoxCAANumber
			// 
			this.textBoxCAANumber.BackColor = System.Drawing.Color.White;
			this.textBoxCAANumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxCAANumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxCAANumber.Location = new System.Drawing.Point(32, 2);
			this.textBoxCAANumber.MaxLength = 200;
			this.textBoxCAANumber.Name = "textBoxCAANumber";
			this.textBoxCAANumber.Size = new System.Drawing.Size(195, 22);
			this.textBoxCAANumber.TabIndex = 36;
			// 
			// labelNumber
			// 
			this.labelNumber.AutoSize = true;
			this.labelNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNumber.Location = new System.Drawing.Point(5, 5);
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.Size = new System.Drawing.Size(21, 14);
			this.labelNumber.TabIndex = 35;
			this.labelNumber.Text = "№";
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(682, 0);
			this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(26, 23);
			this.buttonDelete.TabIndex = 45;
			this.buttonDelete.Text = "-";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Visible = false;
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click_1);
			// 
			// dateTimePickerIssueDate
			// 
			this.dateTimePickerIssueDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerIssueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerIssueDate.Location = new System.Drawing.Point(308, 39);
			this.dateTimePickerIssueDate.Name = "dateTimePickerIssueDate";
			this.dateTimePickerIssueDate.Size = new System.Drawing.Size(166, 22);
			this.dateTimePickerIssueDate.TabIndex = 47;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(255, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 14);
			this.label1.TabIndex = 46;
			this.label1.Text = "Issue:";
			// 
			// lifelengthViewer1
			// 
			this.lifelengthViewer1.AutoSize = true;
			this.lifelengthViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer1.CalendarApplicable = false;
			this.lifelengthViewer1.CyclesApplicable = false;
			this.lifelengthViewer1.EnabledCalendar = true;
			this.lifelengthViewer1.EnabledCycle = true;
			this.lifelengthViewer1.EnabledHours = true;
			this.lifelengthViewer1.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer1.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer1.HeaderCalendar = "Calendar";
			this.lifelengthViewer1.HeaderCycles = "Cycles";
			this.lifelengthViewer1.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer1.HeaderHours = "Hours";
			this.lifelengthViewer1.HoursApplicable = false;
			this.lifelengthViewer1.LeftHeader = "Notify";
			this.lifelengthViewer1.Location = new System.Drawing.Point(479, 31);
			this.lifelengthViewer1.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer1.Modified = false;
			this.lifelengthViewer1.Name = "lifelengthViewer1";
			this.lifelengthViewer1.ReadOnly = false;
			this.lifelengthViewer1.ShowCalendar = true;
			this.lifelengthViewer1.ShowCalendarOnly = true;
			this.lifelengthViewer1.ShowFormattedCalendar = false;
			this.lifelengthViewer1.ShowHeaders = false;
			this.lifelengthViewer1.ShowMinutes = true;
			this.lifelengthViewer1.Size = new System.Drawing.Size(225, 35);
			this.lifelengthViewer1.SystemCalculated = true;
			this.lifelengthViewer1.TabIndex = 48;
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(44, 71);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(664, 41);
			this.documentControl1.TabIndex = 49;
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(8, 110);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter1.Size = new System.Drawing.Size(710, 2);
			this.delimiter1.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Solid;
			this.delimiter1.TabIndex = 50;
			// 
			// checkBoxIsValid
			// 
			this.checkBoxIsValid.AutoSize = true;
			this.checkBoxIsValid.Font = new System.Drawing.Font("Verdana", 9F);
			this.checkBoxIsValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxIsValid.Location = new System.Drawing.Point(5, 44);
			this.checkBoxIsValid.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
			this.checkBoxIsValid.Name = "checkBoxIsValid";
			this.checkBoxIsValid.Size = new System.Drawing.Size(15, 14);
			this.checkBoxIsValid.TabIndex = 51;
			this.checkBoxIsValid.UseVisualStyleBackColor = true;
			this.checkBoxIsValid.CheckedChanged += new System.EventHandler(this.checkBoxIsValid_CheckedChanged);
			// 
			// EmployeeLicenceCaaControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkBoxIsValid);
			this.Controls.Add(this.delimiter1);
			this.Controls.Add(this.documentControl1);
			this.Controls.Add(this.lifelengthViewer1);
			this.Controls.Add(this.dateTimePickerIssueDate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.dateTimePickerValidToCAA);
			this.Controls.Add(this.labelIssueBy);
			this.Controls.Add(this.comboBoxCAA);
			this.Controls.Add(this.labelCAA);
			this.Controls.Add(this.textBoxCAANumber);
			this.Controls.Add(this.labelNumber);
			this.Name = "EmployeeLicenceCaaControl";
			this.Size = new System.Drawing.Size(739, 129);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.CheckBox checkBoxIsValid;

		#endregion

		private System.Windows.Forms.DateTimePicker dateTimePickerValidToCAA;
		private System.Windows.Forms.Label labelIssueBy;
		private System.Windows.Forms.ComboBox comboBoxCAA;
		private System.Windows.Forms.Label labelCAA;
		private System.Windows.Forms.TextBox textBoxCAANumber;
		private System.Windows.Forms.Label labelNumber;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.DateTimePicker dateTimePickerIssueDate;
		private System.Windows.Forms.Label label1;
		private CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthViewer1;
		private CAS.UI.UIControls.DocumentationControls.DocumentControl documentControl1;
		private CAS.UI.UIControls.Auxiliary.Delimiter delimiter1;
	}
}
