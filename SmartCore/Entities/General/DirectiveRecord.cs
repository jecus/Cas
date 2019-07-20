using System;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Files;
using SmartCore.Packages;

namespace SmartCore.Entities.General
{

    /// <summary>
    /// Класс описывает запись о выполнении задачи Directive или DetailDirective
    /// </summary>
    [Table("DirectivesRecords", "dbo", "ItemId")]
    [Dto(typeof(DirectiveRecordDTO))]
	[Condition("IsDeleted", "0")]
    [Serializable]
    public class DirectiveRecord : AbstractPerformanceRecord, IFileContainer// IComparable<DirectiveRecord>
	{
        private static Type _thisType;
        /*
        *  Свойства из базы данных
        */

        #region public Int32 RecordTypeId { get; set; }
        /// <summary>
		/// Идентификатор типа производимой работы
		/// </summary>
        [TableColumnAttribute("RecordTypeId")]
        public Int32 RecordTypeId { get; set; }
		#endregion

        #region Implement of AbstractPerformanceRecord

        #region override public Int32 ParentId { get; set; }

        private Int32 _parentId;
        /// <summary>
        /// Идентификатор детали, к которой пренадлежит запись
        /// </summary>
        [TableColumnAttribute("ParentId")]
        public override Int32 ParentId
        {
            get { return _parentId; } 
            set
            {
                if(_parentId != value)
                {
                    _parentId = value;
                    OnPropertyChanged("PatenrId");
                }
            }
        }

        public static PropertyInfo ParentIdProperty
        {
            get { return GetCurrentType().GetProperty("ParentId"); }
        }

        #endregion

        #region public override Int32 PerformanceNum { get; set; }

        private Int32 _performanceNum;
        /// <summary>
        /// Номер записи о выполнении
        /// </summary>
        [TableColumn("NumGroup")]
        public override Int32 PerformanceNum
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

        #region public override SmartCoreType ParentType

        private SmartCoreType _parentType;

        /// <summary>
        /// Тип родительской задачи
        /// </summary>
        [TableColumnAttribute("ParentTypeId")]
        public override SmartCoreType ParentType
        {
            get { return _parentType ?? SmartCoreType.Unknown; }
            internal set { _parentType = value; }
        }

        public static PropertyInfo ParentTypeIdProperty
        {
            get { return GetCurrentType().GetProperty("ParentType"); }
        }

        #endregion

        #region public IDirective Parent { get; set; }

        private IDirective _parent;
        /// <summary>
        /// Родительская задача
        /// </summary>
        public override IDirective Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                _parentType = (_parent != null ? _parent.SmartCoreObjectType : SmartCoreType.Unknown);
            }
        }

        #endregion

        #region public override DateTime RecordDate { get; set; }

        private DateTime _recordDate;
        /// <summary>
		/// Дата добавления записи
		/// </summary>
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
                if (_onLifelength != value)
                {
                    _onLifelength = value;
                    OnPropertyChanged("Performance");
                }
            }
        }
		#endregion

		#region public override AttachedFile AttachedFile { get; set; }
		[NonSerialized]
        private AttachedFile _attachedFile;
        /// <summary>
        /// 
        /// </summary>
        public override AttachedFile AttachedFile
        {
			get
			{
				return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.DirectiveRecordAttachedFile));
			}
			set
			{
				_attachedFile = value;
				OnPropertyChanged("AttachedFile");
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.DirectiveRecordAttachedFile);
			}
		}
        #endregion

        #region public override Int32 DirectivePackageId { get; set; }

        private Int32 _directivePackageId;
        /// <summary>
        /// используется, только если запись создана workpackage - м
        /// </summary>
        [TableColumnAttribute("WorkPackageId")]
        public override Int32 DirectivePackageId
        {
            get { return _directivePackageId; } 
            set
            {
                if(_directivePackageId != value)
                {
                    _directivePackageId = value;
                    OnPropertyChanged("DirectivePackageId");
                }
            }
        }
        #endregion

        #region public override IDirectivePackage DirectivePackage { get; set; }

        private IDirectivePackage _directivePackage;
        /// <summary>
        /// используется, только если запись создана workpackage - м
        /// </summary>
        public override IDirectivePackage DirectivePackage
        {
            get { return _directivePackage; } 
            set
            {
                if (_directivePackage != value)
                {
                    _directivePackage = value;
                    OnPropertyChanged("DirectivePackage");
                }
            }
        }
        #endregion
       
        #region public override string Remarks { get; set; }

        private string _remarks;
        /// <summary>
        /// Описание
        /// </summary>
        [TableColumnAttribute("Remarks")]
        public override string Remarks
        {
            get { return _remarks; } 
            set
            {
                if(_remarks != value)
                {
                    _remarks = value;
                    OnPropertyChanged("Remarks");
                }
            }
        }
		#endregion

        #region public override Lifelength Unused { get; set; }
        /// <summary>
        /// неизрасходованный ресурс 
        /// ресурс, на котором надо выполнить директиву - ресурс, на котором она была выполнена
        /// записываются только положительные значения, включая 0
        /// </summary>
        //[Savable]
        public override Lifelength Unused { get; set; }
        #endregion

        #region public override Lifelength Overused { get; set; }
        /// <summary>
        /// перерасходованный ресурс 
        /// ресурс, на котором она была выполнена - ресурс, на котором надо выполнить директиву 
        /// записываются только положительные значения, включая 0
        /// </summary>
        //[Savable]
        public override Lifelength Overused { get; set; }
        #endregion

        #endregion 

		#region public DateTime Dispatched { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("Dispatched")]
        public DateTime Dispatched { get; set; }
		#endregion

		#region public Boolean Completed { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("Completed")]
        public Boolean Completed { get; set; }
		#endregion

		#region public String Reference { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("Reference")]
        public String Reference { get; set; }
		#endregion

		#region public Boolean ODR { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("ODR")]
        public Boolean ODR { get; set; }
		#endregion

		#region public String MaintenanceOrganization { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("MaintenanceOrganization")]
        public String MaintenanceOrganization { get; set; }
		#endregion

        #region public Int32 MaintenanceDirectiveRecordId { get; set; }
        /// <summary>
        /// ССылка на другую запись о выполнении Другой задачи, 
        /// <br/> с которой может быть связано данное выполнение 
        /// </summary>
        [TableColumnAttribute("MaintenanceDirectiveRecordId")]
        public Int32 MaintenanceDirectiveRecordId { get; set; }

        public static PropertyInfo MaintenanceDirectiveRecordIdProperty
        {
            get { return GetCurrentType().GetProperty("MaintenanceDirectiveRecordId"); }
        }
        #endregion

        #region public Int32 MaintenanceCheckRecordId { get; set; }
        /// <summary>
        /// ССылка на другую запись о выполнении Чека программы обслуживания, 
        /// <br/> с которой может быть связано данное выполнение 
        /// </summary>
        [TableColumnAttribute("MaintenanceCheckRecordId")]
        public Int32 MaintenanceCheckRecordId { get; set; }

        public static PropertyInfo MaintenanceCheckRecordIdProperty
        {
            get { return GetCurrentType().GetProperty("MaintenanceCheckRecordId"); }
        }
		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1260)]
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

		#region public Document Document { get; set; }
		public Document Document { get; set; }

		#endregion

		/*
         * Вычисляемые свойства (дополнительные)
         */

		#region public DirectiveRecordType RecordType { get; set; }
		/// <summary>
		/// Тип записи о выполнении
		/// </summary>
		public DirectiveRecordType RecordType
        {
            get { return DirectiveRecordType.GetRecordTypeById(RecordTypeId); }
            set { RecordTypeId = value.ItemId; }
        }
        #endregion

        #region public MaintenanceCheck MaintenanceCheck { get; set; }

        [NonSerialized] 
        private MaintenanceCheck _maintenanceCheck;

		private CommonCollection<Document> _documents;

		public MaintenanceCheck MaintenanceCheck
        {
            get { return _maintenanceCheck; }
            set { _maintenanceCheck = value; }
        }

        #endregion

        /*
		*  Методы 
		*/
		
		#region public DirectiveRecord()
        /// <summary>
        /// Создает запись о выполнении директивы без дополнительных параметров
        /// </summary>
        public DirectiveRecord()
        {
            ItemId = -1;
			SmartCoreObjectType = SmartCoreType.DirectiveRecord;
            _directivePackageId = -1;
            Dispatched= DateTimeExtend.GetCASMinDateTime();
         
        }
        #endregion

        #region public static DirectiveRecord CreateInstance(NextPerformance nextPerformance)
        /// <summary>
        /// Создает новый зкземпляр записи о выполнении на основе след.выполнения
        /// </summary>
        /// <param name="nextPerformance"></param>
        /// <returns></returns>
        public static DirectiveRecord CreateInstance(NextPerformance nextPerformance)
        {
            DirectiveRecord dr = new DirectiveRecord();

            if (nextPerformance == null) return dr;

            //дата выполнения
            if (nextPerformance.PerformanceDate.HasValue)
                dr.RecordDate = nextPerformance.PerformanceDate.Value;
            //номер выполнения
            dr.PerformanceNum = nextPerformance.PerformanceNum;

            return dr;
        }
        #endregion

        #region public DirectiveRecord(DirectiveRecord toClone) : this ()
        /// <summary>
        /// Создает несохраненного клона (Itemid которого =-1) переданного элемента
        /// </summary>
        /// <param name="toCopy">Элемент для клонирования (иожет быть равен null)</param>
        /// <returns>Склонированный элемент или элемент по умолчанию</returns>
        public DirectiveRecord(DirectiveRecord toCopy) : this ()
        {
            if (toCopy == null) return;

            Completed = toCopy.Completed;
            Dispatched = toCopy.Dispatched;
            MaintenanceOrganization = toCopy.MaintenanceOrganization;
            ODR = toCopy.ODR;
            _onLifelength = toCopy.OnLifelength;
            _parent = toCopy.Parent;
            _parentId = toCopy.ParentId;
            _parentType = toCopy.ParentType;
            _performanceNum = toCopy.PerformanceNum;
            _recordDate = toCopy.RecordDate;
            RecordTypeId = toCopy.RecordTypeId;
            Reference = toCopy.Reference;
            _remarks = toCopy.Remarks;
            _directivePackage = toCopy.DirectivePackage;
            _directivePackageId = toCopy.DirectivePackageId;

            _attachedFile = toCopy.AttachedFile;
        }
        #endregion

        #region public DirectiveRecord(AbstractPerformanceRecord toClone) : this ()
        /// <summary>
        /// Создает несохраненного клона (Itemid которого =-1) переданного элемента
        /// </summary>
        /// <param name="toCopy">Элемент для клонирования (иожет быть равен null)</param>
        /// <returns>Склонированный элемент или элемент по умолчанию</returns>
        public DirectiveRecord(AbstractPerformanceRecord toCopy)
            : this()
        {
            if (toCopy == null) return;

            _onLifelength = toCopy.OnLifelength;
            _parent = toCopy.Parent;
            _parentId = toCopy.ParentId;
            _parentType = toCopy.ParentType;
            _performanceNum = toCopy.PerformanceNum;
            _recordDate = toCopy.RecordDate;
            _remarks = toCopy.Remarks;
            _directivePackage = toCopy.DirectivePackage;
            _directivePackageId = toCopy.DirectivePackageId;

            _attachedFile = toCopy.AttachedFile;
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Auxiliary.Convert.GetDateFormat(RecordDate) + " " +
                   OnLifelength.ToHoursMinutesAndCyclesFormat("FH", "FC");
        }
        #endregion    

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(DirectiveRecord));
        }
        #endregion

        #region public new DirectiveRecord GetCopyUnsaved()
        /// <summary>
        /// Возвращает полную копию объекта (полностью копирую вложенные элементы и коллекции),
        /// <br/>с ItemId равным -1
        /// </summary>
        /// <returns></returns>
        public new DirectiveRecord GetCopyUnsaved()
        {
            DirectiveRecord directiveRecord = (DirectiveRecord)MemberwiseClone();
            
            directiveRecord.ItemId = -1;

            directiveRecord.OnLifelength = new Lifelength(OnLifelength);
            directiveRecord.Unused = new Lifelength(Unused);
            directiveRecord.Overused = new Lifelength(Overused);

            return directiveRecord;
        }
		#endregion

	}
}
