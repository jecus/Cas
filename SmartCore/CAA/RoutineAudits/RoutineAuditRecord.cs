﻿using System;
using CAA.Entity.Models.DTO;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.RoutineAudits
{
    [CAADto(typeof(CAAAuditRecordDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class CAAAuditRecord : BaseEntityObject
    {
        public int RoutineAuditId { get; set; }

        public int AuditId { get; set; }

        public CAAAuditRecord()
        {
            SmartCoreObjectType = SmartCoreType.CAAAuditRecord;
            ItemId = -1;
        }
    }
}
