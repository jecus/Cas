using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using EntityCore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CasAPI.Infrastructure
{
	public class DictionaryWorker : IWorker
	{
		private readonly IServiceProvider _provider;

		public DictionaryWorker(IServiceProvider provider)
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
				var temp = new Dictionary<Type, List<IBaseDictionary>>();
				var interfaceType = typeof(IBaseDictionary);
				var dictTypes = AppDomain.CurrentDomain.GetAssemblies()
					.SelectMany(s => s.GetTypes())
					.Where(interfaceType.IsAssignableFrom).ToList();

				
				foreach (var dictType in dictTypes)
					temp.Add(dictType, await GetDictionary(dictType));

				GlobalObjects.Dictionaries.Clear();
				foreach (var res in temp)
					GlobalObjects.Dictionaries.Add(res.Key, res.Value);


				Thread.Sleep(TimeSpan.FromMinutes(5));
			}
		}


		private async Task<List<IBaseDictionary>> GetDictionary(Type t)
		{
			using (var s = _provider.CreateScope())
			{
				var context = s.ServiceProvider.GetRequiredService<DataContext>(); ;
				if (t == typeof(AccessoryDescriptionDTO))
				{
					var repo = new Repository<AccessoryDescriptionDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res as List<IBaseDictionary>;
				}
				else return new List<IBaseDictionary>();
			}
		}

		#endregion
	}
}