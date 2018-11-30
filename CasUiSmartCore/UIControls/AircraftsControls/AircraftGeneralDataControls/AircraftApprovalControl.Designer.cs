namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
	partial class AircraftApprovalControl
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
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.aircraftParametrComboBox = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.SuspendLayout();
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Location = new System.Drawing.Point(220, 4);
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(177, 20);
			this.textBoxDescription.TabIndex = 1;
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(403, 2);
			this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(26, 23);
			this.buttonDelete.TabIndex = 44;
			this.buttonDelete.Text = "-";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// aircraftParametrComboBox
			// 
			this.aircraftParametrComboBox.Displayer = null;
			this.aircraftParametrComboBox.DisplayerText = null;
			this.aircraftParametrComboBox.Entity = null;
			this.aircraftParametrComboBox.Location = new System.Drawing.Point(4, 2);
			this.aircraftParametrComboBox.Name = "aircraftParametrComboBox";
			this.aircraftParametrComboBox.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.aircraftParametrComboBox.Size = new System.Drawing.Size(210, 21);
			this.aircraftParametrComboBox.TabIndex = 45;
			// 
			// AircraftApprovalControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.aircraftParametrComboBox);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.textBoxDescription);
			this.Name = "AircraftApprovalControl";
			this.Size = new System.Drawing.Size(438, 28);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.Button buttonDelete;
		private Auxiliary.DictionaryComboBox aircraftParametrComboBox;
	}
}
