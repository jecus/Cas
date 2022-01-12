using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.RoutineAudits
{
    public interface IRoutineAuditFilterParams
    {
        [Filter("AuditNumber:", Order = 1)]
        string AuditNumber { get; set; }

        [Filter("Type:", Order = 2)]
        string Type { get; set; }

        [Filter("Title:", Order = 3)]
        string Title { get; set; }

        [Filter("Description:", Order = 4)]
        string Description { get; set; }

        [Filter("Remark:", Order = 5)]
        string Remark { get; set; }

        [Filter("Created:", Order = 6)]
        DateTime Created { get; set; }
    }
}
