using System;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IProcessingFilterParams
	{
		#region String PartNumber { get; }

		/// <summary>
		/// Чертёжный номер агрегата
		/// </summary>
		[Filter("Part. Number:")]
		string PartNumber { get; }
		#endregion

		#region String SerialNumber { get; }

		/// <summary>
		/// Серийный номер агреагата
		/// </summary>
		[Filter("Serial Number:")]
		string SerialNumber { get; }
		#endregion

		#region string Description { get; }

		/// <summary>
		/// Описание агрегата
		/// </summary>
		[Filter("Description:")]
		string Description { get; }
		#endregion

		#region string Code { get; }

		[Filter("Code:")]
		string Code { get; }
		#endregion

		#region string BatchNumber { get; }

		[Filter("Batch Number:")]
		string BatchNumber { get; }

		#endregion

		#region string IdNumber { get; }

		[Filter("ID:")]
		string IdNumber { get; }

		#endregion

		#region DateTime TransferDate { get; }

		[Filter("Date of shipment :")]
		DateTime TransferDate { get; }

		#endregion

		#region DateTime SupplierReceiptDate { get; }

		[Filter("Date of receipt :")]
		DateTime SupplierReceiptDate { get; }

		#endregion

		#region BaseEntityObject From { get; }

		[Filter("From :")]
		BaseEntityObject From { get; }

		#endregion

		#region BaseEntityObject DestinationObject { get; }

		[Filter("To :")]
		BaseEntityObject DestinationObject { get; }

		#endregion

		#region SupplierClass SupplierClass { get; }

		[Filter("SupplierClass :")]
		SupplierClass SupplierClass { get; }

		#endregion

		#region InitialReason Reason { get; }

		[Filter("Reason :")]
		InitialReason Reason { get; }

			#endregion

		#region GoodsClass GoodsClass { get; }

		[Filter("Class:")]
		GoodsClass GoodsClass { get; }

		#endregion

		#region Lifelength Warranty { get; }

		[Filter("Warranty :")]
		Lifelength Warranty { get; }

		#endregion

		#region bool Approved { get; }

		[Filter("Approved :")]
		bool Approved { get; }

		#endregion

		#region bool IsPOOL { get; }

		[Filter("IsPool :")]
		bool IsPOOL { get; }

		#endregion

		#region bool IsDangerous { get; }

		[Filter("IsDangerous :")]
		bool IsDangerous { get; }

		#endregion
	}
}