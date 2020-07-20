using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using SmartCore.Management;
using SmartCore.Auxiliary;
using SmartCore.Entities.General.MTOP;
using Convert = System.Convert;

namespace SmartCore.Calculations
{
    /// <summary>
    /// Описывает наработку (ресурс)
    /// </summary>
    [Serializable]
    public class Lifelength : IComparable, IEquatable<Lifelength>, IEqualityComparer<Lifelength>
    {

        /*
         * Свойства
         */

        #region public Int32? Cycles { get; set; }
        /// <summary>
        /// Количество циклов
        /// </summary>
        public Int32? Cycles { get; set; }
        #endregion

        #region public Int32? Hours { get; set; }
        /// <summary>
        /// Количество часов 
        /// </summary>
        public Int32? Hours
        {
            get { return TotalMinutes != null ? new Int32?(TotalMinutes.Value / 60) : null; }
            set
            {
                // Если задаваемое значение null, то просто присваиваем null, не обращая внимания на прошлое заданное значение
                if (value == null)
                {
                    TotalMinutes = null;
                }
                // Если прошлое значение не было задано до этого
                else if (TotalMinutes == null)
                {
                    TotalMinutes = value.Value * 60;
                }
                // Если значение уже было задано до этого
                else
                {
                    TotalMinutes = value.Value * 60 + Minutes;
                }
            }
        }
        #endregion

        #region public Int32? Minutes { get; set; }
        /// <summary>
        /// Количество минут 
        /// </summary>
        public Int32? Minutes
        {
            get { return TotalMinutes != null ? new Int32?(TotalMinutes.Value % 60) : null; }
            set
            {
                // Если значение null, то просто присваиваем null, не обращая внимания на прошлое заданное значение
                if (value == null)
                {
                    TotalMinutes = null;
                }
                // Если не null, но прошлое значение не было задано 
                else if (TotalMinutes == null)
                {
                    TotalMinutes = value.Value;
                }
                // Если новое значение не пустое и значение было задано до этого
                else
                {
                    TotalMinutes = Hours * 60 + value.Value;
                }
            }
        }
        #endregion

        #region public Int32? TotalMinutes { get; set; }
        /// <summary>
        /// Полное количество минут (оно и хранится в базе данных)
        /// </summary>
        public Int32? TotalMinutes { get; set; }
        #endregion

        #region public Int32? Days { get; set; }
        /// <summary>
        /// Количество дней
        /// </summary>
        public Int32? Days
        {
            get { return CalendarSpan.Days; }
            set 
            { 
                CalendarSpan.CalendarValue = value;
                CalendarSpan.CalendarType = CalendarTypes.Days;
            }
        }
        #endregion

        #region public Int32? CalendarValue { get; set; }
        /// <summary>
        /// Календарное значение
        /// </summary>
        public Int32? CalendarValue
        {
            get { return _calendarSpan != null ? _calendarSpan.CalendarValue : null; }
            set { CalendarSpan.CalendarValue = value; }
        }
        #endregion

        #region public CalendarTypes CalendarType { get; set; }
        /// <summary>
        /// Тип календаря
        /// </summary>
        public CalendarTypes CalendarType
        {
            get { return _calendarSpan != null ? _calendarSpan.CalendarType : CalendarTypes.Days; }
            set { CalendarSpan.CalendarType = value; }
        }
        #endregion

        #region public CalendarSpan CalendarSpan { get; set; }

        private CalendarSpan _calendarSpan;

        /// <summary>
        /// Тип календаря
        /// </summary>
        public CalendarSpan CalendarSpan
        {
            get { return _calendarSpan ?? (_calendarSpan = new CalendarSpan()); }
            set { _calendarSpan = value; }
        }
        #endregion

        /*
         * Статические объекты
         */

        #region public static Lifelength Zero { get; }
        /// <summary>
        /// Возвращает наработку (ресурс) с нулевыми (но не пустыми) параметрами
        /// </summary>
        public static Lifelength Zero
        {
            get
            {
                return new Lifelength(0, 0, 0);
            }
        }
        #endregion

        #region public static Lifelength Null { get; }
        /// <summary>
        /// Возвращает наработку (ресурс) с пустыми параметрами 
        /// </summary>
        public static Lifelength Null
        {
            get
            {
                return new Lifelength();
            }
        }
        #endregion

        #region public static int SerializedDataLength { get; }
        /// <summary>
        /// Gets length of any serialized <see cref="Lifelength"/>
        /// </summary>
        public static int SerializedDataLength
        {
            get { return 21; }
        }
        #endregion

        /*
         * Конструктор 
         */

        #region public Lifelength()
        /// <summary>
        /// Создает наработку (ресурс) с пустыми параметрами
        /// </summary>
        public Lifelength()
        {
        }
        #endregion

        #region public Lifelength(Int32? days, Int32? cycles, Int32? totalMinutes)
        /// <summary>
        /// Создает наработку (ресурс) с известными параметрами
        /// </summary>
        /// <param name="days"></param>
        /// <param name="cycles"></param>
        /// <param name="totalMinutes"></param>
        public Lifelength(Int32? days, Int32? cycles, Int32? totalMinutes)
        {
            Days = days;
            Cycles = cycles;
            TotalMinutes = totalMinutes;
        }
        #endregion

        #region public Lifelength(Lifelength source)
        /// <summary>
        /// Копирует наработку (Создает новую наработку с такими же параметрами)
        /// </summary>
        /// <param name="source"></param>
        public Lifelength(Lifelength source)
        {
            if (source == null) return;
            //
            Cycles = source.Cycles;
            CalendarSpan = new CalendarSpan(source.CalendarSpan);
            //Days = source.Days;
            TotalMinutes = source.TotalMinutes;
        }
        #endregion

        /*
         * Методы
         */

        #region public static Lifelength ConvertFromByteArray(byte[] data)
        /// <summary>
        /// Конвертирует данные из БД в Lifelength
        /// </summary>
        /// <param name="data"></param>
        public static Lifelength ConvertFromByteArray(byte[] data)
        {

            Lifelength item = new Lifelength();

            byte[] binaryData = data;
            if (null == binaryData) return null;

	        if (binaryData == null || binaryData.Length != SerializedDataLength)
		        return null;//на случай если -1 пришел
                //throw new ArgumentException("Data cannot be converted to Lifelength");

            item.Cycles = DbTypes.Int32FromByteArray(binaryData, 1);

            long calendar = DbTypes.Int64FromByteArray(binaryData, 5);
            TimeSpan cal = new TimeSpan(calendar);

            item.CalendarSpan = new CalendarSpan(cal.Days, (CalendarTypes)cal.Milliseconds);

            long ticks = DbTypes.Int64FromByteArray(binaryData, 13);
            TimeSpan ts = new TimeSpan(ticks);
            item.TotalMinutes = ts.Minutes + ((int)ts.TotalHours) * 60;

            if ((binaryData[0] & 1) == 0) 
                item.Days = null;
            if ((binaryData[0] >> 1 & 1) == 0) 
                item.Cycles = null;
            if ((binaryData[0] >> 2 & 1) == 0) 
                item.Hours = null;

            return item;
        }

        #endregion

        #region public byte[] ConvertToByteArray()
        ///<summary>
        /// Создается массив байт, представляющий наработку для сохранения в базе
        ///</summary>
        ///<returns>Созданные данные</returns>
        public byte[] ConvertToByteArray()
        {
            byte[] binaryData = new byte[SerializedDataLength];
            binaryData[0] = (byte)((Days != null ? 1 : 0) +
                                    ((Cycles != null ? 1 : 0) << 1) +
                                    ((Hours != null ? 1 : 0) << 2));
            Array.Copy(Cycles != null ? DbTypes.Int32ToByteArray(Cycles.Value) : DbTypes.Int32ToByteArray(0), 0, binaryData, 1, 4);

            TimeSpan days = CalendarValue != null ? new TimeSpan((int)CalendarValue, 0, 0, 0, (int)CalendarType) : new TimeSpan(0);
            Array.Copy(DbTypes.Int64ToByteArray(days.Ticks), 0, binaryData, 5, 8);
            
            TimeSpan hours = TotalMinutes != null ? new TimeSpan(0, 0, (int)TotalMinutes, 0) : new TimeSpan(0);
            Array.Copy(DbTypes.Int64ToByteArray(hours.Ticks), 0, binaryData, 13, 8);
            return binaryData;
        }
        #endregion

        #region public void Resemble(Lifelength sample)
        /// <summary>
        /// Сделать похожим на заданный ресурс. Т.е. если не заданы часы - сделать часы n/a и т.д.
        /// </summary>
        /// <param name="sample"></param>
        public void Resemble(Lifelength sample)
        {
            if (sample.TotalMinutes == null) TotalMinutes = null;
            if (sample.Cycles == null) Cycles = null;
            if (sample.Days == null) Days = null;
        }
        #endregion

        #region public void SetMax(Lifelength candidate)
        /// <summary>
        /// По выходу объект будет представлять содержитать максимальные ресурсы от обоих объектов (whichever later)
        /// </summary>
        /// <param name="candidate"></param>
        public void SetMax(Lifelength candidate)
        {
            // Если у кандидата циклы больше чем у текущего объекта - присваиваем максимальные циклы
            if (candidate.Cycles != null && (Cycles == null || Cycles < candidate.Cycles))
                Cycles = candidate.Cycles;

            // то же по часам 
            if (candidate.TotalMinutes != null && (TotalMinutes == null || TotalMinutes < candidate.TotalMinutes))
                TotalMinutes = candidate.TotalMinutes;

            // то же по календарю
            if (candidate.Days != null && (Days == null || Days < candidate.Days))
                Days = candidate.Days;

        }
        #endregion

        #region public void SetMin(Lifelength candidate)
        /// <summary>
        /// По выходу объект будет представлять содержитать минимальных ресурсов от обоих объектов (whichever first)
        /// </summary>
        /// <param name="candidate"></param>
        public void SetMin(Lifelength candidate)
        {
            // Если у кандидата циклы меньше чем у текущего объекта - присваиваем минимальные циклы
            if (candidate.Cycles != null && (Cycles == null || Cycles > candidate.Cycles))
                Cycles = candidate.Cycles;

            // то же по часам 
            if (candidate.TotalMinutes != null && (TotalMinutes == null || TotalMinutes > candidate.TotalMinutes))
                TotalMinutes = candidate.TotalMinutes;

            // то же по календарю
            if (candidate.Days != null && (Days == null || Days > candidate.Days))
                Days = candidate.Days;

        }
        #endregion

        #region public void CompleteNullParameters (Lifelength source)
        /// <summary>
        /// Дополняет пустые параметры текущего объекта параметрами из источника
        /// </summary>
        /// <param name="source"></param>
        public void CompleteNullParameters(Lifelength source)
        {
            if (Cycles == null) Cycles = source.Cycles;
            if (TotalMinutes == null) TotalMinutes = source.TotalMinutes;
            if (Days == null) Days = source.Days;
        }

        #endregion

        public void  AddPersent(double b)
        {
	        if (TotalMinutes != null) TotalMinutes += Convert.ToInt32(Convert.ToInt32(TotalMinutes) * (b/100));
	        if (Cycles != null) Cycles += Convert.ToInt32(Convert.ToInt32(Cycles) * (b / 100));
	        if (CalendarValue != null) CalendarValue += Convert.ToInt32(Convert.ToInt32(CalendarValue) * (b / 100));
        }

        public MTOPCheck ParentCheck { get; set; }

        /*
         * Арифметика 
         */

        #region public bool IsLessByAnyParameter(Lifelength lifelength)
        /// <summary>
        /// Метод проверяет, является ли данная наработка меньше заданной по любому из трех параметров
        /// </summary>
        /// <param name="lifelength"></param>
        /// <returns></returns>
        public bool IsLessByAnyParameter(Lifelength lifelength)
        {
            //Cycles
            if (Cycles != null && lifelength.Cycles != null && Cycles < lifelength.Cycles) return true;
            // TotalMinutes
            if (TotalMinutes != null && lifelength.TotalMinutes != null && TotalMinutes < lifelength.TotalMinutes) return true;
            // Days
            if (Days != null && lifelength.Days != null && Days < lifelength.Days) return true;

            return false;
        }
        #endregion

        #region public bool IsLessOrEqualByAnyParameter(Lifelength lifelength)
        /// <summary>
        /// Метод проверяет, является ли данная наработка меньше или равно по любому из трех параметров
        /// </summary>
        /// <param name="lifelength"></param>
        /// <returns></returns>
        public bool IsLessOrEqualByAnyParameter(Lifelength lifelength)
        {
            //Cycles
            if (Cycles != null && lifelength.Cycles != null && Cycles <= lifelength.Cycles) return true;
            // TotalMinutes
            if (TotalMinutes != null && lifelength.TotalMinutes != null && TotalMinutes <= lifelength.TotalMinutes) return true;
            // Days
            if (Days != null && lifelength.Days != null && Days <= lifelength.Days) return true;

            return false;
        }
        #endregion

        #region public bool IsLessByAnyParameterNullable(Lifelength lifelength)
        /// <summary>
        /// Метод проверяет, является ли данная наработка строго меньшей заданной по всем трем параметрам
        /// NULL параметры заданной наработки не сравниваются. 
        /// </summary>
        /// <param name="lifelength"></param>
        /// <returns></returns>
        public bool IsLessByAnyParameterNullable(Lifelength lifelength)
        {
            if (lifelength.IsNullOrZero()) return false;
            if (IsNullOrZero() && !lifelength.IsNullOrZero()) return true;

            int? cyclesValue = Cycles ?? 0;
            int? minutesValue = TotalMinutes ?? 0;
            int? daysValue = Days ?? 0;
            int? llCyclesValue = lifelength.Cycles ?? 0;
            int? llMinutesValue = lifelength.TotalMinutes ?? 0;
            int? llDaysValue = lifelength.Days ?? 0;

            if (cyclesValue < llCyclesValue) return true;//циклы заданной наработки меньше
            if (minutesValue < llMinutesValue) return true;//время заданной наработки меньше
            if (daysValue < llDaysValue) return  true;//дни заданной наработки меньше

            return false;
        }
        #endregion

        #region public bool IsLess(Lifelength lifelength)

	    /// <summary>
	    /// Метод проверяет, является ли данная наработка строго меньшей заданной по всем трем параметрам
	    /// </summary>
	    /// <param name="lifelength"></param>
	    /// <param name="strictCompare"></param>
	    /// <returns></returns>
	    public bool IsLess(Lifelength lifelength, bool strictCompare = true)
        {
            if (Cycles != null && lifelength.Cycles != null && Cycles < lifelength.Cycles &&
                TotalMinutes != null && lifelength.TotalMinutes != null && TotalMinutes < lifelength.TotalMinutes &&
                Days != null && lifelength.Days != null && Days < lifelength.Days) return true;
            return false;

            if (lifelength == null) lifelength = Null;

            Boolean cycles, days, minutes;

            if (strictCompare)
            {
                if ((Cycles == null && lifelength.Cycles == null) || (Cycles != null && lifelength.Cycles != null && Cycles == lifelength.Cycles))
                    cycles = true;
                else
                    cycles = false;

                if ((Days == null && lifelength.Days == null) || (Days != null && lifelength.Days != null && Days == lifelength.Days))
                    days = true;
                else
                    days = false;

                if ((TotalMinutes == null && lifelength.TotalMinutes == null) || (TotalMinutes != null && lifelength.TotalMinutes != null && TotalMinutes == lifelength.TotalMinutes))
                    minutes = true;
                else
                    minutes = false;
            }
            else
            {
                if ((Cycles == null) || (lifelength.Cycles == null) || (Cycles == lifelength.Cycles))
                    cycles = true;
                else
                    cycles = false;

                if ((Days == null) || (lifelength.Days == null) || (Days == lifelength.Days))
                    days = true;
                else
                    days = false;

                if ((TotalMinutes == null) || (lifelength.TotalMinutes == null) || (TotalMinutes == lifelength.TotalMinutes))
                    minutes = true;
                else
                    minutes = false;
            }

            return cycles && minutes && days;
        }
        #endregion

        #region public bool IsLessIgnoreNulls(Lifelength lifelength)
        /// <summary>
        /// Метод проверяет, является ли данная наработка строго меньшей заданной по всем трем параметрам
        /// <br/> Null параметры обеих наработок игнорируются при сравнении
        /// </summary>
        /// <param name="lifelength"></param>
        /// <returns></returns>
        public bool IsLessIgnoreNulls(Lifelength lifelength)
        {
            if (lifelength == null) lifelength = Null;
            if (IsNullOrZero() && !lifelength.IsNullOrZero())
                return true;

            bool cyclesCompare = Cycles != null && lifelength.Cycles != null;
            bool daysCompare = Days != null && lifelength.Days != null;
            bool minutesCompare = TotalMinutes != null && lifelength.TotalMinutes != null;

            Boolean cyclesLess, daysLess, minutesLess;

            if (cyclesCompare &&Cycles < lifelength.Cycles)
                cyclesLess = true;
            else
                cyclesLess = false;

            if (daysCompare && Days < lifelength.Days)
                daysLess = true;
            else
                daysLess = false;

            if (minutesCompare && TotalMinutes < lifelength.TotalMinutes)
                minutesLess = true;
            else
                minutesLess = false;

            if (cyclesCompare && daysCompare && minutesCompare)
                return cyclesLess && minutesLess && daysLess;
            if (cyclesCompare && daysCompare)
                return cyclesLess && daysLess;
            if (cyclesCompare && minutesCompare)
                return cyclesLess && minutesLess;
            if (daysCompare && minutesCompare)
                return minutesLess && daysLess;
            if (cyclesCompare)
                return cyclesLess;
            if (daysCompare)
                return daysLess;
            if (minutesCompare)
                return minutesLess;

            return false;
        }
        #endregion

        #region public bool IsGreaterByAnyParameter(Lifelength lifelength)
        /// <summary>
        /// Метод проверяет, является ли данная наработка больше заданной по любому из трех параметров
        /// </summary>
        /// <param name="lifelength"></param>
        /// <returns></returns>
        public bool IsGreaterByAnyParameter(Lifelength lifelength)
        {
            // 10, 10, 10 > 5, 5, 5
            // 10, 10, 10 > 5, 20, 5
            //Cycles
            if (Cycles != null && lifelength.Cycles != null && Cycles > lifelength.Cycles) return true;
            // TotalMinutes
            if (TotalMinutes != null && lifelength.TotalMinutes != null && TotalMinutes > lifelength.TotalMinutes) return true;
            // Days
            if (Days != null && lifelength.Days != null && Days > lifelength.Days) return true;

            return false;
        }
        #endregion

        #region public bool IsGreaterOrEqualByAllParameters(Lifelength lifelength)
        /// <summary>
        /// Метод проверяет, является ли данная наработка больше или равной заданной по любому из трех параметров
        /// </summary>
        /// <param name="lifelength"></param>
        /// <returns></returns>
        public bool IsGreaterOrEqualByAllParameters(Lifelength lifelength)
        {
            //Cycles
            if (Cycles != null && lifelength.Cycles != null && Cycles >= lifelength.Cycles) return true;
            // TotalMinutes
            if (TotalMinutes != null && lifelength.TotalMinutes != null && TotalMinutes >= lifelength.TotalMinutes) return true;
            // Days
            if (Days != null && lifelength.Days != null && Days >= lifelength.Days) return true;

            return false;
        }
        #endregion

        #region public bool IsGreaterNullable(Lifelength lifelength)
        /// <summary>
        /// Метод проверяет, является ли данная наработка строго больше заданной по всем трем параметрам. 
        /// NULL параметры заданной наработки не сравниваются. 
        /// </summary>
        /// <param name="lifelength"></param>
        /// <returns></returns>
        public bool IsGreaterNullable(Lifelength lifelength)
        {
            // IsNull   and IsNull     = false
            // IsNull   and 10,10,10   = false
            // 10,10,10 and IsNull     = true
            if (IsNullOrZero()) return false;
            if (!IsNullOrZero() && lifelength.IsNullOrZero()) return true;

            int? cyclesValue = Cycles ?? 0;
            int? minutesValue = TotalMinutes ?? 0;
            int? daysValue = Days ?? 0;
            int? llCyclesValue = lifelength.Cycles ?? 0;
            int? llMinutesValue = lifelength.TotalMinutes ?? 0;
            int? llDaysValue = lifelength.Days ?? 0;

            if (cyclesValue > llCyclesValue) return true;//циклы заданной наработки меньше
            if (minutesValue > llMinutesValue) return true;//время заданной наработки меньше
            if (daysValue > llDaysValue) return true;//дни заданной наработки меньше

            return false;

            //bool cyclesCompared = true, minutesCompared = true, daysCompared = true;

            //if (Cycles != null && lifelength.Cycles != null)
            //{
            //    if (Cycles <= lifelength.Cycles) return false;
            //}
            //else cyclesCompared = false;

            //if (TotalMinutes != null && lifelength.TotalMinutes != null)
            //{
            //    if (TotalMinutes <= lifelength.TotalMinutes) return false;
            //}
            //else minutesCompared = false;

            //if (Days != null && lifelength.Days != null)
            //{
            //    if (Days <= lifelength.Days) return false;
            //}
            //else daysCompared = false;

            //return cyclesCompared || minutesCompared || daysCompared;
        }
        #endregion

        #region public bool IsGreater(Lifelength lifelength)
        /// <summary>
        /// Метод проверяет, является ли данная наработка строго больше заданной по всем трем параметрам
        /// если в данной или заданной наработке есть NULL, то возвращается false
        /// </summary>
        /// <param name="lifelength"></param>
        /// <returns></returns>
        public bool IsGreater(Lifelength lifelength)
        {
            // 10, 10, 10 > 5, 5, 5
            // 10, 10, 10 !> 5, 20, 5
            if (Cycles != null)
            {
                if (lifelength.Cycles != null)
                {
                    if (Cycles <= lifelength.Cycles) return false;
                }
				else return false;
			}
            else return false;

            if (TotalMinutes != null)
            {
                if (lifelength.TotalMinutes != null)
                {
                    if (TotalMinutes <= lifelength.TotalMinutes) return false;
                }
				else return false;
			}
            else return false;

            if (Days != null)
            {
                if (lifelength.Days != null)
                {
                    if (Days <= lifelength.Days) return false;
                }
				else return false;
			}
            else return false;

            return true;
        }
		#endregion

		public bool IsGreaterNew(Lifelength lifelength)
		{
			// 10, 10, 10 > 5, 5, 5
			// 10, 10, 10 !> 5, 20, 5
			if (Cycles != null)
			{
				if (lifelength.Cycles != null)
				{
					if (Cycles <= lifelength.Cycles) return false;
				}
				else return false;
			}

			if (TotalMinutes != null)
			{
				if (lifelength.TotalMinutes != null)
				{
					if (TotalMinutes <= lifelength.TotalMinutes) return false;
				}
				else return false;
			}

			if (Days != null)
			{
				if (lifelength.Days != null)
				{
					if (Days <= lifelength.Days) return false;
				}
				else return false;
			}

			return true;
		}


		public bool IsLessNew(Lifelength lifelength)
		{
			// 10, 10, 10 > 5, 5, 5
			// 10, 10, 10 !> 5, 20, 5
			if (Cycles != null)
			{
				if (lifelength.Cycles != null)
				{
					if (Cycles > lifelength.Cycles) return false;
				}
				else return false;
			}

			if (TotalMinutes != null)
			{
				if (lifelength.TotalMinutes != null)
				{
					if (TotalMinutes > lifelength.TotalMinutes) return false;
				}
				else return false;
			}

			if (Days != null)
			{
				if (lifelength.Days != null)
				{
					if (Days > lifelength.Days) return false;
				}
				else return false;
			}

			return true;
		}


		#region public bool IsGratherIgnoreNulls(Lifelength lifelength)
		/// <summary>
		/// Метод проверяет, является ли данная наработка строго большей заданной по всем трем параметрам
		/// <br/> Null параметры обеих наработок игнорируются при сравнении
		/// </summary>
		/// <param name="lifelength"></param>
		/// <returns></returns>
		public bool IsGratherIgnoreNulls(Lifelength lifelength)
        {
            if (lifelength == null) lifelength = Null;
            if (IsNullOrZero() && !lifelength.IsNullOrZero())
                return true;

            bool cyclesCompare = Cycles != null && lifelength.Cycles != null;
            bool daysCompare = Days != null && lifelength.Days != null;
            bool minutesCompare = TotalMinutes != null && lifelength.TotalMinutes != null;

            Boolean cyclesLess, daysLess, minutesLess;

            if (cyclesCompare && Cycles > lifelength.Cycles)
                cyclesLess = true;
            else
                cyclesLess = false;

            if (daysCompare && Days > lifelength.Days)
                daysLess = true;
            else
                daysLess = false;

            if (minutesCompare && TotalMinutes > lifelength.TotalMinutes)
                minutesLess = true;
            else
                minutesLess = false;

            if (cyclesCompare && daysCompare && minutesCompare)
                return cyclesLess && minutesLess && daysLess;
            if (cyclesCompare && daysCompare)
                return cyclesLess && daysLess;
            if (cyclesCompare && minutesCompare)
                return cyclesLess && minutesLess;
            if (daysCompare && minutesCompare)
                return minutesLess && daysLess;
            if (cyclesCompare)
                return cyclesLess;
            if (daysCompare)
                return daysLess;
            if (minutesCompare)
                return minutesLess;

            return false;
        }
        #endregion

        #region public double? GetPercents(Lifelength lifelength)

        /// <summary>
        /// Метод определяет, какой процент от данной наработки составляет заданная. 
        /// Возвращается минимальное или максимальное значение в зависимости от принципа выполнения
        /// NULL параметры заданной наработки не сравниваются.
        /// Возможны отрицательные значения 
        /// </summary>
        /// <param name="lifelength"></param>
        /// <param name="conditionType"></param>
        /// <returns></returns>
        public Double? GetPercents(Lifelength lifelength, ThresholdConditionType conditionType = ThresholdConditionType.WhicheverFirst)
        {
            if (IsNullOrZero() || lifelength.IsNullOrZero()) return null;

            // 
            Double? d1 = Cycles != null && Cycles != 0 && lifelength.Cycles != null && lifelength.Cycles != 0 
                ? new Double?((double)((double)lifelength.Cycles / Cycles)*100) 
                : null;
            Double? d2 = Hours != null && Hours != 0 && lifelength.Hours != null && lifelength.Hours != 0
                ? new Double?((double)((double)lifelength.Hours / Hours) * 100)
                : null;
            Double? d3 = Days != null && Days != 0 && lifelength.Days != null && lifelength.Days != 0
                ? new Double?((double)((double)lifelength.Days / Days) * 100)
                : null;

            // Whichever First vs. Whichever Later
            if (conditionType == ThresholdConditionType.WhicheverFirst)
            {
                // Выбираем минимум 
                Double? min = null;
                if (d1 != null) min = d1;
                if (d2 != null && (min == null || d2 < min)) min = d2;
                if (d3 != null && (min == null || d3 < min)) min = d3;
                // Возвращаем результат
                return min;
            }

            // Выбираем максимум
            Double? max = null;
            if (d1 != null) max = d1;
            if (d2 != null && (max == null || d2 > max)) max = d2;
            if (d3 != null && (max == null || d3 > max)) max = d3;
            // Возвращаем результат
            return max;
        }
        #endregion

        #region  public bool IsEqual(Lifelength lifelength, bool strictCompare = true)
        /// <summary> 
        /// Проверяет равенство параметров двух наработок. Если strictCompare = false - пустые параметры не сравниваются
        /// </summary>
        /// <param name="lifelength"></param>
        /// <param name="strictCompare"></param>
        /// <returns></returns>
        public bool IsEqual(Lifelength lifelength, bool strictCompare = true)
        {
            // если не strictCompare
            // null и 10  - true если не strict
            // null, null, null == null, null, null
            // 10, 10, null == 10, 10, null
            // 10, 10, null == 10, 10, 20 (не strict)
            // 10, 10, null != 10, 10, 20 (strict)
            if (lifelength == null) lifelength = Null;
           
            Boolean cycles, days, minutes;

            if (strictCompare)
            {
                if ((Cycles == null && lifelength.Cycles == null) || (Cycles != null && lifelength.Cycles != null && Cycles == lifelength.Cycles))
                    cycles = true;
                else
                    cycles = false;

                if ((Days == null && lifelength.Days == null) || (Days != null && lifelength.Days != null && Days == lifelength.Days))
                    days = true;
                else
                    days = false;

                if ((TotalMinutes == null && lifelength.TotalMinutes == null) || (TotalMinutes != null && lifelength.TotalMinutes != null && TotalMinutes == lifelength.TotalMinutes))
                    minutes = true;
                else
                    minutes = false;
            }
            else
            {
                if ((Cycles == null) || (lifelength.Cycles == null) || (Cycles == lifelength.Cycles))
                    cycles = true;
                else
                    cycles = false;

                if ((Days == null) || (lifelength.Days == null) || (Days == lifelength.Days))
                    days = true;
                else
                    days = false;

                if ((TotalMinutes == null) || (lifelength.TotalMinutes == null) || (TotalMinutes == lifelength.TotalMinutes))
                    minutes = true;
                else
                    minutes = false;
            }

            return cycles && minutes && days;
        }
        #endregion

        #region public bool IsNullOrZero()
        /// <summary> 
        /// Метод возвратит true если все три параметра наработки (ресурса) пусты или равны 0
        /// </summary>
        /// <returns></returns>
        public bool IsNullOrZero()
        {
            // cycles && hours && days == null
            if (( Cycles == null || Cycles == 0 ) && 
                ( Days == null || Days == 0 ) && 
                (TotalMinutes == null || TotalMinutes == 0)) return true;

            return false;
        }
        #endregion

        #region public int NotNullParamsCount()
        /// <summary> 
        /// Возвращает кол-во параметров не равных null
        /// </summary>
        /// <returns></returns>
        public int NotNullParamsCount()
        {
            int res = 0;
            if (Cycles != null)
                res++;
            if (TotalMinutes != null)
                res++;
            if (Days != null)
                res++;
            return res;
        }
        #endregion

        #region public bool IsOverdue()
        /// <summary>
        /// Просрочен ли ресурс (т.е. меньше ли он нуля)
        /// </summary>
        /// <returns></returns>
        public bool IsOverdue()
        {
            if (Cycles != null && Cycles <= 0) return true;
            if (TotalMinutes != null && TotalMinutes <= 0) return true;
            if (Days != null && Days <= 0) return true;
            //
            return false;
        }
        #endregion

        #region public bool IsAllOverdue()
        /// <summary>
        /// Просрочен ли ресурс по всем параметрам (условие проверки Whichever Later)
        /// </summary>
        /// <returns></returns>
        public bool IsAllOverdue()
        {
            // Если все параметры неопределены - ресурс не просрочен
            if (Cycles == null && TotalMinutes == null && Days == null) return false;
            // Если хотя бы один параметр больше нуля - ресруср не просрочен
            if ((Cycles != null && Cycles > 0) || (TotalMinutes != null && TotalMinutes > 0) || (Days != null && Days > 0)) return false;
            // Ресурс просрочен
            return true;
        }

        #endregion

        #region public void Add(Lifelength lifelength)

        /// <summary>
        /// Прибавляет заданную наработку к уже существующей
        /// </summary>
        /// <param name="lifelength"></param>
        public void Add(Lifelength lifelength)
        {
            // прибавляем к this
            // null + cycles = cycles
            // cycles + null = cycles
            // null + null = null
            // cycles + cycles = cycles + cycles
            if (Cycles == null && lifelength.Cycles != null) Cycles = lifelength.Cycles;
            else if (Cycles != null && lifelength.Cycles != null) Cycles += lifelength.Cycles;

            if (Days == null && lifelength.Days != null) Days = lifelength.Days;
            else if (Days != null && lifelength.Days != null) Days += lifelength.Days;

            if (TotalMinutes == null && lifelength.TotalMinutes != null) TotalMinutes = lifelength.TotalMinutes;
            else if (TotalMinutes != null && lifelength.TotalMinutes != null) TotalMinutes += lifelength.TotalMinutes;
        }

        #endregion

        #region public void Add(LifelengthSubResource sub, int source)
        /// <summary>
        /// Прибавляет заданную наработку к указанному параметру
        /// </summary>
        public void Add(LifelengthSubResource subResource, int source)
        {
            // прибавляем к this
            // null + cycles = cycles
            // cycles + null = cycles
            // null + null = null
            // cycles + cycles = cycles + cycles
            switch (subResource)
            {
                case LifelengthSubResource.Minutes:
                    if (TotalMinutes == null) TotalMinutes = source;
                    else TotalMinutes += source;
                    break;
                case LifelengthSubResource.Hours:
                    if (TotalMinutes == null) TotalMinutes = source * 60;
                    else TotalMinutes += source * 60;
                    break;
                case LifelengthSubResource.Cycles:
                    if (Cycles == null) Cycles = source;
                    else Cycles += source;
                    break;
                case LifelengthSubResource.Calendar:
                    if (Days == null) Days = source;
                    else Days += source;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region public void Add(Lifelength lifelength)

        /// <summary>
        /// Прибавляет заданную наработку к уже существующей
        /// </summary>
        /// <param name="from"></param>
        /// <param name="lifelength"></param>
        public void Add(DateTime from, Lifelength lifelength)
        {
            // прибавляем к this
            // null + cycles = cycles
            // cycles + null = cycles
            // null + null = null
            // cycles + cycles = cycles + cycles
            if (Cycles == null && lifelength.Cycles != null) Cycles = lifelength.Cycles;
            else if (Cycles != null && lifelength.Cycles != null) Cycles += lifelength.Cycles;

            if (TotalMinutes == null && lifelength.TotalMinutes != null) TotalMinutes = lifelength.TotalMinutes;
            else if (TotalMinutes != null && lifelength.TotalMinutes != null) TotalMinutes += lifelength.TotalMinutes;

            if (CalendarValue == null && lifelength.CalendarValue != null)
            {
                DateTime to = from.AddCalendarSpan(lifelength.CalendarSpan);
                Days = (to - from).Days;
            }
            else if (Days != null && lifelength.Days != null)
            {
                DateTime to = from.AddCalendarSpan(lifelength.CalendarSpan);
                Days += (to - from).Days;
            }
        }

        #endregion

        #region public void Substract(Lifelength lifelength)

        /// <summary>
        /// Отнимает заданную наработку от уже существующей
        /// </summary>
        /// <param name="lifelength"></param>
        public void Substract(Lifelength lifelength)
        {
			if(lifelength == null)
				return;

            Lifelength lifelength2 = new Lifelength(-lifelength.Days, -lifelength.Cycles, -lifelength.TotalMinutes);
            Add(lifelength2);
        }

        #endregion

        #region public void NullSubstract(Lifelength lifelength)

        /// <summary>
        /// Отнимает заданную наработку от уже существующей
        /// Если какой-то параметр сущ. наработки равен null,
        /// то калькуляция этого пареметра не производится
        /// </summary>
        /// <param name="lifelength"></param>
        public void NullSubstract(Lifelength lifelength)
        {
            Lifelength lifelength2
                = new Lifelength(Days == null ? null : -lifelength.Days,
                                 Cycles == null ? null : -lifelength.Cycles,
                                 TotalMinutes == null ? null : -lifelength.TotalMinutes);
            Add(lifelength2);
        }

        #endregion

        #region public void Reset()
        /// <summary>
        /// приравнивает часы, циклы и дни к null
        /// </summary>
        public void Reset()
        {
            Cycles = Hours = Days = null;
        }
        #endregion

        #region public static Lifelength Nearest(Lifelength lifelength, Lifelength sinceEffDate)
        /// <summary>
        /// Выбираем минимальные параметры из двух наработок 
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static Lifelength Nearest(Lifelength l1, Lifelength l2)
        {
            //
            if (l1 == null && l2 == null) return Null;

            // Результат
            Lifelength res = new Lifelength();

            if (l1 == null || l2 == null)
            {
                // Одна из наработок null
                res = l1 == null ? new Lifelength(l2) : new Lifelength(l1);
            }
            else
            {
                // Ни одна из наработок не null

                if (l1.Cycles == null) res.Cycles = l2.Cycles;
                else if (l2.Cycles == null) res.Cycles = l1.Cycles;
                else if (l1.Cycles < l2.Cycles) res.Cycles = l1.Cycles;
                else res.Cycles = l2.Cycles;

                if (l1.TotalMinutes == null) res.TotalMinutes = l2.TotalMinutes;
                else if (l2.TotalMinutes == null) res.TotalMinutes = l1.TotalMinutes;
                else if (l1.TotalMinutes < l2.TotalMinutes) res.TotalMinutes = l1.TotalMinutes;
                else res.TotalMinutes = l2.TotalMinutes;

                if (l1.Days == null) res.Days = l2.Days;
                else if (l2.Days == null) res.Days = l1.Days;
                else if (l1.Days < l2.Days) res.Days = l1.Days;
                else res.Days = l2.Days;
            }
            //
            return res;
        }
        #endregion

        #region public static bool TryParse(string hours, string cycles, string totalDays, out Lifelength result)

        /// <summary>
        /// Выбираем минимальные параметры из двух наработок 
        /// </summary>
        /// <param name="totalDaysS"></param>
        /// <param name="result"></param>
        /// <param name="hoursS"></param>
        /// <param name="cyclesS"></param>
        /// <returns></returns>
        public static bool TryParse(string hoursS, string cyclesS, string totalDaysS, out Lifelength result)
        {
            result = Null;

            TimeSpan hours;

            try
            {
                hours = ParseHours(hoursS);
            }
            catch
            {
                return false;
            }

            int cycles;
            if (!int.TryParse(cyclesS, out cycles))
                return false;

            int days;
            if (!int.TryParse(totalDaysS, out days))
                return false;

            result.TotalMinutes = Convert.ToInt32(hours.TotalMinutes);
            result.Cycles = cycles;
            result.Days = days;

            return true;
        }
        #endregion

        #region public static int? ParseTotalMinutes(String hoursAndMinutesString)

        public static int? ParseTotalMinutes(String hoursAndMinutesString)
        {
            string text = hoursAndMinutesString;
            if (IsNotApplicableString(text))
            {
                return null;
            }
            try
            {
                TimeSpan timeSpan = ParseHours(text);
                return Convert.ToInt32(timeSpan.TotalMinutes);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region public bool ValidateHours(String hoursString)

        public static bool ValidateHours(String hoursString)
        {
            string text = hoursString;
            if (!IsNotApplicableString(text))
            {
                try
                {
                    ParseHours(text);
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region private bool ValidateCyclesOrDays(String cyclesOrDaysString)

        public static bool ValidateCyclesOrDays(String cyclesOrDaysString)
        {
            if (!IsNotApplicableString(cyclesOrDaysString))
            {
                int value;
                if (!((Int32.TryParse(cyclesOrDaysString, out value)) && value >= 0))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region public static int? ParseCyclesOrDays(String cyclesString)

        public static int? ParseCyclesOrDays(String cyclesOrDaysString)
        {
            string text = cyclesOrDaysString;
            if (IsNotApplicableString(text))
            {
                return null;
            }
            try
            {
                int value;
                if ((Int32.TryParse(cyclesOrDaysString, out value)) && value >= 0)
                {
                    return value;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region private static TimeSpan ParseHours(string text)

        /// <summary>
        /// Преобразование данных из строки в <see cref="TimeSpan"/> согласно формату отображения часовой наработки
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static TimeSpan ParseHours(string text)
        {
            Regex regex = new Regex(@"^(?<Hours>-?\d+)(:(?<Minutes>([0-9]|[0-5][0-9])))?$");
            Match match = regex.Match(text);

            if (!match.Success)
                throw new ArgumentException("Parameter is not valid and cannot be converted", "text");
            int hours = Int32.Parse(match.Groups["Hours"].Value);
            int minutes;
            Int32.TryParse(match.Groups["Minutes"].Value, out minutes);

            return new TimeSpan(hours, minutes, 0);
        }

        #endregion

        #region private static bool IsNotApplicableString(string text)

        private static bool IsNotApplicableString(string text)
        {
            return Regex.IsMatch(text, @"([nN][/\][aA])") || text == "-";
        }

        #endregion

        /*
         * Вывод данных 
         */

        #region public int? GetSubresource(SubResource subResource)
        /// <summary>
        /// Возвращает нужную часть от текущей наработки
        /// </summary>
        /// <param name="subResource">определяет, какую часть наработки показать</param>
        /// <returns>часы или циклы или дни в звисимости от значения переданного параметра</returns>
        public int? GetSubresource(LifelengthSubResource subResource)
        {
            switch (subResource)
            {
                case LifelengthSubResource.Minutes:
                    return TotalMinutes;
                case LifelengthSubResource.Hours:
                    return Hours;
                case LifelengthSubResource.Cycles:
                    return Cycles;
                case LifelengthSubResource.Calendar:
                    return Days;
                default:
                    return null;
            }
        }
        #endregion

        #region public string ToString(LifelengthSubResource subResource, string format)

        /// <summary>
        /// Возвращает нужную часть от текущей наработки в виде строки
        /// </summary>
        /// <param name="subResource">определяет, какую часть наработки показать</param>
        /// <param name="advanced">Выводит значение в расширенном формате (применяется в часам/минутам)</param>
        /// <param name="format"></param>
        /// <returns>часы или циклы или дни в виде строки в звисимости от значения переданного параметра</returns>
        public string ToString(LifelengthSubResource subResource, bool advanced = false, string format = "default")
        {
            switch (subResource)
            {
                case LifelengthSubResource.Minutes:
                    return ToHoursMinutesFormat(format == "default" ? "hrs" : format);
                case LifelengthSubResource.Hours:
                    return advanced 
                        ? ToHoursMinutesFormat(format == "default" ? "hrs" : format) 
                        : Hours + (format == "default" ? "FH" : format);
                case LifelengthSubResource.Cycles:
                    return Cycles + (format == "default" ? "FC" : format);
                case LifelengthSubResource.Calendar:
                    return Days + (format == "default" ? "d" : format);
                default:
                    return "";
            }
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Представляет наработку в виде строки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string sh = Hours != null ? Hours + ((Cycles != null || Days != null) ? "FH/" : "FH") : "";
            string sc = Cycles != null ? Cycles + (Days != null ? "FC/" : "FC") : "";
            //string sd = Days != null ? Days + "d " : "";
            string sd = "";
            if(CalendarValue != null)
            {
                switch (CalendarSpan.CalendarType)
                {
                    case CalendarTypes.Years:
                        sd = CalendarValue + "Y ";
                        break;
                    case CalendarTypes.Months:
                        sd = CalendarValue + "MO ";
                        break;
                    case CalendarTypes.Days:
                        sd = CalendarValue + "d ";
                        break;
                }
            }

            return (sh + sc + sd).Trim();
        }

        #endregion

        #region public string ToStrings()
        /// <summary>
        /// Представляет наработку в виде строки (Каждый параметр выводится в новой строке)
        /// </summary>
        /// <returns></returns>
        public string ToStrings()
        {
            string sh = Hours != null && Hours != 0 ? Hours + "FH" : "";
            string sc = Cycles != null && Cycles != 0 ? Cycles + "FC" : "";
            //string sd = Days != null ? Days + "d " : "";
            string sd = "";
            if (CalendarValue != null)
            {
                switch (CalendarSpan.CalendarType)
                {
                    case CalendarTypes.Years:
                        sd = CalendarValue + "Y ";
                        break;
                    case CalendarTypes.Months:
                        sd = CalendarValue + "MO ";
                        break;
                    case CalendarTypes.Days:
                        sd = CalendarValue + "d ";
                        break;
                }
            }
            StringBuilder stringBuilder = new StringBuilder();
            if (!string.IsNullOrEmpty(sh))
                stringBuilder.AppendLine(sh);
            if (!string.IsNullOrEmpty(sc))
                stringBuilder.AppendLine(sc);
            if (!string.IsNullOrEmpty(sd))
                stringBuilder.AppendLine(sd);
            return stringBuilder.ToString();
        }

        #endregion

        #region public string ToString(DateTime approx)

        public string ToString(DateTime approx)
        {
            return approx.ToShortDateString() + "/" + ToString();
        }

        #endregion

        #region public string ToHoursMinutesFormat()

        /// <summary>
        /// Создается отображение наработки в виде: 123:12 hrs
        /// </summary>
        /// <returns></returns>
        public string ToHoursMinutesFormat(string hoursFormat = " hrs")
        {
            string res = "";
            if (TotalMinutes != null)
                res += Hours + ":" + (TotalMinutes - Hours * 60) + hoursFormat;
            return res;
        }

        #endregion

        #region public string ToHoursMinutesAndCyclesFormat(string hoursFormat = " hrs", string cyclesFormat = " cyc", string delimeter = "/")

        /// <summary>
        /// Создается отображение наработки в виде: 123:12 hrs/25 cyc
        /// </summary>
        /// <returns></returns>
        public string ToHoursMinutesAndCyclesFormat(string hoursFormat = " hrs", string cyclesFormat = " cyc", string delimeter = "/")
        {
            string res = "";
            if (TotalMinutes != null)
                res += Hours + ":" + (TotalMinutes - Hours * 60) + hoursFormat;
            if (Cycles != null)
            {
                if (TotalMinutes != null)
                    res += delimeter + Cycles + cyclesFormat;
                else
                    res += Cycles + cyclesFormat;
            }
            return res;
        }

        #endregion

        #region public string ToHoursMinutesAndCyclesStrings(string hoursFormat = " hrs", string cyclesFormat = " cyc")

        /// <summary>
        /// Создается отображение наработки в виде: 123:12 hrs 25 cyc (Каждый параметр выводится в новой строке)
        /// </summary>
        /// <returns></returns>
        public string ToHoursMinutesAndCyclesStrings(string hoursFormat = " hrs", string cyclesFormat = " cyc")
        {
            StringBuilder res = new StringBuilder();
            if (TotalMinutes != null && TotalMinutes != 0)
                res.AppendLine(Hours + ":" + (TotalMinutes - Hours * 60) + hoursFormat);
            if (Cycles != null && Cycles != 0)
            {
                if (TotalMinutes != null)
                    res.AppendLine(Cycles + cyclesFormat);
                else
                    res.AppendLine(Cycles + cyclesFormat);
            }
            return res.ToString();
        }

        #endregion

        #region public string ToHoursAndCyclesFormat(string hoursModifier = "h", string cyclesModifier = "c")

        /// <summary>
        /// Создается отображение наработки в виде ? h ? c
        /// </summary>
        /// <returns></returns>
        public string ToHoursAndCyclesFormat(string hoursModifier = "h", string cyclesModifier = "c")
        {
            string res = "";
            if (TotalMinutes != null)
                res += Hours + " " + hoursModifier;
            if (Cycles != null)
            {
                if (TotalMinutes != null)
                    res += " " + Cycles + " " + cyclesModifier;
                else
                    res += Cycles + " " + cyclesModifier;
            }
            return res;
        }

        #endregion

        #region public string ToRepeatIntervalsFormat()

        /// <summary>
        /// Создается отбражение наработки в виде "? h ? c ? y ? m ? d"
        /// </summary>
        /// <returns></returns>
        public string ToRepeatIntervalsFormat()
        {
            //string res = "";
            //if (TotalMinutes!=null && Hours != 0)
            //{
            //    res += Hours + " h |";
            //}

            //if (Cycles!=null && Cycles != 0)
            //{
            //    res += Cycles + " c |";
            //}

            //if (Days!=null)
            //{
            //    if (Days % 365 == 0)
            //        res += Days / 365 + "y";
            //    else if (Days % 360 == 0)
            //        res += Days / 360 + "y";
            //    else if (Days % 30 == 0)
            //        res += Days / 30 + "m";
            //    else
            //        res += Days + "d";
            //}

            return ToString();
        }

        #endregion

        #region public int CompareTo(object obj)
        /// <summary>
        /// Сравнивает текущий экземпляр с другим объектом того же типа и возвращает целое число, которое показывает, расположен ли текущий экземпляр перед, после или на той же позиции в порядке сортировки, что и другой объект.
        /// </summary>
        /// <returns>
        /// 32-битовое целое число со знаком, указывающее, каков относительный порядок сравниваемых объектов. Возвращаемые значения представляют следующие результаты сравнения. 
        ///                     Значение 
        ///                     Описание 
        ///                     Меньше нуля 
        ///                     Этот экземпляр меньше параметра <paramref name="obj"/>. 
        ///                     Нуль 
        ///                     Этот экземпляр и параметр <paramref name="obj"/> равны. 
        ///                     Больше нуля 
        ///                     Этот экземпляр больше параметра <paramref name="obj"/>. 
        /// </returns>
        /// <param name="obj">Объект для сравнения с данным экземпляром. 
        ///                 </param><exception cref="T:System.ArgumentException">Тип значения параметра <paramref name="obj"/> отличается от типа данного экземпляра. 
        ///                 </exception><filterpriority>2</filterpriority>
        public int CompareTo(object obj)
        {
            if(obj is Lifelength)
            {
                Lifelength y = obj as Lifelength;
                if (IsEqual(y)) return 0;
                if (IsLessByAnyParameterNullable(y)) return -1;
                if (IsGreaterNullable(y)) return 1;
            }
            return 0;
        }
        #endregion

        #region Implement of IEquatable

        #region public bool Equals(Lifelength other)
        public bool Equals(Lifelength other)
        {
            //Без переопределения метода GetHashCode данный метод не работает
            //Почему? - ХЗ

            //Check whether the compared object is null.
            if (ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return IsEqual(other);
        }
        #endregion

        #region public override int GetHashCode()
        public override int GetHashCode()
        {
            int minutesHash = Convert.ToInt32(TotalMinutes).GetHashCode();
            int calendarHash = Convert.ToInt32(Days).GetHashCode();
            int cyclesHash = Convert.ToInt32(Cycles).GetHashCode();

            return minutesHash ^ calendarHash ^ cyclesHash;
        }
        #endregion

        #endregion

        #region IEqualityComparer<Lifelength>

        #region public bool Equals(Lifelength x, Lifelength y)
        public bool Equals(Lifelength x, Lifelength y)
        {
            //Без переопределения метода GetHashCode(Lifelength) данный метод не работает
            //Почему? - ХЗ

            //Check whether the compared object references the same data.
            if (ReferenceEquals(x, y)) return true;

            //Check whether the compared object is null.
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;

            //Check whether the products' properties are equal.
            return x.IsEqual(y);
        }
        #endregion

        #region public int GetHashCode(Lifelength lifelength)
        public int GetHashCode(Lifelength lifelength)
        {
            if (ReferenceEquals(lifelength, null) == true)
                return 0;
            int minutesHash = Convert.ToInt32(TotalMinutes).GetHashCode();
            int calendarHash = Convert.ToInt32(Days).GetHashCode();
            int cyclesHash = Convert.ToInt32(Cycles).GetHashCode();

            return minutesHash ^ calendarHash ^ cyclesHash;
        }
        #endregion

        #endregion

        /*
         * Operator
         */

        public static Lifelength operator -(Lifelength a, Lifelength b)
        {
            Lifelength lifelength = new Lifelength(a);
            lifelength.Substract(b);
            return lifelength;
        }

        public static Lifelength operator +(Lifelength a, Lifelength b)
        {
            Lifelength lifelength = new Lifelength(a);
            lifelength.Add(b);
            return lifelength;
        }

        public static Lifelength operator *(Lifelength a, int b)
        {
            Lifelength lifelength = new Lifelength(a);
            if (lifelength.TotalMinutes != null) lifelength.TotalMinutes *= b;
            if (lifelength.Cycles != null) lifelength.Cycles *= b;
            if (lifelength.CalendarValue != null) lifelength.CalendarValue *= b;
            return lifelength;
        }

        public static Lifelength operator *(int b, Lifelength a)
        {
            return a*b;
        }

        public static Lifelength operator *(Lifelength a, double b)
        {
            Lifelength lifelength = new Lifelength(a);
            if (lifelength.TotalMinutes != null) lifelength.TotalMinutes = Convert.ToInt32(Convert.ToInt32(lifelength.TotalMinutes) * b);
            if (lifelength.Cycles != null) lifelength.Cycles = Convert.ToInt32(Convert.ToInt32(lifelength.Cycles) * b);
            if (lifelength.CalendarValue != null) lifelength.CalendarValue = Convert.ToInt32(Convert.ToInt32(lifelength.CalendarValue) * b);
            return lifelength;
        }

        public static Lifelength operator *(double b, Lifelength a)
        {
            return a * b;
        }

        public static Lifelength operator /(Lifelength a, Lifelength b)
        {
            if (b == null || b.IsNullOrZero())
                return Null;
            Lifelength lifelength = new Lifelength(a);
            lifelength.Resemble(b);
            if (lifelength.TotalMinutes != null) lifelength.TotalMinutes /= b.TotalMinutes;
            if (lifelength.Cycles != null) lifelength.Cycles /= b.Cycles;
            if (lifelength.CalendarValue != null) lifelength.CalendarValue /= b.CalendarValue;
            return lifelength;
        }

        public static Lifelength operator /(Lifelength a, double b)
        {
	        Lifelength lifelength = new Lifelength(a);
	        if (lifelength.Hours != null) lifelength.TotalMinutes = Convert.ToInt32(Convert.ToInt32(lifelength.TotalMinutes) / b);
	        if (lifelength.Cycles != null) lifelength.Cycles = Convert.ToInt32(Convert.ToInt32(lifelength.Cycles) / b);
	        if (lifelength.Days != null) lifelength.CalendarValue = Convert.ToInt32(Convert.ToInt32(lifelength.Days) / b);
	        return lifelength;
        }
    }

    [Serializable]
    public class CalendarSpan
    {
        private int? _calendarValue;
        private CalendarTypes _calendarType;

        public int? CalendarValue
        {
            get { return _calendarValue; }
            set { _calendarValue = value; }
        }

        public CalendarTypes CalendarType
        {
            get { return _calendarType; }
            set { _calendarType = value; }
        }

        #region public Int32? Days

        public Int32? Days
        {
            get
            {
                if (_calendarValue == null)
                    return null;

                int value;
                switch (_calendarType)
                {
                    case CalendarTypes.Months:
                        value = (int)Math.Round(Convert.ToDouble(_calendarValue * 30.4375));
                        break;
                    case CalendarTypes.Years:
                        value = (int)Math.Round(Convert.ToDouble(_calendarValue * 365.25));
                        break;
                    default:
                        value = Convert.ToInt32(_calendarValue);
                        break;
                }
                return value;
            }
        }
        #endregion

        #region public Int32? Months

        public Int32? Months
        {
            get
            {
                if (_calendarValue == null)
                    return null;

                int value;
                switch (_calendarType)
                {
                    case CalendarTypes.Months:
                        value = Convert.ToInt32(_calendarValue);
                        break;
                    case CalendarTypes.Years:
                        value = Convert.ToInt32(_calendarValue * 12);
                        break;
                    default:
                        value = (int)Math.Round(Convert.ToDouble(_calendarValue * 30.4375));
                        break;
                }
                return value;
            }
        }
        #endregion

        #region public Int32? Years

        public Int32? Years
        {
            get
            {
                if (_calendarValue == null)
                    return null;

                int value;
                switch (_calendarType)
                {
                    case CalendarTypes.Months:
                        value = (int)Math.Round(Convert.ToDouble(_calendarValue / 12));
                        break;
                    case CalendarTypes.Years:
                        value = Convert.ToInt32(_calendarValue);
                        break;
                    default:
                        value = (int)Math.Round(Convert.ToDouble(_calendarValue / 365.25));
                        break;
                }
                return value;
            }
        }
        #endregion

        #region public CalendarSpan()

        public CalendarSpan()
        {
            _calendarValue = null;
            _calendarType = CalendarTypes.Days;
        }
        #endregion

        #region public CalendarSpan(int? calandarValue, CalendarTypes calendarType)

        public CalendarSpan(int? calandarValue, CalendarTypes calendarType)
        {
            _calendarValue = calandarValue;
            _calendarType = calendarType;
        }
        #endregion

        #region public CalendarSpan(CalendarSpan source)
        public CalendarSpan(CalendarSpan source)
        {
            if(source != null)
            {
                _calendarValue = source.CalendarValue;
                _calendarType = source.CalendarType;
            }
            else
            {
                _calendarValue = null;
                _calendarType = CalendarTypes.Days;
            }
        }
        #endregion

        /*
         * Operator
         */

        #region public static bool operator > (CalendarSpan a, CalendarSpan b)

        public static bool operator > (CalendarSpan a, CalendarSpan b)
        {
            if (a == null || a.CalendarValue == null)
                return false;
            if (b == null || b.CalendarValue == null)
                return true;
            if (a.CalendarType == b.CalendarType)
            {
                return a.CalendarValue > b.CalendarValue;
            }
            
            double aValue, bValue;

            switch (a.CalendarType)
            {
                case CalendarTypes.Months:
                    aValue = Math.Round(System.Convert.ToDouble(a.CalendarValue * 30.4375));
                    break;
                case CalendarTypes.Years:
                    aValue = Math.Round(System.Convert.ToDouble(a.CalendarValue * 365.25));
                    break;
                default:
                    aValue = System.Convert.ToDouble(a.CalendarValue);
                    break;
            }

            switch (b.CalendarType)
            {
                case CalendarTypes.Months:
                    bValue = Math.Round(System.Convert.ToDouble(b.CalendarValue * 30.4375));
                    break;
                case CalendarTypes.Years:
                    bValue = Math.Round(System.Convert.ToDouble(b.CalendarValue * 365.25));
                    break;
                default:
                    bValue = System.Convert.ToDouble(b.CalendarValue);
                    break;
            }

            return aValue > bValue;
        }
        #endregion

        #region public static bool operator < (CalendarSpan a, CalendarSpan b)

        public static bool operator < (CalendarSpan a, CalendarSpan b)
        {
            if (b == null || b.CalendarValue == null)
                return false;
            if (a == null || a.CalendarValue == null)
                return true;
            if (a.CalendarType == b.CalendarType)
            {
                return a.CalendarValue < b.CalendarValue;
            }

            double aValue, bValue;

            if (a.CalendarType == CalendarTypes.Months)
                aValue = Math.Round(System.Convert.ToDouble(a.CalendarValue * 30.4375));
            else if (a.CalendarType == CalendarTypes.Years)
                aValue = Math.Round(System.Convert.ToDouble(a.CalendarValue * 365.25));
            else aValue = System.Convert.ToDouble(a.CalendarValue);

            if (b.CalendarType == CalendarTypes.Months)
                bValue = Math.Round(System.Convert.ToDouble(b.CalendarValue * 30.4375));
            else if (b.CalendarType == CalendarTypes.Years)
                bValue = Math.Round(System.Convert.ToDouble(b.CalendarValue * 365.25));
            else bValue = System.Convert.ToDouble(b.CalendarValue);

            return aValue < bValue;
        }
        #endregion
    }
}
