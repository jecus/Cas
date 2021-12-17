﻿using System.Collections.Generic;
using CAS.Entity.Models.DTO.General;
using Entity.Abstractions.Filters;
using SmartCore.Entities.NewLoader;

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