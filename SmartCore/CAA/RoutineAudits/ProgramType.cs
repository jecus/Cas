using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.RoutineAudits
{
    [Serializable]
    public class ProgramType : StaticDictionary
    {
        #region public static CommonDictionaryCollection<ProgramType> _Items = new CommonDictionaryCollection<ProgramType>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<ProgramType> _Items = new CommonDictionaryCollection<ProgramType>();
        #endregion

        public static ProgramType IOSA = new ProgramType(1, "IOSA", "IOSA", "");
        public static ProgramType EASA = new ProgramType(2, "EASA Part-FCL", "EASA Part-FCL", "");
        public static ProgramType SAFA = new ProgramType(3, "SAFA", "SAFA", "");
        public static ProgramType SANAKG = new ProgramType(4, "SANA KG", "SANA KG", "");
        public static ProgramType CAAKG = new ProgramType(5, "CAA KG", "CAA KG", "");
        public static ProgramType ISAGO = new ProgramType(6, "ISAGO", "ISAGO", "");
        public static ProgramType SACA = new ProgramType(7, "SACA", "SACA", "");
        public static ProgramType ICAO = new ProgramType(8, "ICAO", "ICAO", "");
        public static ProgramType EASAMed = new ProgramType(9, "EASA Part-Med", "EASA Part-Med", "");
        public static ProgramType Unknown = new ProgramType(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static ProgramType GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static ProgramType GetItemById(int directiveTypeId)
        {
            foreach (ProgramType t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<ProgramType> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<ProgramType> Items
        {
            get
            {
                return _Items;
            }
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
        * Свойства
        */

        /*
         * Реализация
         */
        #region public ProgramType()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public ProgramType()
        {
        }
        #endregion

        #region public ProgramType(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public ProgramType(Int32 itemID, String shortName, String fullName, String commonName)
        {
            ItemId = itemID;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;

            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }
        #endregion
	}
}
