using System.ComponentModel;

namespace CAS.UI.UICAAControls.StandartManual
{
    partial class StandartManualForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label metroLabel1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label13;
            this.comboBoxProgramType = new System.Windows.Forms.ComboBox();
            this.metroTextSource = new MetroFramework.Controls.MetroTextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.numericUpNotify = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickeValidTo = new System.Windows.Forms.DateTimePicker();
            label1 = new System.Windows.Forms.Label();
            metroLabel1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpNotify)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", 9F);
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label1.Location = new System.Drawing.Point(11, 66);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(98, 14);
            label1.TabIndex = 327;
            label1.Text = "Program Type:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel1
            // 
            metroLabel1.AutoSize = true;
            metroLabel1.Font = new System.Drawing.Font("Verdana", 9F);
            metroLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            metroLabel1.Location = new System.Drawing.Point(11, 90);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new System.Drawing.Size(55, 14);
            metroLabel1.TabIndex = 325;
            metroLabel1.Text = "Source:";
            metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxProgramType
            // 
            this.comboBoxProgramType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxProgramType.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxProgramType.FormattingEnabled = true;
            this.comboBoxProgramType.Location = new System.Drawing.Point(114, 63);
            this.comboBoxProgramType.Name = "comboBoxProgramType";
            this.comboBoxProgramType.Size = new System.Drawing.Size(347, 22);
            this.comboBoxProgramType.TabIndex = 328;
            // 
            // metroTextSource
            // 
            // 
            // 
            // 
            this.metroTextSource.CustomButton.Image = null;
            this.metroTextSource.CustomButton.Location = new System.Drawing.Point(309, 1);
            this.metroTextSource.CustomButton.Name = "";
            this.metroTextSource.CustomButton.Size = new System.Drawing.Size(37, 37);
            this.metroTextSource.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextSource.CustomButton.TabIndex = 1;
            this.metroTextSource.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextSource.CustomButton.UseSelectable = true;
            this.metroTextSource.CustomButton.Visible = false;
            this.metroTextSource.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextSource.Lines = new string[0];
            this.metroTextSource.Location = new System.Drawing.Point(114, 88);
            this.metroTextSource.MaxLength = 32767;
            this.metroTextSource.Multiline = true;
            this.metroTextSource.Name = "metroTextSource";
            this.metroTextSource.PasswordChar = '\0';
            this.metroTextSource.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextSource.SelectedText = "";
            this.metroTextSource.SelectionLength = 0;
            this.metroTextSource.SelectionStart = 0;
            this.metroTextSource.ShortcutsEnabled = true;
            this.metroTextSource.Size = new System.Drawing.Size(347, 39);
            this.metroTextSource.TabIndex = 326;
            this.metroTextSource.UseSelectable = true;
            this.metroTextSource.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextSource.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOk.Location = new System.Drawing.Point(330, 397);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 33);
            this.buttonOk.TabIndex = 330;
            this.buttonOk.Text = "OK";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonCancel.Location = new System.Drawing.Point(411, 397);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 329;
            this.buttonCancel.Text = "Cancel";
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(91, 91);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(114, 133);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Multiline = true;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(347, 96);
            this.metroTextBox1.TabIndex = 332;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Verdana", 9F);
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label2.Location = new System.Drawing.Point(11, 135);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 14);
            label2.TabIndex = 331;
            label2.Text = "Source:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroTextBox2
            // 
            // 
            // 
            // 
            this.metroTextBox2.CustomButton.Image = null;
            this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.metroTextBox2.CustomButton.Name = "";
            this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(91, 91);
            this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox2.CustomButton.TabIndex = 1;
            this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox2.CustomButton.UseSelectable = true;
            this.metroTextBox2.CustomButton.Visible = false;
            this.metroTextBox2.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBox2.Lines = new string[0];
            this.metroTextBox2.Location = new System.Drawing.Point(114, 235);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Multiline = true;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.SelectionLength = 0;
            this.metroTextBox2.SelectionStart = 0;
            this.metroTextBox2.ShortcutsEnabled = true;
            this.metroTextBox2.Size = new System.Drawing.Size(347, 96);
            this.metroTextBox2.TabIndex = 334;
            this.metroTextBox2.UseSelectable = true;
            this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Verdana", 9F);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label3.Location = new System.Drawing.Point(11, 237);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(55, 14);
            label3.TabIndex = 333;
            label3.Text = "Source:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Verdana", 9F);
            label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label14.Location = new System.Drawing.Point(11, 366);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(92, 14);
            label14.TabIndex = 338;
            label14.Text = "Notify (days):";
            label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Verdana", 9F);
            label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label13.Location = new System.Drawing.Point(11, 343);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(102, 14);
            label13.TabIndex = 337;
            label13.Text = "Check/Valid To:";
            label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpNotify
            // 
            this.numericUpNotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.numericUpNotify.ForeColor = System.Drawing.Color.DimGray;
            this.numericUpNotify.Location = new System.Drawing.Point(114, 366);
            this.numericUpNotify.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numericUpNotify.Name = "numericUpNotify";
            this.numericUpNotify.Size = new System.Drawing.Size(119, 20);
            this.numericUpNotify.TabIndex = 336;
            this.numericUpNotify.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dateTimePickeValidTo
            // 
            this.dateTimePickeValidTo.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dateTimePickeValidTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dateTimePickeValidTo.Location = new System.Drawing.Point(114, 340);
            this.dateTimePickeValidTo.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dateTimePickeValidTo.Name = "dateTimePickeValidTo";
            this.dateTimePickeValidTo.Size = new System.Drawing.Size(119, 20);
            this.dateTimePickeValidTo.TabIndex = 335;
            // 
            // StandartManualForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 437);
            this.Controls.Add(label14);
            this.Controls.Add(label13);
            this.Controls.Add(this.numericUpNotify);
            this.Controls.Add(this.dateTimePickeValidTo);
            this.Controls.Add(this.metroTextBox2);
            this.Controls.Add(label3);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(label2);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.comboBoxProgramType);
            this.Controls.Add(label1);
            this.Controls.Add(this.metroTextSource);
            this.Controls.Add(metroLabel1);
            this.MaximizeBox = false;
            this.Name = "StandartManualForm";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuditForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpNotify)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private System.Windows.Forms.NumericUpDown numericUpNotify;
        private System.Windows.Forms.DateTimePicker dateTimePickeValidTo;

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;

        private System.Windows.Forms.ComboBox comboBoxProgramType;
        private MetroFramework.Controls.MetroTextBox metroTextSource;

        #endregion
    }
}