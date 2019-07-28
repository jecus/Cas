using System;
using System.Reflection;
using EntityCore.DTO.Dictionaries;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
    [Table("Specializations", "Dictionaries", "ItemId")]
	[Dto(typeof(SpecializationDTO))]
    [DictionaryCollection(typeof(CommonDictionaryCollection<Specialization>))]
    [Condition("IsDeleted", "0")]
	[Serializable]
    public class Specialization : AbstractDictionary
    {
		private static Type _thisType;


		#region public override String ShortName { get; set; }
		/// <summary>
		/// Короткое имя
		/// </summary>
		[TableColumn("ShortName")]
        [ListViewData(0.2f,"Short Name", 1)]
        [FormControl(120, "Short Name", Order = 1)]
        [NotNull]
        public override String ShortName { get; set; }

        #endregion

        #region public override String FullName { get; set; }
        /// <summary>
        /// Полное имя
        /// </summary>
        [TableColumn("FullName")]
        [ListViewData(0.2f, "Full Name", 2)]
        [FormControl(120, "Full Name", Order = 2)]
        [NotNull]
        public override String FullName { get; set; }

		public static PropertyInfo FullNameProperty
		{
			get { return GetCurrentType().GetProperty("FullName"); }
		}

		#endregion

		#region public override string CommonName { get; set; }
		/// <summary>
		/// Общее имя (не сохраняется)
		/// </summary>
		public override string CommonName { get; set; }
        #endregion

        #region public override string Category { get; set; }
        /// <summary>
        /// Категория (не сохраняется)
        /// </summary>
        public override string Category { get; set; }
		#endregion

		#region public Department Department { get; set; }

	    [TableColumn("DepartmentId", 50)]
	    [FormControl(150, "Department", 1, Order = 3)]
	    [ListViewData(0.2f, "Department", 3)]
	    [NotNull]
	    [Child]
	    public Department Department
	    {
		    get => _department ?? Department.Unknown;
		    set => _department = value;
	    }

	    #endregion

		#region public int Level { get; set; }

		[TableColumn("Level")]
	    [FormControl(150, "Level", 1, Order = 4)]
	    [ListViewData(0.2f, "Level", 4)]
	    public int Level { get; set; }

		#endregion

		#region public bool KeyPersonel { get; set; }

		[TableColumn("KeyPersonel")]
	    [FormControl(150, "Key personel", 1, Order = 6)]
		[ListViewData(0.2f, "Key Personel", 6)]
		public bool KeyPersonel { get; set; }

	    #endregion


		#region public override void SetProperties(AbstractDictionary dictionary)
		public override void SetProperties(AbstractDictionary dictionary)
        {
            if (dictionary is Specialization)
                SetProperties((Specialization)dictionary);
        }
        #endregion

        #region public void SetProperties(Specialization dictionary)
        public void SetProperties(Specialization dictionary)
        {
            FullName = dictionary.FullName;
            ShortName = dictionary.ShortName;
            CommonName = dictionary.CommonName;
            Category = dictionary.Category;
        }
        #endregion

        #region public Specialization()
        public Specialization()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.Specialization;
        }
		#endregion

		#region public static Department Unknown
		private static Specialization _unknown;
	    private Department _department;

	    public static Specialization Unknown
		{
			get
			{
				return _unknown ?? (_unknown = new Specialization
				{
					FullName = "Unknown",
					ShortName = "UNK",
					Category = "",
					CommonName = "Unknown"
				});
			}
		}

		#endregion

		public Specialization(Int32 id, string name)
        {
            ShortName = name;
            ItemId = id;
        }

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(Specialization));
		}
		#endregion
	}
}
