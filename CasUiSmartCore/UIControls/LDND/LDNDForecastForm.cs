using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.LDND
{
	///<summary>
	///</summary>
	public partial class LDNDForecastForm : MetroForm
	{
		private MaintenanceCheckCollection _checkItems;

		private AverageUtilization _averageUtilization;
		private Aircraft _aircraft;
		
		#region Constructors

		#region public ForecastCustomsWriteData()
		///<summary>
		///</summary>
		public LDNDForecastForm()
		{
			InitializeComponent();
		}
		#endregion

		#region public ForecastCustomsWriteData(Forecast forecast) : this()

		/// <summary>
		/// </summary>
		public LDNDForecastForm(Aircraft aircraft) : this()
		{
			_aircraft = aircraft;
			
			UpdateInformation();
		}
		#endregion


		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			dateTimePicker1.Enabled = checkBox1.Checked;
			var frame = GlobalObjects.CasEnvironment.BaseComponents.FirstOrDefault(i =>
				i.ParentAircraftId == _aircraft.ItemId && Equals(i.BaseComponentType, BaseComponentType.Frame));
			_averageUtilization = frame.AverageUtilization;
			
			if (checkBox1.Checked)
			{
				var current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_aircraft);
				_averageUtilization.HoursPerDay =  (double)current.Hours / (double)current.Days;
				_averageUtilization.CyclesPerDay = (double) current.Hours / (double)current.Cycles;
			}

			numericUpDownHours.Value = (decimal) _averageUtilization.Hours;
			numericUpDownCycles.Value = (decimal) _averageUtilization.Cycles;
		}

		#endregion

		#region private AverageUtilization GetAverageUtilization()
		private AverageUtilization GetAverageUtilization()
		{
			double eps = 0.00000001;
			double hours = (double)numericUpDownHours.Value;
			double cycles = (double)numericUpDownCycles.Value;

			if(numericUpDownHours.Value >= 24)
			{
				MessageBox.Show(numericUpDownHours.Value + ". Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return null; 
			}
			if (numericUpDownHours.Value >= 744)
			{
				MessageBox.Show(numericUpDownHours.Value + ". Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return null;
			}

			AverageUtilization au = new AverageUtilization();

		   au.SelectedInterval = UtilizationInterval.Dayly;


			if (Math.Abs(au.Hours - hours) > eps)
			{
				if (au.SelectedInterval == UtilizationInterval.Dayly)
					au.HoursPerDay = hours;
				else
					au.HoursPerMonth = hours;
			}
			if (Math.Abs(au.Cycles - cycles) > eps)
				if (au.SelectedInterval == UtilizationInterval.Dayly)
					au.CyclesPerDay = cycles;
				else
					au.CyclesPerMonth = cycles;
			return au;
		}
		#endregion

		#region private void ButtonOkClick(object sender, EventArgs e)
		private void ButtonOkClick(object sender, EventArgs e)
		{
			
		}
		#endregion

		#region private void ButtonCancelClick(object sender, EventArgs e)
		private void ButtonCancelClick(object sender, EventArgs e)
		{
			
		}
		#endregion

		#region private void checkBox1_CheckedChanged(object sender, EventArgs e)

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			dateTimePicker1.Enabled = !checkBox1.Checked;
			numericUpDownHours.Enabled = numericUpDownCycles.Enabled = checkBox1.Checked;

			if (checkBox1.Checked)
			{
				var current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_aircraft);
				_averageUtilization.HoursPerDay = (double)current.Hours / (double)current.Days;
				_averageUtilization.CyclesPerDay = (double)current.Hours / (double)current.Cycles;
			}
			else
			{
				
			}
		}

		#endregion

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{

		}

		#region private void numericUpDown_ValueChanged(object sender, EventArgs e)

		private void numericUpDown_ValueChanged(object sender, EventArgs e)
		{
			numericUpDown1.Value = numericUpDownHours.Value / numericUpDownCycles.Value;
		}

		#endregion

	}
}
