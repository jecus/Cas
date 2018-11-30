using System.Collections.Generic;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class ReplaceComponentForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
			this.panelButtons = new System.Windows.Forms.Panel();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.labelConfirmDate = new System.Windows.Forms.Label();
			this.labelReplacedDetail = new System.Windows.Forms.Label();
			this.labelReplaceByDetail = new System.Windows.Forms.Label();
			this.labelReplaceByDate = new System.Windows.Forms.Label();
			this.panelButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanelMain
			// 
			this.flowLayoutPanelMain.AutoScroll = true;
			this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 22);
			this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
			this.flowLayoutPanelMain.Size = new System.Drawing.Size(1280, 300);
			this.flowLayoutPanelMain.TabIndex = 0;
			// 
			// panelButtons
			// 
			this.panelButtons.Controls.Add(this.buttonCancel);
			this.panelButtons.Controls.Add(this.buttonOK);
			this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelButtons.Location = new System.Drawing.Point(0, 322);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(1284, 34);
			this.panelButtons.TabIndex = 1;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(1197, 6);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(1116, 6);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// labelConfirmDate
			// 
			this.labelConfirmDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelConfirmDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelConfirmDate.Location = new System.Drawing.Point(5, 0);
			this.labelConfirmDate.Name = "labelConfirmDate";
			this.labelConfirmDate.Size = new System.Drawing.Size(123, 19);
			this.labelConfirmDate.TabIndex = 28;
			this.labelConfirmDate.Text = "Confirm date:";
			this.labelConfirmDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelReplacedDetail
			// 
			this.labelReplacedDetail.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelReplacedDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelReplacedDetail.Location = new System.Drawing.Point(131, 0);
			this.labelReplacedDetail.Name = "labelReplacedDetail";
			this.labelReplacedDetail.Size = new System.Drawing.Size(100, 19);
			this.labelReplacedDetail.TabIndex = 70;
			this.labelReplacedDetail.Text = "Confirm date:";
			this.labelReplacedDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelReplaceByDetail
			// 
			this.labelReplaceByDetail.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelReplaceByDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelReplaceByDetail.Location = new System.Drawing.Point(645, 0);
			this.labelReplaceByDetail.Name = "labelReplaceByDetail";
			this.labelReplaceByDetail.Size = new System.Drawing.Size(101, 19);
			this.labelReplaceByDetail.TabIndex = 71;
			this.labelReplaceByDetail.Text = "Confirm date:";
			this.labelReplaceByDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelReplaceByDate
			// 
			this.labelReplaceByDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelReplaceByDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelReplaceByDate.Location = new System.Drawing.Point(1159, 0);
			this.labelReplaceByDate.Name = "labelReplaceByDate";
			this.labelReplaceByDate.Size = new System.Drawing.Size(100, 19);
			this.labelReplaceByDate.TabIndex = 72;
			this.labelReplaceByDate.Text = "Confirm date:";
			this.labelReplaceByDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReplaceComponentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.ClientSize = new System.Drawing.Size(1284, 356);
			this.Controls.Add(this.labelReplaceByDate);
			this.Controls.Add(this.labelReplaceByDetail);
			this.Controls.Add(this.labelReplacedDetail);
			this.Controls.Add(this.labelConfirmDate);
			this.Controls.Add(this.flowLayoutPanelMain);
			this.Controls.Add(this.panelButtons);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1300, 800);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(670, 200);
			this.Name = "ReplaceComponentForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Replace details:";
			this.panelButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label labelConfirmDate;
		private System.Windows.Forms.Label labelReplacedDetail;
		private System.Windows.Forms.Label labelReplaceByDetail;
		private System.Windows.Forms.Label labelReplaceByDate;
	}
}
