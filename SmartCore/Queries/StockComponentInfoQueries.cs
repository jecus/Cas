/*
* Class code generate programm
* Date: 12.07.2010
* Database: CasDemo
* Table: StockDetailInfo
*/

using System;
using System.Collections.Generic;
using System.Data; // DataRow, DataTable, DataSet
using System.Data.SqlClient; // SqlParameter
using SmartCore.Entities.General.Store;
using SmartCore.Management;


namespace SmartCore.Queries
{
	public static class StockComponentInfoQueries
	{

		#region private static String ItemIdName = "TemplatesID";
		/// <summary>
		/// Ключевое поле
		/// </summary>
        private static String ItemIdName = "ItemID";
		#endregion

		#region public static SqlParameter[] GetParameters(StockComponentInfo item)
		/// <summary>
		/// Возвращает список параметров, которые могут использоваться в запросах
		/// </summary>
		public static SqlParameter[] GetParameters(StockComponentInfo item)
		{
				List<SqlParameter> parameters = new List<SqlParameter>();

				parameters.Add(new SqlParameter("@IsDeleted", DbTypes.DbObject(item.IsDeleted)));
				parameters.Add(new SqlParameter("@ItemID", DbTypes.DbObject(item.ItemId)));
				parameters.Add(new SqlParameter("@StoreID", DbTypes.DbObject(item.StoreId)));
				parameters.Add(new SqlParameter("@PartNumber", DbTypes.DbObject(item.PartNumber)));
				parameters.Add(new SqlParameter("@Amount", DbTypes.DbObject(item.ShouldBeOnStock)));
				parameters.Add(new SqlParameter("@Description", DbTypes.DbObject(item.Description)));


			return parameters.ToArray();
		}
		
		#endregion

		#region public static String GetInsertQuery()
		///<summary>
		/// Возвращает строку SQL запроса добавление данных в БД 
		/// </summary>
		public static String GetInsertQuery() 
		{
            return "Set dateformat dmy; Insert Into [dbo].StockComponentInfos (IsDeleted, StoreID, PartNumber, Amount, Description) Values (@IsDeleted, @StoreID, @PartNumber, @Amount, @Description) SELECT SCOPE_IDENTITY();";
		}
		
		#endregion

		#region public static String GetUpdateQuery()
		/// <summary>
		/// Возвращает строку SQL запроса на обновление данных в БД 
		/// </summary>
		public static String GetUpdateQuery() 
		{
 				return "Set dateformat dmy; Update [dbo].StockComponentInfos Set IsDeleted = @IsDeleted, StoreID = @StoreID, PartNumber = @PartNumber, Amount = @Amount, Description = @Description  "+ String.Format("Where {0} = @{1}", ItemIdName, ItemIdName); 
		}
		
		#endregion

		#region public static String GetSelectQuery()
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД 
		/// </summary>
		public static String GetSelectQuery() 
		{
 				return "Select IsDeleted as StockComponentInfoIsDeleted, ItemID as StockComponentInfoItemID, StoreID as StockComponentInfoStoreID, PartNumber as StockComponentInfoPartNumber, Amount as StockComponentInfoAmount, Description as StockComponentInfoDescription from [dbo].[StockComponentInfos] where IsDeleted=0";
		}
		#endregion

        #region public static String GetSelectQuery(Store store)
        /// <summary>
        /// Возвращает строку SQL запроса на селектирование данных из БД по переданному складу
        /// </summary>
        public static String GetSelectQuery(Store store)
        {
            return GetSelectQuery()+" and StoreId = "+ store.ItemId;
        }
        #endregion


        #region public static void Fill(DataRow row, CorrectiveAction item)
        /// <summary>
        /// Заполняет поля 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="item"></param>
        public static void Fill(DataRow row, StockComponentInfo item)
        {
			item.IsDeleted = DbTypes.ToBool(row["StockComponentInfoIsDeleted"]);
			item.ItemId = DbTypes.ToInt32(row["StockComponentInfoItemID"]);
			item.StoreId = DbTypes.ToInt32(row["StockComponentInfoStoreID"]);
			item.PartNumber = DbTypes.ToString(row["StockComponentInfoPartNumber"]);
			item.ShouldBeOnStock = DbTypes.ToInt32(row["StockComponentInfoAmount"]);
			item.Description = DbTypes.ToString(row["StockComponentInfoDescription"]);

        }
		#endregion

		#region public static List<StockComponentInfo> GetStockComponentInfoList(DataTable table)
		/// <summary>
		/// Получает список воздушных судов из запроса
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public static List<StockComponentInfo> GetStockComponentInfoList(DataTable table)
        {
            List<StockComponentInfo> items = new List<StockComponentInfo>();
             for (int i=0; i < table.Rows.Count;i++)
            {
				StockComponentInfo item = new StockComponentInfo();
                Fill(table.Rows[i], item);
                items.Add(item);
            }
            //
            return items;
        }
        #endregion
 
 
 
	} 


}
  
  
  
  
  
  
