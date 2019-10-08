using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    [Serializable]
    public class InitialReason : StaticDictionary
    {

        #region private static CommonDictionaryCollection<InitionalReason> _Items = new CommonDictionaryCollection<InitionalReason>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<InitialReason> _Items = new CommonDictionaryCollection<InitialReason>();
        #endregion

        /*
         * Предопределенные типы
         */

        #region public static InitionalReason DefectCrew = new InitionalReason(1, "Crew", "Defect (Crew)", "");
        /// <summary>
        /// 
        /// </summary>
        public static InitialReason DefectCrew = new InitialReason(1, "Crew", "Defect (Crew)", "");
        #endregion

        #region public static InitionalReason DefectMaintenance = new InitionalReason(2, "Maintenance", "Defect (Maintenance)", "");
        /// <summary>
        /// 
        /// </summary>
        public static InitialReason DefectMaintenance = new InitialReason(2, "Maintenance", "Defect (Maintenance)", "");
        #endregion

        #region public static InitionalReason Routine = new InitionalReason(3, "Routine", "Routine", "");
        /// <summary>
        /// 
        /// </summary>
        public static InitialReason Routine = new InitialReason(3, "Routine", "Routine", "");
        #endregion

        #region public static InitionalReason NonRoutine = new InitionalReason(4, "Non-Routine", "Non-Routine", "");
        /// <summary>
        /// 
        /// </summary>
        public static InitialReason NonRoutine = new InitialReason(4, "Non-Routine", "Non-Routine", "");
        #endregion

        #region public static InitionalReason AD = new InitionalReason(5, "AD", "AD", "");
        /// <summary>
        /// 
        /// </summary>
        public static InitialReason AD = new InitialReason(5, "AD", "AD", "");
        #endregion

        #region public static InitionalReason SB = new InitionalReason(6, "SB", "SB", "");
        /// <summary>
        /// 
        /// </summary>
        public static InitialReason SB = new InitialReason(6, "SB", "SB", "");
        #endregion

        #region public static InitionalReason SL = new InitionalReason(7, "SL", "SL", "");
        /// <summary>
        /// 
        /// </summary>
        public static InitialReason SL = new InitialReason(7, "SL", "SL", "");
		#endregion

		#region public static InitialReason EO = new InitialReason(8, "EO", "EO", "");
		/// <summary>
		/// 
		/// </summary>
		public static InitialReason EO = new InitialReason(8, "EO", "EO", "");
		#endregion

		#region public static InitialReason Recycling = new InitialReason(9, "Recycling", "Recycling", "");

		public static InitialReason Recycling = new InitialReason(9, "Recycling", "Recycling", "");

		#endregion

		#region public static InitialReason Pool = new InitialReason(10, "Pool", "Pool", "");

		public static InitialReason Pool = new InitialReason(10, "Pool", "Pool", "");

		#endregion

		#region public static InitialReason Lease = new InitialReason(11, "Lease", "Lease", "");

		public static InitialReason Lease = new InitialReason(11, "Lease", "Lease", "");

		#endregion

		#region public static InitialReason Sale = new InitialReason(12, "Sale", "Sale", "");

		public static InitialReason Sale = new InitialReason(12, "Sale", "Sale", "");

		#endregion

		#region public static InitialReason Forpersonaluse = new InitialReason(13, "For personal use", "For personal use", "");

		public static InitialReason Forpersonaluse = new InitialReason(13, "For personal use", "For personal use", "");

		#endregion

		#region public static InitialReason Return = new InitialReason(14, "Return", "Return", "");

		public static InitialReason Return = new InitialReason(14, "Return", "Return", "");

		#endregion

		#region public static InitialReason SWAP = new InitialReason(15, "SWAP", "SWAP", "");

		public static InitialReason SWAP = new InitialReason(15, "SWAP", "SWAP", "");

		#endregion

		#region public static InitialReason ByProduction = new InitialReason(16, "By production necessity", "By production necessity", "");

		public static InitialReason ByProduction = new InitialReason(16, "By production necessity", "By production necessity", "");

		#endregion

		#region public static InitialReason ResourceLimitation = new InitialReason(17, "Resource limitation", "Resource limitation", "");

		public static InitialReason ResourceLimitation = new InitialReason(17, "Resource limitation", "Resource limitation", "");

		#endregion

		#region public static InitialReason MEL = new InitialReason(18, "MEL", "MEL", "");

		public static InitialReason MEL = new InitialReason(18, "MEL", "MEL", "");

		#endregion

		#region public static InitionalReason All = new InitionalReason(-2, "All", "All", "All");
		/// <summary> 
		/// Указатель на то что нужно выводить все директивы в скрине Forecast
		/// </summary>
		public static InitialReason All = new InitialReason(-2, "All", "All", "All");
        #endregion

        #region public static InitionalReason Unknown = new InitionalReason(-1, "Unknown", "Unknown", "Unknown");
        /// <summary> 
        /// Неизвестный объект
        /// </summary>
        public static InitialReason Unknown = new InitialReason(-1, "Unknown", "Unknown", "Unknown");
        #endregion

        /*
         * Методы
         */

        #region public static InitionalReason GetItemById(Int32 itemId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static InitialReason GetItemById(Int32 itemId)
        {
            foreach (InitialReason t in _Items)
                if (t.ItemId == itemId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<InitionalReason> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<InitialReason> Items
        {
            get { return _Items; }
        }
        #endregion

        #region public virtual override CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is DirectiveWorkType)
                return FullName.CompareTo(((DirectiveWorkType)y).FullName);
            return 0;
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Переводит тип директивы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FullName;
        }
        #endregion

        /*
         * Реализация
         */
        #region public InitionalReason()
        public InitialReason()
        {
            
        }
        #endregion

        #region public InitionalReason(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект начальноц проичины закупки
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public InitialReason(Int32 itemId, String shortName, String fullName, String commonName)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;

            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }
        #endregion
    
    }
}
