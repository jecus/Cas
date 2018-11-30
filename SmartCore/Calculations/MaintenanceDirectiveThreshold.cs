using System;
using System.Collections.Generic;
using System.Text;
using SmartCore.Auxiliary;
using SmartCore.Management;

namespace SmartCore.Calculations
{
    /// <summary>
    /// Класс описывает параметры выполнения чека обслуживания
    /// </summary>
    [Serializable]
    public class MaintenanceDirectiveThreshold : IThreshold
    {
        #region public ThresholdConditionType FirstPerformanceConditionType

        private ThresholdConditionType _performanceConditionType;
        /// <summary>
        /// Возвращает условие первого выполнения обслуживания детали. Оно всегда WhicheverFirst
        /// </summary>
        public ThresholdConditionType FirstPerformanceConditionType
        {
            get { return _performanceConditionType; }
            set { _performanceConditionType = value; }
        }

        #endregion

        #region public ThresholdConditionType RepeatPerformanceConditionType

        private ThresholdConditionType _repeatPerformanceConditionType;
        /// <summary>
        /// Возвращает условие повторного выполнения обслуживания детали. Оно всегда WhicheverFirst
        /// </summary>
        public ThresholdConditionType RepeatPerformanceConditionType
        {
            get { return _repeatPerformanceConditionType; }
            set { _repeatPerformanceConditionType = value; }
        }

        #endregion

        #region public bool PerformRepeatedly { get; set; }

        private bool _performRepeatedly;
        /// <summary>
        /// Нужно ли повторять обслуживание. Всегда true 
        /// </summary>
        public bool PerformRepeatedly
        {
            get { return _performRepeatedly; }
            set { _performRepeatedly = true; }
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
            get { return _sinceEffDate ?? (_sinceEffDate = Lifelength.Null); } 
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

        private Lifelength _repeatInterval;
        /// <summary>
        /// Интервал выполнения директивы
        /// </summary>
        public Lifelength RepeatInterval
        {
            get { return _repeatInterval ?? (_repeatInterval = Lifelength.Null); }
            set { _repeatInterval = value; }
        }

        #endregion

        #region public Lifelength RepeatNotification { get; set; }

        private Lifelength _repeatNotification;
        /// <summary>
        /// Ресурс предупреждения о приближающемся повторном выполнении директивы
        /// </summary>
        public Lifelength RepeatNotification
        {
            get { return _repeatNotification ?? (_repeatNotification = Lifelength.Null); }
            set { _repeatNotification = value; }
        }

        #endregion

        /*
         * Методы
         */

        #region public MaintenanceDirectiveThreshold()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public MaintenanceDirectiveThreshold()
        {
            //EffectiveDate = DateTime.Today;
            _performRepeatedly = true;
            _sinceNew = Lifelength.Null;
            FirstNotification = Lifelength.Null;
            _performRepeatedly = true;
            _repeatInterval = Lifelength.Null;
            RepeatNotification = Lifelength.Null;
            EffectiveDate = DateTimeExtend.GetCASMinDateTime();
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Представляет выполнение директивы в виде 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FirstPerformanceToString() + "\r\n" + ThresholdConditionToString(FirstPerformanceConditionType) + "\r\n" +
                   RepeatPerformanceToString() + "\r\n" + ThresholdConditionToString(RepeatPerformanceConditionType);
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
            StringBuilder stringBuilder = new StringBuilder();
            if (!FirstPerformanceSinceNew.IsNullOrZero() && !FirstPerformanceSinceEffectiveDate.IsNullOrZero())
            {
                stringBuilder.Append(FirstPerformanceSinceNew.ToStrings());
                stringBuilder.AppendLine("s./n.");
                stringBuilder.AppendLine("or");
                stringBuilder.Append(FirstPerformanceSinceEffectiveDate.ToStrings());
                stringBuilder.AppendLine("s/e.d.");
                stringBuilder.AppendLine(FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst ? "W.O.F" : "W.O.L");
            }
            else if (!FirstPerformanceSinceNew.IsNullOrZero())
            {
                stringBuilder.Append(FirstPerformanceSinceNew.ToStrings());
                if(FirstPerformanceSinceNew.NotNullParamsCount() > 1)
                    stringBuilder.AppendLine(FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst ? "W.O.F" : "W.O.L");
            }
            else if (!FirstPerformanceSinceEffectiveDate.IsNullOrZero())
            {
                stringBuilder.Append(FirstPerformanceSinceEffectiveDate.ToStrings());
                stringBuilder.AppendLine("s/e.d.");
                if (FirstPerformanceSinceEffectiveDate.NotNullParamsCount() > 1)
                    stringBuilder.AppendLine(FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst ? "W.O.F" : "W.O.L");
            }
            return stringBuilder.ToString();
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
            if (!FirstPerformanceSinceEffectiveDate.IsNullOrZero()) res = LifelengthToString(FirstPerformanceSinceEffectiveDate, "f.p.s.e.d");
            if (!FirstNotification.IsNullOrZero()) res += LifelengthToString(FirstNotification, "f.p.n");

            return "Perform at " + res.Trim();
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
            StringBuilder stringBuilder = new StringBuilder();
            if (!RepeatInterval.IsNullOrZero())
            {
                stringBuilder.Append(RepeatInterval.ToStrings());
                if (RepeatInterval.NotNullParamsCount() > 1)
                    stringBuilder.AppendLine(RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst ? "W.O.F" : "W.O.L");
            }
            return stringBuilder.ToString();
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
                return sizeof(long) + sizeof(bool) * 3 + Lifelength.SerializedDataLength * 5;
            }
        }
        #endregion

        #region public static MaintenanceDirectiveThreshold ConvertFromByteArray(byte[] data)
        /// <summary>
        /// Получает свойства из массива байт
        /// </summary>
        /// <param name="data"></param>
        public static MaintenanceDirectiveThreshold ConvertFromByteArray(byte[] data)
        {
            MaintenanceDirectiveThreshold item = new MaintenanceDirectiveThreshold();

            if (data == null) data = new byte[SerializedDataLength];
            int currentPos = 0;

            byte[] serializedEffectivityDate = new byte[sizeof(long)];
            Array.Copy(data, currentPos, serializedEffectivityDate, 0, sizeof(long));
            item.EffectiveDate = new DateTime(DbTypes.Int64FromByteArray(serializedEffectivityDate, 0));
            currentPos += sizeof (long);

            byte[] serializedPerformSinceNew = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, currentPos, serializedPerformSinceNew, 0, Lifelength.SerializedDataLength);
            item._sinceNew = Lifelength.ConvertFromByteArray(serializedPerformSinceNew);
            currentPos += Lifelength.SerializedDataLength;

            byte[] serializedSinceEffectivityLifelength = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, currentPos, serializedSinceEffectivityLifelength, 0, Lifelength.SerializedDataLength);
            item._sinceEffDate = Lifelength.ConvertFromByteArray(serializedSinceEffectivityLifelength);
            currentPos += Lifelength.SerializedDataLength;

            byte[] serializedNotification = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, currentPos, serializedNotification, 0, Lifelength.SerializedDataLength);
            item._firstNotification = Lifelength.ConvertFromByteArray(serializedNotification);
            currentPos += Lifelength.SerializedDataLength;

            item._performanceConditionType = data[currentPos] == 1 ? ThresholdConditionType.WhicheverLater : ThresholdConditionType.WhicheverFirst;
            currentPos += 1;

            item._performRepeatedly = data[currentPos] == 1;
            currentPos += 1;

            byte[] serializedrepeatPerform = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, currentPos, serializedrepeatPerform, 0, Lifelength.SerializedDataLength);
            item._repeatInterval = Lifelength.ConvertFromByteArray(serializedrepeatPerform);
            currentPos += Lifelength.SerializedDataLength;

            byte[] serializedRepeatNotificaction = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, currentPos, serializedRepeatNotificaction, 0, Lifelength.SerializedDataLength);
            item._repeatNotification = Lifelength.ConvertFromByteArray(serializedRepeatNotificaction);
            currentPos += Lifelength.SerializedDataLength;

            item._repeatPerformanceConditionType = data[currentPos] == 1 ? ThresholdConditionType.WhicheverLater : ThresholdConditionType.WhicheverFirst;

            return item;
        }
        #endregion

        #region public byte[] ToBinary()
        /// <summary>
        /// Представляет объект Directive Treshold в виде массива байтов для хранения в базе данных
        /// </summary>
        /// <returns></returns>
        public byte[] ToBinary()
        {
            List<byte> data = new List<byte>(SerializedDataLength);

            data.AddRange(DbTypes.Int64ToByteArray(EffectiveDate.Ticks));
            data.AddRange(FirstPerformanceSinceNew.ConvertToByteArray());
            data.AddRange(FirstPerformanceSinceEffectiveDate.ConvertToByteArray());
            data.AddRange(FirstNotification.ConvertToByteArray());
            data.Add((byte)(FirstPerformanceConditionType == ThresholdConditionType.WhicheverLater ? 1 : 0));
            data.Add((byte)(PerformRepeatedly ? 1 : 0));
            data.AddRange(RepeatInterval.ConvertToByteArray());
            data.AddRange(RepeatNotification.ConvertToByteArray());
            data.Add((byte)(RepeatPerformanceConditionType == ThresholdConditionType.WhicheverLater ? 1 : 0));
            return data.ToArray();
        }
        #endregion
    }
}
