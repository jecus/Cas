using System;

namespace SmartCore.Calculations
{
    /// <summary>
    /// Класс описывает параметры выполнения чека обслуживания
    /// </summary>
    [Serializable]
    public class MaintenanceCheckThreshold : IThreshold
    {
        #region public ThresholdConditionType FirstPerformanceConditionType

        private ThresholdConditionType _performanceConditionType;
        /// <summary>
        /// Возвращает условие первого выполнения обслуживания детали. Оно всегда WhicheverFirst
        /// </summary>
        public ThresholdConditionType FirstPerformanceConditionType
        {
            get { return ThresholdConditionType.WhicheverFirst; }
            set { _performanceConditionType = value; }
        }

        #endregion

        #region public ThresholdConditionType RepeatPerformanceConditionType
        /// <summary>
        /// Возвращает условие повторного выполнения обслуживания детали. Оно всегда WhicheverFirst
        /// </summary>
        public ThresholdConditionType RepeatPerformanceConditionType
        {
            get { return ThresholdConditionType.WhicheverFirst; }
            set { _performanceConditionType = value; }
        }

        #endregion

        #region public bool PerformRepeatedly { get; set; }

        private bool _performRepeatedly;
        /// <summary>
        /// Нужно ли повторять обслуживание. Всегда false 
        /// </summary>
        public bool PerformRepeatedly
        {
            get { return true; }
            set { _performRepeatedly = value; }
        }
        #endregion

        #region public DateTime EffectiveDate { get; set;}
        /// <summary>
        /// Дата вступления директивы в действие - дата выпуска директивы
        /// </summary>
        public DateTime EffectiveDate { get; set; }

        #endregion

        #region public Lifelength FirstPerformanceSinceNew{ get; set; }

        private Lifelength _sinceNew;
        /// <summary>
        /// Условие первого выполнения с момента производства детали
        /// </summary>
        public Lifelength FirstPerformanceSinceNew
        { 
            get { return _sinceNew ?? (_sinceNew = Lifelength.Null); } 
            set { _sinceNew = value; } 
        }

        #endregion

        #region public Lifelength FirstPerformanceSinceEffectiveDate{ get; set; }

        private Lifelength _sinceEffDate;
        /// <summary>
        /// Условие выполнения директивы с момента выпуска директивы (У детали она равна Lifelength.Null)
        /// </summary>
        public Lifelength FirstPerformanceSinceEffectiveDate
        {
            get
            {
                _sinceEffDate = Lifelength.Null;
                return _sinceEffDate;
            }
            set { _sinceEffDate = value; }
        }

        #endregion

        #region public Lifelength FirstNotification { get; set; }
        private Lifelength _firstNotification;
        /// <summary>
        /// Ресурс предупреждения о приближающемся первом выполнении чека обслуживания
        /// </summary>
        public Lifelength FirstNotification
        {
            get { return _firstNotification ?? (_firstNotification = Lifelength.Null); } 
            set { _firstNotification = value; } 
        }

        #endregion

        #region public Lifelength RepeatInterval { get; set; }
        /// <summary>
        /// Интервал выполнения обслуживания чека. Всегда _sinceNew
        /// </summary>
        public Lifelength RepeatInterval { get { return FirstPerformanceSinceNew; } set { FirstPerformanceSinceNew = value; } }

        #endregion

        #region public Lifelength RepeatNotification { get; set; }
        /// <summary>
        /// Ресурс предупреждения о приближающемся повторном выполнении чека обслуживания. Всегда FirstNotification
        /// </summary>
        public Lifelength RepeatNotification { get { return FirstNotification; } set { FirstNotification = value; } }

        #endregion

        /*
         * Методы
         */

        #region public MaintenanceCheckThreshold()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public MaintenanceCheckThreshold()
        {
            //EffectiveDate = DateTime.Today;
            _sinceNew = Lifelength.Null;
            FirstNotification = Lifelength.Null;
            _performRepeatedly = true;
            RepeatInterval = Lifelength.Null;
            RepeatNotification = Lifelength.Null;
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Представляет выполнение директивы в виде 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FirstPerformanceToString() + "\r\n" + RepeatPerformanceToString() + "\r\n" +
                   ThresholdConditionToString(FirstPerformanceConditionType);
        }
        #endregion

        #region private string FirstPerformanceToString()
        /// <summary> 
        /// Возвращает условие первого выполнения директиыв
        /// </summary>
        /// <returns></returns>
        private string FirstPerformanceToString()
        {
            string res = "";

            // ресурсы заполнены 
            // выводим результат
            if (!FirstPerformanceSinceNew.IsNullOrZero()) res = LifelengthToString(FirstPerformanceSinceNew, "f.p");
            if (!FirstNotification.IsNullOrZero()) res += LifelengthToString(FirstNotification, "f.p.n");

            return "Perform at " + res.Trim();
        }
        #endregion

        #region public string FirstPerformanceToStrings()
        /// <summary> 
        /// Возвращает условие первого выполнения директивы в виде строки (Каждый параметр выводится в новой строке)
        /// </summary>
        /// <returns></returns>
        public string FirstPerformanceToStrings()
        {
            // ресурсы заполнены 
            // выводим результат
            return "";
        }
        #endregion

        #region private string RepeatPerformanceToString()
        /// <summary>
        /// Возвращает условие повторного выполнения директивы
        /// </summary>
        /// <returns></returns>
        private string RepeatPerformanceToString()
        {
            //if (!PerformRepeatedly) return "and then close";
            //else if (PerformRepeatedly && (RepeatInterval == null || RepeatInterval.IsNullLifelength()))
            //    return "repeat interval depends on first performance";
            //else
            //{
                string res = "and then repeat every ";
            //    Lifelength repeat = new Lifelength();

                if (!RepeatInterval.IsNullOrZero()) res = LifelengthToString(RepeatInterval, "r.p");
                if (!RepeatNotification.IsNullOrZero()) res += LifelengthToString(RepeatNotification, "r.p.n");

                return res.Trim();
            //}
        }
        #endregion

        #region public string RepeatPerformanceToStrings()
        /// <summary> 
        /// Возвращает условие повторного выполнения директивы в виде строки (Каждый параметр выводится в новой строке)
        /// </summary>
        /// <returns></returns>
        public string RepeatPerformanceToStrings()
        {
            // ресурсы заполнены 
            // выводим результат
            return "";
        }
        #endregion

        #region private string LifelengthToString(Lifelength lifelength, string label)
        /// <summary>
        /// Представляет наработку в виде строки
        /// </summary>
        /// <param name="lifelength"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        private string LifelengthToString(Lifelength lifelength, string label)
        {
            return lifelength + " " + label;
        }
        #endregion

        #region private string ThresholdConditionToString(ThresholdConditionType type)
        /// <summary>
        /// Представляет условие выполения директивы в виде строки
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string ThresholdConditionToString(ThresholdConditionType type)
        {
            if (type == ThresholdConditionType.WhicheverFirst)
            {
                return "w.f.";
            }
            if (type == ThresholdConditionType.WhicheverLater)
            {
                return "w.l.";
            }
            throw new Exception("1525: Failed to specify directive threshold condition type");
        }

        #endregion

        #region public static int SerializedDataLength { get; }
        ///<summary>
        /// Размер сериализованных данных объекта
        ///</summary>
        public static int SerializedDataLength
        {
            get
            {
                return sizeof(bool) * 2 + Lifelength.SerializedDataLength * 6;
            }
        }
        #endregion
    }
}
