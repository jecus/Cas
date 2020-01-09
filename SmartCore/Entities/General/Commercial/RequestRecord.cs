using EntityCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Packages;

namespace SmartCore.Entities.General.Commercial
{
    [Table("RequestRecords", "dbo", "ItemId")]
    [Dto(typeof(RequestRecordDTO))]
	[Condition("IsDeleted", "0")]
    public class RequestRecord : BaseDirectivePackageRecord
    {
        /*
         *  Свойства
         */
        /*
		*  Методы 
		*/
		
		#region public RequestRecord()
        /// <summary>
        /// Создает запись о задаче в рабочем пакете без дополнительной информации
        /// </summary>
        public RequestRecord()
        {
            ItemId = -1;
            DirectiveId = 0;
            ParentId = 0;
            PackageItemType = SmartCoreType.RequestRecord;
        }
        /// <summary>
        /// Создает запись о задаче в рабочем пакете на основе переданных параметров
        /// </summary>
        public RequestRecord(int workPakageId, int directiveId, SmartCoreType directiveType)
        {
            DirectiveId = directiveId;
            ParentId = workPakageId;
            PackageItemType = directiveType;
        }
        #endregion

        #region public override string ToString()
        public override string ToString()
        {
            return $"Dir:id {DirectiveId} desc:{(Task != null ? Task.ToString() : "")} ";
        }
        #endregion
    }
}
