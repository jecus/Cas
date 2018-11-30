#region

using System;

#endregion

namespace AvControls.ExtendableList
{
    public interface IExtendableItem : IScrollLayoutPanelItem
    {
        event EventHandler Extended;

        void SetExtendedView();
        void SetShortView();
    }
}