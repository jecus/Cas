using System;
using System.Data;
using SmartCore.DataAccesses.AttachedFiles;
using SmartCore.Entities.General;
using SmartCore.Filters;
using SmartCore.Management;
using SmartCore.Queries;

namespace SmartCore.Files
{
	public interface IFilesSmartCore
	{
		int SaveAttachedFile(ItemFileLink item);
		void DeleteAttachedFile(ItemFileLink item);
		int SaveAttachedFileDTO(ItemFileLinkDTO link);
		void DeleteAttachedFileDTO(ItemFileLinkDTO link);
	}

	public class FilesSmartCore : IFilesSmartCore
	{
		private readonly IBaseEnvironment _environment;


		#region public FilesSmartCore(DatabaseManager databaseManager)
		/// <summary>
		/// Создает Ядро для работы с файлами
		/// </summary>
		public FilesSmartCore(IBaseEnvironment environment)
		{
			_environment = environment;
		}
		#endregion

		#region public int SaveAttachedFile(ItemFileLink link)

		public int SaveAttachedFile(ItemFileLink link)
		{
			if (link == null)
				throw new ArgumentNullException("ItemFileLink", "can not be null");

			var dsAfterInsertLink = new DataSet();
			var existsFileId = FindFileId(link.File);

			if (existsFileId > 0)
			{
				//Присваиваем fileId  файла, обновляем линк и возвращаем Id файла
				link.File.ItemId = existsFileId;

				dsAfterInsertLink = _environment.Execute(ItemFileLinksQueries.GetMergeQuery(), ItemFileLinksQueries.GetParameters(link));
				link.ItemId = DbTypes.ToInt32(dsAfterInsertLink.Tables[0].Rows[0][0]);

				return existsFileId;
			}
			//Запоминаем fileId старого файла
			var oldFileId = link.File.ItemId;

			var ds = _environment.Execute(AttachedFileQueries.GetInsertQuery(), AttachedFileQueries.GetParameters(link.File));
			//Запоминаем fileId нового файла
			var newFileId = DbTypes.ToInt32(ds.Tables[0].Rows[0][0]);

			link.File.ItemId = newFileId;

			dsAfterInsertLink = _environment.Execute(ItemFileLinksQueries.GetMergeQuery(), ItemFileLinksQueries.GetParameters(link));
			link.ItemId = DbTypes.ToInt32(dsAfterInsertLink.Tables[0].Rows[0][0]);

			if (oldFileId > 0)
				DeleteFileIfFileHasNoLinks(oldFileId);

			return newFileId;
		}

		#endregion

		#region public void DeleteAttachedFile(ItemFileLink link)

		public void DeleteAttachedFile(ItemFileLink link)
		{
			if (link == null)
				throw new ArgumentNullException("ItemFileLink", "can not be null");
			var oldFileId = link.File.ItemId;

			_environment.Execute(ItemFileLinksQueries.GetDeleteQuery(link.ParentId, link.ParentTypeId, link.File.ItemId));

			if (oldFileId > 0)
				DeleteFileIfFileHasNoLinks(oldFileId);
		}

		#endregion

		#region public int SaveAttachedFileDTO(ItemFileLinkDTO link)

		public int SaveAttachedFileDTO(ItemFileLinkDTO link)
		{
			if (link == null)
				throw new ArgumentNullException("ItemFileLink", "can not be null");

			var dsAfterInsertLink = new DataSet();
			var existsFileId = FindFileId(link.File);

			if (existsFileId > 0)
			{
				//Присваиваем fileId  файла, обновляем линк и возвращаем Id файла
				link.File.ItemId = existsFileId;

				dsAfterInsertLink = _environment.Execute(ItemFileLinksQueries.GetMergeQuery(), ItemFileLinksQueries.GetParameters(link));
				link.ItemId = DbTypes.ToInt32(dsAfterInsertLink.Tables[0].Rows[0][0]);

				return existsFileId;
			}
			//Запоминаем fileId старого файла
			var oldFileId = link.File.ItemId;

			var ds = _environment.Execute(AttachedFileQueries.GetInsertQuery(), AttachedFileQueries.GetParameters(link.File));
			//Запоминаем fileId нового файла
			var newFileId = DbTypes.ToInt32(ds.Tables[0].Rows[0][0]);

			link.File.ItemId = newFileId;

			dsAfterInsertLink = _environment.Execute(ItemFileLinksQueries.GetMergeQuery(), ItemFileLinksQueries.GetParameters(link));
			link.ItemId = DbTypes.ToInt32(dsAfterInsertLink.Tables[0].Rows[0][0]);

			if (oldFileId > 0)
				DeleteFileIfFileHasNoLinks(oldFileId);

			return newFileId;
		}

		#endregion

		#region public void DeleteAttachedFileDTO(ItemFileLinkDTO link)

		public void DeleteAttachedFileDTO(ItemFileLinkDTO link)
		{
			if (link == null)
				throw new ArgumentNullException("ItemFileLink", "can not be null");
			var oldFileId = link.File.ItemId;

			_environment.Execute(ItemFileLinksQueries.GetDeleteQuery(link.ParentId, link.ParentTypeId, link.File.ItemId));

			if (oldFileId > 0)
				DeleteFileIfFileHasNoLinks(oldFileId);
		}

		#endregion

		#region private int FindFileId(AttachedFile file)

		/// <summary>
		/// Проверяем есть ли файл в Бд(если есть возвращаем его fileId, если нет то ноль)
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		private int FindFileId(AttachedFile file)
		{
			int fileId = 0;
			var ds = _environment.Execute(AttachedFileQueries.GetSelectQueryByNameAndSize(file.FileName, Convert.ToInt32(file.FileSize)));

			if(ds.Tables[0].Rows.Count > 0)
				fileId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

			return fileId;
		}

		#endregion

		#region private void DeleteFileIfFileHasNoLinks(int fileId)
		/// <summary>
		/// Проверяем есть ли линки на файл, если нет то удаляем файл из Бд
		/// </summary>
		/// <param name="fileId"></param>
		private void DeleteFileIfFileHasNoLinks(int fileId)
		{
			ICommonFilter idFilter = new CommonFilter<int>(ItemFileLink.FileIdProperty, fileId);

			var query = BaseQueries.GetSelectQueryColumnOnly<ItemFileLink>(BaseEntityObject.ItemIdProperty,new[] {idFilter});

			var ds = _environment.Execute(query);

			var count = ds.Tables[0].Rows.Count;

			if (count == 0)
				_environment.Execute(AttachedFileQueries.GetDeleteQuery(fileId));
		}

		#endregion

		#region private int FindFileId(AttachedFileDTO file)

		/// <summary>
		/// Проверяем есть ли файл в Бд(если есть возвращаем его fileId, если нет то ноль)
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		private int FindFileId(AttachedFileDTO file)
		{
			int fileId = 0;
			var ds = _environment.Execute(AttachedFileQueries.GetSelectQueryByNameAndSize(file.FileName, Convert.ToInt32(file.FileSize)));

			if (ds.Tables[0].Rows.Count > 0)
				fileId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

			return fileId;
		}

		#endregion

	}
}
