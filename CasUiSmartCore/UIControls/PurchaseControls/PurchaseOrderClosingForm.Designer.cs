namespace CAS.UI.UIControls.PurchaseControls
{
    partial class PurchaseOrderClosingForm
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
            this.labelClosingDate = new System.Windows.Forms.Label();
            this.dateTimePickerClosingDate = new System.Windows.Forms.DateTimePicker();
            this.labelRemarks = new System.Windows.Forms.Label();
            this.textBox_Remarks = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelFileControls = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelClosingDate
            // 
            this.labelClosingDate.AutoSize = true;
            this.labelClosingDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClosingDate.ForeColor = System.Drawing.Color.DimGray;
            this.labelClosingDate.Location = new System.Drawing.Point(12, 14);
            this.labelClosingDate.Name = "labelClosingDate";
            this.labelClosingDate.Size = new System.Drawing.Size(42, 14);
            this.labelClosingDate.TabIndex = 3;
            this.labelClosingDate.Text = "Date:";
            // 
            // dateTimePickerClosingDate
            // 
            this.dateTimePickerClosingDate.CalendarFont = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerClosingDate.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dateTimePickerClosingDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerClosingDate.Location = new System.Drawing.Point(98, 8);
            this.dateTimePickerClosingDate.Name = "dateTimePickerClosingDate";
            this.dateTimePickerClosingDate.Size = new System.Drawing.Size(267, 22);
            this.dateTimePickerClosingDate.TabIndex = 4;
            this.dateTimePickerClosingDate.ValueChanged += new System.EventHandler(this.DateTimePickerClosingDateValueChanged);
            // 
            // labelRemarks
            // 
            this.labelRemarks.AutoSize = true;
            this.labelRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRemarks.ForeColor = System.Drawing.Color.DimGray;
            this.labelRemarks.Location = new System.Drawing.Point(12, 39);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(66, 14);
            this.labelRemarks.TabIndex = 5;
            this.labelRemarks.Text = "Remarks:";
            // 
            // textBox_Remarks
            // 
            this.textBox_Remarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Remarks.Location = new System.Drawing.Point(98, 36);
            this.textBox_Remarks.Multiline = true;
            this.textBox_Remarks.Name = "textBox_Remarks";
            this.textBox_Remarks.Size = new System.Drawing.Size(267, 104);
            this.textBox_Remarks.TabIndex = 6;
            // 
            // flowLayoutPanelFileControls
            // 
            this.flowLayoutPanelFileControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelFileControls.AutoScroll = true;
            this.flowLayoutPanelFileControls.Location = new System.Drawing.Point(5, 147);
            this.flowLayoutPanelFileControls.Name = "flowLayoutPanelFileControls";
            this.flowLayoutPanelFileControls.Size = new System.Drawing.Size(381, 347);
            this.flowLayoutPanelFileControls.TabIndex = 7;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.Location = new System.Drawing.Point(303, 500);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(30, 23);
            this.buttonOk.TabIndex = 104;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(339, 500);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(47, 23);
            this.buttonCancel.TabIndex = 105;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // PurchaseOrderClosingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 522);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.flowLayoutPanelFileControls);
            this.Controls.Add(this.labelRemarks);
            this.Controls.Add(this.textBox_Remarks);
            this.Controls.Add(this.labelClosingDate);
            this.Controls.Add(this.dateTimePickerClosingDate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(415, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(405, 450);
            this.Name = "PurchaseOrderClosingForm";
            this.ShowIcon = false;
            this.Text = "Purchase Order Closing Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelClosingDate;
        public System.Windows.Forms.DateTimePicker dateTimePickerClosingDate;
        public System.Windows.Forms.Label labelRemarks;
        public System.Windows.Forms.TextBox textBox_Remarks;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFileControls;
        public System.Windows.Forms.Button buttonOk;
        public System.Windows.Forms.Button buttonCancel;
    }
}