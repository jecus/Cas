using System;
using System.Linq;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Files;

namespace SmartCore.Entities.General.Directives
{
    /// <summary>
    /// Описывает класс Deffered Item
    /// </summary>
    [Table("Directives", "dbo", "ItemId")]
    [Dto(typeof(DirectiveDTO))]
	[Condition("DirectiveType","12")]
    [Condition("IsDeleted", "0")]
	[Serializable]
    public class DamageItem : Directive
	{
        private static Type _thisType;
        /*
         * Свойства
         */

        #region public String Number { get; set; }
        /// <summary>
        /// Номер повреждения
        /// </summary>
        [TableColumn("Number")]
        public String Number { get; set; }
        #endregion

        #region public String Location { get; set; }
        /// <summary>
        /// Местоположение повреждения
        /// </summary>
        [TableColumn("Location")]
        public String Location { get; set; }
        #endregion

        #region public bool IsTemporary { get; set; }
        /// <summary>
        /// Флаг, обозначающий, является ли ремонт временным
        /// </summary>
        [TableColumn("IsTemporary")]
        public bool IsTemporary { get; set; }
        #endregion

        #region public double DamageLenght { get; set; }
        /// <summary>
        /// Длина повреждения
        /// </summary>
        [TableColumn("DamageLenght")]
        public double DamageLenght { get; set; }
        #endregion

        #region public double DamageWidth { get; set; }
        /// <summary>
        /// Ширина повреждения
        /// </summary>
        [TableColumn("DamageWidth")]
        public double DamageWidth { get; set; }
        #endregion

        #region public double DamageDepth { get; set; }
        /// <summary>
        /// Глубина повреждения
        /// </summary>
        [TableColumn("DamageDepth")]
        public double DamageDepth { get; set; }
        #endregion

        #region public double DamageLenghLimitt { get; set; }
        /// <summary>
        /// лимит на длину повреждения
        /// </summary>
        [TableColumn("DamageLenghtLimit")]
        public double DamageLenghtLimit { get; set; }
        #endregion

        #region public double DamageWidthLimit { get; set; }
        /// <summary>
        /// Лимит на ширину повреждения
        /// </summary>
        [TableColumn("DamageWidthLimit")]
        public double DamageWidthLimit { get; set; }
        #endregion

        #region public double DamageDepthLimit { get; set; }
        /// <summary>
        /// Лимит на глубину повреждения
        /// </summary>
        [TableColumn("DamageDepthLimit")]
        public double DamageDepthLimit { get; set; }
        #endregion

        #region public String DamageMeasure { get; set; }
        /// <summary>
        /// Единица измерения параметров (длина, ширина, глубина) повреждения
        /// </summary>
        [TableColumn("DamageMeasure")]
        public Measure DamageMeasure { get; set; }
        #endregion

        #region public DamageType DamageType { get; set; }
        /// <summary>
        /// Тип повреждения
        /// </summary>
        [TableColumn("DamageType")]
        public DamageType DamageType { get; set; }
		#endregion

		#region public DamageClass DamageClass

		[TableColumn("DamageClass")]
		public DamageClass DamageClass
		{
			get { return _damageClass != null ? _damageClass :  DamageClass.Unknown; }
			set { _damageClass = value; }
		}

			#endregion

		[TableColumn("CorrectiveAction")]
		public string CorrectiveAction { get; set; } 

		#region public String InspectionDocumentsNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("InspectionDocumentsNo")]
        public String InspectionDocumentsNo { get; set; }
		#endregion

		#region  public AttachedFile InspectionDocumentsFile { get; set; }

		private AttachedFile _inspectionDocumentsFile;

		/// <summary>
		/// Связь с файлом описания сервисного бюллетеня
		/// </summary>

		public AttachedFile InspectionDocumentsFile
	    {
			get
			{
				return _inspectionDocumentsFile ?? (Files.GetFileByFileLinkType(FileLinkType.InspectionDocumentsFile));
			}
			set
			{
				_inspectionDocumentsFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.InspectionDocumentsFile);
			}
		}

	    #endregion
		


        #region public String Location { get; set; }

        /// <summary>
        /// Строковое представление размера повреждения
        /// </summary>
        public String Size
        {
            get
            {
                if (DamageType == DamageType.Damage || DamageType == DamageType.Repair)
                {
                    return string.Format("{0}x{1} limit({2}x{3}) {4}",
                                      DamageLenght,
                                      DamageWidth,
                                      DamageLenghtLimit,
                                      DamageWidthLimit,
                                      DamageMeasure);
                }
                if (DamageType == DamageType.Dent)
                {
                    return string.Format("{0}x{1} limit({2}x{3}) {4} A/Y={5}",
                                      DamageWidth,
                                      DamageDepth,
                                      DamageWidthLimit,
                                      DamageDepthLimit,
                                      DamageMeasure,
                                      (DamageWidth / DamageDepth));
                }
                if (DamageType == DamageType.Scratch)
                {
                    return string.Format("{0}x{1} limit({2}x{3}) {4}",
                                      DamageLenght,
                                      DamageDepth,
                                      DamageLenghtLimit,
                                      DamageDepthLimit,
                                      DamageMeasure);
                }

                return "";
            }
        }
        #endregion

        #region public DamageDocumentsCollection DamageDocs { get; set; }

        private DamageDocumentsCollection _damageDocs;

        [Child(RelationType.OneToMany, "DirectiveId")]
        public DamageDocumentsCollection DamageDocs
        {
            get { return _damageDocs ?? (_damageDocs = new DamageDocumentsCollection()); }
            internal set
            {
                if (_damageDocs != value)
                {
                    if (_damageDocs != null)
                        _damageDocs.Clear();
                    if (value != null)
                        _damageDocs = value;
                }
            }
        }

        #endregion

        #region public JobCard JobCard { get; set; }

        private JobCard _jobCard;
		private DamageClass _damageClass;

		/// <summary>
        /// Рабочая карта данной директивы
        /// </summary>
        //[TableColumnAttribute("JobCard"), ListViewData("Job Card")]
        //[Child(false)]
        //[Filter("Check:", Order = 13)]
        public JobCard JobCard
        {
            get { return _jobCard; }
            set
            {
                _jobCard = value;
                if (_jobCard != null)
                {
                    _jobCard.Parent = this;
                }
            }
        }

        public static PropertyInfo JobCardProperty
        {
            get { return GetCurrentType().GetProperty("JobCard"); }
        }

        #endregion

        /*
         * Методы
         */

        #region public DamageItem()
        /// <summary>
        /// Конструктор без дополнительных параметров
        /// </summary>
        public DamageItem()
        {
            DirectiveType = DirectiveType.DamagesRequiring;
            DamageMeasure = Measure.Millimeters;
            DamageType = DamageType.Damage;
        }

        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(DamageItem));
        }
		#endregion

	}
}
