using System;
using System.Drawing;
using System.Drawing.Imaging;
using SmartCore.Entities.General;
using SmartCore.Management;

namespace SmartCore.CAA
{
    public class CaaOpearatorDto : BaseEntityObject
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string ICAOCode { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }

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
            get { return _logoTypeImageByteView; }
            set
            {
                _logoTypeImageByteView = value;
                OnPropertyChanged("LogoTypeImageByteView");
            }
        }

        #endregion

        public bool IsCommertial { get; set; }
        public bool IsAEMS { get; set; }
        public bool IsAerodromOperator { get; set; }
        public bool IsAMO { get; set; }
        public bool IsTraningOperation { get; set; }
        public bool IsFuel { get; set; }
        public bool IsATC { get; set; }

        public string TypeOperation { get; set; }
        public string SpecialOperation { get; set; }
        public string Fleet { get; set; }
        public string AemcPrivilages { get; set; }
        public string Ratings { get; set; }
        public string TraningOrgPrivilages { get; set; }

    }
}
