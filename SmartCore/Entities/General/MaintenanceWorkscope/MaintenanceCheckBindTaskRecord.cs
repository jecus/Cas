using System;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Entities.General.MaintenanceWorkscope
{
    [Table("MaintenanceChecksBindTaskRecords", "dbo", "ItemId")]
    [Dto(typeof(MaintenanceCheckBindTaskRecordDTO))]
	[Condition("IsDeleted", "0")]
    public class MaintenanceCheckBindTaskRecord : BaseEntityObject
    {
        private static Type _thisType;
        /*
         *  Свойства
         */

        #region public Int32 CheckId { get; set; }
        /// <summary>
		/// ID чека
		/// </summary>
        [TableColumnAttribute("CheckId")]
        public Int32 CheckId { get; set; }
        /// <summary>
        /// Отраженное своиство CheckId
        /// </summary>
        public static PropertyInfo CheckIdProperty
        {
            get { return GetCurrentType().GetProperty("CheckId"); }
        }
		#endregion

        #region public Int32 CheckPerformaceNum { get; set; }
        /// <summary>
        /// Порядковый номер выполнения чека
        /// </summary>
        [TableColumnAttribute("CheckPerformaceNum")]
        public Int32 CheckPerformaceNum { get; set; }
        #endregion

        #region public Int32 CheckPerformaceGroupNum { get; set; }
        /// <summary>
        /// Порядковый номер группы выполнения чека
        /// </summary>
        [TableColumnAttribute("CheckPerformaceGroupNum")]
        public Int32 CheckPerformaceGroupNum { get; set; }
        #endregion

        #region public SmartCoreType TaskType { get; set; }
        /// <summary>
        /// ID задачи, с которой производится связь
        /// </summary>
        [TableColumnAttribute("TaskId")]
        public Int32 TaskId { get; set; }
        #endregion

        #region public SmartCoreType TaskType { get; set; }
        /// <summary>
        /// Тип задачи, с которой производится связь
		/// </summary>
        [TableColumnAttribute("TaskTypeId")]
        public SmartCoreType TaskType { get; set; }
		#endregion

        #region  public Int32 TaskPerformanceNumFromStart { get; set; }
        /// <summary>
        /// Порядковый номер выполнения связной задачи от начала выполнения задачи
        /// </summary>
        [TableColumnAttribute("TaskPerfNumFromStart")]
        public Int32 TaskPerformanceNumFromStart { get; set; }
        #endregion

        #region public Int32 TaskPerformanceNumFromRecord { get; set; }
        /// <summary>
        /// Порядковый номер выполнения связной задачи от какого-то выполнения связной задачи 
        /// </summary>
        [TableColumnAttribute("TaskPerfNumFromRecord")]
        public Int32 TaskPerformanceNumFromRecord { get; set; }
        #endregion

        #region public Int32 TaskFromRecordId { get; set; }
        /// <summary>
        /// Идентификатор записи, от которой отчитываются выполнения TaskPerformanceNumFromRecord
        /// </summary>
        [TableColumnAttribute("TaskFromRecordId")]
        public Int32 TaskFromRecordId { get; set; }
        #endregion

        #region public Int32 WorkPackageId { get; set; }
        /// <summary>
        /// Идентификатор Рабочего пакета, в котором осуществилась привязка
        /// </summary>
        [TableColumnAttribute("WorkPackageId")]
        public Int32 WorkPackageId { get; set; }
        /// <summary>
        /// Отраженное своиство WorkPackageId
        /// </summary>
        public static PropertyInfo WorkPackageIdProperty
        {
            get { return GetCurrentType().GetProperty("WorkPackageId"); }
        }
        #endregion

        #region public MaintenanceCheck ParentCheck { get; set; }
        /// <summary>
        /// Родительский чек
        /// </summary>
        public MaintenanceCheck ParentCheck { get; set; }
        #endregion

        #region public IDirective Task { get; set; }
        /// <summary>
        /// Задача, привязанная к чеку
        /// </summary>
        public IDirective Task { get; set; }
        #endregion

        /*
		*  Методы 
		*/
		
		#region public MaintenanceCheckBindTaskRecord()
        /// <summary>
        /// Создает запись о привязке задачи к выполнению чека программы обслуживания без дополнительной информации
        /// </summary>
        public MaintenanceCheckBindTaskRecord()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.MaintenanceCheckBindTaskRecord;
        }

        #endregion

        #region public override string ToString()
        public override string ToString()
        {
            return string.Format("Check:id {0} desc:{1} ",CheckId, Task != null ? Task.ToString() : "");
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(MaintenanceCheckBindTaskRecord));
        }
        #endregion
    }
}
