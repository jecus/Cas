
namespace CAS.UI.UIControls.PurchaseControls
{
    partial class PurchaseOrderListScreen
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
            this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
            this.buttonDeleteSelected = new AvControls.AvButtonT.AvButtonT();
            this.buttonReleaseToService = new AvControls.AvButtonT.AvButtonT();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 129);
            this.panel1.Size = new System.Drawing.Size(917, 413);
            // 
            // headerControl
            // 
            this.headerControl.Size = new System.Drawing.Size(950, 58);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<Interfaces.ReferenceEventArgs>(this.HeaderControlButtonPrintDisplayerRequested);
            //
            // panelTopContainer
            //
            this.panelTopContainer.Controls.Add(this.labelTitle);
            this.panelTopContainer.Controls.Add(this.buttonReleaseToService);
            this.panelTopContainer.Controls.Add(this.buttonDeleteSelected);
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
            this.buttonDeleteSelected.TextMain = "Delete";
            this.buttonDeleteSelected.TextSecondary = "selected";
            // 
            // buttonComposeWorkPackage
            // 
            this.buttonReleaseToService.ActiveBackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.buttonReleaseToService.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonReleaseToService.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonReleaseToService.ForeColorMain = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonReleaseToService.ForeColorSecondary = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonReleaseToService.Icon = CAS.UI.Properties.Resources.PrintIcon;
            this.buttonReleaseToService.IconNotEnabled = CAS.UI.Properties.Resources.PrintIcon_gray;
            this.buttonReleaseToService.Location = new System.Drawing.Point(700, 0);
            this.buttonReleaseToService.Width = 200;
            this.buttonReleaseToService.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonReleaseToService.TabIndex = 19;
            this.buttonReleaseToService.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonReleaseToService.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.buttonReleaseToService.TextMain = "Preview";
            this.buttonReleaseToService.TextSecondary = "Purchase order";
            this.buttonReleaseToService.Enabled = false;
            this.buttonReleaseToService.Click += ButtonReleaseToServiceClick;
            this.buttonReleaseToService.Name = "buttonReleaseToService";
            // 
            // RequestForQuotationListScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "PurchaseOrderListScreen";
            this.ShowAircraftStatusPanel = false;
            this.Size = new System.Drawing.Size(917, 590);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
        private AvControls.AvButtonT.AvButtonT buttonDeleteSelected;
        private AvControls.AvButtonT.AvButtonT buttonReleaseToService;
    }
}
