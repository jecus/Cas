using System;
using System.Collections.Generic;
using System.ComponentModel;
using EntityCore.DTO.Dictionaries;
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
    [Condition("IsDeleted", "0")]
    [Condition("ModelingObjectTypeId", "5")]
    [Description("Component Models")]
    [Serializable]
    public class ComponentModel : AbstractModel
    {

        #region public SmartCoreType ModelingObjectType
        /// <summary>
        /// Тип родительской задачи
        /// </summary>
        [TableColumnAttribute("ModelingObjectTypeId", ColumnAccessType.WriteOnly)]
        public override SmartCoreType ModelingObjectType
        {
            get { return SmartCoreType.Component; }
        }
		#endregion
		

		/*
         * Свойства 
         */

		/*
         * Методы
         */

		//#region public override void SetProperties(AbstractDictionary dictionary)
		//public override void SetProperties(AbstractDictionary dictionary)
		//{
		//    if (dictionary is DetailModel) 
		//        SetProperties((DetailModel)dictionary);
		//}
		//#endregion

		//#region public void SetProperties(DetailModel dictionary)
		//public void SetProperties(DetailModel dictionary)
		//{
		//    FullName = dictionary.FullName;
		//    ShortName = dictionary.ShortName;
		//    Model = dictionary.Model;
		//    Series = dictionary.Series;
		//    Manufacturer = dictionary.Manufacturer;
		//    ManufactureReg = dictionary.ManufactureReg;
		//}
		//#endregion

		#region public override string ToString()
		/// <summary>
		/// Переводит тип директивы в строку
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (string.IsNullOrEmpty(PartNumber) || PartNumber == "N/A")
				return FullName;

			//todo:(Evgenii Babak)Возможно даст ошибку в других местах
			return FullName + " | P/N:" + PartNumber;
        }
		#endregion

		/*
         * Реализация
         */
		#region public ComponentModel()
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public ComponentModel()
        {
            ManufactureReg = ManufactureRegion.Unknown;

            GoodsClass = GoodsClass.ComponentsAndParts;
            Measure = Measure.Unit;
        }
		#endregion

		#region public ComponentModel(string manufacturer, String shortName, String fullName, AircraftManufactureRegion region)

		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		/// <param name="manufacturer"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		/// <param name="region"></param>
		public ComponentModel GetInstance(string manufacturer, String shortName, String fullName, ManufactureRegion region)
        {
            return new ComponentModel
                       {
                           Manufacturer = manufacturer,
                           ShortName = shortName,
                           FullName = fullName,
                           ManufactureReg = region
                       };
        }
        #endregion

        #region public override int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is ComponentModel)
                return String.Compare(FullName, ((ComponentModel)y).FullName, StringComparison.Ordinal);
            return 0;
        }
		#endregion

		#region public static ComponentModel GetInstanceFromProduct(Product product)
		/// <summary>
		/// Создает модель агрегата на основе продукта
		/// </summary>
		public static ComponentModel GetInstanceFromProduct(Product product)
        {
            return new ComponentModel
                       {
                           ItemId = product.ItemId,
                           IsDeleted = product.IsDeleted,
                           GoodsClass = product.GoodsClass,
                           Standart = product.Standart,
                           PartNumber = product.PartNumber,
                           SerialNumber = product.SerialNumber,
                           BatchNumber = product.BatchNumber,
                           Description = product.Description,
                           Manufacturer = product.Manufacturer,
                           CostNew = product.CostNew,
                           CostOverhaul = product.CostOverhaul,
                           CostServiceable = product.CostServiceable,
                           Measure = product.Measure,
                           Remarks = product.Remarks,
                           Suppliers = product.Suppliers,
                           SupplierRelations = product.SupplierRelations
                       };
        }
		#endregion

		#region public bool Equals(ComponentModel other)
		//public bool Equals(DetailModel other)
		//{
		//    //Без переопределения метода GetHashCode данный метод не работает
		//    //Почему? - ХЗ

		//    //Check whether the compared object is null.
		//    if (ReferenceEquals(other, null)) return false;

		//    //Check whether the compared object references the same data.
		//    if (ReferenceEquals(this, other)) return true;

		//    if (ItemId > 0 && other.ItemId > 0)
		//        return ItemId == other.ItemId;

		//    //Check whether the products' properties are equal.
		//                   ShortName = "",
		//                   Model = "",
		//                   Series = "",
		//                   ManufactureReg = ManufactureRegion.Unknown,
		//                   Manufacturer = "",
		//                   Designer = ""
		//    return FullName == other.FullName &&
		//           FullName == other.FullName &&
		//           FullName == other.FullName &&
		//           FullName == other.FullName &&
		//        FullName == other.FullName &&
		//        FullName == other.FullName &&
		//           GoodsClass == other.GoodsClass &&
		//           Standart == other.Standart &&
		//           PartNumber == other.PartNumber &&
		//           Description == other.Description;
		//}
		#endregion

	    public new ComponentModel GetCopyUnsaved()
	    {
		    ComponentModel product = (ComponentModel)MemberwiseClone();
		    product.ItemId = -1;
		    product.Name += " Copy";
		    product.UnSetEvents();

		    product.SupplierRelations = new CommonCollection<KitSuppliersRelation>();
		    foreach (KitSuppliersRelation kitSuppliers in SupplierRelations)
		    {
			    KitSuppliersRelation newObject = kitSuppliers.GetCopyUnsaved();
			    product.SupplierRelations.Add(newObject);
		    }

		    return product;
	    }
	}

	#region public class DetailModelStringComparer : IEqualityComparer<DetailModel>
	/// <summary>
	/// Сравнивает строковые преобразования моделей деталей
	/// </summary>
	public class ComponentModelStringComparer : IEqualityComparer<ComponentModel>
    {
        // Products are equal if their names and product numbers are equal. 
        public bool Equals(ComponentModel x, ComponentModel y)
        {
            //Check whether any of the compared objects is null. 
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal. 
            return x.ToString() == y.ToString();
        }

        // If Equals() returns true for a pair of objects  
        // then GetHashCode() must return the same value for these objects. 

        public int GetHashCode(ComponentModel model)
        {
            //Check whether the object is null 
            if (ReferenceEquals(model, null)) 
                return 0;
            //Calculate the hash code for the product. 
            return model.ToString().GetHashCode();
        }
    }
    #endregion
}
