using System;
using SmartCore.Analyst;
using SmartCore.Auxiliary;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;
using Convert = System.Convert;

namespace SmartCore.Calculations
{

    /// <summary>
    /// Каким образом составлялся отчет
    /// </summary>
    [Serializable]
    public enum ForecastType
    {
        /// <summary>
        /// Отчет на заданный чек
        /// </summary>
        ForecastByCheck,
        /// <summary>
        /// Отчет на указанную дату
        /// </summary>
        ForecastByDate,
        /// <summary>
        /// Отчет на заданные ресурс
        /// </summary>
        ForecastByLifelength,
        /// <summary>
        /// Отчет на заданный промежуток сремени
        /// </summary>
        ForecastByPeriod,
    }

    /// <summary>
    /// Хранит данные о прогнозе - эти данные учитываются при подготовки отчетов Forecast
    /// </summary>
    [Serializable]
    public class ForecastData
    {
        private DateTime _forecastDate;

        /*
         * Данные, используемые для расчета - все данные могут быть заданны пользователем 
         */
        #region public BaseDetail BaseDetail { get; set; }

        public BaseComponent BaseComponent { get; set; }
        #endregion

        #region public DateTime ForecastDate { get; set; }

        /// <summary>
        /// Дата, на которую строится отчет
        /// </summary>
        public DateTime ForecastDate
        {
            get { return _forecastDate; }
            set
            {
                _forecastDate = value;
                Calc();
            }
        }

        #endregion

        #region public Lifelength ForecastLifelength { get; set; }

        /// <summary>
        /// Наработка базового агрегата (или налет вс), на которую строится отчет 
        /// </summary>
        public Lifelength ForecastLifelength { get; set; }

        #endregion

        #region public Lifelength LowerLimit{ get; set; }

        private DateTime _lowerLimit;
        /// <summary>
        /// Наработка базового агрегата (или налет вс), являющаяся нижним ограничением
        /// </summary>
        public DateTime LowerLimit
        {
            get { return _lowerLimit; }
            set
            {
                _lowerLimit = value;
            }
        }

        #endregion

        #region public NextPerformance NextPerformance{ get; set; }

        private NextPerformance _nextPerformance;
        /// <summary>
        /// Выполнение чека, на которое требуется сделать отчет
        /// </summary>
        public NextPerformance NextPerformance
        {
            get { return _nextPerformance; }
            set
            {
                _nextPerformance = value;
            }
        }

        #endregion

        #region public string CheckName { get; }

        /// <summary>
        /// Строкое представление чека, на который требуется сделать отчет
        /// </summary>
        public string CheckName
        {
            get
            {
                if (_nextPerformance == null)
                    return "";
                if (_nextPerformance is MaintenanceNextPerformance)
                    return ((MaintenanceNextPerformance)_nextPerformance).PerformanceGroup.GetGroupName();
                if (_nextPerformance.Parent == null)
                    return Auxiliary.Convert.GetDateFormat(Convert.ToDateTime(_nextPerformance.PerformanceDate));
                if(_nextPerformance.Parent is MaintenanceCheck)
                    return ((MaintenanceCheck)_nextPerformance.Parent).Name;
                return Auxiliary.Convert.GetDateFormat(Convert.ToDateTime(_nextPerformance.PerformanceDate));
            }
        }

        #endregion

        #region public bool NextPerformanceByDate{ get; set; }

        private bool _nextPerformanceByDate;
        /// <summary>
        /// Параметр выполнения чека, по которому стороится отчет. (Дата - true или родительский чек - false)
        /// </summary>
        public bool NextPerformanceByDate
        {
            get { return _nextPerformanceByDate; }
            set
            {
                _nextPerformanceByDate = value;
            }
        }

        #endregion

        #region public string NextPerformanceString{ get; set; }

        private string _nextPerformanceString;
        /// <summary>
        /// Строковое представление выполнения, по которому строится отчет.
        /// </summary>
        public string NextPerformanceString
        {
            get { return _nextPerformanceString; }
            set
            {
                _nextPerformanceString = value;
            }
        }

        #endregion

        #region public AverageUtilization AverageUtilization { get; set; }

        /// <summary>
        /// Среднестатистический налет ВС, который берется при расчете Approximate Date
        /// </summary>
        public AverageUtilization AverageUtilization { get; set; }

        #endregion

        #region public Lifelength CurrentLifelength { get; private set; }

        /// <summary>
        /// Текущий ресурс (налет вс или наработка базового агрегата)
        /// </summary>
        public Lifelength CurrentLifelength { get; private set; }

        #endregion

        #region public ForecastType SelectedForecastType { get; set; }

        /// <summary>
        /// Каким образом составлялся отчет
        /// </summary>
        public ForecastType SelectedForecastType { get; set; }

        #endregion

        #region public bool IncludeNotifyes { get; set; }

        public bool IncludeNotifyes { get; set; }
        #endregion

        #region public bool IncludePercents { get; set; }

        public bool IncludePercents { get; set; }
        #endregion

        #region public int Percents { get; set; }

        public int Percents { get; set; }
        #endregion

        /*
         * Конструктор
         */

        #region public ForecastData(DateTime date, AverageUtilization average, Lifelength current)

        /// <summary>
        /// Создает прогноз на заданную дату
        /// </summary>
        /// <param name="date">Дата, на которую необходимо построить отчет</param>
        /// <param name="average">Среднестатистическая наработка агрегата или налет ВС</param>
        /// <param name="current">Текущая наработка агрегата или налет ВС</param>
        public ForecastData(DateTime date, AverageUtilization average, Lifelength current)
        {
            SelectedForecastType = ForecastType.ForecastByDate;
            Init(date, average, current);
        }

        #endregion

        #region public ForecastData(DateTime date, BaseDetail baseDetail, Lifelength current, Lifelength lowerLimit = null)

        /// <summary>
        /// Создает прогноз на заданную дату
        /// </summary>
        /// <param name="date">Дата, на которую необходимо построить отчет</param>
        /// <param name="baseComponentгрегат</param>
        /// <param name="current">Текущая наработка агрегата или налет ВС</param>
        /// <param name="lowerLimit">Нижняя граница прогноза</param>
        public ForecastData(DateTime date, BaseComponent baseComponent, Lifelength current, DateTime? lowerLimit = null)
        {
            BaseComponent = baseComponent;
            SelectedForecastType = lowerLimit != null ? ForecastType.ForecastByPeriod : ForecastType.ForecastByDate;
            LowerLimit = lowerLimit != null ? Convert.ToDateTime(lowerLimit) : DateTimeExtend.GetCASMinDateTime();
            Init(date, BaseComponent.AverageUtilization, current);
        }

        #endregion

        #region public ForecastData(Lifelength forecastLifelength, AverageUtilization average, Lifelength current)

        /// <summary>
        /// Создает прогноз на заданный ресурс агрегата (налет воздушного судна)
        /// </summary>
        /// <param name="forecastLifelength">Ресурс агрегата или налет воздушного судна, на который требуется построить отчет</param>
        /// <param name="average">Среднестатистическая наработка агрегата или налет ВС</param>
        /// <param name="current">Текущая наработка агрегата или налет ВС</param>
        public ForecastData(Lifelength forecastLifelength, AverageUtilization average, Lifelength current)
        {
            SelectedForecastType = ForecastType.ForecastByLifelength;
            Lifelength delta = new Lifelength(forecastLifelength);
            delta.Substract(current);
            DateTime? date = AnalystHelper.GetApproximateDate(delta, average);
            if (date == null) throw new Exception("1327: Can not compose forecast report for null date");
            Init(date.Value, average, current);
        }

	    public ForecastData()
	    {
		    
	    }

	    #endregion

        /*
         * Реализация
         */

        #region private void Init(DateTime date, AverageUtilization average, Lifelength current)
        /// <summary>
        /// Инициализирует все поля
        /// </summary>
        /// <param name="date"></param>
        /// <param name="average"></param>
        /// <param name="current"></param>
        private void Init(DateTime date, AverageUtilization average, Lifelength current)
        {
            CurrentLifelength = new Lifelength(current);
            _forecastDate = date;
            AverageUtilization = average;
            ForecastLifelength = new Lifelength(current);
            ForecastLifelength.Add(AnalystHelper.GetUtilization(average, Calculator.GetDays(DateTime.Today, date)));
            IncludeNotifyes = false;
            Percents = 5;
        }
        #endregion

        #region private void Calc()
        /// <summary>
        /// Инициализирует все поля
        /// </summary>
        private void Calc()
        {
            if(CurrentLifelength == null || AverageUtilization == null)return;
            if(ForecastLifelength == null) ForecastLifelength = new Lifelength(CurrentLifelength);
            else
            {
                ForecastLifelength.Reset();
                ForecastLifelength += CurrentLifelength;
            }
            
            ForecastLifelength.Add(AnalystHelper.GetUtilization(AverageUtilization, Calculator.GetDays(DateTime.Today, _forecastDate)));
            IncludeNotifyes = false;
            Percents = 5;
        }
        #endregion
    }
}
