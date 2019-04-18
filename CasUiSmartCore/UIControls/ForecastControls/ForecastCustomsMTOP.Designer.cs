using System.Threading;
using MetroFramework.Controls;

namespace CAS.UI.UIControls.ForecastControls
{
    partial class ForecastCustomsMTOP
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
                if (_animatedThreadWorker.IsBusy)
                    _animatedThreadWorker.CancelAsync();

                while (_animatedThreadWorker.IsBusy)
                {
                    Thread.Sleep(500);
                }

                _animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
                _animatedThreadWorker.RunWorkerCompleted -= AnimatedThreadWorkerRunWorkerCompleted;
                _animatedThreadWorker.Dispose();

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
			this.tabPageCheck = new System.Windows.Forms.TabPage();
			this.radioButtonZero = new MetroFramework.Controls.MetroRadioButton();
			this.radioButtonAll = new MetroFramework.Controls.MetroRadioButton();
			this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
			this.labelTo = new MetroFramework.Controls.MetroLabel();
			this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
			this.labelPeriodFrom = new MetroFramework.Controls.MetroLabel();
			this.tabControlMain = new System.Windows.Forms.TabControl();
			this.numericUpDownCycles = new System.Windows.Forms.NumericUpDown();
			this.labelCycles = new MetroFramework.Controls.MetroLabel();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.checkBox1 = new MetroFramework.Controls.MetroCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
			this.tabPageCheck.SuspendLayout();
			this.tabControlMain.SuspendLayout();
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
			this.button1.Location = new System.Drawing.Point(169, 292);
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
			this.button2.Location = new System.Drawing.Point(250, 292);
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
			this.labelHours.Location = new System.Drawing.Point(8, 187);
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
			this.numericUpDownHours.Location = new System.Drawing.Point(89, 187);
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
			this.numericUpDownHours.ValueChanged += new System.EventHandler(this.numericUpDownHours_ValueChanged);
			// 
			// tabPageCheck
			// 
			this.tabPageCheck.BackColor = System.Drawing.SystemColors.Control;
			this.tabPageCheck.Controls.Add(this.radioButtonZero);
			this.tabPageCheck.Controls.Add(this.radioButtonAll);
			this.tabPageCheck.Controls.Add(this.dateTimePickerTo);
			this.tabPageCheck.Controls.Add(this.labelTo);
			this.tabPageCheck.Controls.Add(this.dateTimePickerFrom);
			this.tabPageCheck.Controls.Add(this.labelPeriodFrom);
			this.tabPageCheck.Location = new System.Drawing.Point(4, 22);
			this.tabPageCheck.Name = "tabPageCheck";
			this.tabPageCheck.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageCheck.Size = new System.Drawing.Size(329, 99);
			this.tabPageCheck.TabIndex = 1;
			this.tabPageCheck.Text = "Period";
			// 
			// radioButtonZero
			// 
			this.radioButtonZero.AutoSize = true;
			this.radioButtonZero.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonZero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.radioButtonZero.Location = new System.Drawing.Point(147, 62);
			this.radioButtonZero.Name = "radioButtonZero";
			this.radioButtonZero.Size = new System.Drawing.Size(109, 15);
			this.radioButtonZero.TabIndex = 29;
			this.radioButtonZero.Text = "Zero Phase Only";
			this.radioButtonZero.UseSelectable = true;
			// 
			// radioButtonAll
			// 
			this.radioButtonAll.AutoSize = true;
			this.radioButtonAll.Checked = true;
			this.radioButtonAll.Cursor = System.Windows.Forms.Cursors.Hand;
			this.radioButtonAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.radioButtonAll.Location = new System.Drawing.Point(60, 62);
			this.radioButtonAll.Name = "radioButtonAll";
			this.radioButtonAll.Size = new System.Drawing.Size(71, 15);
			this.radioButtonAll.TabIndex = 28;
			this.radioButtonAll.TabStop = true;
			this.radioButtonAll.Text = "All Phase";
			this.radioButtonAll.UseSelectable = true;
			// 
			// dateTimePickerTo
			// 
			this.dateTimePickerTo.Font = new System.Drawing.Font("Verdana", 10.2F);
			this.dateTimePickerTo.Location = new System.Drawing.Point(60, 33);
			this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerTo.Name = "dateTimePickerTo";
			this.dateTimePickerTo.Size = new System.Drawing.Size(256, 24);
			this.dateTimePickerTo.TabIndex = 24;
			// 
			// labelTo
			// 
			this.labelTo.AutoSize = true;
			this.labelTo.ForeColor = System.Drawing.Color.DimGray;
			this.labelTo.Location = new System.Drawing.Point(24, 36);
			this.labelTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelTo.Name = "labelTo";
			this.labelTo.Size = new System.Drawing.Size(25, 19);
			this.labelTo.TabIndex = 26;
			this.labelTo.Text = "To:";
			// 
			// dateTimePickerFrom
			// 
			this.dateTimePickerFrom.Font = new System.Drawing.Font("Verdana", 10.2F);
			this.dateTimePickerFrom.Location = new System.Drawing.Point(60, 5);
			this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerFrom.Name = "dateTimePickerFrom";
			this.dateTimePickerFrom.Size = new System.Drawing.Size(256, 24);
			this.dateTimePickerFrom.TabIndex = 23;
			// 
			// labelPeriodFrom
			// 
			this.labelPeriodFrom.AutoSize = true;
			this.labelPeriodFrom.ForeColor = System.Drawing.Color.DimGray;
			this.labelPeriodFrom.Location = new System.Drawing.Point(4, 8);
			this.labelPeriodFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPeriodFrom.Name = "labelPeriodFrom";
			this.labelPeriodFrom.Size = new System.Drawing.Size(44, 19);
			this.labelPeriodFrom.TabIndex = 25;
			this.labelPeriodFrom.Text = "From:";
			// 
			// tabControlMain
			// 
			this.tabControlMain.Controls.Add(this.tabPageCheck);
			this.tabControlMain.Location = new System.Drawing.Point(0, 63);
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.SelectedIndex = 0;
			this.tabControlMain.Size = new System.Drawing.Size(337, 125);
			this.tabControlMain.TabIndex = 40;
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
			this.numericUpDownCycles.Location = new System.Drawing.Point(89, 212);
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
			this.numericUpDownCycles.ValueChanged += new System.EventHandler(this.numericUpDownHours_ValueChanged);
			// 
			// labelCycles
			// 
			this.labelCycles.AutoSize = true;
			this.labelCycles.ForeColor = System.Drawing.Color.DimGray;
			this.labelCycles.Location = new System.Drawing.Point(8, 212);
			this.labelCycles.Name = "labelCycles";
			this.labelCycles.Size = new System.Drawing.Size(64, 19);
			this.labelCycles.TabIndex = 41;
			this.labelCycles.Text = "HRS/CYC";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(8, 237);
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
			this.numericUpDown1.Location = new System.Drawing.Point(89, 237);
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
			this.checkBox1.Location = new System.Drawing.Point(149, 264);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(139, 15);
			this.checkBox1.TabIndex = 63;
			this.checkBox1.Text = "Use current Utilization";
			this.checkBox1.UseSelectable = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// ForecastCustomsMTOP
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(337, 337);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.labelCycles);
			this.Controls.Add(this.numericUpDownCycles);
			this.Controls.Add(this.labelHours);
			this.Controls.Add(this.numericUpDownHours);
			this.Controls.Add(this.tabControlMain);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ForecastCustomsMTOP";
			this.Text = "Forecast Parameters Form";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).EndInit();
			this.tabPageCheck.ResumeLayout(false);
			this.tabPageCheck.PerformLayout();
			this.tabControlMain.ResumeLayout(false);
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
		private System.Windows.Forms.TabPage tabPageCheck;
		private System.Windows.Forms.DateTimePicker dateTimePickerTo;
		private MetroLabel labelTo;
		private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
		private MetroLabel labelPeriodFrom;
		private System.Windows.Forms.TabControl tabControlMain;
		private System.Windows.Forms.NumericUpDown numericUpDownCycles;
		private MetroLabel labelCycles;
		private MetroLabel label1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private MetroRadioButton radioButtonZero;
		private MetroRadioButton radioButtonAll;
		private MetroCheckBox checkBox1;
	}
}