using CASTerms;
using EntityCore.DTO.General;

namespace CAS.UI.UIControls.PurchaseControls
{
    partial class InitionalOrderScreen
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
	        var userType = GlobalObjects.CasEnvironment.IdentityUser.UserType;
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
            this.buttonDeleteSelected = new AvControls.AvButtonT.AvButtonT();
            this.pictureBoxS1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxS2 = new System.Windows.Forms.PictureBox();
            this.buttonFilter = new AvControls.AvButtonT.AvButtonT();
            this.buttonClose = new AvControls.AvButtonT.AvButtonT();
            this.buttonPublish = new AvControls.AvButtonT.AvButtonT();
            this.labelStatus = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 129);
            this.panel1.Size = new System.Drawing.Size(917, 413);
            // 
            // headerControl
            // 
            this.headerControl.ShowPrintButton = true;
            this.headerControl.ShowEditButton = true;
            this.headerControl.EditButtonShowToolTip = true;
            this.headerControl.EditButtonToolTipText = "Edit Initional Order";
            this.headerControl.Size = new System.Drawing.Size(950, 58);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<Interfaces.ReferenceEventArgs>(this.HeaderControlButtonPrintDisplayerRequested);
            this.headerControl.EditButtonClick += new System.EventHandler(HeaderControlButtonEditClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.buttonClose);
            this.flowLayoutPanel1.Controls.Add(this.pictureBoxS1);
            this.flowLayoutPanel1.Controls.Add(this.buttonPublish);
            this.flowLayoutPanel1.Controls.Add(this.pictureBoxS2);
            this.flowLayoutPanel1.Controls.Add(this.buttonFilter);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(593, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(232, 62);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.WrapContents = false;
            //
            // panelTopContainer
            //
            this.panelTopContainer.Controls.Add(this.labelTitle);
            this.panelTopContainer.Controls.Add(this.flowLayoutPanel1);
            // 
            // aircraftHeaderControl1
            // 
            this.aircraftHeaderControl1.ChildClickable = true;
            this.aircraftHeaderControl1.OperatorClickable = true;
            this.aircraftHeaderControl1.NextClickable = true;
            this.aircraftHeaderControl1.PrevClickable = true;
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
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            this.labelStatus.ForeColor = System.Drawing.Color.DimGray;
            this.labelStatus.Location = new System.Drawing.Point(57, 30);
            this.labelStatus.Size = new System.Drawing.Size(47, 19);
            this.labelStatus.TabIndex = 21;
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Text = "Status: ";
            // 
            // buttonDeleteSelected
            // 
            this.buttonDeleteSelected.ActiveBackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.buttonDeleteSelected.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonDeleteSelected.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonDeleteSelected.ForeColorMain = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonDeleteSelected.ForeColorSecondary = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonDeleteSelected.Click += ButtonDeleteClick;
            this.buttonDeleteSelected.Icon = CAS.UI.Properties.Resources.DeleteIcon;
            this.buttonDeleteSelected.IconNotEnabled = CAS.UI.Properties.Resources.DeleteIcon_gray;
            this.buttonDeleteSelected.Location = new System.Drawing.Point(920, 0);
            this.buttonDeleteSelected.PaddingSecondary = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.buttonDeleteSelected.Size = new System.Drawing.Size(145, 59);
            this.buttonDeleteSelected.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDeleteSelected.TabIndex = 20;
            this.buttonDeleteSelected.TextAlignMain = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonDeleteSelected.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
            this.buttonDeleteSelected.TextMain = "";
            this.buttonDeleteSelected.TextSecondary = "";
            this.buttonDeleteSelected.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// buttonClose
			// 
			this.buttonClose.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.buttonClose.ActiveBackgroundImage = null;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonClose.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonClose.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonClose.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonClose.Icon = global::CAS.UI.Properties.Resources.WPPerformIcon;
            this.buttonClose.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonClose.IconNotEnabled = global::CAS.UI.Properties.Resources.WPPerformIconGray;
            this.buttonClose.Location = new System.Drawing.Point(180, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.NormalBackgroundImage = null;
            this.buttonClose.PaddingMain = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClose.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonClose.ShowToolTip = true;
            this.buttonClose.Size = new System.Drawing.Size(52, 57);
            this.buttonClose.TabIndex = 20;
            this.buttonClose.TextAlignMain = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonClose.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClose.TextMain = "";
            this.buttonClose.TextSecondary = "";
            this.buttonClose.ToolTipText = "Close";
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // buttonPublish
            // 
            this.buttonPublish.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.buttonPublish.ActiveBackgroundImage = null;
            this.buttonPublish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPublish.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonPublish.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonPublish.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonPublish.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonPublish.Icon = global::CAS.UI.Properties.Resources.WorkPackagePublishIcon;
            this.buttonPublish.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonPublish.IconNotEnabled = global::CAS.UI.Properties.Resources.WorkPackagePublishIcon_gray;
            this.buttonPublish.Location = new System.Drawing.Point(120, 0);
            this.buttonPublish.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPublish.Name = "buttonPublish";
            this.buttonPublish.NormalBackgroundImage = null;
            this.buttonPublish.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonPublish.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonPublish.ShowToolTip = true;
            this.buttonPublish.Size = new System.Drawing.Size(52, 57);
            this.buttonPublish.TabIndex = 19;
            this.buttonPublish.TextAlignMain = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonPublish.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPublish.TextMain = "";
            this.buttonPublish.TextSecondary = "";
            this.buttonPublish.ToolTipText = "Publish";
            this.buttonPublish.Click += new System.EventHandler(this.ButtonPublishClick);
            this.buttonPublish.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// buttonFilter
			// 
			this.buttonFilter.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.buttonFilter.ActiveBackgroundImage = null;
            this.buttonFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFilter.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonFilter.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonFilter.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonFilter.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonFilter.Icon = global::CAS.UI.Properties.Resources.ApplyFilterIcon;
            this.buttonFilter.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonFilter.IconNotEnabled = global::CAS.UI.Properties.Resources.AddJobIcon_gray;
            this.buttonFilter.Location = new System.Drawing.Point(0, 0);
            this.buttonFilter.Margin = new System.Windows.Forms.Padding(0);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.NormalBackgroundImage = null;
            this.buttonFilter.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonFilter.ShowToolTip = true;
            this.buttonFilter.Size = new System.Drawing.Size(52, 57);
            this.buttonFilter.TabIndex = 22;
            this.buttonFilter.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonFilter.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.buttonFilter.TextMain = "";
            this.buttonFilter.TextSecondary = "";
            this.buttonFilter.ToolTipText = "Apply Filter";
            this.buttonFilter.Click += ButtonFilter_Click;
            // 
            // pictureBoxS1
            // 
            this.pictureBoxS1.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
            this.pictureBoxS1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxS1.Location = new System.Drawing.Point(54, 3);
            this.pictureBoxS1.Name = "pictureBoxS1";
            this.pictureBoxS1.Size = new System.Drawing.Size(5, 50);
            this.pictureBoxS1.TabIndex = 15;
            this.pictureBoxS1.TabStop = false;
            // 
            // pictureBoxS2
            // 
            this.pictureBoxS2.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
            this.pictureBoxS2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxS2.Location = new System.Drawing.Point(114, 3);
            this.pictureBoxS2.Name = "pictureBoxS2";
            this.pictureBoxS2.Size = new System.Drawing.Size(5, 50);
            this.pictureBoxS2.TabIndex = 20;
            this.pictureBoxS2.TabStop = false;
            // 
            // RequestForQuotationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "InitionalOrderScreen";
            this.ShowAircraftStatusPanel = false;
            this.Size = new System.Drawing.Size(917, 590);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
        private System.Windows.Forms.Label labelStatus;
        private AvControls.AvButtonT.AvButtonT buttonDeleteSelected;
        private System.Windows.Forms.PictureBox pictureBoxS2;
        private System.Windows.Forms.PictureBox pictureBoxS1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private AvControls.AvButtonT.AvButtonT buttonFilter;
        private AvControls.AvButtonT.AvButtonT buttonClose;
        private AvControls.AvButtonT.AvButtonT buttonPublish;
    }
}
