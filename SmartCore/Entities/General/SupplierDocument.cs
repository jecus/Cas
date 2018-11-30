using System;
using System.Linq;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Files;

namespace SmartCore.Entities.General
{
    [TableAttribute("SupplierDocuments", "dbo", "ItemId")]
    [Dto(typeof(SupplierDocumentDTO))]
	[Condition("IsDeleted", "0")]
    public class SupplierDocument : BaseEntityObject, IFileContainer
	{
        private static Type _thisType;

        #region public Int32 SupplierId { get; set; }
        /// <summary>
        /// Id поставщика 
        /// </summary>
        [TableColumn("SupplierId")]
        public Int32 SupplierId { get; set; }

        public static PropertyInfo SupplierIdProperty
        {
            get { return _thisType.GetProperty("SupplierId"); }
        }

        #endregion

        #region public String Name { get; set; }
        /// <summary>
        /// название документа 
        /// </summary>
        [TableColumn("Name")]
        public String Name { get; set; }
        #endregion

        #region public int FileId { get; set; }
        /// <summary>
        /// ИД фаила долкумента
        /// </summary>
        [TableColumn("FileId")]
        public int FileId { get; set; }
        #endregion

        #region public String DocumentType { get; set; }
        /// <summary>
        /// Название типа документа 
        /// </summary>
        [TableColumn("DocumentType")]
        public String DocumentType { get; set; }
		#endregion

		#region  public AttachedFile AttachedFile { get; set; }

		private AttachedFile _attachedFile;
		/// <summary>
		/// Файл листа повреждений
		/// </summary>
		public AttachedFile AttachedFile
	    {
			get
			{
				return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.SupplierDocumentAttachedFile));
			}
			set
			{
				_attachedFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.SupplierDocumentAttachedFile);
			}
		}

	    #endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

	    [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 2050)]
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

		#region public override int CompareTo(object y)
		public override int CompareTo(object y)
        {
            if (y is SupplierDocument)
                return ItemId.CompareTo(((SupplierDocument)y).ItemId);
            return 0;
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Переводит тип директивы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + " " + DocumentType;
        }
        #endregion

        #region public SupplierDocument()
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public SupplierDocument()
        {
            _thisType = typeof (SupplierDocument);

            ItemId = -1;
			SmartCoreObjectType = SmartCoreType.SupplierDocument;
            SupplierId = -1;
            Name = "";
            FileId = -1;
            DocumentType = "";
            AttachedFile = null;
        }
        #endregion

        #region public SupplierDocument(int supplierId)
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public SupplierDocument(int supplierId) : this()
        {
            SupplierId = supplierId;
        }
		#endregion

	}
}
