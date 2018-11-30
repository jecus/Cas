namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls.AircraftFlightLight
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
			this.flightDateRouteControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.AircraftFlightLight.FlightDateRouteControlLight();
			this.delimiter3 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// flightDateRouteControl1
			// 
			this.flightDateRouteControl1.AttachedObject = null;
			this.flightDateRouteControl1.Location = new System.Drawing.Point(3, 3);
			this.flightDateRouteControl1.Margin = new System.Windows.Forms.Padding(5);
			this.flightDateRouteControl1.Name = "flightDateRouteControl1";
			this.flightDateRouteControl1.Size = new System.Drawing.Size(307, 250);
			this.flightDateRouteControl1.TabIndex = 1;
			this.flightDateRouteControl1.FlightDateChanget += new CAS.UI.UIControls.Auxiliary.Events.DateChangedEventHandler(this.FlightDateRouteControl1FlightDateChanget);
			this.flightDateRouteControl1.FlightStationFromChanget += new CAS.UI.UIControls.Auxiliary.Events.ValueChangedEventHandler(this.FlightDateRouteControl1FlightStationFromChanget);
			this.flightDateRouteControl1.TakeOffTimeChanget += new CAS.UI.UIControls.Auxiliary.Events.DateChangedEventHandler(this.FlightTimeControl1TakeOffTimeChanget);
			this.flightDateRouteControl1.LDGTimeChanget += new CAS.UI.UIControls.Auxiliary.Events.DateChangedEventHandler(this.FlightTimeControl1LDGTimeChanget);
			// 
			// delimiter3
			// 
			this.delimiter3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter3.BackgroundImage")));
			this.delimiter3.Location = new System.Drawing.Point(316, 9);
			this.delimiter3.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter3.Name = "delimiter3";
			this.delimiter3.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter3.Size = new System.Drawing.Size(1, 255);
			this.delimiter3.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter3.TabIndex = 10;
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(327, 24);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(314, 41);
			this.documentControl1.TabIndex = 67;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(324, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 68;
			this.label1.Text = "Document";
			// 
			// FlightGeneralInformatonControlLight
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.documentControl1);
			this.Controls.Add(this.delimiter3);
			this.Controls.Add(this.flightDateRouteControl1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FlightGeneralInformatonControlLight";
			this.Size = new System.Drawing.Size(982, 268);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion


        private FlightDateRouteControlLight flightDateRouteControl1;
		private Auxiliary.Delimiter delimiter3;
		private DocumentationControls.DocumentControl documentControl1;
		private System.Windows.Forms.Label label1;
	}
}
