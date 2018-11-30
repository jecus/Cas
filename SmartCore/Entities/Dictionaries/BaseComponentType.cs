using System;
using System.Collections.Generic;

namespace SmartCore.Entities.Dictionaries
{

    /// <summary>
    /// Класс описывает типы базовых агрегатов
    /// </summary>
    public class BaseComponentType : StaticDictionary
    {

		#region private static List<BaseComponentType> _Items = new List<BaseComponentType>();
		/// <summary>
		/// Содержит все элементы - это пригодиться нам, когда мы захотим получить тип базового агрегата по его id
		/// </summary>
		private static List<BaseComponentType> _Items = new List<BaseComponentType>();
		#endregion


		/*
         * Предопределенные типы
         * 
         * Не менять текст FullName в преопределенных типах
         * оно использутся для определения AtaChapter
         */

		#region public static BaseComponentType Propeller = new BaseComponentType(1, "Propeller", "Propeller");
		/// <summary>
		/// Пропеллер
		/// </summary>
		public static BaseComponentType Propeller = new BaseComponentType(1, "Propeller", "Propeller");
		#endregion

		#region public static BaseComponentType Apu = new BaseComponentType(2, "APU", "Auxiliary Power Unit");
		/// <summary>
		/// Вспомогательная силовая установка (ВСУ)
		/// </summary>
		public static BaseComponentType Apu = new BaseComponentType(2, "APU", "Auxiliary Power Unit");
		#endregion

		#region public static BaseComponentType Engine = new BaseComponentType(3, "Engine", "Engine");
		/// <summary>
		/// Двигатель
		/// </summary>
		public static BaseComponentType Engine = new BaseComponentType(3, "Engine", "Engine");
		#endregion

		#region public static BaseComponentType Frame = new BaseComponentType(4, "Frame", "Aircraft Frame");
		/// <summary>
		/// Планер (фюзеляж, воздушное судно)
		/// </summary>
		public static BaseComponentType Frame = new BaseComponentType(4, "Frame", "Aircraft Frame");
		#endregion

		#region public static BaseComponentType LandingGear = new BaseComponentType(6, "Landing Gear", "Landing Gear Assembly");
		/// <summary>
		/// Стойка шасси
		/// </summary>
		public static BaseComponentType LandingGear = new BaseComponentType(6, "Landing Gear", "Landing Gear Assembly");
		#endregion

		#region public static BaseComponentType Unknown = new BaseComponentType(-1, "Unknown", "Unknown");
		/// <summary> 
		/// Неизвестный объект
		/// </summary>
		public static BaseComponentType Unknown = new BaseComponentType(-1, "Unknown", "Unknown");
		#endregion

		/*
         * Методы
         */

		#region public static BaseComponentType GetComponentTypeById(int componentTypeId)
		/// <summary>
		/// Возвращает тип базового агрегата по его Id
		/// </summary>
		/// <param name="componentTypeId"></param>
		/// <returns></returns>
		public static BaseComponentType GetComponentTypeById(int componentTypeId)
        {
            foreach (BaseComponentType t in _Items)
                if (t.ItemId == componentTypeId)
                    return t;
            //
            return Unknown;
        }

		#endregion

		#region public static List<BaseComponentType> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static List<BaseComponentType> Items
        {
            get { return _Items; }
        }
        #endregion

        #region public override string ToString()
        /// <summary> 
        /// Представляет тип агрегата в виде строки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ShortName;
        }
		#endregion

		/*
         * Свойства
         */

		/*
         * Реализация
         */

		#region public BaseComponentType()
		/// <summary>
		/// Конструктор создает объект по умолчанию
		/// </summary>
		public BaseComponentType()
        {
        }
		#endregion

		#region public BaseComponentType(Int32 ItemId, String shortName, String fullName)
		/// <summary>
		/// Конструктор создает запись о типе агрегата
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		public BaseComponentType(int itemId, string shortName, string fullName)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;

            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }
        #endregion

    }

}
