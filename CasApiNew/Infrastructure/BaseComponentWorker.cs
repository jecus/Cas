using System;
using System.Threading;
using API.Abstractions.Abstractions.Workers;
using CAS.Entity.Core;
using CAS.Entity.Core.Repository;
using CAS.Entity.Models.DTO.General;
using Microsoft.Extensions.DependencyInjection;

namespace CAS.API.Infrastructure
{
	public class BaseComponentWorker : IWorker
	{
		private readonly IServiceProvider _provider;

		public BaseComponentWorker(IServiceProvider provider)
		{
			_provider = provider;
		}

		#region Implementation of IDisposable

		public void Dispose()
		{
			
		}

		public async void Start()
		{
			while (true)
			{
				using (var s = _provider.CreateScope())
				{
					var context = s.ServiceProvider.GetRequiredService<DataContext>();
					var repo = new Repository<BaseComponentDTO>(context);
					var res = await repo.GetObjectListAllAsync(loadChild: true);

					GlobalObjects.BaseComponents.Clear();
					GlobalObjects.BaseComponents.AddRange(res);

					Thread.Sleep(TimeSpan.FromMinutes(15));
				}
			}
			
		}

		#endregion
	}
}