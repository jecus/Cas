namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class FlightTakeOffWeightControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightTakeOffWeightControl));
            this.label1 = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.labelCrew = new System.Windows.Forms.Label();
            this.numericUpDownOpEmptyWeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCrew = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownZeroFuel = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCargo = new System.Windows.Forms.NumericUpDown();
            this.labelCargo = new System.Windows.Forms.Label();
            this.labelZeroFuel = new System.Windows.Forms.Label();
            this.delimiter5 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.labelMaxZeroFuel = new System.Windows.Forms.Label();
            this.numericUpDownMaxZeroFuel = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFuel = new System.Windows.Forms.NumericUpDown();
            this.labelFuel = new System.Windows.Forms.Label();
            this.numericUpDownTakeOffWeight = new System.Windows.Forms.NumericUpDown();
            this.labelTakeOffWeight = new System.Windows.Forms.Label();
            this.numericUpDownMaxTakeOffWeight = new System.Windows.Forms.NumericUpDown();
            this.labelMaxTakeOffWeight = new System.Windows.Forms.Label();
            this.labelMaxParams = new System.Windows.Forms.Label();
            this.numericUpDownPassengers = new System.Windows.Forms.NumericUpDown();
            this.labelPassengers = new System.Windows.Forms.Label();
            this.labelPayLoad = new System.Windows.Forms.Label();
            this.numericUpDownPayload = new System.Windows.Forms.NumericUpDown();
            this.labelMaxPayload = new System.Windows.Forms.Label();
            this.numericUpDownMaxPayload = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxTaxiWeight = new System.Windows.Forms.NumericUpDown();
            this.labelMaxTaxiWeight = new System.Windows.Forms.Label();
            this.numericUpDownMaxLandingWeight = new System.Windows.Forms.NumericUpDown();
            this.labelMaxLandingWeight = new System.Windows.Forms.Label();
            this.numericUpDownLandingWeight = new System.Windows.Forms.NumericUpDown();
            this.labelLandingWeight = new System.Windows.Forms.Label();
            this.numericUpDownFuelRemainAfter = new System.Windows.Forms.NumericUpDown();
            this.labelFuelRemainAfter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpEmptyWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCrew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZeroFuel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxZeroFuel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTakeOffWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTakeOffWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPassengers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPayload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxPayload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTaxiWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLandingWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLandingWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelRemainAfter)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Take off weight";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(3, 37);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(110, 13);
            this.labelLevel.TabIndex = 7;
            this.labelLevel.Text = "Op. empty weight. KG";
            // 
            // labelCrew
            // 
            this.labelCrew.AutoSize = true;
            this.labelCrew.Location = new System.Drawing.Point(3, 67);
            this.labelCrew.Name = "labelCrew";
            this.labelCrew.Size = new System.Drawing.Size(52, 13);
            this.labelCrew.TabIndex = 14;
            this.labelCrew.Text = "Crew. KG";
            // 
            // numericUpDownOpEmptyWeight
            // 
            this.numericUpDownOpEmptyWeight.DecimalPlaces = 2;
            this.numericUpDownOpEmptyWeight.Enabled = false;
            this.numericUpDownOpEmptyWeight.Location = new System.Drawing.Point(121, 36);
            this.numericUpDownOpEmptyWeight.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownOpEmptyWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownOpEmptyWeight.Name = "numericUpDownOpEmptyWeight";
            this.numericUpDownOpEmptyWeight.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownOpEmptyWeight.TabIndex = 1;
            this.numericUpDownOpEmptyWeight.ValueChanged += new System.EventHandler(this.NumericUpDownValueChanged);
            // 
            // numericUpDownCrew
            // 
            this.numericUpDownCrew.DecimalPlaces = 2;
            this.numericUpDownCrew.Location = new System.Drawing.Point(121, 66);
            this.numericUpDownCrew.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownCrew.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownCrew.Name = "numericUpDownCrew";
            this.numericUpDownCrew.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownCrew.TabIndex = 2;
            this.numericUpDownCrew.ValueChanged += new System.EventHandler(this.NumericUpDownValueChanged);
            // 
            // numericUpDownZeroFuel
            // 
            this.numericUpDownZeroFuel.DecimalPlaces = 2;
            this.numericUpDownZeroFuel.Enabled = false;
            this.numericUpDownZeroFuel.Location = new System.Drawing.Point(121, 186);
            this.numericUpDownZeroFuel.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownZeroFuel.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownZeroFuel.Name = "numericUpDownZeroFuel";
            this.numericUpDownZeroFuel.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownZeroFuel.TabIndex = 4;
            // 
            // numericUpDownCargo
            // 
            this.numericUpDownCargo.DecimalPlaces = 2;
            this.numericUpDownCargo.Location = new System.Drawing.Point(121, 126);
            this.numericUpDownCargo.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownCargo.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownCargo.Name = "numericUpDownCargo";
            this.numericUpDownCargo.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownCargo.TabIndex = 3;
            this.numericUpDownCargo.ValueChanged += new System.EventHandler(this.NumericUpDownValueChanged);
            // 
            // labelCargo
            // 
            this.labelCargo.AutoSize = true;
            this.labelCargo.Location = new System.Drawing.Point(3, 128);
            this.labelCargo.Name = "labelCargo";
            this.labelCargo.Size = new System.Drawing.Size(56, 13);
            this.labelCargo.TabIndex = 6;
            this.labelCargo.Text = "Cargo. KG";
            // 
            // labelZeroFuel
            // 
            this.labelZeroFuel.AutoSize = true;
            this.labelZeroFuel.Location = new System.Drawing.Point(3, 188);
            this.labelZeroFuel.Name = "labelZeroFuel";
            this.labelZeroFuel.Size = new System.Drawing.Size(73, 13);
            this.labelZeroFuel.TabIndex = 72;
            this.labelZeroFuel.Text = "Zero Fuel. KG";
            // 
            // delimiter5
            // 
            this.delimiter5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter5.BackgroundImage")));
            this.delimiter5.Location = new System.Drawing.Point(239, 36);
            this.delimiter5.Margin = new System.Windows.Forms.Padding(4);
            this.delimiter5.Name = "delimiter5";
            this.delimiter5.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
            this.delimiter5.Size = new System.Drawing.Size(1, 290);
            this.delimiter5.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter5.TabIndex = 73;
            // 
            // labelMaxZeroFuel
            // 
            this.labelMaxZeroFuel.AutoSize = true;
            this.labelMaxZeroFuel.Location = new System.Drawing.Point(247, 188);
            this.labelMaxZeroFuel.Name = "labelMaxZeroFuel";
            this.labelMaxZeroFuel.Size = new System.Drawing.Size(99, 13);
            this.labelMaxZeroFuel.TabIndex = 75;
            this.labelMaxZeroFuel.Text = "Max. Zero Fuel. KG";
            // 
            // numericUpDownMaxZeroFuel
            // 
            this.numericUpDownMaxZeroFuel.DecimalPlaces = 2;
            this.numericUpDownMaxZeroFuel.Enabled = false;
            this.numericUpDownMaxZeroFuel.Location = new System.Drawing.Point(378, 186);
            this.numericUpDownMaxZeroFuel.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownMaxZeroFuel.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownMaxZeroFuel.Name = "numericUpDownMaxZeroFuel";
            this.numericUpDownMaxZeroFuel.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownMaxZeroFuel.TabIndex = 74;
            // 
            // numericUpDownFuel
            // 
            this.numericUpDownFuel.DecimalPlaces = 2;
            this.numericUpDownFuel.Location = new System.Drawing.Point(121, 216);
            this.numericUpDownFuel.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownFuel.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownFuel.Name = "numericUpDownFuel";
            this.numericUpDownFuel.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownFuel.TabIndex = 5;
            this.numericUpDownFuel.ValueChanged += new System.EventHandler(this.NumericUpDownValueChanged);
            // 
            // labelFuel
            // 
            this.labelFuel.AutoSize = true;
            this.labelFuel.Location = new System.Drawing.Point(3, 218);
            this.labelFuel.Name = "labelFuel";
            this.labelFuel.Size = new System.Drawing.Size(94, 13);
            this.labelFuel.TabIndex = 76;
            this.labelFuel.Text = "Fuel on Board. KG";
            // 
            // numericUpDownTakeOffWeight
            // 
            this.numericUpDownTakeOffWeight.DecimalPlaces = 2;
            this.numericUpDownTakeOffWeight.Location = new System.Drawing.Point(121, 246);
            this.numericUpDownTakeOffWeight.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownTakeOffWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownTakeOffWeight.Name = "numericUpDownTakeOffWeight";
            this.numericUpDownTakeOffWeight.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownTakeOffWeight.TabIndex = 6;
            // 
            // labelTakeOffWeight
            // 
            this.labelTakeOffWeight.AutoSize = true;
            this.labelTakeOffWeight.Location = new System.Drawing.Point(3, 248);
            this.labelTakeOffWeight.Name = "labelTakeOffWeight";
            this.labelTakeOffWeight.Size = new System.Drawing.Size(107, 13);
            this.labelTakeOffWeight.TabIndex = 78;
            this.labelTakeOffWeight.Text = "Take Off Weight. KG";
            // 
            // numericUpDownMaxTakeOffWeight
            // 
            this.numericUpDownMaxTakeOffWeight.DecimalPlaces = 2;
            this.numericUpDownMaxTakeOffWeight.Enabled = false;
            this.numericUpDownMaxTakeOffWeight.Location = new System.Drawing.Point(378, 246);
            this.numericUpDownMaxTakeOffWeight.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownMaxTakeOffWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownMaxTakeOffWeight.Name = "numericUpDownMaxTakeOffWeight";
            this.numericUpDownMaxTakeOffWeight.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownMaxTakeOffWeight.TabIndex = 81;
            // 
            // labelMaxTakeOffWeight
            // 
            this.labelMaxTakeOffWeight.AutoSize = true;
            this.labelMaxTakeOffWeight.Location = new System.Drawing.Point(247, 248);
            this.labelMaxTakeOffWeight.Name = "labelMaxTakeOffWeight";
            this.labelMaxTakeOffWeight.Size = new System.Drawing.Size(130, 13);
            this.labelMaxTakeOffWeight.TabIndex = 80;
            this.labelMaxTakeOffWeight.Text = "Max Take Off Weight. KG";
            // 
            // labelMaxParams
            // 
            this.labelMaxParams.AutoSize = true;
            this.labelMaxParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelMaxParams.Location = new System.Drawing.Point(247, 3);
            this.labelMaxParams.Name = "labelMaxParams";
            this.labelMaxParams.Size = new System.Drawing.Size(126, 13);
            this.labelMaxParams.TabIndex = 82;
            this.labelMaxParams.Text = "Max Take off params";
            // 
            // numericUpDownPassengers
            // 
            this.numericUpDownPassengers.DecimalPlaces = 2;
            this.numericUpDownPassengers.Location = new System.Drawing.Point(121, 96);
            this.numericUpDownPassengers.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownPassengers.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownPassengers.Name = "numericUpDownPassengers";
            this.numericUpDownPassengers.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownPassengers.TabIndex = 83;
            this.numericUpDownPassengers.ValueChanged += new System.EventHandler(this.NumericUpDownValueChanged);
            // 
            // labelPassengers
            // 
            this.labelPassengers.AutoSize = true;
            this.labelPassengers.Location = new System.Drawing.Point(3, 98);
            this.labelPassengers.Name = "labelPassengers";
            this.labelPassengers.Size = new System.Drawing.Size(83, 13);
            this.labelPassengers.TabIndex = 84;
            this.labelPassengers.Text = "Passengers. KG";
            // 
            // labelPayLoad
            // 
            this.labelPayLoad.AutoSize = true;
            this.labelPayLoad.Location = new System.Drawing.Point(3, 158);
            this.labelPayLoad.Name = "labelPayLoad";
            this.labelPayLoad.Size = new System.Drawing.Size(66, 13);
            this.labelPayLoad.TabIndex = 86;
            this.labelPayLoad.Text = "Payload. KG";
            // 
            // numericUpDownPayload
            // 
            this.numericUpDownPayload.DecimalPlaces = 2;
            this.numericUpDownPayload.Enabled = false;
            this.numericUpDownPayload.Location = new System.Drawing.Point(121, 156);
            this.numericUpDownPayload.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownPayload.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownPayload.Name = "numericUpDownPayload";
            this.numericUpDownPayload.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownPayload.TabIndex = 85;
            // 
            // labelMaxPayload
            // 
            this.labelMaxPayload.AutoSize = true;
            this.labelMaxPayload.Location = new System.Drawing.Point(247, 158);
            this.labelMaxPayload.Name = "labelMaxPayload";
            this.labelMaxPayload.Size = new System.Drawing.Size(89, 13);
            this.labelMaxPayload.TabIndex = 88;
            this.labelMaxPayload.Text = "Max Payload. KG";
            // 
            // numericUpDownMaxPayload
            // 
            this.numericUpDownMaxPayload.DecimalPlaces = 2;
            this.numericUpDownMaxPayload.Enabled = false;
            this.numericUpDownMaxPayload.Location = new System.Drawing.Point(378, 156);
            this.numericUpDownMaxPayload.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownMaxPayload.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownMaxPayload.Name = "numericUpDownMaxPayload";
            this.numericUpDownMaxPayload.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownMaxPayload.TabIndex = 87;
            // 
            // numericUpDownMaxTaxiWeight
            // 
            this.numericUpDownMaxTaxiWeight.DecimalPlaces = 2;
            this.numericUpDownMaxTaxiWeight.Enabled = false;
            this.numericUpDownMaxTaxiWeight.Location = new System.Drawing.Point(378, 216);
            this.numericUpDownMaxTaxiWeight.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownMaxTaxiWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownMaxTaxiWeight.Name = "numericUpDownMaxTaxiWeight";
            this.numericUpDownMaxTaxiWeight.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownMaxTaxiWeight.TabIndex = 90;
            // 
            // labelMaxTaxiWeight
            // 
            this.labelMaxTaxiWeight.AutoSize = true;
            this.labelMaxTaxiWeight.Location = new System.Drawing.Point(247, 218);
            this.labelMaxTaxiWeight.Name = "labelMaxTaxiWeight";
            this.labelMaxTaxiWeight.Size = new System.Drawing.Size(108, 13);
            this.labelMaxTaxiWeight.TabIndex = 89;
            this.labelMaxTaxiWeight.Text = "Max Taxi Weight. KG";
            // 
            // numericUpDownMaxLandingWeight
            // 
            this.numericUpDownMaxLandingWeight.DecimalPlaces = 2;
            this.numericUpDownMaxLandingWeight.Enabled = false;
            this.numericUpDownMaxLandingWeight.Location = new System.Drawing.Point(378, 306);
            this.numericUpDownMaxLandingWeight.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownMaxLandingWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownMaxLandingWeight.Name = "numericUpDownMaxLandingWeight";
            this.numericUpDownMaxLandingWeight.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownMaxLandingWeight.TabIndex = 94;
            // 
            // labelMaxLandingWeight
            // 
            this.labelMaxLandingWeight.AutoSize = true;
            this.labelMaxLandingWeight.Location = new System.Drawing.Point(247, 308);
            this.labelMaxLandingWeight.Name = "labelMaxLandingWeight";
            this.labelMaxLandingWeight.Size = new System.Drawing.Size(126, 13);
            this.labelMaxLandingWeight.TabIndex = 93;
            this.labelMaxLandingWeight.Text = "Max Landing Weight. KG";
            // 
            // numericUpDownLandingWeight
            // 
            this.numericUpDownLandingWeight.DecimalPlaces = 2;
            this.numericUpDownLandingWeight.Location = new System.Drawing.Point(121, 306);
            this.numericUpDownLandingWeight.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownLandingWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownLandingWeight.Name = "numericUpDownLandingWeight";
            this.numericUpDownLandingWeight.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownLandingWeight.TabIndex = 91;
            // 
            // labelLandingWeight
            // 
            this.labelLandingWeight.AutoSize = true;
            this.labelLandingWeight.Location = new System.Drawing.Point(3, 308);
            this.labelLandingWeight.Name = "labelLandingWeight";
            this.labelLandingWeight.Size = new System.Drawing.Size(103, 13);
            this.labelLandingWeight.TabIndex = 92;
            this.labelLandingWeight.Text = "Landing Weight. KG";
            // 
            // numericUpDownFuelRemainAfter
            // 
            this.numericUpDownFuelRemainAfter.DecimalPlaces = 2;
            this.numericUpDownFuelRemainAfter.Enabled = false;
            this.numericUpDownFuelRemainAfter.Location = new System.Drawing.Point(121, 276);
            this.numericUpDownFuelRemainAfter.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownFuelRemainAfter.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownFuelRemainAfter.Name = "numericUpDownFuelRemainAfter";
            this.numericUpDownFuelRemainAfter.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownFuelRemainAfter.TabIndex = 95;
            this.numericUpDownFuelRemainAfter.ValueChanged += new System.EventHandler(this.NumericUpDownValueChanged);
            // 
            // labelFuelRemainAfter
            // 
            this.labelFuelRemainAfter.AutoSize = true;
            this.labelFuelRemainAfter.Location = new System.Drawing.Point(3, 278);
            this.labelFuelRemainAfter.Name = "labelFuelRemainAfter";
            this.labelFuelRemainAfter.Size = new System.Drawing.Size(106, 13);
            this.labelFuelRemainAfter.TabIndex = 96;
            this.labelFuelRemainAfter.Text = "Fuel remain after. KG";
            // 
            // FlightTakeOffWeightControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownFuelRemainAfter);
            this.Controls.Add(this.labelFuelRemainAfter);
            this.Controls.Add(this.numericUpDownMaxLandingWeight);
            this.Controls.Add(this.labelMaxLandingWeight);
            this.Controls.Add(this.numericUpDownLandingWeight);
            this.Controls.Add(this.labelLandingWeight);
            this.Controls.Add(this.numericUpDownMaxTaxiWeight);
            this.Controls.Add(this.labelMaxTaxiWeight);
            this.Controls.Add(this.labelMaxPayload);
            this.Controls.Add(this.numericUpDownMaxPayload);
            this.Controls.Add(this.labelPayLoad);
            this.Controls.Add(this.numericUpDownPayload);
            this.Controls.Add(this.numericUpDownPassengers);
            this.Controls.Add(this.labelPassengers);
            this.Controls.Add(this.labelMaxParams);
            this.Controls.Add(this.numericUpDownMaxTakeOffWeight);
            this.Controls.Add(this.labelMaxTakeOffWeight);
            this.Controls.Add(this.numericUpDownTakeOffWeight);
            this.Controls.Add(this.labelTakeOffWeight);
            this.Controls.Add(this.numericUpDownFuel);
            this.Controls.Add(this.labelFuel);
            this.Controls.Add(this.labelMaxZeroFuel);
            this.Controls.Add(this.numericUpDownMaxZeroFuel);
            this.Controls.Add(this.delimiter5);
            this.Controls.Add(this.labelZeroFuel);
            this.Controls.Add(this.numericUpDownZeroFuel);
            this.Controls.Add(this.numericUpDownCargo);
            this.Controls.Add(this.numericUpDownCrew);
            this.Controls.Add(this.numericUpDownOpEmptyWeight);
            this.Controls.Add(this.labelCrew);
            this.Controls.Add(this.labelCargo);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FlightTakeOffWeightControl";
            this.Size = new System.Drawing.Size(500, 340);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpEmptyWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCrew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZeroFuel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxZeroFuel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTakeOffWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTakeOffWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPassengers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPayload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxPayload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTaxiWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLandingWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLandingWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelRemainAfter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label labelCrew;
        private System.Windows.Forms.NumericUpDown numericUpDownOpEmptyWeight;
        private System.Windows.Forms.NumericUpDown numericUpDownCrew;
        private System.Windows.Forms.NumericUpDown numericUpDownZeroFuel;
        private System.Windows.Forms.NumericUpDown numericUpDownCargo;
        private System.Windows.Forms.Label labelCargo;
        private System.Windows.Forms.Label labelZeroFuel;
        private Auxiliary.Delimiter delimiter5;
        private System.Windows.Forms.Label labelMaxZeroFuel;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxZeroFuel;
        private System.Windows.Forms.NumericUpDown numericUpDownFuel;
        private System.Windows.Forms.Label labelFuel;
        private System.Windows.Forms.NumericUpDown numericUpDownTakeOffWeight;
        private System.Windows.Forms.Label labelTakeOffWeight;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxTakeOffWeight;
        private System.Windows.Forms.Label labelMaxTakeOffWeight;
        private System.Windows.Forms.Label labelMaxParams;
        private System.Windows.Forms.NumericUpDown numericUpDownPassengers;
        private System.Windows.Forms.Label labelPassengers;
        private System.Windows.Forms.Label labelPayLoad;
        private System.Windows.Forms.NumericUpDown numericUpDownPayload;
        private System.Windows.Forms.Label labelMaxPayload;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxPayload;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxTaxiWeight;
        private System.Windows.Forms.Label labelMaxTaxiWeight;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxLandingWeight;
        private System.Windows.Forms.Label labelMaxLandingWeight;
        private System.Windows.Forms.NumericUpDown numericUpDownLandingWeight;
        private System.Windows.Forms.Label labelLandingWeight;
        private System.Windows.Forms.NumericUpDown numericUpDownFuelRemainAfter;
        private System.Windows.Forms.Label labelFuelRemainAfter;

    }
}
