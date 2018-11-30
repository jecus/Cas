using System;
using System.Collections.Generic;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Filters;

namespace SmartCore.Directives
{
	public interface IDirectiveCore
	{
		DirectiveCollection GetDirectives(params object[] parametres);
		DirectiveCollection GetDirectives(Aircraft parentAircraft, DirectiveType directiveType);
		DirectiveCollection GetDirectives(BaseComponent parentBaseComponent, DirectiveType directiveType);
		DirectiveCollection GetDeferredItems(params object[] parametres);
		DirectiveCollection GetDeferredItems(BaseComponent parentBaseComponent = null, Aircraft parentAircraft = null,
											 AircraftFlight parentFlight = null,
											 IEnumerable<ICommonFilter> filters = null);
		DirectiveCollection GetDamageItems(BaseComponent parentBaseComponent = null,
										   Aircraft parentAircraft = null,
										   ICommonFilter[] filters = null);

		IList<Directive> GetDirectivesList(int aircraftId, DirectiveType directiveType, IList<int> directiveIds, bool loadDeleted = false);
		Directive GetDirectiveById(Int32 itemId, DirectiveType directiveType, bool loadChild = true);

		IList<Directive> GetDirectivesByDirectiveType(int directiveTypeId);

		void AddDamageDocument(DamageDocument damageDocument);

		void AddDamageChart(DamageChart damageChart);

		void Save(Directive directive);

		void Delete(Directive directive);
	}
}