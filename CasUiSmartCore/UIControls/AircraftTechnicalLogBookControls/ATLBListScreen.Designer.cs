using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class ATLBListScreen
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
            this.buttonAddNew = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.buttonDeleteSelected = new AvControls.AvButtonT.AvButtonT();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 129);
            this.panel1.Size = new System.Drawing.Size(917, 413);
            // 
            // headerControl
            // 
            this.headerControl.Size = new System.Drawing.Size(985, 58);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<Interfaces.ReferenceEventArgs>(HeaderControlButtonPrintDisplayerRequested);
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
            // panelTopContainer
            //
            this.panelTopContainer.Controls.Add(this.labelTitle);
            this.panelTopContainer.Controls.Add(this.buttonAddNew);
            this.panelTopContainer.Controls.Add(this.buttonDeleteSelected);
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
            this.labelTitle.Size = new System.Drawing.Size(600, 27);
            this.labelTitle.TabIndex = 16;
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonAddNew
            // 
            this.buttonAddNew.ActiveBackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.buttonAddNew.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAddNew.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAddNew.ForeColorMain = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonAddNew.ForeColorSecondary = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonAddNew.Icon = CAS.UI.Properties.Resources.AddIcon;
            this.buttonAddNew.IconNotEnabled = CAS.UI.Properties.Resources.AddIcon_gray;
            this.buttonAddNew.Location = new System.Drawing.Point(845, 0);
            this.buttonAddNew.Width = 115;
            this.buttonAddNew.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAddNew.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddNew.TextMain = "Add";
            this.buttonAddNew.TextSecondary = "New";
            this.buttonAddNew.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.DisplayerRequested += ButtonAddDisplayerRequested;
            this.buttonAddNew.Enabled = !(userType == UserType.ReadOnly);
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
            this.buttonDeleteSelected.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDeleteSelected.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDeleteSelected.TextMain = "Delete";
            this.buttonDeleteSelected.TextSecondary = "selected";
            this.buttonDeleteSelected.Enabled = !(userType == UserType.ReadOnly || userType == UserType.SaveOnly);
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
            // RequestForQuotationListScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "RequestForQuotationListScreen";
            this.ShowAircraftStatusPanel = false;
            this.Size = new System.Drawing.Size(917, 590);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
        private CAS.UI.Management.Dispatchering.RichReferenceButton buttonAddNew;
        private AvControls.AvButtonT.AvButtonT buttonDeleteSelected;
        private System.Windows.Forms.Label labelDateAsOf;
    }
}
