using System;
using EFCore.DTO.Dictionaries;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
    [Serializable]
    public class DocumentType : StaticDictionary
    {
        #region private static List<DocumentType> _Items = new List<DocumentType>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<DocumentType> _Items = new CommonDictionaryCollection<DocumentType>();
        #endregion

        /*
         * Предопределенные типы
         */

        #region public static DocumentType Document = new DocumentType(1, "Doc.", "Document");
        /// <summary>
        /// 
        /// </summary>
        public static DocumentType Document = new DocumentType(1, "Doc.", "Document");
        #endregion

        #region public static DocumentType Contract = new DocumentType(2, "Cont.", "Contract");
        /// <summary>
        /// 
        /// </summary>
        public static DocumentType Contract = new DocumentType(2, "Cont.", "Contract");
        #endregion

        #region public static DocumentType Certificate = new DocumentType(3, "Cert", "Certificate");
        /// <summary>
        /// 
        /// </summary>
        public static DocumentType Certificate = new DocumentType(3, "Cert", "Certificate");
        #endregion

        #region public static DocumentType Equipment = new DocumentType(4, "Equip", "Equipment");
        /// <summary>
        /// 
        /// </summary>
        public static DocumentType Equipment = new DocumentType(4, "Equip", "Equipment");
        #endregion

        #region public static DocumentType Forms = new DocumentType(5, "Form", "Forms");
        /// <summary>
        /// 
        /// </summary>
        public static DocumentType Forms = new DocumentType(5, "Form", "Forms");
        #endregion

        #region public static DocumentType Patent = new DocumentType(6, "Patent", "Patent");
        /// <summary>
        /// 
        /// </summary>
        public static DocumentType Patent = new DocumentType(6, "Patent", "Patent");
        #endregion

        #region public static DocumentType License = new DocumentType(7, "License", "License");
        /// <summary>
        /// 
        /// </summary>
        public static DocumentType License = new DocumentType(7, "License", "License");
        #endregion

        #region public static DocumentType Manuals = new DocumentType(8, "Manual", "Manual");
        /// <summary>
        /// 
        /// </summary>
        public static DocumentType Manuals = new DocumentType(8, "Manual", "Manual");
        #endregion

        #region public static DocumentType Requirements = new DocumentType(9, "Requirements", "Requirements");
        /// <summary>
        /// 
        /// </summary>
        public static DocumentType Requirements = new DocumentType(9, "Requirements", "Requirements");
		#endregion
		
		#region public static DocumentType TechnicalPublication = new DocumentType(10, "Technical Publication", "Technical Publication");
		/// <summary>
		/// 
		/// </summary>
		public static DocumentType TechnicalPublication = new DocumentType(10, "Technical Publication","Technical Publication");

		#endregion

		#region public static DocumentType Act = new DocumentType(11, "Act", "Act");

		public static DocumentType Act = new DocumentType(11, "Act", "Act");

		#endregion

		#region public static DocumentType Protocol = new DocumentType(12, "Protocol", "Protocol");

		public static DocumentType Protocol = new DocumentType(12, "Protocol", "Protocol");

		#endregion

		#region public static DocumentType Instruction = new DocumentType(13, "Instruction", "Instruction");

		public static DocumentType Instruction = new DocumentType(13, "Instruction", "Instruction");

		#endregion

		#region public static DocumentType Program = new DocumentType(14, "Program", "Program");

		public static DocumentType Program = new DocumentType(14, "Program", "Program");

		#endregion

		#region public static DocumentType Library = new DocumentType(15, "Library", "Library");

		public static DocumentType Library = new DocumentType(15, "Library", "Library");

		#endregion

		#region public static DocumentType RegularPayments = new DocumentType(16, "Regular payments", "Regular payments");

		public static DocumentType RegularPayments = new DocumentType(16, "Regular payments", "Regular payments");

		#endregion

		#region public static DocumentType RequirementsCompany = new DocumentType(17, "Requirements company", "Requirements company");

		public static DocumentType RequirementsCompany = new DocumentType(17, "Requirements company", "Requirements company");

		#endregion

		#region public static DocumentType Letter = new DocumentType(18, "Letter", "Letter");

		public static DocumentType Letter = new DocumentType(18, "Letter", "Letter");

		#endregion

		#region public static DocumentType Order = new DocumentType(19, "Order", "Order");

		public static DocumentType Order = new DocumentType(19, "Order", "Order");

		#endregion

		#region public static DocumentType Explanatory = new DocumentType(20, "Explanatory", "Explanatory");

		public static DocumentType Explanatory = new DocumentType(20, "Explanatory", "Explanatory");

		#endregion

		#region public static DocumentType Statement = new DocumentType(21, "Statement", "Statement");

		public static DocumentType Statement = new DocumentType(21, "Statement", "Statement");

		#endregion

		#region public static DocumentType Report = new DocumentType(22, "Report", "Report");

		public static DocumentType Report = new DocumentType(22, "Report", "Report");

		#endregion

		#region public static DocumentType TechnicalRecords = new DocumentType(23, "Technical records", "Technical records");

		public static DocumentType TechnicalRecords = new DocumentType(23, "Technical records", "Technical records");

		#endregion

	    public static DocumentType Permission = new DocumentType(24, "Permission", "Permission");

		#region public static DocumentType Other = new DocumentType(-1, "Oth", "Other");
		/// <summary> 
		/// Неизвестный объект
		/// </summary>
		public static DocumentType Other = new DocumentType(-1, "Oth", "Other");
        #endregion

        /*
         * Методы
         */

        #region public static DocumentType GetDocumentTypeById(Int32 DocumentTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="documentTypeId"></param>
        /// <returns></returns>
        public static DocumentType GetDocumentTypeById(int documentTypeId)
        {
            for (int i = 0; i < _Items.Count; i++)
                if (_Items[i].ItemId == documentTypeId)
                    return _Items[i];
            //
            return Other;
        }
        #endregion

        #region static public List<DocumentType> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<DocumentType> Items
        {
            get { return _Items; }
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Переводит тип директивы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FullName;
        }
        #endregion

        /*
         * Реализация
         */

        #region public DocumentType(Int16 ItemId, String shortName, String fullName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        public DocumentType(short itemId, string shortName, string fullName)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            _Items.Add(this);
        }
		#endregion

		#region public DocumentType()

		public DocumentType()
	    {
		    
	    }

	    #endregion
    }

    [Table("DocumentSubType", "Dictionaries", "ItemId")]
	[Dto(typeof(DocumentSubTypeDTO))]
    [DictionaryCollection(typeof(DocumentSubTypeCollection))]
    [Serializable]
    public class DocumentSubType : AbstractDictionary
    {
		private static DocumentSubType _unknown;
		/*
         *  Свойства
         */
		#region public Int32 DocumentTypeId
		/// <summary>
		/// Id типа документа родителя (контракт, сертификат и т.д.)
		/// </summary>
		private Int32 _documentTypeId;
        [TableColumnAttribute("DocumentTypeId")]
        public Int32 DocumentTypeId
        {
            get { return _documentTypeId; }
            set
            {
                if (_documentTypeId != value)
                {
                    _documentTypeId = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        #endregion

        #region public String Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private string _name;
        [TableColumnAttribute("Name")]
        public override string FullName
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("FullName");
                }
            }
        }
        #endregion

        #region public override string ShortName  { get; set }

        /// <summary>
        /// Короткое имя
        /// </summary>
        public override string ShortName
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("FullName");
                }
            }
        }
        #endregion

        #region public override string CommonName  { get; set }
        /// <summary>
        /// Общее имя 
        /// </summary>
        public override string CommonName 
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("FullName");
                }
            }
        }
        #endregion

        #region public override string Category  { get; set }
        /// <summary>
        /// категория записи
        /// </summary>
        public override string Category
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("FullName");
                }
            }
        }
		#endregion

		#region public static DocumentSubType Unknown

		public static DocumentSubType Unknown
		{
			get
			{
				return _unknown ?? (_unknown = new DocumentSubType
				{
					FullName = "Unknown",
					ShortName = "UNK",
					Category = "",
					CommonName = "Unknown"
				});
			}
		}

		#endregion

		/*
		*  Методы 
		*/
		#region public override void SetProperties(AbstractDictionary dictionary)
		public override void SetProperties(AbstractDictionary dictionary)
        {
            if (dictionary is DocumentSubType)
                SetProperties((DocumentSubType)dictionary);
        }
        #endregion

        #region public void SetProperties(DocumentSubType dictionary)
        public void SetProperties(DocumentSubType dictionary)
        {
            DocumentTypeId = dictionary.DocumentTypeId;
            FullName = dictionary.FullName;
            ShortName = dictionary.ShortName;
            CommonName = dictionary.CommonName;
            Category = dictionary.Category;
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FullName;
        }
        #endregion

        #region public DocumentSubType()
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public DocumentSubType()
        {
            ItemId = -1;
            _documentTypeId = -1;
            SmartCoreObjectType = SmartCoreType.DocumentSubType;
        }
        #endregion
    }
}
