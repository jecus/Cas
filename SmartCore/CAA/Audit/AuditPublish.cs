﻿using SmartCore.Entities.General;

namespace SmartCore.CAA.Audit
{
    public class AuditPublish : BaseEntityObject
    {
        public int WorkFlowStageId { get; set; }
        public int AllTask { get; set; }
        public int MyTask { get; set; }
    }
}