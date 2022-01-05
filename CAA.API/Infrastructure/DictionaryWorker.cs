using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Abstractions.Abstractions.Workers;
using CAA.API.Infrastructure;
using CAA.Entity.Core;
using CAA.Entity.Core.Repository;
using CAA.Entity.Models.Dictionary;
using CAS.Entity.Models.DTO.Dictionaries;
using Entity.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CAS.API.Infrastructure
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
				{
					var dict = await GetDictionary(dictType);
					temp.Add(dictType, dict);
				}

				GlobalObjects.Dictionaries.Clear();
				foreach (var res in temp)
					GlobalObjects.Dictionaries.Add(res.Key, res.Value);


				Thread.Sleep(TimeSpan.FromMinutes(30));
			}
		}

		private async Task<List<IBaseDictionary>> GetDictionary(Type t)
		{
			using (var s = _provider.CreateScope())
			{
				var context = s.ServiceProvider.GetRequiredService<DataContext>(); ;
				if (t == typeof(CAAAccessoryDescriptionDTO))
				{
					var repo = new Repository<CAAAccessoryDescriptionDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(CAAAGWCategorieDTO))
				{
					var repo = new Repository<CAAAGWCategorieDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}


				if (t == typeof(CAAATAChapterDTO))
				{
					var repo = new Repository<CAAATAChapterDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

                if (t == typeof(CAADepartmentDTO))
				{
					var repo = new Repository<CAADepartmentDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(CAADocumentSubTypeDTO))
				{
					var repo = new Repository<CAADocumentSubTypeDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(CAAEmployeeSubjectDTO))
				{
					var repo = new Repository<CAAEmployeeSubjectDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

                if (t == typeof(FindingLevelsDTO))
                {
                    var repo = new Repository<FindingLevelsDTO>(context);
                    var res = await repo.GetObjectListAsync(loadChild: true);
                    return res.Cast<IBaseDictionary>().ToList();
                }
				if (t == typeof(CAAGoodStandartDTO))
				{
					var repo = new Repository<CAAGoodStandartDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(CAALicenseRemarkRightDTO))
				{
					var repo = new Repository<CAALicenseRemarkRightDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}


				if (t == typeof(CAALocationDTO))
				{
					var repo = new Repository<CAALocationDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(CAALocationsTypeDTO))
				{
					var repo = new Repository<CAALocationsTypeDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(CAANomenclatureDTO))
				{
					var repo = new Repository<CAANomenclatureDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}


				if (t == typeof(CAARestrictionDTO))
				{
					var repo = new Repository<CAARestrictionDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(CAAServiceTypeDTO))
				{
					var repo = new Repository<CAAServiceTypeDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(CAASpecializationDTO))
				{
					var repo = new Repository<CAASpecializationDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				else return new List<IBaseDictionary>();
			}
		}


		#endregion
	}
}