using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Personnel;
using SmartCore.Purchase;

namespace SmartCore.Entities.General.Interfaces
{
	public interface ITransferRecordFilterParams : IBaseEntityObject
	{
		#region String PartNumber { get; }

		/// <summary>
		/// Чертёжный номер агрегата
		/// </summary>
		[Filter("Part. Number:", Order = 1)]
		string PartNumber { get; }
		#endregion

		#region String SerialNumber { get; }

		/// <summary>
		/// Серийный номер агреагата
		/// </summary>
		[Filter("Serial Number:", Order = 2)]
		string SerialNumber { get; }
		#endregion

		#region string Description { get; }

		/// <summary>
		/// Описание агрегата
		/// </summary>
		[Filter("Description:", Order = 3)]
		string ComponentDescription { get; }
		#endregion

		#region AtaChapter ATAChapter { get;}

		[Filter("ATA:", Order = 4)]
		AtaChapter ATAChapter { get; }
		#endregion

		#region GoodsClass GoodsClass { get; }

		[Filter("Class:", Order = 6)]
		GoodsClass GoodsClass { get; }

		#endregion

		#region InitialReason Reason { get; }

		[Filter("Reason:", Order = 10)]
		InitialReason Reason { get; }

		#endregion

		#region BaseEntityObject From { get; }

		[Filter("From:", Order = 5)]
		BaseEntityObject From { get; }
		#endregion

		[Filter("Received:", Order = 12)]
		Specialist ReceivedSpecialist { get; }
		[Filter("Released:", Order = 13)]
		Specialist ReleasedSpecialist { get; }

		[Filter("From Supplier:", Order = 14)]
		Supplier FromSupplier { get; }


		#region BaseEntityObject DestinationObject { get; }

		[Filter("To:", Order = 7)]
		BaseEntityObject DestinationObject { get; }

		#endregion

	}
}
