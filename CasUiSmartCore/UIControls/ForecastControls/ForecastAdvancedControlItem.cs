using System;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Analyst;
using SmartCore.Calculations;

namespace CAS.UI.UIControls.ForecastControls
{
    ///<summary>
    /// ЭУ для редактирования данных прогноза для отдельной базовой детали
    ///</summary>
    public partial class ForecastAdvancedControlItem : UserControl
    {
        private ForecastData _currentForecastData;
        private DateTime _forecastDate;

        ///<summary>
        /// Меняет текст названия базовой детали
        ///</summary>
        public string DetailNameText
        {
            set { labelBaseDetailName.Text = value; }
        }

        /// <summary>
        /// возвращает данные прогноза
        /// </summary>
        public ForecastData CurrneForecastData
        {
            get { return _currentForecastData; }
        }

        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        private ForecastAdvancedControlItem()
        {
            InitializeComponent();
        }

        ///<summary>
        /// Конструктор, принимающий в качестве параметра прогноз для базовой детали
        ///</summary>
        ///<param name="forecastData">Данные прогнозя для базовой детали</param>
        public ForecastAdvancedControlItem(ForecastData forecastData) : this()
        {
            _currentForecastData = forecastData;
            _forecastDate = forecastData.ForecastDate;

            UpdateInformation();
        }

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            //строится прогноз по самолету
            if (_currentForecastData.AverageUtilization.SelectedInterval == UtilizationInterval.Dayly)
                radioButtonDayly.Checked = true;
            else
                radioButtonMonthly.Checked = true;

            numericUpDownHours.Value = (decimal)_currentForecastData.AverageUtilization.Hours;
            numericUpDownCycles.Value = (decimal)_currentForecastData.AverageUtilization.Cycles;
            lifelengthViewer_ForecastResource.Lifelength = _currentForecastData.ForecastLifelength;
            lifelengthViewerCurrent.Lifelength = _currentForecastData.CurrentLifelength;
            labelBaseDetailName.Text = _currentForecastData.BaseComponent.ToString();
        }

        #endregion

        #region private AverageUtilization GetAverageUtilization()
        private AverageUtilization GetAverageUtilization()
        {
            double eps = 0.00000001;
            double hours = (double)numericUpDownHours.Value;
            double cycles = (double)numericUpDownCycles.Value;

            if (radioButtonDayly.Checked && numericUpDownHours.Value >= 24)
            {
                MessageBox.Show(numericUpDownHours.Value + ". Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
            if (radioButtonMonthly.Checked && numericUpDownHours.Value >= 744)
            {
                MessageBox.Show(numericUpDownHours.Value + ". Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            AverageUtilization au = new AverageUtilization();
            if (radioButtonDayly.Checked)
                au.SelectedInterval = UtilizationInterval.Dayly;
            else au.SelectedInterval = UtilizationInterval.Monthly;

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

        #region public bool SaveData()
        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        public bool SaveData()
        {
            _currentForecastData.AverageUtilization = GetAverageUtilization();
            if (_currentForecastData.AverageUtilization == null) return false;
            _currentForecastData.ForecastLifelength = lifelengthViewer_ForecastResource.Lifelength;
            _currentForecastData.ForecastDate = _forecastDate;
            return true;
        }

        #endregion

        #region public void DateChanged(DateTime date)
        ///<summary>
        /// Выстраивает прогнозируемые ресурсы формы согласно указанной дате
        ///</summary>
        ///<param name="date"></param>
        public void DateChanged(DateTime date)
        {
            if (_currentForecastData == null) return;
            _forecastDate = date;

            Lifelength baseDetailLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentForecastData.BaseComponent);

            if (date <= DateTime.Today)
            {
                //если дата прогноза меньше сегодняшней, то выводиться зписанная наработка на эту дату
                lifelengthViewer_ForecastResource.Lifelength =
                GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(_currentForecastData.BaseComponent, date);
                Lifelength different = new Lifelength(lifelengthViewer_ForecastResource.Lifelength);
                different.Substract(baseDetailLifeLenght);
                lifelengthViewerDifferentSource.Lifelength = different;
            }
            else
            {
                //если дата прогноза выше сегодняшней, то сначала вычисляется
                //наработка на сегодняшний день, а к ней добавляется среднепрогнозируемая наработка
                //между сегодняшним днем и днем прогноза

                //если не задана сердняя утилизация, то прогноз строить нельзя
                AverageUtilization au = GetAverageUtilization();
                if (au == null) return;

                Lifelength average = AnalystHelper.GetUtilization(au, Calculator.GetDays(DateTime.Today, date));
                lifelengthViewerDifferentSource.Lifelength = average;
                baseDetailLifeLenght.Add(average);
                lifelengthViewer_ForecastResource.Lifelength = baseDetailLifeLenght;
            }
        }
        #endregion

        #region private void NumericUpDownsValueChanged(object sender, EventArgs e)
        private void NumericUpDownsValueChanged(object sender, EventArgs e)
        {
            if (radioButtonDayly.Checked && numericUpDownHours.Value >= 24)
            {
                numericUpDownHours.Value = (decimal)23.9;
            }
            if (radioButtonMonthly.Checked && numericUpDownHours.Value >= 744)
            {
                numericUpDownHours.Value = (decimal)743.9;
            }
            AverageUtilization au = GetAverageUtilization();
            if (au == null || _forecastDate <= DateTime.Today) return;

            //наработка агрегата на сегодня
            Lifelength baseDetailLifeLenght =
                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentForecastData.BaseComponent);

            if (_forecastDate <= DateTime.Today)
            {
                //если дата прогноза меньше сегодняшней, то выводиться зписанная наработка на эту дату
                Lifelength different = new Lifelength(lifelengthViewer_ForecastResource.Lifelength);
                different.Substract(baseDetailLifeLenght);
                lifelengthViewerDifferentSource.Lifelength = different;
            }
            else
            {
                //если дата прогноза выше сегодняшней, то сначала вычисляется
                //наработка на сегодняшний день, а к ней добавляется среднепрогнозируемая наработка
                //между сегодняшним днем и днем прогноза

                Lifelength average = AnalystHelper.GetUtilization(au, Calculator.GetDays(DateTime.Today, _forecastDate));
                lifelengthViewerDifferentSource.Lifelength = average;
                baseDetailLifeLenght.Add(average);
                lifelengthViewer_ForecastResource.Lifelength = baseDetailLifeLenght;
            }
        }
        #endregion

        #region private void RadioButtonDaylyClick(object sender, EventArgs e)
        private void RadioButtonDaylyClick(object sender, EventArgs e)
        {
            if (radioButtonDayly.Checked && numericUpDownHours.Value >= 24)
            {
                numericUpDownHours.Value = (decimal)23.9;
            }
            if (radioButtonMonthly.Checked && numericUpDownHours.Value >= 744)
            {
                numericUpDownHours.Value = (decimal)743.9;
            }
            AverageUtilization au = GetAverageUtilization();
            if (au == null || _forecastDate <= DateTime.Today) return;

            if (_forecastDate <= DateTime.Today) return;
            //если дата прогноза выше сегодняшней, то сначала вычисляется
            //наработка на сегодняшний день, а к ней добавляется среднепрогнозируемая наработка
            //между сегодняшним днем и днем прогноза
            //наработка агрегата на сегодня
            Lifelength baseDetailLifeLenght =
                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentForecastData.BaseComponent);

            Lifelength average = AnalystHelper.GetUtilization(au, Calculator.GetDays(DateTime.Today, _forecastDate));
            lifelengthViewerDifferentSource.Lifelength = average;
            baseDetailLifeLenght.Add(average);
            lifelengthViewer_ForecastResource.Lifelength = baseDetailLifeLenght;
        }
        #endregion
    }
}
