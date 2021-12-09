using System.Collections.Generic;
using ItemFileLinkDTO = Entity.Models.DTO.General.ItemFileLinkDTO;

namespace Entity.Models.DTO
{
	public interface IFileDtoContainer : Entity.Models.DTO.IBaseEntity
	{
		ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}