using System;
using System.Reflection;
using EFCore.DTO.Dictionaries;
using SmartCore.Auxiliary;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
	[Table("SchedulePeriods", "Dictionaries", "ItemId")]
	[Dto(typeof(SchedulePeriodDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class SchedulePeriods : AbstractDictionary
	{
		private static Type _thisType;
		private DateTime _from;
		private DateTime _to;

		#region Implement of Dictionary

		#region public override string ShortName { get; set; }

		public override string ShortName { get; set; }

		#endregion

		#region public override string FullName { get; set; }

		public override string FullName { get; set; }

		#endregion

		#region public override string CommonName { get; set; }

		public override string CommonName { get; set; }

		#endregion

		#region public override string Category { get; set; }

		public override string Category { get; set; }

		#endregion

		[TableColumn("Schedule")]
		public Schedule Schedule { get; set; }

		[TableColumn("DateFrom")]
		public DateTime From
		{
			get { return _from < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : _from.Date; }
			set { _from = value; }
		}

		[TableColumn("DateTo")]
		public DateTime To
		{
			get { return _to < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : _to.Date; }
			set { _to = value; }
		}

		#endregion

		#region Methods

		#region public override void SetProperties(AbstractDictionary dict)

		public override void SetProperties(AbstractDictionary dict)
		{
			if (dict is SchedulePeriods)
				SetProperties((SchedulePeriods)dict);
		}


		public void SetProperties(SchedulePeriods dictionary)
		{
			FullName = dictionary.FullName;
			ShortName = dictionary.ShortName;
		}

		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(SchedulePeriods));
		}
		#endregion

		#endregion
	}
}