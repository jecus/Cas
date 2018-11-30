using System;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.EngineeringOrdersDirectives;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.EngineeringOrdersDirectives
{
    /// <summary>
    /// Ёлемент управлени€ дл€ работы со списком директив <see cref="EngineeringOrderDirective"/> 
    /// </summary>
    public class DispatcheredEngeneeringOrdersDirectiveListScreen : EngineeringOrdersDirectiveListScreen, IDisplayingEntity
    {

        #region Constructor

        /// <summary>
        /// —оздаЄт элемент управлени€ дл€ работы со списком директив <see cref="EngineeringOrderDirective"/> 
        /// </summary>
        ///<param name="parentBaseDetail">Ѕазовый агрегат, к которому принадлежат директивы</param>
        /////<param name="directiveFilter">‘ильтр</param>
        public DispatcheredEngeneeringOrdersDirectiveListScreen(BaseDetail parentBaseDetail) : base(parentBaseDetail)//, DirectiveCollectionFilter directiveFilter) : base(parentBaseDetail, directiveFilter)
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
            if (!(obj is DispatcheredEngeneeringOrdersDirectiveListScreen)) return false;
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
            SetPageEnable(isEnbaled);
        }

        public event EventHandler InitComplition;

        #endregion
    }
}