namespace CAS.UI.UIControls.MailControls
{
	partial class MailChatAddingForm
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
			System.Windows.Forms.Label labelDescription;
			System.Windows.Forms.Label labelCreateDate;
			this.labelFrom = new System.Windows.Forms.Label();
			this.comboBoxSupplierFrom = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxSupplierTo = new System.Windows.Forms.ComboBox();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.dateTimePickerCreateDate = new System.Windows.Forms.DateTimePicker();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			labelDescription = new System.Windows.Forms.Label();
			labelCreateDate = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelDescription
			// 
			labelDescription.AutoSize = true;
			labelDescription.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelDescription.Location = new System.Drawing.Point(5, 70);
			labelDescription.Name = "labelDescription";
			labelDescription.Size = new System.Drawing.Size(82, 14);
			labelDescription.TabIndex = 235;
			labelDescription.Text = "Description:";
			labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelFrom
			// 
			this.labelFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFrom.Location = new System.Drawing.Point(6, 12);
			this.labelFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelFrom.Name = "labelFrom";
			this.labelFrom.Size = new System.Drawing.Size(72, 25);
			this.labelFrom.TabIndex = 205;
			this.labelFrom.Text = "From:";
			this.labelFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxSupplierFrom
			// 
			this.comboBoxSupplierFrom.BackColor = System.Drawing.Color.White;
			this.comboBoxSupplierFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxSupplierFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxSupplierFrom.Location = new System.Drawing.Point(101, 12);
			this.comboBoxSupplierFrom.Name = "comboBoxSupplierFrom";
			this.comboBoxSupplierFrom.Size = new System.Drawing.Size(250, 22);
			this.comboBoxSupplierFrom.TabIndex = 204;
			this.comboBoxSupplierFrom.SelectedIndexChanged += new System.EventHandler(this.comboBoxSupplierFrom_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(6, 40);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 25);
			this.label1.TabIndex = 207;
			this.label1.Text = "To:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxSupplierTo
			// 
			this.comboBoxSupplierTo.BackColor = System.Drawing.Color.White;
			this.comboBoxSupplierTo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxSupplierTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxSupplierTo.Location = new System.Drawing.Point(101, 40);
			this.comboBoxSupplierTo.Name = "comboBoxSupplierTo";
			this.comboBoxSupplierTo.Size = new System.Drawing.Size(250, 22);
			this.comboBoxSupplierTo.TabIndex = 206;
			this.comboBoxSupplierTo.SelectedIndexChanged += new System.EventHandler(this.comboBoxSupplierTo_SelectedIndexChanged);
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxDescription.Location = new System.Drawing.Point(101, 68);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(250, 80);
			this.textBoxDescription.TabIndex = 236;
			// 
			// labelCreateDate
			// 
			labelCreateDate.AutoSize = true;
			labelCreateDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelCreateDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelCreateDate.Location = new System.Drawing.Point(0, 160);
			labelCreateDate.Name = "labelCreateDate";
			labelCreateDate.Size = new System.Drawing.Size(89, 14);
			labelCreateDate.TabIndex = 238;
			labelCreateDate.Text = "Create Date:";
			labelCreateDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dateTimePickerCreateDate
			// 
			this.dateTimePickerCreateDate.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerCreateDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerCreateDate.Location = new System.Drawing.Point(101, 154);
			this.dateTimePickerCreateDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerCreateDate.Name = "dateTimePickerCreateDate";
			this.dateTimePickerCreateDate.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerCreateDate.TabIndex = 237;
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(195, 193);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 240;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonClose.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonClose.Location = new System.Drawing.Point(276, 193);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 33);
			this.buttonClose.TabIndex = 239;
			this.buttonClose.Text = "Cancel";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// MailChatAddingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(359, 238);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(labelCreateDate);
			this.Controls.Add(this.dateTimePickerCreateDate);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(labelDescription);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxSupplierTo);
			this.Controls.Add(this.labelFrom);
			this.Controls.Add(this.comboBoxSupplierFrom);
			this.MaximumSize = new System.Drawing.Size(375, 280);
			this.MinimumSize = new System.Drawing.Size(375, 280);
			this.Name = "MailChatAddingForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MailChatAddingForm";
			this.Load += new System.EventHandler(this.MailChatAddingForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelFrom;
		private System.Windows.Forms.ComboBox comboBoxSupplierFrom;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxSupplierTo;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.DateTimePicker dateTimePickerCreateDate;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonClose;
	}
}