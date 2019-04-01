using System;
using System.Collections.Generic;

namespace SmartCore.Entities.Dictionaries
{

    /// <summary>
    /// Варианты обработки закупочного акта
    /// </summary>
    public class PorProcessType
    {


        #region private static List<PorProcessType> _Items=new List<PorProcessType>();
        /// <summary>
        /// Коллекция свойств
        /// </summary>
        private static List<PorProcessType> _Items = new List<PorProcessType>();

        #endregion

        #region public static List<PorProcessType> PorProcessTypeList { get { return _Items; } }
        /// <summary>
        /// Возвращает список Origins
        /// </summary>
        public static List<PorProcessType> PorProcessTypeList { get { return _Items; } }

        #endregion

        /*
        * Предопределенный свойсва
        */

        #region public static PorProcessType NotProcessed=new PorProcessType(1,"Not Processed");
        /// <summary>
        /// не обработан
        /// </summary>
        public static PorProcessType NotProcessed = new PorProcessType(1, "Not Processed");

        #endregion

        #region public static PorProcessType Emailed=new PorProcessType(2,"Emailed");
        /// <summary>
        /// Отправленно по почте
        /// </summary>
        public static PorProcessType Emailed = new PorProcessType(2, "Sent by email");

        #endregion

        #region public static PorProcessType DynamicsAX=new PorProcessType(3,"DynamicsAX");
        /// <summary>
        /// Отправленно в Microsoft Dynamics AX
        /// </summary>
        public static PorProcessType DynamicsAX = new PorProcessType(3, "Processed by Microsoft Dynamics AX");

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

        #region public PorProcessType(Int32 itemId,String Name)
        /// <summary>
        /// Конструктор создает Коллекцию Origin,и принимает 2 свойства для создания объекта
        /// </summary>
        /// <param name="itemId">id</param>
        /// <param name="Name">Наименование</param>
        public PorProcessType(Int32 itemId, String name)
        {
            ItemID = itemId;
            Name = name;
            _Items.Add(this);
        }

        #endregion

        /*
         * Методы
         */

        #region public static PorProcessType GetDetailLabeById(Int32 ID)
        /// <summary>
        /// Возвращает свойсва по заданному ID
        /// </summary>
        /// <param name="ID">id свойства</param>
        /// <returns></returns>
        public static PorProcessType GetPorProcessTypeById(Int32 ID)
        {
            foreach (PorProcessType item in _Items)
            {
                if (item.ItemID == ID)
                {
                    return item;
                }
            }
            return new PorProcessType(-1,"N\\A");
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
