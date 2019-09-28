using System;
using System.Collections.Generic;
using SmartCore.Auxiliary;
using SmartCore.Management;

namespace SmartCore.Calculations
{
    /// <summary>
    /// Класс описывает параметры выполнения директивы детали
    /// </summary>
    [Serializable]
    public class ComponentDirectiveThreshold : IThreshold
    {
        #region public ThresholdConditionType FirstPerformanceConditionType

        private ThresholdConditionType _performanceConditionType;
        /// <summary>
        /// Возвращает условие первого выполнения директивы
        /// </summary>
        public ThresholdConditionType FirstPerformanceConditionType
        {
            get { return _performanceConditionType; }
            set { _performanceConditionType = value; }
        }

        #endregion

        #region public ThresholdConditionType RepeatPerformanceConditionType
        /// <summary>
        /// Возвращает условие повторного выполнения директивы (У директивы детали условия первого и повторного выполнения одинаковы)
        /// </summary>
        public ThresholdConditionType RepeatPerformanceConditionType
        {
            get { return _performanceConditionType; }
            set { _performanceConditionType = value; }
        }

        #endregion

        #region public bool PerformRepeatedly { get; set; }

        private bool _performRepeatedly;
        /// <summary>
        /// Нужно ли повторять директиву
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
        /// Условие первого выполнения директивы с момента производства детали (по умочанию Lifelength.Null)
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
        /// Условие выполнения директивы с момента выпуска директивы (У директивы детали она равна Lifelength.Null)
        /// </summary>
        public Lifelength FirstPerformanceSinceEffectiveDate
        {
            get { return _sinceEffDate ?? (_sinceEffDate = Lifelength.Null); }
            set { _sinceEffDate = value; }
        }

        #endregion

        #region public Lifelength FirstNotification { get; set; }

        /// <summary>
        /// Ресурс предупреждения о приближающемся первом выполнении директивы
        /// </summary>
        public Lifelength FirstNotification { get; set; }

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

        /// <summary>
        /// Ресурс предупреждения о приближающемся повторном выполнении директивы
        /// </summary>
        public Lifelength RepeatNotification { get; set; }

        #endregion

        #region public Lifelength Warranty { get; set; }

        /// <summary>
        /// Длительность гарантии
        /// </summary>
        public Lifelength Warranty { get; set; }

        #endregion

        #region public Lifelength WarrantyNotification { get; set; }

        /// <summary>
        /// Предупреждение об окончании срока гарантии
        /// </summary>
        public Lifelength WarrantyNotification { get; set; }

		#endregion

		/*
		* Методы
		*/

		#region public ComponentDirectiveThreshold()
		/// <summary>
		/// Пустой конструктор
		/// </summary>
		public ComponentDirectiveThreshold()
        {
            //EffectiveDate = DateTime.Today;
            _sinceNew = new Lifelength();
            FirstNotification = new Lifelength();
            _performRepeatedly = true;
            RepeatInterval = new Lifelength ();
            RepeatNotification = new Lifelength();
            Warranty = new Lifelength();
            WarrantyNotification = new Lifelength();
            EffectiveDate = DateTimeExtend.GetCASMinDateTime();
        }
        #endregion

        public ComponentDirectiveThreshold(ComponentDirectiveThreshold source)
        {
            FirstPerformanceConditionType = source.FirstPerformanceConditionType;
            RepeatPerformanceConditionType = source.RepeatPerformanceConditionType;
            PerformRepeatedly = source.PerformRepeatedly;
            EffectiveDate = source.EffectiveDate;
            FirstPerformanceSinceNew = source.FirstPerformanceSinceNew;
            FirstPerformanceSinceEffectiveDate = source.FirstPerformanceSinceEffectiveDate;
            FirstNotification = source.FirstNotification;
            RepeatInterval = source.RepeatInterval;
            RepeatNotification = source.RepeatNotification;
            Warranty = source.Warranty;
            WarrantyNotification = source.WarrantyNotification;
        }

		#region public ComponentDirectiveThreshold(byte[] bytes)
		/// <summary>
		/// Получает данные из массива байтов 
		/// </summary>
		/// <param name="bytes"></param>
		public ComponentDirectiveThreshold(byte[] bytes)
        {
            ConvertFromSerializedData(bytes, SerializedDataLength);
        }
        #endregion

        #region public byte[] ToBinary()
        /// <summary>
        /// Представляет объект Directive Treshold в виде массива байтов для хранения в базе данных
        /// </summary>
        /// <returns></returns>
        public byte[] ToBinary()
        {
            List<byte> data = new List<byte>();

            data.AddRange(FirstPerformanceSinceNew.ConvertToByteArray());
            data.AddRange(FirstNotification.ConvertToByteArray());
            data.AddRange(RepeatInterval.ConvertToByteArray());
            data.AddRange(RepeatNotification.ConvertToByteArray());
            data.AddRange(Warranty.ConvertToByteArray());
            data.AddRange(WarrantyNotification.ConvertToByteArray());
            data.Add((byte)(_performRepeatedly ? 1 : 0));
            data.Add((byte)(FirstPerformanceConditionType == ThresholdConditionType.WhicheverLater ? 1 : 0));
            data.AddRange(DbTypes.Int64ToByteArray(EffectiveDate.Ticks));
            data.AddRange(FirstPerformanceSinceEffectiveDate.ConvertToByteArray());

            return data.ToArray();
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Представляет выполнение директивы в виде 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FirstPerformanceToString() + "\r\n" + RepeatPerformanceToString()+ "\r\n" +
                   WarrantyToString() + ThresholdConditionToString(FirstPerformanceConditionType);
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

        #region private string WarrantyToString()
        /// <summary>
        /// Возвращает условие гарантии
        /// </summary>
        /// <returns></returns>
        private string WarrantyToString()
        {
            string res = "";

            if (!Warranty.IsNullOrZero()) res = LifelengthToString(Warranty, "war");
            if (!WarrantyNotification.IsNullOrZero()) res += LifelengthToString(WarrantyNotification, "war.p");
         
            return res.Trim();
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

        #region public static void ConvertFromSerializedData(ref byte[] data, int serializedDataLength)
        /// <summary>
        /// Получает свойства из массива байт
        /// </summary>
        /// <param name="data"></param>
        /// <param name="serializedDataLength"></param>
        private void ConvertFromSerializedData(byte[] data, int serializedDataLength)
        {
            if (data == null) data = new byte[serializedDataLength];
            byte[] serializedFirstPerformance = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, 0, serializedFirstPerformance, 0, Lifelength.SerializedDataLength);

            FirstPerformanceSinceNew = Lifelength.ConvertFromByteArray(serializedFirstPerformance);

            byte[] serializedFirstNotification = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, Lifelength.SerializedDataLength, serializedFirstNotification, 0, Lifelength.SerializedDataLength);

            FirstNotification = Lifelength.ConvertFromByteArray(serializedFirstNotification);

            byte[] serializedrepeatPerform = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, Lifelength.SerializedDataLength*2, serializedrepeatPerform, 0, Lifelength.SerializedDataLength);

            RepeatInterval = Lifelength.ConvertFromByteArray(serializedrepeatPerform);

            byte[] serializedNotification = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, Lifelength.SerializedDataLength * 3, serializedNotification, 0, Lifelength.SerializedDataLength);

            RepeatNotification = Lifelength.ConvertFromByteArray(serializedNotification);

            byte[] serializedWarranty = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, Lifelength.SerializedDataLength * 4, serializedWarranty, 0, Lifelength.SerializedDataLength);

            Warranty = Lifelength.ConvertFromByteArray(serializedWarranty);

            byte[] serializedWarrantyNotification = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, Lifelength.SerializedDataLength * 5, serializedWarrantyNotification, 0, Lifelength.SerializedDataLength);

            WarrantyNotification = Lifelength.ConvertFromByteArray(serializedWarrantyNotification);

            _performRepeatedly = data[Lifelength.SerializedDataLength * 6] == 1;

            FirstPerformanceConditionType = data[Lifelength.SerializedDataLength * 6 + 1] == 1 ? ThresholdConditionType.WhicheverLater : ThresholdConditionType.WhicheverFirst;

            // если еще есть данные то рекурсивно считываем и его
            int dataIndex = serializedDataLength;
            int dataLeft = data.Length - dataIndex;

            if (dataLeft >= sizeof(long))
            {
                byte[] serializedEffectivityDate = new byte[sizeof(long)];
                Array.Copy(data, dataIndex, serializedEffectivityDate, 0, sizeof(long));

                EffectiveDate = new DateTime(DbTypes.Int64FromByteArray(serializedEffectivityDate, 0));
            }
            
            dataLeft -= sizeof (long);
            dataIndex += sizeof (long);

            if (dataLeft >= Lifelength.SerializedDataLength)
            {
                byte[] serializedRepeatNotificaction = new byte[Lifelength.SerializedDataLength];
                Array.Copy(data, dataIndex, serializedRepeatNotificaction, 0, Lifelength.SerializedDataLength);

                FirstPerformanceSinceEffectiveDate = Lifelength.ConvertFromByteArray(serializedRepeatNotificaction);
            }
        }
        #endregion

    }
}
