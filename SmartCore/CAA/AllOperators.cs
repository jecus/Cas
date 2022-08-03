using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using CAA.Entity.Models.DTO;
using SmartCore.CAA.Operators;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Management;

namespace SmartCore.CAA
{
    public enum Cat
    {
        Commertial,
        NotCommertial,
        None
    }

    public enum Type
    {
        AirOperator,
        AMO,
        CAMO,
        CAO,
        AerodromOperator,
        ATCANS,
        Fuel,
        AeMC,
        ATO,
        None

    }

    [CAADto(typeof(AllOperatorsDTO))]
    [Serializable]
    public class AllOperators : BaseEntityObject, IAllOperatorFilterParams
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
            get { return _logoTypeImageByteView ?? (_logoTypeImageByteView = new byte[0]); ; }
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
        public string Privilages { get; set; }
        public string Ratings { get; set; }
        
        public string CEO { get; set; }
        public int  OperatorStatusId { get; set; }


        public string IATACode { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public bool IsAirOperator { get; set; }
        public bool IsCAMO { get; set; }
        public bool IsCAO { get; set; }
        public bool IsOther { get; set; }


        public string TypeString => TypeFilter.ToString();

        public Type TypeFilter
        {
            get
            {
                if (IsAirOperator)
                    return Type.AirOperator;
                if (IsAMO)
                    return Type.AMO;
                if (IsCAMO)
                    return Type.CAMO;
                if (IsCAO)
                    return Type.CAO;
                if (IsAerodromOperator)
                    return Type.AerodromOperator;
                if (IsATC)
                    return Type.ATCANS;
                if (IsFuel)
                    return Type.Fuel;
                if (IsAEMS)
                    return Type.AeMC;
                if (IsTraningOperation)
                    return Type.ATO;

                return Type.None;
            }
        }

        public string CommertialString => CommertialFilter.ToString();


        public Cat CommertialFilter
        {
            get
            {
                if (!IsAirOperator)
                    return Cat.None;

                if (IsCommertial)
                    return Cat.Commertial;
                return Cat.NotCommertial;
            }
        }



        public string PrivilagesString => string.Join(", ", PrivilagesFilter);

        public List<Privileges> PrivilagesFilter
        {
            get
            {
                var res = new List<Privileges>();
                if (string.IsNullOrEmpty(Privilages)) return res;
                res.AddRange(Privileges.Items.Where(items => Privilages.Contains(items.FullName)));

                return res;

            }
        }

        public string TPOString => string.Join(", ", TPOFilter);

        public List<TypesOfOperations> TPOFilter
        {
            get
            {
                var res = new List<TypesOfOperations>();
                if (string.IsNullOrEmpty(TypeOperation)) return res;
                res.AddRange(TypesOfOperations.Items.Where(items => TypeOperation.Contains(items.FullName)));
                return res;

            }
        }

        public string SPOString => string.Join(", ", SPOFilter);

        public List<SpecialOperations> SPOFilter
        {
            get
            {
                var res = new List<SpecialOperations>();
                if (string.IsNullOrEmpty(SpecialOperation)) return res;
                res.AddRange(SpecialOperations.Items.Where(items => SpecialOperation.Contains(items.FullName)));
                return res;

            }
        }

        public string FleetString => string.Join(", ", FleetFilter);

        public List<Fleet> FleetFilter
        {
            get
            {
                var res = new List<Fleet>();
                if (string.IsNullOrEmpty(Fleet)) return res;
                res.AddRange(Operators.Fleet.Items.Where(items => Fleet.Contains(items.FullName)));
                return res;

            }
        }


        public override string ToString()
        {
            return !string.IsNullOrEmpty(FullName) ? FullName : ShortName;
        }


        private static AllOperators _unknown;
        public static AllOperators Unknown =>
            _unknown ?? (_unknown = new AllOperators
            {
                ShortName = "CAA",
                FullName = "CAA",
                ItemId = -1
            });
    }
}
