using System;
using EFCore.DTO.General;
using SmartCore.AuditMongo.Repository;
using SmartCore.Entities;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Activity
{
	public class ActivityDTO : BaseEntityObject
	{
		private Aircraft _aircraft;

		[Filter("Title:", Order = 1)]
		public string Title { get; set; }

		[Filter("Date:", Order = 2)]
		public DateTime Date { get; set; }

		[Filter("User:", Order = 3)]
		public User User { get; set; }

		[Filter("Operation:", Order = 4)]
		public AuditOperation Operation { get; set; }

		[Filter("Aircraft:", Order = 5)]
		public Aircraft Aircraft
		{
			get => _aircraft ?? Aircraft.Unknown;
			set => _aircraft = value;
		}

		[Filter("Type:", Order = 6)]
		public SmartCoreType Type { get; set; }

		public int ObjectId { get; set; }
		public string Information { get; set; }
	}
}