using System.Windows.Forms;
using LTR.Core;
using LTR.UI.Interfaces;
using LTR.UI.UIControls;

namespace LTR.UI.DispatcheredUIControls
{
    internal partial class DispatcheredUIAircraftCollection : UIAircraftCollection, IDisplayingEntity
    {
        public DispatcheredUIAircraftCollection(Operator currentOperator) : base(currentOperator)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }


        #region IDisplayingEntity Members

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

        #endregion
    }
}
