using System;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{

    /// <summary>
    /// модель воздушного судна
    /// </summary>
    [Table("AccessoryDescriptions", "Dictionaries", "ItemId")]
	[Dto(typeof(AccessoryDescriptionDTO))]
    //[Table("Models", "Dictionaries", "ItemId")]
    //[DictionaryCollection(typeof(CommonDictionaryCollection<AircraftModel>))]
    [Condition("IsDeleted", "0")]
    [Condition("ModelingObjectTypeId", "7")]
    [Serializable]
    public class AircraftModel : AbstractModel
    {
	    #region public string FullName { get; set; }

	    private string _fullName;
	    /// <summary>
	    /// Полное название серии модели самолета Н:Boeing 737
	    /// </summary>
	    [TableColumn("FullName")]
	    [FormControl(150, "Full Name", 1, Order = 5)]
	    [ListViewData(0.2f, "Full Name", 4)]
	    [NotNull]
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

	    #region public string ShortName { get; set; }

	    private string _shortName;
	    /// <summary>
	    /// Сокращенное название модели самолета
	    /// </summary>
	    [TableColumn("ShortName")]
	    [FormControl(150, "Short Name", Order = 6)]
	    [ListViewData(0.08f, "Short Name",5)]
	    [NotNull]
	    public string ShortName
	    {
		    get { return _shortName; }
		    set
		    {
			    if (_shortName != value)
			    {
				    _shortName = value;
				    OnPropertyChanged("ShortName");
			    }
		    }
	    }

	    #endregion

		private static AircraftModel _unknown;

        #region public SmartCoreType ModelingObjectType
        /// <summary>
        /// Тип родительской задачи
        /// </summary>
        [TableColumnAttribute("ModelingObjectTypeId", ColumnAccessType.WriteOnly)]
        public override SmartCoreType ModelingObjectType
        {
            get { return SmartCoreType.Aircraft; }
        }
		#endregion

		#region public GoodsClass GoodsClass { get; set; }

	    private GoodsClass _goodsClass;
	    /// <summary>
	    /// Класс
	    /// </summary>
	    [TableColumn("ComponentClass")]
	    [FormControl(250, "Class:", "Standart", "GoodsClass", false,
		    TreeDictRootNodes = new[]
		    {
				"ComponentsAndParts"
			}, Order = 10)]
	    [ListViewData(0.15f, "Class")]
	    [NotNull]
	    [Filter("Class:")]

	    public GoodsClass GoodsClass
	    {
		    get { return _goodsClass; }
		    set
		    {
			    if (_goodsClass != value)
			    {
				    _goodsClass = value;
				    OnPropertyChanged("GoodsClass");
			    }
		    }
	    }

		#endregion
		/*
         * Свойства 
         */

		/*
         * Методы
         */
		public new AircraftModel GetCopyUnsaved(bool marked = true)
	    {
		    var model = (AircraftModel)MemberwiseClone();
		    model.ItemId = -1;

			if(marked)
				model.Name += " Copy";

		    model.UnSetEvents();

		    model.SupplierRelations = new CommonCollection<KitSuppliersRelation>();
		    foreach (KitSuppliersRelation kitSuppliers in SupplierRelations)
		    {
			    KitSuppliersRelation newObject = kitSuppliers.GetCopyUnsaved();
			    model.SupplierRelations.Add(newObject);
		    }

		    return model;
	    }

		#region public override string ToString()
		/// <summary>
		/// Переводит тип директивы в строку
		/// </summary>
		/// <returns></returns>
		public override string ToString()
        {
			//todo:(Evgenii Babak)Возможно даст ошибку в других местах
			return FullName;
        }
        #endregion

        /*
         * Реализация
         */
        #region public AircraftModel()
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public AircraftModel()
        {
            //SmartCoreObjectType = SmartCoreType.AircraftModel;

            //_fullName = "";
            //_shortName = "";
            //_commonName = "";
            //_category = "";
            //_manufactureReg = ManufactureRegion.Unknown;
            //_manufacturer = "";
            //_designer = "";
        }
        #endregion

        #region public override int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is AircraftModel)
                return String.Compare(FullName, ((AircraftModel)y).FullName, StringComparison.Ordinal);
            return 0;
        }
        #endregion

        #region public static AircraftModel Unknown
        /// <summary>
        /// Возвращает неизвестную модель ВС
        /// </summary>
        public static AircraftModel Unknown
        {
            get
            {
                return _unknown ??
                       (_unknown = new AircraftModel
                                       {
                                           FullName = "N/A",
                                           ShortName = "N/A",
                                           Name = "",
                                           Series = "",
                                           ManufactureReg = ManufactureRegion.Unknown,
                                           Manufacturer = "",
                                           Designer = ""
                                       });
            }
        }
		#endregion

	}
}
