using SmartCore.DataAccesses.AttachedFiles;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.DataAccesses
{
	public interface IFileDTOContainer : IBaseEntityObject
	{
		 CommonCollection<ItemFileLinkDTO> Files { get; set; }
	}
}