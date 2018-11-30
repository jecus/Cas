namespace CAS.UI.UIControls.Reliability
{
	partial class SystemListScreen
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
			this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
			this.headerControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.Size = new System.Drawing.Size(1458, 54);
			this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
			this.headerControl.ShowPrintButton = false;
			this.headerControl.ShowForecastButton = false;
			// 
			// aircraftHeaderControl1
			// 
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
			this.aircraftHeaderControl1.NextClickable = true;
			this.aircraftHeaderControl1.PrevClickable = true;
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(1462, 390);
			//
			// panelTopContainer
			//
			this.panelTopContainer.Controls.Add(this.labelTitle);
			// 
			// labelTitle
			// 
			this.labelTitle.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
			this.labelTitle.ForeColor = System.Drawing.Color.DimGray;
			this.labelTitle.Enabled = false;
			this.labelTitle.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.labelTitle.Location = new System.Drawing.Point(28, 3);
			this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
			this.labelTitle.Size = new System.Drawing.Size(600, 27);
			this.labelTitle.TabIndex = 16;
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ComponentChangeReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "ComponentChangeReport";
			this.Size = new System.Drawing.Size(1462, 607);
			this.ShowAircraftStatusPanel = false;
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;

		#endregion
	}
}
