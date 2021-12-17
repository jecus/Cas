using System;
using System.Linq;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General
{
    /// <summary>
    /// Класс описывает запись об актуальном состоянии
    /// </summary>
    [Serializable]
    [Table("ActualStateRecords", "dbo", "ItemId")]
    [Dto(typeof(ActualStateRecordDTO))]
	[Condition("IsDeleted", "0")]
    public class ActualStateRecord : AbstractRecord
    {
        private static Type _thisType;

		/*
        *  Свойства
        */

		#region public Int32 ComponentId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("ComponentId")]
        public int ComponentId { get; set; }

        public static PropertyInfo ComponentIdProperty
        {
            get { return GetCurrentType().GetProperty("ComponentId"); }
        }

		#endregion

        #region public SmartCoreType WorkRegimeType { get; set; }
        
        private SmartCoreType _workRegimeType;
        /// <summary>
        /// Тип работы агрегата (н: полетный режим или LLP-категория)
        /// </summary>
        [TableColumn("WorkRegimeTypeId")]
        [ListViewData(0.2f, "Work Regime Type")]
        public SmartCoreType WorkRegimeType
        {
            get
            {
                if (_workRegime == null && _workRegimeType == null)
                    _workRegimeType = SmartCoreType.Unknown;
                return _workRegimeType;
            }
            set { _workRegimeType = value; }
        }

        #endregion

        #region public IWorkRegime WorkRegime { get; set; }

        private IWorkRegime _workRegime;

        /// <summary>
        /// Режим работы агрегата
        /// </summary>
        [TableColumnAttribute("FlightRegimeId", "WorkRegimeType")]
        public IWorkRegime WorkRegime
        {
            get { return _workRegime ?? (_workRegime = FlightRegime.UNK); }
            set
            {
                if (value == null)
                    _workRegimeType = SmartCoreType.Unknown;
                else if (value is BaseEntityObject)
                    _workRegimeType = ((BaseEntityObject)value).SmartCoreObjectType;
                else if (value.GetType().IsEnum)
                    _workRegimeType = SmartCoreType.Items.Where(i => i.ObjectType != null && i.ObjectType.Name == value.GetType().Name).First();
                else _workRegimeType = SmartCoreType.Unknown;

                if (_workRegime != value)
                {
                    _workRegime = value;
                    OnPropertyChanged("FlightRegime");
                }
            }
        }
        #endregion

        #region Implement of AbstractRecord

        #region public override String Remarks { get; set; }

        private string _remarks;
        /// <summary>
        /// Remarks
        /// </summary>
        [TableColumnAttribute("Remarks")]
        public override String Remarks
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

        #region public override Lifelength OnLifelength { get; set; }

        private Lifelength _onLifelength;
        /// <summary>
        /// наработка при которой была выполнена директива
        /// </summary>
        [TableColumnAttribute("OnLifelength")]
        public override Lifelength OnLifelength
        {
            get { return _onLifelength; } 
            set
            {
                if(_onLifelength != value)
                {
                    _onLifelength = value;
                    OnPropertyChanged("OnLifelength");
                }
            }
        }
		#endregion

        #region public override DateTime RecordDate { get; set; }

        private DateTime _recordDate;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("RecordDate")]
        public override DateTime RecordDate
        {
            get { return _recordDate; } 
            set
            {
                if(_recordDate != value)
                {
                    _recordDate = value;
                    OnPropertyChanged("RecordDate");
                }
            }
        }
		#endregion

		#endregion
		/*
         * Дополнительные свойства
         */

		#region public Component ParentComponent { get; internal set; }
		/// <summary>
		/// Агрегат для которого задано актуальное состояние - Нужно смотреть оба свойства ParentComponent и ParentBaseComponent
		/// </summary>
		public Accessory.Component ParentComponent { get; internal set; }
        #endregion

        /*
		*  Методы 
		*/
		
		#region public ActualStateRecord()
        /// <summary>
        /// Создает воздушное судно без дополнительной информации
        /// </summary>
        public ActualStateRecord()
        {
            ItemId = -1;
            _workRegime = FlightRegime.UNK;
            _workRegimeType = SmartCoreType.FlightRegime;
            SmartCoreObjectType = SmartCoreType.ActualStateRecord;
        }
        #endregion

        #region public ActualStateRecord(ActualStateRecord toCopy) : this()
        /// <summary>
        /// Создает воздушное судно без дополнительной информации
        /// </summary>
        public ActualStateRecord(ActualStateRecord toCopy) : this()
        {
            if(toCopy == null)
                return;
            ComponentId = toCopy.ComponentId;
            _onLifelength = new Lifelength(toCopy.OnLifelength);
            ParentComponent = toCopy.ParentComponent;
            _recordDate = toCopy.RecordDate.Date;
            _remarks = toCopy.Remarks;
            _workRegime = toCopy.WorkRegime;
            _workRegimeType = toCopy.WorkRegimeType;

        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(ActualStateRecord));
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return RecordDate.Date.ToShortDateString() + " " + OnLifelength;
        }
        #endregion

        public new ActualStateRecord GetCopyUnsaved(bool marked = true)
        {
            ActualStateRecord asr = (ActualStateRecord) MemberwiseClone();
            asr.ItemId = -1;
            asr.UnSetEvents();

            asr.OnLifelength =new Lifelength(OnLifelength);

            return asr;
        }

    }

}
