
namespace CASReports.Builders
{
    public abstract class AbstractReportBuilder
    {

        #region public object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public abstract object GenerateReport();

        #endregion
    }
}
