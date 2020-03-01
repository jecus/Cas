namespace CAS.UI.UIControls.MTOP
{
	partial class MTOPScreen
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
			this.extendableRichContainerSummary = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.extendableRichContainerGeneralData = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.extendableRichContainerPerformance = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.extendableRichContainerZeroPerformance = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.mtopGeneralControl = new CAS.UI.UIControls.MTOP.MTOPGeneralControl();
			this.mtopPerformanceControl1 = new CAS.UI.UIControls.MTOP.MTOPPerformanceControl();
			this.mtopZeroPhasePerformanceControl = new CAS.UI.UIControls.MTOP.MTOPPerformanceControl();
			this.mtopCompliance1 = new CAS.UI.UIControls.MTOP.MTOPCompliance();
			this.mtopSummary1 = new CAS.UI.UIControls.MTOP.MTOPSummary();
			this.buttonApplyFilter = new AvControls.AvButtonT.AvButtonT();
			this.buttonApplyFilterZero = new AvControls.AvButtonT.AvButtonT();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.headerControl.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.ShowSaveButton = true;
			this.headerControl.Size = new System.Drawing.Size(1450, 58);
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
			this.headerControl.SaveButtonClick += new System.EventHandler(this.HeaderControlButtonSaveClick);
			this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 105);
			this.panel1.Size = new System.Drawing.Size(1454, 431);
			// 
			// aircraftHeaderControl1
			// 
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
			//
			// panelTopContainer
			//
			this.panelTopContainer.Controls.Add(this.labelTitle);
			this.panelTopContainer.Controls.Add(this.flowLayoutPanel2);
			this.panelTopContainer.Size = new System.Drawing.Size(1138, 62);
			// 
			// extendableRichContainerSummary
			// 
			this.extendableRichContainerSummary.AfterCaptionControl = null;
			this.extendableRichContainerSummary.AfterCaptionControl2 = null;
			this.extendableRichContainerSummary.AfterCaptionControl3 = null;
			this.extendableRichContainerSummary.AutoSize = true;
			this.extendableRichContainerSummary.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerSummary.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerSummary.Caption = "Summary";
			this.extendableRichContainerSummary.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerSummary.Condition = null;
			this.extendableRichContainerSummary.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerSummary.Extendable = true;
			this.extendableRichContainerSummary.Extended = true;
			this.extendableRichContainerSummary.Location = new System.Drawing.Point(3, 328);
			this.extendableRichContainerSummary.MainControl = null;
			this.extendableRichContainerSummary.Name = "extendableRichContainerSummary";
			this.extendableRichContainerSummary.Size = new System.Drawing.Size(192, 40);
			this.extendableRichContainerSummary.TabIndex = 7;
			this.extendableRichContainerSummary.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerSummary.Extending += new System.EventHandler(this.ExtendableRichContainerSummaryExtending);
			// 
			// extendableRichContainerGeneralData
			// 
			this.extendableRichContainerGeneralData.AfterCaptionControl = null;
			this.extendableRichContainerGeneralData.AfterCaptionControl2 = null;
			this.extendableRichContainerGeneralData.AfterCaptionControl3 = null;
			this.extendableRichContainerGeneralData.AutoSize = true;
			this.extendableRichContainerGeneralData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerGeneralData.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerGeneralData.Caption = "General Data";
			this.extendableRichContainerGeneralData.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerGeneralData.Condition = null;
			this.extendableRichContainerGeneralData.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerGeneralData.Extendable = true;
			this.extendableRichContainerGeneralData.Extended = true;
			this.extendableRichContainerGeneralData.Location = new System.Drawing.Point(3, 374);
			this.extendableRichContainerGeneralData.MainControl = null;
			this.extendableRichContainerGeneralData.Name = "extendableRichContainerGeneralData";
			this.extendableRichContainerGeneralData.Size = new System.Drawing.Size(244, 40);
			this.extendableRichContainerGeneralData.TabIndex = 7;
			this.extendableRichContainerGeneralData.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerGeneralData.Extending += new System.EventHandler(this.ExtendableRichContainerGeneralDataExtending);
			// 
			// extendableRichContainerPerformance
			// 
			this.extendableRichContainerPerformance.AfterCaptionControl = null;
			this.extendableRichContainerPerformance.AfterCaptionControl2 = null;
			this.extendableRichContainerPerformance.AfterCaptionControl3 = null;
			this.extendableRichContainerPerformance.AutoSize = true;
			this.extendableRichContainerPerformance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerPerformance.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerPerformance.Caption = "Performance";
			this.extendableRichContainerPerformance.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerPerformance.Condition = null;
			this.extendableRichContainerPerformance.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerPerformance.Extendable = true;
			this.extendableRichContainerPerformance.Extended = true;
			this.extendableRichContainerPerformance.Location = new System.Drawing.Point(3, 736);
			this.extendableRichContainerPerformance.MainControl = null;
			this.extendableRichContainerPerformance.Name = "extendableRichContainerPerformance";
			this.extendableRichContainerPerformance.Size = new System.Drawing.Size(233, 40);
			this.extendableRichContainerPerformance.TabIndex = 7;
			this.extendableRichContainerPerformance.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerPerformance.Extending += new System.EventHandler(this.ExtendableRichContainerPerformanceExtending);
			// 
			// extendableRichContainerZeroPerformance
			// 
			this.extendableRichContainerZeroPerformance.AfterCaptionControl = null;
			this.extendableRichContainerZeroPerformance.AfterCaptionControl2 = null;
			this.extendableRichContainerZeroPerformance.AfterCaptionControl3 = null;
			this.extendableRichContainerZeroPerformance.AutoSize = true;
			this.extendableRichContainerZeroPerformance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerZeroPerformance.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerZeroPerformance.Caption = "Performance For Zero Phase";
			this.extendableRichContainerZeroPerformance.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerZeroPerformance.Condition = null;
			this.extendableRichContainerZeroPerformance.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerZeroPerformance.Extendable = true;
			this.extendableRichContainerZeroPerformance.Extended = true;
			this.extendableRichContainerZeroPerformance.Location = new System.Drawing.Point(3, 736);
			this.extendableRichContainerZeroPerformance.MainControl = null;
			this.extendableRichContainerZeroPerformance.Name = "extendableRichContainerPerformance";
			this.extendableRichContainerZeroPerformance.Size = new System.Drawing.Size(233, 40);
			this.extendableRichContainerZeroPerformance.TabIndex = 7;
			this.extendableRichContainerZeroPerformance.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerZeroPerformance.Extending += new System.EventHandler(this.ExtendableRichContainerZeroPerformanceExtending);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.extendableRichContainerSummary);
			this.flowLayoutPanel1.Controls.Add(this.mtopSummary1);
			this.flowLayoutPanel1.Controls.Add(this.extendableRichContainerGeneralData);
			this.flowLayoutPanel1.Controls.Add(this.mtopGeneralControl);
			this.flowLayoutPanel1.Controls.Add(this.extendableRichContainerPerformance);
			this.flowLayoutPanel1.Controls.Add(this.mtopPerformanceControl1);
			this.flowLayoutPanel1.Controls.Add(this.extendableRichContainerZeroPerformance);
			this.flowLayoutPanel1.Controls.Add(this.mtopZeroPhasePerformanceControl);
			this.flowLayoutPanel1.Controls.Add(this.mtopCompliance1);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 105);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(1454, 431);
			this.flowLayoutPanel1.TabIndex = 1;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// buttonApplyFilter
			// 
			this.buttonApplyFilter.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonApplyFilter.ActiveBackgroundImage = null;
			this.buttonApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonApplyFilter.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonApplyFilter.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonApplyFilter.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonApplyFilter.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
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
			this.buttonApplyFilter.Size = new System.Drawing.Size(152, 57);
			this.buttonApplyFilter.TabIndex = 18;
			this.buttonApplyFilter.TextMain = "1 & Phase";
			this.buttonApplyFilter.TextSecondary = "";
			this.buttonApplyFilter.ToolTipText = "Apply filter";
			this.buttonApplyFilter.Click += ButtonApplyFilterClick;
			// 
			// // 
			// buttonApplyFilterZero
			// 
			this.buttonApplyFilterZero.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonApplyFilterZero.ActiveBackgroundImage = null;
			this.buttonApplyFilterZero.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonApplyFilterZero.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonApplyFilterZero.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonApplyFilterZero.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonApplyFilterZero.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonApplyFilterZero.Icon = global::CAS.UI.Properties.Resources.ApplyFilterIcon;
			this.buttonApplyFilterZero.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonApplyFilterZero.IconNotEnabled = null;
			this.buttonApplyFilterZero.Location = new System.Drawing.Point(0, 0);
			this.buttonApplyFilterZero.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.buttonApplyFilterZero.Name = "buttonApplyFilter";
			this.buttonApplyFilterZero.NormalBackgroundImage = null;
			this.buttonApplyFilterZero.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilterZero.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilterZero.ShowToolTip = true;
			this.buttonApplyFilterZero.Size = new System.Drawing.Size(152, 57);
			this.buttonApplyFilterZero.TabIndex = 18;
			this.buttonApplyFilterZero.TextMain = "0 & Phase";
			this.buttonApplyFilterZero.TextSecondary = "";
			this.buttonApplyFilterZero.ToolTipText = "Apply filter";
			this.buttonApplyFilterZero.Click += ButtonApplyFilterZeroClick;
			// 
			// mtopGeneralControl
			// 
			this.mtopGeneralControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mtopGeneralControl.Location = new System.Drawing.Point(3, 420);
			this.mtopGeneralControl.Name = "mtopGeneralControl";
			this.mtopGeneralControl.Size = new System.Drawing.Size(1800, 375);
			this.mtopGeneralControl.TabIndex = 2;
			// 
			// mtopPerformanceControl1
			// 
			this.mtopPerformanceControl1.Location = new System.Drawing.Point(3, 782);
			this.mtopPerformanceControl1.Name = "mtopPerformanceControl1";
			this.mtopPerformanceControl1.Size = new System.Drawing.Size(1800, 400);
			this.mtopPerformanceControl1.TabIndex = 8;
			// 
			// mtopZeroPhasePerformanceControl
			// 
			this.mtopZeroPhasePerformanceControl.Location = new System.Drawing.Point(3, 782);
			this.mtopZeroPhasePerformanceControl.Name = "mtopPerformanceControl1";
			this.mtopZeroPhasePerformanceControl.Size = new System.Drawing.Size(1800, 400);
			this.mtopZeroPhasePerformanceControl.TabIndex = 8;
			// 
			// mtopCompliance1
			// 
			this.mtopCompliance1.Displayer = null;
			this.mtopCompliance1.DisplayerText = null;
			this.mtopCompliance1.Entity = null;
			this.mtopCompliance1.Location = new System.Drawing.Point(3, 1688);
			this.mtopCompliance1.Name = "mtopCompliance1";
			this.mtopCompliance1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.mtopCompliance1.ShowContainer = true;
			this.mtopCompliance1.ShowContent = true;
			this.mtopCompliance1.Size = new System.Drawing.Size(801, 448);
			this.mtopCompliance1.TabIndex = 9;
			this.mtopCompliance1.ComplianceAdded += MtopCompliance1_ComplianceAdded;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox1.Location = new System.Drawing.Point(181, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(5, 50);
			this.pictureBox1.TabIndex = 21;
			this.pictureBox1.TabStop = false;
			// 
			// mtopSummary1
			// 
			this.mtopSummary1.Location = new System.Drawing.Point(3, 3);
			this.mtopSummary1.Name = "mtopSummary1";
			this.mtopSummary1.Size = new System.Drawing.Size(1223, 961);
			this.mtopSummary1.TabIndex = 10;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.AutoSize = true;
			this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel2.Controls.Add(this.buttonApplyFilter);
			this.flowLayoutPanel2.Controls.Add(this.pictureBox1);
			this.flowLayoutPanel2.Controls.Add(this.buttonApplyFilterZero);
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(1291, 0);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel2.Name = "flowLayoutPanel1";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(190, 62);
			this.flowLayoutPanel2.TabIndex = 3;
			this.flowLayoutPanel2.WrapContents = false;
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
			// MTOPScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "MTOPScreen";
			this.OperatorClickable = true;
			this.ShowAircraftStatusPanel = false;
			this.Size = new System.Drawing.Size(1454, 584);
			this.StatusTitle = "MTOP";
			//this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
		private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerGeneralData;
		private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerSummary;
		private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerPerformance;
		private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerZeroPerformance;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private MTOPGeneralControl mtopGeneralControl;
		private AvControls.AvButtonT.AvButtonT buttonApplyFilter;
		private AvControls.AvButtonT.AvButtonT buttonApplyFilterZero;
		private System.Windows.Forms.PictureBox pictureBox1;

		#endregion

		private MTOPPerformanceControl mtopPerformanceControl1;
		private MTOPPerformanceControl mtopZeroPhasePerformanceControl;
		private MTOPCompliance mtopCompliance1;
		private MTOPSummary mtopSummary1;
	}
}
