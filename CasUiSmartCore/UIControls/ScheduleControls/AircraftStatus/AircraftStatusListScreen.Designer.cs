namespace CAS.UI.UIControls.ScheduleControls.AircraftStatus
{
	partial class AircraftStatusListScreen
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
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 129);
			this.panel1.Size = new System.Drawing.Size(917, 413);
			// 
			// aircraftHeaderControl1
			//
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
			this.aircraftHeaderControl1.NextClickable = true;
			this.aircraftHeaderControl1.PrevClickable = true;
			// 
			// headerControl
			// 
			this.headerControl.Size = new System.Drawing.Size(985, 58);
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);


			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "AircraftStatusListScreen";
			this.ShowAircraftStatusPanel = false;
			this.Size = new System.Drawing.Size(917, 590);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion
	}
}
