namespace CAS.UI.UIControls.PurchaseControls
{
    partial class PurchaseOrderKitSupplierItem
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
			this.checkBoxSupplier = new System.Windows.Forms.CheckBox();
			this.labelSupplierName = new System.Windows.Forms.Label();
			this.flowLayoutPanelCostConditions = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// checkBoxSupplier
			// 
			this.checkBoxSupplier.AutoSize = true;
			this.checkBoxSupplier.Checked = true;
			this.checkBoxSupplier.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSupplier.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.checkBoxSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxSupplier.Location = new System.Drawing.Point(3, 16);
			this.checkBoxSupplier.Name = "checkBoxSupplier";
			this.checkBoxSupplier.Size = new System.Drawing.Size(15, 14);
			this.checkBoxSupplier.TabIndex = 0;
			this.checkBoxSupplier.UseVisualStyleBackColor = true;
			this.checkBoxSupplier.CheckedChanged += new System.EventHandler(this.CheckBoxSupplierCheckedChanged);
			// 
			// labelSupplierName
			// 
			this.labelSupplierName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSupplierName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSupplierName.Location = new System.Drawing.Point(24, 0);
			this.labelSupplierName.Name = "labelSupplierName";
			this.labelSupplierName.Size = new System.Drawing.Size(203, 48);
			this.labelSupplierName.TabIndex = 1;
			this.labelSupplierName.Text = "Name:";
			this.labelSupplierName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// flowLayoutPanelCostConditions
			// 
			this.flowLayoutPanelCostConditions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanelCostConditions.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.flowLayoutPanelCostConditions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.flowLayoutPanelCostConditions.Location = new System.Drawing.Point(233, 0);
			this.flowLayoutPanelCostConditions.Name = "flowLayoutPanelCostConditions";
			this.flowLayoutPanelCostConditions.Size = new System.Drawing.Size(334, 48);
			this.flowLayoutPanelCostConditions.TabIndex = 2;
			// 
			// PurchaseOrderKitSupplierItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.flowLayoutPanelCostConditions);
			this.Controls.Add(this.labelSupplierName);
			this.Controls.Add(this.checkBoxSupplier);
			this.Name = "PurchaseOrderKitSupplierItem";
			this.Size = new System.Drawing.Size(570, 51);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxSupplier;
        private System.Windows.Forms.Label labelSupplierName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCostConditions;
    }
}
