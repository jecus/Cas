using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Files;

namespace SmartCore.Entities
{
	public interface IFileContainer : IBaseEntityObject
	{
		 CommonCollection<ItemFileLink> Files { get; set; }
	}
}