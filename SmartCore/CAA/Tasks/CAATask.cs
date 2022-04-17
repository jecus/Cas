using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CAA.Entity.Models;
using CAA.Entity.Models.Dictionary;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Tasks
{
	[CAADto(typeof(TaskDTO))]
	[Serializable]
	[Description("Task")]
    public class CAATask : BaseEntityObject, IOperatable
    {

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
        [FormControl(250, "FullName",Order = 5, Height = 80)]
        public string FullName { get; set; }
        
        
        [ListViewData(0.4f, "Description")]
        [FormControl(250, "Description",Order = 6, Height = 80)]
        public string Description { get; set; }
		
        [ListViewData(0.2f, "Level")]
        [FormControl(250, "Level",Order = 7)]
        public TaskLevel Level { get; set; }
        
        
        public int OperatorId { get; set; }
        
    }
}