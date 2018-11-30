#region

using System.Windows.Forms;

#endregion

namespace AvControls.ExtendableList
{
    public abstract class ScrollItem : PictureBox, IScrollLayoutPanelItem
    {
        #region IScrollLayoutPanelItem Members

        public abstract int BlocksCount { get; set; }

        #endregion
    }
}