using System;

namespace EFCore.Attributte
{
	[AttributeUsage(AttributeTargets.Property)]
	public class IncludeAttribute : Attribute
	{
		public IncludeAttribute()
		{
			
		}
	}
}