using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.PurchaseControls
{
    partial class RequestForQuotationRecordForm
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

            dictionaryComboProduct.SelectedIndexChanged -= DictionaryComboProductSelectedIndexChanged;
            dictionaryComboStandard.SelectedIndexChanged -= DictComboDescriptionSelectedIndexChanged;
            comboBoxDetailClass.SelectedIndexChanged -= ComboBoxDetailClassSelectedIndexChanged;
            comboBoxMeasure.SelectedIndexChanged -= ComboBoxMeasureSelectedIndexChanged;
            numericUpDownQuantity.ValueChanged -= NumericUpDownQuantityValueChanged;

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestForQuotationRecordForm));
            this.comboBoxDetailClass = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
            this.labelClass = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelPartNumber = new System.Windows.Forms.Label();
            this.textBoxPartNumber = new System.Windows.Forms.TextBox();
            this.labelStandart = new System.Windows.Forms.Label();
            this.dictionaryComboStandard = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelRemarks = new System.Windows.Forms.Label();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.labelSuppliers = new System.Windows.Forms.Label();
            this.labelManufacturer = new System.Windows.Forms.Label();
            this.textBoxManufacturer = new System.Windows.Forms.TextBox();
            this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
            this.labelMeasure = new System.Windows.Forms.Label();
            this.labelProductCode = new System.Windows.Forms.Label();
            this.textBoxProductCode = new System.Windows.Forms.TextBox();
            this.dataGridViewControlSuppliers = new CAS.UI.UIControls.Auxiliary.CommonDataGridViewControl();
            this.dictionaryComboProduct = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
            this.labelProduct = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxDetailClass
            // 
            this.comboBoxDetailClass.Displayer = null;
            this.comboBoxDetailClass.DisplayerText = null;
            this.comboBoxDetailClass.DropDownHeight = 106;
            this.comboBoxDetailClass.Enabled = false;
            this.comboBoxDetailClass.Entity = null;
            this.comboBoxDetailClass.Location = new System.Drawing.Point(148, 71);
            this.comboBoxDetailClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxDetailClass.Name = "comboBoxDetailClass";
            this.comboBoxDetailClass.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.comboBoxDetailClass.RootNodesNames = null;
            this.comboBoxDetailClass.Size = new System.Drawing.Size(416, 25);
            this.comboBoxDetailClass.TabIndex = 1;
            this.comboBoxDetailClass.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDetailClassSelectedIndexChanged);
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelClass.Location = new System.Drawing.Point(7, 73);
            this.labelClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(57, 18);
            this.labelClass.TabIndex = 99;
            this.labelClass.Text = "Class:";
            this.labelClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDescription
            // 
            this.labelDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDescription.Location = new System.Drawing.Point(7, 133);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(119, 31);
            this.labelDescription.TabIndex = 81;
            this.labelDescription.Text = "Description:";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.White;
            this.textBoxDescription.Enabled = false;
            this.textBoxDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxDescription.Location = new System.Drawing.Point(148, 136);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDescription.MaxLength = 128;
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(416, 63);
            this.textBoxDescription.TabIndex = 3;
            // 
            // labelPartNumber
            // 
            this.labelPartNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelPartNumber.Location = new System.Drawing.Point(7, 100);
            this.labelPartNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPartNumber.Name = "labelPartNumber";
            this.labelPartNumber.Size = new System.Drawing.Size(92, 31);
            this.labelPartNumber.TabIndex = 79;
            this.labelPartNumber.Text = "P/N:";
            this.labelPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPartNumber
            // 
            this.textBoxPartNumber.BackColor = System.Drawing.Color.White;
            this.textBoxPartNumber.Enabled = false;
            this.textBoxPartNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxPartNumber.Location = new System.Drawing.Point(148, 103);
            this.textBoxPartNumber.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPartNumber.MaxLength = 128;
            this.textBoxPartNumber.Name = "textBoxPartNumber";
            this.textBoxPartNumber.Size = new System.Drawing.Size(416, 26);
            this.textBoxPartNumber.TabIndex = 2;
            // 
            // labelStandart
            // 
            this.labelStandart.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStandart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelStandart.Location = new System.Drawing.Point(7, 35);
            this.labelStandart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStandart.Name = "labelStandart";
            this.labelStandart.Size = new System.Drawing.Size(92, 31);
            this.labelStandart.TabIndex = 88;
            this.labelStandart.Text = "Standart:";
            this.labelStandart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dictionaryComboStandard
            // 
            this.dictionaryComboStandard.Displayer = null;
            this.dictionaryComboStandard.DisplayerText = null;
            this.dictionaryComboStandard.Enabled = false;
            this.dictionaryComboStandard.Entity = null;
            this.dictionaryComboStandard.Location = new System.Drawing.Point(148, 38);
            this.dictionaryComboStandard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dictionaryComboStandard.Name = "dictionaryComboStandard";
            this.dictionaryComboStandard.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictionaryComboStandard.Size = new System.Drawing.Size(416, 25);
            this.dictionaryComboStandard.TabIndex = 0;
            this.dictionaryComboStandard.Type = null;
            this.dictionaryComboStandard.SelectedIndexChanged += new System.EventHandler(this.DictComboDescriptionSelectedIndexChanged);
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.DecimalPlaces = 2;
            this.numericUpDownQuantity.Location = new System.Drawing.Point(148, 308);
            this.numericUpDownQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownQuantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(417, 22);
            this.numericUpDownQuantity.TabIndex = 6;
            this.numericUpDownQuantity.ValueChanged += new System.EventHandler(this.NumericUpDownQuantityValueChanged);
            // 
            // labelQuantity
            // 
            this.labelQuantity.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelQuantity.Location = new System.Drawing.Point(8, 302);
            this.labelQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(108, 31);
            this.labelQuantity.TabIndex = 103;
            this.labelQuantity.Text = "Quantity:";
            this.labelQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRemarks
            // 
            this.labelRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemarks.Location = new System.Drawing.Point(8, 367);
            this.labelRemarks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(133, 31);
            this.labelRemarks.TabIndex = 111;
            this.labelRemarks.Text = "Remarks:";
            this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.BackColor = System.Drawing.Color.White;
            this.textBoxRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxRemarks.Location = new System.Drawing.Point(148, 369);
            this.textBoxRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRemarks.MaxLength = 100;
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(416, 110);
            this.textBoxRemarks.TabIndex = 107;
            this.textBoxRemarks.Text = "Line1\r\nLin2\r\nLine3\r\nLine4\r\nLine5\r\nLine 6";
            // 
            // labelSuppliers
            // 
            this.labelSuppliers.AutoSize = true;
            this.labelSuppliers.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelSuppliers.Location = new System.Drawing.Point(235, 484);
            this.labelSuppliers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSuppliers.Name = "labelSuppliers";
            this.labelSuppliers.Size = new System.Drawing.Size(81, 18);
            this.labelSuppliers.TabIndex = 110;
            this.labelSuppliers.Text = "Suppliers:";
            this.labelSuppliers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelManufacturer
            // 
            this.labelManufacturer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelManufacturer.Location = new System.Drawing.Point(7, 241);
            this.labelManufacturer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelManufacturer.Name = "labelManufacturer";
            this.labelManufacturer.Size = new System.Drawing.Size(133, 31);
            this.labelManufacturer.TabIndex = 109;
            this.labelManufacturer.Text = "Manufacturer:";
            this.labelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxManufacturer
            // 
            this.textBoxManufacturer.BackColor = System.Drawing.Color.White;
            this.textBoxManufacturer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxManufacturer.Location = new System.Drawing.Point(148, 241);
            this.textBoxManufacturer.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxManufacturer.MaxLength = 128;
            this.textBoxManufacturer.Name = "textBoxManufacturer";
            this.textBoxManufacturer.Size = new System.Drawing.Size(416, 26);
            this.textBoxManufacturer.TabIndex = 105;
            // 
            // comboBoxMeasure
            // 
            this.comboBoxMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMeasure.FormattingEnabled = true;
            this.comboBoxMeasure.Location = new System.Drawing.Point(148, 276);
            this.comboBoxMeasure.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxMeasure.Name = "comboBoxMeasure";
            this.comboBoxMeasure.Size = new System.Drawing.Size(416, 24);
            this.comboBoxMeasure.TabIndex = 106;
            this.comboBoxMeasure.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMeasureSelectedIndexChanged);
            // 
            // labelMeasure
            // 
            this.labelMeasure.AutoSize = true;
            this.labelMeasure.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.labelMeasure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelMeasure.Location = new System.Drawing.Point(7, 279);
            this.labelMeasure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMeasure.Name = "labelMeasure";
            this.labelMeasure.Size = new System.Drawing.Size(84, 18);
            this.labelMeasure.TabIndex = 112;
            this.labelMeasure.Text = "Measure:";
            this.labelMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelProductCode
            // 
            this.labelProductCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelProductCode.Location = new System.Drawing.Point(7, 204);
            this.labelProductCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProductCode.Name = "labelProductCode";
            this.labelProductCode.Size = new System.Drawing.Size(133, 31);
            this.labelProductCode.TabIndex = 113;
            this.labelProductCode.Text = "Product Code:";
            this.labelProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxProductCode
            // 
            this.textBoxProductCode.BackColor = System.Drawing.Color.White;
            this.textBoxProductCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxProductCode.Location = new System.Drawing.Point(148, 207);
            this.textBoxProductCode.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxProductCode.MaxLength = 128;
            this.textBoxProductCode.Name = "textBoxProductCode";
            this.textBoxProductCode.Size = new System.Drawing.Size(416, 26);
            this.textBoxProductCode.TabIndex = 104;
            // 
            // dataGridViewControlSuppliers
            // 
            this.dataGridViewControlSuppliers.CanOpenEditFormOnDoubleClick = false;
            this.dataGridViewControlSuppliers.Displayer = null;
            this.dataGridViewControlSuppliers.DisplayerText = null;
            this.dataGridViewControlSuppliers.Entity = null;
            this.dataGridViewControlSuppliers.Location = new System.Drawing.Point(11, 512);
            this.dataGridViewControlSuppliers.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewControlSuppliers.Name = "dataGridViewControlSuppliers";
            this.dataGridViewControlSuppliers.ReadOnly = true;
            this.dataGridViewControlSuppliers.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dataGridViewControlSuppliers.RowHeadersVisible = false;
            this.dataGridViewControlSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            this.dataGridViewControlSuppliers.ShowAddNew = false;
            this.dataGridViewControlSuppliers.ShowDelete = false;
            this.dataGridViewControlSuppliers.ShowQuickSearch = false;
            this.dataGridViewControlSuppliers.Size = new System.Drawing.Size(554, 161);
            this.dataGridViewControlSuppliers.TabIndex = 108;
            // 
            // dictionaryComboProduct
            // 
            this.dictionaryComboProduct.Displayer = null;
            this.dictionaryComboProduct.DisplayerText = null;
            this.dictionaryComboProduct.Entity = null;
            this.dictionaryComboProduct.Location = new System.Drawing.Point(148, 6);
            this.dictionaryComboProduct.Margin = new System.Windows.Forms.Padding(5);
            this.dictionaryComboProduct.Name = "dictionaryComboProduct";
            this.dictionaryComboProduct.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictionaryComboProduct.Size = new System.Drawing.Size(416, 25);
            this.dictionaryComboProduct.TabIndex = 114;
            this.dictionaryComboProduct.Type = null;
            this.dictionaryComboProduct.SelectedIndexChanged += new System.EventHandler(this.DictionaryComboProductSelectedIndexChanged);
            // 
            // labelProduct
            // 
            this.labelProduct.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelProduct.Location = new System.Drawing.Point(7, 4);
            this.labelProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(92, 31);
            this.labelProduct.TabIndex = 115;
            this.labelProduct.Text = "Product:";
            this.labelProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Verdana", 9F);
            this.labelTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelTotal.Location = new System.Drawing.Point(8, 341);
            this.labelTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(52, 18);
            this.labelTotal.TabIndex = 128;
            this.labelTotal.Text = "Total:";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.BackColor = System.Drawing.Color.White;
            this.textBoxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTotal.ForeColor = System.Drawing.Color.Black;
            this.textBoxTotal.Location = new System.Drawing.Point(148, 338);
            this.textBoxTotal.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTotal.MaxLength = 128;
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(416, 23);
            this.textBoxTotal.TabIndex = 127;

            this.panelMain.Controls.Add(this.labelTotal);
            this.panelMain.Controls.Add(this.textBoxTotal);
            this.panelMain.Controls.Add(this.labelProduct);
            this.panelMain.Controls.Add(this.dictionaryComboProduct);
            this.panelMain.Controls.Add(this.dictionaryComboStandard);
            this.panelMain.Controls.Add(this.comboBoxDetailClass);
            this.panelMain.Controls.Add(this.labelClass);
            this.panelMain.Controls.Add(this.labelQuantity);
            this.panelMain.Controls.Add(this.numericUpDownQuantity);
            this.panelMain.Controls.Add(this.labelRemarks);
            this.panelMain.Controls.Add(this.textBoxRemarks);
            this.panelMain.Controls.Add(this.labelSuppliers);
            this.panelMain.Controls.Add(this.dataGridViewControlSuppliers);
            this.panelMain.Controls.Add(this.labelManufacturer);
            this.panelMain.Controls.Add(this.textBoxManufacturer);
            this.panelMain.Controls.Add(this.labelDescription);
            this.panelMain.Controls.Add(this.textBoxDescription);
            this.panelMain.Controls.Add(this.labelPartNumber);
            this.panelMain.Controls.Add(this.textBoxPartNumber);
            this.panelMain.Controls.Add(this.comboBoxMeasure);
            this.panelMain.Controls.Add(this.labelMeasure);
            this.panelMain.Controls.Add(this.labelStandart);
            // 
            // RequestForQuotationRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 725);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1359, 935);
            this.MinimumSize = new System.Drawing.Size(374, 193);
            this.Name = "RequestForQuotationRecordForm";
            this.Text = "Quotation Record Form";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeDictionaryComboBox comboBoxDetailClass;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelPartNumber;
        private System.Windows.Forms.TextBox textBoxPartNumber;
        private System.Windows.Forms.Label labelStandart;
        private LookupCombobox dictionaryComboStandard;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.Label labelSuppliers;
        private System.Windows.Forms.Label labelManufacturer;
        private System.Windows.Forms.TextBox textBoxManufacturer;
        private System.Windows.Forms.ComboBox comboBoxMeasure;
        private System.Windows.Forms.Label labelMeasure;
        private System.Windows.Forms.Label labelProductCode;
        private System.Windows.Forms.TextBox textBoxProductCode;
        private CommonDataGridViewControl dataGridViewControlSuppliers;
        private LookupCombobox dictionaryComboProduct;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.TextBox textBoxTotal;

    }
}