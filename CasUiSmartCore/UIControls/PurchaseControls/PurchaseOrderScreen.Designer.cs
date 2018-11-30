
namespace CAS.UI.UIControls.PurchaseControls
{
    partial class PurchaseOrderScreen
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
            this.buttonClose = new AvControls.AvButtonT.AvButtonT();
            this.buttonPublish = new AvControls.AvButtonT.AvButtonT();
            this.labelStatus = new System.Windows.Forms.Label();
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
            this.headerControl.EditButtonToolTipText = "Edit Purchase Order";
            this.headerControl.Size = new System.Drawing.Size(950, 58);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<Interfaces.ReferenceEventArgs>(this.HeaderControlButtonPrintDisplayerRequested);
            this.headerControl.EditButtonClick += new System.EventHandler(HeaderControlButtonEditClick);
            //
            // panelTopContainer
            //
            this.panelTopContainer.Controls.Add(this.labelTitle);
            this.panelTopContainer.Controls.Add(this.buttonPublish);
            this.panelTopContainer.Controls.Add(this.buttonClose);
            this.panelTopContainer.Controls.Add(this.buttonDeleteSelected);
            this.panelTopContainer.Controls.Add(this.labelStatus);
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
            this.buttonDeleteSelected.TextMain = "Delete";
            this.buttonDeleteSelected.TextSecondary = "selected";
            // 
            // buttonClose
            //
            this.buttonClose.ActiveBackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.buttonClose.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonClose.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonClose.ForeColorMain = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonClose.ForeColorSecondary = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonClose.Icon = CAS.UI.Properties.Resources.CloseIcon;
            this.buttonClose.IconNotEnabled = CAS.UI.Properties.Resources.CloseIcon_gray;
            this.buttonClose.Location = new System.Drawing.Point(850, 0);
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.Width = 120;
            this.buttonClose.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClose.TextMain = "Close";
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // this.buttonPublish
            // 
            this.buttonPublish.ActiveBackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.buttonPublish.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonPublish.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonPublish.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonPublish.ForeColorMain = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonPublish.ForeColorSecondary = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonPublish.Icon = CAS.UI.Properties.Resources.AddIcon;
            this.buttonPublish.IconNotEnabled = CAS.UI.Properties.Resources.AddIcon_gray;
            this.buttonPublish.Location = new System.Drawing.Point(670, 0);
            this.buttonPublish.Width = 130;
            this.buttonPublish.TextAlignMain = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonPublish.TextMain = "Publish";
            this.buttonPublish.Name = "this.buttonPublish";
            this.buttonPublish.Click += new System.EventHandler(this.ButtonPublishClick);
            // 
            // RequestForQuotationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "RequestForQuotationScreen";
            this.ShowAircraftStatusPanel = false;
            this.Size = new System.Drawing.Size(917, 590);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
        private System.Windows.Forms.Label labelStatus;
        private AvControls.AvButtonT.AvButtonT buttonDeleteSelected;
        private AvControls.AvButtonT.AvButtonT buttonClose;
        private AvControls.AvButtonT.AvButtonT buttonPublish;
    }
}
