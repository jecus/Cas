namespace CAS.UI.UIControls.ScheduleControls.PlanOPS
{
	partial class FlightPlanOpsRecordListScreen
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
			this.buttonApplyFilter = new AvControls.AvButtonT.AvButtonT();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this._statusImageLinkLabel1 = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this._statusImageLinkLabel2 = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 129);
			this.panel1.Size = new System.Drawing.Size(917, 413);
			// 
			// aircraftHeaderControl1
			//
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
			this.aircraftHeaderControl1.NextClickable = true;
			this.aircraftHeaderControl1.PrevClickable = true;
			// 
			// headerControl
			// 
			this.headerControl.Size = new System.Drawing.Size(985, 58);
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
			//
			// panelTopContainer
			//
			this.panelTopContainer.Controls.Add(this._statusImageLinkLabel1);
			this.panelTopContainer.Controls.Add(this._statusImageLinkLabel2);
			this.panelTopContainer.Controls.Add(this.flowLayoutPanel1);
			this.panelTopContainer.Size = new System.Drawing.Size(1138, 62);
			// 
			// buttonApplyFilter
			// 
			this.buttonApplyFilter.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonApplyFilter.ActiveBackgroundImage = null;
			this.buttonApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonApplyFilter.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonApplyFilter.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonApplyFilter.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonApplyFilter.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonApplyFilter.Icon = global::CAS.UI.Properties.Resources.ApplyFilterIcon;
			this.buttonApplyFilter.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonApplyFilter.IconNotEnabled = null;
			this.buttonApplyFilter.Location = new System.Drawing.Point(0, 0);
			this.buttonApplyFilter.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.buttonApplyFilter.Name = "buttonApplyFilter";
			this.buttonApplyFilter.NormalBackgroundImage = null;
			this.buttonApplyFilter.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.ShowToolTip = true;
			this.buttonApplyFilter.Size = new System.Drawing.Size(52, 57);
			this.buttonApplyFilter.TabIndex = 18;
			this.buttonApplyFilter.TextMain = "";
			this.buttonApplyFilter.TextSecondary = "";
			this.buttonApplyFilter.ToolTipText = "Apply filter";
			this.buttonApplyFilter.Click += ButtonApplyFilterClick;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox1.Location = new System.Drawing.Point(124, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(5, 50);
			this.pictureBox1.TabIndex = 15;
			this.pictureBox1.TabStop = false;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
			this.flowLayoutPanel1.Controls.Add(this.buttonApplyFilter);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(1291, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(190, 62);
			this.flowLayoutPanel1.TabIndex = 3;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// _statusImageLinkLabel1
			// 
			this._statusImageLinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._statusImageLinkLabel1.Displayer = null;
			this._statusImageLinkLabel1.DisplayerText = null;
			this._statusImageLinkLabel1.Entity = null;
			this._statusImageLinkLabel1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this._statusImageLinkLabel1.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this._statusImageLinkLabel1.ImageBackColor = System.Drawing.Color.Transparent;
			this._statusImageLinkLabel1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this._statusImageLinkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._statusImageLinkLabel1.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this._statusImageLinkLabel1.Location = new System.Drawing.Point(12, 6);
			this._statusImageLinkLabel1.Margin = new System.Windows.Forms.Padding(0);
			this._statusImageLinkLabel1.Name = "_statusImageLinkLabel1";
			this._statusImageLinkLabel1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this._statusImageLinkLabel1.Size = new System.Drawing.Size(250, 27);
			this._statusImageLinkLabel1.Status = AvControls.Statuses.Pending;
			this._statusImageLinkLabel1.TabIndex = 16;
			this._statusImageLinkLabel1.Text = "Schedule Flights";
			this._statusImageLinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._statusImageLinkLabel1.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this._statusImageLinkLabel1.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkSheduleDisplayerRequested);
			// 
			// _statusImageLinkLabel2
			// 
			this._statusImageLinkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._statusImageLinkLabel2.Displayer = null;
			this._statusImageLinkLabel2.DisplayerText = null;
			this._statusImageLinkLabel2.Entity = null;
			this._statusImageLinkLabel2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this._statusImageLinkLabel2.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this._statusImageLinkLabel2.ImageBackColor = System.Drawing.Color.Transparent;
			this._statusImageLinkLabel2.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this._statusImageLinkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._statusImageLinkLabel2.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this._statusImageLinkLabel2.Location = new System.Drawing.Point(12, 33);
			this._statusImageLinkLabel2.Margin = new System.Windows.Forms.Padding(0);
			this._statusImageLinkLabel2.Name = "_statusImageLinkLabel2";
			this._statusImageLinkLabel2.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this._statusImageLinkLabel2.Size = new System.Drawing.Size(250, 27);
			this._statusImageLinkLabel2.Status = AvControls.Statuses.Pending;
			this._statusImageLinkLabel2.TabIndex = 16;
			this._statusImageLinkLabel2.Text = "UnSchedule Flights";
			this._statusImageLinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._statusImageLinkLabel2.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this._statusImageLinkLabel2.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkUnSheduleDisplayerRequested);

			// 
			// PlanOPSListScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "FlightPlanOpsRecordListScreen";
			this.ShowAircraftStatusPanel = false;
			this.Size = new System.Drawing.Size(917, 590);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private AvControls.AvButtonT.AvButtonT buttonApplyFilter;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel _statusImageLinkLabel1;
		private CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel _statusImageLinkLabel2;

		#endregion
	}
}
