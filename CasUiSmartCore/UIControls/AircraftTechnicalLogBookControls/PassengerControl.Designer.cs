namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class PassengerControl
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
            this.labelPassCategory = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.dictComboPassCategory = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
            this.labelEconomy = new System.Windows.Forms.Label();
            this.labelBusiness = new System.Windows.Forms.Label();
            this.labelFirst = new System.Windows.Forms.Label();
            this.numericUpDownEconomy = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBusiness = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFirst = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEconomy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBusiness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFirst)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPassCategory
            // 
            this.labelPassCategory.AutoSize = true;
            this.labelPassCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassCategory.Location = new System.Drawing.Point(4, 0);
            this.labelPassCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassCategory.Name = "labelPassCategory";
            this.labelPassCategory.Size = new System.Drawing.Size(158, 17);
            this.labelPassCategory.TabIndex = 140;
            this.labelPassCategory.Text = "Passenger category:";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 5;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Controls.Add(this.buttonDelete, 4, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelPassCategory, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.dictComboPassCategory, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelEconomy, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelBusiness, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelFirst, 3, 0);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownEconomy, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownBusiness, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownFirst, 3, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 4);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(501, 45);
            this.tableLayoutPanelMain.TabIndex = 176;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(462, 17);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(35, 28);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "-";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // dictComboPassCategory
            // 
            this.dictComboPassCategory.Displayer = null;
            this.dictComboPassCategory.DisplayerText = null;
            this.dictComboPassCategory.Entity = null;
            this.dictComboPassCategory.Location = new System.Drawing.Point(1, 17);
            this.dictComboPassCategory.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.dictComboPassCategory.Name = "dictComboPassCategory";
            this.dictComboPassCategory.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictComboPassCategory.Size = new System.Drawing.Size(199, 24);
            this.dictComboPassCategory.TabIndex = 1;
            this.dictComboPassCategory.SelectedIndexChanged += new System.EventHandler(this.DictComboPassCategorySelectedIndexChanged);
            // 
            // labelEconomy
            // 
            this.labelEconomy.AutoSize = true;
            this.labelEconomy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEconomy.Location = new System.Drawing.Point(204, 0);
            this.labelEconomy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEconomy.Name = "labelEconomy";
            this.labelEconomy.Size = new System.Drawing.Size(73, 17);
            this.labelEconomy.TabIndex = 186;
            this.labelEconomy.Text = "Economy";
            // 
            // labelBusiness
            // 
            this.labelBusiness.AutoSize = true;
            this.labelBusiness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBusiness.Location = new System.Drawing.Point(290, 0);
            this.labelBusiness.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBusiness.Name = "labelBusiness";
            this.labelBusiness.Size = new System.Drawing.Size(73, 17);
            this.labelBusiness.TabIndex = 188;
            this.labelBusiness.Text = "Business";
            // 
            // labelFirst
            // 
            this.labelFirst.AutoSize = true;
            this.labelFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFirst.Location = new System.Drawing.Point(376, 0);
            this.labelFirst.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFirst.Name = "labelFirst";
            this.labelFirst.Size = new System.Drawing.Size(40, 17);
            this.labelFirst.TabIndex = 190;
            this.labelFirst.Text = "First";
            // 
            // numericUpDownEconomy
            // 
            this.numericUpDownEconomy.Location = new System.Drawing.Point(203, 17);
            this.numericUpDownEconomy.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.numericUpDownEconomy.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownEconomy.Name = "numericUpDownEconomy";
            this.numericUpDownEconomy.Size = new System.Drawing.Size(80, 22);
            this.numericUpDownEconomy.TabIndex = 2;
            this.numericUpDownEconomy.ValueChanged += new System.EventHandler(this.NumericUpDownValueChanged);
            // 
            // numericUpDownBusiness
            // 
            this.numericUpDownBusiness.Location = new System.Drawing.Point(289, 17);
            this.numericUpDownBusiness.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.numericUpDownBusiness.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownBusiness.Name = "numericUpDownBusiness";
            this.numericUpDownBusiness.Size = new System.Drawing.Size(80, 22);
            this.numericUpDownBusiness.TabIndex = 3;
            this.numericUpDownBusiness.ValueChanged += new System.EventHandler(this.NumericUpDownValueChanged);
            // 
            // numericUpDownFirst
            // 
            this.numericUpDownFirst.Location = new System.Drawing.Point(375, 17);
            this.numericUpDownFirst.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.numericUpDownFirst.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownFirst.Name = "numericUpDownFirst";
            this.numericUpDownFirst.Size = new System.Drawing.Size(80, 22);
            this.numericUpDownFirst.TabIndex = 4;
            this.numericUpDownFirst.ValueChanged += new System.EventHandler(this.NumericUpDownValueChanged);
            // 
            // PassengerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PassengerControl";
            this.Size = new System.Drawing.Size(505, 49);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEconomy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBusiness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFirst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPassCategory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.NumericUpDown numericUpDownEconomy;
        private System.Windows.Forms.Label labelEconomy;
        private System.Windows.Forms.NumericUpDown numericUpDownBusiness;
        private System.Windows.Forms.Label labelBusiness;
        private Auxiliary.DictionaryComboBox dictComboPassCategory;
        private System.Windows.Forms.NumericUpDown numericUpDownFirst;
        private System.Windows.Forms.Label labelFirst;
    }
}
