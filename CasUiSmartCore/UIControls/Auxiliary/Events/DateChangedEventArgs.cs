using System;
using System.Collections.Generic;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.Auxiliary.Events
{
    #region public class DateChangedEventArgs
    ///<summary>
    /// Описывает агрумент для события изменения даты - времени
    ///</summary>
    public class DateChangedEventArgs
    {
        ///<summary>
        /// Возвращает измененную дату
        ///</summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Создает экземпляр объекта с определенным значением даты-времени
        /// </summary>
        /// <param name="date">Значение даты-времени</param>
        public DateChangedEventArgs (DateTime date)
        {
            Date = date;
        }
    }

    /// <summary>
    /// Делегат для события изменения даты-времени
    /// </summary>
    /// <param name="e"></param>
    public delegate void DateChangedEventHandler(DateChangedEventArgs e);
    #endregion

    #region public class CrewChangedEventArgs
    ///<summary>
    /// Описывает агрумент для события изменения состава экипажа
    ///</summary>
    public class CrewChangedEventArgs
    {
        ///<summary>
        /// Возвращает экипаж
        ///</summary>
        public List<Specialist> Crew { get; private set; }

        /// <summary>
        /// Создает экземпляр объекта с определенным экипажем
        /// </summary>
        /// <param name="сrew">Измененный экипаж</param>
        public CrewChangedEventArgs(List<Specialist> сrew)
        {
            Crew = сrew;
        }
    }

    /// <summary>
    /// Делегат для события изменения состава экипажа
    /// </summary>
    /// <param name="e"></param>
    public delegate void CrewChangedEventHandler(CrewChangedEventArgs e);

    #endregion

    #region public class ValueChangedEventArgs : EventArgs
    ///<summary>
    /// Описывает агрумент для события изменения значения
    ///</summary>
    public class ValueChangedEventArgs : EventArgs
    {
        ///<summary>
        /// Возвращает значение
        ///</summary>
        public object Value { get; private set; }

        /// <summary>
        /// Создает экземпляр объекта с определенным значением
        /// </summary>
        /// <param name="value">Значение</param>
        public ValueChangedEventArgs(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Создает экземпляр объекта с определенным значением
        /// </summary>
        /// <param name="value">Значение</param>
        public ValueChangedEventArgs(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Создает экземпляр объекта с определенным значением
        /// </summary>
        /// <param name="value">Значение</param>
        public ValueChangedEventArgs(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Создает экземпляр объекта с определенным значением
        /// </summary>
        /// <param name="value">Значение</param>
        public ValueChangedEventArgs(TimeSpan value)
        {
            Value = value;
        }

        /// <summary>
        /// Создает экземпляр объекта с определенным значением
        /// </summary>
        /// <param name="value">Значение</param>
        public ValueChangedEventArgs(FlightRegime value)
        {
            Value = value;
        }

        /// <summary>
        /// Создает экземпляр объекта с определенным значением
        /// </summary>
        /// <param name="value">Значение</param>
        public ValueChangedEventArgs(GoodsClass value)
        {
            Value = value;
        }

	    public ValueChangedEventArgs(AtlbRecordType value)
	    {
		    Value = value;
	    }
	}

    /// <summary>
    /// Делегат для события изменения значения
    /// </summary>
    /// <param name="e"></param>
    public delegate void ValueChangedEventHandler(ValueChangedEventArgs e);

    #endregion
}
