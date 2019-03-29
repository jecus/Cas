using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using SmartCore.DataAccesses.AttachedFiles;
using SmartCore.Entities.General;
using SmartCore.Files;
using SmartCore.Management;

namespace SmartCore.Queries
{
	public static class ItemFileLinksQueries
	{
		#region private static String ItemIdName = "ItemID";
		/// <summary>
		/// Ключевое поле
		/// </summary>
		private static String ItemIdName = "ItemID";
		#endregion

		#region public static SqlParameter[] GetParameters(AttachedFile item)
		/// <summary>
		/// Возвращает список параметров, которые могут использоваться в запросах
		/// </summary>
		public static SqlParameter[] GetParameters(ItemFileLink item)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();

			parameters.Add(new SqlParameter("@IsDeleted", DbTypes.DbObject(item.IsDeleted)));
			parameters.Add(new SqlParameter("@ItemID", DbTypes.DbObject(item.ItemId)));
			parameters.Add(new SqlParameter("@ParentId", DbTypes.DbObject(item.ParentId)));
			parameters.Add(new SqlParameter("@ParentTypeId", DbTypes.DbObject(item.ParentTypeId)));
			parameters.Add(new SqlParameter("@LinkType", DbTypes.DbObject(item.LinkType)));
			parameters.Add(new SqlParameter("@FileId", DbTypes.DbObject(item.File.ItemId)));

			return parameters.ToArray();
		}

		#endregion


		#region public static SqlParameter[] GetParameters(AttachedFile item)
		/// <summary>
		/// Возвращает список параметров, которые могут использоваться в запросах
		/// </summary>
		public static SqlParameter[] GetParameters(ItemFileLinkDTO item)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();

			parameters.Add(new SqlParameter("@IsDeleted", DbTypes.DbObject(item.IsDeleted)));
			parameters.Add(new SqlParameter("@ItemID", DbTypes.DbObject(item.ItemId)));
			parameters.Add(new SqlParameter("@ParentId", DbTypes.DbObject(item.ParentId)));
			parameters.Add(new SqlParameter("@ParentTypeId", DbTypes.DbObject(item.ParentTypeId)));
			parameters.Add(new SqlParameter("@LinkType", DbTypes.DbObject(item.LinkType)));
			parameters.Add(new SqlParameter("@FileId", DbTypes.DbObject(item.File.ItemId)));

			return parameters.ToArray();
		}

		#endregion


		#region public static String GetDeleteQuery()
		///<summary>
		/// Возвращает строку SQL запроса добавление данных в БД 
		/// </summary>
		public static String GetDeleteQuery()
        {
            return "Set dateformat dmy; DELETE FROM [dbo].ItemsFilesLinks where ";
        }

		#endregion

		#region public static String GetDeleteQuery(int parentId, int parentTypeId, int fileId)
		///<summary>
		/// Возвращает строку SQL запроса добавление данных в БД 
		/// </summary>
		public static String GetDeleteQuery(int parentId, int parentTypeId, int fileId)
		{
			return GetDeleteQuery() + $"ParentId = {parentId} and ParentTypeId = {parentTypeId} and FileId = {fileId}";
		}

		#endregion

		#region public static String GetMergeQuery()
		///<summary>
		/// Возвращает строку SQL запроса добавление данных в БД 
		/// </summary>
		public static String GetMergeQuery()
		{
			return @"MERGE [dbo].[ItemsFilesLinks] as T
							using (select @IsDeleted as IsDeleted, @ParentId as ParentId, @ParentTypeId as ParentTypeId, @LinkType as LinkType, @FileId as FileId) as S
							on S.ParentId = T.ParentId and S.ParentTypeId = T.ParentTypeId and S.LinkType = T.LinkType
							WHEN NOT MATCHED BY TARGET
							THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (@IsDeleted, @ParentId, @ParentTypeId, @LinkType, @FileId)
							WHEN MATCHED 
							THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId
							OUTPUT inserted.ItemId;";
		}

		#endregion

		#region public static String GetSelectQuery()
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД 
		/// </summary>
		public static String GetSelectQuery()
		{
			return @"Select IsDeleted, ItemID, ParentId, ParentTypeId, LinkType, FileId from [dbo].[ItemsFilesLinks]";
		}
		#endregion

		#region public static String GetSelectQueryById(int id)
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД по заданному ID
		/// </summary>
		public static String GetSelectQueryById(int id)
		{
			return GetSelectQuery() +  string.Format(" where ItemID='{0}'", id);
		}
		#endregion

		public static String GetSelectQuery(int[] ids)
		{
			return string.Format("{0} where ItemId In ({1})",GetSelectQuery(), string.Join(", ", ids.Select(id => id.ToString(CultureInfo.InvariantCulture)).ToArray()));
		}

		#region public static AttachedFile Fill(DataRow row)
		/// <summary>
		/// Заполняет поля 
		/// </summary>
		/// <param name="row"></param>
		public static ItemFileLink Fill(DataRow row)
		{
			ItemFileLink item = new ItemFileLink();

			item.IsDeleted = DbTypes.ToBool(row["IsDeleted"]);
			item.ItemId = DbTypes.ToInt32(row["ItemID"]);
			item.ParentId = DbTypes.ToInt32(row["ParentId"]);
			item.ParentTypeId = DbTypes.ToInt32(row["ParentTypeId"]);
			item.LinkType = DbTypes.ToInt16(row["LinkType"]);
			//TODO:(Evgenii Babak) Инициализируем экземпляр AttachedFile чтобы было куда записать ItemId. Требуется разделение BL и DA
			item.File = new AttachedFile();
			item.File.ItemId = DbTypes.ToInt32(row["FileId"]);

			return item;
		}
		#endregion

		#region public void AttachedFile Fill(DataRow row)
		/// <summary>
		/// Заполняет поля 
		/// </summary>
		/// <param name="row"></param>
		/// <param name="item"></param>
		public static void Fill(DataRow row, ItemFileLink item)
		{
			item.IsDeleted = DbTypes.ToBool(row["IsDeleted"]);
			item.ItemId = DbTypes.ToInt32(row["ItemID"]);
			item.ParentId = DbTypes.ToInt32(row["ParentId"]);
			item.ParentTypeId = DbTypes.ToInt32(row["ParentTypeId"]);
			item.LinkType = DbTypes.ToInt16(row["LinkType"]);

			item.File = new AttachedFile();
			item.File.ItemId = DbTypes.ToInt32(row["FileId"]);
		}
		#endregion
	}
}
