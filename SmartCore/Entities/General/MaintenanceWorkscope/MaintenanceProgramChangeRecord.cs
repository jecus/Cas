using System;
using EntityCore.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.MaintenanceWorkscope
{
    /// <summary>
    /// Содержит данные о выполнении данного чека
    /// </summary>
    [Table("MaintenanceProgramChangeRecords", "dbo", "ItemId")]
    [Dto(typeof(MaintenanceProgramChangeRecordDTO))]
	[Condition("IsDeleted", "0")]
    public class MaintenanceProgramChangeRecord: AbstractRecord
    {
        /*
         *  Свойства
         */

        #region public Aircraft ParentAircraft

        /// <summary>
        /// 
        /// </summary>
        private Aircraft _parentAircraft;
        [TableColumnAttribute("ParentAircraftId")]
        public int ParentAircraftId { get; set; }

        #endregion

        #region public MSG MSG

        /// <summary>
        /// 
        /// </summary>
        private MSG _msg;
        [TableColumnAttribute("MSG")]
        public MSG MSG
        {
            get
            {
                return _msg;
            }
            set
            {
                if (_msg != value)
                {
                    _msg = value;
                    OnPropertyChanged("MSG");
                }
            }
        }
        #endregion

        #region public int MaintenanceCheckRecordId

        /// <summary>
        /// 
        /// </summary>
        private int _maintenanceCheckRecordId;
        [TableColumnAttribute("MaintenanceCheckRecordId")]
        public int MaintenanceCheckRecordId
        {
            get
            {
                return _maintenanceCheckRecordId;
            }
            set
            {
                if (_maintenanceCheckRecordId != value)
                {
                    _maintenanceCheckRecordId = value;
                    OnPropertyChanged("MaintenanceCheckRecordId");
                }
            }
        }
        #endregion

        #region public Lifelength CalculatedPerformanceSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private Lifelength _calculatedPerformanceSource;
        [TableColumnAttribute("CalculatedPerformanceSource")]
        public Lifelength CalculatedPerformanceSource
        {
            get { return _calculatedPerformanceSource; }
            set
            {
                if (_calculatedPerformanceSource != value)
                {
                    _calculatedPerformanceSource = value;
                    OnPropertyChanged("CalculatedPerformanceSource");
                }
            }
        }
        #endregion

        #region public override Int32 PerformanceNum { get; set; }

        private int _performanceNum;
        /// <summary>
        /// Номер записи о выполнении
        /// </summary>
        [TableColumnAttribute("PerformanceNum")]
        public Int32 PerformanceNum
        {
            get { return _performanceNum; }
            set
            {
                if (_performanceNum != value)
                {
                    _performanceNum = value;
                    OnPropertyChanged("PerformanceNum");
                }
            }
        }
        #endregion

        #region Implement of AbstractRecord

        #region public override DateTime RecordDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private DateTime _recordDate;
        [TableColumnAttribute("RecordDate")]
        public override DateTime RecordDate
        {
            get { return _recordDate; }
            set
            {
                if (_recordDate != value)
                {
                    _recordDate = value;
                    OnPropertyChanged("RecordDate");
                }
            }
        }
        #endregion

        #region public override Lifelength OnLifelength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private Lifelength _performance;
        [TableColumnAttribute("OnLifelength")]
        public override Lifelength OnLifelength
        {
            get { return _performance ?? (_performance = new Lifelength()); }
            set
            {
                if (_performance != value)
                {
                    _performance = value;
                    OnPropertyChanged("Performance");
                }
            }
        }
        #endregion

        #region public override string Remarks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private string _remarks;
        [TableColumnAttribute("Remarks")]
        public override string Remarks
        {
            get { return _remarks; }
            set
            {
                if (_remarks != value)
                {
                    _remarks = value;
                    OnPropertyChanged("Remarks");
                }
            }
        }
        #endregion

        #endregion

        #region public MaintenanceProgramChangeRecord()

        public MaintenanceProgramChangeRecord()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.MaintenanceProgramChangeRecord;
            _msg = MSG.Unknown;
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, {1} {2}", _recordDate, _performance, _remarks);
        }
        #endregion

    }
}
