using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Events;
using CASTerms;
using EntityCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls.AircraftFlightLight
{
    ///<summary>
    ///</summary>
    public partial class FlightScreenLight : ScreenControl
    {
		#region Fields

		private AircraftFlight _currentFlight;
		private ATLB _currentAtlb;
		List<Discrepancy> discrepancies = new List<Discrepancy>();

		private string _lastFlightString = "Unknown";
		private string _lastAtlbString = "Unknown";
		private int _flightsOnPage;
		private int _flightsOnPageMax;
	    private AtlbRecordType _type;

	    #endregion

		#region Constructors

		#region private FlightScreen()
		///<summary>
		///</summary>
		private FlightScreenLight()
		{
			InitializeComponent();
		}
		#endregion

		#region public FlightScreen(AircraftFlight flight)
		///<summary>
		/// Создает страницу для отображения информации об одной директиве
		///</summary>
		/// <param name="flight">Директива</param>
		public FlightScreenLight(AircraftFlight flight)
			: this()
		{
			if (flight == null)
				throw new ArgumentNullException("flight", "Argument cannot be null");

			if (flight.AircraftId > 0)
			{
				_currentFlight = flight;
				CurrentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(flight.AircraftId);
			}
			else throw new ArgumentException("flight.AircraftId cannot be 0", "flight");

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWorkWithCreateFlight;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
		}
		#endregion

		#region public FlightScreen(ATLB atlb, Aircraft aircraft) : this()
		///<summary>
		/// Создает страницу для отображения информации об одной директиве
		///</summary>
		/// <param name="atlb">Директива</param>
		///<param name="aircraft"></param>
		public FlightScreenLight(ATLB atlb, Aircraft aircraft, AtlbRecordType type = AtlbRecordType.Flight) : this()
		{
			if (atlb == null)
				throw new ArgumentNullException("atlb", "Argument cannot be null");
			_currentAtlb = atlb;
			CurrentAircraft = aircraft;
			_type = type;

			#region ButtonPrintContextMenu

			//buttonPrintMenuStrip = new ContextMenuStrip();
			//itemPrintReportRecords = new ToolStripMenuItem { Text = "Records" };
			//itemPrintReportHistory = new ToolStripMenuItem { Text = "Compliance history" };
			//buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { itemPrintReportRecords, itemPrintReportHistory });

			//ButtonPrintMenuStrip = buttonPrintMenuStrip;
			#endregion

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWorkWithCreateFlight;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWorkWithCreateFlight;
		}

		#endregion

		#region public FlightScreen(Aircraft aircraft) : this()
		///<summary>
		/// Создает страницу для отображения информации об одной директиве
		///</summary>
		///<param name="aircraft"></param>
		public FlightScreenLight(Aircraft aircraft) : this()
		{
			CurrentAircraft = aircraft;

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWorkWithCreateFlight;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWorkWithCreateFlight;
		}

		#endregion

		#endregion

		#region Methods

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			labelTitle.Text = "Date as of: " +
					SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
					GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);

			labelDateAsOf.Text = "Current ATLB: " + _lastAtlbString +
								 " Previous Page No: " + _lastFlightString +
								 $" flights on page {_flightsOnPage}/{_flightsOnPageMax}";

			if (_currentFlight.ItemId > 0) buttonAddAtlb.Enabled = false;


			flightGeneralInformatonControl.AttachedObject = _currentFlight;
			discrepanciesList.Discrepancies = discrepancies;
			discrepanciesList._discrepanciesCount = 0;
			discrepanciesList.AttachedObject = _currentFlight;
			
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			AnimatedThreadWorker.ReportProgress(0, "load flight");

			try
			{
				_currentFlight = GlobalObjects.AircraftFlightsCore.LoadFullAircraftFlightById(_currentFlight.ItemId, CurrentAircraft.ItemId);
				if (_currentFlight.ParentATLB == null || _currentFlight.ParentATLB.ItemId != _currentFlight.ATLBId)
					_currentFlight.ParentATLB = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<ATLBDTO,ATLB>(_currentFlight.ATLBId);



			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while loading flight", ex);
			}

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			ATLB lastAtlb = null;
			AircraftFlight lastAircraftFlight;
			_lastFlightString = "Unknown";
			_lastAtlbString = "Unknown";
			_flightsOnPage = 0;
			_flightsOnPageMax = 0;

			var flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsByAircraftId(CurrentAircraft.ItemId);

			if (_currentFlight.ATLBId > 0)
			{
				lastAtlb = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<ATLBDTO,ATLB>(_currentFlight.ATLBId);
				if (lastAtlb != null)
				{
					_lastAtlbString = lastAtlb.ATLBNo;
					_flightsOnPageMax = lastAtlb.PageFlightCount;
				}

				lastAircraftFlight = _currentFlight.ItemId <= 0
					? flights.GetLastFlightInAtlb(_currentFlight.ATLBId)
					: flights.GetPreviousKnownRecord(_currentFlight.FlightDate);
				if (lastAircraftFlight != null)
				{
					_lastFlightString = lastAircraftFlight.PageNo;
					_flightsOnPage = flights.GetFlightWithPageNumInAtlb(_currentFlight.PageNo, _currentFlight.ATLBId).Count;
				}
			}
			else
			{
				lastAircraftFlight = _currentFlight.ItemId <= 0
				   ? flights.GetLast()
				   : flights.GetPreviousKnownRecord(_currentFlight.FlightDate);
				if (lastAircraftFlight != null)
				{
					_lastFlightString = lastAircraftFlight.PageNo;
					lastAtlb = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<ATLBDTO,ATLB>(lastAircraftFlight.ATLBId);
				}
				if (lastAtlb != null)
				{
					_lastAtlbString = lastAtlb.ATLBNo;
					_flightsOnPageMax = lastAtlb.PageFlightCount;
				}
			}

			discrepancies.Clear();
			discrepancies.AddRange(GlobalObjects.DiscrepanciesCore.GetDiscrepancies(CurrentAircraft).Distinct());

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region private void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		private void AnimatedThreadWorkerDoWorkWithCreateFlight(object sender, DoWorkEventArgs e)
		{
			AnimatedThreadWorker.ReportProgress(0, "create flight");

		#if SCAT
			GlobalObjects.AircraftFlightsCore.LoadAircraftFlights(CurrentAircraft.ItemId);
		#endif

			_currentFlight = new AircraftFlight{AtlbRecordType =  _type};//создание нового объекта полета

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			AnimatedThreadWorker.ReportProgress(30, "loading information to flight");

			ATLB lastAtlb;

			if (CurrentAircraft != null)
			{
				if (_currentAtlb != null)
				{
					_currentFlight.ATLBId = _currentAtlb.ItemId;//присваивание идентификатора бортового журнала
					_currentFlight.AttachedFile = _currentAtlb.AttachedFile;//присваивание идентификатора файла бортового журнала
					_currentFlight.ParentATLB = _currentAtlb;//присваивание обратной ссылки на объект бортового журнала 
				}
				else
				{
					var lastFlight = GlobalObjects.AircraftFlightsCore.GetLastAircraftFlight(CurrentAircraft.ItemId);

					lastAtlb = lastFlight != null
						? GlobalObjects.CasEnvironment.NewLoader.GetObjectById<ATLBDTO,ATLB>(lastFlight.ATLBId)
						: null;
					if (lastAtlb != null)
					{
						_currentFlight.ATLBId = lastAtlb.ItemId;//присваивание идентификатора бортового журнала 
						_currentFlight.AttachedFile = lastAtlb.AttachedFile;//присваивание идентификатора файла бортового журнала
						_currentFlight.ParentATLB = lastAtlb;//присваивание обратной ссылки на объект бортового журнала
					} 
				}
				_currentFlight.AircraftId = CurrentAircraft.ItemId;//присваивание обратной на родительский самолет 

				//загрузка данных Воздушного судно в объект полета
				try
				{
					GlobalObjects.AircraftFlightsCore.GetAircraftInformationToFlight(CurrentAircraft.ItemId, _currentFlight);
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while loading flight on Aircrat: " + CurrentAircraft, ex);
				}

				lastAtlb = null;
				AircraftFlight lastAircraftFlight;
				_lastFlightString = "Unknown";
				_lastAtlbString = "Unknown";
				_flightsOnPage = 0;
				_flightsOnPageMax = 0;

				var flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsByAircraftId(CurrentAircraft.ItemId);

				if (_currentFlight.ATLBId > 0)
				{
					lastAtlb = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<ATLBDTO,ATLB>(_currentFlight.ATLBId);
					if (lastAtlb != null)
					{
						_lastAtlbString = lastAtlb.ATLBNo;
						_flightsOnPageMax = lastAtlb.PageFlightCount;
					}

					lastAircraftFlight = _currentFlight.ItemId <= 0
						? flights.GetLastFlightInAtlb(_currentFlight.ATLBId)
						: flights.GetPreviousKnownRecord(_currentFlight.FlightDate);
					if (lastAircraftFlight != null)
					{
						_lastFlightString = lastAircraftFlight.PageNo;
						_flightsOnPage = flights.GetFlightWithPageNumInAtlb(_currentFlight.PageNo, _currentFlight.ATLBId).Count;
					}
				}
				else
				{
					

					lastAircraftFlight = _currentFlight.ItemId <= 0
					   ? flights.GetLast()
					   : flights.GetPreviousKnownRecord(_currentFlight.FlightDate);
					if (lastAircraftFlight != null)
					{
						_lastFlightString = lastAircraftFlight.PageNo;
						lastAtlb = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<ATLBDTO,ATLB>(lastAircraftFlight.ATLBId);
					}
					if (lastAtlb != null)
					{
						_lastAtlbString = lastAtlb.ATLBNo;
						_flightsOnPageMax = lastAtlb.PageFlightCount;
					}
				}
			}

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			discrepancies.Clear();
			discrepancies.AddRange(GlobalObjects.DiscrepanciesCore.GetDiscrepancies(CurrentAircraft).Distinct());
			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
#endregion

		#region public override void OnInitCompletion(object sender)
		/// <summary>
		/// Метод, вызывается после добавления содежимого на отображатель(вкладку)
		/// </summary>
		/// <returns></returns>
		public override void OnInitCompletion(object sender)
		{
			AnimatedThreadWorker.RunWorkerAsync();

			base.OnInitCompletion(sender);
		}
		#endregion

		#region private bool Save()

		private bool Save()
		{
			if (!CheckData()) return false;

			ApplyChanges();

			try
			{
				GlobalObjects.AircraftFlightsCore.AddAircraftFlight(_currentFlight);
				GlobalObjects.CasEnvironment.Calculator.ResetMath(CurrentAircraft);
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while saving data", ex);
				return false;
			}
			return true;
		}
		#endregion

		#region private bool CheckData()
		/// <summary>
		/// Сохраняет данные текущей директивы
		/// </summary>
		private bool CheckData()
		{
			// Просматриваем до первой "провалившейся" проверки
			foreach (Control c in flowLayoutPanelMain.Controls)
			{
				EditObjectControl cc = c as EditObjectControl;
				if (cc != null)
					if (!cc.CheckData()) return false;
			}
			// Все проверки завершились успешно
			return true;
		}

		#endregion

		#region private void ApplyChanges()
		/// <summary>
		/// Вызывает метод ApplyChanges у каждого контрола
		/// </summary>
		/// <returns></returns>
		private void ApplyChanges()
		{
			// Просматриваем до первой "провалившейся" проверки
			foreach (Control c in flowLayoutPanelMain.Controls)
			{
				EditObjectControl cc = c as EditObjectControl;
				if (cc != null) cc.ApplyChanges();
			}
		}
		#endregion

		#region private void HeaderControlButtonSaveClick(object sender, EventArgs e)

		private void HeaderControlButtonSaveClick(object sender, EventArgs e)
		{
			ATLB lastAtlb = null;
			//TODO:(Evgenii Babak) создать новый метод FindLastATLB
			if (_currentAtlb == null)
			{
				var lastFlight = GlobalObjects.AircraftFlightsCore.GetLastAircraftFlight(CurrentAircraft.ItemId);
				if(lastFlight != null)
					lastAtlb = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<ATLBDTO,ATLB>(lastFlight.ATLBId);
			}
			else
			{
				var atlbs = GlobalObjects.AircraftFlightsCore.GetATLBsByAircraftId(CurrentAircraft.ItemId);
				if (atlbs.Count > 0)
					lastAtlb = atlbs.OrderBy(a => a.OpeningDate).Last();
			}

			if (lastAtlb == null)
			{
				MessageBox.Show("On this plane no matches logbook. \n Click Add New ATLB to create a new logbook", "Message infomation", MessageBoxButtons.OK,
							MessageBoxIcon.Information);
				return;
			}

			if (!Save()) return;
			MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
							MessageBoxIcon.Information);


			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			
		}

		#endregion

		#region private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)

		private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)
		{
			flightGeneralInformatonControl.Visible = !flightGeneralInformatonControl.Visible;
		}
		#endregion


		#region private void ExtendableRichContainerDiscrepanciesExtending(object sender, EventArgs e)

		private void ExtendableRichContainerDiscrepanciesExtending(object sender, EventArgs e)
		{
			discrepanciesList.Visible = !discrepanciesList.Visible;
		}
		#endregion

		#region private void ButtonAddAtlbClick(object sender, EventArgs e)

		private void ButtonAddAtlbClick(object sender, EventArgs e)
		{
			var newATLB = new ATLB(CurrentAircraft);
			CommonEditorForm form = new CommonEditorForm(newATLB);
			form.ShowDialog();
			if (newATLB.ItemId <= 0) return;
			buttonAddAtlb.Enabled = false;

			_currentFlight.ATLBId = newATLB.ItemId;//присваивание идентификатора бортового журнала
			_currentFlight.AttachedFile = newATLB.AttachedFile;//присваивание идентификатора файла бортового журнала
			_currentFlight.ParentATLB = newATLB;//присваивание обратной ссылки на объект бортового журнала
			_currentFlight.AircraftId = CurrentAircraft.ItemId;//присваивание обратной на родительский самолет

			_currentAtlb = newATLB;

			var flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsByAircraftId(CurrentAircraft.ItemId);

			var lastAircraftFlight = _currentFlight.ItemId <= 0
				? flights.GetLast()
				: flights.GetPreviousKnownRecord(_currentFlight.FlightDate);
			if (lastAircraftFlight != null)
			{
				labelDateAsOf.Text = "Current ATLB: " + newATLB.ATLBNo +
								 " Previous Page No: " + lastAircraftFlight.PageNo;
			}


		}
		#endregion

		#region private void FlightGeneralInformatonControlFlightDateChanget(DateChangedEventArgs e)
		private void FlightGeneralInformatonControlFlightDateChanget(DateChangedEventArgs e)
		{
			discrepanciesList.RTSDate = e.Date;
		}
		#endregion

		#region private void FlightGeneralInformatonControlFlightStationFromChanget(DateChangedEventArgs e)
		private void FlightGeneralInformatonControlFlightStationFromChanget(ValueChangedEventArgs e)
		{
			if (e.Value is string) discrepanciesList.Station = e.Value as string;
		}
		#endregion

		#endregion
	}
}
