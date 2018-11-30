using CAS.UI.UIControls.DirectivesControls;

namespace CAS.UI.UIControls.AircraftsControls
{
    partial class AircraftSummaryScreen
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
            this.aircraftSummaryControl1 = new CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.AircraftSummaryControl();
            this.extendableRichContainerPowerPlants = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.powerPlantsControl1 = new CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentSummaryCollectionControl();
            this.extendableRichContainerPropellers = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.propellersControl1 = new CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentSummaryCollectionControl();
            this.extendableRichContainerAPU = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this._baseComponentEditorControlApu = new CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentSummary();
            this.extendableRichContainerLG = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.landingGearsControl1 = new CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentSummaryCollectionControl();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.headerControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerControl
            // 
            this.headerControl.ShowPrintButton = true;
            this.headerControl.ShowSaveButton = true;
            this.headerControl.Size = new System.Drawing.Size(985, 58);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControl1ReloadRised);
            this.headerControl.SaveButtonClick += new System.EventHandler(this.HeaderControlButtonSaveClick);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<Interfaces.ReferenceEventArgs>(HeaderControlButtonPrintDisplayerRequested);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanelMain);
            this.panel1.Size = new System.Drawing.Size(973, 478);
            // 
            // aircraftHeaderControl1
            // 
            this.aircraftHeaderControl1.ChildClickable = true;
            this.aircraftHeaderControl1.OperatorClickable = true;
            this.aircraftHeaderControl1.NextClickable = true;
            this.aircraftHeaderControl1.PrevClickable = true;
            // 
            // statusControl
            // 
            this.statusControl.MinimumSize = new System.Drawing.Size(1000, 35);
            this.statusControl.Size = new System.Drawing.Size(1000, 35);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerAircraft);
            this.flowLayoutPanelMain.Controls.Add(this.aircraftSummaryControl1);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerPowerPlants);
            this.flowLayoutPanelMain.Controls.Add(this.powerPlantsControl1);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerPropellers);
            this.flowLayoutPanelMain.Controls.Add(this.propellersControl1);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerAPU);
            this.flowLayoutPanelMain.Controls.Add(this._baseComponentEditorControlApu);
            this.flowLayoutPanelMain.Controls.Add(this.extendableRichContainerLG);
            this.flowLayoutPanelMain.Controls.Add(this.landingGearsControl1);
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(973, 478);
            this.flowLayoutPanelMain.TabIndex = 0;
            this.flowLayoutPanelMain.WrapContents = false;
            // 
            // extendableRichContainerAircraft
            // 
            this.extendableRichContainerAircraft.AfterCaptionControl = null;
            this.extendableRichContainerAircraft.AfterCaptionControl2 = null;
            this.extendableRichContainerAircraft.AfterCaptionControl3 = null;
            this.extendableRichContainerAircraft.AutoSize = true;
            this.extendableRichContainerAircraft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerAircraft.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerAircraft.Caption = "Aircraft";
            this.extendableRichContainerAircraft.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerAircraft.Extendable = true;
            this.extendableRichContainerAircraft.Extended = true;
            this.extendableRichContainerAircraft.Location = new System.Drawing.Point(3, 3);
            this.extendableRichContainerAircraft.MainControl = null;
            this.extendableRichContainerAircraft.Name = "extendableRichContainerAircraft";
            this.extendableRichContainerAircraft.Size = new System.Drawing.Size(207, 40);
            this.extendableRichContainerAircraft.TabIndex = 1;
            this.extendableRichContainerAircraft.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerAircraft.Extending += new System.EventHandler(this.ExtendableRichContainerAircraftExtending);
            // 
            // aircraftControl1
            // 
            this.aircraftSummaryControl1.Displayer = null;
            this.aircraftSummaryControl1.DisplayerText = null;
            this.aircraftSummaryControl1.Entity = null;
            this.aircraftSummaryControl1.Location = new System.Drawing.Point(3, 49);
            this.aircraftSummaryControl1.Name = "aircraftSummaryControl1";
            this.aircraftSummaryControl1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.aircraftSummaryControl1.Size = new System.Drawing.Size(962, 379);
            this.aircraftSummaryControl1.TabIndex = 0;
            // 
            // extendableRichContainerPowerPlants
            // 
            this.extendableRichContainerPowerPlants.AfterCaptionControl = null;
            this.extendableRichContainerPowerPlants.AfterCaptionControl2 = null;
            this.extendableRichContainerPowerPlants.AfterCaptionControl3 = null;
            this.extendableRichContainerPowerPlants.AutoSize = true;
            this.extendableRichContainerPowerPlants.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerPowerPlants.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerPowerPlants.Caption = "Power Plants";
            this.extendableRichContainerPowerPlants.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerPowerPlants.Extendable = true;
            this.extendableRichContainerPowerPlants.Extended = true;
            this.extendableRichContainerPowerPlants.Location = new System.Drawing.Point(3, 392);
            this.extendableRichContainerPowerPlants.MainControl = null;
            this.extendableRichContainerPowerPlants.Name = "extendableRichContainerPowerPlants";
            this.extendableRichContainerPowerPlants.Size = new System.Drawing.Size(285, 40);
            this.extendableRichContainerPowerPlants.TabIndex = 3;
            this.extendableRichContainerPowerPlants.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerPowerPlants.Extending += new System.EventHandler(this.ExtendableRichContainerPpExtending);
            // 
            // powerPlantsControl1
            // 
            this.powerPlantsControl1.AutoScroll = true;
            this.powerPlantsControl1.AutoSize = true;
            this.powerPlantsControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.powerPlantsControl1.Location = new System.Drawing.Point(3, 438);
            this.powerPlantsControl1.Name = "powerPlantsControl1";
            this.powerPlantsControl1.Size = new System.Drawing.Size(0, 0);
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
            this.extendableRichContainerPropellers.Caption = "Propellers";
            this.extendableRichContainerPropellers.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerPropellers.Extendable = true;
            this.extendableRichContainerPropellers.Extended = true;
            this.extendableRichContainerPropellers.Location = new System.Drawing.Point(3, 392);
            this.extendableRichContainerPropellers.MainControl = null;
            this.extendableRichContainerPropellers.Name = "extendableRichContainerPropellers";
            this.extendableRichContainerPropellers.Size = new System.Drawing.Size(285, 40);
            this.extendableRichContainerPropellers.TabIndex = 3;
            this.extendableRichContainerPropellers.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerPropellers.Extending += new System.EventHandler(this.ExtendableRichContainerPropellersExtending);
            // 
            // propellersControl1
            // 
            this.propellersControl1.AutoScroll = true;
            this.propellersControl1.AutoSize = true;
            this.propellersControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.propellersControl1.Location = new System.Drawing.Point(3, 438);
            this.propellersControl1.Name = "propellersControl1";
            this.propellersControl1.Size = new System.Drawing.Size(0, 0);
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
            this.extendableRichContainerAPU.Caption = "Auxilary Power Unit";
            this.extendableRichContainerAPU.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerAPU.Extendable = true;
            this.extendableRichContainerAPU.Extended = true;
            this.extendableRichContainerAPU.Location = new System.Drawing.Point(3, 444);
            this.extendableRichContainerAPU.MainControl = null;
            this.extendableRichContainerAPU.Name = "extendableRichContainerAPU";
            this.extendableRichContainerAPU.Size = new System.Drawing.Size(386, 40);
            this.extendableRichContainerAPU.TabIndex = 4;
            this.extendableRichContainerAPU.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerAPU.Extending += new System.EventHandler(this.ExtendableRichContainerApuExtending);
            // 
            // baseDetailEditorControlAPU
            // 
            this._baseComponentEditorControlApu.EnableExtendedControl = false;
            this._baseComponentEditorControlApu.CurrentComponent = null;
            this._baseComponentEditorControlApu.Location = new System.Drawing.Point(3, 490);
            this._baseComponentEditorControlApu.Name = "_baseComponentEditorControlApu";
            this._baseComponentEditorControlApu.Size = new System.Drawing.Size(393, 746);
            this._baseComponentEditorControlApu.TabIndex = 12;
            this._baseComponentEditorControlApu.Visible = false;
            // 
            // extendableRichContainerLG
            // 
            this.extendableRichContainerLG.AfterCaptionControl = null;
            this.extendableRichContainerLG.AfterCaptionControl2 = null;
            this.extendableRichContainerLG.AfterCaptionControl3 = null;
            this.extendableRichContainerLG.AutoSize = true;
            this.extendableRichContainerLG.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerLG.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerLG.Caption = "Landing Gears";
            this.extendableRichContainerLG.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerLG.Extendable = true;
            this.extendableRichContainerLG.Extended = true;
            this.extendableRichContainerLG.Location = new System.Drawing.Point(3, 1497);
            this.extendableRichContainerLG.MainControl = null;
            this.extendableRichContainerLG.Name = "extendableRichContainerLG";
            this.extendableRichContainerLG.Size = new System.Drawing.Size(306, 40);
            this.extendableRichContainerLG.TabIndex = 9;
            this.extendableRichContainerLG.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainerLG.Extending += new System.EventHandler(this.ExtendableRichContainerLgExtending);
            // 
            // landingGearsControl1
            // 
            this.landingGearsControl1.AutoSize = true;
            this.landingGearsControl1.Location = new System.Drawing.Point(3, 1543);
            this.landingGearsControl1.Name = "landingGearsControl1";
            this.landingGearsControl1.Size = new System.Drawing.Size(203, 103);
            this.landingGearsControl1.TabIndex = 8;
            this.landingGearsControl1.Visible = false;
            // 
            // DirectiveAddingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ShowTopPanelContainer = false;
            this.Name = "AircraftSummaryScreen";
            this.ShowAircraftStatusPanel = false;
            this.Size = new System.Drawing.Size(973, 621);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.headerControl.ResumeLayout(false);
            this.headerControl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.AircraftSummaryControl aircraftSummaryControl1;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerAircraft;
        private CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentSummaryCollectionControl powerPlantsControl1;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerPowerPlants;
        private CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentSummaryCollectionControl propellersControl1;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerPropellers;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerAPU;
        private CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentSummaryCollectionControl landingGearsControl1;
        private CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainerLG;
        private CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls.BaseComponentSummary _baseComponentEditorControlApu;
    }
}
