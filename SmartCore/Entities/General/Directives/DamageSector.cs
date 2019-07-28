using System;
using EntityCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Directives
{
    /// <summary>
    /// Описывает Сектор на карте повреждения
    /// </summary>
    [Table("DamageSectors", "dbo", "ItemId")]
    [Dto(typeof(DamageSectorDTO))]
	[Condition("IsDeleted", "0")]
    public class DamageSector : BaseEntityObject
    {

        /*
         * Свойства
         */

        #region public int DamageChartColumn { get; set; }
        /// <summary>
        /// Номер колонки в Карте повреждения
        /// </summary>
        [TableColumn("DamageChartColumn")]
        public int DamageChartColumn { get; set; }
        #endregion

        #region public int DamageChartRow { get; set; }
        /// <summary>
        /// Номер строки в карте повреждения
        /// </summary>
        [TableColumn("DamageChartRow")]
        public int DamageChartRow { get; set; }
        #endregion

        #region public String Remarks { get; set; }
        /// <summary>
        /// Заметки по сектору повреждения
        /// </summary>
        [TableColumn("Remarks", -1)]
        [FormControl(900,"Remarks:", 32, true)]
        public String Remarks { get; set; }
        #endregion

        #region public DamageDocument DamageDocument { get; set; }
        /// <summary>
        /// Файл документа повреждения
        /// </summary>
        [TableColumn("DamageDocumentId")]
        [Parent]
        public DamageDocument DamageDocument { get; set; }
        #endregion

        /*
         * Методы
         */

        #region public DamageSector()
        /// <summary>
        /// Конструктор без дополнительных параметров
        /// </summary>
        public DamageSector()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.DamageSector;
            DamageChartColumn = -1;
            DamageChartRow = -1;
            Remarks = "";
        }

        #endregion

    }
}
