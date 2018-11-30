using System;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Atlbs
{
    /// <summary>
    /// Класс описывает данные сбоя по двигателю
    /// </summary>
    class EngineFailureData : ApuFailureData
    {
        #region OTHER CONDITIONS AT TIME OF FAILURE/SHUTDOWN

        #region public ThrustLever ThrustLever { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("ThrustLever")]
        public ThrustLever ThrustLever { get; set; }
        #endregion

        #endregion

        #region WINDMILLING INFORMATION

        #region public Int32 WMALT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("WMALT")]
        public Int32 WMALT { get; set; }
        #endregion

        #region public Int32 WMOilPress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("WMOilPress")]
        public Int32 WMOilPress { get; set; }
        #endregion

        #region public Int32 TotalTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("TotalTime")]
        public Int32 TotalTime { get; set; }
        #endregion

        #region public Int32 WMIAS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("WMIAS")]
        public Int32 WMIAS { get; set; }
        #endregion

        #region public Int32 WMN1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("WMN1")]
        public Int32 WMN1 { get; set; }
        #endregion

        #region public Int32 WMN2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("WMN2")]
        public Int32 WMN2 { get; set; }
        #endregion

        #region public Boolean FireSwitch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("FireSwitch")]
        public Boolean FireSwitch { get; set; }
        #endregion

        #endregion
    }
}
