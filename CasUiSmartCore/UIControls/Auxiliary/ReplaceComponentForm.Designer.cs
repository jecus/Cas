using System.Collections.Generic;
using MetroFramework.Controls;

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
			this.labelConfirmDate = new MetroFramework.Controls.MetroLabel();
			this.labelReplacedDetail = new MetroFramework.Controls.MetroLabel();
			this.labelReplaceByDetail = new MetroFramework.Controls.MetroLabel();
			this.labelReplaceByDate = new MetroFramework.Controls.MetroLabel();
			this.panelButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanelMain
			// 
			this.flowLayoutPanelMain.AutoScroll = true;
			this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelMain.Location = new System.Drawing.Point(2, 82);
			this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
			this.flowLayoutPanelMain.Size = new System.Drawing.Size(1280, 300);
			this.flowLayoutPanelMain.TabIndex = 0;
			// 
			// panelButtons
			// 
			this.panelButtons.Controls.Add(this.buttonCancel);
			this.panelButtons.Controls.Add(this.buttonOK);
			this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelButtons.Location = new System.Drawing.Point(20, 388);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(1244, 40);
			this.panelButtons.TabIndex = 1;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(1157, 3);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOK.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOK.Location = new System.Drawing.Point(1076, 3);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 33);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// labelConfirmDate
			// 
			this.labelConfirmDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelConfirmDate.Location = new System.Drawing.Point(7, 60);
			this.labelConfirmDate.Name = "labelConfirmDate";
			this.labelConfirmDate.Size = new System.Drawing.Size(123, 19);
			this.labelConfirmDate.TabIndex = 28;
			this.labelConfirmDate.Text = "Confirm date:";
			this.labelConfirmDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelReplacedDetail
			// 
			this.labelReplacedDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelReplacedDetail.Location = new System.Drawing.Point(133, 60);
			this.labelReplacedDetail.Name = "labelReplacedDetail";
			this.labelReplacedDetail.Size = new System.Drawing.Size(100, 19);
			this.labelReplacedDetail.TabIndex = 70;
			this.labelReplacedDetail.Text = "Confirm date:";
			this.labelReplacedDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelReplaceByDetail
			// 
			this.labelReplaceByDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelReplaceByDetail.Location = new System.Drawing.Point(647, 60);
			this.labelReplaceByDetail.Name = "labelReplaceByDetail";
			this.labelReplaceByDetail.Size = new System.Drawing.Size(101, 19);
			this.labelReplaceByDetail.TabIndex = 71;
			this.labelReplaceByDetail.Text = "Confirm date:";
			this.labelReplaceByDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelReplaceByDate
			// 
			this.labelReplaceByDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelReplaceByDate.Location = new System.Drawing.Point(1161, 60);
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
			this.ClientSize = new System.Drawing.Size(1284, 448);
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
			this.Text = "Replace details:";
			this.panelButtons.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
		private System.Windows.Forms.Panel panelButtons;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private MetroLabel labelConfirmDate;
		private MetroLabel labelReplacedDetail;
		private MetroLabel labelReplaceByDetail;
		private MetroLabel labelReplaceByDate;
	}
}
