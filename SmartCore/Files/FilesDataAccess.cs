using System.Collections.Generic;
using System.Linq;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Entities;
using SmartCore.Entities.NewLoader;
using SmartCore.Filters;

namespace SmartCore.Files
{
	public class FilesDataAccess : IFilesDataAccess
	{
		private readonly INewLoader _newLoader;

		public FilesDataAccess(INewLoader newLoader)
		{
			_newLoader = newLoader;
		}

		public IList<ItemFileLink> GetItemFileLinks(IList<int> ids, int typeId)
		{
			return _newLoader.GetObjectListAll<ItemFileLinkDTO,ItemFileLink>(new List<Filter>()
			{
				new Filter("ParentTypeId",typeId),
				new Filter("ParentId",ids)
			}, true);
		}
	}
}