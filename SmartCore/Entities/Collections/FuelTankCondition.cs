using System;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Состояние топливного бака
    /// </summary>
    [Serializable]
    public class FuelTankCondition// : StringConvertibleObject
    {

        /*
         * Свойства 
         */


        #region public string Tank
        /// <summary>
        /// Название топливного бака в текстовом виде (например, Tank1, Central Tank, Tank2)
        /// </summary>
        private string _tank;
        /// <summary>
        /// Название топливного бака в текстовом виде (например, Tank1, Central Tank, Tank2)
        /// </summary>
        public string Tank
        {
            get { return _tank; }
            set
            {
                 _tank = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public double Remaining
        /// <summary>
        /// Количетсво топлива оставшееся после пред. полета
        /// </summary>
        private double _remaining;
        /// <summary>
        /// Количетсво топлива оставшееся после пред. полета
        /// </summary>
        public double Remaining
        {
            get { return _remaining; }
            set
            {
                _remaining = value;
             //   OnDataChange();
            }
        }
        #endregion

        #region public double OnBoard
        /// <summary>
        /// Количество топлива, доступное перед следующим полетом
        /// </summary>
        private double _onBoard;
        /// <summary>
        /// Количество топлива, доступное перед следующим полетом
        /// </summary>
        public double OnBoard
        {
            get { return _onBoard; }
            set
            {
                _onBoard = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public double Correction
        /// <summary>
        /// Количество топлива перед следующим полетом и после выполнения корректирущий действий (дозоправка и т.д.)
        /// </summary>
        private double _correction;
        /// <summary>
        /// Количество топлива перед следующим полетом и после выполнения корректирущий действий (дозоправка и т.д.)
        /// </summary>
        public double Correction
        {
            get { return _correction; }
            set
            {
                _correction = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public double Spent
        /// <summary>
        /// Израсходованное топливо
        /// </summary>
        private double _spent;
        /// <summary>
        /// Израсходованное топливо
        /// </summary>
        public double Spent
        {
            get { return _spent; }
            set
            {
                _spent = value;
            }
        }
        #endregion

        #region public double RemainingAfter
        /// <summary>
        /// Количество топлива оставшееся после полета
        /// </summary>
        private double _remainingAfter;
        /// <summary>
        /// Количество топлива оставшееся после полета
        /// </summary>
        public double RemainingAfter
        {
            get { return _remainingAfter; }
            set
            {
                _remainingAfter = value;
                //    OnDataChange();
            }
        }
        #endregion

        #region public double ActualUpliftLit
        /// <summary>
        /// Количество топлива, которое было залито
        /// </summary>
        private double _actualUpliftLit;
        /// <summary>
        /// Количество топлива, которое было залито
        /// </summary>
        public double ActualUpliftLit
        {
            get { return _actualUpliftLit; }
            set
            {
                _actualUpliftLit = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public double Density
        /// <summary>
        /// Плотность топлива
        /// </summary>
        private double _density;
        /// <summary>
        /// Плотность топлива
        /// </summary>
        public double Density
        {
            get { return _density; }
            set
            {
                _density = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public double CalculateUplift
        /// <summary>
        /// Вычисленное количество топлива
        /// </summary>
        private double _calculateUplift;
        /// <summary>
        /// Вычисленное количество топлива
        /// </summary>
        public double CalculateUplift
        {
            get { return _calculateUplift; }
            set
            {
                _calculateUplift = value;
            //    OnDataChange();
            }
        }
        #endregion

        #region public double Discrepancy
        /// <summary>
        /// Отклонение от нормы
        /// </summary>
        private double _discrepancy;
        /// <summary>
        /// Отлонение от нормы
        /// </summary>
        public double Discrepancy
        {
            get { return _discrepancy; }
            set
            {
                _discrepancy = value;
            //    OnDataChange();
            }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public FuelTankCondition()
        /// <summary>
        /// Состояние топливного бака
        /// </summary>
        public FuelTankCondition()
        {
        }
        #endregion


        /*
         * Реализация StringConvertibleObject
         */

        #region public FuelTankCondition(string Data)
        /// <summary>
        /// Создает класс с уже заполненными данными 
        /// </summary>
        /// <param name="data"></param>
        public FuelTankCondition(string data)
        {
            if (data == null)
                return;
            // Разбиваем по разделителю
            string[] values = data.Split(new[] { ' ' });
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

        #region private string[] GetFields()
        /// <summary>
        /// Перечисляет поля объекта
        /// </summary>
        /// <returns></returns>
        private string[] GetFields()
        {
            return new[] { "Tank", "Remaining", "OnBoard", "Correction", "ActualUpliftLIT", "Density", "CalculateUplift", "Discrepancy", "Spent", "RemainingAfter"};
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
            if (field == "Tank")
            {
                _tank = value;
            }
            else if (field == "Remaining")
            {
                _remaining = StringToDouble(value);
            }
            else if (field == "OnBoard")
            {
                _onBoard = StringToDouble(value);
            }
            else if (field == "Correction")
            {
                _correction = StringToDouble(value);
            }
            else if (field == "ActualUpliftLIT")
            {
                _actualUpliftLit = StringToDouble(value);
            }
            else if (field == "Density")
            {
                _density = StringToDouble(value);
            }
            else if (field == "CalculateUplift")
            {
                _calculateUplift = StringToDouble(value);
            }
            else if (field == "Discrepancy")
            {
                _discrepancy = StringToDouble(value);
            }
            else if (field == "Spent")
            {
                _spent = StringToDouble(value);
            }
            else if (field == "RemainingAfter")
            {
                _remainingAfter = StringToDouble(value);
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


            System.Globalization.CultureInfo my = new System.Globalization.CultureInfo("en-US", true);
            my.NumberFormat.NumberDecimalSeparator = ".";
            s = s.Replace(",", ".");

            if (!Double.TryParse(s, System.Globalization.NumberStyles.AllowDecimalPoint, my, out d)) return false;

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

        #region public override string ToString()
        /// <summary>
        /// Преобразование объекта а строку. Значения объекта разделены пробелами
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _tank + " " + _remaining + " " + _onBoard + " " + _correction + " " + _actualUpliftLit + " " +
                   _density + " " + _calculateUplift + " " + _discrepancy + " " + _spent + " " + _remainingAfter;
        }
        #endregion
    }
}