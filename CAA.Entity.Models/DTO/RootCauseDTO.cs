﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;

namespace CAA.Entity.Models.DTO
{
    [Table("RootCauses", Schema = "dbo")]
    public class RootCauseDTO : BaseEntity
    {
        [Column("CategoryNumber"), MaxLength(250)]
        public string CategoryNumber { get; set; }
        [Column("CategoryName"), MaxLength(250)]
        public string CategoryName { get; set; }
        [Column("Remark")]
        public string Remark { get; set; }
    }
}
