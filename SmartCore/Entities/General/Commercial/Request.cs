using System;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Packages;

namespace SmartCore.Entities.General.Commercial
{

    /// <summary>
    /// Класс описывает рабочую карту
    /// </summary>
    [Table("Requests", "dbo", "ItemId")]
    [Dto(typeof(RequestDTO))]
	[Condition("IsDeleted", "0")]
    public class Request : AbstractDirectivePackage<RequestRecord>, IKitRequired//, IDirectivePackage
    {
        private static Type _thisType;
        /*
        *  Свойства
        */

        #region public String Form { get; set; }
        /// <summary>
        /// Форма рабочей карты
        /// </summary>
        //[TableColumn("Form")]
        public String Form { get; set; }
        #endregion

        #region public String FormRevision { get; set; }
        /// <summary>
        /// Ревизия формы рабочей карты
        /// </summary>
        //[TableColumn("FormRevision")]
        public String FormRevision { get; set; }
        #endregion

        #region public DateTime FormDate { get; set; }
        /// <summary>
        /// Дата формы рабочей карты
        /// </summary>
        //[TableColumn("FormDate")]
        public DateTime FormDate { get; set; }
        #endregion

        #region public DateTime PreparedByDate { get; set; }
        /// <summary>
        /// Дата подготовки рабочей карты
        /// </summary>
        [TableColumn("PreparedByDate")]
        public DateTime PreparedByDate { get; set; }
        #endregion

        #region public Specialist PreparedBy { get; set; }
        /// <summary>
        /// Сотрудник, подготовивший рабочую карту
        /// </summary>
        [TableColumn("PreparedById")]
        //[Child]
        public Specialist PreparedBy { get; set; }
        #endregion

        #region public DateTime CheckedByDate { get; set; }
        /// <summary>
        /// Дата проверки рабочей карты
        /// </summary>
        [TableColumn("CheckedByDate")]
        public DateTime CheckedByDate { get; set; }
        #endregion

        #region public Specialist CheckedBy { get; set; }
        /// <summary>
        /// Сотрудник, Проверивший рабочую карту
        /// </summary>
        [TableColumn("CheckedById")]
        //[Child]
        public Specialist CheckedBy { get; set; }
        #endregion

        #region public DateTime ApprovedByDate { get; set; }
        /// <summary>
        /// Дата допуска рабочей карты
        /// </summary>
        [TableColumn("ApprovedByDate")]
        public DateTime ApprovedByDate { get; set; }
        #endregion

        #region public Specialist ApprovedBy { get; set; }
        /// <summary>
        /// Сотрудник, допустивший рабочую карту
        /// </summary>
        [TableColumn("ApprovedById")]
        //[Child]
        public Specialist ApprovedBy { get; set; }
        #endregion

        #region public String RequestHeader { get; set; }
        /// <summary>
        /// Заголовок рабочей карты
        /// </summary>
        [TableColumn("RequestdHeader")]
        public String RequestHeader { get; set; }
        #endregion

        //#region public String AircraftRegistrationNumber { get; set; }
        ///// <summary>
        ///// Регистрационный номер ВС, для которого создана карта
        ///// </summary>
        //public String AircraftRegistrationNumber { get; set; }
        //#endregion

        //#region public AircraftModel AircraftModel { get; set; }
        ///// <summary>
        ///// Модель ВС для которого создана рабочая карта
        ///// </summary>
        //public AircraftModel AircraftModel { get; set; }
        //#endregion

        #region public DateTime RequestDate { get; set; }
        /// <summary>
        /// Дата выдачи рабочей карты
        /// </summary>
        //[TableColumn("JobCardDate")]
        public DateTime RequestDate { get; set; }
        #endregion

        #region public String RequestRevision { get; set; }
        /// <summary>
        /// Ревизия рабочей карты
        /// </summary>
        //[TableColumn("JobCardRevision")]
        public String RequestRevision { get; set; }
        #endregion

        #region public DateTime RequestRevisionDate { get; set; }
        /// <summary>
        /// Дата ревизии рабочей карты
        /// </summary>
        //[TableColumn("JobCardRevisionDate")]
        public DateTime RequestRevisionDate { get; set; }
        #endregion

        #region Implement of IKitRequired

        #region public string KitParentString { get; }
        /// <summary>
        /// Возвращает строку для описания родителя КИТа
        /// </summary>
        public string KitParentString
        {
            get { return $"Dir.:{Title}:{Description}"; }
        }
        #endregion

        #region public CommonCollection<AccessoryRequired> Kits

        private CommonCollection<AccessoryRequired> _kits;

        [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1450, "ParentObject")]
        public CommonCollection<AccessoryRequired> Kits
        {
            get { return _kits ?? (_kits = new CommonCollection<AccessoryRequired>()); }
            internal set
            {
                if (_kits != value)
                {
                    if (_kits != null)
                        _kits.Clear();
                    if (value != null)
                        _kits = value;
                }
            }
        }
        #endregion

        #endregion

        #region public override CommonCollection<RequestRecord> PakageRecords { get; }

        private CommonCollection<RequestRecord> _packageRecords;
        /// <summary>
        /// Взвращает массив элементов для привязки директив к рабочему пакету
        /// </summary>
        [Child(RelationType.OneToMany, "ParentId", "ParentPackage", false)]
        public override CommonCollection<RequestRecord> PackageRecords
        {
            get { return _packageRecords ?? (_packageRecords = new CommonCollection<RequestRecord>()); }
            internal set
            {
                if (_packageRecords != value)
                {
                    if (_packageRecords != null)
                        _packageRecords.Clear();
                    if (value != null)
                        _packageRecords = value;
                }
            }
        }

        #endregion

        #region public String RequestFooter { get; set; }
        /// <summary>
        /// Нижний заголовок рабочей карты
        /// </summary>
        [TableColumn("RequestFooter")]
        public String RequestFooter { get; set; }
        #endregion

        /*
		*  Методы 
		*/

        #region public Request()
        /// <summary>
        /// Создает воздушное судно без дополнительной информации
        /// </summary>
        public Request()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.JobCard;

            ApprovedByDate = DateTime.Today;
            CheckedByDate = DateTime.Today;
            FormDate = DateTime.Today;
            RequestDate = DateTime.Today;
            RequestRevisionDate = DateTime.Today;
            PreparedByDate = DateTime.Today;

            Status = WorkPackageStatus.Opened;

            CreateDate = OpeningDate = PublishingDate = ClosingDate = DateTime.Today;

        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(Request));
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

    }

}
