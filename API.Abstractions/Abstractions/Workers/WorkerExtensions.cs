
using Microsoft.Extensions.DependencyInjection;

namespace API.Abstractions.Abstractions.Workers
{
	public static class WorkerExtensions
	{
		public static IServiceCollection AddWorker<TWorker>(this IServiceCollection services)
			where TWorker : class, IWorker
		{
			services.AddScoped<IWorker, TWorker>();
			return services;
		}

		
	}
}