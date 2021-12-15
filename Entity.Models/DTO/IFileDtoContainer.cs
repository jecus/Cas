using System.Collections.Generic;
using Entity.Abstractions;
using Entity.Models.DTO.General;


namespace Entity.Models.DTO
{
	public interface IFileDtoContainer : IBaseEntity
	{
		ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}