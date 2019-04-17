using MetroFramework.Controls;

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
			this.textBoxPartNumber = new MetroFramework.Controls.MetroTextBox();
			this.textBoxDescription = new MetroFramework.Controls.MetroTextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.dictionaryComboProduct = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.labelPartNumber = new MetroFramework.Controls.MetroLabel();
			this.labelDescription = new MetroFramework.Controls.MetroLabel();
			this.labelProduct = new MetroFramework.Controls.MetroLabel();
			this.comboBoxDetailClass = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
			this.labelDetailModel = new MetroFramework.Controls.MetroLabel();
			this.labelMeasure = new MetroFramework.Controls.MetroLabel();
			this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
			this.labelQuantity = new MetroFramework.Controls.MetroLabel();
			this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
			this.textBoxStandart = new MetroFramework.Controls.MetroTextBox();
			this.labelStandart = new MetroFramework.Controls.MetroLabel();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxPartNumber
			// 
			this.textBoxPartNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			// 
			// 
			// 
			this.textBoxPartNumber.CustomButton.Image = null;
			this.textBoxPartNumber.CustomButton.Location = new System.Drawing.Point(306, 2);
			this.textBoxPartNumber.CustomButton.Name = "";
			this.textBoxPartNumber.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxPartNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxPartNumber.CustomButton.TabIndex = 1;
			this.textBoxPartNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxPartNumber.CustomButton.UseSelectable = true;
			this.textBoxPartNumber.CustomButton.Visible = false;
			this.textBoxPartNumber.Lines = new string[0];
			this.textBoxPartNumber.Location = new System.Drawing.Point(100, 146);
			this.textBoxPartNumber.MaxLength = 128;
			this.textBoxPartNumber.Name = "textBoxPartNumber";
			this.textBoxPartNumber.PasswordChar = '\0';
			this.textBoxPartNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxPartNumber.SelectedText = "";
			this.textBoxPartNumber.SelectionLength = 0;
			this.textBoxPartNumber.SelectionStart = 0;
			this.textBoxPartNumber.ShortcutsEnabled = true;
			this.textBoxPartNumber.Size = new System.Drawing.Size(324, 20);
			this.textBoxPartNumber.TabIndex = 3;
			this.textBoxPartNumber.UseSelectable = true;
			this.textBoxPartNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxPartNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			// 
			// 
			// 
			this.textBoxDescription.CustomButton.Image = null;
			this.textBoxDescription.CustomButton.Location = new System.Drawing.Point(266, 2);
			this.textBoxDescription.CustomButton.Name = "";
			this.textBoxDescription.CustomButton.Size = new System.Drawing.Size(55, 55);
			this.textBoxDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxDescription.CustomButton.TabIndex = 1;
			this.textBoxDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxDescription.CustomButton.UseSelectable = true;
			this.textBoxDescription.CustomButton.Visible = false;
			this.textBoxDescription.Lines = new string[0];
			this.textBoxDescription.Location = new System.Drawing.Point(100, 172);
			this.textBoxDescription.MaxLength = 128;
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.PasswordChar = '\0';
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxDescription.SelectedText = "";
			this.textBoxDescription.SelectionLength = 0;
			this.textBoxDescription.SelectionStart = 0;
			this.textBoxDescription.ShortcutsEnabled = true;
			this.textBoxDescription.Size = new System.Drawing.Size(324, 60);
			this.textBoxDescription.TabIndex = 4;
			this.textBoxDescription.UseSelectable = true;
			this.textBoxDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOK.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOK.Location = new System.Drawing.Point(270, 301);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(2);
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
			this.buttonCancel.Location = new System.Drawing.Point(349, 301);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
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
			this.dictionaryComboProduct.Location = new System.Drawing.Point(100, 64);
			this.dictionaryComboProduct.Margin = new System.Windows.Forms.Padding(4);
			this.dictionaryComboProduct.Name = "dictionaryComboProduct";
			this.dictionaryComboProduct.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboProduct.Size = new System.Drawing.Size(324, 21);
			this.dictionaryComboProduct.TabIndex = 5;
			this.dictionaryComboProduct.Type = null;
			this.dictionaryComboProduct.SelectedIndexChanged += new System.EventHandler(this.DictionaryComboProductSelectedIndexChanged);
			// 
			// labelPartNumber
			// 
			this.labelPartNumber.AutoSize = true;
			this.labelPartNumber.Location = new System.Drawing.Point(4, 146);
			this.labelPartNumber.Name = "labelPartNumber";
			this.labelPartNumber.Size = new System.Drawing.Size(90, 19);
			this.labelPartNumber.TabIndex = 0;
			this.labelPartNumber.Text = "Part Number:";
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(4, 172);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(77, 19);
			this.labelDescription.TabIndex = 0;
			this.labelDescription.Text = "Description:";
			// 
			// labelProduct
			// 
			this.labelProduct.AutoSize = true;
			this.labelProduct.Location = new System.Drawing.Point(4, 64);
			this.labelProduct.Name = "labelProduct";
			this.labelProduct.Size = new System.Drawing.Size(58, 19);
			this.labelProduct.TabIndex = 16;
			this.labelProduct.Text = "Product:";
			// 
			// comboBoxDetailClass
			// 
			this.comboBoxDetailClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxDetailClass.Displayer = null;
			this.comboBoxDetailClass.DisplayerText = null;
			this.comboBoxDetailClass.DropDownHeight = 106;
			this.comboBoxDetailClass.Entity = null;
			this.comboBoxDetailClass.Location = new System.Drawing.Point(100, 120);
			this.comboBoxDetailClass.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxDetailClass.Name = "comboBoxDetailClass";
			this.comboBoxDetailClass.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.comboBoxDetailClass.RootNodesNames = null;
			this.comboBoxDetailClass.Size = new System.Drawing.Size(324, 21);
			this.comboBoxDetailClass.TabIndex = 2;
			this.comboBoxDetailClass.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDetailClassSelectedIndexChanged);
			// 
			// labelDetailModel
			// 
			this.labelDetailModel.AutoSize = true;
			this.labelDetailModel.Location = new System.Drawing.Point(4, 120);
			this.labelDetailModel.Name = "labelDetailModel";
			this.labelDetailModel.Size = new System.Drawing.Size(41, 19);
			this.labelDetailModel.TabIndex = 17;
			this.labelDetailModel.Text = "Class:";
			// 
			// labelMeasure
			// 
			this.labelMeasure.AutoSize = true;
			this.labelMeasure.Location = new System.Drawing.Point(4, 238);
			this.labelMeasure.Name = "labelMeasure";
			this.labelMeasure.Size = new System.Drawing.Size(62, 19);
			this.labelMeasure.TabIndex = 0;
			this.labelMeasure.Text = "Measure:";
			// 
			// comboBoxMeasure
			// 
			this.comboBoxMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxMeasure.FormattingEnabled = true;
			this.comboBoxMeasure.Location = new System.Drawing.Point(100, 238);
			this.comboBoxMeasure.Name = "comboBoxMeasure";
			this.comboBoxMeasure.Size = new System.Drawing.Size(324, 21);
			this.comboBoxMeasure.TabIndex = 7;
			this.comboBoxMeasure.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMeasureSelectedIndexChanged);
			// 
			// labelQuantity
			// 
			this.labelQuantity.AutoSize = true;
			this.labelQuantity.Location = new System.Drawing.Point(4, 267);
			this.labelQuantity.Name = "labelQuantity";
			this.labelQuantity.Size = new System.Drawing.Size(61, 19);
			this.labelQuantity.TabIndex = 0;
			this.labelQuantity.Text = "Quantity:";
			// 
			// numericUpDownQuantity
			// 
			this.numericUpDownQuantity.Location = new System.Drawing.Point(100, 267);
			this.numericUpDownQuantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownQuantity.Name = "numericUpDownQuantity";
			this.numericUpDownQuantity.Size = new System.Drawing.Size(324, 20);
			this.numericUpDownQuantity.TabIndex = 8;
			this.numericUpDownQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textBoxStandart
			// 
			this.textBoxStandart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			// 
			// 
			// 
			this.textBoxStandart.CustomButton.Image = null;
			this.textBoxStandart.CustomButton.Location = new System.Drawing.Point(307, 2);
			this.textBoxStandart.CustomButton.Name = "";
			this.textBoxStandart.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxStandart.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxStandart.CustomButton.TabIndex = 1;
			this.textBoxStandart.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxStandart.CustomButton.UseSelectable = true;
			this.textBoxStandart.CustomButton.Visible = false;
			this.textBoxStandart.Lines = new string[0];
			this.textBoxStandart.Location = new System.Drawing.Point(100, 92);
			this.textBoxStandart.MaxLength = 128;
			this.textBoxStandart.Name = "textBoxStandart";
			this.textBoxStandart.PasswordChar = '\0';
			this.textBoxStandart.ReadOnly = true;
			this.textBoxStandart.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxStandart.SelectedText = "";
			this.textBoxStandart.SelectionLength = 0;
			this.textBoxStandart.SelectionStart = 0;
			this.textBoxStandart.ShortcutsEnabled = true;
			this.textBoxStandart.Size = new System.Drawing.Size(325, 20);
			this.textBoxStandart.TabIndex = 87;
			this.textBoxStandart.UseSelectable = true;
			this.textBoxStandart.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxStandart.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelStandart
			// 
			this.labelStandart.Location = new System.Drawing.Point(4, 87);
			this.labelStandart.Name = "labelStandart";
			this.labelStandart.Size = new System.Drawing.Size(69, 25);
			this.labelStandart.TabIndex = 88;
			this.labelStandart.Text = "Standard:";
			this.labelStandart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// StockComponentInfoForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(434, 340);
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
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1023, 340);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(350, 340);
			this.Name = "StockComponentInfoForm";
			this.Resizable = false;
			this.Text = "Stock Detail Info Form";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private MetroTextBox textBoxPartNumber;
        private MetroTextBox textBoxDescription;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private Auxiliary.LookupCombobox dictionaryComboProduct;
        private MetroLabel labelPartNumber;
        private MetroLabel labelDescription;
        private MetroLabel labelProduct;
        private Auxiliary.TreeDictionaryComboBox comboBoxDetailClass;
        private MetroLabel labelDetailModel;
        private MetroLabel labelMeasure;
        private System.Windows.Forms.ComboBox comboBoxMeasure;
        private MetroLabel labelQuantity;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private MetroTextBox textBoxStandart;
        private MetroLabel labelStandart;
    }
}