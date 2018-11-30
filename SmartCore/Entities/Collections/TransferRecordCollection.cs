using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.General;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Коллекция записей о перемещении агрегатов с правильной сортировкой по дате
    /// </summary>
    [Serializable]
    public class TransferRecordCollection: BaseRecordCollection<TransferRecord>
    {

        #region public TransferRecordCollection()
        /// <summary>
        /// Создает пустую коллекцию записей о переносе
        /// </summary>
        public TransferRecordCollection()
        {
        }
        #endregion

        #region public TransferRecordCollection(TransferRecord[] transferRecords)
        /// <summary>
        /// Создает коллекцию записей о переносе на основе передаваемого массива 
        /// </summary>
        /// <param name="transferRecords"></param>
        public TransferRecordCollection(TransferRecord[] transferRecords)
        {
			if(transferRecords != null)
				AddRange(transferRecords);
        }
		#endregion

		#region public TransferRecord GetRecordByComponentId(Int32 id)
		/// <summary>
		/// Возвращает запись о переносе с указанным номером детали, либо null если такой записи о переносе не было найдено в коллекции
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public TransferRecord GetRecordByComponentId(int id)
        {
            return Items.FirstOrDefault(item => item.ParentId == id);
        }

        #endregion

        #region public new IEnumerator<TransferRecord> GetEnumerator()
        /// <summary>
        /// Реализация цикла foreach 
        /// </summary>
        /// <returns></returns>
        public new IEnumerator<TransferRecord> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        #endregion
    }

}
