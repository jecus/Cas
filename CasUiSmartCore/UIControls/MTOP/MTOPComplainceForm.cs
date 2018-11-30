using System;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.MaintananceProgram;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.MTOP;

namespace CAS.UI.UIControls.MTOP
{
	public partial class MTOPComplainceForm : Form
	{
		private MTOPCheckRecord _checkRecord;
		private Aircraft _aircraft;
		private AverageUtilization _averageUtilization;

		#region Constructor

		public MTOPComplainceForm()
		{
			InitializeComponent();
		}

		public MTOPComplainceForm(MTOPCheck check, Aircraft aircraft, AverageUtilization averageUtilization) : this()
		{
			if (check == null)
				return;
			_aircraft = aircraft;
			_averageUtilization = averageUtilization;

			_checkRecord = new MTOPCheckRecord
			{
				RecordDate = DateTime.Today,
				CheckName = check.Name,
				GroupName = check.Group,
				CalculatedPerformanceSource =  check.NextPerformance.PerformanceSource,
				ParentId = check.ItemId
			};

			UpdateInformation();
		}

		public MTOPComplainceForm(MTOPCheckRecord check, Aircraft aircraft, AverageUtilization averageUtilization) : this()
		{
			if (check == null)
				return;
			_aircraft = aircraft;
			_checkRecord = check;
			_averageUtilization = averageUtilization;

			dateTimePicker1.ValueChanged -= dateTimePicker1_ValueChanged;
			UpdateInformation();
			dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
		}

		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			lifelengthViewer_LastCompliance.Lifelength = _checkRecord.CalculatedPerformanceSource;
			dateTimePicker1.Value = _checkRecord.RecordDate;
			checkBoxControlPoint.Checked = _checkRecord.IsControlPoint;
			textBox_Remarks.Text = _checkRecord.Remarks;
		}

		#endregion

		#region private void ApplyChanges()

		private void ApplyChanges()
		{
			_checkRecord.CalculatedPerformanceSource = lifelengthViewer_LastCompliance.Lifelength;
			_checkRecord.RecordDate = dateTimePicker1.Value;
			_checkRecord.IsControlPoint = checkBoxControlPoint.Checked;
			_checkRecord.Remarks = textBox_Remarks.Text;
			_checkRecord.AverageUtilization = _averageUtilization;
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			try
			{
				ApplyChanges();
				GlobalObjects.CasEnvironment.NewKeeper.Save(_checkRecord);
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}
		}

		#endregion

		#region private void button1_Click(object sender, EventArgs e)

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		#endregion

		#region private void dateTimePicker1_ValueChanged(object sender, EventArgs e)

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			dateTimePicker1.ValueChanged -= dateTimePicker1_ValueChanged;

			if (dateTimePicker1.Value < DateTimeExtend.GetCASMinDateTime())
				dateTimePicker1.Value = DateTimeExtend.GetCASMinDateTime();

			//_checkRecord.CalculatedPerformanceSource.Days = Calculator.GetDays(_aircraft.ManufactureDate, dateTimePicker1.Value);
			//lifelengthViewer_LastCompliance.Lifelength = _checkRecord.CalculatedPerformanceSource;

			lifelengthViewer_LastCompliance.Lifelength =
				GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(_aircraft, dateTimePicker1.Value);

			var flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsOnDate(_aircraft.ItemId, dateTimePicker1.Value);

			checkedListBox1.Items.Clear();
			checkedListBox1.Items.AddRange(flights.ToArray());

			dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
		}

		#endregion

		private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			var flight = checkedListBox1.Items[e.Index] as AircraftFlight;
			if (e.NewValue == CheckState.Checked)
			{
				lifelengthViewer_LastCompliance.Lifelength += flight.FlightTimeLifelength;
			}
			else if (e.NewValue == CheckState.Unchecked)
			{
				lifelengthViewer_LastCompliance.Lifelength -= flight.FlightTimeLifelength;
			}
		}
	}
}
