using CAS.UI.Helpers;

namespace CAS.UI.UIControls.ScheduleControls
{
	partial class FlightNumberIPerformanceControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightNumberIPerformanceControl));
			this.numericUpDownDistance = new System.Windows.Forms.NumericUpDown();
			this.labelDistance = new System.Windows.Forms.Label();
			this.labelMinLevel = new System.Windows.Forms.Label();
			this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
			this.labelMeasure = new System.Windows.Forms.Label();
			this.numericUpDownFuelRemainAfter = new System.Windows.Forms.NumericUpDown();
			this.labelMinFuelRemainAfter = new System.Windows.Forms.Label();
			this.labelPayLoad = new System.Windows.Forms.Label();
			this.numericUpDownPayload = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownPassengers = new System.Windows.Forms.NumericUpDown();
			this.labelPassengers = new System.Windows.Forms.Label();
			this.numericUpDownTakeOffWeight = new System.Windows.Forms.NumericUpDown();
			this.labelTakeOffWeight = new System.Windows.Forms.Label();
			this.numericUpDownFuel = new System.Windows.Forms.NumericUpDown();
			this.labelMaxFuel = new System.Windows.Forms.Label();
			this.numericUpDownCargo = new System.Windows.Forms.NumericUpDown();
			this.labelCargo = new System.Windows.Forms.Label();
			this.numericUpDownMaxLandWeight = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.delimiter5 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.labelCrew = new System.Windows.Forms.Label();
			this.dataGridViewCrew = new CAS.UI.UIControls.Auxiliary.CommonDataGridViewControl();
			this.delimiter4 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter3 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.labelAlternateAirPorts = new System.Windows.Forms.Label();
			this.dataGridViewAirports = new CAS.UI.UIControls.Auxiliary.CommonDataGridViewControl();
			this.labelApprovedModels = new System.Windows.Forms.Label();
			this.dataGridViewAircraftModels = new CAS.UI.UIControls.Auxiliary.CommonDataGridViewControl();
			this.dictComboBoxMinLevel = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelRemainAfter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPayload)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPassengers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTakeOffWeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCargo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLandWeight)).BeginInit();
			this.SuspendLayout();
			// 
			// numericUpDownDistance
			// 
			this.numericUpDownDistance.Location = new System.Drawing.Point(72, 3);
			this.numericUpDownDistance.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.numericUpDownDistance.Maximum = new decimal(new int[] {
			10000000,
			0,
			0,
			0});
			this.numericUpDownDistance.Name = "numericUpDownDistance";
			this.numericUpDownDistance.Size = new System.Drawing.Size(194, 20);
			this.numericUpDownDistance.TabIndex = 80;
			this.numericUpDownDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelDistance
			// 
			this.labelDistance.AutoSize = true;
			this.labelDistance.Location = new System.Drawing.Point(5, 5);
			this.labelDistance.Name = "labelDistance";
			this.labelDistance.Size = new System.Drawing.Size(49, 13);
			this.labelDistance.TabIndex = 81;
			this.labelDistance.Text = "Distance";
			// 
			// labelMinLevel
			// 
			this.labelMinLevel.AutoSize = true;
			this.labelMinLevel.Location = new System.Drawing.Point(5, 53);
			this.labelMinLevel.Name = "labelMinLevel";
			this.labelMinLevel.Size = new System.Drawing.Size(56, 13);
			this.labelMinLevel.TabIndex = 84;
			this.labelMinLevel.Text = "Min. Level";
			// 
			// comboBoxMeasure
			// 
			this.comboBoxMeasure.FormattingEnabled = true;
			this.comboBoxMeasure.Location = new System.Drawing.Point(72, 26);
			this.comboBoxMeasure.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.comboBoxMeasure.Name = "comboBoxMeasure";
			this.comboBoxMeasure.Size = new System.Drawing.Size(193, 21);
			this.comboBoxMeasure.TabIndex = 82;
			this.comboBoxMeasure.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelMeasure
			// 
			this.labelMeasure.AutoSize = true;
			this.labelMeasure.Location = new System.Drawing.Point(5, 29);
			this.labelMeasure.Name = "labelMeasure";
			this.labelMeasure.Size = new System.Drawing.Size(48, 13);
			this.labelMeasure.TabIndex = 83;
			this.labelMeasure.Text = "Measure";
			// 
			// numericUpDownFuelRemainAfter
			// 
			this.numericUpDownFuelRemainAfter.DecimalPlaces = 2;
			this.numericUpDownFuelRemainAfter.Location = new System.Drawing.Point(420, 26);
			this.numericUpDownFuelRemainAfter.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.numericUpDownFuelRemainAfter.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownFuelRemainAfter.Name = "numericUpDownFuelRemainAfter";
			this.numericUpDownFuelRemainAfter.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownFuelRemainAfter.TabIndex = 129;
			this.numericUpDownFuelRemainAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelMinFuelRemainAfter
			// 
			this.labelMinFuelRemainAfter.AutoSize = true;
			this.labelMinFuelRemainAfter.Location = new System.Drawing.Point(285, 28);
			this.labelMinFuelRemainAfter.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelMinFuelRemainAfter.Name = "labelMinFuelRemainAfter";
			this.labelMinFuelRemainAfter.Size = new System.Drawing.Size(129, 13);
			this.labelMinFuelRemainAfter.TabIndex = 130;
			this.labelMinFuelRemainAfter.Text = "Min. Fuel remain after. KG";
			// 
			// labelPayLoad
			// 
			this.labelPayLoad.AutoSize = true;
			this.labelPayLoad.Location = new System.Drawing.Point(285, 100);
			this.labelPayLoad.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelPayLoad.Name = "labelPayLoad";
			this.labelPayLoad.Size = new System.Drawing.Size(66, 13);
			this.labelPayLoad.TabIndex = 128;
			this.labelPayLoad.Text = "Payload. KG";
			// 
			// numericUpDownPayload
			// 
			this.numericUpDownPayload.DecimalPlaces = 2;
			this.numericUpDownPayload.Location = new System.Drawing.Point(420, 98);
			this.numericUpDownPayload.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.numericUpDownPayload.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownPayload.Name = "numericUpDownPayload";
			this.numericUpDownPayload.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownPayload.TabIndex = 127;
			this.numericUpDownPayload.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// numericUpDownPassengers
			// 
			this.numericUpDownPassengers.Location = new System.Drawing.Point(420, 51);
			this.numericUpDownPassengers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.numericUpDownPassengers.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			this.numericUpDownPassengers.Name = "numericUpDownPassengers";
			this.numericUpDownPassengers.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownPassengers.TabIndex = 125;
			this.numericUpDownPassengers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelPassengers
			// 
			this.labelPassengers.AutoSize = true;
			this.labelPassengers.Location = new System.Drawing.Point(285, 53);
			this.labelPassengers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelPassengers.Name = "labelPassengers";
			this.labelPassengers.Size = new System.Drawing.Size(62, 13);
			this.labelPassengers.TabIndex = 126;
			this.labelPassengers.Text = "Passengers";
			// 
			// numericUpDownTakeOffWeight
			// 
			this.numericUpDownTakeOffWeight.DecimalPlaces = 2;
			this.numericUpDownTakeOffWeight.Location = new System.Drawing.Point(420, 122);
			this.numericUpDownTakeOffWeight.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.numericUpDownTakeOffWeight.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownTakeOffWeight.Name = "numericUpDownTakeOffWeight";
			this.numericUpDownTakeOffWeight.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownTakeOffWeight.TabIndex = 121;
			this.numericUpDownTakeOffWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelTakeOffWeight
			// 
			this.labelTakeOffWeight.AutoSize = true;
			this.labelTakeOffWeight.Location = new System.Drawing.Point(285, 124);
			this.labelTakeOffWeight.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelTakeOffWeight.Name = "labelTakeOffWeight";
			this.labelTakeOffWeight.Size = new System.Drawing.Size(107, 13);
			this.labelTakeOffWeight.TabIndex = 124;
			this.labelTakeOffWeight.Text = "Take Off Weight. KG";
			// 
			// numericUpDownFuel
			// 
			this.numericUpDownFuel.DecimalPlaces = 2;
			this.numericUpDownFuel.Location = new System.Drawing.Point(420, 2);
			this.numericUpDownFuel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.numericUpDownFuel.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownFuel.Name = "numericUpDownFuel";
			this.numericUpDownFuel.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownFuel.TabIndex = 120;
			this.numericUpDownFuel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelMaxFuel
			// 
			this.labelMaxFuel.AutoSize = true;
			this.labelMaxFuel.Location = new System.Drawing.Point(288, 5);
			this.labelMaxFuel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelMaxFuel.Name = "labelMaxFuel";
			this.labelMaxFuel.Size = new System.Drawing.Size(68, 13);
			this.labelMaxFuel.TabIndex = 123;
			this.labelMaxFuel.Text = "Min. Fuel KG";
			// 
			// numericUpDownCargo
			// 
			this.numericUpDownCargo.DecimalPlaces = 2;
			this.numericUpDownCargo.Location = new System.Drawing.Point(420, 74);
			this.numericUpDownCargo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.numericUpDownCargo.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownCargo.Name = "numericUpDownCargo";
			this.numericUpDownCargo.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownCargo.TabIndex = 119;
			this.numericUpDownCargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelCargo
			// 
			this.labelCargo.AutoSize = true;
			this.labelCargo.Location = new System.Drawing.Point(285, 76);
			this.labelCargo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelCargo.Name = "labelCargo";
			this.labelCargo.Size = new System.Drawing.Size(56, 13);
			this.labelCargo.TabIndex = 122;
			this.labelCargo.Text = "Cargo. KG";
			// 
			// numericUpDownMaxLandWeight
			// 
			this.numericUpDownMaxLandWeight.DecimalPlaces = 2;
			this.numericUpDownMaxLandWeight.Location = new System.Drawing.Point(420, 145);
			this.numericUpDownMaxLandWeight.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.numericUpDownMaxLandWeight.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownMaxLandWeight.Name = "numericUpDownMaxLandWeight";
			this.numericUpDownMaxLandWeight.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownMaxLandWeight.TabIndex = 131;
			this.numericUpDownMaxLandWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(285, 147);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 13);
			this.label1.TabIndex = 132;
			this.label1.Text = "Max Land Weight. KG";
			// 
			// delimiter5
			// 
			this.delimiter5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter5.BackgroundImage")));
			this.delimiter5.Location = new System.Drawing.Point(279, 5);
			this.delimiter5.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter5.Name = "delimiter5";
			this.delimiter5.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter5.Size = new System.Drawing.Size(1, 167);
			this.delimiter5.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter5.TabIndex = 133;
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(8, 172);
			this.delimiter1.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter1.Size = new System.Drawing.Size(967, 1);
			this.delimiter1.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter1.TabIndex = 134;
			// 
			// labelCrew
			// 
			this.labelCrew.AutoSize = true;
			this.labelCrew.Location = new System.Drawing.Point(580, 177);
			this.labelCrew.Name = "labelCrew";
			this.labelCrew.Size = new System.Drawing.Size(31, 13);
			this.labelCrew.TabIndex = 143;
			this.labelCrew.Text = "Crew";
			// 
			// dataGridViewCrew
			// 
			this.dataGridViewCrew.CanOpenEditFormOnDoubleClick = false;
			this.dataGridViewCrew.Displayer = null;
			this.dataGridViewCrew.DisplayerText = null;
			this.dataGridViewCrew.Entity = null;
			this.dataGridViewCrew.Location = new System.Drawing.Point(583, 202);
			this.dataGridViewCrew.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.dataGridViewCrew.Name = "dataGridViewCrew";
			this.dataGridViewCrew.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dataGridViewCrew.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
			this.dataGridViewCrew.ShowQuickSearch = false;
			this.dataGridViewCrew.Size = new System.Drawing.Size(401, 150);
			this.dataGridViewCrew.TabIndex = 142;
			// 
			// delimiter4
			// 
			this.delimiter4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter4.BackgroundImage")));
			this.delimiter4.Location = new System.Drawing.Point(574, 172);
			this.delimiter4.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter4.Name = "delimiter4";
			this.delimiter4.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter4.Size = new System.Drawing.Size(1, 180);
			this.delimiter4.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter4.TabIndex = 141;
			// 
			// delimiter3
			// 
			this.delimiter3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter3.BackgroundImage")));
			this.delimiter3.Location = new System.Drawing.Point(280, 171);
			this.delimiter3.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter3.Name = "delimiter3";
			this.delimiter3.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter3.Size = new System.Drawing.Size(1, 181);
			this.delimiter3.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter3.TabIndex = 140;
			// 
			// labelAlternateAirPorts
			// 
			this.labelAlternateAirPorts.AutoSize = true;
			this.labelAlternateAirPorts.Location = new System.Drawing.Point(5, 177);
			this.labelAlternateAirPorts.Name = "labelAlternateAirPorts";
			this.labelAlternateAirPorts.Size = new System.Drawing.Size(87, 13);
			this.labelAlternateAirPorts.TabIndex = 139;
			this.labelAlternateAirPorts.Text = "Alternate Airports";
			// 
			// dataGridViewAirports
			// 
			this.dataGridViewAirports.CanOpenEditFormOnDoubleClick = false;
			this.dataGridViewAirports.Displayer = null;
			this.dataGridViewAirports.DisplayerText = null;
			this.dataGridViewAirports.Entity = null;
			this.dataGridViewAirports.Location = new System.Drawing.Point(9, 202);
			this.dataGridViewAirports.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.dataGridViewAirports.Name = "dataGridViewAirports";
			this.dataGridViewAirports.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dataGridViewAirports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
			this.dataGridViewAirports.ShowQuickSearch = false;
			this.dataGridViewAirports.Size = new System.Drawing.Size(257, 150);
			this.dataGridViewAirports.TabIndex = 138;
			// 
			// labelApprovedModels
			// 
			this.labelApprovedModels.AutoSize = true;
			this.labelApprovedModels.Location = new System.Drawing.Point(288, 177);
			this.labelApprovedModels.Name = "labelApprovedModels";
			this.labelApprovedModels.Size = new System.Drawing.Size(126, 13);
			this.labelApprovedModels.TabIndex = 137;
			this.labelApprovedModels.Text = "Approved Aircraft Models";
			// 
			// dataGridViewAircraftModels
			// 
			this.dataGridViewAircraftModels.CanOpenEditFormOnDoubleClick = false;
			this.dataGridViewAircraftModels.Displayer = null;
			this.dataGridViewAircraftModels.DisplayerText = null;
			this.dataGridViewAircraftModels.Entity = null;
			this.dataGridViewAircraftModels.Location = new System.Drawing.Point(291, 202);
			this.dataGridViewAircraftModels.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.dataGridViewAircraftModels.Name = "dataGridViewAircraftModels";
			this.dataGridViewAircraftModels.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dataGridViewAircraftModels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
			this.dataGridViewAircraftModels.ShowQuickSearch = false;
			this.dataGridViewAircraftModels.Size = new System.Drawing.Size(273, 150);
			this.dataGridViewAircraftModels.TabIndex = 136;
			// 
			// dictComboBoxMinLevel
			// 
			this.dictComboBoxMinLevel.Displayer = null;
			this.dictComboBoxMinLevel.DisplayerText = null;
			this.dictComboBoxMinLevel.Entity = null;
			this.dictComboBoxMinLevel.Location = new System.Drawing.Point(72, 51);
			this.dictComboBoxMinLevel.Name = "dictComboBoxMinLevel";
			this.dictComboBoxMinLevel.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictComboBoxMinLevel.Size = new System.Drawing.Size(193, 21);
			this.dictComboBoxMinLevel.TabIndex = 144;
			this.dictComboBoxMinLevel.Type = null;
			this.dictComboBoxMinLevel.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// FlightNumberIPerformanceControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dictComboBoxMinLevel);
			this.Controls.Add(this.labelCrew);
			this.Controls.Add(this.dataGridViewCrew);
			this.Controls.Add(this.delimiter4);
			this.Controls.Add(this.delimiter3);
			this.Controls.Add(this.labelAlternateAirPorts);
			this.Controls.Add(this.dataGridViewAirports);
			this.Controls.Add(this.labelApprovedModels);
			this.Controls.Add(this.dataGridViewAircraftModels);
			this.Controls.Add(this.delimiter1);
			this.Controls.Add(this.delimiter5);
			this.Controls.Add(this.numericUpDownMaxLandWeight);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDownFuelRemainAfter);
			this.Controls.Add(this.labelMinFuelRemainAfter);
			this.Controls.Add(this.labelPayLoad);
			this.Controls.Add(this.numericUpDownPayload);
			this.Controls.Add(this.numericUpDownPassengers);
			this.Controls.Add(this.labelPassengers);
			this.Controls.Add(this.numericUpDownTakeOffWeight);
			this.Controls.Add(this.labelTakeOffWeight);
			this.Controls.Add(this.numericUpDownFuel);
			this.Controls.Add(this.labelMaxFuel);
			this.Controls.Add(this.numericUpDownCargo);
			this.Controls.Add(this.labelCargo);
			this.Controls.Add(this.labelMinLevel);
			this.Controls.Add(this.comboBoxMeasure);
			this.Controls.Add(this.labelMeasure);
			this.Controls.Add(this.numericUpDownDistance);
			this.Controls.Add(this.labelDistance);
			this.Name = "FlightNumberIPerformanceControl";
			this.Size = new System.Drawing.Size(1016, 381);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelRemainAfter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPayload)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPassengers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTakeOffWeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCargo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLandWeight)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numericUpDownDistance;
		private System.Windows.Forms.Label labelDistance;
		private System.Windows.Forms.Label labelMinLevel;
		private System.Windows.Forms.ComboBox comboBoxMeasure;
		private System.Windows.Forms.Label labelMeasure;
		private System.Windows.Forms.NumericUpDown numericUpDownFuelRemainAfter;
		private System.Windows.Forms.Label labelMinFuelRemainAfter;
		private System.Windows.Forms.Label labelPayLoad;
		private System.Windows.Forms.NumericUpDown numericUpDownPayload;
		private System.Windows.Forms.NumericUpDown numericUpDownPassengers;
		private System.Windows.Forms.Label labelPassengers;
		private System.Windows.Forms.NumericUpDown numericUpDownTakeOffWeight;
		private System.Windows.Forms.Label labelTakeOffWeight;
		private System.Windows.Forms.NumericUpDown numericUpDownFuel;
		private System.Windows.Forms.Label labelMaxFuel;
		private System.Windows.Forms.NumericUpDown numericUpDownCargo;
		private System.Windows.Forms.Label labelCargo;
		private System.Windows.Forms.NumericUpDown numericUpDownMaxLandWeight;
		private System.Windows.Forms.Label label1;
		private Auxiliary.Delimiter delimiter5;
		private Auxiliary.Delimiter delimiter1;
		private System.Windows.Forms.Label labelCrew;
		private Auxiliary.CommonDataGridViewControl dataGridViewCrew;
		private Auxiliary.Delimiter delimiter4;
		private Auxiliary.Delimiter delimiter3;
		private System.Windows.Forms.Label labelAlternateAirPorts;
		private Auxiliary.CommonDataGridViewControl dataGridViewAirports;
		private System.Windows.Forms.Label labelApprovedModels;
		private Auxiliary.CommonDataGridViewControl dataGridViewAircraftModels;
		private Auxiliary.LookupCombobox dictComboBoxMinLevel;
	}
}
