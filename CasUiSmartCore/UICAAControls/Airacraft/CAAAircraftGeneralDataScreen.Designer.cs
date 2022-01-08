namespace CAS.UI.UICAAControls.Airacraft
{
    partial class CAAAircraftGeneralDataScreen
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
			this.extendableRichContainerAircraft = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.aircraftControl1 = new CAAAircraftControl();
			this.extendableRichContainerPowerPlants = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.powerPlantsControl1 = new CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentEditorCollectionControl();
			this.extendableRichContainerPropellers = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.propellersControl1 = new CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentEditorCollectionControl();
			this.extendableRichContainerAPU = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.apusControl = new CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentEditorCollectionControl();
			this.extendableRichContainerPD = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.performanceDataControl1 = new CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.PerformanceDataControl();
			this.extendableRichContainerLG = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.landingGearsControl1 = new CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentEditorCollectionControl();
			this.extendableRichContainerIC = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.interiorConfigurationControl1 = new CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.InteriorConfigurationControl();
			this.extendableRichContainerOther = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanelOther = new System.Windows.Forms.FlowLayoutPanel();
			this.aircraftOtherControl1 = new CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.AircraftOtherControl();
			this.aircraftOtherControl2 = new CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.AircraftOtherControl();
			this.headerControl.SuspendLayout();
			this.panel1.SuspendLayout();
			this.flowLayoutPanelMain.SuspendLayout();
			this.flowLayoutPanelOther.SuspendLayout();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.ShowPrintButton = true;
			this.headerControl.ShowSaveButton = true;
			this.headerControl.Size = new System.Drawing.Size(1442, 58);
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControl1ReloadRised);
			this.headerControl.SaveButtonClick += new System.EventHandler(this.HeaderControlButtonSaveClick);
			this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.HeaderControlButtonPrintDisplayerRequested);
			this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.flowLayoutPanelMain);
			this.panel1.Location = new System.Drawing.Point(0, 62);
			this.panel1.Size = new System.Drawing.Size(1446, 559);
			// 
			// aircraftHeaderControl1
			// 
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
			// 
			// extendableRichContainerAircraft
			// 
			this.extendableRichContainerAircraft.AfterCaptionControl = null;
			this.extendableRichContainerAircraft.AfterCaptionControl2 = null;
			this.extendableRichContainerAircraft.AfterCaptionControl3 = null;
			this.extendableRichContainerAircraft.AutoSize = true;
			this.extendableRichContainerAircraft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerAircraft.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerAircraft.Caption = "A. Aircraft";
			this.extendableRichContainerAircraft.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerAircraft.Condition = null;
			this.extendableRichContainerAircraft.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerAircraft.Extendable = true;
			this.extendableRichContainerAircraft.Extended = true;
			this.extendableRichContainerAircraft.Location = new System.Drawing.Point(3, 3);
			this.extendableRichContainerAircraft.MainControl = null;
			this.extendableRichContainerAircraft.Name = "extendableRichContainerAircraft";
			this.extendableRichContainerAircraft.Size = new System.Drawing.Size(199, 40);
			this.extendableRichContainerAircraft.TabIndex = 1;
			this.extendableRichContainerAircraft.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerAircraft.Extending += new System.EventHandler(this.ExtendableRichContainerAircraftExtending);
			// 
			// aircraftControl1
			// 
			this.aircraftControl1.CurrentAircraft = null;
			this.aircraftControl1.Displayer = null;
			this.aircraftControl1.DisplayerText = null;
			this.aircraftControl1.Entity = null;
			this.aircraftControl1.Location = new System.Drawing.Point(3, 49);
			this.aircraftControl1.Name = "aircraftControl1";
			this.aircraftControl1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.aircraftControl1.Size = new System.Drawing.Size(962, 379);
			this.aircraftControl1.TabIndex = 0;
			// 
			// extendableRichContainerPowerPlants
			// 
			this.extendableRichContainerPowerPlants.AfterCaptionControl = null;
			this.extendableRichContainerPowerPlants.AfterCaptionControl2 = null;
			this.extendableRichContainerPowerPlants.AfterCaptionControl3 = null;
			this.extendableRichContainerPowerPlants.AutoSize = true;
			this.extendableRichContainerPowerPlants.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerPowerPlants.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerPowerPlants.Caption = "B. Power Plants";
			this.extendableRichContainerPowerPlants.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerPowerPlants.Condition = null;
			this.extendableRichContainerPowerPlants.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerPowerPlants.Extendable = true;
			this.extendableRichContainerPowerPlants.Extended = true;
			this.extendableRichContainerPowerPlants.Location = new System.Drawing.Point(3, 434);
			this.extendableRichContainerPowerPlants.MainControl = null;
			this.extendableRichContainerPowerPlants.Name = "extendableRichContainerPowerPlants";
			this.extendableRichContainerPowerPlants.Size = new System.Drawing.Size(276, 40);
			this.extendableRichContainerPowerPlants.TabIndex = 3;
			this.extendableRichContainerPowerPlants.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerPowerPlants.Extending += new System.EventHandler(this.ExtendableRichContainerPpExtending);
			// 
			// powerPlantsControl1
			// 
			this.powerPlantsControl1.AutoScroll = true;
			this.powerPlantsControl1.AutoSize = true;
			this.powerPlantsControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.powerPlantsControl1.Location = new System.Drawing.Point(3, 480);
			this.powerPlantsControl1.MinimumSize = new System.Drawing.Size(40, 50);
			this.powerPlantsControl1.Name = "powerPlantsControl1";
			this.powerPlantsControl1.Size = new System.Drawing.Size(89, 50);
			this.powerPlantsControl1.TabIndex = 2;
			this.powerPlantsControl1.Visible = false;
			// 
			// extendableRichContainerPropellers
			// 
			this.extendableRichContainerPropellers.AfterCaptionControl = null;
			this.extendableRichContainerPropellers.AfterCaptionControl2 = null;
			this.extendableRichContainerPropellers.AfterCaptionControl3 = null;
			this.extendableRichContainerPropellers.AutoSize = true;
			this.extendableRichContainerPropellers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerPropellers.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerPropellers.Caption = "B1. Propellers";
			this.extendableRichContainerPropellers.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerPropellers.Condition = null;
			this.extendableRichContainerPropellers.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerPropellers.Extendable = true;
			this.extendableRichContainerPropellers.Extended = true;
			this.extendableRichContainerPropellers.Location = new System.Drawing.Point(3, 536);
			this.extendableRichContainerPropellers.MainControl = null;
			this.extendableRichContainerPropellers.Name = "extendableRichContainerPropellers";
			this.extendableRichContainerPropellers.Size = new System.Drawing.Size(254, 40);
			this.extendableRichContainerPropellers.TabIndex = 3;
			this.extendableRichContainerPropellers.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerPropellers.Extending += new System.EventHandler(this.ExtendableRichContainerPropellersExtending);
			// 
			// propellersControl1
			// 
			this.propellersControl1.AutoScroll = true;
			this.propellersControl1.AutoSize = true;
			this.propellersControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.propellersControl1.Location = new System.Drawing.Point(3, 582);
			this.propellersControl1.MinimumSize = new System.Drawing.Size(40, 50);
			this.propellersControl1.Name = "propellersControl1";
			this.propellersControl1.Size = new System.Drawing.Size(89, 50);
			this.propellersControl1.TabIndex = 2;
			this.propellersControl1.Visible = false;
			// 
			// extendableRichContainerAPU
			// 
			this.extendableRichContainerAPU.AfterCaptionControl = null;
			this.extendableRichContainerAPU.AfterCaptionControl2 = null;
			this.extendableRichContainerAPU.AfterCaptionControl3 = null;
			this.extendableRichContainerAPU.AutoSize = true;
			this.extendableRichContainerAPU.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerAPU.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerAPU.Caption = "C. Auxilary Power Unit";
			this.extendableRichContainerAPU.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerAPU.Condition = null;
			this.extendableRichContainerAPU.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerAPU.Extendable = true;
			this.extendableRichContainerAPU.Extended = true;
			this.extendableRichContainerAPU.Location = new System.Drawing.Point(3, 638);
			this.extendableRichContainerAPU.MainControl = null;
			this.extendableRichContainerAPU.Name = "extendableRichContainerAPU";
			this.extendableRichContainerAPU.Size = new System.Drawing.Size(377, 40);
			this.extendableRichContainerAPU.TabIndex = 4;
			this.extendableRichContainerAPU.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerAPU.Extending += new System.EventHandler(this.ExtendableRichContainerApuExtending);
			// 
			// apusControl
			// 
			this.apusControl.AutoScroll = true;
			this.apusControl.AutoSize = true;
			this.apusControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.apusControl.Location = new System.Drawing.Point(3, 684);
			this.apusControl.MinimumSize = new System.Drawing.Size(40, 50);
			this.apusControl.Name = "apusControl";
			this.apusControl.Size = new System.Drawing.Size(89, 50);
			this.apusControl.TabIndex = 12;
			this.apusControl.Visible = false;
			// 
			// extendableRichContainerPD
			// 
			this.extendableRichContainerPD.AfterCaptionControl = null;
			this.extendableRichContainerPD.AfterCaptionControl2 = null;
			this.extendableRichContainerPD.AfterCaptionControl3 = null;
			this.extendableRichContainerPD.AutoSize = true;
			this.extendableRichContainerPD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerPD.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerPD.Caption = "D. Performance Data";
			this.extendableRichContainerPD.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerPD.Condition = null;
			this.extendableRichContainerPD.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerPD.Extendable = true;
			this.extendableRichContainerPD.Extended = true;
			this.extendableRichContainerPD.Location = new System.Drawing.Point(3, 740);
			this.extendableRichContainerPD.MainControl = null;
			this.extendableRichContainerPD.Name = "extendableRichContainerPD";
			this.extendableRichContainerPD.Size = new System.Drawing.Size(351, 40);
			this.extendableRichContainerPD.TabIndex = 6;
			this.extendableRichContainerPD.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerPD.Extending += new System.EventHandler(this.ExtendableRichContainerPdExtending);
			// 
			// performanceDataControl1
			// 
			this.performanceDataControl1.Aircraft = null;
			this.performanceDataControl1.Location = new System.Drawing.Point(3, 786);
			this.performanceDataControl1.Name = "performanceDataControl1";
			this.performanceDataControl1.Size = new System.Drawing.Size(994, 275);
			this.performanceDataControl1.TabIndex = 7;
			this.performanceDataControl1.Visible = false;
			// 
			// extendableRichContainerLG
			// 
			this.extendableRichContainerLG.AfterCaptionControl = null;
			this.extendableRichContainerLG.AfterCaptionControl2 = null;
			this.extendableRichContainerLG.AfterCaptionControl3 = null;
			this.extendableRichContainerLG.AutoSize = true;
			this.extendableRichContainerLG.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerLG.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerLG.Caption = "E. Landing Gears";
			this.extendableRichContainerLG.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerLG.Condition = null;
			this.extendableRichContainerLG.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerLG.Extendable = true;
			this.extendableRichContainerLG.Extended = true;
			this.extendableRichContainerLG.Location = new System.Drawing.Point(3, 1067);
			this.extendableRichContainerLG.MainControl = null;
			this.extendableRichContainerLG.Name = "extendableRichContainerLG";
			this.extendableRichContainerLG.Size = new System.Drawing.Size(298, 40);
			this.extendableRichContainerLG.TabIndex = 9;
			this.extendableRichContainerLG.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerLG.Extending += new System.EventHandler(this.ExtendableRichContainerLgExtending);
			// 
			// landingGearsControl1
			// 
			this.landingGearsControl1.AutoSize = true;
			this.landingGearsControl1.Location = new System.Drawing.Point(3, 1113);
			this.landingGearsControl1.MinimumSize = new System.Drawing.Size(40, 50);
			this.landingGearsControl1.Name = "landingGearsControl1";
			this.landingGearsControl1.Size = new System.Drawing.Size(89, 50);
			this.landingGearsControl1.TabIndex = 8;
			this.landingGearsControl1.Visible = false;
			// 
			// extendableRichContainerIC
			// 
			this.extendableRichContainerIC.AfterCaptionControl = null;
			this.extendableRichContainerIC.AfterCaptionControl2 = null;
			this.extendableRichContainerIC.AfterCaptionControl3 = null;
			this.extendableRichContainerIC.AutoSize = true;
			this.extendableRichContainerIC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerIC.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerIC.Caption = "F. Interior Configuration";
			this.extendableRichContainerIC.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerIC.Condition = null;
			this.extendableRichContainerIC.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerIC.Extendable = true;
			this.extendableRichContainerIC.Extended = true;
			this.extendableRichContainerIC.Location = new System.Drawing.Point(3, 1169);
			this.extendableRichContainerIC.MainControl = null;
			this.extendableRichContainerIC.Name = "extendableRichContainerIC";
			this.extendableRichContainerIC.Size = new System.Drawing.Size(399, 40);
			this.extendableRichContainerIC.TabIndex = 10;
			this.extendableRichContainerIC.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerIC.Extending += new System.EventHandler(this.ExtendableRichContainerIcExtending);
			// 
			// interiorConfigurationControl1
			// 
			this.interiorConfigurationControl1.Aircraft = null;
			this.interiorConfigurationControl1.Location = new System.Drawing.Point(3, 1215);
			this.interiorConfigurationControl1.Name = "interiorConfigurationControl1";
			this.interiorConfigurationControl1.Size = new System.Drawing.Size(687, 195);
			this.interiorConfigurationControl1.TabIndex = 11;
			this.interiorConfigurationControl1.Visible = false;
			// 
			// extendableRichContainerOther
			// 
			this.extendableRichContainerOther.AfterCaptionControl = null;
			this.extendableRichContainerOther.AfterCaptionControl2 = null;
			this.extendableRichContainerOther.AfterCaptionControl3 = null;
			this.extendableRichContainerOther.AutoSize = true;
			this.extendableRichContainerOther.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainerOther.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainerOther.Caption = "H. Other";
			this.extendableRichContainerOther.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainerOther.Condition = null;
			this.extendableRichContainerOther.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainerOther.Extendable = true;
			this.extendableRichContainerOther.Extended = true;
			this.extendableRichContainerOther.Location = new System.Drawing.Point(3, 1416);
			this.extendableRichContainerOther.MainControl = null;
			this.extendableRichContainerOther.Name = "extendableRichContainerOther";
			this.extendableRichContainerOther.Size = new System.Drawing.Size(176, 40);
			this.extendableRichContainerOther.TabIndex = 10;
			this.extendableRichContainerOther.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainerOther.Extending += new System.EventHandler(this.ExtendableRichContainerOtherExtending);
			// 
			// flowLayoutPanelMain
			// 
			this.flowLayoutPanelMain.AutoScroll = true;
			this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerAircraft);
			this.flowLayoutPanelMain.Controls.Add(this.aircraftControl1);
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerPowerPlants);
			this.flowLayoutPanelMain.Controls.Add(this.powerPlantsControl1);
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerPropellers);
			this.flowLayoutPanelMain.Controls.Add(this.propellersControl1);
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerAPU);
			this.flowLayoutPanelMain.Controls.Add(this.apusControl);
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerPD);
			this.flowLayoutPanelMain.Controls.Add(this.performanceDataControl1);
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerLG);
			this.flowLayoutPanelMain.Controls.Add(this.landingGearsControl1);
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerIC);
			this.flowLayoutPanelMain.Controls.Add(this.interiorConfigurationControl1);
			this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerOther);
			this.flowLayoutPanelMain.Controls.Add(this.flowLayoutPanelOther);
			this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
			this.flowLayoutPanelMain.Size = new System.Drawing.Size(1446, 559);
			this.flowLayoutPanelMain.TabIndex = 0;
			this.flowLayoutPanelMain.WrapContents = false;
			// 
			// flowLayoutPanelOther
			// 
			this.flowLayoutPanelOther.Controls.Add(this.aircraftOtherControl1);
			this.flowLayoutPanelOther.Controls.Add(this.aircraftOtherControl2);
			this.flowLayoutPanelOther.Location = new System.Drawing.Point(3, 1462);
			this.flowLayoutPanelOther.Name = "flowLayoutPanelOther";
			this.flowLayoutPanelOther.Size = new System.Drawing.Size(1136, 369);
			this.flowLayoutPanelOther.TabIndex = 13;
			this.flowLayoutPanelOther.Visible = false;
			// 
			// aircraftOtherControl1
			// 
			this.aircraftOtherControl1.AttachedObject = null;
			this.aircraftOtherControl1.ForeColor = System.Drawing.Color.Gray;
			this.aircraftOtherControl1.Location = new System.Drawing.Point(3, 3);
			this.aircraftOtherControl1.Name = "aircraftOtherControl1";
			this.aircraftOtherControl1.Size = new System.Drawing.Size(508, 353);
			this.aircraftOtherControl1.TabIndex = 15;
			this.aircraftOtherControl1.Title = "Tape of operation approval:";
			// 
			// aircraftOtherControl2
			// 
			this.aircraftOtherControl2.AttachedObject = null;
			this.aircraftOtherControl2.Location = new System.Drawing.Point(517, 3);
			this.aircraftOtherControl2.Name = "aircraftOtherControl2";
			this.aircraftOtherControl2.Size = new System.Drawing.Size(524, 353);
			this.aircraftOtherControl2.TabIndex = 16;
			this.aircraftOtherControl2.Title = "Equipment:";
			// 
			// AircraftGeneralDataScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Name = "AircraftGeneralDataScreen";
			this.OperatorClickable = true;
			this.ShowAircraftStatusPanel = false;
			this.ShowTopPanelContainer = false;
			this.Size = new System.Drawing.Size(1446, 669);
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.flowLayoutPanelMain.ResumeLayout(false);
			this.flowLayoutPanelMain.PerformLayout();
			this.flowLayoutPanelOther.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private CAAAircraftControl aircraftControl1;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerAircraft;
        private CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentEditorCollectionControl powerPlantsControl1;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerPowerPlants;
        private CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentEditorCollectionControl propellersControl1;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerPropellers;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerAPU;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerPD;
        private CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.PerformanceDataControl performanceDataControl1;
        private CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentEditorCollectionControl landingGearsControl1;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerLG;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerIC;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerOther;
        private CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.InteriorConfigurationControl interiorConfigurationControl1;
        private CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentEditorCollectionControl apusControl;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOther;
		private UIControls.AircraftsControls.AircraftGeneralDataControls.AircraftOtherControl aircraftOtherControl1;
		private UIControls.AircraftsControls.AircraftGeneralDataControls.AircraftOtherControl aircraftOtherControl2;
	}
}
