using System;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
	[Table("FlightNum", "Dictionaries", "ItemId")]
	[Dto(typeof(FlightNumDTO))]
	[DictionaryCollection(typeof(CommonDictionaryCollection<FlightNum>))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class FlightNum : AbstractDictionary
	{
		private static FlightNum _unknown;
		public override string ShortName { get; set; }

		[TableColumn("FlightNumber")]
		[FormControl("FlightNumber", Enabled = true, Order = 6)]
		[Filter("FullName")]
		[ListViewData(100f, "FlightNumber", 6)]
		public override string FullName { get; set; }
		public override string CommonName { get; set; }
		public override string Category { get; set; }

		#region public override void SetProperties(AbstractDictionary dictionary)

		public override void SetProperties(AbstractDictionary dictionary)
		{
			if (dictionary is FlightNum)
				SetProperties((FlightNum)dictionary);
		}

		#endregion

		#region public void SetProperties(Airport dictionary)
		public void SetProperties(FlightNum dictionary)
		{
			FullName = dictionary.FullName;
			ShortName = dictionary.ShortName;
			CommonName = dictionary.CommonName;
			Category = dictionary.Category;
		}
		#endregion

		#region public static FlightNum Unknown

		public static FlightNum Unknown
		{
			get
			{
				return _unknown ?? (_unknown = new FlightNum
				{
					FullName = "Maintenance",
					ShortName = "Maintenance",
					Category = "",
					CommonName = "N/A",
					ItemId = -1
				});
			}
		}

		#endregion

		public override string ToString()
		{
			return FullName;
		}

        #region public FlightNum()

        public FlightNum()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.FlightNum;
        }

        #endregion
	}
}