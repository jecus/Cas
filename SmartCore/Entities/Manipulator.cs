using System.Linq;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.AircraftFlights;
using SmartCore.Aircrafts;
using SmartCore.AuditMongo.Repository;
using SmartCore.Component;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Store;
using SmartCore.Maintenance;
using SmartCore.Purchase;
using SmartCore.Relation;
using SmartCore.WorkPackages;

namespace SmartCore.Entities
{
    /// <summary>
    /// Класс обеспечивает легкое сохранение и создание объектов Cas
    /// </summary>
    public class Manipulator : IManipulator
    {

        /*
         * Связь с ядром
        */
        private IPurchaseCore _purchaseCore;
		private IMaintenanceCore _maintenanceCore;
		private IWorkPackageCore _workPackageCore;
		private IAircraftFlightCore _aircraftFlightCore;
		private IComponentCore _componentCore;
		private IAircraftsCore _aircraftsCore;
		private IBindedItemsCore _bindedItemCore;

		public IPurchaseCore PurchaseService
        {
            get { return _purchaseCore; }
            set { _purchaseCore = value; }
        }

	    public IMaintenanceCore MaintenanceCore
	    {
		    get { return _maintenanceCore; }
		    set { _maintenanceCore = value; }
	    }

	    public IWorkPackageCore WorkPackageCore
	    {
		    get { return _workPackageCore; }
		    set { _workPackageCore = value; }
	    }

	    public IAircraftFlightCore AircraftFlightCore
	    {
		    get { return _aircraftFlightCore; }
		    set { _aircraftFlightCore = value; }
	    }

	    public IComponentCore ComponentCore
	    {
		    get { return _componentCore; }
		    set { _componentCore = value; }
	    }

	    public IAircraftsCore AircraftsCore
	    {
		    get { return _aircraftsCore; }
		    set { _aircraftsCore = value; }
	    }

	    public IBindedItemsCore BindedItemCore
	    {
		    get { return _bindedItemCore; }
		    set { _bindedItemCore = value; }
	    }

	    #region public CasEnvironment CasEnvironment { get; }
        /// <summary>
        /// Ядро, с которым связан манипулятор
        /// </summary>
        private readonly ICasEnvironment _casEnvironment;

        private readonly IAuditRepository _auditRepository;

        /// <summary>
        /// Ядро, с которым связан манипулятор
        /// </summary>
        private ICasEnvironment CasEnvironment { get { return _casEnvironment; } }
        #endregion

        #region public Manipulator(CasEnvironment casEnvironment)

        /// <summary>
        /// Класс обеспечивает легкое сохранение и создание объектов Cas
        /// </summary>
        /// <param name="casEnvironment"></param>
        public Manipulator(ICasEnvironment casEnvironment, IAuditRepository auditRepository)
        {
	        _casEnvironment = casEnvironment;
	        _auditRepository = auditRepository;
        }

        #endregion

        /*
         * Глобальные коллекции
         */

        #region public void Save(BaseSmartCoreObject saveObject)
        public void Save(BaseEntityObject saveObject)
        {
            if(saveObject == null) return;

            var type = AuditOperation.Created;
            if (saveObject.ItemId > 0)
	            type = AuditOperation.Changed;

			CasEnvironment.Keeper.Save(saveObject);
			_auditRepository.WriteAsync(saveObject, type, _casEnvironment.IdentityUser);

			if (saveObject is AbstractDictionary)
            {
                IDictionaryCollection col = CasEnvironment.GetDictionary(saveObject.GetType());

                if (col == null) return;
                AbstractDictionary dict = (AbstractDictionary)col.GetItemById(saveObject.ItemId);
                if (dict == null || saveObject.ItemId != dict.ItemId)
                {
                    col.Add(saveObject);
                }
                else
                {
                    dict.SetProperties((AbstractDictionary)saveObject);   
                }
            }
            if (saveObject is Store)
            {
                Store o = CasEnvironment.Stores.GetItemById(saveObject.ItemId);
                if (o == null || saveObject.ItemId != o.ItemId)
                {
                    CasEnvironment.Stores.Add((Store)saveObject);
                }
            }
            if (saveObject is BaseComponent)
            {
                BaseComponent o = _componentCore.GetBaseComponentById(saveObject.ItemId);
                if (o == null || saveObject.ItemId != o.ItemId)
                {
                    CasEnvironment.BaseComponents.Add((BaseComponent)saveObject);
                }
            }
        }
        #endregion

        #region public void SaveAll(BaseEntityObject saveObject, bool saveChild = false, bool saveForced = false)

        /// <summary>
        /// Новый метод для сохранения объектов
        /// </summary>
        /// <param name="saveObject">Сохраняемый объект</param>
        /// <param name="saveChild">Сохранять дочерние объекты</param>
        /// <param name="saveForced">Сохранять свойтсва, помеченные как "принудительные"</param>
        public void SaveAll(BaseEntityObject saveObject, bool saveChild = false, bool saveForced = false)
        {
            if (saveObject == null) return;

			CasEnvironment.Keeper.SaveAll(saveObject, saveChild, saveForced);

			if (saveObject is AbstractDictionary)
            {
                IDictionaryCollection col = CasEnvironment.GetDictionary(saveObject.GetType());

                if (col == null) return;
                AbstractDictionary dict = (AbstractDictionary)col.GetItemById(saveObject.ItemId);
                if (dict == null || saveObject.ItemId != dict.ItemId)
                {
                    col.Add(saveObject);
                }
                else
                {
                    dict.SetProperties((AbstractDictionary)saveObject);
                }
            }
            if (saveObject is Store)
            {
                Store o = CasEnvironment.Stores.GetItemById(saveObject.ItemId);
                if (o == null || saveObject.ItemId != o.ItemId)
                {
                    CasEnvironment.Stores.Add((Store)saveObject);
                }
            }
            if (saveObject is BaseComponent)
            {
                BaseComponent o = _componentCore.GetBaseComponentById(saveObject.ItemId);
                if (o == null || saveObject.ItemId != o.ItemId)
                {
                    CasEnvironment.BaseComponents.Add((BaseComponent)saveObject);
                }
            }
        }
		#endregion

		#region public void Save(AbstractPerformanceRecord performance, bool saveAttachedFile = true)

		/// <summary>
		/// Добавить выполнение работы к задаче
		/// </summary>
		/// <param name="performance"></param>
		/// <param name="saveAttachedFile"></param>
		public void Save(AbstractPerformanceRecord performance, bool saveAttachedFile = true)
        {
            if(performance == null)
                return;

            var type = AuditOperation.Created;
            if (performance.ItemId > 0)
	            type = AuditOperation.Changed;
            
			_casEnvironment.Keeper.Save(performance, saveAttachedFile);
			_auditRepository.WriteAsync(performance, type, _casEnvironment.IdentityUser);

			if (performance.Parent.PerformanceRecords.GetItemById(performance.ItemId) == null)
                performance.Parent.PerformanceRecords.Add(performance);

            if (performance.Parent is MaintenanceDirective)
            {
				DirectiveRecord ddr = _casEnvironment.NewLoader.GetObjectListAll<DirectiveRecordDTO, DirectiveRecord>(new Filter("MaintenanceDirectiveRecordId", performance.ItemId)).FirstOrDefault();

				if (ddr != null)
                {
                    ComponentDirective dd = _casEnvironment.NewLoader.GetObject<ComponentDirectiveDTO,ComponentDirective>(new Filter("ItemId", ddr.ParentId));
                    if(dd != null)
                    {
                        BaseComponent bd = _componentCore.GetBaseComponentById(dd.ComponentId);
                        if(bd != null)
                        {
                            ddr.OnLifelength = 
                                _casEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(bd,performance.RecordDate);
                        }
                        else
                        {
                            General.Accessory.Component d = _componentCore.GetComponentById(dd.ComponentId);
                            if(d != null)
                            {
                                ddr.OnLifelength = _casEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(d, performance.RecordDate);
                            }
                        }
                    }
                    ddr.RecordDate = performance.RecordDate;
                    _casEnvironment.NewKeeper.Save(ddr, saveAttachedFile);
                }
            }
            else if (performance.Parent is ComponentDirective)
            {
                DirectiveRecord ddr = performance as DirectiveRecord;
                if (ddr != null)
                {
                    DirectiveRecord mpdRecord = _casEnvironment.NewLoader.GetObject<DirectiveRecordDTO, DirectiveRecord>(new Filter("ItemId", ddr.MaintenanceDirectiveRecordId));
                    if (mpdRecord != null)
                    {
                        MaintenanceDirective md = _maintenanceCore.GetMaintenanceDirective(mpdRecord.ParentId);
                        if (md != null)
                            mpdRecord.OnLifelength = _casEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(md.ParentBaseComponent, ddr.RecordDate);
                        mpdRecord.RecordDate = ddr.RecordDate;
                        _casEnvironment.NewKeeper.Save(mpdRecord, saveAttachedFile);
                    }
                }
            }
        }
        #endregion

        /*
         * Воздушное судно и склад
         */


		/*
         * Агрегаты
         */

		/*
         * Перемещение агрегатов
         */


		/*
         * Directive: Добавление в БД всех классов относящихся к директиве
         */

        /*
         * Удаление объектов
         */
        #region public void Delete(BaseSmartCoreObject deletedObject, bool isDeletedOnly = true)
        /// <summary>
        /// Удаляет объект из БД 
        /// </summary>
        /// <param name="deletedObject">Объект, который нужно удалить</param>
        /// <param name="isDeletedOnly">Флаг - сделать запись недействительной (true)или физически удалить(false)</param>
        public void Delete(BaseEntityObject deletedObject, bool isDeletedOnly = true)
        {
            if (deletedObject == null) return;

			CasEnvironment.Keeper.Delete(deletedObject, isDeletedOnly);

			if (deletedObject is AbstractDictionary)
            {
                var col = CasEnvironment.GetDictionary(deletedObject.GetType());

                if (col == null) return;
                col.Remove(deletedObject);
            }
            if (deletedObject is Store)
            {
                CasEnvironment.Stores.Remove((Store)deletedObject);
            }
            if (deletedObject is BaseComponent)
            {
                CasEnvironment.BaseComponents.Remove((BaseComponent)deletedObject);
            }
            if (deletedObject is ComponentWorkInRegimeParams && 
                ((ComponentWorkInRegimeParams)deletedObject).Engine != null)
            {
                ((ComponentWorkInRegimeParams)deletedObject).Engine.ComponentWorkParams.Remove((ComponentWorkInRegimeParams)deletedObject);
            }
            if (deletedObject is MaintenanceProgramChangeRecord)
            {
				var aircraft = _aircraftsCore.GetAircraftById(((MaintenanceProgramChangeRecord)deletedObject).ParentAircraftId);
				aircraft.MaintenanceProgramChangeRecords.Remove((MaintenanceProgramChangeRecord)deletedObject);
            }
        }
		#endregion

        /*
         * Бортовая книга воздушного судна
         */

        /*
         * Программа по обслуживанию
         */

        /*
         * 
         */

        /*
         * Поставщики 
         */

        /*
         * Закупочные Ордера
         */
        #region public void Publish(PurchaseOrder po, DateTime date)

        #endregion

        /*
         * Ордера запросов на поставку
         */


        /*
         * Рабочие пакеты
         */


        /*
         *  Audit
         */

        /*
         * Cas3Maintenance
         */

        /*
         * SMS
         */

        /*
         * SMS
         */

        /*
         * Job cards
         */

        #region public void Save(JobCardTask smsEvent)
        /// <summary>
        /// Сохраняет событие системы безопасности полетов
        /// </summary>
        /// <param name="jobCardTask"></param>
        public void Save(JobCardTask jobCardTask)
        {
            if (jobCardTask == null) return;

            Save((BaseEntityObject)jobCardTask);

            foreach (JobCardTask eventCondition in jobCardTask.Tasks)
            {
                eventCondition.JobCard = jobCardTask.JobCard;
                eventCondition.ParentTask = jobCardTask;

                Save(eventCondition);
            }
        }
        #endregion

    }

}
