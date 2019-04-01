using System;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General
{
	[Table("AircraftEquipments", "dbo", "ItemId")]
	[Dto(typeof(AircraftEquipmentDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class AircraftEquipments : BaseEntityObject
	{
		private static Type _thisType;
		private AircraftOtherParameters _aircraftOtherParameter;

		#region public string Description { get; set; }

		[TableColumn("Description")]
		public string Description { get; set; }
		#endregion

		#region public AircraftOtherParameters AircraftOtherParameter { get; set; }

		[TableColumn("AircraftOtherParameter")]
		[Child]
		public AircraftOtherParameters AircraftOtherParameter
		{
			get { return _aircraftOtherParameter ?? AircraftOtherParameters.Unknown; }
			set { _aircraftOtherParameter = value; }
		}

		#endregion

		#region public AircraftEquipmetType AircraftEquipmetType { get; set; }

		[TableColumn("AircraftEquipmetType")]
		public AircraftEquipmetType AircraftEquipmetType { get; set; }
		#endregion

		#region public int AircraftId { get; set; }

		[TableColumn("AircraftId")]
		public int AircraftId { get; set; }

		public static PropertyInfo AircraftIdProperty
		{
			get { return GetCurrentType().GetProperty("AircraftId"); }
		}

		#endregion
        
		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(AircraftEquipments));
		}
        #endregion

        #region public AircraftEquipments()

        public AircraftEquipments()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.AircraftEquipments;
        }

        #endregion

	}
}