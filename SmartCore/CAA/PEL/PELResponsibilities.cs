using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.RoutineAudits
{
    [Serializable]
    public class PELResponsibilities : StaticDictionary
    {
        
        public ProgramType ProgramType { get; set; }
            
        
        #region public static CommonDictionaryCollection<PELResponsibilities> _Items = new CommonDictionaryCollection<PELResponsibilities>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<PELResponsibilities> _Items = new CommonDictionaryCollection<PELResponsibilities>();
        #endregion

        public static PELResponsibilities ORG = new PELResponsibilities(1, "Organization and Management System (ORG)", "Organization and Management System (ORG)", "", ProgramType.IOSA);
        public static PELResponsibilities FLT = new PELResponsibilities(2, "Flight Operations (FLT)", "Flight Operations (FLT)", "", ProgramType.IOSA);
        public static PELResponsibilities DSP = new PELResponsibilities(3, "Operational Control and Flight Dispatch (DSP)", "Operational Control and Flight Dispatch (DSP)", "", ProgramType.IOSA);
        public static PELResponsibilities MNT = new PELResponsibilities(4, "Aircraft Engineering and Maintenance (MNT)", "Aircraft Engineering and Maintenance (MNT)", "", ProgramType.IOSA);
        public static PELResponsibilities CAB = new PELResponsibilities(5, "Cabin Operations (CAB)", "Cabin Operations (CAB)", "", ProgramType.IOSA);
        public static PELResponsibilities GRH = new PELResponsibilities(6, "Ground Handling Operations (GRH)", "Ground Handling Operations (GRH)", "", ProgramType.IOSA);
        public static PELResponsibilities CGO = new PELResponsibilities(7, "Cargo Operations (CGO)", "Cargo Operations (CGO)", "", ProgramType.IOSA);
        public static PELResponsibilities SEC = new PELResponsibilities(8, "Security Management (SEC)", "Security Management (SEC)", "", ProgramType.IOSA);

        
        public static PELResponsibilities ORM = new PELResponsibilities(1, "Organization and Management (ORM)", "Organization and Management (ORM)", "", ProgramType.ISAGO);
        public static PELResponsibilities LOD = new PELResponsibilities(2, "Load Control (LOD)", "Load Control (LOD)", "", ProgramType.ISAGO);
        public static PELResponsibilities PAB = new PELResponsibilities(3, "Passenger and Baggage Handling (PAB)", "Passenger and Baggage Handling (PAB)", "", ProgramType.ISAGO);
        public static PELResponsibilities HDL = new PELResponsibilities(4, "Aircraft Handling and Loading (HDL)", "Aircraft Handling and Loading (HDL)", "", ProgramType.ISAGO);
        public static PELResponsibilities AGM = new PELResponsibilities(5, "Aircraft Ground Movement (AGM)", "Aircraft Ground Movement (AGM)", "", ProgramType.ISAGO);
        public static PELResponsibilities CGM = new PELResponsibilities(6, "Cargo and Mail Handling (CGM).", "Cargo and Mail Handling (CGM).", "", ProgramType.ISAGO);
        
        
        public static PELResponsibilities Unknown = new PELResponsibilities(-1, "Unknown", "Unknown", "Unknown", ProgramType.Unknown);

        /*
         * Методы
         */

        #region public static PELResponsibilities GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static PELResponsibilities GetItemById(int directiveTypeId)
        {
            foreach (PELResponsibilities t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<PELResponsibilities> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<PELResponsibilities> Items
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
        #region public PELResponsibilities()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public PELResponsibilities()
        {
        }
        #endregion

        #region public PELResponsibilities(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public PELResponsibilities(Int32 itemID, String shortName, String fullName, String commonName, ProgramType programType)
        {
            ItemId = itemID;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;
            ProgramType = programType;

            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }
        #endregion
	}
}
