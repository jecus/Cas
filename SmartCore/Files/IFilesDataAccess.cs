using System.Collections.Generic;

namespace SmartCore.Files
{
	public interface IFilesDataAccess
	{
		IList<ItemFileLink> GetItemFileLinks(IList<int> ids, int typeId);
	}
}