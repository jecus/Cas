using System.Collections.Generic;
using EFCore.DTO;
using SmartCore.Entities.General;

namespace SmartCore.Entities
{
	public interface INewKeeper
	{
		void Save(BaseEntityObject value, bool saveAttachedFile = true, bool writeAudit = true);

		void SaveGeneric<T, TOut>(T value, bool saveAttachedFile = true)
			where T : BaseEntityObject, new() where TOut : BaseEntity, new();

		void Delete(BaseEntityObject value, bool isDeletedOnly = false, bool saveAttachedFile = true);

		void DeleteGeneric<T, TOut>(T value, bool isDeletedOnly = false, bool saveAttachedFile = true)
			where T : BaseEntityObject, new() where TOut : BaseEntity, new();

		void SaveAttachedFile(IFileContainer container);

		void BulkInsert<T, TOut>(IEnumerable<T> values, int? batchSize = null) where T : BaseEntityObject, new()
			where TOut : BaseEntity, new();

		void BulkDelete<T, TOut>(IEnumerable<T> values, int? batchSize = null) where T : BaseEntityObject, new()
			where TOut : BaseEntity, new();
	}
}