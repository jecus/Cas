using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SmartCore.Aircrafts;
using SmartCore.Component;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Filters;
using SmartCore.Queries;

namespace SmartCore.Packages
{

    public interface IPackageCore
    {
        void DeleteFromDirectivePackage<T, TV>(IEnumerable<IBaseEntityObject> directives, T directivePackage)
            where T : AbstractDirectivePackage<TV>, new()
            where TV : BaseDirectivePackageRecord, new();

        void DeleteFromPackage<T, TV>(IEnumerable<IBaseEntityObject> directives, T directivePackage)
            where T : AbstractPackage<TV>, new()
            where TV : BasePackageRecord, new();

        T GetDirectivePackage<T, TV>(int itemId, bool loadWorkPackageItems = false)
            where T : AbstractDirectivePackage<TV>, new()
            where TV : BaseDirectivePackageRecord, new();

        List<T> GetDirectivePackages<T, TV>(BaseEntityObject parent = null,
                                            WorkPackageStatus[] statuses = null,
                                            bool loadWorkPackageItems = false,
                                            ICommonCollection includedTasks = null)
            where T : AbstractDirectivePackage<TV>, new()
            where TV : BaseDirectivePackageRecord, new();

        List<T> GetPackages<T, TV>(BaseEntityObject parent = null,
                                   WorkPackageStatus[] statuses = null,
                                   bool loadWorkPackageItems = false,
                                   BaseEntityObject[] includedTasks = null)
            where T : AbstractPackage<TV>, new()
            where TV : BasePackageRecord, new();

        void LoadDirectivePackageItems<T, TV>(T package)
            where T : AbstractDirectivePackage<TV>, new()
            where TV : BaseDirectivePackageRecord, new();

        void LoadPackageItems<T, TV>(T package)
            where T : AbstractPackage<TV>, new()
            where TV : BasePackageRecord, new();

        void Publish<T, TV>(T wp, DateTime date, String remarks)
            where T : AbstractDirectivePackage<TV>, new()
            where TV : BaseDirectivePackageRecord, new();


        void PublishPackage<T, TV>(T wp, DateTime date, String remarks = "")
            where T : AbstractPackage<TV>, new()
            where TV : BasePackageRecord, new();

        void SetParents(IPackage package);
    }


    /// <summary>
    /// Ядро пакетов
    /// </summary>
    public class PackagesCore : IPackageCore
    {
        private readonly ICasEnvironment _casEnvironment;
	    private readonly INewKeeper _newKeeper;
	    private readonly ILoader _loader;
	    private readonly IAircraftsCore _aircraftsCore;
	    private readonly IComponentCore _componentCore;

	    /// <summary>
		/// Создает Сурвис закупок
		/// </summary>
		public PackagesCore(ICasEnvironment casEnvironment, INewKeeper newKeeper,
							ILoader loader, IAircraftsCore aircraftsCore, IComponentCore componentCore)
        {
            _casEnvironment = casEnvironment;
		    _newKeeper = newKeeper;
		    _loader = loader;
		    _aircraftsCore = aircraftsCore;
		    _componentCore = componentCore;
        }

        /// <summary>
        /// Удаляет запись из рабочего пакета
        /// </summary>
        /// <param name="directives"></param>
        /// <param name="directivePackage"></param>
        public void DeleteFromDirectivePackage<T, TV>(IEnumerable<IBaseEntityObject> directives, T directivePackage)
            where T : AbstractDirectivePackage<TV>, new()
            where TV : BaseDirectivePackageRecord, new()
        {
            foreach (IBaseEntityObject directive in directives)
            {
                TV wpRecord = directivePackage.PackageRecords.FirstOrDefault(wpr => wpr.DirectiveId == directive.ItemId &&
                                                                                   wpr.PackageItemType == directive.SmartCoreObjectType);
                if (wpRecord == null)
                {
                    wpRecord = _loader.GetObject<TV>(
                        new ICommonFilter[]
                        {
                            new CommonFilter<int>(BaseDirectivePackageRecord.DirectiveIdProperty, directive.ItemId),
                            new CommonFilter<int>(BaseDirectivePackageRecord.PackageItemTypeProperty,directive.SmartCoreObjectType.ItemId),
                            new CommonFilter<int>(BaseDirectivePackageRecord.ParentIdProperty, directivePackage.ItemId)
                        });
                }

                if (wpRecord != null)
                {
                    _casEnvironment.Manipulator.Delete(wpRecord);
                    directivePackage.PackageRecords.Remove(wpRecord);
                }
            }
        }

        /// <summary>
        /// Удаляет запись из пакета элементов
        /// </summary>
        /// <param name="directives"></param>
        /// <param name="directivePackage"></param>
        public void DeleteFromPackage<T, TV>(IEnumerable<IBaseEntityObject> directives, T directivePackage)
            where T : AbstractPackage<TV>, new()
            where TV : BasePackageRecord, new()
        {
            foreach (IBaseEntityObject directive in directives)
            {
                TV wpRecord = directivePackage.PackageRecords.FirstOrDefault(wpr => wpr.PackageItemId == directive.ItemId &&
                                                                                    wpr.PackageItemType == directive.SmartCoreObjectType);
                if (wpRecord == null)
                {
                    wpRecord = _loader.GetObject<TV>(
                        new ICommonFilter[]
                        {
                            new CommonFilter<int>(BasePackageRecord.PackageItemIdProperty, directive.ItemId),
                            new CommonFilter<int>(BasePackageRecord.PackageItemTypeProperty,directive.SmartCoreObjectType.ItemId),
                            new CommonFilter<int>(BasePackageRecord.ParentPackageIdProperty, directivePackage.ItemId)
                        });
                }

                if (wpRecord != null)
                {
                    _casEnvironment.Manipulator.Delete(wpRecord);
                    directivePackage.PackageRecords.Remove(wpRecord);
                }
            }
        }
        
        /// <summary>
        /// Возвращает пакеты задач для определенного родителя (воздушного судна, оператора и т.д.)
        /// </summary>
        /// <param name="parent">Родитель. При пережаче null вернет все пакеты задач переданного типа</param>
        /// <param name="statuses">Фильтр статуса рабочего пакета. (По умолчанию = null)</param>
        /// <param name="loadWorkPackageItems">Флаг загрузки элементов рабочих пакетов</param>
        /// <param name="includedTasks">Задачи, которые должны содержать пакеты (при передаче пустои коллекции запрос вернет 0 рабочих пакетов)</param>
        /// <returns></returns>
        public List<T> GetPackages<T, TV>(BaseEntityObject parent = null,
                                          WorkPackageStatus[] statuses = null,
                                          bool loadWorkPackageItems = false,
                                          BaseEntityObject[] includedTasks = null)
            where T : AbstractPackage<TV>, new()
            where TV : BasePackageRecord, new()
        {

            List<ICommonFilter> filters = new List<ICommonFilter>();

            if (includedTasks != null)
            {
                if (includedTasks.Length == 0 || includedTasks.Count(t => t != null) == 0)
                {
                    //Строка запроса, выдающая идентификаторы пакетов задач
                    string recordsParentId = BaseQueries.GetSelectQueryColumnOnly<TV>
                        (BaseDirectivePackageRecord.ParentIdProperty, new ICommonFilter[] 
                         {
                             new CommonFilter<int>(BasePackageRecord.PackageItemTypeProperty, 0), 
                             new CommonFilter<int>(BasePackageRecord.PackageItemIdProperty, 0) 
                         }
                        );
                    //Фильтр по ключевому полю таблицы обозначающий 
                    //что значения ключевого поля таблицы должны быть
                    //среди идентификаторов пакетов задач
                    ICommonFilter idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty,
                                                                      FilterType.In,
                                                                      new[] { recordsParentId });

                    filters.Add(idFilter);
                }
                else
                {
                    Dictionary<int, string> subs = new Dictionary<int, string>();
                    foreach (BaseEntityObject task in includedTasks.Where(t => t != null))
                    {
                        if (subs.ContainsKey(task.SmartCoreObjectType.ItemId))
                        {
                            string s = subs[task.SmartCoreObjectType.ItemId];
                            if (s != "")
                                s += ", ";

                            s += task.ItemId;
                            subs[task.SmartCoreObjectType.ItemId] = s;
                        }
                        else subs.Add(task.SmartCoreObjectType.ItemId, task.ItemId.ToString(CultureInfo.InvariantCulture));
                    }

                    string filterString = "";
                    foreach (KeyValuePair<int, string> sub in subs)
                    {
                        if (filterString != "") filterString += "\n or";
                        filterString += string.Format("(PackageItemTypeId = {0} and PackageItemId in ({1}))", sub.Key, sub.Value);
                    }

                    //Строка запроса, выдающая идентификаторы пакетов задач
                    string recordsParentId =
                        BaseQueries.GetSelectQueryColumnOnly<TV>
                        (BasePackageRecord.PackageItemIdProperty, new ICommonFilter[] { new CommonFilter<string>(null, FilterType.In, new[] { filterString }) });
                    //Фильтр по ключевому полю таблицы обозначающий 
                    //что значения ключевого поля таблицы должны быть
                    //среди идентификаторов пакетов задач
                    ICommonFilter idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty,
                                                                      FilterType.In,
                                                                      new[] { recordsParentId });

                    filters.Add(idFilter);
                }
            }
            if (parent != null)
            {
                filters.Add(new CommonFilter<int>(AbstractPackage<TV>.ParentIdProperty, parent.ItemId));
                filters.Add(new CommonFilter<SmartCoreType>(AbstractPackage<TV>.ParentTypeIdProperty, parent.SmartCoreObjectType));
            }
            if (statuses != null && statuses.Length > 0)
            {
                filters.Add(new CommonFilter<WorkPackageStatus>(AbstractPackage<TV>.StatusProperty, FilterType.In, statuses));
            }
            List<T> wps = _loader.GetObjectList<T>(filters.ToArray(), true);

            if (!loadWorkPackageItems) 
                return wps;
            foreach (T wp in wps)
            {
                //Обратная ссылка на родительский объект
                //загрузка элементов рабочих пакетов (если требуется)
                LoadPackageItems<T, TV>(wp);
            }
            return wps;
        }

        /// <summary>
        /// Загружает все элементы рабочего пакета
        /// </summary>
        /// <param name="package"></param>
        public void LoadPackageItems<T, TV>(T package)
            where T : AbstractPackage<TV>, new()
            where TV : BasePackageRecord, new()
        {
            // Компоненты
            package.PackageRecords.Clear();
            package.PackageRecords.AddRange(_loader.GetObjectListAll<TV>(BasePackageRecord.ParentPackageIdProperty, package.ItemId));
            foreach (TV record in package.PackageRecords)
                record.ParentPackage = package;

            IEnumerable<IGrouping<SmartCoreType, TV>> groupedRecordsByTaskType =
                package.PackageRecords
                .Where(pr => pr.PackageItemType != SmartCoreType.Unknown)
                .GroupBy(pr => pr.PackageItemType);

            foreach (IGrouping<SmartCoreType, TV> groupedRecords in groupedRecordsByTaskType)
            {
                if (groupedRecords.Key.ObjectType == null)
                    continue;

                Type objectType = groupedRecords.Key.ObjectType;

                ICommonFilter filter =
                   new CommonFilter<int>(BaseEntityObject.ItemIdProperty,
                                         FilterType.In,
                                         groupedRecords.Select(wpr => wpr.PackageItemId).ToArray());

                IList directiveCollection = _loader.GetObjectList(objectType, new[] { filter }, true, true, ignoreConditions: true);

                if (directiveCollection.Count > 0)
                {
                    foreach (TV adWpr in groupedRecords)
                    {
                        BaseEntityObject d = directiveCollection
                            .OfType<BaseEntityObject>()
                            .FirstOrDefault(i => i.ItemId == adWpr.PackageItemId);
                        if (d != null)
                            adWpr.PackageItem = d;
                        else
                        {
                            package.PackageRecords.RemoveById(adWpr.ItemId);
                        }
                    }
                }
            }
            // ставим флаг о том, что все элементы рабочего пакета считаны
            package.PackageItemsLoaded = true;
        }

        public void SetParents(IPackage package)
        {
            if (package.Parent == null && package.ParentId > 0)
            {
                if (package.ParentType == SmartCoreType.Aircraft)
                    package.Parent = _aircraftsCore.GetAircraftById(package.ParentId);
                else if (package.ParentType == SmartCoreType.Store)
                    package.Parent = _casEnvironment.Stores.GetItemById(package.ParentId);
                else if (package.ParentType == SmartCoreType.Operator)
                    package.Parent = _casEnvironment.Operators.GetItemById(package.ParentId);

                if (package.Parent == null)
                    package.Parent = _casEnvironment.Operators[0];
            }
        }

        /// <summary>
        /// Публикует рабочий пакет - выдает рабочий пакет на перрон
        /// </summary>
        /// <param name="wp"></param>
        /// <param name="date"></param>
        /// <param name="remarks"></param>
        public void Publish<T, TV>(T wp, DateTime date, string remarks)
            where T : AbstractDirectivePackage<TV>, new()
            where TV : BaseDirectivePackageRecord, new()
        {
            if (wp.Status != WorkPackageStatus.Closed)
            {
                wp.Status = WorkPackageStatus.Published;
                wp.PublishingDate = date;
                wp.PublishedBy = _casEnvironment.IdentityUser.Login;
                wp.Remarks = remarks;
            }
            else
            {
                LoadDirectivePackageItems<T, TV>(wp);

                foreach (IDirective item in wp.PackageRecords.Where(pr => pr.Task != null).Select(pr => pr.Task))
                {
                    var records = new List<AbstractPerformanceRecord>(item.PerformanceRecords.OfType<AbstractPerformanceRecord>().ToArray());
                    foreach (AbstractPerformanceRecord record in records)
                    {
                        if (record.DirectivePackageId == wp.ItemId)
                            _casEnvironment.Manipulator.Delete(record);
                    }
                }

                wp.Status = WorkPackageStatus.Published;
                wp.PublishingDate = date;
                wp.PublishedBy = _casEnvironment.IdentityUser.Login;
                wp.ClosedBy = "";
            }

	        _newKeeper.Save(wp);
        }

        /// <summary>
        /// Возвращает пакеты задач для определенного родителя (воздушного судна, оператора и т.д.)
        /// </summary>
        /// <param name="itemId">Идентификатор пакета задач</param>
        /// <param name="loadWorkPackageItems">Флаг загрузки элементов рабочих пакетов</param>
        /// <returns></returns>
        public T GetDirectivePackage<T, TV>(int itemId, bool loadWorkPackageItems = false)
            where T : AbstractDirectivePackage<TV>, new()
            where TV : BaseDirectivePackageRecord, new()
        {
            T directivePackage = _loader.GetObject<T>(itemId, loadWorkPackageItems, loadDeleted: true);
            if (directivePackage == null)
                return null;
            //загрузка элементов рабочих пакетов (если требуется)
            if (loadWorkPackageItems)
                LoadDirectivePackageItems<T, TV>(directivePackage);
            return directivePackage;
        }

        /// <summary>
        /// Возвращает пакеты задач для определенного родителя (воздушного судна, оператора и т.д.)
        /// </summary>
        /// <param name="parent">Родитель. При пережаче null вернет все пакеты задач переданного типа</param>
        /// <param name="statuses">Фильтр статуса рабочего пакета. (По умолчанию = null)</param>
        /// <param name="loadWorkPackageItems">Флаг загрузки элементов рабочих пакетов</param>
        /// <param name="includedTasks">Задачи, которые должны содержать пакеты (при передаче пустои коллекции запрос вернет 0 рабочих пакетов)</param>
        /// <returns></returns>
        public List<T> GetDirectivePackages<T, TV>(BaseEntityObject parent = null,
                                                   WorkPackageStatus[] statuses = null,
                                                   bool loadWorkPackageItems = false,
                                                   ICommonCollection includedTasks = null)
            where T : AbstractDirectivePackage<TV>, new()
            where TV : BaseDirectivePackageRecord, new()
        {

            List<ICommonFilter> filters = new List<ICommonFilter>();

            if (includedTasks != null)
            {
                if (includedTasks.Count == 0)
                {
                    //Строка запроса, выдающая идентификаторы пакетов задач
                    string recordsParentId = BaseQueries.GetSelectQueryColumnOnly<TV>
                        (BaseDirectivePackageRecord.ParentIdProperty, new ICommonFilter[] 
                         {
                             new CommonFilter<int>(BaseDirectivePackageRecord.PackageItemTypeProperty, 0), 
                             new CommonFilter<int>(BaseDirectivePackageRecord.ParentIdProperty, 0) 
                         }
                        );
                    //Фильтр по ключевому полю таблицы обозначающий 
                    //что значения ключевого поля таблицы должны быть
                    //среди идентификаторов пакетов задач
                    ICommonFilter idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty,
                                                                      FilterType.In,
                                                                      new[] { recordsParentId });

                    filters.Add(idFilter);
                }
                else
                {
                    Dictionary<int, string> subs = new Dictionary<int, string>();
                    foreach (BaseEntityObject task in includedTasks)
                    {
                        if (subs.ContainsKey(task.SmartCoreObjectType.ItemId))
                        {
                            string s = subs[task.SmartCoreObjectType.ItemId];
                            if (s != "")
                                s += ", ";

                            s += task.ItemId;
                            subs[task.SmartCoreObjectType.ItemId] = s;
                        }
                        else subs.Add(task.SmartCoreObjectType.ItemId, task.ItemId.ToString());
                    }
                    string filterString = "";
                    foreach (KeyValuePair<int, string> sub in subs)
                    {
                        if (filterString != "") filterString += "\n or";
                        filterString += string.Format("(PackageItemType = {0} and DirectivesId in ({1}))", sub.Key, sub.Value);
                    }

                    //Строка запроса, выдающая идентификаторы пакетов задач
                    string recordsParentId =
                        BaseQueries.GetSelectQueryColumnOnly<TV>
                        (BaseDirectivePackageRecord.ParentIdProperty, new ICommonFilter[] { new CommonFilter<string>(null, FilterType.In, new[] { filterString }) });
                    //Фильтр по ключевому полю таблицы обозначающий 
                    //что значения ключевого поля таблицы должны быть
                    //среди идентификаторов пакетов задач
                    ICommonFilter idFilter = new CommonFilter<string>(BaseEntityObject.ItemIdProperty,
                                                                      FilterType.In,
                                                                      new[] { recordsParentId });

                    filters.Add(idFilter);
                }
            }
            if (parent != null)
            {
                filters.Add(new CommonFilter<int>(AbstractDirectivePackage<TV>.ParentIdProperty, parent.ItemId));
                filters.Add(new CommonFilter<SmartCoreType>(AbstractDirectivePackage<TV>.ParentTypeIdProperty, parent.SmartCoreObjectType));
            }
            if (statuses != null && statuses.Length > 0)
            {
                filters.Add(new CommonFilter<WorkPackageStatus>(AbstractDirectivePackage<TV>.StatusProperty, FilterType.In, statuses));
            }
            List<T> wps = _loader.GetObjectListAll<T>(filters.ToArray());

            foreach (T wp in wps)
            {
                //Обратная ссылка на родительский самолет
                wp.Parent = parent;
                //загрузка элементов рабочих пакетов (если требуется)
                if (loadWorkPackageItems)
                    LoadDirectivePackageItems<T, TV>(wp);
            }
            return wps;
        }

        /// <summary>
        /// Загружает все элементы рабочего пакета
        /// </summary>
        /// <param name="package"></param>
        public void LoadDirectivePackageItems<T, TV>(T package)
            where T : AbstractDirectivePackage<TV>, new()
            where TV : BaseDirectivePackageRecord, new()
        {
            package.CanPublish = package.CanClose = true;
            package.BlockPublishReason = "";
            package.MinClosingDate = null;
            package.MaxClosingDate = null;
            // Компоненты
            package.PackageRecords.Clear();
            package.PackageRecords.AddRange(_loader.GetObjectListAll<TV>(BaseDirectivePackageRecord.ParentIdProperty, package.ItemId));
            foreach (TV record in package.PackageRecords)
                record.ParentPackage = package;

            IEnumerable<IGrouping<SmartCoreType, TV>> groupedRecordsByTaskType =
                package.PackageRecords.GroupBy(pr => pr.PackageItemType);

            foreach (IGrouping<SmartCoreType, TV> groupedRecords in groupedRecordsByTaskType)
            {
                #region загрузка Базовых деталей
                if (groupedRecords.Key == SmartCoreType.BaseComponent)
                {
                    foreach (TV adWpr in groupedRecords)
                    {
                        IDirective d = _componentCore.GetBaseComponentById(adWpr.DirectiveId);
                        if (d != null)
                            adWpr.Task = d;
                        else package.PackageRecords.RemoveById(adWpr.ItemId);
                    }
                    continue;
                }
                #endregion

                if (groupedRecords.Key.ObjectType == null)
                    continue;

                Type objectType = groupedRecords.Key.ObjectType;

                ICommonFilter filter =
                   new CommonFilter<int>(BaseEntityObject.ItemIdProperty,
                                         FilterType.In,
                                         groupedRecords.Select(wpr => wpr.DirectiveId).ToArray());

                ICommonCollection directiveCollection = _loader.GetObjectCollection(objectType, new[] { filter }, true, true);

                if (directiveCollection.Count > 0)
                {
                    foreach (TV adWpr in groupedRecords)
                    {
                        IDirective d = directiveCollection.GetItemById(adWpr.DirectiveId) as IDirective;
                        if (d != null)
                            adWpr.Task = d;
                        else
                        {
                            package.PackageRecords.RemoveById(adWpr.ItemId);
                        }
                    }
                }
            }
            // ставим флаг о том, что все элементы рабочего пакета считаны
            package.PackageItemsLoaded = true;
        }

        /// <summary>
        /// Публикует пакет
        /// </summary>
        /// <param name="wp"></param>
        /// <param name="date"></param>
        /// <param name="remarks"></param>
        public void PublishPackage<T, TV>(T wp, DateTime date, String remarks = "")
            where T : AbstractPackage<TV>, new()
            where TV : BasePackageRecord, new()
        {
            if (wp.Status != WorkPackageStatus.Closed)
            {
                wp.Status = WorkPackageStatus.Published;
                wp.PublishingDate = date;
                //wp.PublishedBy = _casEnvironment.IdentityUser.Login;
                wp.Remarks = remarks;
            }
            else
            {
                wp.Status = WorkPackageStatus.Published;
                wp.PublishingDate = date;
                //wp.PublishedBy = _casEnvironment.IdentityUser.Login;
                //wp.ClosedBy = "";
            }

	        _newKeeper.Save(wp);
        }
    }
}
