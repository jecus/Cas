using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CAA.Entity.Models;
using CAA.Entity.Models.Dictionary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Files;

namespace SmartCore.CAA.Tasks
{
	[CAADto(typeof(TaskDTO))]
	[Serializable]
	[Description("Task")]
    public class CAATask : BaseEntityObject, IOperatable, IFileContainer
    {

	    public CAATask()
	    {
		    SmartCoreObjectType = SmartCoreType.CAATask;
	    }

	    [ListViewData(0.2f, "Code")]
	    [FormControl(250, "Code", Order = 1)]
        public string Code { get; set; }
        
        [ListViewData(0.2f, "CodeName")]
        [FormControl(250, "CodeName",Order = 2)]
        public string CodeName { get; set; }
        
        [ListViewData(0.2f, "SubTaskCode")]
        [FormControl(250, "SubTaskCode",Order = 3)]
        public string SubTaskCode { get; set; }
        
        [ListViewData(0.2f, "SubTaskName")]
        [FormControl(250, "SubTaskName",Order = 4)]
        public string ShortName { get; set; }
        
        [ListViewData(0.4f, "FullName")]
        public string FullName { get; set; }
        
        
        [ListViewData(0.4f, "Description")]
        [FormControl(250, "Description",Order = 6, Height = 80)]
        public string Description { get; set; }
		
        
        [ListViewData(0.2f, "Type")]
        [FormControl(250, "Type",Order = 7)]
        public TaskType Type { get; set; }
        
        [ListViewData(0.2f, "Hour")]
        [FormControl(250, "Hour",Order = 8)]
        public string Hour { get; set; }
        
        [ListViewData(0.2f, "Level")]
        [FormControl(250, "Level",Order = 9)]
        public TaskLevel Level { get; set; }
        
        [ListViewData(0.2f, "Repeat")]
        [FormControl(250, "Repeat",Order = 10)]
        [LifeLenghtCalendarOnly(false)]
        public Lifelength Repeat { get; set; }
        
        public int OperatorId { get; set; }
        
        
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
        [FormControl(250, "File",Order = 11)]
        public AttachedFile AttachedFile
        {
	        get { return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.CAATask)); }
	        set
	        {
		        _attachedFile = value;
		        Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.CAATask);
	        }
        }
        
        
        
    }
}