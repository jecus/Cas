using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Entities.General.Interfaces
{
    /// <summary>
    /// Интерфеис описывает объект- задачу по инженерии ВС
    /// <br/> У любого объекта-задачи должны быть
    /// <br/> 1. ATA - глава
    /// <br/> 2. Название (Титул)
    /// <br/> 3. Описание
    /// <br/> 4. Зона - Доступ
    /// <br/> 5. Тип работы
    /// <br/> 6. Параметры трудозатрат
    /// <br/> 7. Цена выполнения работы
    /// </summary>
    public interface IEngineeringDirective : IDirective
    {
        #region Properties

        #region AtaChapter ATAChapter { get; }
        /// <summary>
        ///  ATA глава
        /// </summary>
        AtaChapter ATAChapter { get; }
        #endregion

        #region String Title { get; }
        /// <summary>
        /// Название директивы
        /// </summary>
        String Title { get; }
        #endregion

        #region String Description { get; }
        /// <summary>
        /// описание задачи
        /// </summary>
        String Description { get; }
        #endregion

        #region String Zone { get; }
        /// <summary>
        /// Зона
        /// </summary>
        String Zone { get; }
        #endregion

        #region String Access { get; }
        /// <summary>
        /// Доступ
        /// </summary>
        String Access { get; }
        #endregion

        #region MaintenanceDirectiveProgramType Program { get; }
        /// <summary>
        /// Программа обслуживания
        /// </summary>
        MaintenanceDirectiveProgramType Program { get; }
        #endregion

        #region StaticDictionary WorkType { get; }
        /// <summary>
        /// Тип/Вид Работ
        /// </summary>
        StaticDictionary WorkType { get; }
        #endregion

        #region String Phase { get; }
        /// <summary>
        /// Фаза
        /// </summary>
        String Phase { get; }
        #endregion



        #region Double ManHours { get; set; }
        /// <summary>
        /// Параметр трудозатрат
        /// </summary>
        Double ManHours { get; set; }
        #endregion

        #region Double Elapsed { get; set; }
        /// <summary>
        /// Параметр полных трудозатрат 
        /// </summary>
        Double Elapsed { get; set; }
        #endregion

        #region int Mans { get; set; }
        /// <summary>
        /// Количество сотрудников для выполнения задачи
        /// </summary>
        int Mans { get; set; }
        #endregion

        #region Double Cost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        Double Cost { get; set; }
        #endregion

        #region CommonCollection<CategoryRecord> CategoriesRecords { get; }
        /// <summary>
        /// 
        /// </summary>
        CommonCollection<CategoryRecord> CategoriesRecords { get; }
        #endregion

        #endregion
    }
}
