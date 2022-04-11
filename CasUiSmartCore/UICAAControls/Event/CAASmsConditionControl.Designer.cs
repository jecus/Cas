namespace CAS.UI.UICAAControls.Event
{
    partial class CAASmsConditionControl
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
            this.labelCondition = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.treeDictionaryComboCond = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCondition
            // 
            this.labelCondition.AutoSize = true;
            this.labelCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCondition.Location = new System.Drawing.Point(3, 0);
            this.labelCondition.Name = "labelCondition";
            this.labelCondition.Size = new System.Drawing.Size(64, 13);
            this.labelCondition.TabIndex = 0;
            this.labelCondition.Text = "Condition:";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanelMain.Controls.Add(this.labelCondition, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.buttonDelete, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.treeDictionaryComboCond, 0, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(438, 36);
            this.tableLayoutPanelMain.TabIndex = 176;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(409, 13);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(26, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "-";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // treeDictionaryComboCond
            // 
            this.treeDictionaryComboCond.Displayer = null;
            this.treeDictionaryComboCond.DisplayerText = null;
            this.treeDictionaryComboCond.Entity = null;
            this.treeDictionaryComboCond.Location = new System.Drawing.Point(3, 13);
            this.treeDictionaryComboCond.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.treeDictionaryComboCond.Name = "treeDictionaryComboCond";
            this.treeDictionaryComboCond.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.treeDictionaryComboCond.Size = new System.Drawing.Size(400, 20);
            this.treeDictionaryComboCond.TabIndex = 3;
            // 
            // SmsConditionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SmsConditionControl";
            this.Size = new System.Drawing.Size(441, 39);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCondition;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button buttonDelete;
        private UIControls.Auxiliary.TreeDictionaryComboBox treeDictionaryComboCond;
    }
}
