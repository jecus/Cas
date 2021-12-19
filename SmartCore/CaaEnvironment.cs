using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CAS.Entity.Models.DTO.General;
using CAS.UI.Helpers;
using Entity.Abstractions;
using SmartCore.AuditMongo.Repository;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.NewLoader;
using SmartCore.Management;
using SmartCore.Queries;

namespace SmartCore
{
    public interface ICaaEnvironment : IBaseEnvironment
    {

    }

    public class CaaEnvironment : ICaaEnvironment
    {
        public OperatorCollection Operators { get; set; }
        public IAuditRepository AuditRepository { get; set; }
        public ApiProvider ApiProvider { get; set; }

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

        public void InitAsync(BackgroundWorker backgroundWorker, LoadingState loadingState)
        {
            // Загрузка всех операторов
            loadingState.CurrentPersentage = 3;
            loadingState.CurrentPersentageDescription = "Loading Operators";
            backgroundWorker.ReportProgress(1, loadingState);

            Operators = new OperatorCollection(_newLoader.GetObjectList<OperatorDTO, Operator>().ToArray());

            if (backgroundWorker.CancellationPending)
            {
                return;
            }
        }

        #endregion

        public void UpdateUser(string password)
        {
            ApiProvider.UpdatePassword(IdentityUser.ItemId, password);
        }


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

    }
}
