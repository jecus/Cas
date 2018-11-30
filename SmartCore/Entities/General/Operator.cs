using System;
using System.Drawing;
using System.Drawing.Imaging;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Management;

namespace SmartCore.Entities.General
{

    /// <summary>
    /// Класс описывает оператора 
    /// </summary>
    [Serializable]
    public class Operator : BaseEntityObject, IComponentContainer
	{

		/*
		*  Свойства
		*/

		#region public String Name { get; set; }

        private string _name;
		/// <summary>
		/// Название эксплуатанта
		/// </summary>
		public String Name 
        { 
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
		}
		#endregion

		#region public Byte[] LogoType { get; set; }

        private Byte[] _logoType;
        /// <summary>
        /// Логотип эксплуатанта
        /// </summary>
        public Byte[] LogoType
        {
            get { return _logoType; } 
            set
            {
                _logoType = value;
                OnPropertyChanged("LogoType");
            }
        }
		#endregion

		#region public String ICAOCode { get; set; }

        private string _icaoCode;
        /// <summary>
        /// ICAO код оператора
        /// </summary>
        public String ICAOCode
        {
            get { return _icaoCode; }
            set
            {
                _icaoCode = value;
                OnPropertyChanged("ICAOCode");
            }
        }
		#endregion

		#region public String Address { get; set; }

        private string _address;

        /// <summary>
        /// Адрес оператора
        /// </summary>
        public String Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }
		#endregion

		#region public String Phone { get; set; }

        private string _phone;
        /// <summary>
        /// Телефон оператора
        /// </summary>
        public String Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }
		#endregion

		#region public String Fax { get; set; }

        private string _fax;
        /// <summary>
        /// Факс оператора
        /// </summary>
        public String Fax
        {
            get { return _fax; }
            set
            {
                _fax = value;
                OnPropertyChanged("Fax");
            }
        }
		#endregion

		#region public Byte[] LogoTypeWhite { get; set; }

        private Byte[] _logoTypeWhite;
        /// <summary>
        /// 
        /// </summary>
        public Byte[] LogoTypeWhite
        {
            get { return _logoTypeWhite ?? (_logoTypeWhite = new byte[0]); }
            set
            {
                _logoTypeWhite = value;
                OnPropertyChanged("LogoTypeWhite");
            }
        }
		#endregion

        #region public Byte[] LogotypeReportLarge { get; set; }

        private Byte[] _logotypeReportLarge;
        /// <summary>
        /// Логопит оператора (широкий) для отчета
        /// </summary>
        public Byte[] LogotypeReportLarge
        {
            get { return _logotypeReportLarge ?? (_logotypeReportLarge = new byte[0]); }
            set
            {
                _logotypeReportLarge = value;
                OnPropertyChanged("LogotypeReportLarge");
            }
        }
        #endregion

        #region public Byte[] LogotypeReportVeryLarge { get; set; }

        private Byte[] _logotypeReportVeryLarge;
        /// <summary>
        /// Логопит оператора (очень широкий) для отчета
        /// </summary>
        public Byte[] LogotypeReportVeryLarge
        {
            get { return _logotypeReportVeryLarge ?? (_logotypeReportVeryLarge = new byte[0]); }
            set
            {
                _logotypeReportVeryLarge = value;
                OnPropertyChanged("LogotypeReportVeryLarge");
            }
        }
        #endregion

        #region public Image LogoTypeWhiteImage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Image LogoTypeWhiteImage
        {
            get
            {
                return DbTypes.BytesToImage(LogoTypeWhite);
            }
            set
            {
                LogoTypeWhite = DbTypes.ImageToBytes(value, ImageFormat.Png);
                OnPropertyChanged("LogoTypeWhiteImage");
            }
        }
        #endregion

        #region public Image LogoTypeImage { get; set; }

        public Image LogoTypeImage
        {
            get
            {
                return DbTypes.BytesToImage(LogoTypeImageByteView);
            }
            set
            {
                LogoTypeImageByteView = DbTypes.ImageToBytes(value, ImageFormat.Png);
                OnPropertyChanged("LogoTypeImage");
            
            }
        }

        #endregion

        #region public Image LogotypeReportLargeImage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Image LogotypeReportLargeImage
        {
            get
            {
                return DbTypes.BytesToImage(LogotypeReportLarge);
            }
            set
            {
                LogotypeReportLarge = DbTypes.ImageToBytes(value, ImageFormat.Png);
                OnPropertyChanged("LogotypeReportLargeImage");
            }
        }
        #endregion

        #region public Image LogotypeReportVeryLargeImage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Image LogotypeReportVeryLargeImage
        {
            get
            {
                return DbTypes.BytesToImage(LogotypeReportVeryLarge);
            }
            set
            {
                LogotypeReportVeryLarge = DbTypes.ImageToBytes(value, ImageFormat.Png);
                OnPropertyChanged("LogotypeReportVeryLargeImage");
            }
        }
        #endregion

        #region public Byte[] LogoTypeImageByteView { get; set; }

        private Byte[] _logoTypeImageByteView;

        public Byte[] LogoTypeImageByteView
        {
            get {return _logoTypeImageByteView; }
            set
            {
                _logoTypeImageByteView = value;
                OnPropertyChanged("LogoTypeImageByteView");
            }
        }

        #endregion

		#region public String Email { get; set; }

        private String _email;
        /// <summary>
        /// 
        /// </summary>
        public String Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
		#endregion
		
		/*
		*  Методы 
		*/
		
		#region public Operator()
        /// <summary>
        /// Создает воздушное судно без дополнительной информации
        /// </summary>
        public Operator()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.Operator;
        }
        #endregion
      
        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
        #endregion

    }

}
