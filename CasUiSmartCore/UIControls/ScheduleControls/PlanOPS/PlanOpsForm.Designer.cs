namespace CAS.UI.UIControls.ScheduleControls.PlanOPS
{
	partial class PlanOpsForm
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
			System.Windows.Forms.Label labelSubType;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label11;
			this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			labelSubType = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelSubType
			// 
			labelSubType.AutoSize = true;
			labelSubType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelSubType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelSubType.Location = new System.Drawing.Point(12, 15);
			labelSubType.Name = "labelSubType";
			labelSubType.Size = new System.Drawing.Size(43, 14);
			labelSubType.TabIndex = 12;
			labelSubType.Text = "From:";
			labelSubType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label1.Location = new System.Drawing.Point(12, 41);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(26, 14);
			label1.TabIndex = 15;
			label1.Text = "To:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label11.Location = new System.Drawing.Point(12, 64);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(66, 14);
			label11.TabIndex = 276;
			label11.Text = "Remarks:";
			label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dateTimePickerFrom
			// 
			this.dateTimePickerFrom.Location = new System.Drawing.Point(84, 12);
			this.dateTimePickerFrom.Name = "dateTimePickerFrom";
			this.dateTimePickerFrom.Size = new System.Drawing.Size(231, 20);
			this.dateTimePickerFrom.TabIndex = 14;
			this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);
			this.dateTimePickerFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePickerFrom_KeyPress);
			// 
			// dateTimePickerTo
			// 
			this.dateTimePickerTo.Enabled = false;
			this.dateTimePickerTo.Location = new System.Drawing.Point(84, 38);
			this.dateTimePickerTo.Name = "dateTimePickerTo";
			this.dateTimePickerTo.Size = new System.Drawing.Size(231, 20);
			this.dateTimePickerTo.TabIndex = 16;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.Location = new System.Drawing.Point(84, 64);
			this.textBoxRemarks.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.textBoxRemarks.MaxLength = 1024;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.Size = new System.Drawing.Size(231, 66);
			this.textBoxRemarks.TabIndex = 275;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(166, 146);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 278;
			this.buttonCancel.Text = "OK";
			this.buttonCancel.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(247, 146);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(85, 33);
			this.buttonOk.TabIndex = 277;
			this.buttonOk.Text = "Cancel";
			this.buttonOk.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// PlanOpsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(335, 181);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(label11);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(this.dateTimePickerTo);
			this.Controls.Add(label1);
			this.Controls.Add(this.dateTimePickerFrom);
			this.Controls.Add(labelSubType);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PlanOpsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PlanOpsForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
		private System.Windows.Forms.DateTimePicker dateTimePickerTo;
		private System.Windows.Forms.TextBox textBoxRemarks;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOk;
	}
}