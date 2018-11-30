
using System.Windows.Forms;
using LTR.UI.Interfaces;
using LTR.UI.Management.Dispatchering;
using LTR.UI.UIControls;

namespace LTR.UI.DispatcheredUIControls
{
    public partial class DispatcheredUIStartPage : UIStartPage, IDisplayingEntity
    {
        public DispatcheredUIStartPage()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #region IDisplayingEntity Members
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return this; }
            set { }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (obj is DispatcheredUIStartPage)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
