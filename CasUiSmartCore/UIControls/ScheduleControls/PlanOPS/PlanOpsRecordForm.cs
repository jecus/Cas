using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary.DataGridViewElements;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls.PlanOPS
{
	public partial class PlanOpsRecordForm : Form
	{
		#region Fields

		private Aircraft[] _aircrafts;
		private Aircraft _currentAircraft;
		private AircraftFlight aircraftFlightEdit;

		private readonly FlightPlanOpsRecords _planOpsRecord;
		private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

		private Rectangle _rectangle;
		private DateTimePicker takeOffPicker = new DateTimePicker();
		private DateTimePicker LDGPicker = new DateTimePicker();

		#endregion

		#region Constructor

		public PlanOpsRecordForm()
		{
			InitializeComponent();
		}

		public PlanOpsRecordForm(FlightPlanOpsRecords planOpsRecord) : this()
		{
			_planOpsRecord = planOpsRecord;
			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
		}

		#endregion

		private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			UpdateInformation();
		}

		private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
		{
			_animatedThreadWorker.ReportProgress(0, "Loading");

			var documents = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<DocumentDTO, Document>(new List<Filter>()
			{
				new Filter("ParentID",_planOpsRecord.ItemId),
				new Filter("ParentTypeId",SmartCoreType.FlightPlanOpsRecords.ItemId)
			});

			var reasonType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Flight Schedule(Reason)") as DocumentSubType;
			var delayType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Flight Schedule(Delay)") as DocumentSubType;
			var cancellatinType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Flight Schedule(Cancellation)") as DocumentSubType;

			_planOpsRecord.ReasonDocument = documents.FirstOrDefault(i => i.ParentId == _planOpsRecord.ItemId && i.DocumentSubType.Equals(reasonType));
			_planOpsRecord.DelayDocument = documents.FirstOrDefault(i => i.ParentId == _planOpsRecord.ItemId && i.DocumentSubType.Equals(delayType));
			_planOpsRecord.CancellationDocument = documents.FirstOrDefault(i => i.ParentId == _planOpsRecord.ItemId && i.DocumentSubType.Equals(cancellatinType));

			_animatedThreadWorker.ReportProgress(100, "Loading complete");
		}

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			_aircrafts = GlobalObjects.AircraftsCore.GetAllAircrafts().ToArray();

			delayComboBox.ReasonCategory = "Delay";
			reasonComboBoxCancel.ReasonCategory = "Cancel";
			reasonComboBox.ReasonCategory = "Reason";

			comboBoxAircrafts.Items.Clear();
			comboBoxAircrafts.Items.AddRange(_aircrafts);

			comboBoxStatus.Items.Clear();
			comboBoxStatus.Items.AddRange(OpsStatus.Items.ToArray());
			comboBoxStatus.SelectedItem = _planOpsRecord.Status;

			comboBoxAircraftExchange.Items.Clear();
			comboBoxAircraftExchange.Items.AddRange(_aircrafts);
			comboBoxAircraftExchange.Items.Add(Aircraft.Unknown);


			comboBoxAircraftExchange.SelectedIndexChanged -= comboBoxAircrafts_SelectedIndexChanged;
			comboBoxAircraftExchange.SelectedItem = _planOpsRecord.AircraftExchange;
			comboBoxAircrafts.SelectedItem = _planOpsRecord.Aircraft;
			comboBoxAircraftExchange.SelectedIndexChanged += comboBoxAircrafts_SelectedIndexChanged;

			delayComboBox.SelectedReason = _planOpsRecord.DelayReason;
			reasonComboBoxCancel.SelectedReason = _planOpsRecord.CancelReason;
			reasonComboBox.SelectedReason = _planOpsRecord.Reason;

			textBoxRemarks.Text = _planOpsRecord.Remarks;
			textBoxHiddenRemarks.Text = _planOpsRecord.HiddenRemarks;

			var period = _planOpsRecord.FlightTrackRecord.FlightNumberPeriod;

			dateTimePickerTakeOffS.Value = period.DepartureDate.Date.AddMinutes(period.PeriodFrom);
			dateTimePickerLDGS.Value = period.DepartureDate.Date.AddMinutes(period.PeriodTo);

			checkBox1.Checked = _planOpsRecord.IsDispatcherEdit;
			dateTimePickerTakeOffD.Enabled = checkBox1.Checked;

			checkBox2.Checked = _planOpsRecord.IsDispatcherEditLdg;
			dateTimePickerLDGD.Enabled = checkBox1.Checked;

			dateTimePickerTakeOffD.Value = period.DepartureDate.Date.AddMinutes(_planOpsRecord.PeriodFrom);
			dateTimePickerLDGD.Value = period.DepartureDate.Date.AddMinutes(_planOpsRecord.PeriodTo);

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

			documentControlReason.CurrentDocument = _planOpsRecord.ReasonDocument;
			documentControlReason.Added += DocumentControlReason_Added;

			documentControlDelay.CurrentDocument = _planOpsRecord.DelayDocument;
			documentControlDelay.Added += DocumentControlDelay_Added;

			documentControlCancellation.CurrentDocument = _planOpsRecord.CancellationDocument;
			documentControlCancellation.Added += DocumentControlCancellation_Added;


			documentControlFlight.Added += DocumentControlFlight_Added;
			takeOffPicker.TextChanged += TakeOffPicker_TextChanged;
			LDGPicker.TextChanged += LDGPicker_TextChanged;
		}

		#endregion

		#region public bool ValidateData(out string message)
		/// <summary>
		/// Возвращает значение, показывающее является ли значение элемента управления допустимым
		/// </summary>
		/// <returns></returns>
		public bool ValidateData(out string message)
		{
			message = "";

			if (comboBoxAircrafts.SelectedItem == null)
			{
				if (message != "")
					message += "\n";
				message += "Not set Aircraft";
				return false;
			}

			return true;
		}

		#endregion

		#region private bool GetChangeStatus()

		/// <summary>
		/// Возвращает значение, показывающее были ли изменения в данном элементе управления
		/// </summary>
		/// <returns></returns>
		private bool GetChangeStatus()
		{
			// Проверяем, изменены ли поля WestAircraft
			return _planOpsRecord.Aircraft != comboBoxAircrafts.SelectedItem as Aircraft ||
				   _planOpsRecord.AircraftExchange != comboBoxAircraftExchange.SelectedItem as Aircraft ||
				   delayComboBox.SelectedReason != _planOpsRecord.DelayReason ||
				   reasonComboBoxCancel.SelectedReason != _planOpsRecord.CancelReason ||
			       _planOpsRecord.PeriodFrom != (Int32)dateTimePickerTakeOffD.Value.TimeOfDay.TotalMinutes ||
			       _planOpsRecord.PeriodTo != (Int32)dateTimePickerLDGD.Value.TimeOfDay.TotalMinutes;
		}

		#endregion

		#region public void ApplyChanges()

		public void ApplyChanges()
		{
			_planOpsRecord.PeriodFrom = (Int32)dateTimePickerTakeOffD.Value.TimeOfDay.TotalMinutes;
			_planOpsRecord.PeriodTo = (Int32)dateTimePickerLDGD.Value.TimeOfDay.TotalMinutes;

			_planOpsRecord.DelayReason = delayComboBox.SelectedReason;
			_planOpsRecord.CancelReason = reasonComboBoxCancel.SelectedReason;
			_planOpsRecord.Reason = reasonComboBox.SelectedReason;

			_planOpsRecord.Remarks = textBoxRemarks.Text;
			_planOpsRecord.HiddenRemarks = textBoxHiddenRemarks.Text;
			_planOpsRecord.IsDispatcherEdit = checkBox1.Checked;
			_planOpsRecord.IsDispatcherEditLdg = checkBox2.Checked;

			_planOpsRecord.ParentFlightId = aircraftFlightEdit.ItemId;

			_planOpsRecord.Status = comboBoxStatus.SelectedItem as OpsStatus;

			if (comboBoxAircrafts.SelectedItem != null)
			{
				var aircraft = comboBoxAircrafts.SelectedItem as Aircraft;
				_planOpsRecord.Aircraft = aircraft;
				_planOpsRecord.AircraftId = aircraft.ItemId;
			}
			if (comboBoxAircraftExchange.SelectedItem != null)
			{
				var aircraftExchange = comboBoxAircraftExchange.SelectedItem as Aircraft;
				_planOpsRecord.AircraftExchange = aircraftExchange;
				_planOpsRecord.AircraftExchangeId = aircraftExchange.ItemId;
			}

		}

		#endregion

		#region private void PlanOpsRecordForm_Load(object sender, System.EventArgs e)

		private void PlanOpsRecordForm_Load(object sender, EventArgs e)
		{
			_animatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void dateTimePickerTakeOffS_ValueChanged(object sender, EventArgs e)

		private void dateTimePickerTakeOffS_ValueChanged(object sender, EventArgs e)
		{
			if (sender != dateTimePickerTakeOffS && sender != dateTimePickerLDGS)
				return;

			var flightDifference = UsefulMethods.GetDifference(dateTimePickerLDGS.Value.TimeOfDay, dateTimePickerTakeOffS.Value.TimeOfDay);
			textFlightS.Text = UsefulMethods.TimeToString(flightDifference);
		}

		#endregion

		#region private void dateTimePickerTakeOffD_ValueChanged(object sender, EventArgs e)

		private void dateTimePickerTakeOffD_ValueChanged(object sender, EventArgs e)
		{
			if (sender != dateTimePickerTakeOffD && sender != dateTimePickerLDGD)
				return;

			var flightDifference = UsefulMethods.GetDifference(dateTimePickerLDGD.Value.TimeOfDay, dateTimePickerTakeOffD.Value.TimeOfDay);
			textFlightD.Text = UsefulMethods.TimeToString(flightDifference);
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			string message;
			if (!ValidateData(out message))
			{
				message += "\nAbort operation";
				MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				if (aircraftFlightEdit != null)
				{
					var items = dataGridViewFlights.Rows.Cast<DataGridViewRow>().ToList();

					foreach (var row in items)
					{
						if((bool)row.Cells[0].Value == false)
							continue;

						var arrival = (int)TimeSpan.Parse(row.Cells[6].Value.ToString()).TotalMinutes;
						var departure = (int)TimeSpan.Parse(row.Cells[7].Value.ToString()).TotalMinutes;
						aircraftFlightEdit.FlightNumber = row.Cells[1].Value as FlightNum;
						aircraftFlightEdit.PageNo = row.Cells[2].Value.ToString();
						aircraftFlightEdit.StationFromId = row.Cells[3].Tag as AirportsCodes;
						aircraftFlightEdit.StationToId = row.Cells[4].Tag as AirportsCodes;
						aircraftFlightEdit.TakeOffTime = arrival;
						aircraftFlightEdit.LDGTime = departure;
						aircraftFlightEdit.OutTime = arrival;
						aircraftFlightEdit.InTime = departure;
						aircraftFlightEdit.DelayReason = delayComboBox.SelectedReason;
						aircraftFlightEdit.CancelReason = reasonComboBoxCancel.SelectedReason;

						GlobalObjects.CasEnvironment.NewKeeper.Save(aircraftFlightEdit);

						if (_planOpsRecord.ParentFlight != null && _planOpsRecord.ParentFlight.ItemId != aircraftFlightEdit.ItemId)
						{
							if (_planOpsRecord.ParentFlight.Document != null)
								GlobalObjects.CasEnvironment.Manipulator.Delete(_planOpsRecord.ParentFlight.Document);

							GlobalObjects.AircraftFlightsCore.Delete(_planOpsRecord.ParentFlight);
						}

						_planOpsRecord.ParentFlight = aircraftFlightEdit;

						if (aircraftFlightEdit.Document?.ParentId <= 0)
						{
							aircraftFlightEdit.Document.ParentId = aircraftFlightEdit.ItemId;
							GlobalObjects.CasEnvironment.NewKeeper.Save(aircraftFlightEdit.Document);
						}
					}
				}

				ApplyChanges();
				GlobalObjects.CasEnvironment.NewKeeper.Save(_planOpsRecord);
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}
		}

		#endregion

		#region private void buttonDelete_Click(object sender, EventArgs e)

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#region private void comboBoxAircrafts_SelectedIndexChanged(object sender, EventArgs e)

		private void comboBoxAircrafts_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxAircrafts.SelectedItem == null && comboBoxAircraftExchange.SelectedItem == null)
			{
				documentControlFlight.Visible = false;
				return;
			}

			documentControlFlight.Visible = true;

			if (comboBoxAircraftExchange.SelectedItem != null)
			{
				var a = comboBoxAircraftExchange.SelectedItem as Aircraft;
				if(a == Aircraft.Unknown)
					_currentAircraft = comboBoxAircrafts.SelectedItem as Aircraft;
				else  _currentAircraft = a;
			}
			else if (comboBoxAircrafts.SelectedItem != null)
				_currentAircraft = comboBoxAircrafts.SelectedItem as Aircraft;

			_animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted -= BackgroundWorkerRunWorkerLoadCompleted;
			_animatedThreadWorker.DoWork += _animatedThreadWorker_DoLoadFlight;
			_animatedThreadWorker.RunWorkerCompleted += _animatedThreadWorker_DoLoadFlightCompleted;
			_animatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void _animatedThreadWorker_DoLoadFlightCompleted(object sender, RunWorkerCompletedEventArgs e)

		private void _animatedThreadWorker_DoLoadFlightCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if(aircraftFlightEdit == null)
				return;

			documentControlFlight.CurrentDocument = aircraftFlightEdit.Document;

			dataGridViewFlights.Rows.Clear();
			var row = new DataGridViewRow { Tag = aircraftFlightEdit };

			DataGridViewCell check = new DataGridViewCheckBoxCell { Value = _planOpsRecord.ParentFlightId > 0 };
			DataGridViewCell flightNo = new DataGridViewTextBoxCell { Value = aircraftFlightEdit.FlightNumber };
			DataGridViewCell pageNo = new DataGridViewTextBoxCell { Value = aircraftFlightEdit.PageNo };
			DataGridViewCell from = new DataGridViewTextBoxCell { Value = aircraftFlightEdit.StationFromId, Tag = aircraftFlightEdit.StationFromId };
			DataGridViewCell to = new DataGridViewTextBoxCell { Value = aircraftFlightEdit.StationToId, Tag = aircraftFlightEdit.StationToId };
			DataGridViewCell flightDate = new DataGridViewCalendarCell { Value = aircraftFlightEdit.FlightDate };
			DataGridViewCell arrivalDate = new DataGridViewTextBoxCell { Value = aircraftFlightEdit.FlightDate.Date.AddMinutes(aircraftFlightEdit.LDGTime).ToString("HH:mm") };
			DataGridViewCell departuteDate = new DataGridViewTextBoxCell { Value = aircraftFlightEdit.FlightDate.Date.AddMinutes(aircraftFlightEdit.TakeOffTime).ToString("HH:mm") };

			row.Cells.AddRange(check, flightNo, pageNo, from, to, flightDate, departuteDate, arrivalDate);
			dataGridViewFlights.Rows.Add(row);
		}


		#endregion

		#region private void _animatedThreadWorker_DoLoadFlight(object sender, DoWorkEventArgs e)

		private void _animatedThreadWorker_DoLoadFlight(object sender, DoWorkEventArgs e)
		{
			aircraftFlightEdit = GlobalObjects.CasEnvironment.NewLoader.GetObject<AircraftFlightDTO, AircraftFlight>(new List<Filter>()
			{
				new Filter("AircraftId",_currentAircraft.ItemId),
				new Filter("FlightNumberId", _planOpsRecord.FlightTrackRecord.FlightNo.ItemId),
				new Filter("StationFromId",_planOpsRecord.FlightTrackRecord.StationFrom.ItemId),
				new Filter("StationToId",_planOpsRecord.FlightTrackRecord.StationTo.ItemId ),
				new Filter("FlightDate",_planOpsRecord.Date)
			});
			if (aircraftFlightEdit != null)
			{
				aircraftFlightEdit.ParentATLB = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<ATLBDTO,ATLB>(aircraftFlightEdit.ATLBId);
				aircraftFlightEdit.Document = GlobalObjects.CasEnvironment.NewLoader.GetObject<DocumentDTO,Document>(new List<Filter>
				{
					new Filter("ParentID",aircraftFlightEdit.ItemId),
					new Filter("ParentTypeId",SmartCoreType.AircraftFlight.ItemId)
				}, true);

			}
			else
			{
				var atlb = GlobalObjects.AircraftFlightsCore.GetATLBsByAircraftId(_currentAircraft.ItemId).FirstOrDefault(a => a.AtlbStatus == AtlbStatus.Opened);

				aircraftFlightEdit = new AircraftFlight();
				aircraftFlightEdit.ParentATLB = atlb;
				aircraftFlightEdit.ATLBId = atlb.ItemId;
				aircraftFlightEdit.AircraftId = _currentAircraft.ItemId;

				aircraftFlightEdit.PageNo = GlobalObjects.AircraftFlightsCore.GetNextPageNoFromAtlb(atlb.ItemId, _currentAircraft.ItemId);

				//Если полет Schedule то берем дату на день прогноза, если Unschedule то берем дату вылета
				if(_planOpsRecord.FlightTrackRecord.FlightType == FlightType.Schedule)
					aircraftFlightEdit.FlightDate = _planOpsRecord.Date;
				else aircraftFlightEdit.FlightDate = _planOpsRecord.FlightTrackRecord.FlightNumberPeriod.DepartureDate;

				aircraftFlightEdit.DistanceMeasure = Measure.Kilometres;
				aircraftFlightEdit.FlightNumber = _planOpsRecord.FlightTrackRecord.FlightNo;
				aircraftFlightEdit.StationFromId = _planOpsRecord.FlightTrackRecord.StationFrom;
				aircraftFlightEdit.StationToId = _planOpsRecord.FlightTrackRecord.StationTo;
				aircraftFlightEdit.FlightAircraftCode = _planOpsRecord.FlightTrackRecord.FlightAircraftCode;
				aircraftFlightEdit.FlightCategory = _planOpsRecord.FlightTrackRecord.FlightCategory;
				aircraftFlightEdit.FlightType = _planOpsRecord.FlightTrackRecord.FlightType;

				if (_planOpsRecord.IsDispatcherEditLdg)
					aircraftFlightEdit.LDGTime = (int) dateTimePickerLDGD.Value.TimeOfDay.TotalMinutes;
				else aircraftFlightEdit.LDGTime = _planOpsRecord.FlightTrackRecord.FlightNumberPeriod.PeriodTo;

				if (_planOpsRecord.IsDispatcherEdit)
					aircraftFlightEdit.TakeOffTime = (int)dateTimePickerTakeOffD.Value.TimeOfDay.TotalMinutes;
				else aircraftFlightEdit.TakeOffTime = _planOpsRecord.FlightTrackRecord.FlightNumberPeriod.PeriodFrom;


			}
		}

		#endregion

		#region private void LDGPicker_TextChanged(object sender, EventArgs e)

		private void LDGPicker_TextChanged(object sender, EventArgs e)
		{
			dataGridViewFlights.CurrentCell.Value = LDGPicker.Text;
			if(!checkBox2.Checked)
				dateTimePickerLDGD.Value = LDGPicker.Value;
		}

		#endregion

		#region private void TakeOffPicker_TextChanged(object sender, EventArgs e)

		private void TakeOffPicker_TextChanged(object sender, EventArgs e)
		{
			dataGridViewFlights.CurrentCell.Value = takeOffPicker.Text;
			if (!checkBox1.Checked)
				dateTimePickerTakeOffD.Value = takeOffPicker.Value;
		}

		#endregion

		#region private void dataGridViewFlights_CellClick(object sender, DataGridViewCellEventArgs e)

		private void dataGridViewFlights_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

		#region private void dataGridViewFlights_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)

		private void dataGridViewFlights_ColumnWidthChanged_1(object sender, DataGridViewColumnEventArgs e)
		{
			takeOffPicker.Visible = false;
			LDGPicker.Visible = false;
		}

		#endregion

		#region private void dataGridViewFlights_Scroll(object sender, ScrollEventArgs e)

		private void dataGridViewFlights_Scroll_1(object sender, ScrollEventArgs e)
		{
			takeOffPicker.Visible = false;
			LDGPicker.Visible = false;
		}


		#endregion

		private void DocumentControlFlight_Added(object sender, EventArgs e)
		{
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("ATLB") as DocumentSubType;
			var newDocument = new Document
			{
				Parent = aircraftFlightEdit,
				ParentId = aircraftFlightEdit.ItemId,
				ParentTypeId = aircraftFlightEdit.SmartCoreObjectType.ItemId,
				DocType = DocumentType.TechnicalRecords,
				DocumentSubType = docSubType,
				IsClosed = true,
				ContractNumber = $"{aircraftFlightEdit.PageNo}",
				Description = aircraftFlightEdit.ParentATLB.ATLBNo,
				IssueDateValidFrom = aircraftFlightEdit.FlightDate
			};

			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				aircraftFlightEdit.Document = newDocument;
				documentControlFlight.CurrentDocument = newDocument;

			}
		}

		private void DocumentControlReason_Added(object sender, EventArgs e)
		{
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Flight Schedule(Reason)") as DocumentSubType;
			var newDocument = new Document
			{
				Parent = _planOpsRecord,
				ParentId = _planOpsRecord.ItemId,
				ParentTypeId = _planOpsRecord.SmartCoreObjectType.ItemId,
				DocType = DocumentType.Report,
				DocumentSubType = docSubType,
				IssueDateValidFrom = _planOpsRecord.Date
			};

			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_planOpsRecord.ReasonDocument = newDocument;
				documentControlReason.CurrentDocument = newDocument;

			}
		}

		private void DocumentControlDelay_Added(object sender, EventArgs e)
		{
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Flight Schedule(Delay)") as DocumentSubType;
			var newDocument = new Document
			{
				Parent = _planOpsRecord,
				ParentId = _planOpsRecord.ItemId,
				ParentTypeId = _planOpsRecord.SmartCoreObjectType.ItemId,
				DocType = DocumentType.Order,
				DocumentSubType = docSubType,
				IssueDateValidFrom = _planOpsRecord.Date
			};

			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_planOpsRecord.DelayDocument = newDocument;
				documentControlDelay.CurrentDocument = newDocument;

			}
		}

		private void DocumentControlCancellation_Added(object sender, EventArgs e)
		{
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Flight Schedule(Cancellation)") as DocumentSubType;
			var newDocument = new Document
			{
				Parent = _planOpsRecord,
				ParentId = _planOpsRecord.ItemId,
				ParentTypeId = _planOpsRecord.SmartCoreObjectType.ItemId,
				DocType = DocumentType.Order,
				DocumentSubType = docSubType,
				IssueDateValidFrom = _planOpsRecord.Date
			};

			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_planOpsRecord.CancellationDocument = newDocument;
				documentControlCancellation.CurrentDocument = newDocument;

			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			dateTimePickerTakeOffD.Enabled = checkBox1.Checked;
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			dateTimePickerLDGD.Enabled = checkBox2.Checked;
		}
	}
}
