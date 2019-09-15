using CAS.UI.Helpers;

namespace CAS.UI.UIControls.Auxiliary
{
	partial class ReplaceComponentFormItem
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
			this.dateTimePickerConfirmDate = new System.Windows.Forms.DateTimePicker();
			this.comboBoxReplaceByDetail = new System.Windows.Forms.ComboBox();
			this.dateTimePickerReplaceByDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxReplacedDetails = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// dateTimePickerConfirmDate
			// 
			this.dateTimePickerConfirmDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerConfirmDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerConfirmDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerConfirmDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerConfirmDate.Location = new System.Drawing.Point(0, 3);
			this.dateTimePickerConfirmDate.Name = "dateTimePickerConfirmDate";
			this.dateTimePickerConfirmDate.Size = new System.Drawing.Size(123, 22);
			this.dateTimePickerConfirmDate.TabIndex = 26;
			// 
			// comboBoxReplaceByDetail
			// 
			this.comboBoxReplaceByDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxReplaceByDetail.FormattingEnabled = true;
			this.comboBoxReplaceByDetail.Location = new System.Drawing.Point(643, 4);
			this.comboBoxReplaceByDetail.Name = "comboBoxReplaceByDetail";
			this.comboBoxReplaceByDetail.Size = new System.Drawing.Size(510, 21);
			this.comboBoxReplaceByDetail.TabIndex = 67;
			this.comboBoxReplaceByDetail.SelectedIndexChanged += new System.EventHandler(this.ComboBoxReplaceByDetailSelectedIndexChanged);
			this.comboBoxReplaceByDetail.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// dateTimePickerReplaceByDate
			// 
			this.dateTimePickerReplaceByDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerReplaceByDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerReplaceByDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerReplaceByDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerReplaceByDate.Location = new System.Drawing.Point(1157, 4);
			this.dateTimePickerReplaceByDate.Name = "dateTimePickerReplaceByDate";
			this.dateTimePickerReplaceByDate.Size = new System.Drawing.Size(123, 22);
			this.dateTimePickerReplaceByDate.TabIndex = 68;
			// 
			// textBoxReplacedDetails
			// 
			this.textBoxReplacedDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxReplacedDetails.Location = new System.Drawing.Point(129, 4);
			this.textBoxReplacedDetails.Name = "textBoxReplacedDetails";
			this.textBoxReplacedDetails.ReadOnly = true;
			this.textBoxReplacedDetails.Size = new System.Drawing.Size(510, 20);
			this.textBoxReplacedDetails.TabIndex = 72;
			// 
			// ReplaceComponentFormItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.textBoxReplacedDetails);
			this.Controls.Add(this.dateTimePickerReplaceByDate);
			this.Controls.Add(this.comboBoxReplaceByDetail);
			this.Controls.Add(this.dateTimePickerConfirmDate);
			this.Name = "ReplaceComponentFormItem";
			this.Size = new System.Drawing.Size(1280, 28);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dateTimePickerConfirmDate;
		public System.Windows.Forms.ComboBox comboBoxReplaceByDetail;
		private System.Windows.Forms.DateTimePicker dateTimePickerReplaceByDate;
		private System.Windows.Forms.TextBox textBoxReplacedDetails;
	}
}
