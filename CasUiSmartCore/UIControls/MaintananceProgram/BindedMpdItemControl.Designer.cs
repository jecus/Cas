namespace CAS.UI.UIControls.MaintananceProgram
{
    partial class BindedMpdItemControl
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
            this.labelMpdItem = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelClose = new System.Windows.Forms.Label();
            this.textBoxMpdItem = new System.Windows.Forms.TextBox();
            this.checkBoxClose = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMpdItem
            // 
            this.labelMpdItem.AutoSize = true;
            this.labelMpdItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMpdItem.Location = new System.Drawing.Point(3, 0);
            this.labelMpdItem.Name = "labelMpdItem";
            this.labelMpdItem.Size = new System.Drawing.Size(66, 13);
            this.labelMpdItem.TabIndex = 0;
            this.labelMpdItem.Text = "MPD Item:";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.Controls.Add(this.labelMpdItem, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelClose, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxMpdItem, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.checkBoxClose, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.dateTimePicker1, 2, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(332, 39);
            this.tableLayoutPanelMain.TabIndex = 176;
            // 
            // labelClose
            // 
            this.labelClose.AutoSize = true;
            this.labelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClose.Location = new System.Drawing.Point(160, 0);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(42, 13);
            this.labelClose.TabIndex = 0;
            this.labelClose.Text = "Close:";
            // 
            // textBoxMpdItem
            // 
            this.textBoxMpdItem.Location = new System.Drawing.Point(3, 16);
            this.textBoxMpdItem.Name = "textBoxMpdItem";
            this.textBoxMpdItem.ReadOnly = true;
            this.textBoxMpdItem.Size = new System.Drawing.Size(151, 20);
            this.textBoxMpdItem.TabIndex = 6;
            // 
            // checkBoxClose
            // 
            this.checkBoxClose.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxClose.Location = new System.Drawing.Point(160, 16);
            this.checkBoxClose.Name = "checkBoxClose";
            this.checkBoxClose.Size = new System.Drawing.Size(42, 20);
            this.checkBoxClose.TabIndex = 7;
            this.checkBoxClose.UseVisualStyleBackColor = true;
            this.checkBoxClose.CheckedChanged += new System.EventHandler(this.CheckBoxCloseCheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dateTimePicker1.Location = new System.Drawing.Point(208, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.Visible = false;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1ValueChanged);
            // 
            // BindedMpdItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BindedMpdItemControl";
            this.Size = new System.Drawing.Size(335, 42);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMpdItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.TextBox textBoxMpdItem;
        private System.Windows.Forms.CheckBox checkBoxClose;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
