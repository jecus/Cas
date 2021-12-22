using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstractions.Filters;

namespace Entity.Abstractions.Extensions
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this IEnumerable<Filter> filters)
        {
            return filters.All(i => i.Value == null && i.Values == null && i.FilterProperty == null);
        }
    }
}
