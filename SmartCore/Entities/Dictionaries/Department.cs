using System;
using System.Reflection;
using CAA.Entity.Models.Dictionary;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
	[Table("Departments", "Dictionaries", "ItemId")]
	[Dto(typeof(DepartmentDTO))]
	[CAADto(typeof(CAADepartmentDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class Department : AbstractDictionary
	{
		private static Type _thisType;
		private static Department _unknown;

		#region public Department()

		public Department()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.Department;
		}

		#endregion

		#region Implement of Dictionary

		#region public override string ShortName { get; set; }

		private string _shortName;

		[TableColumn("Name", 50)]
		[FormControl(250, "Short Name", 1, Order = 1)]
		[ListViewData(0.2f, "Short Name", 1)]
		[Filter("Short Name:", Order = 1)]
		[NotNull]
		public override string ShortName
		{
			get { return _shortName; }
			set
			{
				_shortName = value;
				OnPropertyChanged("ShortName");
			}
		}

		#endregion

		#region public override string FullName { get; set; }

		private string _fullName;

		/// <summary>
		/// Полное название Категории
		/// </summary>
		[TableColumn("FullName", 256)]
		[FormControl(250, "Full Name", 5, Order = 2)]
		[ListViewData(0.2f, "Full Name", 2)]
		[Filter("Full Name:", Order = 2)]
		[NotNull]
		public override string FullName
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


		public static PropertyInfo FullNameProperty
		{
			get { return GetCurrentType().GetProperty("FullName"); }
		}

		#endregion

		[TableColumn("Address", 50)]
		[FormControl(250, "Address", 3, Order = 3)]
		[ListViewData(0.12f, "Address", 3)]
		[Filter("Address:", Order = 3)]
		public string Address { get; set; }

		[TableColumn("Phone", 50)]
		[FormControl(250, "Phone", 1, Order = 4)]
		[ListViewData(0.12f, "Phone", 4)]
		[Filter("Phone:", Order = 4)]
		public string Phone { get; set; }

		[TableColumn("Fax", 50)]
		[FormControl(250, "Fax", 1, Order = 5)]
		[ListViewData(0.12f, "Fax", 5)]
		[Filter("Fax:", Order = 5)]
		public string Fax { get; set; }

		[TableColumn("Email", 50)]
		[FormControl(250, "Email", 1, Order = 6)]
		[ListViewData(0.12f, "Email", 6)]
		[Filter("Email:", Order = 6)]
		public string Email { get; set; }

		[TableColumn("Website", 50)]
		[FormControl(250, "Website", 1, Order = 7)]
		[ListViewData(0.12f, "Website", 7)]
		[Filter("Website:", Order = 7)]
		public string Website { get; set; }

		#region public override string CommonName { get; set; }

		public override string CommonName { get; set; }

		#endregion

		#region public override string Category { get; set; }

		public override string Category { get; set; }

		#endregion

		#endregion

		#region Methods

		#region public override void SetProperties(AbstractDictionary dict)

		public override void SetProperties(AbstractDictionary dict)
		{
			if (dict is Department)
				SetProperties((Department) dict);
		}


		public void SetProperties(Department dictionary)
		{
			FullName = dictionary.FullName;
			ShortName = dictionary.ShortName;
			Address = dictionary.Address;
			Phone = dictionary.Phone;
			Fax = dictionary.Fax;
			Email = dictionary.Email;
			Website = dictionary.Website;
		}

		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(Department));
		}
		#endregion

		#endregion

		#region public static Department Unknown

		public static Department Unknown
		{
			get
			{
				return _unknown ?? (_unknown = new Department
				{
					FullName = "Unknown",
					ShortName = "UNK",
					Category = "",
					CommonName = "Unknown"
				});
			}
		}

		#endregion


	}
}