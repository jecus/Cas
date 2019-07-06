using System.Collections.Generic;
using EFCore.DTO;
using SmartCore.Entities.General;

namespace SmartCore.Entities
{
	public interface INewKeeper
	{

		void BulkInsert<T, TOut>(List<BaseEntityObject> values, int? batchSize = null) where T : BaseEntityObject, new()
			where TOut : BaseEntity, new();
		void SaveGeneric<T, TOut>(T value, bool saveAttachedFile = true) where T : BaseEntityObject, new()
			where TOut : BaseEntity, new();
		void DeleteGeneric<T, TOut>(T value, bool isDeletedOnly = false, bool saveAttachedFile = true)
			where T : BaseEntityObject, new() where TOut : BaseEntity, new();
		void BulkDelete<T, TOut>(List<BaseEntityObject> values, int? batchSize = null, bool isDeleted = true) where T : BaseEntityObject, new() where TOut : BaseEntity, new();

		void Save(BaseEntityObject value, bool saveAttachedFile = true, bool writeAudit = true);

		void Delete(BaseEntityObject value, bool isDeletedOnly = false, bool saveAttachedFile = true);
		void SaveAttachedFile(IFileContainer container);
		void BulkInsert(List<BaseEntityObject> value, int? batchSize = null);
		void BulkDelete(List<BaseEntityObject> value, int? batchSize = null);

		

	}
}