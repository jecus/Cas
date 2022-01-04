using System;
using System.Collections.Generic;
using CAA.Entity.Models.DTO;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Check
{
    [CAADto(typeof(CheckListDTO))]
    public class CheckLists : BaseEntityObject, ICheckListFilterParams
    {
        public string Source { get; set; }

        public CheckListSettings Settings { get; set; }

        public List<CheckListRecords> CheckListRecords { get; set; }

        public CheckLists()
        {
            ItemId = -1;
            CheckListRecords = new List<CheckListRecords>();
            Settings = new CheckListSettings();
            SmartCoreObjectType = SmartCoreType.CheckLists;
        }

        public string EditionNumber => Settings.EditionNumber;
        public string RevisonNumber => Settings.RevisonNumber;
        public string SectionNumber => Settings.SectionNumber;
        public string SectionName => Settings.SectionName;
        public string PartNumber => Settings.PartNumber;
        public string PartName => Settings.PartName;
        public string SubPartNumber => Settings.SubPartNumber;
        public string SubPartName => Settings.SubPartName;
        public string ItemNumber => Settings.ItemNumber;
        public string ItemtName => Settings.ItemtName;
        public string Requirement => Settings.Requirement;
    }
}
