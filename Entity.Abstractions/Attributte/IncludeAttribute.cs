using System;

namespace Entity.Abstractions.Attributte
{
	[AttributeUsage(AttributeTargets.Property)]
	public class IncludeAttribute : Attribute
	{
		public IncludeAttribute()
		{
			
		}
	}
}