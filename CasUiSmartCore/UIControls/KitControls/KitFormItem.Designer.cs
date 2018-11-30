namespace CAS.UI.UIControls.KitControls
{
    partial class KitFormItem
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
            comboBoxProduct.SelectedIndexChanged -= DictComboDescriptionSelectedIndexChanged;
            comboBoxStandart.SelectedIndexChanged -= ComboBoxStandartSelectedIndexChanged;

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
			this.labelPartNumber = new System.Windows.Forms.Label();
			this.textBoxPartNumber = new System.Windows.Forms.TextBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.labelRemarks = new System.Windows.Forms.Label();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.numericCount = new System.Windows.Forms.NumericUpDown();
			this.labelCount = new System.Windows.Forms.Label();
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			this.comboBoxDetailClass = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
			this.labelType = new System.Windows.Forms.Label();
			this.labelAccessoryDescription = new System.Windows.Forms.Label();
			this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
			this.labelMeasure = new System.Windows.Forms.Label();
			this.labelStandart = new System.Windows.Forms.Label();
			this.labelManufacturer = new System.Windows.Forms.Label();
			this.textBoxManufacturer = new System.Windows.Forms.TextBox();
			this.comboBoxProduct = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.comboBoxStandart = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			((System.ComponentModel.ISupportInitialize)(this.numericCount)).BeginInit();
			this.SuspendLayout();
			// 
			// labelPartNumber
			// 
			this.labelPartNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPartNumber.Location = new System.Drawing.Point(8, 82);
			this.labelPartNumber.Name = "labelPartNumber";
			this.labelPartNumber.Size = new System.Drawing.Size(69, 25);
			this.labelPartNumber.TabIndex = 38;
			this.labelPartNumber.Text = "P/N:";
			this.labelPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPartNumber
			// 
			this.textBoxPartNumber.BackColor = System.Drawing.Color.White;
			this.textBoxPartNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPartNumber.Location = new System.Drawing.Point(114, 84);
			this.textBoxPartNumber.MaxLength = 128;
			this.textBoxPartNumber.Name = "textBoxPartNumber";
			this.textBoxPartNumber.Size = new System.Drawing.Size(229, 22);
			this.textBoxPartNumber.TabIndex = 3;
			// 
			// labelDescription
			// 
			this.labelDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDescription.Location = new System.Drawing.Point(8, 111);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(89, 25);
			this.labelDescription.TabIndex = 40;
			this.labelDescription.Text = "Description:";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.BackColor = System.Drawing.Color.White;
			this.textBoxDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxDescription.Location = new System.Drawing.Point(114, 114);
			this.textBoxDescription.MaxLength = 256;
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDescription.Size = new System.Drawing.Size(436, 76);
			this.textBoxDescription.TabIndex = 4;
			// 
			// labelRemarks
			// 
			this.labelRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(8, 222);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(100, 25);
			this.labelRemarks.TabIndex = 47;
			this.labelRemarks.Text = "Remarks:";
			this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.BackColor = System.Drawing.Color.White;
			this.textBoxRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxRemarks.Location = new System.Drawing.Point(114, 222);
			this.textBoxRemarks.MaxLength = 5000;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxRemarks.Size = new System.Drawing.Size(436, 62);
			this.textBoxRemarks.TabIndex = 13;
			this.textBoxRemarks.Text = "Line1\r\nLin2\r\nLine3\r\nLine4";
			// 
			// numericCount
			// 
			this.numericCount.DecimalPlaces = 2;
			this.numericCount.Location = new System.Drawing.Point(436, 86);
			this.numericCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericCount.Name = "numericCount";
			this.numericCount.Size = new System.Drawing.Size(114, 20);
			this.numericCount.TabIndex = 6;
			this.numericCount.ValueChanged += new System.EventHandler(this.numericCount_ValueChanged);
			// 
			// labelCount
			// 
			this.labelCount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCount.Location = new System.Drawing.Point(349, 83);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new System.Drawing.Size(69, 25);
			this.labelCount.TabIndex = 50;
			this.labelCount.Text = "Quantity:";
			this.labelCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ButtonDelete
			// 
			this.ButtonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonDelete.ActiveBackgroundImage = null;
			this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonDelete.FontMain = new System.Drawing.Font("Verdana", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ButtonDelete.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.ButtonDelete.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.ButtonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIconSmall;
			this.ButtonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.ButtonDelete.IconNotEnabled = null;
			this.ButtonDelete.Location = new System.Drawing.Point(478, 290);
			this.ButtonDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ButtonDelete.Name = "ButtonDelete";
			this.ButtonDelete.NormalBackgroundImage = null;
			this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.ShowToolTip = false;
			this.ButtonDelete.Size = new System.Drawing.Size(72, 23);
			this.ButtonDelete.TabIndex = 14;
			this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextMain = "delete";
			this.ButtonDelete.TextSecondary = "";
			this.ButtonDelete.ToolTipText = "";
			this.ButtonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			// 
			// comboBoxDetailClass
			// 
			this.comboBoxDetailClass.Displayer = null;
			this.comboBoxDetailClass.DisplayerText = null;
			this.comboBoxDetailClass.DropDownHeight = 106;
			this.comboBoxDetailClass.Entity = null;
			this.comboBoxDetailClass.Location = new System.Drawing.Point(114, 56);
			this.comboBoxDetailClass.Name = "comboBoxDetailClass";
			this.comboBoxDetailClass.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.comboBoxDetailClass.RootNodesNames = null;
			this.comboBoxDetailClass.Size = new System.Drawing.Size(228, 21);
			this.comboBoxDetailClass.TabIndex = 2;
			// 
			// labelType
			// 
			this.labelType.AutoSize = true;
			this.labelType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelType.Location = new System.Drawing.Point(8, 58);
			this.labelType.Name = "labelType";
			this.labelType.Size = new System.Drawing.Size(47, 14);
			this.labelType.TabIndex = 78;
			this.labelType.Text = "Class:";
			this.labelType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAccessoryDescription
			// 
			this.labelAccessoryDescription.AutoSize = true;
			this.labelAccessoryDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelAccessoryDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAccessoryDescription.Location = new System.Drawing.Point(8, 5);
			this.labelAccessoryDescription.Name = "labelAccessoryDescription";
			this.labelAccessoryDescription.Size = new System.Drawing.Size(60, 14);
			this.labelAccessoryDescription.TabIndex = 80;
			this.labelAccessoryDescription.Text = "Product:";
			this.labelAccessoryDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxMeasure
			// 
			this.comboBoxMeasure.FormattingEnabled = true;
			this.comboBoxMeasure.Location = new System.Drawing.Point(436, 56);
			this.comboBoxMeasure.Name = "comboBoxMeasure";
			this.comboBoxMeasure.Size = new System.Drawing.Size(116, 21);
			this.comboBoxMeasure.TabIndex = 5;
			// 
			// labelMeasure
			// 
			this.labelMeasure.AutoSize = true;
			this.labelMeasure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMeasure.ForeColor = System.Drawing.Color.Black;
			this.labelMeasure.Location = new System.Drawing.Point(349, 58);
			this.labelMeasure.Name = "labelMeasure";
			this.labelMeasure.Size = new System.Drawing.Size(59, 13);
			this.labelMeasure.TabIndex = 85;
			this.labelMeasure.Text = "Measure:";
			this.labelMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelStandart
			// 
			this.labelStandart.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelStandart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelStandart.Location = new System.Drawing.Point(8, 28);
			this.labelStandart.Name = "labelStandart";
			this.labelStandart.Size = new System.Drawing.Size(69, 25);
			this.labelStandart.TabIndex = 86;
			this.labelStandart.Text = "Standard:";
			this.labelStandart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelManufacturer
			// 
			this.labelManufacturer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufacturer.Location = new System.Drawing.Point(8, 192);
			this.labelManufacturer.Name = "labelManufacturer";
			this.labelManufacturer.Size = new System.Drawing.Size(100, 25);
			this.labelManufacturer.TabIndex = 91;
			this.labelManufacturer.Text = "Manufacturer:";
			this.labelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxManufacturer
			// 
			this.textBoxManufacturer.BackColor = System.Drawing.Color.White;
			this.textBoxManufacturer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxManufacturer.Location = new System.Drawing.Point(114, 194);
			this.textBoxManufacturer.MaxLength = 128;
			this.textBoxManufacturer.Name = "textBoxManufacturer";
			this.textBoxManufacturer.Size = new System.Drawing.Size(438, 22);
			this.textBoxManufacturer.TabIndex = 10;
			// 
			// comboBoxProduct
			// 
			this.comboBoxProduct.Displayer = null;
			this.comboBoxProduct.DisplayerText = null;
			this.comboBoxProduct.Entity = null;
			this.comboBoxProduct.Location = new System.Drawing.Point(114, 2);
			this.comboBoxProduct.Name = "comboBoxProduct";
			this.comboBoxProduct.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.comboBoxProduct.Size = new System.Drawing.Size(435, 21);
			this.comboBoxProduct.TabIndex = 0;
			this.comboBoxProduct.Type = null;
			this.comboBoxProduct.SelectedIndexChanged += new System.EventHandler(this.DictComboDescriptionSelectedIndexChanged);
			// 
			// comboBoxStandart
			// 
			this.comboBoxStandart.Displayer = null;
			this.comboBoxStandart.DisplayerText = null;
			this.comboBoxStandart.Entity = null;
			this.comboBoxStandart.Location = new System.Drawing.Point(114, 29);
			this.comboBoxStandart.Name = "comboBoxStandart";
			this.comboBoxStandart.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.comboBoxStandart.Size = new System.Drawing.Size(435, 21);
			this.comboBoxStandart.TabIndex = 1;
			this.comboBoxStandart.Type = null;
			this.comboBoxStandart.SelectedIndexChanged += new System.EventHandler(this.ComboBoxStandartSelectedIndexChanged);
			// 
			// KitFormItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.comboBoxStandart);
			this.Controls.Add(this.comboBoxProduct);
			this.Controls.Add(this.labelManufacturer);
			this.Controls.Add(this.textBoxManufacturer);
			this.Controls.Add(this.labelStandart);
			this.Controls.Add(this.comboBoxMeasure);
			this.Controls.Add(this.labelMeasure);
			this.Controls.Add(this.labelAccessoryDescription);
			this.Controls.Add(this.comboBoxDetailClass);
			this.Controls.Add(this.labelType);
			this.Controls.Add(this.ButtonDelete);
			this.Controls.Add(this.labelCount);
			this.Controls.Add(this.numericCount);
			this.Controls.Add(this.labelRemarks);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.labelPartNumber);
			this.Controls.Add(this.textBoxPartNumber);
			this.Name = "KitFormItem";
			this.Size = new System.Drawing.Size(555, 321);
			((System.ComponentModel.ISupportInitialize)(this.numericCount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPartNumber;
        private System.Windows.Forms.TextBox textBoxPartNumber;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.NumericUpDown numericCount;
        private System.Windows.Forms.Label labelCount;
        private AvControls.AvButtonT.AvButtonT ButtonDelete;
        private Auxiliary.TreeDictionaryComboBox comboBoxDetailClass;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelAccessoryDescription;
        private System.Windows.Forms.ComboBox comboBoxMeasure;
        private System.Windows.Forms.Label labelMeasure;
        private System.Windows.Forms.Label labelStandart;
        private System.Windows.Forms.Label labelManufacturer;
        private System.Windows.Forms.TextBox textBoxManufacturer;
        private Auxiliary.LookupCombobox comboBoxProduct;
        private Auxiliary.LookupCombobox comboBoxStandart;
    }
}
