using System;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Purchase
{
	/// <summary>
	/// Класс, описывает отношение между записью в первоначальном акте и записью в котировочном акте
	/// </summary>
	[Table("IORQORRelations", "dbo", "ItemId")]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class IORQORRelation : BaseEntityObject
	{
		//private static Type _thisType;
		/*
		*  Свойства
		*/

		#region public InitionalReason InitialReason { get; set; }

		private InitialOrderRecord _initialOrderRecord;
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("InitialOrderRecordId")]
		[Parent]
		public InitialOrderRecord InitialOrderRecord
		{
			get { return _initialOrderRecord; }
			set { _initialOrderRecord = value; }
		}

		#endregion

		#region public RequestForQuotationRecord RequestForQuotationRecord { get; set; }

		private RequestForQuotationRecord _requestForQuotationRecord;
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("RequestForQuotationRecordId")]
		[Parent]
		public RequestForQuotationRecord RequestForQuotationRecord
		{
			get { return _requestForQuotationRecord; }
			set { _requestForQuotationRecord = value; }
		}

		#endregion


		#region public Boolean Processed { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Processed")]
		public Boolean Processed { get; set; }
		#endregion

		/*
		*  Методы 
		*/

		#region public IORQORRelation()
		/// <summary>
		/// Создает отношение между записью в первоначальном акте и записью в котировочном акте
		/// </summary>
		public IORQORRelation()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.IORQORRelation;
		}
		#endregion

		#region public IORQORRelation(int rfqId, Product accessory, double quantity, DateTime effDate, DeferredCategory category = null):this()
		/// <summary>
		/// Создает запись  без дополнительной информации
		/// </summary>
		public IORQORRelation(InitialOrderRecord initialOrderRecord, RequestForQuotationRecord requestForQuotationRecord):this()
		{
			_initialOrderRecord = initialOrderRecord;
			_requestForQuotationRecord = requestForQuotationRecord;
		}
		#endregion

		//#region private static Type GetCurrentType()
		//private static Type GetCurrentType()
		//{
		//    return _thisType ?? (_thisType = typeof(RequestForQuotationRecord));
		//}
		//#endregion

		#region public override string ToString()
		/// <summary>
		/// Перегружаем для отладки
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return "";
		}
		#endregion   
	}
}
