using System;
using System.Collections.Generic;

namespace SmartCore.Entities.Dictionaries
{
   public  class Origin
   {

       #region private static List<Origin> _Items=new List<Origin>();
       /// <summary>
       /// Коллекция свойств
       /// </summary>
       private static List<Origin> _Items = new List<Origin>();

       #endregion

       #region public static List<Origin> Origins { get { return _Items; } }
       /// <summary>
       /// Возвращает список Origins
       /// </summary>
       public static List<Origin> Origins { get { return _Items; } }

       #endregion

       /*
       * Предопределенный свойсва
       */
       
       #region public static Origin New=new Origin(1,"New");

       public static Origin New=new Origin(1,"New");

       #endregion

       #region public static Origin Used=new Origin(2,"Used");

       public static Origin Used=new Origin(2,"Used");

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
       
       #region public Origin(Int32 itemId,String Name)
       /// <summary>
       /// Конструктор создает Коллекцию Origin,и принимает 2 свойства для создания объекта
       /// </summary>
       /// <param name="itemId">id</param>
       /// <param name="name">Наименование</param>
       public Origin(Int32 itemId,String name)
       {
           ItemID = itemId;
           Name = name;
           _Items.Add(this);
       }

       #endregion

       /*
        * Методы
        */

       #region public static Origin GetOriginById(Int32 ID)
       /// <summary>
       /// Возвращает свойсва по заданному ID
       /// </summary>
       /// <param name="ID">id свойства</param>
       /// <returns></returns>
       public static Origin GetOriginById(Int32 ID)
       {
           foreach (Origin item in _Items)
           {
               if (item.ItemID==ID)
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
