using System;

namespace CASTerms
{
    /// <summary>
    /// Класс хранящий инфомацию о лицензии системы
    /// </summary>
    public class LicenseInformation
    {
        #region Fields

        /// <summary>
        /// Название компании, для которой выписан ключ
        /// </summary>
        private string _company = "";

        /// <summary>
        /// Дата истечения релиза или демо-версии
        /// </summary>
        private DateTime _expires= DateTime.MinValue;

        /// <summary>
        /// Ключ, единый для компании
        /// </summary>
        private string _productKey = "";

        /// <summary>
        /// Сковозной номер ключа
        /// </summary>
        private string _keyNo = "";

        /// <summary>
        /// Версия программы
        /// </summary>
        private string _version = "";

        /// <summary>
        /// Компании разрешено использовать только одного 
        /// </summary>
        private bool _singleOperator;

        /// <summary>
        /// Ограничение по кол-ву ВС
        /// </summary>
        private int _maxAircrafts;

        /// <summary>
        /// Работает ли CAS с отчетами BiWeekly
        /// </summary>
        private bool _biWeeklies = true;

        /// <summary>
        /// Возможно ли редактирование отчетов
        /// </summary>
        private bool _editTemplates = true;

        /// <summary>
        /// Дата установки системы
        /// </summary>
        private DateTime _installationDate;


        private const int EvaluationPeriod = 45;

        #endregion

        #region Constructors

        #region public LicenseInformation(string company, DateTime expires, string productKey, string keyNo, string version, bool singleOperator, int maxAircrafts, bool biWeeklies, bool editTemplates)


        /// <summary>
        /// Создается класс хранящий инфомацию о лицензии системы
        /// </summary>
        /// <param name="company">Название компании, для которой выписан ключ</param>
        /// <param name="expires">Дата истечения релиза или демо-версии</param>
        /// <param name="productKey">Ключ, единый для компании</param>
        /// <param name="keyNo">Сковозной номер ключа</param>
        /// <param name="version">Версия программы</param>
        /// <param name="biWeeklies">Работает ли CAS с отчетами BiWeekly</param>
        /// <param name="editTemplates">Возможно ли редактирование отчетов</param>
        /// <param name="maxAircrafts">Ограничение по кол-ву ВС</param>
        /// <param name="singleOperator">Компании разрешено использовать только одного </param>
        public LicenseInformation(string company, DateTime expires, string productKey, string keyNo, string version, bool singleOperator, int maxAircrafts, bool biWeeklies, bool editTemplates)
        {
            this._company = company;
            this._expires = expires;
            this._productKey = productKey;
            this._keyNo = keyNo;
            this._version = version;
            this._singleOperator = singleOperator;
            this._maxAircrafts = maxAircrafts;
            this._biWeeklies = biWeeklies;
            this._editTemplates = editTemplates;
        }

        #region public LicenseInformation(string productKey, string company)

        /// <summary>
        /// Создается класс хранящий инфомацию о лицензии системы
        /// </summary>
        /// <param name="productKey">Название компании, для которой выписан ключ</param>
        /// <param name="company">Ключ, единый для компании</param>
        public LicenseInformation(string productKey, string company)
        {
            this._productKey = productKey;
            this._company = company;
        }

        #endregion

        #region public LicenseInformation(string productKey, string company, DateTime installationDate)

        /// <summary>
        /// Создается класс хранящий инфомацию о лицензии системы
        /// </summary>
        /// <param name="company">Ключ, единый для компании</param>
        /// <param name="installationDate">Дата установки системы</param>
        public LicenseInformation(string company, DateTime installationDate)
        {
            this._company = company;
            this._installationDate = installationDate;
            _expires = installationDate.AddDays(EvaluationPeriod);

        }

        #endregion


        #region         public LicenseInformation(string company, DateTime expires, string productKey, string version, bool singleOperator, int maxAircrafts, bool biWeeklies, bool editTemplates)

        /// <summary>
        /// Создается класс хранящий инфомацию о лицензии системы
        /// </summary>
        /// <param name="company">Название компании, для которой выписан ключ</param>
        /// <param name="expires">Дата истечения релиза или демо-версии</param>
        /// <param name="productKey">Ключ, единый для компании</param>
        /// <param name="version">Версия программы</param>
        /// <param name="biWeeklies">Работает ли CAS с отчетами BiWeekly</param>
        /// <param name="editTemplates">Возможно ли редактирование отчетов</param>
        /// <param name="maxAircrafts">Ограничение по кол-ву ВС</param>
        /// <param name="singleOperator">Компании разрешено использовать только одного </param>
        public LicenseInformation(string company, DateTime expires, string productKey, string version, bool singleOperator, int maxAircrafts, bool biWeeklies, bool editTemplates)
        {
            this._company = company;
            this._expires = expires;
            this._productKey = productKey;
            this._version = version;
            this._singleOperator = singleOperator;
            this._maxAircrafts = maxAircrafts;
            this._biWeeklies = biWeeklies;
            this._editTemplates = editTemplates;
        }

        #endregion

        #endregion

        public LicenseInformation()
        {
            
        }
        #endregion


        #region Properties

        #region public DateTime InstallationDate
        /// <summary>
        /// Дата установки системы
        /// </summary>
        public DateTime InstallationDate
        {
            get { return _installationDate; }
            set { _installationDate = value; }
        }

        #endregion

        #region public string Company

        /// <summary>
        /// Название компании, для которой выписан ключ
        /// </summary>
        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }

        #endregion

        #region public DateTime Expires

        /// <summary>
        /// Дата истечения релиза или демо-версии
        /// </summary>
        public DateTime Expires
        {
            get { return _expires; }
            set { _expires = value; }
        }

        #endregion

        #region public string ProductKey

        /// <summary>
        /// Ключ, единый для компании
        /// </summary>
        public string ProductKey
        {
            get { return _productKey; }
            set { _productKey = value; }
        }

        #endregion

        #region public string KeyNo

        /// <summary>
        /// Сковозной номер ключа
        /// </summary>
        public string KeyNo
        {
            get { return _keyNo; }
            set { _keyNo = value; }
        }

        #endregion

        #region public string Version
        /// <summary>
        /// Версия программы
        /// </summary>
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        #endregion

        #region public bool SingleOperator

        /// <summary>
        /// Компании разрешено использовать только одного 
        /// </summary>
        public bool SingleOperator
        {
            get { return _singleOperator; }
            set { _singleOperator = value; }
        }

        #endregion

        #region public int MaxAircrafts

        /// <summary>
        /// Ограничение по кол-ву ВС
        /// </summary>
        public int MaxAircrafts
        {
            get { return _maxAircrafts; }
            set { _maxAircrafts = value; }
        }

        #endregion

        #region public bool BiWeeklies

        /// <summary>
        /// Работает ли CAS с отчетами BiWeekly
        /// </summary>
        public bool BiWeeklies
        {
            get { return _biWeeklies; }
            set { _biWeeklies = value; }
        }

        #endregion

        #region public bool EditTemplates

        /// <summary>
        /// Возможно ли редактирование отчетов
        /// </summary>
        public bool EditTemplates
        {
            get { return _editTemplates; }
            set { _editTemplates = value; }
        }

        #endregion

        #endregion
    }
}
