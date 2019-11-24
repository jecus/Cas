namespace CAS.UI.UIControls.PurchaseControls
{
    partial class CostConditionItem
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
			this.checkBoxCost = new System.Windows.Forms.CheckBox();
			this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
			this.labelCostCondition = new System.Windows.Forms.Label();
			this.numericUpDownCost = new System.Windows.Forms.NumericUpDown();
			this.labelQuantity = new System.Windows.Forms.Label();
			this.labelCost = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBoxCost
			// 
			this.checkBoxCost.AutoSize = true;
			this.checkBoxCost.Checked = true;
			this.checkBoxCost.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxCost.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.checkBoxCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxCost.Location = new System.Drawing.Point(27, 4);
			this.checkBoxCost.Name = "checkBoxCost";
			this.checkBoxCost.Size = new System.Drawing.Size(15, 14);
			this.checkBoxCost.TabIndex = 0;
			this.checkBoxCost.UseVisualStyleBackColor = true;
			this.checkBoxCost.CheckedChanged += new System.EventHandler(this.CheckBoxCostCheckedChanged);
			// 
			// numericUpDownQuantity
			// 
			this.numericUpDownQuantity.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.numericUpDownQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.numericUpDownQuantity.Location = new System.Drawing.Point(150, 1);
			this.numericUpDownQuantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numericUpDownQuantity.Name = "numericUpDownQuantity";
			this.numericUpDownQuantity.Size = new System.Drawing.Size(50, 22);
			this.numericUpDownQuantity.TabIndex = 1;
			// 
			// labelCostCondition
			// 
			this.labelCostCondition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCostCondition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCostCondition.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.labelCostCondition.Location = new System.Drawing.Point(0, 3);
			this.labelCostCondition.Name = "labelCostCondition";
			this.labelCostCondition.Size = new System.Drawing.Size(25, 14);
			this.labelCostCondition.TabIndex = 2;
			this.labelCostCondition.Text = "CC";
			this.labelCostCondition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// numericUpDownCost
			// 
			this.numericUpDownCost.DecimalPlaces = 2;
			this.numericUpDownCost.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.numericUpDownCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.numericUpDownCost.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDownCost.Location = new System.Drawing.Point(70, 1);
			this.numericUpDownCost.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numericUpDownCost.Name = "numericUpDownCost";
			this.numericUpDownCost.Size = new System.Drawing.Size(50, 22);
			this.numericUpDownCost.TabIndex = 3;
			// 
			// labelQuantity
			// 
			this.labelQuantity.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelQuantity.Location = new System.Drawing.Point(126, 3);
			this.labelQuantity.Name = "labelQuantity";
			this.labelQuantity.Size = new System.Drawing.Size(22, 14);
			this.labelQuantity.TabIndex = 4;
			this.labelQuantity.Text = "Q:";
			this.labelQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelCost
			// 
			this.labelCost.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCost.Location = new System.Drawing.Point(47, 3);
			this.labelCost.Name = "labelCost";
			this.labelCost.Size = new System.Drawing.Size(21, 14);
			this.labelCost.TabIndex = 5;
			this.labelCost.Text = "C:";
			this.labelCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// CostConditionItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelCost);
			this.Controls.Add(this.labelQuantity);
			this.Controls.Add(this.numericUpDownCost);
			this.Controls.Add(this.labelCostCondition);
			this.Controls.Add(this.numericUpDownQuantity);
			this.Controls.Add(this.checkBoxCost);
			this.Name = "CostConditionItem";
			this.Size = new System.Drawing.Size(211, 30);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxCost;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Label labelCostCondition;
        private System.Windows.Forms.NumericUpDown numericUpDownCost;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelCost;
    }
}
