using System;
using System.Globalization;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Entities.General.Atlbs
{

    /// <summary>
    /// Общее состояние двигателей при проведении измерений во время полета
    /// </summary>
    [Serializable]
    public class EnginesGeneralCondition //: StringConvertibleObject
    {

        /*
         * Свойства 
         */

        #region public string PressALT
        /// <summary>
        /// высота
        /// </summary>
        private string _pressALT=String.Empty;
        /// <summary>
        /// Высота
        /// </summary>
        public string PressALT
        {
            get { return _pressALT; }
            set
            {
                _pressALT = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public TimeSpan TimeGMT
        /// <summary>
        /// Время проведения измерений
        /// </summary>
        private TimeSpan _timeGMT;
        /// <summary>
        /// Время проведения измерений
        /// </summary>
        public TimeSpan TimeGMT
        {
            get { return _timeGMT; }
            set
            {
                _timeGMT = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public double GrossWeight
        /// <summary>
        /// Масса
        /// </summary>
        private double _grossWeight;
        /// <summary>
        /// Масса
        /// </summary>
        public double GrossWeight
        {
            get { return _grossWeight; }
            set
            {
            //    OnDataChange();
                _grossWeight = value;
            }
        }
        #endregion

        #region public double IAS
        /// <summary>
        /// Показываемая скорость полета
        /// </summary>
        private double _ias;
        /// <summary>
        /// Показываемая скорость полета
        /// </summary>
        public double IAS
        {
            get { return _ias; }
            set
            {
                _ias = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public double MACH
        /// <summary>
        /// Реальная скорость полета
        /// </summary>
        private double _mach;
        /// <summary>
        /// Реальная скорость полета
        /// </summary>
        public double Mach
        {
            get { return _mach; }
            set
            {
                _mach = value;
           //     OnDataChange();
            }
        }
        #endregion

        #region public double TAT
        /// <summary>
        /// Total Air Temperature
        /// </summary>
        private double _tat;
        /// <summary>
        /// Total Air Temperature
        /// </summary>
        public double TAT
        {
            get { return _tat; }
            set
            {
                _tat = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public double OAT
        /// <summary>
        /// Outside Air Temperature
        /// </summary>
        private double _oat;
        /// <summary>
        /// Outside Air Temperature
        /// </summary>
        public double OAT
        {
            get { return _oat; }
            set
            {
                _oat = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public FlightRegime FlightRegime
        /// <summary>
        /// Outside Air Temperature
        /// </summary>
        private FlightRegime _flightRegine;
        /// <summary>
        /// Outside Air Temperature
        /// </summary>
        public FlightRegime FlightRegime
        {
            get { return _flightRegine; }
            set
            {
                _flightRegine = value;
                //    OnDataChange();
            }
        }
        #endregion

        #region public int16 TimeInRegime
        /// <summary>
        /// Outside Air Temperature
        /// </summary>
        private GroundAir _groundAir;
        /// <summary>
        /// Outside Air Temperature
        /// </summary>
        public GroundAir GroundAir
        {
            get { return _groundAir; }
            set
            {
                _groundAir = value;
                //    OnDataChange();
            }
        }
        #endregion

        #region public WeatherCondition Weather

        private WeatherCondition _weather;

        public WeatherCondition Weather
        {
            get { return _weather; }
            set { _weather = value; }
        }

        #endregion

        #region public BaseRecordCollection<EngineCondition> EngineConditions { get; set; }

        private BaseRecordCollection<EngineCondition> _engineConditions;
        /// <summary>
        /// Записи о состоянии силовых установок (Двигатели, ВСУ)
        /// </summary>
        public BaseRecordCollection<EngineCondition> EngineConditions
        {
            get { return _engineConditions ?? (_engineConditions = new BaseRecordCollection<EngineCondition>()); }
            set
            {
                if (_engineConditions != value)
                {
                    if (_engineConditions != null)
                        _engineConditions.Clear();
                    if (value != null)
                        _engineConditions = value;
                }
            }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public EnginesGeneralCondition()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public EnginesGeneralCondition()
        {
        }
        #endregion

        /*
         * Реализация StringConvertibleObject
         */

        #region public EnginesGeneralCondition(string Data) : base(Data)

        /// <summary>
        /// Создает объект и заполняет данными
        /// </summary>
        /// <param name="source"></param>
        public EnginesGeneralCondition(EngineCondition source)
        {
            _pressALT = source.PressALT.ToString();
            _timeGMT = source.TimeGMT;
            _grossWeight = source.GrossWeight;
            _ias = source.IAS;
            _mach = source.Mach;
            _tat = source.TAT;
            _oat = source.OAT;
            _flightRegine = source.FlightRegime;
            _groundAir = source.GroundAir;
            _weather = source.Weather;
        }
        #endregion

        #region public EnginesGeneralCondition(string Data) : base(Data)
        /// <summary>
        /// Создает объект и заполняет данными
        /// </summary>
        /// <param name="Data"></param>
        public EnginesGeneralCondition(string Data)
        //    : base(Data)
        {
        }
        #endregion

        #region protected override string[] GetFields()
        /// <summary>
        /// Перечисляет поля объекта
        /// </summary>
        /// <returns></returns>
        protected /*override*/ string[] GetFields()
        {
            return new string[] { "PressALT", "TimeGMT", "GrossWeight", "IAS", "MACH", "TAT", "OAT" };
        }
        #endregion

        #region public string[] GetValues()
        /// <summary>
        /// Возвращает значения всех полей объекта
        /// </summary>
        /// <returns></returns>
        public string[] GetValues()
        {
            return new string[] { _pressALT.ToString(), TimeToString(_timeGMT), _grossWeight.ToString(),
            _ias.ToString(), _mach.ToString(), _tat.ToString(), _oat.ToString() };
        }
        #endregion

        #region protected override void SetValue(string field, string value)
        /// <summary>
        /// Присваивает значения полям объекта
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        protected /*override*/ void SetValue(string field, string value)
        {
            if (field == "PressALT")
            {
                _pressALT = value;
            }
            else if (field == "TimeGMT")
            {
                _timeGMT = StringToTime(value);
            }
            else if (field == "GrossWeight")
            {
                _grossWeight = StringToDouble(value);
            }
            else if (field == "IAS")
            {
                _ias = StringToDouble(value);
            }
            else if (field == "MACH")
            {
                _mach = StringToDouble(value);
            }
            else if (field == "TAT")
            {
                _tat = StringToDouble(value);
            }
            else if (field == "OAT")
            {
                _oat = StringToDouble(value);
            }

        }
        #endregion

        /*
         * Реализация 
         */

        #region public bool StringToDouble(string s, out double d)
        /// <summary>
        /// Переводит строку в дробное число, в случае не успешной операции функция возвратит false
        /// </summary>
        /// <param name="s"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool StringToDouble(string s, out double d)
        {
            //
            d = 0;

            s = s.Trim();
            if (s.Length == 0) return true;


            CultureInfo my = new CultureInfo("en-US", true);
            my.NumberFormat.NumberDecimalSeparator = ".";
            s = s.Replace(",", ".");

            if (!Double.TryParse(s, NumberStyles.AllowDecimalPoint, my, out d)) return false;

            // Операция конвертирования прошла успешно
            return true;
        }
        #endregion

        #region public double StringToDouble(string s)
        /// <summary>
        /// Переводит строку в число
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public double StringToDouble(string s)
        {
            double d;
            if (!StringToDouble(s, out d)) return 0;

            //
            return d;
        }
        #endregion

        #region public string TimeToString(TimeSpan time)
        /// <summary>
        /// Представляет время в виде строки
        /// </summary>
        /// <returns></returns>
        public string TimeToString(TimeSpan time)
        {
            //Переводим в минуты и сохраняем в виде строки
            int m = time.Hours * 60 + time.Minutes;
            return m.ToString();
        }
        #endregion

        #region public TimeSpan StringToTime(string s)
        /// <summary> 
        /// Переводит строку (количество минут) в дату
        /// </summary>
        /// <returns></returns>
        public TimeSpan StringToTime(string s)
        {
            int i;
            TimeSpan time = new TimeSpan();
            if (int.TryParse(s, out i))
            {
                time = time.Add(new TimeSpan(0, i, 0));
            }

            //
            return time;
        }
        #endregion

        #region public void ToValues()
        /// <summary>
        /// Преобразование строки в значения полей объекта.
        /// </summary>
        /// <returns></returns>
        public void ToValues(string data)
        {
            if (data == null)
                return;
            // Разбиваем по разделителю
            string[] values = data.Split(new[]{' '});
            string[] fields = GetFields();
            //
            for (int i = 0; i < values.Length && i<fields.Length; i++)
            {
                values[i].Trim();
                fields[i].Trim();
                
                SetValue(fields[i], values[i]);
            }
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Преобразование объекта а строку. Значения объекта разделены пробелами
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _pressALT + " " + TimeToString(_timeGMT) + " " + _grossWeight + " " + _ias + " " + _mach + " " + _tat + " " + _oat;
        }
        #endregion
    }
}
