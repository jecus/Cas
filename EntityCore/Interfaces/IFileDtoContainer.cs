using System.Collections.Generic;
using EntityCore.DTO.General;

namespace EntityCore.Interfaces
{
	public interface IFileDtoContainer : IBaseEntity
	{
		ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}