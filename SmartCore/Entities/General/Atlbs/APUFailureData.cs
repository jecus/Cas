using System;
using System.Linq;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Files;

namespace SmartCore.Entities.General.Atlbs
{
    /// <summary>
    /// Класс опысывает данные сбоя ВСУ
    /// </summary>
    [Table("ComponentFailureData", "dbo", "ItemId")]
	public class ApuFailureData : BaseEntityObject, IFileContainer
	{
		#region public Int32 BaseComponentId { get; set; }
		/// <summary>
		/// идентификатор базовой детали, на которой произошла авария
		/// </summary>
		public int BaseComponentId { get; set; }

        #endregion

        #region public Int32 RunUpId { get; set; }
        /// <summary>
        /// идентификатор запуска, во время которого произошла авария
        /// </summary>
        public Int32 RunUpId { get; set; }

        #endregion

        #region OVER TEMP DATA

        #region public Int32 TotalTimeAboveGageLine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("TotalTimeAboveGageLine")]
        public Int32 TotalTimeAboveGageLine { get; set; }
        #endregion

        #region public Int32 PeakEGTAttained { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("PeakEGTAttained")]
        public Int32 PeakEGTAttained { get; set; }
        #endregion

        #region public Int32 TotalTimeAtPeakEGT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("TotalTimeAtPeakEGT")]
        public Int32 TotalTimeAtPeakEGT { get; set; }
        #endregion

        #endregion

        #region PRIOR TO FAILURE

        #region public Int32 N1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("N1")]
        public Int32 N1 { get; set; }
        #endregion

        #region public Int32 N2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("N2")]
        public Int32 N2 { get; set; }
        #endregion

        #region public Int32 EGT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("EGT")]
        public Int32 EGT { get; set; }
        #endregion

        #region public Int32 OilPress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("OilPress")]
        public Int32 OilPress { get; set; }
        #endregion

        #region public Int32 OilTemp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("OilTemp")]
        public Int32 OilTemp { get; set; }
        #endregion

        #region public Int32 FuelFlow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelFlow")]
        public Int32 FuelFlow { get; set; }
        #endregion

        #region public Int32 FuelBurn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelBurn")]
        public Int32 FuelBurn { get; set; }
        #endregion

        #region public Boolean IfStallItWas { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("IfStallItWas")]
        public Boolean IfStallItWas { get; set; }
        #endregion

        #endregion

        #region FLIGHT CONDITIONS

        #region public Int32 ALT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("ALT")]
        public Int32 ALT { get; set; }
        #endregion

        #region public Int32 IAS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("IAS")]
        public Int32 IAS { get; set; }
        #endregion

        #region public Int32 TAT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("TAT")]
        public Int32 TAT { get; set; }
        #endregion

        #region public Int32 OAT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("OAT")]
        public Int32 OAT { get; set; }
        #endregion

        #region public Int32 Mach { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("Mach")]
        public Int32 Mach { get; set; }
        #endregion

        #region public FlightRegime FlightRegime { get; set; }
        /// <summary>
        /// Режим полета
        /// </summary>
        [TableColumnAttribute("FlightRegime")]
        public FlightRegime FlightRegime { get; set; }
        #endregion

        #region public Int32 TimeInRegime { get; set; }
        /// <summary>
        /// Время в указанном режиме полета
        /// </summary>
        [TableColumnAttribute("TimeInRegime")]
        public Int32 TimeInRegime { get; set; }
        #endregion

        #region public WeatherCondition Weather { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("Weather")]
        public WeatherCondition Weather { get; set; }
        #endregion

        #endregion

        #region FUEL CONDITIONS

        #region public Int32 FuelTempTank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelTempTank")]
        public Int32 FuelTempTank { get; set; }
        #endregion

        #region public Int32 FuelTempEngine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelTempEngine")]
        public Int32 FuelTempEngine { get; set; }
        #endregion

        #region public Boolean FuelHeat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelHeat")]
        public Boolean FuelHeat { get; set; }
        #endregion

        #region public Boolean FuelDump { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelDump")]
        public Boolean FuelDump { get; set; }
        #endregion

        #region public Int32 FuelDumpAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FuelDumpAmount")]
        public Int32 FuelDumpAmount { get; set; }
        #endregion

        #region public Boolean TankToEngine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("TankToEngine")]
        public Boolean TankToEngine { get; set; }
        #endregion

        #region public String CenterTankToEngines { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("CenterTankToEngines")]
        public String CenterTankToEngines { get; set; }
        #endregion

        #region public String InboardToEngines { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("InboardToEngines")]
        public String InboardToEngines { get; set; }
        #endregion

        #endregion

        #region OTHER CONDITIONS AT TIME OF FAILURE/SHUTDOWN

        #region public DateTime FirstFailureIndication { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FirstFailureIndication")]
        public DateTime FirstFailureIndication { get; set; }
        #endregion

        #region public PowerLoss PowerLoss { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("PowerLoss")]
        public PowerLoss PowerLoss { get; set; }
        #endregion

        #region public AntiIce AntiIce { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("AntiIce")]
        public AntiIce AntiIce { get; set; }
        #endregion

        #region public RunUpCondition RelightCondition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("RelightCondition")]
        public RunUpCondition RelightCondition { get; set; }
        #endregion

        #endregion

        #region public String Remarks { get; set; }

        public String Remarks { get; set; }
		#endregion

		#region public AttachedFile AttachedFile { get; set; }
		private AttachedFile _attachedFile;
		/// <summary>
		/// 
		/// </summary>
		public AttachedFile AttachedFile
	    {
			get
			{
				return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.ApuFailureDataAttachedFile));
			}
			set
			{
				_attachedFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.ApuFailureDataAttachedFile);
			}
		}

	    #endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

	    [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1035)]
		public CommonCollection<ItemFileLink> Files
		{
			get { return _files ?? (_files = new CommonCollection<ItemFileLink>()); }
			set
			{
				if (_files != value)
				{
					if (_files != null)
						_files.Clear();
					if (value != null)
						_files = value;
				}
			}
		}

		#endregion

	    public ApuFailureData()
	    {
		    ItemId = -1;
			SmartCoreObjectType = SmartCoreType.ApuFailureData;
	    }
	}
}
