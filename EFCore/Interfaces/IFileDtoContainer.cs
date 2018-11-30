using System.Collections.Generic;
using EFCore.DTO.General;

namespace EFCore.Interfaces
{
	public interface IFileDtoContainer : IBaseEntity
	{
		ICollection<ItemFileLinkDTO> Files { get; set; }
	}
}