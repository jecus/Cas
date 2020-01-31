using System.Threading;
using MetroFramework.Controls;

namespace CAS.UI.UIControls.LDND
{
	partial class LDNDForecastForm
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
				if (_checkItems != null)
					_checkItems.Clear();

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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.labelHours = new MetroFramework.Controls.MetroLabel();
			this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownCycles = new System.Windows.Forms.NumericUpDown();
			this.labelCycles = new MetroFramework.Controls.MetroLabel();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.checkBox1 = new MetroFramework.Controls.MetroCheckBox();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCycles)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button1.Location = new System.Drawing.Point(164, 196);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 33);
			this.button1.TabIndex = 2;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button2.Location = new System.Drawing.Point(245, 196);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 33);
			this.button2.TabIndex = 3;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// labelHours
			// 
			this.labelHours.AutoSize = true;
			this.labelHours.ForeColor = System.Drawing.Color.DimGray;
			this.labelHours.Location = new System.Drawing.Point(8, 89);
			this.labelHours.Name = "labelHours";
			this.labelHours.Size = new System.Drawing.Size(62, 19);
			this.labelHours.TabIndex = 42;
			this.labelHours.Text = "HRS/DAY";
			// 
			// numericUpDownHours
			// 
			this.numericUpDownHours.DecimalPlaces = 2;
			this.numericUpDownHours.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.numericUpDownHours.ForeColor = System.Drawing.Color.DimGray;
			this.numericUpDownHours.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDownHours.Location = new System.Drawing.Point(89, 89);
			this.numericUpDownHours.Maximum = new decimal(new int[] {
            744,
            0,
            0,
            0});
			this.numericUpDownHours.Name = "numericUpDownHours";
			this.numericUpDownHours.Size = new System.Drawing.Size(231, 22);
			this.numericUpDownHours.TabIndex = 48;
			this.numericUpDownHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownHours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownHours.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
			// 
			// numericUpDownCycles
			// 
			this.numericUpDownCycles.DecimalPlaces = 2;
			this.numericUpDownCycles.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.numericUpDownCycles.ForeColor = System.Drawing.Color.DimGray;
			this.numericUpDownCycles.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDownCycles.Location = new System.Drawing.Point(89, 114);
			this.numericUpDownCycles.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
			this.numericUpDownCycles.Name = "numericUpDownCycles";
			this.numericUpDownCycles.Size = new System.Drawing.Size(231, 22);
			this.numericUpDownCycles.TabIndex = 49;
			this.numericUpDownCycles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownCycles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownCycles.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
			// 
			// labelCycles
			// 
			this.labelCycles.AutoSize = true;
			this.labelCycles.ForeColor = System.Drawing.Color.DimGray;
			this.labelCycles.Location = new System.Drawing.Point(8, 114);
			this.labelCycles.Name = "labelCycles";
			this.labelCycles.Size = new System.Drawing.Size(64, 19);
			this.labelCycles.TabIndex = 41;
			this.labelCycles.Text = "HRS/CYC";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(8, 139);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 19);
			this.label1.TabIndex = 50;
			this.label1.Text = "CYC/DAY";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 2;
			this.numericUpDown1.Enabled = false;
			this.numericUpDown1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.numericUpDown1.ForeColor = System.Drawing.Color.DimGray;
			this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDown1.Location = new System.Drawing.Point(89, 139);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(231, 22);
			this.numericUpDown1.TabIndex = 51;
			this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(181, 166);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(139, 15);
			this.checkBox1.TabIndex = 63;
			this.checkBox1.Text = "Use current Utilization";
			this.checkBox1.UseSelectable = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.ForeColor = System.Drawing.Color.DimGray;
			this.metroLabel1.Location = new System.Drawing.Point(8, 63);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(68, 19);
			this.metroLabel1.TabIndex = 64;
			this.metroLabel1.Text = "Date as of";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePicker1.Location = new System.Drawing.Point(89, 63);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(231, 22);
			this.dateTimePicker1.TabIndex = 65;
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
			// 
			// LDNDForecastForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(337, 241);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.metroLabel1);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.labelCycles);
			this.Controls.Add(this.numericUpDownCycles);
			this.Controls.Add(this.labelHours);
			this.Controls.Add(this.numericUpDownHours);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LDNDForecastForm";
			this.Resizable = false;
			this.Text = "LDND Forecast Form";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCycles)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private MetroLabel labelHours;
		private System.Windows.Forms.NumericUpDown numericUpDownHours;
		private System.Windows.Forms.NumericUpDown numericUpDownCycles;
		private MetroLabel labelCycles;
		private MetroLabel label1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private MetroCheckBox checkBox1;
		private MetroLabel metroLabel1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
	}
}