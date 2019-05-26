using System.Collections.Generic;
using EFCore.DTO;
using SmartCore.Entities.General;

namespace SmartCore.Entities
{
	public interface INewKeeper
	{
		void Save(BaseEntityObject value, bool saveAttachedFile = true, bool writeAudit = true);

		void Delete(BaseEntityObject value, bool isDeletedOnly = false, bool saveAttachedFile = true);
		void SaveAttachedFile(IFileContainer container);
		void BulkInsert(List<BaseEntityObject> value, int? batchSize = null);
		void BulkDelete(List<BaseEntityObject> value, int? batchSize = null);

	}
}