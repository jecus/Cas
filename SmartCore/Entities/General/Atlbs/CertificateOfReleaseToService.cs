using System;
using EFCore.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.Entities.General.Atlbs
{

    /// <summary>
    /// Допуск на дальнейшую эксплуатацию воздушного судна
    /// </summary>
    [Table("CRSs", "dbo", "ItemId")]
    [Dto(typeof(CertificateOfReleaseToServiceDTO))]
	public class CertificateOfReleaseToService : AbstractRecord // : LoggableType
    {

        #region public string Station
        /// <summary>
        /// Аэропорт, база ТО, где проходило устранение дефекат
        /// </summary>
        private string _station;
        /// <summary>
        /// Аэропорт, база ТО, где проходило устранение дефекта
        /// </summary>
        [TableColumnAttribute("Station")]
        public string Station
        {
            get { return _station ?? ""; }
            set
            {
           //     ModificationApplied(_Station, value);
                _station = value;
            }
        }
        #endregion

        #region public string MRO
        /// <summary>
        /// Организация, производившая устранения дефекта
        /// </summary>
        private string _mro;
        /// <summary>
        /// Организация, производившая устранения дефекта
        /// </summary>
        //[TableColumnAttribute("Station")]
        public string MRO
        {
            get { return _mro; }
            set
            {
                //     ModificationApplied(_Station, value);
                _mro = value;
            }
        }
        #endregion

        #region public Specialist AuthorizationB1
        /// <summary>
        /// Выдающий допуск специалист
        /// </summary>
        private Specialist _authorizationB1;
        /// <summary>
        /// Выдающий допуск специалист
        /// </summary>
        [TableColumnAttribute("AuthorizationB1Id"), Child(false)]
        public Specialist AuthorizationB1
        {
            get { return _authorizationB1 != null ? _authorizationB1 : Specialist.Unknown; }
            set
            {
             //   ModificationApplied(_AuthorizationNo, value);
                _authorizationB1 = value;
            }
        }
        #endregion

        #region public Specialist AuthorizationB2
        /// <summary>
        /// Выдающий допуск специалист
        /// </summary>
        private Specialist _authorizationB2;
        /// <summary>
        /// Выдающий допуск специалист
        /// </summary>
        [TableColumnAttribute("AuthorizationB2Id"), Child(false)]
        public Specialist AuthorizationB2
        {
			get { return _authorizationB2 != null ? _authorizationB2 : Specialist.Unknown; }
			set
            {
                //   ModificationApplied(_AuthorizationNo, value);
                _authorizationB2 = value;
            }
        }
        #endregion

        #region public string CheckPerformed
        /// <summary>
        /// Чеки, которые были выполнены перед полетом
        /// </summary>
        private string _checkPerformed;
        /// <summary>
        /// Чеки, которые были выполнены перед полетом
        /// </summary>
        [TableColumnAttribute("CheckPerformed")]
        public string CheckPerformed
        {
            get { return _checkPerformed; }
            set
            {
            //    ModificationApplied(_CheckPerformed, value);
                _checkPerformed = value;
            }
        }
        #endregion

        #region public string Reference

        private string _reference;
        /// <summary>
        /// Ссылка на документ, на основании которого  была выполнена работаи выдан соответствующий сертификат
        /// </summary>
        [TableColumnAttribute("Reference")]
        public string Reference
        {
            get { return _reference; }
            set
            {
            //    ModificationApplied(reference, value);
                _reference = value;
            }
        }

        #endregion

        #region public override DateTime RecordDate { get; set; }

        private DateTime _recordDate;
        /// <summary>
        /// Дата добавления записи
        /// </summary>
        [TableColumnAttribute("RecordDate")]
        public override DateTime RecordDate
        {
            get { return _recordDate; }
            set { _recordDate = value; }
        }
        #endregion

        #region public override Lifelength OnLifelength { get; set; }
        /// <summary>
        /// Унаследовано от AbstractRecord в БД не сохраняется
        /// </summary>
        public override Lifelength OnLifelength { get; set; }
        #endregion

        #region override public string Remarks { get; set; }
        /// <summary>
        /// Унаследовано от AbstractRecord в БД не сохраняется
        /// </summary>
        public override string Remarks { get; set; }
        #endregion
        /*
         * Перегруженные свойства и методы
         */
        public CertificateOfReleaseToService()
        {
            _recordDate = DateTime.Today;
        }
    }

}
