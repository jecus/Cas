using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Auxiliary;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Store;

namespace SmartCore.Calculations
{
    /// <summary>
    /// Прогноз на будущее - выступает в роли контейнера всех объектов системы Cas
    /// </summary>
    public class Forecast
    {

        /*
         * Общие данные о прогнозе
         */
        #region  public List<ForecastData> ForecastDatas;

        public List<ForecastData> ForecastDatas { get; set; }
        #endregion

        #region public ForecastData ForecastDataForNonLifelenght

        private ForecastData _forecastDataForNonLifelenght;
        /// <summary>
        /// Данные для прогноза по объекту не поддерживающему расчет наработки
        /// </summary>
        public ForecastData ForecastDataForNonLifelenght
        {
            get { return _forecastDataForNonLifelenght; }
        }
        #endregion

        #region public Aircraft Aircraft { get; set; }
        /// <summary>
        /// Воздушное судно, для которого составляется отчет (см. св-во BaseComponent)
        /// </summary>
        public Aircraft Aircraft { get; set; }
        #endregion

        #region public  Store Store { get; set; }

        private Store _store;

		/// <summary>
		/// Склад, для которого составляется отчет (см. св-во BaseComponent)
		/// </summary>
		public Store Store
        {
            get { return _store; }
        }
        #endregion

        #region public Operator Operator { get; set; }

        private Operator _operator;

		/// <summary>
		/// Склад, для которого составляется отчет (см. св-во BaseComponent)
		/// </summary>
		public Operator Operator
        {
            get { return _operator; }
        }
        #endregion

        #region public DateTime ForecastDate { get; set; }
        /// <summary>
        /// Дата, на которую составляется прогноз
        /// </summary>
        public DateTime ForecastDate { get; set; }
		#endregion

		/*
         * Элементы системы, которые попали в прогноз
         */

		#region public BaseComponentCollection BaseComponents { get; internal set; }
		/// <summary>
		/// Базовые агрегаты, для которых задан Lifelimit
		/// </summary>
		public BaseComponentCollection BaseComponents { get; internal set; }
		#endregion

		#region ICommonCollection<ComponentDirective> BaseComponentDirectives { get; internal set; }
		/// <summary>
		/// Работы по компонентам, которые необходимо выполнить. Важно - для Component Directive родителем могут быть BaseComponent так и Component
		/// </summary>
		public ICommonCollection<ComponentDirective> BaseComponentDirectives { get; internal set; }
		#endregion

		#region public ComponentCollection Components { get; internal set; }
		/// <summary>
		/// Компоненты, которые необходимо заменить (Remove/Replace)
		/// </summary>
		public ComponentCollection Components { get; internal set; }
		#endregion

		#region public ICommonCollection<ComponentDirective> ComponentDirectives { get; internal set; }
		/// <summary>
		/// Работы по компонентам, которые необходимо выполнить. Важно - для Component Directive родителем могут быть как BaseComponent так и Component
		/// </summary>
		public ICommonCollection<ComponentDirective> ComponentDirectives { get; internal set; }
        #endregion

        #region public DirectiveCollection Directives { get; private set; }
        /// <summary>
        /// Возвращает все директивы попавшие в прогноз (влючая Ad, cpcp, damage и т.д.)
        /// </summary>
        /// 
        public Dictionary<DirectiveType, DirectiveCollection> DirectiveCollections { get; private set; }
        #endregion

        #region public DirectiveCollection AdStatus { get; internal set; }

        /// <summary>
        /// Директивы Ad статуса, которые должны быть выполнены
        /// </summary>
        public DirectiveCollection AdStatus { get; private set; }
        #endregion

        #region public List< Cas3MaintenanceCheck > MaintenanceChecks { get; internal set; }
        /// <summary>
        /// Элементы Maintenance, которые требуют выполнения 
        /// </summary>
        public List< MaintenanceCheck > MaintenanceChecks { get; private set; }
        #endregion

        #region public List< MaintenanceDirective > MaintenanceDirectives { get; internal set; }
        /// <summary>
        /// Элементы MaintenanceDirective, которые требуют выполнения 
        /// </summary>
        public List<MaintenanceDirective> MaintenanceDirectives { get; private set; }
        #endregion

        #region public DirectiveCollection Damages { get; internal set; }
        /// <summary>
        /// Элементы отчета Cpcp, которые требуют выполнения 
        /// </summary>
        public DirectiveCollection Damages { get; private set; }
        #endregion

        #region public DirectiveCollection DefferedItems { get; internal set; }
        /// <summary>
        /// Элементы отчета Deffered, которые требуют выполнения 
        /// </summary>
        public DirectiveCollection DefferedItems { get; private set; }
        #endregion

        #region public DirectiveCollection ModificationStatus { get; internal set; }
        /// <summary>
        /// Модификации ордера, которые нужно выполнить
        /// </summary>
        public DirectiveCollection ModificationStatus { get; private set; }
        #endregion

        #region public DirectiveCollection OutOfPhaseItems { get; internal set; }
        /// <summary>
        /// Элементы внепланового обслуживания, требующие выполнения
        /// </summary>
        public DirectiveCollection OutOfPhaseItems { get; private set; }
        #endregion

        #region public DirectiveCollection ServiceBulletins { get; internal set; }
        /// <summary>
        /// Сервисные бюллетени, которые нужно выполнить
        /// </summary>
        public DirectiveCollection ServiceBulletins { get; private set; }
        #endregion

        #region public DirectiveCollection EngineeringOrders { get; internal set; }
        /// <summary>
        /// Инженерные ордера, которые нужно выполнить
        /// </summary>
        public DirectiveCollection EngineeringOrders { get; private set; }
        #endregion

        #region public List<Kit> Kits { get; internal set; }
        /// <summary>
        /// КИТы, которые нужно выполнить
        /// </summary>
        public List<AccessoryRequired> Kits { get; internal set; }
        #endregion

		public bool IsAllPhase { get; set; }

        /*
         * Методы
         */

        #region public Forecast()
        /// <summary>
        /// Прогноз на будущее - выступает в роли контейнера всех объектов системы Cas
        /// </summary>
        public Forecast()
        {
            // Создаем все коллекции
            ForecastDatas = new List<ForecastData>();
            //
            BaseComponents = new BaseComponentCollection();
            BaseComponentDirectives = new CommonCollection<ComponentDirective>();
            Components = new ComponentCollection();
            ComponentDirectives = new CommonCollection<ComponentDirective>(); 
            AdStatus = new DirectiveCollection();
            Damages = new DirectiveCollection();
            DefferedItems = new DirectiveCollection();
            EngineeringOrders = new DirectiveCollection();
            ModificationStatus = new DirectiveCollection();
            OutOfPhaseItems = new DirectiveCollection();
            ServiceBulletins = new DirectiveCollection();
            MaintenanceChecks = new List<MaintenanceCheck>();
            MaintenanceDirectives = new List<MaintenanceDirective>();
            Kits = new List<AccessoryRequired>();

            DirectiveCollections = new Dictionary<DirectiveType, DirectiveCollection>
                                       {
                                           {DirectiveType.AirworthenessDirectives, AdStatus},
                                           {DirectiveType.DamagesRequiring, Damages},
                                           {DirectiveType.DeferredItems, DefferedItems},
                                           {DirectiveType.EngineeringOrders, EngineeringOrders},
                                           {DirectiveType.ModificationStatus, ModificationStatus},
                                           {DirectiveType.OutOfPhase, OutOfPhaseItems},
                                           {DirectiveType.SB, ServiceBulletins}
                                       };
        }
        #endregion

        #region public Forecast(Store store, DateTime forecastDate)
        /// <summary>
        /// Создает прогноз по складу
        /// </summary>
        /// <param name="store">Склад, на котором выполняется прогноз</param>
        /// <param name="forecastDate">Дата прогноза по складу</param>
        public Forecast(Store store, DateTime forecastDate) : this()
        {
            _store = store;
            if (_store != null) 
                _forecastDataForNonLifelenght = new ForecastData(forecastDate, 
                                        new AverageUtilization(0,0),
                                        new Lifelength((forecastDate - DateTimeExtend.GetCASMinDateTime()).Days, null, null));
        }
        #endregion

        #region public Forecast(Operator @operator, DateTime forecastDate)
        /// <summary>
        /// Создает прогноз по складу
        /// </summary>
        /// <param name="operator">Склад, на котором выполняется прогноз</param>
        /// <param name="forecastDate">Дата прогноза по складу</param>
        public Forecast(Operator @operator, DateTime forecastDate)
            : this()
        {
            _operator = @operator;
            if (_operator != null)
                _forecastDataForNonLifelenght = new ForecastData(forecastDate,
                                        new AverageUtilization(0, 0),
                                        new Lifelength((forecastDate - DateTimeExtend.GetCASMinDateTime()).Days, null, null));
        }
		#endregion

		#region public ForecastData GetForecastDataByBaseComponentId(int baseComponentId)
		public ForecastData GetForecastDataByBaseComponentId(int baseComponentId)
        {
            return ForecastDatas == null 
                ? null 
                : ForecastDatas.Where(fd => fd.BaseComponent.ItemId == baseComponentId).FirstOrDefault();
        }
        #endregion

        #region public ForecastData GetForecastDataFrame()
        /// <summary>
        /// Возвращает объект ForecastData для базовой детали типа Frame или NULL 
        /// </summary>
        /// <returns></returns>
        public ForecastData GetForecastDataFrame()
        {
            return Aircraft == null ? null : GetForecastDataByBaseComponentId(Aircraft.AircraftFrameId);
        }

		#endregion

		#region public void FilterByComponentType(List<BaseComponentType>types)
		/// <summary>
		/// фильтрует объекты ForecastData по типу базовой детали сравнивая с типами в коллекции types
		/// </summary>
		/// <returns></returns>
		public void FilterByComponentType(List<BaseComponentType>types)
        {
            if(types == null || types.Count == 0)return;
            
            List<ForecastData> forecastDatas = new List<ForecastData>();
            foreach (ForecastData fd in ForecastDatas)
            {
                if (types.Contains(fd.BaseComponent.BaseComponentType)) forecastDatas.Add(fd);
            }
            ForecastDatas = forecastDatas;
        }
        #endregion

        #region public void Clear()
        /// <summary>
        /// Производит очистку прогноза
        /// </summary>
        public void Clear()
        {
            // Создаем все коллекции
            ForecastDatas.Clear();
            BaseComponents.Clear();
            BaseComponentDirectives.Clear();
            Components.Clear();
            ComponentDirectives.Clear();
            AdStatus.Clear();
            Damages.Clear();
            DefferedItems.Clear();
            EngineeringOrders.Clear();
            OutOfPhaseItems.Clear();
            ServiceBulletins.Clear();
            MaintenanceChecks.Clear();
            Kits.Clear();

            DirectiveCollections.Clear();

        }
        #endregion

        #region public void Dispose()
        /// <summary>
        /// Производит удаление всех коллекций прогноза
        /// </summary>
        public void Dispose()
        {
            // Создаем все коллекции
            ForecastDatas.Clear();
            ForecastDatas = null;
            BaseComponents.Clear();
            BaseComponents = null;
            BaseComponentDirectives.Clear();
            BaseComponentDirectives = null;
            Components.Clear();
            Components = null;
            ComponentDirectives.Clear();
            ComponentDirectives = null;
            AdStatus.Clear();
            AdStatus = null;
            Damages.Clear();
            Damages = null;
            DefferedItems.Clear();
            DefferedItems = null;
            EngineeringOrders.Clear();
            EngineeringOrders = null;
            OutOfPhaseItems.Clear();
            OutOfPhaseItems = null;
            ServiceBulletins.Clear();
            ServiceBulletins = null;
            MaintenanceChecks.Clear();
            MaintenanceChecks = null;
            Kits.Clear();
            Kits = null;

            DirectiveCollections.Clear();
            DirectiveCollections = null;

        }
        #endregion
    }
}
