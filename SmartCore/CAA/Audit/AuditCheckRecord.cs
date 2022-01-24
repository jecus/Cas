using System;
using CAA.Entity.Models.DTO;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Audit
{
    [CAADto(typeof(AuditCheckRecordDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class AuditCheckRecord : BaseEntityObject
    {
        public int CheckListRecordId { get; set; }

        public bool IsChecked { get; set; }
        public AuditCheckRecord()
        {
            SmartCoreObjectType = SmartCoreType.AuditCheckRecord;
            ItemId = -1;

        }
    }
}
