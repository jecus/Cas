using MetroFramework.Controls;

namespace CAS.UI.UIControls.ScheduleControls
{
	partial class SchedulePeriodForm
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
			MetroFramework.Controls.MetroLabel labelDepartment;
			MetroFramework.Controls.MetroLabel label1;
			MetroFramework.Controls.MetroLabel labelValidFrom;
			MetroFramework.Controls.MetroLabel label2;
			MetroFramework.Controls.MetroLabel label3;
			MetroFramework.Controls.MetroLabel label4;
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.dateTimePickerSummerFrom = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerSummerTo = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerWinterTo = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerWinterFrom = new System.Windows.Forms.DateTimePicker();
			labelDepartment = new MetroFramework.Controls.MetroLabel();
			label1 = new MetroFramework.Controls.MetroLabel();
			labelValidFrom = new MetroFramework.Controls.MetroLabel();
			label2 = new MetroFramework.Controls.MetroLabel();
			label3 = new MetroFramework.Controls.MetroLabel();
			label4 = new MetroFramework.Controls.MetroLabel();
			this.SuspendLayout();
			// 
			// labelDepartment
			// 
			labelDepartment.AutoSize = true;
			labelDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelDepartment.Location = new System.Drawing.Point(15, 63);
			labelDepartment.Name = "labelDepartment";
			labelDepartment.Size = new System.Drawing.Size(59, 19);
			labelDepartment.TabIndex = 50;
			labelDepartment.Text = "Summer";
			labelDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label1.Location = new System.Drawing.Point(15, 91);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(48, 19);
			label1.TabIndex = 51;
			label1.Text = "Winter";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelValidFrom
			// 
			labelValidFrom.AutoSize = true;
			labelValidFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelValidFrom.Location = new System.Drawing.Point(79, 63);
			labelValidFrom.Name = "labelValidFrom";
			labelValidFrom.Size = new System.Drawing.Size(41, 19);
			labelValidFrom.TabIndex = 53;
			labelValidFrom.Text = "From";
			labelValidFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label2.Location = new System.Drawing.Point(251, 63);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(22, 19);
			label2.TabIndex = 55;
			label2.Text = "To";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label3.Location = new System.Drawing.Point(251, 91);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(22, 19);
			label3.TabIndex = 59;
			label3.Text = "To";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label4.Location = new System.Drawing.Point(79, 91);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(41, 19);
			label4.TabIndex = 57;
			label4.Text = "From";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(234, 128);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(85, 33);
			this.buttonOk.TabIndex = 19;
			this.buttonOk.Text = "Ok";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonClose.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonClose.Location = new System.Drawing.Point(325, 128);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 33);
			this.buttonClose.TabIndex = 18;
			this.buttonClose.Text = "Close";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// dateTimePickerSummerFrom
			// 
			this.dateTimePickerSummerFrom.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerSummerFrom.CustomFormat = "dd MMMM";
			this.dateTimePickerSummerFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerSummerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerSummerFrom.Location = new System.Drawing.Point(123, 63);
			this.dateTimePickerSummerFrom.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerSummerFrom.Name = "dateTimePickerSummerFrom";
			this.dateTimePickerSummerFrom.Size = new System.Drawing.Size(122, 22);
			this.dateTimePickerSummerFrom.TabIndex = 52;
			// 
			// dateTimePickerSummerTo
			// 
			this.dateTimePickerSummerTo.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerSummerTo.CustomFormat = "dd MMMM";
			this.dateTimePickerSummerTo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerSummerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerSummerTo.Location = new System.Drawing.Point(278, 63);
			this.dateTimePickerSummerTo.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerSummerTo.Name = "dateTimePickerSummerTo";
			this.dateTimePickerSummerTo.Size = new System.Drawing.Size(122, 22);
			this.dateTimePickerSummerTo.TabIndex = 54;
			// 
			// dateTimePickerWinterTo
			// 
			this.dateTimePickerWinterTo.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerWinterTo.CustomFormat = "dd MMMM";
			this.dateTimePickerWinterTo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerWinterTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerWinterTo.Location = new System.Drawing.Point(278, 91);
			this.dateTimePickerWinterTo.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerWinterTo.Name = "dateTimePickerWinterTo";
			this.dateTimePickerWinterTo.Size = new System.Drawing.Size(122, 22);
			this.dateTimePickerWinterTo.TabIndex = 58;
			// 
			// dateTimePickerWinterFrom
			// 
			this.dateTimePickerWinterFrom.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerWinterFrom.CustomFormat = "dd MMMM";
			this.dateTimePickerWinterFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerWinterFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerWinterFrom.Location = new System.Drawing.Point(123, 91);
			this.dateTimePickerWinterFrom.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerWinterFrom.Name = "dateTimePickerWinterFrom";
			this.dateTimePickerWinterFrom.Size = new System.Drawing.Size(122, 22);
			this.dateTimePickerWinterFrom.TabIndex = 56;
			// 
			// SchedulePeriodForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(418, 176);
			this.Controls.Add(label3);
			this.Controls.Add(this.dateTimePickerWinterTo);
			this.Controls.Add(label4);
			this.Controls.Add(this.dateTimePickerWinterFrom);
			this.Controls.Add(label2);
			this.Controls.Add(this.dateTimePickerSummerTo);
			this.Controls.Add(labelValidFrom);
			this.Controls.Add(this.dateTimePickerSummerFrom);
			this.Controls.Add(label1);
			this.Controls.Add(labelDepartment);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonClose);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SchedulePeriodForm";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Schedule Period";
			this.Load += new System.EventHandler(this.SchedulePeriodForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.DateTimePicker dateTimePickerSummerFrom;
		private System.Windows.Forms.DateTimePicker dateTimePickerSummerTo;
		private System.Windows.Forms.DateTimePicker dateTimePickerWinterTo;
		private System.Windows.Forms.DateTimePicker dateTimePickerWinterFrom;
	}
}