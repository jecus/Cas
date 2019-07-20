using CAS.UI.UIControls.DirectivesControls;
using CASTerms;
using EntityCore.DTO.General;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class FlightScreen
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
            this.flightGeneralInformatonControl = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FlightGeneralInformatonControl();
            this.extendableRichContainerFuel = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.fuelTireOilInformationControl = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FuelTireOilInformationControl();
            this.extendableRichContainerPassengersCargo = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.passengersCargoControl = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.PassengersCargoControl();
            this.extendableRichContainerEngineRunUps = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.EngineRunupsListControl = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.PowerUnitWorkControl();
            this.extendableRichContainerEngineCondition = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.engineMonitoringListControl = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.EngineMonitoringListControl();
            this.extendableRichContainerAPURunUps = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.APURunupsListControl = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.PowerUnitWorkControl();
            this.extendableRichContainerDiscrepancies = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.discrepanciesList = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.DiscrepanciesListControl();
            this.extendableRichContainerSms = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.smsEventListControl = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FlightSmsEventListControl();
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
            this.headerControl.ShowReloadButton = true;
            this.headerControl.Size = new System.Drawing.Size(985, 58);
            this.headerControl.SaveButtonClick += new System.EventHandler(this.HeaderControlButtonSaveClick);
			this.headerControl.ReloadButtonClick += HeaderControl_ReloadButtonClick;
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
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerFuel);
            this.flowLayoutPanelMain.Controls.Add(this.fuelTireOilInformationControl);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerPassengersCargo);
            this.flowLayoutPanelMain.Controls.Add(this.passengersCargoControl);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerEngineRunUps);
            this.flowLayoutPanelMain.Controls.Add(this.EngineRunupsListControl);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerEngineCondition);
            this.flowLayoutPanelMain.Controls.Add(this.engineMonitoringListControl);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerAPURunUps);
            this.flowLayoutPanelMain.Controls.Add(this.APURunupsListControl);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerSms);
            this.flowLayoutPanelMain.Controls.Add(this.smsEventListControl);
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
            this.flightGeneralInformatonControl.OutTimeChanget += new CAS.UI.UIControls.Auxiliary.Events.DateChangedEventHandler(this.FlightTimeControlOutTimeChanget);
            this.flightGeneralInformatonControl.InTimeChanget += new CAS.UI.UIControls.Auxiliary.Events.DateChangedEventHandler(this.FlightTimeControlInTimeChanget);
            this.flightGeneralInformatonControl.TakeOffTimeChanget += new CAS.UI.UIControls.Auxiliary.Events.DateChangedEventHandler(this.FlightTimeControlTakeOffTimeChanget);
            this.flightGeneralInformatonControl.LDGTimeChanget += new CAS.UI.UIControls.Auxiliary.Events.DateChangedEventHandler(this.FlightTimeControlLDGTimeChanget);
            this.flightGeneralInformatonControl.CrewChanged += new Auxiliary.Events.CrewChangedEventHandler(FlightGeneralInformatonControlCrewChanged);
            
            // 
            // extendableRichContainerFuel
            // 
            this.extendableRichContainerFuel.AfterCaptionControl = null;
            this.extendableRichContainerFuel.AfterCaptionControl2 = null;
            this.extendableRichContainerFuel.AfterCaptionControl3 = null;
            this.extendableRichContainerFuel.AutoSize = true;
            this.extendableRichContainerFuel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerFuel.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerFuel.Caption = "Fuel, Tires, Oil";
            this.extendableRichContainerFuel.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainerFuel.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerFuel.Extendable = true;
            this.extendableRichContainerFuel.Extended = true;
            this.extendableRichContainerFuel.Location = new System.Drawing.Point(3, 310);
            this.extendableRichContainerFuel.MainControl = null;
            this.extendableRichContainerFuel.Name = "extendableRichContainerFuel";
            this.extendableRichContainerFuel.Size = new System.Drawing.Size(265, 40);
            this.extendableRichContainerFuel.TabIndex = 9;
            this.extendableRichContainerFuel.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerFuel.Extending += new System.EventHandler(this.ExtendableRichContainerGeneralExtending);
            // 
            // fuelTireOilInformationControl
            // 
            this.fuelTireOilInformationControl.Location = new System.Drawing.Point(3, 356);
            this.fuelTireOilInformationControl.Name = "fuelTireOilInformationControl";
            this.fuelTireOilInformationControl.Size = new System.Drawing.Size(1024, 503);
            this.fuelTireOilInformationControl.TabIndex = 17;
            this.fuelTireOilInformationControl.Visible = false;
            this.fuelTireOilInformationControl.OnBoardChanget += new Auxiliary.Events.ValueChangedEventHandler(fuelTireOilInformationControl_OnBoardChanget);
            this.fuelTireOilInformationControl.RemainAfterChanget += new Auxiliary.Events.ValueChangedEventHandler(FuelTireOilInformationControlRemainAfterChanget);
            this.fuelTireOilInformationControl.OilFlowChanget += new System.EventHandler(FuelTireOilInformationControlOilFlowChanget);
            
            // 
            // extendableRichContainerPassengersCargo
            // 
            this.extendableRichContainerPassengersCargo.AfterCaptionControl = null;
            this.extendableRichContainerPassengersCargo.AfterCaptionControl2 = null;
            this.extendableRichContainerPassengersCargo.AfterCaptionControl3 = null;
            this.extendableRichContainerPassengersCargo.AutoSize = true;
            this.extendableRichContainerPassengersCargo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerPassengersCargo.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerPassengersCargo.Caption = "Loading";
            this.extendableRichContainerPassengersCargo.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainerPassengersCargo.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerPassengersCargo.Extendable = true;
            this.extendableRichContainerPassengersCargo.Extended = true;
            this.extendableRichContainerPassengersCargo.Location = new System.Drawing.Point(3, 568);
            this.extendableRichContainerPassengersCargo.MainControl = null;
            this.extendableRichContainerPassengersCargo.Name = "extendableRichContainerPassengersCargo";
            this.extendableRichContainerPassengersCargo.Size = new System.Drawing.Size(280, 40);
            this.extendableRichContainerPassengersCargo.TabIndex = 11;
            this.extendableRichContainerPassengersCargo.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerPassengersCargo.Extending += new System.EventHandler(this.ExtendableRichContainerPassengersExtending);
            // 
            // passengersCargoControl
            // 
            this.passengersCargoControl.Location = new System.Drawing.Point(3, 356);
            this.passengersCargoControl.Name = "passengersCargoControl";
            this.passengersCargoControl.Size = new System.Drawing.Size(1255, 610);
            this.passengersCargoControl.TabIndex = 17;
            this.passengersCargoControl.Visible = false;
            // 
            // extendableRichContainerEngineRunUps
            // 
            this.extendableRichContainerEngineRunUps.AfterCaptionControl = null;
            this.extendableRichContainerEngineRunUps.AfterCaptionControl2 = null;
            this.extendableRichContainerEngineRunUps.AfterCaptionControl3 = null;
            this.extendableRichContainerEngineRunUps.AutoSize = true;
            this.extendableRichContainerEngineRunUps.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerEngineRunUps.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerEngineRunUps.Caption = "Engine Run-ups";
            this.extendableRichContainerEngineRunUps.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainerEngineRunUps.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerEngineRunUps.Extendable = true;
            this.extendableRichContainerEngineRunUps.Extended = true;
            this.extendableRichContainerEngineRunUps.Location = new System.Drawing.Point(3, 568);
            this.extendableRichContainerEngineRunUps.MainControl = null;
            this.extendableRichContainerEngineRunUps.Name = "extendableRichContainerEngineRunUps";
            this.extendableRichContainerEngineRunUps.Size = new System.Drawing.Size(280, 40);
            this.extendableRichContainerEngineRunUps.TabIndex = 11;
            this.extendableRichContainerEngineRunUps.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerEngineRunUps.Extending += new System.EventHandler(this.ExtendableRichContainerPerformanceExtending);
            // 
            // EngineRunupsListControl
            // 
            this.EngineRunupsListControl.AutoSize = true;
            this.EngineRunupsListControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EngineRunupsListControl.Location = new System.Drawing.Point(3, 614);
            this.EngineRunupsListControl.Name = "EngineRunupsListControl";
            this.EngineRunupsListControl.Size = new System.Drawing.Size(1006, 42);
            this.EngineRunupsListControl.TabIndex = 18;
            this.EngineRunupsListControl.Visible = false;
            this.EngineRunupsListControl.WorkTimeChanged += new System.EventHandler(this.WorkTimeChanged);
            // 
            // extendableRichContainerEngineCondition
            // 
            this.extendableRichContainerEngineCondition.AfterCaptionControl = null;
            this.extendableRichContainerEngineCondition.AfterCaptionControl2 = null;
            this.extendableRichContainerEngineCondition.AfterCaptionControl3 = null;
            this.extendableRichContainerEngineCondition.AutoSize = true;
            this.extendableRichContainerEngineCondition.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerEngineCondition.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerEngineCondition.Caption = "Engine Condition Monitoring";
            this.extendableRichContainerEngineCondition.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainerEngineCondition.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerEngineCondition.Extendable = true;
            this.extendableRichContainerEngineCondition.Extended = true;
            this.extendableRichContainerEngineCondition.Location = new System.Drawing.Point(3, 662);
            this.extendableRichContainerEngineCondition.MainControl = null;
            this.extendableRichContainerEngineCondition.Name = "extendableRichContainerEngineCondition";
            this.extendableRichContainerEngineCondition.Size = new System.Drawing.Size(460, 40);
            this.extendableRichContainerEngineCondition.TabIndex = 12;
            this.extendableRichContainerEngineCondition.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerEngineCondition.Extending += new System.EventHandler(this.ExtendableRichContainerEngineConditionExtending);
            // 
            // engineMonitoringListControl
            // 
            this.engineMonitoringListControl.AttachedObject = null;
            this.engineMonitoringListControl.AutoSize = true;
            this.engineMonitoringListControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.engineMonitoringListControl.Location = new System.Drawing.Point(3, 708);
            this.engineMonitoringListControl.Name = "engineMonitoringListControl";
            this.engineMonitoringListControl.Size = new System.Drawing.Size(1216, 211);
            this.engineMonitoringListControl.TabIndex = 20;
            this.engineMonitoringListControl.Visible = false;
            // 
            // extendableRichContainerAPURunUps
            // 
            this.extendableRichContainerAPURunUps.AfterCaptionControl = null;
            this.extendableRichContainerAPURunUps.AfterCaptionControl2 = null;
            this.extendableRichContainerAPURunUps.AfterCaptionControl3 = null;
            this.extendableRichContainerAPURunUps.AutoSize = true;
            this.extendableRichContainerAPURunUps.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerAPURunUps.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerAPURunUps.Caption = "APU Run-ups";
            this.extendableRichContainerAPURunUps.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainerAPURunUps.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerAPURunUps.Extendable = true;
            this.extendableRichContainerAPURunUps.Extended = true;
            this.extendableRichContainerAPURunUps.Location = new System.Drawing.Point(3, 925);
            this.extendableRichContainerAPURunUps.MainControl = null;
            this.extendableRichContainerAPURunUps.Name = "extendableRichContainerAPURunUps";
            this.extendableRichContainerAPURunUps.Size = new System.Drawing.Size(240, 40);
            this.extendableRichContainerAPURunUps.TabIndex = 13;
            this.extendableRichContainerAPURunUps.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerAPURunUps.Extending += new System.EventHandler(this.ExtendableRichContainerApuRunUpsExtending);
            // 
            // APURunupsListControl
            // 
            this.APURunupsListControl.AutoSize = true;
            this.APURunupsListControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.APURunupsListControl.Location = new System.Drawing.Point(3, 971);
            this.APURunupsListControl.Name = "APURunupsListControl";
            this.APURunupsListControl.Size = new System.Drawing.Size(1006, 42);
            this.APURunupsListControl.TabIndex = 19;
            this.APURunupsListControl.Visible = false;
            this.APURunupsListControl.WorkTimeChanged += new System.EventHandler(this.WorkTimeChanged);
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
            // extendableRichContainerSms
            // 
            this.extendableRichContainerSms.AfterCaptionControl = null;
            this.extendableRichContainerSms.AfterCaptionControl2 = null;
            this.extendableRichContainerSms.AfterCaptionControl3 = null;
            this.extendableRichContainerSms.AutoSize = true;
            this.extendableRichContainerSms.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerSms.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerSms.Caption = "SMS";
            this.extendableRichContainerSms.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainerSms.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerSms.Extendable = true;
            this.extendableRichContainerSms.Extended = true;
            this.extendableRichContainerSms.Location = new System.Drawing.Point(3, 1019);
            this.extendableRichContainerSms.MainControl = null;
            this.extendableRichContainerSms.Name = "extendableRichContainerSms";
            this.extendableRichContainerSms.Size = new System.Drawing.Size(253, 40);
            this.extendableRichContainerSms.TabIndex = 14;
            this.extendableRichContainerSms.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerSms.Extending += new System.EventHandler(this.ExtendableRichContainerSms);
            // 
            // smsEventListControl
            // 
            this.smsEventListControl.AttachedObject = null;
            this.smsEventListControl.AutoSize = true;
            this.smsEventListControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.smsEventListControl.Location = new System.Drawing.Point(3, 1065);
            this.smsEventListControl.Name = "smsEventListControl";
            this.smsEventListControl.Size = new System.Drawing.Size(1003, 566);
            this.smsEventListControl.TabIndex = 17;
            this.smsEventListControl.Visible = false;
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
        private ReferenceControls.ExtendableRichContainer extendableRichContainerFuel;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerPassengersCargo;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerEngineRunUps;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerEngineCondition;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerAPURunUps;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerDiscrepancies;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerSms;
        private DiscrepanciesListControl discrepanciesList;
        private FlightGeneralInformatonControl flightGeneralInformatonControl;
        private FuelTireOilInformationControl fuelTireOilInformationControl;
        private PassengersCargoControl passengersCargoControl;
        private PowerUnitWorkControl EngineRunupsListControl;
        private PowerUnitWorkControl APURunupsListControl;
        private EngineMonitoringListControl engineMonitoringListControl;
        private FlightSmsEventListControl smsEventListControl;
        private AvControls.AvButtonT.AvButtonT buttonAddAtlb;
        private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
        private System.Windows.Forms.Label labelDateAsOf;
    }
}
