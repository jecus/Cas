using System;
using System.Collections.Generic;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.RoutineAudits
{
    [Serializable]
    public class ActionProgramType : StaticDictionary
    {
        #region public static CommonDictionaryCollection<ActionProgramType> _Items = new CommonDictionaryCollection<ActionProgramType>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<ActionProgramType> _Items = new CommonDictionaryCollection<ActionProgramType>();
        #endregion

        public static ActionProgramType SAFAOperator = new ActionProgramType(1, "Providing information to operator", "Providing information to operator", "", new [] {ProgramType.SAFA});
        public static ActionProgramType SAFACAA = new ActionProgramType(2, "Providing information to operator and CAA", "Providing information to operator and CAA", "", new [] {ProgramType.SAFA});
        public static ActionProgramType SAFARestrictions = new ActionProgramType(3, "Restrictions on the aircraft operation", "Restrictions on the aircraft operation", "", new [] {ProgramType.SAFA});
        public static ActionProgramType SAFACorrective = new ActionProgramType(4, "Corrective actions before flight", "Corrective actions before flight", "", new [] {ProgramType.SAFA});
        public static ActionProgramType SAFAAircraft = new ActionProgramType(5, "Aircraft grounded (AOG)", "Aircraft grounded (AOG)", "", new [] {ProgramType.SAFA});
        
        
        
        public static ActionProgramType IOSAOperator = new ActionProgramType(10, "Providing information to operator", "Providing information to operator", "", new [] {ProgramType.IOSA });
        public static ActionProgramType IOSACAA = new ActionProgramType(11, "Providing information to operator and CAA", "", "Providing information to operator and CAA", new [] {ProgramType.IOSA });
        public static ActionProgramType IOSARestrictions = new ActionProgramType(12, "Restrictions on the Operator operation", "Restrictions on the Operator operation", "", new [] {ProgramType.IOSA });
        public static ActionProgramType IOSACorrective = new ActionProgramType(13, "Corrective actions before operation", "Corrective actions before operation", "", new [] {ProgramType.IOSA });
        public static ActionProgramType IOSAOperatorStopped = new ActionProgramType(14, "Operator's activity is operator stopped", "Operator's activity is operator stopped", "", new [] {ProgramType.IOSA });

        
        
        
        
        public static ActionProgramType Unknown = new ActionProgramType(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static ActionProgramType GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static ActionProgramType GetItemById(int directiveTypeId)
        {
            foreach (ActionProgramType t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<ActionProgramType> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<ActionProgramType> Items
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
        
        public List<ProgramType> ProgramTypes { get; set; }

        /*
         * Реализация
         */
        #region public ActionProgramType()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public ActionProgramType()
        {
        }
        #endregion

        #region public ActionProgramType(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public ActionProgramType(Int32 itemID, String shortName, String fullName, String commonName, ProgramType[] type)
        {
            ItemId = itemID;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;
            ProgramTypes = new List<ProgramType>(type);

            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }
        
        public ActionProgramType(Int32 itemID, String shortName, String fullName, String commonName)
        {
            ItemId = itemID;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;
            ProgramTypes = new List<ProgramType>();

            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }        
        
        #endregion
	}
}
