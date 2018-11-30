/*
* Class code generate programm
* Date: 12.07.2010
* Database: CasDemo
* Table: AttachedFile
*/

using System;
using System.Collections.Generic;
using System.Data; // DataRow, DataTable, DataSet
using System.Data.SqlClient;
using SmartCore.DataAccesses.AttachedFiles;
// SqlParameter
using SmartCore.Entities.General;
using SmartCore.Management;


namespace SmartCore.Queries
{

    public static class AttachedFileQueries
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
        public static SqlParameter[] GetParameters(AttachedFile item)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@IsDeleted", DbTypes.DbObject(item.IsDeleted)));
            parameters.Add(new SqlParameter("@ItemID", DbTypes.DbObject(item.ItemId)));
            parameters.Add(new SqlParameter("@FileName", DbTypes.DbObject(item.FileName)));
            //parameters.Add(new SqlParameter("@FileData", DbTypes.DbObject(item.FileData)));

            object dbvalue = DbTypes.DbObject(item.FileData);
            SqlParameter parameter = new SqlParameter();
            if(dbvalue == DBNull.Value)
            {
                parameter.IsNullable = true;
                parameter.ParameterName = "@FileData";
                parameter.SqlDbType = SqlDbType.VarBinary;
                parameter.SqlValue = dbvalue;
            }
            else
            {
                parameter.IsNullable = false;
                parameter.ParameterName = "@FileData";
                parameter.Value = dbvalue;
            }
            parameters.Add(parameter);

            return parameters.ToArray();
        }

		#endregion


		#region public static SqlParameter[] GetParameters(AttachedFile item)
		/// <summary>
		/// Возвращает список параметров, которые могут использоваться в запросах
		/// </summary>
		public static SqlParameter[] GetParameters(AttachedFileDTO item)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();

			parameters.Add(new SqlParameter("@IsDeleted", DbTypes.DbObject(item.IsDeleted)));
			parameters.Add(new SqlParameter("@ItemID", DbTypes.DbObject(item.ItemId)));
			parameters.Add(new SqlParameter("@FileName", DbTypes.DbObject(item.FileName)));

			object dbvalue = DbTypes.DbObject(item.FileData);
			SqlParameter parameter = new SqlParameter();
			if (dbvalue == DBNull.Value)
			{
				parameter.IsNullable = true;
				parameter.ParameterName = "@FileData";
				parameter.SqlDbType = SqlDbType.VarBinary;
				parameter.SqlValue = dbvalue;
			}
			else
			{
				parameter.IsNullable = false;
				parameter.ParameterName = "@FileData";
				parameter.Value = dbvalue;
			}
			parameters.Add(parameter);

			return parameters.ToArray();
		}

		#endregion

		#region public static String GetDeleteQuery()
		///<summary>
		/// Возвращает строку SQL запроса добавление данных в БД 
		/// </summary>
		public static String GetDeleteQuery()
        {
            return "Set dateformat dmy; DELETE FROM [dbo].Files where ";
        }

        #endregion

        #region public static String GetDeleteQuery(int ItemID)
        ///<summary>
        /// Возвращает строку SQL запроса добавление данных в БД 
        /// </summary>
        public static String GetDeleteQuery(int itemId)
        {
            return GetDeleteQuery() + "ItemID = " + itemId;
        }

        #endregion

        #region public static String GetInsertQuery()
        ///<summary>
        /// Возвращает строку SQL запроса добавление данных в БД 
        /// </summary>
        public static String GetInsertQuery()
        {
            return "Set dateformat dmy; Insert Into [dbo].Files (IsDeleted, FileName, FileData) Values (@IsDeleted,  @FileName, Convert(VARBINARY(MAX),@FileData)) SELECT SCOPE_IDENTITY();";
        }

        #endregion

        #region public static String GetUpdateQuery()
        /// <summary>
        /// Возвращает строку SQL запроса на обновление данных в БД 
        /// </summary>
        public static String GetUpdateQuery()
        {
            return "Set dateformat dmy; Update [dbo].Files Set IsDeleted = @IsDeleted, FileName = @FileName, FileData = @FileData, FilePath = @FilePath, StoreInDatabase = @StoreInDatabase  " + String.Format("Where {0} = @{1}", ItemIdName, ItemIdName);
        }

        #endregion

        #region public static String GetSelectQuery()
        /// <summary>
        /// Возвращает строку SQL запроса на селектирование данных из БД 
        /// </summary>
        public static String GetSelectQuery()
        {
            return @"Select 
                        IsDeleted, 
                        ItemID, 
                        FileName ,
                        FileData ,
                        FileSize ,
                        StoreInDataBase,
                        FilePath
                        from [dbo].[Files]";
        }
        #endregion

        #region public static String GetSelectQueryById(int id)
        /// <summary>
        /// Возвращает строку SQL запроса на селектирование данных из БД по заданному ID
        /// </summary>
        public static String GetSelectQueryById(int id)
        {
            return string.Format(@"Select 
                        IsDeleted, 
                        ItemID, 
                        FileName,
                        FileData,
                        FileSize,
                        StoreInDataBase,
                        FilePath
                        from [dbo].[Files] where ItemID='{0}'", id);
        }
		#endregion

		#region public static String GetSelectQueryByNameandSize(AttachedFile file)

	    /// <summary>
	    /// Возвращает строку SQL запроса на селектирование данных из БД по заданному FileName и FileSize
	    /// </summary>
	    /// <param name="fileName"></param>
	    /// <param name="fileSize"></param>
	    /// <returns></returns>
	    public static String GetSelectQueryByNameAndSize(string fileName , int fileSize)
	    {
		    return string.Format(@"Select ItemID from [dbo].[Files] where FileName='{0}' and FileSize='{1}'", fileName, fileSize);
	    }

	    #endregion

	    #region public static String GetSelectQueryByIdLite(int id)
			/// <summary>
			/// Возвращает строку SQL запроса на селектирование данных из БД по заданному ID без  FileData
			/// </summary>
		public static String GetSelectQueryByIdLite(int id)
        {
            return string.Format(@"Select 
                        IsDeleted, 
                        ItemID, 
                        FileName,
                        FileSize,
                        StoreInDataBase,
                        FilePath
                        from [dbo].[Files] where ItemID='{0}'", id);
        }
        #endregion

        #region public static String GetSelectQueryByIdLite(int[] id)
        /// <summary>
        /// Возвращает строку SQL запроса на селектирование данных из БД по заданному ID без  FileData
        /// </summary>
        public static String GetSelectQueryByIdLite(int[] id)
        {
            if (id.Length == 0)
                return GetSelectQuery();

            string s = "";
            for (int i = 0; i < id.Length; i++)
            {
                if (i > 0)
                    s += ",";
                s += id[i].ToString();
            }
            return string.Format(@"Select 
                        IsDeleted, 
                        ItemID, 
                        FileName,
                        FileSize,
                        StoreInDataBase,
                        FilePath
                        from [dbo].[Files] where ItemID in ({0})", s);
        }
        #endregion

        #region public static AttachedFile Fill(DataRow row)
        /// <summary>
        /// Заполняет поля 
        /// </summary>
        /// <param name="row"></param>
        public static AttachedFile Fill(DataRow row)
        {
            if (DbTypes.ToString(row["FileName"]) == "" ||
                DbTypes.ToInt32(row["FileSize"]) <= 4) return null;
            
            AttachedFile item = new AttachedFile();
            item.IsDeleted = DbTypes.ToBool(row["IsDeleted"]);
            item.ItemId = DbTypes.ToInt32(row["ItemID"]);
            item.FileName = DbTypes.ToString(row["FileName"]);

            try  // если не грузим FileData из базы
            {
                item.FileData = DbTypes.ToBytes(row["FileData"]);
            }
            catch
            {
                item.FileData = null;
            }
            
            item.FileSize = DbTypes.ToInt32(row["FileSize"]);
            return item;

        }
        #endregion

        #region public void AttachedFile Fill(DataRow row)
        /// <summary>
        /// Заполняет поля 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="item"></param>
        public static void Fill(DataRow row, AttachedFile item)
        {
            item.IsDeleted = DbTypes.ToBool(row["IsDeleted"]);
            item.ItemId = DbTypes.ToInt32(row["ItemID"]);
            item.FileName = DbTypes.ToString(row["FileName"]);

            try  // если не грузим FileData из базы
            {
                item.FileData = DbTypes.ToBytes(row["FileData"]);
            }
            catch
            {
                item.FileData = null;
            }

            item.FileSize = DbTypes.ToInt32(row["FileSize"]);
        }
        #endregion

    }
}






