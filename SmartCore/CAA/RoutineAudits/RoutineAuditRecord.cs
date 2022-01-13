using System;
using CAA.Entity.Models.DTO;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.RoutineAudits
{
    [CAADto(typeof(RoutineAuditRecordDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class RoutineAuditRecord : BaseEntityObject
    {
        public int RoutineAuditId { get; set; }

        public int CheckListId { get; set; }

        public RoutineAuditRecord()
        {
            SmartCoreObjectType = SmartCoreType.RoutineAudit;
            ItemId = -1;
        }
    }
}
