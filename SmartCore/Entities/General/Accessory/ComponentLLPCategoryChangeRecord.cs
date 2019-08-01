using System;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Files;
using SmartCore.Packages;

namespace SmartCore.Entities.General.Accessory
{

    /// <summary>
    ///  ласс описывает запись о смене категории работы крут€щегос€ компонента двигател€ 
    /// </summary>
    [Table("ComponentLLPCategoryChangeRecords", "dbo", "ItemId")]
    [Dto(typeof(ComponentLLPCategoryChangeRecordDTO))]
	[Serializable]
    public class ComponentLLPCategoryChangeRecord : AbstractPerformanceRecord, IFileContainer
	{
        private static Type _thisType;

        /*
        *  —войства из базы данных
        */

        #region public LLPLifeLimitCategory ToCategory { get; set; }

        private LLPLifeLimitCategory _llpLifeLimitCategory;
        /// <summary>
        /// Ќа какую категорию произошла смена
        /// </summary>
        [TableColumnAttribute("ToCategoryId")]
        public LLPLifeLimitCategory ToCategory
        {
            get { return _llpLifeLimitCategory ?? (_llpLifeLimitCategory = LLPLifeLimitCategory.Unknown); }
            set
            {
                if(_llpLifeLimitCategory != value)
                {
                    _llpLifeLimitCategory = value;
                    OnPropertyChanged("ToCategory");
                }
            }
        }
		#endregion

        #region Implement of AbstractPerformanceRecord

        #region override public Int32 ParentId { get; set; }

        private Int32 _parentId;
        /// <summary>
        /// »дентификатор детали, к которой пренадлежит запись
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
        /// Ќомер записи о выполнении (не используетс€)
        /// </summary>
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
        /// “ип родительской задачи
        /// </summary>
        //[TableColumnAttribute("ParentTypeId", ColumnAccessType.WriteOnly)]
        public override SmartCoreType ParentType
        {
            get { return _parentType ?? SmartCoreType.Unknown; }
            internal set { _parentType = value; }
        }
        #endregion

        #region public override IDirective Parent { get; set; }

        private Component _parent;
        /// <summary>
        /// –одитель данной записи о выполнении
        /// </summary>
        public override IDirective Parent
        {
            get { return _parent; }
            set
            {
                _parent = value as Component;
                _parentType = (_parent != null ? _parent.SmartCoreObjectType : SmartCoreType.Unknown);
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

        private Lifelength _onLifelength;
        /// <summary>
        /// 
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

        #region public override IDirectivePackage DirectivePackage{ get; set; }

        private IDirectivePackage _directivePackage;
        /// <summary>
        /// используетс€, только если запись создана workpackage - м
        /// </summary>
        public override IDirectivePackage DirectivePackage
        {
            get { return _directivePackage; } 
            set
            {
                if(_directivePackage != value)
                {
                    _directivePackage = value;
                    OnPropertyChanged("WorkPackage");
                }
            }
        }
		#endregion

		#region public override AttachedFile AttachedFile { get; set; }
		/// <summary>
		/// —в€зь на файл
		/// </summary>
		[NonSerialized]
        private AttachedFile _file;

        public override AttachedFile AttachedFile
        {
            get
            {
				return _file ?? (Files.GetFileByFileLinkType(FileLinkType.ComponentLLPCategoryChangeRecordAttachedFile));
			}
            set
            {
                if (_file != value)
                {
                    _file = value;
                    OnPropertyChanged("FilePDF");
					Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.ComponentLLPCategoryChangeRecordAttachedFile);
				}
            }
        }
		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1200)]
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

		#region public override Lifelength Unused { get; set; }
		/// <summary>
		/// неизрасходованный ресурс 
		/// ресурс, на котором надо выполнить директиву - ресурс, на котором она была выполнена
		/// записываютс€ только положительные значени€, включа€ 0
		/// </summary>
		public override Lifelength Unused { get; set; }
        #endregion

        #region public override Lifelength Overused { get; set; }
        /// <summary>
        /// перерасходованный ресурс 
        /// ресурс, на котором она была выполнена - ресурс, на котором надо выполнить директиву 
        /// записываютс€ только положительные значени€, включа€ 0
        /// </summary>
        public override Lifelength Overused { get; set; }
		#endregion

		#endregion

		/*
         * ¬ычисл€емые свойства (дополнительные)
         */

		#region public Component ParentComponent { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Component ParentComponent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                _parentType = (_parent != null ? _parent.SmartCoreObjectType : SmartCoreType.Component);
            }
        }
		#endregion

		/*
		*  ћетоды 
		*/

		#region public ComponentLLPCategoryChangeRecord()
		/// <summary>
		/// —оздает воздушное судно без дополнительной информации
		/// </summary>
		public ComponentLLPCategoryChangeRecord()
        {
            ItemId = -1;
			SmartCoreObjectType = SmartCoreType.ComponentLLPCategoryChangeRecord;
            _parentId = -1;
            _recordDate = DateTimeExtend.GetCASMinDateTime();
            ToCategory = LLPLifeLimitCategory.Unknown;
            _onLifelength = Lifelength.Null;
            _remarks = "";
         
        }
		#endregion

		#region public ComponentLLPCategoryChangeRecord(ComponentLLPCategoryChangeRecord toCopy) : this ()
		/// <summary>
		/// —оздает воздушное судно без дополнительной информации
		/// </summary>
		public ComponentLLPCategoryChangeRecord(ComponentLLPCategoryChangeRecord toCopy) : this ()
        {
            if(toCopy == null) return;

            _file = toCopy.AttachedFile;
            _onLifelength = new Lifelength(toCopy.OnLifelength);
            ParentComponent = toCopy.ParentComponent;
            _parentId = toCopy.ParentId;
            _parentType = toCopy.ParentType;
            _performanceNum = toCopy.PerformanceNum;
            _remarks = toCopy.Remarks;
            ToCategory = toCopy.ToCategory;
            _wpId = toCopy.DirectivePackageId;
            _directivePackage = toCopy.DirectivePackage;
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(ComponentLLPCategoryChangeRecord));
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// ѕереводит тип директивы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return RecordDate + " to:" + ToCategory;
        }
		#endregion

		#region public new ComponentLLPCategoryChangeRecord GetCopyUnsaved()

		public new ComponentLLPCategoryChangeRecord GetCopyUnsaved()
        {
            var componentLLPCategory = (ComponentLLPCategoryChangeRecord) MemberwiseClone();
            componentLLPCategory.ItemId = -1;
            componentLLPCategory.UnSetEvents();

            componentLLPCategory.OnLifelength=new Lifelength(OnLifelength);
            componentLLPCategory.Unused=new Lifelength(Unused);
            componentLLPCategory.Overused=new Lifelength(Overused);
          
            return componentLLPCategory;
        }

		#endregion

	}

}
