using System;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.WorkShop
{

    /// <summary>
    /// Класс описывает лабораторию
    /// </summary>
    [Serializable]
    [Table("WorkStations", "dbo", "ItemId")]
	[Condition("IsDeleted", "0")]
    public class WorkStation: BaseEntityObject// IComparable<Store>
    {

        /*
         * Свойства
         */

        #region public String Name { get; set; }
        
        /// <summary>
        /// Название лаборатории
        /// </summary>
        [TableColumn("StoreName")]
        [FormControl(300,"Name")]
        [NotNull]
        public String Name { get; set; }

        #endregion

        #region public String Location { get; set; }
        
        /// <summary>
        /// Расположение лаборатории
        /// </summary>
        [TableColumn("Location")]
        [FormControl(300, "Location")]
        [NotNull]
        public String Location { get; set; }

        #endregion

        #region public Int32 OperatorId { get; set; }
       
        /// <summary>
        /// Оператор, которому принадлежит склад
        /// </summary>
        [TableColumn("OperatorId")] 
        public Int32 OperatorId { get; set; }

        #endregion

        #region public String Remarks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Remarks")] 
        [FormControl(200, "Remarks",5)]
        public String Remarks { get; set; }

        #endregion

        /*
         * Дополнительные, вычисляемые поля
         */

        #region public Operator Operator { get; set; }
        /// <summary>
        /// Оператор, которому принадлежит склад
        /// </summary>
        public Operator Operator { get; set; }
        #endregion

        /*
         * Методы
         */

        #region public WorkStation()
        /// <summary>
        /// Создает лабораторию без дополнительной информации
        /// </summary>
        public WorkStation()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.WorkStation;
        }
        #endregion

        #region public override string ToString()

        /// <summary>
        /// Переопределяем для удобства отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + (Location != "" ? ", " + Location : "");
        }
        #endregion

        #region public int CompareTo(WorkShop y)

        public int CompareTo(WorkShop y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

        #endregion

    }

}

