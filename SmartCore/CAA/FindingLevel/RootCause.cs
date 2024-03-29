﻿using System;
using CAA.Entity.Models;
using CAA.Entity.Models.DTO;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.FindingLevel
{
    [CAADto(typeof(RootCauseDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class RootCause : BaseEntityObject, IOperatable
    {
        [FormControl(150, "Category №", 1, Order = 1)]
        [Filter("Category №", Order = 1)]
        [ListViewData(120,"Category №", 1)]
        public string CategoryNumber { get; set; }

        [FormControl(150, "Category Name:", 1, Order = 2)]
        [Filter("Category Name", Order = 2)]
        [ListViewData(250,"Category Name", 2)]
        public string CategoryName { get; set; }

        [FormControl(350, "Remark:", 1, Order = 3, Height = 150)]
        [Filter("Remark", Order = 3)]
        [ListViewData(150,"Remark", 3)]
        public string Remark { get; set; }


        public override string ToString()
        {
            return $"{CategoryNumber} {CategoryName}";
        }

        public int OperatorId { get; set; }
    }
}
