namespace CAS.UI.UIControls.PurchaseControls
{
    partial class PurchaseRequestForm
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
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.labelPublishDate = new System.Windows.Forms.Label();
            this.dateTimePickerPublishDate = new System.Windows.Forms.DateTimePicker();
            this.labelOpeningDate = new System.Windows.Forms.Label();
            this.dateTimePickerOpeningDate = new System.Windows.Forms.DateTimePicker();
            this.labelClosingDate = new System.Windows.Forms.Label();
            this.dateTimePickerClosingDate = new System.Windows.Forms.DateTimePicker();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Remarks = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.flowLayoutPanelFileControls = new System.Windows.Forms.FlowLayoutPanel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxAuthor.Location = new System.Drawing.Point(127, 100);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(252, 22);
            this.textBoxAuthor.TabIndex = 117;
            // 
            // labelPublishDate
            // 
            this.labelPublishDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPublishDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelPublishDate.Location = new System.Drawing.Point(3, 159);
            this.labelPublishDate.Name = "labelPublishDate";
            this.labelPublishDate.Size = new System.Drawing.Size(118, 20);
            this.labelPublishDate.TabIndex = 116;
            this.labelPublishDate.Text = "Publishing Date:";
            this.labelPublishDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerPublishDate
            // 
            this.dateTimePickerPublishDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerPublishDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerPublishDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerPublishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerPublishDate.Location = new System.Drawing.Point(127, 156);
            this.dateTimePickerPublishDate.Name = "dateTimePickerPublishDate";
            this.dateTimePickerPublishDate.Size = new System.Drawing.Size(252, 22);
            this.dateTimePickerPublishDate.TabIndex = 115;
            this.dateTimePickerPublishDate.ValueChanged += new System.EventHandler(this.DateTimePickerPublishDateValueChanged);
            // 
            // labelOpeningDate
            // 
            this.labelOpeningDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOpeningDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelOpeningDate.Location = new System.Drawing.Point(3, 131);
            this.labelOpeningDate.Name = "labelOpeningDate";
            this.labelOpeningDate.Size = new System.Drawing.Size(118, 20);
            this.labelOpeningDate.TabIndex = 114;
            this.labelOpeningDate.Text = "Opening Date:";
            this.labelOpeningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerOpeningDate
            // 
            this.dateTimePickerOpeningDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerOpeningDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerOpeningDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerOpeningDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOpeningDate.Location = new System.Drawing.Point(127, 128);
            this.dateTimePickerOpeningDate.Name = "dateTimePickerOpeningDate";
            this.dateTimePickerOpeningDate.Size = new System.Drawing.Size(252, 22);
            this.dateTimePickerOpeningDate.TabIndex = 113;
            this.dateTimePickerOpeningDate.ValueChanged += new System.EventHandler(this.DateTimePickerOpeningDateValueChanged);
            // 
            // labelClosingDate
            // 
            this.labelClosingDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClosingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelClosingDate.Location = new System.Drawing.Point(3, 187);
            this.labelClosingDate.Name = "labelClosingDate";
            this.labelClosingDate.Size = new System.Drawing.Size(118, 20);
            this.labelClosingDate.TabIndex = 112;
            this.labelClosingDate.Text = "Closing Date:";
            this.labelClosingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerClosingDate
            // 
            this.dateTimePickerClosingDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerClosingDate.Font = new System.Drawing.Font("Verdana", 9F);
            this.dateTimePickerClosingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerClosingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerClosingDate.Location = new System.Drawing.Point(127, 184);
            this.dateTimePickerClosingDate.Name = "dateTimePickerClosingDate";
            this.dateTimePickerClosingDate.Size = new System.Drawing.Size(252, 22);
            this.dateTimePickerClosingDate.TabIndex = 111;
            this.dateTimePickerClosingDate.ValueChanged += new System.EventHandler(this.DateTimePickerClosingDateValueChanged);
            // 
            // labelAuthor
            // 
            this.labelAuthor.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAuthor.Location = new System.Drawing.Point(3, 102);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(118, 20);
            this.labelAuthor.TabIndex = 110;
            this.labelAuthor.Text = "Author:";
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDescription
            // 
            this.labelDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDescription.Location = new System.Drawing.Point(3, 30);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(118, 20);
            this.labelDescription.TabIndex = 109;
            this.labelDescription.Text = "Description:";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxDescription.Location = new System.Drawing.Point(127, 28);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(252, 66);
            this.textBoxDescription.TabIndex = 108;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelTitle.Location = new System.Drawing.Point(3, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(118, 20);
            this.labelTitle.TabIndex = 107;
            this.labelTitle.Text = "Title:";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxTitle.Location = new System.Drawing.Point(127, 0);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(252, 22);
            this.textBoxTitle.TabIndex = 106;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label1.Location = new System.Drawing.Point(3, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 105;
            this.label1.Text = "Remarks:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_Remarks
            // 
            this.textBox_Remarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Remarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBox_Remarks.Location = new System.Drawing.Point(127, 212);
            this.textBox_Remarks.Multiline = true;
            this.textBox_Remarks.Name = "textBox_Remarks";
            this.textBox_Remarks.Size = new System.Drawing.Size(252, 77);
            this.textBox_Remarks.TabIndex = 104;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.Location = new System.Drawing.Point(294, 2);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(30, 23);
            this.buttonOk.TabIndex = 102;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(332, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(47, 23);
            this.buttonCancel.TabIndex = 103;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.Controls.Add(this.flowLayoutPanelFileControls);
            this.panelMain.Controls.Add(this.labelTitle);
            this.panelMain.Controls.Add(this.textBox_Remarks);
            this.panelMain.Controls.Add(this.textBoxAuthor);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.labelPublishDate);
            this.panelMain.Controls.Add(this.textBoxTitle);
            this.panelMain.Controls.Add(this.dateTimePickerPublishDate);
            this.panelMain.Controls.Add(this.textBoxDescription);
            this.panelMain.Controls.Add(this.labelOpeningDate);
            this.panelMain.Controls.Add(this.labelDescription);
            this.panelMain.Controls.Add(this.dateTimePickerOpeningDate);
            this.panelMain.Controls.Add(this.labelAuthor);
            this.panelMain.Controls.Add(this.labelClosingDate);
            this.panelMain.Controls.Add(this.dateTimePickerClosingDate);
            this.panelMain.Location = new System.Drawing.Point(3, 3);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(383, 508);
            this.panelMain.TabIndex = 118;
            // 
            // flowLayoutPanelFileControls
            // 
            this.flowLayoutPanelFileControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelFileControls.AutoScroll = true;
            this.flowLayoutPanelFileControls.Location = new System.Drawing.Point(1, 295);
            this.flowLayoutPanelFileControls.MinimumSize = new System.Drawing.Size(381, 2);
            this.flowLayoutPanelFileControls.Name = "flowLayoutPanelFileControls";
            this.flowLayoutPanelFileControls.Size = new System.Drawing.Size(381, 213);
            this.flowLayoutPanelFileControls.TabIndex = 118;
            this.flowLayoutPanelFileControls.Visible = false;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Controls.Add(this.buttonOk);
            this.panelButtons.Location = new System.Drawing.Point(3, 517);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(383, 28);
            this.panelButtons.TabIndex = 119;
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMain.Controls.Add(this.panelMain);
            this.flowLayoutPanelMain.Controls.Add(this.panelButtons);
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(389, 548);
            this.flowLayoutPanelMain.TabIndex = 120;
            // 
            // PurchaseRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(391, 550);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurchaseRequestForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order Form";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Label labelPublishDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerPublishDate;
        private System.Windows.Forms.Label labelOpeningDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerOpeningDate;
        private System.Windows.Forms.Label labelClosingDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerClosingDate;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Remarks;
        public System.Windows.Forms.Button buttonOk;
        public System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFileControls;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;

    }
}