/*
* Class code generate programm
* Date: 12.07.2010
* Database: CasDemo
* Table: UsersPermission
*/

using System;
using System.Collections.Generic;
using System.Data; // DataRow, DataTable, DataSet
using System.Data.SqlClient; // SqlParameter
using SmartCore.Entities.General;
using SmartCore.Management;


namespace SmartCore.Queries
{

	public class UsersPermissionQueries
	{

		#region private static String ItemIdName = "TemplatesID";
		/// <summary>
		/// Ключевое поле
		/// </summary>
		private static String ItemIdName = "TemplatesID"; 
 		#endregion

		#region public static SqlParameter[] GetParameters(UsersPermission item)
		/// <summary>
		/// Возвращает список параметров, которые могут использоваться в запросах
		/// </summary>
		public static SqlParameter[] GetParameters(UsersPermission item)
		{
				List<SqlParameter> parameters = new List<SqlParameter>();

				parameters.Add(new SqlParameter("@PermissionId", DbTypes.DbObject(item.PermissionId)));
				parameters.Add(new SqlParameter("@UserId", DbTypes.DbObject(item.UserId)));
				parameters.Add(new SqlParameter("@OperatorId", DbTypes.DbObject(item.OperatorId)));


			return parameters.ToArray();
		}
		
		#endregion

		#region public static String GetInsertQuery()
		///<summary>
		/// Возвращает строку SQL запроса добавление данных в БД 
		/// </summary>
		public static String GetInsertQuery() 
		{
				return "Set dateformat dmy; Insert Into [dbo].UsersPermissions (PermissionId, UserId, OperatorId) Values (@PermissionId, @UserId, @OperatorId)";
		}
		
		#endregion

		#region public static String GetUpdateQuery()
		/// <summary>
		/// Возвращает строку SQL запроса на обновление данных в БД 
		/// </summary>
		public static String GetUpdateQuery() 
		{
 				return "Set dateformat dmy; Update [dbo].UsersPermissions Set PermissionId = @PermissionId, UserId = @UserId, OperatorId = @OperatorId  "+ String.Format("Where {0} = @{1}", ItemIdName, ItemIdName); 
		}
		
		#endregion

		#region public static String GetSelectQuery()
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД 
		/// </summary>
		public static String GetSelectQuery() 
		{
 				return  "Select PermissionId as UsersPermissionPermissionId, UserId as UsersPermissionUserId, OperatorId as UsersPermissionOperatorId from [dbo].[UsersPermissions]";
		}
		#endregion

        #region public static void Fill(DataRow row, CorrectiveAction item)
        /// <summary>
        /// Заполняет поля 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="item"></param>
        public static void Fill(DataRow row, UsersPermission item)
        {
			item.PermissionId = DbTypes.ToInt32(row["UsersPermissionPermissionId"]);
			item.UserId = DbTypes.ToInt32(row["UsersPermissionUserId"]);
			item.OperatorId = DbTypes.ToInt32(row["UsersPermissionOperatorId"]);

        }
        #endregion

        #region public static List<UsersPermission> GetUsersPermissionList(DataTable table)
        /// <summary>
        /// Получает список воздушных судов из запроса
        /// </summary>
        /// <param name="table"></param>
		/// <returns></returns>
        public static List<UsersPermission> GetUsersPermissionList(DataTable table)
        {
            List<UsersPermission> items = new List<UsersPermission>();
             for (int i=0; i < table.Rows.Count;i++)
            {
				UsersPermission item = new UsersPermission();
                Fill(table.Rows[i], item);
                items.Add(item);
            }
            //
            return items;
        }
        #endregion
 
 
 
	} 


}
  
  
  
  
  
  
