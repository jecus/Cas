namespace CAS.UI.UIControls.ScheduleControls
{
	partial class FlightNumberPeriodListControl
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
			this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
			this.flowLayoutPanelPerformances = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanelPerformances.SuspendLayout();
			this.SuspendLayout();
			// 
			// linkLabelAddNew
			// 
			this.linkLabelAddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.linkLabelAddNew.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelAddNew.Location = new System.Drawing.Point(3, 0);
			this.linkLabelAddNew.Name = "linkLabelAddNew";
			this.linkLabelAddNew.Size = new System.Drawing.Size(664, 23);
			this.linkLabelAddNew.TabIndex = 0;
			this.linkLabelAddNew.TabStop = true;
			this.linkLabelAddNew.Text = "Add new";
			this.linkLabelAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelAddNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddNew_LinkClicked);
			// 
			// flowLayoutPanelPerformances
			// 
			this.flowLayoutPanelPerformances.AutoSize = true;
			this.flowLayoutPanelPerformances.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanelPerformances.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.flowLayoutPanelPerformances.Controls.Add(this.linkLabelAddNew);
			this.flowLayoutPanelPerformances.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelPerformances.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanelPerformances.Name = "flowLayoutPanelPerformances";
			this.flowLayoutPanelPerformances.Size = new System.Drawing.Size(670, 23);
			this.flowLayoutPanelPerformances.TabIndex = 1;
			// 
			// FlightNumberPeriodListControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.Controls.Add(this.flowLayoutPanelPerformances);
			this.Name = "FlightNumberPeriodListControl";
			this.Size = new System.Drawing.Size(676, 41);
			this.flowLayoutPanelPerformances.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.LinkLabel linkLabelAddNew;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPerformances;
	}
}
