using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Packages
{
    /// <summary>
    /// Интерфейс, Описывающий объект содержащий в себе элементы-задачи
    /// </summary>
    public interface IDirectivePackage : IBaseEntityObject
    {
        /// <summary>
        /// 
        /// </summary>
        String Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        String Number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        String Station { get; set; }
        /// <summary>
        /// Статус (состояние) рабочего пакета
        /// </summary>
        WorkPackageStatus Status { get; set; }
        /// <summary>
        /// Дата открытия Рабочего Пакета 
        /// </summary>
        DateTime CreateDate { get; set; }
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
        /// <summary>
        /// Имя пользователя опубликовавшего рабочий пакет
        /// </summary>
        String PublishedBy { get; set; }
        /// <summary>
        /// Имя пользователя закрывшего рабочий пакет
        /// </summary>
        String ClosedBy { get; set; }
        /// <summary>
        /// Примечания рабочего пакета 
        /// </summary>
        String Remarks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        String PublishingRemarks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        String ClosingRemarks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        AttachedFile AttachedFile { get; set; }
        /// <summary>
        /// Взвращает массив элементов для привязки директив к рабочему пакету
        /// </summary>
        ICommonCollection PackageRecords { get; }
    }
}
