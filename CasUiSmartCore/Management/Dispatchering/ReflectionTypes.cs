namespace CAS.UI.Management.Dispatchering
{
    /// <summary>
    /// Types of reflection mode
    /// </summary>
    public enum ReflectionTypes
    {
        /// <summary>
        /// Show entity in currently activated displayer
        /// </summary>
        DisplayInCurrent,
        /// <summary>
        /// Create new displayer and show entity in it
        /// </summary>
        DisplayInNew,
        /// <summary>
        /// Show existing displayer for entity
        /// </summary>
        DisplayInExisting,
        ///<summary>
        /// Close currently selected Displayer
        ///</summary>
        CloseSelected,
        /// <summary>
        /// Закрыть вкладку с данным содержимым 
        /// </summary>
        CloseDisplayerContainingEntity,
        ///<summary>
        /// Closes all displayers
        ///</summary>
        CloseAll,
        ///<summary>
        /// Closes all displayers but not currently selected
        ///</summary>
        CloseAllButSelected,
        ///<summary>
        /// Closes all displayers and open some displayer
        ///</summary>
        CloseAllButSome,
        /// <summary>
        /// Changes text of given displayer
        /// </summary>
        ChangeText,
        /// <summary>
        /// Changes text of selected displayer
        /// </summary>
        ChangeTextOfSelected,
        /// <summary>
        /// Changes text of displayer containing control rised the event
        /// </summary>
        ChangeTextOfContainingDisplayer,
        /// <summary>
        /// Display next page if exist
        /// </summary>
        DisplayNextPage,
        /// <summary>
        /// Display prerevios page
        /// </summary>
        DisplayPreviousPage,
        /// <summary>
        /// Display few page
        /// </summary>
        DisplayFewPages,
        /// <summary>
        /// Отображает содержимое на новой вкладке 
        /// <br/>при этом закрывая текущую
        /// </summary>
        DisplayInNewWithCloseCurrent,
    }
}