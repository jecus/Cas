using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IStoreFilterParam : IBaseEntityObject
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
		string Description { get; }
		#endregion

		#region string Manufacturer { get; }

		/// <summary>
		/// Производитель
		/// </summary>
		[Filter("Manufacturer:", Order = 4)]
		string Manufacturer { get; }
		#endregion

		#region string Remarks { get; }
		/// <summary>
		/// 
		/// </summary>
		[Filter("Remarks:", Order = 5)]
		string Remarks { get; }
		#endregion

		#region string HiddenRemarks { get; }
		/// <summary>
		/// 
		/// </summary>
		[Filter("Hidden Remarks:", Order = 6)]
		string HiddenRemarks { get; }
		#endregion

		#region string BatchNumber { get; }

		[Filter("Batch Number:", Order = 7)]
		string BatchNumber { get; }

		#endregion

		#region string Code { get; }

		[Filter("Code:", Order = 8)]
		string Code { get; }
		#endregion

		#region string IdNumber { get; }

		[Filter("ID:", Order = 9)]
		string IdNumber { get; }

		#endregion

		#region bool IsPOOL { get; }

		[Filter("IsPool :", Order = 14)]
		bool IsPOOL { get; }

		#endregion

		#region bool IsDangerous { get; }

		[Filter("IsDangerous :", Order = 16)]
		bool IsDangerous { get; }

		#endregion

		#region GoodsClass GoodsClass { get; }

		[Filter("Class:", Order = 15)]
		GoodsClass GoodsClass { get; }

		#endregion

		#region AtaChapter ATAChapter { get;}
		/// <summary>
		/// Внешний ключ на идентификатор записи со справочной информацией
		/// </summary>
		[Filter("ATA:", Order = 18)]
		AtaChapter ATAChapter { get; }
		#endregion

		#region ComponentRecordType DirectiveType  { get; }

		/// <summary>
		/// Возвращает тип выполняемых работ
		/// </summary>
		[Filter("Work Type:", Order = 20)]
		ComponentRecordType DirectiveType { get; }
		#endregion

		#region ComponentStatus ComponentStatus { get; }

		/// <summary>
		/// Возвращает текущий статус задачи: Открыта, Повторяется или Закрыта
		/// </summary>
		[Filter("Status:", Order = 19)]
		ComponentStatus ComponentStatus { get; }
		#endregion

		#region ComponentStorePosition State { get; }

		[Filter("State:", Order = 17)]
		ComponentStorePosition State { get; }

		#endregion

		#region Locations Location { get; }

		[Filter("Location :", Order = 21)]
		Locations Location { get; }

		#endregion

		#region ConditionState Condition { get; }

		/// <summary>
		/// Возвращает состояние ближайшего выполнения задачи (если оно расчитано) или ConditionState.NotEstimated
		/// </summary>
		[Filter("Condition:", Order = 22)]
		ConditionState Condition { get; }
		#endregion

		#region LocationsType Facility { get; }

		[Filter("Facility:", Order = 23)]
		LocationsType Facility { get; }
			#endregion

		#region SupplierCollection Suppliers  { get; set; }

		/// <summary>
		/// Поставщики данной детали
		/// </summary>
		[Filter("Suppliers:")]
		SupplierCollection Suppliers { get; }
		#endregion

		#region NDTType NDTType { get; }
		/// <summary>
		/// Возвращает тип производимого Non-Destructive-Test
		/// </summary>
		[Filter("NDT:")]
		NDTType NDTType { get; }

		#endregion

		#region MaintenanceControlProcess MaintenanceControlProcess { get; }
		/// <summary>
		/// Идентификатор записи с типом технического обслуживания
		/// </summary>
		[Filter("Maint. Proc.:")]
		MaintenanceControlProcess MaintenanceControlProcess { get; }
		#endregion

		[Filter("Standart:")]
		GoodStandart Standart { get; }

		#region BaseComponent ParentBaseComponent { get; }

		/// <summary>
		/// Получает базовый агрегат, на котором установлен агрегат
		/// </summary>
		[Filter("Base Detail:")]
		BaseComponent ParentBaseComponent { get; }
		#endregion

		#region Lifelength FirstPerformanceSinceNew { get; }

		/// <summary>
		/// Возвращает порог первого выполнения задачи
		/// </summary>
		[Filter("1st. Perf.:")]
		Lifelength FirstPerformanceSinceNew { get; }
		#endregion

		#region Lifelength Interval { get; }

		/// <summary>
		/// Возвращает интервал повторного выполнения задачи или Lifelength.Null
		/// </summary>
		[Filter("Rpt. Int.:")]
		Lifelength Interval { get; }
		#endregion

		#region Lifelength Warranty { get; }

		[Filter("Warranty :")]
		Lifelength Warranty { get; }

		#endregion

		[Filter("Refference:", Order = 10)]
		string Reference { get; }

		[Filter("Effectivity:", Order = 11)]
		string IsEffectivity { get; }

		[Filter("Alt. Part No:", Order = 12)]
		string ALTPartNumber { get; }
		
		[Filter("Name:", Order = 13)]
		string Name { get; }
	}
}