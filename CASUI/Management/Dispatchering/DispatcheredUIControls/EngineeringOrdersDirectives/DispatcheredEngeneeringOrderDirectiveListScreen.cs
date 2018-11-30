using System;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.EngineeringOrdersDirectives;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls
{
    /// <summary>
    /// Ёлемент управлени€ дл€ работы со списком директив <see cref="EngineeringOrderDirective"/> 
    /// </summary>
    public class DispatcheredEngeneeringOrderDirectiveListScreen : EngineeringOrdersDirectiveListScreen, IDisplayingEntity
    {

        #region Constructor

        /// <summary>
        /// —оздаЄт элемент управлени€ дл€ работы со списком директив <see cref="EngineeringOrderDirective"/> 
        /// </summary>
        ///<param name="parentBaseDetail">Ѕазовый агрегат, к которому принадлежат директивы</param>
        ///<param name="directiveFilter">‘ильтр</param>
        public DispatcheredEngeneeringOrderDirectiveListScreen(BaseDetail parentBaseDetail, DirectiveCollectionFilter directiveFilter) : base(parentBaseDetail, directiveFilter)
        {
            Dock = DockStyle.Fill;
        }

        #endregion

        #region IDisplayingEntity Members

        public object ContainedData
        {
            get
            {
                return parentBaseDetail;
            }
            set
            {
                if (value is BaseDetail)
                    parentBaseDetail = value as BaseDetail;
            }
        }

        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredEngeneeringOrderDirectiveListScreen)) return false;
            if (!(obj.ContainedData is BaseDetail)) return false;

            return (parentBaseDetail.ID == ((BaseDetail)obj.ContainedData).ID); //todo Filters
        }

        public void OnInitCompletion(object sender)
        {
            if (InitComplition != null)
                InitComplition(sender, new EventArgs());
        }

        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            
        }

        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
            
        }

        public void SetEnabled(bool isEnbaled)
        {
            
        }

        public event EventHandler InitComplition;

        #endregion
    }
}