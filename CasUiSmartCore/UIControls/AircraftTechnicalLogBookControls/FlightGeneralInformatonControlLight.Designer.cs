namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class FlightGeneralInformatonControlLight
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightGeneralInformatonControlLight));
			this.flightDateRouteControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FlightDateRouteControlLight();
			this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter2 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.SuspendLayout();
			// 
			// flightDateRouteControl1
			// 
			this.flightDateRouteControl1.AttachedObject = null;
			this.flightDateRouteControl1.Location = new System.Drawing.Point(3, 3);
			this.flightDateRouteControl1.Margin = new System.Windows.Forms.Padding(5);
			this.flightDateRouteControl1.Name = "flightDateRouteControl1";
			this.flightDateRouteControl1.Size = new System.Drawing.Size(280, 235);
			this.flightDateRouteControl1.TabIndex = 1;
			this.flightDateRouteControl1.FlightDateChanget += new CAS.UI.UIControls.Auxiliary.Events.DateChangedEventHandler(this.FlightDateRouteControl1FlightDateChanget);
			this.flightDateRouteControl1.FlightStationFromChanget += new CAS.UI.UIControls.Auxiliary.Events.ValueChangedEventHandler(this.FlightDateRouteControl1FlightStationFromChanget);
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(4, 243);
			this.delimiter1.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter1.Size = new System.Drawing.Size(932, 1);
			this.delimiter1.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter1.TabIndex = 4;
			// 
			// delimiter2
			// 
			this.delimiter2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter2.BackgroundImage")));
			this.delimiter2.Location = new System.Drawing.Point(299, 14);
			this.delimiter2.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter2.Name = "delimiter2";
			this.delimiter2.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter2.Size = new System.Drawing.Size(1, 221);
			this.delimiter2.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter2.TabIndex = 8;
			// 
			// FlightGeneralInformatonControlLight
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.delimiter2);
			this.Controls.Add(this.delimiter1);
			this.Controls.Add(this.flightDateRouteControl1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FlightGeneralInformatonControlLight";
			this.Size = new System.Drawing.Size(982, 551);
			this.ResumeLayout(false);

        }

        #endregion
        private FlightDateRouteControlLight flightDateRouteControl1;
        private Auxiliary.Delimiter delimiter1;
		private Auxiliary.Delimiter delimiter2;
	}
}
