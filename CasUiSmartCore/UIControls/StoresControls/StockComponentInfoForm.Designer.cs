namespace CAS.UI.UIControls.StoresControls
{
    partial class StockComponentInfoForm
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
            dictionaryComboProduct.SelectedIndexChanged -= DictionaryComboProductSelectedIndexChanged;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockComponentInfoForm));
            this.textBoxPartNumber = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dictionaryComboProduct = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
            this.labelPartNumber = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelProduct = new System.Windows.Forms.Label();
            this.comboBoxDetailClass = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
            this.labelDetailModel = new System.Windows.Forms.Label();
            this.labelMeasure = new System.Windows.Forms.Label();
            this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.textBoxStandart = new System.Windows.Forms.TextBox();
            this.labelStandart = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPartNumber
            // 
            this.textBoxPartNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPartNumber.Location = new System.Drawing.Point(129, 115);
            this.textBoxPartNumber.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPartNumber.MaxLength = 128;
            this.textBoxPartNumber.Name = "textBoxPartNumber";
            this.textBoxPartNumber.Size = new System.Drawing.Size(431, 22);
            this.textBoxPartNumber.TabIndex = 3;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.Location = new System.Drawing.Point(129, 147);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDescription.MaxLength = 128;
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(431, 73);
            this.textBoxDescription.TabIndex = 4;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOK.Location = new System.Drawing.Point(392, 300);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 33);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonCancel.Location = new System.Drawing.Point(472, 300);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(92, 33);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // dictionaryComboProduct
            // 
            this.dictionaryComboProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dictionaryComboProduct.Displayer = null;
            this.dictionaryComboProduct.DisplayerText = null;
            this.dictionaryComboProduct.Entity = null;
            this.dictionaryComboProduct.Location = new System.Drawing.Point(130, 14);
            this.dictionaryComboProduct.Margin = new System.Windows.Forms.Padding(5);
            this.dictionaryComboProduct.Name = "dictionaryComboProduct";
            this.dictionaryComboProduct.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictionaryComboProduct.Size = new System.Drawing.Size(431, 25);
            this.dictionaryComboProduct.TabIndex = 5;
            this.dictionaryComboProduct.Type = null;
            this.dictionaryComboProduct.SelectedIndexChanged += new System.EventHandler(this.DictionaryComboProductSelectedIndexChanged);
            // 
            // labelPartNumber
            // 
            this.labelPartNumber.AutoSize = true;
            this.labelPartNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPartNumber.Location = new System.Drawing.Point(14, 119);
            this.labelPartNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPartNumber.Name = "labelPartNumber";
            this.labelPartNumber.Size = new System.Drawing.Size(104, 17);
            this.labelPartNumber.TabIndex = 0;
            this.labelPartNumber.Text = "Part Number:";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDescription.Location = new System.Drawing.Point(14, 151);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(95, 17);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = "Description:";
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(15, 19);
            this.labelProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(61, 17);
            this.labelProduct.TabIndex = 16;
            this.labelProduct.Text = "Product:";
            // 
            // comboBoxDetailClass
            // 
            this.comboBoxDetailClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDetailClass.Displayer = null;
            this.comboBoxDetailClass.DisplayerText = null;
            this.comboBoxDetailClass.Entity = null;
            this.comboBoxDetailClass.Location = new System.Drawing.Point(129, 82);
            this.comboBoxDetailClass.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxDetailClass.Name = "comboBoxDetailClass";
            this.comboBoxDetailClass.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.comboBoxDetailClass.RootNodesNames = null;
            this.comboBoxDetailClass.Size = new System.Drawing.Size(432, 25);
            this.comboBoxDetailClass.TabIndex = 2;
            this.comboBoxDetailClass.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDetailClassSelectedIndexChanged);
            // 
            // labelDetailModel
            // 
            this.labelDetailModel.AutoSize = true;
            this.labelDetailModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDetailModel.Location = new System.Drawing.Point(14, 85);
            this.labelDetailModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDetailModel.Name = "labelDetailModel";
            this.labelDetailModel.Size = new System.Drawing.Size(99, 17);
            this.labelDetailModel.TabIndex = 17;
            this.labelDetailModel.Text = "Class:";
            // 
            // labelMeasure
            // 
            this.labelMeasure.AutoSize = true;
            this.labelMeasure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMeasure.Location = new System.Drawing.Point(15, 232);
            this.labelMeasure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMeasure.Name = "labelMeasure";
            this.labelMeasure.Size = new System.Drawing.Size(75, 17);
            this.labelMeasure.TabIndex = 0;
            this.labelMeasure.Text = "Measure:";
            // 
            // comboBoxMeasure
            // 
            this.comboBoxMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMeasure.FormattingEnabled = true;
            this.comboBoxMeasure.Location = new System.Drawing.Point(129, 228);
            this.comboBoxMeasure.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxMeasure.Name = "comboBoxMeasure";
            this.comboBoxMeasure.Size = new System.Drawing.Size(431, 24);
            this.comboBoxMeasure.TabIndex = 7;
            this.comboBoxMeasure.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMeasureSelectedIndexChanged);
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQuantity.Location = new System.Drawing.Point(16, 265);
            this.labelQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(74, 17);
            this.labelQuantity.TabIndex = 0;
            this.labelQuantity.Text = "Quantity:";
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(129, 263);
            this.numericUpDownQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownQuantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(432, 22);
            this.numericUpDownQuantity.TabIndex = 8;
            this.numericUpDownQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxStandart
            // 
            this.textBoxStandart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStandart.Location = new System.Drawing.Point(130, 48);
            this.textBoxStandart.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStandart.MaxLength = 128;
            this.textBoxStandart.Name = "textBoxStandart";
            this.textBoxStandart.Size = new System.Drawing.Size(430, 25);
            this.textBoxStandart.ReadOnly = true;
            this.textBoxStandart.TabIndex = 87;
            // 
            // labelStandart
            // 
            this.labelStandart.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStandart.Location = new System.Drawing.Point(15, 45);
            this.labelStandart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStandart.Name = "labelStandart";
            this.labelStandart.Size = new System.Drawing.Size(92, 31);
            this.labelStandart.TabIndex = 88;
            this.labelStandart.Text = "Standard:";
            this.labelStandart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StockDetailInfoForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(579, 338);
            this.Controls.Add(this.textBoxStandart);
            this.Controls.Add(this.labelStandart);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.labelMeasure);
            this.Controls.Add(this.comboBoxMeasure);
            this.Controls.Add(this.labelDetailModel);
            this.Controls.Add(this.comboBoxDetailClass);
            this.Controls.Add(this.labelProduct);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelPartNumber);
            this.Controls.Add(this.dictionaryComboProduct);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxPartNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1359, 383);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(461, 383);
            this.Name = "StockComponentInfoForm";
            this.Text = "Stock Detail Info Form";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPartNumber;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private Auxiliary.LookupCombobox dictionaryComboProduct;
        private System.Windows.Forms.Label labelPartNumber;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelProduct;
        private Auxiliary.TreeDictionaryComboBox comboBoxDetailClass;
        private System.Windows.Forms.Label labelDetailModel;
        private System.Windows.Forms.Label labelMeasure;
        private System.Windows.Forms.ComboBox comboBoxMeasure;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.TextBox textBoxStandart;
        private System.Windows.Forms.Label labelStandart;
    }
}