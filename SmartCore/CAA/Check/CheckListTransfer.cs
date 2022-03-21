using System;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Files;

namespace SmartCore.CAA.Check
{
    [CAADto(typeof(CheckListTransferDTO))]
    [Serializable]
    public class CheckListTransfer: BaseEntityObject, IFileContainer
    {
        public DateTime Created { get; set; }
        public int AuditId { get; set; }
        public int CheckListId { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string SettingsJSON
        {
            get
            {
                if (Settings == null)
                    return null;

                return JsonConvert.SerializeObject(Settings,
                    Formatting.Indented,
                    new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            }

            set => Settings = string.IsNullOrWhiteSpace(value)
                ? new CheckListTransferSettings()
                : JsonConvert.DeserializeObject<CheckListTransferSettings>(value);
        }

        public int WorkflowStageId { get; set; }
        
        public CheckListTransferSettings Settings { get; set; }

        public CheckListTransfer()
        {
            SmartCoreObjectType = SmartCoreType.CheckListTransfer;
            Settings = new CheckListTransferSettings(){WorkflowStageId = 2};
        }
        
        
        #region public AttachedFile AttachedFile { get; set; }

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
        
        
        private AttachedFile _attachedFile;

        public AttachedFile AttachedFile
        {
            get { return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.CheckListMove)); }
            set
            {
                _attachedFile = value;
                Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.CheckListMove);
            }
        }

        #endregion
    }

    [Serializable]
    public class CheckListTransferSettings
    {
        [JsonProperty]
        public string Remark { get; set; }
        
        [JsonProperty]
        public int WorkflowStageId { get; set; }

        [JsonProperty]
        public bool IsWorkFlowChanged { get; set; }
    }
}