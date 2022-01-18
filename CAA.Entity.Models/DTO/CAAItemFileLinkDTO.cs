using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Entity.Abstractions.DTO.General;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
	[Table("ItemsFilesLinks", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CAAItemFileLinkDTO : BaseEntity, IItemFileLinkDTO
	{
        [Column("ParentId")]
        public int? ParentId { get; set; }


        [Column("ParentTypeId")]
        public int ParentTypeId { get; set; }


        [Column("LinkType")]
        public short LinkType { get; set; }


        [Column("FileId")]
        public int? FileId { get; set; }


        [Child]
        public CAAAttachedFileDTO File { get; set; }


        [JsonIgnore]
        public CAASpecialistTrainingDTO SpecialistTraining { get; set; }
        [JsonIgnore]
        public CAASpecialistDTO SpecialistDto { get; set; }

    }
}