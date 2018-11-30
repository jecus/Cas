namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class FuelTireOilInformationControl
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
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.fuelControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FuelControl();
            this.tirePressureControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.TirePressureControl();
            this.componentOilListControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.ComponentOilListControl();
            this.hydraulicListControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.HydraulicListControl();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.Controls.Add(this.fuelControl1);
            this.flowLayoutPanelMain.Controls.Add(this.tirePressureControl1);
            this.flowLayoutPanelMain.Controls.Add(this.componentOilListControl1);
            this.flowLayoutPanelMain.Controls.Add(this.hydraulicListControl1);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.MaximumSize = new System.Drawing.Size(1024, 640);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(1024, 503);
            this.flowLayoutPanelMain.TabIndex = 0;
            // 
            // fuelControl1
            // 
            this.fuelControl1.AttachedObject = null;
            this.fuelControl1.Location = new System.Drawing.Point(5, 5);
            this.fuelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.fuelControl1.Name = "fuelControl1";
            this.fuelControl1.Size = new System.Drawing.Size(664, 143);
            this.fuelControl1.TabIndex = 0;
            this.fuelControl1.OnBoardChanget += new CAS.UI.UIControls.Auxiliary.Events.ValueChangedEventHandler(this.fuelControl1_OnBoardChanget);
            this.fuelControl1.RemainAfterChanget += new CAS.UI.UIControls.Auxiliary.Events.ValueChangedEventHandler(this.FuelControl1RemainAfterChanget);
            // 
            // tirePressureControl1
            // 
            this.tirePressureControl1.AttachedObject = null;
            this.tirePressureControl1.Location = new System.Drawing.Point(679, 5);
            this.tirePressureControl1.Margin = new System.Windows.Forms.Padding(5);
            this.tirePressureControl1.Name = "tirePressureControl1";
            this.tirePressureControl1.Size = new System.Drawing.Size(210, 115);
            this.tirePressureControl1.TabIndex = 1;
            // 
            // componentOilListControl1
            // 
            this.componentOilListControl1.AttachedObject = null;
            this.componentOilListControl1.Location = new System.Drawing.Point(5, 158);
            this.componentOilListControl1.Margin = new System.Windows.Forms.Padding(5);
            this.componentOilListControl1.Name = "componentOilListControl1";
            this.componentOilListControl1.Size = new System.Drawing.Size(590, 162);
            this.componentOilListControl1.TabIndex = 2;
            this.componentOilListControl1.OilFlowChanget += new System.EventHandler(this.ComponentOilListControl1OilFlowChanget);
            // 
            // hydraulicListControl1
            // 
            this.hydraulicListControl1.AttachedObject = null;
            this.hydraulicListControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hydraulicListControl1.Location = new System.Drawing.Point(4, 329);
            this.hydraulicListControl1.Margin = new System.Windows.Forms.Padding(4);
            this.hydraulicListControl1.MinimumSize = new System.Drawing.Size(540, 165);
            this.hydraulicListControl1.Name = "hydraulicListControl1";
            this.hydraulicListControl1.Size = new System.Drawing.Size(540, 165);
            this.hydraulicListControl1.TabIndex = 3;
            // 
            // FuelTireOilInformationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1024, 640);
            this.Name = "FuelTireOilInformationControl";
            this.Size = new System.Drawing.Size(1024, 503);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private FuelControl fuelControl1;
        private TirePressureControl tirePressureControl1;
        private ComponentOilListControl componentOilListControl1;
        private HydraulicListControl hydraulicListControl1;
    }
}
