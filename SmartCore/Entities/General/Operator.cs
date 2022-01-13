using System;
using System.Drawing;
using System.Drawing.Imaging;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Management;

namespace SmartCore.Entities.General
{

    /// <summary>
    /// ����� ��������� ��������� 
    /// </summary>
    [Serializable]
    [Dto(typeof(OperatorDTO))]
    [CAADto(typeof(CAAOperatorDTO))]
	public class Operator : BaseEntityObject, IComponentContainer
	{

		/*
		*  ��������
		*/

		#region public String Name { get; set; }

        private string _name;
		/// <summary>
		/// �������� ������������
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
        /// ������� ������������
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
        /// ICAO ��� ���������
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
        /// ����� ���������
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
        /// ������� ���������
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
        /// ���� ���������
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
        /// ������� ��������� (�������) ��� ������
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
        /// ������� ��������� (����� �������) ��� ������
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

        public Byte[] LogoTypeImageByteView
        {
            get { return _logoType ?? (_logoType = new byte[0]); }
            set
            {
                _logoType = value;
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
		*  ������ 
		*/
		
		#region public Operator()
        /// <summary>
        /// ������� ��������� ����� ��� �������������� ����������
        /// </summary>
        public Operator()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.Operator;
        }
        #endregion
      
        #region public override string ToString()
        /// <summary>
        /// ����������� ��� �������
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
        #endregion

    }

}
