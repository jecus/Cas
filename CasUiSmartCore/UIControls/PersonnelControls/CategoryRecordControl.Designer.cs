namespace CAS.UI.UIControls.PersonnelControls
{
    partial class CategoryRecordControl
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
            this.labelCategory = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.dictionaryComboBoxACType = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelAircraftType = new System.Windows.Forms.Label();
            this.dictionaryComboBoxCategory = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCategory.Location = new System.Drawing.Point(4, 0);
            this.labelCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(78, 17);
            this.labelCategory.TabIndex = 0;
            this.labelCategory.Text = "Category:";
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
            this.tableLayoutPanelMain.Controls.Add(this.dictionaryComboBoxACType, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.buttonDelete, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelCategory, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelAircraftType, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.dictionaryComboBoxCategory, 0, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 4);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(623, 52);
            this.tableLayoutPanelMain.TabIndex = 176;
            // 
            // dictionaryComboBoxACType
            // 
            this.dictionaryComboBoxACType.Displayer = null;
            this.dictionaryComboBoxACType.DisplayerText = null;
            this.dictionaryComboBoxACType.Entity = null;
            this.dictionaryComboBoxACType.Location = new System.Drawing.Point(415, 22);
            this.dictionaryComboBoxACType.Margin = new System.Windows.Forms.Padding(5);
            this.dictionaryComboBoxACType.Name = "dictionaryComboBoxACType";
            this.dictionaryComboBoxACType.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictionaryComboBoxACType.Size = new System.Drawing.Size(160, 25);
            this.dictionaryComboBoxACType.TabIndex = 8;
            this.dictionaryComboBoxACType.SelectedIndexChanged += new System.EventHandler(this.DictionaryComboBoxAcTypeSelectedIndexChanged);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(584, 17);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(35, 28);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "-";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // labelAircraftType
            // 
            this.labelAircraftType.AutoSize = true;
            this.labelAircraftType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAircraftType.Location = new System.Drawing.Point(414, 0);
            this.labelAircraftType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAircraftType.Name = "labelAircraftType";
            this.labelAircraftType.Size = new System.Drawing.Size(74, 17);
            this.labelAircraftType.TabIndex = 0;
            this.labelAircraftType.Text = "AC Type:";
            // 
            // dictionaryComboBoxCategory
            // 
            this.dictionaryComboBoxCategory.Displayer = null;
            this.dictionaryComboBoxCategory.DisplayerText = null;
            this.dictionaryComboBoxCategory.Entity = null;
            this.dictionaryComboBoxCategory.Location = new System.Drawing.Point(5, 22);
            this.dictionaryComboBoxCategory.Margin = new System.Windows.Forms.Padding(5);
            this.dictionaryComboBoxCategory.Name = "dictionaryComboBoxCategory";
            this.dictionaryComboBoxCategory.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictionaryComboBoxCategory.Size = new System.Drawing.Size(400, 25);
            this.dictionaryComboBoxCategory.TabIndex = 7;
            this.dictionaryComboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.DictionaryComboBoxModuleSelectedIndexChanged);
            // 
            // CategoryRecordControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CategoryRecordControl";
            this.Size = new System.Drawing.Size(627, 56);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelAircraftType;
        private Auxiliary.DictionaryComboBox dictionaryComboBoxCategory;
        private Auxiliary.LookupCombobox dictionaryComboBoxACType;
    }
}
