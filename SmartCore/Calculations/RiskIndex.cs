using System;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Calculations
{

    /// <summary>
    /// Описывает наработку (ресурс)
    /// </summary>
    public class RiskIndex : IComparable
    {

        /*
         * Свойства
         */

        #region public EventCategory EventCategory { get; set; }

        /// <summary>
        /// Категория события
        /// </summary>
        public EventCategory EventCategory { get; set; }

        #endregion

        #region public EventClass EventClass { get; set; }

        /// <summary>
        /// Класс события
        /// </summary>
        public EventClass EventClass { get; set; }

        #endregion

        /*
         * Конструктор 
         */

        #region public RiskIndex()
        /// <summary>
        /// Создает наработку (ресурс) с пустыми параметрами
        /// </summary>
        public RiskIndex()
        {
        }
        #endregion

        #region public RiskIndex(EventCategory eventCategory, EventClass eventClass)

        /// <summary>
        /// Создает индекс риска с известными параметрами
        /// </summary>
        /// <param name="eventCategory">Категория события</param>
        /// <param name="eventClass">Класс события</param>
        public RiskIndex(EventCategory eventCategory, EventClass eventClass)
        {
            EventCategory = eventCategory;
            EventClass = eventClass;
        }
        #endregion

        /*
         * Методы
         */

        #region public void SetMax(RiskIndex candidate)
        /// <summary>
        /// По выходу объект будет представлять содержать максимальные ресурсы от обоих объектов
        /// </summary>
        /// <param name="candidate"></param>
        public void SetMax(RiskIndex candidate)
        {
            // Если у кандидата класс больше чем у текущего объекта - присваиваем максимальные класс
            if (candidate.EventClass != null && (EventClass == null || EventClass.Weight < candidate.EventClass.Weight))
                EventClass = candidate.EventClass;

            // то же по категории 
            if (candidate.EventCategory != null && (EventCategory == null || EventCategory.Weight < candidate.EventCategory.Weight))
                EventCategory = candidate.EventCategory;

        }
        #endregion

        #region public void SetMin(RiskIndex candidate)
        /// <summary>
        /// По выходу объект будет представлять содержать минимальных ресурсов от обоих объектов (whichever first)
        /// </summary>
        /// <param name="candidate"></param>
        public void SetMin(RiskIndex candidate)
        {
            // Если у кандидата класс меньше чем у текущего объекта - присваиваем минимальные класс
            if (candidate.EventClass != null && (EventClass == null || EventClass.Weight > candidate.EventClass.Weight))
                EventClass = candidate.EventClass;

            // то же по категории 
            if (candidate.EventCategory != null && (EventCategory == null || EventCategory.Weight > candidate.EventCategory.Weight))
                EventCategory = candidate.EventCategory;

        }
        #endregion

        /*
         * Арифметика 
         */

        // Алексей: Мы отказываемся от перегрузки операторов в силу непрозрачности их использования
        // Вместо этого мы будем использовать методы сравнения и арифметики
        // Плюс ко всему мы получим нарост производительности таким образом

        //#region public bool IsLessNullable(RiskIndex RiskIndex)
        ///// <summary>
        ///// Метод проверяет, является ли данная наработка строко меньшей заданной по всем трем параметрам
        ///// NULL параметры заданной наработки не сравниваются. 
        ///// </summary>
        ///// <param name="RiskIndex"></param>
        ///// <returns></returns>
        //public bool IsLessNullable(RiskIndex RiskIndex)
        //{
        //    if (RiskIndex.IsNullRiskIndex()) return false;
        //    if (IsNullRiskIndex() && !RiskIndex.IsNullRiskIndex()) return true;

        //    int? cyclesValue = Cycles ?? 0;
        //    int? minutesValue = TotalMinutes ?? 0;
        //    int? daysValue = Days ?? 0;
        //    int? llCyclesValue = RiskIndex.Cycles ?? 0;
        //    int? llMinutesValue = RiskIndex.TotalMinutes ?? 0;
        //    int? llDaysValue = RiskIndex.Days ?? 0;

        //    if (cyclesValue < llCyclesValue) return true;//циклы заданной наработки меньше
        //    if (minutesValue < llMinutesValue) return true;//время заданной наработки меньше
        //    if (daysValue < llDaysValue) return  true;//дни заданной наработки меньше

        //    return false;
        //}
        //#endregion

        //#region public bool IsGreaterNullable(RiskIndex RiskIndex)
        ///// <summary>
        ///// Метод проверяет, является ли данная наработка строго больше заданной по всем трем параметрам. 
        ///// NULL параметры заданной наработки не сравниваются. 
        ///// </summary>
        ///// <param name="RiskIndex"></param>
        ///// <returns></returns>
        //public bool IsGreaterNullable(RiskIndex RiskIndex)
        //{
        //    // IsNull   and IsNull     = false
        //    // IsNull   and 10,10,10   = false
        //    // 10,10,10 and IsNull     = true
        //    if (IsNullRiskIndex()) return false;
        //    if (!IsNullRiskIndex() && RiskIndex.IsNullRiskIndex()) return true;

        //    int? cyclesValue = Cycles ?? 0;
        //    int? minutesValue = TotalMinutes ?? 0;
        //    int? daysValue = Days ?? 0;
        //    int? llCyclesValue = RiskIndex.Cycles ?? 0;
        //    int? llMinutesValue = RiskIndex.TotalMinutes ?? 0;
        //    int? llDaysValue = RiskIndex.Days ?? 0;

        //    if (cyclesValue > llCyclesValue) return true;//циклы заданной наработки меньше
        //    if (minutesValue > llMinutesValue) return true;//время заданной наработки меньше
        //    if (daysValue > llDaysValue) return true;//дни заданной наработки меньше

        //    return false;

        //    //bool cyclesCompared = true, minutesCompared = true, daysCompared = true;

        //    //if (Cycles != null && RiskIndex.Cycles != null)
        //    //{
        //    //    if (Cycles <= RiskIndex.Cycles) return false;
        //    //}
        //    //else cyclesCompared = false;

        //    //if (TotalMinutes != null && RiskIndex.TotalMinutes != null)
        //    //{
        //    //    if (TotalMinutes <= RiskIndex.TotalMinutes) return false;
        //    //}
        //    //else minutesCompared = false;

        //    //if (Days != null && RiskIndex.Days != null)
        //    //{
        //    //    if (Days <= RiskIndex.Days) return false;
        //    //}
        //    //else daysCompared = false;

        //    //return cyclesCompared || minutesCompared || daysCompared;
        //}
        //#endregion

        //#region  public bool IsEqual(RiskIndex RiskIndex, bool strictCompare = true)
        ///// <summary> 
        ///// Проверяет равенство параметров двух наработок. Если strictCompare = false - пустые параметры не сравниваются
        ///// </summary>
        ///// <param name="RiskIndex"></param>
        ///// <param name="strictCompare"></param>
        ///// <returns></returns>
        //public bool IsEqual(RiskIndex RiskIndex, bool strictCompare = true)
        //{
        //    // если не strictCompare
        //    // null и 10  - true если не strict
        //    // null, null, null == null, null, null
        //    // 10, 10, null == 10, 10, null
        //    // 10, 10, null == 10, 10, 20 (не strict)
        //    // 10, 10, null != 10, 10, 20 (strict)
        //    if (RiskIndex == null) RiskIndex = Null;
           
        //    Boolean cycles, days, minutes;

        //    if (strictCompare)
        //    {
        //        if ((Cycles == null && RiskIndex.Cycles == null) || (Cycles != null && RiskIndex.Cycles != null && Cycles == RiskIndex.Cycles))
        //            cycles = true;
        //        else
        //            cycles = false;

        //        if ((Days == null && RiskIndex.Days == null) || (Days != null && RiskIndex.Days != null && Days == RiskIndex.Days))
        //            days = true;
        //        else
        //            days = false;

        //        if ((TotalMinutes == null && RiskIndex.TotalMinutes == null) || (TotalMinutes != null && RiskIndex.TotalMinutes != null && TotalMinutes == RiskIndex.TotalMinutes))
        //            minutes = true;
        //        else
        //            minutes = false;
        //    }
        //    else
        //    {
        //        if ((Cycles == null) || (RiskIndex.Cycles == null) || (Cycles == RiskIndex.Cycles))
        //            cycles = true;
        //        else
        //            cycles = false;

        //        if ((Days == null) || (RiskIndex.Days == null) || (Days == RiskIndex.Days))
        //            days = true;
        //        else
        //            days = false;

        //        if ((TotalMinutes == null) || (RiskIndex.TotalMinutes == null) || (TotalMinutes == RiskIndex.TotalMinutes))
        //            minutes = true;
        //        else
        //            minutes = false;
        //    }

        //    return cycles && minutes && days;
        //}
        //#endregion

        //#region public bool IsNullRiskIndex()
        ///// <summary> 
        ///// Метод возвратит true если все три параметра наработки (ресурса) пусты
        ///// </summary>
        ///// <returns></returns>
        //public bool IsNullRiskIndex()
        //{
        //    // cycles && hours && days == null
        //    if (Cycles == null && Days == null && TotalMinutes == null) return true;

        //    return false;
        //}
        //#endregion

        /*
         * Вывод данных 
         */

        #region public override string ToString()
        /// <summary>
        /// Представляет наработку в виде строки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (EventCategory != null && EventCategory != EventCategory.UNK && 
                EventClass != null && EventClass.Weight > 0)
            {
                return EventClass.Weight + EventCategory.ShortName + (EventClass.Weight*EventCategory.Weight);
            }
            return "UNK";
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
            //if(obj is RiskIndex)
            //{
            //    RiskIndex y = obj as RiskIndex;
            //    if (IsEqual(y)) return 0;
            //    if (IsLessNullable(y)) return -1;
            //    if (IsGreaterNullable(y)) return 1;
            //}
            return 0;
        }
        #endregion

    }


}
