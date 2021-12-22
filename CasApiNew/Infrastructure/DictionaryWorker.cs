using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Abstractions.Abstractions.Workers;
using CAS.Entity.Core;
using CAS.Entity.Core.Repository;
using CAS.Entity.Models.DTO;
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
				if (t == typeof(AccessoryDescriptionDTO))
				{
					var repo = new Repository<AccessoryDescriptionDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(AGWCategorieDTO))
				{
					var repo = new Repository<AGWCategorieDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(AircraftOtherParameterDTO))
				{
					var repo = new Repository<AircraftOtherParameterDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(AirportCodeDTO))
				{
					var repo = new Repository<AirportCodeDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(AirportDTO))
				{
					var repo = new Repository<AirportDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(ATAChapterDTO))
				{
					var repo = new Repository<ATAChapterDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(CruiseLevelDTO))
				{
					var repo = new Repository<CruiseLevelDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(DamageChartDTO))
				{
					var repo = new Repository<DamageChartDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(DefferedCategorieDTO))
				{
					var repo = new Repository<DefferedCategorieDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(DepartmentDTO))
				{
					var repo = new Repository<DepartmentDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(DocumentSubTypeDTO))
				{
					var repo = new Repository<DocumentSubTypeDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(EmployeeSubjectDTO))
				{
					var repo = new Repository<EmployeeSubjectDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(EventCategorieDTO))
				{
					var repo = new Repository<EventCategorieDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(EventClassDTO))
				{
					var repo = new Repository<EventClassDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(FlightNumDTO))
				{
					var repo = new Repository<FlightNumDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(GoodStandartDTO))
				{
					var repo = new Repository<GoodStandartDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(LicenseRemarkRightDTO))
				{
					var repo = new Repository<LicenseRemarkRightDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(LifeLimitCategorieDTO))
				{
					var repo = new Repository<LifeLimitCategorieDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(LocationDTO))
				{
					var repo = new Repository<LocationDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(LocationsTypeDTO))
				{
					var repo = new Repository<LocationsTypeDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(NomenclatureDTO))
				{
					var repo = new Repository<NomenclatureDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(NonRoutineJobDTO))
				{
					var repo = new Repository<NonRoutineJobDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(ReasonDTO))
				{
					var repo = new Repository<ReasonDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(RestrictionDTO))
				{
					var repo = new Repository<RestrictionDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(SchedulePeriodDTO))
				{
					var repo = new Repository<SchedulePeriodDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(ServiceTypeDTO))
				{
					var repo = new Repository<ServiceTypeDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(SpecializationDTO))
				{
					var repo = new Repository<SpecializationDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				if (t == typeof(TripNameDTO))
				{
					var repo = new Repository<TripNameDTO>(context);
					var res = await repo.GetObjectListAsync(loadChild: true);
					return res.Cast<IBaseDictionary>().ToList();
				}

				else return new List<IBaseDictionary>();
			}
		}


		#endregion
	}
}