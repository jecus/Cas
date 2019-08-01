using CASTerms;
using EntityCore.DTO.General;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class FlightsListScreen
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
			this.labelDateAsOf = new System.Windows.Forms.Label();
            this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
            this.buttonAddNew = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.buttonAddNewLight = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.buttonAddNewFull = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.buttonAddTripFlight = new AvControls.AvButtonT.AvButtonT();
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
            this.headerControl.ShowEditButton = true;
            this.headerControl.EditButtonShowToolTip = true;
            this.headerControl.EditButtonToolTipText = "Edit ATLB";
            this.headerControl.Size = new System.Drawing.Size(950, 58);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<Interfaces.ReferenceEventArgs>(HeaderControlButtonPrintDisplayerRequested);
            this.headerControl.ShowPrintButton = false;
            this.headerControl.ShowForecastButton = false;
            this.headerControl.EditButtonClick += new System.EventHandler(HeaderControlButtonEditClick);
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
	        this.panelTopContainer.Controls.Add(this.buttonAddTripFlight);
			this.panelTopContainer.Controls.Add(this.buttonAddNew);
			this.panelTopContainer.Controls.Add(this.buttonAddNewFull);
			this.panelTopContainer.Controls.Add(this.buttonAddNewLight);
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
            this.buttonAddNew.Location = new System.Drawing.Point(815, 0);
            this.buttonAddNew.Width = 145;
            this.buttonAddNew.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAddNew.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddNew.TextMain = "Add";
            this.buttonAddNew.TextSecondary = "Flight";
            this.buttonAddNew.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.DisplayerRequested += ButtonAddDisplayerRequested;
            this.buttonAddNew.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// buttonAddNewLight
			// 
			this.buttonAddNewLight.ActiveBackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.buttonAddNewLight.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAddNewLight.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAddNewLight.ForeColorMain = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonAddNewLight.ForeColorSecondary = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonAddNewLight.Icon = CAS.UI.Properties.Resources.AddIcon;
            this.buttonAddNewLight.IconNotEnabled = CAS.UI.Properties.Resources.AddIcon_gray;
            this.buttonAddNewLight.Location = new System.Drawing.Point(815, 0);
            this.buttonAddNewLight.Width = 145;
            this.buttonAddNewLight.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAddNewLight.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddNewLight.TextMain = "Add";
            this.buttonAddNewLight.TextSecondary = " Maint Flight";
            this.buttonAddNewLight.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAddNewLight.Name = "buttonAddNew";
            this.buttonAddNewLight.DisplayerRequested += ButtonAddLightDisplayerRequested;
            this.buttonAddNewLight.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// buttonAddNewFull
			// 
			this.buttonAddNewFull.ActiveBackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.buttonAddNewFull.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAddNewFull.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAddNewFull.ForeColorMain = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonAddNewFull.ForeColorSecondary = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonAddNewFull.Icon = CAS.UI.Properties.Resources.AddIcon;
            this.buttonAddNewFull.IconNotEnabled = CAS.UI.Properties.Resources.AddIcon_gray;
            this.buttonAddNewFull.Location = new System.Drawing.Point(815, 0);
            this.buttonAddNewFull.Width = 145;
            this.buttonAddNewFull.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAddNewFull.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddNewFull.TextMain = "Add Reg";
            this.buttonAddNewFull.TextSecondary = "Flight";
            this.buttonAddNewFull.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAddNewFull.Name = "buttonAddNew";
            this.buttonAddNewFull.DisplayerRequested += ButtonAddFullDisplayerRequested;
            this.buttonAddNewFull.Enabled = !(userType == UsetType.ReadOnly);
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
            this.buttonDeleteSelected.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// buttonAddTripFlight
			// 
			this.buttonAddTripFlight.ActiveBackColor = System.Drawing.Color.FromArgb(200, 200, 200);
	        this.buttonAddTripFlight.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
	        this.buttonAddTripFlight.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
	        this.buttonAddTripFlight.ForeColorMain = System.Drawing.Color.FromArgb(49, 82, 128);
	        this.buttonAddTripFlight.ForeColorSecondary = System.Drawing.Color.FromArgb(49, 82, 128);
	        this.buttonAddTripFlight.Click += ButtonAddTripClick;
	        this.buttonAddTripFlight.Icon = CAS.UI.Properties.Resources.AddIcon;
	        this.buttonAddTripFlight.IconNotEnabled = CAS.UI.Properties.Resources.AddIcon_gray;
	        this.buttonAddTripFlight.Location = new System.Drawing.Point(920, 0);
	        this.buttonAddTripFlight.PaddingSecondary = new System.Windows.Forms.Padding(4, 0, 0, 0);
	        this.buttonAddTripFlight.Size = new System.Drawing.Size(145, 59);
	        this.buttonAddTripFlight.Dock = System.Windows.Forms.DockStyle.Right;
	        this.buttonAddTripFlight.TabIndex = 20;
	        this.buttonAddTripFlight.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
	        this.buttonAddTripFlight.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
	        this.buttonAddTripFlight.TextMain = "Add ";
	        this.buttonAddTripFlight.TextSecondary = "Track";
	        this.buttonAddTripFlight.Enabled = !(userType == UsetType.ReadOnly);
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
        private CAS.UI.Management.Dispatchering.RichReferenceButton buttonAddNewLight;
        private CAS.UI.Management.Dispatchering.RichReferenceButton buttonAddNewFull;
        private AvControls.AvButtonT.AvButtonT buttonDeleteSelected;
        private AvControls.AvButtonT.AvButtonT buttonAddTripFlight;
        private System.Windows.Forms.Label labelDateAsOf;
    }
}
