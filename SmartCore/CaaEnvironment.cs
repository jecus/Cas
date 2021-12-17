using System;
using CAS.UI.Helpers;
using EntityCore.DTO.General;
using SmartCore.AuditMongo.Repository;
using SmartCore.Entities.NewLoader;

namespace SmartCore
{
    public interface ICaaEnvironment : IBaseEnvironment
    {

    }

    public class CaaEnvironment : ICaaEnvironment
    {
        public IAuditRepository AuditRepository { get; set; }
        public ApiProvider ApiProvider { get; set; }

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
