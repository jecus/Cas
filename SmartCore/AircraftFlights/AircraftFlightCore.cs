using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Aircrafts;
using SmartCore.Component;
using SmartCore.Directives;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Schedule;
using SmartCore.Entities.General.SMS;
using SmartCore.Entities.NewLoader;
using SmartCore.Filters;
using SmartCore.Queries;

namespace SmartCore.AircraftFlights
{
	public class AircraftFlightCore : IAircraftFlightCore
	{
		private readonly ICasEnvironment _casEnvironment;
		private readonly ILoader _loader;
		private readonly INewLoader _newLoader;
		private readonly IDirectiveCore _directiveCore;
		private readonly IManipulator _manipulator;
		private readonly INewKeeper _newKeeper;
		private readonly IAircraftsCore _aircraftsCore;
		private readonly IComponentCore _componentCore;
		private IDictionary<int, AircraftFlightCollection> _flights;//TODO:(Evgenii Babak)AircraftFlightCollection должен содержать AircraftFlightDTO 

		public AircraftFlightCore(ICasEnvironment casEnvironment, ILoader loader, INewLoader newLoader, IDirectiveCore directiveCore, 
			                      IManipulator manipulator, IComponentCore componentCore,
			INewKeeper newKeeper,IAircraftsCore aircraftsCore)
		{
			_casEnvironment = casEnvironment;
			_loader = loader;
			_newLoader = newLoader;
			_directiveCore = directiveCore;
			_manipulator = manipulator;
			_componentCore = componentCore;
			_newKeeper = newKeeper;
			_aircraftsCore = aircraftsCore;
			_flights = new Dictionary<int, AircraftFlightCollection>();
		}

		#region public AircraftFlight LoadFullAircraftFlightById(int flightId, int parentAircraftId))
		/// <summary>
		/// Возвращает полностью загруженный полет со всеми его вложенными объектами
		/// </summary>
		/// <param name="flightId"></param>
		/// <param name="parentAircraftId"></param>
		/// <returns></returns>
		public AircraftFlight LoadFullAircraftFlightById(int flightId, int parentAircraftId)
		{
			return loadFullAircraftFlightById(flightId, parentAircraftId);
		}

		#endregion

		#region public void GetAircraftInformationToFlight(Aircraft parentAircraft, AircraftFlight flight)
		/// <summary>
		/// Добавляет информацию о Воздушном Судне в Полет
		/// </summary>
		/// <param name="parentAircraftId">Id ВС</param>
		/// <param name="flight">Полет</param>
		public void GetAircraftInformationToFlight(int parentAircraftId, AircraftFlight flight)
		{
			//    Составление списка базовых агрегатов самолета, он необходим    //
			//для определения точного количества агрегатов самолета для заполения//
			//  формы полета и корректого редактироваия состояний этих агрегатов //
			///////////////////////////////////////////////////////////////////////
			var aircraftBaseComponents = _componentCore.GetAicraftBaseComponents(parentAircraftId);
			var parentAircraft = _aircraftsCore.GetAircraftById(parentAircraftId);

			if (flight.RunupsCollection.Count == 0 && parentAircraft.ApuUtizationPerFlightinMinutes != null)
			{
				foreach (var t in aircraftBaseComponents.Where(i => i.BaseComponentType == BaseComponentType.Apu))
				{
					var r = new RunUp { BaseComponent = t, BaseComponentId = t.ItemId };
					flight.RunupsCollection.Add(r);
				}
			}

			//Подсчет количества двигателей
			if (flight.EngineConditionCollection.Count == 0)
			{
				foreach (var t in aircraftBaseComponents.Where(i => i.BaseComponentType == BaseComponentType.Engine))
				{
					var newEngineCondition = new EngineCondition { Engine = t };
					flight.EngineConditionCollection.Add(newEngineCondition);
				}
			}
			//Подсчет количества шасси
			if (flight.LandingGearConditions.Count == 0)
			{
				foreach (var t in aircraftBaseComponents.Where(i => i.BaseComponentType == BaseComponentType.LandingGear))
				{
					var newLgCondition = new LandingGearCondition { LandingGear = t };
					flight.LandingGearConditions.Add(newLgCondition);
				}
			}

			if (GetAircraftFlightsCount(parentAircraftId) != 0)
			{
				var lastAircraftFlightId = getLastAircraftFlight(parentAircraftId, flight.ATLBId).ItemId;
				AircraftFlight tempLast = loadFullAircraftFlightById(lastAircraftFlightId, parentAircraftId);
				ATLB atlb = _newLoader.GetObjectById<ATLBDTO, ATLB>(tempLast.ATLBId);

				#region Дата и маршрут пред. полета

				flight.FlightAircraftCode = tempLast.FlightAircraftCode;
				flight.StationFromId = tempLast.StationToId;
				flight.StationToId = tempLast.StationFromId;
				flight.FlightDate = tempLast.FlightDate;
				flight.FlightType = tempLast.FlightType;
				flight.FlightCategory = tempLast.FlightCategory;
				flight.Distance = tempLast.Distance;
				flight.DistanceMeasure = tempLast.DistanceMeasure;
				flight.Level = tempLast.Level;

				#endregion

				#region Номер страницы пред. полета
				if (atlb != null && flight.ParentATLB != null)
				{
					if (atlb.ItemId == flight.ParentATLB.ItemId)
					{
						int atlbCountFlight = atlb.PageFlightCount;
						var flights = getAircraftFlightsCollection(parentAircraftId);
						int countFlightInLastPage = flights.GetFlightWithPageNumInAtlb(tempLast.PageNo, tempLast.ATLBId).Count;
						if (countFlightInLastPage < atlbCountFlight)
							flight.PageNo = tempLast.PageNo;
						else
						{
							if (tempLast.PageNo != "")
							{
								int lastPageNum;
								//проверка на правильность формата введения номера страницы

								if (int.TryParse(tempLast.PageNo, out lastPageNum))
								{
									string lastSerial = lastPageNum >= 0 ? tempLast.PageNo.Replace(lastPageNum.ToString(), "") : "";
									flight.PageNo = lastSerial + (lastPageNum + 1);
								}
								else
								{
									var pattern = @"^[a-zA-Z]+";
									var strPart = Regex.Match(tempLast.PageNo, pattern).Value;
									var noPart = Regex.Replace(tempLast.PageNo, pattern, "");
									var no = int.Parse(noPart);
									var length = noPart.Length;
									length = (no + 1) / (Math.Pow(10, length)) == 1 ? length + 1 : length;
									flight.PageNo = strPart + (no + 1).ToString("D" + length);

								}
							}
						}
					}
					else flight.PageNo = flight.ParentATLB.StartPageNo.ToString();
				}
				#endregion

				#region Экипаж с пред. полета

				//загрузка информации из предыдущего полета
				foreach (FlightCrewRecord c in tempLast.FlightCrewRecords)
				{
					FlightCrewRecord newFtCondition = new FlightCrewRecord
					{
						Specialist = c.Specialist,
						Specialization = c.Specialization
					};
					flight.FlightCrewRecords.Add(newFtCondition);
				}
				#endregion

				#region Мониторинг двигателей с пред. полета

				foreach (EngineCondition t in flight.EngineConditionCollection)
				{
					EngineCondition lastCondition =
						tempLast.EngineConditionCollection.FirstOrDefault(e => e.EngineId == t.EngineId);
					if (lastCondition != null)
					{
						t.SetProperties(lastCondition);
					}
				}

				#endregion

				#region Работа двигателей в разл. режимах с пред. полета

				foreach (EngineTimeInRegime t in tempLast.PowerUnitTimeInRegimeCollection)
				{
					EngineTimeInRegime newFtCondition = new EngineTimeInRegime
					{
						BaseComponent = t.BaseComponent,
						BaseComponentId = t.BaseComponentId,
						FlightRegime = t.FlightRegime,
					};
					flight.PowerUnitTimeInRegimeCollection.Add(newFtCondition);
				}

				#endregion

				#region Время акселерации двигателей с пред. полета

				foreach (EngineAccelerationTime t in tempLast.EngineAccelerationTimeCollection)
				{
					EngineAccelerationTime newFtCondition = new EngineAccelerationTime
					{
						BaseComponent = t.BaseComponent,
						BaseComponentId = t.BaseComponentId,
						AccelerationTime = t.AccelerationTime,
						AccelerationTimeAir = t.AccelerationTimeAir
					};
					flight.EngineAccelerationTimeCollection.Add(newFtCondition);
				}

				#endregion

				#region Пуски ВСУ с пред. полета

				if (tempLast.RunupsCollection.Count != 0)
				{
					BaseComponent apu = aircraftBaseComponents.FirstOrDefault(bd => bd.BaseComponentType == BaseComponentType.Apu);
					if (apu != null)
					{
						RunUp apuRunUp = tempLast.RunupsCollection.GetByBaseComponent(apu).FirstOrDefault();
						if (apuRunUp != null)
						{
							RunUp r = new RunUp { BaseComponent = apu, BaseComponentId = apu.ItemId };
							flight.RunupsCollection.Add(r);
						}
					}
				}

				#endregion

				#region Подсчет количества топливных баков

				//загрузка информации из предыдущего полета
				for (int i = 0; i < tempLast.FuelTankCollection.Count; i++)
				{
					//Проверка, не является ли кол-во баков на пред. полете
					//большим чем текущее кол-во
					if (i >= parentAircraft.Tanks) break;
					FuelTankCondition newFtCondition = new FuelTankCondition
					{
						Tank = tempLast.FuelTankCollection[i].Tank,
						Remaining = tempLast.FuelTankCollection[i].RemainingAfter,
						OnBoard = tempLast.FuelTankCollection[i].RemainingAfter,
						RemainingAfter = tempLast.FuelTankCollection[i].RemainingAfter
					};
					flight.FuelTankCollection.Add(newFtCondition);
				}

				if (flight.FuelTankCollection.Count < parentAircraft.Tanks)
				{
					//Кол-во баков на пред. полете меньше чем тек. кол-во
					//(значит был добавлен бак)
					for (int i = flight.FuelTankCollection.Count; i < parentAircraft.Tanks; i++)
					{
						FuelTankCondition newFtCondition = new FuelTankCondition();
						flight.FuelTankCollection.Add(newFtCondition);
					}
				}

				#endregion

				#region Учет масла с пред. полета

				//загрузка информации из предыдущего полета
				foreach (ComponentOilCondition c in tempLast.OilConditionCollection)
				{
					ComponentOilCondition newFtCondition = new ComponentOilCondition
					{
						Remain = c.RemainAfter,
						OnBoard = c.RemainAfter,
						RemainAfter = c.RemainAfter
					};
					flight.OilConditionCollection.Add(newFtCondition);
				}
				#endregion

				#region Учет гидравлики с пред. полета

				//загрузка информации из предыдущего полета
				foreach (HydraulicCondition c in tempLast.HydraulicConditionCollection)
				{
					HydraulicCondition newFtCondition = new HydraulicCondition
					{
						HydraulicSystem = c.HydraulicSystem,
						Remain = c.RemainAfter,
						OnBoard = c.RemainAfter,
						RemainAfter = c.RemainAfter
					};
					flight.HydraulicConditionCollection.Add(newFtCondition);
				}
				#endregion

				#region Пассажиры с пред. полета

				//загрузка информации из предыдущего полета
				foreach (FlightPassengerRecord c in tempLast.FlightPassengerRecords)
				{
					FlightPassengerRecord newFtCondition = new FlightPassengerRecord
					{
						PassengerCategory = c.PassengerCategory,
					};
					flight.FlightPassengerRecords.Add(newFtCondition);
				}
				#endregion

				#region Груз с пред. полета

				//загрузка информации из предыдущего полета
				foreach (FlightCargoRecord c in tempLast.FlightCargoRecords)
				{
					FlightCargoRecord newFtCondition = new FlightCargoRecord
					{
						CargoCategory = c.CargoCategory,
						Measure = c.Measure
					};
					flight.FlightCargoRecords.Add(newFtCondition);
				}
				#endregion
			}
			else
			{
				//Подсчет количества топливных баков
				if (flight.FuelTankCollection.Count == 0)
				{
					for (int i = 0; i < parentAircraft.Tanks; i++)
					{
						FuelTankCondition newFtCondition = new FuelTankCondition();
						flight.FuelTankCollection.Add(newFtCondition);
					}
				}

				flight.FlightDate = DateTime.Today;
				flight.FlightCategory = FlightCategory.DomesticFlight;

			}
			flight.AircraftId = parentAircraftId;
		}
		#endregion

		#region public string GetLastPageNoFromAtlb(int atlbId, int aircraftId)

		public string GetLastPageNoFromAtlb(int atlbId, int aircraftId)
		{
			return getLastPageNoFromAtlb(atlbId, aircraftId);
		}

		#endregion

		#region public string GetNextPageNoFromAtlb(int atlbId, int aircraftId)

		public string GetNextPageNoFromAtlb(int atlbId, int aircraftId)
		{
			var lastPage = getLastPageNoFromAtlb(atlbId, aircraftId);
			string nextPage = "";
			if (lastPage != "")
			{
				int lastPageNum;
				//проверка на правильность формата введения номера страницы

				if (int.TryParse(lastPage, out lastPageNum))
				{
					string lastSerial = lastPageNum >= 0 ? lastPage.Replace(lastPageNum.ToString(), "") : "";
					nextPage = lastSerial + (lastPageNum + 1);
				}
				else
				{
					var pattern = @"^[a-zA-Z]+";
					var strPart = Regex.Match(lastPage, pattern).Value;
					var noPart = Regex.Replace(lastPage, pattern, "");
					var no = int.Parse(noPart);
					var length = noPart.Length;
					length = (no + 1) / (Math.Pow(10, length)) == 1 ? length + 1 : length;
					nextPage = strPart + (no + 1).ToString("D" + length);
				}
			}

			return nextPage;
		}

		#endregion

		#region public string getLastPageNoFromAtlb(int atlbId, int aircraftId)

		public string getLastPageNoFromAtlb(int atlbId, int aircraftId)
		{
			var ds = _casEnvironment.Execute($"select top 1 PageNo from AircraftFlights where AircraftId = {aircraftId} and ATLBID = {atlbId} order by PageNo desc");

			return ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0][0].ToString() : "";
		}

		#endregion

		#region public void AddAircraftFlight(AircraftFlight Flight)
		/// <summary>
		/// Заливает полет и его вложенные объекты по соответствующим таблицам БД
		/// </summary>
		/// <param name="flight">Заливаемый полет</param>
		public void AddAircraftFlight(AircraftFlight flight)
		{
			// Проверки
			if (flight == null) throw new Exception("1000: Can not add discrepancy");

			//сохранение CertificateOfReleaseToService
			if (flight.CertificateOfReleaseToService != null)
			{
				//Сертификат сохраняется перед полетов, т.к. ID сертификата 
				//должно быть сохранено в поле CRSID класса AircraftFlight
				_newKeeper.Save(flight.CertificateOfReleaseToService);

				flight.CrsId = flight.CertificateOfReleaseToService.ItemId;
			}

			if (flight.ItemId < 0)
			{
				if (_flights.ContainsKey(flight.AircraftId))
					_flights[flight.AircraftId].Add(flight);
				else
					_flights.Add(flight.AircraftId, new AircraftFlightCollection { flight });
			}
			//сохранение, собственно, самого полета
			flight.FlightDate = flight.FlightDate.Date.AddMinutes(flight.OutTime);
			_newKeeper.Save(flight);

			#region//сохранение RunUps
			foreach (RunUp ru in flight.RunupsCollection)
			{
				ru.FlightId = flight.ItemId;
				ru.RecordDate = flight.FlightDate.Date.AddTicks(ru.StartTime.Ticks);
				_newKeeper.Save(ru);
			}
			#endregion

			#region//сохранение Discrepancies
			foreach (Discrepancy discrepancy in flight.Discrepancies)
			{
				discrepancy.FlightId = flight.ItemId;

				if (discrepancy.DeferredItem != null)
				{
					discrepancy.DirectiveId = discrepancy.DeferredItem.ItemId;
					discrepancy.DeferredItem.AircraftFlightId = flight.ItemId;
					discrepancy.DeferredItem.Threshold.EffectiveDate = flight.FlightDate;
					_newKeeper.Save(discrepancy.DeferredItem);
				}

				AddDiscrepancy(discrepancy);
			}
			#endregion

			#region //сохранение ComponentOilCondition

			foreach (ComponentOilCondition oilCondition in flight.OilConditionCollection)
			{
				oilCondition.FlightId = flight.ItemId;
				_newKeeper.Save(oilCondition);
			}
			#endregion

			#region //сохранение HydraulicCondition

			foreach (HydraulicCondition oilCondition in flight.HydraulicConditionCollection)
			{
				oilCondition.FlightId = flight.ItemId;
				_newKeeper.Save(oilCondition);
			}
			#endregion

			#region//сохранение специалиста
			foreach (FlightCrewRecord item in flight.FlightCrewRecords)
			{
				item.FlightId = flight.ItemId;
				_newKeeper.Save(item);
				//AddSpecialistToFlightCrew(item);
			}
			#endregion

			#region//сохранение пассажиров
			foreach (FlightPassengerRecord item in flight.FlightPassengerRecords)
			{
				item.FlightId = flight.ItemId;
				item.RecordDate = flight.RecordDate;
				_newKeeper.Save(item);
			}
			#endregion

			#region//сохранение груза
			foreach (FlightCargoRecord item in flight.FlightCargoRecords)
			{
				item.FlightId = flight.ItemId;
				item.RecordDate = flight.RecordDate;
				_newKeeper.Save(item);
			}
			#endregion

			#region//сохранение engineCondition
			foreach (EngineCondition engineCondition in flight.EngineConditionCollection)
			{
				engineCondition.FlightId = flight.ItemId;
				engineCondition.RecordDate = flight.FlightDate.Date.AddTicks(engineCondition.TimeGMT.Ticks);
				_newKeeper.Save(engineCondition);
			}
			#endregion

			#region//сохранение PowerUnitTimeInRegime
			foreach (EngineTimeInRegime engineCondition in flight.PowerUnitTimeInRegimeCollection)
			{
				engineCondition.FlightId = flight.ItemId;
				engineCondition.RecordDate = flight.FlightDate.Date.AddMinutes(flight.TakeOffTime);
				_newKeeper.Save(engineCondition);
			}
			#endregion

			#region//сохранение EngineAccelerationTime
			foreach (EngineAccelerationTime engineCondition in flight.EngineAccelerationTimeCollection)
			{
				engineCondition.FlightId = flight.ItemId;
				engineCondition.RecordDate = flight.FlightDate.Date.AddMinutes(flight.TakeOffTime);
				_newKeeper.Save(engineCondition);
			}
			#endregion

			#region//сохранение LandingGearCondition
			foreach (LandingGearCondition landingGearCondition in flight.LandingGearConditions)
			{
				landingGearCondition.FlightId = flight.ItemId;
				landingGearCondition.RecordDate = flight.FlightDate.Date.AddMinutes(flight.TakeOffTime);
				_newKeeper.Save(landingGearCondition);
			}
			#endregion

			#region//сохранение событий системы безопасности полетов
			foreach (Event smsEvent in flight.Events)
			{
				if (flight.AircraftId > 0)
					smsEvent.AircraftId = flight.AircraftId;
				smsEvent.ParentType = flight.SmartCoreObjectType;
				smsEvent.ParentId = flight.ItemId;
				smsEvent.RecordDate = flight.FlightDate.Date.AddMinutes(flight.TakeOffTime);
				_newKeeper.Save(smsEvent);

				foreach (EventCondition condition in smsEvent.EventConditions)
				{
					condition.ParentId = smsEvent.ItemId;
					condition.ParentType = smsEvent.SmartCoreObjectType;
					_manipulator.Save(condition);
				}
			}
			#endregion

		}
		#endregion

		#region public void Delete(AircraftFlight aircraftFlight)
		/// <summary>
		/// Удаление aircraftFlight
		/// </summary>
		/// <param name="aircraftFlight"></param>
		public void Delete(AircraftFlight aircraftFlight)
		{
			// Добавление & удаление полета воздушного судна влияет на подсчет ресурса агрегата 

			aircraftFlight.IsDeleted = true;
			_newKeeper.Save(aircraftFlight);

			if (aircraftFlight.AircraftId <= 0) throw new Exception("1241: Back link to aircraft is null");

			if(_flights.ContainsKey(aircraftFlight.AircraftId))
				_flights[aircraftFlight.AircraftId].Remove(aircraftFlight);
		}

		#endregion

		#region public void AddReason(Reason reason)
		/// <summary>
		/// Добавляет новую причину и изменяе глобальную коллекцию
		/// </summary>
		/// <param name="reason">Новая причина</param>
		public void AddReason(Reason reason)
		{
			_newKeeper.Save(reason);
			_casEnvironment.Reasons.Add(reason);
		}
		#endregion

		#region public void Save(FlightNumber saveObject)
		public void Save(FlightNumber saveObject)
		{
			if (saveObject == null) return;

			_newKeeper.Save(saveObject);


			foreach (var period in saveObject.FlightNumberPeriod)
			{
				period.FlightNumberId = saveObject.ItemId;
				period.FlightNum = saveObject;
				_newKeeper.Save(period);
			}

			#region//сохранение требуемого экипажа

			List<FlightNumberCrewRecord> crewToRemove = new List<FlightNumberCrewRecord>();
			foreach (FlightNumberCrewRecord item in saveObject.FlightNumberCrewRecords)
			{
				item.FlightNumber = saveObject;
				_newKeeper.Save(item);

				if (item.IsDeleted)
					crewToRemove.Add(item);
			}
			//некоторые элементы могут быть проставлены как недействительные
			//их необходимо удалить из коллекции
			foreach (FlightNumberCrewRecord crewRecord in crewToRemove)
			{
				saveObject.FlightNumberCrewRecords.RemoveById(crewRecord.ItemId);
			}

			#endregion

			#region//сохранение Допущенных моделей ВС

			List<FlightNumberAircraftModelRelation> acModelToRemove = new List<FlightNumberAircraftModelRelation>();
			foreach (FlightNumberAircraftModelRelation item in saveObject.AircraftModels)
			{
				item.FlightNumber = saveObject;
				_newKeeper.Save(item);

				if (item.IsDeleted)
					acModelToRemove.Add(item);
			}
			//некоторые элементы могут быть проставлены как недействительные
			//их необходимо удалить из коллекции
			foreach (FlightNumberAircraftModelRelation acModel in acModelToRemove)
			{
				saveObject.AircraftModels.RemoveById(acModel.ItemId);
			}

			#endregion

			#region//сохранение Запасных аэропортов

			List<FlightNumberAirportRelation> airportsRemove = new List<FlightNumberAirportRelation>();
			foreach (FlightNumberAirportRelation item in saveObject.AlternateAirports)
			{
				item.FlightNumber = saveObject;
				_newKeeper.Save(item);

				if (item.IsDeleted)
					airportsRemove.Add(item);
			}
			//некоторые элементы могут быть проставлены как недействительные
			//их необходимо удалить из коллекции
			foreach (FlightNumberAirportRelation airportRelation in airportsRemove)
			{
				saveObject.AlternateAirports.RemoveById(airportRelation.ItemId);
			}

			#endregion
		}
		#endregion

		#region public void AddDiscrepancy(Discrepancy Discrepancy)
		/// <summary>
		/// Заливает Discrepancy и его вложенные объекты по соответствующим таблицам БД
		/// </summary>
		/// <param name="discrepancy">Discrepancy</param>
		private void AddDiscrepancy(Discrepancy discrepancy)
		{
			// Проверки
			if (discrepancy == null) throw new Exception("1000: Can not add discrepancy");
			//сохранение, собственно, самого Discrepancy
			_newKeeper.Save(discrepancy);


			//сохранение CorrectiveAction
			if (discrepancy.CorrectiveActionCollection != null)
			{
				for (int i = 0; i < discrepancy.CorrectiveActionCollection.Count; i++)
				{
					discrepancy.CorrectiveActionCollection[i].DiscrepancyId = discrepancy.ItemId;
					AddCorrectiveAction(discrepancy.CorrectiveActionCollection[i]);
				}
			}
			else if (discrepancy.CorrectiveAction != null)
			{
				discrepancy.CorrectiveAction.DiscrepancyId = discrepancy.ItemId;
				AddCorrectiveAction(discrepancy.CorrectiveAction);
			}
		}
		#endregion

		#region public void AddCorrectiveAction(CorrectiveAction Action)

		/// <summary>
		/// Заливает CorrectiveAction и его вложенные объекты по соответствующим таблицам БД
		/// </summary>
		/// <param name="action"></param>
		private void AddCorrectiveAction(CorrectiveAction action)
		{
			// Проверки
			if (action == null) throw new Exception("1000: Can not add CorrectiveAction");

			//сохранение CertificateReleaseToService 
			if (action.CertificateOfReleaseToService != null)
			{
				_newKeeper.Save(action.CertificateOfReleaseToService);
				action.CRSID = action.CertificateOfReleaseToService.ItemId;
			}


			//сохранение, собственно, самого CorrectiveAction

			_newKeeper.Save(action);
		}
		#endregion

		#region public void LoadAllFlights()
		/// <summary>
		/// Загружает все полеты для всех воздушных судов и разносит по воздушным судам
		/// </summary>
		public void LoadAllFlights()
		{
			var atldIds = _newLoader.GetSelectColumnOnly<ATLBDTO>(null, c => c.ItemId);
			var flights = _newLoader.GetObjectList<AircraftFlightDTO, AircraftFlight>(new Filter("ATLBID", atldIds));

			if (flights.Count == 0)
				return;

			var flightsIds = flights.Select(f => f.ItemId).Distinct().ToArray();
			var runUps = _newLoader.GetObjectList<RunUpDTO, RunUp>(new Filter("FlightId", flightsIds));

			var engimeInRegimeRecords = _newLoader.GetObjectList<EngineTimeInRegimeDTO, EngineTimeInRegime>(new Filter("FlightId", flightsIds));

			var flightsCrsIds = flights.Select(f => f.CrsId).Distinct().ToArray();
			var crs = _newLoader.GetObjectList<CertificateOfReleaseToServiceDTO, CertificateOfReleaseToService>(new Filter("ItemId", flightsCrsIds));

			foreach (var flightRun in runUps)
				flightRun.BaseComponent = _componentCore.GetBaseComponentById(flightRun.BaseComponentId);

			foreach (var flightEwr in engimeInRegimeRecords)
				flightEwr.BaseComponent = _componentCore.GetBaseComponentById(flightEwr.BaseComponentId);

			if(_flights.Count > 0)
				_flights.Clear();

			foreach (var t in flights)
			{
				t.RunupsCollection.AddRange(runUps.Where(r => r.FlightId == t.ItemId).ToArray());
				t.PowerUnitTimeInRegimeCollection.AddRange(engimeInRegimeRecords.Where(r => r.FlightId == t.ItemId).ToArray());
				t.CertificateOfReleaseToService = crs.FirstOrDefault(service => service.ItemId == t.CrsId);

				if (_flights.ContainsKey(t.AircraftId))
					_flights[t.AircraftId].Add(t);
				else
					_flights.Add(t.AircraftId, new AircraftFlightCollection { t });
			}
		}

		#endregion

		#region public void LoadAircraftFlights(Aircraft aircraft)
		/// <summary>
		/// Загружает все полеты воздушного судна
		/// </summary>
		public void LoadAircraftFlights(int aircraftId)
		{
			var atldIds = _newLoader.GetSelectColumnOnly<ATLBDTO>(new []{ new Filter("AircraftID", aircraftId) }, c => c.ItemId);

			if(atldIds.Count == 0)
				return;

			var flights = _newLoader.GetObjectList<AircraftFlightDTO,AircraftFlight>(new Filter("ATLBID", atldIds));

			if (flights.Count == 0)
				return;

			var flightsIds = flights.Select(f => f.ItemId).Distinct().ToArray();
			var runUps = _newLoader.GetObjectList<RunUpDTO, RunUp>(new Filter("FlightId", flightsIds));

			var engimeInRegimeRecords = _newLoader.GetObjectList<EngineTimeInRegimeDTO, EngineTimeInRegime>(new Filter("FlightId", flightsIds));

			var flightsCrsIds = flights.Select(f => f.CrsId).Distinct().ToArray();
			var crs = _newLoader.GetObjectList<CertificateOfReleaseToServiceDTO, CertificateOfReleaseToService>(new Filter("ItemId", flightsCrsIds));

			foreach (var flightRun in runUps)
				flightRun.BaseComponent = _componentCore.GetBaseComponentById(flightRun.BaseComponentId);

			foreach (var flightEwr in engimeInRegimeRecords)
				flightEwr.BaseComponent = _componentCore.GetBaseComponentById(flightEwr.BaseComponentId);

			foreach (var t in flights)
			{
				t.RunupsCollection.AddRange(runUps.Where(r => r.FlightId == t.ItemId).ToArray());
				t.PowerUnitTimeInRegimeCollection.AddRange(engimeInRegimeRecords.Where(r => r.FlightId == t.ItemId).ToArray());
				t.CertificateOfReleaseToService = crs.FirstOrDefault(service => service.ItemId == t.CrsId);
			}

			if (_flights.ContainsKey(aircraftId))
			{
				_flights[aircraftId].Clear();
				_flights[aircraftId].AddRange(flights);
			}
			else _flights.Add(aircraftId, new AircraftFlightCollection(flights.ToList()));
		}

		#endregion

		#region public void LoadAircraftFlightsLight(int aircraftId)

		public void LoadAircraftFlightsLight(int aircraftId)
		{
			var atldIds = _newLoader.GetSelectColumnOnly<ATLBDTO>(new []{ new Filter("AircraftID", aircraftId) }, c => c.ItemId);
			var flights = _newLoader.GetObjectList<AircraftFlightDTO, AircraftFlight>(new Filter("ATLBID", atldIds));

			if (_flights.ContainsKey(aircraftId))
			{
				_flights[aircraftId].Clear();
				_flights[aircraftId].AddRange(flights);
			}
			else _flights.Add(aircraftId, new AircraftFlightCollection(flights.ToList()));
		}

		#endregion

		#region public AircraftFlightCollection GetAircraftFlightsByAircraftId(int aircraftId)

		public AircraftFlightCollection GetAircraftFlightsByAircraftId(int aircraftId)
		{
			return getAircraftFlightsCollection(aircraftId);
		}

		#endregion

		public AircraftFlight GetFirstFlight(int atlbId)
		{
			var qr = BaseQueries.GetSelectQueryWithWhere(typeof(AircraftFlight), new []
			{
				new CommonFilter<int>(AircraftFlight.ATLBIdProperty, atlbId), 
			}).Replace("Select", "Select TOP(1)") + "order by FlightDate,OutTime";

			DataSet ds = _casEnvironment.Execute(qr);
			var result = BaseQueries.GetObjectList<AircraftFlight>(ds.Tables[0]);

			// возвращаем результат
			return result.FirstOrDefault();
		}

		public AircraftFlight GetLastFlight(int atlbId)
		{
			var qr = BaseQueries.GetSelectQueryWithWhere(typeof(AircraftFlight), new[]
			{
				new CommonFilter<int>(AircraftFlight.ATLBIdProperty, atlbId),
			}).Replace("Select", "Select TOP(1)") + "order by FlightDate Desc,OutTime Desc";

			DataSet ds = _casEnvironment.Execute(qr);
			var result = BaseQueries.GetObjectList<AircraftFlight>(ds.Tables[0]);

			// возвращаем результат
			return result.FirstOrDefault();
		}

		#region public AircraftFlight GetAircraftFlightById(int aircraftId, int aircraftFlightId)

		public AircraftFlight GetAircraftFlightById(int aircraftId, int aircraftFlightId)
		{
			return getAircraftFlightById(aircraftId, aircraftFlightId);
		}

		#endregion

		#region public AircraftFlight GetLastAircraftFlight(int aircraftId)

		public AircraftFlight GetLastAircraftFlight(int aircraftId)
		{
			return getLastAircraftFlight(aircraftId);
		}

		#endregion

		#region public IEnumerable<AircraftFlight> GetAircraftFlightsOnDate(int aircraftId, DateTime flightDate)

		public IEnumerable<AircraftFlight> GetAircraftFlightsOnDate(int aircraftId, DateTime flightDate)
		{
			return _flights.ContainsKey(aircraftId) ? _flights[aircraftId].GetFlights(flightDate) : null;
		}

		#endregion

		#region public AircraftFlightCollection GetFlightsByAtlb(params object[] parametres)

		public AircraftFlightCollection GetFlightsByAtlb(params object[] parametres)
		{
			if (parametres == null || parametres.Length < 2 || !(parametres[0] is int) || !(parametres[1] is int))
				return null;

			return GetFlightsByAtlb((int) parametres[0], (int) parametres[1]);

		}

		#endregion

		#region public List<AircraftFlight> GetFlightWithPageNum(int aircraftId, int pageNum, int atlbId)

		public List<AircraftFlight> GetFlightWithPageNum(int aircraftId, string pageNum, int atlbId)
		{
			var flights = getAircraftFlightsCollection(aircraftId);
			return flights.GetFlightWithPageNum(pageNum, atlbId);
		}

		#endregion

		#region public IList<ATLB> GetATLBsByAircraftId(int aircraftId, bool loadChild = false)

		public IList<ATLB> GetATLBsByAircraftId(int aircraftId, bool loadChild = false, bool onlyOpened = false)
		{
			var filter = new List<Filter>
			{
				new Filter("AircraftID", aircraftId),
				
			};
			if (onlyOpened)
				filter.Add(new Filter("AtlbStatus", 0));
			
			return _newLoader.GetObjectList<ATLBDTO,ATLB>(filter, loadChild);
		}

		#endregion

		#region private int GetAircraftFlightsCount(int aircraftId)

		private int GetAircraftFlightsCount(int aircraftId)
		{
			return _flights.ContainsKey(aircraftId) ? _flights[aircraftId].Count : 0;
		}

		#endregion

		#region private AircraftFlightCollection getAircraftFlightsCollectionByAircraftId(int aircraftId)

		private AircraftFlightCollection getAircraftFlightsCollection(int aircraftId)
		{
			if (_flights.ContainsKey(aircraftId))
				return _flights[aircraftId];

			var newCol = new AircraftFlightCollection();
			_flights.Add(aircraftId, newCol);
			return newCol;
		}

		#endregion

		#region private AircraftFlight getAircraftFlightById(int aircraftId, int aircraftFlightId)

		private AircraftFlight getAircraftFlightById(int aircraftId, int aircraftFlightId)
		{
			return _flights.ContainsKey(aircraftId) ? _flights[aircraftId].GetItemById(aircraftFlightId) : null;
		}

		#endregion

		#region private AircraftFlight getLastAircraftFlight(int aircraftId)

		private AircraftFlight getLastAircraftFlight(int aircraftId)
		{
			return _flights.ContainsKey(aircraftId) ? _flights[aircraftId].GetLast() : null;
		}

		#endregion

		private AircraftFlight getLastAircraftFlight(int aircraftId, int atlbId)
		{
			return _flights.ContainsKey(aircraftId) ? _flights[aircraftId].Where(i => i.ATLBId == atlbId).OrderBy(i => i.ItemId).LastOrDefault() ?? getLastAircraftFlight(aircraftId) : null;
		}

		#region private AircraftFlight loadFullAircraftFlightById(int flightId, Aircraft parentAircraft)
		/// <summary>
		/// Возвращает полностью загруженный полет со всеми его вложенными объектами
		/// </summary>
		/// <param name="flightId"></param>
		/// <param name="parentAircraftId"></param>
		/// <returns></returns>
		private AircraftFlight loadFullAircraftFlightById(int flightId, int parentAircraftId)
		{
			//создание нового AircrftFlight и заполнение//
			var existFlight = _newLoader.GetObject<AircraftFlightDTO, AircraftFlight>(new Filter("ItemId", flightId));
			if (existFlight == null)
				return null;

			#region//заполнение Discrepancies CorrectiveAction в Discrepancies нового полета//

			existFlight.Discrepancies.AddRange(_newLoader.GetObjectList<DiscrepancyDTO, Discrepancy>(new Filter("FlightID", flightId)));

			int[] defferedItemsIds = existFlight.Discrepancies
					.Where(i => i.DirectiveId > 0)
					.Select(i => i.DirectiveId)
					.ToArray();

			DirectiveCollection deffereds;
			if (defferedItemsIds.Length > 0)
			{
				var discrepanciesIdFilter = new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, defferedItemsIds);
				deffereds = _directiveCore.GetDeferredItems(filters: new[] { discrepanciesIdFilter });
			}
			else
			{
				deffereds = new DirectiveCollection();
			}

			/////////////////////////////////////////////////////////////
			foreach (Discrepancy t in existFlight.Discrepancies)
			{
				t.ParentFlight = existFlight;
				t.DeferredItem = deffereds.GetDirectiveById(t.DirectiveId) as DeferredItem;
				var qr = CorrectiveActionQueries.GetSelectQuery(t.ItemId);
				var ds = _casEnvironment.Execute(qr);
				t.CorrectiveActionCollection =
					CorrectiveActionQueries.GetCorrectiveActionCollection(ds.Tables[0]);

				if (t.CorrectiveAction.CRSID == 0)
					continue;

				t.CorrectiveAction.CertificateOfReleaseToService =
					_newLoader.GetObject<CertificateOfReleaseToServiceDTO,CertificateOfReleaseToService>(new Filter("ItemId",t.CorrectiveAction.CRSID), true);
			}
			#endregion

			#region //Поиск дефектов/отклонений, которые были созданы раньше этого полета и не были закрыты на данный полет

			deffereds.Clear();
			//(не имеющие статус Closed, не имеющие записей о выполнении
			//  или дата последнего выполения которых >= дате текущего полета при наличии статуса Closed)
			List<DbQuery> qrs = DeferredItemQueries.GetLastSelectQuery(parentAircraftId, existFlight, loadChild: true);
			deffereds.AddRange(_loader.GetObjectListAll<DeferredItem>(qrs, true).ToArray());

			int[] directivesId = deffereds
					.Where(i => i.Threshold != null
							 && i.Threshold.EffectiveDate <= existFlight.FlightDate)
					.Select(i => i.ItemId)
					.ToArray();

			//заполнение Discrepancies нового полета//
			//////////////////////////////////////////
			if (directivesId.Length > 0)
			{
				existFlight.UnclosedDiscrepancies = (CommonCollection<Discrepancy>) _newLoader.GetObjectList<DiscrepancyDTO,Discrepancy>(new Filter("DirectiveId", directivesId));

				//заполнение CorrectiveAction в Discrepancies нового полета//
				/////////////////////////////////////////////////////////////
				foreach (Discrepancy t in existFlight.UnclosedDiscrepancies)
				{
					//для незакрытых отклонений родительский полет отличается от текущего
					t.DeferredItem = (DeferredItem)deffereds.GetDirectiveById(t.DirectiveId);
					t.ParentFlight = getAircraftFlightById(parentAircraftId, t.FlightId);
					var qr = CorrectiveActionQueries.GetSelectQuery(t.ItemId);
					var ds = _casEnvironment.Execute(qr);
					t.CorrectiveActionCollection =
						CorrectiveActionQueries.GetCorrectiveActionCollection(ds.Tables[0]);

					if (t.CorrectiveAction.CRSID == 0) continue;

					//qr = BaseQueries.GetSelectQueryWithWhereById<CertificateOfReleaseToService>(t.CorrectiveAction.CRSID, true);
					//ds = _databaseManager.Execute(qr);
					//t.CorrectiveAction.CertificateOfReleaseToService =
					//    BaseQueries.GetObjectList<CertificateOfReleaseToService>(ds.Tables[0], true).FirstOrDefault();

					t.CorrectiveAction.CertificateOfReleaseToService =
						_newLoader.GetObject<CertificateOfReleaseToServiceDTO, CertificateOfReleaseToService>(new Filter("ItemId", t.CorrectiveAction.CRSID), true);
				}
			}
			else existFlight.UnclosedDiscrepancies = null;

			deffereds.Clear();

			#endregion

			//    Составление списка базовых агрегатов самолета, он необходим    //
			//для определения точного количества агрегатов самолета для заполения//
			//  формы полета и корректого редактироваия состояний этих агрегатов //
			///////////////////////////////////////////////////////////////////////
			var baseComponents = _componentCore.GetAicraftBaseComponents(parentAircraftId);

			#region //заполнение EngineConditions нового полета//
			/////////////////////////////////////////////

			existFlight.EngineConditionCollection.Clear();
			existFlight.EngineConditionCollection.AddRange(_newLoader.GetObjectList<EngineConditionDTO, EngineCondition>(new Filter("FlightID", flightId)));
			//////присоединение объекта BaseComponent к состоянию
			if (existFlight.EngineConditionCollection.Count != 0)
			{
				//в БД были записи по состояниям двигателей
				foreach (EngineCondition enginecondition in existFlight.EngineConditionCollection)
				{
					enginecondition.Engine = _componentCore.GetBaseComponentById(enginecondition.EngineId);
				}
			}
			else
			{
				//в БД НЕбыло записей по состояниям двигателей,
				//Считывание количества двигателей
				foreach (var t in baseComponents)
				{
					if (t.BaseComponentType == BaseComponentType.Engine)
					{
						EngineCondition newEngineCondition = new EngineCondition { Engine = t };
						existFlight.EngineConditionCollection.Add(newEngineCondition);
					}
				}
			}
			#endregion

			#region//заполнение LandingGearConditions нового полета//
			//////////////////////////////////////////////////
			existFlight.LandingGearConditions.Clear();
			existFlight.LandingGearConditions.AddRange(_newLoader.GetObjectList<LandingGearConditionDTO, LandingGearCondition>(new Filter("FlightID", flightId)));
			//////присоединение объекта BaseComponent к состоянию
			if (existFlight.LandingGearConditions.Count != 0)
			{
				//в БД были записи по состояниям шасси
				foreach (LandingGearCondition lgCondition in existFlight.LandingGearConditions)
				{
					lgCondition.LandingGear = _componentCore.GetBaseComponentById(lgCondition.LandingGearId);
				}
			}
			else
			{
				//в БД НЕбыло записей по состояниям шасси,
				//Считывание количества шасси самолета
				foreach (BaseComponent t in baseComponents)
				{
					if (t.BaseComponentType == BaseComponentType.LandingGear)
					{
						LandingGearCondition newLgCondition =
							new LandingGearCondition { LandingGear = t };
						existFlight.LandingGearConditions.Add(newLgCondition);
					}
				}
			}
			#endregion

			#region//заполнение ComponentOilConditions нового полета//
			//////////////////////////////////////////////////
			existFlight.OilConditionCollection.AddRange(_newLoader.GetObjectList<ComponentOilConditionDTO, ComponentOilCondition>(new Filter("FlightId", flightId)));

			if (existFlight.OilConditionCollection.Count != 0)
			{
				//в БД были записи по состояниям шасси
				foreach (ComponentOilCondition oilCondition in existFlight.OilConditionCollection)
				{
					oilCondition.BaseComponent = _componentCore.GetBaseComponentById(oilCondition.ComponentId);
				}
			}

			#endregion

			#region//заполнение HydraulicConditionCollection нового полета//
			//////////////////////////////////////////////////
			existFlight.HydraulicConditionCollection.AddRange(_newLoader.GetObjectList<HydraulicConditionDTO, HydraulicCondition>(new Filter("FlightId", flightId)));

			#endregion

			#region//заполнение RunupsCollection нового полета//
			//////////////////////////////////////////////////
			existFlight.RunupsCollection.Clear();
			existFlight.RunupsCollection.AddRange(_newLoader.GetObjectList<RunUpDTO, RunUp>(new Filter("FlightId", flightId)));
			if (existFlight.RunupsCollection.Count != 0)
			{
				//в БД были записи по состояниям шасси
				foreach (RunUp runUp in existFlight.RunupsCollection)
				{
					runUp.BaseComponent =
						_componentCore.GetBaseComponentById(runUp.BaseComponentId) ??
							   new BaseComponent
							   {
								   ItemId = runUp.BaseComponentId,
								   IsDeleted = true,
								   Description = "Can't Find Base Component with id = " + runUp.BaseComponentId,
								   PartNumber = "Unknown",
								   SerialNumber = "Unknown"
							   };
				}
			}

			#endregion

			#region//заполнение EngineTineInRegimeCollection нового полета//
			//////////////////////////////////////////////////
			existFlight.PowerUnitTimeInRegimeCollection.Clear();
			existFlight.PowerUnitTimeInRegimeCollection.AddRange(_newLoader.GetObjectList<EngineTimeInRegimeDTO, EngineTimeInRegime>(new Filter("FlightId", flightId)));
			if (existFlight.PowerUnitTimeInRegimeCollection.Count != 0)
			{
				//в БД были записи по состояниям шасси
				foreach (EngineTimeInRegime oilCondition in existFlight.PowerUnitTimeInRegimeCollection)
				{
					oilCondition.BaseComponent = _componentCore.GetBaseComponentById(oilCondition.BaseComponentId);
				}
			}

			#endregion

			#region//заполнение EngineAccelerationTimeCollection нового полета//
			//////////////////////////////////////////////////
			existFlight.EngineAccelerationTimeCollection.Clear();
			existFlight.EngineAccelerationTimeCollection.AddRange(_newLoader.GetObjectList<EngineAccelerationTimeDTO, EngineAccelerationTime>(new Filter("FlightId", flightId)));
			if (existFlight.EngineAccelerationTimeCollection.Count != 0)
			{
				//в БД были записи по состояниям шасси
				foreach (EngineAccelerationTime oilCondition in existFlight.EngineAccelerationTimeCollection)
				{
					oilCondition.BaseComponent = _componentCore.GetBaseComponentById(oilCondition.BaseComponentId);
				}
			}

			#endregion

			#region//заполнение CertificateOfReleaseToService нового полета//
			//////////////////////////////////////////////////////////

			existFlight.CertificateOfReleaseToService = _newLoader.GetObject<CertificateOfReleaseToServiceDTO, CertificateOfReleaseToService>(new Filter("ItemId", existFlight.CrsId), true);
			#endregion

			#region //Загрузка специалистов нового полета

			existFlight.FlightCrewRecords.Clear();
			existFlight.FlightCrewRecords.AddRange(_newLoader.GetObjectList<FlightCrewRecordDTO, FlightCrewRecord>(new Filter("FlightID", flightId), true));

			#endregion

			#region //Загрузка пассажиров нового полета

			existFlight.FlightPassengerRecords.Clear();
			existFlight.FlightPassengerRecords.AddRange(_newLoader.GetObjectList<FlightPassengerRecordDTO, FlightPassengerRecord>(new Filter("FlightId", flightId), true, true));
			#endregion

			#region //Загрузка груза нового полета

			existFlight.FlightCargoRecords.Clear();
			existFlight.FlightCargoRecords.AddRange(_newLoader.GetObjectList<FlightCargoRecordDTO, FlightCargoRecord>(new Filter("FlightId", flightId), true, true));

			#endregion

			#region //Загрузка событий системы безопасности полетов
			existFlight.Events.Clear();
			existFlight.Events.AddRange(_newLoader.GetObjectList<EventDTO, Event>(new List<Filter>()
			{
				new Filter("ParentId",flightId),
				new Filter("ParentTypeId",existFlight.SmartCoreObjectType.ItemId)
			}, true, true));

			#endregion
			var documents = _newLoader.GetObjectList<DocumentDTO, Document>(new List<Filter>()
			{
				new Filter("ParentID",flightId),
				new Filter("ParentTypeId",SmartCoreType.AircraftFlight.ItemId)
			},true);

			var doc = documents.FirstOrDefault();
			if (doc != null)
			{
				doc.Parent = existFlight;
				existFlight.Document = doc;
			}
			

			return existFlight;
		}

		#endregion

		#region private AircraftFlightCollection GetFlightsByAtlb(int aircraftId, int atlbId)

		private AircraftFlightCollection GetFlightsByAtlb(int aircraftId, int atlbId)
		{
			var flights = getAircraftFlightsCollection(aircraftId);
			return flights.GetFlightsByAtlb(atlbId);
		}

		#endregion


		public FlightNumber GetFlightNumberById(int itemId, bool loadChild)
		{
			var flightNumber = _newLoader.GetObject<FlightNumberDTO, FlightNumber>(new Filter("ItemId", itemId), loadChild);

			if (loadChild)
			{
				var preriodIds = flightNumber.FlightNumberPeriod.Select(f => f.ItemId).ToArray();
				var documents = _newLoader.GetObjectList<DocumentDTO, Document>(new List<Filter>()
				{
					new Filter("ParentTypeId",SmartCoreType.FlightNumberPeriod.ItemId),
					new Filter("ParentID",preriodIds)
				}, true);

				foreach (var period in flightNumber.FlightNumberPeriod)
				{
					var doc = documents.FirstOrDefault(d => d.ParentId == period.ItemId);
					if (doc != null)
					{
						doc.Parent = period;
						period.Document = doc;
					}
				}
			}
			return flightNumber;
		}

		public List<FlightNumber> GetAllFlightNumbers()
		{
			var flights = _newLoader.GetObjectList<FlightNumberDTO, FlightNumber>(loadChild: true);

			foreach (var flight in flights)
			{
				foreach (var period in flight.FlightNumberPeriod)
					period.FlightNum = flights.FirstOrDefault(f => f.ItemId == period.FlightNumberId);
			}

			return flights.ToList();
		}

	}
}