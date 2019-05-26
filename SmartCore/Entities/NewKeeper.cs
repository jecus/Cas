using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EFCore.DTO;
using EFCore.DTO.General;
using SmartCore.AuditMongo.Repository;
using SmartCore.DataAccesses;
using SmartCore.DtoHelper;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Files;

namespace SmartCore.Entities
{
	public class NewKeeper : INewKeeper
	{
		#region Fields

		private readonly CasEnvironment _casEnvironment;
		private readonly IAuditRepository _auditRepository;
		private readonly FilesSmartCore _filesSmartCore;

		#endregion

		#region Constructor

		public NewKeeper(CasEnvironment casEnvironment, IAuditRepository auditRepository)
		{
			_casEnvironment = casEnvironment;
			_auditRepository = auditRepository;
			_filesSmartCore = new FilesSmartCore(_casEnvironment);
		}

		#endregion

		public void Save(BaseEntityObject value, bool saveAttachedFile = true, bool writeAudit = true)
		{
			if (_casEnvironment.IdentityUser.UserType == UsetType.ReadOnly)
				return;

			value.CorrectorId = _casEnvironment.IdentityUser.ItemId;

			var type = AuditOperation.Created;
			if (value.ItemId > 0)
				type = AuditOperation.Changed;
				
			var blType = value.GetType();
			var dto = (DtoAttribute)blType.GetCustomAttributes(typeof(DtoAttribute), false).FirstOrDefault();
			var method = typeof(INewKeeper).GetMethods().FirstOrDefault(i => i.Name == "SaveGeneric")?.MakeGenericMethod(blType, dto.Type);

			method.Invoke(this, new object[] { value, saveAttachedFile });

			if(writeAudit)
				_auditRepository.WriteAsync(value, type ,_casEnvironment.IdentityUser);
		}

		private void SaveGeneric<T, TOut>(T value, bool saveAttachedFile = true) where T : BaseEntityObject, new() where TOut : BaseEntity, new()
		{
			if (_casEnvironment.IdentityUser.UserType == UsetType.ReadOnly)
				return;

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(T).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var repo = _casEnvironment.UnitOfWork.GetRepository<TOut>();

			if (repo == null)
				throw new ArgumentNullException("repo", $"В репозитории не содержится тип {nameof(T)}");


			var method = GetMethod(typeof(T), "Convert");
			var res = InvokeConverter<T, TOut>(value, method);
			var newId = repo.Save(res);

			value.ItemId = newId;

			if (value is IFileContainer && saveAttachedFile)
				SaveAttachedFile(value as IFileContainer);

			if (value is IFileDTOContainer && saveAttachedFile)
				SaveAttachedFileDTO(value as IFileDTOContainer);
		}

		public void BulkInsert(List<BaseEntityObject> value, int? batchSize = null)
		{
			if (_casEnvironment.IdentityUser.UserType == UsetType.ReadOnly)
				return;

			value.CorrectorId = _casEnvironment.IdentityUser.ItemId;

			var blType = value.GetType();
			var dto = (DtoAttribute)blType.GetCustomAttributes(typeof(DtoAttribute), false).FirstOrDefault();
			var method = typeof(INewKeeper).GetMethods().FirstOrDefault(i => i.Name == "BulkInsert")?.MakeGenericMethod(blType, dto.Type);

			method.Invoke(this, new object[] { value, batchSize });

		}
		private void BulkInsert<T, TOut>(IEnumerable<T> values,int? batchSize = null) where T : BaseEntityObject, new() where TOut : BaseEntity, new()
		{
			if (_casEnvironment.IdentityUser.UserType == UsetType.ReadOnly)
				return;

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(T).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var repo = _casEnvironment.UnitOfWork.GetRepository<TOut>();

			if (repo == null)
				throw new ArgumentNullException("repo", $"В репозитории не содержится тип {nameof(T)}");


			var method = GetMethod(typeof(T), "Convert");

			var res = new List<TOut>();
			foreach (var value in values)
			{
				res.Add(InvokeConverter<T, TOut>(value, method));
			}
			
			repo.BulkInsert(res, batchSize);
			
		}


		public void BulkDelete(List<BaseEntityObject> value,int? batchSize = null)
		{
			if (_casEnvironment.IdentityUser.UserType == UsetType.ReadOnly || _casEnvironment.IdentityUser.UserType == UsetType.SaveOnly)
				return;

			value.CorrectorId = _casEnvironment.IdentityUser.ItemId;

			var blType = value.GetType();
			var dto = (DtoAttribute)blType.GetCustomAttributes(typeof(DtoAttribute), false).FirstOrDefault();
			var method = typeof(INewKeeper).GetMethods().FirstOrDefault(i => i.Name == "BulkDelete")?.MakeGenericMethod(blType, dto.Type);

			method.Invoke(this, new object[] { value, batchSize });

		}
		public void BulkDelete<T, TOut>(IEnumerable<T> values, int? batchSize = null) where T : BaseEntityObject, new() where TOut : BaseEntity, new()
		{
			if (_casEnvironment.IdentityUser.UserType == UsetType.ReadOnly)
				return;

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(T).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var repo = _casEnvironment.UnitOfWork.GetRepository<TOut>();

			if (repo == null)
				throw new ArgumentNullException("repo", $"В репозитории не содержится тип {nameof(T)}");


			var method = GetMethod(typeof(T), "Convert");

			var res = new List<TOut>();
			foreach (var value in values)
			{
				res.Add(InvokeConverter<T, TOut>(value, method));
			}

			repo.BulkDelete(res, batchSize);

		}


		public void Delete(BaseEntityObject value, bool isDeletedOnly = false, bool saveAttachedFile = true)
		{
			if (_casEnvironment.IdentityUser.UserType == UsetType.ReadOnly || _casEnvironment.IdentityUser.UserType == UsetType.SaveOnly)
				return;

			value.CorrectorId = _casEnvironment.IdentityUser.ItemId;

			var blType = value.GetType();
			var dto = (DtoAttribute)blType.GetCustomAttributes(typeof(DtoAttribute), false).FirstOrDefault();
			var method = typeof(INewKeeper).GetMethods().FirstOrDefault(i => i.Name == "DeleteGeneric")?.MakeGenericMethod(blType, dto.Type);

			method.Invoke(this, new object[] { value, isDeletedOnly, saveAttachedFile });

			_auditRepository.WriteAsync(value, AuditOperation.Deleted, _casEnvironment.IdentityUser);

		}

		private void DeleteGeneric<T, TOut>(T value, bool isDeletedOnly = false, bool saveAttachedFile = true) where T : BaseEntityObject, new() where TOut : BaseEntity, new()
		{
			if (_casEnvironment.IdentityUser.UserType == UsetType.ReadOnly || _casEnvironment.IdentityUser.UserType == UsetType.SaveOnly)
				return;

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(T).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var repo = _casEnvironment.UnitOfWork.GetRepository<TOut>();

			if (repo == null)
				throw new ArgumentNullException("repo", $"В репозитории не содержится тип {nameof(T)}");

			var method = GetMethod(typeof(T), "Convert");

			if (isDeletedOnly)
			{
				value.IsDeleted = true;
				repo.Save(InvokeConverter<T, TOut>(value, method));
			}
			else repo.Delete(InvokeConverter<T, TOut>(value, method));

			if (value is IFileContainer && saveAttachedFile)
				DeleteAttachedFile(value as IFileContainer);

			if (value is IFileDTOContainer && saveAttachedFile)
				DeleteAttachedFileDTO(value as IFileDTOContainer);
		}


		#region private void DeleteAttachedFileDTO(IFileContainer container)

		private void DeleteAttachedFile(IFileContainer container)
		{
			if (container.Files == null) return;

			foreach (var itemFileLink in container.Files)
			{
				if (itemFileLink.File == null) continue;
				if (itemFileLink.File.ItemId > 0)
					_filesSmartCore.DeleteAttachedFile(itemFileLink);
			}
		}

		#endregion

		#region private void DeleteAttachedFileDTO(IFileDTOContainer container)

		private void DeleteAttachedFileDTO(IFileDTOContainer container)
		{
			if (container.Files == null) return;

			foreach (var itemFileLink in container.Files)
			{
				if (itemFileLink.File == null) continue;
				if (itemFileLink.File.ItemId > 0)
					_filesSmartCore.DeleteAttachedFileDTO(itemFileLink);
			}
		}

		#endregion

		#region private void SaveAttachedFileDTO(IFileDTOContainer container)

		private void SaveAttachedFileDTO(IFileDTOContainer container)
		{
			if (container.Files == null) return;

			foreach (var itemFileLink in container.Files)
			{
				if (itemFileLink.File == null) continue;
				if (itemFileLink.ParentId <= 0)
					itemFileLink.ParentId = container.ItemId;
				if (itemFileLink.File.ItemId > 0 && itemFileLink.File.IsDeleted)
					_filesSmartCore.DeleteAttachedFileDTO(itemFileLink);
				else _filesSmartCore.SaveAttachedFileDTO(itemFileLink);
			}
		}

		#endregion

		#region public void SaveAttachedFile(IFileContainer container)

		public void SaveAttachedFile(IFileContainer container)
		{
			if (container.Files == null) return;

			foreach (var itemFileLink in container.Files)
			{
				if (itemFileLink.File == null) continue;
				if (itemFileLink.ParentId <= 0)
					itemFileLink.ParentId = container.ItemId;
				if (itemFileLink.File.ItemId > 0 && itemFileLink.File.IsDeleted)
					_filesSmartCore.DeleteAttachedFile(itemFileLink);
				else _filesSmartCore.SaveAttachedFile(itemFileLink);
			}
		}

		#endregion

		#region private MethodInfo GetMethod(Type t, string methodName)

		private MethodInfo GetMethod(Type t, string methodName)
		{
			var method = typeof(GeneralConverterDto).GetMethod(methodName, BindingFlags.Static | BindingFlags.Public, null, new[] { t }, null);
			if (method == null)
				method = typeof(DictionaryConverterDto).GetMethod(methodName, BindingFlags.Static | BindingFlags.Public, null, new[] { t }, null);

			if (method == null)
				throw new ArgumentNullException(methodName, $"В конвертере не содержится метод для {nameof(t)}");

			return method;
		}

		#endregion

		#region private TOut InvokeConverter<T, TOut>(T value)

		private TOut InvokeConverter<T, TOut>(T value, MethodInfo method) where T : BaseEntityObject, new() where TOut : BaseEntity, new()
		{
			var instance = Activator.CreateInstance(typeof(TOut));
			return method.Invoke(instance, new object[] { value }) as TOut;
		}

		#endregion

	}
}