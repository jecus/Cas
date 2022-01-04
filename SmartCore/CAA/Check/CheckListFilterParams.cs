﻿using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Check
{
    public interface ICheckListFilterParams
    {
        [Filter("Source", Order = 1)]
        string Source { get; set; }

        [Filter("EditionNumber", Order = 2)]
        string EditionNumber { get;  }

        [Filter("RevisonNumber", Order = 5)]
        string RevisonNumber { get;  }

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

        [Filter("ItemtName", Order = 15)]
        string ItemtName { get;  }

        [Filter("Requirement", Order = 16)]
        string Requirement { get;  }
    }
}