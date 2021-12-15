using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Calculations;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.NewLoader;

namespace SmartCore.Aircrafts
{
	public class AircraftsCore :IAircraftsCore
	{
		private readonly ILoader _loader;
		private readonly INewKeeper _newKeeper;
		private readonly INewLoader _newLoader;
		private ICommonCollection<Aircraft> _aircrafts;

		public AircraftsCore(ILoader loader, INewKeeper newKeeper, INewLoader newLoader)
		{
			_loader = loader;
			_newKeeper = newKeeper;
			_newLoader = newLoader;
			_aircrafts = new AircraftCollection();
		}

		public void LoadAllAircrafts()
		{
			if(_aircrafts.Count > 0)
				_aircrafts.Clear();

			_aircrafts.AddRange(_loader.GetObjectListAll<Aircraft>(loadChild:true));
		}

		public Aircraft GetAircraftById(int aircraftId)
		{
			return _aircrafts.GetItemById(aircraftId);
		}

		public IList<Aircraft> GetAllAircrafts()
		{
			return _aircrafts.GetValidEntries().ToList();
		}

		public int GetAircraftsCount()
		{
			return _aircrafts.Count;
		}

		public void RegisterAircraft(Aircraft aircraft, int operatorId)
		{
			if (operatorId <= 0) throw new Exception("1650: Can not add aircraft to not existing operator");

			// Сохраняем воздушное судно в базе 
			aircraft.OperatorId = operatorId;
			_newKeeper.Save(aircraft);

			_aircrafts.Add(aircraft);
		}

		//найти все юсаджи и заменить на использование AircraftCore (Delete и Update)
		public void DeleteAircraft(int aircraftId)
		{
			var deletedAircraft = _aircrafts.GetItemById(aircraftId);
			if(deletedAircraft == null) return;

			_newKeeper.Delete(deletedAircraft, true);
			_aircrafts.Remove(deletedAircraft);
		}

		public void UpdateAircraft(Aircraft aircraft)
		{
			if(aircraft == null) return;

			_newKeeper.Save(aircraft);

			var o = _aircrafts.GetItemById(aircraft.ItemId);
			if (o == null || aircraft.ItemId != o.ItemId)
				_aircrafts.Add(aircraft);
		}


		/// <summary>
		/// Пытается получить Aircraft для всех типов объектов
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public Aircraft GetParentAircraft(IBaseEntityObject item)
		{
			if (item == null)
				return null;

			IBaseEntityObject parent;
			if (item is NextPerformance)
			{
				parent = ((NextPerformance)item).Parent;
			}
			else if (item is AbstractPerformanceRecord)
			{
				parent = ((AbstractPerformanceRecord)item).Parent;
			}
			else parent = item;

			if (parent == null)
				return null;

			if (parent is ComponentDirective)
			{
				// ComponentDirective может ссылаться либо на BaseComponent либо на Component
				var componentDirective = parent as ComponentDirective;
				if (componentDirective.ParentComponent != null)
					return _aircrafts.GetItemById(componentDirective.ParentComponent.ParentAircraftId);
				throw new Exception($"0927: Parent object is not set to component directive {componentDirective.ItemId}");
			}
			if (parent is Directive)
			{
				// Directive может ссылаться либо на BaseComponent либо на Component
				var directive = parent as Directive;
				if (directive.ParentBaseComponent != null)
					return _aircrafts.GetItemById(directive.ParentBaseComponent.ParentAircraftId);
				throw new Exception($"1156: Parent object is not set to directive {directive.ItemId}");
			}
			if (parent is BaseComponent)
			{
				var baseComponent = parent as BaseComponent;
				return _aircrafts.GetItemById(baseComponent.ParentAircraftId);
			}
			if (parent is Entities.General.Accessory.Component)
			{
				var component = parent as Entities.General.Accessory.Component;
				return _aircrafts.GetItemById(component.ParentAircraftId);
			}
			if (parent is MaintenanceCheck)
			{
				// MaintenanceCheck может ссылаться либо на BaseComponent либо на Component
				var mc = parent as MaintenanceCheck;
				return _aircrafts.GetItemById(mc.ParentAircraftId);
			}
			if (parent is MaintenanceDirective)
			{
				// MaintenanceDirective может ссылаться либо на BaseComponent либо на Component
				var directive = parent as MaintenanceDirective;
				if (directive.ParentBaseComponent != null)
					return _aircrafts.GetItemById(directive.ParentBaseComponent.ParentAircraftId);
				throw new Exception($"1156: Parent object is not set to directive {directive.ItemId}");
			}
			return null;
		}

	}
}