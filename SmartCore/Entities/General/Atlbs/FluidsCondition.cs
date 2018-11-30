using System;
using System.Globalization;

namespace SmartCore.Entities.General.Atlbs
{

    /// <summary>
    /// Состояние жидкостей
    /// </summary>
    [Serializable]
    public class FluidsCondition //: StringConvertibleObject
    {


        /*
         * Свойства
         */
        #region public Boolean IsDeleted { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Boolean IsDeleted { get; set; }
        #endregion

        #region public Int32 ItemID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32 ItemID { get; set; }
        #endregion

        #region public double HydraulicFluidAdded
        /// <summary>
        /// Количество добавленной гидравлической жидкости (Qts.)
        /// </summary>
        private double _HydraulicFluidAdded;
        /// <summary>
        /// Количество добавленной гидравлической жидкости (Qts.)
        /// </summary>
        public double HydraulicFluidAdded
        {
            get { return _HydraulicFluidAdded; }
            set
            {
                _HydraulicFluidAdded = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public double HydraulicFluidOnBoard
        /// <summary>
        /// Количество гидравлической жидкости перед полетом (Qts.)
        /// </summary>
        private double _HydraulicFluidOnBoard;
        /// <summary>
        /// Количество гидравлической жидкости перед полетом (Qts.)
        /// </summary>
        public double HydraulicFluidOnBoard
        {
            get { return _HydraulicFluidOnBoard; }
            set
            {
                _HydraulicFluidOnBoard = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public bool GroundDeIce
        /// <summary>
        /// Нужно ли проводить процедуру анти обледенения
        /// </summary>
        private bool _GroundDeIce;
        /// <summary>
        /// Нужно ли проводить процедуру анти обледенения
        /// </summary>
        public bool GroundDeIce
        {
            get { return _GroundDeIce; }
            set
            {
                _GroundDeIce = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public TimeSpan AntiIcingStartTime
        /// <summary>
        /// Время начала процедуры анти обледенения
        /// </summary>
        private TimeSpan _AntiIcingStartTime;
        /// <summary>
        /// Время начала процедуры анти обледенения
        /// </summary>
        public TimeSpan AntiIcingStartTime
        {
            get { return _AntiIcingStartTime; }
            set
            {
                _AntiIcingStartTime = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public TimeSpan AntiIcingEndTime
        /// <summary>
        /// Время окончания процедуры анти обледенения
        /// </summary>
        private TimeSpan _AntiIcingEndTime;
        /// <summary>
        /// Время окончания процедуры анти обледенения
        /// </summary>
        public TimeSpan AntiIcingEndTime
        {
            get { return _AntiIcingEndTime; }
            set
            {

                _AntiIcingEndTime = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public string AntiIcingFluidType
        /// <summary>
        /// Тип жидкости для анти обледенения
        /// </summary>
        private string _AntiIcingFluidType;
        /// <summary>
        /// Тип жидкости для анти обледенения
        /// </summary>
        public string AntiIcingFluidType
        {
            get { return _AntiIcingFluidType; }
            set
            {
                _AntiIcingFluidType = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public string AEACode
        /// <summary>
        /// Концентрация жидкости антиобледенения
        /// </summary>
        private string _AEACode;
        /// <summary>
        /// Концентрация жидкости антиобледенения
        /// </summary>
        public string AEACode
        {
            get { return _AEACode; }
            set
            {
                _AEACode = value;
            //    OnDataChange();
            }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public FluidsCondition()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public FluidsCondition()
        {
        }
        #endregion

        /*
         * Реализация StringConvertibleObject
         */

        #region public FluidsCondition(string Data) : base(Data)
        /// <summary>
        /// Создает объект и заполняет данными
        /// </summary>
        /// <param name="Data"></param>
        public FluidsCondition(string Data)
        //   : base(Data)
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
            return new string[] { "HydraulicFluidAdded", "HydraulicFluidOnBoard", "GroundDeIce", "AntiIcingStartTime", "AntiIcingEndTime", "AntiIcingFluidType", "AEACode" };
        }
        #endregion

        #region protected override string[] GetValues()
        /// <summary>
        /// Возвращает значения всех полей объекта
        /// </summary>
        /// <returns></returns>
        protected /*override*/ string[] GetValues()
        {
            return new string[] { _HydraulicFluidAdded.ToString(), _HydraulicFluidOnBoard.ToString(), (_GroundDeIce ? "100" : "0"),
            TimeToString(_AntiIcingStartTime), TimeToString(_AntiIcingEndTime), _AntiIcingFluidType, _AEACode };
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
            if (field == "HydraulicFluidAdded")
            {
                _HydraulicFluidAdded = StringToDouble(value);
            }
            else if (field == "HydraulicFluidOnBoard")
            {
                _HydraulicFluidOnBoard = StringToDouble(value);
            }
            else if (field == "GroundDeIce")
            {
                if (value != "0") _GroundDeIce = true;
            }
            else if (field == "AntiIcingStartTime")
            {
                _AntiIcingStartTime = StringToTime(value);
            }
            else if (field == "AntiIcingEndTime")
            {
                _AntiIcingEndTime = StringToTime(value);
            }
            else if (field == "AntiIcingFluidType")
            {
                _AntiIcingFluidType = value;
            }
            else if (field == "AEACode")
            {
                _AEACode = value;
            }
        }
        #endregion

        /*
         * Реализация 
         */

        #region public static bool StringToDouble(string s, out double d)
        /// <summary>
        /// Переводит строку в дробное число, в случае не успешной операции функция возвратит false
        /// Воспринимает дробные числа и с запятой и с точкой
        /// </summary>
        /// <param name="s"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool StringToDouble(string s, out double d)
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

        #region public static double StringToDouble(string s)
        /// <summary>
        /// Переводит строку в число. Пустую строку интерпретирует как 0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double StringToDouble(string s)
        {
            double d;
            if (!StringToDouble(s, out d)) return 0;

            //
            return d;
        }
        #endregion

        #region public static string TimeToString(TimeSpan time)
        /// <summary>
        /// Представляет время в виде строки
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string TimeToString(TimeSpan time)
        {
            return (time.Hours * 60 + time.Minutes).ToString();
        }
        #endregion

        #region public TimeSpan StringToTime(string s)
        /// <summary> 
        /// Переводит строку (количество минут) в дату
        /// </summary>
        /// <returns></returns>
        public TimeSpan StringToTime(string s)
        {
            int i = 0;
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
        public void ToValues(string Data)
        {
            if (Data == null)
                return;
            // Разбиваем по разделителю
            string[] values = Data.Split(new char[] { ' ' });
            string[] fields = GetFields();
            //
            for (int i = 0; i < values.Length && i < fields.Length; i++)
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
            return _HydraulicFluidAdded + " " + _HydraulicFluidOnBoard + " " + (_GroundDeIce ? "100" : "0")  + " " +
            TimeToString(_AntiIcingStartTime)  + " " + TimeToString(_AntiIcingEndTime)  + " " + _AntiIcingFluidType  + " " + _AEACode;
        }
        #endregion

    }
}
