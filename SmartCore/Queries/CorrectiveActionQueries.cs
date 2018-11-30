/*
* Class code generate programm
* Date: 12.07.2010
* Database: CasDemo
* Table: CorrectiveAction
*/

using System;
using System.Collections.Generic;
using System.Data; // DataRow, DataTable, DataSet
using System.Data.SqlClient; // SqlParameter
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Management;


namespace SmartCore.Queries
{

	public static class CorrectiveActionQueries
	{

		#region private static String ItemIdName = "ItemID";
		/// <summary>
		/// Ключевое поле
		/// </summary>
		private static String ItemIdName = "ItemID"; 
 		#endregion

		#region public static SqlParameter[] GetParameters(CorrectiveAction item)
		/// <summary>
		/// Возвращает список параметров, которые могут использоваться в запросах
		/// </summary>
		public static SqlParameter[] GetParameters(CorrectiveAction item)
		{
				List<SqlParameter> parameters = new List<SqlParameter>();

				parameters.Add(new SqlParameter("@ItemID", DbTypes.DbObject(item.ItemId)));
				parameters.Add(new SqlParameter("@IsDeleted", DbTypes.DbObject(item.IsDeleted)));
				parameters.Add(new SqlParameter("@DiscrepancyID", DbTypes.DbObject(item.DiscrepancyId)));
				parameters.Add(new SqlParameter("@Description", DbTypes.DbObject(item.Description)));
				parameters.Add(new SqlParameter("@ShortDescription", DbTypes.DbObject(item.ShortDescription)));
				parameters.Add(new SqlParameter("@ADDNo", DbTypes.DbObject(item.AddNo)));
				parameters.Add(new SqlParameter("@IsClosed", DbTypes.DbObject(item.IsClosed)));
				parameters.Add(new SqlParameter("@PartNumberOff", DbTypes.DbObject(item.PartNumberOff)));
				parameters.Add(new SqlParameter("@SerialNumberOff", DbTypes.DbObject(item.SerialNumberOff)));
				parameters.Add(new SqlParameter("@PartNumberOn", DbTypes.DbObject(item.PartNumberOn)));
				parameters.Add(new SqlParameter("@SerialNumberOn", DbTypes.DbObject(item.SerialNumberOn)));
				parameters.Add(new SqlParameter("@CRSID", DbTypes.DbObject(item.CRSID)));


			return parameters.ToArray();
		}
		
		#endregion

		#region public static String GetInsertQuery()
		///<summary>
		/// Возвращает строку SQL запроса добавление данных в БД 
		/// </summary>
		public static String GetInsertQuery() 
		{
		    return "Set dateformat dmy; Insert Into [dbo].CorrectiveActions (IsDeleted, DiscrepancyID, Description, ShortDescription, ADDNo, IsClosed, PartNumberOff, SerialNumberOff, PartNumberOn, SerialNumberOn, CRSID) Values (@IsDeleted, @DiscrepancyID, @Description, @ShortDescription, @ADDNo, @IsClosed, @PartNumberOff, @SerialNumberOff, @PartNumberOn, @SerialNumberOn, @CRSID); SELECT SCOPE_IDENTITY();";
		}
		
		#endregion

		#region public static String GetUpdateQuery()
		/// <summary>
		/// Возвращает строку SQL запроса на обновление данных в БД 
		/// </summary>
		public static String GetUpdateQuery() 
		{
 				return " Set dateformat dmy; Update [dbo].CorrectiveActions Set IsDeleted = @IsDeleted, DiscrepancyID = @DiscrepancyID, Description = @Description, ShortDescription = @ShortDescription, ADDNo = @ADDNo, IsClosed = @IsClosed, PartNumberOff = @PartNumberOff, SerialNumberOff = @SerialNumberOff, PartNumberOn = @PartNumberOn, SerialNumberOn = @SerialNumberOn, CRSID = @CRSID  "+ String.Format("Where {0} = @{1}", ItemIdName, ItemIdName); 
		}
		
		#endregion

		#region public static String GetSelectQuery()
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД 
		/// </summary>
		public static String GetSelectQuery() 
		{
 				return  "Select ItemID as CorrectiveActionItemID, IsDeleted as CorrectiveActionIsDeleted, DiscrepancyID as CorrectiveActionDiscrepancyID, Description as CorrectiveActionDescription, ShortDescription as CorrectiveActionShortDescription, ADDNo as CorrectiveActionADDNo, IsClosed as CorrectiveActionIsClosed, PartNumberOff as CorrectiveActionPartNumberOff, SerialNumberOff as CorrectiveActionSerialNumberOff, PartNumberOn as CorrectiveActionPartNumberOn, SerialNumberOn as CorrectiveActionSerialNumberOn, CRSID as CorrectiveActionCRSID from [dbo].[CorrectiveActions]";
		}
		#endregion

        #region public static String GetSelectQuery()
        /// <summary>
        /// Выборка  CorrectiveAction из БД по идентификатору Discrepancy 
        /// </summary>
        public static String GetSelectQuery(Int32 discrepancyId)
        {
            return GetSelectQuery() + " where DiscrepancyID = " + discrepancyId;
        }
		#endregion

        #region public static void Fill(DataRow row, CorrectiveAction item)
        /// <summary>
        /// Заполняет поля 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="item"></param>
        public static void Fill(DataRow row, CorrectiveAction item)
        {
			item.ItemId = DbTypes.ToInt32(row["CorrectiveActionItemID"]);
			item.IsDeleted = DbTypes.ToBool(row["CorrectiveActionIsDeleted"]);
			item.DiscrepancyId = DbTypes.ToInt32(row["CorrectiveActionDiscrepancyID"]);
			item.Description = DbTypes.ToString(row["CorrectiveActionDescription"]);
			item.ShortDescription = DbTypes.ToString(row["CorrectiveActionShortDescription"]);
			item.AddNo = DbTypes.ToString(row["CorrectiveActionADDNo"]);
			item.IsClosed = DbTypes.ToBool(row["CorrectiveActionIsClosed"]);
			item.PartNumberOff = DbTypes.ToString(row["CorrectiveActionPartNumberOff"]);
			item.SerialNumberOff = DbTypes.ToString(row["CorrectiveActionSerialNumberOff"]);
			item.PartNumberOn = DbTypes.ToString(row["CorrectiveActionPartNumberOn"]);
			item.SerialNumberOn = DbTypes.ToString(row["CorrectiveActionSerialNumberOn"]);
			item.CRSID = DbTypes.ToInt32(row["CorrectiveActionCRSID"]);

        }
        #endregion

        #region public static CorrectiveActionCollection GetCorrectiveActionList(DataTable table)
        /// <summary>
        /// Получает список воздушных судов из запроса
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static CorrectiveActionCollection GetCorrectiveActionCollection(DataTable table)
        {
            CorrectiveActionCollection items = new CorrectiveActionCollection();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                CorrectiveAction item = new CorrectiveAction();
                Fill(table.Rows[i], item);
                items.Add(item);
            }
            
            return items;
        }
        #endregion
	} 


}
  
  
  
  
  
  
