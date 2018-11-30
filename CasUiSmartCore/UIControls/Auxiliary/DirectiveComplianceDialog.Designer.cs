namespace CAS.UI.UIControls.Auxiliary
{
    partial class DirectiveComplianceDialog
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
            if (disposing)
            {
                dateTimePicker1.ValueChanged -= DateTimePicker1ValueChanged;    
            }
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
			this.label4 = new System.Windows.Forms.Label();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lifelengthViewer_LastCompliance
			// 
			this.lifelengthViewer_LastCompliance.EnabledCalendar = false;
			this.lifelengthViewer_LastCompliance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewer_LastCompliance.ShowCalendar = true;
			this.lifelengthViewer_LastCompliance.ShowLeftHeader = true;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.DimGray;
			this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
			this.dateTimePicker1.Size = new System.Drawing.Size(348, 20);
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1ValueChanged);
			// 
			// textBox_Remarks
			// 
			this.textBox_Remarks.ForeColor = System.Drawing.Color.DimGray;
			this.textBox_Remarks.Margin = new System.Windows.Forms.Padding(4);
			// 
			// fileControl
			// 
			this.fileControl.Location = new System.Drawing.Point(123, 259);
			this.fileControl.ShowLinkLabelBrowse = true;
			this.fileControl.Visible = false;
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.Location = new System.Drawing.Point(257, 361);
			this.buttonOk.Margin = new System.Windows.Forms.Padding(4);
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(338, 361);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.Location = new System.Drawing.Point(419, 361);
			this.buttonApply.Margin = new System.Windows.Forms.Padding(4);
			this.buttonApply.Click += new System.EventHandler(this.ButtonApplyClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.documentControl1);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(483, 334);
			this.groupBox1.Controls.SetChildIndex(this.documentControl1, 0);
			this.groupBox1.Controls.SetChildIndex(this.label4, 0);
			this.groupBox1.Controls.SetChildIndex(this.fileControl, 0);
			this.groupBox1.Controls.SetChildIndex(this.textBox_Remarks, 0);
			this.groupBox1.Controls.SetChildIndex(this.label2, 0);
			this.groupBox1.Controls.SetChildIndex(this.dateTimePicker1, 0);
			this.groupBox1.Controls.SetChildIndex(this.delimiter1, 0);
			this.groupBox1.Controls.SetChildIndex(this.label1, 0);
			this.groupBox1.Controls.SetChildIndex(this.delimiter2, 0);
			this.groupBox1.Controls.SetChildIndex(this.lifelengthViewer_LastCompliance, 0);
			this.groupBox1.Controls.SetChildIndex(this.checkBox1, 0);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(39, 124);
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.label4.ForeColor = System.Drawing.Color.DimGray;
			this.label4.Location = new System.Drawing.Point(28, 268);
			this.label4.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 18);
			this.label4.TabIndex = 13;
			this.label4.Text = "Document:";
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(115, 259);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(359, 41);
			this.documentControl1.TabIndex = 14;
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(501, 60);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(276, 289);
			this.checkedListBox1.TabIndex = 12;
			this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.label3.ForeColor = System.Drawing.Color.DimGray;
			this.label3.Location = new System.Drawing.Point(497, 39);
			this.label3.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 18);
			this.label3.TabIndex = 15;
			this.label3.Text = "Flights";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBox1.Location = new System.Drawing.Point(302, 69);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(171, 18);
			this.checkBox1.TabIndex = 63;
			this.checkBox1.Text = "Close With Mtop Check";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.Visible = false;
			this.checkBox1.Checked = false;
			// 
			// DirectiveComplianceDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.ClientSize = new System.Drawing.Size(489, 388);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.checkedListBox1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximumSize = new System.Drawing.Size(805, 428);
			this.Name = "DirectiveComplianceDialog";
			this.Text = "Directive Compliance";
			this.Load += new System.EventHandler(this.DirectiveComplianceDialog_Load);
			this.Controls.SetChildIndex(this.buttonOk, 0);
			this.Controls.SetChildIndex(this.buttonCancel, 0);
			this.Controls.SetChildIndex(this.buttonApply, 0);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.Controls.SetChildIndex(this.checkedListBox1, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion
		private System.Windows.Forms.Label label4;
		private DocumentationControls.DocumentControl documentControl1;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}