using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.Filter
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


		[DataMember]
		public string FilterProperty { get; private set; }

		[DataMember]
		public FilterType FilterType { get; private set; }

		[DataMember]
		public object Value { get; private set; }

		[DataMember]
		public IEnumerable<int> Values { get; private set; }
	}
}