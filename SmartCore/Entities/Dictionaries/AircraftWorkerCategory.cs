using System;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
    [Table("AircraftWorkerCategories", "dbo", "ItemId")]
	[Dto(typeof(AircraftWorkerCategoryDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class AircraftWorkerCategory : AbstractDictionary
    {
        #region public AircraftWorkerCategory()

        public AircraftWorkerCategory()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.AircraftWorkerCategory;
        }

        #endregion

        #region Implement of Dictionary

        #region  public override string FullName { get; set; }

        /// <summary>
        /// Полное название Категории
        /// </summary>
        //[TableColumn("FullName")]
        //[FormControl(250, "Name", 1, Order = 1)]
        //[ListViewData(0.2f, "Name", 1)]
        //[NotNull]
        public override string FullName
        {
            get { return Category; }
            set
            {
                Category = value;
            }
        }

        #endregion

        #region public override string ShortName { get; set; }

        public override string ShortName
        {
            get { return Category; }
            set { Category = value; }
        }

        #endregion

        #region public override string CommonName

        public override string CommonName
        {
            get { return Category; }
            set { Category = value; }
        }
        #endregion

        #region public override String Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Category")]
        [ListViewData(0.4f, "Category")]
        [FormControl(120, "Category")]
        [NotNull]
        public override String Category { get; set; }
        #endregion

        #endregion

        #region public CommonCollection<ModuleRecord> Modules

        private CommonCollection<ModuleRecord> _moduleRecords;
        /// <summary>
        /// 
        /// </summary>
        [Child(RelationType.OneToMany, "AircraftWorkerCategoryId", "AircraftWorkerCategory")]
        public CommonCollection<ModuleRecord> ModuleRecords
        {
            get { return _moduleRecords ?? (_moduleRecords = new CommonCollection<ModuleRecord>()); }
            internal set
            {
                if (_moduleRecords != value)
                {
                    if (_moduleRecords != null)
                        _moduleRecords.Clear();
                    if (value != null)
                        _moduleRecords = value;
                }
            }
        }
        #endregion

        #region public override void SetProperties(AbstractDictionary dictionary)
        public override void SetProperties(AbstractDictionary dictionary)
        {
            if (dictionary is AircraftWorkerCategory)
                SetProperties((AircraftWorkerCategory)dictionary);
        }
        #endregion

        #region public void SetProperties(AircraftWorkerCategory dictionary)
        public void SetProperties(AircraftWorkerCategory dictionary)
        {
            Category = dictionary.Category;

            OnPropertyChanged("FullName");
        }
        #endregion

    }

    #region public class ModuleRecord : BaseEntityObject

    [Table("ModuleRecords", "dbo", "ItemId")]
	[Dto(typeof(ModuleRecordDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class ModuleRecord : BaseEntityObject
    {
        #region public ModuleRecord()

        public ModuleRecord()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.ModuleRecord;
        }

            #endregion

        #region public AircraftWorkerCategory AircraftWorkerCategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("AircraftWorkerCategoryId")]
        [Parent]
        public AircraftWorkerCategory AircraftWorkerCategory { get; set; }
        
        #endregion

        #region public KnowledgeModule KnowledgeModule { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("KnowledgeModuleId")]
        [ListViewData(0.2f, "KnowledgeModule")]
        [FormControl(120, "KnowledgeModule")]
        [NotNull]
        public KnowledgeModule KnowledgeModule { get; set; }

        #endregion

        #region public int KnowledgeLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("KnowledgeLevel")]
        [ListViewData(0.2f, "Level")]
        [FormControl(120, "Level")]
        [NotNull]
        [MinMaxValue(1,3)]
        public int KnowledgeLevel { get; set; }

        #endregion

    }
    #endregion

    #region public class CategoryRecord : BaseEntityObject

    [Table("CategoryRecords", "dbo", "ItemId")]
	[Dto(typeof(CategoryRecordDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class CategoryRecord : BaseEntityObject
    {
        #region public CategoryRecord()

        public CategoryRecord()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.CategoryRecord;
        }

        #endregion

        private static Type _thisType;

        #region override public Int32 ParentId { get; set; }

        private Int32 _parentId;
        /// <summary>
        /// Идентификатор детали, к которой пренадлежит запись
        /// </summary>
        [TableColumnAttribute("ParentId")]
        public Int32 ParentId
        {
            get { return (_parent != null ? _parent.ItemId : _parentId); }
            set
            {
                if (_parentId != value)
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

        #region public override SmartCoreType ParentType

        private SmartCoreType _parentType;

        /// <summary>
        /// Тип родительской задачи
        /// </summary>
        [TableColumnAttribute("ParentTypeId")]
        public SmartCoreType ParentType
        {
            get { return _parentType ?? SmartCoreType.Unknown; }
            internal set { _parentType = value; }
        }

        public static PropertyInfo ParentTypeIdProperty
        {
            get { return GetCurrentType().GetProperty("ParentType"); }
        }

        #endregion

        #region public BaseEntityObject Parent { get; set; }

        private BaseEntityObject _parent;
        /// <summary>
        /// Родительская задача
        /// </summary>
        public BaseEntityObject Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                _parentType = (_parent != null ? _parent.SmartCoreObjectType : SmartCoreType.Unknown);
            }
        }

        #endregion

        #region public AircraftWorkerCategory AircraftWorkerCategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("AircraftWorkerCategoryId")]
        public AircraftWorkerCategory AircraftWorkerCategory { get; set; }

        #endregion

        #region public int KnowledgeLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("AircraftTypeId")]
        [ListViewData(0.2f, "AC Type")]
        [FormControl(120, "AC Type")]
        [NotNull]
		[Child]
        public AircraftModel AircraftModel { get; set; }

        #endregion

        #region public new DirectiveRecord GetCopyUnsaved()
        /// <summary>
        /// Возвращает полную копию объекта (полностью копирую вложенные элементы и коллекции),
        /// <br/>с ItemId равным -1
        /// </summary>
        /// <returns></returns>
        public new CategoryRecord GetCopyUnsaved(bool marked = true)
        {
            CategoryRecord categoryRecord = (CategoryRecord)MemberwiseClone();
            categoryRecord.ItemId = -1;

            return categoryRecord;
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(CategoryRecord));
        }
        #endregion
    }
    #endregion

}
