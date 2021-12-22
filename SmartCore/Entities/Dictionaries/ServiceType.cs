using System;
using CAA.Entity.Models.Dictionary;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
	[Table("ServiceTypes", "Dictionaries", "ItemId")]
	[Dto(typeof(ServiceTypeDTO))]
	[CAADto(typeof(CAAServiceTypeDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class ServiceType: AbstractDictionary
	{
		private static ServiceType _unknown;

		#region Implement of Dictionary

		#region public override string ShortName { get; set; }

		private string _shortName;

		[TableColumnAttribute("Name", 50)]
		[FormControl(150, "Name", 1, Order = 1)]
		[ListViewData(0.2f, "Name", 1)]
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
		[TableColumnAttribute("FullName", 256)]
		[FormControl(150, "FullName", 5, Order = 2)]
		[ListViewData(0.2f, "FullName", 2)]
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

		#endregion

		#region public override string CommonName { get; set; }

		public override string CommonName { get; set; }

		#endregion

		#region public override string Category { get; set; }

		public override string Category { get; set; }


		#endregion

		#endregion

		#region Methods

		public override void SetProperties(AbstractDictionary dict)
		{
			FullName = dict.FullName;
			ShortName = dict.ShortName;
		}

		#endregion

		#region public static ServiceType Unknown

		public static ServiceType Unknown
		{
			get
			{
				return _unknown ?? (_unknown = new ServiceType
				{
					FullName = "Unknown",
					ShortName = "UNK",
					Category = "",
					CommonName = "Unknown",
				});
			}
		}

        #endregion

        #region public ServiceType()

        public ServiceType()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.ServiceType;
        }

        #endregion

	}
}