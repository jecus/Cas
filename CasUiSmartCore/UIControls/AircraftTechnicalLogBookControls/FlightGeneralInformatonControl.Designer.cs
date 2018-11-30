namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class FlightGeneralInformatonControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightGeneralInformatonControl));
			this.flightTimeControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FlightTimeControl();
			this.flightDateRouteControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FlightDateRouteControl();
			this.flightFluidsControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FlightFluidsControl();
			this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.releaseToServiceControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.ReleaseToServiceControl();
			this.flightCrewControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FlightCrewControl();
			this.flightDistanceControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FlightDistanceControl();
			this.delimiter2 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter3 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter4 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// flightTimeControl1
			// 
			this.flightTimeControl1.AttachedObject = null;
			this.flightTimeControl1.Location = new System.Drawing.Point(269, 5);
			this.flightTimeControl1.Margin = new System.Windows.Forms.Padding(5);
			this.flightTimeControl1.Name = "flightTimeControl1";
			this.flightTimeControl1.Size = new System.Drawing.Size(300, 185);
			this.flightTimeControl1.TabIndex = 0;
			this.flightTimeControl1.OutTimeChanget += new CAS.UI.UIControls.Auxiliary.Events.DateChangedEventHandler(this.FlightTimeControl1OutTimeChanget);
			this.flightTimeControl1.InTimeChanget += new CAS.UI.UIControls.Auxiliary.Events.DateChangedEventHandler(this.FlightTimeControl1InTimeChanget);
			this.flightTimeControl1.TakeOffTimeChanget += new CAS.UI.UIControls.Auxiliary.Events.DateChangedEventHandler(this.FlightTimeControl1TakeOffTimeChanget);
			this.flightTimeControl1.LDGTimeChanget += new CAS.UI.UIControls.Auxiliary.Events.DateChangedEventHandler(this.FlightTimeControl1LDGTimeChanget);
			// 
			// flightDateRouteControl1
			// 
			this.flightDateRouteControl1.AttachedObject = null;
			this.flightDateRouteControl1.Location = new System.Drawing.Point(3, 3);
			this.flightDateRouteControl1.Margin = new System.Windows.Forms.Padding(5);
			this.flightDateRouteControl1.Name = "flightDateRouteControl1";
			this.flightDateRouteControl1.Size = new System.Drawing.Size(265, 258);
			this.flightDateRouteControl1.TabIndex = 1;
			this.flightDateRouteControl1.FlightDateChanget += new CAS.UI.UIControls.Auxiliary.Events.DateChangedEventHandler(this.FlightDateRouteControl1FlightDateChanget);
	        this.flightDateRouteControl1.RecordTypeChanget += FlightDateRouteControl1_RecordTypeChanget;
			this.flightDateRouteControl1.FlightStationFromChanget += new CAS.UI.UIControls.Auxiliary.Events.ValueChangedEventHandler(this.FlightDateRouteControl1FlightStationFromChanget);
			// 
			// flightFluidsControl1
			// 
			this.flightFluidsControl1.AttachedObject = null;
			this.flightFluidsControl1.Location = new System.Drawing.Point(3, 280);
			this.flightFluidsControl1.Margin = new System.Windows.Forms.Padding(5);
			this.flightFluidsControl1.Name = "flightFluidsControl1";
			this.flightFluidsControl1.Size = new System.Drawing.Size(137, 114);
			this.flightFluidsControl1.TabIndex = 3;
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(4, 268);
			this.delimiter1.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter1.Size = new System.Drawing.Size(1350, 1);
			this.delimiter1.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter1.TabIndex = 4;
			// 
			// releaseToServiceControl1
			// 
			this.releaseToServiceControl1.AttachedObject = null;
			this.releaseToServiceControl1.Location = new System.Drawing.Point(150, 280);
			this.releaseToServiceControl1.Margin = new System.Windows.Forms.Padding(5);
			this.releaseToServiceControl1.Name = "releaseToServiceControl1";
			this.releaseToServiceControl1.ReleaseDate = new System.DateTime(2012, 12, 27, 19, 14, 57, 433);
			this.releaseToServiceControl1.Size = new System.Drawing.Size(284, 114);
			this.releaseToServiceControl1.TabIndex = 5;
			// 
			// flightCrewControl1
			// 
			this.flightCrewControl1.AttachedObject = null;
			this.flightCrewControl1.AutoSize = true;
			this.flightCrewControl1.Location = new System.Drawing.Point(587, 3);
			this.flightCrewControl1.Margin = new System.Windows.Forms.Padding(4);
			this.flightCrewControl1.Name = "flightCrewControl1";
			this.flightCrewControl1.Size = new System.Drawing.Size(414, 232);
			this.flightCrewControl1.TabIndex = 6;
			this.flightCrewControl1.CrewChanged += new CAS.UI.UIControls.Auxiliary.Events.CrewChangedEventHandler(this.FlightCrewControl1CrewChanged);
			// 
			// flightDistanceControl1
			// 
			this.flightDistanceControl1.AttachedObject = null;
			this.flightDistanceControl1.AutoSize = true;
			this.flightDistanceControl1.Location = new System.Drawing.Point(443, 280);
			this.flightDistanceControl1.Margin = new System.Windows.Forms.Padding(4);
			this.flightDistanceControl1.Name = "flightDistanceControl1";
			this.flightDistanceControl1.Size = new System.Drawing.Size(588, 115);
			this.flightDistanceControl1.TabIndex = 7;
			// 
			// delimiter2
			// 
			this.delimiter2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter2.BackgroundImage")));
			this.delimiter2.Location = new System.Drawing.Point(261, 14);
			this.delimiter2.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter2.Name = "delimiter2";
			this.delimiter2.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter2.Size = new System.Drawing.Size(1, 257);
			this.delimiter2.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter2.TabIndex = 8;
			// 
			// delimiter3
			// 
			this.delimiter3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter3.BackgroundImage")));
			this.delimiter3.Location = new System.Drawing.Point(578, 14);
			this.delimiter3.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter3.Name = "delimiter3";
			this.delimiter3.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter3.Size = new System.Drawing.Size(1, 255);
			this.delimiter3.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter3.TabIndex = 9;
			// 
			// delimiter4
			// 
			this.delimiter4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter4.BackgroundImage")));
			this.delimiter4.Location = new System.Drawing.Point(982, 14);
			this.delimiter4.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter4.Name = "delimiter4";
			this.delimiter4.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter4.Size = new System.Drawing.Size(1, 255);
			this.delimiter4.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter4.TabIndex = 10;
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(992, 33);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(314, 41);
			this.documentControl1.TabIndex = 69;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(992, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 70;
			this.label1.Text = "Document";
			// 
			// FlightGeneralInformatonControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.documentControl1);
			this.Controls.Add(this.delimiter4);
			this.Controls.Add(this.delimiter3);
			this.Controls.Add(this.delimiter2);
			this.Controls.Add(this.flightDistanceControl1);
			this.Controls.Add(this.flightCrewControl1);
			this.Controls.Add(this.releaseToServiceControl1);
			this.Controls.Add(this.delimiter1);
			this.Controls.Add(this.flightFluidsControl1);
			this.Controls.Add(this.flightDateRouteControl1);
			this.Controls.Add(this.flightTimeControl1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FlightGeneralInformatonControl";
			this.Size = new System.Drawing.Size(1358, 402);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private FlightTimeControl flightTimeControl1;
        private FlightDateRouteControl flightDateRouteControl1;
        private FlightFluidsControl flightFluidsControl1;
        private Auxiliary.Delimiter delimiter1;
        private ReleaseToServiceControl releaseToServiceControl1;
        private FlightCrewControl flightCrewControl1;
        private FlightDistanceControl flightDistanceControl1;
        private Auxiliary.Delimiter delimiter2;
        private Auxiliary.Delimiter delimiter3;
		private Auxiliary.Delimiter delimiter4;
		private DocumentationControls.DocumentControl documentControl1;
		private System.Windows.Forms.Label label1;
	}
}
