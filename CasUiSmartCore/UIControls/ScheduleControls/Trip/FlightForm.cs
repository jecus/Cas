using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary.DataGridViewElements;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls.Trip
{
	public partial class FlightForm : MetroForm
	{
		#region Fields

		private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

		private CommonCollection<FlightNumberPeriod> _initialFlightNumberArray = new CommonCollection<FlightNumberPeriod>();

		private ATLB _atlb;
		private Aircraft _currentAircraft;

		private Rectangle _rectangle;
		private DateTimePicker takeOffPicker = new DateTimePicker();
		private DateTimePicker LDGPicker = new DateTimePicker();
		
		#endregion

		#region Constructor

		public FlightForm()
		{
			InitializeComponent();
		}

		public FlightForm(ATLB atlb, Aircraft currentAircraft) : this()
		{
			_atlb = atlb;
			_currentAircraft = currentAircraft;

			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
			UpdateInformation();
		}

		#endregion

		#region private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)

		private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			comboBox1.Items.Clear();
			comboBox1.Items.AddRange(_initialFlightNumberArray.OrderBy(f => f.FlightNo).ToArray());
		}

		#endregion

		#region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
		{
			_initialFlightNumberArray.Clear();

			try
			{
				var flights = GlobalObjects.AircraftFlightsCore.GetAllFlightNumbers();
				_initialFlightNumberArray.AddRange(flights.SelectMany(f => f.FlightNumberPeriod));
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while load records", exception);
			}
		}

		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			takeOffPicker.Format = DateTimePickerFormat.Custom;
			takeOffPicker.CustomFormat = "HH:mm";
			takeOffPicker.ShowUpDown = true;
			takeOffPicker.Visible = false;

			LDGPicker.Format = DateTimePickerFormat.Custom;
			LDGPicker.CustomFormat = "HH:mm";
			LDGPicker.ShowUpDown = true;
			LDGPicker.Visible = false;

			dataGridViewFlights.Controls.Add(takeOffPicker);
			dataGridViewFlights.Controls.Add(LDGPicker);

			takeOffPicker.TextChanged += TakeOffPicker_TextChanged;
			LDGPicker.TextChanged += LDGPicker_TextChanged;

			_animatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void LDGPicker_TextChanged(object sender, EventArgs e)

		private void LDGPicker_TextChanged(object sender, EventArgs e)
		{
			dataGridViewFlights.CurrentCell.Value = LDGPicker.Text;
		}

		#endregion

		#region private void TakeOffPicker_TextChanged(object sender, EventArgs e)

		private void TakeOffPicker_TextChanged(object sender, EventArgs e)
		{
			dataGridViewFlights.CurrentCell.Value = takeOffPicker.Text;
		}

		#endregion

		#region private void dataGridViewFlights_CellClick(object sender, DataGridViewCellEventArgs e)

		private void dataGridViewFlights_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			switch (dataGridViewFlights.Columns[e.ColumnIndex].Name)
			{
				case "ColumnTakeOff":
					_rectangle = dataGridViewFlights.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
					takeOffPicker.Size = new Size(_rectangle.Width, _rectangle.Height);
					takeOffPicker.Location = new Point(_rectangle.X, _rectangle.Y);
					takeOffPicker.Visible = true;
					var value = dataGridViewFlights[e.ColumnIndex, e.RowIndex].Value as string;
					takeOffPicker.Value = DateTime.Parse(value);
					break;
				case "ColumnLDG":
					_rectangle = dataGridViewFlights.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
					LDGPicker.Size = new Size(_rectangle.Width, _rectangle.Height);
					LDGPicker.Location = new Point(_rectangle.X, _rectangle.Y);
					LDGPicker.Visible = true;
					var value1 = dataGridViewFlights[e.ColumnIndex, e.RowIndex].Value as string;
					LDGPicker.Value = DateTime.Parse(value1);
					break;
			}
		}

		#endregion

		#region private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(comboBox1.SelectedItem == null)
				return;

			dataGridViewFlights.Rows.Clear();

			var flightPeriod = comboBox1.SelectedItem as FlightNumberPeriod;

			var row = new DataGridViewRow { Tag = flightPeriod };

			DataGridViewCell check = new DataGridViewCheckBoxCell { Value = true };
			DataGridViewCell flightNo = new DataGridViewTextBoxCell { Value = flightPeriod.FlightNo };
			DataGridViewCell from = new DataGridViewTextBoxCell { Value = flightPeriod.StationFrom, Tag = flightPeriod.StationFrom };
			DataGridViewCell to = new DataGridViewTextBoxCell { Value = flightPeriod.StationTo, Tag = flightPeriod.StationTo };
			DataGridViewCell flightDate = new DataGridViewCalendarCell { Value = DateTime.Today };
			DataGridViewCell arrivalDate = new DataGridViewTextBoxCell { Value = flightPeriod.DepartureDate.Date.AddMinutes(flightPeriod.PeriodTo).ToString("HH:mm") };
			DataGridViewCell departuteDate = new DataGridViewTextBoxCell { Value = flightPeriod.DepartureDate.Date.AddMinutes(flightPeriod.PeriodFrom).ToString("HH:mm") };

			row.Cells.AddRange(check, flightNo, from, to, flightDate, departuteDate, arrivalDate);
			dataGridViewFlights.Rows.Add(row);
		}

		#endregion

		#region private void dataGridViewFlights_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)

		private void dataGridViewFlights_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
		{
			takeOffPicker.Visible = false;
			LDGPicker.Visible = false;
		}

		#endregion

		#region private void dataGridViewFlights_Scroll(object sender, ScrollEventArgs e)

		private void dataGridViewFlights_Scroll(object sender, ScrollEventArgs e)
		{
			takeOffPicker.Visible = false;
			LDGPicker.Visible = false;
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			var items = dataGridViewFlights.Rows.Cast<DataGridViewRow>().ToList();

			foreach (var row in items)
			{
				var flightPeriod = row.Tag as FlightNumberPeriod;

				var includeRow = (bool) row.Cells[0].Value;
				if(!includeRow)
					continue;

				var flightNo = row.Cells[1].Value as FlightNum;
				var from = row.Cells[2].Tag as AirportsCodes;
				var to = row.Cells[3].Tag as AirportsCodes;
				var flightDate = (DateTime)row.Cells[4].Value;
				var arrival = (int)TimeSpan.Parse(row.Cells[5].Value.ToString()).TotalMinutes;
				var departure = (int)TimeSpan.Parse(row.Cells[6].Value.ToString()).TotalMinutes;

				var flight = new AircraftFlight();
				flight.ParentATLB = _atlb;
				flight.ATLBId = _atlb.ItemId;
				flight.AircraftId = _currentAircraft.ItemId;

				GlobalObjects.AircraftFlightsCore.GetAircraftInformationToFlight(_currentAircraft.ItemId, flight);

				flight.DistanceMeasure = Measure.Kilometres;
				flight.FlightDate = flightDate;
				flight.FlightNumber = flightNo;
				flight.StationFromId = from;
				flight.StationToId = to;
				flight.TakeOffTime = arrival;
				flight.LDGTime = departure;
				flight.OutTime = arrival;
				flight.InTime = departure;
				flight.FlightAircraftCode = flightPeriod.FlightAircraftCode;
				flight.FlightCategory = flightPeriod.FlightCategory;
				flight.FlightType = flightPeriod.FlightType;


				GlobalObjects.AircraftFlightsCore.AddAircraftFlight(flight);
			}

			DialogResult = DialogResult.OK;
		}

		#endregion

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			if (comboBox1.SelectedItem == null)
				return;

			var items = dataGridViewFlights.Rows.Cast<DataGridViewRow>().ToList();

			foreach (var item in items)
				item.Cells[4].Value = dateTimePicker1.Value;
		}

		private void comboBox1_TextUpdate(object sender, EventArgs e)
		{
			var _filterString = comboBox1.Text;

			comboBox1.Items.Clear();

			foreach (var dic in _initialFlightNumberArray.Where(i => i.ToString().ToLowerInvariant().Contains(_filterString.ToLowerInvariant())))
				comboBox1.Items.Add(dic);

			comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
			comboBox1.SelectionStart = _filterString.Length;
		}
	}
}
