using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.ForecastControls
{
    ///<summary>
    ///</summary>
    public partial class ForecastCustomsMTOP : Form
    {
        private MaintenanceCheckCollection _checkItems;

        private Forecast _currentForecast;
        private AverageUtilization _averageUtilization;
	    private Aircraft _aircraft;

	    private double tempHours;
	    private double tempCycles;
		private readonly AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

	    #region Constructors

        #region public ForecastCustomsWriteData()
        ///<summary>
        ///</summary>
        public ForecastCustomsMTOP()
        {
            InitializeComponent();
        }
        #endregion

        #region public ForecastCustomsWriteData(Forecast forecast) : this()
        ///<summary>
        ///</summary>
        ///<param name="forecastData">данные прогнозя для изменения</param>
        public ForecastCustomsMTOP(Aircraft aircraft, Forecast forecastData) : this()
        {
	        _aircraft = aircraft;
	        _currentForecast = forecastData;


			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
            _animatedThreadWorker.RunWorkerCompleted += AnimatedThreadWorkerRunWorkerCompleted;

            UpdateInformation();
        }
        #endregion


        #endregion

        #region protected virtual void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected virtual void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          
        }
        #endregion

        #region protected virtual void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected virtual void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            
        }
        #endregion

        #region public void CancelAsync()
        /// <summary>
        /// Проверяет, выполняет ли AnimatedThreadWorker задачу, и производит отмену выполнения
        /// </summary>
        public void CancelAsync()
        {
            if (_animatedThreadWorker.IsBusy)
                _animatedThreadWorker.CancelAsync();
        }
        #endregion

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
			var frame = GlobalObjects.CasEnvironment.BaseComponents.FirstOrDefault(i =>
		        i.ParentAircraftId == _aircraft.ItemId && Equals(i.BaseComponentType, BaseComponentType.Frame));
	        _averageUtilization = frame.AverageUtilization;


			dateTimePickerFrom.Value = DateTime.Today;
		    dateTimePickerTo.Value = DateTime.Today;

	        tempHours = _averageUtilization.HoursPerDay;
	        tempCycles = _averageUtilization.CyclesPerDay;

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

        #region private bool SaveData()
        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private bool SaveData()
        {
	        foreach (var fd in _currentForecast.ForecastDatas)
	        {
		        fd.AverageUtilization = GetAverageUtilization();

		        if (fd.AverageUtilization == null) return false;

		        //определение ресурсов прогноза для каждой базовой детали
		        fd.LowerLimit = dateTimePickerFrom.Value;
		        fd.ForecastDate = dateTimePickerTo.Value;
		        fd.SelectedForecastType = ForecastType.ForecastByPeriod;
	        }

	        _currentForecast.IsAllPhase = radioButtonAll.Checked;


			return true;
        }

        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)
        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (SaveData())
                DialogResult = DialogResult.OK;

            CancelAsync();
            Close();
        }
        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            _currentForecast = null;
            DialogResult = DialogResult.Cancel;

            CancelAsync();
            Close();
        }
		#endregion

		private void numericUpDownHours_ValueChanged(object sender, EventArgs e)
		{
			numericUpDown1.Value = numericUpDownHours.Value / numericUpDownCycles.Value;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				var current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_aircraft);
				_averageUtilization.HoursPerDay = (double)current.Hours / (double)current.Days;
				_averageUtilization.CyclesPerDay = (double)current.Hours / (double)current.Cycles;
			}
			else
			{
				_averageUtilization.HoursPerDay = tempHours;
				_averageUtilization.CyclesPerDay = tempCycles;
			}

			numericUpDownHours.Value = (decimal)_averageUtilization.Hours;
			numericUpDownCycles.Value = (decimal)_averageUtilization.Cycles;
		}
	}
}
