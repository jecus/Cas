using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls
{
    ///<summary>
    ///</summary>
    [Designer(typeof(FlightNumberInformationControlDesigner))]
    public partial class FlightNumberInformationControl : EditObjectControl, IReference
    {
	    private FlightNumberScreenType _screenType;

	    #region Constructors

        #region public FlightNumberInformationControl()

        ///<summary>
        /// Создает объект для отображения информации о планируемом рейсе
        ///</summary>
        public FlightNumberInformationControl()
        {
            InitializeComponent();
        }

		#endregion

		#endregion

		#region Methods

		#region private void UpdateControl()

		private void UpdateControl(FlightNumberScreenType screenType)
	    {

		    dictComboBoxStationFrom.Type = typeof(AirportsCodes);
		    dictComboBoxStationTo.Type = typeof(AirportsCodes);
		    dictionaryComboBoxFlightNo.Type = typeof(FlightNum);

		    Program.MainDispatcher.ProcessControl(dictComboBoxStationFrom);
		    Program.MainDispatcher.ProcessControl(dictComboBoxStationTo);
		    Program.MainDispatcher.ProcessControl(dictionaryComboBoxFlightNo);

		    var flType = new List<FlightType>();
			if(screenType == FlightNumberScreenType.Schedule)
				flType.AddRange(FlightType.Items.Where(f => f.ItemId == FlightType.Schedule.ItemId));
			else flType.AddRange(FlightType.Items.Where(f => f.ItemId != FlightType.Schedule.ItemId));

			comboBoxFlightType.Items.Clear();
			comboBoxFlightType.Items.AddRange(flType.ToArray());

			comboBoxFlightCategory.Items.Clear();
		    foreach (object o in Enum.GetValues(typeof(FlightCategory)))
			    comboBoxFlightCategory.Items.Add(o);

		    comboBoxAircraftCode.Items.Clear();
		    foreach (object o in Enum.GetValues(typeof(FlightAircraftCode)))
			    comboBoxAircraftCode.Items.Add(o);

		}

	    #endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Заполняет поля для редактирования директивы
		/// </summary>
		public void UpdateInformation(FlightNumber _currentDirective, List<SchedulePeriods> schedulePeriods, FlightNumberScreenType screenType)
        {
            if (_currentDirective == null) return;
	        _screenType = screenType;
			UpdateControl(_screenType);

			//Выставление значений
			dictionaryComboBoxFlightNo.SelectedItem = _currentDirective.FlightNo;
            comboBoxAircraftCode.SelectedItem = _currentDirective.FlightAircraftCode;

			if(_screenType == FlightNumberScreenType.UnSchedule)
				comboBoxFlightType.SelectedItem = _currentDirective.FlightType;
			else comboBoxFlightType.SelectedItem = FlightType.Schedule;
			comboBoxFlightCategory.SelectedItem = _currentDirective.FlightCategory;
            dictComboBoxStationFrom.SelectedItem = _currentDirective.StationFrom;
            dictComboBoxStationTo.SelectedItem = _currentDirective.StationTo;
            textBoxHiddenRemarks.Text = _currentDirective.HiddenRemarks;
            textBoxDescription.Text = _currentDirective.Description;
            textBoxRemarks.Text = _currentDirective.Remarks;

	        _flightNumberPeriodListControl.SchedulePeriods = schedulePeriods;
			_flightNumberPeriodListControl.UpdateControl(_currentDirective, _screenType);
		}

        #endregion

        #region public bool GetChangeStatus(bool directiveExist)
        ///<summary>
        ///Возвращает значение, показывающее были ли изменения в данном элементе управления
        ///</summary>
        ///<param name="directiveExist">Показывает, существует ли уже директива или нет</param>
        ///<returns></returns>
        public bool GetChangeStatus(FlightNumber _currentDirective)
        {
            if (_currentDirective.ItemId > 0)
                return (_flightNumberPeriodListControl.GetChangeStatus() ||
					_currentDirective.FlightNo != dictionaryComboBoxFlightNo.SelectedItem ||
                        _currentDirective.FlightAircraftCode != (FlightAircraftCode)comboBoxAircraftCode.SelectedItem ||
                        _currentDirective.FlightType != (FlightType)comboBoxFlightType.SelectedItem ||
                        _currentDirective.FlightCategory != (FlightCategory)comboBoxFlightCategory.SelectedItem ||
                        _currentDirective.StationFrom != dictComboBoxStationFrom.SelectedItem ||
                        _currentDirective.StationTo != dictComboBoxStationTo.SelectedItem ||
                        textBoxHiddenRemarks.Text != _currentDirective.HiddenRemarks ||
                        textBoxDescription.Text != _currentDirective.Description ||
                        textBoxRemarks.Text != _currentDirective.Remarks); 
            return (dictionaryComboBoxFlightNo.SelectedItem != null ||
                    comboBoxAircraftCode.SelectedItem != null ||
                    comboBoxFlightType.SelectedItem != null ||
                    comboBoxFlightCategory.SelectedItem != null ||
                    dictComboBoxStationFrom.SelectedItem != null ||
                    dictComboBoxStationTo.SelectedItem != null ||
                    textBoxHiddenRemarks.Text != "" ||
                    textBoxDescription.Text != "" ||
                    textBoxRemarks.Text != "");
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

            if(dictionaryComboBoxFlightNo.SelectedItem == null)
            {
                if (message != "")
                    message += "\n";
                message += "Not set Flight №";
                return false;
            }
	        if (dictComboBoxStationFrom.SelectedItem == null)
	        {
				if (message != "")
			        message += "\n";
		        message += "Not set Station From";
		        return false;
			}
	        if (dictComboBoxStationTo.SelectedItem == null)
	        {
		        if (message != "")
			        message += "\n";
		        message += "Not set Station To";
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
            _currentDirective.FlightNo = dictionaryComboBoxFlightNo.SelectedItem as FlightNum;
            _currentDirective.FlightAircraftCode = (FlightAircraftCode) comboBoxAircraftCode.SelectedItem;
            _currentDirective.FlightType = (FlightType) comboBoxFlightType.SelectedItem;
            _currentDirective.FlightCategory = (FlightCategory) comboBoxFlightCategory.SelectedItem;
            _currentDirective.StationFrom = (AirportsCodes) dictComboBoxStationFrom.SelectedItem;
            _currentDirective.StationTo = (AirportsCodes) dictComboBoxStationTo.SelectedItem;
            _currentDirective.HiddenRemarks = textBoxHiddenRemarks.Text;
            _currentDirective.Description = textBoxDescription.Text;
            _currentDirective.Remarks = textBoxRemarks.Text;

	        _flightNumberPeriodListControl.ApplyChanges();

		}
        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            textBoxHiddenRemarks.Text = "";
            textBoxDescription.Text = "";
            textBoxRemarks.Text = "";
        }

		#endregion

		#region public void UpdatePeriodControl(FlightNumber currentDirective)

		public void UpdatePeriodControl(FlightNumber currentDirective)
	    {
		    _flightNumberPeriodListControl.Clear();
			_flightNumberPeriodListControl.UpdateControl(currentDirective, _screenType);
	    }

	    #endregion

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

	#region internal class FlightNumberInformationControlDesigner : ControlDesigner

	internal class FlightNumberInformationControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("CurrentDirective");
            properties.Remove("CurrentBaseDetail");
            properties.Remove("EffectiveDate");
        }
    }
    #endregion
}
