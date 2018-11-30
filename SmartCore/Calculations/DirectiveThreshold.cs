using System;
using System.Collections.Generic;
using System.Text;
using SmartCore.Management;

namespace SmartCore.Calculations
{

    /// <summary>
    /// Класс описывает параметры выполнения директивы
    /// </summary>
    [Serializable]
    public class DirectiveThreshold : IThreshold
    {

        #region public ThresholdConditionType FirstPerformanceConditionType

        /// <summary>
        /// Возвращает условие первого выполнения директивы
        /// </summary>
        public ThresholdConditionType FirstPerformanceConditionType { get; set; }

        #endregion

        #region public ThresholdConditionType RepeatPerformanceConditionType

        /// <summary>
        /// Возвращает условие повторного выполнения директивы
        /// </summary>
        public ThresholdConditionType RepeatPerformanceConditionType { get; set; }

        #endregion

        #region public bool PerformRepeatedly { get; set; }
        /// <summary>
        /// Нужно ли повторять директиву
        /// </summary>
        public bool PerformRepeatedly { get; set; }
        #endregion

        /*
         * Свойства (условия выполнения директивы)
         */

        #region public DateTime EffectiveDate { get; set;}

        /// <summary>
        /// Дата вступления директивы в действие - дата выпуска директивы
        /// </summary>
        public DateTime EffectiveDate { get; set;}

        #endregion

        #region public Lifelength FirstPerformanceSinceEffectiveDate{ get; set; }

        /// <summary>
        /// Условие выполнения директивы с момента выпуска директивы
        /// </summary>
        public Lifelength FirstPerformanceSinceEffectiveDate { get; set; }

        #endregion

        #region public Lifelength FirstPerformanceSinceNew { get; set; }

        /// <summary>
        /// Условие первого выполнения директивы с момента производства ВС 
        /// </summary>
        public Lifelength FirstPerformanceSinceNew { get; set; }

        #endregion

        #region public Lifelength FirstNotification { get; set; }

        /// <summary>
        /// Ресурс предупреждения о приближающемся выполнении директивы
        /// </summary>
        public Lifelength FirstNotification { get; set; }

        #endregion

        #region public Lifelength RepeatInterval { get; set; }

        /// <summary>
        /// Интервал выполнения директивы
        /// </summary>
        public Lifelength RepeatInterval { get; set; }

        #endregion

        #region public Lifelength RepeatNotification { get; set; }

        private Lifelength _repeatNotification;
        /// <summary>
        /// Ресурс предупреждения о приближающемся повторном выполнении директивы
        /// </summary>
        public Lifelength RepeatNotification
        {
            get { return _repeatNotification ?? (_repeatNotification = Lifelength.Null);} 
            set { _repeatNotification = value; }
        }

        #endregion

        // Флаги - 

        // Пример: директива повторяемая, но интервал повторений мы не знаем, 
        // поэтому ставим флаг, чтобы система не закрыла директиву при ее выполнении

        #region public bool PerformSinceNew { get; set; }

        /// <summary>
        /// Задан ли ресурс выполнения с момента производства ВС 
        /// </summary>
        public bool PerformSinceNew { get; set; }

        #endregion

        #region public bool PerformSinceEffectiveDate { get; set; }

        /// <summary>
        /// Нужно ли выполнять с момента вступления директивы в действие
        /// </summary>
        public bool PerformSinceEffectiveDate { get; set; }

        #endregion

        /*
         * Методы
         */

        #region public DirectiveThreshold()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public DirectiveThreshold()
        {
            EffectiveDate = DateTime.Today;
            FirstPerformanceSinceEffectiveDate = new Lifelength();
            FirstPerformanceSinceNew = new Lifelength();
            RepeatInterval = new Lifelength ();
            FirstNotification = new Lifelength();
            RepeatNotification = new Lifelength();
        }
        #endregion

        #region public DirectiveThreshold(byte[] bytes, byte[] condition)
        /// <summary>
        /// Получает данные из массива байтов 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="condition"></param>
        public DirectiveThreshold(byte[] bytes, byte[] condition)
        {
            ConvertFromSerializedData(bytes, SerializedDataLength);
            ConvertToCondition(condition);
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
            data.AddRange(RepeatInterval.ConvertToByteArray());
            data.AddRange(FirstNotification.ConvertToByteArray());
            data.Add((byte)(PerformSinceNew ? 1 : 0));
            data.Add((byte)(PerformSinceEffectiveDate ? 1 : 0));
            data.Add((byte)(PerformRepeatedly ? 1 : 0));
            data.AddRange(FirstPerformanceSinceEffectiveDate.ConvertToByteArray());
            data.AddRange(RepeatNotification.ConvertToByteArray());
            data.Add((byte)(FirstPerformanceConditionType == ThresholdConditionType.WhicheverLater ? 1 : 0));
            data.Add((byte)(RepeatPerformanceConditionType == ThresholdConditionType.WhicheverLater ? 1 : 0));
            //
            return data.ToArray();
        }
        #endregion

        #region public byte[] ThrldTypeToBinary()
        /// <summary>
        /// Представляет объект Directive Treshold в виде массива байтов для хранения в базе данных
        /// </summary>
        /// <returns></returns>
        public byte[] ThrldTypeToBinary()
        {
            List<byte> data = 
                new List<byte>(2)
                {
                    (byte)(FirstPerformanceConditionType == ThresholdConditionType.WhicheverLater ? 1 : 0),
                    (byte)(RepeatPerformanceConditionType == ThresholdConditionType.WhicheverLater ? 1 : 0)
                };

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
            return FirstPerformanceToString() + "\r\n" + ThresholdConditionToString(FirstPerformanceConditionType) + "\r\n" +
                (PerformRepeatedly ? " Perform Repeatedly " : "") +
                   RepeatPerformanceToString() + "\r\n" + ThresholdConditionToString(RepeatPerformanceConditionType);
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
                if (FirstPerformanceSinceNew.NotNullParamsCount() > 1)
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

        #region private string RepeatPerformanceToString()
        /// <summary>
        /// Возвращает условие повторного выполнения директивы
        /// </summary>
        /// <returns></returns>
        private string RepeatPerformanceToString()
        {
            string res = "and then repeat every ";

            if (!RepeatInterval.IsNullOrZero()) res = LifelengthToString(RepeatInterval, "r.p");
            if (!RepeatNotification.IsNullOrZero()) res += LifelengthToString(RepeatNotification, "r.p.n");

            return res.Trim();
        }
        #endregion

        #region public string RepeatPerformanceToStrings()
        /// <summary> 
        /// Возвращает условие повторного выполнения директивы в виде строки (Каждый параметр выводится в новой строке)
        /// </summary>
        /// <returns></returns>
        public string RepeatPerformanceToStrings()
        {
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

        #region private string LifelengthToString(Lifelength lifelength, string label)
        /// <summary>
        /// Представляет наработку в виде строки
        /// </summary>
        /// <param name="lifelength"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        private static string LifelengthToString(Lifelength lifelength, string label)
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
        private static string ThresholdConditionToString(ThresholdConditionType type)
        {
            if (type == ThresholdConditionType.WhicheverFirst )
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

        /*
         * Реализация
         */

        #region public static int SerializedDataLength { get; }
        ///<summary>
        /// Размер сериализованных данных объекта
        ///</summary>
        public static int SerializedDataLength
        {
            get
            {
                return sizeof(long) + sizeof(bool) * 3 + Lifelength.SerializedDataLength * 4;
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
            byte[] serializedEffectivityDate = new byte[sizeof(long)];
            Array.Copy(data, 0, serializedEffectivityDate, 0, sizeof(long));

            EffectiveDate = new DateTime(DbTypes.Int64FromByteArray(serializedEffectivityDate, 0));

            byte[] serializedPerformSinceNew = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, sizeof(long), serializedPerformSinceNew, 0, Lifelength.SerializedDataLength);

            FirstPerformanceSinceNew = Lifelength.ConvertFromByteArray(serializedPerformSinceNew);

            byte[] serializedrepeatPerform = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, sizeof(long) + Lifelength.SerializedDataLength, serializedrepeatPerform, 0, Lifelength.SerializedDataLength);

            RepeatInterval = Lifelength.ConvertFromByteArray(serializedrepeatPerform);

            byte[] serializedNotification = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, sizeof(long) + Lifelength.SerializedDataLength * 2, serializedNotification, 0, Lifelength.SerializedDataLength);

            FirstNotification = Lifelength.ConvertFromByteArray(serializedNotification);

            PerformSinceNew = data[sizeof(long) + Lifelength.SerializedDataLength * 3] == 1;
            PerformSinceEffectiveDate = data[sizeof(long) + Lifelength.SerializedDataLength * 3 + 1] == 1;
            PerformRepeatedly = data[sizeof(long) + Lifelength.SerializedDataLength * 3 + 2] == 1;

            byte[] serializedSinceEffectivityLifelength = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, sizeof(long) + Lifelength.SerializedDataLength * 3 + 3, serializedSinceEffectivityLifelength, 0, Lifelength.SerializedDataLength);

            FirstPerformanceSinceEffectiveDate = Lifelength.ConvertFromByteArray(serializedSinceEffectivityLifelength);

            // если у нас еще есть данные то рекурсивно считываем и его
            int dataIndex = SerializedDataLength;
            int dataLeft = data.Length - SerializedDataLength;

            if (dataLeft >= Lifelength.SerializedDataLength)
            {
                byte[] serializedRepeatNotificaction = new byte[Lifelength.SerializedDataLength];
                Array.Copy(data, sizeof(long) + Lifelength.SerializedDataLength * 4 + 3, serializedRepeatNotificaction, 0, Lifelength.SerializedDataLength);

                RepeatNotification = Lifelength.ConvertFromByteArray(serializedRepeatNotificaction);

                dataLeft -= Lifelength.SerializedDataLength;
                dataIndex += Lifelength.SerializedDataLength;
            }

            if (dataLeft >= sizeof(byte))
            {
                FirstPerformanceConditionType = data[dataIndex] == 0
                                                    ? ThresholdConditionType.WhicheverFirst
                                                    : ThresholdConditionType.WhicheverLater;
                dataLeft -= sizeof(byte);
                dataIndex += sizeof(byte);
            }

            if (dataLeft >= sizeof(byte))
            {
                RepeatPerformanceConditionType = data[dataIndex] == 0
                                                    ? ThresholdConditionType.WhicheverFirst
                                                    : ThresholdConditionType.WhicheverLater;
            }
        }
        #endregion

        #region public static DirectiveThreshold ConvertFromByteArray(byte[] data)
        /// <summary>
        /// Получает свойства из массива байт
        /// </summary>
        /// <param name="data"></param>
        public static DirectiveThreshold ConvertFromByteArray(byte[] data)
        {
            DirectiveThreshold item = new DirectiveThreshold();

            if (data == null) data = new byte[SerializedDataLength];
            byte[] serializedEffectivityDate = new byte[sizeof(long)];
            Array.Copy(data, 0, serializedEffectivityDate, 0, sizeof(long));

            item.EffectiveDate = new DateTime(DbTypes.Int64FromByteArray(serializedEffectivityDate, 0));

            byte[] serializedPerformSinceNew = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, sizeof(long), serializedPerformSinceNew, 0, Lifelength.SerializedDataLength);

            item.FirstPerformanceSinceNew = Lifelength.ConvertFromByteArray(serializedPerformSinceNew);

            byte[] serializedrepeatPerform = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, sizeof(long) + Lifelength.SerializedDataLength, serializedrepeatPerform, 0, Lifelength.SerializedDataLength);

            item.RepeatInterval = Lifelength.ConvertFromByteArray(serializedrepeatPerform);

            byte[] serializedNotification = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, sizeof(long) + Lifelength.SerializedDataLength * 2, serializedNotification, 0, Lifelength.SerializedDataLength);

            item.FirstNotification = Lifelength.ConvertFromByteArray(serializedNotification);

            item.PerformSinceNew = data[sizeof(long) + Lifelength.SerializedDataLength * 3] == 1;
            item.PerformSinceEffectiveDate = data[sizeof(long) + Lifelength.SerializedDataLength * 3 + 1] == 1;
            item.PerformRepeatedly = data[sizeof(long) + Lifelength.SerializedDataLength * 3 + 2] == 1;

            byte[] serializedSinceEffectivityLifelength = new byte[Lifelength.SerializedDataLength];
            Array.Copy(data, sizeof(long) + Lifelength.SerializedDataLength * 3 + 3, serializedSinceEffectivityLifelength, 0, Lifelength.SerializedDataLength);

            item.FirstPerformanceSinceEffectiveDate = Lifelength.ConvertFromByteArray(serializedSinceEffectivityLifelength);

            // если у нас еще есть данные то рекурсивно считываем и его
            int dataIndex = SerializedDataLength;
            int dataLeft = data.Length - SerializedDataLength;

            if (dataLeft >= Lifelength.SerializedDataLength)
            {
                byte[] serializedRepeatNotificaction = new byte[Lifelength.SerializedDataLength];
                Array.Copy(data, sizeof(long) + Lifelength.SerializedDataLength * 4 + 3, serializedRepeatNotificaction, 0, Lifelength.SerializedDataLength);

                item.RepeatNotification = Lifelength.ConvertFromByteArray(serializedRepeatNotificaction);

                dataLeft -= Lifelength.SerializedDataLength;
                dataIndex += Lifelength.SerializedDataLength;
            }

            if (dataLeft >= sizeof(byte))
            {
                item.FirstPerformanceConditionType = data[dataIndex] == 0
                                                    ? ThresholdConditionType.WhicheverFirst
                                                    : ThresholdConditionType.WhicheverLater;
                dataLeft -= sizeof(byte);
                dataIndex += sizeof(byte);
            }

            if (dataLeft >= sizeof(byte))
            {
                item.RepeatPerformanceConditionType = data[dataIndex] == 0
                                                    ? ThresholdConditionType.WhicheverFirst
                                                    : ThresholdConditionType.WhicheverLater;
            }

            return item;
        }
        #endregion

        #region public static void ConvertToCondition(ref byte[] data)
        /// <summary>
        /// Получает свойства из массива байт
        /// </summary>
        /// <param name="data"></param>
        public void ConvertToCondition(byte[] data)
        {
            if (data == null) data = new byte[2];

            FirstPerformanceConditionType = data[0] == 0
                                                ? ThresholdConditionType.WhicheverFirst
                                                : ThresholdConditionType.WhicheverLater;

            RepeatPerformanceConditionType = data[1] == 0
                                                ? ThresholdConditionType.WhicheverFirst
                                                : ThresholdConditionType.WhicheverLater; 
        }
        #endregion

    }
}
