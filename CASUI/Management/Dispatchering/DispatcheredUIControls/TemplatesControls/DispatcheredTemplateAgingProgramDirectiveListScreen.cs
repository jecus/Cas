using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters.Templates;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls
{
    /// <summary>
    /// Класс, описывающий отображение Aging Propgram директив для базового агрегата
    /// </summary>
    public class DispatcheredTemplateAgingProgramDirectiveListScreen : DispatcheredTemplateDirectiveListView
    {
        /// <summary>
        /// Создается элемент - отображение Aging Propgram директив для базового агрегата
        /// </summary>
        /// <param name="currentItem">Базовый агрегат, для которого отображаются директивы</param>
        public DispatcheredTemplateAgingProgramDirectiveListScreen(TemplateBaseDetail currentItem) : base(currentItem)
        {
        }

        /// <summary>
        /// Создается элемент - отображение Aging Propgram директив для базового агрегата
        /// </summary>
        /// <param name="currentItem">ВС, для которого отображаются директивы</param>
        public DispatcheredTemplateAgingProgramDirectiveListScreen(TemplateAircraft currentItem) : base(currentItem)
        {
        }

        /// <summary>
        /// Текст заголовка отчета
        /// </summary>
        public override string ReportTitileText
        {
            get { return DirectiveTypeCollection.Instance.AgineProgramDirectiveType.CommonName; }
        }

        /// <summary>
        /// Тип директивы по умолчанию
        /// </summary>
        public override DirectiveType DirectiveDefaultType
        {
            get { return DirectiveTypeCollection.Instance.AgineProgramDirectiveType; }
        }

        /// <summary>
        /// Собирается коллекция фильтров для отображения
        /// </summary>
        /// <returns></returns>
        protected override TemplateDirectiveFilter[] GetCollectionFilters()
        {
            return new TemplateDirectiveFilter[1]{new TemplateAgingProgramFilter()};
        }

        /// <summary>
        /// Тот же тип у объекта что у данного класса или нет
        /// </summary>
        /// <param name="obj">Проверяемый объект</param>
        /// <returns></returns>
        protected override bool IsSameType(IDisplayingEntity obj)
        {
            return (obj is DispatcheredTemplateAgingProgramDirectiveListScreen);
        }
    }
}