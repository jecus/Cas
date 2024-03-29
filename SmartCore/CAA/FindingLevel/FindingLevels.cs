﻿using System;
using CAA.Entity.Models;
using CAA.Entity.Models.Dictionary;
using Entity.Abstractions;
using SmartCore.CAA.RoutineAudits;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.FindingLevel
{
    [CAADto(typeof(FindingLevelsDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class FindingLevels : BaseEntityObject, IBaseDictionary, IOperatable
    {
        [FormControl(150, "Level/Category:", 1, Order = 1)]
        [Filter("Level/Category", Order = 1)]
        [ListViewData("Level/Category",  1)]
        public string LevelName { get; set; }

        [FormControl(150, "Class:", 1, Order = 2)]
        [Filter("Class", Order = 2)]
        [ListViewData("Class", 2)]
        public LevelClass LevelClass { get; set; }

        [FormControl(150, "Color:", 1, Order = 3)]
        [Filter("Color", Order = 3)]
        [ListViewData("Color", 3)]
        public LevelColor LevelColor { get; set; }
        
        [FormControl(150, "Action:", 1, Order = 4)]
        [Filter("Action", Order = 4)]
        [ListViewData("Action", 4)]
        public ActionProgramType ActionProgramType { get; set; }
        
        [FormControl(150, "Corrective Action:", 1, Order = 5)]
        [Filter("Corrective Action", Order = 5)]
        [ListViewData("Corrective Action", 5)]
        [LifeLenghtCalendarOnly]
        public Lifelength CorrectiveAction { get; set; }

        [FormControl(150, "Final Action:", 1, Order = 6)]
        [Filter("Final Action", Order = 6)]
        [ListViewData("Final Action", 6)]
        [LifeLenghtCalendarOnly]
        public Lifelength FinalAction { get; set; }
        
        [FormControl(150, "ProgramType:", 1, Order = 7)]
        [Filter("ProgramType", Order = 7)]
        [ListViewData("ProgramType", 7)]
        public ProgramType ProgramType { get; set; }
        
        [FormControl(150, "Remark:", 1, Order = 8)]
        [Filter("Remark", Order = 8)]
        [ListViewData("Remark", 8)]
        public string Remark { get; set; }
        
        
        
        

        
        
        private static FindingLevels _unknown;
        public static FindingLevels Unknown =>
            _unknown ?? (_unknown = new FindingLevels
            {
                LevelName = "N/A",
                LevelClass = LevelClass.Major,
                Remark = "Unknown",
                ItemId = -1
            });


        public FindingLevels()
        {
            FinalAction = Lifelength.Zero;
            CorrectiveAction = Lifelength.Zero;
        }

        public override string ToString()
        {
            if (ItemId == -1)
                return LevelName;
            return $"{LevelName}/{LevelClass}";
        }

        public int OperatorId { get; set; }
    }
}
