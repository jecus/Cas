using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.RoutineAudits
{
    [Serializable]
    public class PELRole : StaticDictionary
    {
        #region public static CommonDictionaryCollection<PELRole> _Items = new CommonDictionaryCollection<PELRole>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<PELRole> _Items = new CommonDictionaryCollection<PELRole>();
        #endregion

        public static PELRole GroupManager = new PELRole(1, "Group Manager", "Group Manager", "");
        public static PELRole KeyGroupManager = new PELRole(2, "Key Group Manager", "Key Group Manager", "");
        public static PELRole Expert = new PELRole(3, "Expert", "Expert", "");
        public static PELRole KeyExpert = new PELRole(4, "SKey Expert", "Key Expert", "");
        public static PELRole ProjectDirector = new PELRole(5, "Project Director", "Project Director", "");
        public static PELRole ProjectManager = new PELRole(6, "ProjectManager", "ProjectManager", "");
        public static PELRole Inspector = new PELRole(7, "Inspector", "Inspector", "");
        public static PELRole LeaderTeam = new PELRole(8, "Leader Team", "Leader Team", "");
        public static PELRole Advisor = new PELRole(9, "Advisor", "Advisor", "");
        public static PELRole TechnicalAdvisor = new PELRole(10, "Technical Advisor", "Technical Advisor", "");
        public static PELRole SpecialAdvisor = new PELRole(11, "Special Advisor", "Special Advisor", "");
        public static PELRole Associate = new PELRole(12, "Associate", "Associate", "");
        public static PELRole Unknown = new PELRole(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static PELRole GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static PELRole GetItemById(int directiveTypeId)
        {
            foreach (PELRole t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<PELRole> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<PELRole> Items
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
        #region public PELRole()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public PELRole()
        {
        }
        #endregion

        #region public PELRole(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public PELRole(Int32 itemID, String shortName, String fullName, String commonName)
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
