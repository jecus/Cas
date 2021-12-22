using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Operators
{
    public class TypesOfOperations : StaticDictionary
    {
        #region public static CommonDictionaryCollection<TypesOfOperations> _Items = new CommonDictionaryCollection<TypesOfOperations>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<TypesOfOperations> _Items = new CommonDictionaryCollection<TypesOfOperations>();
        #endregion

        public static TypesOfOperations Passangerandcargo = new TypesOfOperations(1, "Passanger and cargo", "Passanger and cargo", "");
        public static TypesOfOperations Cargoonly = new TypesOfOperations(2, "Cargo only", "Cargo only", "");
        public static TypesOfOperations Scheduledoperations = new TypesOfOperations(3, "Scheduled operations", "Scheduled operations", "");
        public static TypesOfOperations Charterflightoperations = new TypesOfOperations(4, "Charter flight operations", "Charter flight operations", "");
        public static TypesOfOperations Unknown = new TypesOfOperations(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static TypesOfOperations GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static TypesOfOperations GetItemById(int directiveTypeId)
        {
            foreach (TypesOfOperations t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<TypesOfOperations> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<TypesOfOperations> Items
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
        #region public TypesOfOperations()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public TypesOfOperations()
        {
        }
        #endregion

        #region public TypesOfOperations(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public TypesOfOperations(Int32 itemID, String shortName, String fullName, String commonName)
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
