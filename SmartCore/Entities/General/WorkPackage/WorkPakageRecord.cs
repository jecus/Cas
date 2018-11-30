using System;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Entities.General.WorkPackage
{
    [Table("Cas3WorkPakageRecord", "dbo", "ItemId")]
    [Dto(typeof(WorkPackageRecordDTO))]
	[Condition("IsDeleted", "0")]
	//TODO:(Evgenii Babak) создать свойство ParentId которое будет содержать то же значение что и ParentId у WorkPackage
    public class WorkPackageRecord : BaseEntityObject
    {
        private static Type _thisType;

        /*
         *  Свойства
         */
       
		#region public Int32 WorkPakageId { get; set; }
		/// <summary>
		/// ID Рабочего пакета
		/// </summary>
        [TableColumnAttribute("WorkPakageId")]
        public Int32 WorkPakageId { get; set; }

        public static PropertyInfo WorkPakageIdProperty
        {
            get { return GetCurrentType().GetProperty("WorkPakageId"); }
        }

		#endregion

        #region public Int32 DirectiveId { get; set; }
        /// <summary>
		/// ID директивы хранящейся в пакете
		/// </summary>
        [TableColumnAttribute("DirectivesId")]
        public Int32 DirectiveId { get; set; }

        public static PropertyInfo DirectiveIdProperty
        {
            get { return GetCurrentType().GetProperty("DirectiveId"); }
        }

		#endregion

        #region public Int32 WorkPackageItemType { get; set; }
        /// <summary>
		/// Тип задачи, которой пренадлежит данная запись
		/// </summary>
        [TableColumnAttribute("WorkPackageItemType")]
        public Int32 WorkPackageItemType { get; set; }

        public static PropertyInfo WorkPackageItemTypeProperty
        {
            get { return GetCurrentType().GetProperty("WorkPackageItemType"); }
        }

		#endregion

        #region  public Int32 PerformanceNumFromStart { get; set; }
        /// <summary>
        /// Порядковый номер выполнения данной записи о задаче от начала выполнения задачи
        /// </summary>
        [TableColumnAttribute("PerfNumFromStart")]
        public Int32 PerformanceNumFromStart { get; set; }
        #endregion

        #region public Int32 PerformanceNumFromRecord { get; set; }
        /// <summary>
        /// Порядковый номер выполнения данной записи о задаче от какого-то выполнения задачи 
        /// </summary>
        [TableColumnAttribute("PerfNumFromRecord")]
        public Int32 PerformanceNumFromRecord { get; set; }
        #endregion

        #region public Int32 FromRecordId { get; set; }
        /// <summary>
        /// Идентификатор записи, от которой отчитываются выполнения PerformanceNumFromRecord
        /// </summary>
        [TableColumnAttribute("FromRecordId")]
        public Int32 FromRecordId { get; set; }
		#endregion


	    [TableColumnAttribute("GroupNumber")]
		public Int32 Group { get; set; }

	    [TableColumnAttribute("ParentCheckId")]
		public Int32 ParentCheckId { get; set; }

		#region public string JobCardNumber { get; set; }
		/// <summary>
		/// Названия карты нарадя. (Применяется только для NonRoutineJob)
		/// </summary>
		[TableColumnAttribute("JobCardNumber")]
        public string JobCardNumber { get; set; }
        #endregion

        #region public IDirective Task { get; set; }
        /// <summary>
        /// Задача, привязанная к данной записи
        /// </summary>
        public IDirective Task { get; set; }
        #endregion

        #region public WorkPackage WorkPackage { get; set; }
        /// <summary>
        /// Родительский рабочий пакет
        /// </summary>
        public WorkPackage WorkPackage { get; set; }
        #endregion
        /*
		*  Методы 
		*/
		
		#region public WorkPakageRecord()
        /// <summary>
        /// Создает запись о задаче в рабочем пакете без дополнительной информации
        /// </summary>
        public WorkPackageRecord()
        {
            ItemId = -1;
            DirectiveId = 0;
            WorkPakageId = 0;
            WorkPackageItemType = 0;
        }
        /// <summary>
        /// Создает запись о задаче в рабочем пакете на основе переданных параметров
        /// </summary>
        public WorkPackageRecord(int workPakageId,int directiveId,Int32 directiveType)
        {
            DirectiveId = directiveId;
            WorkPakageId = workPakageId;
            WorkPackageItemType = directiveType;
        }
        #endregion

        #region public override string ToString()
        public override string ToString()
        {
            return string.Format("Dir:id {0} desc:{1} ",DirectiveId, Task != null ? Task.ToString() : "");
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(WorkPackageRecord));
        }
        #endregion
    }
}
