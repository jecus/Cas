#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.AuditMongo.Repository;
using SmartCore.DataAccesses;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Files;
using SmartCore.Filters;
using SmartCore.Management;
using SmartCore.Queries;


#endregion

namespace SmartCore.Entities
{
    /// <summary>
    /// Сохраняет объекты в базе данных
    /// </summary>
    public class Keeper : IKeeper
    {
        #region public CasEnvironment CasEnvironment { get; }
        /// <summary>
        /// Ядро, с которым связан калькулятор
        /// </summary>
        private readonly CasEnvironment _casEnvironment;

        private readonly IAuditRepository _auditRepository;

        #endregion

	    private readonly FilesSmartCore _filesSmartCore;

        #region public Keeper(CasEnvironment casEnvironment)

        /// <summary>
        /// Сохраняет объекты в базе данных
        /// </summary>
        /// <param name="casEnvironment"></param>
        public Keeper(CasEnvironment casEnvironment, IAuditRepository auditRepository)
        {
            _casEnvironment = casEnvironment;
            _auditRepository = auditRepository;
            _filesSmartCore = new FilesSmartCore(_casEnvironment);
        }

		#endregion

		/*
         * Сохранение данных
         */

		#region public void Save(BaseSmartCoreObject obj)

		/// <summary>
		/// Сохраняет <see cref="BaseEntityObject"/> в БД сохраняет если такой уже есть или создает новый если такой объект появляется первый раз
		/// </summary>
		/// <param name="obj">Принимает <see cref="BaseEntityObject"/></param>
		/// <param name="saveAttachedFile">Сохранять прикрепленные файлы</param>
		public void Save(BaseEntityObject obj, bool saveAttachedFile = true)
        {
			if (_casEnvironment.IdentityUser.UserType == UsetType.ReadOnly)
				return;

	        obj.CorrectorId = _casEnvironment.IdentityUser.ItemId;
	        obj.Updated = DateTime.Now;

            if (obj.ItemId <= 0)
            {
                var qr = BaseQueries.GetInsertQuery(obj);
                var ds = _casEnvironment.Execute(qr, BaseQueries.GetParameters(obj));
                obj.ItemId = DbTypes.ToInt32(ds.Tables[0].Rows[0][0]);
                _auditRepository.WriteAsync(obj, AuditOperation.Created, _casEnvironment.IdentityUser);
			}
            else
            {
                // update уже существующей записи
                var qr = BaseQueries.GetUpdateQuery(obj);
                _casEnvironment.Execute(qr, BaseQueries.GetParameters(obj));
                _auditRepository.WriteAsync(obj, AuditOperation.Changed, _casEnvironment.IdentityUser);
			}

			if (obj is IFileContainer && saveAttachedFile)
				SaveAttachedFile(obj as IFileContainer);

			if (obj is IFileDTOContainer && saveAttachedFile)
				SaveAttachedFileDTO(obj as IFileDTOContainer);
		}
        #endregion

        #region public void SaveAll(BaseEntityObject obj, bool saveChild = false, bool saveForsed = false)

        /// <summary>
        /// Сохраняет <see cref="BaseEntityObject"/> в БД сохраняет если такой уже есть или создает новый если такой объект появляется первый раз
        /// </summary>
        /// <param name="obj">Принимает <see cref="BaseEntityObject"/></param>
        /// <param name="saveChild">Сохранять дочерние объекты</param>
        /// <param name="saveForsed">Сохранять свойства, помеченные как "принудительные"</param>
        public void SaveAll(BaseEntityObject obj, bool saveChild = false, bool saveForsed = false)
        {
	        if (_casEnvironment.IdentityUser.UserType == UsetType.ReadOnly)
		        return;

			SaveAllInternal(obj, saveChild, saveForsed);
        }
        #endregion

        #region public void SaveAttachedFile(IFileContainer container)

		public void SaveAttachedFile(IFileContainer container)
	    {
			if(container.Files == null) return;

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

		#region public void Delete(BaseSmartCoreObject obj, bool isDeletedOnly)

		/// <summary>
		/// Удаляет <see cref="BaseEntityObject"/> из БД если такой объект там сохранен
		/// </summary>
		/// <param name="obj">Принимает <see cref="BaseEntityObject"/></param>
		/// <param name="isDeletedOnly">удалить совсем (false) или поставить флаг IsDeleted = true(true)</param>
		/// <param name="saveAttachedFile"></param>
		public void Delete(BaseEntityObject obj, bool isDeletedOnly = false, bool saveAttachedFile = true)
        {
	        if (_casEnvironment.IdentityUser.UserType == UsetType.ReadOnly || _casEnvironment.IdentityUser.UserType == UsetType.SaveOnly)
		        return;

			if (obj.ItemId <= 0) return;

            if(isDeletedOnly)
            {
                obj.IsDeleted = true;
                obj.CorrectorId = _casEnvironment.IdentityUser.ItemId;
                Save(obj, saveAttachedFile);
			}
			else
            {
				var qr = BaseQueries.GetDeleteQuery(obj);
                _casEnvironment.Execute(qr, BaseQueries.GetParameters(obj));

                _auditRepository.WriteAsync(obj, AuditOperation.Deleted, _casEnvironment.IdentityUser);
			}

			if (obj is IFileContainer && saveAttachedFile)
				DeleteAttachedFile(obj as IFileContainer);

			if (obj is IFileDTOContainer && saveAttachedFile)
				DeleteAttachedFileDTO(obj as IFileDTOContainer);

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

		#region public void MarkAsDeletedQuery<T>(ICommonFilter[] filters) where T : BaseEntityObject 

		public void MarkAsDeleted<T>(ICommonFilter[] filters) where T : BaseEntityObject
	    {
		    if (_casEnvironment.IdentityUser.UserType == UsetType.ReadOnly || _casEnvironment.IdentityUser.UserType == UsetType.SaveOnly)
			    return;

			var query = BaseQueries.GetMarkAsDeletedQuery<T>(filters);
		    _casEnvironment.Execute(query);
	    }

		#endregion

		#region private void SaveAllInternal(BaseEntityObject savingObject, bool saveChild = false, bool saveForced = false)

		/// <summary>
		/// Сохраняет переданный объект со всеми его вложеными объектами в БД
		/// </summary>
		/// <param name="savingObject">Объект, который необходимо сохранить</param>
		/// <param name="saveChild">сохранять дочерние объекты для данного типа</param>
		/// <param name="saveForced">сохранять свойства помеченные принудительно</param>
		private void SaveAllInternal(BaseEntityObject savingObject, 
                                     bool saveChild = false, 
                                     bool saveForced = false)
        {
            if (savingObject == null)
            {
                return;
            }
            if (!saveChild)
            {
                Save(savingObject);

                return;
            }

            // Определение конструкций для загрузки вложенных типов (помеченных атрибутом Child), 
            // являющихся BaseSmartCoreObject
            Type type = savingObject.GetType();

            #region Сохранение вложенных объектов в отношении 1 к 1

            //определение своиств, имеющих атрибут "сохраняемое"
            //а так же являющихся вложенными типами
            //и имеющих отношение с данным типом 1 к 1
            List<PropertyInfo> properties;
            if (saveForced)
            {
                //определение своиств, имеющих атрибут "сохраняемое"
                //исключая своиства, которые только считывают информацию из БД
                properties = 
                type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
                                       ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly)
                                       || p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0).ToList();
            }
            else
            {
                //определение своиств, имеющих атрибут "сохраняемое"
                //исключая своиства, которые только записывают информацию в БД
                //и которые загружаются/сохраняются принудительно
                properties =
                type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
                                       ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
                                       ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false)
                                       || p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0).ToList();
            }
            foreach (PropertyInfo t in properties)
            {
                Type baseType = t.PropertyType;
                //Определение атрибута сохраняемой таблицы
                TableAttribute childTypeTable = 
                    (TableAttribute)t.PropertyType.GetCustomAttributes(typeof(TableAttribute), true)
                                                  .FirstOrDefault();
                ChildAttribute child = 
                    (ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), true)
                                     .FirstOrDefault();
                while (baseType != null)
                {
                    if (baseType.Name == typeof(BaseEntityObject).Name &&
                        childTypeTable != null && child != null)
                    {
                        SaveAllInternal(t.GetValue(savingObject, null) as BaseEntityObject, child.LoadChild, saveForced);
                        break;
                    }
                    baseType = baseType.BaseType;
                }
            }
            #endregion

            #region Сохранение текущего объекта

            Save(savingObject);

			#endregion

			#region Определение конструкций для загрузки вложенных типов при отношении 1 к *

			//Поиск своиств имеющих только атрибут Child
			//с пареметром RelationType = 1 ко многим
			properties = type.GetProperties().Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length == 0
                                                        && p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length == 0
                                                        && p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
                                                        && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany
														&& ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.ReadOnly)
                                            .ToList();

            foreach (PropertyInfo t in properties)
            {
                var currentChild = (ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), true).First();
                var collection = t.GetValue(savingObject, null) as ICommonCollection;
                if(collection == null || collection.Count == 0)
                    continue;

                var genericArgumentType = collection[0].GetType();
                PropertyInfo foreightKeyTypeProperty = null;
                PropertyInfo foreightKeyProperty = null;

				//Поиск свойств в дочернем элементе, отвечающих за внешние ключи и обратные ссылки на родителя
                if (!string.IsNullOrEmpty(currentChild.ForeignKeyTypeColumn))
                    foreightKeyTypeProperty = genericArgumentType.GetProperty(currentChild.ForeignKeyTypeColumn);
                if (!string.IsNullOrEmpty(currentChild.ForeignKeyColumn))
                    foreightKeyProperty = genericArgumentType.GetProperty(currentChild.ForeignKeyColumn);

                foreach (BaseEntityObject o in collection)
                {
					//Если свойства, указывающие на внешние ключи и обратные ссылки на родителя найдены,
					//то этим свойствам проставляются данные из текущего родителя
	                foreightKeyProperty?.SetValue(o, savingObject.ItemId, null);
	                foreightKeyTypeProperty?.SetValue(o, savingObject.SmartCoreObjectType.ItemId, null);

	                SaveAllInternal(o, currentChild.LoadChild, saveForced);
                }
            }
            #endregion
        }
        #endregion

        /*
         * Связь с ядром
        */

        /*
         * Сохранение данных
         */
    }
}