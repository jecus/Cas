using CASTerms;
using EFCore.DTO.General;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls.AircraftFlightLight
{
    partial class FlightScreenLight
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
			this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.extendableRichContainerSummary = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.flightGeneralInformatonControl = new FlightGeneralInformatonControlLight();
            this.extendableRichContainerDiscrepancies = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.discrepanciesList = new DiscrepanciesListControlLight();
            this.buttonAddAtlb = new AvControls.AvButtonT.AvButtonT();
            this.labelDateAsOf = new System.Windows.Forms.Label();
            this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
            
            this.panel1.SuspendLayout();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerControl
            // 
            this.headerControl.ShowPrintButton = true;
            this.headerControl.ShowSaveButton = true;
            this.headerControl.ShowReloadButton = false;
            this.headerControl.Size = new System.Drawing.Size(985, 58);
            this.headerControl.SaveButtonClick += new System.EventHandler(this.HeaderControlButtonSaveClick);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ButtonPrintDisplayerRequested);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanelMain);
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Size = new System.Drawing.Size(962, 485);
            //
            // panelTopContainer
            //
            this.panelTopContainer.Controls.Add(this.labelTitle);
            this.panelTopContainer.Controls.Add(this.buttonAddAtlb);
            this.panelTopContainer.Controls.Add(this.labelDateAsOf);
            this.panelTopContainer.Size = new System.Drawing.Size(1138, 62);
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
            this.buttonAddAtlb.ActiveBackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.buttonAddAtlb.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAddAtlb.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAddAtlb.ForeColorMain = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonAddAtlb.ForeColorSecondary = System.Drawing.Color.FromArgb(49, 82, 128);
            this.buttonAddAtlb.Click += ButtonAddAtlbClick;
            this.buttonAddAtlb.Icon = CAS.UI.Properties.Resources.AddIcon;
            this.buttonAddAtlb.IconNotEnabled = CAS.UI.Properties.Resources.AddIcon_gray;
            this.buttonAddAtlb.Location = new System.Drawing.Point(920, 0);
            this.buttonAddAtlb.PaddingSecondary = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.buttonAddAtlb.Size = new System.Drawing.Size(145, 59);
            this.buttonAddAtlb.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAddAtlb.TabIndex = 20;
            this.buttonAddAtlb.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAddAtlb.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddAtlb.TextMain = "Add new";
            this.buttonAddAtlb.TextSecondary = "ATLB";
            this.buttonAddAtlb.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// flowLayoutPanelMain
			// 
			this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerSummary);
            this.flowLayoutPanelMain.Controls.Add(this.flightGeneralInformatonControl);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerDiscrepancies);
            this.flowLayoutPanelMain.Controls.Add(this.discrepanciesList);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(962, 485);
            this.flowLayoutPanelMain.TabIndex = 0;
            this.flowLayoutPanelMain.WrapContents = false;
            // 
            // extendableRichContainerSummary
            // 
            this.extendableRichContainerSummary.AfterCaptionControl = null;
            this.extendableRichContainerSummary.AfterCaptionControl2 = null;
            this.extendableRichContainerSummary.AfterCaptionControl3 = null;
            this.extendableRichContainerSummary.AutoSize = true;
            this.extendableRichContainerSummary.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerSummary.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerSummary.Caption = "Flight General";
            this.extendableRichContainerSummary.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainerSummary.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerSummary.Extendable = true;
            this.extendableRichContainerSummary.Extended = true;
            this.extendableRichContainerSummary.Location = new System.Drawing.Point(3, 3);
            this.extendableRichContainerSummary.MainControl = null;
            this.extendableRichContainerSummary.Name = "extendableRichContainerSummary";
            this.extendableRichContainerSummary.Size = new System.Drawing.Size(257, 40);
            this.extendableRichContainerSummary.TabIndex = 7;
            this.extendableRichContainerSummary.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerSummary.Extending += new System.EventHandler(this.ExtendableRichContainerSummaryExtending);
            // 
            // flightGeneralInformatonControl
            // 
            this.flightGeneralInformatonControl.Location = new System.Drawing.Point(3, 49);
            this.flightGeneralInformatonControl.Name = "flightGeneralInformatonControl";
            this.flightGeneralInformatonControl.Size = new System.Drawing.Size(982, 375);
            this.flightGeneralInformatonControl.TabIndex = 16;
            this.flightGeneralInformatonControl.FlightDateChanget += new Auxiliary.Events.DateChangedEventHandler(this.FlightGeneralInformatonControlFlightDateChanget);
            this.flightGeneralInformatonControl.FlightStationFromChanget += new Auxiliary.Events.ValueChangedEventHandler(this.FlightGeneralInformatonControlFlightStationFromChanget);
            
            // 
            // extendableRichContainerDiscrepancies
            // 
            this.extendableRichContainerDiscrepancies.AfterCaptionControl = null;
            this.extendableRichContainerDiscrepancies.AfterCaptionControl2 = null;
            this.extendableRichContainerDiscrepancies.AfterCaptionControl3 = null;
            this.extendableRichContainerDiscrepancies.AutoSize = true;
            this.extendableRichContainerDiscrepancies.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerDiscrepancies.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerDiscrepancies.Caption = "Discrepancies";
            this.extendableRichContainerDiscrepancies.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainerDiscrepancies.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerDiscrepancies.Extendable = true;
            this.extendableRichContainerDiscrepancies.Extended = true;
            this.extendableRichContainerDiscrepancies.Location = new System.Drawing.Point(3, 1019);
            this.extendableRichContainerDiscrepancies.MainControl = null;
            this.extendableRichContainerDiscrepancies.Name = "extendableRichContainerDiscrepancies";
            this.extendableRichContainerDiscrepancies.Size = new System.Drawing.Size(253, 40);
            this.extendableRichContainerDiscrepancies.TabIndex = 14;
            this.extendableRichContainerDiscrepancies.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerDiscrepancies.Extending += new System.EventHandler(this.ExtendableRichContainerDiscrepanciesExtending);
            // 
            // discrepanciesList
            // 
            this.discrepanciesList.AttachedObject = null;
            this.discrepanciesList.AutoSize = true;
            this.discrepanciesList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.discrepanciesList.Location = new System.Drawing.Point(3, 1065);
            this.discrepanciesList.Name = "discrepanciesList";
            this.discrepanciesList.Size = new System.Drawing.Size(1015, 566);
            this.discrepanciesList.TabIndex = 15;
            this.discrepanciesList.Visible = false;
            // 
            // FlightScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FlightScreen";
            this.ShowAircraftStatusPanel = false;
            this.Size = new System.Drawing.Size(962, 597);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerSummary;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerDiscrepancies;
        private DiscrepanciesListControlLight discrepanciesList;
        private FlightGeneralInformatonControlLight flightGeneralInformatonControl;
        private AvControls.AvButtonT.AvButtonT buttonAddAtlb;
        private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
        private System.Windows.Forms.Label labelDateAsOf;
    }
}
