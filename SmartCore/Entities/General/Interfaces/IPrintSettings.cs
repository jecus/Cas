namespace SmartCore.Entities.General.Interfaces
{
    /// <summary>
    /// Интерфейс, Описывающий настроики печати элемента в различных модулях программы
    /// </summary>
    public interface IPrintSettings
    {
        #region bool PrintInWorkPackage { get; set; }
        /// <summary>
        /// Возвращает или задает значение, показвающее настройку печати элемента в Рабочем пакете
        /// </summary>
        bool PrintInWorkPackage { get; set; }
        #endregion

        #region bool WorkPackageACCPrintTitle { get; set; }
        /// <summary>
        /// Возвращает или задает значение, показвающее печать НАЗВАНИЯ задачи в AccountabilitySheet рабочего пакета
        /// </summary>
        bool WorkPackageACCPrintTitle { get; set; }
        #endregion

        #region bool WorkPackageACCPrintTaskCard { get; set; }
        /// <summary>
        /// Возвращает или задает значение, показвающее печать РАБОЧЕЙ КАРТЫ задачи в AccountabilitySheet рабочего пакета
        /// </summary>
        bool WorkPackageACCPrintTaskCard { get; set; }
        #endregion

    }
}
