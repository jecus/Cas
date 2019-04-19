using MetroFramework.Controls;

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
			this.checkBoxNotifyes = new MetroFramework.Controls.MetroCheckBox();
			this.numericUpDownPercents = new System.Windows.Forms.NumericUpDown();
			this.checkBoxIncludePercents = new MetroFramework.Controls.MetroCheckBox();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercents)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(298, 375);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 22;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(379, 375);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
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
			this.flowLayoutPanelMain.Location = new System.Drawing.Point(3, 63);
			this.flowLayoutPanelMain.MaximumSize = new System.Drawing.Size(960, 850);
			this.flowLayoutPanelMain.MinimumSize = new System.Drawing.Size(460, 220);
			this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
			this.flowLayoutPanelMain.Size = new System.Drawing.Size(460, 243);
			this.flowLayoutPanelMain.TabIndex = 21;
			// 
			// checkBoxNotifyes
			// 
			this.checkBoxNotifyes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxNotifyes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxNotifyes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxNotifyes.Location = new System.Drawing.Point(108, 343);
			this.checkBoxNotifyes.Name = "checkBoxNotifyes";
			this.checkBoxNotifyes.Size = new System.Drawing.Size(142, 25);
			this.checkBoxNotifyes.TabIndex = 39;
			this.checkBoxNotifyes.Text = "Include Notifyes";
			this.checkBoxNotifyes.UseSelectable = true;
			// 
			// numericUpDownPercents
			// 
			this.numericUpDownPercents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownPercents.Enabled = false;
			this.numericUpDownPercents.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.numericUpDownPercents.ForeColor = System.Drawing.Color.DimGray;
			this.numericUpDownPercents.Location = new System.Drawing.Point(393, 346);
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
			this.checkBoxIncludePercents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxIncludePercents.Location = new System.Drawing.Point(296, 343);
			this.checkBoxIncludePercents.Name = "checkBoxIncludePercents";
			this.checkBoxIncludePercents.Size = new System.Drawing.Size(91, 25);
			this.checkBoxIncludePercents.TabIndex = 37;
			this.checkBoxIncludePercents.Text = "Percents:";
			this.checkBoxIncludePercents.UseSelectable = true;
			this.checkBoxIncludePercents.Click += new System.EventHandler(this.CheckBoxIncludePercentsClick);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(3, 314);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 19);
			this.label1.TabIndex = 36;
			this.label1.Text = "Date as of:";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.dateTimePicker1.Location = new System.Drawing.Point(108, 311);
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
			this.ClientSize = new System.Drawing.Size(466, 410);
			this.Controls.Add(this.checkBoxNotifyes);
			this.Controls.Add(this.numericUpDownPercents);
			this.Controls.Add(this.checkBoxIncludePercents);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.flowLayoutPanelMain);
			this.Name = "ForecastCustomsAdvancedForm";
			this.Resizable = false;
			this.Text = "Forecast Advanced Form";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercents)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button buttonOk;
        public System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private MetroCheckBox checkBoxNotifyes;
        private System.Windows.Forms.NumericUpDown numericUpDownPercents;
        private MetroCheckBox checkBoxIncludePercents;
        private MetroLabel label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}