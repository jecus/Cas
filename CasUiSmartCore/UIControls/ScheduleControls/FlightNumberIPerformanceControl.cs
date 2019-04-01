using System;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls
{
	public partial class FlightNumberIPerformanceControl : UserControl, IReference
	{

		#region Constructor

		public FlightNumberIPerformanceControl()
		{
			InitializeComponent();
		}

		#endregion


		#region private void UpdateInformation()

		/// <summary>
		/// Заполняет поля для редактирования директивы
		/// </summary>
		public void UpdateInformation(FlightNumber _currentDirective)
		{
			if (_currentDirective == null) return;

			dictComboBoxMinLevel.Type = typeof(CruiseLevel);
			Program.MainDispatcher.ProcessControl(dictComboBoxMinLevel);

			comboBoxMeasure.Items.Clear();
			foreach (Measure o in Measure.Items.Where(i => i == Measure.Kilometres || i == Measure.Miles || i == Measure.Unknown))
				comboBoxMeasure.Items.Add(o);

			numericUpDownDistance.Value = _currentDirective.Distance;
			comboBoxMeasure.SelectedItem = _currentDirective.DistanceMeasure;
			dictComboBoxMinLevel.SelectedItem = _currentDirective.MinLevel;
			numericUpDownPassengers.Value = _currentDirective.MaxPassengerAmount;
			numericUpDownFuel.Value = (decimal)_currentDirective.MaxFuelAmount;
			numericUpDownFuelRemainAfter.Value = (decimal)_currentDirective.MinFuelAmount;
			numericUpDownPayload.Value = (decimal)_currentDirective.MaxPayload;
			numericUpDownCargo.Value = (decimal)_currentDirective.MaxCargoWeight;
			numericUpDownTakeOffWeight.Value = (decimal)_currentDirective.MaxTakeOffWeight;
			numericUpDownMaxLandWeight.Value = (decimal)_currentDirective.MaxLandWeight;

			dataGridViewCrew.ViewedType = typeof(FlightNumberCrewRecord);
			dataGridViewAirports.ViewedType = typeof(FlightNumberAirportRelation);
			dataGridViewAircraftModels.ViewedType = typeof(FlightNumberAircraftModelRelation);

			dataGridViewCrew.SetItemsArray(_currentDirective.FlightNumberCrewRecords.ToArray());
			dataGridViewAirports.SetItemsArray(_currentDirective.AlternateAirports.ToArray());
			dataGridViewAircraftModels.SetItemsArray(_currentDirective.AircraftModels.ToArray());
		}

		#endregion

		#region public bool GetChangeStatus(bool directiveExist)
		///<summary>
		///Возвращает значение, показывающее были ли изменения в данном элементе управления
		///</summary>
		///<param name="_currentDirective">Показывает, существует ли уже директива или нет</param>
		///<returns></returns>
		public bool GetChangeStatus(FlightNumber _currentDirective)
		{
			if (dataGridViewCrew.GetChangeStatus() ||
			    dataGridViewAirports.GetChangeStatus() ||
			    dataGridViewAircraftModels.GetChangeStatus())
				return true;

			if (_currentDirective.ItemId > 0)
				return  _currentDirective.Distance != numericUpDownDistance.Value ||
				        _currentDirective.DistanceMeasure != comboBoxMeasure.SelectedItem ||
				        _currentDirective.MinLevel != dictComboBoxMinLevel.SelectedItem ||
				        _currentDirective.MaxPassengerAmount != numericUpDownPassengers.Value ||
				        _currentDirective.MaxFuelAmount != (double)numericUpDownFuel.Value ||
				        _currentDirective.MinFuelAmount != (double)numericUpDownFuelRemainAfter.Value ||
				        _currentDirective.MaxPayload != (double)numericUpDownPayload.Value ||
				        _currentDirective.MaxCargoWeight != (double)numericUpDownCargo.Value ||
				        _currentDirective.MaxLandWeight != (double)numericUpDownMaxLandWeight.Value ||
				        _currentDirective.MaxTakeOffWeight != (double)numericUpDownTakeOffWeight.Value;
			return  numericUpDownDistance.Value != 0 ||
			        comboBoxMeasure.SelectedItem != null ||
			        dictComboBoxMinLevel.SelectedItem != null ||
			        numericUpDownPassengers.Value != 0 ||
			        numericUpDownFuel.Value != 0 ||
			        numericUpDownFuelRemainAfter.Value != 0 ||
			        numericUpDownPayload.Value != 0 ||
			        numericUpDownCargo.Value != 0 ||
			        numericUpDownTakeOffWeight.Value != 0;
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
			string m;
			if (!dataGridViewCrew.ValidateData(out m))
			{
				if (message != "")
					message += "\n";
				message += m;

				return false;
			}
			if (!dataGridViewAirports.ValidateData(out m))
			{
				if (message != "")
					message += "\n";
				message += m;

				return false;
			}
			if (!dataGridViewAircraftModels.ValidateData(out m))
			{
				if (message != "")
					message += "\n";
				message += m;

				return false;
			}
			return true;
		}

		#endregion

		#region public void ApplyChanges()

		/// <summary>
		/// Данные у директивы обновляются по введенным данным
		/// </summary>
		/// <param name="_currentDirective"></param>
		public void ApplyChanges(FlightNumber _currentDirective)
		{
			_currentDirective.Distance = (int)numericUpDownDistance.Value;
			_currentDirective.DistanceMeasure = (Measure)comboBoxMeasure.SelectedItem;
			_currentDirective.MinLevel = (CruiseLevel)dictComboBoxMinLevel.SelectedItem;
			_currentDirective.MaxPassengerAmount = (int)numericUpDownPassengers.Value;
			_currentDirective.MaxFuelAmount = (double)numericUpDownFuel.Value;
			_currentDirective.MinFuelAmount = (double)numericUpDownFuelRemainAfter.Value;
			_currentDirective.MaxPayload = (double)numericUpDownPayload.Value;
			_currentDirective.MaxCargoWeight = (double)numericUpDownCargo.Value;
			_currentDirective.MaxTakeOffWeight = (double)numericUpDownTakeOffWeight.Value;
			_currentDirective.MaxLandWeight = (double)numericUpDownMaxLandWeight.Value;

			dataGridViewCrew.ApplyChanges();
			//очистка текущей коллекции элементов
			_currentDirective.FlightNumberCrewRecords.Clear();
			//Получение всех элементов списка
			ICommonCollection icc = dataGridViewCrew.GetItemsArray();
			//добавление в редактируемый объект
			_currentDirective.FlightNumberCrewRecords.AddRange(icc);
			//очистка коллекции элементов списка для предотвращения утечки памяти
			icc.Clear();

			dataGridViewAirports.ApplyChanges();
			//очистка текущей коллекции элементов
			_currentDirective.AlternateAirports.Clear();
			//Получение всех элементов списка
			icc = dataGridViewAirports.GetItemsArray();
			//добавление в редактируемый объект
			_currentDirective.AlternateAirports.AddRange(icc);
			//очистка коллекции элементов списка для предотвращения утечки памяти
			icc.Clear();

			dataGridViewAircraftModels.ApplyChanges();
			//очистка текущей коллекции элементов
			_currentDirective.AircraftModels.Clear();
			//Получение всех элементов списка
			icc = dataGridViewAircraftModels.GetItemsArray();
			//добавление в редактируемый объект
			_currentDirective.AircraftModels.AddRange(icc);
			//очистка коллекции элементов списка для предотвращения утечки памяти
			icc.Clear();
		}
		#endregion

		#region public void ClearFields()

		/// <summary>
		/// Очищает все поля
		/// </summary>
		public void ClearFields()
		{
			numericUpDownDistance.Value = 0;
			numericUpDownPassengers.Value = 0;
			numericUpDownFuel.Value = 0;
			numericUpDownFuelRemainAfter.Value = 0;
			numericUpDownPayload.Value = 0;
			numericUpDownCargo.Value = 0;
			numericUpDownTakeOffWeight.Value = 0;
		}

		#endregion


		#region IReference Members

		/// <summary>
		/// Displayer for displaying entity
		/// </summary>
		public IDisplayer Displayer { get; set; }

		/// <summary>
		/// Text of page's header that Reference lead to
		/// </summary>
		public string DisplayerText { get; set; }

		/// <summary>
		/// Entity to display
		/// </summary>
		public IDisplayingEntity Entity { get; set; }

		/// <summary>
		/// Type of reflection
		/// </summary>
		public ReflectionTypes ReflectionType { get; set; }

		/// <summary>
		/// Occurs when linked invoker requests displaying 
		/// </summary>
		public event EventHandler<ReferenceEventArgs> DisplayerRequested;

		#endregion
	}
}
