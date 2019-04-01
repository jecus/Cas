using System;
using EFCore.DTO.Dictionaries;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
	[Table("AirportsCodes", "Dictionaries", "ItemId")]
	[Dto(typeof(AirportCodeDTO))]
	[DictionaryCollection(typeof(CommonDictionaryCollection<AirportsCodes>))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class AirportsCodes : AbstractDictionary
	{
        #region public AirportsCodes()

        public AirportsCodes()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.AirportsCodes;
        }

            #endregion

		#region public override string ShortName { get; set; }

		[TableColumn("Iata")]
		[FormControl("Iata", Enabled = true, Order = 1)]
		[ListViewData(100f, "Iata", 1)]
		[Filter("Iata", Order = 1)]
		public override string ShortName { get; set; }

		#endregion

		#region public string Icao { get; set; }

		[TableColumn("Icao")]
		[FormControl("Icao", Enabled = true, Order = 2)]
		[ListViewData(100f, "Icao", 2)]
		[Filter("Icao", Order = 2)]
		public string Icao { get; set; }

		#endregion

		#region public override string FullName { get; set; }

		[TableColumn("FullName")]
		[FormControl("Airport", Enabled = true, Order = 3)]
		[ListViewData(100f, "Airport", 3)]
		[Filter("Airport", Order = 3)]
		public override string FullName { get; set; }

		#endregion

		#region public string City { get; set; }

		[TableColumn("City")]
		[FormControl("City", Enabled = true, Order = 4)]
		[ListViewData(100f, "City", 4)]
		[Filter("City", Order = 4)]
		public string City { get; set; }

		#endregion

		#region public string Country { get; set; }

		[TableColumn("Country")]
		[FormControl("Country", Enabled = true, Order = 5)]
		[ListViewData(100f, "Country", 5)]
		[Filter("Country", Order = 5)]
		public string Country { get; set; }

		#endregion

		#region public string Iso { get; set; }

		[TableColumn("Iso")]
		[FormControl("Iso", Enabled = true, Order = 6)]
		[ListViewData(100f, "Iso", 6)]
		[Filter("Iso", Order = 6)]
		public string Iso { get; set; }

		#endregion

		#region public AirportsCodes Unknown

		private static AirportsCodes _unknown;

		public static AirportsCodes Unknown
		{
			get
			{
				return _unknown ?? (_unknown = new AirportsCodes
				{
					FullName = "Unknown",ItemId = -1
				});
			}
		}

		#endregion


		#region public override string CommonName { get; set; }

		public override string CommonName { get; set; }

		#endregion

		#region public override string Category { get; set; }

		public override string Category { get; set; }

		#endregion

		#region public override void SetProperties(AbstractDictionary dictionary)

		public override void SetProperties(AbstractDictionary dictionary)
		{
			if (dictionary is AirportsCodes)
				SetProperties((AirportsCodes)dictionary);
		}

		#endregion

		#region public void SetProperties(Airport dictionary)
		public void SetProperties(AirportsCodes dictionary)
		{
			FullName = dictionary.FullName;
			ShortName = dictionary.ShortName;
			CommonName = dictionary.CommonName;
			Category = dictionary.Category;
			City = dictionary.City;
			Country = dictionary.Country;
			Icao = dictionary.Icao;
			Iso = dictionary.Iso;
		}
		#endregion

		public override string ToString()
		{
			return $"{ShortName} {City}";
		}
	}
}