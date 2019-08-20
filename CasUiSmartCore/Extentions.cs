using System;
using System.Collections.Generic;
using System.Linq;
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

		public static IEnumerable<DateTime> Range(this DateTime startDate, DateTime endDate)
		{
			return Enumerable.Range(0, (endDate - startDate).Days + 1).Select(d => startDate.AddDays(d));
		}

	}
}