using System.Linq;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Files;

namespace SmartCore.Auxiliary.Extentions
{
	public static class ItemsFileLinksExtentions
	{
		public static AttachedFile GetFileByFileLinkType(this ICommonCollection<ItemFileLink> files, FileLinkType fileLinkType)
		{
			return files.FirstOrDefault(i => i.LinkType == (short)fileLinkType)?.File;
		}


		public static void SetFileByFileLinkType(this ICommonCollection<ItemFileLink> files, int typeId, AttachedFile file, FileLinkType fileLinkType)
		{
			var link = files.FirstOrDefault(i => i.LinkType == (short)fileLinkType);

			if (link != null)
				link.File = file;
			else if (file != null)
				files.Add(new ItemFileLink
				{
					ParentTypeId = typeId,
					LinkType = (short)fileLinkType,
					File = file
				});
		}
	}
}