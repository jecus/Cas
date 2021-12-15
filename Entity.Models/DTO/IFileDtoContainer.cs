using System.Collections.Generic;
using CAS.Entity.Models.DTO.General;
using Entity.Abstractions;

namespace CAS.Entity.Models.DTO
{
	public interface IFileDtoContainer : IBaseEntity
	{
		ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}