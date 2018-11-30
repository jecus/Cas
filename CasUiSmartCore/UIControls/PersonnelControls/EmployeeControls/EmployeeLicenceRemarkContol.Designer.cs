namespace CAS.UI.UIControls.PersonnelControls.EmployeeControls
{
	partial class EmployeeLicenceRemarkControl
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
			this.labelRestriction = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.dateTimePickerIssue = new System.Windows.Forms.DateTimePicker();
			this.labelIssue = new System.Windows.Forms.Label();
			this.dictionaryComboBoxRestriction = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.dictionaryComboBoxRights = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.SuspendLayout();
			// 
			// labelRestriction
			// 
			this.labelRestriction.AutoSize = true;
			this.labelRestriction.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelRestriction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRestriction.Location = new System.Drawing.Point(105, 0);
			this.labelRestriction.Name = "labelRestriction";
			this.labelRestriction.Size = new System.Drawing.Size(78, 14);
			this.labelRestriction.TabIndex = 36;
			this.labelRestriction.Text = "Restriction:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(400, 0);
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
			// dictionaryComboBoxRestriction
			// 
			this.dictionaryComboBoxRestriction.Displayer = null;
			this.dictionaryComboBoxRestriction.DisplayerText = null;
			this.dictionaryComboBoxRestriction.Entity = null;
			this.dictionaryComboBoxRestriction.Location = new System.Drawing.Point(4, 17);
			this.dictionaryComboBoxRestriction.Name = "dictionaryComboBoxRestriction";
			this.dictionaryComboBoxRestriction.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboBoxRestriction.Size = new System.Drawing.Size(295, 21);
			this.dictionaryComboBoxRestriction.TabIndex = 49;
			// 
			// dictionaryComboBoxRights
			// 
			this.dictionaryComboBoxRights.Displayer = null;
			this.dictionaryComboBoxRights.DisplayerText = null;
			this.dictionaryComboBoxRights.Entity = null;
			this.dictionaryComboBoxRights.Location = new System.Drawing.Point(305, 17);
			this.dictionaryComboBoxRights.Name = "dictionaryComboBoxRights";
			this.dictionaryComboBoxRights.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboBoxRights.Size = new System.Drawing.Size(267, 21);
			this.dictionaryComboBoxRights.TabIndex = 50;
			// 
			// EmployeeLicenceRemarkControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dictionaryComboBoxRights);
			this.Controls.Add(this.dictionaryComboBoxRestriction);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.dateTimePickerIssue);
			this.Controls.Add(this.labelIssue);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelRestriction);
			this.Name = "EmployeeLicenceRemarkControl";
			this.Size = new System.Drawing.Size(834, 47);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelRestriction;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.DateTimePicker dateTimePickerIssue;
		private System.Windows.Forms.Label labelIssue;
		private Auxiliary.DictionaryComboBox dictionaryComboBoxRestriction;
		private Auxiliary.DictionaryComboBox dictionaryComboBoxRights;
	}
}
