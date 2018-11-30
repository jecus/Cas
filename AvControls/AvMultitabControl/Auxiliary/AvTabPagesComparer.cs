#region

using System.Collections.Generic;

#endregion

namespace AvControls.AvMultitabControl.Auxiliary
{
    /// <summary>
    /// Сравниватель страниц мультивкладочного контрола
    /// </summary>
    public class AvTabPagesComparer : IComparer<MultitabPage>
    {
        #region IComparer<AvTabPage> Members

        public int Compare(MultitabPage x, MultitabPage y)
        {
            return string.Compare(x.Text, y.Text);
        }

        #endregion
    }
}