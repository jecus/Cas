using System.Collections.Generic;
using Entity.Models.Attributte;

namespace Entity.Models.Filter
{
	
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

		public Filter()
		{
			
		}

		#endregion


		
		public string FilterProperty { get;  set; }

		
		public FilterType FilterType { get;  set; }

		
		public object Value { get;  set; }

		
		public IEnumerable<int> Values { get;  set; }
	}
}