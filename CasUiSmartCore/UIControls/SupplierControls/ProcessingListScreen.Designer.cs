namespace CAS.UI.UIControls.SupplierControls
{
	partial class ProcessingListScreen
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
			components = new System.ComponentModel.Container();
			this._buttonApplyFilter = new AvControls.AvButtonT.AvButtonT();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this._buttonTransferDetails = new AvControls.AvButtonT.AvButtonT();
			this.pictureBoxSeparatorD = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorD)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();

			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 130);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Size = new System.Drawing.Size(739, 205);
			// 
			// aircraftHeaderControl1
			// 
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this._buttonApplyFilter);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeparatorD);
			this.flowLayoutPanel1.Controls.Add(this._buttonTransferDetails);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(426, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(307, 62);
			this.flowLayoutPanel1.TabIndex = 3;
			this.flowLayoutPanel1.WrapContents = false;

			//
			// panelTopContainer
			//
			this.panelTopContainer.Controls.Add(this.flowLayoutPanel1);
			this.panelTopContainer.Size = new System.Drawing.Size(1138, 62);
			// 
			// _buttonTransferDetails
			// 
			this._buttonTransferDetails.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this._buttonTransferDetails.ActiveBackgroundImage = null;
			this._buttonTransferDetails.Cursor = System.Windows.Forms.Cursors.Hand;
			this._buttonTransferDetails.Dock = System.Windows.Forms.DockStyle.Right;
			this._buttonTransferDetails.Enabled = false;
			this._buttonTransferDetails.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this._buttonTransferDetails.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this._buttonTransferDetails.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this._buttonTransferDetails.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this._buttonTransferDetails.Icon = global::CAS.UI.Properties.Resources.TransferComponentRed;
			this._buttonTransferDetails.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this._buttonTransferDetails.IconNotEnabled = global::CAS.UI.Properties.Resources.TransferComponentGray;
			this._buttonTransferDetails.Location = new System.Drawing.Point(63, 0);
			this._buttonTransferDetails.Margin = new System.Windows.Forms.Padding(0);
			this._buttonTransferDetails.MinimumSize = new System.Drawing.Size(52, 57);
			this._buttonTransferDetails.Name = "_buttonTransferDetails";
			this._buttonTransferDetails.NormalBackgroundImage = null;
			this._buttonTransferDetails.PaddingMain = new System.Windows.Forms.Padding(0);
			this._buttonTransferDetails.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this._buttonTransferDetails.ShowToolTip = true;
			this._buttonTransferDetails.Size = new System.Drawing.Size(55, 63);
			this._buttonTransferDetails.TabIndex = 19;
			this._buttonTransferDetails.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
			this._buttonTransferDetails.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
			this._buttonTransferDetails.TextMain = "";
			this._buttonTransferDetails.TextSecondary = "";
			this._buttonTransferDetails.ToolTipText = "Transfered details";
			this._buttonTransferDetails.Click += new System.EventHandler(this.ButtonTransferedDetailsClick);

			// 
			// _buttonApplyFilter
			// 
			this._buttonApplyFilter.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this._buttonApplyFilter.ActiveBackgroundImage = null;
			this._buttonApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
			this._buttonApplyFilter.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this._buttonApplyFilter.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this._buttonApplyFilter.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this._buttonApplyFilter.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this._buttonApplyFilter.Icon = global::CAS.UI.Properties.Resources.ApplyFilterIcon;
			this._buttonApplyFilter.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this._buttonApplyFilter.IconNotEnabled = null;
			this._buttonApplyFilter.Location = new System.Drawing.Point(63, 0);
			this._buttonApplyFilter.Margin = new System.Windows.Forms.Padding(0);
			this._buttonApplyFilter.Name = "buttonApplyFilter";
			this._buttonApplyFilter.NormalBackgroundImage = null;
			this._buttonApplyFilter.PaddingMain = new System.Windows.Forms.Padding(0);
			this._buttonApplyFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this._buttonApplyFilter.ShowToolTip = true;
			this._buttonApplyFilter.Size = new System.Drawing.Size(52, 57);
			this._buttonApplyFilter.TabIndex = 18;
			this._buttonApplyFilter.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this._buttonApplyFilter.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this._buttonApplyFilter.TextMain = "";
			this._buttonApplyFilter.TextSecondary = "";
			this._buttonApplyFilter.ToolTipText = "Apply filter";
			this._buttonApplyFilter.Click += new System.EventHandler(this.ButtonApplyFilterClick);

			// 
			// pictureBoxSeparatorD
			// 
			this.pictureBoxSeparatorD.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeparatorD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeparatorD.Location = new System.Drawing.Point(247, 3);
			this.pictureBoxSeparatorD.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeparatorD.Name = "pictureBoxSeparatorD";
			this.pictureBoxSeparatorD.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeparatorD.TabIndex = 21;
			this.pictureBoxSeparatorD.TabStop = false;

			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "StoreScreen";
			this.OperatorClickable = true;
			this.ShowAircraftStatusPanel = false;
			this.Size = new System.Drawing.Size(739, 383);
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorD)).EndInit();
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private AvControls.AvButtonT.AvButtonT _buttonApplyFilter;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private AvControls.AvButtonT.AvButtonT _buttonTransferDetails;
		private System.Windows.Forms.PictureBox pictureBoxSeparatorD;
	}
}
