/*
* Class code generate programm
* Date: 12.07.2010
* Database: CasDemo
* Table: TransferRecord
*/

using System;
using System.Collections.Generic;
using System.Data; // DataRow, DataTable, DataSet
    // SqlParameter
using SmartCore.Entities.General;


namespace SmartCore.Queries
{
    /// <summary>
    /// Запросы для получения данных о перемещениях
    /// </summary>
	public static class TransferRecordQueries
    {

		#region public static String GetSelectQuery()
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД 
		/// </summary>
		private static String GetSelectQuery() 
		{
            return BaseQueries.GetSelectQuery<TransferRecord>();
		}
		#endregion

        #region public static String GetSelectQuery(String Statement)
        /// <summary>
        /// Возвращает запрос на получение данных о перемещении данного базового агрегата
        /// </summary>
        public static String GetSelectQuery(String statement)
        {
            return GetSelectQuery() + string.Format(@"where IsDeleted = 0 and {0}", statement);
        }
        #endregion

        #region private static void Fill(DataRow row, CorrectiveAction item)
        /// <summary>
        /// Заполняет поля 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="item"></param>
        private static void Fill(DataRow row, TransferRecord item)
        {
            BaseQueries.Fill(row, item);
        }
        #endregion

        #region public static List<TransferRecord> GetTransferRecordList(DataTable table)
        /// <summary>
        /// Получает список записей о перемещении
        /// </summary>
        /// <param name="table"></param>
		/// <returns></returns>
        public static List<TransferRecord> GetTransferRecordList(DataTable table)
        {
            List<TransferRecord> items = new List<TransferRecord>();
            
            for (int i=0; i < table.Rows.Count;i++)
            {
				TransferRecord item = new TransferRecord();
                Fill(table.Rows[i], item);
                items.Add(item);
            }
            //
            return items;
        }
        #endregion
	} 
}
  
  
  
  
  
  
