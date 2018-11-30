using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.UIControls.Auxiliary.Events;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls
{
	public partial class FlightNumberPeriodControl : UserControl
	{

		#region Fields

		private FlightNumberPeriod _flightNumberPeriod;
		public List<SchedulePeriods> SchedulePeriods;
		private readonly FlightNumberScreenType _screenType;

		#endregion

		#region Property

		public FlightNumberPeriod FlightNumberPeriod
		{
			get { return _flightNumberPeriod; }
			set { _flightNumberPeriod = value; }
		}

		#endregion

		#region Constructor

		public FlightNumberPeriodControl(FlightNumberScreenType screenType)
		{
			_screenType = screenType;
			InitializeComponent();
		}

		#endregion

		#region public void UpdateInformation()

		public void UpdateInformation()
		{
			if (_screenType == FlightNumberScreenType.UnSchedule)
			{
				dateTimePickerDep.ValueChanged += dateTimePickerDep_ValueChanged;

				label1.Visible = false;
				dateTimePickerArrival.Visible = false;
				radioButtonSummer.Visible = false;
				radioButtonWinter.Visible = false;
				checkMonday.Enabled = checkBoxFriday.Enabled = checkBoxSaturday.Enabled = checkBoxSunday.Enabled =
					checkBoxThursday.Enabled = checkBoxTuesday.Enabled = checkBoxWednesday.Enabled = checkBox1.Enabled = false;
			}

			dateTimePickerTakeOff.Value = _flightNumberPeriod.DepartureDate.Date.AddMinutes(_flightNumberPeriod.PeriodFrom);
			dateTimePickerLDG.Value = _flightNumberPeriod.DepartureDate.Date.AddMinutes(_flightNumberPeriod.PeriodTo);
			dateTimePickerArrival.Value = _flightNumberPeriod.ArrivalDate;
			dateTimePickerDep.Value = _flightNumberPeriod.DepartureDate;
			checkMonday.Checked = _flightNumberPeriod.IsMonday;
			checkBoxThursday.Checked = _flightNumberPeriod.IsThursday;
			checkBoxWednesday.Checked = _flightNumberPeriod.IsWednesday;
			checkBoxTuesday.Checked = _flightNumberPeriod.IsTuesday;
			checkBoxFriday.Checked = _flightNumberPeriod.IsFriday;
			checkBoxSaturday.Checked = _flightNumberPeriod.IsSaturday;
			checkBoxSunday.Checked = _flightNumberPeriod.IsSunday;

			documentControl1.CurrentDocument = _flightNumberPeriod.Document;
			documentControl1.Added += DocumentControl1_Added;
		}

		#endregion

		#region public void ApplyChanges()

		public void ApplyChanges()
		{
			_flightNumberPeriod.PeriodFrom = (Int32)dateTimePickerTakeOff.Value.TimeOfDay.TotalMinutes;
			_flightNumberPeriod.PeriodTo = (Int32)dateTimePickerLDG.Value.TimeOfDay.TotalMinutes;
			_flightNumberPeriod.ArrivalDate = dateTimePickerArrival.Value.Date;
			_flightNumberPeriod.DepartureDate = dateTimePickerDep.Value.Date;
			_flightNumberPeriod.IsMonday = checkMonday.Checked;
			_flightNumberPeriod.IsThursday = checkBoxThursday.Checked;
			_flightNumberPeriod.IsWednesday = checkBoxWednesday.Checked;
			_flightNumberPeriod.IsTuesday = checkBoxTuesday.Checked;
			_flightNumberPeriod.IsFriday = checkBoxFriday.Checked;
			_flightNumberPeriod.IsSaturday = checkBoxSaturday.Checked;
			_flightNumberPeriod.IsSunday = checkBoxSunday.Checked;

			//Определяем период
			//var winterPeriod = SchedulePeriods.Where(p => p.Schedule == Schedule.Winter).FirstOrDefault(p =>
			//													   p.From.Month < _flightNumberPeriod.DepartureDate.Month ||
			//													  (p.From.Month == _flightNumberPeriod.DepartureDate.Month && p.From.Day <= _flightNumberPeriod.DepartureDate.Day) &&
			//													   p.To.Month > _flightNumberPeriod.ArrivalDate.Month ||
			//													  (p.To.Month == _flightNumberPeriod.ArrivalDate.Month && p.To.Day >= _flightNumberPeriod.ArrivalDate.Day));

			//var summerPeriod = SchedulePeriods.Where(p => p.Schedule == Schedule.Summer).FirstOrDefault(p =>
			//                                                       p.From.Month < _flightNumberPeriod.DepartureDate.Month ||
			//                                                       (p.From.Month == _flightNumberPeriod.DepartureDate.Month && p.From.Day <= _flightNumberPeriod.DepartureDate.Day) &&
			//                                                       p.To.Month > _flightNumberPeriod.ArrivalDate.Month ||
			//                                                       (p.To.Month == _flightNumberPeriod.ArrivalDate.Month && p.To.Day >= _flightNumberPeriod.ArrivalDate.Day));

			var winterPeriod = SchedulePeriods.FirstOrDefault(p => p.Schedule == Schedule.Winter);
			var summerPeriod = SchedulePeriods.FirstOrDefault(p => p.Schedule == Schedule.Summer);

			if (_screenType == FlightNumberScreenType.Schedule)
			{
				if (winterPeriod != null)
				{
					var from = new DateTime(winterPeriod.From.Year - 1, winterPeriod.From.Month, winterPeriod.From.Day);

					if (from <= _flightNumberPeriod.DepartureDate &&
					    winterPeriod.To >= _flightNumberPeriod.DepartureDate &&
					    winterPeriod.From >= _flightNumberPeriod.ArrivalDate &&
					    winterPeriod.To >= _flightNumberPeriod.ArrivalDate)
					{
						_flightNumberPeriod.Schedule = Schedule.Winter;
						return;
					}
				}
				if (summerPeriod != null)
				{
					if (summerPeriod.From <= _flightNumberPeriod.DepartureDate &&
					    summerPeriod.To >= _flightNumberPeriod.DepartureDate &&
					    summerPeriod.From <= _flightNumberPeriod.ArrivalDate &&
					    summerPeriod.To >= _flightNumberPeriod.ArrivalDate)
					{
						_flightNumberPeriod.Schedule = Schedule.Summer;
						return;
					}
				}

				_flightNumberPeriod.Schedule = Schedule.Unknown;
			}
			else
			{
				if (winterPeriod != null)
				{
					var from = new DateTime(_flightNumberPeriod.DepartureDate.Year - 1, winterPeriod.From.Month, winterPeriod.From.Day);
					var to = new DateTime(_flightNumberPeriod.DepartureDate.Year, winterPeriod.To.Month, winterPeriod.To.Day);

					if (from <= _flightNumberPeriod.DepartureDate &&
					    to >= _flightNumberPeriod.DepartureDate)
					{
						_flightNumberPeriod.Schedule = Schedule.Winter;
						return;
					}
				}
				if (summerPeriod != null)
				{
					var from = new DateTime(_flightNumberPeriod.DepartureDate.Year, summerPeriod.From.Month, summerPeriod.From.Day);
					var to = new DateTime(_flightNumberPeriod.DepartureDate.Year, summerPeriod.To.Month, summerPeriod.To.Day);

					if (from <= _flightNumberPeriod.DepartureDate &&
					    to >= _flightNumberPeriod.DepartureDate)
					{
						_flightNumberPeriod.Schedule = Schedule.Summer;
						return;
					}
				}

				_flightNumberPeriod.Schedule = Schedule.Unknown;
			}
			
		}

		#endregion

		#region private void DocumentControl1_Added(object sender, EventArgs e)

		private void DocumentControl1_Added(object sender, EventArgs e)
		{
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Flight Schedule") as DocumentSubType;
			var newDocument = new Document
			{
				Parent = _flightNumberPeriod,
				ParentId = _flightNumberPeriod.ItemId,
				ParentTypeId = _flightNumberPeriod.SmartCoreObjectType.ItemId,
				DocType = DocumentType.Order,
				DocumentSubType = docSubType,
				IsClosed = true
			};

			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_flightNumberPeriod.Document = newDocument;
				documentControl1.CurrentDocument = newDocument;

			}
		}

		#endregion

		#region public bool GetChangeStatus()

		public bool GetChangeStatus()
		{
			return _flightNumberPeriod.PeriodFrom != (Int32)dateTimePickerTakeOff.Value.TimeOfDay.TotalMinutes ||
					_flightNumberPeriod.PeriodTo != (Int32)dateTimePickerLDG.Value.TimeOfDay.TotalMinutes ||
					_flightNumberPeriod.ArrivalDate != dateTimePickerArrival.Value ||
					_flightNumberPeriod.DepartureDate != dateTimePickerDep.Value ||
					_flightNumberPeriod.IsMonday != checkMonday.Checked ||
					_flightNumberPeriod.IsThursday != checkBoxThursday.Checked ||
					_flightNumberPeriod.IsWednesday != checkBoxWednesday.Checked ||
					_flightNumberPeriod.IsTuesday != checkBoxTuesday.Checked ||
					_flightNumberPeriod.IsFriday != checkBoxFriday.Checked ||
					_flightNumberPeriod.IsSaturday != checkBoxSaturday.Checked ||
					_flightNumberPeriod.IsSunday != checkBoxSunday.Checked;
		}

		#endregion

		#region private void dateTimePickerTakeOff_ValueChanged(object sender, EventArgs e)

		private void dateTimePickerTakeOff_ValueChanged(object sender, EventArgs e)
		{
			if (sender != dateTimePickerTakeOff && sender != dateTimePickerLDG)
				return;

			TimeSpan flightDifference =
				UsefulMethods.GetDifference(dateTimePickerLDG.Value.TimeOfDay,
					dateTimePickerTakeOff.Value.TimeOfDay);
			textFlight.Text =
				UsefulMethods.TimeToString(flightDifference);

			if (sender == dateTimePickerTakeOff) InvokeTakeOffTimeChanget(dateTimePickerTakeOff.Value);
			if (sender == dateTimePickerLDG) InvokeLDGTimeChanget(dateTimePickerLDG.Value);
		}

		#endregion

		#region private void linkLabelRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabelRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (Deleted != null)
				Deleted(this, EventArgs.Empty);
		}

			#endregion

		#region Event

		///
		/// Возникает при изменении времени взлета
		///</summary>
		[Category("Flight data")]
		[Description("Возникает при изменении времени взлета")]
		public event DateChangedEventHandler TakeOffTimeChanget;

		///<summary>
		/// Возникает при изменении времени посадки
		///</summary>
		[Category("Flight data")]
		[Description("Возникает при изменении времени посадки")]
		public event DateChangedEventHandler LDGTimeChanget;

		///<summary>
		/// Сигнализирует об изменении времени ввода в ангар
		///</summary>
		///<param name="e"></param>
		private void InvokeTakeOffTimeChanget(DateTime e)
		{
			DateChangedEventHandler handler = TakeOffTimeChanget;
			if (handler != null) handler(new DateChangedEventArgs(e));
		}

		///<summary>
		/// Сигнализирует об изменении времени посадки
		///</summary>
		///<param name="e"></param>
		private void InvokeLDGTimeChanget(DateTime e)
		{
			DateChangedEventHandler handler = LDGTimeChanget;
			if (handler != null) handler(new DateChangedEventArgs(e));
		}

		public event EventHandler Deleted;

		#endregion

		#region private void checkBox1_CheckedChanged(object sender, EventArgs e)

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			checkMonday.Checked = checkBoxFriday.Checked = checkBoxSaturday.Checked = checkBoxSunday.Checked =
				checkBoxThursday.Checked = checkBoxTuesday.Checked = checkBoxWednesday.Checked = checkBox1.Checked;
		}

		#endregion

		#region private void radioButton_CheckedChanged(object sender, EventArgs e)

		private void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonSummer.Checked)
			{
				var summerPeriod = SchedulePeriods.FirstOrDefault(s => s.Schedule == Schedule.Summer);
				if (summerPeriod != null)
				{
					dateTimePickerDep.Value = summerPeriod.From;
					dateTimePickerArrival.Value = summerPeriod.To;
				}
			}
			else
			{
				var winterPeriod = SchedulePeriods.FirstOrDefault(s => s.Schedule == Schedule.Winter);

				if (winterPeriod != null)
				{
					dateTimePickerDep.Value = winterPeriod.From.AddYears(-1);
					dateTimePickerArrival.Value = winterPeriod.To;
				}
			}
		}

		#endregion

		private void dateTimePickerDep_ValueChanged(object sender, EventArgs e)
		{
			checkMonday.Checked = checkBoxFriday.Checked = checkBoxSaturday.Checked = checkBoxSunday.Checked =
				checkBoxThursday.Checked = checkBoxTuesday.Checked = checkBoxWednesday.Checked = checkBox1.Checked = false;

			var dayofWeek = dateTimePickerDep.Value.DayOfWeek;

			if (dayofWeek == DayOfWeek.Monday)
				checkMonday.Checked = true;
			else if (dayofWeek == DayOfWeek.Tuesday)
				checkBoxTuesday.Checked = true;
			else if (dayofWeek == DayOfWeek.Wednesday)
				checkBoxWednesday.Checked = true;
			else if (dayofWeek == DayOfWeek.Thursday)
				checkBoxThursday.Checked = true;
			else if (dayofWeek == DayOfWeek.Friday)
				checkBoxFriday.Checked = true;
			else if (dayofWeek == DayOfWeek.Saturday)
				checkBoxSaturday.Checked = true;
			else if (dayofWeek == DayOfWeek.Sunday)
				checkBoxSunday.Checked = true;
		}
	}
}
