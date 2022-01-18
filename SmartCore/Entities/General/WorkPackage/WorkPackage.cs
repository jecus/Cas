using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using Newtonsoft.Json;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Personnel;
using SmartCore.Files;
using SmartCore.Packages;
using SmartCore.Purchase;
using ComponentCollection = SmartCore.Entities.Collections.ComponentCollection;
using Convert = System.Convert;
using Currency =  SmartCore.Entities.Dictionaries.Сurrency;

namespace SmartCore.Entities.General.WorkPackage
{
	/// <summary>
	/// Класс описывает рабочий пакет - набор заданий 
	/// </summary>
	[Table("WorkPackages", "dbo", "ItemId")]
	[Dto(typeof(WorkPackageDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class WorkPackage : BaseEntityObject, IDirectivePackage, IFileContainer, EmployeeWorkPackageFilterParams
	{
		private static Type _thisType;
		/*
		*  Свойства взятые из базы данных
		*/

		#region public Int32 ParentId { get; set; }
		/// <summary>
		/// Id воздушного судна, для которого составлен рабочий пакет
		/// </summary>
		[TableColumn("ParentId")]
		public Int32 ParentId { get; set; }

		public static PropertyInfo ParentIdProperty
		{
			get { return GetCurrentType().GetProperty("ParentId"); }
		}

		#endregion

		#region public String Number { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Number")]
		[ListViewData(100f, "WP/WO №", 3)]
		[FilterAttribute("WP/WO №", Order = 1)]
		public String Number { get; set; }
		#endregion

		#region public String Title { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Title")]
		[FormControl("Title:")]
		[ListViewData(150f, "Title", 4)]
		[FilterAttribute("Title", Order = 2)]
		public String Title { get; set; }
		#endregion

		#region public String Description { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Description")]
		[FormControl("Description:")]
		[ListViewData(100, "Description", 5)]
		[FilterAttribute("Description", Order = 3)]
		public String Description { get; set; }
		#endregion

		#region public double ManHours { get; set; }

		/// <summary>
		/// Трудозатраты пакета работ
		/// </summary>
		[SubQueryAttribute("ManHours",
			@"(select sum(manhours) 
			from (SELECT manhours 
				  FROM directives 
				  CROSS APPLY
				  (
					select DirectivesId  from Cas3WorkPakageRecord
											  where Cas3WorkPakageRecord.IsDeleted = 0 and 
													Cas3WorkPakageRecord.WorkPackageItemType = 1 and 
													Cas3WorkPakageRecord.WorkPakageId = WorkPackages.ItemId
				  ) R
				  where directives.itemId in (R.DirectivesId)
				  UNION ALL
				  SELECT manhours 
				  FROM components 
				  CROSS APPLY
				  (
					select DirectivesId from Cas3WorkPakageRecord
											  where Cas3WorkPakageRecord.IsDeleted = 0 and 
													Cas3WorkPakageRecord.WorkPackageItemType = 5 and 
													Cas3WorkPakageRecord.WorkPakageId = WorkPackages.ItemId
				  )R
				  where components.itemId in (R.DirectivesId)
				  UNION ALL
				  SELECT manhours 
				  FROM components 
				  CROSS APPLY
				  (
					select DirectivesId 
											  from Cas3WorkPakageRecord
											  where Cas3WorkPakageRecord.IsDeleted = 0 and 
													Cas3WorkPakageRecord.WorkPackageItemType = 6 and 
													Cas3WorkPakageRecord.WorkPakageId = WorkPackages.ItemId
				  )R
				  where components.itemId in (R.DirectivesId)
				  UNION ALL
				  SELECT manhours 
				  FROM componentdirectives 
				  CROSS APPLY
				  (
					select DirectivesId 
											  from Cas3WorkPakageRecord
											  where Cas3WorkPakageRecord.IsDeleted = 0 and 
													Cas3WorkPakageRecord.WorkPackageItemType = 2 and 
													Cas3WorkPakageRecord.WorkPakageId = WorkPackages.ItemId
				  )R
				  where componentdirectives.ItemId in (R.DirectivesId)
				  UNION ALL
				  SELECT manhours 
				  FROM Cas3MaintenanceCheck 
				  CROSS APPLY
				  (
					select DirectivesId 
											  from Cas3WorkPakageRecord
											  where Cas3WorkPakageRecord.IsDeleted = 0 and 
													Cas3WorkPakageRecord.WorkPackageItemType = 3 and 
													Cas3WorkPakageRecord.WorkPakageId = WorkPackages.ItemId
				  )R
				  where Cas3MaintenanceCheck.itemId in (R.DirectivesId)
				  UNION ALL
				  SELECT manhours 
				  FROM dictionaries.NonRoutineJobs 
				  CROSS APPLY
				  (
					select DirectivesId 
											  from Cas3WorkPakageRecord
											  where Cas3WorkPakageRecord.IsDeleted = 0 and 
													Cas3WorkPakageRecord.WorkPackageItemType = 4 and 
													Cas3WorkPakageRecord.WorkPakageId = WorkPackages.ItemId
				  )R
				  where dictionaries.NonRoutineJobs.itemId in (R.DirectivesId)

				  UNION ALL
				  SELECT manhours 
				  FROM MaintenanceDirectives
				  CROSS APPLY
				  (
				  select DirectivesId 
											  from Cas3WorkPakageRecord
											  where Cas3WorkPakageRecord.IsDeleted = 0 and 
													Cas3WorkPakageRecord.WorkPackageItemType = 14 and 
													Cas3WorkPakageRecord.WorkPakageId = WorkPackages.ItemId
				  )R
				  where MaintenanceDirectives.itemId in (R.DirectivesId)) WPMH)"
			)]
		[ListViewData(85, "MH", 13)]
		public double ManHours { get; set; }
		#endregion

		#region public double Persent { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[ListViewData(0.08f, "Persent", 19)]
		public double Persent { get; set; }
		#endregion

		#region public WorkPackageStatus Status { get; set; }

		private WorkPackageStatus _status;
		/// <summary>
		/// Статус (состояние) рабочего пакета
		/// </summary>
		[TableColumn("Status")]
		[FormControl("Status:", Enabled = false)]
		[FilterAttribute("Status", Order = 20)]
		[ListViewData(0.10f, "Status", 2)]
		public WorkPackageStatus Status
		{
			get { return _status; }
			set { _status = value; }
		}

		public static PropertyInfo StatusProperty
		{
			get { return GetCurrentType().GetProperty("Status"); }
		}

		#endregion

		#region public DateTime CreateDate { get; set; }

		private DateTime _createDate;
		/// <summary>
		/// Дата открытия Рабочего Пакета 
		/// </summary>
		[TableColumn("CreateDate")]
		[FormControl("Create Date:", Enabled = false)]
		public DateTime CreateDate
		{
			get { return _createDate; }
			set
			{
				var min = DateTimeExtend.GetCASMinDateTime();
				if (_createDate < min || _createDate != value)
				{
					_createDate = value < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : value;
				}
			}
		}

		#endregion

		#region public DateTime OpeningDate { get; set; }

		private DateTime _openingDate;
		/// <summary>
		/// Дата открытия Рабочего Пакета 
		/// </summary>
		[TableColumn("OpeningDate")]
		[FormControl("Opening Date:")]
		[FilterAttribute("Open", Order = 13)]
		public DateTime OpeningDate
		{
			get { return _openingDate; }
			set
			{
				var min = DateTimeExtend.GetCASMinDateTime();
				if (_openingDate < min || _openingDate != value)
				{
					_openingDate = value < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : value;
				}
			}
		}
        #endregion

		#region public DateTime PublishingDate { get; set; }

		private DateTime _publishingDate;
		/// <summary>
		/// Дата публикации рабочего пакета 
		/// </summary>
		[TableColumn("PublishingDate")]
		[FormControl("Publishing Date:")]
		[FilterAttribute("Published", Order = 15)]
		public DateTime PublishingDate
		{
			get { return _publishingDate; }
			set
			{
				var min = DateTimeExtend.GetCASMinDateTime();
				if (_publishingDate < min || _publishingDate != value)
				{
					_publishingDate = value < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : value;
				}
			}
		}

		#endregion

		[TableColumn("PerformAfter")]
		public string PerformAfter
		{
			get => JsonConvert.SerializeObject(PerfAfter, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
			set => PerfAfter = JsonConvert.DeserializeObject<PerformAfter>(value ?? "", new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
		}

		public PerformAfter PerfAfter
		{
			get => _perfAfter ?? (_perfAfter = new PerformAfter());
			set => _perfAfter = value;
		}

		[ListViewData(0.1f, "Perform Date", 10)]
		public string PerformDate => PerfAfter.PerformDate != DateTimeExtend.GetCASMinDateTime() ?  SmartCore.Auxiliary.Convert.GetDateFormat(PerfAfter.PerformDate) : "";

		[ListViewData(0.1f, "Perform After", 9)]
		public string PerformAfterLW => PerfAfter.ToString();

		[TableColumn("WpWorkType")]
		public WpWorkType WpWorkType
		{
			get => _wpWorkType ?? WpWorkType.Unknown;
			set => _wpWorkType = value;
		}


		[TableColumn("ProviderJSON")]
		public string ProviderJSON
		{
			get => JsonConvert.SerializeObject(ProviderPrice, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
			set => ProviderPrice = JsonConvert.DeserializeObject<List<ProviderPrice>>(value ?? "", new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
		}

		private List<ProviderPrice> _providerPrice;
		public List<ProviderPrice> ProviderPrice
		{
			get => _providerPrice ?? (_providerPrice = new List<ProviderPrice>());
			set => _providerPrice = value;
		}


		#region public double KMH { get; set; }

		[TableColumn("KMH")]
		public double KMH { get; set; }

		#endregion

		#region public string KMHLW => KMH.ToString("##.##");

		[ListViewData(85, "K for MH", 14)]
		public string KMHLW => KMH.ToString("##.##");

		#endregion

		#region public string KMLW => (KMH * ManHours).ToString("##.##");

		[ListViewData(85, "K * MH", 15)]
		public string KMLW => (KMH * ManHours).ToString("##.##");

		#endregion

		#region public DateTime ClosingDate { get; set; }

		private DateTime _closingDate;
		/// <summary>
		/// Дата закрытия рабочего пакета
		/// </summary>
		[TableColumn("ClosingDate")]
		[FormControl("Closing Date:")]
		[FilterAttribute("Closed", Order = 19)]
		public DateTime ClosingDate
		{
			get { return _closingDate; }
			set
			{
				var min = DateTimeExtend.GetCASMinDateTime();
				if (_closingDate < min || _closingDate != value)
				{
					_closingDate = value < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : value;
				}
			}
		}

		/// <summary>
		/// Представление даты закрытия рабочего пакета для списка
		/// </summary>
		[ListViewData(0.1f, "Closing date", 12)]
		public DateTime? ListViewClosingDate
		{
			get
			{
				if (_status == WorkPackageStatus.Closed && _closingDate >= (DateTimeExtend.GetCASMinDateTime())) return _closingDate;
				return null;
			}
		}

		#endregion

		#region public String WorkTimeString { get; set; }
		/// <summary>
		/// Для закрытого рабочего пакета, возвращает временной интервал, затраченный на исполнение задач в виде строки
		/// </summary>
		[ListViewData(100, "Work time", 16)]
		public String WorkTimeString
		{
			get
			{
				string workTime = "";
				if (_status == WorkPackageStatus.Closed)
				{
					TimeSpan time = _closingDate - _publishingDate;
					if (time.TotalDays - time.TotalDays % 1 > 0) workTime += Convert.ToInt32(time.TotalDays - time.TotalDays % 1) + "d ";
					if (time.Hours > 0) workTime += Convert.ToInt32(time.Hours) + "h ";
					if (time.Minutes > 0) workTime += Convert.ToInt32(time.Minutes) + "m ";
				}

				return workTime;
			}
		}
		#endregion

		#region public String Author { get; set; }
		/// <summary>
		/// Автор рабочего пакета 
		/// </summary>
		[TableColumn("Author")]
		[FormControl("Author:", Enabled = false)]
		[ListViewData(0.08f, "Author")]
		[FilterAttribute("Author", Order = 12)]
		public String Author { get; set; }
		#endregion

		#region public String PublishedBy { get; set; }
		/// <summary>
		/// Имя пользователя опубликовавшего рабочий пакет
		/// </summary>
		[TableColumn("PublishedBy")]
		[FormControl("Published By:", Enabled = false)]
		[ListViewData(0.08f, "Published By")]
		[FilterAttribute("Published By", Order = 14)]
		public String PublishedBy { get; set; }
		#endregion

		#region public String ClosedBy { get; set; }
		/// <summary>
		/// Имя пользователя закрывшего рабочий пакет
		/// </summary>
		[TableColumn("ClosedBy")]
		[FormControl("Closed By:", Enabled = false)]
		[ListViewData(0.08f, "Closed By")]
		[FilterAttribute("Closed By", Order = 16)]
		public String ClosedBy { get; set; }
		#endregion

		#region public String Remarks { get; set; }
		/// <summary>
		/// Примечания рабочего пакета 
		/// </summary>
		[TableColumn("Remarks")]
		[FormControl("Remarks:")]
		[ListViewData(0.12f, "Remark", 11)]
		public String Remarks { get; set; }
		#endregion

		#region public String PublishingRemarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("PublishingRemarks")]
		[FormControl("Publishing Remarks:")]
		public String PublishingRemarks { get; set; }
		#endregion

		#region public String ClosingRemarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("ClosingRemarks")]
		[FormControl("Closing Remarks:")]
		public String ClosingRemarks { get; set; }
		#endregion

		#region public Boolean OnceClosed { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("OnceClosed")]
		public Boolean OnceClosed { get; set; }
		#endregion

		#region public String ReleaseCertificateNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("ReleaseCertificateNo")]
		[FormControl("Release Certificate No:")]
		public String ReleaseCertificateNo { get; set; }
		#endregion

		#region public String Revision { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Revision")]
		[FormControl("Revision:")]
		public String Revision { get; set; }
		#endregion

		#region public String CheckType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("CheckType")]
		[FormControl("Check Type:")]
		public String CheckType { get; set; }
		#endregion

		#region public String Station { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Station")]
		[FormControl("Station:")]
		[ListViewData(0.08f, "Station", 17)]
		[FilterAttribute("Station", Order = 4)]
		public String Station { get; set; }
		#endregion

		#region public string EmployeesRemark { get; set; }

		[TableColumn("EmployeesRemark")]
		public string EmployeesRemark { get; set; }

		#endregion

		#region public String MaintenanceRepairOrzanization { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("MaintenanceReportNo")]
		[ListViewData(0.05f, "MRO", 18)]
		[FormControl("MRO:")]
		[FilterAttribute("MRO", Order = 10)]
		public String MaintenanceRepairOrzanization { get; set; }
		#endregion

		#region public AttachedFile AttachedFile { get; set; }

		private AttachedFile _attachedFile;

		/// <summary>
		/// 
		/// </summary>
		[FormControl("WP File:")]
		public AttachedFile AttachedFile
		{
			get
			{
				return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.WorkPackageAttachedFile));
			}
			set
			{
				_attachedFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.WorkPackageAttachedFile);
			}
		}

		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 2499)]
		public CommonCollection<ItemFileLink> Files
		{
			get { return _files ?? (_files = new CommonCollection<ItemFileLink>()); }
			set
			{
				if (_files != value)
				{
					if (_files != null)
						_files.Clear();
					if (value != null)
						_files = value;
				}
			}
		}

		#endregion
		/*
		 * Дополнительные свойства
		 */

		#region public Aircraft Aircraft { get; set; }

		/// <summary>
		/// Обратная ссылка на воздушное судно, для которого составлен рабочий пакет. 
		/// Может быть null если рабочий пакет составлен не для воздушного судна
		/// </summary>
		[FilterAttribute("Aircraft", Order = 41)]
		public Aircraft Aircraft { get; set; }

		#endregion

		#region public Lifelength AircraftCurrentLifelenght { get; set; }

		/// <summary>
		/// Обратная ссылка на воздушное судно, для которого составлен рабочий пакет. 
		/// Может быть null если рабочий пакет составлен не для воздушного судна
		/// </summary>
		public Lifelength AircraftCurrentLifelenght { get; set; }

		#endregion

		#region public Lifelength AircraftString { get; set; }

		/// <summary>
		/// Обратная ссылка на воздушное судно, для которого составлен рабочий пакет. 
		/// Может быть null если рабочий пакет составлен не для воздушного судна
		/// </summary>
		[ListViewData(85, "Aircraft", 1)]
		public string AircraftString
		{
			get
			{
				string res = "";

				if (Aircraft != null)
					res = Aircraft + " ";
				//if (AircraftCurrentLifelenght != null)
				//	res += AircraftCurrentLifelenght.ToString();
				return res;
			}
		}

		#endregion

		#region ICommonCollection IDirectivePackage.PakageRecords { get; }
		/// <summary>
		/// Взвращает массив элементов для привязки директив к рабочему пакету
		/// </summary>
		ICommonCollection IDirectivePackage.PackageRecords { get { return _workPackageRecords; } }

		#endregion

		#region public CommonCollection<WorkPackageRecord> WorkPakageRecords { get; }

		private CommonCollection<WorkPackageRecord> _workPackageRecords;
		/// <summary>
		/// Взвращает массив элементов для привязки директив к рабочему пакету
		/// </summary>
		[Child(RelationType.OneToMany, "WorkPakageId", "WorkPackage", false)]
		public CommonCollection<WorkPackageRecord> WorkPakageRecords
		{
			get { return _workPackageRecords ?? (_workPackageRecords = new CommonCollection<WorkPackageRecord>()); }
		}

		#endregion

		#region public CommonCollection<MaintenanceCheckBindTaskRecord> MaintenanceCheckBindTaskRecords { get; }

		private CommonCollection<MaintenanceCheckBindTaskRecord> _maintenanceCheckBindTaskRecords;
		private List<Document> _closingDocument;
		private WpWorkType _wpWorkType;
		private PerformAfter _perfAfter;

		/// <summary>
		/// Возвращает массив записей о привязке задач к чекам находящимся в данном рабочем пакете
		/// </summary>
		public CommonCollection<MaintenanceCheckBindTaskRecord> MaintenanceCheckBindTaskRecords
		{
			get { return _maintenanceCheckBindTaskRecords ?? (_maintenanceCheckBindTaskRecords = new CommonCollection<MaintenanceCheckBindTaskRecord>()); }
		}

		#endregion

		#region Boolean Boolean WorkPackageItemsLoaded { get; set; }

		/// <summary>
		/// Были ли загружены элементы рабочего пакета - по умолчанию - false
		/// </summary>
		public Boolean WorkPackageItemsLoaded { get; set; }

		#endregion

		#region public DateTime MinClosingDate { get; set; }

		/// <summary>
		/// Минимальная дата закрытия рабочего пакета
		/// </summary>
		public DateTime? MinClosingDate { get; set; }

		#endregion

		#region public DateTime MaxClosingDate { get; set; }

		/// <summary>
		/// Максимальная дата закрытия рабочего пакета
		/// </summary>
		public DateTime? MaxClosingDate { get; set; }

		#endregion

		#region public bool CanPublish { get; set; }
		/// <summary>
		/// Можно ли опубликовать пакет
		/// </summary>
		public bool CanPublish { get; set; }
		#endregion

		#region public string BlockPublishReason { get; set; }
		/// <summary>
		/// ПРичина невозможности публикации рабочего пакета
		/// </summary>
		public string BlockPublishReason { get; set; }
		#endregion

		#region bool bool CanClose { get; set; }
		/// <summary>
		/// Можно ли закрыть пакет
		/// </summary>
		public bool CanClose { get; set; }
		#endregion

		/*
		 * Элементы рабочего пакета, Work Package содержит все виды работ из Forecast + Job Cards + Non Routine Jobs + Maintenance Cheks + Maintenance Workscope Items
		 */

		#region public BaseComponentCollection BaseComponents { get; internal set; }
		/// <summary>
		/// Базовые агрегаты, для которых задан Lifelimit
		/// </summary>
		public BaseComponentCollection BaseComponents
		{
			get
			{
				BaseComponentCollection res = new BaseComponentCollection();
				foreach (WorkPackageRecord record in _workPackageRecords)
				{
					if (record.Task != null &&
						record.Task.SmartCoreObjectType == SmartCoreType.BaseComponent)
					{
						res.Add((BaseComponent)record.Task);
					}
				}
				return res;
			}
		}
		#endregion

		#region public ComponentCollection Components { get; internal set; }
		/// <summary>
		/// Компоненты, которые необходимо заменить (Remove/Replace)
		/// </summary>
		public ComponentCollection Components
		{
			get
			{
				ComponentCollection res = new ComponentCollection();
				foreach (WorkPackageRecord record in _workPackageRecords)
				{
					if (record.Task != null &&
						record.Task.SmartCoreObjectType == SmartCoreType.Component)
					{
						res.Add((Accessory.Component)record.Task);
					}
				}
				return res;
			}
		}
		#endregion

		#region public IEnumerable<ComponentDirective> ComponentDirectives { get; }
		/// <summary>
		/// Работы по компонентам, которые необходимо выполнить. Важно - для Component Directive родителем могут быть как BaseComponent так и Component
		/// </summary>
		public IEnumerable<ComponentDirective> ComponentDirectives
		{
			get
			{
				List<ComponentDirective> res = new List<ComponentDirective>();
				foreach (WorkPackageRecord record in _workPackageRecords)
				{
					if (record.Task != null &&
					   record.Task.SmartCoreObjectType == SmartCoreType.ComponentDirective)
						res.Add((ComponentDirective)record.Task);
				}
				return res;
			}
		}
		#endregion

		#region public ICommonCollection<Directive> AdStatus { get; }
		/// <summary>
		/// Директивы Ad статуса, которые должны быть выполнены
		/// </summary>
		public ICommonCollection<Directive> AdStatus
		{
			get
			{
				CommonCollection<Directive> res = new CommonCollection<Directive>();
				foreach (WorkPackageRecord record in _workPackageRecords)
				{
					if (record.Task != null &&
						record.Task.SmartCoreObjectType == SmartCoreType.Directive &&
						((Directive)record.Task).DirectiveType == DirectiveType.AirworthenessDirectives)
					{
						res.Add((Directive)record.Task);
					}
				}
				return res;
			}
		}
		#endregion

		#region public IEnumerable<Directive> SbStatus { get; }
		/// <summary>
		/// Элементы отчета Cpcp, которые требуют выполнения 
		/// </summary>
		public IEnumerable<Directive> SbStatus
		{
			get
			{
				CommonCollection<Directive> res = new CommonCollection<Directive>();
				foreach (WorkPackageRecord record in _workPackageRecords)
				{
					if (record.Task != null &&
						record.Task.SmartCoreObjectType == SmartCoreType.Directive &&
						((Directive)record.Task).DirectiveType == DirectiveType.SB)
					{
						res.Add((Directive)record.Task);
					}
				}
				return res;
			}
		}
		#endregion

		#region public IEnumerable<Directive> EoStatus { get; }
		/// <summary>
		/// Элементы отчета Cpcp, которые требуют выполнения 
		/// </summary>
		public IEnumerable<Directive> EoStatus
		{
			get
			{
				CommonCollection<Directive> res = new CommonCollection<Directive>();
				foreach (WorkPackageRecord record in _workPackageRecords)
				{
					if (record.Task != null &&
						record.Task.SmartCoreObjectType == SmartCoreType.Directive &&
						((Directive)record.Task).DirectiveType == DirectiveType.EngineeringOrders)
					{
						res.Add((Directive)record.Task);
					}
				}
				return res;
			}
		}
		#endregion

		#region public IEnumerable<Directive> Damages { get; }
		/// <summary>
		/// Элементы отчета Cpcp, которые требуют выполнения 
		/// </summary>
		public IEnumerable<Directive> Damages
		{
			get
			{
				IEnumerable<Directive> res =
				   _workPackageRecords.Where(record => record.Task != null &&
													   record.Task.SmartCoreObjectType == SmartCoreType.Directive &&
													   ((Directive)record.Task).DirectiveType == DirectiveType.DamagesRequiring)
									  .Select(record => record.Task as Directive);
				return res;
			}
		}
		#endregion

		#region public IEnumerable<Directive> DefferedItems { get; }
		/// <summary>
		/// Элементы отчета DefferedItems, которые требуют выполнения 
		/// </summary>
		public IEnumerable<Directive> DefferedItems
		{
			get
			{
				IEnumerable<Directive> res =
				   _workPackageRecords.Where(record => record.Task != null &&
													   record.Task.SmartCoreObjectType == SmartCoreType.Directive &&
													   ((Directive)record.Task).DirectiveType == DirectiveType.DeferredItems)
									  .Select(record => record.Task as Directive);
				return res;
			}
		}
		#endregion

		#region public IEnumerable<Directive> OutOfPhaseItems { get; }
		/// <summary>
		/// Элементы отчета OutOfPhaseItems, которые требуют выполнения 
		/// </summary>
		public IEnumerable<Directive> OutOfPhaseItems
		{
			get
			{
				IEnumerable<Directive> res =
					_workPackageRecords.Where(record => record.Task != null &&
														record.Task.SmartCoreObjectType == SmartCoreType.Directive &&
														((Directive)record.Task).DirectiveType == DirectiveType.OutOfPhase)
									   .Select(record => record.Task as Directive);
				return res;
			}
		}
		#endregion

		#region public IEnumerable<NonRoutineJob> NonRoutines
		/// <summary>
		/// Список не рутинных операций
		/// </summary>
		public IEnumerable<NonRoutineJob> NonRoutines
		{
			get
			{
				IEnumerable<NonRoutineJob> res =
					_workPackageRecords.Where(record => record.Task != null &&
														record.Task.SmartCoreObjectType == SmartCoreType.NonRoutineJob)
									   .Select(record => record.Task as NonRoutineJob);
				return res;
			}
		}
		#endregion

		#region public IEnumerable<MaintenanceCheck> MaintenanceChecks { get; }
		/// <summary>
		/// Элементы пакета MaintenanceChecks, которые требуют выполнения 
		/// </summary>
		public IEnumerable<MaintenanceCheck> MaintenanceChecks
		{
			get
			{
				IEnumerable<MaintenanceCheck> res =
					_workPackageRecords.Where(record => record.Task != null &&
														record.Task.SmartCoreObjectType == SmartCoreType.MaintenanceCheck)
									   .Select(record => record.Task as MaintenanceCheck);
				return res;
			}
		}
		#endregion

		#region  public IEnumerable<MaintenanceDirective> MaintenanceDirectives { get; }
		/// <summary>
		/// Директивы программы обслуживания
		/// </summary>
		public IEnumerable<MaintenanceDirective> MaintenanceDirectives
		{
			get
			{
				IEnumerable<MaintenanceDirective> res =
					_workPackageRecords.Where(record => record.Task != null &&
														record.Task.SmartCoreObjectType == SmartCoreType.MaintenanceDirective)
									   .Select(record => record.Task as MaintenanceDirective);
				return res;
			}
		}
		#endregion

		#region public IEnumerable<AbstractAccessory> Kits {get;}

		public IEnumerable<AbstractAccessory> Kits
		{
			get
			{
				var kits = new List<AbstractAccessory>();

				foreach (var wpr in WorkPakageRecords)
				{
					if (wpr.Task != null && wpr.Task is IKitRequired)
						kits.AddRange((wpr.Task as IKitRequired).Kits.ToArray());
				}

				return kits;
			}
		}

		#endregion

		#region #EmployeeWorkPackageFilterParams

		public Specialist Specialist { get; set; }

		public List<AircraftModel> LicenseAircrafts
		{
			get { return Specialist.LicenseAircrafts; }
		}

		public List<LicenseFunction> LicenseFunctions
		{
			get { return Specialist.LicenseFunctions; }
		}

		public List<LicenseRights> LicenseRights
		{
			get { return Specialist.LicenseRights; }
		}

		#endregion

		#region public Document ClosingDocument { get; set; }

		public List<Document> ClosingDocument
		{
			get => _closingDocument ?? (_closingDocument = new List<Document>());
			set => _closingDocument = value;
		}

		#endregion

		/*
		*  Методы 
		*/

		public string ComboBoxMember
		{
			get { return $"{Aircraft} WP : {Number} | Title: {Title}"; }
		}


		#region public WorkPackage()
		/// <summary>
		/// Создает воздушное судно без дополнительной информации
		/// </summary>
		public WorkPackage()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.WorkPackage;
			CanClose = true;
			CanPublish = true;
			WorkPackageItemsLoaded = false;
			Title = "";
			// создаем все коллекции
		}
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(WorkPackage));
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// Перегружаем для отладки
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Title;
		}
		#endregion

		#region public override BaseEntityObject GetCopyUnsaved()

		public override BaseEntityObject GetCopyUnsaved(bool marked = true)
		{
			var wp = (WorkPackage)MemberwiseClone();
			wp.ItemId = -1;
			if (marked)
				wp.Number += " Copy";
			wp.UnSetEvents();

			return wp;
		}

		#endregion

	}

	[JsonObject]
	[Serializable]
	public class PerformAfter
	{
		#region Fields

		private DateTime _performDate;

		#endregion

		#region Constructor

		public PerformAfter()
		{
			AirportFromId = -1;
			AirportToId = -1;
			FlightNumId = -1;

		}

			#endregion

		[DefaultValue(-1)]
		public int AirportFromId { get; set; }

		[DefaultValue(-1)]
		public int AirportToId { get; set; }

		[DefaultValue(-1)]
		public int FlightNumId { get; set; }

		public DateTime PerformDate
		{
			get => _performDate < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : _performDate; 
			set => _performDate = value;
		}

		[JsonIgnore]
		public FlightNum FlightNum { get; set; }

		[JsonIgnore]
		public AirportsCodes AirportFrom { get; set; }

		[JsonIgnore]
		public AirportsCodes AirportTo { get; set; }

		#region Overrides of Object

		public override string ToString()
		{
			var res = "";

			if (FlightNum != null)
				res += FlightNum.ToString();
			if(AirportFrom != null)
				res += $" {AirportFrom.ShortName}";
			if(AirportTo != null)
				res += $"-{AirportTo.ShortName}";
			return res;
		}

		#endregion
	}

	[JsonObject]
	[Serializable]
	public class ProviderPrice : BaseEntityObject
	{
		[JsonIgnore] public Supplier Supplier { get; set; }

		[JsonIgnore] public WorkPackage Parent { get; set; }

		[JsonIgnore]
		[ListViewData(200, "Supplier", 1)]
		public string SupplierName
		{
			get => Supplier?.Name ?? Supplier.Unknown.Name;
		}

		[JsonProperty] public int SupplierId { get; set; }

		[ListViewData(80, "Offering", 2)]
		[JsonProperty]
		public decimal Offering { get; set; }

		[ListViewData(80, "Routine", 4)]
		[JsonProperty]
		public decimal Routine { get; set; }

		[ListViewData(80, "K for MH", 5)]
		[JsonProperty]
		public decimal RoutineKMH { get; set; }

		[ListViewData(80, "NDT", 6)]
		[JsonProperty]
		public decimal NDT { get; set; }

		[ListViewData(80, "K for MH", 7)]
		[JsonProperty]
		public decimal NDTKMH { get; set; }

		[ListViewData(80, "AD", 8)]
		[JsonProperty]
		public decimal AD { get; set; }

		[ListViewData(80, "K for MH", 9)]
		[JsonProperty]
		public decimal ADKMH { get; set; }

		[ListViewData(80, "NRC", 10)]
		[JsonProperty]
		public decimal NRC { get; set; }

		[ListViewData(80, "K for MH", 11)]
		[JsonProperty]
		public decimal NRCKMH { get; set; }

		[DefaultValue(-1)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public int CurrencyOfferingId { get; set; }

		[JsonIgnore]
		[ListViewData(80, "Currency", 12)]
		public Currency CurrencyOffering
		{
			get => Currency.GetItemById(CurrencyOfferingId);
			set => CurrencyOfferingId = value.ItemId;
		}
	}

}
