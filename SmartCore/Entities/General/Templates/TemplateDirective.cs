using System;
using System.Collections.Generic;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Templates
{

	/// <summary>
	/// Класс описывает директиву
	/// </summary>
	[Table("Directives", "Template", "ItemId")]
	[Condition("IsPrimeDirective", "0")]
	[Serializable]
	public class TemplateDirective: BaseEntityObject, IComparable<TemplateDirective>
	{

		/*
		*  Свойства
		*/
		#region public Int32 TemplateId { get; set; }
		/// <summary>
		/// Код шаблона, которому принадлежит элемент
		/// </summary>
		[TableColumnAttribute("TemplateId")]
		public Int32 TemplateId { get; set; }
		#endregion

		#region public Int32 PrimeDirectiveId { get; set; }
		/// <summary>
		/// Идентификатор основной директивы, которой пренадлежит данная задача
		/// </summary>
		[TableColumnAttribute("PrimeDirectiveId")]
		public Int32 PrimeDirectiveId { get; set; }
		#endregion

		#region public DirectiveType DirectiveType { get; set; }
		/// <summary>
		/// Тип директивы
		/// </summary>
		[TableColumnAttribute("DirectiveTypeId"), ListViewData("Directive Type")]
		public DirectiveWorkType DirectiveWorkType { get; set; }
		#endregion

		#region public String Title { get; set; }
		/// <summary>
		/// Название директивы
		/// </summary>
		[TableColumnAttribute("Title"), ListViewData("Title")]
		public String Title { get; set; }
		#endregion

		#region public Double ManHours { get; set; }
		/// <summary>
		/// Параметр трудозатрат
		/// </summary>
		[TableColumnAttribute("ManHours"), ListViewData("Man Hours"), MinMaxValue(0,100000)]
		public Double ManHours { get; set; }
		#endregion

		#region public String Remarks { get; set; }
		/// <summary>
		/// Заметки по директиве
		/// </summary>
		[TableColumnAttribute("Remarks"), ListViewData("Remarks")]
		public String Remarks { get; set; }
		#endregion

		#region public String Applicability { get; set; }
		/// <summary>
		/// Применимость директивы
		/// </summary>
		[TableColumnAttribute("Applicability"), ListViewData("Applicability")]
		public String Applicability { get; set; }
		#endregion

		#region public Int32 ComponentId { get; set; }
		/// <summary>
		/// Id агрегата за которым директива закреплена
		/// </summary>
		[TableColumnAttribute("ComponentId")]
		public int ComponentId { get; set; }
		#endregion

		#region public AtaChapter ATAChapter { get; set; }
		/// <summary>
		/// ATA глава, к которой директива относится
		/// </summary>
		[TableColumnAttribute("ATAChapterId"), ListViewData("ATA Chapter")]
		public AtaChapter ATAChapter { get; set; }
		#endregion

		#region public Int32 DirectiveType { get; set; }
		/// <summary>
		/// Тип директивы
		/// </summary>
		[TableColumnAttribute("PrimaryDirectiveTypeId")]
		public DirectiveType DirectiveType { get; set; }
		#endregion

		#region public ADType ADType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("AdType"), ListViewData("AD Type")]
		public ADType ADType { get; set; }
		#endregion

		#region public String ServiceBulletinNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("ServiceBulletinNo"), ListViewData("Service Bulletin №")]
		public String ServiceBulletinNo { get; set; }
		#endregion

		//TODO: переделать на использование нового fileCore
		#region  public AttachedFile ServiceBulletinFile { get; set; }
		/// <summary>
		/// Связь с файлом описания сервисного бюллетеня
		/// </summary>
		[TableColumnAttribute("ServiceBulletinFileId"), ListViewData("Service Bulletin File")]
		public AttachedFile ServiceBulletinFile { get; set; }
		#endregion

		#region  public AttachedFile ADNoFile { get; set; }
		/// <summary>
		/// Связь с файлом описания директивы летной годности
		/// </summary>
		[TableColumnAttribute("ADNoFileId"), ListViewData("AD № File")]
		public AttachedFile ADNoFile { get; set; }
		#endregion

		#region public String Description { get; set; }
		/// <summary>
		/// Описание директивы
		/// </summary>
		[TableColumnAttribute("Description"), ListViewData("Description")]
		public String Description { get; set; }
		#endregion

		#region public String EngineeringOrders { get; set; }
		/// <summary>
		/// Параметр Engineering orders
		/// </summary>
		[TableColumnAttribute("EngineeringOrders"), ListViewData("Engineering Orders")]
		public String EngineeringOrders { get; set; }
		#endregion

		#region public String JobCardNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("JobCardNo"), ListViewData("Job Card No")]
		public String JobCardNo { get; set; }
		#endregion

		#region  public AttachedFile EngineeringOrderFile { get; set; }
		/// <summary>
		/// Связь с файлом описания инженерного ордера
		/// </summary>
		[TableColumnAttribute("EngineeringOrderFileId"), ListViewData("Eng. Order File")]
		public AttachedFile EngineeringOrderFile { get; set; }
		#endregion

		#region public Double Cost { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Cost"), ListViewData("Cost"), MinMaxValue(0,1000000000)]
		public Double Cost { get; set; }
		#endregion

		#region public Highlight Highlight { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Highlight")]
		public Highlight Highlight { get; set; }
		#endregion

		#region public String KitRequired { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("KitRequired"), ListViewData("Kit Req.")]
		public String KitRequired { get; set; }
		#endregion

		#region public String HiddenRemarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("HiddenRemarks"), ListViewData("HiddenRemarks")]
		public String HiddenRemarks { get; set; }
		#endregion

		#region public String InspectionDocumentsNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("InspectionDocumentsNo")]
		public String InspectionDocumentsNo { get; set; }
		#endregion

		#region  public AttachedFile InspectionDocumentsFile { get; set; }
		/// <summary>
		/// Связь с файлом описания сервисного бюллетеня
		/// </summary>
		[TableColumnAttribute("InspectionDocumentsFileId")]
		public AttachedFile InspectionDocumentsFile { get; set; }
		#endregion

		#region public Int32 IsPrimeDirective { get; set; }
		/// <summary>
		/// Является ли данная директива основной или подзадачей
		/// </summary>
		[TableColumnAttribute("IsPrimeDirective") ]
		public bool IsPrimeDirective { get; set; }
		#endregion

		/*
		 * Дополнительные свойства
		 */

		#region public String Paragraph { get; set; }
		/// <summary>
		/// Параметр трудозатрат
		/// </summary>
		[TableColumnAttribute("Paragraph"), ListViewData("§")]
		public String Paragraph { get; set; }
		#endregion

		#region public NDTType NDTType { get; set; }
		/// <summary>
		/// Тип производимого Non-Destructive-Test
		/// </summary>
		[TableColumnAttribute("NDTType"), ListViewData("NDT")]
		public NDTType NDTType { get; set; }
		#endregion

		#region public DirectiveThreshold Threshold { get; set; }
		/// <summary>
		/// Условие выполнения директивы
		/// </summary>
		[TableColumnAttribute("Threshold"), ListViewData("Threshold")]
		public DirectiveThreshold Threshold { get; set; }
		#endregion

		#region Implement of IKitRequired
		public List<AccessoryRequired> Kits { get; set; }
		#endregion

		/*
		*  Методы 
		*/


		#region public TemplateDirective()
		/// <summary>
		/// Создает воздушное судно без дополнительной информации
		/// </summary>
		public TemplateDirective()
		{
			//задаем все ID в -1
			ItemId = -1;
		   
			// Ad директива
			DirectiveWorkType = DirectiveWorkType.Inspection; 

			// Задаем все String
			Title = Remarks = Applicability = Description = EngineeringOrders = JobCardNo =
					KitRequired = HiddenRemarks = "";
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// Перегружаем для отладки
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Title + " " + Description;
		}
		#endregion   

		#region public int CompareTo(PrimaryDirective y)

		public int CompareTo(TemplateDirective y)
		{
			return ItemId.CompareTo(y.ItemId);
		}

		#endregion

		#region public override int CompareTo(object y)
		public override int CompareTo(object y)
		{
			if(y is TemplateDirective) return ItemId.CompareTo(((TemplateDirective) y).ItemId);
			return 0;
		}
		#endregion

	}
}
