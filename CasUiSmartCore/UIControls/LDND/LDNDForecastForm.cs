using System;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Analyst;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.LDND
{
	///<summary>
	///</summary>
	public partial class LDNDForecastForm : MetroForm
	{
		private MaintenanceCheckCollection _checkItems;

		private AverageUtilization _averageUtilization;
		private Aircraft _aircraft;
		private BaseComponent _frame;

		#region Constructors

		#region public ForecastCustomsWriteData()

		///<summary>
		///</summary>
		public LDNDForecastForm()
		{
			InitializeComponent();
		}

		#endregion

		#region public LDNDForecastForm(Aircraft aircraft) : this()

		/// <summary>
		/// </summary>
		public LDNDForecastForm(Aircraft aircraft, AverageUtilization averageUtilization) : this()
		{
			_aircraft = aircraft;
			_averageUtilization = averageUtilization;

			UpdateInformation();
		}

		#endregion


		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			_frame = GlobalObjects.CasEnvironment.BaseComponents.FirstOrDefault(i =>
				i.ParentAircraftId == _aircraft.ItemId && Equals(i.BaseComponentType, BaseComponentType.Frame));
			_averageUtilization = _frame.AverageUtilization;

			lifelengthViewerCurrent.Lifelength = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_aircraft);
			if (radioButtonCurrentUtil.Checked)
			{
				var current = _frame.AverageUtilization;
				numericUpDownHours.Value = (decimal)current.Hours;
				numericUpDownCycles.Value = (decimal)current.Cycles;

				dateTimePickerForecastDate.Enabled = false;
				numericUpDownCycles.Enabled = false;
				numericUpDownHours.Enabled = false;

				//var current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_aircraft);
				//_averageUtilization.HoursPerDay = (double) current.Hours / (double) current.Days;
				//_averageUtilization.CyclesPerDay = (double) current.Hours / (double) current.Cycles;
			}
		}

		#endregion

		#region private AverageUtilization GetAverageUtilization()

		private AverageUtilization GetAverageUtilization()
		{
			double eps = 0.00000001;
			double hours = (double) numericUpDownHours.Value;
			double cycles = (double) numericUpDownCycles.Value;

			if (numericUpDownHours.Value >= 24)
			{
				MessageBox.Show(numericUpDownHours.Value + ". Invalid value",
					(string) new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return null;
			}

			if (numericUpDownHours.Value >= 744)
			{
				MessageBox.Show(numericUpDownHours.Value + ". Invalid value",
					(string) new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
			DialogResult = DialogResult.OK;
			_averageUtilization = GetAverageUtilization();
			this.Close();
		}

		#endregion

		private void RadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioButtonCurrentUtil.Checked)
			{
				dateTimePickerForecastDate.Enabled = false;
				numericUpDownCycles.Enabled = false;
				numericUpDownHours.Enabled = false;

				var current = _frame.AverageUtilization;
				numericUpDownHours.Value = (decimal)current.Hours;
				numericUpDownCycles.Value = (decimal)current.Cycles;
			}
			else if (radioButtonCustom.Checked)
			{
				dateTimePickerForecastDate.Enabled = true;
				numericUpDownCycles.Enabled = true;
				numericUpDownHours.Enabled = true;
				CalculateUtilizationByDate();
			}
			else if (radioButtonLast7Days.Checked)
			{
				dateTimePickerForecastDate.Enabled = false;
				numericUpDownCycles.Enabled = true;
				numericUpDownHours.Enabled = true;

				var flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsByAircraftId(_aircraft.ItemId);
				var last = GlobalObjects.AircraftFlightsCore.GetLastAircraftFlight(_aircraft.ItemId);

				var lastDate = last.FlightDate.Date;
				var  lastSevenDate = lastDate.AddDays(-7);
				var find = flights.Where(i =>
					i.AtlbRecordType == AtlbRecordType.Flight && i.FlightDate <= lastDate &&
					i.FlightDate >= lastSevenDate);

				numericUpDownCycles.Value = find.Count();
				numericUpDownHours.Value = (decimal) (find.Sum(i => i.FlightTime.TotalMinutes)/60);


			}
		}

		#region private void DateTimePickerForecastDate_ValueChanged(object sender, System.EventArgs e)

		private void DateTimePickerForecastDate_ValueChanged(object sender, EventArgs e)
		{
			CalculateUtilizationByDate();
		}

		#endregion

		#region private void CalculateUtilizationByDate()

		private void CalculateUtilizationByDate()
		{
			Lifelength baseDetailLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_frame);

			//if (dateTimePickerForecastDate.Value <= DateTime.Today)
			//{
			//	//если дата прогноза меньше сегодняшней, то выводиться зписанная наработка на эту дату
			//	lifelengthViewer_ForecastResource.Lifelength =
			//		GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(_frame, dateTimePickerForecastDate.Value);
			//	Lifelength different = new Lifelength(lifelengthViewer_ForecastResource.Lifelength);
			//	different.Substract(baseDetailLifeLenght);
			//	lifelengthViewerDifferentSource.Lifelength = different;
			//}
			//else
			//{
				//если дата прогноза выше сегодняшней, то сначала вычисляется
				//наработка на сегодняшний день, а к ней добавляется среднепрогнозируемая наработка
				//между сегодняшним днем и днем прогноза

				//если не задана сердняя утилизация, то прогноз строить нельзя
				AverageUtilization au = GetAverageUtilization();
				if (au == null) return;

				Lifelength average = AnalystHelper.GetUtilization(au, Calculator.GetDays(DateTime.Today, dateTimePickerForecastDate.Value));
				lifelengthViewerDifferentSource.Lifelength = average;
				baseDetailLifeLenght.Add(average);
				lifelengthViewer_ForecastResource.Lifelength = baseDetailLifeLenght;
			//}
		}

		#endregion
		
		#region private void numericUpDown_ValueChanged(object sender, EventArgs e)

		private void numericUpDown_ValueChanged(object sender, EventArgs e)
		{
			numericUpDown1.Value = numericUpDownHours.Value / numericUpDownCycles.Value;
			CalculateUtilizationByDate();
			
		}

		#endregion

	}
}
