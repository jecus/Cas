using System;
using SmartCore.CAA.Check;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.RoutineAudits
{
    public interface IRoutineAuditFilterParams
    {
        [Filter("Program Type:", Order =1)]
        ProgramType Type { get; }

        [Filter("Object:", Order = 2)]
        RoutineObject RoutineObject { get; }

        [Filter("Description:", Order = 4)]
        string Description { get; }

        [Filter("Remark:", Order = 5)]
        string Remark { get; }
    }
}
