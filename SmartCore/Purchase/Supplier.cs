using System;
using System.Reflection;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Purchase
{

	/// <summary>
	/// Класс описывает поставщика
	/// </summary>
	[Table("Supplier", "dbo", "ItemId")]
	[Dto(typeof(SupplierDTO))]
	[CAADto(typeof(CAASupplierDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class Supplier : BaseEntityObject
	{
		private static Type _thisType;
		/*
		*  Свойства
		*/

		#region public String Name { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Name")]
		[ListViewData(150, "Name")]
		[Filter("Name:")]
		public String Name { get; set; }
		#endregion

		#region public override GoodsClass GoodsClass { get; set; }

		private SupplierClass _supplierClass;

		[TableColumn("SupplierClassId")]
		[ListViewData(80, "SupplierType")]
		[Filter("SupplierType:")]
		[FormControl(250, "Class:",
			TreeDictRootNodes = new[]
			{
				"Customer", "Vendor","Manufacturer"
			})]
		public SupplierClass SupplierClass
		{
			get { return _supplierClass ?? (_supplierClass = SupplierClass.Unknown); }
			set
			{
				if (_supplierClass != value)
				{
					_supplierClass = value;
					OnPropertyChanged("SupplierClass");
				}
			}
		}

		public static PropertyInfo SupplierClassProperty
		{
			get { return GetCurrentType().GetProperty("SupplierClass"); }
		}

		#endregion

		[TableColumn("AirCode")]
		[ListViewData(150, "AirCode")]
		public String AirCode { get; set; }

		#region public String Subject { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Subject")]
		[ListViewData(225, "Subject")]
		[Filter("Subject:")]
		public string Subject { get; set; }
		#endregion

		#region public String Phone { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Phone")]
		[ListViewData(128, "Phone")]
		[Filter("Phone:")]
		public String Phone { get; set; }
		#endregion

		#region public String Fax { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Fax")]
		[ListViewData(128, "Fax")]
		[Filter("Fax:")]
		public String Fax { get; set; }
		#endregion

		#region public String Address { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Address")]
		[ListViewData(225, "Address")]
		[Filter("Address:")]
		public String Address { get; set; }
		#endregion

		#region public String ContactPerson { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("ContactPerson")]
		[ListViewData(150, "Contact Person")]
		[Filter("ContactPerson:")]
		public String ContactPerson { get; set; }
		#endregion

		#region public String Email { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Email")]
		[ListViewData(128, "Email")]
		[Filter("Email:")]
		public String Email { get; set; }
		#endregion

		#region public String WebSite { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("WebSite")]
		[ListViewData(150, "Web Site")]
		[Filter("WebSite:")]
		public String WebSite { get; set; }
		#endregion

		#region public String Products { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Products")]
		[ListViewData(225, "Products")]
		[Filter("Products:")]
		public String Products { get; set; }
		#endregion

		#region public bool Approved { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Approved")]
		public bool Approved { get; set; }

		[ListViewData(80, "Approved")]
		public string ListViewApproved
		{
			get { return Approved ? "Yes" : "No"; }
		}

		#endregion

		#region public String Remarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Remarks")]
		[ListViewData(225, "Remarks")]
		[Filter("Remarks:")]
		public String Remarks { get; set; }
		#endregion

		#region public String ShortName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("ShortName")]
		[ListViewData(80, "Short Name")]
		public String ShortName { get; set; }
		#endregion

		#region public String VendorCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("VendorCode")]
		[ListViewData(80, "Vendor Code")]
		public String VendorCode { get; set; }
		#endregion

		#region public CommonCollection<Document> EmployeeDocuments

		private CommonCollection<Document> _employeeDocuments;
		/// <summary>
		/// 
		/// </summary>
		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 2048, "Parent")]
		public CommonCollection<Document> SupplierDocs
		{
			get { return _employeeDocuments ?? (_employeeDocuments = new CommonCollection<Document>()); }
			internal set
			{
				if (_employeeDocuments != value)
				{
					if (_employeeDocuments != null)
						_employeeDocuments.Clear();
					if (value != null)
						_employeeDocuments = value;
				}
			}
		}
		#endregion
		/*
		*  Методы 
		*/
		
		#region public Supplier()
		/// <summary>
		/// Создает воздушное судно без дополнительной информации
		/// </summary>
		public Supplier()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.Supplier;
		}
		#endregion

		#region public override bool Equals(object obj)

		public override bool Equals(object obj)
		{
			//Check whether the compared object is null.
			if (ReferenceEquals(obj, null) || !(obj is Supplier))
				return false;

			//Check whether the compared object references the same data.
			if (ReferenceEquals(this, obj))
				return true;

			//Check whether the products' properties are equal.
			Supplier s = (Supplier) obj;
			if (ItemId > 0 && s.ItemId > 0 && ItemId == s.ItemId)
				return true;
			return Name == s.Name &&
				   ShortName == s.ShortName &&
				   VendorCode == s.VendorCode &&
				   Phone == s.Phone &&
				   Address == s.Address;
		}
		#endregion

		#region public override int GetHashCode()
		public override int GetHashCode()
		{
			return ItemId.GetHashCode();
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// Перегружаем для отладки
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Name;
		}
		#endregion 
  
		#region public override int CompareTo(object y)
		public override int CompareTo(object y)
		{
			if (y is Supplier) return Name.CompareTo(((Supplier) y).Name);
			return 0;
		}
		#endregion

		#region public static Department Unknown
		private static Supplier _unknown;

		public static Supplier Unknown
		{
			get
			{
				return _unknown ?? (_unknown = new Supplier
				{
					Name = "Unknown",
					ShortName = "UNK",
				});
			}
		}

		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(Supplier));
		}
		#endregion

		#region public override BaseEntityObject GetCopyUnsaved()

		public override BaseEntityObject GetCopyUnsaved(bool marked = true)
		{
			var supplier = (Supplier)MemberwiseClone();
			supplier.ItemId = -1;
			if (marked)
				supplier.Name += " Copy";
			supplier.UnSetEvents();

			return supplier;
		}

		#endregion

	}

}
