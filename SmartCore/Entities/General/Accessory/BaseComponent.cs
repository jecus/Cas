using System;
using System.Linq;
using EntityCore.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Templates;

namespace SmartCore.Entities.General.Accessory
{

    /// <summary>
    /// Класс описывает воздушное судно
    /// </summary>
    [Table("Components","dbo","ItemId")]
	[Dto(typeof(ComponentDTO))]
    [Condition("IsBaseComponent", "1")]
    [Condition("IsDeleted", "0")]
    public class BaseComponent: Component, IComparable<BaseComponent>, IComponentContainer, IWorkPackageItemFilterParams
	{

		/*
        *  Свойства из базы данных
        */

		#region public Int32 BaseComponentTypeId { get; set; }
		/// <summary>
		/// Идентификатор типа агрегата
		/// </summary>
		[TableColumn("BaseComponentTypeId")]
        public int BaseComponentTypeId { get; set; }
		#endregion

        #region private Int32 ComponentCount { get; set; }
        /// <summary>
        /// Количество компонентов, которые должно быть на данной базовой детали
        /// </summary>
        [TableColumn("ComponentCount")]
        public Int32 ComponentCount { get; set; }
        #endregion

        /*
         * Дополнительные (вычисляемые) свойства
         */

        #region private Int32 CurrentComponentCount { get; set; }
        /// <summary>
        /// Количество компонентов, которые имеется на данной базовой детали
        /// </summary>
        public Int32 CurrentComponentCount { get; set; }
		#endregion

		#region public Int32 LastDestinationObjectId{ get;internal set;}

		//[SubQueryAttribute("LastDestinationObjectId", @"(select top 1 TransferRecords.DestinationObjectId 
  //                             from dbo.TransferRecords 
  //                             where IsDeleted=0 and ParentID = dbo.Components.ItemId order by dbo.TransferRecords.TransferDate desc)")]
		public int LastDestinationObjectId
		{
			get { return TransferRecords.OrderBy(i => i.TransferDate).FirstOrDefault(i => i.ParentId == ItemId)?.DestinationObjectId ?? -1; }
		}

		#endregion


		#region public SmartCoreType LastDestinationObjectType { get; internal set; }

		//[SubQuery("LastDestinationObjectType", @"(select top 1 TransferRecords.DestinationObjectType 
  //                             from dbo.TransferRecords 
  //                             where IsDeleted=0 and ParentID = dbo.Components.ItemId order by dbo.TransferRecords.TransferDate desc)")]
		public SmartCoreType LastDestinationObjectType
		{
			get
			{
				return TransferRecords.OrderBy(i => i.TransferDate).FirstOrDefault(i => i.ParentId == ItemId)?.DestinationObjectType ?? SmartCoreType.Unknown;
			}
		}

		#endregion

		#region public BaseComponentType BaseComponentType { get; set; }
		/// <summary>
		/// Тип базового агрегата
		/// </summary>
		public BaseComponentType BaseComponentType
        {
            get { return BaseComponentType.GetComponentTypeById(BaseComponentTypeId); }
            set { BaseComponentTypeId = value.ItemId; }
        }
        #endregion

        #region public String PositionNumber { get; }

        public String PositionNumber
        {
            get
            {
                String text = TransferRecords.Count != 0 ? TransferRecords.GetLast().Position : "";
                return text;
            }
        }

        #endregion
        
        #region internal Object LastTransferObject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        internal Object LastTransferObject { get; set; }

        #endregion

        #region public AverageUtilization AverageUtilization { get; set; }
        [TableColumn("AverageUtilization")]
        public AverageUtilization AverageUtilization { get; set; }
        #endregion

        #region public bool LLPCategories { get; }

        private bool _llpCategories;
        /// <summary>
        /// Флаг, показывающий рачсеты дочерних деталей по LLP категориям. Только для Engine
        /// </summary>
        [TableColumn("LLPCategories")]
        public new bool LLPCategories
        {
            set { _llpCategories = value; }
            get { return BaseComponentTypeId == BaseComponentType.Engine.ItemId && _llpCategories;}
        }

        #endregion

        #region public int AccelerationGround { get; set; }
        /// <summary>
        /// Время перехода из номинального режима во взлетый в секундах на земле. Только для Engine
        /// </summary>
        [TableColumn("Acceleration")]
        public int AccelerationGround { get; set; }
        #endregion

        #region public int AccelerationAir { get; set; }
        /// <summary>
        /// Время перехода из номинального режима во взлетый в секундах в воздухе. Только для Engine
        /// </summary>
        [TableColumn("AccelerationAir")]
        public int AccelerationAir { get; set; }
        #endregion

        #region public DateTime ManufactureDate { get; set; }
        /// <summary>
        /// Дата выпуска
        /// </summary>
        [TableColumn("ManufactureDate")]
        public new DateTime ManufactureDate
        {
            get { return manufactureDate; }
            set
            {
                manufactureDate = value;
                if (LifelengthCalculated != null)
                    LifelengthCalculated.StartDate = manufactureDate;
                else LifelengthCalculated = new LifelengthCollection(manufactureDate);
            }
        }
        #endregion

        #region public String Thrust { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Thrust", 128)]
        public String Thrust { get; set; }
		#endregion

		#region Implement of IWorkPackageItemFilterParams

		#region public SmartCoreType SmartCoreType { get; }

		public SmartCoreType SmartCoreType => SmartCoreObjectType;

		#endregion

		#region public Lifelength RepeatInterval { get; }

		public Lifelength RepeatInterval { get { return  Lifelength.Null; } }

		#endregion

		#region public bool HasKits { get; }

		public bool HasKits { get { return Kits.Count > 0; } }

		#endregion

		#region public bool HasNDT { get; }

		public bool HasNDT { get { return NDTType != NDTType.UNK; } }

		#endregion

		#endregion

		#region public string Aircraft { get; set; }
		//Свойство сделанно специально для отладки используется в фильтре(Tracking(Form)). Изменить подход!
		public string Aircraft { get; set; }

		#endregion
		/*
         * Математический аппарат
         */

		#region public CommonCollection<ComponentWorkInRegimeParams> ComponentWorkParams { get; set; }

		private CommonCollection<ComponentWorkInRegimeParams> _componentWorkParams;

		/// <summary>
        /// Список директив базового агрегата
        /// </summary>
        [Child(RelationType.OneToMany, "ComponentId", "Engine")]
        public CommonCollection<ComponentWorkInRegimeParams> ComponentWorkParams
        {
            get { return _componentWorkParams ?? (_componentWorkParams = new CommonCollection<ComponentWorkInRegimeParams>()); }
            set
            {
                if (_componentWorkParams != value)
                {
                    if (_componentWorkParams != null)
                        _componentWorkParams.Clear();
                    if (value != null)
                        _componentWorkParams = value;

                    OnPropertyChanged("ComponentWorkParams");
                }
            }
        }
        #endregion

        #region internal LifelengthCollection LifelengthCalculated { get; set; }
        /// <summary>
        /// Подсчитанные наработки базовой детали
        /// </summary>
        internal LifelengthCollection LifelengthCalculated { get; set; }
		#endregion

		/*
		*  Методы 
		*/

		#region public BaseComponent()
		/// <summary>
		/// Создает воздушное судно без дополнительной информации
		/// </summary>
		public BaseComponent()
        {
            ItemId = -1;
            IsBaseComponent = true;
            AverageUtilization = new AverageUtilization();
            manufactureDate = DateTimeExtend.GetCASMinDateTime();
            SmartCoreObjectType = SmartCoreType.BaseComponent;
            // Мат аппарат
            // OpeningLifelengthCalculated = new LifelengthCollection();
            //LifelengthCalculated = new LifelengthCollection();
            ComponentWorkParams = new CommonCollection<ComponentWorkInRegimeParams>();
        }
		#endregion

		#region public static BaseComponent CreateFromTemplate(TemplateBaseComponent templateBaseComponent)
		public static BaseComponent CreateFromTemplate(TemplateBaseComponent templateBaseComponent)
        {
            var bd = new BaseComponent();
            bd.IsBaseComponent = true;
            bd.ATAChapter = templateBaseComponent.ATAChapter;
            bd.PartNumber = templateBaseComponent.PartNumber;
            bd.Description = templateBaseComponent.Description;
            bd.SerialNumber = templateBaseComponent.SerialNumber;
            bd.MaintenanceControlProcess = templateBaseComponent.MaintenanceControlProcess;
            bd.Remarks = templateBaseComponent.Remarks;
            bd.Model = templateBaseComponent.Model;
            bd.Manufacturer = templateBaseComponent.Manufacturer;
            bd.LLPMark = templateBaseComponent.LLPMark;
            bd.LLPCategories = templateBaseComponent.LLPCategories;
            bd.LandingGear = templateBaseComponent.LandingGear;
            bd.AvionicsInventory = templateBaseComponent.AvionicsInventory;
            bd.ALTPartNumber = templateBaseComponent.ALTPartNumber;
            bd.MTOGW = templateBaseComponent.MTOGW;
            bd.HushKit = templateBaseComponent.HushKit;
            bd.Cost = templateBaseComponent.Cost;
            bd.CostOverhaul = templateBaseComponent.CostOverhaul;
            bd.CostServiceable = templateBaseComponent.CostServiceable;
            bd.Quantity = templateBaseComponent.Quantity;
            bd.ManHours = templateBaseComponent.ManHours;
            bd.FaaFormFile = templateBaseComponent.FaaFormFile;
            bd.Warranty = templateBaseComponent.Warranty;
            bd.WarrantyNotify = templateBaseComponent.WarrantyNotify;
            bd.Serviceable = templateBaseComponent.Serviceable;
            bd.GoodsClass = templateBaseComponent.GoodsClass;
            bd.ShelfLife = templateBaseComponent.ShelfLife;
            bd.MPDItem = templateBaseComponent.MPDItem;
            bd.Suppliers = templateBaseComponent.Supplier;
            bd.LifeLimit = templateBaseComponent.LifeLimit;
            bd.LifeLimitNotify = templateBaseComponent.LifeLimitNotify;
            bd.Highlight = Highlight.White;

            #region Часть базовой детали

            bd.BaseComponentType = templateBaseComponent.BaseComponentType;

            #endregion

            return bd;
        }
        #endregion

        #region public override string ToString()

        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
			var position = TransferRecords != null && TransferRecords.GetLast() != null
                                  ? TransferRecords.GetLast().Position
                                  : "";
            var res = Aircraft;
			res += BaseComponentType.ShortName != "" ? " " + BaseComponentType.ShortName : "";
            res += position != "" ? " " + position : "";
            res += " S/N " + SerialNumber;


            return res;
        }
		#endregion

		#region public int CompareTo(BaseComponent y)

		public int CompareTo(BaseComponent y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

        #endregion

        #region public override bool Equals(object y)

        public bool Equals(BaseComponent y)
        {
            if (y == null || 
                ItemId != y.ItemId ||
                ATAChapter != y.ATAChapter ||
                PartNumber != y.PartNumber ||
                Description != y.Description ||
                SerialNumber != y.SerialNumber ||
                MaintenanceControlProcess != y.MaintenanceControlProcess ||
                Remarks != y.Remarks ||
                Model != y.Model ||
                Manufacturer != y.Manufacturer ||
                LLPMark != y.LLPMark ||
                LLPCategories != y.LLPCategories ||
                LandingGear != y.LandingGear ||
                AvionicsInventory != y.AvionicsInventory ||
                ALTPartNumber != y.ALTPartNumber ||
                MTOGW != y.MTOGW ||
                HushKit != y.HushKit ||
                Cost != y.Cost ||
                CostOverhaul != y.CostOverhaul ||
                CostServiceable != y.CostServiceable ||
                Quantity != y.Quantity ||
                ManHours != y.ManHours ||
                !Warranty.IsEqual(y.Warranty) ||
                !WarrantyNotify.IsEqual(y.WarrantyNotify) ||
                Serviceable != y.Serviceable ||
                GoodsClass != y.GoodsClass ||
                ShelfLife != y.ShelfLife ||
                MPDItem != y.MPDItem ||
                //Suppliers != y.Suppliers ||
                !LifeLimit.IsEqual(y.LifeLimit) ||
                !LifeLimitNotify.IsEqual(y.LifeLimitNotify) ||
                BaseComponentType != y.BaseComponentType)
                return false;
            return true;
        }
        #endregion

        #region public override bool Equals(object y)

        public override bool Equals(object y)
        {
            return Equals(y as BaseComponent);
        }
        #endregion

        #region public override int GetHashCode()
        ///<summary>
        ///Serves as a hash function for a particular type. <see cref="M:System.Object.GetHashCode"></see> is suitable for use in hashing algorithms and data structures like a hash table.
        ///</summary>
        ///
        ///<returns>
        ///A hash code for the current <see cref="T:System.Object"></see>.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        #endregion

    }

}


