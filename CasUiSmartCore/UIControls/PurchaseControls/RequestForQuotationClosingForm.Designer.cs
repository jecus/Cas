namespace CAS.UI.UIControls.PurchaseControls
{
    partial class RequestForQuotationClosingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelRemarks = new System.Windows.Forms.Label();
            this.textBox_Remarks = new System.Windows.Forms.TextBox();
            this.checkBoxCreatePurchaseOrder = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dateTimePickerClosingDate = new System.Windows.Forms.DateTimePicker();
            this.labelClosingDate = new System.Windows.Forms.Label();
            this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.SuspendLayout();
            // 
            // labelRemarks
            // 
            this.labelRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemarks.Location = new System.Drawing.Point(12, 9);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(76, 20);
            this.labelRemarks.TabIndex = 80;
            this.labelRemarks.Text = "Remarks:";
            this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_Remarks
            // 
            this.textBox_Remarks.Location = new System.Drawing.Point(110, 10);
            this.textBox_Remarks.Multiline = true;
            this.textBox_Remarks.Name = "textBox_Remarks";
            this.textBox_Remarks.Size = new System.Drawing.Size(350, 77);
            this.textBox_Remarks.TabIndex = 4;
            // 
            // checkBoxCreatePurchaseOrder
            // 
            this.checkBoxCreatePurchaseOrder.Checked = true;
            this.checkBoxCreatePurchaseOrder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCreatePurchaseOrder.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxCreatePurchaseOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.checkBoxCreatePurchaseOrder.Location = new System.Drawing.Point(375, 133);
            this.checkBoxCreatePurchaseOrder.Name = "checkBoxCreatePurchaseOrder";
            this.checkBoxCreatePurchaseOrder.Size = new System.Drawing.Size(85, 53);
            this.checkBoxCreatePurchaseOrder.TabIndex = 81;
            this.checkBoxCreatePurchaseOrder.Text = "create Purchase order";
            this.checkBoxCreatePurchaseOrder.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.Location = new System.Drawing.Point(375, 196);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(30, 23);
            this.buttonOk.TabIndex = 13;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(413, 196);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(47, 23);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // dateTimePickerClosingDate
            // 
            this.dateTimePickerClosingDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerClosingDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dateTimePickerClosingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerClosingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerClosingDate.Location = new System.Drawing.Point(110, 105);
            this.dateTimePickerClosingDate.Name = "dateTimePickerClosingDate";
            this.dateTimePickerClosingDate.Size = new System.Drawing.Size(350, 22);
            this.dateTimePickerClosingDate.TabIndex = 11;
            this.dateTimePickerClosingDate.ValueChanged += new System.EventHandler(this.DateTimePickerClosingDateValueChanged);
            // 
            // labelClosingDate
            // 
            this.labelClosingDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClosingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelClosingDate.Location = new System.Drawing.Point(12, 105);
            this.labelClosingDate.Name = "labelClosingDate";
            this.labelClosingDate.Size = new System.Drawing.Size(92, 20);
            this.labelClosingDate.TabIndex = 82;
            this.labelClosingDate.Text = "ClosingDate:";
            this.labelClosingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _fileControl
            // 
            this.fileControl.AttachedFile = null;
            this.fileControl.AutoSize = true;
            this.fileControl.BackColor = System.Drawing.Color.Transparent;
            this.fileControl.Description1 = null;
            this.fileControl.Description2 = null;
            this.fileControl.Filter = "PDF file (*.pdf)|*.pdf";
            this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
            this.fileControl.Location = new System.Drawing.Point(12, 135);
            this.fileControl.MaximumSize = new System.Drawing.Size(350, 75);
            this.fileControl.MinimumSize = new System.Drawing.Size(350, 50);
            this.fileControl.Name = "_fileControl";
            this.fileControl.Size = new System.Drawing.Size(350, 50);
            this.fileControl.TabIndex = 5;
            // 
            // RequestForQuotationClosingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 231);
            this.Controls.Add(this.labelClosingDate);
            this.Controls.Add(this.checkBoxCreatePurchaseOrder);
            this.Controls.Add(this.labelRemarks);
            this.Controls.Add(this.textBox_Remarks);
            this.Controls.Add(this.dateTimePickerClosingDate);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.fileControl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(484, 269);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(484, 269);
            this.Name = "RequestForQuotationClosingForm";
            this.ShowIcon = false;
            this.Text = "Request For Quotation Closing Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.TextBox textBox_Remarks;
        private System.Windows.Forms.CheckBox checkBoxCreatePurchaseOrder;
        private CAS.UI.UIControls.Auxiliary.AttachedFileControl fileControl;
        private System.Windows.Forms.DateTimePicker dateTimePickerClosingDate;
        public System.Windows.Forms.Button buttonOk;
        public System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelClosingDate;
    }
}