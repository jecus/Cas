using System.Windows.Forms;

namespace CAS.UI.Helpers
{
    public static  class UIExtensions
    {

        public static void Unchecked(this CheckedListBox list)
        {
            foreach (int i in list.CheckedIndices)
                list.SetItemCheckState(i, CheckState.Unchecked);
        }
    }
}
