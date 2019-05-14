using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    [Serializable]
    public class Measure : StaticDictionary
    {

        public MeasureCategory MeasureCategory { get; set; }

        #region private static CommonDictionaryCollection<Measure> _Items = new CommonDictionaryCollection<Measure>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<Measure> _Items = new CommonDictionaryCollection<Measure>();
        #endregion

        /*
         * Предопределенные типы
         */
        #region public static Measure Unknown = new Measure(-1, "Unk", "Unknown", MeasureCategory.Unknown);
        /// <summary>
        /// Неизвестный
        /// </summary>
        public static Measure Unknown = new Measure(-1, "Unk", "Unknown", MeasureCategory.Unknown);
        #endregion

        #region public static Measure Kilometres = new Measure(10, "KM", "Kilometres", MeasureCategory.Length);
        /// <summary>
        /// Километры
        /// </summary>
        public static Measure Kilometres = new Measure(10, "KM", "Kilometres", MeasureCategory.Length);
        #endregion

        #region public static Measure Metres = new Measure(11, "M", "Metres", MeasureCategory.Length);
        /// <summary>
        /// Метры
        /// </summary>
        public static Measure Metres = new Measure(11, "M", "Metres", MeasureCategory.Length);
        #endregion

        #region public static Measure Centimeters = new Measure(12, "CM", "Centimeters", MeasureCategory.Length);
        /// <summary>
        /// Сантиметры
        /// </summary>
        public static Measure Centimeters = new Measure(12, "CM", "Centimeters", MeasureCategory.Length);
        #endregion

        #region public static Measure Millimeters = new Measure(13, "MM", "Millimeters", MeasureCategory.Length);
        /// <summary>
        /// Миллиметры
        /// </summary>
        public static Measure Millimeters = new Measure(13, "MM", "Millimeters", MeasureCategory.Length);
        #endregion

        #region public static Measure Miles = new Measure(16, "Ml", "Miles", MeasureCategory.Length);
        /// <summary>
        /// Миля
        /// </summary>
        public static Measure Miles = new Measure(16, "Ml", "Miles", MeasureCategory.Length);

        #endregion

        #region public static Measure Foot = new Measure(18, "FT", "FT", MeasureCategory.Length);
        /// <summary>
        /// Фут
        /// </summary>
        public static Measure Foot = new Measure(18, "FT", "FT", MeasureCategory.Length);

        #endregion

        #region public static Measure Inches = new Measure(19, "Inch", "Inches", MeasureCategory.Length);
        /// <summary>
        /// Дюймы
        /// </summary>
        public static Measure Inches = new Measure(19, "Inch", "Inches", MeasureCategory.Length);
        #endregion

        #region public static Measure Kilograms = new Measure(30, "KG", "Kilograms", MeasureCategory.Weight);
        /// <summary>
        /// Килограммы
        /// </summary>
        public static Measure Kilograms = new Measure(30, "KG", "Kilograms", MeasureCategory.Mass);
        #endregion

        #region public static Measure Lb = new Measure(31, "Lb", "Lb", MeasureCategory.Weight);
        /// <summary>
        /// Фунт
        /// </summary>
        public static Measure Lb = new Measure(31, "Lb", "Lb", MeasureCategory.Mass);
        #endregion

        #region public static Measure Liter = new Measure(40, "Lt", "Liter", MeasureCategory.Volume);
        /// <summary>
        /// Литр
        /// </summary>
        public static Measure Liter = new Measure(40, "Lt", "Liter", MeasureCategory.Volume);

        #endregion

        #region public static Measure Gallon = new Measure(45, "Gal", "Gallon", MeasureCategory.Volume);
        /// <summary>
        /// Галлон 
        /// </summary>
        public static Measure Gallon = new Measure(45, "Gal", "Gallon", MeasureCategory.Volume);

        #endregion

        #region public static Measure Quart = new Measure(46, "Qrt", "Quart", MeasureCategory.Volume);
        /// <summary>
        /// Кварта 
        /// </summary>
        public static Measure Quart = new Measure(46, "Qrt", "Quart", MeasureCategory.Volume);

		#endregion

		#region public static Measure Can = new Measure(47, "Can", "Can", MeasureCategory.Volume);

		public static Measure Can = new Measure(47, "Can", "Can", MeasureCategory.Volume);

		#endregion

		#region public static Measure Tube = new Measure(48, "Tube", "Tube", MeasureCategory.Volume);

		public static Measure Tube = new Measure(48, "Tube", "Tube", MeasureCategory.Volume);

		#endregion

		#region public static Measure Botle = new Measure(49, "Botle", "Botle", MeasureCategory.Volume);
		
		public static Measure Botle = new Measure(49, "Botle", "Botle", MeasureCategory.Volume);

		#endregion

		#region public static Measure Box = new Measure(50, "Box", "Box", MeasureCategory.Volume);
		
		public static Measure Box = new Measure(50, "Box", "Box", MeasureCategory.Volume);

		#endregion

		#region public static Measure KgCm2 = new Measure(51, "KgCm2", "Kg/Cm2", MeasureCategory.Pressure);
		/// <summary>
		/// Килограмм на квадратный сантиметр
		/// </summary>
		public static Measure KgCm2 = new Measure(51, "KgCm2", "Kg/Cm2", MeasureCategory.Pressure);
		#endregion


		#region public static Measure PCI = new Measure(61, "PCI", "PCI", MeasureCategory.Pressure);
		/// <summary>
		/// Килограмм на квадратный сантиметр
		/// </summary>
		public static Measure PCI = new Measure(61, "PCI", "PCI", MeasureCategory.Pressure);
		#endregion

		#region public static Measure DegreeCelsius = new Measure(71, "°C", "°C", MeasureCategory.Temperature);
		/// <summary>
		/// Градус Цельсия
		/// </summary>
		public static Measure DegreeCelsius = new Measure(71, "°C", "°C", MeasureCategory.Temperature);
        #endregion

        #region public static Measure KgHour = new Measure(91, "KgH", "Kg/hr", MeasureCategory.MassFlowRate);
        /// <summary>
        /// Килограм в час
        /// </summary>
        public static Measure KgHour = new Measure(91, "KgH", "Kg/h", MeasureCategory.MassFlowRate);
        #endregion

        #region public static Measure KgSec = new Measure(92, "KgS", "Kg/s", MeasureCategory.MassFlowRate);
        /// <summary>
        /// Килограм в секунду
        /// </summary>
        public static Measure KgSec = new Measure(92, "KgS", "Kg/s", MeasureCategory.MassFlowRate);
		#endregion

		#region public static Measure PoundHour = new Measure(93, "PoundH", "Pound/h", MeasureCategory.MassFlowRate);

		public static Measure PoundHour = new Measure(93, "PoundH", "Pound/h", MeasureCategory.MassFlowRate);

		#endregion

		#region public static Measure PoundSec = new Measure(94, "PoundS", "Pound/s", MeasureCategory.MassFlowRate);

		public static Measure PoundSec = new Measure(94, "PoundS", "Pound/s", MeasureCategory.MassFlowRate);

		#endregion

		#region public static Measure QuartHour = new Measure(95, "QuartH", "Quart/h", MeasureCategory.MassFlowRate);

		public static Measure QuartHour = new Measure(95, "QuartH", "Quart/h", MeasureCategory.MassFlowRate);

		#endregion

		#region public static Measure QuartSec = new Measure(96, "QuartS", "Quart/s", MeasureCategory.MassFlowRate);

		public static Measure QuartSec = new Measure(96, "QuartS", "Quart/s", MeasureCategory.MassFlowRate);

		#endregion

		#region public static Measure GallonHour = new Measure(97, "GallonH", "Gallon/h", MeasureCategory.MassFlowRate);

		public static Measure GallonHour = new Measure(97, "GallonH", "Gallon/h", MeasureCategory.MassFlowRate);

	    #endregion

		#region public static Measure LiterHour = new Measure(101, "LtH", "Lt/h", MeasureCategory.FlowRate);
		/// <summary>
		/// литр в час
		/// </summary>
		public static Measure LiterHour = new Measure(101, "LtH", "Lt/h", MeasureCategory.FlowRate);
        #endregion

        #region public static Measure LiterSec = new Measure(102, "LtS", "Lt/S", MeasureCategory.FlowRate);
        /// <summary>
        /// литр в сек
        /// </summary>
        public static Measure LiterSec = new Measure(102, "LtS", "Lt/S", MeasureCategory.FlowRate);
        #endregion

        #region public static Measure Unit = new Measure(151, "Unit", "Unit", MeasureCategory.EconomicEntity);
        /// <summary>
        /// Единица 
        /// </summary>
        public static Measure Unit = new Measure(151, "Unit", "Unit", MeasureCategory.EconomicEntity);
        #endregion

        #region public static Measure Pieces = new Measure(152, "Pieces", "Pieces", MeasureCategory.EconomicEntity);
        /// <summary>
        /// Штука
        /// </summary>
        public static Measure Pieces = new Measure(152, "Pieces", "Pieces", MeasureCategory.EconomicEntity);
        #endregion

        #region public static Measure SquareMeter = new Measure(170, "M2", "M2", MeasureCategory.Area);
        /// <summary>
        /// Квадратный метр
        /// </summary>
        public static Measure SquareMeter = new Measure(170, "M2", "M2", MeasureCategory.Area);

        #endregion

        #region public static Measure SquareFoot = new Measure(180, "Ft2", "FT2", MeasureCategory.Area);
        /// <summary>
        /// Квадратный  Фут
        /// </summary>
        public static Measure SquareFoot = new Measure(180, "Ft2", "FT2", MeasureCategory.Area);

        #endregion

        /*
         * Свойства 
         */

        #region static public CommonDictionaryCollection<Measure> Items
        /// <summary>
        /// Возвращает список элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<Measure> Items
        {
            get
            {
                return _Items;
            }
        }
        #endregion

        /*
		*  Методы 
		*/

        #region public Measure()
        /// <summary>
        /// Конструктор создает пустой объект категории единицы измерения
        /// </summary>
        public Measure()
        {
        }
        #endregion

        #region public Measure(Int32 ItemId, String shortName, String fullName)

        /// <summary>
        /// Конструктор создает объект категории единицы измерения
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="mc"></param>
        public Measure(Int32 itemId, String shortName, String fullName, MeasureCategory mc)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            MeasureCategory = mc;
            _Items.Add(this);
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FullName;
        }
        #endregion

        #region public static Measure[] GetByCategory(MeasureCategory category)
        /// <summary>
        /// Возвращает единицы измерения соостветствующие определенной категории, 
        /// </summary>
        /// <returns></returns>
        public static Measure[] GetByCategory(MeasureCategory category)
        {
            return _Items.Where(m=>m.MeasureCategory == category).ToArray();
        }
        #endregion

        #region public static Measure[] GetByCategories(IEnumerable<MeasureCategory> categories)
        /// <summary>
        /// Возвращает единицы измерения соостветствующие заданным категории, 
        /// </summary>
        /// <returns></returns>
        public static Measure[] GetByCategories(IEnumerable<MeasureCategory> categories)
        {
            if (categories == null || !categories.Any())
                return Items.ToArray();
            return _Items.Where(m => categories.Contains(m.MeasureCategory)).ToArray();
        }
        #endregion

        #region public static double Convert(double value, Measure from, Measure to)
        /// <summary>
        /// Переводит значение из одной единицы измерения в другую, 
        /// <br/> или возвращает значение обратно, в случае неверно заданных параметров
        /// </summary>
        /// <returns></returns>
        public static double Convert(double value, Measure from, Measure to)
        {
            if (from == null || to == null ||
                from == to ||
                from.MeasureCategory != to.MeasureCategory ) return value;

            if(from == Kilograms)
            {
                //из килограммов в фунты
                if(to == Lb) return value/0.45359237f;
            }
            if (from == Lb)
            {
                //из фунтов в килограммы
                if (to == Kilograms) return value * 0.45359237f;
            }
            return value;
        }
        #endregion
    }

    #region public class MeasureCategory : StaticDictionary
    /// <summary>
    /// Категория Единицы измерения
    /// </summary>
    [Serializable]
    public class MeasureCategory : StaticDictionary
    {

        #region private static CommonDictionaryCollection<MeasureCategory> _Items = new CommonDictionaryCollection<MeasureCategory>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<MeasureCategory> _Items = new CommonDictionaryCollection<MeasureCategory>();
        #endregion

        /*
         * Предопределенные типы
         */
        #region public static MeasureCategory Unknown = new MeasureCategory(-1, "Unk", "Unknown", "");
        /// <summary>
        /// Неизвестный
        /// </summary>
        public static MeasureCategory Unknown = new MeasureCategory(-1, "Unk", "Unknown");
        #endregion

        #region public static MeasureCategory Area = new MeasureCategory(1, "A", "Area");
        /// <summary>
        /// площадь
        /// </summary>
        public static MeasureCategory Area = new MeasureCategory(1, "A", "Area");
        #endregion

        #region public static MeasureCategory Length = new MeasureCategory(11, "L", "Length");
        /// <summary>
        /// длина
        /// </summary>
        public static MeasureCategory Length = new MeasureCategory(11, "L", "Length");
        #endregion

        #region public static MeasureCategory Volume = new MeasureCategory(21, "V", "Volume");
        /// <summary>
        /// объем
        /// </summary>
        public static MeasureCategory Volume = new MeasureCategory(21, "V", "Volume");
        #endregion

        #region public static MeasureCategory Mass = new MeasureCategory(31, "M", "Mass");
        /// <summary>
        /// вес
        /// </summary>
        public static MeasureCategory Mass = new MeasureCategory(31, "M", "Mass");
        #endregion

        #region public static MeasureCategory Pressure = new MeasureCategory(41, "P", "Pressure");
        /// <summary>
        /// Давление
        /// </summary>
        public static MeasureCategory Pressure = new MeasureCategory(41, "P", "Pressure");
		#endregion

		#region public static MeasureCategory Temperature = new MeasureCategory(51, "T", "Temperature");
		/// <summary>
		/// Температура
		/// </summary>
		public static MeasureCategory Temperature = new MeasureCategory(51, "T", "Temperature");
        #endregion

        #region public static MeasureCategory FlowRate = new MeasureCategory(61, "MFR", "Mass Flow rate");
        /// <summary>
        /// Массовая Скорость потока
        /// </summary>
        public static MeasureCategory MassFlowRate = new MeasureCategory(61, "MFR", "Mass Flow rate");
        #endregion

        #region public static MeasureCategory FlowRate = new MeasureCategory(71, "FR", "Flow rate");
        /// <summary>
        /// Скорость потока
        /// </summary>
        public static MeasureCategory FlowRate = new MeasureCategory(71, "FR", "Flow rate");
        #endregion

        #region public static MeasureCategory EconomicEntity = new MeasureCategory(81, "EE", "Economic Entity");
        /// <summary>
        /// Экономические единицы
        /// </summary>
        public static MeasureCategory EconomicEntity = new MeasureCategory(81, "EE", "Economic Entity");
        #endregion

        /*
         * Свойства 
         */

        #region static public CommonDictionaryCollection<MeasureCategory> Items
        /// <summary>
        /// Возвращает список элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<MeasureCategory> Items
        {
            get
            {
                return _Items;
            }
        }
        #endregion

        /*
		*  Методы 
		*/
        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FullName;
        }
        #endregion

        #region public MeasureCategory()
        /// <summary>
        /// Конструктор создает пустой объект категории единицы измерения
        /// </summary>
        public MeasureCategory()
        {
        }
        #endregion

        #region public MeasureCategory(Int32 ItemId, String shortName, String fullName)

        /// <summary>
        /// Конструктор создает объект категории единицы измерения
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        public MeasureCategory(Int32 itemId, String shortName, String fullName)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            _Items.Add(this);
        }
        #endregion
    }

    #endregion
}
