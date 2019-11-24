namespace CAS.UI.UIControls.PurchaseControls
{
    partial class PurchaseOrderKitFormItem
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
			this.checkBoxKit = new System.Windows.Forms.CheckBox();
			this.labelKitName = new System.Windows.Forms.Label();
			this.flowLayoutPanelSuppliers = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// checkBoxKit
			// 
			this.checkBoxKit.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.checkBoxKit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.checkBoxKit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkBoxKit.Location = new System.Drawing.Point(14, 52);
			this.checkBoxKit.Name = "checkBoxKit";
			this.checkBoxKit.Size = new System.Drawing.Size(15, 44);
			this.checkBoxKit.TabIndex = 0;
			this.checkBoxKit.UseVisualStyleBackColor = true;
			this.checkBoxKit.CheckedChanged += new System.EventHandler(this.CheckBoxKitCheckedChanged);
			// 
			// labelKitName
			// 
			this.labelKitName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelKitName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelKitName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelKitName.Location = new System.Drawing.Point(35, 15);
			this.labelKitName.Name = "labelKitName";
			this.labelKitName.Size = new System.Drawing.Size(223, 118);
			this.labelKitName.TabIndex = 1;
			this.labelKitName.Text = "Kit:";
			this.labelKitName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// flowLayoutPanelSuppliers
			// 
			this.flowLayoutPanelSuppliers.AutoScroll = true;
			this.flowLayoutPanelSuppliers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanelSuppliers.Enabled = false;
			this.flowLayoutPanelSuppliers.Location = new System.Drawing.Point(251, 3);
			this.flowLayoutPanelSuppliers.Name = "flowLayoutPanelSuppliers";
			this.flowLayoutPanelSuppliers.Size = new System.Drawing.Size(597, 142);
			this.flowLayoutPanelSuppliers.TabIndex = 2;
			// 
			// PurchaseOrderKitFormItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.flowLayoutPanelSuppliers);
			this.Controls.Add(this.labelKitName);
			this.Controls.Add(this.checkBoxKit);
			this.Name = "PurchaseOrderKitFormItem";
			this.Size = new System.Drawing.Size(851, 148);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxKit;
        private System.Windows.Forms.Label labelKitName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSuppliers;
    }
}
