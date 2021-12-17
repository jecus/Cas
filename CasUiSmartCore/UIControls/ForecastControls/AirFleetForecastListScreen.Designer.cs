using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UIControls.ForecastControls
{
    partial class AirFleetForecastListScreen
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
	        var userType = GlobalObjects.CasEnvironment?.IdentityUser.UserType ?? GlobalObjects.CaaEnvironment?.IdentityUser.UserType;;
			this.labelDateAsOf = new System.Windows.Forms.Label();
            this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
            this._buttonComposeWorkPackage = new AvControls.AvButtonT.AvButtonT();
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
            this.headerControl.ShowForecastButton = true;
            this.headerControl.ShowNoForecastMenuItem = false;
            this.headerControl.ShowPrintButton = true;
            this.headerControl.ForecastContextMenuClick += ForecastMenuClick;
            // 
            // aircraftHeaderControl1
            // 
            this.aircraftHeaderControl1.ChildClickable = true;
            this.aircraftHeaderControl1.OperatorClickable = true;
            this.aircraftHeaderControl1.NextClickable = true;
            this.aircraftHeaderControl1.PrevClickable = true;
            //
            // panelTopContainer
            //
            this.panelTopContainer.Controls.Add(this.labelTitle);
            this.panelTopContainer.Controls.Add(this._buttonComposeWorkPackage);
            this.panelTopContainer.Controls.Add(this.labelDateAsOf);
            this.panelTopContainer.Size = new System.Drawing.Size(1138, 62);
            
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            this.labelTitle.ForeColor = System.Drawing.Color.DimGray;
            this.labelTitle.Enabled = false;
            this.labelTitle.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.labelTitle.Location = new System.Drawing.Point(28, 3);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.Size = new System.Drawing.Size(1000, 27);
            this.labelTitle.TabIndex = 16;
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDateAsOf
            // 
            this.labelDateAsOf.AutoSize = true;
            this.labelDateAsOf.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDateAsOf.ForeColor = System.Drawing.Color.FromArgb(122, 122, 122);
            this.labelDateAsOf.Location = new System.Drawing.Point(57, 30);
            this.labelDateAsOf.Size = new System.Drawing.Size(47, 19);
            this.labelDateAsOf.TabIndex = 21;
            this.labelDateAsOf.Name = "_labelDateAsOf";
            // 
            // buttonDeleteSelected
            // 
            this._buttonComposeWorkPackage.ActiveBackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this._buttonComposeWorkPackage.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this._buttonComposeWorkPackage.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this._buttonComposeWorkPackage.ForeColorMain = System.Drawing.Color.FromArgb(49, 82, 128);
            this._buttonComposeWorkPackage.ForeColorSecondary = System.Drawing.Color.FromArgb(49, 82, 128);
            this._buttonComposeWorkPackage.Click += ButtonCreateWorkPakageClick;
            this._buttonComposeWorkPackage.Icon = CAS.UI.Properties.Resources.AddIcon;
            this._buttonComposeWorkPackage.IconNotEnabled = CAS.UI.Properties.Resources.AddIcon_gray;
            this._buttonComposeWorkPackage.Location = new System.Drawing.Point(920, 0);
            this._buttonComposeWorkPackage.PaddingSecondary = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this._buttonComposeWorkPackage.Size = new System.Drawing.Size(200, 59);
            this._buttonComposeWorkPackage.Dock = System.Windows.Forms.DockStyle.Right;
            this._buttonComposeWorkPackage.TabIndex = 20;
            this._buttonComposeWorkPackage.TextAlignMain = System.Drawing.ContentAlignment.BottomLeft;
            this._buttonComposeWorkPackage.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
            this._buttonComposeWorkPackage.TextMain = "Compose a";
            this._buttonComposeWorkPackage.TextSecondary = "work package";
            this._buttonComposeWorkPackage.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// RequestForQuotationListScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ForecastListScreen";
            this.ShowAircraftStatusPanel = false;
            this.Size = new System.Drawing.Size(917, 590);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
        private System.Windows.Forms.Label labelDateAsOf;
        private AvControls.AvButtonT.AvButtonT _buttonComposeWorkPackage;
    }
}
