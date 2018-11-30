using System;
using SmartCore.Calculations;

namespace CAS.UI.UIControls.Auxiliary
{
	partial class TestControl
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
			this.lifelengthViewer1 = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.SuspendLayout();
			// 
			// lifelengthViewer1
			// 
			this.lifelengthViewer1.AutoSize = true;
			this.lifelengthViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer1.CalendarApplicable = false;
			this.lifelengthViewer1.CyclesApplicable = false;
			this.lifelengthViewer1.EnabledCalendar = true;
			this.lifelengthViewer1.EnabledCycle = true;
			this.lifelengthViewer1.EnabledHours = true;
			this.lifelengthViewer1.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer1.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer1.HeaderCalendar = "Calendar";
			this.lifelengthViewer1.HeaderCycles = "Cycles";
			this.lifelengthViewer1.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer1.HeaderHours = "Hours";
			this.lifelengthViewer1.HoursApplicable = false;
			this.lifelengthViewer1.LeftHeader = "Left";
			this.lifelengthViewer1.Location = new System.Drawing.Point(2, 2);
			this.lifelengthViewer1.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer1.Modified = false;
			this.lifelengthViewer1.Name = "lifelengthViewer1";
			this.lifelengthViewer1.ReadOnly = false;
			this.lifelengthViewer1.ShowCalendar = false;
			this.lifelengthViewer1.ShowFormattedCalendar = true;
			this.lifelengthViewer1.ShowMinutes = true;
			this.lifelengthViewer1.Size = new System.Drawing.Size(315, 51);
			this.lifelengthViewer1.SystemCalculated = true;
			this.lifelengthViewer1.TabIndex = 0;
			// 
			// TestControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lifelengthViewer1);
			this.Name = "TestControl";
			this.Size = new System.Drawing.Size(498, 147);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private LifelengthViewer lifelengthViewer1;
	}
}
