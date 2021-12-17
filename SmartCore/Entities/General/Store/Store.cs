using System;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Entities.General.Store
{

    /// <summary>
    /// Класс описывает склад
    /// </summary>
    [Serializable]
    [Table("Stores", "dbo", "ItemId")]
    [Dto(typeof(StoreDTO))]
	[Condition("IsDeleted", "0")]
    public class Store: BaseEntityObject, IComponentContainer// IComparable<Store>
	{

        /*
         * Свойства
         */

        #region public String Name { get; set; }
        
        /// <summary>
        /// Название склада
        /// </summary>
        [TableColumn("StoreName")]
        [FormControl(300,"Name:")]
        [NotNull]
        public String Name { get; set; }

        #endregion

        #region public String Location { get; set; }
        
        /// <summary>
        /// Расположение склада
        /// </summary>
        [TableColumn("Location")]
        [FormControl(300, "Location:")]
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

        #region public String Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Code")]
        [FormControl(200, "Store Code:")]
        public String Code { get; set; }

		#endregion

		[TableColumn("Adress")]
		[FormControl(300, "Adress:",3)]
		public string Adress { get; set; }

		[TableColumn("Phone")]
		[FormControl(300, "Phone:")]
		public string Phone { get; set; }

		[TableColumn("Email")]
		[FormControl(300, "Email:")]
		public string Email { get; set; }

		[TableColumn("Contact")]
		[FormControl(300, "Contact:")]
		public string Contact { get; set; }

		#region public String Remarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Remarks")] 
        [FormControl(200, "Remarks:",5)]
        public string Remarks { get; set; }

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

        #region public Store()
        /// <summary>
        /// Создает склад без дополнительной информации
        /// </summary>
        public Store()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.Store;
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

        #region public int CompareTo(Store y)

        public int CompareTo(Store y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

        #endregion

    }

}

