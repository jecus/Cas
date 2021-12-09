using System;

namespace Entity.Models.Attributte
{
	[AttributeUsage(AttributeTargets.Property)]
	public class ChildAttribute : Attribute
	{
		private string _parentProperty;
		private int _parentPropertyValue;
		private int[] _parentPropertyValues;
		private FilterType _filter;

		#region Property

		public string ParentProperty
		{
			get { return _parentProperty; }
		}

		public int ParentPropertyValue
		{
			get { return _parentPropertyValue; }
		}

		public int[] ParentPropertyValues
		{
			get { return _parentPropertyValues; }
		}

		public FilterType Filter
		{
			get { return _filter; }
		}

		#endregion

		public ChildAttribute()
		{

		}

		public ChildAttribute(FilterType filter, string parentProperty, int parentPropertyValue)
		{
			_filter = filter;
			_parentProperty = parentProperty;
			_parentPropertyValue = parentPropertyValue;
		}

		public ChildAttribute(FilterType filter, string parentProperty, int[] parentPropertyValues)
		{
			_filter = filter;
			_parentProperty = parentProperty;
			_parentPropertyValues = parentPropertyValues;
		}
	}


}