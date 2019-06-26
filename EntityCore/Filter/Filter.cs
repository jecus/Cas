using System.Collections.Generic;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.Filter
{
	[DataContract]
	public class Filter
	{
		#region public Filter(string filterProperty, FilterType filterType, object value)

		public Filter(string filterProperty, FilterType filterType, object value)
		{
			FilterProperty = filterProperty;
			FilterType = filterType;
			Value = value;
		}

		#endregion

		#region public Filter(string filterProperty, FilterType filterType, IEnumerable<int> values)

		public Filter(string filterProperty, IEnumerable<int> values)
		{
			FilterProperty = filterProperty;
			FilterType = FilterType.Equal;
			Values = values;
		}

		#endregion

		#region public Filter(string filterProperty, object value) : this(filterProperty, FilterType.Equal, value )

		public Filter(string filterProperty, object value) : this(filterProperty, FilterType.Equal, value )
		{
		}

		#endregion


		
		public string FilterProperty { get; private set; }

		
		public FilterType FilterType { get; private set; }

		
		public object Value { get; private set; }

		
		public IEnumerable<int> Values { get; private set; }
	}
}