using System;
using System.Collections.Generic;
using System.Linq;
using CAS.Entity.Models.DTO.General;
using Entity.Abstractions.Filters;
using SmartCore.AircraftFlights;
using SmartCore.Directives;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.NewLoader;
using SmartCore.Filters;

namespace SmartCore.Discrepancies
{
	public enum DiscFilterType
	{
		All,
		Defect,
		Occurrence
	}

	public class DiscrepanciesCore : IDiscrepanciesCore
	{
		private readonly ILoader _loader;
		private readonly INewLoader _newLoader;
		private readonly IDirectiveCore _directiveCore;
		private readonly IAircraftFlightCore _aircraftFlightCore;
		
		public DiscrepanciesCore(ILoader loader, INewLoader newLoader, IDirectiveCore directiveCore,
			IAircraftFlightCore aircraftFlightCore)
		{
			_loader = loader;
			_newLoader = newLoader;
			_directiveCore = directiveCore;
			_aircraftFlightCore = aircraftFlightCore;
		}

		#region public List<Discrepancy> GetDiscrepancies(Aircraft aircraft = null)

		///// <param name="status">Фильтр статуса рабочего пакета. (По умолчанию = WorkPackageStatus.All)</param>
		///// <param name="loadWorkPackageItems">Флаг загрузки элементов рабочих пакетов</param>
		///// <param name="includedTasks">Задачи, которые должны содержать пакеты (при передаче пустои коллекции запрос вернет 0 рабочих пакетов)</param>
		/// <returns></returns>
		public List<Discrepancy> GetDiscrepancies(Aircraft aircraft = null, DiscFilterType filterType = DiscFilterType.All, DateTime? from = null, DateTime? to = null) //TODO: Переделать на int? aircraftId = null
		{
			var resultList = new List<Discrepancy>();
			var preResultList = new List<Discrepancy>();


			var filters = new List<ICommonFilter>();

			if(filterType == DiscFilterType.Defect)
				filters.Add(new CommonFilter<bool>(Discrepancy.IsReliabilityProperty, true));
			else if(filterType == DiscFilterType.Occurrence)
				filters.Add(new CommonFilter<bool>(Discrepancy.IsOccurrenceProperty, true));
			else if(from.HasValue && to.HasValue)
			{
				var flights = _loader.GetObjectList<AircraftFlight>(new ICommonFilter[]
				{
					new CommonFilter<DateTime>(AircraftFlight.FlightDateProperty, FilterType.GratherOrEqual, new []{from.Value.Date}), 
					new CommonFilter<DateTime>(AircraftFlight.FlightDateProperty, FilterType.LessOrEqual, new []{to.Value.Date}),
				});

				if(flights.Count > 0) 
					filters.Add(new CommonFilter<int>(Discrepancy.FlightIdProperty, FilterType.In, flights.Select(i => i.ItemId).ToArray()));
			}

			if (aircraft != null)
			{
				preResultList.AddRange(_loader.GetObjectList<Discrepancy>(new[]
				{
					new CommonFilter<string>(Discrepancy.FlightIdProperty,FilterType.In, new []{$"(Select ItemId from AircraftFlights where AircraftId = {aircraft.ItemId} and IsDeleted = 0)"}),
				}));

				//Строка запроса, выдающая идентификаторы родительских задач КИТов
				//Фильтр по ключевому полю таблицы обозначающий 
				//что значения ключевого поля таблицы должны быть
				//среди идентификаторов родительских задач КИТов
			}
			else
			{
				if(filters.Count> 0)
					preResultList.AddRange(_loader.GetObjectListAll<Discrepancy>(filters.ToArray(), loadChild:true));
			}


			#region//заполнение Discrepancies CorrectiveAction в Discrepancies нового полета//

			int[] deferredsIds = preResultList
					.Where(i => i.DirectiveId > 0)
					.Select(i => i.DirectiveId)
					.ToArray();

			var deffereds = new DirectiveCollection();
			if (deferredsIds.Length > 0)
				deffereds = _directiveCore.GetDeferredItems(filters: new ICommonFilter[]{new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, deferredsIds)});


			var parentFlights = new List<AircraftFlight>();
			var flightIds = preResultList.Select(i => i.FlightId).Distinct().ToArray();
			if (aircraft != null)
			{
				foreach (var id in flightIds)
				{
					var fl = _aircraftFlightCore.GetAircraftFlightById(aircraft.ItemId, id);
					if (fl != null)
					{
						parentFlights.Add(fl);
						resultList.Add(preResultList.FirstOrDefault(i => i.FlightId == id));
					}
				}
			}
			else
			{
				if (flightIds.Length > 0)
				{
					var flights = _newLoader.GetObjectList<AircraftFlightDTO, AircraftFlight>(new Filter("ItemId", flightIds));


					foreach (var id in flightIds)
					{
						var fl = flights.FirstOrDefault(i => i.ItemId == id);
						if (fl != null)
						{
							parentFlights.Add(fl);
							resultList.Add(preResultList.FirstOrDefault(i => i.FlightId == id));
						}
					}
				}
			}

			var atlbs = new List<ATLB>();
			var atlbIds = parentFlights.Select(i => i.ATLBId).Distinct().ToArray();
			if (atlbIds.Length > 0)
				//atlbs.AddRange(_loader.GetObjectList<ATLB>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, atlbIds)));
				atlbs.AddRange(_newLoader.GetObjectList<ATLBDTO, ATLB>(new Filter("ItemId", atlbIds)));

			var correctiveActions = new List<CorrectiveAction>();
			var discrepancyIds = resultList.Select(i => i.ItemId).Distinct().ToArray();
			if(discrepancyIds.Length > 0)
				//correctiveActions.AddRange(_loader.GetObjectList<CorrectiveAction>(new CommonFilter<int>(CorrectiveAction.DiscrepancyIdProperty, FilterType.In, discrepancyIds), true));
				correctiveActions.AddRange(_newLoader.GetObjectList<CorrectiveActionDTO, CorrectiveAction>(new Filter("DiscrepancyID", discrepancyIds), true));

			var cetificates = new List<CertificateOfReleaseToService>();
			var crsIds = correctiveActions.Select(i => i.CRSID).Distinct().ToArray();
			if (crsIds.Length > 0)
				cetificates.AddRange(_loader.GetObjectList<CertificateOfReleaseToService>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, crsIds), true));
				//cetificates.AddRange(_newLoader.GetObjectList<CertificateOfReleaseToServiceDTO, CertificateOfReleaseToService>(new Filter("ItemId", crsIds), true));


			foreach (var t in resultList)
			{
				t.ParentFlight = parentFlights.FirstOrDefault(i => i.ItemId == t.FlightId);

				if (t.ParentFlight != null)
					t.ParentFlight.ParentATLB = atlbs.FirstOrDefault(i => i.ItemId == t.ParentFlight.ATLBId);

				t.DeferredItem = deffereds.GetDirectiveById(t.DirectiveId) as DeferredItem;
			
				t.CorrectiveActionCollection = new CorrectiveActionCollection();
				t.CorrectiveActionCollection.AddRange(correctiveActions.Where(i => t.ItemId == i.DiscrepancyId));

				t.CorrectiveAction.CertificateOfReleaseToService = cetificates.FirstOrDefault(i => i.ItemId == t.CorrectiveAction.CRSID);
			}

			#endregion

			return resultList.Where(i => i.ParentFlight != null && i.ParentFlight.ParentATLB != null).ToList();
		}

		#endregion
	}
}