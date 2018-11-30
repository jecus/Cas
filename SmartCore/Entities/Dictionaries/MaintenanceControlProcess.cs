using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    [Serializable]
    public class MaintenanceControlProcess : StaticDictionary
    {

        #region private static CommonDictionaryCollection<MaintenanceControlProcess> _Items = new CommonDictionaryCollection<MaintenanceControlProcess>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<MaintenanceControlProcess> _Items = new CommonDictionaryCollection<MaintenanceControlProcess>();
        #endregion

        /*
         * Предопределенные типы
         */

        #region public static MaintenanceControlProcess OC = new MaintenanceControlProcess(1, "OC", "On condition");
        /// <summary>
        /// 
        /// </summary>
        public static MaintenanceControlProcess OC = new MaintenanceControlProcess(1, "OC", "On condition");
        #endregion

        #region public static MaintenanceControlProcess CM = new MaintenanceControlProcess(2, "CM", "Condition monitoring");
        /// <summary>
        /// 
        /// </summary>
        public static MaintenanceControlProcess CM = new MaintenanceControlProcess(2, "CM", "Condition monitoring");
        #endregion

        #region public static MaintenanceControlProcess HT = new MaintenanceControlProcess(3, "HT", "Hard Time");
        /// <summary>
        /// 
        /// </summary>
        public static MaintenanceControlProcess HT = new MaintenanceControlProcess(3, "HT", "Hard Time");
        #endregion

        #region public static MaintenanceControlProcess UNK = new MaintenanceControlProcess(4, "UNK", "Unknown detail type");
        /// <summary>
        /// 
        /// </summary>
        public static MaintenanceControlProcess UNK = new MaintenanceControlProcess(4, "UNK", "Unknown detail type");
        #endregion

        /*
         * Свойства 
         */

        /*
         * Методы
         */

        #region public static MaintenanceControlProcess GetItemById(Int32 maintenanceTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="maintenanceTypeId"></param>
        /// <returns></returns>
        public static MaintenanceControlProcess GetItemById(Int32 maintenanceTypeId)
        {
            foreach (MaintenanceControlProcess t in _Items)
                if (t.ItemId == maintenanceTypeId)
                    return t;
            //
            return UNK;
        }

        #endregion

        #region static public CommonDictionaryCollection<MaintenanceControlProcess> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<MaintenanceControlProcess> Items
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
         * Реализация
         */
        #region public MaintenanceControlProcess()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public MaintenanceControlProcess()
        {
        }
        #endregion

        #region public MaintenanceControlProcess(Int32 itemID, String shortName, String fullName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        public MaintenanceControlProcess(Int32 itemId, String shortName, String fullName)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;

            _Items.Add(this);
        }
        #endregion

        #region public override int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is MaintenanceControlProcess)
                return FullName.CompareTo(((MaintenanceControlProcess)y).FullName);
            return 0;
        }
        #endregion
    }
}
