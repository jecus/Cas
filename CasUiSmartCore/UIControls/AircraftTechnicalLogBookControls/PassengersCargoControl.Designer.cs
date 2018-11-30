namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class PassengersCargoControl
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
            this.passengerListControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.PassengerListControl();
            this.cargoListControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.CargoListControl();
            this.flightTakeOffWeightControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FlightTakeOffWeightControl();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMain.Controls.Add(this.passengerListControl1);
            this.flowLayoutPanelMain.Controls.Add(this.cargoListControl1);
            this.flowLayoutPanelMain.Controls.Add(this.flightTakeOffWeightControl1);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(1255, 610);
            this.flowLayoutPanelMain.TabIndex = 0;
            // 
            // passengerListControl1
            // 
            this.passengerListControl1.AttachedObject = null;
            this.passengerListControl1.Location = new System.Drawing.Point(4, 4);
            this.passengerListControl1.Margin = new System.Windows.Forms.Padding(4);
            this.passengerListControl1.Name = "passengerListControl1";
            this.passengerListControl1.Size = new System.Drawing.Size(470, 247);
            this.passengerListControl1.TabIndex = 3;
            this.passengerListControl1.OnPassengersWeightChanget += new CAS.UI.UIControls.Auxiliary.Events.ValueChangedEventHandler(this.passengerListControl1_OnPassengersWeightChanget);
            // 
            // cargoListControl1
            // 
            this.cargoListControl1.AttachedObject = null;
            this.cargoListControl1.Location = new System.Drawing.Point(482, 4);
            this.cargoListControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cargoListControl1.Name = "cargoListControl1";
            this.cargoListControl1.Size = new System.Drawing.Size(456, 195);
            this.cargoListControl1.TabIndex = 4;
            this.cargoListControl1.OnCargoWeightChanget += new CAS.UI.UIControls.Auxiliary.Events.ValueChangedEventHandler(this.cargoListControl1_OnCargoWeightChanget);
            // 
            // flightTakeOffWeightControl1
            // 
            this.flightTakeOffWeightControl1.AttachedObject = null;
            this.flightTakeOffWeightControl1.Location = new System.Drawing.Point(4, 259);
            this.flightTakeOffWeightControl1.Margin = new System.Windows.Forms.Padding(4);
            this.flightTakeOffWeightControl1.Name = "flightTakeOffWeightControl1";
            this.flightTakeOffWeightControl1.Size = new System.Drawing.Size(500, 340);
            this.flightTakeOffWeightControl1.TabIndex = 5;
            // 
            // PassengersCargoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1255, 640);
            this.Name = "PassengersCargoControl";
            this.Size = new System.Drawing.Size(1255, 610);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private PassengerListControl passengerListControl1;
        private CargoListControl cargoListControl1;
        private FlightTakeOffWeightControl flightTakeOffWeightControl1;
    }
}
