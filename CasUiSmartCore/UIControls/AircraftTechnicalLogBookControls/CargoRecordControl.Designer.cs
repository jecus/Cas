using CAS.UI.Helpers;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class CargoRecordControl
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
            this.comboBoxCargoCategory = new System.Windows.Forms.ComboBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelWeight = new System.Windows.Forms.Label();
            this.labelMeasure = new System.Windows.Forms.Label();
            this.numericUpDownWeight = new System.Windows.Forms.NumericUpDown();
            this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPassCategory
            // 
            this.labelPassCategory.AutoSize = true;
            this.labelPassCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassCategory.Location = new System.Drawing.Point(4, 0);
            this.labelPassCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassCategory.Name = "labelPassCategory";
            this.labelPassCategory.Size = new System.Drawing.Size(124, 17);
            this.labelPassCategory.TabIndex = 140;
            this.labelPassCategory.Text = "Cargo category:";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 4;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxCargoCategory, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.buttonDelete, 3, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelPassCategory, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelWeight, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelMeasure, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownWeight, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxMeasure, 2, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 4);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(576, 45);
            this.tableLayoutPanelMain.TabIndex = 176;
            // 
            // comboBoxCargoCategory
            // 
            this.comboBoxCargoCategory.FormattingEnabled = true;
            this.comboBoxCargoCategory.Location = new System.Drawing.Point(4, 17);
            this.comboBoxCargoCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.comboBoxCargoCategory.Name = "comboBoxCargoCategory";
            this.comboBoxCargoCategory.Size = new System.Drawing.Size(199, 24);
            this.comboBoxCargoCategory.TabIndex = 1;
            this.comboBoxCargoCategory.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(537, 17);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(35, 28);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "-";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWeight.Location = new System.Drawing.Point(211, 0);
            this.labelWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(58, 17);
            this.labelWeight.TabIndex = 186;
            this.labelWeight.Text = "Weight";
            // 
            // labelMeasure
            // 
            this.labelMeasure.AutoSize = true;
            this.labelMeasure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMeasure.Location = new System.Drawing.Point(337, 0);
            this.labelMeasure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMeasure.Name = "labelMeasure";
            this.labelMeasure.Size = new System.Drawing.Size(70, 17);
            this.labelMeasure.TabIndex = 188;
            this.labelMeasure.Text = "Measure";
            // 
            // numericUpDownWeight
            // 
            this.numericUpDownWeight.DecimalPlaces = 2;
            this.numericUpDownWeight.Location = new System.Drawing.Point(210, 17);
            this.numericUpDownWeight.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.numericUpDownWeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownWeight.Name = "numericUpDownWeight";
            this.numericUpDownWeight.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownWeight.TabIndex = 2;
            this.numericUpDownWeight.ValueChanged += new System.EventHandler(this.NumericUpDownValueChanged);
            // 
            // comboBoxMeasure
            // 
            this.comboBoxMeasure.FormattingEnabled = true;
            this.comboBoxMeasure.Location = new System.Drawing.Point(334, 17);
            this.comboBoxMeasure.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.comboBoxMeasure.Name = "comboBoxMeasure";
            this.comboBoxMeasure.Size = new System.Drawing.Size(199, 24);
            this.comboBoxMeasure.TabIndex = 3;
            this.comboBoxMeasure.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMeasureSelectedIndexChanged);
            this.comboBoxMeasure.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// CargoRecordControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CargoRecordControl";
            this.Size = new System.Drawing.Size(580, 49);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPassCategory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.NumericUpDown numericUpDownWeight;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.Label labelMeasure;
        private System.Windows.Forms.ComboBox comboBoxCargoCategory;
        private System.Windows.Forms.ComboBox comboBoxMeasure;
    }
}
