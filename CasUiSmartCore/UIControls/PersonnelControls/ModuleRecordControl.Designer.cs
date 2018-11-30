namespace CAS.UI.UIControls.PersonnelControls
{
    partial class ModuleRecordControl
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
            this.labelModule = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelLevel = new System.Windows.Forms.Label();
            this.numericUpDownLevel = new System.Windows.Forms.NumericUpDown();
            this.dictionaryComboBoxModule = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // labelModule
            // 
            this.labelModule.AutoSize = true;
            this.labelModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelModule.Location = new System.Drawing.Point(4, 0);
            this.labelModule.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelModule.Name = "labelModule";
            this.labelModule.Size = new System.Drawing.Size(65, 17);
            this.labelModule.TabIndex = 0;
            this.labelModule.Text = "Module:";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Controls.Add(this.buttonDelete, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelModule, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelLevel, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownLevel, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.dictionaryComboBoxModule, 0, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 4);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(561, 52);
            this.tableLayoutPanelMain.TabIndex = 176;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(522, 17);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(35, 28);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "-";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLevel.Location = new System.Drawing.Point(434, 0);
            this.labelLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(52, 17);
            this.labelLevel.TabIndex = 0;
            this.labelLevel.Text = "Level:";
            // 
            // numericUpDownLevel
            // 
            this.numericUpDownLevel.Location = new System.Drawing.Point(434, 21);
            this.numericUpDownLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownLevel.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLevel.Name = "numericUpDownLevel";
            this.numericUpDownLevel.Size = new System.Drawing.Size(80, 22);
            this.numericUpDownLevel.TabIndex = 6;
            this.numericUpDownLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dictionaryComboBoxModule
            // 
            this.dictionaryComboBoxModule.Displayer = null;
            this.dictionaryComboBoxModule.DisplayerText = null;
            this.dictionaryComboBoxModule.Entity = null;
            this.dictionaryComboBoxModule.Location = new System.Drawing.Point(5, 22);
            this.dictionaryComboBoxModule.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dictionaryComboBoxModule.Name = "dictionaryComboBoxModule";
            this.dictionaryComboBoxModule.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictionaryComboBoxModule.Size = new System.Drawing.Size(420, 25);
            this.dictionaryComboBoxModule.TabIndex = 7;
            this.dictionaryComboBoxModule.SelectedIndexChanged += new System.EventHandler(this.dictionaryComboBoxModule_SelectedIndexChanged);
            // 
            // ModuleRecordControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ModuleRecordControl";
            this.Size = new System.Drawing.Size(565, 56);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelModule;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.NumericUpDown numericUpDownLevel;
        private Auxiliary.DictionaryComboBox dictionaryComboBoxModule;
    }
}
