using EFCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Packages;

namespace SmartCore.Entities.General.Commercial
{
    [Table("WorkOrderRecords", "dbo", "ItemId")]
    [Dto(typeof(WorkOrderRecordDTO))]
	[Condition("IsDeleted", "0")]
    public class WorkOrderRecord : BaseDirectivePackageRecord
    {
        /*
         *  Свойства
         */
        /*
		*  Методы 
		*/
		
		#region public WorkOrderRecord()
        /// <summary>
        /// Создает запись о задаче в рабочем пакете без дополнительной информации
        /// </summary>
        public WorkOrderRecord()
        {
            ItemId = -1;
            DirectiveId = 0;
            ParentId = 0;
            PackageItemType = SmartCoreType.WorkOrderRecord;
        }
        /// <summary>
        /// Создает запись о задаче в рабочем пакете на основе переданных параметров
        /// </summary>
        public WorkOrderRecord(int workPakageId, int directiveId, SmartCoreType directiveType)
        {
            DirectiveId = directiveId;
            ParentId = workPakageId;
            PackageItemType = directiveType;
        }
        #endregion

        #region public override string ToString()
        public override string ToString()
        {
            return string.Format("Dir:id {0} desc:{1} ",DirectiveId, Task != null ? Task.ToString() : "");
        }
        #endregion
    }
}
