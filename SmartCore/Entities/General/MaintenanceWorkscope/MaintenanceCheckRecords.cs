using System;
using CAS.Entity.Models.DTO.General;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Files;
using SmartCore.Packages;

namespace SmartCore.Entities.General.MaintenanceWorkscope
{
    /// <summary>
    /// Содержит данные о выполнении данного чека
    /// </summary>
    [Table("DirectivesRecords", "dbo", "ItemId")]
    [Dto(typeof(DirectiveRecordDTO))]
	[Condition("IsDeleted","0")]
    [Serializable]
    public class MaintenanceCheckRecord : AbstractPerformanceRecord, IFileContainer
	{
        /*
         *  Свойства
         */

        #region public int NumGroup

        private int _numGroup;
        [TableColumnAttribute("NumGroup")]
        public int NumGroup
        {
            get { return _numGroup; }
            set
            {
                if (_numGroup != value)
                {
                    _numGroup = value;
                    OnPropertyChanged("NumGroup");
                }
            }
        }

        #endregion

        #region  public bool IsControlPoint

        private bool _isControlPoint;
        [TableColumnAttribute("IsControlPoint")]
        public bool IsControlPoint
        {
            get { return _isControlPoint; }
            set
            {
                if (_isControlPoint != value)
                {
                    _isControlPoint = value;
                    OnPropertyChanged("IsControlPoint");
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

        #region public Cas3MaintenanceCheck ParentCheck

        /// <summary>
        /// 
        /// </summary>
        private MaintenanceCheck _parentCheck;
        public MaintenanceCheck ParentCheck
        {
            get
            {
                return _parentCheck;
            }
            set
            {
                if (_parentCheck != value)
                {
                    if (value != null) ParentId = value.ItemId;
                    _parentCheck = value;
                    _parentType = (_parentCheck != null ? _parentCheck.SmartCoreObjectType : SmartCoreType.Unknown);
                    OnPropertyChanged("ParentCheck");
                }
            }
        }
        #endregion

        #region public string ComplianceCheckName

        private string _complianceCheckName;
        [TableColumnAttribute("ComplianceCheckName", 128)]
        public string ComplianceCheckName
        {
            get { return _complianceCheckName; }
            set
            {
                if (_complianceCheckName != value)
                {
                    _complianceCheckName = value;
                    OnPropertyChanged("ComplianceCheckName");
                }
            }
        }

        #endregion

        #region Implement of AbstractPerformanceRecord

        #region public override int ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("ParentId")]
        public override int ParentId { get; set; }
        #endregion

        #region public override Int32 PerformanceNum { get; set; }

        private int _performanceNum;
        /// <summary>
        /// Номер записи о выполнении
        /// </summary>
        [TableColumnAttribute("PerformanceNum")]
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
        #endregion

        #region public override IDirective Parent { get; set; }

        /// <summary>
        /// Родитель данной записи о выполнении
        /// </summary>
        public override IDirective Parent
        {
            get
            {
                return _parentCheck;
            }
            set
            {
                if (_parentCheck != value)
                {
                    if (value != null) ParentId = value.ItemId;
                    _parentCheck = value as MaintenanceCheck;
                    _parentType = (_parentCheck != null ? _parentCheck.SmartCoreObjectType : SmartCoreType.Unknown);
                    OnPropertyChanged("ParentCheck");
                }
            }
        }
        #endregion

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
            get { return _performance; }
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

        #region public override int WorkPackageId

        private int _wpId;
        [TableColumnAttribute("WorkPackageId")]
        public override int DirectivePackageId
        {
            get { return _wpId; }
            set
            {
                if (_wpId != value)
                {
                    _wpId = value;
                    OnPropertyChanged("WorkPackageId");
                }
            }
        }

        #endregion

        #region public override IDirectivePackage DirectivePackage { get; set; }
        /// <summary>
        /// используется, только если запись создана workpackage - м
        /// </summary>
        public override IDirectivePackage DirectivePackage{ get; set; }
		#endregion

		#region public override AttachedFile AttachedFile { get; set; }
		/// <summary>
		/// Связь на файл
		/// </summary>
		private AttachedFile _attachedFile;

        public override AttachedFile AttachedFile
        {
			get
			{
				return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.MaintenanceCheckRecordAttachedFile));
			}
			set
			{
				_attachedFile = value;
				OnPropertyChanged("AttachedFile");
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.MaintenanceCheckRecordAttachedFile);
			}
		}
        #endregion

        #region public override Lifelength Unused { get; set; }
        /// <summary>
        /// неизрасходованный ресурс 
        /// ресурс, на котором надо выполнить директиву - ресурс, на котором она была выполнена
        /// записываются только положительные значения, включая 0
        /// </summary>
        public override Lifelength Unused { get; set; }
        #endregion

        #region public override Lifelength Overused { get; set; }
        /// <summary>
        /// перерасходованный ресурс 
        /// ресурс, на котором она была выполнена - ресурс, на котором надо выполнить директиву 
        /// записываются только положительные значения, включая 0
        /// </summary>
        public override Lifelength Overused { get; set; }
		#endregion


		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1680)]
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

		#region public MaintenanceCheckRecord()

		public MaintenanceCheckRecord()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.MaintenanceCheckRecord;
            _parentCheck = null;
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ItemId.ToString();
        }
		#endregion

	}
}
