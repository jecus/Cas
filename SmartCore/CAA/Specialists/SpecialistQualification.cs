using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Specialists
{
    [Serializable]
    public class SpecialistQualification : StaticDictionary
    {
        #region public static CommonDictionaryCollection<SpecialistQualification> _Items = new CommonDictionaryCollection<SpecialistQualification>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<SpecialistQualification> _Items = new CommonDictionaryCollection<SpecialistQualification>();
        #endregion

        public static SpecialistQualification CertificationAirOperator = new SpecialistQualification(1, "Certification Air Operator", "Certification Air Operator", "");
        public static SpecialistQualification AMO = new SpecialistQualification(2, "Certification AMO", "Certification AMO", "");
        public static SpecialistQualification CATO = new SpecialistQualification(3, "Certification CAMO", "Certification CAMO", "");
        public static SpecialistQualification ATO = new SpecialistQualification(4, "Certification ATO", "Certification ATO", "");
        public static SpecialistQualification Aerodrome = new SpecialistQualification(5, "Certification Aerodrome", "Certification Aerodrome", "");
        public static SpecialistQualification ATC = new SpecialistQualification(6, "Certification ATC/ANS", "Certification ATC/ANS", "");
        public static SpecialistQualification AeMC = new SpecialistQualification(7, "Certification AeMC", "Certification AeMC", "");
        public static SpecialistQualification Airworthiness = new SpecialistQualification(8, "Certification Airworthiness", "Certification Airworthiness", "");
        public static SpecialistQualification Personnel = new SpecialistQualification(9, "Certification Personnel", "Certification Personnel", "");
        public static SpecialistQualification ORG = new SpecialistQualification(10, "Organization and Management System (ORG)", "Organization and Management System (ORG)", "");
        public static SpecialistQualification FLT = new SpecialistQualification(11, "Flight Operations (FLT)", "Flight Operations (FLT)", "");
        public static SpecialistQualification DSP = new SpecialistQualification(12, "Operational Control and Flight Dispatch (DSP)", "Operational Control and Flight Dispatch (DSP)", "");
        public static SpecialistQualification MNT = new SpecialistQualification(13, "Aircraft Engineering and Maintenance (MNT)", "Aircraft Engineering and Maintenance (MNT)", "");
        public static SpecialistQualification CAB = new SpecialistQualification(14, "Cabin Operations (CAB)", "Cabin Operations (CAB)", "");
        public static SpecialistQualification GRH = new SpecialistQualification(15, "Ground Handling Operations (GRH)", "Ground Handling Operations (GRH)", "");
        public static SpecialistQualification CGO = new SpecialistQualification(16, "Cargo Operations (CGO)", "Cargo Operations (CGO)", "");
        public static SpecialistQualification SEC = new SpecialistQualification(17, "Security Management (SEC)", "Security Management (SEC)", "");
        public static SpecialistQualification ORM = new SpecialistQualification(18, "Organization and Management (ORM)", "Organization and Management (ORM)", "");
        public static SpecialistQualification LOD = new SpecialistQualification(19, "Load Control (LOD)", "Load Control (LOD)", "");
        public static SpecialistQualification PAB = new SpecialistQualification(20, "Passenger and Baggage Handling (PAB)", "Passenger and Baggage Handling (PAB)", "");
        public static SpecialistQualification HDL = new SpecialistQualification(21, "Aircraft Handling and Loading (HDL)", "Aircraft Handling and Loading (HDL)", "");
        public static SpecialistQualification AGM = new SpecialistQualification(22, "Aircraft Ground Movement (AGM)", "Aircraft Ground Movement (AGM)", "");
        public static SpecialistQualification CGM = new SpecialistQualification(23, "Cargo and Mail Handling (CGM)", "Cargo and Mail Handling (CGM)", "");


        /*
         * Методы
         */

        #region public static SpecialistQualification GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static SpecialistQualification GetItemById(int directiveTypeId)
        {
            foreach (SpecialistQualification t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return CertificationAirOperator;
        }

        #endregion

        #region static public CommonDictionaryCollection<SpecialistQualification> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<SpecialistQualification> Items
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
        #region public SpecialistQualification()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public SpecialistQualification()
        {
        }
        #endregion

        #region public SpecialistQualification(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public SpecialistQualification(Int32 itemID, String shortName, String fullName, String commonName)
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
