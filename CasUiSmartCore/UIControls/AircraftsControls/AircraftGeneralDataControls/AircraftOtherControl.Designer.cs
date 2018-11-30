namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
	partial class AircraftOtherControl
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
			this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lableTitle = new System.Windows.Forms.Label();
			this.panelAdd = new System.Windows.Forms.Panel();
			this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
			this.flowLayoutPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panelAdd.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel
			// 
			this.flowLayoutPanel.AutoScroll = true;
			this.flowLayoutPanel.Controls.Add(this.panel1);
			this.flowLayoutPanel.Controls.Add(this.panelAdd);
			this.flowLayoutPanel.Location = new System.Drawing.Point(0, 4);
			this.flowLayoutPanel.Name = "flowLayoutPanel";
			this.flowLayoutPanel.Size = new System.Drawing.Size(508, 346);
			this.flowLayoutPanel.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lableTitle);
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(461, 23);
			this.panel1.TabIndex = 6;
			// 
			// lableTitle
			// 
			this.lableTitle.AutoSize = true;
			this.lableTitle.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lableTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lableTitle.Location = new System.Drawing.Point(12, 0);
			this.lableTitle.Name = "lableTitle";
			this.lableTitle.Size = new System.Drawing.Size(0, 17);
			this.lableTitle.TabIndex = 0;
			// 
			// panelAdd
			// 
			this.panelAdd.Controls.Add(this.linkLabelAddNew);
			this.panelAdd.Location = new System.Drawing.Point(0, 29);
			this.panelAdd.Margin = new System.Windows.Forms.Padding(0);
			this.panelAdd.Name = "panelAdd";
			this.panelAdd.Size = new System.Drawing.Size(475, 24);
			this.panelAdd.TabIndex = 5;
			// 
			// linkLabelAddNew
			// 
			this.linkLabelAddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.linkLabelAddNew.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelAddNew.Location = new System.Drawing.Point(162, 0);
			this.linkLabelAddNew.Name = "linkLabelAddNew";
			this.linkLabelAddNew.Size = new System.Drawing.Size(170, 20);
			this.linkLabelAddNew.TabIndex = 1;
			this.linkLabelAddNew.TabStop = true;
			this.linkLabelAddNew.Text = "Add new";
			this.linkLabelAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelAddNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddNew_LinkClicked);
			// 
			// AircraftOtherControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.flowLayoutPanel);
			this.Name = "AircraftOtherControl";
			this.Size = new System.Drawing.Size(511, 353);
			this.flowLayoutPanel.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panelAdd.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
		private System.Windows.Forms.Panel panelAdd;
		private System.Windows.Forms.LinkLabel linkLabelAddNew;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lableTitle;
	}
}
