using System.Windows.Forms;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    partial class PerformanceDataControl
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
            this.labelBasicEmptyWeight = new System.Windows.Forms.Label();
            this.labelBasicEmptyWeightCargoConfig = new System.Windows.Forms.Label();
            this.labelCargoCapacityContainer = new System.Windows.Forms.Label();
            this.labelCruise = new System.Windows.Forms.Label();
            this.labelCruiseFuelFlow = new System.Windows.Forms.Label();
            this.labelFuelCapacity = new System.Windows.Forms.Label();
            this.labelMaxCruiseAltitude = new System.Windows.Forms.Label();
            this.labelMaxLandingWeight = new System.Windows.Forms.Label();
            this.labelMaxTakeOffCrossWeight = new System.Windows.Forms.Label();
            this.labelMaxZeroFuelWeight = new System.Windows.Forms.Label();
            this.textBoxCargoCapacityContainer = new System.Windows.Forms.TextBox();
            this.textBoxCruise = new System.Windows.Forms.TextBox();
            this.textBoxCruiseFuelFlow = new System.Windows.Forms.TextBox();
            this.textBoxFuelCapacity = new System.Windows.Forms.TextBox();
            this.textBoxMaxCruiseAltitude = new System.Windows.Forms.TextBox();
            this.labelMaxTaxiWeight = new System.Windows.Forms.Label();
            this.labelOpertionalEmptyWeight = new System.Windows.Forms.Label();
            this.labelTanks = new System.Windows.Forms.Label();
            this.numericTanks = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBasicEmptyWeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBasicEmptyweightCargoConfig = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxLandingWeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxTakeoffCrossWeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxTaxiWeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxZeroFuelWeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOperationEmptyWeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxPayload = new System.Windows.Forms.NumericUpDown();
            this.labelMaxPayload = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericTanks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBasicEmptyWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBasicEmptyweightCargoConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLandingWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTakeoffCrossWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTaxiWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxZeroFuelWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOperationEmptyWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxPayload)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBasicEmptyWeight
            // 
            this.labelBasicEmptyWeight.AutoSize = true;
            this.labelBasicEmptyWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelBasicEmptyWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelBasicEmptyWeight.Location = new System.Drawing.Point(3, 14);
            this.labelBasicEmptyWeight.Name = "labelBasicEmptyWeight";
            this.labelBasicEmptyWeight.Size = new System.Drawing.Size(149, 17);
            this.labelBasicEmptyWeight.TabIndex = 0;
            this.labelBasicEmptyWeight.Text = "Basic Empty Weight";
            this.labelBasicEmptyWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBasicEmptyWeightCargoConfig
            // 
            this.labelBasicEmptyWeightCargoConfig.AutoSize = true;
            this.labelBasicEmptyWeightCargoConfig.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelBasicEmptyWeightCargoConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelBasicEmptyWeightCargoConfig.Location = new System.Drawing.Point(3, 53);
            this.labelBasicEmptyWeightCargoConfig.Name = "labelBasicEmptyWeightCargoConfig";
            this.labelBasicEmptyWeightCargoConfig.Size = new System.Drawing.Size(263, 17);
            this.labelBasicEmptyWeightCargoConfig.TabIndex = 1;
            this.labelBasicEmptyWeightCargoConfig.Text = "Basic Empty Weight (Cargo Config.)";
            this.labelBasicEmptyWeightCargoConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCargoCapacityContainer
            // 
            this.labelCargoCapacityContainer.AutoSize = true;
            this.labelCargoCapacityContainer.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCargoCapacityContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCargoCapacityContainer.Location = new System.Drawing.Point(3, 131);
            this.labelCargoCapacityContainer.Name = "labelCargoCapacityContainer";
            this.labelCargoCapacityContainer.Size = new System.Drawing.Size(187, 17);
            this.labelCargoCapacityContainer.TabIndex = 2;
            this.labelCargoCapacityContainer.Text = "Cargo Capacity Container";
            this.labelCargoCapacityContainer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCruise
            // 
            this.labelCruise.AutoSize = true;
            this.labelCruise.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCruise.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCruise.Location = new System.Drawing.Point(3, 170);
            this.labelCruise.Name = "labelCruise";
            this.labelCruise.Size = new System.Drawing.Size(104, 17);
            this.labelCruise.TabIndex = 3;
            this.labelCruise.Text = "Cruise (Mach)";
            this.labelCruise.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCruiseFuelFlow
            // 
            this.labelCruiseFuelFlow.AutoSize = true;
            this.labelCruiseFuelFlow.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCruiseFuelFlow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCruiseFuelFlow.Location = new System.Drawing.Point(3, 209);
            this.labelCruiseFuelFlow.Name = "labelCruiseFuelFlow";
            this.labelCruiseFuelFlow.Size = new System.Drawing.Size(121, 17);
            this.labelCruiseFuelFlow.TabIndex = 4;
            this.labelCruiseFuelFlow.Text = "Cruise Fuel Flow";
            this.labelCruiseFuelFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFuelCapacity
            // 
            this.labelFuelCapacity.AutoSize = true;
            this.labelFuelCapacity.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelFuelCapacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelFuelCapacity.Location = new System.Drawing.Point(3, 248);
            this.labelFuelCapacity.Name = "labelFuelCapacity";
            this.labelFuelCapacity.Size = new System.Drawing.Size(100, 17);
            this.labelFuelCapacity.TabIndex = 5;
            this.labelFuelCapacity.Text = "Fuel Capacity";
            this.labelFuelCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMaxCruiseAltitude
            // 
            this.labelMaxCruiseAltitude.AutoSize = true;
            this.labelMaxCruiseAltitude.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelMaxCruiseAltitude.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelMaxCruiseAltitude.Location = new System.Drawing.Point(3, 92);
            this.labelMaxCruiseAltitude.Name = "labelMaxCruiseAltitude";
            this.labelMaxCruiseAltitude.Size = new System.Drawing.Size(149, 17);
            this.labelMaxCruiseAltitude.TabIndex = 6;
            this.labelMaxCruiseAltitude.Text = "Max. Cruise Altitude";
            this.labelMaxCruiseAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMaxLandingWeight
            // 
            this.labelMaxLandingWeight.AutoSize = true;
            this.labelMaxLandingWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelMaxLandingWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelMaxLandingWeight.Location = new System.Drawing.Point(542, 53);
            this.labelMaxLandingWeight.Name = "labelMaxLandingWeight";
            this.labelMaxLandingWeight.Size = new System.Drawing.Size(156, 17);
            this.labelMaxLandingWeight.TabIndex = 7;
            this.labelMaxLandingWeight.Text = "Max. Landing Weight";
            this.labelMaxLandingWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMaxTakeOffCrossWeight
            // 
            this.labelMaxTakeOffCrossWeight.AutoSize = true;
            this.labelMaxTakeOffCrossWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelMaxTakeOffCrossWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelMaxTakeOffCrossWeight.Location = new System.Drawing.Point(542, 92);
            this.labelMaxTakeOffCrossWeight.Name = "labelMaxTakeOffCrossWeight";
            this.labelMaxTakeOffCrossWeight.Size = new System.Drawing.Size(208, 17);
            this.labelMaxTakeOffCrossWeight.TabIndex = 8;
            this.labelMaxTakeOffCrossWeight.Text = "Max. Take-Off Cross Weight";
            this.labelMaxTakeOffCrossWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMaxZeroFuelWeight
            // 
            this.labelMaxZeroFuelWeight.AutoSize = true;
            this.labelMaxZeroFuelWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelMaxZeroFuelWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelMaxZeroFuelWeight.Location = new System.Drawing.Point(542, 170);
            this.labelMaxZeroFuelWeight.Name = "labelMaxZeroFuelWeight";
            this.labelMaxZeroFuelWeight.Size = new System.Drawing.Size(167, 17);
            this.labelMaxZeroFuelWeight.TabIndex = 9;
            this.labelMaxZeroFuelWeight.Text = "Max. Zero Fuel Weight";
            this.labelMaxZeroFuelWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxCargoCapacityContainer
            // 
            this.textBoxCargoCapacityContainer.BackColor = System.Drawing.Color.White;
            this.textBoxCargoCapacityContainer.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxCargoCapacityContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxCargoCapacityContainer.Location = new System.Drawing.Point(282, 128);
            this.textBoxCargoCapacityContainer.Name = "textBoxCargoCapacityContainer";
            this.textBoxCargoCapacityContainer.Size = new System.Drawing.Size(200, 25);
            this.textBoxCargoCapacityContainer.TabIndex = 12;
            // 
            // textBoxCruise
            // 
            this.textBoxCruise.BackColor = System.Drawing.Color.White;
            this.textBoxCruise.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxCruise.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxCruise.Location = new System.Drawing.Point(282, 167);
            this.textBoxCruise.Name = "textBoxCruise";
            this.textBoxCruise.Size = new System.Drawing.Size(200, 25);
            this.textBoxCruise.TabIndex = 13;
            // 
            // textBoxCruiseFuelFlow
            // 
            this.textBoxCruiseFuelFlow.BackColor = System.Drawing.Color.White;
            this.textBoxCruiseFuelFlow.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxCruiseFuelFlow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxCruiseFuelFlow.Location = new System.Drawing.Point(282, 206);
            this.textBoxCruiseFuelFlow.Name = "textBoxCruiseFuelFlow";
            this.textBoxCruiseFuelFlow.Size = new System.Drawing.Size(200, 25);
            this.textBoxCruiseFuelFlow.TabIndex = 14;
            // 
            // textBoxFuelCapacity
            // 
            this.textBoxFuelCapacity.BackColor = System.Drawing.Color.White;
            this.textBoxFuelCapacity.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxFuelCapacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxFuelCapacity.Location = new System.Drawing.Point(282, 245);
            this.textBoxFuelCapacity.Name = "textBoxFuelCapacity";
            this.textBoxFuelCapacity.Size = new System.Drawing.Size(200, 25);
            this.textBoxFuelCapacity.TabIndex = 15;
            // 
            // textBoxMaxCruiseAltitude
            // 
            this.textBoxMaxCruiseAltitude.BackColor = System.Drawing.Color.White;
            this.textBoxMaxCruiseAltitude.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxMaxCruiseAltitude.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxMaxCruiseAltitude.Location = new System.Drawing.Point(281, 89);
            this.textBoxMaxCruiseAltitude.Name = "textBoxMaxCruiseAltitude";
            this.textBoxMaxCruiseAltitude.Size = new System.Drawing.Size(200, 25);
            this.textBoxMaxCruiseAltitude.TabIndex = 16;
            // 
            // labelMaxTaxiWeight
            // 
            this.labelMaxTaxiWeight.AutoSize = true;
            this.labelMaxTaxiWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelMaxTaxiWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelMaxTaxiWeight.Location = new System.Drawing.Point(542, 131);
            this.labelMaxTaxiWeight.Name = "labelMaxTaxiWeight";
            this.labelMaxTaxiWeight.Size = new System.Drawing.Size(130, 17);
            this.labelMaxTaxiWeight.TabIndex = 20;
            this.labelMaxTaxiWeight.Text = "Max. Taxi Weight";
            this.labelMaxTaxiWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOpertionalEmptyWeight
            // 
            this.labelOpertionalEmptyWeight.AutoSize = true;
            this.labelOpertionalEmptyWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelOpertionalEmptyWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelOpertionalEmptyWeight.Location = new System.Drawing.Point(542, 209);
            this.labelOpertionalEmptyWeight.Name = "labelOpertionalEmptyWeight";
            this.labelOpertionalEmptyWeight.Size = new System.Drawing.Size(193, 17);
            this.labelOpertionalEmptyWeight.TabIndex = 22;
            this.labelOpertionalEmptyWeight.Text = "Operational Empty Weight";
            this.labelOpertionalEmptyWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTanks
            // 
            this.labelTanks.AutoSize = true;
            this.labelTanks.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelTanks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelTanks.Location = new System.Drawing.Point(542, 248);
            this.labelTanks.Name = "labelTanks";
            this.labelTanks.Size = new System.Drawing.Size(50, 17);
            this.labelTanks.TabIndex = 24;
            this.labelTanks.Text = "Tanks";
            this.labelTanks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericTanks
            // 
            this.numericTanks.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericTanks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.numericTanks.Location = new System.Drawing.Point(766, 246);
            this.numericTanks.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericTanks.Name = "numericTanks";
            this.numericTanks.Size = new System.Drawing.Size(200, 25);
            this.numericTanks.TabIndex = 26;
            this.numericTanks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericTanks.ValueChanged += new System.EventHandler(this.NumericTanksValueChanged);
            // 
            // numericUpDownBasicEmptyWeight
            // 
            this.numericUpDownBasicEmptyWeight.DecimalPlaces = 2;
            this.numericUpDownBasicEmptyWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownBasicEmptyWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.numericUpDownBasicEmptyWeight.Location = new System.Drawing.Point(282, 11);
            this.numericUpDownBasicEmptyWeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownBasicEmptyWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownBasicEmptyWeight.Name = "numericUpDownBasicEmptyWeight";
            this.numericUpDownBasicEmptyWeight.Size = new System.Drawing.Size(199, 25);
            this.numericUpDownBasicEmptyWeight.TabIndex = 27;
            // 
            // numericUpDownBasicEmptyweightCargoConfig
            // 
            this.numericUpDownBasicEmptyweightCargoConfig.DecimalPlaces = 2;
            this.numericUpDownBasicEmptyweightCargoConfig.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownBasicEmptyweightCargoConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.numericUpDownBasicEmptyweightCargoConfig.Location = new System.Drawing.Point(282, 51);
            this.numericUpDownBasicEmptyweightCargoConfig.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownBasicEmptyweightCargoConfig.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownBasicEmptyweightCargoConfig.Name = "numericUpDownBasicEmptyweightCargoConfig";
            this.numericUpDownBasicEmptyweightCargoConfig.Size = new System.Drawing.Size(199, 25);
            this.numericUpDownBasicEmptyweightCargoConfig.TabIndex = 28;
            // 
            // numericUpDownMaxLandingWeight
            // 
            this.numericUpDownMaxLandingWeight.DecimalPlaces = 2;
            this.numericUpDownMaxLandingWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownMaxLandingWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.numericUpDownMaxLandingWeight.Location = new System.Drawing.Point(766, 50);
            this.numericUpDownMaxLandingWeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownMaxLandingWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownMaxLandingWeight.Name = "numericUpDownMaxLandingWeight";
            this.numericUpDownMaxLandingWeight.Size = new System.Drawing.Size(199, 25);
            this.numericUpDownMaxLandingWeight.TabIndex = 29;
            // 
            // numericUpDownMaxTakeoffCrossWeight
            // 
            this.numericUpDownMaxTakeoffCrossWeight.DecimalPlaces = 2;
            this.numericUpDownMaxTakeoffCrossWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownMaxTakeoffCrossWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.numericUpDownMaxTakeoffCrossWeight.Location = new System.Drawing.Point(766, 89);
            this.numericUpDownMaxTakeoffCrossWeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownMaxTakeoffCrossWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownMaxTakeoffCrossWeight.Name = "numericUpDownMaxTakeoffCrossWeight";
            this.numericUpDownMaxTakeoffCrossWeight.Size = new System.Drawing.Size(199, 25);
            this.numericUpDownMaxTakeoffCrossWeight.TabIndex = 30;
            // 
            // numericUpDownMaxTaxiWeight
            // 
            this.numericUpDownMaxTaxiWeight.DecimalPlaces = 2;
            this.numericUpDownMaxTaxiWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownMaxTaxiWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.numericUpDownMaxTaxiWeight.Location = new System.Drawing.Point(766, 128);
            this.numericUpDownMaxTaxiWeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownMaxTaxiWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownMaxTaxiWeight.Name = "numericUpDownMaxTaxiWeight";
            this.numericUpDownMaxTaxiWeight.Size = new System.Drawing.Size(199, 25);
            this.numericUpDownMaxTaxiWeight.TabIndex = 31;
            // 
            // numericUpDownMaxZeroFuelWeight
            // 
            this.numericUpDownMaxZeroFuelWeight.DecimalPlaces = 2;
            this.numericUpDownMaxZeroFuelWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownMaxZeroFuelWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.numericUpDownMaxZeroFuelWeight.Location = new System.Drawing.Point(766, 167);
            this.numericUpDownMaxZeroFuelWeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownMaxZeroFuelWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownMaxZeroFuelWeight.Name = "numericUpDownMaxZeroFuelWeight";
            this.numericUpDownMaxZeroFuelWeight.Size = new System.Drawing.Size(199, 25);
            this.numericUpDownMaxZeroFuelWeight.TabIndex = 32;
            // 
            // numericUpDownOperationEmptyWeight
            // 
            this.numericUpDownOperationEmptyWeight.DecimalPlaces = 2;
            this.numericUpDownOperationEmptyWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownOperationEmptyWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.numericUpDownOperationEmptyWeight.Location = new System.Drawing.Point(766, 206);
            this.numericUpDownOperationEmptyWeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownOperationEmptyWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownOperationEmptyWeight.Name = "numericUpDownOperationEmptyWeight";
            this.numericUpDownOperationEmptyWeight.Size = new System.Drawing.Size(199, 25);
            this.numericUpDownOperationEmptyWeight.TabIndex = 33;
            // 
            // numericUpDownMaxPayload
            // 
            this.numericUpDownMaxPayload.DecimalPlaces = 2;
            this.numericUpDownMaxPayload.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownMaxPayload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.numericUpDownMaxPayload.Location = new System.Drawing.Point(766, 12);
            this.numericUpDownMaxPayload.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownMaxPayload.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownMaxPayload.Name = "numericUpDownMaxPayload";
            this.numericUpDownMaxPayload.Size = new System.Drawing.Size(199, 25);
            this.numericUpDownMaxPayload.TabIndex = 35;
            // 
            // labelMaxPayload
            // 
            this.labelMaxPayload.AutoSize = true;
            this.labelMaxPayload.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelMaxPayload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelMaxPayload.Location = new System.Drawing.Point(542, 14);
            this.labelMaxPayload.Name = "labelMaxPayload";
            this.labelMaxPayload.Size = new System.Drawing.Size(94, 17);
            this.labelMaxPayload.TabIndex = 34;
            this.labelMaxPayload.Text = "Max Payload";
            this.labelMaxPayload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PerformanceDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownMaxPayload);
            this.Controls.Add(this.labelMaxPayload);
            this.Controls.Add(this.numericUpDownOperationEmptyWeight);
            this.Controls.Add(this.numericUpDownMaxZeroFuelWeight);
            this.Controls.Add(this.numericUpDownMaxTaxiWeight);
            this.Controls.Add(this.numericUpDownMaxTakeoffCrossWeight);
            this.Controls.Add(this.numericUpDownMaxLandingWeight);
            this.Controls.Add(this.numericUpDownBasicEmptyweightCargoConfig);
            this.Controls.Add(this.numericUpDownBasicEmptyWeight);
            this.Controls.Add(this.numericTanks);
            this.Controls.Add(this.labelTanks);
            this.Controls.Add(this.labelOpertionalEmptyWeight);
            this.Controls.Add(this.labelMaxTaxiWeight);
            this.Controls.Add(this.labelBasicEmptyWeight);
            this.Controls.Add(this.labelBasicEmptyWeightCargoConfig);
            this.Controls.Add(this.labelCargoCapacityContainer);
            this.Controls.Add(this.labelCruise);
            this.Controls.Add(this.labelCruiseFuelFlow);
            this.Controls.Add(this.labelFuelCapacity);
            this.Controls.Add(this.labelMaxCruiseAltitude);
            this.Controls.Add(this.labelMaxLandingWeight);
            this.Controls.Add(this.labelMaxTakeOffCrossWeight);
            this.Controls.Add(this.labelMaxZeroFuelWeight);
            this.Controls.Add(this.textBoxCargoCapacityContainer);
            this.Controls.Add(this.textBoxCruise);
            this.Controls.Add(this.textBoxCruiseFuelFlow);
            this.Controls.Add(this.textBoxFuelCapacity);
            this.Controls.Add(this.textBoxMaxCruiseAltitude);
            this.Name = "PerformanceDataControl";
            this.Size = new System.Drawing.Size(971, 275);
            ((System.ComponentModel.ISupportInitialize)(this.numericTanks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBasicEmptyWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBasicEmptyweightCargoConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLandingWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTakeoffCrossWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTaxiWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxZeroFuelWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOperationEmptyWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxPayload)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Label labelBasicEmptyWeight = new Label();
        private Label labelBasicEmptyWeightCargoConfig = new Label();
        private Label labelCargoCapacityContainer = new Label();
        private Label labelCruise = new Label();
        private Label labelCruiseFuelFlow = new Label();
        private Label labelFuelCapacity = new Label();
        private Label labelMaxCruiseAltitude = new Label();
        private Label labelMaxLandingWeight = new Label();
        private Label labelMaxTakeOffCrossWeight = new Label();
        private Label labelMaxZeroFuelWeight = new Label();
        private TextBox textBoxCargoCapacityContainer = new TextBox();
        private TextBox textBoxCruise = new TextBox();
        private TextBox textBoxCruiseFuelFlow = new TextBox();
        private TextBox textBoxFuelCapacity = new TextBox();
        private TextBox textBoxMaxCruiseAltitude = new TextBox();
        #endregion
        private Label labelMaxTaxiWeight;
        private Label labelOpertionalEmptyWeight;
        private Label labelTanks;
        private NumericUpDown numericTanks;
        private NumericUpDown numericUpDownBasicEmptyWeight;
        private NumericUpDown numericUpDownBasicEmptyweightCargoConfig;
        private NumericUpDown numericUpDownMaxLandingWeight;
        private NumericUpDown numericUpDownMaxTakeoffCrossWeight;
        private NumericUpDown numericUpDownMaxTaxiWeight;
        private NumericUpDown numericUpDownMaxZeroFuelWeight;
        private NumericUpDown numericUpDownOperationEmptyWeight;
        private NumericUpDown numericUpDownMaxPayload;
        private Label labelMaxPayload;
    }
}
