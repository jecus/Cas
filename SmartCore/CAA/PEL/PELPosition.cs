using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.PEL
{
    
    [Serializable]
    public class PELPosition : StaticDictionary
    {
        #region public static CommonDictionaryCollection<PELPosition> _Items = new CommonDictionaryCollection<PELPosition>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<PELPosition> _Items = new CommonDictionaryCollection<PELPosition>();
        #endregion

        public static PELPosition GroupManager = new PELPosition(1, "Group Manager", "Group Manager", "");
        public static PELPosition ProjectDirector = new PELPosition(2, "Project Director", "Project Director", "");
        public static PELPosition ProjectManager = new PELPosition(3, "ProjectManager", "ProjectManager", "");
        public static PELPosition LeaderTeam = new PELPosition(4, "Leader Team", "Leader Team", "");
        public static PELPosition Unknown = new PELPosition(-1, "N/A", "N/A", "N/A");

        /*
         * Методы
         */

        #region public static PELPosition GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static PELPosition GetItemById(int directiveTypeId)
        {
            foreach (PELPosition t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<PELPosition> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<PELPosition> Items
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
        #region public PELPosition()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public PELPosition()
        {
        }
        #endregion

        #region public PELPosition(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public PELPosition(Int32 itemID, String shortName, String fullName, String commonName)
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
