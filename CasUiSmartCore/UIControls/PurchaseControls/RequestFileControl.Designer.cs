namespace CAS.UI.UIControls.PurchaseControls
{
    partial class RequestFileControl
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
            this.labelSupplierName = new System.Windows.Forms.Label();
            this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.labelRemarks = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSupplierName
            // 
            this.labelSupplierName.AutoSize = true;
            this.labelSupplierName.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.labelSupplierName.ForeColor = System.Drawing.Color.DimGray;
            this.labelSupplierName.Location = new System.Drawing.Point(3, 0);
            this.labelSupplierName.Name = "labelSupplierName";
            this.labelSupplierName.Size = new System.Drawing.Size(73, 18);
            this.labelSupplierName.TabIndex = 4;
            this.labelSupplierName.Text = "Supplier:";
            // 
            // fileControl
            // 
            this.fileControl.AttachedFile = null;
            this.fileControl.AutoSize = true;
            this.fileControl.BackColor = System.Drawing.Color.Transparent;
            this.fileControl.Description1 = null;
            this.fileControl.Description2 = null;
            this.fileControl.Filter = "PDF file (*.pdf)|*.pdf";
            this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
            this.fileControl.Location = new System.Drawing.Point(6, 21);
            this.fileControl.MaximumSize = new System.Drawing.Size(350, 75);
            this.fileControl.Name = "fileControl";
            this.fileControl.Size = new System.Drawing.Size(350, 75);
            this.fileControl.TabIndex = 3;
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.Location = new System.Drawing.Point(6, 120);
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(347, 40);
            this.textBoxRemarks.TabIndex = 5;
            // 
            // labelRemarks
            // 
            this.labelRemarks.AutoSize = true;
            this.labelRemarks.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.labelRemarks.ForeColor = System.Drawing.Color.DimGray;
            this.labelRemarks.Location = new System.Drawing.Point(3, 99);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(81, 18);
            this.labelRemarks.TabIndex = 6;
            this.labelRemarks.Text = "Remarks:";
            // 
            // RequestFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelRemarks);
            this.Controls.Add(this.textBoxRemarks);
            this.Controls.Add(this.labelSupplierName);
            this.Controls.Add(this.fileControl);
            this.Name = "RequestFileControl";
            this.Size = new System.Drawing.Size(355, 165);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelSupplierName;
        private Auxiliary.AttachedFileControl fileControl;
        private System.Windows.Forms.TextBox textBoxRemarks;
        public System.Windows.Forms.Label labelRemarks;
    }
}
