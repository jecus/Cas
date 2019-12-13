using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;

namespace SmartCore.Entities.Collections
{

	/// <summary>
	/// Коллекция записей о выполнении директивы
	/// </summary>
	[Serializable]
	public class RunupsCollection: BaseRecordCollection<RunUp>
	{
		#region public RunupsCollection()
		/// <summary>
		/// Создает пустую коллекцию записей о запусках силовых установок
		/// </summary>
		public RunupsCollection()
		{
		}
		#endregion

		#region public RunupsCollection(IEnumerable<RunUp> directiveRecords) : base(directiveRecords)
		/// <summary>
		/// Создает коллекцию на основе списка записей о запусках
		/// </summary>
		/// <param name="directiveRecords"></param>
		public RunupsCollection(IEnumerable<RunUp> directiveRecords)
			: base(directiveRecords)
		{
		}
		#endregion

		#region public IEnumerable<RunUp> GetByBaseComponent(BaseComponent bd)
		/// <summary>
		/// Возвращает коллекцию запусков, пренадлежащих переданной базовой детали, или пустую коллекцию
		/// </summary>
		/// <param name="bd">Базовая деталь, запуски которой необходимо вернуть</param>
		/// <returns>Коллекция запусков базовой детали</returns>
		public IEnumerable<RunUp> GetByBaseComponent(BaseComponent bd)
		{
			List<RunUp> runups = new List<RunUp>();
			
			if(bd != null) runups.AddRange(Items.Where(r => r.BaseComponentId == bd.ItemId));

			return runups;
		}
		#endregion
	}
}
