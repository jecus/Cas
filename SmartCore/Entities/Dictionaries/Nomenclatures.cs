using System;
using System.Reflection;
using CAA.Entity.Models;
using CAA.Entity.Models.Dictionary;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
	[Table("Nomenclatures", "Dictionaries", "ItemId")]
	[Dto(typeof(NomenclatureDTO))]
	[CAADto(typeof(CAANomenclatureDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class Nomenclatures : AbstractDictionary, IOperatable
	{
		private static Type _thisType;
		private static Nomenclatures _unknown;

		#region Implement of Dictionary

		#region public override string ShortName { get; set; }

		private string _shortName;

		[Filter("Short Name", Order = 1)]
		[TableColumn("Name", 50)]
		[FormControl(150, "Short Name", 1, Order = 1)]
		[ListViewData(0.2f, "Short Name", 1)]
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
		[Filter("Full Name", Order = 2)]
		[TableColumn("FullName", 256)]
		[FormControl(150, "Full Name", 5, Order = 2)]
		[ListViewData(0.2f, "Full Name", 2)]
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

		#region public override string CommonName { get; set; }

		public override string CommonName { get; set; }

		#endregion

		#region public override string Category { get; set; }

		public override string Category { get; set; }

		#endregion

		#endregion

		#region public Department Department { get; set; }

		[Filter("Department", Order = 3)]
		[TableColumn("DepartmentId", 50)]
		[FormControl(150, "Department", 1, Order = 3)]
		[ListViewData(0.2f, "Department", 3)]
		[NotNull]
		[Child]
		public Department Department { get; set; }
		
		#endregion

		#region public static Nomenclatures Unknown

		public static Nomenclatures Unknown
		{
			get
			{
				return _unknown ?? (_unknown = new Nomenclatures
				{
					FullName = "Unknown",
					ShortName = "UNK",
					Category = "",
					CommonName = "Unknown",
					Department = Department.Unknown
				});
			}
		}

		#endregion


		#region Methods

		#region public override void SetProperties(AbstractDictionary dict)

		public override void SetProperties(AbstractDictionary dict)
		{
			if (dict is Nomenclatures)
				SetProperties((Nomenclatures)dict);
		}


		public void SetProperties(Nomenclatures dictionary)
		{
			FullName = dictionary.FullName;
			ShortName = dictionary.ShortName;
			Department = dictionary.Department;
		}

		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(Nomenclatures));
		}
		#endregion

		#region public override BaseEntityObject GetCopyUnsaved()

		public override BaseEntityObject GetCopyUnsaved(bool marked = true)
		{
			var nomenclatures = (Nomenclatures)MemberwiseClone();
			nomenclatures.ItemId = -1;
			if(marked)
				nomenclatures.FullName += " Copy";
			nomenclatures.UnSetEvents();

			return nomenclatures;
		}

		#endregion

		public override string ToString()
		{
			return $"{FullName}";
		}

        #endregion

        #region public Nomenclatures()

        public Nomenclatures()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.Nomenclatures;
        }

		#endregion

        public int OperatorId { get; set; }
	}
}