using System.ComponentModel;
using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.Core.Types.Dictionaries;
using LTR.Core.Types.ReportFilters;
using LTR.UI.Interfaces;
using LTRReports.Builders;

namespace LTR.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl
{
    /// <summary>
    /// Класс, описывающий отображение всех директив заданного базового агрегата
    /// </summary>
    [ToolboxItem(false)]
    public class DispatcheredBaseDetailDirectivesView : DispatcheredDirectivesView
    {
        #region public DispatcheredBaseDetailDirectivesView(BaseDetail currentItem):base(currentItem)

        /// <summary>
        /// Создается элемент - отображение всех директив заданного базового агрегата
        /// </summary>
        public DispatcheredBaseDetailDirectivesView(BaseDetail currentItem):base(currentItem)
        {
        }

        #endregion

        /// <summary>
        /// Отображение директив для всего ВС
        /// </summary>
        /// <param name="currentItem">ВС, для которого отображаются директивы</param>
        public DispatcheredBaseDetailDirectivesView(Aircraft currentItem)
            : base(currentItem)
        {
        }

        #region protected override bool IsSameType(IDisplayingEntity obj)

        /// <summary>
        /// Тот же тип у объекта что у данного класса или нет
        /// </summary>
        /// <param name="obj">Проверяемый объект</param>
        /// <returns></returns>
        protected override bool IsSameType(IDisplayingEntity obj)
        {
            return (obj is DispatcheredBaseDetailDirectivesView);
        }

        #endregion

        #region protected override DirectiveFilter[] GetCollectionFilters()

        /// <summary>
        /// Текст заголовка отчета
        /// </summary>
        public override string ReportTitileText
        {
            get { return "Directives list"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override DirectiveListReportBuilder CreateReportBuilder()
        {
            return new DirectiveListReportBuilder();//throw new System.NotImplementedException();
        }

        /// <summary>
        /// Тип директивы по умолчанию
        /// </summary>
        public override DirectiveType DirectiveDefaultType
        {
            get { return DirectiveTypeCollection.Instance.GetByID((int)DirectiveTypeID.UsualBaseDetailDirectiveTypeID); }
        }

        /// <summary>
        /// Собирается коллекция фильтров для отображения
        /// </summary>
        /// <returns></returns>
        protected override DirectiveFilter[] GetCollectionFilters()
        {
            return new DirectiveFilter[1] { new AllDirectiveFilter() };
        }

        #endregion

    }
}
