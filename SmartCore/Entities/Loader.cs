#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Hangar;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.Templates;
using SmartCore.Entities.General.WorkShop;
using SmartCore.Filters;
using SmartCore.Management;
using SmartCore.Queries;
using System.Linq;

#endregion

namespace SmartCore.Entities
{
    /// <summary>
    /// Реализует все методы загрузки информации из базы данных
    /// </summary>
    public class Loader:ILoader
    {

		#region private readonly CasEnvironment _casEnvironment;

		/// <summary>
		/// Ядро, с которым связан калькулятор
		/// </summary>
		private readonly CasEnvironment _casEnvironment;

        #endregion

        #region public Loader(CasEnvironment casEnvironment)

        /// <summary>
        /// Создает загрузчик для ядра Cas
        /// </summary>
        /// <param name="casEnvironment"></param>
        public Loader(CasEnvironment casEnvironment)
        {
            _casEnvironment = casEnvironment;
        }

        #endregion

		public void LoadBaseComponents(Aircraft aircraft)
		{
			if (aircraft == null)
				return;

			List<ExecutionResultArgs> resultArgses;
			List<DbQuery> qrs = BaseComponentQueries.GetSelectQueries(aircraft, loadChild: true);
			DataSet ds = _casEnvironment.Execute(qrs, out resultArgses);
			ExecutionResultArgs args = resultArgses.FirstOrDefault(r => r.Exception != null);
			if (args != null)
				throw args.Exception;
			var baseComponents = BaseQueries.GetObjectList(ds, true, true);

			#region Проверка на еквивалентность базовых агрегатов ВС содержащийхся в ядре

			bool equals = true;
			foreach (BaseComponent baseComponent in baseComponents)
			{
				var envBaseComponent = _casEnvironment.BaseComponents.GetItemById(baseComponent.ItemId);//TODO(Evgenii Babak): использовать ComponentCore
				if (envBaseComponent != null && envBaseComponent.Equals(baseComponent))
					continue;
				equals = false;
				break;
			}

			//Если коллекции идентичны, то никаких изменений производить не нужно
			if (equals)
				return;

			#endregion

			foreach (BaseComponent baseComponent in baseComponents)
			{
				_casEnvironment.BaseComponents.RemoveById(baseComponent.ItemId);
				_casEnvironment.BaseComponents.Add(baseComponent);
			}
			//return baseDetails;
		}


		#region public T GetObject<T>(int itemId, bool loadChild = false, bool loadForced = false, bool loadDeleted = false) where T : BaseEntityObject, new()
		/// <summary>
		/// Возвращает объект определенного типа с заданным Id
		/// </summary>
		/// <typeparam name="T">Тип объекта</typeparam>
		/// <param name="itemId">Id объекта</param>
		/// <param name="loadChild">Загружать объекты, помеченные атрибутом Child</param>
		/// <param name="loadForced">Загружать поля, помеченные как принудительные</param>
		/// <param name="loadDeleted">Загружать элементы, помеченные как удаленные</param>
		/// <returns></returns>
		public T GetObject<T>(int itemId, 
                              bool loadChild = false, 
                              bool loadForced = false, 
                              bool loadDeleted = false) where T : BaseEntityObject, new()
        {
            return (T)GetObject(typeof(T), itemId, loadChild, false, loadForced, loadDeleted);
        }
        #endregion

        #region public T GetObject<T>(ICommonFilter[] filters = null, bool loadChild = false, bool loadForced = false, bool loadDeleted = false) where T : BaseEntityObject, new()
        /// <summary>
        /// Возвращает объект определенного типа с заданным Id
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="filters">Дополнительные фильтры</param>
        /// <param name="loadChild">Загружать объекты, помеченные атрибутом Child</param>
        /// <param name="loadForced">Загружать поля, помеченные как принудительные</param>
        /// <param name="loadDeleted">Загружать элементы, помеченные как удаленные</param>
        /// <returns></returns>
        public T GetObject<T>(ICommonFilter[] filters,
                              bool loadChild = false,
                              bool loadForced = false,
                              bool loadDeleted = false) where T : BaseEntityObject, new()
        {
            return (T)GetObject(typeof(T), filters, loadChild, false, loadForced, loadDeleted);
        }
        #endregion

        #region public T GetObject<T>(ICommonFilter filter = null, bool loadChild = false, bool loadForced = false, bool loadDeleted = false) where T : BaseEntityObject, new()
        /// <summary>
        /// Возвращает объект определенного типа с заданным Id
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="filter">Дополнительные фильтр</param>
        /// <param name="loadChild">Загружать объекты, помеченные атрибутом Child</param>
        /// <param name="loadForced">Загружать поля, помеченные как принудительные</param>
        /// <param name="loadDeleted">Загружать элементы, помеченные как удаленные</param>
        /// <returns></returns>
        public T GetObject<T>(ICommonFilter filter,
                              bool loadChild = false,
                              bool loadForced = false,
                              bool loadDeleted = false) where T : BaseEntityObject, new()
        {
            return (T)GetObject(typeof(T), new[]{filter}, loadChild, false, loadForced, loadDeleted);
        }
        #endregion


        #region private BaseEntityObject GetObject(Type type, int itemId IQueryFilter[]filters = null, bool loadChild = false, bool getDeleted = false)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="itemId">Идентификатор элемента</param>
        /// <param name="loadChild">Производить загрузку дочерних объектов (помеченных атрибутом Child). По умолчанию FALSE</param>
        /// <param name="checkType">Проверить тип на иерархию наследования</param>
        /// <param name="getForced">Загружать поля, помеченные как принудительные</param>
        /// <param name="getDeleted">Загружать элементы, помеченные как удаленные</param>
        /// <returns></returns>
        private BaseEntityObject GetObject(Type type, 
                                           int itemId,
                                           bool loadChild = false, 
                                           bool checkType = false, 
                                           bool getForced = false,
                                           bool getDeleted = false)
        {
            if (type == null)
                throw new ArgumentNullException("type", "не должен быть null");

            //Проверка, является ли переданный тип наследником BaseSmartCoreObject
            if (!type.IsSubclassOf(typeof(BaseEntityObject)))
            {
                throw new ArgumentException("type", "не является наследником " + typeof(BaseEntityObject).Name);
            }
            if (type.GetCustomAttributes(typeof(TableAttribute), false).Length <= 0)
            {
                throw new ArgumentException("не определен атрибут таблицы для хранения в БД", "type");
            }
            List<ExecutionResultArgs> resultArgses;
            List<DbQuery> qrs = 
                BaseQueries.GetSelectQueryWithWhereAll(type,
                                                       new ICommonFilter[] { new CommonFilter<int>(BaseEntityObject.ItemIdProperty, itemId) }, 
                                                       loadChild, checkType, getDeleted, getForced);
            DataSet ds = _casEnvironment.Execute(qrs, out resultArgses);
            if (resultArgses.Count(r => r.Exception != null) > 0)
                throw resultArgses.First(r => r.Exception != null).Exception;
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return (BaseEntityObject)BaseQueries.GetObjectList(ds, loadChild, true, getForced)[0];
        }
        #endregion

        #region private BaseEntityObject GetObject(Type type, ICommonFilter[] filters, bool loadChild = false, bool checkType = false, bool getForced = false, bool getDeleted = false)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="filters">фильтры</param>
        /// <param name="loadChild">Производить загрузку дочерних объектов (помеченных атрибутом Child). По умолчанию FALSE</param>
        /// <param name="checkType">Проверить тип на иерархию наследования</param>
        /// <param name="getForced">Загружать поля, помеченные как принудительные</param>
        /// <param name="getDeleted">Загружать элементы, помеченные как удаленные</param>
        /// <returns></returns>
        private BaseEntityObject GetObject(Type type,
                                           ICommonFilter[] filters,
                                           bool loadChild = false,
                                           bool checkType = false,
                                           bool getForced = false,
                                           bool getDeleted = false)
        {
            if (type == null)
                throw new ArgumentNullException("type", "не должен быть null");
            if (filters == null || filters.Length <= 0)
                throw new ArgumentNullException("filters", "не должен быть null");

            //Проверка, является ли переданный тип наследником BaseSmartCoreObject
            if (!type.IsSubclassOf(typeof(BaseEntityObject)))
            {
                throw new ArgumentException("type", "не является наследником " + typeof(BaseEntityObject).Name);
            }
            if (type.GetCustomAttributes(typeof(TableAttribute), false).Length <= 0)
            {
                throw new ArgumentException("не определен атрибут таблицы для хранения в БД", "type");
            }

            List<ExecutionResultArgs> resultArgses;
            List<DbQuery> qrs =
                BaseQueries.GetSelectQueryWithWhereAll(type,
                                                       filters,
                                                       loadChild, checkType, getDeleted, getForced);
            DataSet ds = _casEnvironment.Execute(qrs, out resultArgses);
            if (resultArgses.Count(r => r.Exception != null) > 0)
                throw resultArgses.First(r => r.Exception != null).Exception;
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return (BaseEntityObject)BaseQueries.GetObjectList(ds, loadChild, true, getForced)[0];
        }
        #endregion

        #region public List<T> GetObjectList<T>(IQueryFilter[] filters = null, bool loadChild = false, bool getDeleted = false) where T : BaseSmartCoreObject, new()
        /// <summary>
        /// Делает запрос к БД и возвращает список объектов переданного типа
        /// </summary>
        /// <typeparam name="T">Тип объетов, которые необходимо вернуть из БД</typeparam>
        /// <param name="filters">Фильтрация по определенным полям</param>
        /// <param name="loadChild">Производить загрузку дочерних объектов (помеченных атрибутом Child). По умолчанию FALSE</param>
        /// <param name="getDeleted">Загружать недействительные записи. По умолчанию FALSE</param>
        /// <returns>Список объектов переданного типа</returns>
        public List<T> GetObjectList<T>(ICommonFilter[] filters = null, bool loadChild = false, bool getDeleted = false) where T : BaseEntityObject, new()
        {
            _casEnvironment.CheckType(typeof(T));

            String qr = BaseQueries.GetSelectQueryWithWhere<T>(filters, loadChild, getDeleted);
            DataSet ds = _casEnvironment.Execute(qr);
            List<T> result = BaseQueries.GetObjectList<T>(ds.Tables[0],loadChild);

            // возвращаем результат
            return result;
        }
        #endregion

        #region public List<T> GetObjectListAll<T>(IQueryFilter[] filters = null, bool loadChild = false, bool getDeleted = false) where T : BaseSmartCoreObject, new()

        /// <summary>
        /// Делает запрос к БД и возвращает список объектов переданного типа
        /// </summary>
        /// <typeparam name="T">Тип объетов, которые необходимо вернуть из БД</typeparam>
        /// <param name="filters">Фильтрация по определенным полям</param>
        /// <param name="loadChild">Производить загрузку дочерних объектов (помеченных атрибутом Child). По умолчанию FALSE</param>
        /// <param name="getDeleted">Загружать недействительные записи. По умолчанию FALSE</param>
        /// <param name="ignoreConditions">Игнорировать значения полей по умолчанию</param>
        /// <returns>Список объектов переданного типа</returns>
        public List<T> GetObjectListAll<T>(ICommonFilter[] filters = null, 
                                           bool loadChild = false, 
                                           bool getDeleted = false,
                                           bool ignoreConditions = false) where T : BaseEntityObject, new()
        {
	        _casEnvironment.CheckType(typeof(T));
			// возвращаем результат
			return (List<T>)GetObjectList(typeof(T), filters, loadChild, getDeleted, ignoreConditions : ignoreConditions);
        }
        #endregion

        #region public List<T> GetObjectListAll<T>(IQueryFilter filter, bool loadChild = false, bool getDeleted = false) where T : BaseSmartCoreObject, new()

        /// <summary>
        /// Делает запрос к БД и возвращает список объектов переданного типа
        /// </summary>
        /// <typeparam name="T">Тип объетов, которые необходимо вернуть из БД</typeparam>
        /// <param name="filter">Фильтрация по определенным полям</param>
        /// <param name="loadChild">Производить загрузку дочерних объектов (помеченных атрибутом Child). По умолчанию FALSE</param>
        /// <param name="getDeleted">Загружать недействительные записи. По умолчанию FALSE</param>
        /// <param name="ignoreConditions">Игнорировать значения полей по умолчанию</param>
        /// <returns>Список объектов переданного типа</returns>
        public List<T> GetObjectListAll<T>(ICommonFilter filter, bool loadChild = false, bool getDeleted = false, bool ignoreConditions = false) where T : BaseEntityObject, new()
        {
            _casEnvironment.CheckType(typeof(T));
			// возвращаем результат
			return (List<T>)GetObjectList(typeof(T), new[] {filter}, loadChild, getDeleted, ignoreConditions : ignoreConditions);
        }
        #endregion

        #region public List<T> GetObjectListAll<T>(PropertyInfo filterProperty, int filterPropertyValue, bool loadChild = false, bool getDeleted = false) where T : BaseSmartCoreObject, new()

        /// <summary>
        /// Делает запрос к БД и возвращает список объектов переданного типа
        /// </summary>
        /// <typeparam name="T">Тип объетов, которые необходимо вернуть из БД</typeparam>
        /// <param name="filterProperty">Свойство, по которомц нужно произвести фильтрацию</param>
        /// <param name="filterPropertyValue">Значение фильтруемого свойства</param>
        /// <param name="loadChild">Производить загрузку дочерних объектов (помеченных атрибутом Child). По умолчанию FALSE</param>
        /// <param name="getDeleted">Загружать недействительные записи. По умолчанию FALSE</param>
        /// <returns>Список объектов переданного типа</returns>
        public List<T> GetObjectListAll<T>(PropertyInfo filterProperty, int filterPropertyValue, bool loadChild = false, bool getDeleted = false) where T : BaseEntityObject, new()
        {
            _casEnvironment.CheckType(typeof(T));
			// возвращаем результат
			return (List<T>)GetObjectList(typeof(T), new ICommonFilter[] { new CommonFilter<int>(filterProperty, filterPropertyValue) }, loadChild, getDeleted);
        }
        #endregion

        #region public List<T> GetObjectListAll<T>(PropertyInfo filterProperty, int[] filterPropertyValues, bool loadChild = false, bool getDeleted = false) where T : BaseSmartCoreObject, new()

        /// <summary>
        /// Делает запрос к БД и возвращает список объектов переданного типа
        /// </summary>
        /// <typeparam name="T">Тип объетов, которые необходимо вернуть из БД</typeparam>
        /// <param name="filterProperty">Свойство, по которомц нужно произвести фильтрацию</param>
        /// <param name="filterPropertyValues">Значения фильтруемого свойства</param>
        /// <param name="loadChild">Производить загрузку дочерних объектов (помеченных атрибутом Child). По умолчанию FALSE</param>
        /// <param name="getDeleted">Загружать недействительные записи. По умолчанию FALSE</param>
        /// <returns>Список объектов переданного типа</returns>
        public List<T> GetObjectListAll<T>(PropertyInfo filterProperty, int[] filterPropertyValues, bool loadChild = false, bool getDeleted = false) where T : BaseEntityObject, new()
        {
            _casEnvironment.CheckType(typeof(T));
			// возвращаем результат
			return (List<T>)GetObjectList(typeof(T), new ICommonFilter[] { new CommonFilter<int>(filterProperty, FilterType.In, filterPropertyValues) }, loadChild, getDeleted);
        }
        #endregion


	    public List<T> GetObjectListAll<T>(List<DbQuery> qrs, bool loadChild = false, bool getForced = false) where T : BaseEntityObject, new() 
	    {
			if (qrs == null)
				throw new ArgumentNullException("qrs", "не должен быть null");

			List<ExecutionResultArgs> resultArgses;
			var ds = _casEnvironment.Execute(qrs, out resultArgses);
			ExecutionResultArgs args = resultArgses.FirstOrDefault(r => r.Exception != null);
			if (args != null)
				throw args.Exception;
			return (List<T>)BaseQueries.GetObjectList(ds, loadChild, true, getForced);
		}

		public List<T> GetObjectListAll<T>(string qr, bool loadChild = false, bool getForced = false) where T : BaseEntityObject, new()
		{
			var ds = _casEnvironment.Execute(qr);
			return BaseQueries.GetObjectList<T>(ds.Tables[0], loadChild, getForced);
		}

		#region public List<T> GetObjectList<T>(IQueryFilter filter, bool loadChild = false, bool getDeleted = false) where T : BaseSmartCoreObject, new()
		/// <summary>
		/// Делает запрос к БД и возвращает список объектов переданного типа
		/// </summary>
		/// <typeparam name="T">Тип объетов, которые необходимо вернуть из БД</typeparam>
		/// <param name="filter">Фильтрация по определенному полю</param>
		/// <param name="loadChild">Производить загрузку дочерних объектов (помеченных атрибутом Child). По умолчанию FALSE</param>
		/// <param name="getDeleted">Загружать недействительные записи. По умолчанию FALSE</param>
		/// <returns>Список объектов переданного типа</returns>
		public List<T> GetObjectList<T>(ICommonFilter filter, bool loadChild = false, bool getDeleted = false) where T : BaseEntityObject, new()
        {
            // возвращаем результат
            return GetObjectList<T>(new[]{filter},loadChild,getDeleted);
        }
        #endregion

        #region public TV GetObjectCollection<T, TV>(IQueryFilter[] filters = null, bool loadChild = false, bool getDeleted = false) where T : BaseEntityObject, new() where TV : CommonCollection<T>, new()
        /// <summary>
        /// Возвращает из БД массив объектов типа Т, упакованных в коллекцию типа TV 
        /// </summary>
        /// <param name="filters">Фильтрация по определенным полям</param>
        /// <param name="loadChild">Производить загрузку дочерних объектов (помеченных атрибутом Child). По умолчанию FALSE</param>
        /// <param name="getDeleted">Загружать недействительные записи</param>
        /// <returns>коллекция типа TV,</returns>
        public TV GetObjectCollection<T, TV>(ICommonFilter[] filters = null, bool loadChild = false, bool getDeleted = false)
            where T : BaseEntityObject, new() 
            where TV : CommonCollection<T>, new()
        {
            _casEnvironment.CheckType(typeof(T));

			String qr = BaseQueries.GetSelectQueryWithWhere<T>(filters, loadChild, getDeleted);
            DataSet ds = _casEnvironment.Execute(qr);
            TV result = BaseQueries.GetObjectCollection<T, TV>(ds.Tables[0], loadChild);

            // возвращаем результат
            return result;
        }
        #endregion

        #region public TV GetObjectCollection<T, TV>(IQueryFilter filter, bool loadChild = false, bool getDeleted = false) where T : BaseEntityObject, new() where TV : CommonCollection<T>, new()
        /// <summary>
        /// Возвращает из БД массив объектов типа Т, упакованных в коллекцию типа TV 
        /// </summary>
        /// <param name="filter">Фильтрация по определенным полям</param>
        /// <param name="loadChild">Производить загрузку дочерних объектов (помеченных атрибутом Child). По умолчанию FALSE</param>
        /// <param name="getDeleted">Загружать недействительные записи</param>
        /// <returns>коллекция типа TV,</returns>
        public TV GetObjectCollection<T, TV>(ICommonFilter filter, bool loadChild = false, bool getDeleted = false)
            where T : BaseEntityObject, new()
            where TV : CommonCollection<T>, new()
        {
            return GetObjectCollection<T,TV>(new[] { filter }, loadChild, getDeleted);
        }
		#endregion

		#region public IList GetObjectList(Type type, IQueryFilter[]filters = null, bool loadChild = false, bool getDeleted = false)

		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <param name="filters">Фильтрация по определенным полям</param>
		/// <param name="loadChild">Производить загрузку дочерних объектов (помеченных атрибутом Child). По умолчанию FALSE</param>
		/// <param name="getDeleted">Загружать недействительные записи</param>
		/// <param name="getForced">Загружать поля, помеченные как принудительные</param>
		/// <param name="ignoreConditions">Игнорировать значения полей по умолчанию</param>
		/// <returns></returns>
		public IList GetObjectList(Type type, ICommonFilter[]filters = null, bool loadChild = false,
                                    bool getDeleted = false, bool getForced = false, bool ignoreConditions = false)
        {
            if (type == null)
                throw new ArgumentNullException("type", "не должен быть null");

            //Проверка, является ли переданный тип наследником BaseSmartCoreObject
            if (!type.IsSubclassOf(typeof(BaseEntityObject)))
            {
                throw new ArgumentException("type", "не является наследником " + typeof(BaseEntityObject).Name);
            }
            if (type.GetCustomAttributes(typeof(TableAttribute), false).Length <= 0)
            {
                throw new ArgumentException("не определен атрибут таблицы для хранения в БД", "type");
            }

            List<ExecutionResultArgs> resultArgses;
            List<DbQuery> qrs = BaseQueries.GetSelectQueryWithWhereAll(type, filters, loadChild, false, getDeleted, ignoreConditions:ignoreConditions);
            DataSet ds = _casEnvironment.Execute(qrs, out resultArgses);
            ExecutionResultArgs args = resultArgses.FirstOrDefault(r => r.Exception != null);
            if (args != null)
                throw args.Exception;
            IList result = BaseQueries.GetObjectList(ds, loadChild, true, getForced);

            // возвращаем результат
            return result;
        }
        #endregion

        #region public ICommonCollection GetObjectCollection(Type type, IQueryFilter[] filters = null, bool loadChild = false, bool getDeleted = false)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">Тип, объекты которого нужно загрузить</param>
        /// <param name="filters">Фильтрация по определенным полям</param>
        /// <param name="loadChild">Производить загрузку дочерних объектов (помеченных атрибутом Child). По умолчанию FALSE</param>
        /// <param name="getDeleted">Загружать недействительные записи</param>
        /// <param name="getForced">Загружать поля помеченные как принудительные</param>
        /// <param name="ignoreConditions">Задает значение, нежно ли игнорировать состояния объектов по умолчанию</param>
        /// <returns></returns>
        public ICommonCollection GetObjectCollection(Type type, ICommonFilter[] filters = null, 
                                                     bool loadChild = false, bool getDeleted = false, bool getForced = false,
                                                     bool ignoreConditions = false)
        {
            if (type == null)
                throw new ArgumentNullException("type", "не должен быть null");

            //Проверка, является ли переданный тип наследником BaseSmartCoreObject
            if (!type.IsSubclassOf(typeof(BaseEntityObject)))
            {
                throw new ArgumentException("type", "не является наследником " + typeof(BaseEntityObject).Name);
            }
            if (type.GetCustomAttributes(typeof(TableAttribute), false).Length <= 0)
            {
                throw new ArgumentException("не определен атрибут таблицы для хранения в БД", "type");
            }

            List<ExecutionResultArgs> resultArgses;
            List<DbQuery> qrs = BaseQueries.GetSelectQueryWithWhereAll(type, filters, loadChild, false, getDeleted, ignoreConditions:ignoreConditions);
            DataSet ds = _casEnvironment.Execute(qrs, out resultArgses);
            if (resultArgses.Count(r => r.Exception != null) > 0)
                throw resultArgses.First(r => r.Exception != null).Exception;
            ICommonCollection result = BaseQueries.GetObjectCollection(ds, loadChild, true, getForced);

            // возвращаем результат
            return result;
        }
        #endregion

        #region public ICommonCollection<T> GetObjectCollection<T>(IQueryFilter filter, bool loadChild = false, bool getDeleted = false) where T : BaseEntityObject, new() where TV : CommonCollection<T>, new()
        /// <summary>
        /// Возвращает из БД массив объектов типа Т, упакованных в коллекцию типа ICommonCollectionT 
        /// </summary>
        /// <param name="filter">Фильтрация по определенным полям</param>
        /// <param name="loadChild">Производить загрузку дочерних объектов (помеченных атрибутом Child). По умолчанию FALSE</param>
        /// <param name="getDeleted">Загружать недействительные записи</param>
        /// <returns>ICommonCollectionT ,</returns>
        public ICommonCollection<T> GetObjectCollection<T>(ICommonFilter filter, bool loadChild = false, bool getDeleted = false)
            where T : BaseEntityObject, new()
        {
            return GetObjectCollection<T, CommonCollection<T>>(new[] { filter }, loadChild, getDeleted);
        }
        #endregion

        #region public ICommonCollection<T> GetObjectCollection<T>(IQueryFilter[] filters, bool loadChild = false, bool getDeleted = false) where T : BaseEntityObject, new() where TV : CommonCollection<T>, new()
        /// <summary>
        /// Возвращает из БД массив объектов типа Т, упакованных в коллекцию типа ICommonCollectionT 
        /// </summary>
        /// <param name="filters">Фильтрация по определенным полям</param>
        /// <param name="loadChild">Производить загрузку дочерних объектов (помеченных атрибутом Child). По умолчанию FALSE</param>
        /// <param name="getDeleted">Загружать недействительные записи</param>
        /// <returns>ICommonCollectionT ,</returns>
        public ICommonCollection<T> GetObjectCollection<T>(ICommonFilter[] filters = null, bool loadChild = false, bool getDeleted = false)
            where T : BaseEntityObject, new()
        {
            return GetObjectCollection<T, CommonCollection<T>>(filters, loadChild, getDeleted);
        }
		#endregion

		#region public T GetPerformances<T>(SmartCoreType parentType, int parentId, bool lastOnly = false) where T : AbstractPerformanceRecord, new()
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T">Тип записей (DirectiveRecord, MaintenanceCheckRecord и т.д.)</typeparam>
		/// <param name="parentType">Тип родителя (Directive, ComponentDirective, MaintenanceCheck и т.д.)</param>
		/// <param name="parentId">Идентификатор родителя</param>
		/// <param name="lastOnly">True - грузится только последняя запись о выполнении</param>
		/// <returns></returns>
		public T GetPerformances<T>(SmartCoreType parentType, int parentId, bool lastOnly = false) where T : AbstractPerformanceRecord, new()
        {
            String qr = BaseQueries.GetPerformancesQuery<T>(parentType, parentId, lastOnly);
            DataSet ds = _casEnvironment.Execute(qr);
            T result = BaseQueries.GetObjectList<T>(ds.Tables[0])[0];

            // возвращаем результат
            return result;
        }
		#endregion

		#region public int GetCountPerformanceRecords<T>(SmartCoreType parentType, int parentId) where T : AbstractPerformanceRecord

		/// <summary>
		/// Возвращает количество записей о выполнении
		/// </summary>
		/// <typeparam name="T">Тип записей (DirectiveRecord, MaintenanceCheckRecord и т.д.)</typeparam>
		/// <param name="parentType">Тип родителя (Directive, ComponentDirective, MaintenanceCheck)</param>
		/// <param name="parentId"></param>
		/// <returns></returns>
		public int GetCountPerformanceRecords<T>(SmartCoreType parentType, int parentId) where T : AbstractPerformanceRecord
        {
            String qr = BaseQueries.GetCountPerformancesQuery<T>(parentType,parentId);
            DataSet ds = _casEnvironment.Execute(qr);
            int result = (int)ds.Tables[0].Rows[0][0];
            // возвращаем результат
            return result;   
        }
        #endregion

        /*
         * Директивы летной годности
         */


        /*
         * Audits
         */

        /*
         * 
         */
		/*
        /  KITs
        */

		//TODO!!!! метод временный. Создан для обновления словарей в кэше. Подумать над новым подходом загрузки словарей
		#region public void ReloadDictionary(params Type[] types)
		
		public void ReloadDictionary(params Type[] types)
	    {
		    foreach (var type in types)
		    {
			    var reloadedDict = GetObjectList(type, loadChild: true);

			    var dict = _casEnvironment.GetDictionary(type);
			    dict.Clear();

			    foreach (AbstractDictionary dictionary in reloadedDict)
				    dict.Add(dictionary);
		    }
	    }

	    #endregion

		/*
         * Связь с ядром
         */

		/*
         * Загрузка данных 
         */

		// Вначале

		//

		// Компоненты

		// Работы 

		// Воздушное судно

		// Полеты воздушного судна

		/*
         * Загрузка связанных данных
         */

		// Загрузка математического аппарата - загрузка данных для воздушных судов и базовых агрегатов

		// Компоненты

		// Борт журнал воздушного судна

		/*
         * Полная загрузка элементов
         */

		// Базовый агрегат

		// Агрегат

		// Директива

		/*
         * Реализация 
         */

		/*
         * Поставщики
         */

		/*
         * Программа по обслуживанию
         */

		/*
         * Maintenance
         */

		/*
         * Cas3Maintenance
         */

	}
}