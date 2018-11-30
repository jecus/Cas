/*
* Class code generate programm
* Date: 12.07.2010
* Database: CasDemo
* Table: Operator
*/

using System;
using System.Collections.Generic;
using System.Data; // DataRow, DataTable, DataSet
using System.Data.SqlClient; // SqlParameter
using System.Drawing.Imaging;
using SmartCore.Entities.General;
using SmartCore.Management;


namespace SmartCore.Queries
{

	public class OperatorQueries
	{

		#region private static String ItemIdName = "TemplatesID";
		/// <summary>
		/// Ключевое поле
		/// </summary>
        private static String ItemIdName = "OperatorID"; 
 		#endregion

		#region public static SqlParameter[] GetParameters(Operator item)
		/// <summary>
		/// Возвращает список параметров, которые могут использоваться в запросах
		/// </summary>
		public static SqlParameter[] GetParameters(Operator item)
		{
				List<SqlParameter> parameters = new List<SqlParameter>();

				parameters.Add(new SqlParameter("@IsDeleted", DbTypes.DbObject(item.IsDeleted)));
				parameters.Add(new SqlParameter("@OperatorID", DbTypes.DbObject(item.ItemId)));
				parameters.Add(new SqlParameter("@Name", DbTypes.DbObject(item.Name)));
				parameters.Add(new SqlParameter("@ICAOCode", DbTypes.DbObject(item.ICAOCode)));
				parameters.Add(new SqlParameter("@Address", DbTypes.DbObject(item.Address)));
				parameters.Add(new SqlParameter("@Phone", DbTypes.DbObject(item.Phone)));
				parameters.Add(new SqlParameter("@Fax", DbTypes.DbObject(item.Fax)));
				parameters.Add(new SqlParameter("@LogoTypeWhite", DbTypes.DbObject(item.LogoTypeWhite)));
                parameters.Add(new SqlParameter("@LogotypeReportLarge", DbTypes.DbObject(item.LogotypeReportLarge)));
                parameters.Add(new SqlParameter("@LogotypeReportVeryLarge", DbTypes.DbObject(item.LogotypeReportVeryLarge)));
				parameters.Add(new SqlParameter("@Email", DbTypes.DbObject(item.Email)));
                parameters.Add(new SqlParameter("@LogoType", DbTypes.DbObject(DbTypes.ImageToBytes(item.LogoTypeImage, ImageFormat.Png))));

			return parameters.ToArray();
		}
		
		#endregion

		#region public static String GetInsertQuery()
		///<summary>
		/// Возвращает строку SQL запроса добавление данных в БД 
		/// </summary>
		public static String GetInsertQuery() 
		{
            return "Set dateformat dmy; Insert Into [dbo].Operators (IsDeleted, Name, LogoType, ICAOCode, Address, Phone, Fax, LogoTypeWhite, LogotypeReportLarge, LogotypeReportVeryLarge, Email) Values (@IsDeleted, @Name, @LogoType, @ICAOCode, @Address, @Phone, @Fax, @LogoTypeWhite, @LogotypeReportLarge, @LogotypeReportVeryLarge, @Email) SELECT SCOPE_IDENTITY();";
		}
		
		#endregion

		#region public static String GetUpdateQuery()
		/// <summary>
		/// Возвращает строку SQL запроса на обновление данных в БД 
		/// </summary>
		public static String GetUpdateQuery() 
		{
            return "Set dateformat dmy; Update [dbo].Operators Set IsDeleted = @IsDeleted, Name = @Name, LogoType = @LogoType, ICAOCode = @ICAOCode, Address = @Address, Phone = @Phone, Fax = @Fax, LogoTypeWhite = @LogoTypeWhite, LogotypeReportLarge = @LogotypeReportLarge, LogotypeReportVeryLarge = @LogotypeReportVeryLarge, Email = @Email  " + String.Format("Where {0} = @{1}", ItemIdName, ItemIdName); 
		}
		
		#endregion

		#region public static String GetSelectQuery()
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД 
		/// </summary>
		public static String GetSelectQuery() 
		{
            return "Select IsDeleted as OperatorIsDeleted, OperatorID as OperatorOperatorID, Name as OperatorName, LogoType as OperatorLogoType, ICAOCode as OperatorICAOCode, Address as OperatorAddress, Phone as OperatorPhone, Fax as OperatorFax, LogoTypeWhite as OperatorLogoTypeWhite, LogotypeReportLarge as OperatorLogotypeReportLarge, LogotypeReportVeryLarge as OperatorLogotypeReportVeryLarge, Email as OperatorEmail from [dbo].[Operators]";
		}
		#endregion

        #region public static void Fill(DataRow row, Operator item)
        /// <summary>
        /// Заполняет поля 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="item"></param>
        public static void Fill(DataRow row, Operator item)
        {
			item.IsDeleted = DbTypes.ToBool(row["OperatorIsDeleted"]);
			item.ItemId = DbTypes.ToInt32(row["OperatorOperatorID"]);
			item.Name = DbTypes.ToString(row["OperatorName"]);
			item.LogoType = DbTypes.ToBytes(row["OperatorLogoType"]);
			item.ICAOCode = DbTypes.ToString(row["OperatorICAOCode"]);
			item.Address = DbTypes.ToString(row["OperatorAddress"]);
			item.Phone = DbTypes.ToString(row["OperatorPhone"]);
			item.Fax = DbTypes.ToString(row["OperatorFax"]);
			item.LogoTypeWhite = DbTypes.ToBytes(row["OperatorLogoTypeWhite"]);
            item.LogotypeReportLarge = DbTypes.ToBytes(row["OperatorLogotypeReportLarge"]);
            item.LogotypeReportVeryLarge = DbTypes.ToBytes(row["OperatorLogotypeReportVeryLarge"]);
			item.Email = DbTypes.ToString(row["OperatorEmail"]);
            item.LogoTypeImageByteView = DbTypes.ToBytes(row["OperatorLogoType"]);
        }
        #endregion

        #region public static List<Operator> GetOperatorList(DataTable table)
        /// <summary>
        /// Получает список воздушных судов из запроса
        /// </summary>
        /// <param name="table"></param>
		/// <returns></returns>
        public static List<Operator> GetOperatorList(DataTable table)
        {
            List<Operator> items = new List<Operator>();
             for (int i=0; i < table.Rows.Count;i++)
            {
				Operator item = new Operator();
                Fill(table.Rows[i], item);
                items.Add(item);
            }
            //
            return items;
        }
        #endregion
	} 
}
  
  
  
  
  
  
