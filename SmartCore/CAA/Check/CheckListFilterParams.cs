using SmartCore.CAA.FindingLevel;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Check
{
    public interface ICheckListFilterParams
    {
        [Filter("Source", Order = 1)]
        string Source { get; set; }

        [Filter("EditionNumber", Order = 2)]
        int EditionNumber { get;  }

        [Filter("RevisionNumber", Order = 5)]
        string RevisionNumber { get;  }

        [Filter("SectionNumber", Order = 8)]
        string SectionNumber { get;  }

        [Filter("SectionName", Order = 9)]
        string SectionName { get;  }

        [Filter("PartNumber", Order = 10)]
        string PartNumber { get;  }

        [Filter("PartName", Order = 11)]
        string PartName { get;  }

        [Filter("SubPartNumber", Order = 12)]
        string SubPartNumber { get;  }

        [Filter("SubPartName", Order = 13)]
        string SubPartName { get;  }

        [Filter("ItemNumber", Order = 14)]
        string ItemNumber { get;  }

        [Filter("ItemName", Order = 15)]
        string ItemName { get;  }

        [Filter("Requirement", Order = 16)]
        string Requirement { get;  }

        [Filter("Level", Order = 17)]
        FindingLevels Level { get; set; }
    }
}
