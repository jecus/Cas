using System;
using System.Collections.Generic;

namespace SmartCore.Entities.Dictionaries
{
    public class TypeReference
    {

        #region private static List<TypeReference> _Items=new List<TypeReference>();
        /// <summary>
        /// Коллекция свойств
        /// </summary>
        private static List<TypeReference> _items = new List<TypeReference>();

        #endregion

        #region public static List<TypeReference> TypeReferences { get { return _Items; } }
        /// <summary>
        /// Возвращает список TypeReferences
        /// </summary>
        public static List<TypeReference> TypeReferences { get { return _items; } }

        #endregion

        /*
       * Предопределенный свойсва
       */

        #region public static TypeReference New=new TypeReference(1,"SubCheck");

        public static TypeReference SubCheck = new TypeReference(1, "SubCheck");

        #endregion

        #region public static TypeReference Used=new TypeReference(2,"JobCard");

        public static TypeReference JobCard = new TypeReference(2, "JobCard");

        #endregion

        /*
        * Свойства
        */

        #region public Int32 ItemID { get; set; }
        /// <summary>
        /// Id Свойства
        /// </summary>
        public Int32 ItemID { get; set; }

        #endregion

        #region  public String Name { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public String Name { get; set; }

        #endregion


        /*
       * Конструкторы
       */

        #region public TypeReference(Int32 itemId,String Name)
        /// <summary>
        /// Конструктор создает Коллекцию TypeReference,и принимает 2 свойства для создания объекта
        /// </summary>
        /// <param name="itemId">id</param>
        /// <param name="name">Наименование</param>
        public TypeReference(Int32 itemId, String name)
        {
            ItemID = itemId;
            Name = name;
            _items.Add(this);
        }

        #endregion

        /*
        * Методы
        */

        #region public static TypeReference GetTypeReferenceById(Int32 ID)
        /// <summary>
        /// Возвращает свойсва по заданному ID
        /// </summary>
        /// <param name="ID">id свойства</param>
        /// <returns></returns>
        public static TypeReference GetTypeReferenceById(Int32 ID)
        {
            foreach (TypeReference item in _items)
            {
                if (item.ItemID == ID)
                {
                    return item;
                }
            }
            return null;
        }

        #endregion

        #region public override string ToString()

        public override string ToString()
        {
            return Name;
        }

        #endregion


    }
}
