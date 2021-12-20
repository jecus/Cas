using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions.Attributte;

namespace Entity.Abstractions.DTO.General
{
    public interface IItemFileLinkDTO : IBaseEntity
    {
        public int? ParentId { get; set; }

        public int ParentTypeId { get; set; }

        public short LinkType { get; set; }
        public int? FileId { get; set; }
    }
}
