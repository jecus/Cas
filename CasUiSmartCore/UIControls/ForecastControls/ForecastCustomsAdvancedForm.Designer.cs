namespace CAS.UI.UIControls.ForecastControls
{
    partial class ForecastCustomsAdvancedForm
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxNotifyes = new System.Windows.Forms.CheckBox();
            this.numericUpDownPercents = new System.Windows.Forms.NumericUpDown();
            this.checkBoxIncludePercents = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercents)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.Location = new System.Drawing.Point(371, 292);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(30, 23);
            this.buttonOk.TabIndex = 22;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(407, 292);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(47, 23);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelMain.MaximumSize = new System.Drawing.Size(960, 850);
            this.flowLayoutPanelMain.MinimumSize = new System.Drawing.Size(460, 220);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(460, 220);
            this.flowLayoutPanelMain.TabIndex = 21;
            // 
            // checkBoxNotifyes
            // 
            this.checkBoxNotifyes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxNotifyes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxNotifyes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxNotifyes.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.checkBoxNotifyes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.checkBoxNotifyes.Location = new System.Drawing.Point(108, 260);
            this.checkBoxNotifyes.Name = "checkBoxNotifyes";
            this.checkBoxNotifyes.Size = new System.Drawing.Size(142, 25);
            this.checkBoxNotifyes.TabIndex = 39;
            this.checkBoxNotifyes.Text = "Include Notifyes";
            // 
            // numericUpDownPercents
            // 
            this.numericUpDownPercents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPercents.Enabled = false;
            this.numericUpDownPercents.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownPercents.ForeColor = System.Drawing.Color.DimGray;
            this.numericUpDownPercents.Location = new System.Drawing.Point(393, 263);
            this.numericUpDownPercents.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPercents.Name = "numericUpDownPercents";
            this.numericUpDownPercents.Size = new System.Drawing.Size(61, 22);
            this.numericUpDownPercents.TabIndex = 38;
            this.numericUpDownPercents.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownPercents.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // checkBoxIncludePercents
            // 
            this.checkBoxIncludePercents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxIncludePercents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxIncludePercents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxIncludePercents.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.checkBoxIncludePercents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.checkBoxIncludePercents.Location = new System.Drawing.Point(296, 260);
            this.checkBoxIncludePercents.Name = "checkBoxIncludePercents";
            this.checkBoxIncludePercents.Size = new System.Drawing.Size(91, 25);
            this.checkBoxIncludePercents.TabIndex = 37;
            this.checkBoxIncludePercents.Text = "Percents:";
            this.checkBoxIncludePercents.Click += new System.EventHandler(this.CheckBoxIncludePercentsClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(6, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "Date as of:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.dateTimePicker1.Location = new System.Drawing.Point(108, 228);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(347, 26);
            this.dateTimePicker1.TabIndex = 35;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1ValueChanged);
            // 
            // ForecastCustomsAdvancedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(466, 327);
            this.Controls.Add(this.checkBoxNotifyes);
            this.Controls.Add(this.numericUpDownPercents);
            this.Controls.Add(this.checkBoxIncludePercents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ForecastCustomsAdvancedForm";
            this.Text = "Forecast Advanced Form";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button buttonOk;
        public System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.CheckBox checkBoxNotifyes;
        private System.Windows.Forms.NumericUpDown numericUpDownPercents;
        private System.Windows.Forms.CheckBox checkBoxIncludePercents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}