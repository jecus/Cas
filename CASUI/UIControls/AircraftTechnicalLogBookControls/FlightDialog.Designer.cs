using System.Windows.Forms;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class FlightDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightDialog));
            this.flightCrewControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FlightCrewControl();
            this.flightTimeControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FlightTimeControl();
            this.flightGeneralInformationControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FlightGeneralInformationControl();
            this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.delimiter2 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.delimiter3 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.delimiter4 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.delimiter6 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.buttonSave = new System.Windows.Forms.Button();
            this.discrepanciesListControl1 = new CAS.UI.Interfaces.DiscrepanciesListControl();
            this.delimiter7 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.engineMonitoringControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.EngineMonitoringControl();
            this.delimiter8 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.flightFluidsControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FlightFluidsControl();
            this.tirePressureControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.TirePressureControl();
            this.delimiter9 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.delimiter10 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.fuelControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FuelControl();
            this.releaseToServiceControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.ReleaseToServiceControl();
            this.delimiter11 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.componentOilListControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.ComponentOilListControl();
            this.SuspendLayout();
            // 
            // flightCrewControl1
            // 
            this.flightCrewControl1.AttachedObject = null;
            this.flightCrewControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flightCrewControl1.Location = new System.Drawing.Point(549, 46);
            this.flightCrewControl1.Name = "flightCrewControl1";
            this.flightCrewControl1.Size = new System.Drawing.Size(441, 114);
            this.flightCrewControl1.TabIndex = 2;
            // 
            // flightTimeControl1
            // 
            this.flightTimeControl1.AttachedObject = null;
            this.flightTimeControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flightTimeControl1.Location = new System.Drawing.Point(251, 46);
            this.flightTimeControl1.Name = "flightTimeControl1";
            this.flightTimeControl1.Size = new System.Drawing.Size(268, 87);
            this.flightTimeControl1.TabIndex = 1;
            // 
            // flightGeneralInformationControl1
            // 
            this.flightGeneralInformationControl1.AttachedObject = null;
            this.flightGeneralInformationControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flightGeneralInformationControl1.Location = new System.Drawing.Point(12, 46);
            this.flightGeneralInformationControl1.Name = "flightGeneralInformationControl1";
            this.flightGeneralInformationControl1.Size = new System.Drawing.Size(212, 115);
            this.flightGeneralInformationControl1.TabIndex = 0;
            // 
            // delimiter1
            // 
            this.delimiter1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
            this.delimiter1.Location = new System.Drawing.Point(12, 31);
            this.delimiter1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.delimiter1.Name = "delimiter1";
            this.delimiter1.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
            this.delimiter1.Size = new System.Drawing.Size(896, 2);
            this.delimiter1.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Solid;
            this.delimiter1.TabIndex = 5;
            // 
            // delimiter2
            // 
            this.delimiter2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter2.BackgroundImage")));
            this.delimiter2.Location = new System.Drawing.Point(237, 77);
            this.delimiter2.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.delimiter2.Name = "delimiter2";
            this.delimiter2.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
            this.delimiter2.Size = new System.Drawing.Size(1, 81);
            this.delimiter2.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter2.TabIndex = 6;
            // 
            // delimiter3
            // 
            this.delimiter3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter3.BackgroundImage")));
            this.delimiter3.Location = new System.Drawing.Point(535, 77);
            this.delimiter3.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.delimiter3.Name = "delimiter3";
            this.delimiter3.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
            this.delimiter3.Size = new System.Drawing.Size(1, 81);
            this.delimiter3.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter3.TabIndex = 7;
            // 
            // delimiter4
            // 
            this.delimiter4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.delimiter4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter4.BackgroundImage")));
            this.delimiter4.Location = new System.Drawing.Point(12, 174);
            this.delimiter4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.delimiter4.Name = "delimiter4";
            this.delimiter4.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
            this.delimiter4.Size = new System.Drawing.Size(896, 2);
            this.delimiter4.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Solid;
            this.delimiter4.TabIndex = 8;
            // 
            // delimiter6
            // 
            this.delimiter6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.delimiter6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter6.BackgroundImage")));
            this.delimiter6.Location = new System.Drawing.Point(12, 317);
            this.delimiter6.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.delimiter6.Name = "delimiter6";
            this.delimiter6.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
            this.delimiter6.Size = new System.Drawing.Size(896, 2);
            this.delimiter6.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Solid;
            this.delimiter6.TabIndex = 10;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(74, 23);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // discrepanciesListControl1
            // 
            this.discrepanciesListControl1.AttachedObject = null;
            this.discrepanciesListControl1.AutoSize = true;
            this.discrepanciesListControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discrepanciesListControl1.Location = new System.Drawing.Point(12, 544);
            this.discrepanciesListControl1.Name = "discrepanciesListControl1";
            this.discrepanciesListControl1.Size = new System.Drawing.Size(1015, 596);
            this.discrepanciesListControl1.TabIndex = 12;
            this.discrepanciesListControl1.Load += new System.EventHandler(this.discrepanciesListControl1_Load);
            // 
            // delimiter7
            // 
            this.delimiter7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter7.BackgroundImage")));
            this.delimiter7.Location = new System.Drawing.Point(328, 394);
            this.delimiter7.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.delimiter7.Name = "delimiter7";
            this.delimiter7.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
            this.delimiter7.Size = new System.Drawing.Size(1, 81);
            this.delimiter7.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter7.TabIndex = 14;
            // 
            // engineMonitoringControl1
            // 
            this.engineMonitoringControl1.AttachedObject = null;
            this.engineMonitoringControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.engineMonitoringControl1.Location = new System.Drawing.Point(569, 332);
            this.engineMonitoringControl1.Name = "engineMonitoringControl1";
            this.engineMonitoringControl1.Size = new System.Drawing.Size(367, 184);
            this.engineMonitoringControl1.TabIndex = 15;
            // 
            // delimiter8
            // 
            this.delimiter8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.delimiter8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter8.BackgroundImage")));
            this.delimiter8.Location = new System.Drawing.Point(12, 529);
            this.delimiter8.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.delimiter8.Name = "delimiter8";
            this.delimiter8.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
            this.delimiter8.Size = new System.Drawing.Size(896, 2);
            this.delimiter8.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Solid;
            this.delimiter8.TabIndex = 16;
            // 
            // flightFluidsControl1
            // 
            this.flightFluidsControl1.AttachedObject = null;
            this.flightFluidsControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flightFluidsControl1.Location = new System.Drawing.Point(12, 189);
            this.flightFluidsControl1.Name = "flightFluidsControl1";
            this.flightFluidsControl1.Size = new System.Drawing.Size(293, 114);
            this.flightFluidsControl1.TabIndex = 17;
            // 
            // tirePressureControl1
            // 
            this.tirePressureControl1.AttachedObject = null;
            this.tirePressureControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tirePressureControl1.Location = new System.Drawing.Point(328, 189);
            this.tirePressureControl1.Name = "tirePressureControl1";
            this.tirePressureControl1.Size = new System.Drawing.Size(210, 115);
            this.tirePressureControl1.TabIndex = 18;
            // 
            // delimiter9
            // 
            this.delimiter9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter9.BackgroundImage")));
            this.delimiter9.Location = new System.Drawing.Point(556, 366);
            this.delimiter9.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.delimiter9.Name = "delimiter9";
            this.delimiter9.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
            this.delimiter9.Size = new System.Drawing.Size(1, 109);
            this.delimiter9.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter9.TabIndex = 19;
            // 
            // delimiter10
            // 
            this.delimiter10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter10.BackgroundImage")));
            this.delimiter10.Location = new System.Drawing.Point(314, 220);
            this.delimiter10.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.delimiter10.Name = "delimiter10";
            this.delimiter10.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
            this.delimiter10.Size = new System.Drawing.Size(1, 81);
            this.delimiter10.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter10.TabIndex = 20;
            // 
            // fuelControl1
            // 
            this.fuelControl1.AttachedObject = null;
            this.fuelControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fuelControl1.Location = new System.Drawing.Point(12, 332);
            this.fuelControl1.Name = "fuelControl1";
            this.fuelControl1.Size = new System.Drawing.Size(520, 143);
            this.fuelControl1.TabIndex = 21;
            // 
            // releaseToServiceControl1
            // 
            this.releaseToServiceControl1.AttachedObject = null;
            this.releaseToServiceControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.releaseToServiceControl1.Location = new System.Drawing.Point(565, 189);
            this.releaseToServiceControl1.Name = "releaseToServiceControl1";
            this.releaseToServiceControl1.Size = new System.Drawing.Size(231, 84);
            this.releaseToServiceControl1.TabIndex = 22;
            // 
            // delimiter11
            // 
            this.delimiter11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter11.BackgroundImage")));
            this.delimiter11.Location = new System.Drawing.Point(551, 220);
            this.delimiter11.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.delimiter11.Name = "delimiter11";
            this.delimiter11.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
            this.delimiter11.Size = new System.Drawing.Size(1, 81);
            this.delimiter11.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter11.TabIndex = 23;
            // 
            // componentOilListControl1
            // 
            this.componentOilListControl1.AttachedObject = null;
            this.componentOilListControl1.AutoSize = true;
            this.componentOilListControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.componentOilListControl1.Location = new System.Drawing.Point(824, 189);
            this.componentOilListControl1.Name = "componentOilListControl1";
            this.componentOilListControl1.Size = new System.Drawing.Size(256, 146);
            this.componentOilListControl1.TabIndex = 24;
            // 
            // FlightDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1109, 715);
            this.Controls.Add(this.componentOilListControl1);
            this.Controls.Add(this.delimiter11);
            this.Controls.Add(this.releaseToServiceControl1);
            this.Controls.Add(this.delimiter7);
            this.Controls.Add(this.fuelControl1);
            this.Controls.Add(this.delimiter10);
            this.Controls.Add(this.delimiter9);
            this.Controls.Add(this.tirePressureControl1);
            this.Controls.Add(this.flightFluidsControl1);
            this.Controls.Add(this.delimiter8);
            this.Controls.Add(this.engineMonitoringControl1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.delimiter6);
            this.Controls.Add(this.delimiter4);
            this.Controls.Add(this.delimiter3);
            this.Controls.Add(this.delimiter2);
            this.Controls.Add(this.delimiter1);
            this.Controls.Add(this.flightGeneralInformationControl1);
            this.Controls.Add(this.flightTimeControl1);
            this.Controls.Add(this.flightCrewControl1);
            this.Controls.Add(this.discrepanciesListControl1);
            this.DoubleBuffered = true;
            this.Name = "FlightDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FlightDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlightCrewControl flightCrewControl1;
        private FlightTimeControl flightTimeControl1;
        private FlightGeneralInformationControl flightGeneralInformationControl1;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter1;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter2;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter3;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter4;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter6;
        private System.Windows.Forms.Button buttonSave;
        private CAS.UI.Interfaces.DiscrepanciesListControl discrepanciesListControl1;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter7;
        private EngineMonitoringControl engineMonitoringControl1;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter8;
        private FlightFluidsControl flightFluidsControl1;
        private TirePressureControl tirePressureControl1;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter9;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter10;
        private FuelControl fuelControl1;
        private ReleaseToServiceControl releaseToServiceControl1;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter11;
        private ComponentOilListControl componentOilListControl1;
    }
}
