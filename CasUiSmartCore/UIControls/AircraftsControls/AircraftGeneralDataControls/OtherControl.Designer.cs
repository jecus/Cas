using System.Windows.Forms;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    partial class OtherControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelELTHexCode = new System.Windows.Forms.Label();
            this.labelAddress24Bit = new System.Windows.Forms.Label();
            this.textBoxELTHexCode = new System.Windows.Forms.TextBox();
            this.textBoxAddressBit = new System.Windows.Forms.TextBox();
            this.labelNoiceCategory = new System.Windows.Forms.Label();
            this.numericUpDownNoiceCategory = new System.Windows.Forms.NumericUpDown();
            this.labelFADEC = new System.Windows.Forms.Label();
            this.checkBoxFADEC = new System.Windows.Forms.CheckBox();
            this.checkBoxEFIS = new System.Windows.Forms.CheckBox();
            this.labelEFIS = new System.Windows.Forms.Label();
            this.checkBoxWinglets = new System.Windows.Forms.CheckBox();
            this.labelWinglets = new System.Windows.Forms.Label();
            this.numericUpDownlandingCategory = new System.Windows.Forms.NumericUpDown();
            this.labelLandingCategory = new System.Windows.Forms.Label();
            this.labelBrakes = new System.Windows.Forms.Label();
            this.comboBoxBrakes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoiceCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownlandingCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // labelELTHexCode
            // 
            this.labelELTHexCode.AutoSize = true;
            this.labelELTHexCode.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelELTHexCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelELTHexCode.Location = new System.Drawing.Point(10, 92);
            this.labelELTHexCode.Name = "labelELTHexCode";
            this.labelELTHexCode.Size = new System.Drawing.Size(126, 17);
            this.labelELTHexCode.TabIndex = 1;
            this.labelELTHexCode.Text = "ELT Id Hex Code";
            this.labelELTHexCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAddress24Bit
            // 
            this.labelAddress24Bit.AutoSize = true;
            this.labelAddress24Bit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAddress24Bit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAddress24Bit.Location = new System.Drawing.Point(10, 6);
            this.labelAddress24Bit.Name = "labelAddress24Bit";
            this.labelAddress24Bit.Size = new System.Drawing.Size(112, 17);
            this.labelAddress24Bit.TabIndex = 0;
            this.labelAddress24Bit.Text = "Address 24 bit";
            this.labelAddress24Bit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxELTHexCode
            // 
            this.textBoxELTHexCode.BackColor = System.Drawing.Color.White;
            this.textBoxELTHexCode.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxELTHexCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxELTHexCode.Location = new System.Drawing.Point(142, 89);
            this.textBoxELTHexCode.Multiline = true;
            this.textBoxELTHexCode.Name = "textBoxELTHexCode";
            this.textBoxELTHexCode.Size = new System.Drawing.Size(300, 67);
            this.textBoxELTHexCode.TabIndex = 5;
            // 
            // textBoxAddressBit
            // 
            this.textBoxAddressBit.BackColor = System.Drawing.Color.White;
            this.textBoxAddressBit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxAddressBit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxAddressBit.Location = new System.Drawing.Point(142, 3);
            this.textBoxAddressBit.Multiline = true;
            this.textBoxAddressBit.Name = "textBoxAddressBit";
            this.textBoxAddressBit.Size = new System.Drawing.Size(300, 80);
            this.textBoxAddressBit.TabIndex = 4;
            // 
            // labelNoiceCategory
            // 
            this.labelNoiceCategory.AutoSize = true;
            this.labelNoiceCategory.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelNoiceCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelNoiceCategory.Location = new System.Drawing.Point(460, 6);
            this.labelNoiceCategory.Name = "labelNoiceCategory";
            this.labelNoiceCategory.Size = new System.Drawing.Size(120, 17);
            this.labelNoiceCategory.TabIndex = 6;
            this.labelNoiceCategory.Text = "Noice Category:";
            this.labelNoiceCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownNoiceCategory
            // 
            this.numericUpDownNoiceCategory.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownNoiceCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.numericUpDownNoiceCategory.Location = new System.Drawing.Point(603, 3);
            this.numericUpDownNoiceCategory.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownNoiceCategory.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownNoiceCategory.Name = "numericUpDownNoiceCategory";
            this.numericUpDownNoiceCategory.Size = new System.Drawing.Size(199, 25);
            this.numericUpDownNoiceCategory.TabIndex = 28;
            // 
            // labelFADEC
            // 
            this.labelFADEC.AutoSize = true;
            this.labelFADEC.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelFADEC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelFADEC.Location = new System.Drawing.Point(460, 90);
            this.labelFADEC.Name = "labelFADEC";
            this.labelFADEC.Size = new System.Drawing.Size(62, 17);
            this.labelFADEC.TabIndex = 29;
            this.labelFADEC.Text = "FADEC:";
            this.labelFADEC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxFADEC
            // 
            this.checkBoxFADEC.AutoSize = true;
            this.checkBoxFADEC.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.checkBoxFADEC.Location = new System.Drawing.Point(603, 93);
            this.checkBoxFADEC.Name = "checkBoxFADEC";
            this.checkBoxFADEC.Size = new System.Drawing.Size(15, 14);
            this.checkBoxFADEC.TabIndex = 30;
            this.checkBoxFADEC.UseVisualStyleBackColor = true;
            // 
            // checkBoxEFIS
            // 
            this.checkBoxEFIS.AutoSize = true;
            this.checkBoxEFIS.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.checkBoxEFIS.Location = new System.Drawing.Point(603, 113);
            this.checkBoxEFIS.Name = "checkBoxEFIS";
            this.checkBoxEFIS.Size = new System.Drawing.Size(15, 14);
            this.checkBoxEFIS.TabIndex = 32;
            this.checkBoxEFIS.UseVisualStyleBackColor = true;
            // 
            // labelEFIS
            // 
            this.labelEFIS.AutoSize = true;
            this.labelEFIS.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelEFIS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelEFIS.Location = new System.Drawing.Point(460, 110);
            this.labelEFIS.Name = "labelEFIS";
            this.labelEFIS.Size = new System.Drawing.Size(46, 17);
            this.labelEFIS.TabIndex = 31;
            this.labelEFIS.Text = "EFIS:";
            this.labelEFIS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxWinglets
            // 
            this.checkBoxWinglets.AutoSize = true;
            this.checkBoxWinglets.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.checkBoxWinglets.Location = new System.Drawing.Point(603, 133);
            this.checkBoxWinglets.Name = "checkBoxWinglets";
            this.checkBoxWinglets.Size = new System.Drawing.Size(15, 14);
            this.checkBoxWinglets.TabIndex = 34;
            this.checkBoxWinglets.UseVisualStyleBackColor = true;
            // 
            // labelWinglets
            // 
            this.labelWinglets.AutoSize = true;
            this.labelWinglets.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelWinglets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelWinglets.Location = new System.Drawing.Point(460, 130);
            this.labelWinglets.Name = "labelWinglets";
            this.labelWinglets.Size = new System.Drawing.Size(75, 17);
            this.labelWinglets.TabIndex = 33;
            this.labelWinglets.Text = "Winglets:";
            this.labelWinglets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownlandingCategory
            // 
            this.numericUpDownlandingCategory.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownlandingCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.numericUpDownlandingCategory.Location = new System.Drawing.Point(603, 32);
            this.numericUpDownlandingCategory.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownlandingCategory.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownlandingCategory.Name = "numericUpDownlandingCategory";
            this.numericUpDownlandingCategory.Size = new System.Drawing.Size(199, 25);
            this.numericUpDownlandingCategory.TabIndex = 36;
            // 
            // labelLandingCategory
            // 
            this.labelLandingCategory.AutoSize = true;
            this.labelLandingCategory.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelLandingCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelLandingCategory.Location = new System.Drawing.Point(460, 34);
            this.labelLandingCategory.Name = "labelLandingCategory";
            this.labelLandingCategory.Size = new System.Drawing.Size(138, 17);
            this.labelLandingCategory.TabIndex = 35;
            this.labelLandingCategory.Text = "Landing Category:";
            this.labelLandingCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBrakes
            // 
            this.labelBrakes.AutoSize = true;
            this.labelBrakes.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelBrakes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelBrakes.Location = new System.Drawing.Point(460, 66);
            this.labelBrakes.Name = "labelBrakes";
            this.labelBrakes.Size = new System.Drawing.Size(62, 17);
            this.labelBrakes.TabIndex = 37;
            this.labelBrakes.Text = "Brakes:";
            this.labelBrakes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxBrakes
            // 
            this.comboBoxBrakes.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxBrakes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.comboBoxBrakes.FormattingEnabled = true;
            this.comboBoxBrakes.Location = new System.Drawing.Point(603, 62);
            this.comboBoxBrakes.Name = "comboBoxBrakes";
            this.comboBoxBrakes.Size = new System.Drawing.Size(199, 25);
            this.comboBoxBrakes.TabIndex = 38;
            // 
            // OtherControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxBrakes);
            this.Controls.Add(this.labelBrakes);
            this.Controls.Add(this.numericUpDownlandingCategory);
            this.Controls.Add(this.labelLandingCategory);
            this.Controls.Add(this.checkBoxWinglets);
            this.Controls.Add(this.labelWinglets);
            this.Controls.Add(this.checkBoxEFIS);
            this.Controls.Add(this.labelEFIS);
            this.Controls.Add(this.checkBoxFADEC);
            this.Controls.Add(this.labelFADEC);
            this.Controls.Add(this.numericUpDownNoiceCategory);
            this.Controls.Add(this.labelNoiceCategory);
            this.Controls.Add(this.labelAddress24Bit);
            this.Controls.Add(this.labelELTHexCode);
            this.Controls.Add(this.textBoxAddressBit);
            this.Controls.Add(this.textBoxELTHexCode);
            this.Name = "OtherControl";
            this.Size = new System.Drawing.Size(812, 163);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoiceCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownlandingCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Label labelELTHexCode = new Label();
        private Label labelAddress24Bit = new Label();
        private TextBox textBoxELTHexCode = new TextBox();
        private  TextBox textBoxAddressBit = new TextBox();
        #endregion
        private Label labelNoiceCategory;
        private NumericUpDown numericUpDownNoiceCategory;
        private Label labelFADEC;
        private CheckBox checkBoxFADEC;
        private CheckBox checkBoxEFIS;
        private Label labelEFIS;
        private CheckBox checkBoxWinglets;
        private Label labelWinglets;
        private NumericUpDown numericUpDownlandingCategory;
        private Label labelLandingCategory;
        private Label labelBrakes;
        private ComboBox comboBoxBrakes;

    }
}
