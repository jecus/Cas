using System;
using System.Drawing;
using System.Linq;
using EFCore.DTO.General;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Directives;
using SmartCore.Files;

namespace SmartCore.Entities.General
{
    [Table("DamageDocuments", "dbo", "ItemId")]
    [Dto(typeof(DamageDocumentDTO))]
	[Condition("IsDeleted", "0")]
    public class DamageDocument : BaseEntityObject, IFileContainer
	{

        #region public Int16 DocumentTypeId { get; set; }
        /// <summary>
        /// тип документа 
        /// </summary>
        [TableColumn("DocumentType")]
        public Int16 DocumentTypeId { get; set; }
        #endregion

        #region public Int32 ParentDirectiveId { get; set; }
        /// <summary>
        /// Общее имя 
        /// </summary>
        [TableColumn("DirectiveId")]
        public Int32 ParentDirectiveId { get; set; }
		#endregion

		#region  public AttachedFile DamageDocFile { get; set; }

		private AttachedFile _damageDocFile;

		/// <summary>
		/// Файл листа повреждений
		/// </summary>
		public AttachedFile DamageDocFile
	    {
			get
			{
				return _damageDocFile ?? (Files.GetFileByFileLinkType(FileLinkType.DamageDocFile));
			}
			set
			{
				_damageDocFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.DamageDocFile);
			}
		}

	    #endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1185)]
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

		#region public Int32 DamageChartId { get; set; }
		/// <summary>
		/// ID рисунка повреждении 
		/// </summary>
		[TableColumn("DamageChartId")]
        public Int32 DamageChartId { get; set; }
        #endregion

        #region public DamageChart DocDamageChart { get; set; }
        /// <summary>
        /// объект документа повреждения 
        /// </summary>    
        public DamageChart DocDamageChart { get; set; }
        #endregion

        #region public DamageChart DamageChart2DImageName { get; set; }
        /// <summary>
        /// "-х Мерная картинка повредения, связанная с данным файлом 
        /// </summary>    
        [TableColumn("DamageChart2DImageName")]
        public string DamageChart2DImageName { get; set; }
        #endregion

        #region public string Location { get; set; }
        [TableColumn("DamageLocation")]
        public string Location { get; set; }

        #endregion

        #region public Image DamageChartImage { get; set; }
        /// <summary>
        /// Изображение, хранящееся в Chart-е 
        /// </summary>    
        public Image DamageChartImage { get; set; }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Переводит тип директивы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (DamageDocFile != null) return DamageDocFile.FileName;
            return "";
        }
        #endregion

        #region public DamageDocument()
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public DamageDocument()
        {
            ItemId = -1;
			SmartCoreObjectType = SmartCoreType.DamageDocument;
            DocumentTypeId = -1;
            ParentDirectiveId = -1;
            DamageDocFile = null;
            DamageChartId = -1;
            DocDamageChart = null;
            Location = "";
        }
        #endregion

        #region public DamageDocument(Int16 docType, int parentDirectiveId)
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public DamageDocument(Int16 docType, int parentDirectiveId)
        {
            ItemId = -1;
            DocumentTypeId = docType;
            ParentDirectiveId = parentDirectiveId;
            DamageDocFile = null;
            DamageChartId = -1;
            DocDamageChart = null;
            Location = "";
        }
        #endregion

        #region public CommonCollection<DamageSector> DamageSectors { get; private set; }

        private CommonCollection<DamageSector> _damageSectors;

	    /// <summary>
        /// Коллекция содержит все записи о выполнении директивы
        /// </summary>
        [Child(RelationType.OneToMany, "DamageDocumentId", "DamageDocument")]
        public CommonCollection<DamageSector> DamageSectors
        {
            get { return _damageSectors ?? (_damageSectors = new CommonCollection<DamageSector>()); }
            internal set
            {
                if (_damageSectors != value)
                {
                    if (_damageSectors != null)
                        _damageSectors.Clear();
                    if (value != null)
                        _damageSectors = value;
                }
            }
        }
		#endregion
	}
}
