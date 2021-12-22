using System;
using System.Linq;
using CAA.Entity.Models.Dictionary;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{

    /// <summary>
    /// Класс, описывает стандарт (ГОСТ), по которому производится товар
    /// </summary>
    [Table("GoodStandarts", "Dictionaries", "ItemId")]
	[Dto(typeof(GoodStandartDTO))]
	[CAADto(typeof(CAAGoodStandartDTO))]
    //[DictionaryCollection(typeof(CommonDictionaryCollection<GoodStandart>))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class GoodStandart : BaseEntityObject, IEquatable<GoodStandart>
    {
        private static Type _thisType;

        //#region Implement of Dictionary

        //#region  public override string FullName { get; set; }

        //private string _fullName;
        ///// <summary>
        ///// Полное название Категории
        ///// </summary>
        //[TableColumn("Name"), ListViewData(0.12f, "Name", 1)]
        //[FormControl(150, "Name", Order = 1)]
        //public override string FullName
        //{
        //    get { return _fullName; }
        //    set
        //    {
        //        if (_fullName != value)
        //        {
        //            _fullName = value;
        //            OnPropertyChanged("FullName");
        //        }
        //    }
        //}

        //#endregion

        //#region public override string ShortName { get; set; }

        //public override string ShortName
        //{
        //    get { return FullName; }
        //    set { FullName = value; }
        //}

        //#endregion

        //#region public override string CommonName

        //public override string CommonName
        //{
        //    get { return FullName; }
        //    set { FullName = value; }
        //}
        //#endregion

        //#region public override string Category
        ///// <summary>
        ///// Категория не сохраняется 
        ///// </summary>
        //public override string Category { get; set; }
        //#endregion

        //#endregion

        #region public string FullName { get; set; }

        private string _fullName;
        /// <summary>
        /// Полное название Категории
        /// </summary>
        [TableColumn("Name"), ListViewData(0.12f, "Name", 1)]
        [FormControl(150, "Name", Order = 1)]
        [Filter("Name:",Order = 1)]
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged("FullName");
                }
            }
        }

        #endregion

        #region public GoodsClass GoodsClass { get; set; }

        private GoodsClass _goodsClass;
        /// <summary>
        /// Класс
        /// </summary>
        [TableColumn("ComponentClass")]
        [FormControl(250, "Class:",
            TreeDictRootNodes = new[]
            {
                "ComponentsAndParts", "ProductionAuxiliaryEquipment", "OfficeEquipment",
				"MaintenanceMaterials"
			}, Order = 10)]
        [ListViewData(0.15f, "Class")]
        [NotNull]
        [Filter("Class:", Order = 4)]
        public GoodsClass GoodsClass
        {
            get { return _goodsClass ?? (_goodsClass = GoodsClass.Unknown); }
            set
            {
                if (_goodsClass != value)
                {
                    _goodsClass = value;
                    OnPropertyChanged("DetailClass");
                }
            }
        }

        //[ListViewData(0.15f, "Class")]
        //public string DetailClassTypeString
        //{
        //    get
        //    {
        //        if (DetailType == DetailType.CTE) 
        //            return DetailType.ToString();
        //        return GoodsClass.ToString();
        //    }
        //}

        #endregion

        #region public DetailType DetailType { get; set; }

        //private DetailClass _detailClass;
        ///// <summary>
        ///// тип простого агрегата
        ///// </summary>
        ////[TableColumn("DetailType")]
        //public DetailClass DetailClass
        //{
        //    get { return _detailClass; }
        //    set
        //    {
        //        if (_detailClass != value)
        //        {
        //            _detailClass = value;
        //            OnPropertyChanged("DetailClass");
        //        }
        //    }
        //}
        #endregion

        #region public DetailType DetailType { get; set; }

        //private DetailType _detailType;
        ///// <summary>
        ///// тип простого агрегата
        ///// </summary>
        //[TableColumn("DetailType")]
        //public DetailType DetailType
        //{
        //    get { return _detailType; }
        //    set
        //    {
        //        if (_detailType != value)
        //        {
        //            _detailType = value;
        //            OnPropertyChanged("DetailType");
        //        }
        //    }
        //}
        #endregion

        #region public String PartNumber { get; set; }

        private string _partNumber;
        /// <summary>
        /// Чертёжный номер агрегата
        /// </summary>
        [TableColumn("PartNumber"), ListViewData(0.12f, "Part Number", 2)]
        [Filter("Part Number:", Order = 2)]
        [FormControl(150, "Part Number", Order = 2)]
        public String PartNumber
        {
            get { return _partNumber; }
            set { _partNumber = value; }
        }
        #endregion

        #region public String Description { get; set; }

        private string _description;
        /// <summary>
        /// Описание агрегата
        /// </summary>
        [TableColumn("Description"), ListViewData(0.12f, "Description", 3)]
        [FormControl(150, "Description", 8, Order = 3)]
        [Filter("Description:", Order = 3)]
        public String Description
        {
            get { return _description; }
            set
            {
                if(_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        #endregion

        //#region public Double CostNew { get; set; }

        //private double _costNew;
        ///// <summary>
        ///// Цена новой детали
        ///// </summary>
        //[TableColumn("CostNew"), MinMaxValue(0, 1000000000), ListViewData(0.08f, "Cost new")]
        //[FormControl(150, "Cost New")]
        //public Double CostNew
        //{
        //    get { return _costNew; } 
        //    set
        //    {
        //        if(_costNew != value)
        //        {
        //            _costNew = value;
        //            OnPropertyChanged("CostNew");
        //        }
        //    }
        //}
        //#endregion

        //#region public Double CostOverhaul { get; set; }

        //private double _costOvehaul;
        ///// <summary>
        ///// 
        ///// </summary>
        //[TableColumn("CostOverhaul"), MinMaxValue(0, 1000000000), ListViewData(0.08f, "Cost OH")]
        //[FormControl(150, "Cost OH")]
        //public Double CostOverhaul
        //{
        //    get { return _costOvehaul; } 
        //    set
        //    {
        //        if(_costOvehaul != value)
        //        {
        //            _costOvehaul = value;
        //            OnPropertyChanged("CostOverhaul");
        //        }
        //    }
        //}
        //#endregion

        //#region public Double CostServiceable { get; set; }

        //private double _costServiceable;
        ///// <summary>
        ///// 
        ///// </summary>
        //[TableColumn("CostServiceable"), MinMaxValue(0, 1000000000), ListViewData(0.08f, "Cost Serv.")]
        //[FormControl(150, "Cost Serv.")]
        //public Double CostServiceable
        //{
        //    get { return _costServiceable; } 
        //    set
        //    {
        //        if (_costServiceable != value)
        //        {
        //            _costServiceable = value;
        //            OnPropertyChanged("CostServiceable");
        //        }
        //    }
        //}
        //#endregion

        //#region public Measure Measure

        //private Measure _measure;
        ///// <summary>
        ///// Единица измерения
        ///// </summary>
        //[TableColumn("Measure"), ListViewData(0.08f, "Measure")]
        //[FormControl(150, "Measure")]
        //public Measure Measure
        //{
        //    get { return _measure; }
        //    set
        //    {
        //        if (_measure != value)
        //        {
        //            _measure = value;
        //            OnPropertyChanged("Measure");
        //        }
        //    }
        //}
        //#endregion

        #region public AccessoryDescription DefaultProduct { get; set; }

        private int _defaultProductId;
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("DefaultProductId"), MinMaxValue(0, 1000000000)]
        public int DefaultProductId
        {
            get { return _defaultProductId; }
            set
            {
                if (_defaultProductId != value)
                {
                    _defaultProductId = value;
                    OnPropertyChanged("DefaultProductId");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ListViewData(0.08f, "Default Product")]
        public Product DefaultProduct
        {
            get
            {
                return Products.FirstOrDefault(p => p.ItemId == _defaultProductId);
            }
        }
        #endregion

        #region public CommonCollection<AccessoryDescription> Products

        private CommonCollection<Product> _products;

        [Child(RelationType.OneToMany, "Standart", "Standart", false)]
        public CommonCollection<Product> Products
        {
            get { return _products ?? (_products = new CommonCollection<Product>()); }
            internal set
            {
                if (_products != value)
                {
                    if (_products != null)
                        _products.Clear();
                    if (value != null)
                        _products = value;
                }
            }
        }
        #endregion

        #region public String Remarks { get; set; }

        private string _remarks;
        /// <summary>
        /// Дополнительные заметки
        /// </summary>
        [TableColumn("Remarks"), ListViewData(0.08f, "Remarks")]
        [FormControl(300, "Remarks", 8)]
        public String Remarks
        {
            get { return _remarks; } 
            set { _remarks = value; }
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

        #region public int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is GoodStandart)
                return String.Compare(FullName, ((GoodStandart)y).FullName, StringComparison.Ordinal);
            return 0;
        }
        #endregion

        #region Implement of IEquatable

        #region public bool Equals(GoodStandart other)
        public bool Equals(GoodStandart other)
        {
            //Без переопределения метода GetHashCode данный метод не работает
            //Почему? - ХЗ

            //Check whether the compared object is null.
            if (ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return GoodsClass == other.GoodsClass &&
                   //DetailType == other.DetailType &&
                   FullName == other.FullName &&
                   Description == other.Description;
        }
        #endregion

        #region public override int GetHashCode()
        public override int GetHashCode()
        {
            var componentClassHash = GoodsClass.GetHashCode();
            var fullNameHash = FullName.GetHashCode();
            var partNumberHash = PartNumber.GetHashCode();
            var descriptionHash = Description.GetHashCode();

            return componentClassHash ^ fullNameHash ^ partNumberHash ^ descriptionHash;
        }
        #endregion

        #endregion

        #region public GoodStandart()
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public GoodStandart()
        {
            ItemId = -2;
            _description = "";
            _partNumber = "";
            _fullName = "";
            _remarks = "";
            //_measure = Measure.Unit;
            
            SmartCoreObjectType = SmartCoreType.GoodStandart;
        }
        #endregion

        #region public GoodStandart(GoodStandart toCopy) : this()
        /// <summary>
        /// Конструктор создает объект с привязкой родительского объекта
        /// </summary>
        public GoodStandart(GoodStandart toCopy)
            : this()
        {
            if (toCopy == null) 
                return;
            _fullName = toCopy.FullName;
            //_costNew = toCopy.CostNew;
            //_costOvehaul = toCopy.CostOverhaul;
            //_costServiceable = toCopy.CostServiceable;
            _description = toCopy.Description;
            //_measure = toCopy.Measure;
            _partNumber = toCopy.PartNumber;
            _remarks = toCopy.Remarks;
            _defaultProductId = -1;
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(GoodStandart));
        }
        #endregion

        //#region public override void SetProperties(AbstractDictionary dictionary)
        //public override void SetProperties(AbstractDictionary dictionary)
        //{
        //    if (dictionary is GoodStandart)
        //        SetProperties((GoodStandart)dictionary);
        //}
        //#endregion

        //#region public void SetProperties(GoodStandart dictionary)
        //public void SetProperties(GoodStandart dictionary)
        //{
        //    _fullName = dictionary.FullName;
        //    DetailClass = dictionary.DetailClass;
        //    DetailType = dictionary.DetailType;
        //    PartNumber = dictionary.PartNumber;
        //    Description = dictionary.Description;
        //    CostNew = dictionary.CostNew;
        //    CostOverhaul = dictionary.CostOverhaul;
        //    CostServiceable = dictionary.CostServiceable;
        //    Measure = dictionary.Measure;
        //    DefaultProductId = dictionary.DefaultProductId;
        //    Remarks = dictionary.Remarks;
        //    OnPropertyChanged("FullName");
        //}
        //#endregion

        #region public override BaseEntityObject GetCopyUnsaved()

        public override BaseEntityObject GetCopyUnsaved(bool marked = true)
        {
            GoodStandart good = (GoodStandart) MemberwiseClone();
            good.ItemId = -1;
            if(marked)
				good.FullName += " Copy";
            good.UnSetEvents();

            return good;
        }

        #endregion

    }
}
