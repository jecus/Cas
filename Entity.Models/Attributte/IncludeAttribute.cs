using System;

namespace Entity.Models.Attributte
{
	[AttributeUsage(AttributeTargets.Property)]
	public class IncludeAttribute : Attribute
	{
		public IncludeAttribute()
		{
			
		}
	}
}