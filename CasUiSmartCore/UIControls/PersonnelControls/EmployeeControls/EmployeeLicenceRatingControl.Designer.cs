using CAS.UI.Helpers;

namespace CAS.UI.UIControls.PersonnelControls.EmployeeControls
{
	partial class EmployeeLicenceRatingControl
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
			this.labelFunction = new System.Windows.Forms.Label();
			this.comboBoxFunction = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.dateTimePickerIssue = new System.Windows.Forms.DateTimePicker();
			this.labelIssue = new System.Windows.Forms.Label();
			this.comboBoxRights = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// labelFunction
			// 
			this.labelFunction.AutoSize = true;
			this.labelFunction.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelFunction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFunction.Location = new System.Drawing.Point(107, 0);
			this.labelFunction.Name = "labelFunction";
			this.labelFunction.Size = new System.Drawing.Size(65, 14);
			this.labelFunction.TabIndex = 36;
			this.labelFunction.Text = "Function:";
			// 
			// comboBoxFunction
			// 
			this.comboBoxFunction.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxFunction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxFunction.FormattingEnabled = true;
			this.comboBoxFunction.Location = new System.Drawing.Point(6, 17);
			this.comboBoxFunction.Name = "comboBoxFunction";
			this.comboBoxFunction.Size = new System.Drawing.Size(288, 25);
			this.comboBoxFunction.TabIndex = 39;
			this.comboBoxFunction.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(402, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 14);
			this.label1.TabIndex = 40;
			this.label1.Text = "Rights:";
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(803, 17);
			this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(26, 23);
			this.buttonDelete.TabIndex = 48;
			this.buttonDelete.Text = "-";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click_1);
			// 
			// dateTimePickerIssue
			// 
			this.dateTimePickerIssue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerIssue.Location = new System.Drawing.Point(631, 17);
			this.dateTimePickerIssue.Name = "dateTimePickerIssue";
			this.dateTimePickerIssue.Size = new System.Drawing.Size(166, 22);
			this.dateTimePickerIssue.TabIndex = 47;
			// 
			// labelIssue
			// 
			this.labelIssue.AutoSize = true;
			this.labelIssue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelIssue.Location = new System.Drawing.Point(578, 22);
			this.labelIssue.Name = "labelIssue";
			this.labelIssue.Size = new System.Drawing.Size(47, 14);
			this.labelIssue.TabIndex = 46;
			this.labelIssue.Text = "Issue:";
			// 
			// comboBoxRights
			// 
			this.comboBoxRights.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxRights.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxRights.FormattingEnabled = true;
			this.comboBoxRights.Location = new System.Drawing.Point(300, 17);
			this.comboBoxRights.Name = "comboBoxRights";
			this.comboBoxRights.Size = new System.Drawing.Size(280, 25);
			this.comboBoxRights.TabIndex = 49;
			this.comboBoxRights.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// EmployeeLicenceRatingControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.comboBoxRights);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.dateTimePickerIssue);
			this.Controls.Add(this.labelIssue);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxFunction);
			this.Controls.Add(this.labelFunction);
			this.Name = "EmployeeLicenceRatingControl";
			this.Size = new System.Drawing.Size(834, 47);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelFunction;
		private System.Windows.Forms.ComboBox comboBoxFunction;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.DateTimePicker dateTimePickerIssue;
		private System.Windows.Forms.Label labelIssue;
		private System.Windows.Forms.ComboBox comboBoxRights;
	}
}
