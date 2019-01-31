using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Packages
{
    /// <summary>
    /// Интерфейс, Описывающий объект содержащий в себе элементы
    /// </summary>
    public interface IPackage : IBaseEntityObject
    {
        /// <summary>
        /// 
        /// </summary>
        String Title { get; set; }
        
        //#region String Number { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //String Number { get; set; }
        //#endregion

        /// <summary>
        /// Статус (состояние) рабочего пакета
        /// </summary>
        WorkPackageStatus Status { get; set; }

        //#region DateTime CreateDate { get; set; }
        ///// <summary>
        ///// Дата открытия Рабочего Пакета 
        ///// </summary>
        //DateTime CreateDate { get; set; }

        //#endregion

        /// <summary>
        /// Дата открытия Рабочего Пакета 
        /// </summary>
        DateTime OpeningDate { get; set; }
        /// <summary>
        /// Дата публикации рабочего пакета 
        /// </summary>
        DateTime PublishingDate { get; set; }
        /// <summary>
        /// Дата закрытия рабочего пакета
        /// </summary>
        DateTime ClosingDate { get; set; }

        //#region String PublishedBy { get; set; }
        ///// <summary>
        ///// Имя пользователя опубликовавшего рабочий пакет
        ///// </summary>
        //String PublishedBy { get; set; }
        //#endregion

        //#region String ClosedBy { get; set; }
        ///// <summary>
        ///// Имя пользователя закрывшего рабочий пакет
        ///// </summary>
        //String ClosedBy { get; set; }
        //#endregion

        /// <summary>
        /// Примечания рабочего пакета 
        /// </summary>
        String Remarks { get; set; }

        //#region String PublishingRemarks { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //String PublishingRemarks { get; set; }
        //#endregion

        //#region String ClosingRemarks { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //String ClosingRemarks { get; set; }
        //#endregion

        /// <summary>
        /// Взвращает массив элементов для привязки директив к рабочему пакету
        /// </summary>
        ICommonCollection PackageRecords { get; }
        /// <summary>
        /// Были ли загружены элементы рабочего пакета - по умолчанию - false
        /// </summary>
        Boolean PackageItemsLoaded { get; set; }
        /// <summary>
        /// Возвращает или задает тип родительского объекта
        /// </summary>
        SmartCoreType ParentType { get; set; }
        /// <summary>
        /// Идентификатор родительского объекта
        /// </summary>
        Int32 ParentId { get; set; }

        BaseEntityObject Parent { get; set; }
    }
}
