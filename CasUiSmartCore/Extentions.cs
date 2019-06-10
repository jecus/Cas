using System.Reflection;
using System.Windows.Forms;

namespace CAS.UI
{
	public static class Extentions
	{

		public static void DoubleBuffering(this Control control, bool enable)
		{
			var method = typeof(Control).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic);
			method.Invoke(control, new object[] {ControlStyles.OptimizedDoubleBuffer, enable});
		}

	}
}