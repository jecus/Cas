using System;
using LTR.Core;
using LTR.UI.Interfaces;
using LTR.UI.Management.Dispatchering;

namespace LTR.UI.UIControls
{
    public class DispatcheredUIOperators : UIOperators, IDisplayingEntity
    {

        /*public DispatcheredUIOperators(ControlMode mode, ICoreTypesCollection collection) : base(mode, collection)
        {
            ContainedData = collection;
        }*/

        public DispatcheredUIOperators():base()
        {

        }

        public object ContainedData
        {
            get
            {
                return Collection;
            }
            set
            {
                Collection = value as ICoreTypesCollection;
            }
        }

        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            return Collection.Equals(obj.ContainedData);
        }

    }
}