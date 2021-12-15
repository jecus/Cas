using System.Collections.Generic;
using System.Linq;
using CAS.Entity.Models.Filter;
using Microsoft.Extensions.DependencyInjection;

namespace CAS.API.Infrastructure
{
	public static class WorkerExtensions
	{
		public static IServiceCollection AddWorker<TWorker>(this IServiceCollection services)
			where TWorker : class, IWorker
		{
			services.AddScoped<IWorker, TWorker>();
			return services;
		}

		public static bool IsNullOrEmpty(this IEnumerable<Filter> filters)
		{
			return filters.All(i => i.Value == null && i.Values == null && i.FilterProperty == null);
		}
	}
}