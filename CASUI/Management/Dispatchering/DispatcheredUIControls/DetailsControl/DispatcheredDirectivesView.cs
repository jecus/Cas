using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LTR.Core;
using LTR.Core.Core.Interfaces;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.Core.Types.Dictionaries;
using LTR.Core.Types.ReportFilters;
using LTR.UI.Interfaces;
using LTR.UI.UIControls.DirectivesControls;
using LTRReports.Builders;

namespace LTR.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl
{
    /// <summary>
    /// Класс, описывающий отображение директив заданного базового агрегата
    /// </summary>
    [ToolboxItem(false)]
    public abstract class DispatcheredDirectivesView : UserControl, IDisplayingEntity
    {
        private CoreType currentItem;

        #region public DispatcheredDirectivesView(BaseDetail currentItem)

        /// <summary>
        /// Создается элемент - отображение директив заданного базового агрегата
        /// </summary>
        public DispatcheredDirectivesView(BaseDetail currentItem):this(currentItem as IDirectiveContainer)
        {
            this.currentItem = currentItem;
        }

        #endregion

        #region public DispatcheredDirectivesView(BaseDetail currentItem)
        /// <summary>
        /// Создается элемент - отображение директив заданного ВС
        /// </summary>
        /// <param name="currentItem"></param>
        public DispatcheredDirectivesView(Aircraft currentItem)
            : this(currentItem as IDirectiveContainer)
        {
            this.currentItem = currentItem;
        }

        #endregion

        #region public DispatcheredDirectivesView(BaseDetail currentItem)
        /// <summary>
        /// Создается элемент - отображение директив заданного ВС
        /// </summary>
        /// <param name="currentItem"></param>
        protected DispatcheredDirectivesView(IDirectiveContainer currentItem)
        {
            DirectiveCollectionFilter filter = new DirectiveCollectionFilter(currentItem.Directives, GetCollectionFilters());

            DirectiveListControl control = null;
            if (currentItem is Aircraft) control = new DirectiveListControl((Aircraft) currentItem, filter, ReportTitileText);
            if (currentItem is BaseDetail) control = new DirectiveListControl((BaseDetail)currentItem, filter, ReportTitileText, DirectiveDefaultType);
            if (control != null)
            {
                control.ReportBuilder = CreateReportBuilder();
                control.ReportText = ReportTitileText;
                control.Dock = DockStyle.Fill;
                Controls.Add(control);
                Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// Текст заголовка отчета
        /// </summary>
        public abstract string ReportTitileText
        { get;
        }

        /// <summary>
        /// 
        /// </summary>
        protected abstract DirectiveListReportBuilder CreateReportBuilder();
        #endregion

        /// <summary>
        /// Тип директивы по умолчанию
        /// </summary>
        public abstract DirectiveType DirectiveDefaultType
        { get;
        }

        #region protected abstract DirectiveFilter[] GetCollectionFilters()

        /// <summary>
        /// Собирается коллекция фильтров для отображения
        /// </summary>
        /// <returns></returns>
        protected abstract DirectiveFilter[] GetCollectionFilters();

        #endregion

        #region public object ContainedData

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return currentItem; }
            set
            { 
                if (value is BaseDetail) 
                    currentItem = value as BaseDetail;
                if (value is Aircraft)
                    currentItem = value as Aircraft;
            }
        }

        #endregion

        #region public bool ContainedDataEquals(IDisplayingEntity obj)

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!IsSameType(obj)) return false;
            if (obj.ContainedData as CoreType == null) return false;
            if (currentItem == null) return false;

            return ((CoreType)obj.ContainedData).ID == currentItem.ID;
        }

        #endregion

        #region protected abstract bool IsSameType(IDisplayingEntity obj)

        /// <summary>
        /// Тот же тип у объекта что у данного класса или нет
        /// </summary>
        /// <param name="obj">Проверяемый объект</param>
        /// <returns></returns>
        protected abstract bool IsSameType(IDisplayingEntity obj);

        #endregion

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)

        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
        }

        #endregion

    }
}
