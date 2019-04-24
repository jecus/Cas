using System;
using EFCore.DTO.General;
using SmartCore.AuditMongo.Repository;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Activity
{
	public class ActivityDTO : BaseEntityObject
	{
		[Filter("Date:", Order = 1)]
		public DateTime Date { get; set; }

		[Filter("User:", Order = 2)]
		public UserDTO User { get; set; }

		[Filter("Operation:", Order = 3)]
		public AuditOperation Operation { get; set; }

		[Filter("Type:", Order = 4)]
		public SmartCoreType Type { get; set; }


		public int ObjectId { get; set; }
	}
}