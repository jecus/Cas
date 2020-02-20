namespace CAS.UI.UIControls.Users
{
	partial class CopyADToAircraftForm
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
			MetroFramework.Controls.MetroLabel labelAircraft;
			MetroFramework.Controls.MetroLabel labelApplicability;
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.checkedListBoxAircraft = new System.Windows.Forms.CheckedListBox();
			this.checkedListBoxApplicability = new System.Windows.Forms.CheckedListBox();
			labelAircraft = new MetroFramework.Controls.MetroLabel();
			labelApplicability = new MetroFramework.Controls.MetroLabel();
			this.SuspendLayout();
			// 
			// labelAircraft
			// 
			labelAircraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelAircraft.Location = new System.Drawing.Point(8, 36);
			labelAircraft.Name = "labelAircraft";
			labelAircraft.Size = new System.Drawing.Size(200, 19);
			labelAircraft.TabIndex = 28;
			labelAircraft.Text = "Aircraft";
			labelAircraft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelApplicability
			// 
			labelApplicability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelApplicability.Location = new System.Drawing.Point(222, 36);
			labelApplicability.Name = "labelApplicability";
			labelApplicability.Size = new System.Drawing.Size(199, 19);
			labelApplicability.TabIndex = 39;
			labelApplicability.Text = "Applicability";
			labelApplicability.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(346, 517);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 38;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(265, 517);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 37;
			this.buttonOk.Text = "Ok";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// checkedListBoxAircraft
			// 
			this.checkedListBoxAircraft.FormattingEnabled = true;
			this.checkedListBoxAircraft.Location = new System.Drawing.Point(8, 63);
			this.checkedListBoxAircraft.Name = "checkedListBoxAircraft";
			this.checkedListBoxAircraft.Size = new System.Drawing.Size(200, 439);
			this.checkedListBoxAircraft.TabIndex = 40;
			this.checkedListBoxAircraft.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxAircraft_SelectedIndexChanged);
			// 
			// checkedListBoxApplicability
			// 
			this.checkedListBoxApplicability.FormattingEnabled = true;
			this.checkedListBoxApplicability.Location = new System.Drawing.Point(222, 63);
			this.checkedListBoxApplicability.Name = "checkedListBoxApplicability";
			this.checkedListBoxApplicability.Size = new System.Drawing.Size(200, 439);
			this.checkedListBoxApplicability.TabIndex = 41;
			// 
			// CopyADToAircraftForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 562);
			this.Controls.Add(this.checkedListBoxApplicability);
			this.Controls.Add(this.checkedListBoxAircraft);
			this.Controls.Add(labelApplicability);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(labelAircraft);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CopyADToAircraftForm";
			this.Resizable = false;
			this.ResumeLayout(false);

		}

		#endregion
		public System.Windows.Forms.Button buttonCancel;
		public System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.CheckedListBox checkedListBoxAircraft;
		private System.Windows.Forms.CheckedListBox checkedListBoxApplicability;
	}
}