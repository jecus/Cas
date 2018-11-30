using System;
using System.Globalization;
using System.Reflection;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Класс, возвращающий IReportBuilder для типа необходимого ReportBuilder
    /// </summary>
    public static class InstanceProvider
    {
        /// <summary>
        /// Returns new displayer for specified entity
        /// </summary>
        /// <param name="item">Specified entity to display in displayer</param>
        /// <returns></returns>
        public static object CreateInstance(object item)
        {
            Type type = item.GetType();            
            Assembly assembly = Assembly.GetAssembly(type);
            object result =
                assembly.CreateInstance(type.FullName, true, BindingFlags.CreateInstance, null,
                                        new object[] { }, CultureInfo.CurrentCulture, null);

            return result;
        }
    }
}
