using System;
using System.Collections.Generic;
using CAA.Entity.Models.DTO;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Files;

namespace SmartCore.CAA.Check
{
    [CAADto(typeof(CheckListDTO))]
    [Serializable]
    public class CheckLists : BaseEntityObject, ICheckListFilterParams, IFileContainer
    {
        public string Source { get; set; }

        public CheckListSettings Settings { get; set; }

        public List<CheckListRecords> CheckListRecords { get; set; }

        private CommonCollection<ItemFileLink> _files;
        public CommonCollection<ItemFileLink> Files
        {
            get { return _files ?? (_files = new CommonCollection<ItemFileLink>()); }
            set
            {
                if (_files != value)
                {
                    if (_files != null)
                        _files.Clear();
                    if (value != null)
                        _files = value;
                }
            }
        }


        #region public AttachedFile FaaFormFile { get; set; }
        [NonSerialized]
        private AttachedFile _file;
        public AttachedFile File
        {
            get
            {
                return _file ?? (Files?.GetFileByFileLinkType(FileLinkType.CheckList));
            }
            set
            {
                _file = value;
                Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.CheckList);
            }
        }

        #endregion


        public Lifelength Remains { get; set; }
        public ConditionState Condition { get; set; }

        public CheckLists()
        {
            ItemId = -1;
            CheckListRecords = new List<CheckListRecords>();
            Settings = new CheckListSettings();
            SmartCoreObjectType = SmartCoreType.CheckLists;
        }

        public override BaseEntityObject GetCopyUnsaved(bool marked = true)
        {
            var clone = (CheckLists)MemberwiseClone();
            clone.ItemId = -1;
            clone.UnSetEvents();

            if (marked)
                clone.Source += " Copy";

            clone.Files?.Clear();
            clone.CheckListRecords?.Clear();

            return clone;
        }

        public string EditionNumber => Settings.EditionNumber;
        public string RevisionNumber => Settings.RevisionNumber;
        public string SectionNumber => Settings.SectionNumber;
        public string SectionName => Settings.SectionName;
        public string PartNumber => Settings.PartNumber;
        public string PartName => Settings.PartName;
        public string SubPartNumber => Settings.SubPartNumber;
        public string SubPartName => Settings.SubPartName;
        public string ItemNumber => Settings.ItemNumber;
        public string ItemName => Settings.ItemtName;
        public string Requirement => Settings.Requirement;
        
    }
}
