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
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.General;
using CAS.UI.Helpers;
using Entity.Abstractions;
using SmartCore.AuditMongo.Repository;
using SmartCore.CAA;
using SmartCore.CAA.Repositories;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.NewLoader;
using SmartCore.Management;
using SmartCore.ObjectCache;
using SmartCore.Queries;
using Type = System.Type;

namespace SmartCore
{
    public interface ICaaEnvironment : IBaseEnvironment
    {
        int ObtainId();
        AircraftCollection Aircraft { get; set; }
        List<AllOperators> AllOperators { get; set; }
        
         ICaaPerformanceRepository CaaPerformanceRepository { get; set; }
        
        

    }

    public class CaaEnvironment : ICaaEnvironment
    {
        public CaaEnvironment()
        {
            _dictionaries = new CommonDictionariesCache();
        }


        public OperatorCollection Operators { get; set; }
        public AircraftCollection Aircraft { get; set; }
        public List<AllOperators> AllOperators { get; set; }
        public IAuditRepository AuditRepository { get; set; }
        public ICaaPerformanceRepository CaaPerformanceRepository { get; set; }
        public ApiProvider ApiProvider { get; set; }


        public int ObtainId()
        {
            var ds = _newLoader.Execute("SELECT NEXT VALUE FOR item_counter");
            return (int)ds.Tables[0].Rows[0][0];
        }

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

        #region public CommonCollection<Store> User { get; internal set; }

        public Dictionary<int, string> Users { get; set; }
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
                    _currentUser = new UserDTO() { Name = "Error" };

                return _currentUser;
            }
            set { _currentUser = value; }
        }
        #endregion

        public void InitAsync(BackgroundWorker backgroundWorker, LoadingState loadingState)
        {
            if (backgroundWorker == null) return;

            if (loadingState == null)
                loadingState = new LoadingState();
            loadingState.MaxPersentage = 10;

            //Загрузка всех пользователей
            loadingState.CurrentPersentage = 0;
            loadingState.CurrentPersentageDescription = "Loading Users";
            backgroundWorker.ReportProgress(1, loadingState);

            var users = ApiProvider.GetAllUsersAsync();
            Users = new Dictionary<int, string>();
            foreach (var user in users)
                Users.Add(user.ItemId, user.ToString());

            if (backgroundWorker.CancellationPending)
            {
                return;
            }

            loadingState.CurrentPersentage = 1;
            loadingState.CurrentPersentageDescription = "Loading Operators";
            backgroundWorker.ReportProgress(1, loadingState);

            Operators = new OperatorCollection(_newLoader.GetObjectList<OperatorDTO, Operator>().ToArray());

            AllOperators = new List<AllOperators>(_newLoader.GetObjectList<AllOperatorsDTO, AllOperators>().ToArray());

            if (backgroundWorker.CancellationPending)
            {
                return;
            }

            loadingState.CurrentPersentage = 2;
            loadingState.CurrentPersentageDescription = "Loading Aircrafts";
            backgroundWorker.ReportProgress(1, loadingState);

            Aircraft = new AircraftCollection(_newLoader.GetObjectList<CAAAircraftDTO, Aircraft>().ToArray());

            if (backgroundWorker.CancellationPending)
            {
                return;
            }

            //Загрузка всех словарей
            loadingState.CurrentPersentage = 3;
            loadingState.CurrentPersentageDescription = "Loading Dictionaries";
            backgroundWorker.ReportProgress(1, loadingState);

            GetDictionaries();

            if (backgroundWorker.CancellationPending)
            {
                return;
            }
        }




        #region public CommonDictionariesCache Dictionaries

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

        public void GetDictionaries()
        {
            ClearDictionaries();

            var assembly = Assembly.GetAssembly(typeof(BaseEntityObject));
            var types = assembly.GetTypes()
                .Where(t => t.Namespace != null && t.IsClass && 
                            (t.Namespace.StartsWith("SmartCore.Entities.Dictionaries") || t.Namespace.StartsWith("SmartCore.CAA")));

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
                    var bl = (CAADtoAttribute)type.GetCustomAttributes(typeof(CAADtoAttribute), false).FirstOrDefault();

                    var tt = bl?.Type;
                    if (tt == null)
                    {
                        var caaBl = (DtoAttribute)type.GetCustomAttributes(typeof(DtoAttribute), false).FirstOrDefault();
                        tt = caaBl.Type;
                    }

                    var typeDict = dca == null
                        ? new CommonDictionaryCollection<AbstractDictionary>()
                        : dca.GetInstance();

                    IEnumerable items = _newLoader.GetObjectList(tt, type, true);
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

        public void UpdateUser(string password)
        {
            ApiProvider.UpdatePassword(IdentityUser.ItemId, password);
        }

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

        public void SaveAsFile(AttachedFile attachedFile, string filePath, out string message)
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

        #region public INewLoader NewLoader { get; }

        private INewLoader _newLoader;

        public INewLoader NewLoader
        {
            get { return _newLoader ?? (_newLoader = new NewLoader(this)); }
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
            ApiProvider.CheckAPIConnection();

            var user = ApiProvider.GetUserAsync(userName, pass);
            if (user == null)
                throw new Exception($"Invalid combination of login and password");

            IdentityUser = user;
            AuditRepository.WriteAsync(new Entities.User(user), AuditOperation.SignIn, user);

            _newLoader = new NewLoader(this);
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

    }
}
