using System;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Hangar
{

    /// <summary>
    /// Класс описывает ангар
    /// </summary>
    [Serializable]
    [Table("Hangars", "dbo", "ItemId")]
    [Dto(typeof(HangarDTO))]
	[Condition("IsDeleted", "0")]
    public class Hangar: BaseEntityObject// IComparable<Store>
    {

        /*
         * Свойства
         */

        #region public String Name { get; set; }
        
        /// <summary>
        /// Название ангара
        /// </summary>
        [TableColumn("StoreName")]
        [FormControl(300,"Name")]
        [NotNull]
        public String Name { get; set; }

        #endregion

        #region public String Location { get; set; }
        
        /// <summary>
        /// Расположение ангара
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

        #region public Hangar()
        /// <summary>
        /// Создает ангар без дополнительной информации
        /// </summary>
        public Hangar()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.Hangar;
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

        #region public int CompareTo(Hangar y)

        public int CompareTo(Hangar y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

        #endregion

    }

}

