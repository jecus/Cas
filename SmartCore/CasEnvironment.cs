using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using CAS.UI.Helpers;
using EntityCore.DTO.General;
using EntityCore.DTO.Dictionaries;
using EntityCore.Filter;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Hangar;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkShop;
using SmartCore.Management;
using SmartCore.Aircrafts;
using SmartCore.AuditMongo.Repository;
using SmartCore.Entities.General;
using SmartCore.Entities.Collections;
using SmartCore.Calculations;
using SmartCore.Component;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.NewLoader;
using SmartCore.Files;
using SmartCore.ObjectCache;
using SmartCore.Queries;

namespace SmartCore
{
	/// <summary>
    /// Окружение системы CAS. Движок CAS
    /// </summary>
    public class CasEnvironment:ICasEnvironment
    {
        // Начало работы с окружением CAS

        #region public CasEnvironment()
        /// <summary>
        /// Создает окружение системы CAS, необходимую для ее работы
        /// </summary>
        public CasEnvironment()
        {
	        _dictionaries = new CommonDictionariesCache();
        }
        #endregion

        #region class FileProcess

        class FileProcess
        {
            private readonly AttachedFile _attachedFile;
            private readonly Process _process;
            private readonly string _fileNameToRemove;

            #region public AttachedFile AttachedFile

            public AttachedFile AttachedFile
            {
                get { return _attachedFile; }
            }
            #endregion

            #region public string FileNameToRemove

            public string FileNameToRemove
            {
                get { return _fileNameToRemove; }
            }
            #endregion

            #region public Process Process

            public Process Process
            {
                get { return _process; }
            }
            #endregion

            #region public FileProcess(AttachedFile attachedFile, string fileNameToRemove, Process process)

            public FileProcess(AttachedFile attachedFile, string fileNameToRemove, Process process)
            {
                _attachedFile = attachedFile;
                _fileNameToRemove = fileNameToRemove;
                _process = process;
            }
            #endregion
        }

        #endregion

        private ApiProvider _apiProvider;
		public ApiProvider ApiProvider
		{
			get { return _apiProvider; }
			set { _apiProvider = value; }
		}


		#region public IAuditRepository AuditRepository { get; set; }

		public IAuditRepository AuditRepository
		{
			get => _auditRepository ?? (_auditRepository = new AuditRepository(null));
			set => _auditRepository = value;
		}

		#endregion

        #region public void Disconnect()

        /// <summary>
        /// Производит отключение от базы данных
        /// </summary>
        public void Disconnect()
        {
            _exit = true;

            if(_tempFileMonitoringThread != null)
            {
                _tempFileMonitoringThread.Abort();

                foreach (FileProcess fileProcess in _openFileProcesses.Where(p => File.Exists(p.FileNameToRemove)))
                {
                    try
                    {
                        File.Delete(fileProcess.FileNameToRemove);
                    }
                    catch
                    {
                        Thread.Sleep(100);
                    }
                }
            }
        }

        #endregion

        #region public void Connect(String serverName, String userName, String pass, String database)
        /// <summary>
        /// Подключаемся к базе данных под указанной учетной записью и выбираем базу данных
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="userName"></param>
        /// <param name="pass"></param>
        /// <param name="database"></param>
        public void Connect(string serverName, string userName, string pass, string database)
        {
            _apiProvider.CheckAPIConnection();

	        var user = _apiProvider.GetUserAsync(userName, pass);
	        if(user == null)
		        throw new Exception($"Invalid combination of login and password");

	        IdentityUser = user;
	        AuditRepository.WriteAsync(new Entities.User(user), AuditOperation.SignIn, user);

	        _newLoader = new NewLoader(this);
		}
		#endregion

		public void UpdateUser(string password)
		{
			_apiProvider.UpdatePassword(IdentityUser.ItemId, password);
		}

        #region public override string ToString()
        /// <summary>
        /// Дает короткую информацию о загруженной базе данных и окружении
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //return "Orenair, CasDemo at Dev\\Dev2005, 15 aircrafts";
            return "";
        }
		#endregion

		#region public UserDTO GetCorrector(int id)

		public string GetCorrector(int id)
		{
			return Users.ContainsKey(id) ? Users[id] : "Unknown";
		}

		public string GetCorrector(IBaseEntityObject entity)
		{
			return Users.ContainsKey(entity.CorrectorId) ?
				$"{Users[entity.CorrectorId]} ({Auxiliary.Convert.GetDateFormat(entity.Updated)} {entity.Updated.TimeOfDay.Hours}:{entity.Updated.TimeOfDay.Minutes}:{entity.Updated.TimeOfDay.Seconds})"
				: "Unknown";
		}

		#endregion

		/*
		* Выполнение запросов
		*/

		public DataSet Execute(string sql)
	    {
		    return _newLoader.Execute(sql);
	    }

	    public DataSet Execute(IEnumerable<DbQuery> dbQueries, out List<ExecutionResultArgs> results)
	    {
		    return _newLoader.Execute(dbQueries, out results);
	    }

	    public DataSet Execute(string query, SqlParameter[] parameters)
	    {
		    return _newLoader.Execute(query, parameters);
	    }

	    /*
         * Свойства, глобальные объекты
         */

		#region public OperatorCollection Operators { get; internal set; }

		/// <summary>
		/// Доступные операторы
		/// </summary>
		private OperatorCollection _operators;
        /// <summary>
        /// Доступные операторы
        /// </summary>
        public OperatorCollection Operators
        {
            get
            {
                if (_operators.Count == 0 || _stores == null || _baseComponents == null)
                    FirstLoad();
                //
                return _operators;
            }
            internal set { _operators = value; }
        }
        #endregion

        #region public CommonCollection<Vehicle> Vehicles { get; internal set; }
        /// <summary>
        /// Доступные транспортные средства
        /// </summary>
        private CommonCollection<Vehicle> _vehicles;
        /// <summary>
        /// Доступные транспортные средства
        /// </summary>
        public CommonCollection<Vehicle> Vehicles
        {
            get
            {
                if (_operators.Count == 0 || _stores == null || _baseComponents == null) 
                    FirstLoad();
                    //
                return _vehicles ?? (_vehicles = new CommonCollection<Vehicle>());
            }
            internal set
            {
                _vehicles = value;
            }
        }
        #endregion

        #region public CommonCollection<Store> Stores { get; internal set; }
        /// <summary>
        /// Доступные склады компании
        /// </summary>
        private CommonCollection<Store> _stores;
        /// <summary>
        /// Доступные склады компании
        /// </summary>
        public CommonCollection<Store> Stores
        {
            get
            {
                if (_operators.Count == 0 || _stores == null || _baseComponents == null)
                    FirstLoad();
                
                //
                return _stores;
            }
            internal set
            {
                _stores = value;
            }
        }
		#endregion

		#region public CommonCollection<Store> User { get; internal set; }

		public Dictionary<int, string> Users { get; set; }
		#endregion

		#region public CommonCollection<Hangar> Hangars { get; internal set; }
		/// <summary>
		/// Доступные ангары компании
		/// </summary>
		private CommonCollection<Hangar> _hangars;
        /// <summary>
        /// Доступные ангары компании
        /// </summary>
        public CommonCollection<Hangar> Hangars
        {
            get
            {
                if (_operators.Count == 0 || _stores == null || _baseComponents == null)
                    FirstLoad();
                
                //
                return _hangars ?? (_hangars = new CommonCollection<Hangar>());
            }
            internal set
            {
                _hangars = value;
            }
        }
        #endregion

        #region public CommonCollection<WorkShop> WorkShops { get; internal set; }
        /// <summary>
        /// Доступные лаборатории компании
        /// </summary>
        private CommonCollection<WorkShop> _workShops;
        /// <summary>
        /// Доступные лаборатории компании
        /// </summary>
        public CommonCollection<WorkShop> WorkShops
        {
            get
            {
                if (_operators.Count == 0 || _stores == null || _baseComponents == null)
                    FirstLoad();
                //
                return _workShops ?? (_workShops = new CommonCollection<WorkShop>());
            }
            internal set
            {
                _workShops = value;
            }
        }
        #endregion

        #region public CommonCollection<WorkShop> WorkShops { get; internal set; }
        /// <summary>
        /// Доступные лаборатории компании
        /// </summary>
        private CommonCollection<WorkStation> _workStations;
        /// <summary>
        /// Доступные лаборатории компании
        /// </summary>
        public CommonCollection<WorkStation> WorkStations
        {
	        get
	        {
		        if (_operators.Count == 0 || _stores == null || _baseComponents == null)
		            FirstLoad();
		        
		        //
		        return _workStations ?? (_workStations = new CommonCollection<WorkStation>());
	        }
	        internal set
	        {
		        _workStations = value;
	        }
        }
        #endregion

        #region public BaseComponentCollection BaseComponents { get; internal set; }
        /// <summary>
        /// Доступные базовые агрегаты
        /// </summary>
        private BaseComponentCollection _baseComponents;
        /// <summary>
        /// Доступные базовые агрегаты
        /// </summary>
        public BaseComponentCollection BaseComponents
        {
            get
            {
                if (_operators.Count == 0 || _stores == null || _baseComponents == null)
                    FirstLoad();
                
                //
                return _baseComponents;
            }
            internal set
            {
                _baseComponents = value;
            }
        }
        #endregion

        #region public CommonDictionariesCache Dictionaries

        private readonly CommonDictionariesCache _dictionaries;

        public IDictionaryCollection GetDictionary<T>() where T : IDictionaryItem
        {
            return _dictionaries.GetDictionary<T>();
        }

        public IDictionaryCollection GetDictionary(Type type)
        {
            return _dictionaries.GetDictionary(type);
        }

        public void ClearDictionaries()
        {
            _dictionaries.Clear();
        }

        public void AddDictionary(Type t, IDictionaryCollection dictionary)
        {
            _dictionaries.Add(t, dictionary);    
        }

        #endregion

        #region public Dictionary<string, ICommonCollection> TempCollections
        private Dictionary<string, ICommonCollection> _tempCollections;
        /// <summary>
        /// Временные коллекции (коллекции, используемые более чем в одном контроле)
        /// </summary>
        public Dictionary<string, ICommonCollection> TempCollections
        {
            get { return _tempCollections; }
            internal set { _tempCollections = value; }
        }
        #endregion

        #region public ReasonCollection Reasons { get; }
        /// <summary>
        /// Причины сбоя
        /// </summary>
        private ReasonCollection _reasons;
        /// <summary>
        /// Возвращает все Причины сбоя
        /// </summary>
        public ReasonCollection Reasons
        {
            get
            {
                if (_reasons == null)
                {
                    //Загрузки причин сбоя
                    _reasons = new ReasonCollection(_newLoader.GetObjectList<ReasonDTO, Reason>().ToArray());
                }
                //
                return _reasons;
            }
        }
		#endregion

		#region public IIdentityUser IdentityUser { get; }
		/// <summary>
		/// Пользователь, подключенный к базе данных
		/// </summary>
		private IIdentityUser _currentUser;
        /// <summary>
        /// Возвращает пользователя, подключенного к базе данных
        /// </summary>
        public IIdentityUser IdentityUser
        {
            get
            {
                // Возвращаем текущего пользователя 
                if (_currentUser == null)
                    _currentUser = new UserDTO(){Name = "Error"};
               
                return _currentUser;
            }
	        set { _currentUser = value; }
        }
        #endregion

        /*
         * Загрузка, Перезагрузка ядра
         */

        #region public void Reset()
        /// <summary>
        /// Сбрасывает все коллекции и загружает их заново - все старые ссылки на базовые агрегаты, воздушные суда и операторы становятся не актуальными 
        /// </summary>
        public void Reset()
        {
            //Временные коллекции
            if(_tempCollections != null)
            {
                foreach (KeyValuePair<string, ICommonCollection> pair in _tempCollections)
                {
                    if(pair.Value != null)pair.Value.Clear();
                }
                _tempCollections.Clear();
            }
            _tempCollections = null;

            //Словари
            _dictionaries.Clear();

            //Операторы
            if(_operators != null)
                _operators.Clear();
            _operators = null;
            

            //Склады
            if (_stores != null)
                _stores.Clear();
            _stores = null;

            //Базовые агрегаты
            if (_baseComponents != null)
                _baseComponents.Clear();
            _baseComponents = null;

            //Приничы сбоев
            if (_reasons != null)
                _reasons.Clear();
            _reasons = null;

            //Калькулятор
            if (_calculator != null) _calculator.Reset();
        }
        #endregion

        #region public void FirstLoad()

        /// <summary>
        /// Выполняет первую загрузку ядра
        /// </summary>
        public void FirstLoad()
        {
            //Временные коллекции
            TempCollections = new Dictionary<string, ICommonCollection>();

            //Загрузка всех словарей
            GetDictionaries();

            // Загрузка всех операторов
            Operators = new OperatorCollection(_newLoader.GetObjectList<OperatorDTO, Operator>().ToArray());

            // Загрузка всех воздушных судов 

#if !KAC
            //Загрузка всех транспортный средств
            Vehicles = new CommonCollection<Vehicle>(_newLoader.GetObjectListAll<VehicleDTO, Vehicle>());
            //Загрузка всех ангаров
            Hangars = new CommonCollection<Hangar>(_newLoader.GetObjectListAll<HangarDTO, Hangar>());
#endif
            // Загрузка всех складов
            Stores = new CommonCollection<Store>(_newLoader.GetObjectListAll<StoreDTO, Store>());
            //Загрузка всех лабораторий
#if !KAC
           WorkShops = new CommonCollection<WorkShop>(_newLoader.GetObjectListAll<WorkShopDTO, WorkShop>());
#endif
            // Загрузка всех базовых агрегатов
            BaseComponents = new BaseComponentCollection(_newLoader.GetObjectListAll<BaseComponentDTO, BaseComponent>(loadChild: true)); //GetBaseDetails();

            // Выставляем ссылки между объектами

            SetParentsToStores();
            _componentCore.SetParentsToBaseComponents();
#if !KAC
            foreach (var store in Hangars)
                store.Operator = Operators.GetOperatorById(store.OperatorId);
            foreach (var store in WorkShops)
                store.Operator = Operators.GetOperatorById(store.OperatorId);
#endif
        }

        #endregion

        public void GetDictionaries()
        {
            ClearDictionaries();

            var assembly = Assembly.GetAssembly(typeof(BaseEntityObject));
            var types = assembly.GetTypes()
                .Where(t => t.Namespace != null && t.IsClass && t.Namespace.StartsWith("SmartCore.Entities.Dictionaries"));

            var staticDictionaryType = types.Where(t => t.IsSubclassOf(typeof(StaticDictionary))
                                                            && t.GetCustomAttributes(typeof(TableAttribute), false).Length > 0).ToList();

            foreach (var type in staticDictionaryType)
            {
                try
                {
                    string qr = BaseQueries.GetSelectQueryWithWhere(type, loadChild: true);
                    DataSet ds = Execute(qr);

                    //поиск в типе своиства Items
                    PropertyInfo itemsProp = type.GetProperty("Items");
                    //поиск у типа конструктора беза параметров
                    ConstructorInfo ci = type.GetConstructor(new Type[0]);
                    //создание экземпляра статического словаря 
                    //(при этом будут созданы все его статические элементы, 
                    // которые будут доступны через статическое своиство Items)
                    StaticDictionary instance = (StaticDictionary)ci.Invoke(null);
                    //Получение элементов статического своиства Items
                    IEnumerable staticList = (IEnumerable)itemsProp.GetValue(instance, null);

                    BaseQueries.SetFields(staticList, ds);
                }
                catch (Exception)
                {
                    continue;
                    //throw ex;
                }
            }

            var abstractDictionaryTypes = types.Where(t => t.IsSubclassOf(typeof(AbstractDictionary))
                                                               && !t.IsAbstract)
                                                      .ToList();
            //коллекция дл типов, которые не удалось загрузить сразу
            //по причине отсутствия другого словаря в коллекции словарей ядра
            var defferedTypes = new List<Type>();
            foreach (var type in abstractDictionaryTypes)
            {
                try
                {
                    var dca = (DictionaryCollectionAttribute)type.GetCustomAttributes(typeof(DictionaryCollectionAttribute), false).FirstOrDefault();
                    var bl = (DtoAttribute)type.GetCustomAttributes(typeof(DtoAttribute), false).FirstOrDefault();

                    var typeDict = dca == null
                        ? new CommonDictionaryCollection<AbstractDictionary>()
                        : dca.GetInstance();

                    IEnumerable items = _newLoader.GetObjectList(bl.Type, type, true);
                    typeDict.AddRange((IEnumerable<IDictionaryItem>)items);
                    AddDictionary(type, typeDict);

                }
                catch (KeyNotFoundException)
                {
                    defferedTypes.Add(type);
                    continue;
                }
                catch (Exception)
                {
                    continue;
                    //throw ex;
                }
            }

            //Повторная попытка загрузить типы данных, которые не удалось загрузить с первого раза
            foreach (var type in defferedTypes)
            {
                try
                {
                    var dca = (DictionaryCollectionAttribute)type.GetCustomAttributes(typeof(DictionaryCollectionAttribute), false).FirstOrDefault();
                    var bl = (DtoAttribute)type.GetCustomAttributes(typeof(DtoAttribute), false).FirstOrDefault();
                    var typeDict = dca == null
                        ? new CommonDictionaryCollection<AbstractDictionary>()
                        : dca.GetInstance();
                    IEnumerable items = _newLoader.GetObjectList(bl.Type, type, true);
                    typeDict.AddRange((IEnumerable<IDictionaryItem>)items);
                    AddDictionary(type, typeDict);
                }
                catch (Exception)
                {
                    continue;
                    //throw ex;
                }
            }
        }

        #region public void SetParentsToStores()

        public void SetParentsToStores()
        {
            foreach (var store in Stores)
                store.Operator = Operators.GetOperatorById(store.OperatorId);
        }

        #endregion

        #region public void InitAsync(BackgroundWorker backgroundWorker, LoadingState loadingState)
        /// <summary>
        /// Загружает все данные из базы, необходимые для функционирования ядра
        /// </summary>
        public void InitAsync(BackgroundWorker backgroundWorker, LoadingState loadingState)
        {
			if ( backgroundWorker == null )return;
            
            if ( loadingState == null )
                 loadingState = new LoadingState();
            loadingState.MaxPersentage = 10;

            //Загрузка всех пользователей
			loadingState.CurrentPersentage = 0;
            loadingState.CurrentPersentageDescription = "Loading Users";
            backgroundWorker.ReportProgress(1, loadingState);

            var users =  ApiProvider.GetAllUsersAsync();
            Users = new Dictionary<int, string>();
			foreach (var user in users)
				Users.Add(user.ItemId, user.ToString());

            if (backgroundWorker.CancellationPending)
            {
	            return;
            }

			//Временные коллекции
			loadingState.CurrentPersentage = 1;
            loadingState.CurrentPersentageDescription = "Loading Temp Collection";
            backgroundWorker.ReportProgress(1, loadingState);

            TempCollections = new Dictionary<string, ICommonCollection>();

            if (backgroundWorker.CancellationPending)
            {
                return;
            }

            //Загрузка всех словарей
            loadingState.CurrentPersentage = 2;
            loadingState.CurrentPersentageDescription = "Loading Dictionaries";
            backgroundWorker.ReportProgress(1, loadingState);

            GetDictionaries();
            
            if (backgroundWorker.CancellationPending)
            {
                return;
            }

            // Загрузка всех операторов
            loadingState.CurrentPersentage = 3;
            loadingState.CurrentPersentageDescription = "Loading Operators";
            backgroundWorker.ReportProgress(1, loadingState);

            Operators = new OperatorCollection(_newLoader.GetObjectList<OperatorDTO,Operator>().ToArray());
            
            if (backgroundWorker.CancellationPending)
            {
                return;
            }

            // Загрузка всех воздушных судов 
            loadingState.CurrentPersentage = 4;
            loadingState.CurrentPersentageDescription = "Loading Aircrafts";
            backgroundWorker.ReportProgress(1, loadingState);

			_aircraftsCore.LoadAllAircrafts();

			if (backgroundWorker.CancellationPending)
            {
                return;
            }

#if !KAC
            //Загрузка всех ТС
            loadingState.CurrentPersentage = 5;
            loadingState.CurrentPersentageDescription = "Loading Vehicles";
            backgroundWorker.ReportProgress(1, loadingState);

	        Vehicles = new CommonCollection<Vehicle>(_newLoader.GetObjectList<VehicleDTO, Vehicle>());

            if (backgroundWorker.CancellationPending)
            {
                return;
            }

            //Загрузка всех ангаров
            loadingState.CurrentPersentage = 6;
            loadingState.CurrentPersentageDescription = "Loading Hangars";
            backgroundWorker.ReportProgress(1, loadingState);

			Hangars = new CommonCollection<Hangar>(_newLoader.GetObjectList<HangarDTO, Hangar>());

            if (backgroundWorker.CancellationPending)
            {
                return;
            }
#endif

            // Загрузка всех складов
            loadingState.CurrentPersentage = 7;
            loadingState.CurrentPersentageDescription = "Loading Stores";
            backgroundWorker.ReportProgress(1, loadingState);

			Stores = new CommonCollection<Store>(_newLoader.GetObjectList<StoreDTO, Store>());

            if (backgroundWorker.CancellationPending)
            {
                return;
            }

#if !KAC
            // Загрузка всех лабораторий
            loadingState.CurrentPersentage = 8;
            loadingState.CurrentPersentageDescription = "Loading Work Shops";
            backgroundWorker.ReportProgress(1, loadingState);

	        WorkShops = new CommonCollection<WorkShop>(_newLoader.GetObjectList<WorkShopDTO, WorkShop>());

            if (backgroundWorker.CancellationPending)
            {
                return;
            }
#endif

	        loadingState.CurrentPersentage = 9;
	        loadingState.CurrentPersentageDescription = "Loading Work Stations";
	        backgroundWorker.ReportProgress(1, loadingState);

	        WorkStations = new CommonCollection<WorkStation>(_newLoader.GetObjectList<WorkStationsDTO, WorkStation>());

	        if (backgroundWorker.CancellationPending)
	        {
		        return;
	        }

            // Загрузка всех базовых агрегатов
            loadingState.CurrentPersentage = 10;
            loadingState.CurrentPersentageDescription = "Loading Base Details";
            backgroundWorker.ReportProgress(1, loadingState);

            BaseComponents = new BaseComponentCollection(NewLoader.GetObjectListAll<BaseComponentDTO, BaseComponent>(loadChild:true));
            
            if (backgroundWorker.CancellationPending)
            {
                return;
            }

            // Выставляем ссылки между объектами
            loadingState.CurrentPersentage = 11;
            loadingState.CurrentPersentageDescription = "Set Links";
            backgroundWorker.ReportProgress(1, loadingState);

			SetParentsToStores();
            _componentCore.SetParentsToBaseComponents();

            //foreach (Vehicle vehicle in Vehicles)
            //    vehicle.Operator = Operators.GetOperatorById(vehicle.OperatorId);

            foreach (Hangar store in Hangars)
                store.Operator = Operators.GetOperatorById(store.OperatorId);

            foreach (WorkShop store in WorkShops)
                store.Operator = Operators.GetOperatorById(store.OperatorId);

            _tempFileMonitoringThread = new Thread(TempFileDeleting) {IsBackground = true};
            _tempFileMonitoringThread.Start();
        }
        #endregion

        #region public BaseItemsCollection<DamageChart> GetDamageChartsByAircraftModel(AircraftModel aircraftModel)

        public IList<DamageChart> GetDamageChartsByAircraftModel(AircraftModel aircraftModel)
        {
            var res = _newLoader.GetObjectListAll<DamageChartDTO, DamageChart>(new Filter("AircraftModelId", aircraftModel.ItemId), true);
            var ids = res.Select(i => i.ItemId);
            var links = _newLoader.GetObjectListAll<ItemFileLinkDTO, ItemFileLink>(new List<Filter>()
            {
                new Filter("ParentId",ids),
                new Filter("ParentTypeId",SmartCoreType.DamageChart.ItemId)
            }, true);


            foreach (var damageChart in res)
            {
                damageChart.Files.AddRange(links.Where(i => i.ParentId == damageChart.ItemId));
            }

            return res;
        }
        #endregion

        #region public AttachedFile GetAttachedFileById(Int32 id)

        public AttachedFile GetAttachedFileById(int id)
        {
            AttachedFile attachedFile = null;

            if (id > 0)
                attachedFile = _newLoader.GetObject<AttachedFileDTO, AttachedFile>(new Filter("ItemId", id));

            return attachedFile;
        }

        #endregion

        #region public ICommonCollection<EmployeeSubject> GetEmployeeSubject(params object[] parametres)

        public ICommonCollection<EmployeeSubject> GetEmployeeSubject(params object[] parametres)
        {
            if (parametres[0] is int)
            {
                var type = (int)parametres[0];
                return new CommonCollection<EmployeeSubject>(_newLoader.GetObjectListAll<EmployeeSubjectDTO, EmployeeSubject>(new Filter("LicenceTypeId", type), true));
            }
            throw new ArgumentException("must be EmployeeLicenceType", "parametres");
        }

        #endregion

        public ICommonCollection<ComponentModel> GetComponentModels(params object[] type)
        {
            var ids = new List<int>() { GoodsClass.AircraftBaseComponents.ItemId };
            var res = new CommonCollection<ComponentModel>(_newLoader.GetObjectList<AccessoryDescriptionDTO, ComponentModel>(new Filter("ComponentClass", ids)));
            return res;
        }

        #region public ICommonCollection<JobCard> GetJobCard(params object[] parametres)

        public ICommonCollection<JobCard> GetJobCard(params object[] parametres)
        {
            if (parametres == null || parametres.Length == 0 || parametres[0] == null)
                return null;
            if (parametres[0] is BaseEntityObject)
            {
                var a = (BaseEntityObject)parametres[0];
                if (a.ItemId == -1)
                    return null;
                return new CommonCollection<JobCard>(_newLoader.GetObjectListAll<JobCardDTO, JobCard>(new List<Filter>()
                {
                    new Filter("ParentId",a.ItemId),
                    new Filter("ParentTypeId",  a.SmartCoreObjectType.ItemId)
                }, true, true));
            }
            throw new ArgumentException("must be Aircraft or BaseComponent or Store or List<BaseComponent>", "parametres");
        }

        #endregion

        /*
         * Вспомогательные 
         */

        /*
         * Базовые агрегаты
         */
        /*
         * Родительский объект для другого объекта
         */

        /*
         * Работа с Файлами: Свойства, глобальные объекты
         */

        private bool _exit;
        private Thread _tempFileMonitoringThread;
        private List<FileProcess> _openFileProcesses = new List<FileProcess>();

        #region public void OpenFile(AttachedFile attachedFile, out string message)

        /// <summary>
        /// Копирует файл во временную папку. В зависимости от расширения файла открывает подходящий процесс
        /// </summary>
        /// <param name="attachedFile">Файл для открытия</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public void OpenFile(AttachedFile attachedFile, out string message)
        {   
            message = "";

	        if (attachedFile.FileData == null)
            {
                attachedFile = _newLoader.GetObjectById<AttachedFileDTO, AttachedFile>(attachedFile.ItemId, true);

                if (attachedFile.FileData == null)
                    return;
            }

            var fileNameToRemove = Path.GetTempPath() + attachedFile.FileName;
            if (!File.Exists(fileNameToRemove))
            {
                try
                {
                    FileStream fileStreamBack = new FileStream(fileNameToRemove, FileMode.Create, FileAccess.Write);
                    fileStreamBack.Write(attachedFile.FileData, 0, attachedFile.FileData.Length);
                    fileStreamBack.Close();
                }
                catch (IOException ioException)
                {
                    message = ioException.Message;
                }
            }

            if (File.Exists(fileNameToRemove))
            {
                Process tempProcess = new Process();
                //определение расширения файла
                string pattern = @"\.\w+$";
                Match m = Regex.Match(attachedFile.FileName, pattern);
                string fileExtension = m.Groups[0].Value;
                //определение,чем открыть фаил, в зависимости от расширения
                if (Regex.IsMatch(fileExtension, @"(\.[pP][dD][fF])"))
                    tempProcess.StartInfo.FileName = fileNameToRemove;
                if (Regex.IsMatch(fileExtension, @"(\.[pP][nN][gG])") ||
                    Regex.IsMatch(fileExtension, @"(\.[jJ][pP][gG])"))
                {
                    //tempProcess.StartInfo.FileName = "mspaint.exe";
                    tempProcess.StartInfo.FileName = fileNameToRemove;
                    tempProcess.StartInfo.Arguments = fileNameToRemove;
                }

                tempProcess.Start();
                FileProcess fileProcess = new FileProcess(attachedFile, fileNameToRemove, tempProcess);

                lock (_openFileProcesses)
                {
                    _openFileProcesses.Add(fileProcess);    
                }
            }
            else
            {
                message = "File : " + fileNameToRemove + " deleted or moved in another place." +
                            "\nPlease check file location or bing another file.";
            }
        }

		#endregion

		#region public void SaveAsFile(AttachedFile attachedFile, string filePath,out string message)

		public void SaveAsFile(AttachedFile attachedFile, string filePath,out string message)
	    {
		    message = "";

		    if (attachedFile.FileData == null)
		    {
				attachedFile = _newLoader.GetObjectById<AttachedFileDTO, AttachedFile>(attachedFile.ItemId, true);

				if (attachedFile.FileData == null)
				    return;
		    }

		    try
		    {
			    var fileStreamBack = new FileStream(filePath, FileMode.Create, FileAccess.Write);
			    fileStreamBack.Write(attachedFile.FileData, 0, attachedFile.FileData.Length);
			    fileStreamBack.Close();
		    }
		    catch (IOException ioException)
		    {
			    message = ioException.Message;
		    }
	    }

	    #endregion

        #region private void TempFileDeleting()

        /// <summary>
        /// Копирует файл во временную папку. В зависимости от расширения файла открывает его в подходящем процессе
        /// </summary>
        /// <returns></returns>
        private void TempFileDeleting()
        {
            while (!_exit)
            {
                lock (_openFileProcesses)
                {
                    List<FileProcess> removedFileProcesses = new List<FileProcess>();
                    foreach (FileProcess fileProcess in _openFileProcesses.Where(p => File.Exists(p.FileNameToRemove)))
                    {
                        try
                        { 
                            File.Delete(fileProcess.FileNameToRemove);
                            removedFileProcesses.Add(fileProcess);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    if (removedFileProcesses.Count > 0)
                        foreach (FileProcess removedFileProcess in removedFileProcesses)
                            _openFileProcesses.Remove(removedFileProcess);
                }
                Thread.Sleep(10000);
            }

            if (!_exit) 
                return;
            foreach (FileProcess fileProcess in _openFileProcesses.Where(p => File.Exists(p.FileNameToRemove)))
            {
                while (File.Exists(fileProcess.FileNameToRemove))
                {
                    try
                    {
                        File.Delete(fileProcess.FileNameToRemove);
                    }
                    catch
                    {
                        Thread.Sleep(100);
                    }
                }
            }
        }

        #endregion

        /*
         * Загрузка данных из базы 
         */

        #region public Loader Loader { get; }
        /// <summary>
        /// Загрузчик данных
        /// </summary>
        private ILoader _loader;
        /// <summary>
        /// Загрузчик данных - За загрузку объектов отвечает отдельный класс
        /// </summary>
        public ILoader Loader
        {
            get
            {
                if (_loader == null) _loader = new Loader(this);
                return _loader;
            }
        }
		#endregion


		/*
         * Математичесский аппарат 
         */

		#region public Calculator Calculator { get; }
		/// <summary>
		/// Возвращает математический аппарат системы Cas
		/// </summary>
		private Calculator _calculator;
        /// <summary>
        /// Возвращает математический аппарат системы Cas
        /// </summary>
        public Calculator Calculator
        {
            get
            {
                return _calculator;
            }
	        set { _calculator = value; }
        }
        #endregion

        /*
         * Сохранение объектов
         */

        #region public Keeper Keeper { get; }
        /// <summary>
        /// Сохранение всех сущностей
        /// </summary>
        private Keeper _keeper;
        /// <summary>
        /// Сохранение всех сущностей
        /// </summary>
        public Keeper Keeper
        {
            get
            {
                if (_keeper == null) _keeper = new Keeper(this, AuditRepository);
                //
                return _keeper;
            }
        }
        #endregion

        /*
         * Управление объектами
         */

        #region public Manipulator Manipulator { get; }
        /// <summary>
        /// Управление объектами
        /// </summary>
        private Manipulator _manipulator;
	    /// <summary>
        /// Управление объектами
        /// </summary>
        public Manipulator Manipulator
        {
            get
            {
                if (_manipulator == null) _manipulator = new Manipulator(this, AuditRepository);
                //
                return _manipulator;
            }
        }
		#endregion


		#region public INewLoader NewLoader { get; }

		private INewLoader _newLoader;

	    public INewLoader NewLoader
	    {
		    get { return _newLoader ?? (_newLoader = new NewLoader(this)); }
	    }

		#endregion


		#region public NewKeeper NewKeeper { get; }
	    /// <summary>
	    /// Загрузчик данных
	    /// </summary>
	    private INewKeeper _newKeeper;
	    /// <summary>
	    /// Загрузчик данных - За загрузку объектов отвечает отдельный класс
	    /// </summary>
	    public INewKeeper NewKeeper
	    {
		    get
		    {
			    if (_newKeeper == null) _newKeeper = new NewKeeper(this, AuditRepository);
			    return _newKeeper;
		    }
	    }
	    #endregion

		private IAircraftsCore _aircraftsCore;
		private IComponentCore _componentCore;

	    private IAuditRepository _auditRepository;

	    //TODO: врменный метод. IAircraftsCore должен передаваться через конструктор
		public void SetAircraftCore(IAircraftsCore aircraftsCore)
	    {
		    _aircraftsCore = aircraftsCore;
	    }

        public void SetComponentCore(IComponentCore componentCore)
        {
            _componentCore = componentCore;
        }
    }
}
