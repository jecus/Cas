using MetroFramework.Controls;

namespace CAS.UI.UIControls.ScheduleControls.PlanOPS
{
	partial class AddAircraftPlanOpsForm
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
			MetroFramework.Controls.MetroLabel labelSubType;
			this.comboBoxAircrafts = new System.Windows.Forms.ComboBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			labelSubType = new MetroFramework.Controls.MetroLabel();
			this.SuspendLayout();
			// 
			// labelSubType
			// 
			labelSubType.AutoSize = true;
			labelSubType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelSubType.Location = new System.Drawing.Point(14, 63);
			labelSubType.Name = "labelSubType";
			labelSubType.Size = new System.Drawing.Size(55, 19);
			labelSubType.TabIndex = 13;
			labelSubType.Text = "Aircraft:";
			labelSubType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboBoxAircrafts
			// 
			this.comboBoxAircrafts.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxAircrafts.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxAircrafts.FormattingEnabled = true;
			this.comboBoxAircrafts.Location = new System.Drawing.Point(120, 63);
			this.comboBoxAircrafts.Name = "comboBoxAircrafts";
			this.comboBoxAircrafts.Size = new System.Drawing.Size(236, 22);
			this.comboBoxAircrafts.TabIndex = 12;
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(190, 105);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 247;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDelete.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonDelete.Location = new System.Drawing.Point(271, 105);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(85, 33);
			this.buttonDelete.TabIndex = 246;
			this.buttonDelete.Text = "Cancel";
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// AddAircraftPlanOpsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(363, 150);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(labelSubType);
			this.Controls.Add(this.comboBoxAircrafts);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddAircraftPlanOpsForm";
			this.Resizable = false;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Add Aircraft Plan Ops Form";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxAircrafts;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonDelete;
	}
}