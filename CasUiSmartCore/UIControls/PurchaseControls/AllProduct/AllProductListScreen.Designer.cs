using CASTerms;
using EFCore.DTO.General;

namespace CAS.UI.UIControls.PurchaseControls
{
    partial class AllProductListScreen
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
	        var userType = GlobalObjects.CasEnvironment.IdentityUser.UserType;
			this.buttonAddProduct = new AvControls.AvButtonT.AvButtonT();
			this.buttonApplyFilter = new AvControls.AvButtonT.AvButtonT();
			this.buttonDeleteSelected = new AvControls.AvButtonT.AvButtonT();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.headerControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.Size = new System.Drawing.Size(1442, 54);
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
			this.headerControl.SaveButtonClick += new System.EventHandler(this.HeaderControlSaveButtonClick);
			this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 126);
			this.panel1.Size = new System.Drawing.Size(1446, 415);
			// 
			// aircraftHeaderControl1
			// 
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
			// 
			// buttonAddProduct
			// 
			this.buttonAddProduct.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonAddProduct.ActiveBackgroundImage = null;
			this.buttonAddProduct.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonAddProduct.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddProduct.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddProduct.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonAddProduct.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonAddProduct.Icon = global::CAS.UI.Properties.Resources.AddIcon;
			this.buttonAddProduct.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonAddProduct.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
			this.buttonAddProduct.Location = new System.Drawing.Point(66, 3);
			this.buttonAddProduct.Name = "buttonAddProduct";
			this.buttonAddProduct.NormalBackgroundImage = null;
			this.buttonAddProduct.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonAddProduct.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonAddProduct.ShowToolTip = true;
			this.buttonAddProduct.Size = new System.Drawing.Size(52, 57);
			this.buttonAddProduct.TabIndex = 0;
			this.buttonAddProduct.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonAddProduct.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonAddProduct.TextMain = "";
			this.buttonAddProduct.TextSecondary = "";
			this.buttonAddProduct.ToolTipText = "Add new";
			this.buttonAddProduct.Click += new System.EventHandler(this.ButtonAddProductClick);
			this.buttonAddProduct.Enabled = !(userType == UsetType.ReadOnly);
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
			this.buttonApplyFilter.Location = new System.Drawing.Point(0, 3);
			this.buttonApplyFilter.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.buttonApplyFilter.Name = "buttonApplyFilter";
			this.buttonApplyFilter.NormalBackgroundImage = null;
			this.buttonApplyFilter.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.ShowToolTip = true;
			this.buttonApplyFilter.Size = new System.Drawing.Size(52, 57);
			this.buttonApplyFilter.TabIndex = 18;
			this.buttonApplyFilter.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonApplyFilter.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonApplyFilter.TextMain = "";
			this.buttonApplyFilter.TextSecondary = "";
			this.buttonApplyFilter.ToolTipText = "Apply filter";
			this.buttonApplyFilter.Click += new System.EventHandler(this.ButtonApplyFilterClick);
			// 
			// buttonDeleteSelected
			// 
			this.buttonDeleteSelected.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonDeleteSelected.ActiveBackgroundImage = null;
			this.buttonDeleteSelected.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonDeleteSelected.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonDeleteSelected.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonDeleteSelected.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonDeleteSelected.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonDeleteSelected.Icon = global::CAS.UI.Properties.Resources.DeleteIcon;
			this.buttonDeleteSelected.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonDeleteSelected.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIcon_gray;
			this.buttonDeleteSelected.Location = new System.Drawing.Point(135, 3);
			this.buttonDeleteSelected.Name = "buttonDeleteSelected";
			this.buttonDeleteSelected.NormalBackgroundImage = null;
			this.buttonDeleteSelected.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonDeleteSelected.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonDeleteSelected.ShowToolTip = true;
			this.buttonDeleteSelected.Size = new System.Drawing.Size(52, 57);
			this.buttonDeleteSelected.TabIndex = 20;
			this.buttonDeleteSelected.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDeleteSelected.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDeleteSelected.TextMain = "";
			this.buttonDeleteSelected.TextSecondary = "";
			this.buttonDeleteSelected.ToolTipText = "Delete selected";
			this.buttonDeleteSelected.Click += new System.EventHandler(this.ButtonDeleteClick);
			this.buttonDeleteSelected.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
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
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox2.Location = new System.Drawing.Point(55, 3);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(5, 50);
			this.pictureBox2.TabIndex = 15;
			this.pictureBox2.TabStop = false;

			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.buttonDeleteSelected);
			this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
			//this.flowLayoutPanel1.Controls.Add(this.buttonAddProduct);
			//this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
			this.flowLayoutPanel1.Controls.Add(this.buttonApplyFilter);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(1250, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(190, 62);
			this.flowLayoutPanel1.TabIndex = 3;
			this.flowLayoutPanel1.WrapContents = false;
			//
			// panelTopContainer
			//
			this.panelTopContainer.Controls.Add(this.flowLayoutPanel1);
			// 
			// AllProductListScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Name = "AllProductListScreen";
			this.OperatorClickable = true;
			this.ShowAircraftStatusPanel = false;
			this.Size = new System.Drawing.Size(1487, 634);
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private AvControls.AvButtonT.AvButtonT buttonAddProduct;
		private AvControls.AvButtonT.AvButtonT buttonApplyFilter;
		private AvControls.AvButtonT.AvButtonT buttonDeleteSelected;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		#endregion
	}
}
