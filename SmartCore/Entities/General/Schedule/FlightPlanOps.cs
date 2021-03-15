using System;
using EntityCore.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Schedule
{
	[Table("FlightPlanOps", "dbo", "ItemId")]
	[Dto(typeof(FlightPlanOpsDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class FlightPlanOps : BaseEntityObject
	{
		#region public DateTime From { get; set; }

		private DateTime _from;

		[TableColumn("DateFrom")]
		[FormControl("From", Order = 1)]
		public DateTime From
		{
			get
			{
				DateTime check = DateTimeExtend.GetCASMinDateTime();
				if (_from < check) _from = DateTime.Today;
				return _from;

			}
			set { _from = value; }
		}

		#endregion

		#region public DateTime From { get; set; }

		private DateTime _to;
		[TableColumn("DateTo")]
		[FormControl("To", Order = 2)]
		public DateTime To
		{
			get
			{
				DateTime check = DateTimeExtend.GetCASMinDateTime();
				if (_to < check) _to = DateTime.Today;
				return _to;

			}
			set { _to = value; }
		}

		#endregion

		#region public string Remarks { get; set; }
		[TableColumn("Remarks")]
		[FormControl("Remarks", Order = 3)]
		public string Remarks { get; set; }

		#endregion

		#region public new FlightPlanOps GetCopyUnsaved()

		public new FlightPlanOps GetCopyUnsaved(bool marked = true)
		{
			var newFlightPlanOps = (FlightPlanOps) MemberwiseClone();
			newFlightPlanOps.ItemId = -1;
			newFlightPlanOps.UnSetEvents();

			newFlightPlanOps.From.AddDays(6);
			return newFlightPlanOps;
		}

		#endregion

        public FlightPlanOps()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.FlightPlanOps;
        }
	}
}