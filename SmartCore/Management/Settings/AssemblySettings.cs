namespace SmartCore.Management.Settings
{
    /// <summary>
    /// Параметры для работы программы
    /// </summary>
    public static class AssemblySettings
    {

        #region Constants

        /// <summary>
        /// Краткое название программы
        /// </summary>
        /// Внимание!!! При изменении значения поменять вручную в проектах TextProcessing и CASTriggers в файле AssemblyInfo.cs значение атрибута AssemblyCompany
        public const string ProductShortName = "CAS";

        /// <summary>
        /// Информация о правах на программу
        /// </summary>
        /// Внимание!!! При изменении значения поменять вручную в проектах TextProcessing и CASTriggers в файле AssemblyInfo.cs значение атрибута AssemblyCopyright
        public const string CopyrightShort = "Copyright © Avalon Worldgroup Inc. 2009";

        /// <summary>
        /// Информация о компании разработчике ПО
        /// </summary>
        /// Внимание!!! При изменении значения поменять вручную в проектах TextProcessing и CASTriggers в файле AssemblyInfo.cs значение атрибута AssemblyCompany
        public const string CompanyName = "Avalon Worldgroup Inc.";

        #endregion

    }
}