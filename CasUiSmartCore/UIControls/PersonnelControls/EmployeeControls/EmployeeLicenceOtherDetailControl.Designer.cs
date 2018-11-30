namespace CAS.UI.UIControls.PersonnelControls.EmployeeControls
{
	partial class EmployeeLicenceOtherDetailControl
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
			this.buttonDelete = new System.Windows.Forms.Button();
			this.dateTimePickerIssue = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.textboxDescription = new System.Windows.Forms.TextBox();
			this.labelIssue = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(803, 0);
			this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(26, 23);
			this.buttonDelete.TabIndex = 52;
			this.buttonDelete.Text = "-";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click_1);
			// 
			// dateTimePickerIssue
			// 
			this.dateTimePickerIssue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerIssue.Location = new System.Drawing.Point(631, 0);
			this.dateTimePickerIssue.Name = "dateTimePickerIssue";
			this.dateTimePickerIssue.Size = new System.Drawing.Size(166, 22);
			this.dateTimePickerIssue.TabIndex = 51;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(416, -17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 14);
			this.label1.TabIndex = 49;
			this.label1.Text = "Rights:";
			// 
			// textboxDescription
			// 
			this.textboxDescription.BackColor = System.Drawing.Color.White;
			this.textboxDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxDescription.Location = new System.Drawing.Point(3, 3);
			this.textboxDescription.MaxLength = 3000;
			this.textboxDescription.Multiline = true;
			this.textboxDescription.Name = "textboxDescription";
			this.textboxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textboxDescription.Size = new System.Drawing.Size(569, 60);
			this.textboxDescription.TabIndex = 53;
			// 
			// labelIssue
			// 
			this.labelIssue.AutoSize = true;
			this.labelIssue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelIssue.Location = new System.Drawing.Point(578, 4);
			this.labelIssue.Name = "labelIssue";
			this.labelIssue.Size = new System.Drawing.Size(47, 14);
			this.labelIssue.TabIndex = 54;
			this.labelIssue.Text = "Issue:";
			// 
			// EmployeeLicenceOtherDetailControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelIssue);
			this.Controls.Add(this.textboxDescription);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.dateTimePickerIssue);
			this.Controls.Add(this.label1);
			this.Name = "EmployeeLicenceOtherDetailControl";
			this.Size = new System.Drawing.Size(834, 66);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.DateTimePicker dateTimePickerIssue;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textboxDescription;
		private System.Windows.Forms.Label labelIssue;
	}
}
