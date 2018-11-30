using System;
using System.Collections.Generic;
using System.Reflection;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace SmartCore.DataAccesses.Kits
{
	[Table("Kits", "dbo", "ItemId")]
	[Dto(typeof(KitDTO))]
	[Condition("IsDeleted", "0")]
	public class KitDTO : BaseEntityObject
	{
		private static Type _thisType;

		/// <summary>
		/// Описание агрегата
		/// </summary>
		[TableColumn("AccessoryDescriptionId")]
		[Child(true)]
		public Product Product { get; set; }

		/// <summary>
		/// Чертёжный номер агрегата
		/// </summary>
		[TableColumn("GoodStandartId")]
		public int GoodStandartId { get; set; }

		/// <summary>
		/// Чертёжный номер агрегата
		/// </summary>
		[TableColumn("PartNumber")]
		public string PartNumber { get; set; }

		//TODO:(Evgenii Babak) удалить закоменченные свойства если не нужны
		/// <summary>
		/// Цена новой детали
		/// </summary>
		//[TableColumn("CostNew")]
		//public double CostNew { get; set; }


		/// <summary>
		/// 
		/// </summary>
		//[TableColumn("CostOverhaul")]
		//public double CostOverhaul { get; set; }

		/// <summary>
		/// Стоимость после обслуживания
		/// </summary>
		//[TableColumn("CostServiceable")]
		//public double CostServiceable { get; set; }

		/// <summary>
		/// Необходимое кол-во комплектующего для выполнения задачи
		/// </summary>
		[TableColumn("Quantity")]
		public  double Quantity { get; set; }


		//[TableColumn("Measure")]
		public int Measure { get; set; }

		/// <summary>
		/// Дополнительные заметки
		/// </summary>
		[TableColumn("Remarks")]
		public string Remarks { get; set; }

		/// <summary>
		/// Описание агрегата
		/// </summary>
		[TableColumn("Description")]
		public string Description { get; set; }

		/// <summary>
		/// Производитель
		/// </summary>
		[TableColumn("Manufacturer")]
		public string Manufacturer { get; set; }

		/// <summary>
		/// Id родительского элемента 
		/// </summary>
		[TableColumnAttribute("ParentId")]
		public int ParentId { get; set; }

		public static PropertyInfo ParentIdProperty
		{
			get { return GetCurrentType().GetProperty("ParentId"); }
		}

		/// <summary>
		/// Тип родительского элемента 
		/// </summary>
		[TableColumnAttribute("ParentTypeId")]
		public int ParentTypeId { get; set; }

		public static PropertyInfo ParentTypeIdProperty
		{
			get { return GetCurrentType().GetProperty("ParentTypeId"); }
		}



		#region public int CompareTo(object y)
		public override int CompareTo(object y)
		{
			if (y is KitDTO) return PartNumber.CompareTo(((KitDTO)y).PartNumber);
			return 0;
		}
		#endregion

		#region public AccessoryRequired()
		/// <summary>
		/// Конструктор создает объект с параметрами по умолчанию
		/// </summary>
		public KitDTO()
		{
			ItemId = -1;
			ParentId = -1;
			Remarks = "";

			SmartCoreObjectType = SmartCoreType.AccessoryRequired;
		}
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(KitDTO));
		}
		#endregion

	}
}