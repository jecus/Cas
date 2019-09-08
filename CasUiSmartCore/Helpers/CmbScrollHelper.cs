using System.Windows.Forms;

namespace CAS.UI.Helpers
{
	public static class CmbScrollHelper
	{
		public static void ComboBoxDocumentType_MouseWheel(object sender, MouseEventArgs e)
		{
			((HandledMouseEventArgs)e).Handled = true;
		}
	}
}