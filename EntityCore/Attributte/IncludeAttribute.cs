using System;

namespace EntityCore.Attributte
{
	[AttributeUsage(AttributeTargets.Property)]
	public class IncludeAttribute : Attribute
	{
		public IncludeAttribute()
		{
			
		}
	}
}