using System;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Files;
using SmartCore.Packages;
using SmartCore.Purchase;


namespace SmartCore.Entities.General
{

	/// <summary>
	/// ����� ��������� ������ � �����������
	/// </summary>
	[Serializable]
	[Table("TransferRecords", "dbo", "ItemId")]
	[Dto(typeof(TransferRecordDTO))]
	[Condition("IsDeleted", "0")]
	public class TransferRecord : AbstractPerformanceRecord, IComparable<TransferRecord>, IFileContainer, ITransferRecordFilterParams
	{

		private static Type _thisType;
		/*
		*  ��������
		*/

		#region public Int32 FromAircraftId { get; set; }
		/// <summary>
		/// ID �������� � �������� ��� ��������� ������� (ID ������ ����� ����� ����)
		/// </summary>
		[TableColumnAttribute("FromAircraftID")]
		public Int32 FromAircraftId { get; set; }


		public static PropertyInfo FromAircraftIdProperty
		{
			get { return GetCurrentType().GetProperty("FromAircraftId"); }
		}
		#endregion

		#region public Int32 FromBaseComponentId { get; set; }
		/// <summary>
		/// ID �������� �������� � �������� ��� ��������� ���������
		/// </summary>
		[TableColumnAttribute("FromBaseComponentID")]
		public int FromBaseComponentId { get; set; }

		public static PropertyInfo FromBaseComponentIdProperty
		{
			get { return GetCurrentType().GetProperty("FromBaseComponentId"); }
		}
		#endregion

		#region public Int32 FromStoreId { get; set; }
		/// <summary>
		/// ID ������ � �������� ��� ���� ��������� (ID �������� ����� ����� ����)
		/// </summary>
		[TableColumnAttribute("FromStoreID")]
		public Int32 FromStoreId { get; set; }

		public static PropertyInfo FromStoreIdProperty
		{
			get { return GetCurrentType().GetProperty("FromStoreId"); }
		}
		#endregion

		#region public int FromSupplierId { get; set; }

		[TableColumn("FromSupplierId")]
		public int FromSupplierId { get; set; }

		public static PropertyInfo FromSupplierIdProperty
		{
			get { return GetCurrentType().GetProperty("FromSupplierId"); }
		}

		#endregion

		#region public int FromSpecialistId { get; set; }

		[TableColumn("FromSpecialistId")]
		public int FromSpecialistId { get; set; }

		public static PropertyInfo FromSpecialistIdProperty
		{
			get { return GetCurrentType().GetProperty("FromSpecialistId"); }
		}

		#endregion

		#region public Int32 DestinationObjectId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("DestinationObjectID")]
		public Int32 DestinationObjectId { get; set; }

		public static PropertyInfo DestinationObjectIDProperty
		{
			get { return GetCurrentType().GetProperty("DestinationObjectId"); }
		}

		#endregion

		#region public SmartCoreType DestinationObjectType{ get; set; }
		/// <summary>
		/// ��� ������� ����������
		/// </summary>
		[TableColumnAttribute("DestinationObjectType")]
		public SmartCoreType DestinationObjectType{ get; set; }

		public static PropertyInfo DestinationObjectTypeProperty
		{
			get { return GetCurrentType().GetProperty("DestinationObjectType"); }
		}

		#endregion

		#region public DateTime TransferDate { get; set; }

		private DateTime _transferDate;
		/// <summary>
		/// ����, ����� ������ ���������� ���������� ����������� 
		/// </summary>
		[TableColumnAttribute("DestConfirmTransferDate")]
		public DateTime TransferDate
		{
			get { return _transferDate; }
			set { _transferDate = value; }
		}
		#endregion

		#region public DateTime StartTransferDate { get; set; }

		/// <summary>
		/// ���� ������ �����������
		/// </summary>
		[TableColumnAttribute("TransferDate")]
		public DateTime StartTransferDate { get; set; }
		#endregion

		[TableColumnAttribute("SupplierReceiptDate")]
		public DateTime SupplierReceiptDate
		{
			get =>  _supplierReceiptDate > DateTimeExtend.GetCASMinDateTime()? _supplierReceiptDate : DateTimeExtend.GetCASMinDateTime();
			set
			{
				var min = DateTimeExtend.GetCASMinDateTime();
				if (_supplierReceiptDate < min || _supplierReceiptDate != value)
					_supplierReceiptDate = value < DateTimeExtend.GetCASMinDateTime()
						? DateTimeExtend.GetCASMinDateTime() : value;
			}
		}

		[TableColumnAttribute("SupplierNotify")]
		public Lifelength SupplierNotify { get; set; }

		#region public double BeforeReplace { get; set; }
		/// <summary>
		/// ������� ����������� ���� �� ������ �����������
		/// <br/>����������� ��� ����������� �����������
		/// </summary>
		//[TableColumnAttribute("BeforeReplace")]
		public double BeforeReplace { get; set; }
		#endregion

		#region public double Replaced { get; set; }
		/// <summary>
		/// ������� ����������� ���� ����������
		/// <br/>����������� ��� ����������� �����������
		/// </summary>
		//[TableColumnAttribute("Replaced")]
		public double Replaced { get; set; }
		#endregion

		#region public Int32 ConsumableId { get; set; }
		/// <summary>
		/// ������������� ����������, ����� �������� ���� ����������
		/// <br/> ��� ������������� ������, ����� �� ������ ���-�� ������� ���������� �������� ������ ������ � �����������
		/// <br/> �� �� ������ ���� ����� ParentID
		/// </summary>
		[TableColumnAttribute("ConsumableId")]
		public Int32 ConsumableId { get; set; }
		#endregion

		#region public String Reference { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Reference")]
		public String Reference { get; set; }
		#endregion

		#region public Boolean DODR { get; set; }
		/// <summary>
		/// ���� ������������� ����������� �� ������� ����������
		/// </summary>
		[TableColumnAttribute("DODR")]
		public bool DODR { get; set; }
		#endregion

		#region public Boolean PODR { get; set; }
		/// <summary>
		/// ���� ������������� ����������� �� ������� �����������
		/// </summary>
		[TableColumnAttribute("PODR")]
		public bool PODR { get; set; }

		public static PropertyInfo PODRProperty
		{
			get { return GetCurrentType().GetProperty("PODR"); }
		}
		#endregion

		#region public bool PreConfirmTransfer { get; set; }

		[TableColumn("PreConfirmTransfer")]
		public bool PreConfirmTransfer { get; set; }

		public static PropertyInfo PreConfirmTransferProperty
		{
			get { return GetCurrentType().GetProperty("PreConfirmTransfer"); }
		}

		#endregion

		#region public String Position { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Position")]
		public String Position { get; set; }
		#endregion

		#region public String Position { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("State")]
		public ComponentStorePosition State { get; set; }
		#endregion

		#region public int ReplaceComponentId { get; set; }

		[TableColumn("ReplaceComponentId")]
		public int ReplaceComponentId { get; set; }

		public static PropertyInfo ReplaceComponentIdProperty
		{
			get { return GetCurrentType().GetProperty("ReplaceComponentId"); }
		}

		#endregion

		#region public bool IsReplaceComponentRemoved { get; set; }
		//�������� ��� MoveComponentForm ���������� ReplaceComponent ��������� ��� �����������
		[TableColumn("IsReplaceComponentRemoved")]
		public bool IsReplaceComponentRemoved { get; set; }

		#endregion

		#region Implement of AbstractPerformanceRecord

		#region public override Int32 ParentId { get; set; }

		private Int32 _parentId;
		/// <summary>
		/// ������������� ������, ��� ������� ���� ��������� ������
		/// </summary>
		[TableColumnAttribute("ParentID")]
		public override Int32 ParentId
		{
			get { return _parentId; } 
			set { _parentId = value; }
		}

		public static PropertyInfo ParentIdProperty
		{
			get { return GetCurrentType().GetProperty("ParentId"); }
		}

		#endregion

		#region public override Int32 PerformanceNum { get; set; }

		private Int32 _performanceNum;
		/// <summary>
		/// ����� ������ � ����������
		/// </summary>
		[TableColumnAttribute("PerformanceNum")]
		public override Int32 PerformanceNum
		{
			get { return _performanceNum; } 
			set { _performanceNum = value; }
		}
		#endregion

		#region public override SmartCoreType ParentType

		private SmartCoreType _parentType;
		/// <summary>
		/// ��� ������������� �������
		/// </summary>
		[TableColumnAttribute("ParentType")]
		public override SmartCoreType ParentType
		{
			get { return _parentType ?? SmartCoreType.Unknown; }
			internal set { _parentType = value; }
		}

		public static PropertyInfo ParentTypeProperty
		{
			get { return GetCurrentType().GetProperty("ParentType"); }
		}
		#endregion

		#region public override IDirective Parent { get; set; }

		private Accessory.Component _parent;
		/// <summary>
		/// �������� ������ ������ � ����������
		/// </summary>
		public override IDirective Parent
		{
			get { return _parent; }
			set
			{
				_parent = value as Accessory.Component;
				_parentType = (_parent != null ? _parent.SmartCoreObjectType : SmartCoreType.Unknown);
			}
		}
		#endregion

		#region public override DateTime RecordDate
		/// <summary>
		/// ������������ �� AbstractRecord. ���������� TransferDate
		/// </summary>
		public override DateTime RecordDate
		{
			get { return _transferDate; }
			set { _transferDate = value; }
		}
		#endregion

		#region public override Lifelength OnLifelength{get; set; }
		/// <summary>
		/// ������������ �� AbstractRecord �� ������������
		/// </summary>
		public override Lifelength OnLifelength { get { return Lifelength.Null; } set { } }
		#endregion

		#region public override AttachedFile AttachedFile { get; set; }
		[NonSerialized]
		private AttachedFile _attachedFile;
		/// <summary>
		/// 
		/// </summary>
		public override AttachedFile AttachedFile
		{
			get
			{
				return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.TransferRecordAttachedFile));
			}
			set
			{
				_attachedFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.TransferRecordAttachedFile);
			}
		}
		#endregion

		#region public override Int32 WorkPackageId { get; set; }

		private Int32 _workPackageId;
		/// <summary>
		/// ������������, ������ ���� ������ ������� workpackage - �
		/// </summary>
		[TableColumnAttribute("WorkPackageId")]
		public override Int32 DirectivePackageId
		{
			get { return _workPackageId; } 
			set { _workPackageId = value; }
		}
		#endregion

		#region public override IDirectivePackage DirectivePackage { get; set; }

		private IDirectivePackage _directivePackage;
		/// <summary>
		/// ������������, ������ ���� ������ ������� workpackage - �
		/// </summary>
		public override IDirectivePackage DirectivePackage
		{
			get { return _directivePackage; }
			set { _directivePackage = value; }
		}
		#endregion

		#region public override string Remarks { get; set; }

		private string _remarks;
		/// <summary>
		/// ��������
		/// </summary>
		[TableColumnAttribute("Remarks")]
		public override string Remarks
		{
			get { return _remarks; } 
			set { _remarks = value; }
		}
		#endregion

		#region public override Lifelength Unused { get; set; }
		/// <summary>
		/// ����������������� ������ 
		/// ������, �� ������� ���� ��������� ��������� - ������, �� ������� ��� ���� ���������
		/// ������������ ������ ������������� ��������, ������� 0
		/// </summary>
		//[Savable]
		public override Lifelength Unused { get; set; }
		#endregion

		#region public override Lifelength Overused { get; set; }
		/// <summary>
		/// ����������������� ������ 
		/// ������, �� ������� ��� ���� ��������� - ������, �� ������� ���� ��������� ��������� 
		/// ������������ ������ ������������� ��������, ������� 0
		/// </summary>
		//[Savable]
		public override Lifelength Overused { get; set; }
		#endregion

		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 2260)]
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

		#region public Highlight Highlight { get; set; }
		/// <summary>
		/// ���������
		/// </summary>
		public Highlight Highlight { get; set; }

		#endregion

		#region public InitionalReason Reason { get; set; }

		private InitialReason _reason;

		/// <summary>
		/// 
		/// </summary>
		[TableColumn("ReasonId")]
		public InitialReason Reason
		{
			get { return _reason ?? (_reason = InitialReason.Unknown); }
			set { _reason = value; }
		}

		#endregion

		#region public Specialist ReceivedSpecialist { get; set; }

		[Child]
		[TableColumn("ReceivedSpecialistId")]
		public Specialist ReceivedSpecialist { get; set; }

		#endregion

		#region public Specialist ReleasedSpecialist { get; set; }

		[Child]
		[TableColumn("ReleasedSpecialistId")]
		public Specialist ReleasedSpecialist { get; set; }

		#endregion

		#region public Supplier FromSupplier { get; set; }

		public Supplier FromSupplier { get; set; }

			#endregion

		#region public string Description { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Description")]
		public string Description { get; set; }

		#endregion

		#region Implement ITransferRecordFilterParams

		public string PartNumber { get { return ParentComponent.PartNumber; } }
		public string SerialNumber { get { return ParentComponent.SerialNumber; } }
		public string ComponentDescription { get { return ParentComponent.Description; } }
		public GoodsClass GoodsClass { get { return ParentComponent.GoodsClass; } }

		private BaseEntityObject _from;
		public BaseEntityObject From
		{
			get
			{
				//����������� �� ������ �� ��
				if (FromAircraftId > 0 && FromStoreId > 0 && FromBaseComponentId == 0)
				{
					_from = FromStore;
				}
				//����������� � �� �� �����
				else if (FromAircraftId > 0 && FromStoreId == 0 &&
						 FromBaseComponentId > 0 && DestinationObjectType.ItemId == SmartCoreType.Store.ItemId)
				{
					_from = FromBaseComponent;
				}
				//����������� � �� �� ��
				else if (FromAircraftId > 0 && FromStoreId == 0 &&
						 FromBaseComponentId > 0 && DestinationObjectType.ItemId == SmartCoreType.BaseComponent.ItemId)
				{
					_from = FromBaseComponent;
				}
				else if (FromSupplierId > 0)
				{
					_from = FromSupplier;
				}
				else if (FromSpecialistId > 0)
				{
					_from = FromSpecialist;
				}

				return _from;
			}
		}


		#endregion

		/*
		 * �������������� ��������
		 */

		#region public Accessory.Component ReplaceComponent { get; set; }

		public Accessory.Component ReplaceComponent { get; set; }

		#endregion
	
		#region public Component ParentComponent { get; set; }
		/// <summary>
		/// ������� ��� �������� ������ ������ � �����������
		/// </summary>
		public Accessory.Component ParentComponent
		{
			get { return _parent; }
			set
			{
				_parent = value;
				_parentType = _parent != null ? _parent.SmartCoreObjectType : SmartCoreType.Component;
			}
		}
		#endregion

		#region public Aircraft FromAircraft { get; set; }

		/// <summary>
		/// �� � �������� ������� ������ � �����������, ����������� �� FromAircraftID
		/// </summary>
		[NonSerialized]
		private Aircraft _fromAircraft;

		public Aircraft FromAircraft
		{
			get { return _fromAircraft;}
			set { _fromAircraft = value; }
		}

		#endregion

		#region public BaseComponent FromBaseComponent { get; set; }

		[NonSerialized]
		private BaseComponent _fromBaseComponent;
		/// <summary>
		/// ������� ��������� � �������� ������� ������ � �����������, ����������� �� FromBaseComponentID
		/// </summary>
		public BaseComponent FromBaseComponent
		{
			get { return _fromBaseComponent; }
			set { _fromBaseComponent = value; }
		}
		#endregion

		#region public Store.Store FromStore { get; set; }

		[NonSerialized]
		private Store.Store _store;
		/// <summary>
		/// ����� � �������� ������� ������ � �����������, ����������� �� FromStoreID
		/// </summary>
		public Store.Store FromStore
		{
			get { return _store; }
			set { _store = value; }
		}
		#endregion

		public Specialist FromSpecialist { get; set; }

		#region public BaseSmartCoreObject DestinationObject { get; set; }
		[NonSerialized]
		private BaseEntityObject _destinationObject;

		private DateTime _supplierReceiptDate;

		/// <summary>
		/// ����������� ������ (���� ������������ �����������) ����������� �� DestinationObjectID � DestinationObjectTypeID
		/// </summary>
		public BaseEntityObject DestinationObject
		{
			get { return _destinationObject; }
			set { _destinationObject = value; }
		}


		#endregion

		public string ComboBoxMember
		{
			get { return $"On: S/N:{ParentComponent?.SerialNumber} P/N:{ParentComponent?.PartNumber} | Off: S/N:{ReplaceComponent?.SerialNumber} P/N:{ReplaceComponent?.PartNumber}"; }
		}

		/*
		*  ������ 
		*/

		#region public TransferRecord()
		/// <summary>
		/// ������� ��������� ����� ��� �������������� ����������
		/// </summary>
		public TransferRecord()
		{
			ItemId = -1;
			SmartCoreObjectType= SmartCoreType.TransferRecord;
			_workPackageId = - 1;
			SupplierReceiptDate = DateTimeExtend.GetCASMinDateTime();
		}
		#endregion

		#region public TransferRecord(TransferRecord copyRecord) : this()
		/// <summary>
		/// ������� ������������� ���� ������ � �����������
		/// </summary>
		public TransferRecord(TransferRecord copyRecord) : this()
		{
			_attachedFile = copyRecord.AttachedFile;
			BeforeReplace = copyRecord.BeforeReplace;
			ConsumableId = copyRecord.ConsumableId;
			DestinationObject = copyRecord.DestinationObject;
			DestinationObjectId = copyRecord.DestinationObjectId;
			DestinationObjectType = copyRecord.DestinationObjectType;
			DODR = copyRecord.DODR;
			FromAircraft = copyRecord.FromAircraft;
			FromAircraftId = copyRecord.FromAircraftId;
			FromBaseComponent = copyRecord.FromBaseComponent;
			FromBaseComponentId = copyRecord.FromBaseComponentId;
			FromStore = copyRecord.FromStore;
			FromStoreId = copyRecord.FromStoreId;
			ParentComponent = copyRecord.ParentComponent;
			_parentId = copyRecord.ParentId;
			_parentType = copyRecord.ParentType;
			_performanceNum = copyRecord.PerformanceNum;
			PODR = copyRecord.PODR;
			Position = copyRecord.Position;
			Reference = copyRecord.Reference;
			_remarks = copyRecord.Remarks;
			Replaced = copyRecord.Replaced;
			StartTransferDate = copyRecord.StartTransferDate;
			TransferDate = copyRecord.TransferDate;
			_directivePackage = copyRecord.DirectivePackage;
			_workPackageId = copyRecord.DirectivePackageId;

		/*
		 * �������������� ��������
		 */      
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// ����������� ��� �������
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return TransferDate.ToShortDateString() + " " + DestinationObjectId; 
		}
		#endregion   

		#region public int CompareTo(TransferRecord y)

		public int CompareTo(TransferRecord y)
		{
			return TransferDate.CompareTo(y.TransferDate);
		}

		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(TransferRecord));
		}
		#endregion

		#region public void SetProperties(TransferRecord condition)
		/// <summary>
		/// �������� �������� ������� �� ����������� ������� � �������
		/// </summary>
		/// <param name="condition"></param>
		public void SetProperties(TransferRecord condition)
		{
			ParentComponent = condition.ParentComponent;
			ParentId = condition.ParentId;
			FromAircraftId = condition.FromAircraftId;
			FromBaseComponentId = condition.FromBaseComponentId;
			FromStoreId = condition.FromStoreId;
			TransferDate = condition.TransferDate;
			StartTransferDate = condition.StartTransferDate;
			Position = condition.Position ?? "";
			Remarks = condition.Remarks;
			DestinationObjectId = condition.DestinationObjectId;
			DestinationObjectType = condition.DestinationObjectType;
		}
		#endregion

		public new TransferRecord GetCopyUnsaved(bool marked = true)
		{
			TransferRecord transferRecord = (TransferRecord) MemberwiseClone();
			transferRecord.ItemId = -1;
			transferRecord.UnSetEvents();

			transferRecord.Unused=new Lifelength(Unused);
			transferRecord.Overused=new Lifelength(Overused);

			return transferRecord;
		}
	}

}
