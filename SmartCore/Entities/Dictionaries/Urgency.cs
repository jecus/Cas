using System;
using System.Collections.Generic;

namespace SmartCore.Entities.Dictionaries
{
    public  class Urgency
    {
        #region  private  static List<Urgency> _Items=new List<Urgency>();

        private static List<Urgency> _Items = new List<Urgency>();

        #endregion

        #region public static List<Urgency> Urgencys { get { return _Items; } }

        public static List<Urgency> Urgencys { get { return _Items; } }

        #endregion


        /*
         * Предопределенные свойства
         */

        #region public static Urgency Urgent = new Urgency(1, "Urgent");

        public static Urgency Urgent = new Urgency(1, "Urgent");

        #endregion

        #region public static Urgency NotUrgent = new Urgency(2, "NotUrgent");

        public static Urgency NotUrgent = new Urgency(2, "NotUrgent");

        #endregion

        /*
         * Свойства
         */

        #region   public Int32 ItemId{ get; set;}
        /// <summary>
        /// ID Свойства
        /// </summary>
        public Int32 ItemId{ get; set;}

        #endregion
       
        #region public String Name { get; set; }
        /// <summary>
        /// Наименование свойства
        /// </summary>
        public String Name { get; set; }

        #endregion

 
        /*
        * Конструкторы
        */
      
        #region public Urgency(Int32 ItemId,String Name)
            /// <summary>
            /// Принимает 2 параметра ID Свойства и Наименование .Создает лист объектов.
            /// </summary>
            /// <param name="ItemId"></param>
            /// <param name="Name"></param>
          public Urgency(Int32 ItemID,String NameP)
            {
                ItemId = ItemID;
                Name = NameP;
                _Items.Add(this);
            }

            #endregion

        /*
         * Методы
         */

        #region public override string ToString()

          public override string ToString()
        {
            return Name;
        }

        #endregion

        #region public static Urgency GetUrgencybyId(Int32 id)
        /// <summary>
        /// Возвращает свойства по заданному ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Urgency GetUrgencybyId(Int32 id)
        {
            foreach (Urgency item in _Items)
            {
                if (item.ItemId==id)
                {
                    return item;
                }
            }
            return null;
        }

        #endregion



    }
}
